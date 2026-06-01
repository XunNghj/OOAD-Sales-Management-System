CREATE DATABASE SQL_THTRUEMART;
GO 
USE SQL_THTRUEMART;

-- CHINHANH
CREATE TABLE CHINHANH (
    MACN CHAR(10) NOT NULL,
    TENCN NVARCHAR(100) NOT NULL,
    DIACHI_CN NVARCHAR(255) NOT NULL,
    CONSTRAINT CHINHANH_PK PRIMARY KEY (MACN)
);
GO

-- LOAIDT
CREATE TABLE LOAIDT (
    MALOAIDT CHAR(10) NOT NULL,
    TEN_LOAIDT NVARCHAR(100) NOT NULL,
    CONSTRAINT LOAIDT_PK PRIMARY KEY (MALOAIDT),
    CONSTRAINT LOAIDT_TEN_UK UNIQUE (TEN_LOAIDT)
);
GO

-- LOAISP
CREATE TABLE LOAISP (
    MA_LOAISP CHAR(10) NOT NULL,
    TEN_LOAISP NVARCHAR(100) NOT NULL,
    CONSTRAINT LOAISP_PK PRIMARY KEY (MA_LOAISP),
    CONSTRAINT LOAISP_TEN_UK UNIQUE (TEN_LOAISP)
);
GO

-- DONVITINH
CREATE TABLE DONVITINH (
    MADVT CHAR(10) NOT NULL,
    TENDVT NVARCHAR(100) NOT NULL,
    CONSTRAINT DVT_PK PRIMARY KEY (MADVT),
    CONSTRAINT DVT_TEN_UK UNIQUE (TENDVT)
);
GO

-- LOAIQUYEN
CREATE TABLE LOAIQUYEN (
    MALOAIQUYEN CHAR(10) NOT NULL,
    TENLOAIQUYEN NVARCHAR(100) NOT NULL,
    CONSTRAINT LOAIQUYEN_PK PRIMARY KEY (MALOAIQUYEN),
    CONSTRAINT LOAIQUYEN_TEN_UK UNIQUE (TENLOAIQUYEN)
);
GO

-- LOAI_HD
CREATE TABLE LOAI_HD (
    MA_LOAIHD CHAR(10) NOT NULL,
    TEN_LOAIHD NVARCHAR(100) NOT NULL,
    CONSTRAINT LOAIHD_PK PRIMARY KEY (MA_LOAIHD),
    CONSTRAINT LOAIHD_TEN_UK UNIQUE (TEN_LOAIHD)
);
GO

-- LOAIKH
CREATE TABLE LOAIKH (
    MA_LOAIKH CHAR(10) NOT NULL,
    TEN_LOAIKH NVARCHAR(100) NOT NULL,
    CONSTRAINT LOAIKH_PK PRIMARY KEY (MA_LOAIKH),
    CONSTRAINT LOAIKH_TEN_UK UNIQUE (TEN_LOAIKH)
);
GO

-- PHONGBAN
CREATE TABLE PHONGBAN (
    MAPB CHAR(10) NOT NULL,
    TEN_PB NVARCHAR(100) NOT NULL,
    MACN CHAR(10) NOT NULL,
    CONSTRAINT PHONGBAN_PK PRIMARY KEY (MAPB),
    CONSTRAINT PHONGBAN_CN_FK FOREIGN KEY (MACN) REFERENCES CHINHANH(MACN)
);
GO

-- DONVITINHQUYDOI
CREATE TABLE DONVITINHQUYDOI (
    MADVTQD CHAR(10) NOT NULL,
    MADVT CHAR(10) NOT NULL,
    TENDVTQD NVARCHAR(100) NOT NULL,
    SOLUONGQUYDOI INT NOT NULL CHECK (SOLUONGQUYDOI > 0),
    CONSTRAINT DVTQD_PK PRIMARY KEY (MADVTQD),
    CONSTRAINT DVTQD_DVT_FK FOREIGN KEY (MADVT) REFERENCES DONVITINH(MADVT)
);
GO

-- CHUCVU
CREATE TABLE CHUCVU (
    MACV CHAR(10) NOT NULL,
    TENCV NVARCHAR(60) NOT NULL,
    CONSTRAINT CHUCVU_PK PRIMARY KEY (MACV),
    CONSTRAINT CHUCVU_TEN_UK UNIQUE (TENCV)
);
GO

-- NHANVIEN
CREATE TABLE NHANVIEN (
    MANV CHAR(10) NOT NULL,
    TENNV NVARCHAR(100) NOT NULL,
    SDT VARCHAR(12) NOT NULL,
    EMAIL VARCHAR(100) NOT NULL,
    MACV CHAR(10) NOT NULL,
    MAPB CHAR(10) NOT NULL,
    TRANGTHAI_NV NVARCHAR(50) NOT NULL,
    CONSTRAINT NV_PK PRIMARY KEY (MANV),
    CONSTRAINT NV_SDT_UK UNIQUE (SDT),
    CONSTRAINT NV_EMAIL_UK UNIQUE (EMAIL),
    CONSTRAINT NV_CV_FK FOREIGN KEY (MACV) REFERENCES CHUCVU(MACV),
    CONSTRAINT NV_PB_FK FOREIGN KEY (MAPB) REFERENCES PHONGBAN(MAPB)
);
GO

-- TAIKHOAN
CREATE TABLE TAIKHOAN (
    MATK CHAR(10) NOT NULL,
    TENTK VARCHAR(100) NOT NULL,
    MANV CHAR(10) NOT NULL,
	MK CHAR(256),
    CONSTRAINT TAIKHOAN_PK PRIMARY KEY (MATK),
    CONSTRAINT TAIKHOAN_NV_FK FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)
);
GO

-- KHACHHANG
CREATE TABLE KHACHHANG (
    MA_KH CHAR(10) NOT NULL,
    TEN_KH NVARCHAR(100) NOT NULL,
    SDT_KH VARCHAR(12) NOT NULL,
    EMAIL_KH VARCHAR(100) NOT NULL,
    DIACHI_KH NVARCHAR(255) NOT NULL,
    MA_LOAIKH CHAR(10) NOT NULL,
    CONSTRAINT KH_PK PRIMARY KEY (MA_KH),
    CONSTRAINT KH_SDT_UK UNIQUE (SDT_KH),
    CONSTRAINT KH_EMAIL_UK UNIQUE (EMAIL_KH),
    CONSTRAINT KH_LOAIKH_FK FOREIGN KEY (MA_LOAIKH) REFERENCES LOAIKH(MA_LOAIKH)
);
GO

-- THETHANHVIEN
CREATE TABLE THETHANHVIEN (
    SOTHE CHAR(10) NOT NULL,
    NGAYCAP DATE NOT NULL CHECK(NGAYCAP <= GETDATE()),
    DIEM_HT INT NOT NULL,
    DIEM_TL_NGAY INT NOT NULL,
    DIEM_CK INT NOT NULL,
    GHICHU_TTV NVARCHAR(255),
    NGAY_CN DATE NOT NULL CHECK(NGAY_CN <= GETDATE()),
    MA_KH CHAR(10) NOT NULL,
    CONSTRAINT TTV_PK PRIMARY KEY (SOTHE),
    CONSTRAINT TTV_KH_FK FOREIGN KEY (MA_KH) REFERENCES KHACHHANG(MA_KH)
);
GO

-- NGANHANG
CREATE TABLE NGANHANG (
    MA_NH CHAR(10) NOT NULL,
    TEN_NH NVARCHAR(100) NOT NULL,
    SDT_NH VARCHAR(12) NOT NULL,
    DIACHI_NH NVARCHAR(255) NOT NULL,
    CHINHANH_NH NVARCHAR(100) NOT NULL,
    MA_KH CHAR(10) NOT NULL,
    CONSTRAINT NH_PK PRIMARY KEY (MA_NH),
    CONSTRAINT NH_SDT_UK UNIQUE (SDT_NH),
    CONSTRAINT NH_KH_FK FOREIGN KEY (MA_KH) REFERENCES KHACHHANG(MA_KH)
);
GO

-- SANPHAM
CREATE TABLE SANPHAM (
    MASP CHAR(10) NOT NULL,
    MA_LOAISP CHAR(10) NOT NULL,
    MADVT CHAR(10) NOT NULL,
    MADVTQD CHAR(10) NOT NULL,
    TENSP NVARCHAR(100) NOT NULL,
    MOTASP NVARCHAR(180),
    HINHANH_SP VARCHAR(255),
    NXSSP DATE NOT NULL CHECK (NXSSP <= GETDATE()),
    HSDSP INT NOT NULL CHECK (HSDSP > 0),
    CONSTRAINT SANPHAM_PK PRIMARY KEY (MASP),
    CONSTRAINT SANPHAM_LOAISP_FK FOREIGN KEY (MA_LOAISP) REFERENCES LOAISP(MA_LOAISP),
    CONSTRAINT SANPHAM_DVT_FK FOREIGN KEY (MADVT) REFERENCES DONVITINH(MADVT),
    CONSTRAINT SANPHAM_DVTQD_FK FOREIGN KEY (MADVTQD) REFERENCES DONVITINHQUYDOI(MADVTQD)
);
GO

-- KHO
CREATE TABLE KHO (
    MA_KHO CHAR(10) NOT NULL,
    TEN_KHO NVARCHAR(100) NOT NULL,
    DIACHI_KHO NVARCHAR(255) NOT NULL,
    CONSTRAINT KHO_PK PRIMARY KEY (MA_KHO)
);
GO

-- TONKHO
CREATE TABLE TONKHO (
    MA_KHO CHAR(10) NOT NULL,
    MASP CHAR(10) NOT NULL,
    NGAYCN_TK DATE NOT NULL CHECK (NGAYCN_TK <= GETDATE()),
    THANGTK INT NOT NULL CHECK (THANGTK BETWEEN 1 AND 12),
    NAMTK INT NOT NULL CHECK (NAMTK >= 2000),
    TONDK DECIMAL(18,2) NOT NULL,
    TRIGIATONDK DECIMAL(18,2) NOT NULL,
    NHAPTK DECIMAL(18,2) NOT NULL,
    TRIGIANHAPTK DECIMAL(18,2) NOT NULL,
    XUATTK DECIMAL(18,2) NOT NULL,
    TRIGIAXUATTK DECIMAL(18,2) NOT NULL,
    TONCK DECIMAL(18,2) NOT NULL,
    TRIGIATONCK DECIMAL(18,2) NOT NULL,
    CONSTRAINT TONKHO_PK PRIMARY KEY (MA_KHO, MASP),
    CONSTRAINT TONKHO_KHO_FK FOREIGN KEY (MA_KHO) REFERENCES KHO(MA_KHO),
    CONSTRAINT TONKHO_SP_FK FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP),
    CONSTRAINT TONKHO_TON_CHK CHECK (TONCK = TONDK + NHAPTK - XUATTK)
);
GO

-- NHACUNGCAP
CREATE TABLE NHACUNGCAP (
    MA_NCC CHAR(10) NOT NULL,
    TEN_NCC NVARCHAR(100) NOT NULL,
    SDT_NCC VARCHAR(12) NOT NULL,
    DIACHI_NCC NVARCHAR(255) NOT NULL,
    EMAIL_NCC VARCHAR(100) NOT NULL,
    CONSTRAINT NCC_PK PRIMARY KEY (MA_NCC),
    CONSTRAINT NCC_SDT_UK UNIQUE (SDT_NCC),
    CONSTRAINT NCC_EMAIL_UK UNIQUE (EMAIL_NCC)
);
GO


-- PHIEUNHAP
CREATE TABLE PHIEUNHAP (
    SO_PN CHAR(10) NOT NULL,
    NGAYNHAP DATE NOT NULL CHECK(NGAYNHAP <= GETDATE()),
    LYDONHAP NVARCHAR(255),
    TRIGIA_PN DECIMAL(18,2) NOT NULL,
    GHICHU_PN NVARCHAR(100),
    MA_NCC CHAR(10) NOT NULL,
    MANV CHAR(10) NOT NULL,
    CONSTRAINT PHIEUNHAP_PK PRIMARY KEY (SO_PN),
    CONSTRAINT PHIEUNHAP_NCC_FK FOREIGN KEY (MA_NCC) REFERENCES NHACUNGCAP(MA_NCC),
    CONSTRAINT PHIEUNHAP_NV_FK FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)
);
GO

-- CT_PHIEUNHAP
CREATE TABLE CT_PHIEUNHAP (
    SO_PN CHAR(10) NOT NULL,
    MASP CHAR(10) NOT NULL,
    SOLUONGNHAP INT NOT NULL CHECK (SOLUONGNHAP > 0),
    DONGIA_PN DECIMAL(18,2) NOT NULL,
    THANHTIEN_PN DECIMAL(18,2) NOT NULL,
    CONSTRAINT CTPN_PK PRIMARY KEY (SO_PN, MASP),
    CONSTRAINT CTPN_PN_FK FOREIGN KEY (SO_PN) REFERENCES PHIEUNHAP(SO_PN)
        ON DELETE CASCADE,
    CONSTRAINT CTPN_SP_FK FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP)
);
GO

-- PHIEUXUAT
CREATE TABLE PHIEUXUAT (
    MA_PX CHAR(10) NOT NULL,
    NGAYXUAT DATE NOT NULL CHECK(NGAYXUAT <= GETDATE()),
    LYDOXUAT NVARCHAR(255),
    TRIGIA_PX DECIMAL(18,2) NOT NULL,
    DIADIEMGH NVARCHAR(100) NOT NULL,
    GHICHU_PX NVARCHAR(100),
    MA_KHO CHAR(10) NOT NULL,
    MANV CHAR(10) NOT NULL,
    CONSTRAINT PHIEUXUAT_PK PRIMARY KEY (MA_PX),
	CONSTRAINT PHIEUXUAT_KHO_FK FOREIGN KEY (MA_KHO) REFERENCES KHO(MA_KHO),
    CONSTRAINT PHIEUXUAT_NV_FK FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)
);
GO

-- CT_PHIEUXUAT
CREATE TABLE CT_PHIEUXUAT (
    MA_PX CHAR(10) NOT NULL,
    MASP CHAR(10) NOT NULL,
    SOLUONGXUAT INT NOT NULL CHECK(SOLUONGXUAT > 0),
    DONGIA_PX DECIMAL(18,2) NOT NULL,
    THANHTIEN_PX DECIMAL(18,2) NOT NULL,
    CONSTRAINT CTPX_PK PRIMARY KEY (MA_PX, MASP),
    CONSTRAINT CTPX_PX_FK FOREIGN KEY (MA_PX) REFERENCES PHIEUXUAT(MA_PX)
        ON DELETE CASCADE,
    CONSTRAINT CTPX_SP_FK FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP)
);
GO

-- HOADON
CREATE TABLE HOADON (
    MA_HD CHAR(10) NOT NULL,
    NGAYLAPHD DATE NOT NULL CHECK(NGAYLAPHD <= GETDATE()),
    HINHTHUCTT NVARCHAR(100) NOT NULL,
    THUEVAT DECIMAL(18,2) NOT NULL CHECK(THUEVAT >= 0),
    TRIGIATRUOCTHUE DECIMAL(18,2) NOT NULL,
    TRIGIASAUTHUE DECIMAL(18,2) NOT NULL,
    TONGTIENGIAM DECIMAL(18,2) NOT NULL CHECK(TONGTIENGIAM >= 0),
    TONGCONGTHANHTIEN DECIMAL(18,2) NOT NULL,
    GHICHU_HD NVARCHAR(255),
    MA_KH CHAR(10) NOT NULL,
    MA_LOAIHD CHAR(10) NOT NULL,
	MA_PX CHAR(10) NOT NULL, 
    CONSTRAINT HOADON_PK PRIMARY KEY (MA_HD),
    CONSTRAINT HOADON_KH_FK FOREIGN KEY (MA_KH) REFERENCES KHACHHANG(MA_KH),
    CONSTRAINT HOADON_LOAIHD_FK FOREIGN KEY (MA_LOAIHD) REFERENCES LOAI_HD(MA_LOAIHD),
	CONSTRAINT HOADON_PX_FK FOREIGN KEY (MA_PX) REFERENCES PHIEUXUAT(MA_PX)
);
GO

-- CT_HD
CREATE TABLE CT_HD (
    MA_HD CHAR(10) NOT NULL,
    MASP CHAR(10) NOT NULL,
    SOLUONG_TRA INT NOT NULL CHECK(SOLUONG_TRA > 0),
    DONGIA_HD DECIMAL(18,2) NOT NULL,
    PHANTRAMGIAMHD DECIMAL(18,2) NOT NULL CHECK(PHANTRAMGIAMHD >= 0),
    GIASAUGIAM DECIMAL(18,2) NOT NULL,
    THANHTIENHD DECIMAL(18,2) NOT NULL,
    CONSTRAINT CTHD_PK PRIMARY KEY (MA_HD, MASP),
    CONSTRAINT CTHD_HD_FK FOREIGN KEY (MA_HD) REFERENCES HOADON(MA_HD)
        ON DELETE CASCADE,
    CONSTRAINT CTHD_SP_FK FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP)
);
GO

-- PHIEUTRAHANG
CREATE TABLE PHIEUTRAHANG (
    MA_PTH CHAR(10) NOT NULL,
    NGAYTRA DATE NOT NULL CHECK(NGAYTRA <= GETDATE()),
    LYDOTRA NVARCHAR(255),
    TONGTIENHOAN DECIMAL(18,2) NOT NULL,
    TRANGTHAI_TRAHANG NVARCHAR(100) NOT NULL,
    PHUONGTHUCHOAN NVARCHAR(100) NOT NULL,
    GHICHU_TRAHANG NVARCHAR(255),
    MA_KH CHAR(10) NOT NULL,
    MA_NCC CHAR(10) NOT NULL,
    MANV CHAR(10) NOT NULL,
    CONSTRAINT PTH_PK PRIMARY KEY (MA_PTH),
    CONSTRAINT PTH_KH_FK FOREIGN KEY (MA_KH) REFERENCES KHACHHANG(MA_KH),
    CONSTRAINT PTH_NCC_FK FOREIGN KEY (MA_NCC) REFERENCES NHACUNGCAP(MA_NCC),
    CONSTRAINT PTH_NV_FK FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)
);
GO

-- CT_PHIEUTRAHANG
CREATE TABLE CT_PHIEUTRAHANG (
    MA_PTH CHAR(10) NOT NULL,
    MA_HD CHAR(10) NOT NULL,
    SOLUONG_TRA INT NOT NULL CHECK(SOLUONG_TRA > 0),
    DONGIA_TRA DECIMAL(18,2) NOT NULL,
    THANHTIEN_TRA DECIMAL(18,2) NOT NULL,
    CONSTRAINT CTPTH_PK PRIMARY KEY (MA_PTH, MA_HD),
    CONSTRAINT CTPTH_PTH_FK FOREIGN KEY (MA_PTH) REFERENCES PHIEUTRAHANG(MA_PTH)
        ON DELETE CASCADE,
    CONSTRAINT CTPTH_HD_FK FOREIGN KEY (MA_HD) REFERENCES HOADON(MA_HD)
);
GO


-- DOITUONG
CREATE TABLE DOITUONG (
    MA_DT CHAR(10) NOT NULL,
    TEN_DT NVARCHAR(100) NOT NULL,
    MALOAIDT CHAR(10) NOT NULL,
    CONSTRAINT DOITUONG_PK PRIMARY KEY (MA_DT),
    CONSTRAINT DOITUONG_LDT_FK FOREIGN KEY (MALOAIDT) REFERENCES LOAIDT(MALOAIDT)
);
GO


-- QUYEN
CREATE TABLE QUYEN (
    MAQUYEN CHAR(10) NOT NULL,
    TENQUYEN NVARCHAR(100) NOT NULL,
    MALOAIQUYEN CHAR(10) NOT NULL,
    CONSTRAINT QUYEN_PK PRIMARY KEY (MAQUYEN),
    CONSTRAINT QUYEN_LQ_FK FOREIGN KEY (MALOAIQUYEN) REFERENCES LOAIQUYEN(MALOAIQUYEN)
);
GO

-- VAITRO
CREATE TABLE VAITRO (
    MAVT CHAR(10) NOT NULL,
    TENVT NVARCHAR(100) NOT NULL,
    CONSTRAINT VAITRO_PK PRIMARY KEY (MAVT),
    CONSTRAINT VAITRO_TEN_UK UNIQUE (TENVT)
);
ALTER TABLE VAITRO
ADD MATK CHAR(10) NOT NULL;

ALTER TABLE VAITRO
ADD CONSTRAINT VAITRO_TK_FK
FOREIGN KEY (MATK) REFERENCES TAIKHOAN(MATK);
GO

-- PHANQUYEN
CREATE TABLE PHANQUYEN (
    MAVT CHAR(10) NOT NULL,
    MAQUYEN CHAR(10) NOT NULL,
    MA_DT CHAR(10) NOT NULL,
    NGAY_PQ DATE NOT NULL CHECK(NGAY_PQ <= GETDATE()),
    NGUOICAP NVARCHAR(100) NOT NULL,
    TRANGTHAI_PQ NVARCHAR(100) NOT NULL,
    CONSTRAINT PHANQUYEN_PK PRIMARY KEY (MAVT, MAQUYEN, MA_DT),
    CONSTRAINT PQ_VT_FK FOREIGN KEY (MAVT) REFERENCES VAITRO(MAVT)
        ON DELETE CASCADE,
    CONSTRAINT PQ_Q_FK FOREIGN KEY (MAQUYEN) REFERENCES QUYEN(MAQUYEN)
        ON DELETE CASCADE,
    CONSTRAINT PQ_DT_FK FOREIGN KEY (MA_DT) REFERENCES DOITUONG(MA_DT)
        ON DELETE CASCADE
);
GO

-- DONHANG
CREATE TABLE DONHANG (
    MA_DH CHAR(10) NOT NULL,
    NGAYLAP_DH DATE NOT NULL CHECK(NGAYLAP_DH <= GETDATE()),
    THANHTIEN_DH DECIMAL(18,2) NOT NULL,
    HINHTHUCTT_DH NVARCHAR(100) NOT NULL,
    MA_KH CHAR(10) NOT NULL,
    MANV CHAR(10) NOT NULL,
    CONSTRAINT DONHANG_PK PRIMARY KEY (MA_DH),
    CONSTRAINT DH_KH_FK FOREIGN KEY (MA_KH) REFERENCES KHACHHANG(MA_KH),
    CONSTRAINT DH_NV_FK FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)
);
GO

-- CT_DH
CREATE TABLE CT_DH (
    MA_DH CHAR(10) NOT NULL,
    MASP CHAR(10) NOT NULL,
    SOLUONG_DH INT NOT NULL CHECK (SOLUONG_DH > 0),
    DONGIA_DH DECIMAL(18,2) NOT NULL,
    GIAMGIA_DH DECIMAL(18,2) NOT NULL CHECK(GIAMGIA_DH >= 0),
    GHICHU_DH NVARCHAR(255),
    CONSTRAINT CTDH_PK PRIMARY KEY (MA_DH, MASP),
    CONSTRAINT CTDH_DH_FK FOREIGN KEY (MA_DH) REFERENCES DONHANG(MA_DH)
        ON DELETE CASCADE,
    CONSTRAINT CTDH_SP_FK FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP)
);
GO

-- CHUONGTRINHKHUYENMAI
CREATE TABLE CHUONGTRINHKHUYENMAI (
    MA_CTKM CHAR(10) NOT NULL,
    TEN_CTKM NVARCHAR(100) NOT NULL,
    NGAYBDCTKM DATE NOT NULL CHECK(NGAYBDCTKM <= GETDATE()),
    NGAYKTCTKM DATE NOT NULL,
    LYDOCTKM NVARCHAR(255),
    CONSTRAINT CTKM_PK PRIMARY KEY (MA_CTKM),
    CONSTRAINT CTKM_NGAY_CHK CHECK (NGAYKTCTKM >= NGAYBDCTKM)
);
GO

-- CT_CTKM
CREATE TABLE CT_CTKM (
    MASP CHAR(10) NOT NULL,
    MA_CTKM CHAR(10) NOT NULL,
    PHAMTRAMGIAM DECIMAL(18,2) NOT NULL CHECK(PHAMTRAMGIAM >= 0),
    GHICHU NVARCHAR(255),
    CONSTRAINT CTKMCT_PK PRIMARY KEY (MASP, MA_CTKM),
    CONSTRAINT CTKMCT_SP_FK FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP),
    CONSTRAINT CTKMCT_CTKM_FK FOREIGN KEY (MA_CTKM) REFERENCES CHUONGTRINHKHUYENMAI(MA_CTKM)
        ON DELETE CASCADE
);
GO

-- BIENDONGGIA
CREATE TABLE BIENDONGGIA (
    MASP CHAR(10) NOT NULL,
    NGAYCAPNHAT_BDG DATE NOT NULL CHECK(NGAYCAPNHAT_BDG <= GETDATE()),
    GIABAN DECIMAL(18,2) NOT NULL CHECK(GIABAN >= 0),
    CONSTRAINT BDG_PK PRIMARY KEY (MASP, NGAYCAPNHAT_BDG),
    CONSTRAINT BDG_SP_FK FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP)
        ON DELETE CASCADE
);
GO
select* from CHINHANH
-- CHINHANH
INSERT INTO CHINHANH (MACN, TENCN, DIACHI_CN) VALUES
('CN001', N'Chi Nhánh 1 TP. HCM', N'123 Nguyễn Văn Cừ, Phường 4, Quận 5, TP. Hồ Chí Minh'),
('CN002', N'Chi Nhánh 2 Hà Nội', N'456 Trần Duy Hưng, Phường Trung Hòa, Quận Cầu Giấy, TP. Hà Nội'),
('CN003', N'Chi Nhánh 3 Đà Nẵng', N'789 Lê Duẩn, Phường Chính Gián, Quận Thanh Khê, TP. Đà Nẵng'),
('CN004', N'Chi Nhánh 4 Cần Thơ', N'30/4, Phường Xuân Khánh, Quận Ninh Kiều, TP. Cần Thơ'),
('CN005', N'Chi Nhánh 5 Hải Phòng', N'22 Điện Biên Phủ, Phường Máy Tơ, Quận Ngô Quyền, TP. Hải Phòng'),
('CN006', N'Chi Nhánh 6 Bình Dương', N'55 Đại Lộ Bình Dương, Phường Phú Hòa, TP. Thủ Dầu Một, Tỉnh Bình Dương'),
('CN007', N'Chi Nhánh 7 Đồng Nai', N'1A Phạm Văn Thuận, Phường Tân Mai, TP. Biên Hòa, Tỉnh Đồng Nai'),
('CN008', N'Chi Nhánh 8 Nha Trang', N'60 Thái Nguyên, Phường Phước Tân, TP. Nha Trang, Tỉnh Khánh Hòa'),
('CN009', N'Chi Nhánh 9 Huế', N'100 Hùng Vương, Phường Phú Nhuận, TP. Huế, Tỉnh Thừa Thiên Huế'),
('CN010', N'Chi Nhánh 10 Vũng Tàu', N'99 Ba Mươi Tháng Tư, Phường 9, TP. Vũng Tàu, Tỉnh Bà Rịa - Vũng Tàu');
GO

-- LOAIDT
INSERT INTO LOAIDT (MALOAIDT, TEN_LOAIDT) VALUES
('LDT001', N'Phòng Ban'),
('LDT002', N'Chức Vụ'),
('LDT003', N'Nhân Viên'),
('LDT004', N'Khách Hàng'),
('LDT005', N'Sản Phẩm'),
('LDT006', N'Kho Hàng'),
('LDT007', N'Hóa Đơn'),
('LDT008', N'Nhà Cung Cấp'),
('LDT009', N'Đơn Hàng'),
('LDT010', N'Chương Trình KM');
GO

-- LOAISP
INSERT INTO LOAISP (MA_LOAISP, TEN_LOAISP) VALUES
('LSP001', N'Sữa Tươi Thanh Trùng'),
('LSP002', N'Sữa Tươi Tiệt Trùng'),
('LSP003', N'Sữa Chua & Kem'),
('LSP004', N'Đồ Uống Giải Khát'),
('LSP005', N'Thực Phẩm Chế Biến'),
('LSP006', N'Các Sản Phẩm Từ Sữa'),
('LSP007', N'Nước Suối & Nước Khoáng'),
('LSP008', N'Bánh Kẹo & Đồ Ăn Vặt'),
('LSP009', N'Trái Cây & Rau Củ'),
('LSP010', N'Hàng Gia Dụng');
GO

-- DONVITINH
INSERT INTO DONVITINH (MADVT, TENDVT) VALUES
('DVT001', N'Thùng'),
('DVT002', N'Lốc'),
('DVT003', N'Chai'),
('DVT004', N'Hộp'),
('DVT005', N'Gói'),
('DVT006', N'Kg'),
('DVT007', N'Chiếc'),
('DVT008', N'Cái'),
('DVT009', N'Bó'),
('DVT010', N'Viên');
GO

-- LOAIQUYEN
INSERT INTO LOAIQUYEN (MALOAIQUYEN, TENLOAIQUYEN) VALUES
('LQUY01', N'Quản Trị Hệ Thống'),
('LQUY02', N'Quản Lý Dữ Liệu Gốc'),
('LQUY03', N'Quản Lý Kho Hàng'),
('LQUY04', N'Quản Lý Bán Hàng'),
('LQUY05', N'Quản Lý Khách Hàng'),
('LQUY06', N'Quản Lý Đơn Hàng'),
('LQUY07', N'Quản Lý Chương Trình KM'),
('LQUY08', N'Báo Cáo - Thống Kê'),
('LQUY09', N'Thực Hiện Giao Dịch'),
('LQUY10', N'Xem Thông Tin');
GO

-- LOAI_HD
INSERT INTO LOAI_HD (MA_LOAIHD, TEN_LOAIHD) VALUES
('LHD001', N'Hóa Đơn Bán Lẻ'),
('LHD002', N'Hóa Đơn Xuất Kho'),
('LHD003', N'Hóa Đơn VAT'),
('LHD004', N'Hóa Đơn Điện Tử'),
('LHD005', N'Hóa Đơn Đổi Trả'),
('LHD006', N'Hóa Đơn Khuyến Mãi'),
('LHD007', N'Hóa Đơn Sỉ'),
('LHD008', N'Hóa Đơn Trả Hàng Sỉ'),
('LHD009', N'Hóa Đơn Online'),
('LHD010', N'Hóa Đơn Nhập Khẩu');
GO

-- LOAIKH
INSERT INTO LOAIKH (MA_LOAIKH, TEN_LOAIKH) VALUES
('LKH001', N'Khách Hàng Thường'),
('LKH002', N'Khách Hàng Thành Viên Bạc'),
('LKH003', N'Khách Hàng Thành Viên Vàng'),
('LKH004', N'Khách Hàng Thành Viên Kim Cương'),
('LKH005', N'Khách Hàng Doanh Nghiệp'),
('LKH006', N'Khách Hàng Tiềm Năng'),
('LKH007', N'Khách Vãng Lai'),
('LKH008', N'Khách Hàng VIP'),
('LKH009', N'Khách Hàng Thân Thiết'),
('LKH010', N'Khách Hàng Mới');
GO

-- PHONGBAN (Cần MACN từ CHINHANH)
INSERT INTO PHONGBAN (MAPB, TEN_PB, MACN) VALUES
('PB001', N'Kế Toán - Tài Chính', 'CN001'),
('PB002', N'Kinh Doanh - Bán Hàng', 'CN001'),
('PB003', N'Quản Lý Kho Vận', 'CN002'),
('PB004', N'Marketing - Truyền Thông', 'CN002'),
('PB005', N'Nhân Sự - Hành Chính', 'CN003'),
('PB006', N'Phòng Công Nghệ', 'CN003'),
('PB007', N'Hỗ Trợ Khách Hàng', 'CN004'),
('PB008', N'Quản Lý Chất Lượng', 'CN005'),
('PB009', N'Phát Triển Sản Phẩm', 'CN006'),
('PB010', N'Phòng Điều Hành', 'CN007');
GO

-- DONVITINHQUYDOI (Cần MADVT từ DONVITINH)
INSERT INTO DONVITINHQUYDOI (MADVTQD, MADVT, TENDVTQD, SOLUONGQUYDOI) VALUES
('QDVT001', 'DVT001', N'Hộp 180ml', 48), -- Thùng (DVT001) -> Hộp (48 hộp/thùng)
('QDVT002', 'DVT002', N'Hộp 180ml', 4), -- Lốc (DVT002) -> Hộp (4 hộp/lốc)
('QDVT003', 'DVT003', N'Lít', 1), -- Chai (DVT003) -> Lít
('QDVT004', 'DVT004', N'ml', 180), -- Hộp (DVT004) -> ml
('QDVT005', 'DVT005', N'gram', 500), -- Gói (DVT005) -> gram
('QDVT006', 'DVT006', N'gram', 1000), -- Kg (DVT006) -> gram
('QDVT007', 'DVT007', N'Đôi', 1),
('QDVT008', 'DVT008', N'Bộ', 1),
('QDVT009', 'DVT009', N'Cây', 10), -- Bó (DVT009) -> Cây
('QDVT010', 'DVT004', N'Hộp 110ml', 1);
GO

-- CHUCVU
INSERT INTO CHUCVU (MACV, TENCV) VALUES
('CV001', N'Giám Đốc Chi Nhánh'),
('CV002', N'Trưởng Phòng'),
('CV003', N'Trưởng Nhóm Bán Hàng'),
('CV004', N'Nhân Viên Bán Hàng'),
('CV005', N'Nhân Viên Kế Toán'),
('CV006', N'Nhân Viên Kho'),
('CV007', N'Nhân Viên IT'),
('CV008', N'Nhân Viên Marketing'),
('CV009', N'Thủ Kho'),
('CV010', N'Bảo Vệ');
GO

-- KHO
INSERT INTO KHO (MA_KHO, TEN_KHO, DIACHI_KHO) VALUES
('KHO001', N'Kho Trung Tâm Sài Gòn', N'200 Võ Văn Kiệt, Phường Cầu Ông Lãnh, Quận 1, TP. Hồ Chí Minh'),
('KHO002', N'Kho Khu Vực Miền Bắc', N'Lô C2, Đường D5, Khu CN Thăng Long, TP. Hà Nội'),
('KHO003', N'Kho Đà Nẵng', N'12 Ngũ Hành Sơn, Phường Mỹ An, Quận Ngũ Hành Sơn, TP. Đà Nẵng'),
('KHO004', N'Kho Cần Thơ', N'Đường Số 1, KDC Hưng Phú, Phường Hưng Phú, Quận Cái Răng, TP. Cần Thơ'),
('KHO005', N'Kho Thủ Đức', N'90 Xa Lộ Hà Nội, Phường Hiệp Phú, TP. Thủ Đức, TP. Hồ Chí Minh'),
('KHO006', N'Kho Bình Dương', N'Khu Phố 4, Phường An Phú, TP. Thuận An, Tỉnh Bình Dương'),
('KHO007', N'Kho Biên Hòa', N'Đường Nguyễn Ái Quốc, Phường Quang Vinh, TP. Biên Hòa, Tỉnh Đồng Nai'),
('KHO008', N'Kho Hải Phòng', N'221 Lạch Tray, Phường Đông Hải, Quận Hải An, TP. Hải Phòng'),
('KHO009', N'Kho Vũng Tàu', N'345 Thống Nhất, Phường 8, TP. Vũng Tàu, Tỉnh Bà Rịa - Vũng Tàu'),
('KHO010', N'Kho Miền Trung', N'55 Tố Hữu, Phường Hòa Cường Nam, Quận Hải Châu, TP. Đà Nẵng');
GO

-- NHACUNGCAP
INSERT INTO NHACUNGCAP (MA_NCC, TEN_NCC, SDT_NCC, DIACHI_NCC, EMAIL_NCC) VALUES
('NCC001', N'Công ty CP Sữa TH True Milk', '02438889999', N'Đường Vạn Phúc, Phường Kim Mã, Quận Ba Đình, TP. Hà Nội', 'thmilk@thgroup.vn'),
('NCC002', N'Công ty CP Thực Phẩm Miền Đông', '02837776666', N'Khu Công Nghiệp Amata, TP. Biên Hòa, Tỉnh Đồng Nai', 'thucphammd@md.vn'),
('NCC003', N'Công ty Nước Giải Khát Quốc Tế', '02365554444', N'Đường Điện Biên Phủ, Phường Thanh Khê, TP. Đà Nẵng', 'nuocgiaikhat@qte.com'),
('NCC004', N'Công ty CP Nông Sản Sạch', '02921112222', N'Đường 30/4, Phường Hưng Lợi, Quận Ninh Kiều, TP. Cần Thơ', 'nongsansach@ns.vn'),
('NCC005', N'Công ty Thiết Bị Gia Dụng', '02253331111', N'Đường Lê Hồng Phong, Phường Đông Khê, Quận Ngô Quyền, TP. Hải Phòng', 'giadung@tbgd.com'),
('NCC006', N'Công ty CP Bánh Kẹo Việt Nam', '02744445555', N'Đại Lộ Bình Dương, Phường An Phú, TP. Thuận An, Tỉnh Bình Dương', 'banhkeo@vn.com'),
('NCC007', N'Doanh Nghiệp Tư Nhân VinaFarm', '02586667777', N'Đường Hoàng Diệu, Phường Vĩnh Nguyên, TP. Nha Trang, Tỉnh Khánh Hòa', 'vinafarm@agri.vn'),
('NCC008', N'Công ty Cung Ứng Vật Tư', '02348880000', N'Đường Phan Bội Châu, Phường Vĩnh Ninh, TP. Huế, Tỉnh Thừa Thiên Huế', 'vattu@cungung.com'),
('NCC009', N'Công ty Thực Phẩm Chế Biến Mới', '02542223333', N'Đường Thống Nhất, Phường 1, TP. Vũng Tàu, Tỉnh Bà Rịa - Vũng Tàu', 'tpchebien@new.vn'),
('NCC010', N'Cty CP Bao Bì Đóng Gói', '02839998888', N'Đường Tô Ký, Phường Trung Mỹ Tây, Quận 12, TP. Hồ Chí Minh', 'baobi@pkg.vn');
GO

-- VAITRO (Cần MATK từ TAIKHOAN, tạm thời chưa có MATK)
INSERT INTO VAITRO (MAVT, TENVT, MATK) VALUES
('VT001', N'Admin Tổng', 'TK001'),
('VT002', N'Quản Lý Chi Nhánh', 'TK002'),
('VT003', N'Nhân Viên Kế Toán', 'TK003'),
('VT004', N'Nhân Viên Bán Hàng', 'TK004'),
('VT005', N'Thủ Kho Chính', 'TK005'),
('VT006', N'Nhân Viên Marketing', 'TK008'),
('VT007', N'Trưởng Phòng Kinh Doanh', 'TK010'),
('VT008', N'Nhân Viên Hỗ Trợ', 'TK012'),
('VT009', N'Quản Lý Chất Lượng', 'TK015'),
('VT010', N'Nhân Viên Hành Chính', 'TK018');
GO

-- QUYEN (Cần MALOAIQUYEN từ LOAIQUYEN)
INSERT INTO QUYEN (MAQUYEN, TENQUYEN, MALOAIQUYEN) VALUES
('Q001', N'Tạo Mới (Create)', 'LQUY02'),
('Q002', N'Đọc (Read)', 'LQUY10'),
('Q003', N'Cập Nhật (Update)', 'LQUY02'),
('Q004', N'Xóa (Delete)', 'LQUY01'),
('Q005', N'Nhập Kho', 'LQUY03'),
('Q006', N'Xuất Kho', 'LQUY03'),
('Q007', N'Lập Hóa Đơn', 'LQUY04'),
('Q008', N'Quản Lý Thẻ Thành Viên', 'LQUY05'),
('Q009', N'Thiết Lập Chương Trình KM', 'LQUY07'),
('Q010', N'Xem Báo Cáo Doanh Thu', 'LQUY08');
GO

-- DOITUONG (Cần MALOAIDT từ LOAIDT)
INSERT INTO DOITUONG (MA_DT, TEN_DT, MALOAIDT) VALUES
('DT001', N'Quản Lý Sản Phẩm', 'LDT005'),
('DT002', N'Quản Lý Khách Hàng', 'LDT004'),
('DT003', N'Quản Lý Kho Nhập', 'LDT006'),
('DT004', N'Quản Lý Kho Xuất', 'LDT006'),
('DT005', N'Quản Lý Hóa Đơn', 'LDT007'),
('DT006', N'Quản Lý NCC', 'LDT008'),
('DT007', N'Quản Lý Nhân Sự', 'LDT003'),
('DT008', N'Quản Lý Đơn Hàng', 'LDT009'),
('DT009', N'Quản Lý Khuyến Mãi', 'LDT010'),
('DT010', N'Quản Lý Tài Khoản', 'LDT001');
GO

-- NHANVIEN (Cần MACV, MAPB)
SET DATEFORMAT dmy;
INSERT INTO NHANVIEN (MANV, TENNV, SDT, EMAIL, MACV, MAPB, TRANGTHAI_NV) VALUES
('NV001', N'Nguyễn Văn Anh', '0901111111', 'vana@thtruemart.com',  'CV001', 'PB010', N'Đang làm việc'),
('NV002', N'Trần Thị Bình', '0902222222', 'thib@thtruemart.com',  'CV002', 'PB002', N'Đang làm việc'),
('NV003', N'Lê Văn Cường', '0903333333', 'vanc@thtruemart.com',  'CV003', 'PB002', N'Đang làm việc'),
('NV004', N'Phạm Thị Diệu', '0904444444', 'thid@thtruemart.com', 'CV004', 'PB002', N'Đang làm việc'),
('NV005', N'Hoàng Trung Hiếu', '0905555555', 'vane@thtruemart.com',  'CV006', 'PB003', N'Đang làm việc'),
('NV006', N'Đỗ Hà Phương', '0906666666', 'thif@thtruemart.com',  'CV004', 'PB002', N'Đang làm việc'),
('NV007', N'Ngô Công Giao', '0907777777', 'vang@thtruemart.com', 'CV005', 'PB001', N'Đang làm việc'),
('NV008', N'Bùi Thanh Huyền', '0908888888', 'thih@thtruemart.com', 'CV008', 'PB004', N'Đang làm việc'),
('NV009', N'Đinh Văn Khánh', '0909999999', 'vani@thtruemart.com',  'CV007', 'PB006', N'Đang làm việc'),
('NV010', N'Lý Mai Khuê', '0910000000', 'thik@thtruemart.com',  'CV003', 'PB002', N'Đang làm việc'),
('NV011', N'Võ Tấn Lực', '0911111111', 'vanl@thtruemart.com',  'CV004', 'PB002', N'Đang làm việc'),
('NV012', N'Tô Minh Ngọc', '0912222222', 'thim@thtruemart.com',  'CV004', 'PB002', N'Đang làm việc'),
('NV013', N'Huỳnh Gia Phát', '0913333333', 'vann@thtruemart.com',  'CV009', 'PB003', N'Đang làm việc'),
('NV014', N'Trương Cẩm Oanh', '0914444444', 'thio@thtruemart.com',  'CV004', 'PB002', N'Đang làm việc'),
('NV015', N'Mai Thế Phong', '0915555555', 'vanp@thtruemart.com',  'CV006', 'PB003', N'Đang làm việc'),
('NV016', N'Nguyễn Thanh Quyên', '0916666666', 'thiq@thtruemart.com', 'CV005', 'PB001', N'Đang làm việc'),
('NV017', N'Phan Tấn Tài', '0917777777', 'vanr@thtruemart.com',  'CV002', 'PB001', N'Đang làm việc'),
('NV018', N'Đặng Thanh Xuân', '0918888888', 'this@thtruemart.com',  'CV004', 'PB002', N'Đang làm việc'),
('NV019', N'Đinh Tuấn Tú', '0919999999', 'vant@thtruemart.com',  'CV001', 'PB010', N'Đang làm việc'),
('NV020', N'Lê Thùy Uyên', '0920000000', 'thiu@thtruemart.com',  'CV008', 'PB004', N'Đang làm việc');
GO

-- TAIKHOAN (Cần MANV)
INSERT INTO TAIKHOAN (MATK, TENTK, MANV) VALUES
('TK001', 'admin_a', 'NV001'),
('TK002', 'qlcn_b', 'NV002'),
('TK003', 'ketoan_g', 'NV007'),
('TK004', 'banhang_d', 'NV004'),
('TK005', 'thukho_e', 'NV005'),
('TK006', 'banhang_f', 'NV006'),
('TK007', 'ketoan_q', 'NV016'),
('TK008', 'marketing_h', 'NV008'),
('TK009', 'it_i', 'NV009'),
('TK010', 'truongnhom_k', 'NV010'),
('TK011', 'banhang_l', 'NV011'),
('TK012', 'banhang_m', 'NV012'),
('TK013', 'thukho_n', 'NV013'),
('TK014', 'banhang_o', 'NV014'),
('TK015', 'nhapkh_p', 'NV015'),
('TK016', 'truongphong_r', 'NV017'),
('TK017', 'banhang_s', 'NV018'),
('TK018', 'admin_t', 'NV019'),
('TK019', 'marketing_u', 'NV020'),
('TK020', 'bh_c', 'NV003');
GO

-- KHACHHANG (Cần MA_LOAIKH)
INSERT INTO KHACHHANG (MA_KH, TEN_KH, SDT_KH, EMAIL_KH, DIACHI_KH, MA_LOAIKH) VALUES
('KH001', N'Trần Đình Kha', '0931234567', 'kha@email.com', N'10 Lê Duẩn, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh', 'LKH004'),
('KH002', N'Nguyễn Thị Hồng', '0932345678', 'hong@email.com', N'22 Nguyễn Huệ, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh', 'LKH003'),
('KH003', N'Phạm Văn Quyết', '0933456789', 'quyet@email.com', N'34 Hàng Khay, Phường Tràng Tiền, Quận Hoàn Kiếm, TP. Hà Nội', 'LKH002'),
('KH004', N'Lê Thị Mai', '0934567890', 'mai@email.com', N'46 Nguyễn Chí Thanh, Phường Láng Hạ, Quận Đống Đa, TP. Hà Nội', 'LKH001'),
('KH005', N'Hoàng Anh Tú', '0935678901', 'tu@email.com', N'15 Trần Cao Vân, Phường Xuân Hà, Quận Thanh Khê, TP. Đà Nẵng', 'LKH004'),
('KH006', N'Đỗ Minh Quân', '0936789012', 'quan@email.com', N'25 Lê Lợi, Phường Thạch Thang, Quận Hải Châu, TP. Đà Nẵng', 'LKH003'),
('KH007', N'Vũ Thị Phương', '0937890123', 'phuong@email.com', N'50 Võ Văn Kiệt, Phường An Lạc, Quận Ninh Kiều, TP. Cần Thơ', 'LKH002'),
('KH008', N'Bùi Quang Vinh', '0938901234', 'vinh@email.com', N'66 Phan Đình Phùng, Phường Cầu Trắng, Quận Ninh Kiều, TP. Cần Thơ', 'LKH001'),
('KH009', N'Tống Văn Hùng', '0939012345', 'hung@email.com', N'111 Điện Biên Phủ, Phường Máy Tơ, Quận Ngô Quyền, TP. Hải Phòng', 'LKH004'),
('KH010', N'Nguyễn Thanh Tùng', '0940123456', 'tung@email.com', N'123 Cầu Đất, Phường Cầu Đất, Quận Ngô Quyền, TP. Hải Phòng', 'LKH003'),
('KH011', N'Đặng Văn Trung', '0941234567', 'trung@email.com', N'5 Đại Lộ Bình Dương, Phường Phú Thọ, TP. Thủ Dầu Một, Tỉnh Bình Dương', 'LKH002'),
('KH012', N'Mai Thị Lan', '0942345678', 'lan@email.com', N'100 Phạm Văn Thuận, Phường Tân Mai, TP. Biên Hòa, Tỉnh Đồng Nai', 'LKH001'),
('KH013', N'Phan Đình Phùng', '0943456789', 'phung@email.com', N'20 Trần Phú, Phường Lộc Thọ, TP. Nha Trang, Tỉnh Khánh Hòa', 'LKH004'),
('KH014', N'Trần Văn Long', '0944567890', 'long@email.com', N'35 Nguyễn Tất Thành, Phường Vĩnh Nguyên, TP. Nha Trang, Tỉnh Khánh Hòa', 'LKH003'),
('KH015', N'Ngô Đức Mạnh', '0945678901', 'manh@email.com', N'77 Hùng Vương, Phường Phú Nhuận, TP. Huế, Tỉnh Thừa Thiên Huế', 'LKH002'),
('KH016', N'Lê Hoàng Anh', '0946789012', 'anh@email.com', N'88 Phạm Ngũ Lão, Phường Phú Hội, TP. Huế, Tỉnh Thừa Thiên Huế', 'LKH001'),
('KH017', N'Đinh Tuấn Kiệt', '0947890123', 'kiet@email.com', N'11 Ba Mươi Tháng Tư, Phường 1, TP. Vũng Tàu, Tỉnh Bà Rịa - Vũng Tàu', 'LKH004'),
('KH018', N'Võ Thanh Tú', '0948901234', 'tu_vo@email.com', N'22 Lê Hồng Phong, Phường 4, TP. Vũng Tàu, Tỉnh Bà Rịa - Vũng Tàu', 'LKH003'),
('KH019', N'Trương Công Định', '0949012345', 'dinh@email.com', N'30 Nguyễn Văn Cừ, Phường 1, Quận 5, TP. Hồ Chí Minh', 'LKH002'),
('KH020', N'Hồ Thị Thảo', '0950123456', 'thao@email.com', N'40 Trần Duy Hưng, Phường Trung Hòa, Quận Cầu Giấy, TP. Hà Nội', 'LKH001');
GO

-- THETHANHVIEN (Cần MA_KH)
SET DATEFORMAT dmy;
INSERT INTO THETHANHVIEN (SOTHE, NGAYCAP, DIEM_HT, DIEM_TL_NGAY, DIEM_CK, GHICHU_TTV, NGAY_CN, MA_KH) VALUES
('TTV0000001', '01/01/2023', 5000, 1500, 3500, N'VIP Kim Cương', '30/11/2025', 'KH001'),
('TTV0000002', '10/02/2023', 3500, 1000, 2500, N'Vàng - Sắp lên Kim Cương', '30/11/2025', 'KH002'),
('TTV0000003', '20/03/2023', 2000, 500, 1500, N'Bạc', '29/11/2025', 'KH003'),
('TTV0000004', '01/04/2023', 800, 200, 600, N'Thường', '28/11/2025', 'KH004'),
('TTV0000005', '15/05/2023', 6000, 2000, 4000, N'VIP Kim Cương', '30/11/2025', 'KH005'),
('TTV0000006', '25/06/2023', 3200, 800, 2400, N'Vàng', '29/11/2025', 'KH006'),
('TTV0000007', '07/07/2023', 1500, 300, 1200, N'Bạc', '27/11/2025', 'KH007'),
('TTV0000008', '19/08/2023', 500, 100, 400, N'Thường', '26/11/2025', 'KH008'),
('TTV0000009', '05/09/2023', 5500, 1800, 3700, N'VIP Kim Cương', '30/11/2025', 'KH009'),
('TTV0000010', '18/10/2023', 3800, 1100, 2700, N'Vàng', '29/11/2025', 'KH010'),
('TTV0000011', '01/11/2023', 2100, 600, 1500, N'Bạc', '28/11/2025', 'KH011'),
('TTV0000012', '12/12/2023', 750, 150, 600, N'Thường', '27/11/2025', 'KH012'),
('TTV0000013', '24/01/2024', 4900, 1600, 3300, N'VIP Kim Cương', '30/11/2025', 'KH013'),
('TTV0000014', '05/02/2024', 3000, 900, 2100, N'Vàng', '29/11/2025', 'KH014'),
('TTV0000015', '17/03/2024', 1800, 400, 1400, N'Bạc', '28/11/2025', 'KH015'),
('TTV0000016', '28/04/2024', 650, 120, 530, N'Thường', '26/11/2025', 'KH016'),
('TTV0000017', '10/05/2024', 5200, 1700, 3500, N'VIP Kim Cương', '30/11/2025', 'KH017'),
('TTV0000018', '21/06/2024', 3400, 1000, 2400, N'Vàng', '29/11/2025', 'KH018'),
('TTV0000019', '02/07/2024', 1900, 450, 1450, N'Bạc', '28/11/2025', 'KH019'),
('TTV0000020', '13/08/2024', 850, 180, 670, N'Thường', '27/11/2025', 'KH020');
GO

-- SANPHAM (Cần MA_LOAISP, MADVT, MADVTQD)
SET DATEFORMAT dmy;
INSERT INTO SANPHAM (MASP, MA_LOAISP, MADVT, MADVTQD, TENSP, MOTASP, HINHANH_SP, NXSSP, HSDSP) VALUES
('SP001', 'LSP002', 'DVT001', 'QDVT001', N'Sữa Tươi Tiệt Trùng Nguyên Chất 180ml', N'100% sữa tươi nguyên chất, hộp giấy', 'img/sp001.jpg', '01/01/2025', 180),
('SP002', 'LSP002', 'DVT002', 'QDVT002', N'Sữa Tươi Tiệt Trùng Ít Đường 180ml', N'Ít đường, lốc 4 hộp', 'img/sp002.jpg', '05/01/2025', 180),
('SP003', 'LSP001', 'DVT003', 'QDVT003', N'Sữa Tươi Thanh Trùng Nguyên Chất 950ml', N'Sữa tươi thanh trùng, chai nhựa', 'img/sp003.jpg', '10/01/2025', 14),
('SP004', 'LSP003', 'DVT004', 'QDVT004', N'Sữa Chua Ăn Có Đường 100g', N'Sữa chua ăn lên men tự nhiên', 'img/sp004.jpg', '15/01/2025', 45),
('SP005', 'LSP004', 'DVT003', 'QDVT003', N'Nước Suối Tinh Khiết 500ml', N'Nước uống tinh khiết', 'img/sp005.jpg', '20/01/2025', 730),
('SP006', 'LSP003', 'DVT004', 'QDVT010', N'Kem Ly Socola 110ml', N'Kem ly vị Socola', 'img/sp006.jpg', '25/01/2025', 365),
('SP007', 'LSP002', 'DVT001', 'QDVT001', N'Sữa Tươi Tiệt Trùng Hương Dâu 180ml', N'Hương dâu tự nhiên', 'img/sp007.jpg', '01/02/2025', 180),
('SP008', 'LSP001', 'DVT003', 'QDVT003', N'Sữa Tươi Thanh Trùng Vị Dâu 450ml', N'Thanh trùng vị dâu', 'img/sp008.jpg', '05/02/2025', 14),
('SP009', 'LSP005', 'DVT006', 'QDVT006', N'Phô Mai Mozzarella 500g', N'Phô mai sợi, gói 500g', 'img/sp009.jpg', '10/02/2025', 90),
('SP010', 'LSP005', 'DVT005', 'QDVT005', N'Bơ Lạt 250g', N'Bơ lạt tự nhiên, gói', 'img/sp010.jpg', '15/02/2025', 60),
('SP011', 'LSP002', 'DVT001', 'QDVT001', N'Sữa Tươi Tiệt Trùng Có Đường 1L', N'100% sữa tươi, hộp 1L', 'img/sp011.jpg', '20/02/2025', 180),
('SP012', 'LSP004', 'DVT003', 'QDVT003', N'Trà Xanh Không Đường 500ml', N'Trà xanh đóng chai', 'img/sp012.jpg', '25/02/2025', 365),
('SP013', 'LSP003', 'DVT004', 'QDVT004', N'Sữa Chua Uống Hương Cam 180ml', N'Sữa chua uống, hộp', 'img/sp013.jpg', '01/03/2025', 90),
('SP014', 'LSP008', 'DVT005', 'QDVT005', N'Bánh Quy Bơ 300g', N'Bánh quy vị bơ', 'img/sp014.jpg', '05/03/2025', 365),
('SP015', 'LSP007', 'DVT003', 'QDVT003', N'Nước Khoáng Có Ga 330ml', N'Nước khoáng tự nhiên', 'img/sp015.jpg', '10/03/2025', 730),
('SP016', 'LSP002', 'DVT002', 'QDVT002', N'Sữa Tươi Tiệt Trùng Socola 180ml', N'Lốc 4 hộp vị Socola', 'img/sp016.jpg', '15/03/2025', 180),
('SP017', 'LSP001', 'DVT003', 'QDVT003', N'Sữa Tươi Thanh Trùng Hữu Cơ 950ml', N'Hữu cơ, chai', 'img/sp017.jpg', '20/03/2025', 14),
('SP018', 'LSP003', 'DVT004', 'QDVT004', N'Sữa Chua Ăn Nha Đam 100g', N'Sữa chua nha đam', 'img/sp018.jpg', '25/03/2025', 45),
('SP019', 'LSP004', 'DVT003', 'QDVT003', N'Nước Ép Trái Cây Hỗn Hợp 1L', N'Nước ép tự nhiên', 'img/sp019.jpg', '01/04/2025', 180),
('SP020', 'LSP006', 'DVT006', 'QDVT006', N'Váng Sữa Vị Vanilla 50g', N'Sản phẩm từ sữa', 'img/sp020.jpg', '05/04/2025', 60);
GO

-- BIENDONGGIA (Cần MASP)
SET DATEFORMAT dmy;
INSERT INTO BIENDONGGIA (MASP, NGAYCAPNHAT_BDG, GIABAN) VALUES
('SP001', '01/01/2025', 380000.00), -- Giá thùng
('SP002', '05/01/2025', 35000.00), -- Giá lốc
('SP003', '10/01/2025', 42000.00), -- Giá chai
('SP004', '15/01/2025', 6000.00), -- Giá hộp
('SP005', '20/01/2025', 8000.00), -- Giá chai
('SP006', '25/01/2025', 15000.00), -- Giá hộp
('SP007', '01/02/2025', 390000.00), -- Giá thùng
('SP008', '05/02/2025', 25000.00), -- Giá chai
('SP009', '10/02/2025', 95000.00), -- Giá kg (500g)
('SP010', '15/02/2025', 48000.00), -- Giá gói
('SP011', '20/02/2025', 45000.00), -- Giá hộp 1L
('SP012', '25/02/2025', 10000.00), -- Giá chai
('SP013', '01/03/2025', 8500.00), -- Giá hộp
('SP014', '05/03/2025', 75000.00), -- Giá gói
('SP015', '10/03/2025', 12000.00), -- Giá chai
('SP016', '15/03/2025', 36000.00), -- Giá lốc
('SP017', '20/03/2025', 48000.00), -- Giá chai
('SP018', '25/03/2025', 6500.00), -- Giá hộp
('SP019', '01/04/2025', 30000.00), -- Giá chai
('SP020', '05/04/2025', 11000.00), -- Giá gói
('SP001', '01/07/2025', 375000.00), -- Cập nhật giá SP001
('SP004', '15/07/2025', 5500.00), -- Cập nhật giá SP004
('SP011', '20/08/2025', 44000.00), -- Cập nhật giá SP011
('SP017', '20/09/2025', 47500.00); -- Cập nhật giá SP017
GO

-- CHUONGTRINHKHUYENMAI
SET DATEFORMAT dmy;
INSERT INTO CHUONGTRINHKHUYENMAI (MA_CTKM, TEN_CTKM, NGAYBDCTKM, NGAYKTCTKM, LYDOCTKM) VALUES
('KM001', N'Khuyến Mãi Lễ Tình Nhân', '01/02/2025', '14/02/2025', N'Giảm giá các sản phẩm sữa chua, kem'),
('KM002', N'Đón Xuân Giáp Thìn', '01/01/2025', '28/02/2025', N'Giảm giá tất cả sản phẩm Sữa Tươi'),
('KM003', N'Mùa Hè Sôi Động', '01/05/2025', '30/06/2025', N'Giảm giá các loại nước giải khát, nước suối'),
('KM004', N'Ngày Hội Thành Viên', '15/08/2025', '30/08/2025', N'Giảm thêm cho khách hàng thành viên'),
('KM005', N'Giảm Giá Cuối Năm', '01/11/2025', '31/12/2025', N'Ưu đãi lớn cho sản phẩm phô mai, bơ'),
('KM006', N'Sữa Chua Cho Bé', '01/03/2025', '31/03/2025', N'Khuyến mãi sữa chua uống, sữa chua ăn'),
('KM007', N'Black Friday Sale', '25/11/2025', '27/11/2025', N'Siêu giảm giá 20%'),
('KM008', N'Tri Ân Khách Hàng', '01/10/2025', '31/10/2025', N'Ưu đãi đặc biệt cho KH có thẻ TV'),
('KM009', N'Giảm Giá 50%', '01/07/2025', '07/07/2025', N'Áp dụng cho một số sản phẩm tồn kho'),
('KM010', N'Khai Trương Chi Nhánh Mới', '01/09/2025', '15/09/2025', N'Giảm 10% tại CN001, CN002'),
('KM011', N'Ưu Đãi Đặc Biệt', '01/04/2025', '30/04/2025', N'Giảm giá chung 5%'),
('KM012', N'Mừng Quốc Khánh', '01/09/2025', '03/09/2025', N'Giảm 15% tất cả mặt hàng'),
('KM013', N'Thứ 6 Vui Vẻ', '01/06/2025', '30/06/2025', N'Giảm 10% vào mỗi thứ 6'),
('KM014', N'Đồng Giá Sản Phẩm', '10/05/2025', '15/05/2025', N'Đồng giá 50,000VND'),
('KM015', N'Online Booking Ưu Đãi', '01/01/2025', '31/12/2025', N'Giảm 5% khi đặt hàng qua app'),
('KM016', N'Combo Sữa Và Bánh', '01/01/2025', '31/01/2025', N'Combo SP001 và SP014'),
('KM017', N'Mua 2 Tặng 1', '01/10/2025', '15/10/2025', N'Áp dụng cho SP003'),
('KM018', N'Chi Nhánh 1 Ưu Đãi', '01/01/2025', '31/12/2025', N'Giảm 7% tại CN001'),
('KM019', N'Sữa Tươi Thảo Mộc', '01/08/2025', '31/08/2025', N'Giảm 10% cho dòng sản phẩm hữu cơ'),
('KM020', N'Thanh Toán Ví Điện Tử', '01/01/2025', '31/12/2025', N'Giảm 5% khi thanh toán bằng ví');
GO

-- CT_CTKM (Cần MASP, MA_CTKM)
INSERT INTO CT_CTKM (MASP, MA_CTKM, PHAMTRAMGIAM, GHICHU) VALUES
('SP004', 'KM001', 0.15, N'Giảm 15% sữa chua ăn'),
('SP006', 'KM001', 0.10, N'Giảm 10% kem ly'),
('SP001', 'KM002', 0.10, N'Giảm 10% sữa tươi'),
('SP007', 'KM002', 0.10, N'Giảm 10% sữa tươi vị dâu'),
('SP011', 'KM002', 0.10, N'Giảm 10% sữa tươi 1L'),
('SP005', 'KM003', 0.05, N'Giảm 5% nước suối'),
('SP012', 'KM003', 0.05, N'Giảm 5% trà xanh'),
('SP015', 'KM003', 0.05, N'Giảm 5% nước khoáng'),
('SP001', 'KM004', 0.05, N'Giảm thêm cho TV'), -- KM dành cho TV
('SP002', 'KM004', 0.05, N'Giảm thêm cho TV'),
('SP009', 'KM005', 0.10, N'Giảm 10% phô mai'),
('SP010', 'KM005', 0.10, N'Giảm 10% bơ lạt'),
('SP013', 'KM006', 0.15, N'Giảm 15% sữa chua uống'),
('SP004', 'KM006', 0.15, N'Giảm 15% sữa chua ăn'),
('SP001', 'KM007', 0.20, N'Black Friday Sale'),
('SP017', 'KM007', 0.20, N'Black Friday Sale'),
('SP003', 'KM008', 0.05, N'Tri ân khách hàng'),
('SP008', 'KM008', 0.05, N'Tri ân khách hàng'),
('SP014', 'KM005', 0.05, N'Giảm 5% bánh quy'),
('SP019', 'KM003', 0.10, N'Giảm 10% nước ép');
GO

SET DATEFORMAT dmy;
INSERT INTO TONKHO ( MA_KHO, MASP, NGAYCN_TK, THANGTK, NAMTK, TONDK, TRIGIATONDK, NHAPTK, TRIGIANHAPTK, 
XUATTK, TRIGIAXUATTK, TONCK, TRIGIATONCK ) VALUES
('KHO001','SP001','30/11/2025',11,2025, 100, 1000000, 150, 1500000, 120, 1200000, 130, 1300000),
('KHO001','SP002','30/11/2025',11,2025,  80,  800000, 120, 1200000,  90,  900000, 110, 1100000),
('KHO002','SP003','30/11/2025',11,2025,  60,  600000,  90,  900000,  50,  500000, 100, 1000000),
('KHO002','SP004','30/11/2025',11,2025,  50,  500000,  80,  800000,  40,  400000,  90,  900000),
('KHO003','SP005','30/11/2025',11,2025,  40,  400000, 100, 1000000,  60,  600000,  80,  800000),
('KHO003','SP006','30/11/2025',11,2025,  70,  700000, 120, 1200000,  90,  900000, 100, 1000000),
('KHO004','SP007','30/11/2025',11,2025,  30,  300000,  70,  700000,  40,  400000,  60,  600000),
('KHO004','SP008','30/11/2025',11,2025,  90,  900000, 110, 1100000,  70,  700000, 130, 1300000),
('KHO005','SP009','30/11/2025',11,2025, 100, 1000000, 200, 2000000, 150, 1500000, 150, 1500000),
('KHO005','SP010','30/11/2025',11,2025,  50,  500000,  60,  600000,  30,  300000,  80,  800000),
('KHO006','SP011','30/11/2025',11,2025, 120, 1200000, 100, 1000000,  90,  900000, 130, 1300000),
('KHO006','SP012','30/11/2025',11,2025,  40,  400000,  90,  900000,  60,  600000,  70,  700000),
('KHO007','SP013','30/11/2025',11,2025,  60,  600000,  60,  600000,  40,  400000,  80,  800000),
('KHO007','SP014','30/11/2025',11,2025,  80,  800000,  40,  400000,  30,  300000,  90,  900000),
('KHO008','SP015','30/11/2025',11,2025, 100, 1000000,  50,  500000,  40,  400000, 110, 1100000),
('KHO008','SP016','30/11/2025',11,2025,  70,  700000,  80,  800000,  50,  500000, 100, 1000000),
('KHO009','SP017','30/11/2025',11,2025,  90,  900000,  70,  700000,  40,  400000, 120, 1200000),
('KHO009','SP018','30/11/2025',11,2025,  85,  850000,  60,  600000,  45,  450000, 100, 1000000),
('KHO010','SP019','30/11/2025',11,2025, 110, 1100000,  90,  900000,  70,  700000, 130, 1300000),
('KHO010','SP020','30/11/2025',11,2025,  95,  950000,  80,  800000,  55,  550000, 120, 1200000);
GO

-- NGANHANG (Cần MA_KH)
INSERT INTO NGANHANG (MA_NH, TEN_NH, SDT_NH, DIACHI_NH, CHINHANH_NH, MA_KH) VALUES
('NH001', N'Vietcombank', '1900545413', N'123 Nguyễn Văn Cừ, Quận 5', N'Chi nhánh TP. HCM', 'KH001'),
('NH002', N'Techcombank', '1800588822', N'100 Láng Hạ, Quận Đống Đa', N'Chi nhánh Hà Nội', 'KH003'),
('NH003', N'Agribank', '1900570077', N'22 Nguyễn Huệ, Quận 1', N'Chi nhánh TP. HCM', 'KH002'),
('NH004', N'BIDV', '190092923', N'34 Hàng Khay, Quận Hoàn Kiếm', N'Chi nhánh Hà Nội', 'KH004'),
('NH005', N'VietinBank', '1900558868', N'15 Trần Cao Vân, Quận Thanh Khê', N'Chi nhánh Đà Nẵng', 'KH005'),
('NH006', N'VPBank', '1900545415', N'50 Võ Văn Kiệt, Quận Ninh Kiều', N'Chi nhánh Cần Thơ', 'KH007'),
('NH007', N'Sacombank', '1900555588', N'111 Điện Biên Phủ, Quận Ngô Quyền', N'Chi nhánh Hải Phòng', 'KH009'),
('NH008', N'MB Bank', '1900545426', N'20 Trần Phú, TP. Nha Trang', N'Chi nhánh Nha Trang', 'KH013'),
('NH009', N'ACB', '1900545486', N'77 Hùng Vương, TP. Huế', N'Chi nhánh Huế', 'KH015'),
('NH010', N'Shinhan Bank', '1900969636', N'11 Ba Mươi Tháng Tư, TP. Vũng Tàu', N'Chi nhánh Vũng Tàu', 'KH017');
GO

-- DONHANG (Cần MA_KH, MANV)
SET DATEFORMAT dmy;
INSERT INTO DONHANG (MA_DH, NGAYLAP_DH, THANHTIEN_DH, HINHTHUCTT_DH, MA_KH, MANV) VALUES
('DH001', '01/10/2025', 1050000.00, N'Chuyển khoản', 'KH001', 'NV004'),
('DH002', '05/10/2025', 550000.00, N'Thanh toán khi nhận hàng', 'KH002', 'NV006'),
('DH003', '10/10/2025', 200000.00, N'Ví điện tử', 'KH003', 'NV011'),
('DH004', '15/10/2025', 800000.00, N'Chuyển khoản', 'KH005', 'NV012'),
('DH005', '20/10/2025', 120000.00, N'Thanh toán khi nhận hàng', 'KH007', 'NV014'),
('DH006', '25/10/2025', 350000.00, N'Ví điện tử', 'KH009', 'NV017'),
('DH007', '01/11/2025', 90000.00, N'Chuyển khoản', 'KH011', 'NV004'),
('DH008', '05/11/2025', 420000.00, N'Thanh toán khi nhận hàng', 'KH013', 'NV006'),
('DH009', '10/11/2025', 280000.00, N'Ví điện tử', 'KH015', 'NV011'),
('DH010', '15/11/2025', 650000.00, N'Chuyển khoản', 'KH017', 'NV012');
GO

-- CT_DH (Cần MA_DH, MASP)
INSERT INTO CT_DH (MA_DH, MASP, SOLUONG_DH, DONGIA_DH, GIAMGIA_DH, GHICHU_DH) VALUES
('DH001', 'SP001', 2, 375000.00, 75000.00, N'KM mua 2 giảm 10%'),
('DH001', 'SP009', 3, 95000.00, 0.00, NULL),
('DH002', 'SP002', 10, 35000.00, 0.00, N'Mua sỉ'),
('DH002', 'SP014', 2, 75000.00, 0.00, NULL),
('DH003', 'SP004', 10, 5500.00, 0.00, NULL),
('DH003', 'SP013', 15, 8500.00, 0.00, NULL),
('DH004', 'SP011', 15, 44000.00, 0.00, NULL),
('DH004', 'SP019', 2, 30000.00, 0.00, NULL),
('DH005', 'SP005', 10, 8000.00, 0.00, NULL),
('DH005', 'SP006', 4, 10000.00, 0.00, NULL),
('DH006', 'SP016', 8, 36000.00, 38000.00, N'Có KM'),
('DH006', 'SP010', 1, 48000.00, 0.00, NULL),
('DH007', 'SP004', 10, 5500.00, 0.00, NULL),
('DH007', 'SP018', 5, 6500.00, 0.00, NULL),
('DH008', 'SP007', 10, 390000.00, 300000.00, N'KM đặc biệt'),
('DH008', 'SP017', 2, 47500.00, 0.00, NULL),
('DH009', 'SP009', 2, 95000.00, 10000.00, N'Giảm giá phô mai'),
('DH010', 'SP001', 1, 375000.00, 0.00, NULL),
('DH010', 'SP003', 6, 42000.00, 0.00, NULL);
GO

-- PHIEUNHAP (Cần MA_NCC, MANV)
SET DATEFORMAT dmy;
INSERT INTO PHIEUNHAP (SO_PN, NGAYNHAP, LYDONHAP, TRIGIA_PN, GHICHU_PN, MA_NCC, MANV) VALUES
('PN001', '01/05/2025', N'Nhập hàng định kỳ Quý 2', 50000000.00, N'Đã kiểm tra chất lượng', 'NCC001', 'NV007'),
('PN002', '10/05/2025', N'Nhập bổ sung sản phẩm mới', 12000000.00, NULL, 'NCC002', 'NV016'),
('PN003', '20/05/2025', N'Nhập hàng nước giải khát', 8000000.00, N'Hàng tươi, nhập số lượng lớn', 'NCC003', 'NV007'),
('PN004', '01/06/2025', N'Nhập hàng tháng 6', 35000000.00, NULL, 'NCC001', 'NV016'),
('PN005', '15/06/2025', N'Nhập bánh kẹo phục vụ hè', 5000000.00, N'Hàng nhập từ kho khu vực', 'NCC006', 'NV007'),
('PN006', '01/07/2025', N'Nhập hàng sữa tươi', 45000000.00, N'Đã ký hợp đồng mới', 'NCC001', 'NV016'),
('PN007', '10/07/2025', N'Nhập hàng từ NCC009', 15000000.00, NULL, 'NCC009', 'NV007'),
('PN008', '01/08/2025', N'Nhập hàng phục vụ KM', 20000000.00, N'Chuẩn bị cho KM tháng 9', 'NCC001', 'NV016'),
('PN009', '15/08/2025', N'Nhập hàng nông sản', 3000000.00, NULL, 'NCC004', 'NV007'),
('PN010', '01/09/2025', N'Nhập hàng bổ sung', 28000000.00, N'Hàng về muộn 1 ngày', 'NCC001', 'NV016');
GO

-- CT_PHIEUNHAP (Cần SO_PN, MASP)
INSERT INTO CT_PHIEUNHAP (SO_PN, MASP, SOLUONGNHAP, DONGIA_PN, THANHTIEN_PN) VALUES
('PN001', 'SP001', 100, 360000.00, 36000000.00), -- 100 thùng SP001
('PN001', 'SP004', 1000, 5000.00, 5000000.00), -- 1000 hộp SP004
('PN001', 'SP011', 200, 42000.00, 8400000.00), -- 200 hộp SP011
('PN002', 'SP009', 50, 85000.00, 4250000.00), -- 50kg SP009
('PN002', 'SP010', 100, 45000.00, 4500000.00), -- 100 gói SP010
('PN002', 'SP020', 300, 10000.00, 3000000.00), -- 300 gói SP020
('PN003', 'SP005', 500, 7000.00, 3500000.00), -- 500 chai SP005
('PN003', 'SP012', 300, 9000.00, 2700000.00), -- 300 chai SP012
('PN003', 'SP019', 60, 20000.00, 1800000.00), -- 60 chai SP019
('PN004', 'SP002', 100, 33000.00, 3300000.00), -- 100 lốc SP002
('PN004', 'SP007', 50, 370000.00, 18500000.00), -- 50 thùng SP007
('PN004', 'SP016', 150, 34000.00, 5100000.00), -- 150 lốc SP016
('PN005', 'SP014', 100, 70000.00, 7000000.00), -- 100 gói SP014
('PN006', 'SP001', 80, 365000.00, 29200000.00), -- 80 thùng SP001
('PN006', 'SP003', 100, 40000.00, 4000000.00), -- 100 chai SP003
('PN006', 'SP017', 50, 45000.00, 2250000.00), -- 50 chai SP017
('PN007', 'SP018', 500, 6000.00, 3000000.00), -- 500 hộp SP018
('PN008', 'SP004', 2000, 5000.00, 10000000.00), -- 2000 hộp SP004
('PN009', 'SP015', 500, 10000.00, 5000000.00), -- 500 chai SP015
('PN010', 'SP013', 300, 8000.00, 2400000.00); -- 300 hộp SP013
GO

-- PHIEUXUAT (Cần MA_KHO, MANV)
SET DATEFORMAT dmy;
INSERT INTO PHIEUXUAT (MA_PX, NGAYXUAT, LYDOXUAT, TRIGIA_PX, DIADIEMGH, GHICHU_PX, MA_KHO, MANV) VALUES
('PX001', '01/11/2025', N'Xuất bán hàng cho KH', 1000000.00, N'10 Lê Duẩn, Q1, TP. HCM', NULL, 'KHO001', 'NV004'),
('PX002', '05/11/2025', N'Xuất bán hàng cho KH', 500000.00, N'22 Nguyễn Huệ, Q1, TP. HCM', N'Giao hàng nhanh', 'KHO001', 'NV006'),
('PX003', '10/11/2025', N'Xuất hàng cho Chi nhánh CN002', 2000000.00, N'CN002 - Hà Nội', NULL, 'KHO002', 'NV011'),
('PX004', '15/11/2025', N'Xuất bán hàng cho KH', 750000.00, N'15 Trần Cao Vân, Đà Nẵng', N'Giao hàng trong giờ hành chính', 'KHO003', 'NV012'),
('PX005', '20/11/2025', N'Xuất chuyển kho nội bộ', 3000000.00, N'KHO005 - Thủ Đức', NULL, 'KHO001', 'NV014'),
('PX006', '22/11/2025', N'Xuất bán hàng cho KH', 320000.00, N'111 Điện Biên Phủ, Hải Phòng', NULL, 'KHO008', 'NV017'),
('PX007', '24/11/2025', N'Xuất hàng lẻ', 90000.00, N'5 Đại Lộ Bình Dương, Bình Dương', NULL, 'KHO006', 'NV004'),
('PX008', '26/11/2025', N'Xuất bán hàng Online', 400000.00, N'20 Trần Phú, Nha Trang', N'Đơn hàng gấp', 'KHO008', 'NV006'),
('PX009', '28/11/2025', N'Xuất hàng cho đại lý', 250000.00, N'77 Hùng Vương, TP. Huế', NULL, 'KHO009', 'NV011'),
('PX010', '30/11/2025', N'Xuất bán hàng trực tiếp', 600000.00, N'11 Ba Mươi Tháng Tư, Vũng Tàu', NULL, 'KHO009', 'NV012');
GO

-- CT_PHIEUXUAT (Cần MA_PX, MASP)
INSERT INTO CT_PHIEUXUAT (MA_PX, MASP, SOLUONGXUAT, DONGIA_PX, THANHTIEN_PX) VALUES
('PX001', 'SP001', 2, 375000.00, 750000.00), -- 2 Thùng SP001
('PX001', 'SP009', 3, 95000.00, 285000.00), -- 3 Kg SP009
('PX002', 'SP002', 10, 35000.00, 350000.00), -- 10 Lốc SP002
('PX002', 'SP014', 2, 75000.00, 150000.00), -- 2 Gói SP014
('PX003', 'SP011', 20, 44000.00, 880000.00), -- 20 Hộp SP011 (xuất kho nội bộ)
('PX003', 'SP007', 3, 390000.00, 1170000.00), -- 3 Thùng SP007 (xuất kho nội bộ)
('PX004', 'SP004', 10, 5500.00, 55000.00), -- 10 Hộp SP004
('PX004', 'SP013', 15, 8500.00, 127500.00), -- 15 Hộp SP013
('PX004', 'SP019', 10, 30000.00, 300000.00), -- 10 Chai SP019
('PX005', 'SP001', 5, 375000.00, 1875000.00), -- 5 Thùng SP001 (chuyển kho)
('PX005', 'SP002', 10, 35000.00, 350000.00), -- 10 Lốc SP002 (chuyển kho)
('PX006', 'SP016', 8, 36000.00, 288000.00), -- 8 Lốc SP016
('PX006', 'SP010', 1, 48000.00, 48000.00), -- 1 Gói SP010
('PX007', 'SP004', 10, 5500.00, 55000.00), -- 10 Hộp SP004
('PX007', 'SP018', 5, 6500.00, 32500.00), -- 5 Hộp SP018
('PX008', 'SP007', 1, 390000.00, 390000.00), -- 1 Thùng SP007
('PX008', 'SP017', 2, 47500.00, 95000.00), -- 2 Chai SP017
('PX009', 'SP009', 2, 95000.00, 190000.00), -- 2 Kg SP009
('PX010', 'SP001', 1, 375000.00, 375000.00), -- 1 Thùng SP001
('PX010', 'SP003', 6, 42000.00, 252000.00); -- 6 Chai SP003
GO

-- HOADON (Cần MA_KH, MA_LOAIHD, MA_PX)
SET DATEFORMAT dmy;
INSERT INTO HOADON (MA_HD, NGAYLAPHD, HINHTHUCTT, THUEVAT, TRIGIATRUOCTHUE, TRIGIASAUTHUE, TONGTIENGIAM, TONGCONGTHANHTIEN, GHICHU_HD, MA_KH, MA_LOAIHD, MA_PX) VALUES
('HD001', '01/11/2025', N'Thẻ Tín Dụng', 0.10, 1035000.00, 1138500.00, 35000.00, 1103500.00, N'Bán lẻ, áp dụng KM', 'KH001', 'LHD001', 'PX001'),
('HD002', '05/11/2025', N'Tiền Mặt', 0.10, 500000.00, 550000.00, 0.00, 550000.00, N'Bán lẻ, không KM', 'KH002', 'LHD001', 'PX002'),
('HD003', '15/11/2025', N'Chuyển Khoản', 0.00, 482500.00, 482500.00, 0.00, 482500.00, N'Bán lẻ', 'KH005', 'LHD001', 'PX004'),
('HD004', '22/11/2025', N'Ví Điện Tử', 0.10, 336000.00, 369600.00, 56000.00, 313600.00, N'Bán lẻ, có KM', 'KH009', 'LHD001', 'PX006'),
('HD005', '26/11/2025', N'Tiền Mặt', 0.10, 485000.00, 533500.00, 0.00, 533500.00, N'Bán lẻ', 'KH013', 'LHD001', 'PX008'),
('HD006', '30/11/2025', N'Chuyển Khoản', 0.10, 627000.00, 689700.00, 5000.00, 684700.00, N'Bán lẻ', 'KH017', 'LHD001', 'PX010'),
('HD007', '01/11/2025', N'Tiền Mặt', 0.00, 90000.00, 90000.00, 0.00, 90000.00, N'Online - đơn hàng DH007', 'KH011', 'LHD009', 'PX007'),
('HD008', '10/11/2025', N'Tiền Mặt', 0.00, 270000.00, 270000.00, 0.00, 270000.00, N'Online - đơn hàng DH009', 'KH015', 'LHD009', 'PX009'),
('HD009', '01/11/2025', N'Đổi Trả Khách Hàng', 0.10, 100000.00, 110000.00, 0.00, 110000.00, N'Hóa đơn cho hàng đổi trả', 'KH002', 'LHD005', 'PX005'),
('HD010', '01/11/2025', N'Xuất Kho Nội Bộ', 0.00, 2050000.00, 2050000.00, 0.00, 2050000.00, N'Hóa đơn xuất kho nội bộ CN002', 'KH004', 'LHD002', 'PX003');
GO

-- CT_HD (Cần MA_HD, MASP)
INSERT INTO CT_HD (MA_HD, MASP, SOLUONG_TRA, DONGIA_HD, PHANTRAMGIAMHD, GIASAUGIAM, THANHTIENHD) VALUES
('HD001', 'SP001', 2, 375000.00, 0.05, 356250.00, 712500.00), -- 2 thùng
('HD001', 'SP009', 3, 95000.00, 0.00, 95000.00, 285000.00), -- 3 kg
('HD002', 'SP002', 10, 35000.00, 0.00, 35000.00, 350000.00), -- 10 lốc
('HD002', 'SP014', 2, 75000.00, 0.00, 75000.00, 150000.00), -- 2 gói
('HD003', 'SP004', 10, 5500.00, 0.00, 5500.00, 55000.00), -- 10 hộp
('HD003', 'SP013', 15, 8500.00, 0.00, 8500.00, 127500.00), -- 15 hộp
('HD003', 'SP019', 10, 30000.00, 0.00, 30000.00, 300000.00), -- 10 chai
('HD004', 'SP016', 8, 36000.00, 0.15, 30600.00, 244800.00), -- 8 lốc
('HD004', 'SP010', 1, 48000.00, 0.00, 48000.00, 48000.00), -- 1 gói
('HD005', 'SP007', 1, 390000.00, 0.00, 390000.00, 390000.00), -- 1 thùng
('HD005', 'SP017', 2, 47500.00, 0.00, 47500.00, 95000.00), -- 2 chai
('HD006', 'SP001', 1, 375000.00, 0.00, 375000.00, 375000.00), -- 1 thùng
('HD006', 'SP003', 6, 42000.00, 0.05, 39900.00, 239400.00), -- 6 chai
('HD007', 'SP004', 10, 5500.00, 0.00, 5500.00, 55000.00), -- 10 hộp
('HD007', 'SP018', 5, 6500.00, 0.00, 6500.00, 32500.00), -- 5 hộp
('HD008', 'SP009', 2, 95000.00, 0.00, 95000.00, 190000.00), -- 2 kg
('HD010', 'SP011', 20, 44000.00, 0.00, 44000.00, 880000.00), -- 20 hộp
('HD010', 'SP007', 3, 390000.00, 0.00, 390000.00, 1170000.00); -- 3 thùng
GO



-- PHIEUTRAHANG (Cần MA_KH, MA_NCC, MANV)
SET DATEFORMAT dmy;
INSERT INTO PHIEUTRAHANG (MA_PTH, NGAYTRA, LYDOTRA, TONGTIENHOAN, TRANGTHAI_TRAHANG, PHUONGTHUCHOAN, GHICHU_TRAHANG, MA_KH, MA_NCC, MANV) VALUES
('PTH001', '02/11/2025', N'Sản phẩm bị lỗi, đổi trả', 110000.00, N'Đã hoàn tiền', N'Tiền mặt', NULL, 'KH002', 'NCC001', 'NV004'),
('PTH002', '12/11/2025', N'Khách hàng không lấy hàng', 55000.00, N'Chờ hoàn tiền', N'Chuyển khoản', N'Hàng còn nguyên vẹn', 'KH003', 'NCC001', 'NV006'),
('PTH003', '24/11/2025', N'Trả hàng cho nhà cung cấp', 1875000.00, N'Đã xuất kho trả NCC', N'Cấn trừ công nợ', NULL, 'KH001', 'NCC001', 'NV007');
GO

-- CT_PHIEUTRAHANG (Cần MA_PTH, MA_HD)
INSERT INTO CT_PHIEUTRAHANG (MA_PTH, MA_HD, SOLUONG_TRA, DONGIA_TRA, THANHTIEN_TRA) VALUES
('PTH001', 'HD002', 1, 110000.00, 110000.00), 
('PTH002', 'HD003', 1, 55000.00, 55000.00), 
('PTH003', 'HD001', 5, 375000.00, 1875000.00); 
GO

-- PHANQUYEN (Cần MAVT, MAQUYEN, MA_DT)
SET DATEFORMAT dmy;
INSERT INTO PHANQUYEN (MAVT, MAQUYEN, MA_DT, NGAY_PQ, NGUOICAP, TRANGTHAI_PQ) VALUES
('VT001', 'Q001', 'DT001', '01/01/2025', N'System Admin', N'Hoạt động'),
('VT001', 'Q004', 'DT001', '01/01/2025', N'System Admin', N'Hoạt động'),
('VT002', 'Q002', 'DT005', '01/01/2025', N'System Admin', N'Hoạt động'),
('VT002', 'Q007', 'DT005', '01/01/2025', N'System Admin', N'Hoạt động'),
('VT003', 'Q002', 'DT005', '01/01/2025', N'System Admin', N'Hoạt động'),
('VT004', 'Q007', 'DT005', '01/01/2025', N'System Admin', N'Hoạt động'),
('VT005', 'Q005', 'DT003', '01/01/2025', N'System Admin', N'Hoạt động'),
('VT005', 'Q006', 'DT004', '01/01/2025', N'System Admin', N'Hoạt động'),
('VT006', 'Q009', 'DT009', '01/01/2025', N'System Admin', N'Hoạt động'),
('VT007', 'Q010', 'DT005', '01/01/2025', N'System Admin', N'Hoạt động');
GO

---------------------------------------------------------------------------------
--SYSNONYM
USE SQL_THTRUEMART; -- Đảm bảo bạn đang ở đúng cơ sở dữ liệu
GO

SELECT
    name AS TenSynonym,
    base_object_name AS DoiTuongGoc,
    create_date AS NgayTao
FROM sys.synonyms
ORDER BY name;
GO

-- 1. Tạo Synonym cho bảng KHACHHANG
CREATE SYNONYM KH FOR KHACHHANG;
GO

-- 2. Tạo Synonym cho bảng NHANVIEN
CREATE SYNONYM NV FOR NHANVIEN;
GO

-- 3. Tạo Synonym cho bảng SANPHAM
CREATE SYNONYM SP FOR SANPHAM;
GO

-- 4. Tạo Synonym cho bảng HOADON
CREATE SYNONYM HD FOR HOADON;
GO

-- 5. Tạo Synonym cho bảng CT_PHIEUNHAP
CREATE SYNONYM CTPN FOR CT_PHIEUNHAP;
GO

-- Kiểm thử Minh Họa 1:
SELECT
    T1.TEN_KH,
    T1.EMAIL_KH,
    T2.TEN_LOAIKH
FROM KH T1 -- Thay thế KHACHHANG
JOIN LOAIKH T2 ON T1.MA_LOAIKH = T2.MA_LOAIKH
WHERE T2.TEN_LOAIKH LIKE N'%Kim Cương%';

-- Kiểm thử Minh Họa 2:
SELECT
    T2.TENNV,
    T3.MASP,
    T3.SOLUONGNHAP,
    T3.DONGIA_PN
FROM PHIEUNHAP T1
JOIN NV T2 ON T1.MANV = T2.MANV     -- Thay thế NHANVIEN
JOIN CTPN T3 ON T1.SO_PN = T3.SO_PN -- Thay thế CT_PHIEUNHAP
WHERE T1.SO_PN = 'PN001';

-- Kiểm thử Minh Họa 3:
SELECT
    T2.TENSP,
    T1.SOLUONG_TRA AS SoLuongBan,
    T1.THANHTIENHD
FROM CT_HD T1
JOIN SP T2 ON T1.MASP = T2.MASP -- Thay thế SANPHAM
WHERE T1.MA_HD = 'HD001';

-- Kiểm thử Minh Họa 4:
SELECT
    MA_HD,
    NGAYLAPHD,
    TONGTIENGIAM,
    TONGCONGTHANHTIEN
FROM HD -- Thay thế HOADON
WHERE TONGTIENGIAM > 50000.00;

-- Kiểm thử Minh Họa 5:
SELECT
    T1.TEN_CTKM,
    T2.PHAMTRAMGIAM,
    T3.TENSP
FROM CHUONGTRINHKHUYENMAI T1
JOIN CT_CTKM T2 ON T1.MA_CTKM = T2.MA_CTKM
JOIN SP T3 ON T2.MASP = T3.MASP -- Thay thế SANPHAM
WHERE T2.PHAMTRAMGIAM >= 0.15;

----------------------------------------------------------
--INDEX
USE SQL_THTRUEMART; -- Đảm bảo bạn đang ở đúng cơ sở dữ liệu
GO

SELECT
    t.name AS TenBang,
    i.name AS TenIndex,
    i.type_desc AS LoaiIndex, -- CLUSTERED, NONCLUSTERED, XML, SPATIAL
    i.is_unique AS LaDuyNhat,
    i.is_primary_key AS LaKhoaChinh,
    i.fill_factor AS TyLeDay
FROM sys.indexes i
INNER JOIN sys.tables t ON i.object_id = t.object_id
WHERE i.name IS NOT NULL -- Loại trừ các Index Heap (nếu có)
ORDER BY t.name, i.name;
GO

-- 1. Index duy nhất trên SĐT khách hàng
CREATE UNIQUE NONCLUSTERED INDEX IX_KH_SDT
ON KHACHHANG (SDT_KH);
GO

-- 2. Index trên Ngày lập Hóa đơn (Rất quan trọng cho báo cáo)
CREATE NONCLUSTERED INDEX IX_HD_NGAYLAP
ON HOADON (NGAYLAPHD);
GO

-- 3. Index duy nhất trên Email nhân viên
CREATE UNIQUE NONCLUSTERED INDEX IX_NV_EMAIL
ON NHANVIEN (EMAIL);
GO

-- 4. Index đa cột trên Chi tiết Hóa đơn (Tối ưu JOIN và tìm kiếm theo SP)
CREATE NONCLUSTERED INDEX IX_CTHD_SP_HD
ON CT_HD (MASP, MA_HD);
GO

-- 5. Index trên Tên Sản phẩm (Tối ưu tìm kiếm trực tiếp)
CREATE NONCLUSTERED INDEX IX_SP_TENSP
ON SANPHAM (TENSP);
GO

-- Truy vấn tận dụng Index IX_KH_SDT để tìm kiếm cực nhanh
SELECT
    MA_KH,
    TEN_KH,
    DIACHI_KH
FROM KHACHHANG
WHERE SDT_KH = '0931234567'; -- Số điện thoại của KH001

-- Truy vấn tận dụng Index IX_HD_NGAYLAP để lọc hiệu quả
SELECT
    NGAYLAPHD,
    SUM(TONGCONGTHANHTIEN) AS TongDoanhThu
FROM HOADON
WHERE NGAYLAPHD BETWEEN '01/11/2025' AND '30/11/2025'
GROUP BY NGAYLAPHD
ORDER BY NGAYLAPHD DESC;

-- Truy vấn tận dụng Index IX_SP_TENSP
SELECT
    MASP,
    TENSP,
    MADVT
FROM SANPHAM
WHERE TENSP LIKE N'Sữa Tươi%';

-- Truy vấn tận dụng Index IX_CTHD_SP_HD
SELECT
    T1.MASP,
    T2.TENSP,
    SUM(T1.SOLUONG_TRA) AS TongSoLuongBan
FROM CT_HD T1
JOIN SANPHAM T2 ON T1.MASP = T2.MASP
WHERE T1.MASP = 'SP001'
GROUP BY T1.MASP, T2.TENSP;

-----------------------------------------------------------------
--VIEW
USE SQL_THTRUEMART; -- Đảm bảo bạn đang ở đúng cơ sở dữ liệu
GO

SELECT
    name AS TenView,
    create_date AS NgayTao,
    modify_date AS NgayChinhSuaCuoi
FROM sys.objects
WHERE type = 'V' -- 'V' là mã cho VIEW
    AND is_ms_shipped = 0 -- Loại trừ các View hệ thống mặc định của SQL Server
ORDER BY name;
GO

-- Đảm bảo đang sử dụng đúng cơ sở dữ liệu
USE SQL_THTRUEMART;
GO

-- 1. View Báo cáo Doanh thu theo Ngày
CREATE VIEW V_BAOCAO_DOANHTHU_NGAY
AS
SELECT
    NGAYLAPHD AS Ngay,
    SUM(TRIGIATRUOCTHUE) AS TongTriGiaTruocThue,
    SUM(TONGTIENGIAM) AS TongTienGiam,
    SUM(TRIGIASAUTHUE) AS TongTriGiaSauThue,
    SUM(TONGCONGTHANHTIEN) AS TongThanhTien
FROM HOADON
GROUP BY NGAYLAPHD;
GO

-- 2. View Danh sách Khách hàng Thành viên
CREATE VIEW V_DANHSACH_KHACHHANG_TV
AS
SELECT
    KH.MA_KH,
    KH.TEN_KH,
    KH.SDT_KH,
    LKH.TEN_LOAIKH,
    TTV.SOTHE,
    TTV.DIEM_HT,
    TTV.NGAYCAP AS NgayCapThe
FROM KHACHHANG KH
JOIN LOAIKH LKH ON KH.MA_LOAIKH = LKH.MA_LOAIKH
JOIN THETHANHVIEN TTV ON KH.MA_KH = TTV.MA_KH;
GO

-- 3. View Tổng hợp Nhập Xuất Sản phẩm
CREATE VIEW V_TONGHOP_NHAPXUAT_SP
AS
SELECT
    SP.MASP,
    SP.TENSP,
    ISNULL(SUM(CTPN.SOLUONGNHAP), 0) AS TongSoLuongNhap,
    ISNULL(SUM(CTPX.SOLUONGXUAT), 0) AS TongSoLuongXuat,
    ISNULL(SUM(CTPN.SOLUONGNHAP), 0) - ISNULL(SUM(CTPX.SOLUONGXUAT), 0) AS TonTamThoi
FROM SANPHAM SP
LEFT JOIN CT_PHIEUNHAP CTPN ON SP.MASP = CTPN.MASP
LEFT JOIN CT_PHIEUXUAT CTPX ON SP.MASP = CTPX.MASP
GROUP BY SP.MASP, SP.TENSP;
GO

-- 4. View Thông tin Nhân viên và Chức vụ
CREATE VIEW V_THONGTIN_NHANVIEN_CHUCVU
AS
SELECT
    NV.MANV,
    NV.TENNV,
    NV.SDT,
    CV.TENCV,
    PB.TEN_PB,
    NV.EMAIL,
    NV.TRANGTHAI_NV
FROM NHANVIEN NV
JOIN CHUCVU CV ON NV.MACV = CV.MACV
JOIN PHONGBAN PB ON NV.MAPB = PB.MAPB;
GO

-- 5. View Chi tiết Khuyến mãi đang áp dụng
CREATE VIEW V_CTKM_DANG_AP_DUNG
AS
SELECT
    CTKM.MA_CTKM,
    CTKM.TEN_CTKM,
    SP.TENSP,
    CT.PHAMTRAMGIAM,
    CT.GHICHU
FROM CHUONGTRINHKHUYENMAI CTKM
JOIN CT_CTKM CT ON CTKM.MA_CTKM = CT.MA_CTKM
JOIN SANPHAM SP ON CT.MASP = SP.MASP
WHERE CTKM.NGAYKTCTKM >= GETDATE(); 
GO

-- Kiểm thử View Báo cáo Doanh thu
SELECT *
FROM V_BAOCAO_DOANHTHU_NGAY
WHERE Ngay BETWEEN '11/01/2025' AND '11/30/2025'
ORDER BY Ngay;

-- Kiểm thử View Danh sách Khách hàng Thành viên
SELECT TOP 5
    TEN_KH,
    SDT_KH,
    TEN_LOAIKH,
    DIEM_HT
FROM V_DANHSACH_KHACHHANG_TV
ORDER BY DIEM_HT DESC;

-- Kiểm thử View Tổng hợp Nhập Xuất Sản phẩm
SELECT
    MASP,
    TENSP,
    TongSoLuongNhap,
    TongSoLuongXuat,
    TonTamThoi
FROM V_TONGHOP_NHAPXUAT_SP
WHERE MASP IN ('SP001', 'SP004', 'SP011');

-- Kiểm thử View Thông tin Nhân viên và Chức vụ
SELECT
    TENNV,
    TENCV,
    TEN_PB,
    EMAIL
FROM V_THONGTIN_NHANVIEN_CHUCVU
WHERE TENCV = N'Nhân Viên Bán Hàng'
ORDER BY EMAIL;

-- Kiểm thử View Chi tiết Khuyến mãi đang áp dụng
SELECT
    TEN_CTKM,
    TENSP,
    PHAMTRAMGIAM
FROM V_CTKM_DANG_AP_DUNG
WHERE TEN_CTKM LIKE N'%Giảm Giá Cuối Năm%';

-----------------------------------------------
--FUNCTION
USE SQL_THTRUEMART; -- Đảm bảo bạn đang ở đúng cơ sở dữ liệu
GO

SELECT
    obj.name AS TenHam,
    obj.type_desc AS LoaiHam, -- Scalar function, Table-valued function, v.v.
    obj.create_date AS NgayTao,
    modu.definition AS DinhNghiaCode
FROM sys.objects obj
JOIN sys.sql_modules modu ON obj.object_id = modu.object_id
WHERE obj.type IN ('FN', 'IF', 'TF', 'FS', 'FT') -- Lọc các loại Function
    AND obj.is_ms_shipped = 0 -- Loại trừ các hàm hệ thống mặc định
ORDER BY obj.name;
GO

-- Đảm bảo đang sử dụng đúng cơ sở dữ liệu
USE SQL_THTRUEMART;
GO

----------------------------------------------------------------------------------------------------
-- 1. SCALAR FUNCTION: fn_TinhThueVAT
-- Tính toán giá trị VAT thực tế (trước khi trừ giảm giá)
----------------------------------------------------------------------------------------------------
CREATE FUNCTION fn_TinhThueVAT (@MaHD CHAR(10))
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TriGiaTruocThue DECIMAL(18, 2);
    DECLARE @ThueVAT DECIMAL(18, 2);
    DECLARE @GiaTriVAT DECIMAL(18, 2);

    SELECT
        @TriGiaTruocThue = TRIGIATRUOCTHUE,
        @ThueVAT = THUEVAT
    FROM HOADON
    WHERE MA_HD = @MaHD;

    -- Giá trị VAT = Trị giá trước thuế * Tỷ lệ VAT
    SET @GiaTriVAT = @TriGiaTruocThue * @ThueVAT;

    RETURN @GiaTriVAT;
END
GO

----------------------------------------------------------------------------------------------------
-- 2. TABLE-VALUED FUNCTION: ft_LayDS_SP_KM_ConHan
-- Trả về danh sách KM chi tiết, lọc theo mã CTKM và sản phẩm
----------------------------------------------------------------------------------------------------
CREATE FUNCTION ft_LayDS_SP_KM_ConHan (@MaCTKM CHAR(10), @PhanTramGiamToiThieu DECIMAL(18,2))
RETURNS TABLE
AS
RETURN
(
    SELECT
        T1.TEN_CTKM,
        T2.MASP,
        T3.TENSP,
        T2.PHAMTRAMGIAM,
        T1.NGAYKTCTKM
    FROM CHUONGTRINHKHUYENMAI T1
    JOIN CT_CTKM T2 ON T1.MA_CTKM = T2.MA_CTKM
    JOIN SANPHAM T3 ON T2.MASP = T3.MASP
    WHERE
        T1.MA_CTKM = @MaCTKM AND
        T1.NGAYKTCTKM >= GETDATE() AND
        T2.PHAMTRAMGIAM >= @PhanTramGiamToiThieu
);
GO


----------------------------------------------------------------------------------------------------
-- 3. SCALAR FUNCTION: fn_TinhDiemThuong
-- Tính điểm thưởng cho Khách hàng (100,000 VND = 10 điểm)
----------------------------------------------------------------------------------------------------
CREATE FUNCTION fn_TinhDiemThuong (@TongTienChiTieu DECIMAL(18, 2))
RETURNS INT
AS
BEGIN
    DECLARE @DiemThuong INT;
    DECLARE @TyLeDiem INT = 10000; -- Tỷ lệ 1 điểm trên mỗi 10,000 VND

    -- Tính điểm = Tổng tiền chi tiêu / (100,000 / 10 điểm) = Tổng tiền / 10,000
    SET @DiemThuong = CAST(@TongTienChiTieu / @TyLeDiem AS INT);

    RETURN @DiemThuong;
END
GO

----------------------------------------------------------------------------------------------------
-- 4. TABLE-VALUED FUNCTION: ft_BaoCao_SoLuongBan_SP
-- Trả về số lượng bán của SP theo từng tháng trong một năm
----------------------------------------------------------------------------------------------------
CREATE FUNCTION ft_BaoCao_SoLuongBan_SP (@MaSP CHAR(10), @Nam INT)
RETURNS TABLE
AS
RETURN
(
    SELECT
        MONTH(HD.NGAYLAPHD) AS Thang,
        SUM(CTHD.SOLUONG_TRA) AS TongSoLuongBan
    FROM HOADON HD
    JOIN CT_HD CTHD ON HD.MA_HD = CTHD.MA_HD
    WHERE
        CTHD.MASP = @MaSP AND
        YEAR(HD.NGAYLAPHD) = @Nam
    GROUP BY MONTH(HD.NGAYLAPHD)
);
GO
-------------------------------------------------
--5
-- Đảm bảo đang sử dụng đúng cơ sở dữ liệu
USE SQL_THTRUEMART;
GO

----------------------------------------------------------------------------------------------------
-- 6. SCALAR FUNCTION: fn_KiemTra_DieuKien_VIP
-- Kiểm tra xem khách hàng có thuộc loại VIP (Kim Cương) VÀ có điểm tích lũy > 4000

CREATE FUNCTION fn_KiemTra_DieuKien_VIP (@MaKH CHAR(10))
RETURNS BIT
AS
BEGIN
    DECLARE @IsVIP BIT = 0;
    DECLARE @DiemHienTai INT;
    DECLARE @MaLoaiKH CHAR(10);
    DECLARE @MaLoaiKimCuong CHAR(10) = 'LKH004'; 
    SELECT
        @DiemHienTai = ISNULL(TTV.DIEM_HT, 0),
        @MaLoaiKH = KH.MA_LOAIKH
    FROM KHACHHANG KH
    LEFT JOIN THETHANHVIEN TTV ON KH.MA_KH = TTV.MA_KH
    WHERE KH.MA_KH = @MaKH;
    IF @MaLoaiKH = @MaLoaiKimCuong AND @DiemHienTai >= 4000
    BEGIN
        SET @IsVIP = 1;
    END
    RETURN @IsVIP;
END
GO


SELECT
    MA_HD,
    TRIGIATRUOCTHUE,
    THUEVAT,
    dbo.fn_TinhThueVAT(MA_HD) AS GiaTriVAT_ThucTe
FROM HOADON
WHERE MA_HD = 'HD001';

--Minh họa 2 Kiểm thử Table-Valued Function
SELECT
    *
FROM dbo.ft_LayDS_SP_KM_ConHan('KM005', 0.10);

--Minh họa 3
SELECT
    MA_HD,
    TONGCONGTHANHTIEN AS TongTienThanhToan,
    dbo.fn_TinhDiemThuong(TONGCONGTHANHTIEN) AS DiemTichLuyDuoc
FROM HOADON
WHERE NGAYLAPHD BETWEEN '11/01/2025' AND '11/30/2025';

--Minh họa 4
-- Kiểm thử Table-Valued Function
SELECT
    T1.Thang,
    T1.TongSoLuongBan
FROM dbo.ft_BaoCao_SoLuongBan_SP('SP004', 2025) T1;

--Minh họa 5
-- Kiểm thử Function fn_KiemTra_DieuKien_VIP
SELECT
    KH.MA_KH,
    KH.TEN_KH,
    LKH.TEN_LOAIKH,
    ISNULL(TTV.DIEM_HT, 0) AS DiemHienTai,
    dbo.fn_KiemTra_DieuKien_VIP(KH.MA_KH) AS DuDieuKienVIP
FROM KHACHHANG KH
JOIN LOAIKH LKH ON KH.MA_LOAIKH = LKH.MA_LOAIKH
LEFT JOIN THETHANHVIEN TTV ON KH.MA_KH = TTV.MA_KH
WHERE LKH.TEN_LOAIKH IN (N'Khách Hàng Thành Viên Kim Cương', N'Khách Hàng Thành Viên Vàng');

--------------------------------------------------------------------------------
-- STORE PROCEDURE
USE SQL_THTRUEMART;
GO

SELECT
    name AS TenStoreProcedure,
    type_desc AS LoaiDoiTuong,
    create_date AS NgayTao
FROM sys.objects
WHERE type = 'P' -- 'P' là mã cho SQL Stored Procedure
ORDER BY name;
GO

--Minh họa 1
-- DROP SP CŨ
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_LapHoaDon_BanLe')
    DROP PROCEDURE sp_LapHoaDon_BanLe;
GO

CREATE PROCEDURE sp_LapHoaDon_BanLe
    @MaHD CHAR(10),
    @MaKH CHAR(10),
    @MaLoaiHD CHAR(10),
    @MaPX CHAR(10),
    @HinhThucTT NVARCHAR(100),
    @ThueVAT DECIMAL(18,2),
    @ChiTietHD AS dbo.TYPE_CT_HD READONLY
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @TriGiaTruocThue DECIMAL(18,2) = 0;
    DECLARE @TongTienGiam DECIMAL(18,2) = 0;
    DECLARE @NgayLapHD DATE = GETDATE();

    BEGIN TRANSACTION
    BEGIN TRY
        SELECT
            @TriGiaTruocThue = SUM(DonGia * SoLuong),
            @TongTienGiam = SUM(DonGia * SoLuong * PhanTramGiam)
        FROM @ChiTietHD;

        DECLARE @TriGiaSauGiam DECIMAL(18,2) = @TriGiaTruocThue - @TongTienGiam;
        DECLARE @TriGiaSauThue DECIMAL(18,2) = @TriGiaSauGiam * (1 + @ThueVAT);

        INSERT INTO HOADON (MA_HD, NGAYLAPHD, HINHTHUCTT, THUEVAT, TRIGIATRUOCTHUE, TRIGIASAUTHUE, TONGTIENGIAM, TONGCONGTHANHTIEN, MA_KH, MA_LOAIHD, MA_PX)
        VALUES (@MaHD, @NgayLapHD, @HinhThucTT, @ThueVAT, @TriGiaTruocThue, @TriGiaSauThue, @TongTienGiam, @TriGiaSauThue, @MaKH, @MaLoaiHD, @MaPX);

        INSERT INTO CT_HD (MA_HD, MASP, SOLUONG_TRA, DONGIA_HD, PHANTRAMGIAMHD, GIASAUGIAM, THANHTIENHD)
        SELECT
            @MaHD,
            MASP,
            SoLuong,
            DonGia,
            PhanTramGiam,
            DonGia * (1 - PhanTramGiam) AS GiaSauGiam,
            SoLuong * DonGia * (1 - PhanTramGiam) AS ThanhTien
        FROM @ChiTietHD;
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

SET DATEFORMAT dmy;
--Khai báo biến bảng (Table Type) cho chi tiết giao dịch
DECLARE @ChiTietBan AS dbo.TYPE_CT_HD;

INSERT INTO @ChiTietBan (MASP, SoLuong, DonGia, PhanTramGiam) VALUES
('SP004', 10, 6200.00, 0.00),
('SP002', 2, 35000.00, 0.10);

--Chuẩn bị Phiếu Xuất (PX017)
INSERT INTO PHIEUXUAT (MA_PX, NGAYXUAT, LYDOXUAT, TRIGIA_PX, DIADIEMGH, MA_KHO, MANV) VALUES
('PX017', '01/12/2025', N'Xuất bán lẻ HD017', 100000.00, N'Chi nhánh 5', 'KHO001', 'NV004');
--Thực thi SP
EXEC sp_LapHoaDon_BanLe
    @MaHD = 'HD017',
    @MaKH = 'KH005',
    @MaLoaiHD = 'LHD001',
    @MaPX = 'PX017',
    @HinhThucTT = N'Thẻ Tín Dụng',
    @ThueVAT = 0.10,
    @ChiTietHD = @ChiTietBan;

--Kiểm tra kết quả Hóa Đơn 
SELECT MA_HD, TONGCONGTHANHTIEN FROM HOADON WHERE MA_HD = 'HD017';
GO

--Minh họa 2
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_ThemSP_VaoCTKM')
    DROP PROCEDURE sp_ThemSP_VaoCTKM;
GO

CREATE PROCEDURE sp_ThemSP_VaoCTKM
    @MaSP CHAR(10),
    @MaCTKM CHAR(10),
    @PhanTramGiam DECIMAL(18,2),
    @GhiChu NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM CT_CTKM WHERE MASP = @MaSP AND MA_CTKM = @MaCTKM)
    BEGIN
        RAISERROR(N'Sản phẩm này đã tồn tại trong chương trình khuyến mãi hiện tại.', 16, 1);
        RETURN;
    END

    IF @PhanTramGiam < 0 OR @PhanTramGiam > 1
    BEGIN
        RAISERROR(N'Phần trăm giảm phải nằm trong khoảng từ 0 đến 1 (0%% đến 100%%).', 16, 1);
        RETURN;
    END

    INSERT INTO CT_CTKM (MASP, MA_CTKM, PHAMTRAMGIAM, GHICHU)
    VALUES (@MaSP, @MaCTKM, @PhanTramGiam, @GhiChu);

END
GO

-- Thử thành công (Thêm SP015 vào KM001)
EXEC sp_ThemSP_VaoCTKM
    @MaSP = 'SP015',
    @MaCTKM = 'KM001',
    @PhanTramGiam = 0.25,
    @GhiChu = N'KM thử nghiệm';

-- Thử thất bại (Thử thêm lại SP015 vào KM001) 
EXEC sp_ThemSP_VaoCTKM
    @MaSP = 'SP015',
    @MaCTKM = 'KM001',
    @PhanTramGiam = 0.15;

-- Kiểm tra kết quả
SELECT MASP, MA_CTKM, PHAMTRAMGIAM FROM CT_CTKM WHERE MASP = 'SP015' AND MA_CTKM = 'KM001';
GO

--Minh họa 3
-- DROP SP CŨ
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_CapNhat_GiaBan_Moi')
    DROP PROCEDURE sp_CapNhat_GiaBan_Moi;
GO

CREATE PROCEDURE sp_CapNhat_GiaBan_Moi
    @MaSP CHAR(10),
    @GiaBanMoi DECIMAL(18,2),
    @NgayApDung DATE -- Nhận trực tiếp DATE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @NgayCapNhatCuoi DATE;
    DECLARE @NgayCapNhatCuoi_Str NVARCHAR(50);

    -- KIỂM TRA BẢO VỆ 1: Ngày áp dụng không được NULL
    IF @NgayApDung IS NULL
    BEGIN
        RAISERROR(N'Ngày áp dụng không hợp lệ hoặc bị thiếu.', 16, 1);
        RETURN;
    END

    -- 1. Tìm ngày cập nhật giá cuối cùng
    SELECT TOP 1 @NgayCapNhatCuoi = NGAYCAPNHAT_BDG
    FROM BIENDONGGIA WHERE MASP = @MaSP
    ORDER BY NGAYCAPNHAT_BDG DESC;

    -- 2. Kiểm tra logic: Ngày áp dụng giá mới phải LỚN HƠN ngày cập nhật gần nhất
    IF @NgayCapNhatCuoi IS NOT NULL AND @NgayApDung <= @NgayCapNhatCuoi
    BEGIN
        SET @NgayCapNhatCuoi_Str = CONVERT(NVARCHAR, @NgayCapNhatCuoi, 103);
        RAISERROR(N'Ngày áp dụng giá mới phải lớn hơn ngày cập nhật giá cuối cùng (%s). Vui lòng kiểm tra lại.', 16, 1, @NgayCapNhatCuoi_Str);
        RETURN;
    END

    -- 3. Chèn giá mới
    INSERT INTO BIENDONGGIA (MASP, NGAYCAPNHAT_BDG, GIABAN)
    VALUES (@MaSP, @NgayApDung, @GiaBanMoi);
END
GO

SET DATEFORMAT dmy;
DECLARE @NgayCu DATE = CONVERT(DATE, '02/12/2025', 103);
DECLARE @NgayMoi DATE = CONVERT(DATE, '05/12/2025', 103);

-- Thử thất bại (Ngày áp dụng <= Ngày cuối (01/12/2025)) 
EXEC sp_CapNhat_GiaBan_Moi
    @MaSP = 'SP004',
    @GiaBanMoi = 6000.00,
    @NgayApDung = @NgayCu;

-- Thử thành công (Ngày áp dụng > Ngày cuối)
EXEC sp_CapNhat_GiaBan_Moi
    @MaSP = 'SP004',
    @GiaBanMoi = 6500.00,
    @NgayApDung = @NgayMoi;

-- Kiểm tra kết quả
SELECT TOP 3 NGAYCAPNHAT_BDG, GIABAN FROM BIENDONGGIA WHERE MASP = 'SP004' ORDER BY NGAYCAPNHAT_BDG DESC;
GO

--Minh họa 4
USE SQL_THTRUEMART;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_BaoCao_DoanhSoNV')
    DROP PROCEDURE sp_BaoCao_DoanhSoNV;
GO

CREATE PROCEDURE sp_BaoCao_DoanhSoNV
    @Thang INT,
    @Nam INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        NV.MANV,
        NV.TENNV,
        COUNT(HD.MA_HD) AS TongSoHoaDon,
        SUM(HD.TONGCONGTHANHTIEN) AS TongDoanhSo
    FROM NHANVIEN NV
    JOIN PHIEUXUAT PX ON NV.MANV = PX.MANV
    JOIN HOADON HD ON PX.MA_PX = HD.MA_PX
    WHERE
        MONTH(HD.NGAYLAPHD) = @Thang AND
        YEAR(HD.NGAYLAPHD) = @Nam
    GROUP BY NV.MANV, NV.TENNV
    ORDER BY TongDoanhSo DESC;
END
GO

-- Chạy báo cáo cho tháng 11/2025 
EXEC sp_BaoCao_DoanhSoNV
    @Thang = 11,
    @Nam = 2025;
GO

-- Chạy báo cáo cho tháng 12/2025 (Tháng có giao dịch mới HD017)
EXEC sp_BaoCao_DoanhSoNV
    @Thang = 12,
    @Nam = 2025;
GO

--Minh hoạ 5
USE SQL_THTRUEMART;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_LayDS_SP_SapHetHan')
    DROP PROCEDURE sp_LayDS_SP_SapHetHan;
GO

CREATE PROCEDURE sp_LayDS_SP_SapHetHan
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        SP.MASP,
        SP.TENSP,
        SP.NXSSP AS NgaySanXuat_Xuat,
        SP.HSDSP AS HSD_ConLai_Ngay,
        DATEADD(day, SP.HSDSP, SP.NXSSP) AS NgayHetHan
    FROM SANPHAM SP
    WHERE DATEADD(day, SP.HSDSP, SP.NXSSP) <= DATEADD(day, 30, GETDATE())
    ORDER BY NgayHetHan ASC; 
END
GO

EXEC sp_LayDS_SP_SapHetHan;
GO

--Minh họa 6
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'FN' AND name = 'fn_TinhDiemThuong')
    DROP FUNCTION fn_TinhDiemThuong;
GO

CREATE FUNCTION fn_TinhDiemThuong (@TongTienGiaoDich DECIMAL(18, 2))
RETURNS INT
AS
BEGIN
    DECLARE @Diem INT;
    SET @Diem = FLOOR(@TongTienGiaoDich / 10000.00);
    RETURN @Diem;
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_CapNhat_DiemTichLuy')
    DROP PROCEDURE sp_CapNhat_DiemTichLuy;
GO

CREATE PROCEDURE sp_CapNhat_DiemTichLuy
    @MaKH CHAR(10),
    @TongTienGiaoDich DECIMAL(18, 2)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @DiemMoi INT;
    IF NOT EXISTS (SELECT 1 FROM THETHANHVIEN WHERE MA_KH = @MaKH)
    BEGIN
        RAISERROR(N'Không tìm thấy Thẻ Thành Viên cho Khách hàng này.', 16, 1);
        RETURN;
    END
    SET @DiemMoi = dbo.fn_TinhDiemThuong(@TongTienGiaoDich);
    UPDATE THETHANHVIEN
    SET
        DIEM_HT = DIEM_HT + @DiemMoi,
        DIEM_TL_NGAY = DIEM_TL_NGAY + @DiemMoi,
        NGAY_CN = GETDATE()
    WHERE MA_KH = @MaKH;
    PRINT N'Đã cập nhật điểm thành công. Điểm tích lũy mới: ' + CAST(@DiemMoi AS NVARCHAR);
END
GO

-- Kiểm tra điểm ban đầu của KH005 
SELECT TTV.DIEM_HT AS DiemTruocGiaoDich 
FROM THETHANHVIEN TTV WHERE TTV.MA_KH = 'KH005'; 

-- Thực thi SP: 137,500 VND -> (137,500 / 10,000 = 13.75 -> 13 điểm)
DECLARE @TongThanhToan DECIMAL(18,2) = 137500.00;

EXEC sp_CapNhat_DiemTichLuy
    @MaKH = 'KH005',
    @TongTienGiaoDich = @TongThanhToan;

-- Kiểm tra kết quả
SELECT TTV.DIEM_HT AS DiemSauGiaoDich, TTV.DIEM_TL_NGAY
FROM THETHANHVIEN TTV WHERE TTV.MA_KH = 'KH005';
GO

------------------------------------------------------------------------------------------
--Trigger
USE SQL_THTRUEMART;
GO

SELECT
    t.name AS TenTrigger,
    t.type_desc AS LoaiTrigger,
    OBJECT_NAME(parent_object_id) AS TenBangLienQuan,
    t.create_date AS NgayTao
FROM sys.objects t
WHERE t.type IN ('TR', 'TA')
    AND t.is_ms_shipped = 0
ORDER BY TenBangLienQuan, TenTrigger;
GO

--Minh họa 1
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_CapNhat_TongGia_PN')
    DROP TRIGGER TR_CapNhat_TongGia_PN;
GO

CREATE TRIGGER TR_CapNhat_TongGia_PN
ON CT_PHIEUNHAP
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE PN
    SET TRIGIA_PN = I.TongTienMoi
    FROM PHIEUNHAP PN
    INNER JOIN (
        SELECT 
            CT.SO_PN,
            SUM(CT.THANHTIEN_PN) AS TongTienMoi
        FROM CT_PHIEUNHAP CT
        WHERE CT.SO_PN IN (SELECT SO_PN FROM inserted UNION SELECT SO_PN FROM deleted)
        GROUP BY CT.SO_PN
    ) AS I ON PN.SO_PN = I.SO_PN;
    UPDATE PN
    SET TRIGIA_PN = 0
    FROM PHIEUNHAP PN
    LEFT JOIN CT_PHIEUNHAP CT ON PN.SO_PN = CT.SO_PN
    WHERE CT.SO_PN IS NULL
      AND PN.SO_PN IN (SELECT SO_PN FROM deleted);
END
GO

-- Chuẩn bị dữ liệu mẫu (Phiếu Nhập PN005)
INSERT INTO PHIEUNHAP (SO_PN, NGAYNHAP, TRIGIA_PN, MA_NCC, MANV) 
VALUES ('PN005', GETDATE(), 0, 'NCC001', 'NV001');

-- Kích hoạt INSERT: Thêm chi tiết nhập (100 * 5,000 = 500,000)
INSERT INTO CT_PHIEUNHAP (SO_PN, MASP, SOLUONGNHAP, DONGIA_PN, THANHTIEN_PN)
VALUES ('PN005', 'SP004', 100, 5000.00, 500000.00);

-- Kiểm tra kết quả: TRIGIA_PN là 500,000.00
SELECT SO_PN, TRIGIA_PN AS Sau_Insert FROM PHIEUNHAP WHERE SO_PN = 'PN005';
GO

-- Kích hoạt UPDATE: Sửa số lượng. Tổng tiền thay đổi +500,000
UPDATE CT_PHIEUNHAP
SET SOLUONGNHAP = 200, THANHTIEN_PN = 1000000.00
WHERE SO_PN = 'PN005' AND MASP = 'SP004';

-- Kiểm tra kết quả: TRIGIA_PN là 1,000,000.00
SELECT SO_PN, TRIGIA_PN AS Sau_Update FROM PHIEUNHAP WHERE SO_PN = 'PN005';
GO

-- Kích hoạt DELETE: Xóa chi tiết nhập. Tổng tiền thay đổi -1,000,000
DELETE FROM CT_PHIEUNHAP WHERE SO_PN = 'PN005' AND MASP = 'SP004';

-- Kiểm tra kết quả: TRIGIA_PN phải là 0.00
SELECT SO_PN, TRIGIA_PN AS Sau_Delete FROM PHIEUNHAP WHERE SO_PN = 'PN005';
GO

--Minh họa 2
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_CapNhat_NgayCN_TTV')
    DROP TRIGGER TR_CapNhat_NgayCN_TTV;
GO

CREATE TRIGGER TR_CapNhat_NgayCN_TTV
ON THETHANHVIEN
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF UPDATE(DIEM_HT)
    BEGIN
        UPDATE T
        SET NGAY_CN = GETDATE()
        FROM THETHANHVIEN T
        JOIN inserted I ON T.SOTHE = I.SOTHE
        WHERE T.NGAY_CN <> GETDATE();
    END
END
GO


SELECT SOTHE, DIEM_HT AS DiemBanDau, NGAY_CN AS NgayCNDau
FROM THETHANHVIEN WHERE MA_KH = 'KH005';

-- Kích hoạt UPDATE: Cập nhật DIEM_HT (Thay đổi điểm)
UPDATE THETHANHVIEN
SET DIEM_HT = DIEM_HT + 50
WHERE MA_KH = 'KH005';

-- Kiểm tra kết quả
SELECT DIEM_HT AS DiemSauUpdate, NGAY_CN AS NgayCNSau
FROM THETHANHVIEN WHERE MA_KH = 'KH005';
GO

--Minh họa 3
-- TẠO BẢNG GIÁM SÁT
IF OBJECT_ID('LICH_SU_TAI_KHOAN') IS NOT NULL
    DROP TABLE LICH_SU_TAI_KHOAN;
GO

CREATE TABLE LICH_SU_TAI_KHOAN (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MATK CHAR(10) NOT NULL,
    TENTK VARCHAR(100) NOT NULL,
    ThaoTac NVARCHAR(50) NOT NULL,
    NgayGioThucHien DATETIME DEFAULT GETDATE(),
    NguoiThucHien NVARCHAR(100) DEFAULT SUSER_NAME()
);
GO

-- TẠO TRIGGER GIÁM SÁT
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_GhiLog_TaiKhoan')
    DROP TRIGGER TR_GhiLog_TaiKhoan;
GO

CREATE TRIGGER TR_GhiLog_TaiKhoan
ON TAIKHOAN
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO LICH_SU_TAI_KHOAN (MATK, TENTK, ThaoTac)
    SELECT 
        I.MATK, 
        I.TENTK, 
        N'Tạo tài khoản mới'
    FROM inserted I;
END
GO


-- INSERT: Tạo tài khoản mới cho nhân viên NV008
INSERT INTO TAIKHOAN (MATK, TENTK, MANV, MK)
VALUES ('TK008', 'taikhoan_moi_lan2', 'NV008', 'password_hash_new');

-- Kiểm tra 
SELECT ID, MATK, ThaoTac, NgayGioThucHien, NguoiThucHien
FROM LICH_SU_TAI_KHOAN
WHERE MATK = 'TK008';
GO

----------------------------------------
--User
USE SQL_THTRUEMART;
GO

-- 1. TẠO SCHEMA RIÊNG (OPTIONAL - Tăng cường bảo mật)
-- CREATE SCHEMA [NghiepVu];
-- GO

-- 2. CẬP NHẬT MẬT KHẨU TÀI KHOẢN BẰNG HASHBYTES
-- Giả sử mật khẩu là 'thTrueMart@123'
UPDATE TAIKHOAN
SET MK = HASHBYTES('SHA2_256', 'thTrueMart@123') 
WHERE MATK = 'TK001'; -- Giả định TK001 là Quản lý

-- Lưu ý: Mật khẩu này phải được mã hóa lại cho tất cả các tài khoản trong bảng TAIKHOAN.
-- Để đơn giản hóa kiểm thử, ta sẽ tạo tài khoản mới.

-- Nếu tồn tại, xóa Login cũ
IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'Login_QuanLy')
    DROP LOGIN Login_QuanLy;
IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'Login_NhanVien')
    DROP LOGIN Login_NhanVien;

---- Tạo Login cho Quản lý (Mật khẩu: Admin@123!)
--CREATE LOGIN Login_QuanLy WITH PASSWORD = N'Admin@123!', CHECK_POLICY = OFF;
---- Tạo Login cho Nhân viên (Mật khẩu: User@123!)
--CREATE LOGIN Login_NhanVien WITH PASSWORD = N'User@123!', CHECK_POLICY = OFF;
--GO

---- Ánh xạ Login vào DB
--CREATE USER User_QuanLy FOR LOGIN Login_QuanLy;
--CREATE USER User_NhanVien FOR LOGIN Login_NhanVien;
--GO


IF DATABASE_PRINCIPAL_ID('QL_ROLE') IS NOT NULL
    DROP ROLE QL_ROLE;
IF DATABASE_PRINCIPAL_ID('NV_ROLE') IS NOT NULL
    DROP ROLE NV_ROLE;
    
CREATE ROLE QL_ROLE; -- Vai trò Quản lý: Có quyền báo cáo, thay đổi giá
CREATE ROLE NV_ROLE; -- Vai trò Nhân viên: Chỉ có quyền xem và tạo giao dịch (INSERT/SELECT)

ALTER ROLE QL_ROLE ADD MEMBER User_QuanLy;
ALTER ROLE NV_ROLE ADD MEMBER User_NhanVien;
GO



CREATE PROCEDURE sp_LayDS_TatCa_NhanVien
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        NV.MANV,
        NV.TENNV,
        NV.SDT,
        CV.TENCV,
        PB.TEN_PB,
        CN.TENCN,
        NV.TRANGTHAI_NV
    FROM NHANVIEN NV
    JOIN CHUCVU CV ON NV.MACV = CV.MACV
    JOIN PHONGBAN PB ON NV.MAPB = PB.MAPB
    JOIN CHINHANH CN ON PB.MACN = CN.MACN
    ORDER BY NV.MANV;
END
GO

-- NV_ROLE: Quyền cơ bản (SELECT) và giao dịch (EXECUTE SP)
GRANT SELECT ON SCHEMA::dbo TO NV_ROLE; -- Cho phép xem hầu hết các bảng
GRANT INSERT ON HOADON TO NV_ROLE;
GRANT INSERT ON CT_HD TO NV_ROLE;
GRANT EXECUTE ON OBJECT::sp_LapHoaDon_BanLe TO NV_ROLE;
GRANT EXECUTE ON OBJECT::sp_LayDS_TatCa_NhanVien TO NV_ROLE;
GO

-- QL_ROLE: Quyền quản trị cao hơn (Báo cáo, Quản lý giá/khuyến mãi)
GRANT SELECT ON SCHEMA::dbo TO QL_ROLE;
GRANT EXECUTE ON OBJECT::sp_BaoCao_DoanhSoNV TO QL_ROLE; -- Báo cáo
GRANT EXECUTE ON OBJECT::sp_CapNhat_GiaBan_Moi TO QL_ROLE; -- Quản lý giá
GRANT EXECUTE ON OBJECT::sp_ThemSP_VaoCTKM TO QL_ROLE; -- Quản lý KM
GRANT EXECUTE ON OBJECT::sp_LayDS_SP_SapHetHan TO QL_ROLE; -- Báo cáo kho
GO

USE SQL_THTRUEMART;
GO

SELECT
    DP.permission_name AS TenQuyen,
    DP.state_desc AS TrangThai, 
    OBJECT_NAME(DP.major_id) AS TenDoiTuong,
    USER_NAME(DP.grantee_principal_id) AS DuocCapCho
FROM sys.database_permissions AS DP
JOIN sys.database_principals AS DB_P
    ON DP.grantee_principal_id = DB_P.principal_id
WHERE DB_P.name = 'QL_ROLE'
ORDER BY TenDoiTuong, TenQuyen;
GO


/* =========================================================
   0. CHẠY SAU KHI TẠO XONG CSDL SQL_THTRUEMART VÀ DỮ LIỆU
========================================================= */

-----------------------------------------------------------
-- 1. TẠO LOGIN Ở MỨC SERVER
--   (đăng nhập bằng các LOGIN này trong SSMS)
-----------------------------------------------------------
USE master;
GO

-- Xóa login cũ nếu có
IF EXISTS (SELECT * FROM sys.server_principals WHERE name = 'TH_AdminTong')
    DROP LOGIN TH_AdminTong;
IF EXISTS (SELECT * FROM sys.server_principals WHERE name = 'TH_QLChiNhanh')
    DROP LOGIN TH_QLChiNhanh;
IF EXISTS (SELECT * FROM sys.server_principals WHERE name = 'TH_KeToan')
    DROP LOGIN TH_KeToan;
IF EXISTS (SELECT * FROM sys.server_principals WHERE name = 'TH_BanHang')
    DROP LOGIN TH_BanHang;
IF EXISTS (SELECT * FROM sys.server_principals WHERE name = 'TH_ThuKho')
    DROP LOGIN TH_ThuKho;
GO	

-- Tạo login (mật khẩu bạn có thể đổi lại)
CREATE LOGIN TH_AdminTong
WITH PASSWORD = 'AdminTong@123', CHECK_POLICY = OFF;
GO

CREATE LOGIN TH_QLChiNhanh
WITH PASSWORD = 'QLChiNhanh@123', CHECK_POLICY = OFF;
GO

CREATE LOGIN TH_KeToan
WITH PASSWORD = 'KeToan@123', CHECK_POLICY = OFF;
GO

CREATE LOGIN TH_BanHang
WITH PASSWORD = 'BanHang@123', CHECK_POLICY = OFF;
GO

CREATE LOGIN TH_ThuKho
WITH PASSWORD = 'ThuKho@123', CHECK_POLICY = OFF;
GO

-- Đặt default database cho từng login
ALTER LOGIN TH_AdminTong    WITH DEFAULT_DATABASE = SQL_THTRUEMART;
ALTER LOGIN TH_QLChiNhanh   WITH DEFAULT_DATABASE = SQL_THTRUEMART;
ALTER LOGIN TH_KeToan       WITH DEFAULT_DATABASE = SQL_THTRUEMART;
ALTER LOGIN TH_BanHang      WITH DEFAULT_DATABASE = SQL_THTRUEMART;
ALTER LOGIN TH_ThuKho       WITH DEFAULT_DATABASE = SQL_THTRUEMART;
GO


-----------------------------------------------------------
-- 2. TẠO USER TRONG DATABASE, MAP VỚI LOGIN
-----------------------------------------------------------
USE SQL_THTRUEMART;
GO

-- Xóa user cũ nếu có
IF EXISTS (SELECT * FROM sys.database_principals WHERE name = 'TH_AdminTong')
    DROP USER TH_AdminTong;
IF EXISTS (SELECT * FROM sys.database_principals WHERE name = 'TH_QLChiNhanh')
    DROP USER TH_QLChiNhanh;
IF EXISTS (SELECT * FROM sys.database_principals WHERE name = 'TH_KeToan')
    DROP USER TH_KeToan;
IF EXISTS (SELECT * FROM sys.database_principals WHERE name = 'TH_BanHang')
    DROP USER TH_BanHang;
IF EXISTS (SELECT * FROM sys.database_principals WHERE name = 'TH_ThuKho')
    DROP USER TH_ThuKho;
GO

-- Tạo user mapping đúng login
CREATE USER TH_AdminTong  FOR LOGIN TH_AdminTong;
CREATE USER TH_QLChiNhanh FOR LOGIN TH_QLChiNhanh;
CREATE USER TH_KeToan     FOR LOGIN TH_KeToan;
CREATE USER TH_BanHang    FOR LOGIN TH_BanHang;
CREATE USER TH_ThuKho     FOR LOGIN TH_ThuKho;
GO


-----------------------------------------------------------
-- 3. TẠO ROLE NGHIỆP VỤ TRONG DATABASE
--    (không liên quan tới bảng VAITRO, PHANQUYEN ứng dụng)
-----------------------------------------------------------

IF DATABASE_PRINCIPAL_ID('ROLE_AdminTong') IS NOT NULL
    DROP ROLE ROLE_AdminTong;
IF DATABASE_PRINCIPAL_ID('ROLE_QLChiNhanh') IS NOT NULL
    DROP ROLE ROLE_QLChiNhanh;
IF DATABASE_PRINCIPAL_ID('ROLE_KeToan') IS NOT NULL
    DROP ROLE ROLE_KeToan;
IF DATABASE_PRINCIPAL_ID('ROLE_BanHang') IS NOT NULL
    DROP ROLE ROLE_BanHang;
IF DATABASE_PRINCIPAL_ID('ROLE_ThuKho') IS NOT NULL
    DROP ROLE ROLE_ThuKho;
GO

CREATE ROLE ROLE_AdminTong;     -- Full quyền trong DB (trừ các thao tác server)
CREATE ROLE ROLE_QLChiNhanh;    -- Quản lý chi nhánh, toàn quyền trên dữ liệu nghiệp vụ
CREATE ROLE ROLE_KeToan;        -- Kế toán: hóa đơn, đơn hàng, trả hàng, báo cáo
CREATE ROLE ROLE_BanHang;       -- Bán hàng: xem sản phẩm, KH, lập đơn/hoá đơn
CREATE ROLE ROLE_ThuKho;        -- Thủ kho: nhập/xuất, tồn kho
GO

-- Gắn USER vào ROLE
ALTER ROLE ROLE_AdminTong   ADD MEMBER TH_AdminTong;
ALTER ROLE ROLE_QLChiNhanh  ADD MEMBER TH_QLChiNhanh;
ALTER ROLE ROLE_KeToan      ADD MEMBER TH_KeToan;
ALTER ROLE ROLE_BanHang     ADD MEMBER TH_BanHang;
ALTER ROLE ROLE_ThuKho      ADD MEMBER TH_ThuKho;
GO


-----------------------------------------------------------
-- 4. CẤP QUYỀN CHI TIẾT CHO TỪNG ROLE
--   4.1. Admin tổng: toàn quyền trên database
-----------------------------------------------------------

-- Quyền điều khiển database cho ROLE_AdminTong
GRANT CONTROL ON DATABASE::SQL_THTRUEMART TO ROLE_AdminTong;
GO


-----------------------------------------------------------
-- 4.2. Quản lý chi nhánh: CRUD trên toàn bộ bảng (không DDL)
-----------------------------------------------------------

GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO ROLE_QLChiNhanh;
GO


-----------------------------------------------------------
-- 4.3. Kế toán: hoá đơn, đơn hàng, trả hàng, báo cáo
-----------------------------------------------------------

-- Bảng nghiệp vụ kế toán chính
GRANT SELECT, INSERT, UPDATE, DELETE ON HOADON          TO ROLE_KeToan;
GRANT SELECT, INSERT, UPDATE, DELETE ON CT_HD           TO ROLE_KeToan;
GRANT SELECT, INSERT, UPDATE, DELETE ON DONHANG         TO ROLE_KeToan;
GRANT SELECT, INSERT, UPDATE, DELETE ON CT_DH           TO ROLE_KeToan;
GRANT SELECT, INSERT, UPDATE, DELETE ON PHIEUTRAHANG    TO ROLE_KeToan;
GRANT SELECT, INSERT, UPDATE, DELETE ON CT_PHIEUTRAHANG TO ROLE_KeToan;

-- Các bảng tham chiếu liên quan để lập chứng từ / báo cáo
GRANT SELECT ON KHACHHANG             TO ROLE_KeToan;
GRANT SELECT ON THETHANHVIEN          TO ROLE_KeToan;
GRANT SELECT ON SANPHAM               TO ROLE_KeToan;
GRANT SELECT ON CHUONGTRINHKHUYENMAI  TO ROLE_KeToan;
GRANT SELECT ON CT_CTKM               TO ROLE_KeToan;
GRANT SELECT ON BIENDONGGIA           TO ROLE_KeToan;
GRANT SELECT ON NGANHANG              TO ROLE_KeToan;
GRANT SELECT ON LOAI_HD               TO ROLE_KeToan;
GO


-----------------------------------------------------------
-- 4.4. Nhân viên bán hàng
--     Xem SP, KH, KM; lập đơn hàng, hoá đơn; không được xóa
-----------------------------------------------------------

-- Lập đơn hàng + chi tiết
GRANT SELECT, INSERT, UPDATE ON DONHANG TO ROLE_BanHang;
GRANT SELECT, INSERT, UPDATE ON CT_DH   TO ROLE_BanHang;

-- Lập hoá đơn bán hàng (không cho DELETE)
GRANT SELECT, INSERT, UPDATE ON HOADON  TO ROLE_BanHang;
GRANT SELECT, INSERT, UPDATE ON CT_HD   TO ROLE_BanHang;

-- Thẻ thành viên (tích điểm / tạo mới)
GRANT SELECT, INSERT, UPDATE ON THETHANHVIEN TO ROLE_BanHang;

-- Tra cứu thông tin phục vụ tư vấn
GRANT SELECT ON SANPHAM               TO ROLE_BanHang;
GRANT SELECT ON KHACHHANG             TO ROLE_BanHang;
GRANT SELECT ON CHUONGTRINHKHUYENMAI  TO ROLE_BanHang;
GRANT SELECT ON CT_CTKM               TO ROLE_BanHang;
GRANT SELECT ON BIENDONGGIA           TO ROLE_BanHang;
GO


-----------------------------------------------------------
-- 4.5. Thủ kho
--     Quản lý nhập/xuất kho, tồn kho, không động vào hoá đơn
-----------------------------------------------------------

-- Phiếu nhập / chi tiết phiếu nhập
GRANT SELECT, INSERT, UPDATE, DELETE ON PHIEUNHAP     TO ROLE_ThuKho;
GRANT SELECT, INSERT, UPDATE, DELETE ON CT_PHIEUNHAP  TO ROLE_ThuKho;

-- Phiếu xuất / chi tiết phiếu xuất
GRANT SELECT, INSERT, UPDATE, DELETE ON PHIEUXUAT     TO ROLE_ThuKho;
GRANT SELECT, INSERT, UPDATE, DELETE ON CT_PHIEUXUAT  TO ROLE_ThuKho;

-- Tồn kho
GRANT SELECT, INSERT, UPDATE ON TONKHO TO ROLE_ThuKho;

-- Tra cứu SP, kho, NCC
GRANT SELECT ON SANPHAM      TO ROLE_ThuKho;
GRANT SELECT ON KHO          TO ROLE_ThuKho;
GRANT SELECT ON NHACUNGCAP   TO ROLE_ThuKho;
GO


-----------------------------------------------------------
-- 5. KIỂM TRA NHANH QUYỀN
--    (chạy khi cần xem user/role được gán thế nào)
-----------------------------------------------------------

-- Xem danh sách role trong DB
SELECT name, type_desc
FROM sys.database_principals
WHERE type = 'R';

-- Xem member của từng role
SELECT 
    r.name  AS RoleName,
    m.name  AS MemberName
FROM sys.database_role_members drm
JOIN sys.database_principals r ON drm.role_principal_id = r.principal_id
JOIN sys.database_principals m ON drm.member_principal_id = m.principal_id
ORDER BY r.name, m.name;
GO

-- CHẠY BẰNG sa HOẶC WINDOWS AUTH CÓ QUYỀN SYSADMIN

--Minh họa 1
USE SQL_THTRUEMART;
GO

PRINT N'== TEST 1: QUYỀN TH_AdminTong ==';
EXECUTE AS LOGIN = 'TH_AdminTong';

-- Thông tin login hiện tại và user trong DB
SELECT 
    ORIGINAL_LOGIN() AS LoginGoc,
    SUSER_SNAME()    AS LoginDangChay,
    USER_NAME()      AS DatabaseUser;

-- Danh sách các quyền quan trọng trong database hiện tại
SELECT DISTINCT permission_name
FROM sys.fn_my_permissions(NULL, 'DATABASE')
WHERE permission_name IN ('CONTROL', 'ALTER', 'SELECT', 'INSERT', 'UPDATE', 'DELETE')
ORDER BY permission_name;

REVERT;
GO

--Minh họa 2
USE SQL_THTRUEMART;
GO

PRINT N'== QUYỀN TH_BanHang ==';
EXECUTE AS USER = 'TH_BanHang';

-- Được phép tra cứu sản phẩm
SELECT TOP 5 MaSP, TenSP
FROM SANPHAM;

-- Không được phép xem bảng tồn kho
SELECT TOP 5 *
FROM TONKHO;      

-- Không được phép xóa hoá đơn
DELETE FROM HOADON
WHERE 1 = 0;      

REVERT;
GO

--Minh họa 3
USE SQL_THTRUEMART;
GO

PRINT N'== QUYỀN TH_ThuKho ==';
EXECUTE AS USER = 'TH_ThuKho';

-- Được phép thao tác trên phiếu nhập
DELETE FROM PHIEUNHAP
WHERE 1 = 0;      

-- Được phép xem tồn kho
SELECT TOP 5 *
FROM TONKHO;     

-- Không được phép xem hoặc thao tác hoá đơn bán hàng
SELECT TOP 5 *
FROM HOADON;      

REVERT;
GO

--Xem Login hiện tại
USE master;
GO
SELECT 
    SYSTEM_USER              AS LoginHienTai,
    SUSER_SNAME()            AS LoginTrenServer,
    IS_SRVROLEMEMBER('sysadmin') AS LaSysAdmin;

--Chỉnh Login gốc
REVERT;
GO
SELECT ORIGINAL_LOGIN() AS LoginGoc,
       SUSER_SNAME()    AS LoginDangChay;


ALTER TABLE DONHANG ADD DIACHI_GH    NVARCHAR(300);
ALTER TABLE DONHANG ADD TRANGTHAI_DH NVARCHAR(30) DEFAULT N'Chờ xác nhận';
ALTER TABLE DONHANG ADD GHICHU_DH    NVARCHAR(300);
ALTER TABLE SANPHAM ADD TRANGTHAI_SP NVARCHAR(20) DEFAULT N'Đang bán';

-- ================================================================
-- ĐIỀN DỮ LIỆU CHO CÁC CỘT MỚI THÊM
-- Chạy sau khi đã ALTER TABLE xong
-- ================================================================

USE SQL_THTRUEMART;   -- đổi tên DB nếu cần
GO

-- ────────────────────────────────────────────────────────────────
-- 1. SANPHAM.TRANGTHAI_SP
--    Tất cả 50 sản phẩm đều "Đang bán"
-- ────────────────────────────────────────────────────────────────
UPDATE SANPHAM SET TRANGTHAI_SP = N'Đang bán';
GO

-- ────────────────────────────────────────────────────────────────
-- 2. DONHANG.DIACHI_GH
--    Lấy địa chỉ từ bảng KHACHHANG theo MA_KH
-- ────────────────────────────────────────────────────────────────
UPDATE DH
SET DH.DIACHI_GH = KH.DIACHI_KH
FROM DONHANG DH
JOIN KHACHHANG KH ON DH.MA_KH = KH.MA_KH;
GO

-- ────────────────────────────────────────────────────────────────
-- 3. DONHANG.TRANGTHAI_DH
--    Căn cứ theo ngày lập đơn (khớp dữ liệu gốc)
-- ────────────────────────────────────────────────────────────────
UPDATE DONHANG SET TRANGTHAI_DH =
    CASE
        WHEN MA_DH IN ('DH001','DH002','DH003','DH004','DH005',
                       'DH006','DH007','DH008','DH009','DH010',
                       'DH011','DH012','DH013','DH014','DH015',
                       'DH016','DH017','DH018','DH019','DH020',
                       'DH021','DH022','DH023','DH024','DH025',
                       'DH026','DH027','DH028','DH029')
            THEN N'Hoàn thành'
        WHEN MA_DH IN ('DH030','DH031','DH032')
            THEN N'Đã giao'
        WHEN MA_DH IN ('DH033','DH034','DH035')
            THEN N'Đang giao'
        WHEN MA_DH IN ('DH036','DH037')
            THEN N'Đang chuẩn bị'
        WHEN MA_DH IN ('DH038','DH039')
            THEN N'Đã xác nhận'
        ELSE N'Chờ xác nhận'   -- DH040..DH050 và các đơn mới
    END;
GO

-- ────────────────────────────────────────────────────────────────
-- 4. DONHANG.GHICHU_DH
--    Để NULL (khớp dữ liệu gốc, không có ghi chú)
-- ────────────────────────────────────────────────────────────────
UPDATE DONHANG SET GHICHU_DH = NULL;
GO

-- ────────────────────────────────────────────────────────────────
-- KIỂM TRA KẾT QUẢ
-- ────────────────────────────────────────────────────────────────
SELECT MA_DH, DIACHI_GH, TRANGTHAI_DH, GHICHU_DH
FROM DONHANG ORDER BY MA_DH;

SELECT MASP, TENSP, TRANGTHAI_SP
FROM SANPHAM ORDER BY MASP;

-- Sửa GIAMGIA_DH: đổi từ tiền cố định sang phần trăm đúng
-- Chỉ sửa các dòng có giá trị > 100 (đang lưu sai)

UPDATE CT_DH SET GIAMGIA_DH = 10
WHERE MA_DH = 'DH001' AND MASP = 'SP001';   -- "giảm 10%" → 10%

UPDATE CT_DH SET GIAMGIA_DH = 0
WHERE MA_DH = 'DH001' AND MASP = 'SP009';   -- không có ghi chú KM → 0%

UPDATE CT_DH SET GIAMGIA_DH = 10
WHERE MA_DH = 'DH006' AND MASP = 'SP016';   -- "Có KM" → 10%

UPDATE CT_DH SET GIAMGIA_DH = 20
WHERE MA_DH = 'DH008' AND MASP = 'SP007';   -- "KM đặc biệt" → 20%

UPDATE CT_DH SET GIAMGIA_DH = 10
WHERE MA_DH = 'DH009' AND MASP = 'SP009';   -- "Giảm giá phô mai" → 10%

-- Kiểm tra lại
SELECT MA_DH, MASP, SOLUONG_DH, DONGIA_DH, GIAMGIA_DH,
       CAST(SOLUONG_DH * DONGIA_DH * (1.0 - GIAMGIA_DH/100.0) AS DECIMAL(15,2)) AS THANHTIEN_TINH_LAI
FROM CT_DH
ORDER BY MA_DH;

-- Tính lại toàn bộ HOADON từ CT_HD
UPDATE HD SET
    HD.TRIGIATRUOCTHUE    = ISNULL(AGG.TruocThue, 0),
    HD.TONGTIENGIAM       = ISNULL(AGG.TongGiam,  0),
    HD.TRIGIASAUTHUE      = ISNULL((AGG.TruocThue - AGG.TongGiam), 0) * (1 + HD.THUEVAT),
    HD.TONGCONGTHANHTIEN  = ISNULL((AGG.TruocThue - AGG.TongGiam), 0) * (1 + HD.THUEVAT)
FROM HOADON HD
LEFT JOIN (
    SELECT MA_HD,
           SUM(SOLUONG_TRA * DONGIA_HD)                  AS TruocThue,
           SUM(SOLUONG_TRA * DONGIA_HD * PHANTRAMGIAMHD) AS TongGiam
    FROM CT_HD
    GROUP BY MA_HD
) AGG ON HD.MA_HD = AGG.MA_HD;

-- Kiểm tra kết quả HD006
SELECT MA_HD, TRIGIATRUOCTHUE, TONGTIENGIAM, TONGCONGTHANHTIEN
FROM HOADON WHERE MA_HD = 'HD006';
-- Kết quả đúng: 627000 / 12600 / 675840

CREATE OR ALTER TRIGGER trg_CT_HD_SyncHOADON
ON CT_HD
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Gom tất cả MA_HD bị ảnh hưởng
    DECLARE @AffectedHD TABLE (MA_HD CHAR(10));
    INSERT INTO @AffectedHD SELECT DISTINCT MA_HD FROM inserted;
    INSERT INTO @AffectedHD SELECT DISTINCT MA_HD FROM deleted
    WHERE MA_HD NOT IN (SELECT MA_HD FROM @AffectedHD);

    -- Cập nhật HOADON từ CT_HD cho các HD bị ảnh hưởng
    UPDATE HD SET
        HD.TRIGIATRUOCTHUE   = ISNULL(AGG.TruocThue, 0),
        HD.TONGTIENGIAM      = ISNULL(AGG.TongGiam,  0),
        HD.TRIGIASAUTHUE     = ISNULL((AGG.TruocThue - AGG.TongGiam), 0) * (1 + HD.THUEVAT),
        HD.TONGCONGTHANHTIEN = ISNULL((AGG.TruocThue - AGG.TongGiam), 0) * (1 + HD.THUEVAT)
    FROM HOADON HD
    INNER JOIN @AffectedHD AH ON HD.MA_HD = AH.MA_HD
    LEFT JOIN (
        SELECT MA_HD,
               SUM(SOLUONG_TRA * DONGIA_HD)                  AS TruocThue,
               SUM(SOLUONG_TRA * DONGIA_HD * PHANTRAMGIAMHD) AS TongGiam
        FROM CT_HD
        GROUP BY MA_HD
    ) AGG ON HD.MA_HD = AGG.MA_HD;
END;

-- Bước 1: Thêm cột MA_KH vào TAIKHOAN (cho phép NULL vì NV không cần)
ALTER TABLE TAIKHOAN
ADD MA_KH CHAR(10) NULL;

-- Bước 2: Thêm khóa ngoại liên kết sang KHACHHANG
ALTER TABLE TAIKHOAN
ADD CONSTRAINT FK_TAIKHOAN_KHACHHANG
FOREIGN KEY (MA_KH) REFERENCES KHACHHANG(MA_KH);

-- Bước 3: Kiểm tra cấu trúc bảng sau khi sửa
SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'TAIKHOAN'
ORDER BY ORDINAL_POSITION;

-- Kiểm tra TAIKHOAN có cột MA_KH chưa
SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'TAIKHOAN';

-- Cho phép MANV = NULL (dành cho tài khoản khách hàng)
ALTER TABLE TAIKHOAN ALTER COLUMN MANV CHAR(10) NULL;

-- Đặt mật khẩu mặc định '123456' cho tất cả tài khoản chưa có mật khẩu
-- MD5('123456') = e10adc3949ba59abbe56e057f20f883e
UPDATE TAIKHOAN
SET MK = 'e10adc3949ba59abbe56e057f20f883e'
WHERE MK IS NULL OR MK = '';

-- Xóa hết hash cũ, đặt lại tất cả về 123456 plain text
UPDATE TAIKHOAN SET MK = '123456';

-- Xóa hết hash cũ, đặt lại tất cả về 123456 plain text
UPDATE TAIKHOAN SET MK = '123456';