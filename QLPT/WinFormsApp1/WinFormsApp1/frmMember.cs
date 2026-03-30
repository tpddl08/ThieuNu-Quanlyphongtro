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
        private Guid currentUserId = frmLogin.idLoged;
        private bool isLeader = false;

        public frmMember()
        {
            InitializeComponent();
        }

        private async void frmMember_Load(object sender, EventArgs e)
        {


            //Tạo cột id của phòng ẩn
            if (!dgvMember.Columns.Contains("colHouseMemberId"))
            {
                var c = new DataGridViewTextBoxColumn
                {
                    Name = "colHouseMemberId",
                    Visible = false
                };
                dgvMember.Columns.Add(c);
            }

            //Tạo cột id của người dùng ẩn
            if (!dgvMember.Columns.Contains("colUserId"))
            {
                var c = new DataGridViewTextBoxColumn
                {
                    Name = "colUserId",
                    Visible = false
                };
                dgvMember.Columns.Add(c);
            }

            if (!dgvMember.Columns.Contains("colPaidStatus"))
            {
                var c = new DataGridViewCheckBoxColumn
                {
                    Name = "colPaidStatus",
                    HeaderText = "Đã đóng tiền"
                };
                dgvMember.Columns.Add(c);
            }

            //Gọi Database để kiểm tra người dùng có phòng hay chưa
            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            var memberResponse = await client
                .From<HouseMembersData>()
                .Select("*")
                .Where(m => m.UserId == currentUserId && m.IsActive == true)
                .Get();

            //Không tìm thấy
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
                .OrderByDescending(m => m.JoinedAt) //Nếu người đó có nhiều phòng thì chọn phòng tham gia gần nhất
                .First();

            //Kiểm tra người đó là trưởng phòng
            isLeader = string.Equals(currentMember.Role, "owner", StringComparison.OrdinalIgnoreCase);

            //Lấy thông tin phòng hiện tại
            var houseResponse = await client
                .From<HousesData>()
                .Select("*")
                .Where(h => h.Id == currentMember.HouseId)
                .Get();

            //Không tìm thấy phòng thì chỉ hiển thị thông tin cá nhân
            if (!houseResponse.Models.Any())
            {
                currentHouse = null;
                await LoadProfileOnly();
                return;
            }

            currentHouse = houseResponse.Models.First();

            btnCreateroom.Visible = false;
            lblNoti.Text = $"PHÒNG: {currentHouse.Name}";

            await LoadMembersToDGV(currentHouse.Id); //Hiển thị thành viên nếu có phòng

        }

        //Tạo phòng
        private void btnCreateroom_Click(object sender, EventArgs e)
        {
            this.Hide();
            using var frm = new frmCreateroom();
            frm.ShowDialog();
            this.Close();
        }

        //Hiển thị thông tin của người dùng
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
                MessageBox.Show("Không tìm thấy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            r.Cells["colPaidStatus"].Value = false; 
        }

        //Tải thành viên của phòng
        private async Task LoadMembersToDGV(Guid houseId)
        {
            dgvMember.Rows.Clear(); //Làm mới dgv

            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            //Tìm thành viên cùng phòng
            var membersResp = await client
                .From<HouseMembersData>()
                .Select("*")
                .Where(m => m.HouseId == houseId)
                .Get();

            var userIds = membersResp.Models.Select(m => m.UserId).Distinct().ToList();

            //Lấy thông tin thành viên
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

            //Hiển thị thông tin lên dgv
            foreach (var hm in membersResp.Models)
            {
                var prof = profilesList.FirstOrDefault(p => p.Id == hm.UserId);

                int idx = dgvMember.Rows.Add();
                var row = dgvMember.Rows[idx];
                bool isPaid = hm.IsPaid ?? false;

                row.Cells["colName"].Value = prof?.FullName ?? "";
                row.Cells["colNumberphone"].Value = prof?.Phone ?? "";
                row.Cells["colEmail"].Value = prof?.Email ?? "";
                row.Cells["colStatus"].Value = hm.IsActive ? "Đang ở" : "Rời đi";
                row.Cells["colHouseMemberId"].Value = hm.Id.ToString();
                row.Cells["colUserId"].Value = hm.UserId.ToString();
                row.Cells["colPaidStatus"].Value = isPaid;

                if (hm.UserId == currentUserId)
                {
                    row.Cells["colEdit"].Value = "Sửa";
                }
                else
                {
                    row.Cells["colEdit"].Value = ""; // để trống cho người khác
                }

                row.Tag = null;

                if (!hm.IsActive) row.DefaultCellStyle.BackColor = Color.LightGray;
                else row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        //Thêm hàng để thêm thành viên
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (currentHouse == null)
            {
                MessageBox.Show("Bạn chưa có phòng. Tạo phòng trước khi thêm thành viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Nhập số điện thoại để thêm thành viên
            string phone = Microsoft.VisualBasic.Interaction.InputBox("Nhập số điện thoại:", "Thêm thành viên", "");
            if (string.IsNullOrWhiteSpace(phone)) return;

            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            try
            {
                //tìm thành viên có số điện thoại cần thêm
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

                //Hiển thị thông tin người muốn thêm lên dgv
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
                        MessageBox.Show("Đã thêm lại người này. Nhấn Lưu để xác nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        //Xóa thành viên, thành viên rời đi
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

            //Đánh dấu
            row.Tag = "leave";
            row.Cells["colStatus"].Value = "Rời đi";
            row.DefaultCellStyle.BackColor = Color.LightGray;

            MessageBox.Show("Đã rời phòng. Nhấn Lưu để xác nhận thay đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Chỉnh sửa thông tin trên dgv
        private void dgvMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvMember.Columns[e.ColumnIndex].Name != "colEdit") return;

            //Lấy thông tin dòng được chọn
            var row = dgvMember.Rows[e.RowIndex];
            string rowUserIdStr = row.Cells["colUserId"].Value?.ToString() ?? "";
            Guid.TryParse(rowUserIdStr, out Guid rowUserId);

            //Chỉ được phép tự chỉnh sửa thông tin cá nhân
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

            //Nhập thông tin cần sửa
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

        //Lưu thông tin lên db
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var client = await SupabaseHelper.GetClientAsync();
            if (client == null) return;

            // Nếu chưa có phòng thì chỉ lưu thông tin cá nhân
            if (currentHouse == null)
            {
                foreach (DataGridViewRow row in dgvMember.Rows)
                {
                    var pending = row.Tag as string;
                    if (string.IsNullOrEmpty(pending)) continue;

                    // Lấy userId từ dòng
                    string userIdStr = row.Cells["colUserId"].Value?.ToString() ?? "";
                    if (!Guid.TryParse(userIdStr, out Guid userId)) continue;
                    if (userId != currentUserId) continue; // chỉ cho phép sửa chính mình

                    // Lấy profile từ DB và cập nhật
                    var resp = await client.From<ProfilesData>().Select("*").Where(p => p.Id == userId).Get();
                    var existing = resp.Models.FirstOrDefault();
                    if (existing != null)
                    {
                        existing.FullName = row.Cells["colName"].Value?.ToString();
                        existing.Phone = row.Cells["colNumberphone"].Value?.ToString();
                        existing.Email = row.Cells["colEmail"].Value?.ToString();
                        await client.From<ProfilesData>().Update(existing);
                    }

                    // Reset trạng thái dòng
                    row.Tag = null;
                    row.DefaultCellStyle.BackColor = Color.White;
                }

                MessageBox.Show("Đã lưu thông tin cá nhân!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadProfileOnly();
                return;
            }

            // Nếu có phòng thì xử lý các dòng add/edit
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
                        // Thêm mới hoặc kích hoạt lại thành viên
                        if (userId == Guid.Empty) continue;

                        var checkResp = await client.From<HouseMembersData>()
                                                   .Select("*")
                                                   .Where(m => m.HouseId == currentHouse.Id && m.UserId == userId)
                                                   .Get();

                        var existing = checkResp.Models.FirstOrDefault();
                        if (existing != null)
                        {
                            // Nếu đã có thì kích hoạt lại
                            existing.IsActive = true;
                            existing.JoinedAt = DateTime.Now;
                            existing.LeftAt = null;
                            await client.From<HouseMembersData>().Update(existing);
                        }
                        else
                        {
                            // Nếu chưa có thì thêm mới
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

                        // Reset trạng thái dòng
                        row.Tag = null;
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                    else if (pending == "edit")
                    {
                        // Cập nhật thông tin profile
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

                        // Reset trạng thái dòng
                        row.Tag = null;
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu (add/edit): {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Xử lý các dòng leave
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
                        // Tìm theo Id
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
                        //Tìm theo HouseId và UserId
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

                    // Nếu chính user rời phòng thì đánh dấu
                    if (userId == currentUserId) currentUserMarkedLeave = true;

                    // Reset trạng thái dòng
                    row.Tag = null;
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.Cells["colStatus"].Value = "Rời đi";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu (leave): {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Nếu trưởng phòng rời phòng thì chuyển quyền cho người đã ở lâu nhất
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

            // Thông báo và tải lại danh sách thành viên
            if (currentHouse != null)
            {
                MessageBox.Show("Đã lưu thay đổi!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadMembersToDGV(currentHouse.Id);
            }
        }


    }
}
