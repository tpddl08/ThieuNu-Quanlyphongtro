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

        public frmDetail(string houseId)
        {
            InitializeComponent();
            _houseId = houseId;
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

                // Lấy totalAmount thực từ DB thay vì hardcode
                decimal totalAmount = await GetTotalAmountAsync();
                await LoadSplitBill(totalAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }

        private async Task<decimal> GetTotalAmountAsync()
        {
            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return 0;

            if (!Guid.TryParse(_houseId, out Guid houseGuid)) return 0;

            // Lấy thông tin phòng
            var houseResp = await client
                .From<HousesData>()
                .Select("*")
                .Where(h => h.Id == houseGuid)
                .Get();

            var house = houseResp.Models.FirstOrDefault();
            if (house == null) return 0;

            // Lấy số thành viên đang ở
            var memberResp = await client
                .From<HouseMembersData>()
                .Select("*")
                .Where(m => m.HouseId == houseGuid && m.IsActive == true)
                .Get();

            int totalMembers = memberResp.Models.Count;

            // Tính tổng tiền
            int oldNums = house.OldNumber ?? 0;
            int newNums = house.NewNumber ?? 0;
            decimal electricTotal = (newNums - oldNums) * (house.ElectricityRate ?? 4000);
            decimal waterTotal = totalMembers * (house.WaterRate ?? 100000);
            decimal totalAmount = (house.TotalRent ?? 0) + electricTotal + waterTotal + (house.ServiceRate ?? 0);

            return totalAmount;
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

            // Lấy profile của tất cả thành viên
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

                int idx = dgvSplitBill.Rows.Add();
                dgvSplitBill.Rows[idx].Cells["colName"].Value = prof?.FullName ?? "Không tên";
                dgvSplitBill.Rows[idx].Cells["colAmount"].Value = perPerson.ToString("N0") + " đ";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}