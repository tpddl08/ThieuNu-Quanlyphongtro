using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supabase;
using static Supabase.Postgrest.Constants;

namespace ThieunuQLPT
{
    public partial class frmListExpense : Form
    {
        private string _houseId = "";


        public frmListExpense(string houseId)
        {
            InitializeComponent();
            dgvExpenses.AllowUserToAddRows = false;
            dgvExpenses.ReadOnly = true;
            _houseId = houseId;
            this.Load += frmListExpense_Load;
        }

        private async void frmListExpense_Load(object? sender, EventArgs e)
        {
            dgvExpenses.AllowUserToAddRows = false;
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.MultiSelect = false;

            await LoadExpenses();
        }

        private async Task LoadFundBalance(Guid houseId)
        {
            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            var resp = await client
                .From<ExpensesData>()
                .Select("*")
                .Where(x => x.HouseId == houseId && x.Category == "Quỹ chung")
                .Get();

            decimal total = resp.Models.Sum(x =>
            {
                decimal amount = x.Amount ?? 0;

                if (x.Type == "INCOME") return amount;
                if (x.Type == "EXPENSE") return -amount;

                return 0;
            });

            lblFundhave.Text = $"Quỹ còn: {total:N0} đ";
        }

        private async Task LoadExpenses()
        {
            try
            {
                var client = await SupabaseHelper.GetClientAsync();
                if (client == null) return;

                Guid houseGuid;
                if (!Guid.TryParse(_houseId, out houseGuid) || houseGuid == Guid.Empty)
                {
                    // Nếu không có houseId hợp lệ, thử lấy phòng hiện tại của user đang đăng nhập
                    var currentUser = frmLogin.idLoged;
                    if (currentUser == Guid.Empty)
                    {
                        MessageBox.Show("HouseId không hợp lệ và không có user đã đăng nhập!");
                        return;
                    }

                    var memberResp = await client
                        .From<HouseMembersData>()
                        .Select("*")
                        .Where(m => m.UserId == currentUser && m.IsActive == true)
                        .Get();

                    if (!memberResp.Models.Any())
                    {
                        MessageBox.Show("Không tìm thấy phòng cho người dùng này.");
                        return;
                    }

                    var currentMember = memberResp.Models.OrderByDescending(m => m.JoinedAt).First();                    
                    houseGuid = currentMember.HouseId;
                }

                // Lấy expenses
                var resp = await client
                    .From<ExpensesData>()
                    .Select("*")
                    .Where(x => x.HouseId == houseGuid && x.Type == "EXPENSE")
                    .Get();

                var expenses = resp.Models;

                // Lấy userId list
                var userIds = expenses
                    .Where(x => x.PaidBy.HasValue)
                    .Select(x => x.PaidBy!.Value)
                    .Distinct()
                    .ToList();

                // Lấy profile để hiện tên
                var profileResp = await client
                    .From<ProfilesData>()
                    .Select("*")
                    .Filter("id", Operator.In, userIds.Select(x => x.ToString()).ToList())
                    .Get();

                var profileDict = profileResp.Models.ToDictionary(p => p.Id, p => p);

                dgvExpenses.Rows.Clear();

                await LoadFundBalance(houseGuid);

                foreach (var e in expenses.OrderByDescending(x => x.ExpenseDate))
                {
                    int idx = dgvExpenses.Rows.Add();
                    var row = dgvExpenses.Rows[idx];

                    row.Cells["date"].Value = e.ExpenseDate?.ToString("dd/MM/yyyy");
                    row.Cells["title"].Value = e.Title;
                    row.Cells["amount"].Value = (e.Amount ?? 0).ToString("N0") + " đ";

                    var name = "Không rõ";
                    if (e.PaidBy.HasValue && profileDict.ContainsKey(e.PaidBy.Value))
                    {
                        name = profileDict[e.PaidBy.Value].FullName;
                    }

                    row.Cells["name"].Value = name;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            frmExpenses f = new frmExpenses(_houseId, frmLogin.idLoged.ToString());
            f.ShowDialog();

            await LoadExpenses();
        }
    }
}
