using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThieunuQLPT.Models;
using Supabase;
namespace ThieunuQLPT
{
    public partial class frmBill : Form
    {
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

                var result = await client.From<DetailBill>().Where(x => x.id == houseId).Single();
                var invoice = await client.From<ListBills>().Where(x => x.house_id == houseId).Single();

                if (result != null && invoice != null)
                {
                    decimal electricTotal = (result.newNums - result.oldNums) * 4000;
                    decimal waterTotal = result.maxMembers * 100000;

                    lblRoom.Text = result.Name;
                    lblRent.Text = result.totalRent.ToString("N0") + " đ";
                    lblOldNums.Text = result.oldNums.ToString();
                    lblNewNums.Text = result.newNums.ToString();
                    lblConsume.Text = $"{result.newNums - result.oldNums} kWh x 4,000đ";
                    lblElectricRate.Text = electricTotal.ToString("N0") + " đ";
                    lblWaterRate.Text = waterTotal.ToString("N0") + " đ";
                    lblServiceRate.Text = result.serviceRate.ToString("N0") + " đ";
                    lblMembers.Text = result.maxMembers.ToString() + " người";

                    lblMonthYear.Text = invoice.month_year;
                    lblTotal.Text = invoice.total_amount.ToString("N0") + " đ";
                }
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