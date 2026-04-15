using System;
using System.Windows.Forms;
using Supabase;

namespace ThieunuQLPT
{
    public partial class ucNoteitemcard : UserControl
    {
        public NotesData? NoteData { get; private set; } // dữ liệu note hiện tại

        // các event callback ra ngoài
        public event EventHandler? OnViewDetail;
        public event EventHandler? OnPin;
        public event EventHandler? OnDelete;

        public ucNoteitemcard()
        {
            InitializeComponent();
        }

        public void LoadData(NotesData note, string authorName, bool canDelete)
        {
            NoteData = note; // lưu lại dữ liệu

            lblTitle.Text = note.Title ?? "";

            // cắt nội dung hiển thị tối đa 100 ký tự
            string content = note.Content ?? "";
            lblSummary.Text = content.Length > 100
                ? content.Substring(0, 100) + "..."
                : content;

            lblAuthor.Text = $"{authorName}";

            // convert UTC -> local (giờ VN)
            var utc = DateTime.SpecifyKind(note.CreatedAt, DateTimeKind.Utc);
            lblDate.Text = utc.ToLocalTime().ToString("dd/MM/yyyy HH:mm");

            // hiển thị trạng thái ghim
            lblPinicon.Visible = note.IsPinned;
            lblPinicon.Text = "Đã ghim";

            // đổi text nút ghim
            btnPin.Text = note.IsPinned ? "Bỏ ghim" : "Ghim";

            // quyền xóa
            btnDelete.Visible = canDelete;
        }

        private void btnViewdatail_Click(object? sender, EventArgs e)
        {
            // trigger event xem chi tiết
            OnViewDetail?.Invoke(this, EventArgs.Empty);
        }

        private void btnPin_Click(object? sender, EventArgs e)
        {
            // trigger event ghim/bỏ ghim
            OnPin?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            // trigger event xóa
            OnDelete?.Invoke(this, EventArgs.Empty);
        }
    }
}
