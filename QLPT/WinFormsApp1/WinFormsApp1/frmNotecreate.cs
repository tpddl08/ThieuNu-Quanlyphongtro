using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supabase;

namespace ThieunuQLPT
{
    public partial class frmNotecreate : Form
    {
        private HousesData? currentHouse;
        private Guid currentUserId = frmLogin.idLoged; // user hiện tại

        public frmNotecreate()
        {
            InitializeComponent();

            // ẩn label lỗi ban đầu
            lblError.Text = "";
            lblError.Visible = false;

            this.Load += frmNotecreate_Load; // event load form
        }

        private async void frmNotecreate_Load(object? sender, EventArgs e)
        {
            await LoadCurrentHouseAsync(); // lấy phòng hiện tại
        }

        private async Task LoadCurrentHouseAsync()
        {
            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            // lấy membership active
            var memberResponse = await client
                .From<HouseMembersData>()
                .Select("*")
                .Where(m => m.UserId == currentUserId && m.IsActive == true)
                .Get();

            if (!memberResponse.Models.Any())
            {
                currentHouse = null;
                return;
            }

            // lấy membership mới nhất
            var currentMember = memberResponse.Models
                .OrderByDescending(m => m.JoinedAt)
                .First();

            // lấy thông tin phòng
            var houseResponse = await client
                .From<HousesData>()
                .Select("*")
                .Where(h => h.Id == currentMember.HouseId)
                .Get();

            currentHouse = houseResponse.Models.FirstOrDefault();
        }

        private async void btnSubmit_Click(object? sender, EventArgs e)
        {
            await BtnSubmit_ClickAsync(); // xử lý async
        }

        private async Task BtnSubmit_ClickAsync()
        {
            // validate phòng
            if (currentHouse == null)
            {
                ShowError("Bạn chưa có phòng.");
                return;
            }

            // validate tiêu đề
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                ShowError("Vui lòng nhập tiêu đề.");
                txtTitle.Focus();
                return;
            }

            // validate nội dung
            if (string.IsNullOrWhiteSpace(rtbContent.Text))
            {
                ShowError("Vui lòng nhập nội dung.");
                rtbContent.Focus();
                return;
            }

            HideError();

            // disable nút khi đang submit
            btnSubmit.Enabled = false;
            btnSubmit.Text = "Đang đăng...";

            try
            {
                var supabase = await SupabaseHelper.GetClientAsync();
                if (supabase == null) return;

                // tạo note mới
                var newNote = new NotesData
                {
                    HouseId = currentHouse.Id,
                    Title = txtTitle.Text.Trim(),
                    Content = rtbContent.Text.Trim(),
                    CreatedBy = currentUserId,
                    IsPinned = false,
                    CreatedAt = DateTime.Now // thời gian tạo (local)
                };

                // insert DB
                await supabase.From<NotesData>().Insert(newNote);

                MessageBox.Show("Đăng bảng tin thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close(); // đóng form sau khi tạo
            }
            catch (Exception ex)
            {
                // hiển thị lỗi
                ShowError($"Lỗi: {ex.Message}");

                // enable lại nút
                btnSubmit.Enabled = true;
                btnSubmit.Text = "Đăng bảng tin";
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.Close(); // hủy tạo
        }

        private void ShowError(string message)
        {
            // hiển thị lỗi
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void HideError()
        {
            // ẩn lỗi
            lblError.Visible = false;
        }
    }
}
