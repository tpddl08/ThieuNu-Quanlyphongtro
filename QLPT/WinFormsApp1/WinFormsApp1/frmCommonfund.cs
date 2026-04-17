using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            await LoadCurrentHouseAsync();

            if (currentHouse == null)
            {
                MessageBox.Show("Bạn chưa có phòng nên chưa thể xem quỹ chung.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            await LoadFundToDGV(currentHouse.Id);
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

        private async Task LoadFundToDGV(Guid houseId)
        {
            dgvCommonfund.Rows.Clear();

            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            // Lấy các khoản thuộc quỹ chung (category = "Quỹ chung")
            var expensesResp = await client
                .From<ExpensesData>()
                .Select("*")
                .Where(ex => ex.HouseId == houseId && ex.Category == "Quỹ chung")
                .Get();

            var expenses = expensesResp.Models.ToList();

            // Lấy profile của những người liên quan
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
                    var fixedDate = ex.ExpenseDate.Value.ToLocalTime();
                    row.Cells["colTime"].Value = fixedDate.ToString("dd/MM/yyyy");
                }
                else
                {
                    row.Cells["colTime"].Value = "";
                }

                bool isPaid = ex.IsPaid ?? false;

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

            // Nhập số điện thoại thành viên
            string phone = Interaction.InputBox(
                "Nhập số điện thoại thành viên đóng quỹ (để trống = bạn):",
                "Thêm khoản quỹ", "");

            // Nhập số tiền
            string amountText = Interaction.InputBox("Nhập số tiền (VD: 200000):", "Thêm khoản quỹ", "");
            if (string.IsNullOrWhiteSpace(amountText) ||
                !decimal.TryParse(amountText.Trim(), out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nhập ngày
            string dateText = Interaction.InputBox("Nhập ngày (dd/MM/yyyy):", "Thêm khoản quỹ",
                DateTime.Now.ToString("dd/MM/yyyy"));
            if (!DateTime.TryParseExact(dateText.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime expDate))
            {
                MessageBox.Show("Ngày không hợp lệ. Ví dụ đúng: 17/04/2026", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //string type = "INCOME";
            string typeLabel = "Chưa đóng";

            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            Guid paidById = currentUserId;
            string memberName = "";

            if (!string.IsNullOrWhiteSpace(phone))
            {
                var profileResp = await client
                    .From<ProfilesData>()
                    .Select("*")
                    .Where(p => p.Phone == phone)
                    .Get();

                if (!profileResp.Models.Any())
                {
                    MessageBox.Show("Không tìm thấy người dùng theo số điện thoại này.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var prof = profileResp.Models.First();

                var memberResp = await client
                    .From<HouseMembersData>()
                    .Select("*")
                    .Where(m => m.HouseId == currentHouse.Id && m.UserId == prof.Id && m.IsActive == true)
                    .Get();

                if (!memberResp.Models.Any())
                {
                    MessageBox.Show("Người này không phải thành viên đang ở trong phòng.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                paidById = prof.Id;
                memberName = prof.FullName ?? "";
            }
            else
            {
                var selfResp = await client
                    .From<ProfilesData>()
                    .Select("*")
                    .Where(p => p.Id == currentUserId)
                    .Get();

                memberName = selfResp.Models.FirstOrDefault()?.FullName ?? "";
            }

            int idx = dgvCommonfund.Rows.Add();
            var row = dgvCommonfund.Rows[idx];

            row.Cells["colExpenseId"].Value = "";
            row.Cells["colPaidById"].Value = paidById.ToString();
            row.Cells["colNamemem"].Value = memberName;
            row.Cells["colMoney"].Value = amount.ToString("N0") + " đ";
            row.Cells["colTime"].Value = expDate.ToString("dd/MM/yyyy");
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

                    // Xóa
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

                    // Parse tiền (bỏ " đ" và dấu phân cách)
                    string cleanMoney = moneyStr.Replace(" đ", "").Replace(",", "").Trim();
                    if (!decimal.TryParse(cleanMoney, out decimal amount))
                        amount = 0;

                    // Parse ngày -> UTC
                    if (!DateTime.TryParseExact(dateStr.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime expDate))
                        expDate = DateTime.Now.Date;

                    expDate = expDate.Date;

                    // Xác định type
                    string type = "INCOME";

                    Guid? paidBy = null;
                    if (Guid.TryParse(paidByIdStr, out Guid parsedPaid) && parsedPaid != Guid.Empty)
                        paidBy = parsedPaid;
                    else
                        paidBy = currentUserId;

                    // Thêm mới
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
                    // Cập nhật
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