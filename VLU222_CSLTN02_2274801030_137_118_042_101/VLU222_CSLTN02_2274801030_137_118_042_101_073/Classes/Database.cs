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

        public static void RenderThamGiaDeTai(ListBox listBox, ComboBox cmbMaDT, ComboBox cmbMaSV)
        {
            string sql = "SELECT MADT, MASV, PHUCAP, KETQUA FROM THAMGIADETAI";
            using (SqlDataReader reader = ExecuteQuery(sql))
            {
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
            sql = "SELECT MADT FROM DETAI";
            using (SqlDataReader reader = ExecuteQuery(sql))
            {
                while (reader.Read())
                    cmbMaDT.Items.Add(reader.GetString(0));
                reader.Close();
            }
            sql = "SELECT MASV FROM SINHVIEN";
            using (SqlDataReader reader = ExecuteQuery(sql))
            {
                while (reader.Read())
                    cmbMaSV.Items.Add(reader.GetString(0));
                reader.Close();
            }
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

        public static int InsertThamGiaDeTai(ThamGiaDeTai thamGiaDeTai)
        {
            string sql = "INSERT INTO THAMGIADETAI " +
                         "VALUES(@MADT, @MASV, @PHUCAP, @KETQUA)";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@MADT", SqlDbType.Char)
                {
                    Value = thamGiaDeTai.MaDT
                }, new SqlParameter("@MASV", SqlDbType.Char)
                {
                    Value = thamGiaDeTai.MaSV
                }, new SqlParameter("@PHUCAP", SqlDbType.Decimal)
                {
                    Value = thamGiaDeTai.PhuCap
                }, new SqlParameter("@KETQUA", SqlDbType.NVarChar)
                {
                    Value = thamGiaDeTai.KetQua
                }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public static int DeleteThamGiaDeTai(ThamGiaDeTai thamGiaDeTai)
        {
            string sql = "DELETE FROM THAMGIADETAI " +
                         "WHERE MADT = @MADT AND MASV = @MASV";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@MADT", SqlDbType.Char)
                {
                    Value = thamGiaDeTai.MaDT
                }, new SqlParameter("@MASV", SqlDbType.Char)
                {
                    Value = thamGiaDeTai.MaSV
                }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public static int UpdateThamGiaDeTai(ThamGiaDeTai oldThamGiaDeTai, ThamGiaDeTai newThamGiaDeTai)
        {
            string sql = "UPDATE THAMGIADETAI " +
                         "SET PHUCAP = @PHUCAP, KETQUA = @KETQUA " +
                         "WHERE MADT = @OLDMADT AND MASV = @OLDMASV";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@PHUCAP", SqlDbType.Decimal)
                {
                    Value = newThamGiaDeTai.PhuCap
                }, new SqlParameter("@KETQUA", SqlDbType.NVarChar)
                {
                    Value = newThamGiaDeTai.KetQua
                },new SqlParameter("@OLDMADT", SqlDbType.Char)
                {
                    Value = oldThamGiaDeTai.MaDT
                }, new SqlParameter("@OLDMASV", SqlDbType.Char)
                {
                    Value = oldThamGiaDeTai.MaSV
                }
            };
            return ExecuteNonQuery(sql, parameters);
        }
    }
}
