using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Postgrest.Constants;

namespace ThieunuQLPT
{
    public partial class frmDetail : Form
    {
        private string _houseId = "";
        private string _invoiceId = "";
        private HousesData? _house;
        private int _totalMembers = 0;
        private int _daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        private List<HouseMembersData> _allMembers = new();

        public frmDetail(string houseId, string invoiceId)
        {
            InitializeComponent();
            _houseId = houseId;
            _invoiceId = invoiceId;
            this.Load += frmDetail_Load;
        }

        private async void frmDetail_Load(object? sender, EventArgs e)
        {
            dgvSplitBill.AllowUserToAddRows = false;
            dgvSplitBill.EditMode = DataGridViewEditMode.EditOnKeystroke;
            dgvSplitBill.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSplitBill.MultiSelect = false;

            // Chỉ cho sửa cột colNumabsent
            foreach (DataGridViewColumn col in dgvSplitBill.Columns)
                col.ReadOnly = true;
            dgvSplitBill.Columns["colNumabsent"].ReadOnly = false;

            dgvSplitBill.CellEndEdit += dgvSplitBill_CellEndEdit;

            if (string.IsNullOrEmpty(_houseId))
            {
                MessageBox.Show("Thiếu houseId!");
                return;
            }

            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                var client = await SupabaseHelper.GetClientAsync();
                if (client == null) return;

                if (!Guid.TryParse(_houseId, out Guid houseGuid)) return;
                if (!Guid.TryParse(_invoiceId, out Guid invoiceGuid)) return;

                // Lấy thông tin phòng
                var houseResp = await client
                    .From<HousesData>()
                    .Select("*")
                    .Where(h => h.Id == houseGuid)
                    .Get();

                _house = houseResp.Models.FirstOrDefault();
                if (_house == null) return;

                // Lấy danh sách members đang ở
                var membersResp = await client
                    .From<HouseMembersData>()
                    .Select("*")
                    .Where(m => m.HouseId == houseGuid && m.IsActive == true)
                    .Get();

                _allMembers = membersResp.Models;
                _totalMembers = _allMembers.Count;

                if (_totalMembers == 0)
                {
                    MessageBox.Show("Nhà này chưa có thành viên nào!");
                    return;
                }

                // Lấy danh sách đã đóng tiền theo invoiceId
                var paymentsResp = await client
                    .From<InvoicePaymentsData>()
                    .Select("*")
                    .Where(p => p.InvoiceId == invoiceGuid)
                    .Get();

                var paidUserIds = paymentsResp.Models
                    .Where(p => p.UserId.HasValue && p.Status == "paid")
                    .Select(p => p.UserId!.Value)
                    .ToHashSet();

                // Lấy profile của tất cả thành viên
                var userIds = _allMembers.Select(m => m.UserId).ToList();
                var profilesResp = await client
                    .From<ProfilesData>()
                    .Select("*")
                    .Filter(p => p.Id, Operator.In, userIds)
                    .Get();

                var profileDict = profilesResp.Models.ToDictionary(p => p.Id, p => p);

                // Tính totalRatio từ dữ liệu gốc trước khi add row
                decimal totalRatio = CalcTotalRatio(_allMembers);

                dgvSplitBill.Rows.Clear();

                foreach (var m in _allMembers)
                {
                    var prof = profileDict.GetValueOrDefault(m.UserId);

                    int idx = dgvSplitBill.Rows.Add();
                    var row = dgvSplitBill.Rows[idx];

                    row.Tag = m;

                    int numAbsent = m.NumAbsent ?? 0;
                    bool isPaid = paidUserIds.Contains(m.UserId);

                    row.Cells["colUsername"].Value = prof?.FullName ?? "Không tên";
                    row.Cells["colNumabsent"].Value = numAbsent;
                    row.Cells["colIspaid"].Value = isPaid ? "Đã đóng" : "Chưa đóng";

                    if (isPaid)
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;

                    // Truyền totalRatio đã tính sẵn để tránh tính sai khi row chưa đủ
                    CalculateAndFillRow(row, numAbsent, totalRatio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }

        // Tính tổng tỉ lệ có mặt từ danh sách thành viên
        private decimal CalcTotalRatio(List<HouseMembersData> members)
        {
            return members.Sum(m =>
            {
                int absent = Math.Max(0, Math.Min(m.NumAbsent ?? 0, _daysInMonth));
                return (_daysInMonth - absent) / (decimal)_daysInMonth;
            });
        }

        // Tính tổng tỉ lệ có mặt từ UI (dùng khi người dùng sửa số ngày vắng)
        private decimal CalcTotalRatioFromUI()
        {
            decimal total = 0;
            foreach (DataGridViewRow r in dgvSplitBill.Rows)
            {
                if (r.IsNewRow) continue;
                int absent = int.TryParse(r.Cells["colNumabsent"].Value?.ToString(), out int a) ? a : 0;
                absent = Math.Max(0, Math.Min(absent, _daysInMonth));
                total += (_daysInMonth - absent) / (decimal)_daysInMonth;
            }
            return total;
        }

        private void CalculateAndFillRow(DataGridViewRow row, int numAbsent, decimal totalRatio)
        {
            if (_house == null || _totalMembers == 0 || totalRatio == 0) return;

            int oldNums = _house.OldNumber ?? 0;
            int newNums = _house.NewNumber ?? 0;
            decimal electricRate = _house.ElectricityRate ?? 4000;
            decimal waterRate = _house.WaterRate ?? 100000;
            decimal priceRent = _house.PriceRent ?? 0;
            decimal serviceRate = _house.ServiceRate ?? 0;

            // Tỉ lệ có mặt của người này
            int absentClamped = Math.Max(0, Math.Min(numAbsent, _daysInMonth));
            decimal myRatio = (_daysInMonth - absentClamped) / (decimal)_daysInMonth;

            // Tổng tiền điện và nước
            decimal totalElectric = (newNums - oldNums) * electricRate;
            decimal totalWater = waterRate * _totalMembers;

            // Chia theo tỉ lệ có mặt — tổng thu luôn đủ
            decimal electricPerPerson = totalElectric * (myRatio / totalRatio);
            decimal waterPerPerson = totalWater * (myRatio / totalRatio);

            // Thuê và dịch vụ chia đều, không tính ngày vắng
            decimal rentPerPerson = priceRent / _totalMembers;
            decimal servicePerPerson = serviceRate / _totalMembers;

            row.Cells["colElectric"].Value = electricPerPerson.ToString("N0") + " đ";
            row.Cells["colWater"].Value = waterPerPerson.ToString("N0") + " đ";
            row.Cells["colRent"].Value = rentPerPerson.ToString("N0") + " đ";
            row.Cells["colService"].Value = servicePerPerson.ToString("N0") + " đ";
        }

        private void dgvSplitBill_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (dgvSplitBill.Columns[e.ColumnIndex].Name != "colNumabsent") return;

            var row = dgvSplitBill.Rows[e.RowIndex];

            if (!int.TryParse(row.Cells["colNumabsent"].Value?.ToString(), out int numAbsent))
                numAbsent = 0;

            numAbsent = Math.Max(0, Math.Min(numAbsent, _daysInMonth));
            row.Cells["colNumabsent"].Value = numAbsent;

            // Tính lại totalRatio từ UI sau khi người dùng sửa
            decimal totalRatio = CalcTotalRatioFromUI();

            // Tính lại tiền cho tất cả các row vì totalRatio đã thay đổi
            foreach (DataGridViewRow r in dgvSplitBill.Rows)
            {
                if (r.IsNewRow) continue;
                int absent = int.TryParse(r.Cells["colNumabsent"].Value?.ToString(), out int a) ? a : 0;
                CalculateAndFillRow(r, absent, totalRatio);
            }
        }

        // Chỉ cập nhật UI, chưa lưu DB
        private void btnPaid_Click(object sender, EventArgs e)
        {
            if (dgvSplitBill.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một thành viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvSplitBill.CurrentRow;

            if (row.Cells["colIspaid"].Value?.ToString() == "Đã đóng")
            {
                MessageBox.Show("Thành viên này đã đóng tiền rồi!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            row.Cells["colIspaid"].Value = "Đã đóng";
            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
        }

        // Lưu tất cả vào DB: số ngày vắng + trạng thái đóng tiền
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var client = await SupabaseHelper.GetClientAsync();
                if (client == null) return;

                if (!Guid.TryParse(_invoiceId, out Guid invoiceGuid)) return;

                foreach (DataGridViewRow row in dgvSplitBill.Rows)
                {
                    if (row.IsNewRow) continue;

                    var member = row.Tag as HouseMembersData;
                    if (member == null) continue;

                    // Lưu số ngày vắng vào house_members
                    if (!int.TryParse(row.Cells["colNumabsent"].Value?.ToString(), out int numAbsent))
                        numAbsent = 0;

                    member.NumAbsent = numAbsent;
                    await client.From<HouseMembersData>().Update(member);

                    // Lấy trạng thái đóng tiền từ UI
                    bool isPaid = row.Cells["colIspaid"].Value?.ToString() == "Đã đóng";

                    // Tính tổng tiền từ các cột trong row
                    decimal electric = decimal.TryParse(
                        row.Cells["colElectric"].Value?.ToString()?.Replace(" đ", "").Replace(",", ""),
                        out decimal e1) ? e1 : 0;
                    decimal water = decimal.TryParse(
                        row.Cells["colWater"].Value?.ToString()?.Replace(" đ", "").Replace(",", ""),
                        out decimal w1) ? w1 : 0;
                    decimal rent = decimal.TryParse(
                        row.Cells["colRent"].Value?.ToString()?.Replace(" đ", "").Replace(",", ""),
                        out decimal r1) ? r1 : 0;
                    decimal service = decimal.TryParse(
                        row.Cells["colService"].Value?.ToString()?.Replace(" đ", "").Replace(",", ""),
                        out decimal s1) ? s1 : 0;

                    decimal totalAmount = electric + water + rent + service;

                    // Tìm bản ghi có sẵn trong invoice_payments
                    var paymentResp = await client
                        .From<InvoicePaymentsData>()
                        .Select("*")
                        .Filter("invoice_id", Operator.Equals, invoiceGuid.ToString())
                        .Filter("user_id", Operator.Equals, member.UserId.ToString())
                        .Get();

                    var payment = paymentResp.Models.FirstOrDefault();

                    if (payment != null)
                    {
                        // Update bản ghi có sẵn
                        payment.Amount = totalAmount;
                        payment.PaidAt = isPaid ? DateTime.Now : null;
                        payment.Status = isPaid ? "paid" : "unpaid";
                        await client.From<InvoicePaymentsData>().Update(payment);
                    }
                    else
                    {
                        // Không có thì insert mới (fallback)
                        await client.From<InvoicePaymentsData>().Insert(new InvoicePaymentsData
                        {
                            InvoiceId = invoiceGuid,
                            UserId = member.UserId,
                            Amount = isPaid ? totalAmount : null,
                            PaidAt = isPaid ? DateTime.Now : null,
                            Status = isPaid ? "paid" : "unpaid"
                        });
                    }
                }

                MessageBox.Show("Đã lưu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }
    }
}