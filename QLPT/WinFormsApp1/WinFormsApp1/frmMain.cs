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
            updateLoginStatus();
        }

        //Cập nhật giao diện
        private void updateLoginStatus()
        {
            if (isLogin)
            {
                btnAccount.BackColor = Color.Red;
                btnAccount.Text = "Đăng xuất";
            }
            else
            {
                btnAccount.BackColor = Color.ForestGreen;
                btnAccount.Text = "Đăng nhập";
            }
        }

        //Phòng
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

        //Mở đăng nhập/đăng xuất
        private void btnAccount_Click(object sender, EventArgs e)
        {
            if (isLogin == true)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    isLogin = false;
                }
                updateLoginStatus();
            }

            else
            {
                frmLogin frm = new frmLogin();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    isLogin = true;
                }
                updateLoginStatus();
            }
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            if (isLogin)
            {
                frmBill frm = new frmBill();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng đăng nhập để sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnChores_Click(object sender, EventArgs e)
        {
            if (isLogin)
            {
                frmChores frm = new frmChores();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng đăng nhập để sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
