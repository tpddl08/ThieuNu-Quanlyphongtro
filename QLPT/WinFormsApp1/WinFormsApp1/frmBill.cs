using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supabase;
using ThieunuQLPT.Models;
namespace ThieunuQLPT
{
    public partial class frmBill : Form
    {
        private Supabase.Client client = null!;
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
            if (string.IsNullOrEmpty(_houseId)) return; // Chặn lỗi UUID rỗng

            client = new Supabase.Client(
                 "https://unkegkyxftsxkusheabr.supabase.co",
                 "sb_publishable_KNYJJ23Wts1x0zkc-ifPbg_f04atwSl"
            );
            await client.InitializeAsync();
            await LoadHouseData(_houseId);
        }

        public async Task LoadHouseData(string houseId)
        {
            try
            {
                //lấy chi tiết chỉ số (điện, nước) từ DetailBill
                var result = await client.From<DetailBill>().Where(x => x.id == houseId).Single();

                //lấy Tổng tiền và Tháng từ ListBills (Cái này mới là cái đã cập nhật đúng)
                var invoice = await client.From<ListBills>().Where(x => x.house_id == houseId).Single();

                if (result != null && invoice != null)
                {
                    // Các chỉ số phụ vẫn tính để hiện thị cho người dùng xem
                    decimal electricTotal = (result.newNums - result.oldNums) * 4000; // fix cứng 4000  giống bên Edit
                    decimal waterTotal = result.maxMembers * 100000;

                    // gán dữ liệu lên form
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
            // Mở form Edit và truyền ID
            frmEditBill editForm = new frmEditBill(_houseId);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                
                await LoadHouseData(_houseId);

                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
