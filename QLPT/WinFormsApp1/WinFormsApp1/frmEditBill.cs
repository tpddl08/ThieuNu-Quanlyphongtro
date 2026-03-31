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
            if (!string.IsNullOrEmpty(_houseId))
            {
                await FetchDataToFields();
            }
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
                txtRent.Text = (result.TotalRent ?? 0).ToString();
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
                decimal totalRent = decimal.Parse(txtRent.Text);
                decimal serviceRate = decimal.Parse(txtServiceRate.Text);

                decimal water_rate = maxMembers * 100000;
                decimal electric_rate = (newNums - oldNums) * 4000;

                decimal totalAmount = totalRent
                    + electric_rate
                    + water_rate
                    + serviceRate;

                house.Name = txtRoom.Text;
                house.TotalRent = totalRent;
                house.OldNumber = oldNums;
                house.NewNumber = newNums;
                house.ServiceRate = serviceRate;

                lblWaterRate.Text = water_rate.ToString();
                lblElectricRate.Text = electric_rate.ToString();
                lblConsume.Text = $"{newNums - oldNums} kWh x 4000đ";
                lblTotal.Text = totalAmount.ToString();

                await client.From<HousesData>().Update(house);

                // Đồng bộ sang bảng Invoices (Danh sách tổng)
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

        /*thêm*/
        private async void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var client = await SupabaseHelper.GetClientAsync();
                if (client == null) return;

                int oldNums = int.Parse(txtOldNums.Text);
                int newNums = int.Parse(txtNewNums.Text);
                decimal totalRent = decimal.Parse(txtRent.Text);
                decimal serviceRate = decimal.Parse(txtServiceRate.Text);
                decimal electricRate = 4000;
                decimal waterRate = 100000;
                int maxMembers = int.Parse(txtMaxMembers.Text);

                //tạo đối tượng House mới
                var newHouse = new HousesData
                {
                    Name = txtRoom.Text,
                    TotalRent = totalRent,
                    OldNumber = oldNums,
                    NewNumber = newNums,
                    ElectricityRate = electricRate,
                    WaterRate = waterRate,
                    MaxMembers = maxMembers,
                    ServiceRate = serviceRate
                };

                // chèn vào bảng houses và lấy kết quả trả về (để lấy ID mới sinh)
                var response = await client.From<HousesData>().Insert(newHouse);
                var createdHouse = response.Models.FirstOrDefault();

                if (createdHouse != null)
                {
                    // Gán người tạo vào phòng
                    var newMember = new HouseMembersData
                    {
                        HouseId = createdHouse.Id,
                        UserId = currentUserId,
                        Role = "owner",
                        IsActive = true,
                        JoinedAt = DateTime.Now
                    };
                    await client.From<HouseMembersData>().Insert(newMember);

                    // tính tổng tiền ban đầu cho hóa đơn
                    decimal electricTotal = (newNums - oldNums) * electricRate;
                    decimal waterTotal = maxMembers * waterRate;
                    decimal totalAmount = totalRent + electricTotal + waterTotal + serviceRate;

                    //tạo hóa đơn tương ứng bên bảng invoices
                    var newInvoice = new InvoicesData
                    {
                        HouseId = createdHouse.Id, // Lấy ID vừa sinh ra từ DB
                        MonthYear = txtMonth.Text,
                        TotalAmount = totalAmount,
                        Status = "Unpaid",
                        CreatedAt = DateTime.Now
                    };
                    await client.From<InvoicesData>().Insert(newInvoice);
                }

                MessageBox.Show("Thêm phòng và hóa đơn thành công!");

                //trả về DialogResult.OK để Form List tự Load lại
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
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
                catch (Exception) { MessageBox.Show("Lỗi: " + "Hóa đơn chưa tồn tại để xóa"); }
            }
        }
    }
}