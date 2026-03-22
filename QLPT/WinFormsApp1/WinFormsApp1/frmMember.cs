using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThieunuQLPT
{
    public partial class frmMember : Form
    {
        public frmMember()
        {
            InitializeComponent();
        }

        private void btnCreateroom_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCreateroom frm = new frmCreateroom();
            frm.ShowDialog();
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void dgvMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void checkHaveRoom()
        {
            var client = await SupabaseHelper.GetClientAsync();
            Guid idUser = frmLogin.idLoged;

            if (client != null)
            {
                var response = await client
                    .From<HouseMembersData>()
                    .Select("*")
                    .Where(m => m.UserId == idUser && m.IsActive == true)
                    .Get();

                var member = response.Models.First();
                var houseResponse = await client
                    .From<HousesData>()
                    .Select("*")
                    .Where(h => h.Id == member.HouseId)
                    .Get();

                if (response.Models.Any())
                {
                    var house = houseResponse.Models.First();
                    btnCreateroom.Visible = false;
                    btnAdd.Visible = true;
                    btnDelete.Visible = true;
                    lblNoti.Text = "PHÒNG " + house.Name + ", ĐỊA CHỈ: " + house.Address;
                }
                else
                {
                    lblNoti.Text = "HIỆN CHƯA CÓ PHÒNG NÀO!";
                }
            }
        }

        private void frmMember_Load(object sender, EventArgs e)
        {
            checkHaveRoom();
        }
    }
}
