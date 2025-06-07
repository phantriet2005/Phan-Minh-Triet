CREATE DATABASE QLCHTL;
GO
USE QLCHTL;
GO

-- Bảng tài khoản
CREATE TABLE TaiKhoan (
    TenTK VARCHAR(10) PRIMARY KEY,
    MatKhau VARCHAR(50) NOT NULL,
    PhanQuyen VARCHAR(2) NOT NULL
);

-- Bảng loại hàng
CREATE TABLE LoaiHang (
    MaLH VARCHAR(10) PRIMARY KEY,
    TenLH NVARCHAR(100) NOT NULL
);

-- Bảng hàng hóa
CREATE TABLE HangHoa (
    MaHH VARCHAR(10) PRIMARY KEY,
    TenHH NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18, 2) NOT NULL,
    DVT NVARCHAR(20),
    XuatSu NVARCHAR(100),
    MaLH VARCHAR(10) NULL,
	TrangThai NVARCHAR(50) NULL,
    FOREIGN KEY (MaLH) REFERENCES LoaiHang(MaLH) ON DELETE SET NULL
);

-- Bảng khách hàng
CREATE TABLE KhachHang (
    MaKH VARCHAR(10) PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(255),
    SDT VARCHAR(15),
    TenTK VARCHAR(10) NULL,
    FOREIGN KEY (TenTK) REFERENCES TaiKhoan(TenTK) ON DELETE SET NULL
);

-- Bảng nhân viên
CREATE TABLE NhanVien (
    MaNV VARCHAR(10) PRIMARY KEY,
    TenNV NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(255),
    SDT VARCHAR(15),
    TenTK VARCHAR(10) NULL,
    FOREIGN KEY (TenTK) REFERENCES TaiKhoan(TenTK) ON DELETE SET NULL
);

-- Bảng hóa đơn
CREATE TABLE HoaDon (
    MaHD VARCHAR(10) PRIMARY KEY,
    NgayLap DATE NOT NULL,
    MaNV VARCHAR(10) NULL,
    MaKH VARCHAR(10) NULL,
    TongTien DECIMAL(18, 2),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV) ON DELETE SET NULL,
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH) ON DELETE SET NULL
);

-- Bảng chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon (
    MaHD VARCHAR(10) NOT NULL,
    MaHH VARCHAR(10) NOT NULL,
    SoLuong INT NOT NULL,
    ThanhTien DECIMAL(18, 2),
    PRIMARY KEY (MaHD, MaHH),
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),     
    FOREIGN KEY (MaHH) REFERENCES HangHoa(MaHH)     
);

select * from TaiKhoan

select * from KhachHang

-- Bảng TaiKhoan (2 mẫu)
INSERT INTO TaiKhoan (TenTK, MatKhau, PhanQuyen) VALUES
('admin', '123', '1'),
('user1', 'abc', '2'),
('user3', 'abc', '3')

-- Bảng LoaiHang (2 mẫu)
INSERT INTO LoaiHang (MaLH, TenLH) VALUES
('LH01', N'Loại 1'),
('LH02', N'Loại 2');

-- Bảng HangHoa (2 mẫu)
INSERT INTO HangHoa (MaHH, TenHH, DonGia, DVT, XuatSu, MaLH,TrangThai) VALUES
('HH01', N'Hàng hóa 1', 100000, N'Cái', N'Việt Nam', 'LH01','Còn bán'),
('HH02', N'Hàng hóa 2', 200000, N'Cái', N'Nhật Bản', 'LH02','Còn bán');

-- Bảng KhachHang (2 mẫu)
INSERT INTO KhachHang (MaKH, TenKH, DiaChi, SDT, TenTK) VALUES
('KH01', N'Khách hàng 1', N'Hà Nội', '0123456789', 'user3'),
('KH02', N'Khách hàng 2', N'Hải Phòng', '0987654321', NULL);

-- Bảng NhanVien (2 mẫu)
INSERT INTO NhanVien (MaNV, TenNV, DiaChi, SDT, TenTK) VALUES
('NV01', N'Nguyễn Văn A', N'Hà Nội', '0123456789', 'admin'),
('NV02', N'Trần Thị B', N'Đà Nẵng', '0987654321', 'user1');

-- Bảng HoaDon (2 mẫu)
INSERT INTO HoaDon (MaHD, NgayLap, MaNV, MaKH, TongTien) VALUES
('HD01', '2025-05-17', 'NV01', 'KH01', 300000),
('HD02', '2025-05-18', 'NV02', 'KH02', 200000);

-- Bảng ChiTietHoaDon (2 mẫu)
INSERT INTO ChiTietHoaDon (MaHD, MaHH, SoLuong, ThanhTien) VALUES
('HD01', 'HH01', 2, 200000),
('HD02', 'HH02', 1, 200000);


Select * from ChiTietHoaDon where MaHD ='hd01'



select * from NhanVien