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

                // Lấy thông tin phòng
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

                // Lấy hóa đơn
                var invoiceResp = await client
                    .From<InvoicesData>()
                    .Select("*")
                    .Where(x => x.HouseId == houseGuid)
                    .Get();

                var invoice = invoiceResp.Models
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefault();

                // Tính tiền để hiển thị chi tiết
                int oldNums = invoice?.OldNumber ?? 0;
                int newNums = invoice?.NewNumber ?? 0;
                decimal electricTotal = (newNums - oldNums) * (currentHouse.ElectricityRate ?? 4000);
                decimal waterTotal = totalMembers * (currentHouse.WaterRate ?? 100000);

                // Hiển thị
                lblRoom.Text = currentHouse.Name;
                lblRent.Text = (currentHouse.PriceRent ?? 0).ToString("N0") + " đ";
                lblOldNums.Text = oldNums.ToString();
                lblNewNums.Text = newNums.ToString();
                lblConsume.Text = $"{newNums - oldNums} kWh x {(currentHouse.ElectricityRate ?? 4000):N0}đ";
                lblElectricRate.Text = electricTotal.ToString("N0") + " đ";
                lblWaterRate.Text = waterTotal.ToString("N0") + " đ";
                lblServiceRate.Text = (currentHouse.ServiceRate ?? 0).ToString("N0") + " đ";
                lblMembers.Text = totalMembers.ToString() + " người";

                // Lấy tổng từ invoices thay vì tự tính
                lblTotal.Text = (invoice?.TotalAmount ?? 0).ToString("N0") + " đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            // Lấy invoice mới nhất của phòng để truyền vào form edit
            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            if (!Guid.TryParse(_houseId, out Guid houseGuid)) return;

            var invoiceResp = await client
                .From<InvoicesData>()
                .Select("*")
                .Where(x => x.HouseId == houseGuid)
                .Get();

            var latestInvoice = invoiceResp.Models
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefault();

            if (latestInvoice == null)
            {
                MessageBox.Show("Phòng này chưa có hóa đơn nào.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmEditBill editForm = new frmEditBill(_houseId, latestInvoice.Id.ToString());
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await LoadHouseData(_houseId);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}