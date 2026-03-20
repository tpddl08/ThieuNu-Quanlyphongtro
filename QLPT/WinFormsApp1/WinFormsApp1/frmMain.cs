using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThieunuQLPT;

namespace WinFormsApp1
{
    public partial class frmMain : Form
    {
        public static bool isLogin = false;
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (isLogin)
            {
                btnAccount.BackColor = Color.Red;
                btnAccount.Text = "Đăng xuất";
            }
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            if (isLogin)
            {
                frmMember frm = new frmMember();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng đăng nhập để sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            if (isLogin)
            {
                btnAccount.BackColor = default;
                btnAccount.Text = default;
                isLogin = false;
            }
            else
            {
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
                
            }
        }
    }
}
