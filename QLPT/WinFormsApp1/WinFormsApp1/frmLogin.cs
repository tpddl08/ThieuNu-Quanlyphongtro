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
using static System.Runtime.InteropServices.JavaScript.JSType;
using Supabase;
using System.Diagnostics.Eventing.Reader;


namespace ThieunuQLPT
{

    public partial class frmLogin : Form
    {
        private string? numberphone, password;
        private DateTime? lastOpenTime;
        private bool isLock= false;
        private int count = 0;
        public static Guid idLoged;
         public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        //Đăng nhập
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            numberphone = txtNumberphone.Text;
            password = txtPassword.Text;

            if (numberphone==""|| password=="")
            {
                MessageBox.Show("Vui lòng không bỏ trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Bị tạm khóa đăng nhập
            if (isLock)
            {
                if (lastOpenTime != null && DateTime.Now.Subtract(lastOpenTime.Value).TotalMinutes >= 10)
                {                  
                    isLock = false;
                    count = 0;
                }
                else
                {
                    MessageBox.Show("Bạn nhập sai quá nhiều lần, hãy chờ 10 phút!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            var client = await SupabaseHelper.GetClientAsync();
            var response = await client
                .From<ProfilesData>()
                .Select("*")
                .Where(p => p.Phone == numberphone && p.Password == password)
                .Get();

            //Không tìm thấy số điện thoại và mật khẩu tương ứng
            if (!response.Models.Any())
            {
                count++; //Tăng số lần nhập sai
                MessageBox.Show("Số điện thoại hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (count >= 3)
                {
                    isLock = true;
                    lastOpenTime = DateTime.Now;
                    MessageBox.Show("Bạn nhập sai quá nhiều lần, hãy chờ 10 phút!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMain.isLogin = true;
                var profile = response.Models.First();
                idLoged = profile.Id; //Lấy id của tài khoản đã đăng nhập
                DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        //Chuyển sang form Đăng kí
        private void llbSignin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSignin frm = new frmSignin();
            frm.ShowDialog();
        }
    }
}
