using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supabase;

namespace ThieunuQLPT
{
    public partial class frmEditBill : Form
    {
        private Guid currentUserId = frmLogin.idLoged;
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
            if (string.IsNullOrEmpty(_houseId))
            {
                MessageBox.Show("Bạn chưa có phòng nên không thể chỉnh sửa hóa đơn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            await FetchDataToFields();
        }

        private async Task FetchDataToFields()
        {
            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            if (!Guid.TryParse(_houseId, out Guid houseGuid)) return;

            var houseResp = await client
                .From<HousesData>()
                .Select("*")
                .Where(h => h.Id == houseGuid)
                .Get();

            var result = houseResp.Models.FirstOrDefault();
            if (result != null)
            {
                var memberResp = await client
                    .From<HouseMembersData>()
                    .Select("*")
                    .Where(m => m.HouseId == houseGuid && m.IsActive == true)
                    .Get();

                txtRoom.Text = result.Name;
                txtRent.Text = (result.PriceRent ?? 0).ToString();
                txtOldNums.Text = (result.OldNumber ?? 0).ToString();
                txtNewNums.Text = (result.NewNumber ?? 0).ToString();
                txtMaxMembers.Text = memberResp.Models.Count.ToString();
                txtServiceRate.Text = (result.ServiceRate ?? 0).ToString();
            }
        }

        //sửa
        private async void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var client = await SupabaseHelper.GetClientAsync();
                if (client == null) return;

                if (!Guid.TryParse(_houseId, out Guid houseGuid)) return;

                var houseResp = await client
                    .From<HousesData>()
                    .Select("*")
                    .Where(h => h.Id == houseGuid)
                    .Get();

                var house = houseResp.Models.FirstOrDefault();
                if (house == null) return;

                int newNums = int.Parse(txtNewNums.Text);
                int oldNums = int.Parse(txtOldNums.Text);
                int maxMembers = int.Parse(txtMaxMembers.Text);
                decimal priceRent = decimal.Parse(txtRent.Text);
                decimal serviceRate = decimal.Parse(txtServiceRate.Text);

                decimal electricRate = house.ElectricityRate ?? 4000;
                decimal waterRate = house.WaterRate ?? 100000;

                decimal water_rate = maxMembers * waterRate;
                decimal electric_rate = (newNums - oldNums) * electricRate;

                decimal totalAmount = priceRent + electric_rate + water_rate + serviceRate;

                house.Name = txtRoom.Text;
                house.PriceRent = priceRent;
                house.OldNumber = oldNums;
                house.NewNumber = newNums;
                house.ServiceRate = serviceRate;

                lblWaterRate.Text = water_rate.ToString("N0") + " đ";
                lblElectricRate.Text = electric_rate.ToString("N0") + " đ";
                lblConsume.Text = $"{newNums - oldNums} kWh x {electricRate:N0}đ";
                lblTotal.Text = totalAmount.ToString("N0") + " đ";

                await client.From<HousesData>().Update(house);

                // Đồng bộ sang bảng Invoices
                var invoiceResp = await client
                    .From<InvoicesData>()
                    .Select("*")
                    .Where(x => x.HouseId == houseGuid)
                    .Get();

                var invoice = invoiceResp.Models.FirstOrDefault();
                if (invoice != null)
                {
                    invoice.TotalAmount = totalAmount;
                    invoice.MonthYear = txtMonth.Text;
                    await client.From<InvoicesData>().Update(invoice);
                }

                MessageBox.Show("Cập nhật thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // xóa
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var client = await SupabaseHelper.GetClientAsync();
                    if (client == null) return;

                    if (!Guid.TryParse(_houseId, out Guid houseGuid)) return;

                    // Xóa invoice trước rồi mới xóa members và phòng
                    await client.From<InvoicesData>()
                        .Where(x => x.HouseId == houseGuid)
                        .Delete();

                    await client.From<HouseMembersData>()
                        .Where(m => m.HouseId == houseGuid)
                        .Delete();

                    await client.From<HousesData>()
                        .Where(h => h.Id == houseGuid)
                        .Delete();

                    MessageBox.Show("Đã xóa!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        /*thêm hóa đơn mới*/
        private async void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var client = await SupabaseHelper.GetClientAsync();
                if (client == null) return;

                if (!Guid.TryParse(_houseId, out Guid houseGuid)) return;

                // Kiểm tra tháng nhập vào
                if (string.IsNullOrWhiteSpace(txtMonth.Text))
                {
                    MessageBox.Show("Vui lòng nhập tháng/năm cho hóa đơn!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra hóa đơn tháng này đã tồn tại chưa
                var existResp = await client
                    .From<InvoicesData>()
                    .Select("*")
                    .Where(x => x.HouseId == houseGuid && x.MonthYear == txtMonth.Text)
                    .Get();

                if (existResp.Models.Any())
                {
                    MessageBox.Show($"Hóa đơn tháng {txtMonth.Text} đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin phòng
                var houseResp = await client
                    .From<HousesData>()
                    .Select("*")
                    .Where(h => h.Id == houseGuid)
                    .Get();

                var house = houseResp.Models.FirstOrDefault();
                if (house == null) return;

                int oldNums = int.Parse(txtOldNums.Text);
                int newNums = int.Parse(txtNewNums.Text);
                decimal priceRent = decimal.Parse(txtRent.Text);
                decimal serviceRate = decimal.Parse(txtServiceRate.Text);
                int maxMembers = int.Parse(txtMaxMembers.Text);

                decimal electricRate = house.ElectricityRate ?? 4000;
                decimal waterRate = house.WaterRate ?? 100000;

                decimal electricTotal = (newNums - oldNums) * electricRate;
                decimal waterTotal = maxMembers * waterRate;
                decimal totalAmount = priceRent + electricTotal + waterTotal + serviceRate;

                // Tạo hóa đơn mới
                var newInvoice = new InvoicesData
                {
                    HouseId = houseGuid,
                    MonthYear = txtMonth.Text,
                    TotalAmount = totalAmount,
                    CreatedAt = DateTime.Now
                };
                await client.From<InvoicesData>().Insert(newInvoice);

                MessageBox.Show($"Đã tạo hóa đơn tháng {txtMonth.Text} thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo hóa đơn: " + ex.Message);
            }
        }
    }
}