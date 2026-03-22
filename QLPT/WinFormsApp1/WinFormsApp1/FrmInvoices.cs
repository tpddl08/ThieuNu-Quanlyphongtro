using Newtonsoft.Json;
using Supabase.Gotrue.Mfa;
using System.Text;
using System.Windows.Forms;
using ThieunuQLPT.Models;
using ThieunuQLPT.Models.Invoices;

namespace ThieunuQLPT
{
    public partial class FrmInvoices : Form
    {
        public FrmInvoices()
        {
            InitializeComponent();
        }

        private Invoice _currentInvoice {  get; set; }
        private House _currentHouse { get; set; }

        SupabaseService service = new SupabaseService();

        async Task LoadInvoices(Guid invoiceId)
        {
            // get invoicce
            string invoiceId_parameter = $"?id=eq.{invoiceId.ToString()}";
            var invoiceResult = await service.Get("invoices", invoiceId_parameter);
            _currentInvoice = JsonConvert.DeserializeObject<List<Invoice>>(invoiceResult).FirstOrDefault();

            // get house information by invoice
            string houseId_parameter = $"?id=eq.{_currentInvoice.house_id.ToString()}";
            var houseResult = await service.Get("houses", houseId_parameter);
            _currentHouse = JsonConvert.DeserializeObject<List<House>>(houseResult).FirstOrDefault();

            // get innvoice details
            string invoice_parameter = $"?invoice_id=eq.{invoiceId.ToString()}";
            var invoiceItemResult = await service.Get("invoice_items", invoice_parameter);
            var dt = JsonConvert.DeserializeObject<List<InvoiceItem>>(invoiceItemResult);

            dgvPhieuThu.DataSource = dt;

            txtHouseName.Text = _currentHouse?.name;
            txtInvoice.Text = _currentInvoice?.month_year;
            EnnrichInvoicItems();
        }

        private void EnnrichInvoicItems()
        {
            foreach (DataGridViewRow row in dgvPhieuThu.Rows)
            {
                if (row.DataBoundItem is InvoiceItem item)
                {
                    decimal totalAmount = 0;
                    if (item.type.Trim() == "tien dien")
                    {
                        item.TotalAmount = item.amount * _currentHouse.electricity_rate;
                    }
                    else if(item.type == "tien nuoc")
                    {
                        item.TotalAmount = item.amount * _currentHouse.water_rate;
                    }
                    else 
                    {
                        item.TotalAmount = item.amount;
                    }
                }
            }

            dgvPhieuThu.Refresh();
        }

        private async void FrmInvoices_Load(object sender, EventArgs e)
        {
            await LoadInvoices(new Guid("6954efce-8e18-4529-9b9d-ae197f8687eb"));
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }




        private void dd_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }



        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }



        private double GetTotal()
        {
            double total = 0;

            foreach (DataGridViewRow row in dgvPhieuThu.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    string value = row.Cells[1].Value.ToString()
                        .Replace("đ", "")
                        .Replace(".", "")
                        .Trim();

                    if (double.TryParse(value, out double money))
                        total += money;
                }
            }

            return total;
        }



        private async void Add_Click(object sender, EventArgs e)
        {
            try
            {
                double total = GetTotal();

                var data = new
                {
                    id = Guid.NewGuid(), // ✅ thêm dòng này
                    house_id = "A101",
                    month_year = "03/2026",
                    total_amount = total,
                    status = "unpaid"
                };

                await service.Insert("invoices", data);

                MessageBox.Show("Thêm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public class SupabaseService
        {
            private string url = "https://unkegkyxftsxkusheabr.supabase.co/rest/v1/";
            private string apiKey = "sb_publishable_KNYJJ23Wts1x0zkc-ifPbg_f04atwSl";

            private HttpClient client;

            public SupabaseService()
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.Add("apikey", apiKey);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);
            }

            // GET
            public async Task<string> Get(string table, string parameter)
            {
                var res = await client.GetAsync(url + table + parameter);
                return await res.Content.ReadAsStringAsync();
            }

            // INSERT
            public async Task Insert(string table, object data)
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                await client.PostAsync(url + table, content);
            }

            // DELETE
            public async Task Delete(string table, string condition)
            {
                await client.DeleteAsync(url + table + "?" + condition);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MonthYear_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            //txtHouseName.Text = _currentHouse.name;
            //txtInvoice.Text = _currentInvoice.month_year;
        }

        private void Detele_Click(object sender, EventArgs e)
        {

        }
    }
}
