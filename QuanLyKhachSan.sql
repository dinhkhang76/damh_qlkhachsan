CREATE DATABASE QuanLyKhachSan
--drop database QuanLyKhachSan
GO
USE QuanLyKhachSan
GO
CREATE TABLE Phong(
	MaPhong nvarchar(12) PRIMARY KEY NOT NULL,
	TenPhong nvarchar(255) NOT NULL,
	MaLoai nvarchar(12) NOT NULL,
	TinhTrang nvarchar(12) NOT NULL,
)
CREATE TABLE LoaiPhong(
	MaLoai nvarchar(12) PRIMARY KEY NOT NULL,
	TenLoai nvarchar(255) NOT NULL,
	SoNguoiChuan int NOT NULL,
	SoNguoiToiDa int NOT NULL,
	DonGia float NOT NULL,
	GhiChu nvarchar(255),
)
CREATE TABLE KhachHang(
	MaKhachHang INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TenKhachHang nvarchar(255) NOT NULL,
	CMND nvarchar(13) NOT NULL,
	DiaChi nvarchar(255) NOT NULL,
	SoDienThoai nvarchar(13) NOT NULL,
)
CREATE TABLE DichVu(
	MaDichVu nvarchar(12) PRIMARY KEY NOT NULL,
	LoaiDichVu nvarchar(255) NOT NULL,
	TenDichVu nvarchar(255) NOT NULL,
	DonGia float NOT NULL,
)
CREATE TABLE ThuePhong(
	MaThue INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MaKhachHang INT NOT NULL,
	MaPhong nvarchar(12) NOT NULL,
	NgayVao date NOT NULL, 
	NgayRa date NOT NULL,
	DatCoc float NOT NULL
)
CREATE TABLE SuDungDichVu(
	MaSuDung INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MaKhachHang INT NOT NULL,
	MaDichVu nvarchar(12) NOT NULL,
	Ngay date NOT NULL,
	SoLuong int NOT NULL,
	DonGia float NOT NULL
)
CREATE TABLE ThanhToan(	
	MaThanhToan INT IDENTITY(1,1) NOT NULL,
	MaPhong nvarchar(12) NOT NULL,
	MaKhachHang INT NOT NULL,
	TenKhachHang nvarchar(255) NOT NULL,
	NgayVao date NOT NULL,
	NgayRa date NOT NULL,
	DatCoc float NOT NULL,
	Thu float NOT NULL,
	ThanhTien float NOT NULL,
	NgayLap date NOT NULL,
	NguoiLap nvarchar(255)
)
CREATE TABLE NhanVien(
	MaNhanVien nvarchar(12) PRIMARY KEY NOT NULL,
	TenNhanVien nvarchar(255) NOT NULL,
	GioiTinh nvarchar(5) NOT NULL,
	NgaySinh date NOT NULL,
	DiaChi nvarchar(255) NOT NULL,
	SoDienThoai nvarchar(13) NOT NULL,
	ChucVu nvarchar(100) NOT NULL
)
CREATE TABLE Account(
	MaNhanVien nvarchar(12) PRIMARY KEY NOT NULL,
	TaiKhoan nvarchar(255) NOT NULL,
	MatKhau nvarchar(255) NOT NULL
)


ALTER TABLE Phong ADD CONSTRAINT fk_phong_loaiphong FOREIGN KEY (MaLoai) REFERENCES LoaiPhong(MaLoai)
ALTER TABLE ThuePhong ADD CONSTRAINT fk_thuephong_khachhang FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
ALTER TABLE ThuePhong ADD CONSTRAINT fk_thuephong_phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong)
ALTER TABLE SuDungDichVu ADD CONSTRAINT fk_sudungdichvu_khachhang FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
ALTER TABLE SuDungDichVu ADD CONSTRAINT fk_sudungdichvu_dichvu FOREIGN KEY (MaDichVu) REFERENCES DichVu(MaDichVu)
ALTER TABLE Account ADD CONSTRAINT fk_taikhoan_nhanvien FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)


INSERT INTO LoaiPhong(MaLoai, TenLoai, SoNguoiChuan, SoNguoiToiDa, DonGia, GhiChu) VALUES(N'T1',N'Thường 1',1,2,500000,N'#')
INSERT INTO LoaiPhong(MaLoai, TenLoai, SoNguoiChuan, SoNguoiToiDa, DonGia, GhiChu) VALUES(N'T2',N'Thường 2',2,4,1000000,N'#')
INSERT INTO LoaiPhong(MaLoai, TenLoai, SoNguoiChuan, SoNguoiToiDa, DonGia, GhiChu) VALUES(N'V1',N'Vip 1',1,2,1000000,N'#')
INSERT INTO LoaiPhong(MaLoai, TenLoai, SoNguoiChuan, SoNguoiToiDa, DonGia, GhiChu) VALUES(N'V2',N'Vip 2',2,4,1500000,N'#')

INSERT INTO Phong(MaPhong, TenPhong, MaLoai, TinhTrang) VALUES(N'P101',N'Phòng 101',N'T1',N'Trống')
INSERT INTO Phong(MaPhong, TenPhong, MaLoai, TinhTrang) VALUES(N'P102',N'Phòng 102',N'T1',N'Trống')
INSERT INTO Phong(MaPhong, TenPhong, MaLoai, TinhTrang) VALUES(N'P103',N'Phòng 103',N'T2',N'Trống')
INSERT INTO Phong(MaPhong, TenPhong, MaLoai, TinhTrang) VALUES(N'P104',N'Phòng 104',N'T2',N'Trống')
INSERT INTO Phong(MaPhong, TenPhong, MaLoai, TinhTrang) VALUES(N'P201',N'Phòng 201',N'T1',N'Trống')
INSERT INTO Phong(MaPhong, TenPhong, MaLoai, TinhTrang) VALUES(N'P202',N'Phòng 202',N'T1',N'Trống')
INSERT INTO Phong(MaPhong, TenPhong, MaLoai, TinhTrang) VALUES(N'P203',N'Phòng 203',N'T2',N'Trống')
INSERT INTO Phong(MaPhong, TenPhong, MaLoai, TinhTrang) VALUES(N'P204',N'Phòng 204',N'T2',N'Trống')
INSERT INTO Phong(MaPhong, TenPhong, MaLoai, TinhTrang) VALUES(N'P301',N'Phòng 301',N'V1',N'Trống')
INSERT INTO Phong(MaPhong, TenPhong, MaLoai, TinhTrang) VALUES(N'P302',N'Phòng 302',N'T2',N'Trống')
INSERT INTO Phong(MaPhong, TenPhong, MaLoai, TinhTrang) VALUES(N'P303',N'Phòng 303',N'V1',N'Trống')
INSERT INTO Phong(MaPhong, TenPhong, MaLoai, TinhTrang) VALUES(N'P304',N'Phòng 304',N'V2',N'Trống')
INSERT INTO Phong(MaPhong, TenPhong, MaLoai, TinhTrang) VALUES(N'P401',N'Phòng 401',N'V2',N'Trống')
INSERT INTO Phong(MaPhong, TenPhong, MaLoai, TinhTrang) VALUES(N'P402',N'Phòng 402',N'V2',N'Trống')

INSERT INTO DichVu(MaDichVu, LoaiDichVu, TenDichVu, DonGia) VALUES(N'Coca01',N'Nước Uống',N'Nước ngọt coca chai 390ml',10000)
INSERT INTO DichVu(MaDichVu, LoaiDichVu, TenDichVu, DonGia) VALUES(N'Coca02',N'Nước Uống',N'Nước ngọt coca lon 330ml',12000)
INSERT INTO DichVu(MaDichVu, LoaiDichVu, TenDichVu, DonGia) VALUES(N'Pepsi01',N'Nước Uống',N'Nước ngọt pepsi chai 390ml',10000)
INSERT INTO DichVu(MaDichVu, LoaiDichVu, TenDichVu, DonGia) VALUES(N'Pepsi02',N'Nước Uống',N'Nước ngọt pepsi lon 330ml',12000)

INSERT INTO NhanVien(MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, DiaChi, SoDienThoai, ChucVu) VALUES(N'admin',N'Lê Đình Khang', N'Nam',N'6/7/2001',N'TPHCM',N'0777749922',N'admin')
INSERT INTO NhanVien(MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, DiaChi, SoDienThoai, ChucVu) VALUES(N'QLDV01',N'Nguyễn Văn A', N'Nam',N'2/20/2001',N'TPHCM ',N'07674376636',N'Quản lý dịch vụ')
INSERT INTO NhanVien(MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, DiaChi, SoDienThoai, ChucVu) VALUES(N'QLP01',N'Nguyễn Văn B', N'Nam',N'1/1/2001',N'TPHCM',N'0288826636',N'Quản lý phòng')
INSERT INTO NhanVien(MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, DiaChi, SoDienThoai, ChucVu) VALUES(N'QLNV01',N'Trần Văn A', N'Nam',N'5/19/2001',N'TPHCM',N'0888405052',N'Quản lý nhân viên')
INSERT INTO NhanVien(MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, DiaChi, SoDienThoai, ChucVu) VALUES(N'QLKH01',N'Nguyễn Thị C', N'Nữ',N'3/20/2001',N'TPHCM',N'07674376636',N'Quản lý khách hàng')
INSERT INTO NhanVien(MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, DiaChi, SoDienThoai, ChucVu) VALUES(N'LT01',N'Lê Văn D', N'Nam',N'9/1/2001',N'TPHCM',N'0288826636',N'Lễ tân')
INSERT INTO NhanVien(MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, DiaChi, SoDienThoai, ChucVu) VALUES(N'KT01',N'Nguyễn Thị E', N'Nữ',N'1/2/2001',N'TPHCM',N'0288826636',N'Kế toán')

INSERT INTO Account(MaNhanVien, TaiKhoan, MatKhau) VALUES(N'admin',N'dinhkhang',N'123')
INSERT INTO Account(MaNhanVien, TaiKhoan, MatKhau) VALUES(N'QLDV01',N'QLDV01',N'123')
INSERT INTO Account(MaNhanVien, TaiKhoan, MatKhau) VALUES(N'QLP01',N'QLP01',N'123')
INSERT INTO Account(MaNhanVien, TaiKhoan, MatKhau) VALUES(N'QLNV01',N'QLNV01',N'123')
INSERT INTO Account(MaNhanVien, TaiKhoan, MatKhau) VALUES(N'QLKH01',N'QLKH01',N'123')
INSERT INTO Account(MaNhanVien, TaiKhoan, MatKhau) VALUES(N'LT01',N'LT01',N'123')
INSERT INTO Account(MaNhanVien, TaiKhoan, MatKhau) VALUES(N'KT01',N'KT01',N'123')

