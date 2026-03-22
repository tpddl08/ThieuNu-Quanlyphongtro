using System;
using System.Windows.Forms;
using Supabase;

namespace ThieunuQLPT
{
    public partial class frmListBills : Form
    {
        private Client client = null!; 

        public frmListBills()
        {
            InitializeComponent();
            this.Load += frmListBills_Load; // Load chạy
        }

       
        private async void frmListBills_Load(object sender, EventArgs e)
        {
            client = new Client(
                 "https://unkegkyxftsxkusheabr.supabase.co",
                 "sb_publishable_KNYJJ23Wts1x0zkc-ifPbg_f04atwSl"
             );

            await client.InitializeAsync();
        }

       
        private async void btnAll_Click(object sender, EventArgs e)
        {
            /*var model = new ListBills()
            {

                house_id = "dcb6a79e-3510-48d7-9655-457a8aa877f5", // đúng dạng UUID
                month_year = "2024-06",
                total_amount = 500000,
                status = "Unpaid",
                created_at = DateTime.Now,
            };
            await client.From<ListBills>().Insert(model);*/


            var result = await client
                .From<ListBills>()   // class mapping 
                .Get();

            // Đổ vào DataGridView
            dataGridView1.DataSource = result.Models;



            dataGridView1.Columns["id"].Visible = false;
             
            dataGridView1.Columns["BaseUrl"].Visible = false;
            dataGridView1.Columns["RequestClientOptions"].Visible = false;
            dataGridView1.Columns["TableName"].Visible = false;
            dataGridView1.Columns["PrimaryKey"].Visible = false;



            MessageBox.Show("Số dòng: " + result.Models.Count);
        }
    }
}