using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Postgrest.Constants;

namespace ThieunuQLPT
{
    public partial class frmDetail : Form
    {
        public frmDetail(string houseId)
        {
            InitializeComponent();
            _houseId = houseId;
            //this.Load += FormDongTien_Load;
        }
        private async void FormDongTien_Load(object sender, EventArgs e)
        {
            try
            {
                if (dgvSplitBill.Columns.Count == 0)
                {
                    dgvSplitBill.Columns.Add("colName", "Tên");
                    dgvSplitBill.Columns.Add("colAmount", "Số tiền phải trả");
                }

                if (string.IsNullOrEmpty(_houseId))
                {
                    MessageBox.Show("Thiếu houseId!");
                    return;
                }

                decimal totalAmount = 5704000; // test
                await LoadSplitBill(totalAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }



        private string _houseId = "";
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private async Task LoadSplitBill(decimal totalAmount)
        {
            dgvSplitBill.Rows.Clear();

            var client = await SupabaseHelper.GetClientAsync();
            if (client == null)
            {
                MessageBox.Show("Không kết nối được với Supabase!");
                return;
            }

            if (!Guid.TryParse(_houseId, out Guid houseGuid))
            {
                MessageBox.Show("houseId không hợp lệ!");
                return;
            }

            // Lấy danh sách members
            var membersResp = await client
                .From<HouseMembersData>()
                .Select("*")
                .Where(m => m.HouseId == houseGuid && m.IsActive == true)
                .Get();

            int totalMember = membersResp.Models.Count;
            if (totalMember == 0)
            {
                MessageBox.Show("Nhà này chưa có thành viên nào!");
                return;
            }

            decimal perPerson = totalAmount / totalMember;

            // Lấy tất cả UserId để query profile một lần (tối ưu hơn)
            var userIds = membersResp.Models.Select(m => m.UserId).ToList();

            var profilesResp = await client
    .From<ProfilesData>()
    .Select("*")
    .Filter(p => p.Id, Operator.In, userIds)
    .Get();

            var profileDict = profilesResp.Models.ToDictionary(p => p.Id, p => p);

            foreach (var m in membersResp.Models)
            {
                var prof = profileDict.GetValueOrDefault(m.UserId);

                this.Invoke((MethodInvoker)delegate
                {
                    int idx = dgvSplitBill.Rows.Add();
                    dgvSplitBill.Rows[idx].Cells["colName"].Value = prof?.FullName ?? "Không tên";
                    dgvSplitBill.Rows[idx].Cells["colAmount"].Value = perPerson.ToString("N0") + " đ";
                });
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            //lblDebug.Text = $"Members: {membersResp.Models.Count}";
        }
    }
}
