using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLU222_CSLTN02_2274801030_137_118_042_101_073.UI;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.Classes
{
    internal static class Database
    {
        private static SqlConnectionStringBuilder connectionStringBuilder = null;
        private static SqlConnection connection = null;

        public static SqlConnectionStringBuilder ConnectionStringBuilder { get => connectionStringBuilder; set => connectionStringBuilder = value; }

        public static void Connect()
        {
            if (connection == null) connection = new SqlConnection(connectionStringBuilder.ConnectionString);
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

        public static void RenderKhoa(ListBox listbox)
        {
            string sql = "SELECT MAKHOA, TENKHOA, NAMTHANHLAP FROM KHOA";
            using (SqlDataReader reader = ExecuteQuery(sql))
            {
                while (reader.Read())
                {
                    string maKhoa = reader.GetString(0);
                    string tenKhoa = reader.GetString(1);
                    int namThanhLap = reader.GetInt32(2);
                    Khoa khoa = new Khoa(maKhoa, tenKhoa, namThanhLap);
                    listbox.Items.Add(khoa);
                }
                reader.Close();
            }
            foreach (Khoa khoa in listbox.Items)
            {
                sql = "SELECT MAGV, HOLOT, TENGV, GIOITINH, TRINHDO, MAKHOA " +
                      $"FROM GIANGVIEN WHERE MAKHOA = '{khoa.MaKhoa}'";
                using (SqlDataReader reader = ExecuteQuery(sql))
                {
                    while (reader.Read())
                    {
                        string maGV = reader.GetString(0);
                        string hoLot = reader.GetString(1);
                        string tenGV = reader.GetString(2);
                        string gioiTinh = reader.GetString(3);
                        string trinhDo = reader.GetString(4);
                        string maKhoa = reader.GetString(5);
                        GiangVien giangVien = new GiangVien(maGV, hoLot, tenGV, gioiTinh, trinhDo, maKhoa);
                        khoa.GiangViens.Add(giangVien);
                    }
                    reader.Close();
                }
                foreach (GiangVien giangVien in khoa.GiangViens)
                {
                    string maGVHD = giangVien.MaGV;
                    sql = "SELECT MADT, TENDT, KINHPHI, NGAYBD, NGAYKT, MASV_CNDT " +
                          $"FROM DETAI WHERE MAGVHD = '{maGVHD}'";
                    using (SqlDataReader reader = ExecuteQuery(sql))
                    {
                        while (reader.Read())
                        {
                            string maDT = reader.GetString(0);
                            string tenDT = reader.GetString(1);
                            long kinhPhi = (long)reader.GetDecimal(2);
                            DateTime ngayBD = reader.GetDateTime(3);
                            DateTime ngayKT = reader.GetDateTime(4);
                            string maSV_CNDT = reader.GetString(5);
                            DeTai deTai = new DeTai(maDT, tenDT, kinhPhi, ngayBD, ngayKT, maGVHD, maSV_CNDT);
                            giangVien.Detais.Add(deTai);
                        }
                        reader.Close();
                    }
                    foreach (DeTai deTai in giangVien.Detais)
                    {
                        string maDT = deTai.MaDT;
                        string maSV = deTai.MaSVCNDT;
                        sql = "SELECT PHUCAP, KETQUA FROM THAMGIADETAI " +
                             $"WHERE MADT = '{maDT}' AND MASV = '{maSV}'";
                        using (SqlDataReader reader = ExecuteQuery(sql))
                        {
                            reader.Read();
                            long phuCap = (long)reader.GetDecimal(0);
                            string ketQua = reader.GetString(1);
                            deTai.ThamGiaDeTai = new ThamGiaDeTai(maDT, maSV, phuCap, ketQua);
                            reader.Close();
                        }
                    }
                }
                sql = "SELECT MASV, HOLOT, TENSV, GIOITINH, MAKHOA " +
                      $"FROM SINHVIEN WHERE MAKHOA = '{khoa.MaKhoa}'";
                using (SqlDataReader reader = ExecuteQuery(sql))
                {
                    while (reader.Read())
                    {
                        string maSV = reader.GetString(0);
                        string hoLot = reader.GetString(1);
                        string tenSV = reader.GetString(2);
                        string gioiTinh = reader.GetString(3);
                        string maKhoa = reader.GetString(4);
                        SinhVien sinhVien = new SinhVien(maSV, hoLot, tenSV, gioiTinh, maKhoa);
                        khoa.SinhViens.Add(sinhVien);
                    }
                    reader.Close();
                }
                foreach (SinhVien sinhVien in khoa.SinhViens)
                {
                    string maSV = sinhVien.MaSV;
                    sql = "SELECT MADT, TENDT, KINHPHI, NGAYBD, NGAYKT, MAGVHD FROM DETAI " +
                         $"WHERE MASV_CNDT = '{maSV}'";
                    using (SqlDataReader reader = ExecuteQuery(sql))
                    {
                        while (reader.Read())
                        {
                            string maDT = reader.GetString(0);
                            string tenDT = reader.GetString(1);
                            long kinhPhi = (long)reader.GetDecimal(2);
                            DateTime ngayBD = reader.GetDateTime(3);
                            DateTime ngayKT = reader.GetDateTime(4);
                            string maGVHD = reader.GetString(5);
                            DeTai deTai = new DeTai(maDT, tenDT, kinhPhi, ngayBD, ngayKT, maGVHD, maSV);
                            sinhVien.Detais.Add(deTai);
                        }
                        reader.Close();
                    }
                    foreach (DeTai deTai in sinhVien.Detais)
                    {
                        string maDT = deTai.MaDT;
                        sql = "SELECT PHUCAP, KETQUA FROM THAMGIADETAI " +
                             $"WHERE MADT = '{maDT}' AND MASV = '{maSV}'";
                        using (SqlDataReader reader = ExecuteQuery(sql))
                        {
                            reader.Read();
                            long phuCap = (long)reader.GetDecimal(0);
                            string ketQua = reader.GetString(1);
                            deTai.ThamGiaDeTai = new ThamGiaDeTai(maDT, maSV, phuCap, ketQua);
                            reader.Close();
                        }
                    }
                }
            }
        }

        public static int InsertKhoa(Khoa khoa)
        {
            string sql = "INSERT INTO KHOA " +
                         "VALUES(@MAKHOA, @TENKHOA, @NAMTHANHLAP)";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@MAKHOA", SqlDbType.Char)
                {
                    Value = khoa.MaKhoa
                }, new SqlParameter("@TENKHOA", SqlDbType.NVarChar)
                {
                    Value = khoa.TenKhoa
                }, new SqlParameter("@NAMTHANHLAP", SqlDbType.Int)
                {
                    Value = khoa.NamThanhLap
                }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public static int DeleteKhoa(Khoa khoa)
        {
            if (khoa.GiangViens.Count > 0)
                foreach (GiangVien giangVien in khoa.GiangViens)
                    DeleteGiangVien(giangVien);
            if (khoa.SinhViens.Count > 0)
                foreach (SinhVien sinhVien in khoa.SinhViens)
                    DeleteSinhVien(sinhVien);
            string sql = "DELETE FROM KHOA " +
                         "WHERE MAKHOA = @MAKHOA";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@MAKHOA", SqlDbType.Char)
                {
                    Value = khoa.MaKhoa
                }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public static int UpdateKhoa(Khoa oldKhoa, Khoa newKhoa)
        {
            string sql = "UPDATE KHOA " +
                         "SET TENKHOA = @TENKHOA, NAMTHANHLAP = @NAMTHANHLAP " +
                         "WHERE MAKHOA = @OLDMAKHOA";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@TENKHOA", SqlDbType.NVarChar)
                {
                    Value = newKhoa.TenKhoa
                }, new SqlParameter("@NAMTHANHLAP", SqlDbType.Int)
                {
                    Value = newKhoa.NamThanhLap
                }, new SqlParameter("@OLDMAKHOA", SqlDbType.Char)
                {
                    Value = oldKhoa.MaKhoa
                }
            };
            return ExecuteNonQuery(sql, parameters);
        }
        public static void RenderGiangVien(ListBox listbox, ComboBox cmB_maKhoa, ComboBox cmB_maSV)
        {
            string sql = "SELECT MAGV, HOLOT, TENGV, GIOITINH, TRINHDO, MAKHOA FROM GIANGVIEN";
            using (SqlDataReader reader = ExecuteQuery(sql))
            {
                while (reader.Read())
                {
                    string maGV = reader.GetString(0);
                    string hoLot = reader.GetString(1);
                    string tenGV = reader.GetString(2);
                    string gioiTinh = reader.GetString(3);
                    string trinhDo = reader.GetString(4);
                    string maKhoa = reader.GetString(5);
                    GiangVien giangVien = new GiangVien(maGV, hoLot, tenGV, gioiTinh, trinhDo, maKhoa);
                    listbox.Items.Add(giangVien);
                }
                reader.Close();
            }
            foreach (GiangVien giangVien in listbox.Items)
            {
                string maGVHD = giangVien.MaGV;
                sql = "SELECT MADT, TENDT, KINHPHI, NGAYBD, NGAYKT, MASV_CNDT " +
                      $"FROM DETAI WHERE MAGVHD = '{maGVHD}'";
                using (SqlDataReader reader = ExecuteQuery(sql))
                {
                    while (reader.Read())
                    {
                        string maDT = reader.GetString(0);
                        string tenDT = reader.GetString(1);
                        long kinhPhi = (long)reader.GetDecimal(2);
                        DateTime ngayBD = reader.GetDateTime(3);
                        DateTime ngayKT = reader.GetDateTime(4);
                        string maSV_CNDT = reader.GetString(5);
                        DeTai deTai = new DeTai(maDT, tenDT, kinhPhi, ngayBD, ngayKT, maGVHD, maSV_CNDT);
                        cmB_maSV.Items.Add(maSV_CNDT);
                        giangVien.Detais.Add(deTai);
                    }
                    reader.Close();
                }
                foreach (DeTai deTai in giangVien.Detais)
                {
                    string maDT = deTai.MaDT;
                    string maSV = deTai.MaSVCNDT;
                    sql = "SELECT PHUCAP, KETQUA FROM THAMGIADETAI " +
                         $"WHERE MADT = '{maDT}' AND MASV = '{maSV}'";
                    using (SqlDataReader reader = ExecuteQuery(sql))
                    {
                        reader.Read();
                        long phuCap = (long)reader.GetDecimal(0);
                        string ketQua = reader.GetString(1);
                        deTai.ThamGiaDeTai = new ThamGiaDeTai(maDT, maSV, phuCap, ketQua);
                        reader.Close();
                    }
                }
            }
            sql = "SELECT MAKHOA FROM KHOA";
            using (SqlDataReader reader = ExecuteQuery(sql))
            {
                while (reader.Read())
                    cmB_maKhoa.Items.Add(reader.GetString(0));
                reader.Close();
            }
            sql = "SELECT MASV FROM SINHVIEN";
            using (SqlDataReader reader = ExecuteQuery(sql))
            {
                while (reader.Read())
                    cmB_maSV.Items.Add(reader.GetString(0));
                reader.Close();
            }
        }

        public static int InsertGiangVien(GiangVien giangVien)
        {
            string sql = "INSERT INTO GIANGVIEN " +
                         "VALUES(@MAGV, @HOLOT, @TENGV, @GIOITINH, @TRINHDO, @MAKHOA)";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@MAGV", SqlDbType.Char)
                {
                    Value = giangVien.MaGV
                }, new SqlParameter("@HOLOT", SqlDbType.NVarChar)
                {
                    Value = giangVien.HoLot
                } , new SqlParameter("@TENGV", SqlDbType.NVarChar)
                {
                    Value = giangVien.TenGV
                } , new SqlParameter("@GIOITINH", SqlDbType.NVarChar)
                {
                    Value = giangVien.GioiTinh
                } , new SqlParameter("@TRINHDO", SqlDbType.NVarChar)
                {
                    Value = giangVien.TrinhDo
                }, new SqlParameter("@MAKHOA", SqlDbType.Char)
                {
                    Value = giangVien.MaKhoa
                }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public static int DeleteGiangVien(GiangVien giangVien)
        {
            if (giangVien.Detais.Count > 0)
                foreach (DeTai deTai in giangVien.Detais)
                    DeleteDeTai(deTai);
            string sql = "DELETE FROM GIANGVIEN " +
                         "WHERE MAGV = @MAGV and MAKHOA = @MAKHOA";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@MAGV", SqlDbType.Char)
                {
                    Value = giangVien.MaGV
                }, new SqlParameter("@MAKHOA", SqlDbType.Char)
                {
                    Value = giangVien.MaKhoa
                }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public static int UpdateGiangVien(GiangVien oldGiangVien, GiangVien newGiangVien)
        {
            string sql = "UPDATE GIANGVIEN " +
                         "SET HOLOT = @HOLOT, TENGV = @TENGV, GIOITINH = @GIOITINH, TRINHDO = @TRINHDO " +
                         "WHERE MAGV = @OLDMAGV AND MAKHOA = @OLDMAKHOA";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@HOLOT", SqlDbType.NVarChar)
                {
                    Value = newGiangVien.HoLot
                }, new SqlParameter("TENGV", SqlDbType.NVarChar)
                {
                    Value = newGiangVien.TenGV
                } , new SqlParameter("@GIOITINH", SqlDbType.NVarChar)
                {
                    Value = newGiangVien.GioiTinh
                } , new SqlParameter("@TRINHDO", SqlDbType.NVarChar)
                {
                    Value = newGiangVien.TrinhDo
                } , new SqlParameter("@OLDMAGV", SqlDbType.Char)
                {
                    Value = oldGiangVien.MaGV
                }, new SqlParameter("@OLDMAKHOA", SqlDbType.Char)
                {
                    Value = oldGiangVien.MaKhoa
                }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public static void RenderSinhVien(ListBox listBox, ComboBox cmBKhoa, ComboBox cmBMaGV)
        {
            string sql = "SELECT MASV, HOLOT, TENSV, GIOITINH, MAKHOA FROM SINHVIEN";
            using (SqlDataReader reader = ExecuteQuery(sql))
            {
                while (reader.Read())
                {
                    string maSV = reader.GetString(0);
                    string hoLot = reader.GetString(1);
                    string tenSV = reader.GetString(2);
                    string gioiTinh = reader.GetString(3);
                    string maKhoa = reader.GetString(4);
                    SinhVien sinhVien = new SinhVien(maSV, hoLot, tenSV, gioiTinh, maKhoa);
                    listBox.Items.Add(sinhVien);
                }
                reader.Close();
            }
            foreach (SinhVien sinhVien in listBox.Items)
            {
                string maSV = sinhVien.MaSV;
                sql = "SELECT MADT, TENDT, KINHPHI, NGAYBD, NGAYKT, MAGVHD FROM DETAI " +
                     $"WHERE MASV_CNDT = '{maSV}'";
                using (SqlDataReader reader = ExecuteQuery(sql))
                {
                    while (reader.Read())
                    {
                        string maDT = reader.GetString(0);
                        string tenDT = reader.GetString(1);
                        long kinhPhi = (long)reader.GetDecimal(2);
                        DateTime ngayBD = reader.GetDateTime(3);
                        DateTime ngayKT = reader.GetDateTime(4);
                        string maGVHD = reader.GetString(5);
                        DeTai deTai = new DeTai(maDT, tenDT, kinhPhi, ngayBD, ngayKT, maGVHD, maSV);
                        sinhVien.Detais.Add(deTai);
                    }
                    reader.Close();
                }
                foreach (DeTai deTai in sinhVien.Detais)
                {
                    string maDT = deTai.MaDT;
                    sql = "SELECT PHUCAP, KETQUA FROM THAMGIADETAI " +
                         $"WHERE MADT = '{maDT}' AND MASV = '{maSV}'";
                    using (SqlDataReader reader = ExecuteQuery(sql))
                    {
                        reader.Read();
                        long phuCap = (long)reader.GetDecimal(0);
                        string ketQua = reader.GetString(1);
                        deTai.ThamGiaDeTai = new ThamGiaDeTai(maDT, maSV, phuCap, ketQua);
                        reader.Close();
                    }
                }
            }
            sql = "SELECT MAKHOA FROM KHOA";
            using (SqlDataReader reader = ExecuteQuery(sql))
            {
                while (reader.Read())
                    cmBKhoa.Items.Add(reader.GetString(0));
                reader.Close();
            }
            sql = "SELECT MAGV FROM GIANGVIEN";
            using (SqlDataReader reader = ExecuteQuery(sql))
            {
                while (reader.Read())
                    cmBMaGV.Items.Add(reader.GetString(0));
                reader.Close();
            }
        }

        public static int InsertSinhVien(SinhVien sinhVien)
        {
            string sql = "INSERT INTO SINHVIEN " +
                         "VALUES(@MASV, @HOLOT, @TENSV, @GIOITINH, @MAKHOA)";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@MASV", SqlDbType.Char)
                {
                    Value = sinhVien.MaSV
                }, new SqlParameter("@HOLOT", SqlDbType.NVarChar)
                {
                    Value = sinhVien.HoLot
                } , new SqlParameter("@TENSV", SqlDbType.NVarChar)
                {
                    Value = sinhVien.TenSV
                } , new SqlParameter("@GIOITINH", SqlDbType.NVarChar)
                {
                    Value = sinhVien.GioiTinh
                } , new SqlParameter("@MAKHOA", SqlDbType.Char)
                {
                    Value = sinhVien.MaKhoa
                }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public static int DeleteSinhVien(SinhVien sinhVien)
        {
            if (sinhVien.Detais.Count > 0)
                foreach (DeTai deTai in sinhVien.Detais)
                    DeleteDeTai(deTai);
            string sql = "DELETE FROM SINHVIEN " +
                         "WHERE MASV = @MASV and MAKHOA = @MAKHOA";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@MASV", SqlDbType.Char)
                {
                    Value = sinhVien.MaSV
                }, new SqlParameter("@MAKHOA", SqlDbType.Char)
                {
                    Value = sinhVien.MaKhoa
                }
            };
            return ExecuteNonQuery(sql, parameters);
        }

        public static int UpdateSinhVien(SinhVien oldSinhVien, SinhVien newSinhVien)
        {
            string sql = "UPDATE SINHVIEN " +
                         "SET HOLOT = @HOLOT, TENSV = @TENSV, GIOITINH = @GIOITINH " +
                         "WHERE MASV = @OLDMASV AND MAKHOA = @OLDMAKHOA";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@HOLOT", SqlDbType.NVarChar)
                {
                    Value = newSinhVien.HoLot
                }, new SqlParameter("TENSV", SqlDbType.NVarChar)
                {
                    Value = newSinhVien.TenSV
                } , new SqlParameter("@GIOITINH", SqlDbType.NVarChar)
                {
                    Value = newSinhVien.GioiTinh
                } , new SqlParameter("@OLDMASV", SqlDbType.Char)
                {
                    Value = oldSinhVien.MaSV
                }, new SqlParameter("@OLDMAKHOA", SqlDbType.Char)
                {
                    Value = oldSinhVien.MaKhoa
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



