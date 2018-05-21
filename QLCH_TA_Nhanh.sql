
---------------------------------------------
-- NHANVIEN
CREATE TABLE NHANVIEN(
	MANV	char(10) not null,	
	HOTEN	varchar(40) ,
	SODT	varchar(20),
	NGVL	smalldatetime,
	MALOAI_NV char(10),
	constraint pk_nv primary key(MANV)
)

----------------------------------------------
--MONAN
CREATE TABLE MONAN(
	MAMA	char(10) not null ,
	TENMA	NVARCHAR(100),
	GIATIEN	money,
	MALOAI_MA char(10) ,
	constraint pk_ma primary key(MAMA)
)

---------------------------------------------
--CTMA
CREATE TABLE CTMA(
	MAMA	char(10) ,
	MATP	char(10),
	constraint pk_ctma primary key(MAMA,MATP)
)

---------------------------------------------
--PHIEU_YEUCAU
   CREATE TABLE PHIEU_YC(
	MAPHIEU_YC		char(10) not null,
	NGYC 		smalldatetime,
	MABA		char(10),
	MANV		char(10),
	constraint pk_pyc primary key(MAPHIEU_YC)
)

---------------------------------------------
--CT_PHIEU_YC
   CREATE TABLE CT_PHIEU_YC(
	MAPHIEU_YC		char(10),
	MAMA		char(10),
	SL			int,
	constraint pk_ctpyc primary key(MAPHIEU_YC,MAMA)
)

---------------------------------------------
--BANAN 
CREATE TABLE BANAN
(
	MABA  char(10) not null,
	TENBA NVARCHAR(100) ,
	TRANGTHAI NVARCHAR(100), 	
	constraint pk_ba primary key(MABA)
)

---------------------------------------------
-- HOADON
CREATE TABLE HOADON(
	MAHD	char(10) not null,
	NGHD 	smalldatetime,
	MANV 	char(10),
	MABA	char(10) ,
	THANHTIEN	money,
	constraint pk_hd primary key(MAHD)
)

---------------------------------------------
-- CTHD
   CREATE TABLE CTHD(
	MAHD	char(10),
	MAMA	char(10),
	SL		int,
	DONGIA	money,
	constraint pk_cthd primary key(MAHD,MAMA)
)

---------------------------------------------
-- THUCPHAM
CREATE TABLE THUCPHAM(
	MATP	char(10) not null,
	TENTP	varchar(40),
	GIA	money,
	DONVI varchar(20),
	MANPP char(10),
	constraint pk_tp primary key(MATP)	
)

---------------------------------------------
--NHAPHANPHOI
CREATE TABLE NHAPHANPHOI(
	MANPP	char(10) not null ,	
	TENNPP	varchar(40) ,	
	DIACHI	varchar(100)
	constraint pk_npp primary key(MANPP)
)

---------------------------------------------
--PHIEUNHAP_TP
   CREATE TABLE PHIEUNHAP_TP(
	MAPHIEU		char(10) not null,
	NGNHAP 		smalldatetime,
	MANPP		char(10),
	MANV		char(10),
	THANHTIEN	MONEY,
	constraint pk_pntp primary key(MAPHIEU)
)

---------------------------------------------
--CT_PHIEUNHAP_TP
   CREATE TABLE CT_PHIEUNHAP_TP(
	MAPHIEU		char(10),
	MATP		char(10),
	SL			int,
	DONGIA		money,
	constraint pk_ctpntp primary key(MAPHIEU,MATP)
)

---------------------------------------------
--LOAINHANVIEN
CREATE TABLE LOAINHANVIEN(
	MALOAI_NV CHAR(10),
	TENLOAI_NV varchar(40),
	constraint pk_loainv primary key(MALOAI_NV)
)

---------------------------------------------
--LOAIMONAN
CREATE TABLE LOAIMONAN(
	MALOAI_MA CHAR(10),
	TENLOAI_MA varchar(40),
	constraint pk_loaima primary key(MALOAI_MA)
)

---------------------------------------------
--TAIKHOAN
CREATE TABLE TAIKHOAN(
	MANV char(10) NOT NULL,
	TENDANGNHAP varchar(40),
	MATKHAU varchar(40),
	constraint pk_taikhoan primary key(MANV)
)
-- Khoa ngoai cho bang HOADON
ALTER TABLE HOADON ADD CONSTRAINT fk01_HD FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)
ALTER TABLE HOADON ADD CONSTRAINT fk02_HD FOREIGN KEY(MABA) REFERENCES BANAN(MABA)
-- Khoa ngoai cho bang MONAN
ALTER TABLE MONAN ADD CONSTRAINT fk01_MA FOREIGN KEY(MALOAI_MA) REFERENCES LOAIMONAN(MALOAI_MA)
-- Khoa ngoai cho bang NHANVIEN
ALTER TABLE NHANVIEN ADD CONSTRAINT fk01_NV FOREIGN KEY(MALOAI_NV) REFERENCES LOAINHANVIEN(MALOAI_NV)
-- Khoa ngoai cho bang CTHD
ALTER TABLE CTHD ADD CONSTRAINT fk01_CTHD FOREIGN KEY(MAHD) REFERENCES HOADON(MAHD)
ALTER TABLE CTHD ADD CONSTRAINT fk02_CTHD FOREIGN KEY(MAMA) REFERENCES MONAN(MAMA)
-- Khoa ngoai cho bang CTMA
ALTER TABLE CTMA ADD CONSTRAINT fk01_CTMA FOREIGN KEY(MAMA) REFERENCES MONAN(MAMA)
ALTER TABLE CTMA ADD CONSTRAINT fk02_CTMA FOREIGN KEY(MATP) REFERENCES THUCPHAM(MATP)
-- Khoa ngoai cho bang PHIEU_YC
ALTER TABLE  PHIEU_YC ADD CONSTRAINT fk01_PHIEU_YC FOREIGN KEY(MABA) REFERENCES BANAN(MABA)
ALTER TABLE  PHIEU_YC ADD CONSTRAINT fk02_PHIEU_YC FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)
-- Khoa ngoai cho bang CT_PHIEUYC
ALTER TABLE  CT_PHIEU_YC ADD CONSTRAINT fk01_CT_PHIEU_YC FOREIGN KEY(MAPHIEU_YC) REFERENCES  PHIEU_YC(MAPHIEU_YC)
ALTER TABLE CT_PHIEU_YC ADD CONSTRAINT fk02_CT_PHIEU_YC FOREIGN KEY(MAMA) REFERENCES MONAN(MAMA)
-- Khoa ngoai cho bang THUCPHAM
ALTER TABLE THUCPHAM ADD CONSTRAINT fk01_TP FOREIGN KEY(MANPP) REFERENCES NHAPHANPHOI(MANPP)
-- Khoa ngoai cho bang PHIEUNHAP_TP
ALTER TABLE PHIEUNHAP_TP ADD CONSTRAINT fk01_PHIEUNHAP_TP FOREIGN KEY(MANPP) REFERENCES NHAPHANPHOI(MANPP)
ALTER TABLE PHIEUNHAP_TP ADD CONSTRAINT fk02_PHIEUNHAP_TP FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)
-- Khoa ngoai cho bang CT_PHIEUNHAP_TP
ALTER TABLE CT_PHIEUNHAP_TP ADD CONSTRAINT fk01_CT_PHIEUNHAP_TP FOREIGN KEY(MAPHIEU) REFERENCES PHIEUNHAP_TP(MAPHIEU)
ALTER TABLE CT_PHIEUNHAP_TP ADD CONSTRAINT fk02_CT_PHIEUNHAP_TP FOREIGN KEY(MATP) REFERENCES THUCPHAM(MATP)
-- Khoa ngoai cho bang TAIKHOAN
ALTER TABLE TAIKHOAN ADD CONSTRAINT fk01_TAIKHOAN FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)

-------------------------------
-- LOAINHANVIEN
insert into LOAINHANVIEN values('LNV01','addmin')
insert into LOAINHANVIEN values('LNV02','nhanvien')

-------------------------------
-- NHANVIEN
insert into nhanvien values('NV01','Nguyen Nhu Nhut','927345678',13/04/2006,'LNV01')
insert into nhanvien values('NV02','Le Thi Phi Yen','987567390',21/04/2006,'LNV02')
insert into nhanvien values('NV03','Nguyen Van B','997047382',27/04/2006,'LNV02')
insert into nhanvien values('NV04','Ngo Thanh Tuan','913758498',24/06/2006,'LNV02')
insert into nhanvien values('NV05','Nguyen Thi Truc Thanh','918590387',20/07/2006,'LNV02')

-------------------------------
--NHAPHANPHOI
insert into NHAPHANPHOI values('NPP01','Tiệm bánh mì Oppa','74 Võ Văn Ngân, Thủ Đức, HCM')
insert into NHAPHANPHOI values('NPP02','Xưởng nem, Lạp xưởng Hoa Mai','170 Đặng Văn Bi, Bình Thọ, Thủ Đức, HCM')
insert into NHAPHANPHOI values('NPP03','Đại lí phân phối kem Q2 collagen','115  Đường số 8, Phường 11, Gò Vấp, HCM')
insert into NHAPHANPHOI values('NPP04','Nhà phân phối nước giải khát Phú Đức','37 Lý Thường Kiệt, Hóc Môn, HCM')
insert into NHAPHANPHOI values('NPP05','Cửa hàng thịt heo Thanh Thảo','Đường 154,phường Tân Phú, quận 9, HCM')
insert into NHAPHANPHOI values('NPP06','Cửa hàng rau củ quả Hà Anh','60A Đường 4,phường Linh Xuân, quận Thủ Đức, HCM')

-------------------------------
-- LOAIMONAN
insert into LOAIMONAN values('LMA01','thức ăn ngọt')
insert into LOAIMONAN values('LMA02','thức ăn mặn')
insert into LOAIMONAN values('LMA03','nước giải khát')
insert into LOAIMONAN values('LMA04','kem')

-------------------------------
-- MONAN
insert into MONAN values('MA01','Hamburger',25000,'LMA02')
insert into MONAN values('MA02','Sandwich',20000,'LMA02')
insert into MONAN values('MA03','Bánh mì ngọt',15000,'LMA01')
insert into MONAN values('MA04','Nem nướng',25000,'LMA02')
insert into MONAN values('MA05','Nước Soda',25000,'LMA03')
insert into MONAN values('MA06','Nước nha dam',18000,'LMA03')
insert into MONAN values('MA07','kem Tràng Tiền',20000,'LMA04')
insert into MONAN values('MA08','kem Ốc Quế',15000,'LMA04')
insert into MONAN values('MA09','kem dừa',15000,'LMA04')
insert into MONAN values('MA010','kem que',15000,'LMA04')

-------------------------------
--THUCPHAM
insert into THUCPHAM values('TP01','bánh mì mềm',10000,'cái','NPP01')
insert into THUCPHAM values('TP02','bánh mì ngọt',10000,'cái','NPP01')
insert into THUCPHAM values('TP03','Nước Soda',20000,'chai','NPP04')
insert into THUCPHAM values('TP04','Nước nha dam',15000,'chai','NPP04')
insert into THUCPHAM values('TP05','rau xà lách',10000,'kg','NPP06')
insert into THUCPHAM values('TP06','thịt heo',100000,'kg','NPP05')
insert into THUCPHAM values('TP07','nem',10000,'cái','NPP02')
insert into THUCPHAM values('TP08','kem',50000,'kg','NPP03')
insert into THUCPHAM values('TP09','bánh ốc quế',1000,'cái','NPP03')
insert into THUCPHAM values('TP010','kem Tràng Tiền',15000,'cái','NPP03')
insert into THUCPHAM values('TP011','kem dừa',10000,'cái','NPP03')
insert into THUCPHAM values('TP012','kem que',10000,'cái','NPP03')

---------------------------------------------
--CTMA
insert into CTMA values('MA01','TP01')
insert into CTMA values('MA01','TP02')
insert into CTMA values('MA01','TP03')
insert into CTMA values('MA02','TP01')
insert into CTMA values('MA02','TP02')
insert into CTMA values('MA02','TP03')
insert into CTMA values('MA03','TP02')
insert into CTMA values('MA04','TP07')
insert into CTMA values('MA05','TP03')
insert into CTMA values('MA06','TP04')
insert into CTMA values('MA07','TP010')
insert into CTMA values('MA07','TP06')
insert into CTMA values('MA08','TP08')
insert into CTMA values('MA08','TP09')
insert into CTMA values('MA09','TP011')
insert into CTMA values('MA010','TP012')

-------------------------------
--BANAN
insert into BANAN values('MABA01','bàn 1','trống')
insert into BANAN values('MABA02','bàn 2','trống')
insert into BANAN values('MABA03','bàn 3','trống')
insert into BANAN values('MABA04','bàn 4','trống')
insert into BANAN values('MABA05','bàn 5','trống')
insert into BANAN values('MABA06','bàn 6','trống')
insert into BANAN values('MABA07','bàn 7','trống')
insert into BANAN values('MABA08','bàn 8','trống')


---------------------------------------------
--PHIEU_YEUCAU
insert into PHIEU_YC values('MYC01',13/02/2007,'MABA01','NV01')
insert into PHIEU_YC values('MYC02',14/02/2007,'MABA02','NV01')
insert into PHIEU_YC values('MYC03',15/02/2007,'MABA04','NV02')

---------------------------------------------
--CT_PHIEU_YC
insert into CT_PHIEU_YC values('MYC01','MA01',1)
insert into CT_PHIEU_YC values('MYC01','MA06',1)
insert into CT_PHIEU_YC values('MYC02','MA01',2)
insert into CT_PHIEU_YC values('MYC03','MA04',1)
insert into CT_PHIEU_YC values('MYC03','MA01',4)
insert into CT_PHIEU_YC values('MYC03','MA010',4)

-------------------------------
--HOADON
insert into HOADON values('HD01',14/02/2007,'NV01','MABA01',43000)
insert into HOADON values('HD02',14/02/2007,'NV02','MABA02',50000)
insert into HOADON values('HD03',14/02/2007,'NV03',null,75000)
insert into HOADON values('HD04',15/02/2007,'NV03','MABA04',160000)

-------------------------------
-- CTHD
insert into CTHD values('HD01','MA01',1,25000)
insert into CTHD values('HD01','MA06',1,18000)
insert into CTHD values('HD02','MA01',2,25000)
insert into CTHD values('HD03','MA04',1,25000)
insert into CTHD values('HD03','MA07',1,20000)
insert into CTHD values('HD03','MA09',2,15000)
insert into CTHD values('HD04','MA01',4,25000)
insert into CTHD values('HD04','MA010',4,15000)

-------------------------------
--PHIEUNHAP_TP(
insert into PHIEUNHAP_TP values('PN01',20/01/2007,'NPP01','NV03',1000000)
insert into PHIEUNHAP_TP values('PN02',27/01/2007,'NPP03','NV05',500000)
insert into PHIEUNHAP_TP values('PN03',09/02/2007,'NPP04','NV04',500000)

-------------------------------
--CT_PHIEUNHAP_TP
insert into CT_PHIEUNHAP_TP values('PN01','TP01',50,10000)
insert into CT_PHIEUNHAP_TP values('PN01','TP02',50,10000)
insert into CT_PHIEUNHAP_TP values('PN02','TP08',4,50000)
insert into CT_PHIEUNHAP_TP values('PN02','TP011',30,10000)
insert into CT_PHIEUNHAP_TP values('PN03','TP03',10,20000)
insert into CT_PHIEUNHAP_TP values('PN03','TP04',20,15000)

-------------------------------
--TAIKHOAN
insert into TAIKHOAN values('nv01','addmin','addmin')
insert into TAIKHOAN values('nv02','2','2')
insert into TAIKHOAN values('nv03','3','3')

select * from PHIEUNHAP_TP