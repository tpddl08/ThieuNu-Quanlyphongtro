using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Supabase;

namespace ThieunuQLPT
{
    public partial class frmCreateroom : Form
    {
        private string? housename;
        private int? housemaxmember;
        private decimal? houseservice, housePriceRent;
        private Guid currentUserId;

        public frmCreateroom()
        {
            InitializeComponent();
        }

        //Tạo phòng
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            housename = txtNameroom.Text;
            housemaxmember = int.TryParse(txtNumbermember.Text, out var max) ? max : null;
            housePriceRent = decimal.TryParse(txtPriceRent.Text, out var rent) ? rent : null;
            houseservice = decimal.TryParse(txtService.Text, out var serv) ? serv : null;

            if (housename == null || housemaxmember == null || housePriceRent == null || houseservice==null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var client = await SupabaseHelper.GetClientAsync();
                currentUserId = frmLogin.idLoged; //Lấy id của người dùng đã đăng nhập
                //Tạo phòng mới
                var newHouse = new HousesData
                {
                    Name = housename,
                    MaxMembers = housemaxmember,
                    ElectricityRate = 4000,
                    WaterRate = 100000,
                    PriceRent = housePriceRent,
                    ServiceRate = houseservice,
                };

                var response = await client.From<HousesData>().Insert(newHouse);

                if (response.Models.Any())
                {
                    var houseId = response.Models.First().Id;

                    //Gán người tạo là trưởng phòng
                    var newMember = new HouseMembersData
                    {
                        HouseId = houseId,
                        UserId = currentUserId,
                        Role = "owner", 
                        IsActive = true,
                        JoinedAt = DateTime.Now
                    };

                    var memberResponse = await client.From<HouseMembersData>().Insert(newMember);
                    MessageBox.Show("Tạo phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmMember frm = new frmMember();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể tạo phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}
