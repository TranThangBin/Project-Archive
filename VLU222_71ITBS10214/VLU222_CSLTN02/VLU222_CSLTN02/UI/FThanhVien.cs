using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLU222_CSLTN02_2274801030_137_118_042_101_073.Classes;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.UI
{
    public partial class FThanhVien : Form
    {
        public FThanhVien()
        {
            InitializeComponent();
        }

        private void FThanhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn muốn trở về trang chủ?","Xác nhận!",MessageBoxButtons.YesNoCancel)==DialogResult.Yes)
                Forms.MainMenu.Show();
            else e.Cancel = true;
        }

        private void btn_trove_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
