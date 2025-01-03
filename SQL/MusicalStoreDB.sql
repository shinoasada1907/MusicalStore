﻿use master;
drop database Test;
create database Test;
use Test;

-- Bảng PHÂN QUYỀN
CREATE TABLE PHAN_QUYEN (
    MaPQ VARCHAR(10) PRIMARY KEY,
    TenPQ VARCHAR(20)
);

-- Bảng CHỨC VỤ
CREATE TABLE CHUC_VU (
    MaCV VARCHAR(10) PRIMARY KEY,
    TenCV VARCHAR(20),
	MucLuong INT
);

-- Bảng NHÂN VIÊN
CREATE TABLE NHAN_VIEN (
    MaNV VARCHAR(10) PRIMARY KEY,
    TenNV VARCHAR(50) NOT NULL,
    GioiTinh VARCHAR(5),
    DienThoai VARCHAR(11),
    CCCD VARCHAR(20),
    NgaySinh DATE,
	MaCV VARCHAR(10),
	FOREIGN KEY (MaCV) REFERENCES CHUC_VU(MaCV)
);
-- Bảng KHÁCH HÀNG
CREATE TABLE KHACH_HANG (
    MaKH VARCHAR(10) PRIMARY KEY,
    TenKH VARCHAR(50) NOT NULL,
    Email VARCHAR(50),
    SDT VARCHAR(11),
    GioiTinh VARCHAR(5),
    NgaySinhKH DATE,
    DiaChi VARCHAR(200)
);

-- Bảng TÀI KHOẢN
CREATE TABLE TAI_KHOAN (
    MaTK VARCHAR(10) PRIMARY KEY,
    TenTK VARCHAR(50) NOT NULL,
    MatKhau VARCHAR(20) NOT NULL,
    Email VARCHAR(50),
	MaKH VARCHAR(10),
	MaNV VARCHAR(10),
	MaPQ VARCHAR(10),
	FOREIGN KEY (MaKH) REFERENCES KHACH_HANG(MaKH),
	FOREIGN KEY (MaNV) REFERENCES NHAN_VIEN(MaNV),
	FOREIGN KEY (MaPQ) REFERENCES PHAN_QUYEN(MaPQ)
);
-- Bảng TÌNH TRẠNG
CREATE TABLE TINH_TRANG (
    MaTT INT PRIMARY KEY,
    TenTT VARCHAR(20) NOT NULL
); 
-- Bảng LOẠI SẢN PHẨM
CREATE TABLE LOAI_SAN_PHAM (
    MaLSP VARCHAR(10) PRIMARY KEY,
    TenLSP VARCHAR(50) NOT NULL
);

-- Bảng SẢN PHẨM
CREATE TABLE SAN_PHAM (
    MaSP VARCHAR(10) PRIMARY KEY,
    TenSP VARCHAR(50) NOT NULL,
    Hang VARCHAR(20),
    DVT VARCHAR(20), -- Đơn vị tính
    Gia FLOAT,
    MoTa VARCHAR(200),
    Hinh VARCHAR(100),
	SLSP INT,
    MaLSP VARCHAR(10),
    FOREIGN KEY (MaLSP) REFERENCES LOAI_SAN_PHAM(MaLSP)
);



-- Bảng CHI TIẾT SẢN PHẨM
CREATE TABLE CT_SAN_PHAM (
    MaCTSP VARCHAR(10) PRIMARY KEY,
    GioiThieu VARCHAR(200),
    ThongSo VARCHAR(200),
    TinhNang VARCHAR(200),
    MaSP VARCHAR(10),
    FOREIGN KEY (MaSP) REFERENCES SAN_PHAM(MaSP)
);

-- Bảng MÃ GIẢM GIÁ
CREATE TABLE MA_GIAM_GIA (
    MaGG VARCHAR(10) PRIMARY KEY,
    GiaTriGiam INT,
    ChiTiet VARCHAR(100)
);

-- Bảng CHI TIẾT GIẢM GIÁ
CREATE TABLE CHI_TIET_GIAM_GIA (
    NgayBD DATE,
	NgayKT DATE ,
	MaSP VARCHAR(10),
	MaGG VARCHAR(10),
	PRIMARY KEY (MaSP, MaGG),
    FOREIGN KEY (MaSP) REFERENCES SAN_PHAM(MaSP),
    FOREIGN KEY (MaGG) REFERENCES MA_GIAM_GIA(MaGG)
);
-- Bảng PHƯƠNG THỨC THANH TOÁN
CREATE TABLE PT_THANH_TOAN (
    MaPTTT VARCHAR(10) PRIMARY KEY,
    HinhThuc VARCHAR(20),
    SDT VARCHAR(11),
    TenNhan VARCHAR(50),
    NganHang VARCHAR(10),
    STK VARCHAR(20)
);
-- Bảng ĐƠN HÀNG
CREATE TABLE DON_HANG (
    MaDH VARCHAR(10) PRIMARY KEY,
    TongTienHang FLOAT NOT NULL,
    TongTT FLOAT NOT NULL,
    NgayLap DATE NOT NULL,
    TinhTrang VARCHAR(20),
    MaKH VARCHAR(10),
	MaTT INT,
	MaPTTT VARCHAR(10),
    FOREIGN KEY (MaKH) REFERENCES KHACH_HANG(MaKH),
	FOREIGN KEY (MaTT) REFERENCES TINH_TRANG(MaTT),
	FOREIGN KEY (MaPTTT) REFERENCES PT_THANH_TOAN(MaPTTT)

);

-- Bảng CHI TIẾT ĐƠN HÀNG
CREATE TABLE CT_DON_HANG (
    MaDH VARCHAR(10),
    SoLuong INT,
    Gia FLOAT,
    Tong FLOAT,
    PRIMARY KEY (MaDH, SoLuong),
    FOREIGN KEY (MaDH) REFERENCES DON_HANG(MaDH)
);


-- Bảng BÌNH LUẬN
CREATE TABLE BINH_LUAN (
    NoiDung VARCHAR(200),
    NgayDang DATE,
    Sao INT,
    MaKH VARCHAR(10),
    MaSP VARCHAR(10),
	PRIMARY KEY (MaKH, MaSP),
    FOREIGN KEY (MaKH) REFERENCES KHACH_HANG(MaKH),
    FOREIGN KEY (MaSP) REFERENCES SAN_PHAM(MaSP)
);

-- Bảng NHÀ CUNG CẤP
CREATE TABLE NHA_CUNG_CAP (
    MaNCC VARCHAR(10) PRIMARY KEY,
    TenNCC VARCHAR(20)
);

-- Bảng PHIẾU NHẬP
CREATE TABLE PHIEU_NHAP (
    MaPN VARCHAR(10) PRIMARY KEY,
    NgayLap DATE,
	NgayXuat DATE,
	MaNCC VARCHAR(10),
	MaNV VARCHAR(10),
	FOREIGN KEY (MaNCC) REFERENCES NHA_CUNG_CAP(MaNCC),
	FOREIGN KEY (MaNV) REFERENCES NHAN_VIEN(MaNV)
);

-- Bảng CT PHIẾU NHẬP
CREATE TABLE CT_PHIEU_NHAP (
    MaPN VARCHAR(10),
    MaSP VARCHAR(10),
	SLNhap INT,
	GiaNhap FLOAT,
	PRIMARY KEY (MaPN, MaSP),
    FOREIGN KEY (MaPN) REFERENCES PHIEU_NHAP(MaPN),
    FOREIGN KEY (MaSP) REFERENCES SAN_PHAM(MaSP)
);
