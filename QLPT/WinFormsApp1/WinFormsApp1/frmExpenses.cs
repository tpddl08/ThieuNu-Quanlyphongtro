using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThieunuQLPT.Models;
using static Supabase.Postgrest.Constants;


namespace ThieunuQLPT
{
    public partial class frmExpenses : Form
    {
        private string _houseId = "";
        private string _userId = ""; 


        public frmExpenses(string houseId, string userId)
        {
            InitializeComponent();
            _houseId = houseId;
            _userId = userId;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Vui lòng nhập nội dung!");
                    return;
                }

                if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
                {
                    MessageBox.Show("Số tiền không hợp lệ!");
                    return;
                }

                
                var client = await SupabaseHelper.GetClientAsync();
                if (client == null) return;

                // Resolve user id
                Guid userGuid;
                if (!Guid.TryParse(_userId, out userGuid) || userGuid == Guid.Empty)
                {
                    // fallback to logged in user
                    userGuid = frmLogin.idLoged;
                }

                if (userGuid == Guid.Empty)
                {
                    MessageBox.Show("UserId không hợp lệ!");
                    return;
                }

                
                Guid houseGuid;
                if (!Guid.TryParse(_houseId, out houseGuid) || houseGuid == Guid.Empty)
                {
                    // tìm membership hiện tại của user
                    var memberResp = await client
                        .From<HouseMembersData>()
                        .Select("*")
                        .Where(m => m.UserId == userGuid && m.IsActive == true)
                        .Get();

                    if (!memberResp.Models.Any())
                    {
                        MessageBox.Show("Không tìm thấy phòng cho người dùng này.");
                        return;
                    }

                    var currentMember = memberResp.Models.OrderByDescending(m => m.JoinedAt).First();
                    houseGuid = currentMember.HouseId;
                }

                // Tạo object
                var expense = new ExpensesData
                {
                    Id = Guid.NewGuid(),
                    HouseId = houseGuid,
                    Title = txtTitle.Text.Trim(),
                    Amount = amount,
                    PaidBy = userGuid,
                    ExpenseDate = dtpDate.Value,
                    Type = "EXPENSE",
                    Note = ""
                };

                // Insert DB
                await client
                    .From<ExpensesData>()
                    .Insert(expense);

                MessageBox.Show("Thêm khoản chi thành công!", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset form
                txtTitle.Clear();
                txtAmount.Clear();
                dtpDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
