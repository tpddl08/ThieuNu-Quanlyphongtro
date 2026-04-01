using System;
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

                _totalMembers = membersResp.Models.Count;
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
                    .Where(p => p.UserId.HasValue)
                    .Select(p => p.UserId!.Value)
                    .ToHashSet();

                // Lấy profile của tất cả thành viên
                var userIds = membersResp.Models.Select(m => m.UserId).ToList();
                var profilesResp = await client
                    .From<ProfilesData>()
                    .Select("*")
                    .Filter(p => p.Id, Operator.In, userIds)
                    .Get();

                var profileDict = profilesResp.Models.ToDictionary(p => p.Id, p => p);

                dgvSplitBill.Rows.Clear();

                foreach (var m in membersResp.Models)
                {
                    var prof = profileDict.GetValueOrDefault(m.UserId);

                    int idx = dgvSplitBill.Rows.Add();
                    var row = dgvSplitBill.Rows[idx];

                    row.Tag = m;

                    int numAbsent = m.NumAbsent ?? 0;

                    // Kiểm tra đã đóng tiền theo invoice_payments
                    bool isPaid = paidUserIds.Contains(m.UserId);

                    row.Cells["colUsername"].Value = prof?.FullName ?? "Không tên";
                    row.Cells["colNumabsent"].Value = numAbsent;
                    row.Cells["colIspaid"].Value = isPaid ? "Đã đóng" : "Chưa đóng";

                    if (isPaid)
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;

                    CalculateAndFillRow(row, numAbsent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }

        private void CalculateAndFillRow(DataGridViewRow row, int numAbsent)
        {
            if (_house == null || _totalMembers == 0) return;

            int oldNums = _house.OldNumber ?? 0;
            int newNums = _house.NewNumber ?? 0;
            decimal electricRate = _house.ElectricityRate ?? 4000;
            decimal waterRate = _house.WaterRate ?? 100000;
            decimal priceRent = _house.PriceRent ?? 0;
            decimal serviceRate = _house.ServiceRate ?? 0;

            // Tỉ lệ có mặt của người này
            int absent = Math.Max(0, Math.Min(numAbsent, _daysInMonth));
            decimal ratio = (_daysInMonth - absent) / (decimal)_daysInMonth;

            // Điện/nước tính theo tỉ lệ có mặt
            decimal electricPerPerson = (newNums - oldNums) * electricRate / _totalMembers * ratio;
            decimal waterPerPerson = waterRate * ratio;

            // Tiền thuê và dịch vụ chia đều không đổi
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

            // Giới hạn hợp lệ
            numAbsent = Math.Max(0, Math.Min(numAbsent, _daysInMonth));
            row.Cells["colNumabsent"].Value = numAbsent;

            // Tính lại tiền ngay khi sửa số ngày vắng
            CalculateAndFillRow(row, numAbsent);
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var client = await SupabaseHelper.GetClientAsync();
                if (client == null) return;

                foreach (DataGridViewRow row in dgvSplitBill.Rows)
                {
                    if (row.IsNewRow) continue;

                    var member = row.Tag as HouseMembersData;
                    if (member == null) continue;

                    if (!int.TryParse(row.Cells["colNumabsent"].Value?.ToString(), out int numAbsent))
                        numAbsent = 0;

                    member.NumAbsent = numAbsent;
                    await client.From<HouseMembersData>().Update(member);
                }

                MessageBox.Show("Đã lưu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private async void btnPaid_Click(object sender, EventArgs e)
        {
            if (dgvSplitBill.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một thành viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var client = await SupabaseHelper.GetClientAsync();
                if (client == null) return;

                var row = dgvSplitBill.CurrentRow;
                var member = row.Tag as HouseMembersData;
                if (member == null) return;

                if (!Guid.TryParse(_invoiceId, out Guid invoiceGuid)) return;

                // Kiểm tra đã đóng chưa
                var existResp = await client
                    .From<InvoicePaymentsData>()
                    .Select("*")
                    .Where(p => p.InvoiceId == invoiceGuid && p.UserId == member.UserId)
                    .Get();

                if (existResp.Models.Any())
                {
                    MessageBox.Show("Thành viên này đã đóng tiền hóa đơn này rồi!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tính tổng tiền của người này
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

                // Lưu vào invoice_payments
                var payment = new InvoicePaymentsData
                {
                    InvoiceId = invoiceGuid,
                    UserId = member.UserId,
                    Amount = totalAmount,
                    PaidAt = DateTime.Now,
                    Status = "paid"
                };
                await client.From<InvoicePaymentsData>().Insert(payment);

                row.Cells["colIspaid"].Value = "Đã đóng";
                row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;

                MessageBox.Show("Đã đánh dấu đóng tiền!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}