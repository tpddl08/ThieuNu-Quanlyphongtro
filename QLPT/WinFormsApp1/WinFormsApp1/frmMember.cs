using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supabase;
using static Supabase.Postgrest.Constants;

namespace ThieunuQLPT
{
    public partial class frmMember : Form
    {
        private HousesData? currentHouse;
        private Guid currentUserId => frmLogin.idLoged;
        private bool isLeader = false;

        public frmMember()
        {
            InitializeComponent();
        }

        private void frmMember_Load(object sender, EventArgs e)
        {
            EnsureDgvColumns();
            checkHaveRoom();
        }

        private void EnsureDgvColumns()
        {
            if (!dgvMember.Columns.Contains("colHouseMemberId"))
            {
                var c = new DataGridViewTextBoxColumn
                {
                    Name = "colHouseMemberId",
                    Visible = false
                };
                dgvMember.Columns.Add(c);
            }

            if (!dgvMember.Columns.Contains("colUserId"))
            {
                var c = new DataGridViewTextBoxColumn
                {
                    Name = "colUserId",
                    Visible = false
                };
                dgvMember.Columns.Add(c);
            }
        }

        private void btnCreateroom_Click(object sender, EventArgs e)
        {
            this.Hide();
            using var frm = new frmCreateroom();
            frm.ShowDialog();
            this.Close();
        }

        private async void checkHaveRoom()
        {
            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            var memberResponse = await client
                .From<HouseMembersData>()
                .Select("*")
                .Where(m => m.UserId == currentUserId && m.IsActive == true)
                .Get();

            if (!memberResponse.Models.Any())
            {
                currentHouse = null;
                isLeader = false;
                btnCreateroom.Visible = true;
                lblNoti.Text = "HIỆN CHƯA CÓ PHÒNG NÀO!";
                await LoadProfileOnly();
                return;
            }

            var currentMember = memberResponse.Models
                .OrderByDescending(m => m.JoinedAt)
                .First();

            isLeader = string.Equals(currentMember.Role, "owner", StringComparison.OrdinalIgnoreCase);

            var houseResponse = await client
                .From<HousesData>()
                .Select("*")
                .Where(h => h.Id == currentMember.HouseId)
                .Get();

            if (!houseResponse.Models.Any())
            {
                currentHouse = null;
                await LoadProfileOnly();
                return;
            }

            currentHouse = houseResponse.Models.First();

            btnCreateroom.Visible = false;
            lblNoti.Text = $"PHÒNG: {currentHouse.Name}";

            await LoadMembersToDGV(currentHouse.Id);
        }


        private async Task LoadProfileOnly()
        {
            dgvMember.Rows.Clear();

            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            var profileResp = await client
                .From<ProfilesData>()
                .Select("*")
                .Where(p => p.Id == currentUserId)
                .Get();

            if (!profileResp.Models.Any())
            {
                int idx = dgvMember.Rows.Add();
                var row = dgvMember.Rows[idx];
                row.Cells["colName"].Value = "";
                row.Cells["colNumberphone"].Value = "";
                row.Cells["colEmail"].Value = "";
                row.Cells["colStatus"].Value = "Đang ở";
                row.Cells["colHouseMemberId"].Value = "";
                row.Cells["colUserId"].Value = currentUserId.ToString();
                return;
            }

            var prof = profileResp.Models.First();
            int i = dgvMember.Rows.Add();
            var r = dgvMember.Rows[i];
            r.Cells["colName"].Value = prof.FullName ?? "";
            r.Cells["colNumberphone"].Value = prof.Phone ?? "";
            r.Cells["colEmail"].Value = prof.Email ?? "";
            r.Cells["colStatus"].Value = "Đang ở";
            r.Cells["colHouseMemberId"].Value = "";
            r.Cells["colUserId"].Value = prof.Id.ToString();
        }

        private async Task LoadMembersToDGV(Guid houseId)
        {
            dgvMember.Rows.Clear();

            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            var membersResp = await client
                .From<HouseMembersData>()
                .Select("*")
                .Where(m => m.HouseId == houseId)
                .Get();

            var userIds = membersResp.Models.Select(m => m.UserId).Distinct().ToList();

            var profilesList = new List<ProfilesData>();
            foreach (var uid in userIds)
            {
                var pr = await client
                    .From<ProfilesData>()
                    .Select("*")
                    .Where(p => p.Id == uid)
                    .Get();

                if (pr?.Models != null && pr.Models.Any())
                    profilesList.Add(pr.Models.First());
            }

            foreach (var hm in membersResp.Models)
            {
                var prof = profilesList.FirstOrDefault(p => p.Id == hm.UserId);

                int idx = dgvMember.Rows.Add();
                var row = dgvMember.Rows[idx];

                row.Cells["colName"].Value = prof?.FullName ?? "";
                row.Cells["colNumberphone"].Value = prof?.Phone ?? "";
                row.Cells["colEmail"].Value = prof?.Email ?? "";
                row.Cells["colStatus"].Value = hm.IsActive ? "Đang ở" : "Rời đi";
                row.Cells["colHouseMemberId"].Value = hm.Id.ToString();
                row.Cells["colUserId"].Value = hm.UserId.ToString();

                row.Tag = null;

                if (!hm.IsActive) row.DefaultCellStyle.BackColor = Color.LightGray;
                else row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (currentHouse == null)
            {
                MessageBox.Show("Bạn chưa có phòng. Tạo phòng trước khi thêm thành viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string phone = Microsoft.VisualBasic.Interaction.InputBox("Nhập số điện thoại:", "Thêm thành viên", "");
            if (string.IsNullOrWhiteSpace(phone)) return;

            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            try
            {
                var profileResp = await client
                    .From<ProfilesData>()
                    .Select("*")
                    .Where(p => p.Phone == phone)
                    .Get();

                if (!profileResp.Models.Any())
                {
                    MessageBox.Show("Người này chưa có tài khoản, không thể thêm vào phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var prof = profileResp.Models.First();
                Guid userId = prof.Id;

                foreach (DataGridViewRow r in dgvMember.Rows)
                {
                    var uid = r.Cells["colUserId"].Value?.ToString() ?? "";
                    if (string.IsNullOrEmpty(uid) || !Guid.TryParse(uid, out Guid g) || g != userId) continue;

                    var status = (r.Cells["colStatus"].Value?.ToString() ?? "").Trim();

                    if (status == "Đang ở")
                    {
                        MessageBox.Show("Người này đã là thành viên của phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (status == "Rời đi")
                    {
                        r.Tag = "add";
                        r.Cells["colStatus"].Value = "Đang ở";
                        r.DefaultCellStyle.BackColor = Color.LightGreen;
                        MessageBox.Show("Đã đánh dấu người này để thêm lại. Nhấn Lưu để xác nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                int idx = dgvMember.Rows.Add();
                var row = dgvMember.Rows[idx];
                row.Cells["colName"].Value = prof.FullName ?? "";
                row.Cells["colNumberphone"].Value = prof.Phone ?? "";
                row.Cells["colEmail"].Value = prof.Email ?? "";
                row.Cells["colStatus"].Value = "Đang ở";
                row.Cells["colHouseMemberId"].Value = "";
                row.Cells["colUserId"].Value = prof.Id.ToString();

                row.Tag = "add";
                row.DefaultCellStyle.BackColor = Color.LightGreen;

                MessageBox.Show("Đã thêm vào danh sách tạm. Nhấn Lưu để xác nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm thành viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMember.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một thành viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentHouse == null)
            {
                MessageBox.Show("Bạn chưa có phòng. Tạo phòng trước khi xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string selUserIdStr = dgvMember.CurrentRow.Cells["colUserId"].Value?.ToString() ?? "";
            Guid.TryParse(selUserIdStr, out Guid selUserId);

            if (selUserId != currentUserId && !isLeader)
            {
                MessageBox.Show("Bạn chỉ có thể rời phòng cho chính mình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn thành viên này Rời đi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            var row = dgvMember.CurrentRow;

            var pending = row.Tag as string;
            if (pending == "add")
            {
                dgvMember.Rows.Remove(row);
                MessageBox.Show("Đã bỏ hàng tạm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            row.Tag = "leave";
            row.Cells["colStatus"].Value = "Rời đi";
            row.DefaultCellStyle.BackColor = Color.LightGray;

            MessageBox.Show("Đã đánh dấu rời phòng tạm. Nhấn Lưu để xác nhận thay đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void dgvMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvMember.Columns[e.ColumnIndex].Name != "colEdit") return;

            var row = dgvMember.Rows[e.RowIndex];
            string rowUserIdStr = row.Cells["colUserId"].Value?.ToString() ?? "";
            Guid.TryParse(rowUserIdStr, out Guid rowUserId);

            if (currentHouse == null)
            {
                if (rowUserId == currentUserId)
                {
                    EditProfileRow(row); 
                }
                else
                {
                    MessageBox.Show("Bạn chỉ có thể chỉnh thông tin của chính mình khi chưa có phòng!", "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            if (rowUserId == currentUserId)
            {
                EditProfileRow(row);
            }
            else
            {
                MessageBox.Show("Bạn chỉ có thể chỉnh thông tin của chính mình!", "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EditProfileRow(DataGridViewRow row)
        {
            string name = row.Cells["colName"].Value?.ToString() ?? "";
            string phone = row.Cells["colNumberphone"].Value?.ToString() ?? "";
            string email = row.Cells["colEmail"].Value?.ToString() ?? "";

            string newName = Microsoft.VisualBasic.Interaction.InputBox("Họ và tên:", "Chỉnh sửa", name ?? "");
            string newPhone = Microsoft.VisualBasic.Interaction.InputBox("Số điện thoại:", "Chỉnh sửa", phone ?? "");
            string newEmail = Microsoft.VisualBasic.Interaction.InputBox("Email:", "Chỉnh sửa", email ?? "");

            if (string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newPhone))
            {
                MessageBox.Show("Họ tên và số điện thoại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            row.Cells["colName"].Value = newName;
            row.Cells["colNumberphone"].Value = newPhone;
            row.Cells["colEmail"].Value = newEmail;

            var pending = row.Tag as string;
            if (pending != "add")
            {
                row.Tag = "edit";
                row.DefaultCellStyle.BackColor = Color.LightYellow;
            }

            MessageBox.Show("Đã cập nhật trên giao diện! Nhấn Lưu để lưu thay đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            if (currentHouse == null)
            {
                foreach (DataGridViewRow row in dgvMember.Rows)
                {
                    var pending = row.Tag as string;
                    if (string.IsNullOrEmpty(pending)) continue;

                    string userIdStr = row.Cells["colUserId"].Value?.ToString() ?? "";
                    if (!Guid.TryParse(userIdStr, out Guid userId)) continue;
                    if (userId != currentUserId) continue;

                    var resp = await client.From<ProfilesData>().Select("*").Where(p => p.Id == userId).Get();
                    var existing = resp.Models.FirstOrDefault();
                    if (existing != null)
                    {
                        existing.FullName = row.Cells["colName"].Value?.ToString();
                        existing.Phone = row.Cells["colNumberphone"].Value?.ToString();
                        existing.Email = row.Cells["colEmail"].Value?.ToString();
                        await client.From<ProfilesData>().Update(existing);
                    }

                    row.Tag = null;
                    row.DefaultCellStyle.BackColor = Color.White;
                }

                MessageBox.Show("Đã lưu thông tin cá nhân!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadProfileOnly();
                return;
            }

            foreach (DataGridViewRow row in dgvMember.Rows)
            {
                var pending = row.Tag as string;
                if (string.IsNullOrEmpty(pending)) continue;

                string userIdStr = row.Cells["colUserId"].Value?.ToString() ?? "";
                Guid.TryParse(userIdStr, out Guid userId);

                try
                {
                    if (pending == "add")
                    {
                        if (userId == Guid.Empty) continue;

                        var checkResp = await client.From<HouseMembersData>()
                                                   .Select("*")
                                                   .Where(m => m.HouseId == currentHouse.Id && m.UserId == userId)
                                                   .Get();

                        var existing = checkResp.Models.FirstOrDefault();
                        if (existing != null)
                        {
                            existing.IsActive = true;
                            existing.JoinedAt = DateTime.Now;
                            existing.LeftAt = null;
                            await client.From<HouseMembersData>().Update(existing);
                        }
                        else
                        {
                            var newMember = new HouseMembersData
                            {
                                HouseId = currentHouse.Id,
                                UserId = userId,
                                Role = "member",
                                JoinedAt = DateTime.Now,
                                IsActive = true
                            };
                            await client.From<HouseMembersData>().Insert(newMember);
                        }

                        row.Tag = null;
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                    else if (pending == "edit")
                    {
                        if (userId == Guid.Empty) continue;

                        var resp = await client.From<ProfilesData>().Select("*").Where(p => p.Id == userId).Get();
                        var existingProfile = resp.Models.FirstOrDefault();
                        if (existingProfile != null)
                        {
                            existingProfile.FullName = row.Cells["colName"].Value?.ToString();
                            existingProfile.Phone = row.Cells["colNumberphone"].Value?.ToString();
                            existingProfile.Email = row.Cells["colEmail"].Value?.ToString();
                            await client.From<ProfilesData>().Update(existingProfile);
                        }

                        row.Tag = null;
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu (add/edit): {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            bool currentUserMarkedLeave = false;
            foreach (DataGridViewRow row in dgvMember.Rows)
            {
                var pending = row.Tag as string;
                if (pending != "leave") continue;

                string userIdStr = row.Cells["colUserId"].Value?.ToString() ?? "";
                string houseMemberIdStr = row.Cells["colHouseMemberId"].Value?.ToString() ?? "";

                Guid.TryParse(userIdStr, out Guid userId);
                Guid.TryParse(houseMemberIdStr, out Guid houseMemberId);

                try
                {
                    if (houseMemberId != Guid.Empty)
                    {
                        var resp = await client.From<HouseMembersData>().Select("*").Where(m => m.Id == houseMemberId).Get();
                        var existing = resp.Models.FirstOrDefault();
                        if (existing != null)
                        {
                            existing.IsActive = false;
                            existing.LeftAt = DateTime.Now;
                            await client.From<HouseMembersData>().Update(existing);
                        }
                    }
                    else if (userId != Guid.Empty)
                    {
                        var resp2 = await client.From<HouseMembersData>()
                                                .Select("*")
                                                .Where(m => m.HouseId == currentHouse.Id && m.UserId == userId)
                                                .Get();
                        var existing2 = resp2.Models.FirstOrDefault();
                        if (existing2 != null)
                        {
                            existing2.IsActive = false;
                            existing2.LeftAt = DateTime.Now;
                            await client.From<HouseMembersData>().Update(existing2);
                        }
                    }

                    if (userId == currentUserId) currentUserMarkedLeave = true;

                    row.Tag = null;
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.Cells["colStatus"].Value = "Rời đi";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu (leave): {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (currentUserMarkedLeave && currentHouse != null)
            {
                try
                {
                    var allResp = await client.From<HouseMembersData>()
                                              .Select("*")
                                              .Where(m => m.HouseId == currentHouse.Id && m.IsActive == true)
                                              .Get();

                    var newLeader = allResp.Models.OrderBy(m => m.JoinedAt).FirstOrDefault();
                    if (newLeader != null)
                    {
                        newLeader.Role = "owner";
                        await client.From<HouseMembersData>().Update(newLeader);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi chuyển quyền leader: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (currentHouse != null)
            {
                MessageBox.Show("Đã lưu thay đổi!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadMembersToDGV(currentHouse.Id);
            }
        }

    }
}
