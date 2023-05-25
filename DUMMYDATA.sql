-- Insert dummy data into KHOA table
INSERT INTO KHOA (MAKHOA, TENKHOA, NAMTHANHLAP)
VALUES ('KH01', N'Khoa học máy tính', 1990),
       ('KH02', N'Toán học', 1980),
       ('KH03', N'Vật lý', 1970);

-- Insert dummy data into GIANGVIEN table
INSERT INTO GIANGVIEN (MAGV, HOLOT, TENGV, GIOITINH, TRINHDO, MAKHOA)
VALUES ('01', N'Nguyễn Văn', 'A', N'Nam', N'Tiến sĩ', 'KH01'),
       ('02', N'Trần Thị', 'B', N'Nữ', N'Tiến sĩ', 'KH02'),
       ('03', N'Lê Văn', 'C', N'Nam', N'Tiến sĩ', 'KH03');

-- Insert dummy data into SINHVIEN table
INSERT INTO SINHVIEN (MASV, HOLOT, TENSV, GIOITINH, MAKHOA)
VALUES ('01', N'Nguyễn Văn', 'D', N'Nam', 'KH01'),
       ('02', N'Trần Thị', 'E', N'Nữ', 'KH02'),
       ('03', N'Lê Văn', 'F', N'Nam', 'KH03');

-- Insert dummy data into DETAI table
INSERT INTO DETAI (MADT, TENDT, KINHPHI, NGAYBD, NGAYKT, MAGVHD, MASV_CNDT)
VALUES ('DT01',N'Đồ án 1','1000000','2022-01-01','2022-12-31','01','01'),
       ('DT02',N'Đồ án 2','2000000','2022-02-01','2022-11-30','02','02'),
       ('DT03',N'Đồ án 3','3000000','2022-03-01','2022-10-31','03','03');

-- Insert dummy data into THAMGIADETAI table
INSERT INTO THAMGIADETAI (MADT,MASV,PHUCAP,KETQUA)
VALUES ('DT01','01','1000000',N'Tốt'),
       ('DT02','02','2000000',N'Xuất sắc'),
       ('DT03','03','3000000',N'Trung bình');