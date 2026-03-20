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
            frmCreateroom frm = new frmCreateroom();
            frm.ShowDialog();
        }
    }
}
