using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supabase;

namespace ThieunuQLPT
{
    public partial class frmNotedetail : Form
    {
        private NotesData _note;          // dữ liệu note hiện tại
        private readonly bool _canDelete; // quyền xóa

        public frmNotedetail(NotesData note, string authorName, bool canDelete)
        {
            InitializeComponent();

            _note = note;
            _canDelete = canDelete;

            this.Load += frmNotedetail_Load; // event load form
            LoadNoteData(authorName);        // bind dữ liệu ban đầu
        }

        private void frmNotedetail_Load(object? sender, EventArgs e)
        {
            UpdatePinUI(); // cập nhật trạng thái ghim
        }

        private void LoadNoteData(string authorName)
        {
            lblTitle.Text = _note.Title ?? "";
            lblAuthor.Text = $" {authorName}";

            // convert UTC -> local (giờ VN)
            var utc = DateTime.SpecifyKind(_note.CreatedAt, DateTimeKind.Utc);
            lblDate.Text = utc.ToLocalTime().ToString("dd/MM/yyyy HH:mm");

            rtbContent.Text = _note.Content ?? "";
            rtbContent.ReadOnly = true; // chỉ đọc

            btnDelete.Visible = _canDelete; // quyền xóa

            UpdatePinUI(); // sync UI ghim
        }

        private void UpdatePinUI()
        {
            // cập nhật UI theo trạng thái ghim
            if (_note.IsPinned)
            {
                lblPinstatus.Text = "Đã ghim";
                lblPinstatus.Visible = true;
                btnTogglepin.Text = "Bỏ ghim";
            }
            else
            {
                lblPinstatus.Visible = false;
                btnTogglepin.Text = "Ghim";
            }
        }

        private async void btnTogglepin_Click(object? sender, EventArgs e)
        {
            await BtnTogglepin_ClickAsync(); // xử lý async
        }

        private async Task BtnTogglepin_ClickAsync()
        {
            try
            {
                _note.IsPinned = !_note.IsPinned; // toggle trạng thái

                var supabase = await SupabaseHelper.GetClientAsync();
                if (supabase == null) return;

                // update DB
                await supabase
                    .From<NotesData>()
                    .Where(n => n.Id == _note.Id)
                    .Set(n => n.IsPinned, _note.IsPinned)
                    .Update();

                UpdatePinUI(); // cập nhật UI

                string msg = _note.IsPinned ? "Đã ghim bảng tin!" : "Đã bỏ ghim bảng tin!";
                MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật ghim: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object? sender, EventArgs e)
        {
            await BtnDelete_ClickAsync(); // xử lý async
        }

        private async Task BtnDelete_ClickAsync()
        {
            // confirm xóa
            var result = MessageBox.Show(
                $"Bạn có chắc muốn xóa bảng tin \"{_note.Title}\"?\nHành động này không thể hoàn tác.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes) return;

            try
            {
                // disable nút khi đang xử lý
                btnDelete.Enabled = false;
                btnDelete.Text = "Đang xóa...";

                var supabase = await SupabaseHelper.GetClientAsync();
                if (supabase == null) return;

                // xóa trên DB
                await supabase
                    .From<NotesData>()
                    .Where(n => n.Id == _note.Id)
                    .Delete();

                MessageBox.Show("Đã xóa bảng tin thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close(); // đóng form sau khi xóa
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // enable lại nếu lỗi
                btnDelete.Enabled = true;
                btnDelete.Text = "Xóa";
            }
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            this.Close(); // đóng form
        }
    }
}
