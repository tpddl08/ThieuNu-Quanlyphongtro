namespace ThieunuQLPT
{
    public partial class frmEditBill : Form
    {
        private Supabase.Client client = new Supabase.Client(
        "https://unkegkyxftsxkusheabr.supabase.co",
        "sb_publishable_KNYJJ23Wts1x0zkc-ifPbg_f04atwSl"
    );
        private string _houseId = "";

        public frmEditBill()
        {
            InitializeComponent();
            _ = client.InitializeAsync();
        }
        public frmEditBill(string houseId) : this()
        {
            this._houseId = houseId;
            this.Load += frmEditBill_Load;
        }

        private async void frmEditBill_Load(object? sender, EventArgs e)
        {
            //đảm bảo client đã sẵn sàng
            await client.InitializeAsync();

            if (!string.IsNullOrEmpty(_houseId))
            {
                await FetchDataToFields();
            }
        }
        private async Task FetchDataToFields()
        {
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
            

        //sửa
        private async void btnSua_Click(object sender, EventArgs e)
        {

            try
            {
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

                // Đồng bộ sang bảng Invoices (Danh sách tổng)


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

        /*thêm*/
        private async void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                //tạo đối tượng House mới
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

                // chèn vào bảng houses và lấy kết quả trả về (để lấy ID mới sinh)
                var response = await client.From<DetailBill>().Insert(newHouse);
                var createdHouse = response.Model;

                if (createdHouse != null)
                {
                    // tính tổng tiền ban đầu cho hóa đơn
                    decimal electricTotal = (createdHouse.newNums - createdHouse.oldNums) * createdHouse.electricRate;
                    decimal waterTotal = createdHouse.maxMembers * createdHouse.waterRate;
                    decimal totalAmount = createdHouse.totalRent + electricTotal + waterTotal + (decimal)createdHouse.serviceRate;
                    
                    //tạo hóa đơn tương ứng bên bảng ListBills (invoices)
                    var newInvoice = new ListBills
                    {
                        house_id = createdHouse.id, // Lấy ID vừa sinh ra từ DB
                        month_year = txtMonth.Text,
                        total_amount = totalAmount,
                        status = "Unpaid",
                        created_at = DateTime.Now
                    };
                    await client.From<ListBills>().Insert(newInvoice);
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
                    await client.From<DetailBill>().Where(x => x.id == _houseId).Delete();
                    await client.From<ListBills>().Where(x => x.house_id == _houseId).Delete();

                    MessageBox.Show("Đã xóa!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception) { MessageBox.Show("Lỗi: " + "Hóa đơn chưa tồn tại để xóa"); }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }
    }
}