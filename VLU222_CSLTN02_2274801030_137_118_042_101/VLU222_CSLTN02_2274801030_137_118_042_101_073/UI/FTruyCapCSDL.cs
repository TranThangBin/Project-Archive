using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLU222_CSLTN02_2274801030_137_118_042_101_073.Classes;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.UI
{
    public partial class FTruyCapCSDL : Form
    {
        public FTruyCapCSDL()
        {
            InitializeComponent();
            Forms.TruyCapCSDL = this;
        }

        private void FTruyCapCSDL_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát Form?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                return;
            else e.Cancel = true;
        }

        private void rdBtn_baoMat_MouseDown(object sender, MouseEventArgs e)
        {
            rdBtn_baoMat.Checked = !rdBtn_baoMat.Checked;
        }

        private void rdBtn_baoMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                rdBtn_baoMat.Checked = !rdBtn_baoMat.Checked;
        }

        private void bnttruyCap_Click(object sender, EventArgs e)
        {
            Database.ConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = txt_tenServer.Text,
                InitialCatalog = txt_tenCSDL.Text,
                IntegratedSecurity = rdBtn_baoMat.Checked,
                UserID = txt_idNguoiDung.Text,
                Password = txt_matKhau.Text,
            };
            Hide();
            Forms.MainMenu = new QLDETAINCKHSINHVIEN();
            Forms.MainMenu.Show();
        }
    }
}
