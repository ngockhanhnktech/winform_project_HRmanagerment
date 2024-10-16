CREATE DATABASE QuanLyNhanSu;
USE QuanLyNhanSu;
DROP DATABASE QuanLyNhanSu;

CREATE TABLE QuanTriVien (
    Ma INT PRIMARY KEY,
    TenDangNhap VARCHAR(255),
    MatKhau VARCHAR(255)
);


CREATE TABLE NguoiDung (
    Ma INT PRIMARY KEY,
    TenDangNhap VARCHAR(255),
    MatKhau VARCHAR(255)
);

CREATE TABLE VaiTro (
    Ma INT PRIMARY KEY,
    TenVaiTro VARCHAR(50)
);


CREATE TABLE VaiTroNguoiDung (
    Ma INT PRIMARY KEY,
    MaQuanTriVien INT NULL,
    MaNguoiDung INT NULL,
    MaVaiTro INT,
    FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(Ma),
    FOREIGN KEY (MaQuanTriVien) REFERENCES QuanTriVien(Ma),
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(Ma)
);


-- Bảng Thông tin cá nhân
CREATE TABLE ThongTinCaNhan (
    Ma INT PRIMARY KEY,
    soCMT varchar(55),
    hoTen varchar(255),
    gioiTinh int,
    noiSinh varchar(255),
    ngaySinh datetime,
    anh text,
    diaChi varchar(255),
    soDienThoai varchar(50),
    danToc varchar(255),
    tonGiao varchar(255),
    quocTich varchar(255),
    trinhDoHocVan varchar(255),
    ghiChu text,
    MaNguoiDung int,
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(Ma)
);

-- Bảng Phòng ban
CREATE TABLE PhongBan (
    Ma INT PRIMARY KEY,
    tenPhongBan varchar(255),
    ngayThanhLap datetime,
    ghiChu text
);

-- Bảng Bảng lương nhân viên
CREATE TABLE BangLuongNhanVien (
    Ma INT PRIMARY KEY,
    luongCoBan decimal,
    luongCoBanMoi decimal,
    phuCapChucVu decimal,
    luong decimal,
    phuCapKhac decimal,
    phuCapChucVuMoi varchar(255),
    KyLuat varchar(255),
    soNgayLamViec int,
    soNgayNghi int,
    soGioLamThem int,
    ngaySuaLuong datetime
);


-- Bảng Thông tin nhân viên
CREATE TABLE ThongTinNhanVien (
    Ma INT PRIMARY KEY,
    tinhTrangHonNhan tinyint,
    chucVu varchar(255),
    loaiHopDong varchar(255),
    ngayBatDauLamViec datetime,
    ngayKyHopDong datetime,
    ngayHetHanHopDong datetime,
    MaPhongBan int null,
    MaThongTinCaNhan int null,
    MaBangLuongNhanVien int null,
    FOREIGN KEY (MaPhongBan) REFERENCES PhongBan(Ma),
    FOREIGN KEY (MaThongTinCaNhan) REFERENCES ThongTinCaNhan(Ma),
    FOREIGN KEY (MaBangLuongNhanVien) REFERENCES BangLuongNhanVien(Ma)
);


-- Bảng Bảng lương thử việc
CREATE TABLE BangLuongThuViec (
    Ma INT PRIMARY KEY,
    soNgayLamViec int,
    soNgayNghi int,
    luong decimal,
    ghiChu text
);

-- Bảng Hồ sơ thử việc
CREATE TABLE HoSoThuViec (
    Ma INT PRIMARY KEY,
    viTriThuViec varchar(255),
    ngayBatDauThuViec datetime,
    ngayHetHan datetime,
    ghiChu text,
    MaphongBan int null,
    MaBangLuongThuViec int null,
    MaThongTinCaNhan int null,
    FOREIGN KEY (MaphongBan) REFERENCES PhongBan(Ma),
    FOREIGN KEY (MaBangLuongThuViec) REFERENCES BangLuongThuViec(Ma),
    FOREIGN KEY (MaThongTinCaNhan) REFERENCES ThongTinCaNhan(Ma)
);



-- Bảng Bảo hiểm
CREATE TABLE BaoHiem (
    Ma INT PRIMARY KEY,
    ngayCap datetime,
    noiCap datetime,
    ghiChu text,
    ngaySuaLuong datetime,
    MaThongTinCaNhan int null,
    FOREIGN KEY (MaThongTinCaNhan) REFERENCES ThongTinCaNhan(Ma)
);

-- Bảng Nghỉ thai sản
CREATE TABLE NghiThaiSan (
    Ma INT PRIMARY KEY,
    ngayNghiThaiSan datetime,
    phuCapCongTy decimal,
    MaThongTinCaNhan int null,
    FOREIGN KEY (MaThongTinCaNhan) REFERENCES ThongTinCaNhan(Ma)
);

-- Bảng Thông tin nghỉ việc
CREATE TABLE ThongTinNghiViec (
    Ma INT PRIMARY KEY,
    ngayNghiViec datetime,
    lyDo text,
    MaThongTinCaNhan int null,
    FOREIGN KEY (MaThongTinCaNhan) REFERENCES ThongTinCaNhan(Ma)
);


