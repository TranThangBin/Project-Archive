using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073
{
    public partial class QLDETAINCKHSINHVIEN : Form
    {
        // connectionString của Trần Quang Thắng
        private const string connectionString = "Data Source=DESKTOP-VOPAJLN;Initial Catalog=QLNCKH_SV;Integrated Security=True";

        // connectionString của Châu Gia Hào
        //private const string connectionString = "Data Source=PeachSwe3t\\HAOCHAU;Initial Catalog=QLNCKH_SV;Integrated Security=True";

        /* ai có làm gì với database thì tự lấy connectionString của mình nha rồi 
           nhớ ghi chú lại với đừng có xóa connectionString cũ nha comment ra thôi */

        //private const string connectionString = "Your connectionString";

        SqlConnection connect = null;
        public QLDETAINCKHSINHVIEN()
        {
            InitializeComponent();
        }

        private void QLDETAINCKHSINHVIEN_Load(object sender, EventArgs e)
        {
            if (connect == null) connect = new SqlConnection(connectionString);
            if (connect.State == ConnectionState.Closed) connect.Open();
        }

        private void QLDETAINCKHSINHVIEN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connect.State == ConnectionState.Open) connect.Close();
        }
    }
}
