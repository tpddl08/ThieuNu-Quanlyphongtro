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

namespace ThieunuQLPT
{
    public partial class frmCreateroom : Form
    {
        private string? housename, houseaddress;
        private int? housemaxmember;
        private decimal? houseelectric, housewatter, houseservice;
        private Guid currentUserId;

        public frmCreateroom()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            housename = txtNameroom.Text;
            houseaddress = txtAddress.Text;
            housemaxmember = int.TryParse(txtNumbermember.Text, out var max) ? max : null;
            houseelectric = decimal.TryParse(txtElectric.Text, out var elec) ? elec : null;
            housewatter = decimal.TryParse(txtWatter.Text, out var wat) ? wat : null;
            houseservice = decimal.TryParse(txtService.Text, out var serv) ? serv : null;

            if (housename == null || houseaddress == null || housemaxmember == null || houseelectric==null || housewatter==null || houseservice==null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var client = await SupabaseHelper.GetClientAsync();
                currentUserId = frmLogin.idLoged;
                var newHouse = new HousesData
                {
                    Name = housename,
                    Address = houseaddress,
                    MaxMembers = housemaxmember,
                    ElectricityRate = houseelectric,
                    WaterRate = housewatter,
                    ServiceRate = houseservice,
                };

                var response = await client.From<HousesData>().Insert(newHouse);

                if (response.Models.Any())
                {
                    var houseId = response.Models.First().Id;

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
