--create database Store_Musical
use Store_Musical
-- Tạo bảng Role
CREATE TABLE Role (
    id INT identity(1,1) PRIMARY KEY,
    role_name VARCHAR(50) NOT NULL,
    description TEXT,
    created_at datetime,
    updated_at datetime 
);

-- Tạo bảng Account
CREATE TABLE Account (
    id INT identity(1,1) PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    role_id INT,
    created_at datetime,
    updated_at datetime ,
    FOREIGN KEY (role_id) REFERENCES Role(id) ON DELETE SET NULL
);

-- Tạo bảng NhanVien
CREATE TABLE NhanVien (
    id INT identity(1,1) PRIMARY KEY,
    ten_nv VARCHAR(50) NOT NULL,
    gioi_tinh VARCHAR(10),
    cccd VARCHAR(20) UNIQUE,
    ngay_sinh DATE,
    account_id INT UNIQUE,
    created_at datetime,
    updated_at datetime ,
    FOREIGN KEY (account_id) REFERENCES Account(id) ON DELETE CASCADE
);

-- Tạo bảng KhachHang
CREATE TABLE KhachHang (
    id INT identity(1,1) PRIMARY KEY,
    ten_kh VARCHAR(50) NOT NULL,
    gioi_tinh VARCHAR(10),
    cccd VARCHAR(20) UNIQUE,
    ngay_sinh DATE,
    account_id INT UNIQUE,
    created_at datetime,
    updated_at datetime ,
    FOREIGN KEY (account_id) REFERENCES Account(id) ON DELETE CASCADE
);

-- Tạo bảng LoaiSanPham
CREATE TABLE LoaiSanPham (
    id INT identity(1,1) PRIMARY KEY,
    ten_loai VARCHAR(100) NOT NULL,
    created_at datetime,
    updated_at datetime 
);

-- Tạo bảng SanPham
CREATE TABLE SanPham (
    id INT identity(1,1) PRIMARY KEY,
    ten_sp VARCHAR(100) NOT NULL,
    loaisanpham_id INT,
    gia DECIMAL(10, 2) NOT NULL,
    mota TEXT,
    created_at datetime,
    updated_at datetime ,
    FOREIGN KEY (loaisanpham_id) REFERENCES LoaiSanPham(id) ON DELETE SET NULL
);



-- Tạo bảng DonHang
CREATE TABLE DonHang (
    id INT identity(1,1) PRIMARY KEY,
    ngay_dat DATE NOT NULL,
    khachhang_id INT,
    tong_tien DECIMAL(10, 2) NOT NULL,
    created_at datetime,
    updated_at datetime ,
    FOREIGN KEY (khachhang_id) REFERENCES KhachHang(id) ON DELETE CASCADE
);

-- Tạo bảng ChiTietDonHang
CREATE TABLE ChiTietDonHang (
    id INT identity(1,1) PRIMARY KEY,
    donhang_id INT,
    sanpham_id INT,
    so_luong INT NOT NULL,
    gia DECIMAL(10, 2) NOT NULL,
    created_at datetime,
    updated_at datetime ,
    FOREIGN KEY (donhang_id) REFERENCES DonHang(id) ON DELETE CASCADE,
    FOREIGN KEY (sanpham_id) REFERENCES SanPham(id) ON DELETE CASCADE
);

-- Tạo bảng HoaDon
CREATE TABLE HoaDon (
    id INT identity(1,1) PRIMARY KEY,
    donhang_id INT UNIQUE,
    ngay_lap DATE NOT NULL,
    tong_tien DECIMAL(10, 2) NOT NULL,
    created_at datetime,
    updated_at datetime ,
    FOREIGN KEY (donhang_id) REFERENCES DonHang(id) ON DELETE CASCADE
);

-- Tạo bảng BinhLuan
CREATE TABLE BinhLuan (
    id INT identity(1,1) PRIMARY KEY,
    sanpham_id INT,
    khachhang_id INT,
    noi_dung TEXT NOT NULL,
    sao INT CHECK (sao BETWEEN 1 AND 5),
    created_at datetime,
    updated_at datetime ,
    FOREIGN KEY (sanpham_id) REFERENCES SanPham(id) ON DELETE CASCADE,
    FOREIGN KEY (khachhang_id) REFERENCES KhachHang(id) ON DELETE CASCADE
);

-- Tạo bảng ActivityLog
CREATE TABLE ActivityLog (
    id INT identity(1,1) PRIMARY KEY,
    account_id INT,
    activity_type VARCHAR(100) NOT NULL,
    timestamp datetime,
    FOREIGN KEY (account_id) REFERENCES Account(id) ON DELETE CASCADE
);
