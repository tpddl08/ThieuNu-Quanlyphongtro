using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace ThieunuQLPT
{
    public partial class frmSignin : Form
    {
        private string? name, numberphone, email, password;
        private DateTime ?datecreate;
        public frmSignin()
        {
            InitializeComponent();
        }

        private void frmSignin_Load(object sender, EventArgs e)
        {
            
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            name = txtName.Text;
            numberphone= txtNumberphone.Text;
            email = txtEmail.Text;
            password = txtPassword.Text;
            datecreate = DateTime.Now;

            if (name == "" || numberphone == "" || email == "" || password == "")
            {
                MessageBox.Show("Vui lòng không bỏ trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var newProfile = new ProfilesData
                {
                    FullName = name,
                    Phone = numberphone,
                    Email = email,
                    Password = password,
                    CreatedAt = datecreate.Value
                };
                var client = await SupabaseHelper.GetClientAsync();
                var response = await client.From<ProfilesData>().Insert(newProfile);

                if (response.Models.Any())
                {
                    MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể tạo tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void llbLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }
    }
}
