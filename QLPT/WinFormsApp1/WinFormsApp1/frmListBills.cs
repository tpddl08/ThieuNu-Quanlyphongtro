using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supabase;
using ThieunuQLPT.Models;

namespace ThieunuQLPT
{
    public partial class frmListBills : Form
    {
        private Client client = null!;

        public frmListBills()
        {
            InitializeComponent();
            this.Load += frmListBills_Load;
        }

        private async void frmListBills_Load(object? sender, EventArgs e)
        {
            client = new Client(
                 "https://unkegkyxftsxkusheabr.supabase.co",
                 "sb_publishable_KNYJJ23Wts1x0zkc-ifPbg_f04atwSl"
             );
            await client.InitializeAsync();
            await LoadData(); // load dữ liệu
        }

        private async Task LoadData()
        {
            try
            {
                var result = await client.From<ListBills>()
                              
                                 .Get();
                dataGridView1.DataSource = result.Models;

                // Ẩn cột thừa an toàn
                string[] hideCols = { "id", "BaseUrl", "RequestClientOptions", "TableName", "PrimaryKey", "House"};
                foreach (var col in hideCols)
                {
                    if (dataGridView1.Columns.Contains(col)) dataGridView1.Columns[col].Visible = false;
                    if (dataGridView1.Columns.Contains("total_amount"))
                    {
                        dataGridView1.Columns["total_amount"].HeaderText = "Tổng Tiền";
                        dataGridView1.Columns["total_amount"].DefaultCellStyle.Format = "N0";
                        dataGridView1.Columns["total_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    dataGridView1.Columns["month_year"].HeaderText = "Tháng";
                    dataGridView1.Columns["status"].HeaderText = "Trạng thái";

                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Lỗi LoadData: " + ex.Message);
            }
        }

        private async void btnAll_Click(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = dataGridView1.Rows[e.RowIndex].Cells["house_id"].Value?.ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    frmBill viewForm = new frmBill(id);
                    // nếu ở các Form con có thay đổi (Sửa/Xóa), load lại danh sách
                    if (viewForm.ShowDialog() == DialogResult.OK)
                    {
                        await LoadData();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEditBill frm = new frmEditBill(); //ko có ID → thêm mới

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _ = LoadData();
            }
        }
    }
}