using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThieunuQLPT.Models;
using Supabase;
namespace ThieunuQLPT
{
    public partial class frmEditBill : Form
    {
        private string _houseId = "";

        public frmEditBill()
        {
            InitializeComponent();
        }

        public frmEditBill(string houseId) : this()
        {
            this._houseId = houseId;
            this.Load += frmEditBill_Load;
        }

        private async void frmEditBill_Load(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_houseId))
            {
                await FetchDataToFields();
            }
        }

        private async Task FetchDataToFields()
        {
            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            var result = await client.From<DetailBill>().Where(x => x.id == _houseId).Single();
            if (result != null)
            {
                txtRoom.Text = result.Name;
                txtRent.Text = result.totalRent.ToString();
                txtOldNums.Text = result.oldNums.ToString();
                txtNewNums.Text = result.newNums.ToString();
                txtMaxMembers.Text = result.maxMembers.ToString();
                txtServiceRate.Text = result.serviceRate.ToString();
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var client = await SupabaseHelper.GetClientAsync();
                if (client == null) return;

                var update = new DetailBill
                {
                    id = _houseId,
                    newNums = int.Parse(txtNewNums.Text),
                    oldNums = int.Parse(txtOldNums.Text),
                    totalRent = decimal.Parse(txtRent.Text),
                    Name = txtRoom.Text,
                    serviceRate = decimal.Parse(txtServiceRate.Text),
                    maxMembers = int.Parse(txtMaxMembers.Text),
                };

                var detailBill = await client.From<DetailBill>()
                    .Where(x => x.id == _houseId)
                    .Single();

                decimal water_rate = update.maxMembers * 100000;
                decimal electric_rate = (update.newNums - update.oldNums) * 4000;

                decimal totalAmount = update.totalRent
                    + ((update.newNums - update.oldNums) * 4000)
                    + (update.maxMembers * 100000)
                    + update.serviceRate;

                detailBill.newNums = update.newNums;
                detailBill.oldNums = update.oldNums;
                detailBill.Name = update.Name;
                lblWaterRate.Text = water_rate.ToString();
                lblElectricRate.Text = electric_rate.ToString();
                lblConsume.Text = $"{update.newNums - update.oldNums} kWh x 4000đ";
                detailBill.totalRent = update.totalRent;
                detailBill.serviceRate = update.serviceRate;
                detailBill.maxMembers = update.maxMembers;
                lblTotal.Text = totalAmount.ToString();

                await client.From<DetailBill>()
                    .Where(x => x.id == _houseId)
                    .Update(detailBill);

                var lisBill = await client.From<ListBills>()
                    .Where(x => x.house_id == _houseId)
                    .Single();
                lisBill.total_amount = totalAmount;
                lisBill.month_year = txtMonth.Text;
                await client.From<ListBills>()
                    .Where(x => x.house_id == _houseId)
                    .Update(lisBill);

                MessageBox.Show("Cập nhật thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var client = await SupabaseHelper.GetClientAsync();
                if (client == null) return;

                var newHouse = new DetailBill
                {
                    Name = txtRoom.Text,
                    totalRent = decimal.Parse(txtRent.Text),
                    oldNums = int.Parse(txtOldNums.Text),
                    newNums = int.Parse(txtNewNums.Text),
                    electricRate = 4000,
                    waterRate = 100000,
                    maxMembers = int.Parse(txtMaxMembers.Text),
                    serviceRate = decimal.Parse(txtServiceRate.Text)
                };

                var response = await client.From<DetailBill>().Insert(newHouse);
                var createdHouse = response.Model;

                if (createdHouse != null)
                {
                    decimal electricTotal = (createdHouse.newNums - createdHouse.oldNums) * createdHouse.electricRate;
                    decimal waterTotal = createdHouse.maxMembers * createdHouse.waterRate;
                    decimal totalAmount = createdHouse.totalRent + electricTotal + waterTotal + (decimal)createdHouse.serviceRate;

                    var newInvoice = new ListBills
                    {
                        house_id = createdHouse.id,
                        month_year = txtMonth.Text,
                        total_amount = totalAmount,
                        status = "Unpaid",
                        created_at = DateTime.Now
                    };
                    await client.From<ListBills>().Insert(newInvoice);
                }

                MessageBox.Show("Thêm phòng và hóa đơn thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var client = await SupabaseHelper.GetClientAsync();
                    if (client == null) return;

                    await client.From<DetailBill>().Where(x => x.id == _houseId).Delete();
                    await client.From<ListBills>().Where(x => x.house_id == _houseId).Delete();

                    MessageBox.Show("Đã xóa!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception) { MessageBox.Show("Lỗi: " + "Hóa đơn chưa tồn tại để xóa"); }
            }
        }
    }
}