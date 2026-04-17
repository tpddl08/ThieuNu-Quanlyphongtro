using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supabase;
using Microsoft.VisualBasic;

namespace ThieunuQLPT
{
    public partial class frmChores : Form
    {
        private HousesData? currentHouse;
        private Guid currentUserId = frmLogin.idLoged; // user hiện tại

        public frmChores()
        {
            InitializeComponent();
        }

        private async void frmChores_Load(object sender, EventArgs e)
        {
            EnsureHiddenColumns(); // đảm bảo có cột ẩn

            await LoadCurrentHouseAsync(); // lấy phòng hiện tại

            if (currentHouse == null)
            {
                MessageBox.Show("Bạn chưa có phòng nên chưa thể xem công việc trực nhật.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            await LoadChoresToDGV(currentHouse.Id); // load dữ liệu
        }

        private void EnsureHiddenColumns()
        {
            // cột lưu id chore
            if (!dgvChores.Columns.Contains("colChoreId"))
            {
                dgvChores.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colChoreId",
                    Visible = false
                });
            }

            // cột lưu id user được giao
            if (!dgvChores.Columns.Contains("colAssignedToId"))
            {
                dgvChores.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colAssignedToId",
                    Visible = false
                });
            }
        }

        private async Task LoadCurrentHouseAsync()
        {
            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            // lấy membership hiện tại
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

        private async Task LoadChoresToDGV(Guid houseId)
        {
            dgvChores.Rows.Clear();

            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            // lấy danh sách công việc
            var choresResp = await client
                .From<ChoresData>()
                .Select("*")
                .Where(c => c.HouseId == houseId)
                .Get();

            var chores = choresResp.Models.ToList();

            // lấy danh sách user id để query profile
            var userIds = chores
                .Where(c => c.AssignedTo.HasValue)
                .Select(c => c.AssignedTo!.Value)
                .Distinct()
                .ToList();

            var profilesList = new List<ProfilesData>();

            // load profile từng user
            foreach (var uid in userIds)
            {
                var pr = await client
                    .From<ProfilesData>()
                    .Select("*")
                    .Where(p => p.Id == uid)
                    .Get();

                if (pr.Models.Any())
                    profilesList.Add(pr.Models.First());
            }

            // bind dữ liệu vào grid
            foreach (var chore in chores)
            {
                var prof = chore.AssignedTo.HasValue
                    ? profilesList.FirstOrDefault(p => p.Id == chore.AssignedTo.Value)
                    : null;

                int idx = dgvChores.Rows.Add();
                var row = dgvChores.Rows[idx];

                row.Cells["colChoreId"].Value = chore.Id.ToString();
                row.Cells["colAssignedToId"].Value = chore.AssignedTo?.ToString() ?? "";
                row.Cells["colNamework"].Value = chore.TaskName ?? "";
                row.Cells["colName"].Value = prof?.FullName ?? "";

                // convert UTC -> local (giờ VN)
                if (chore.DueDate.HasValue)
                {
                    var utc = DateTime.SpecifyKind(chore.DueDate.Value, DateTimeKind.Utc);
                    var vnTime = utc.ToLocalTime();

                    row.Cells["colTime"].Value = vnTime.ToString("dd/MM/yyyy HH:mm");
                }
                else
                {
                    row.Cells["colTime"].Value = "";
                }

                row.Cells["colStatus"].Value = chore.IsCompleted ? "Hoàn thành" : "Chưa xong";

                row.Tag = null; // không có thay đổi

                // đổi màu theo trạng thái
                if (chore.IsCompleted)
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                else
                    row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (currentHouse == null)
            {
                MessageBox.Show("Bạn chưa có phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // nhập tên công việc
            string taskName = Interaction.InputBox("Nhập tên công việc:", "Thêm công việc", "");
            if (string.IsNullOrWhiteSpace(taskName))
                return;

            // nhập số điện thoại người được giao
            string phone = Interaction.InputBox("Nhập số điện thoại người được giao (để trống = giao cho bạn):", "Thêm công việc", "");

            DateTime dueDate = DateTime.Now.Date;

            // nhập hạn làm
            string dueText = Interaction.InputBox("Nhập hạn làm (dd/MM/yyyy HH:mm):", "Thêm công việc", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            if (!string.IsNullOrWhiteSpace(dueText))
            {
                if (!DateTime.TryParseExact(dueText.Trim(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDate))
                {
                    MessageBox.Show("Ngày không hợp lệ. Ví dụ đúng: 29/03/2026 08:30", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            Guid assignedToId = currentUserId;
            string assignedName = "";

            // tìm user theo phone
            if (!string.IsNullOrWhiteSpace(phone))
            {
                var profileResp = await client
                    .From<ProfilesData>()
                    .Select("*")
                    .Where(p => p.Phone == phone)
                    .Get();

                if (!profileResp.Models.Any())
                {
                    MessageBox.Show("Không tìm thấy người dùng theo số điện thoại này.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var prof = profileResp.Models.First();

                // kiểm tra có trong phòng không
                var memberResp = await client
                    .From<HouseMembersData>()
                    .Select("*")
                    .Where(m => m.HouseId == currentHouse.Id && m.UserId == prof.Id && m.IsActive == true)
                    .Get();

                if (!memberResp.Models.Any())
                {
                    MessageBox.Show("Người này không phải thành viên đang ở trong phòng.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                assignedToId = prof.Id;
                assignedName = prof.FullName ?? "";
            }
            else
            {
                // tự giao cho mình
                var selfResp = await client
                    .From<ProfilesData>()
                    .Select("*")
                    .Where(p => p.Id == currentUserId)
                    .Get();

                assignedName = selfResp.Models.FirstOrDefault()?.FullName ?? "";
            }

            // thêm dòng tạm trên UI
            int idx = dgvChores.Rows.Add();
            var row = dgvChores.Rows[idx];

            row.Cells["colChoreId"].Value = "";
            row.Cells["colAssignedToId"].Value = assignedToId.ToString();
            row.Cells["colNamework"].Value = taskName.Trim();
            row.Cells["colName"].Value = assignedName;
            row.Cells["colTime"].Value = dueDate.ToString("dd/MM/yyyy HH:mm");
            row.Cells["colStatus"].Value = "Chưa xong";

            row.Tag = "add"; // đánh dấu thêm mới
            row.DefaultCellStyle.BackColor = Color.LightYellow;

            MessageBox.Show("Đã thêm công việc tạm trên giao diện. Nhấn Lưu để ghi xuống database.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvChores.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một công việc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvChores.CurrentRow;

            row.Tag = "delete"; // đánh dấu xóa
            row.DefaultCellStyle.BackColor = Color.LightGray;
            row.Cells["colStatus"].Value = "Đã xóa trên giao diện";

            MessageBox.Show("Đã đánh dấu xóa. Nhấn Lưu để xác nhận.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (dgvChores.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một công việc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvChores.CurrentRow;

            row.Cells["colStatus"].Value = "Hoàn thành";
            row.DefaultCellStyle.BackColor = Color.LightGreen;

            // nếu không phải thêm mới thì đánh dấu sửa
            if ((row.Tag as string) != "add")
                row.Tag = "edit";

            MessageBox.Show("Đã đánh dấu hoàn thành trên giao diện. Nhấn Lưu để cập nhật database.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (currentHouse == null)
            {
                MessageBox.Show("Bạn chưa có phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            try
            {
                foreach (DataGridViewRow row in dgvChores.Rows)
                {
                    if (row.IsNewRow) continue;

                    string tag = row.Tag as string ?? "";
                    if (string.IsNullOrEmpty(tag)) continue;

                    string choreIdStr = row.Cells["colChoreId"].Value?.ToString() ?? "";
                    string taskName = row.Cells["colNamework"].Value?.ToString() ?? "";
                    string assignedToIdStr = row.Cells["colAssignedToId"].Value?.ToString() ?? "";
                    string dueText = row.Cells["colTime"].Value?.ToString() ?? "";
                    string status = row.Cells["colStatus"].Value?.ToString() ?? "";

                    // xử lý xóa
                    if (tag == "delete")
                    {
                        if (Guid.TryParse(choreIdStr, out Guid choreId) && choreId != Guid.Empty)
                        {
                            await client
                                .From<ChoresData>()
                                .Where(c => c.Id == choreId)
                                .Delete();
                        }

                        continue;
                    }

                    // parse ngày
                    if (!DateTime.TryParseExact(dueText.Trim(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate))
                    {
                        dueDate = DateTime.Now;
                    }

                    // convert local -> UTC để lưu DB
                    dueDate = DateTime.SpecifyKind(dueDate, DateTimeKind.Local).ToUniversalTime();

                    Guid? assignedTo = null;
                    if (Guid.TryParse(assignedToIdStr, out Guid parsedAssignedTo) && parsedAssignedTo != Guid.Empty)
                        assignedTo = parsedAssignedTo;
                    else
                        assignedTo = currentUserId;

                    bool isCompleted = string.Equals(status.Trim(), "Hoàn thành", StringComparison.OrdinalIgnoreCase);

                    // lưu thời gian hoàn thành theo UTC
                    DateTime? completedAt = isCompleted ? DateTime.UtcNow : null;

                    // thêm mới
                    if (string.IsNullOrWhiteSpace(choreIdStr))
                    {
                        var newChore = new ChoresData
                        {
                            HouseId = currentHouse.Id,
                            TaskName = taskName.Trim(),
                            AssignedTo = assignedTo,
                            DueDate = dueDate,
                            IsCompleted = isCompleted,
                            CompletedAt = completedAt
                        };

                        await client.From<ChoresData>().Insert(newChore);

                        row.Tag = null;
                    }
                    // cập nhật
                    else if (Guid.TryParse(choreIdStr, out Guid existingId) && existingId != Guid.Empty)
                    {
                        var resp = await client
                            .From<ChoresData>()
                            .Select("*")
                            .Where(c => c.Id == existingId)
                            .Get();

                        var existing = resp.Models.FirstOrDefault();
                        if (existing != null)
                        {
                            existing.TaskName = taskName.Trim();
                            existing.AssignedTo = assignedTo;
                            existing.DueDate = dueDate;
                            existing.IsCompleted = isCompleted;
                            existing.CompletedAt = completedAt;

                            await client.From<ChoresData>().Update(existing);
                        }

                        row.Tag = null;
                    }
                }

                MessageBox.Show("Đã lưu thay đổi công việc trực nhật!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadChoresToDGV(currentHouse.Id); // reload dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu công việc: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
