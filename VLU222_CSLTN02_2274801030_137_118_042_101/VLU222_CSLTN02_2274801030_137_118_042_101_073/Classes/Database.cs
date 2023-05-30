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

        public static int InsertDeTai(DeTai deTai)
        {
            string sql = "INSERT INTO DETAI " +
                         "VALUES(@MADT, @TENDT, @KINHPHI, @NGAYBD, @NGAYKT, @MAGVHD, @MASV_CNDT)";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@MADT", SqlDbType.Char)
                {
                    Value = deTai.MaDT
                }, new SqlParameter("@TENDT", SqlDbType.NVarChar)
                {
                    Value = deTai.TenDT
                }, new SqlParameter("@KINHPHI", SqlDbType.Decimal)
                {
                    Value = deTai.KinhPhi
                }, new SqlParameter("@NGAYBD", SqlDbType.DateTime)
                {
                    Value = deTai.NgayBD
                }, new SqlParameter("@NGAYKT", SqlDbType.DateTime)
                {
                    Value = deTai.NgayKT
                }, new SqlParameter("@MAGVHD", SqlDbType.Char)
                {
                    Value = deTai.MaGVHD
                }, new SqlParameter("MASV_CNDT", SqlDbType.Char)
                {
                    Value = deTai.MaSVCNDT
                }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public static int DeleteDeTai(DeTai deTai)
        {
            if (deTai.ThamGiaDeTai != null)
                DeleteThamGiaDeTai(deTai.ThamGiaDeTai);
            string sql = "DELETE FROM DETAI " +
                         "WHERE MADT = @MADT AND MASV_CNDT = @MASV_CNDT";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@MADT", SqlDbType.Char)
                {
                    Value = deTai.MaDT
                }, new SqlParameter("@MASV_CNDT", SqlDbType.Char)
                {
                    Value = deTai.MaSVCNDT
                }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public static int UpdateDeTai(DeTai oldDeTai, DeTai newDeTai)
        {
            string sql = "UPDATE DETAI " +
                         "SET TENDT = @TENDT, KINHPHI = @KINHPHI, " +
                         "@NGAYBD = NGAYBD, NGAYKT = @NGAYKT " +
                         "WHERE MADT = @OLDMADT AND MAGVHD = @OLDMAGVHD " +
                                               "AND MASV_CNDT = @OLDMASV_CNDT";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@TENDT", SqlDbType.NVarChar)
                {
                    Value = newDeTai.TenDT
                }, new SqlParameter("@KINHPHI", SqlDbType.Decimal)
                {
                    Value = newDeTai.KinhPhi
                }, new SqlParameter("@NGAYBD", SqlDbType.DateTime)
                {
                    Value = newDeTai.NgayBD
                }, new SqlParameter("@NGAYKT", SqlDbType.DateTime)
                {
                    Value = newDeTai.NgayKT
                },new SqlParameter("@OLDMADT", SqlDbType.Char)
                {
                    Value = oldDeTai.MaDT
                },new SqlParameter("@OLDMAGVHD",SqlDbType.Char)
                {
                    Value = oldDeTai.MaGVHD
                }, new SqlParameter("@OLDMASV_CNDT", SqlDbType.Char)
                {
                    Value = oldDeTai.MaSVCNDT
                }
            };
            return ExecuteNonQuery(sql, parameters);
        }
    }
}



