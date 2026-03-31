using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThieunuQLPT
{
    public partial class frmBill : Form
    {
        private Guid currentUserId = frmLogin.idLoged;
        private HousesData? currentHouse;
        private string _houseId = "";

        public frmBill()
        {
            InitializeComponent();
        }

        public frmBill(string houseId) : this()
        {
            this._houseId = houseId;
            this.Load += frmBill_Load;
        }

        private async void frmBill_Load(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_houseId)) return;
            await LoadHouseData(_houseId);
        }

        public async Task LoadHouseData(string houseId)
        {
            try
            {
                var client = await SupabaseHelper.GetClientAsync();
                if (client == null) return;

                if (!Guid.TryParse(houseId, out Guid houseGuid)) return;

                // Lấy thông tin phòng từ HousesData
                var houseResp = await client
                    .From<HousesData>()
                    .Select("*")
                    .Where(h => h.Id == houseGuid)
                    .Get();

                currentHouse = houseResp.Models.FirstOrDefault();
                if (currentHouse == null) return;

                // Lấy số thành viên đang ở
                var memberResp = await client
                    .From<HouseMembersData>()
                    .Select("*")
                    .Where(m => m.HouseId == houseGuid && m.IsActive == true)
                    .Get();

                int totalMembers = memberResp.Models.Count;

                // Tính tiền
                int oldNums = currentHouse.OldNumber ?? 0;
                int newNums = currentHouse.NewNumber ?? 0;
                decimal electricTotal = (newNums - oldNums) * (currentHouse.ElectricityRate ?? 4000);
                decimal waterTotal = totalMembers * (currentHouse.WaterRate ?? 100000);
                decimal total = (currentHouse.TotalRent ?? 0) + electricTotal + waterTotal + (currentHouse.ServiceRate ?? 0);

                // Hiển thị
                lblRoom.Text = currentHouse.Name;
                lblRent.Text = (currentHouse.TotalRent ?? 0).ToString("N0") + " đ";
                lblOldNums.Text = oldNums.ToString();
                lblNewNums.Text = newNums.ToString();
                lblConsume.Text = $"{newNums - oldNums} kWh x {(currentHouse.ElectricityRate ?? 4000):N0}đ";
                lblElectricRate.Text = electricTotal.ToString("N0") + " đ";
                lblWaterRate.Text = waterTotal.ToString("N0") + " đ";
                lblServiceRate.Text = (currentHouse.ServiceRate ?? 0).ToString("N0") + " đ";
                lblMembers.Text = totalMembers.ToString() + " người";
                lblTotal.Text = total.ToString("N0") + " đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            frmEditBill editForm = new frmEditBill(_houseId);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await LoadHouseData(_houseId);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}