using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supabase;

namespace ThieunuQLPT
{
    public partial class frmListBills : Form
    {
        private Guid currentUserId = frmLogin.idLoged;
        private string _houseId = "";

        public frmListBills()
        {
            InitializeComponent();
            this.Load += frmListBills_Load;
        }

        private async void frmListBills_Load(object? sender, EventArgs e)
        {
            await LoadCurrentHouseAsync();

            if (string.IsNullOrEmpty(_houseId))
            {
                MessageBox.Show("Bạn chưa có phòng nên không thể xem hóa đơn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            await LoadData();
        }

        private async Task LoadCurrentHouseAsync()
        {
            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            var memberResp = await client
                .From<HouseMembersData>()
                .Select("*")
                .Where(m => m.UserId == currentUserId && m.IsActive == true)
                .Get();

            if (!memberResp.Models.Any()) return;

            var currentMember = memberResp.Models
                .OrderByDescending(m => m.JoinedAt)
                .First();

            _houseId = currentMember.HouseId.ToString();
        }

        private async Task LoadData()
        {
            try
            {
                var client = await SupabaseHelper.GetClientAsync();
                if (client == null) return;

                if (!Guid.TryParse(_houseId, out Guid houseGuid)) return;

                // Lấy thông tin phòng
                var houseResp = await client
                    .From<HousesData>()
                    .Select("*")
                    .Where(h => h.Id == houseGuid)
                    .Get();

                var house = houseResp.Models.FirstOrDefault();

                // Lấy hóa đơn của phòng
                var invoiceResp = await client
                    .From<InvoicesData>()
                    .Select("*")
                    .Where(x => x.HouseId == houseGuid)
                    .Get();

                //Tìm hóa đơn mới nhất
                var latestInvoice = invoiceResp.Models
                    .OrderByDescending(x => x.CreatedAt)
                    .FirstOrDefault();

                dgvListinvoices.Rows.Clear();

                foreach (var invoice in invoiceResp.Models)
                {
                    int idx = dgvListinvoices.Rows.Add();
                    var row = dgvListinvoices.Rows[idx];

                    row.Cells["colName"].Value = house?.Name ?? "";
                    row.Cells["colTimeAt"].Value = invoice.MonthYear ?? "";
                    row.Cells["colMoney"].Value = (invoice.TotalAmount ?? 0).ToString("N0") + " đ";
                    row.Cells["colDateCreate"].Value = invoice.CreatedAt.ToString("dd/MM/yyyy");

                    //Chỉ hiện "Xem" cho hóa đơn mới nhất
                    if (latestInvoice != null && invoice.Id == latestInvoice.Id)
                        row.Cells["colDetail"].Value = "Xem";
                    else
                        row.Cells["colDetail"].Value = "";

                    row.Tag = (invoice.HouseId?.ToString() ?? "", invoice.Id.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadData: " + ex.Message);
            }
        }

        private async void dgvListinvoices_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvListinvoices.Columns[e.ColumnIndex].Name != "colDetail") return;

            if (dgvListinvoices.Rows[e.RowIndex].Tag is not (string houseId, string invoiceId)) return;

            if (!string.IsNullOrEmpty(houseId))
            {
                frmDetail viewForm = new frmDetail(houseId, invoiceId);
                if (viewForm.ShowDialog() == DialogResult.OK)
                {
                    await LoadData();
                }
            }
            if (string.IsNullOrEmpty(dgvListinvoices.Rows[e.RowIndex].Cells["colDetail"].Value?.ToString()))
            {
                return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Truyền _houseId để sửa phòng hiện tại
            frmEditBill frm = new frmEditBill(_houseId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _ = LoadData();
            }
        }

        private async void btnReload_Click(object sender, EventArgs e)
        {
            await LoadData();
        }
    }
}