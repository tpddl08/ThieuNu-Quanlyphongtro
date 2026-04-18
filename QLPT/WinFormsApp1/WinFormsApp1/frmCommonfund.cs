using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supabase;
using Microsoft.VisualBasic;

namespace ThieunuQLPT
{
    public partial class frmCommonfund : Form
    {
        private HousesData? currentHouse;
        private Guid currentUserId = frmLogin.idLoged;

        public frmCommonfund()
        {
            InitializeComponent();
        }

        private async void frmCommonfund_Load(object sender, EventArgs e)
        {
            EnsureHiddenColumns();

            if (dgvCommonfund.Columns.Contains("colTime"))
                dgvCommonfund.Columns["colTime"].ValueType = typeof(string);

            await LoadCurrentHouseAsync();

            if (currentHouse == null)
            {
                MessageBox.Show("Bạn chưa có phòng nên chưa thể xem quỹ chung.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblFundhave.Text = "Quỹ còn: 0 đ";
                return;
            }

            await LoadFundToDGV(currentHouse.Id);
            await UpdateFundHaveAsync(currentHouse.Id);
        }

        private void EnsureHiddenColumns()
        {
            if (!dgvCommonfund.Columns.Contains("colExpenseId"))
            {
                dgvCommonfund.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colExpenseId",
                    Visible = false
                });
            }

            if (!dgvCommonfund.Columns.Contains("colPaidById"))
            {
                dgvCommonfund.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colPaidById",
                    Visible = false
                });
            }
        }

        private async Task LoadCurrentHouseAsync()
        {
            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            var memberResponse = await client
                .From<HouseMembersData>()
                .Select("*")
                .Where(m => m.UserId == currentUserId && m.IsActive == true)
                .Get();

            if (!memberResponse.Models.Any())
            {
                currentHouse = null;
                return;
            }

            var currentMember = memberResponse.Models
                .OrderByDescending(m => m.JoinedAt)
                .First();

            var houseResponse = await client
                .From<HousesData>()
                .Select("*")
                .Where(h => h.Id == currentMember.HouseId)
                .Get();

            currentHouse = houseResponse.Models.FirstOrDefault();
        }

        private async Task UpdateFundHaveAsync(Guid houseId)
        {
            var client = await SupabaseHelper.GetClientAsync();
            if (client == null)
            {
                lblFundhave.Text = "Quỹ còn: 0 đ";
                return;
            }

            var resp = await client
                .From<ExpensesData>()
                .Select("*")
                .Where(x => x.HouseId == houseId && x.Category == "Quỹ chung")
                .Get();

            decimal balance = resp.Models.Sum(x =>
            {
                decimal amount = x.Amount ?? 0;

                if (x.Type == "INCOME")
                    return amount;

                if (x.Type == "EXPENSE")
                    return -amount;

                return 0;
            });

            lblFundhave.Text = $"Quỹ còn: {balance:N0} đ";
        }

        private async Task LoadFundToDGV(Guid houseId)
        {
            dgvCommonfund.Rows.Clear();

            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            var expensesResp = await client
                    .From<ExpensesData>()
                    .Select("*")
                    .Where(ex => ex.HouseId == houseId)
                    .Where(ex => ex.Category == "Quỹ chung")
                    .Where(ex => ex.Type == "INCOME") // 🔥 thêm dòng này
                    .Get();

            var expenses = expensesResp.Models.ToList();

            var userIds = expenses
                .Where(ex => ex.PaidBy.HasValue)
                .Select(ex => ex.PaidBy!.Value)
                .Distinct()
                .ToList();

            var profilesList = new List<ProfilesData>();
            foreach (var uid in userIds)
            {
                var pr = await client
                    .From<ProfilesData>()
                    .Select("*")
                    .Where(p => p.Id == uid)
                    .Get();

                if (pr.Models.Any())
                    profilesList.Add(pr.Models.First());
            }

            foreach (var ex in expenses)
            {
                var prof = ex.PaidBy.HasValue
                    ? profilesList.FirstOrDefault(p => p.Id == ex.PaidBy.Value)
                    : null;

                int idx = dgvCommonfund.Rows.Add();
                var row = dgvCommonfund.Rows[idx];

                row.Cells["colExpenseId"].Value = ex.Id.ToString();
                row.Cells["colPaidById"].Value = ex.PaidBy?.ToString() ?? "";
                row.Cells["colNamemem"].Value = prof?.FullName ?? "";

                row.Cells["colMoney"].Value = ex.Amount.HasValue
                    ? ex.Amount.Value.ToString("N0") + " đ"
                    : "0 đ";

                if (ex.ExpenseDate.HasValue)
                {
                    var utc = DateTime.SpecifyKind(ex.ExpenseDate.Value, DateTimeKind.Utc);
                    var vnTime = utc.ToLocalTime();
                    row.Cells["colTime"].Value = vnTime.ToString("dd/MM/yyyy HH:mm");
                }
                else
                {
                    row.Cells["colTime"].Value = "";
                }

                bool isPaid = ex.IsPaid == true;

                row.Cells["colStatus"].Value = isPaid ? "Đã đóng" : "Chưa đóng";

                row.DefaultCellStyle.BackColor = isPaid
                    ? Color.LightGreen
                    : Color.LightPink;

                row.Tag = null;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (currentHouse == null)
            {
                MessageBox.Show("Bạn chưa có phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           

            string amountText = Interaction.InputBox(
                "Nhập số tiền (VD: 200000):",
                "Thêm khoản quỹ", "");

            if (string.IsNullOrWhiteSpace(amountText) ||
                !decimal.TryParse(amountText.Trim(), out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dateText = Interaction.InputBox(
                "Nhập ngày giờ (dd/MM/yyyy HH:mm):",
                "Thêm khoản quỹ",
                DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

            if (!DateTime.TryParseExact(dateText.Trim(), "dd/MM/yyyy HH:mm",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate))
            {
                MessageBox.Show("Ngày không hợp lệ. Ví dụ đúng: 17/04/2026 08:30", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string typeLabel = "Chưa đóng";

            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            Guid paidById = currentUserId;
            string memberName = "";

           
            var selfResp = await client
                .From<ProfilesData>()
                .Select("*")
                .Where(p => p.Id == currentUserId)
                .Get();

            memberName = selfResp.Models.FirstOrDefault()?.FullName ?? "";

            
            

            int idx = dgvCommonfund.Rows.Add();
            var row = dgvCommonfund.Rows[idx];

            row.Cells["colExpenseId"].Value = "";
            row.Cells["colPaidById"].Value = paidById.ToString();
            row.Cells["colNamemem"].Value = memberName;
            row.Cells["colMoney"].Value = amount.ToString("N0") + " đ";
            row.Cells["colTime"].Value = expDate.ToString("dd/MM/yyyy HH:mm");
            row.Cells["colStatus"].Value = typeLabel;

            row.Tag = "add";
            row.DefaultCellStyle.BackColor = Color.LightYellow;

            MessageBox.Show("Đã thêm khoản quỹ tạm. Nhấn Lưu để ghi xuống database.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCommonfund.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvCommonfund.CurrentRow;
            row.Tag = "delete";
            row.DefaultCellStyle.BackColor = Color.LightGray;
            row.Cells["colStatus"].Value = "Đã xóa trên giao diện";

            MessageBox.Show("Đã đánh dấu xóa. Nhấn Lưu để xác nhận.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (dgvCommonfund.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvCommonfund.CurrentRow;
            row.Cells["colStatus"].Value = "Đã đóng";
            row.DefaultCellStyle.BackColor = Color.LightGreen;

            if ((row.Tag as string) != "add")
                row.Tag = "edit";

            MessageBox.Show("Đã đánh dấu đã đóng quỹ. Nhấn Lưu để cập nhật database.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (currentHouse == null)
            {
                MessageBox.Show("Bạn chưa có phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            try
            {
                foreach (DataGridViewRow row in dgvCommonfund.Rows)
                {
                    if (row.IsNewRow) continue;

                    string tag = row.Tag as string ?? "";
                    if (string.IsNullOrEmpty(tag)) continue;

                    string expenseIdStr = row.Cells["colExpenseId"].Value?.ToString() ?? "";
                    string paidByIdStr = row.Cells["colPaidById"].Value?.ToString() ?? "";
                    string moneyStr = row.Cells["colMoney"].Value?.ToString() ?? "0";
                    string dateStr = row.Cells["colTime"].Value?.ToString() ?? "";
                    string status = row.Cells["colStatus"].Value?.ToString() ?? "";
                    bool isPaid = status == "Đã đóng";

                    if (tag == "delete")
                    {
                        if (Guid.TryParse(expenseIdStr, out Guid expId) && expId != Guid.Empty)
                        {
                            await client
                                .From<ExpensesData>()
                                .Where(ex => ex.Id == expId)
                                .Delete();
                        }
                        continue;
                    }

                    string cleanMoney = moneyStr.Replace(" đ", "").Replace(",", "").Trim();
                    if (!decimal.TryParse(cleanMoney, out decimal amount))
                        amount = 0;

                    if (!DateTime.TryParseExact(dateStr.Trim(), "dd/MM/yyyy HH:mm",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate))
                    {
                        expDate = DateTime.Now;
                    }

                    expDate = DateTime.SpecifyKind(expDate, DateTimeKind.Local).ToUniversalTime();

                    string type = "INCOME";

                    Guid? paidBy = null;
                    if (Guid.TryParse(paidByIdStr, out Guid parsedPaid) && parsedPaid != Guid.Empty)
                        paidBy = parsedPaid;
                    else
                        paidBy = currentUserId;

                    if (string.IsNullOrWhiteSpace(expenseIdStr))
                    {
                        var newExp = new ExpensesData
                        {
                            HouseId = currentHouse.Id,
                            Title = "Quỹ chung",
                            Amount = amount,
                            PaidBy = paidBy,
                            ExpenseDate = expDate,
                            Category = "Quỹ chung",
                            Type = type,
                            IsPaid = isPaid,
                            Note = ""
                        };

                        await client.From<ExpensesData>().Insert(newExp);
                        row.Tag = null;
                    }
                    else if (Guid.TryParse(expenseIdStr, out Guid existingId) && existingId != Guid.Empty)
                    {
                        var resp = await client
                            .From<ExpensesData>()
                            .Select("*")
                            .Where(ex => ex.Id == existingId)
                            .Get();

                        var existing = resp.Models.FirstOrDefault();
                        if (existing != null)
                        {
                            existing.Amount = amount;
                            existing.PaidBy = paidBy;
                            existing.ExpenseDate = expDate;
                            existing.Type = type;
                            existing.IsPaid = isPaid;

                            await client.From<ExpensesData>().Update(existing);
                        }

                        row.Tag = null;
                    }
                }

                MessageBox.Show("Đã lưu thay đổi quỹ chung!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadFundToDGV(currentHouse.Id);
                await UpdateFundHaveAsync(currentHouse.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu quỹ chung: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            string houseId = "";
            var frm = new frmListExpense(houseId);
            frm.ShowDialog();
        }
    }
}