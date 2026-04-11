using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supabase;

namespace ThieunuQLPT
{
    public partial class frmNoteslist : Form
    {
        private HousesData? currentHouse;
        private Guid currentUserId = frmLogin.idLoged; // user hiện tại

        // cache id -> tên user
        private Dictionary<Guid, string> _profilesDict = new Dictionary<Guid, string>();

        public frmNoteslist()
        {
            InitializeComponent();

            this.Load += frmNoteslist_Load; // event load form
        }

        private async void frmNoteslist_Load(object? sender, EventArgs e)
        {
            await LoadCurrentHouseAsync(); // lấy phòng hiện tại
            await LoadNotesAsync();        // load danh sách note
        }

        private async Task LoadCurrentHouseAsync()
        {
            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            // lấy membership active của user
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

        private async Task LoadNotesAsync()
        {
            try
            {
                flpNotelist.Controls.Clear(); // clear UI

                if (currentHouse == null)
                {
                    MessageBox.Show("Bạn chưa có phòng.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var supabase = await SupabaseHelper.GetClientAsync();
                if (supabase == null) return;

                // lấy danh sách notes theo house
                var notesRes = await supabase
                    .From<NotesData>()
                    .Where(n => n.HouseId == currentHouse.Id)
                    .Get();

                var notes = notesRes.Models.ToList();

                // load toàn bộ profile để map tên
                var profilesRes = await supabase
                    .From<ProfilesData>()
                    .Get();

                _profilesDict.Clear();
                foreach (var p in profilesRes.Models)
                    _profilesDict[p.Id] = p.FullName ?? "Không rõ";

                // sort: ghim lên trước, sau đó theo thời gian giảm dần
                notes.Sort((a, b) =>
                {
                    if (a.IsPinned != b.IsPinned)
                        return b.IsPinned.CompareTo(a.IsPinned);
                    return b.CreatedAt.CompareTo(a.CreatedAt);
                });

                // nếu không có note
                if (notes.Count == 0)
                {
                    var lblEmpty = new Label
                    {
                        Text = "Chưa có bảng tin nào.",
                        AutoSize = true,
                        Padding = new Padding(10)
                    };
                    flpNotelist.Controls.Add(lblEmpty);
                    return;
                }

                // render từng note
                foreach (var note in notes)
                {
                    string authorName = GetAuthorName(note);
                    bool canDelete = note.CreatedBy == currentUserId;

                    var card = new ucNoteitemcard();
                    card.LoadData(note, authorName, canDelete);

                    // gán event
                    card.OnViewDetail += ucNoteitemcard_OnViewDetail;
                    card.OnPin += ucNoteitemcard_OnPin;
                    card.OnDelete += ucNoteitemcard_OnDelete;

                    flpNotelist.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải bảng tin: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetAuthorName(NotesData note)
        {
            // lấy tên từ cache
            if (note.CreatedBy.HasValue && _profilesDict.ContainsKey(note.CreatedBy.Value))
                return _profilesDict[note.CreatedBy.Value];

            return "Không rõ";
        }

        private async void ucNoteitemcard_OnViewDetail(object? sender, EventArgs e)
        {
            if (sender is not ucNoteitemcard card || card.NoteData == null)
                return;

            var note = card.NoteData;

            string authorName = GetAuthorName(note);
            bool canDelete = note.CreatedBy == currentUserId;

            // mở form chi tiết
            var detailForm = new frmNotedetail(note, authorName, canDelete);
            detailForm.FormClosed += frmNotedetail_FormClosed;
            detailForm.ShowDialog(this);
        }

        private async void ucNoteitemcard_OnPin(object? sender, EventArgs e)
        {
            if (sender is not ucNoteitemcard card || card.NoteData == null)
                return;

            await TogglePinAsync(card.NoteData); // toggle ghim
        }

        private async void ucNoteitemcard_OnDelete(object? sender, EventArgs e)
        {
            if (sender is not ucNoteitemcard card || card.NoteData == null)
                return;

            await DeleteNoteAsync(card.NoteData); // xóa note
        }

        private async void frmNotedetail_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // reload khi đóng form detail
            await LoadCurrentHouseAsync();
            await LoadNotesAsync();
        }

        private async void btnCreatenote_Click(object? sender, EventArgs e)
        {
            // mở form tạo note
            var createForm = new frmNotecreate();
            createForm.FormClosed += frmNotecreate_FormClosed;
            createForm.ShowDialog(this);
        }

        private async void frmNotecreate_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // reload sau khi tạo note
            await LoadCurrentHouseAsync();
            await LoadNotesAsync();
        }

        private async Task TogglePinAsync(NotesData note)
        {
            try
            {
                note.IsPinned = !note.IsPinned; // toggle trạng thái

                var supabase = await SupabaseHelper.GetClientAsync();
                if (supabase == null) return;

                // update DB
                await supabase
                    .From<NotesData>()
                    .Where(n => n.Id == note.Id)
                    .Set(n => n.IsPinned, note.IsPinned)
                    .Update();

                await LoadNotesAsync(); // reload UI
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật ghim: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DeleteNoteAsync(NotesData note)
        {
            // confirm xóa
            var result = MessageBox.Show(
                $"Bạn có chắc muốn xóa bảng tin \"{note.Title}\"?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes) return;

            try
            {
                var supabase = await SupabaseHelper.GetClientAsync();
                if (supabase == null) return;

                // xóa DB
                await supabase
                    .From<NotesData>()
                    .Where(n => n.Id == note.Id)
                    .Delete();

                MessageBox.Show("Đã xóa bảng tin thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadNotesAsync(); // reload UI
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa bảng tin: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
