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
        private string _invoiceId = ""; // thêm field mới

        public frmEditBill()
        {
            InitializeComponent();
        }

        public frmEditBill(string houseId, string invoiceId) : this()
        {
            this._houseId = houseId;
            this._invoiceId = invoiceId; // nhận invoiceId
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

                if (!Guid.TryParse(_invoiceId, out Guid invoiceGuid)) return;

                var invoiceResp = await client
                    .From<InvoicesData>()
                    .Select("*")
                    .Where(x => x.Id == invoiceGuid) // lấy đúng invoice đang chọn
                    .Get();

                var invoice = invoiceResp.Models.FirstOrDefault();
                txtMonth.Text = invoice?.MonthYear ?? "";
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

                    // Lấy danh sách invoice ids trước
                    var invoiceResp = await client
                        .From<InvoicesData>()
                        .Select("*")
                        .Where(x => x.HouseId == houseGuid)
                        .Get();

                    // Xóa invoice_items và invoice_payments theo từng invoice
                    foreach (var inv in invoiceResp.Models)
                    {
                        await client.From<InvoiceItemsData>()
                            .Where(i => i.InvoiceId == inv.Id)
                            .Delete();

                        await client.From<InvoicePaymentsData>()
                            .Where(p => p.InvoiceId == inv.Id)
                            .Delete();
                    }

                    // Sau đó mới xóa invoices, members, phòng
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

                // Validate tháng/năm
                if (string.IsNullOrWhiteSpace(txtMonth.Text))
                {
                    MessageBox.Show("Vui lòng nhập tháng/năm cho hóa đơn!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra trùng tháng
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

                // Validate định dạng số
                if (!int.TryParse(txtOldNums.Text, out int oldNums) ||
                    !int.TryParse(txtNewNums.Text, out int newNums) ||
                    !decimal.TryParse(txtRent.Text, out decimal priceRent) ||
                    !decimal.TryParse(txtServiceRate.Text, out decimal serviceRate) ||
                    !int.TryParse(txtMaxMembers.Text, out int maxMembers))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số!", "Lỗi nhập liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (newNums < oldNums)
                {
                    MessageBox.Show("Chỉ số mới không thể nhỏ hơn chỉ số cũ!", "Lỗi nhập liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin phòng để lấy giá điện/nước
                var houseResp = await client
                    .From<HousesData>()
                    .Select("*")
                    .Where(h => h.Id == houseGuid)
                    .Get();

                var house = houseResp.Models.FirstOrDefault();
                if (house == null) return;

                decimal electricRate = house.ElectricityRate ?? 4000;
                decimal waterRate = house.WaterRate ?? 100000;

                // Tính từng khoản
                decimal electricTotal = (newNums - oldNums) * electricRate;
                decimal waterTotal = maxMembers * waterRate;
                decimal totalAmount = priceRent + electricTotal + waterTotal + serviceRate;

                // Bước 1: Update chỉ số điện và thông tin phòng vào houses
                // Để frmDetail đọc đúng old_number, new_number khi tính tiền
                house.OldNumber = oldNums;
                house.NewNumber = newNums;
                house.PriceRent = priceRent;
                house.ServiceRate = serviceRate;
                await client.From<HousesData>().Update(house);

                // Bước 2: Insert hóa đơn vào invoices
                var newInvoice = new InvoicesData
                {
                    HouseId = houseGuid,
                    MonthYear = txtMonth.Text,
                    TotalAmount = totalAmount,
                    Status = "draft",
                    CreatedAt = DateTime.Now
                };
                await client.From<InvoicesData>().Insert(newInvoice);

                // Lấy lại invoice vừa tạo để có Id
                var createdInvoiceResp = await client
                    .From<InvoicesData>()
                    .Select("*")
                    .Where(x => x.HouseId == houseGuid && x.MonthYear == txtMonth.Text)
                    .Get();

                var createdInvoice = createdInvoiceResp.Models.FirstOrDefault();
                if (createdInvoice == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn vừa tạo!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Guid invoiceGuid = createdInvoice.Id;

                // Bước 3: Insert chi tiết từng khoản vào invoice_items
                var items = new List<InvoiceItemsData>
        {
            new InvoiceItemsData { InvoiceId = invoiceGuid, Name = "Tiền thuê", Amount = priceRent, Type = "rent" },
            new InvoiceItemsData { InvoiceId = invoiceGuid, Name = "Tiền điện", Amount = electricTotal, Type = "electric" },
            new InvoiceItemsData { InvoiceId = invoiceGuid, Name = "Tiền nước", Amount = waterTotal, Type = "water" },
            new InvoiceItemsData { InvoiceId = invoiceGuid, Name = "Phí dịch vụ", Amount = serviceRate, Type = "service" },
        };

                foreach (var item in items)
                    await client.From<InvoiceItemsData>().Insert(item);

                // Bước 4: Insert trạng thái thanh toán cho từng thành viên vào invoice_payments
                // Status mặc định "unpaid", chờ xác nhận trong frmDetail
                var membersResp = await client
                    .From<HouseMembersData>()
                    .Select("*")
                    .Where(m => m.HouseId == houseGuid && m.IsActive == true)
                    .Get();

                foreach (var member in membersResp.Models)
                {
                    var payment = new InvoicePaymentsData
                    {
                        InvoiceId = invoiceGuid,
                        UserId = member.UserId,
                        Amount = null, // frmDetail sẽ tính chính xác theo số ngày vắng
                        Status = "unpaid",
                        PaidAt = null
                    };
                    await client.From<InvoicePaymentsData>().Insert(payment);
                }

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

        //Lưu khi sửa
        private async void btnLuu_Click(object sender, EventArgs e)
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

                if (!int.TryParse(txtNewNums.Text, out int newNums) ||
                    !int.TryParse(txtOldNums.Text, out int oldNums) ||
                    !int.TryParse(txtMaxMembers.Text, out int maxMembers) ||
                    !decimal.TryParse(txtRent.Text, out decimal priceRent) ||
                    !decimal.TryParse(txtServiceRate.Text, out decimal serviceRate))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số!", "Lỗi nhập liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (newNums < oldNums)
                {
                    MessageBox.Show("Chỉ số mới không thể nhỏ hơn chỉ số cũ!", "Lỗi nhập liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

                if (Guid.TryParse(_invoiceId, out Guid invoiceGuid))
                {
                    var invoiceResp = await client
                        .From<InvoicesData>()
                        .Select("*")
                        .Where(x => x.Id == invoiceGuid)
                        .Get();

                    var invoice = invoiceResp.Models.FirstOrDefault();
                    if (invoice != null)
                    {
                        invoice.TotalAmount = totalAmount;
                        invoice.MonthYear = txtMonth.Text;
                        await client.From<InvoicesData>().Update(invoice);
                    }
                }

                MessageBox.Show("Cập nhật thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
    }
}