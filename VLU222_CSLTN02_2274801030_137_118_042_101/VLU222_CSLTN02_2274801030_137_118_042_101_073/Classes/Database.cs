using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.Classes
{
    internal static class Database
    {
        private static SqlConnection connection = null;

        public static void Connect(string connectionString)
        {
            if (connection == null) connection = new SqlConnection(connectionString);
            if (connection.State == ConnectionState.Closed) connection.Open();
        }

        public static void Disconnect()
        {
            if (connection != null)
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                connection = null;
            }
        }

        private static SqlDataReader ExecuteQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            return command.ExecuteReader();
        }

        private static int ExecuteNonQuery(string query, List<SqlParameter> parameters)
        {
            SqlCommand command = new SqlCommand(query, connection);
            foreach (SqlParameter parameter in parameters)
                command.Parameters.Add(parameter);
            return command.ExecuteNonQuery();
        }

        public static void RenderThamGiaDeTai(ListBox listBox)
        {
            string sql = "SELECT MADT, MASV, PHUCAP, KETQUA FROM THAMGIADETAI";
            SqlDataReader reader = ExecuteQuery(sql);
            while (reader.Read())
            {
                string maDT = reader.GetString(0);
                string maSV = reader.GetString(1);
                long phuCap = (long)reader.GetDecimal(2);
                string ketQua = reader.GetString(3);
                ThamGiaDeTai thamGiaDeTai = new ThamGiaDeTai(maDT, maSV, phuCap, ketQua);
                listBox.Items.Add(thamGiaDeTai);
            }
            reader.Close();
        }

        public static void RenderThamGiaDeTai(ListView listView)
        {
            string sql = "SELECT MADT, MASV, PHUCAP, KETQUA FROM THAMGIADETAI";
            SqlDataReader reader = ExecuteQuery(sql);
            while (reader.Read())
            {
                string maDT = reader.GetString(0);
                string maSV = reader.GetString(1);
                long phuCap = (long)reader.GetDecimal(2);
                string ketQua = reader.GetString(3);
                ThamGiaDeTai thamGiaDeTai = new ThamGiaDeTai(maDT, maSV, phuCap, ketQua);
                string[] lsviObj = new string[]
                {
                    thamGiaDeTai.MaDT,
                    thamGiaDeTai.MaSV,
                    thamGiaDeTai.PhuCap+"",
                    thamGiaDeTai.KetQua
                };
                ListViewItem lsvItem = new ListViewItem(lsviObj);
                listView.Items.Add(lsvItem);
            }
            reader.Close();
        }
    }
}
