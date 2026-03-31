using System;
using System.Threading.Tasks;
using System.Windows.Forms;

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

                dgvListinvoices.Rows.Clear();

                foreach (var invoice in invoiceResp.Models)
                {
                    int idx = dgvListinvoices.Rows.Add();
                    var row = dgvListinvoices.Rows[idx];

                    row.Cells["colName"].Value = house?.Name ?? "";
                    row.Cells["colTimeAt"].Value = invoice.MonthYear ?? "";
                    row.Cells["colMoney"].Value = (invoice.TotalAmount ?? 0).ToString("N0") + " đ";
                    row.Cells["colStatus"].Value = invoice.Status ?? "";
                    row.Cells["colDateCreate"].Value = invoice.CreatedAt.ToString("dd/MM/yyyy");
                    row.Cells["colDetail"].Value = "Xem";

                    row.Tag = invoice.HouseId?.ToString() ?? "";
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

        private async void dgvListinvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvListinvoices.Columns[e.ColumnIndex].Name != "colDetail") return;

            // Lấy houseId từ Tag của dòng
            var row = dgvListinvoices.Rows[e.RowIndex];
            string houseId = row.Tag?.ToString() ?? "";

            if (!string.IsNullOrEmpty(houseId))
            {
                frmBill viewForm = new frmBill(houseId);
                if (viewForm.ShowDialog() == DialogResult.OK)
                {
                    await LoadData();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEditBill frm = new frmEditBill();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _ = LoadData();
            }
        }
    }
}