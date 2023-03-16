create database TramYTe
go
use TramYTe
go

create table KhuPho
(
	MaKhuPho varchar(50) primary key,
	TenKhuPho nvarchar(100),
)

create table HoGiaDinh
(
	MaHo varchar(50) primary key,
	DiaChi nvarchar(150),
	Email varchar(max),
	MaKhuPho varchar(50)

	CONSTRAINT FK_HoGiaDinh_KhuPho FOREIGN KEY (MaKhuPho) REFERENCES KhuPho(MaKhuPho)
)

create table TaiKhoanDangNhap
(
	TaiKhoan varchar(50) primary key,
	MatKhau varchar(50),
	MaHo varchar(50),
	Quyen varchar(5) 

	CONSTRAINT FK_TaiKhoanDangNhap_HoGiaDinh FOREIGN KEY (MaHo) REFERENCES HoGiaDinh(MaHo)
)

create table ThanhVien
(
	MaThanhVien varchar(50) primary key,
	HoTen nvarchar(150),
	NgaySinh date,
	GioiTinh nvarchar(3),
	DienThoai varchar(10),
	CCCD varchar(12),
	MaHo varchar(50),
	LichSuBenhAn nvarchar(max)

	CONSTRAINT FK_ThanhVien_HoGiaDinh FOREIGN KEY (MaHo) REFERENCES HoGiaDinh(MaHo)
)

create table ThongBao
(
	MaThongBao int identity primary key,
	TenThongBao nvarchar(300),
	NoiDung nvarchar(max),
	ThoiGianGui date,
	MaHo varchar(50)

	CONSTRAINT FK_ThongBao_HoGiaDinh FOREIGN KEY (MaHo) REFERENCES HoGiaDinh(MaHo)
)

create table Vaccine
(
	MaVaccine varchar(50) primary key,
	TenVaccine nvarchar(200),
	MaLo varchar(50),
	SoLuong int,
	NhaSanXuat nvarchar(max),
	SoLuongDeXuat int,
	NgaySanXuat date,
	HanSuDung int,
	ChuKyTiem int
)

create table TiemChung
(
	MaPhieuTiemChung varchar(50) primary key,
	MaVaccine varchar(50),
	SoLuong int,
	NgayTiem date,
	TrieuChungSauTiem nvarchar(max),
	MaThanhVien varchar(50),
	TrangThai BIT NOT NULL DEFAULT 0

	CONSTRAINT FK_TiemChung_Vaccine FOREIGN KEY (MaVaccine) REFERENCES Vaccine(MaVaccine),
	CONSTRAINT FK_TiemChung_ThanhVien FOREIGN KEY (MaThanhVien) REFERENCES ThanhVien(MaThanhVien)
)

create table DinhDuong
(
	MaPhieuDinhDuong varchar(50) primary key,
	ChieuCao float,
	CanNang float,
	NgayKham date,
	MaThanhVien varchar(50)

	CONSTRAINT FK_DinhDuong_ThanhVien FOREIGN KEY (MaThanhVien) REFERENCES ThanhVien(MaThanhVien),
)

create table ThaiKy
(
	MaPhieuKhamThai varchar(50) primary key,
	CanNang float,
	NgayMangThai date,
	NgayKham date,
	MaThanhVien varchar(50),
	NgayTaiKham date

	CONSTRAINT FK_ThaiKy_ThanhVien FOREIGN KEY (MaThanhVien) REFERENCES ThanhVien(MaThanhVien),
)

create table PhongKham
(
	MaPhongKham varchar(50) primary key,
	TenPhongKham nvarchar(200),
	NoiDung nvarchar(max),
	MaThanhVien varchar(50)

	CONSTRAINT FK_PhongKham_ThanhVien FOREIGN KEY (MaThanhVien) REFERENCES ThanhVien(MaThanhVien),
)

create table LichTiemVaccine
(
	MaLichTiem int identity primary key,
	NgayTiem date,
	NoiDung nvarchar(max)
)

create table TreSuyDinhDuong
(
	GioiTinh nvarchar(3),
	ThangTuoi int,
	CanNang float
)

create table TreBeoPhi
(
	GioiTinh nvarchar(3),
	ThangTuoi int,
	CanNang float
)

-----------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------

-- Tạo khu phố
insert into KhuPho (MaKhuPho, TenKhuPho) values
('KP1', N'Khu phố 1'),
('KP2', N'Khu phố 2'),
('KP3', N'Khu phố 3')


-- Tạo hộ gia đình
insert into HoGiaDinh (MaHo, DiaChi, Email, MaKhuPho) values
('H1', N'1 Lê Văn Sỹ', 'thienthansaokim2001@gmail.com','KP1'),
('H2', N'2 Lê Văn Sỹ', 'vantrung060101@gmail.com','KP1'),
('H3', N'10 Lê Văn Sỹ', 'huyquang.hn8@gmail.com','KP2'),
('H4', N'11 Lê Văn Sỹ', 'giadinh4@gmail.com','KP2'),
('H5', N'12 Lê Văn Sỹ', 'giadinh5@gmail.com','KP2'),
('H6', N'13 Lê Văn Sỹ', 'giadinh6@gmail.com','KP2'),
('H7', N'10 Lê Văn Sỹ', 'giadinh7@gmail.com','KP3'),
('H8', N'11 Lê Văn Sỹ', 'giadinh8@gmail.com','KP3'),
('H9', N'12 Lê Văn Sỹ', 'giadinh9@gmail.com','KP3')


-- Tạo tài khoản cho admin
insert into TaiKhoanDangNhap (TaiKhoan, MatKhau, Quyen) values
('ad','123', 'admin')
-- Tạo tài khoản cho hộ gia đình
insert into TaiKhoanDangNhap (TaiKhoan, MatKhau, MaHo, Quyen) values
('user', '123', 'H1', 'user'),
('fam1', '123', 'H1', 'user'),
('fam2', '123', 'H2', 'user'),
('fam3', '123', 'H3', 'user'),
('fam4', '123', 'H4', 'user'),
('fam5', '123', 'H5', 'user'),
('fam6', '123', 'H6', 'user'),
('fam7', '123', 'H7', 'user'),
('fam8', '123', 'H8', 'user'),
('fam9', '123', 'H9', 'user')


-- Tạo thành viên
insert into ThanhVien(MaThanhVien, HoTen, NgaySinh, GioiTinh, DienThoai, CCCD, MaHo, LichSuBenhAn) values
('TV001', N'Nguyễn Mỹ Tuyến', '1987/10/5', N'Nữ', '090000001', '067231014526', 'H1', N'Tiểu đường, Béo phì'),
('TV002', N'Trần Minh Thanh', '1982/1/25', N'Nam', '090000002', '032201447904', 'H1', N'Viêm gan'),
('TV005', N'Trần Trung Định', '1979/11/5', N'Nam', '090000005', '084547812013', 'H2', N'Suy giảm miễn dịch'),
('TV008', N'Đoàn Thị Mai Uyên', '1987/1/30', N'Nữ', '090000008', '052033192154', 'H3', N'Dị ứng nặng'),
('TV009', N'Phạm Thị Xuân Mai', '1986/9/28', N'Nữ', '090000009', '090645362234', 'H3', N'Tăng huyết áp'),
('TV010', N'Nguyễn Bao Công', '1981/8/19', N'Nam', '090000010', '055328732101', 'H3', N'Bệnh tim'),
('TV014', N'Từ Ngọc Trí', '1985/9/27', N'Nam', '090000014', '088958194012', 'H4', N'Bệnh thận, Bệnh phổi'),
('TV015', N'Vũ Khánh Tình Vân', '1989/3/3', N'Nữ', '090000015', '092211114821', 'H4', N'Suy giảm chức năng gan')
insert into ThanhVien(MaThanhVien, HoTen, NgaySinh, GioiTinh, DienThoai, CCCD, MaHo) values
('TV003', N'Phạm Hữu Trang Nhã', '1990/7/12', N'Nữ', '090000003', '082142556301', 'H1'),
('TV004', N'Trần Thị Bích Trâm', '1985/5/22', N'Nữ', '090000004', '041710921669', 'H1'),
('TV006', N'Báo Tăng Tuy', '1983/4/17', N'Nam', '090000006', '087987341012', 'H2'),
('TV007', N'Trần Văn Thanh', '1988/10/2', N'Nam', '090000007', '096100057899', 'H2'),
('TV011', N'Phùng Anh Đức', '1990/2/1', N'Nam', '090000011', '009099871653', 'H3'),
('TV012', N'Huỳnh Phan Nguyên', '1986/6/6', N'Nam', '090000012', '040101013934', 'H3'),
('TV013', N'Nguyễn Thị Minh Thanh', '1984/4/4', N'Nữ', '090000013', '013711889760', 'H3'),
('TV016', N'Hà Tiến Dũng', '1991/11/11', N'Nam', '090000016', '045678990123', 'H4'),
('TV017', N'Khư Lam Cảnh', '1984/2/24', N'Nam', '090000017', '005231023405', 'H4'),
('TV018', N'Đặng Văn Trung', '1988/12/8', N'Nam', '090000018', '020073468935', 'H4')
-- Tạo thành viên trẻ em
insert into ThanhVien(MaThanhVien, HoTen, NgaySinh, GioiTinh, MaHo) values
('TV019', N'Nguyễn Văn Anh', '2019-03-07', N'Nam', 'H1'),
('TV020', N'Trần Thị Bích', '2019-02-01', N'Nữ', 'H1'),
('TV021', N'Lê Văn Chí', '2020-05-12', N'Nam', 'H2'),
('TV022', N'Phạm Thị Hoa', '2021-01-15', N'Nữ', 'H2'),
('TV023', N'Võ Văn Tần', '2019-11-25', N'Nam', 'H3'),
('TV024', N'Đỗ Thị Mỹ', '2019-06-10', N'Nữ', 'H3'),
('TV025', N'Hoàng Văn Giàu', '2019-09-18', N'Nam', 'H4'),
('TV026', N'Nguyễn Thị Hồng Nhung', '2020-08-07', N'Nữ', 'H4'),
('TV027', N'Trương Văn Nhân', '2021-02-19', N'Nam', 'H1'),
('TV028', N'Phan Thị Tuyết Mai', '2019-12-05', N'Nữ', 'H1');



-- Tạo thông báo có sẵn
insert into ThongBao(TenThongBao, NoiDung , ThoiGianGui, MaHo) values
(N'Lịch tiêm Vaccine', N'Kính mời anh Trần Minh Thanh đến Trạm y tế vào ngày 20/03/2023 đển tiến hành tiêm Vaccine Sinovac', '2023-03-07', 'H1'),
(N'Lịch tiêm Vaccine', N'Kính mời chị Nguyễn Mỹ Tuyến đến Trạm y tế vào ngày 20/03/2023 đển tiến hành tiêm Vaccine Sinovac', '2023-03-07', 'H1'),
(N'Lịch tiêm Vaccine', N'Kính mời anh Báo Tăng Tuy đến Trạm y tế vào ngày 20/03/2023 đển tiến hành tiêm Vaccine Moderna', '2023-03-07', 'H2')


-- Tạo vaccine có sẵn
insert into Vaccine(MaVaccine, TenVaccine, MaLo, SoLuong, NhaSanXuat, SoLuongDeXuat, NgaySanXuat, HanSuDung, ChuKyTiem) values
('VAC001', 'Pfizer-BioNTech', 'LOT0001', 1000, 'Pfizer', 5000, '2023-03-01', 180, 21),
('VAC002', 'Moderna', 'LOT0002', 500, 'Moderna', 3000, '2023-03-01', 180, 28),
('VAC003', 'Johnson & Johnson', 'LOT0003', 2000, 'Johnson & Johnson', 10000, '2023-03-01', 90, 0),
('VAC004', 'AstraZeneca', 'LOT0004', 1500, 'AstraZeneca', 8000, '2023-03-01', 180, 70),
('VAC005', 'Sinovac', 'LOT0005', 800, 'Sinovac', 4000, '2023-03-01', 730, 21)


-- Tạo tiêm chủng có sẵn
insert into TiemChung(MaPhieuTiemChung, MaVaccine, SoLuong, NgayTiem, MaThanhVien, TrangThai) values
('TC001', 'VAC001', 1, '2022-02-28', 'TV001', 0),
('TC002', 'VAC002', 1, '2022-03-01', 'TV005', 0),
('TC003', 'VAC003', 1, '2022-03-01', 'TV007', 1),
('TC004', 'VAC004', 1, '2022-03-02', 'TV011', 0),
('TC005', 'VAC005', 1, '2022-03-02', 'TV012', 0)


-- Tạo dinh dưỡng có sẵn
insert into DinhDuong(MaPhieuDinhDuong, ChieuCao, CanNang, NgayKham, MaThanhVien) values
('DD001', 165, 58, '2022-02-28', 'TV001'),
('DD002', 170, 65, '2022-03-01', 'TV005'),
('DD003', 160, 55, '2022-03-01', 'TV007'),
('DD004', 175, 70, '2022-03-02', 'TV011'),
('DD005', 180, 75, '2022-03-02', 'TV012')
-- Tạo dinh dưỡng trẻ em có sẵn
insert into DinhDuong(MaPhieuDinhDuong, ChieuCao, CanNang, NgayKham, MaThanhVien) values
('DD006', 99, 16.3, '2023-03-07', 'TV019'), --trẻ bình thường (nam)
('DD007', 102, 16.1, '2023-03-07', 'TV020'), --trẻ bình thường (nữ)
('DD008', 88, 13.3, '2023-03-07', 'TV021'), --trẻ bình thường (nam)
('DD009', 86, 9, '2023-03-07', 'TV022'), --trẻ suy dinh dưỡng (nữ)
('DD010', 92, 14.3, '2023-03-07', 'TV023'), --trẻ bình thường (nam)
('DD011', 99, 20, '2023-03-07', 'TV024'), --trẻ béo phì (nữ)
('DD012', 92, 18.5, '2023-03-07', 'TV025'), --trẻ béo phì (nam)
('DD013', 90, 16.5, '2023-03-07', 'TV026'), --trẻ béo phì (nữ)
('DD014', 50, 3, '2023-03-07', 'TV027'), --trẻ suy dinh dưỡng (nam)
('DD015', 94, 10.5, '2023-03-07', 'TV028')  --trẻ béo phì (nữ)


-- Tạo khám thai có sẵn
insert into ThaiKy(MaPhieuKhamThai, CanNang, NgayMangThai, NgayKham, MaThanhVien) values
('TK0001', 0.8, '2022-08-10', '2023-02-28', 'TV001'),
('TK0002', 0.5, '2022-09-05', '2023-03-01', 'TV008'),
('TK0003', 0.6, '2022-10-01', '2023-03-01', 'TV004'),
('TK0004', 0.5, '2022-11-15', '2023-03-02', 'TV003'),
('TK0005', 0.9, '2022-12-20', '2023-03-02', 'TV015')


-- Tạo phòng khám
insert into PhongKham(MaPhongKham, TenPhongKham, NoiDung, MaThanhVien) values
('PK001', N'Phòng Khám Đa Khoa', N'Phòng 5 tầng 2. Chuyên môn nội khoa. Khám các bệnh lý nội khoa', 'TV007'),
('PK002', N'Phòng Khám Răng Hàm Mặt', N'Phòng 3 tầng 2. Chuyên môn răng hàm mặt. Khám và chữa các bệnh lý về răng hàm mặt', 'TV004'),
('PK003', N'Phòng Khám Tai Mũi Họng', N'Phòng 1, tầng 3. Chuyên môn tai mũi họng. Khám và điều trị các bệnh lý tai mũi họng', 'TV017'),
('PK004', N'Phòng Khám Da Liễu', N'Phòng 3, tầng 3. Chuyên môn da liễu. Khám và chữa các bệnh lý về da', 'TV011'),
('PK005', N'Phòng Khám Sản Phụ Khoa', N'Phòng 4, tầng 3. Chuyên môn sản phụ khoa. Khám và điều trị các bệnh lý sản phụ khoa', 'TV012')


-- Tạo lịch khám
insert into LichTiemVaccine(NgayTiem, NoiDung) values
('2023-03-20', N'Tiêm Vaccine ngừa Covid-19 lần 4 cho khu phố 1'),
('2023-03-25', N'Tiêm Vaccine ngừa Covid-19 lần 4 cho khu phố 2'),
('2023-03-30', N'Tiêm Vaccine ngừa Covid-19 lần 4 cho khu phố 3')


-- Tạo bảng tăng trưởng trẻ suy dinh dưỡng
insert into TreSuyDinhDuong(GioiTinh, ThangTuoi, CanNang) values
(N'Nữ', 0, 2.4),
(N'Nữ', 1, 3.2),
(N'Nữ', 2, 4.0),
(N'Nữ', 3, 4.6),
(N'Nữ', 4, 5.1),
(N'Nữ', 5, 5.5),
(N'Nữ', 6, 5.8),
(N'Nữ', 7, 6.1),
(N'Nữ', 8, 6.3),
(N'Nữ', 9, 6.6),
(N'Nữ', 10, 6.8),
(N'Nữ', 11, 7.0),
(N'Nữ', 12, 7.1),
(N'Nữ', 13, 7.3),
(N'Nữ', 14, 7.5),
(N'Nữ', 15, 7.7),
(N'Nữ', 16, 7.8),
(N'Nữ', 17, 8.0),
(N'Nữ', 18, 8.2),
(N'Nữ', 19, 8.3),
(N'Nữ', 20, 8.5),
(N'Nữ', 21, 8.7),
(N'Nữ', 22, 8.8),
(N'Nữ', 23, 9.0),
(N'Nữ', 24, 9.2),
(N'Nữ', 25, 9.3),
(N'Nữ', 26, 9.4),
(N'Nữ', 27, 9.5),
(N'Nữ', 28, 9.6),
(N'Nữ', 29, 9.7),
(N'Nữ', 30, 10.1),
(N'Nữ', 31, 10.2),
(N'Nữ', 32, 10.3),
(N'Nữ', 33, 10.4),
(N'Nữ', 34, 10.5),
(N'Nữ', 35, 10.6),
(N'Nữ', 36, 11.0),
(N'Nữ', 37, 11.1),
(N'Nữ', 38, 11.2),
(N'Nữ', 39, 11.3),
(N'Nữ', 40, 11.4),
(N'Nữ', 41, 11.5),
(N'Nữ', 42, 11.8),
(N'Nữ', 43, 11.9),
(N'Nữ', 44, 12),
(N'Nữ', 45, 12.1),
(N'Nữ', 46, 12.2),
(N'Nữ', 47, 12.3),
(N'Nữ', 48, 12.5),
(N'Nữ', 49, 12.6),
(N'Nữ', 50, 12.7),
(N'Nữ', 51, 12.8),
(N'Nữ', 52, 12.9),
(N'Nữ', 53, 13),
(N'Nữ', 54, 13.2),
(N'Nữ', 55, 13.3),
(N'Nữ', 56, 13.4),
(N'Nữ', 57, 13.5),
(N'Nữ', 58, 13.6),
(N'Nữ', 59, 13.7),
(N'Nữ', 60, 14.0),
(N'Nam', 0, 2.5),
(N'Nam', 1, 3.4),
(N'Nam', 2, 4.4),
(N'Nam', 3, 5.1),
(N'Nam', 4, 5.6),
(N'Nam', 5, 6.1),
(N'Nam', 6, 6.4),
(N'Nam', 7, 6.7),
(N'Nam', 8, 7.0),
(N'Nam', 9, 7.2),
(N'Nam', 10, 7.5),
(N'Nam', 11, 7.7),
(N'Nam', 12, 7.8),
(N'Nam', 13, 8.0),
(N'Nam', 14, 8.2),
(N'Nam', 15, 8.4),
(N'Nam', 16, 8.5),
(N'Nam', 17, 8.7),
(N'Nam', 18, 8.9),
(N'Nam', 19, 9.0),
(N'Nam', 20, 9.2),
(N'Nam', 21, 9.3),
(N'Nam', 22, 9.5),
(N'Nam', 23, 9.7),
(N'Nam', 24, 9.8),
(N'Nam', 25, 9.9),
(N'Nam', 26, 10),
(N'Nam', 27, 10.1),
(N'Nam', 28, 10.2),
(N'Nam', 29, 10.3),
(N'Nam', 30, 10.7),
(N'Nam', 31, 10.8),
(N'Nam', 32, 10.9),
(N'Nam', 33, 11),
(N'Nam', 34, 11.1),
(N'Nam', 35, 11.2),
(N'Nam', 36, 11.4),
(N'Nam', 37, 11.5),
(N'Nam', 38, 11.6),
(N'Nam', 39, 11.7),
(N'Nam', 40, 11.8),
(N'Nam', 41, 11.9),
(N'Nam', 42, 12.2),
(N'Nam', 43, 12.3),
(N'Nam', 44, 12.4),
(N'Nam', 45, 12.5),
(N'Nam', 46, 12.6),
(N'Nam', 47, 12.7),
(N'Nam', 48, 12.9),
(N'Nam', 49, 13),
(N'Nam', 50, 13.1),
(N'Nam', 51, 13.2),
(N'Nam', 52, 13.3),
(N'Nam', 53, 13.4),
(N'Nam', 54, 13.6),
(N'Nam', 55, 13.7),
(N'Nam', 56, 13.8),
(N'Nam', 57, 13.9),
(N'Nam', 58, 14),
(N'Nam', 59, 14.1),
(N'Nam', 60, 14.3)

-- Tạo bảng tăng trưởng trẻ béo phì
insert into TreBeoPhi(GioiTinh, ThangTuoi, CanNang) values
(N'Nữ', 0, 4.2),
(N'Nữ', 1, 5.4),
(N'Nữ', 2, 6.5),
(N'Nữ', 3, 7.4),
(N'Nữ', 4, 8.1),
(N'Nữ', 5, 8.7),
(N'Nữ', 6, 9.2),
(N'Nữ', 7, 9.6),
(N'Nữ', 8, 10.0),
(N'Nữ', 9, 10.4),
(N'Nữ', 10, 10.7),
(N'Nữ', 11, 11.0),
(N'Nữ', 12, 11.3),
(N'Nữ', 13, 11.6),
(N'Nữ', 14, 11.9),
(N'Nữ', 15, 12.2),
(N'Nữ', 16, 12.5),
(N'Nữ', 17, 12.7),
(N'Nữ', 18, 13.0),
(N'Nữ', 19, 13.3),
(N'Nữ', 20, 13.5),
(N'Nữ', 21, 13.8),
(N'Nữ', 22, 14.1),
(N'Nữ', 23, 14.3),
(N'Nữ', 24, 14.6),
(N'Nữ', 25, 14.8),
(N'Nữ', 26, 15),
(N'Nữ', 27, 15.2),
(N'Nữ', 28, 15.4),
(N'Nữ', 29, 15.6),
(N'Nữ', 30, 16.2),
(N'Nữ', 31, 16.4),
(N'Nữ', 32, 16.6),
(N'Nữ', 33, 16.8),
(N'Nữ', 34, 17),
(N'Nữ', 35, 17.2),
(N'Nữ', 36, 17.8),
(N'Nữ', 37, 18),
(N'Nữ', 38, 18.2),
(N'Nữ', 39, 18.4),
(N'Nữ', 40, 18.6),
(N'Nữ', 41, 18.8),
(N'Nữ', 42, 19.5),
(N'Nữ', 43, 19.7),
(N'Nữ', 44, 19.9),
(N'Nữ', 45, 20.1),
(N'Nữ', 46, 20.3),
(N'Nữ', 47, 20.5),
(N'Nữ', 48, 21.1),
(N'Nữ', 49, 21.3),
(N'Nữ', 50, 21.5),
(N'Nữ', 51, 21.7),
(N'Nữ', 52, 21.9),
(N'Nữ', 53, 22.1),
(N'Nữ', 54, 22.8),
(N'Nữ', 55, 23),
(N'Nữ', 56, 23.2),
(N'Nữ', 57, 23.4),
(N'Nữ', 58, 23.6),
(N'Nữ', 59, 23.8),
(N'Nữ', 60, 24.4),
(N'Nam', 0, 4.3),
(N'Nam', 1, 5.7),
(N'Nam', 2, 7.0),
(N'Nam', 3, 7.9),
(N'Nam', 4, 8.6),
(N'Nam', 5, 9.2),
(N'Nam', 6, 9.7),
(N'Nam', 7, 10.2),
(N'Nam', 8, 10.5),
(N'Nam', 9, 10.9),
(N'Nam', 10, 11.2),
(N'Nam', 11, 11.5),
(N'Nam', 12, 11.8),
(N'Nam', 13, 12.1),
(N'Nam', 14, 12.4),
(N'Nam', 15, 12.7),
(N'Nam', 16, 12.9),
(N'Nam', 17, 13.2),
(N'Nam', 18, 13.5),
(N'Nam', 19, 13.7),
(N'Nam', 20, 14.0),
(N'Nam', 21, 14.3),
(N'Nam', 22, 14.5),
(N'Nam', 23, 14.8),
(N'Nam', 24, 15.1),
(N'Nam', 25, 15.3),
(N'Nam', 26, 15.5),
(N'Nam', 27, 15.7),
(N'Nam', 28, 15.8),
(N'Nam', 29, 16),
(N'Nam', 30, 16.6),
(N'Nam', 31, 16.8),
(N'Nam', 32, 17),
(N'Nam', 33, 17.2),
(N'Nam', 34, 17.4),
(N'Nam', 35, 17.6),
(N'Nam', 36, 18.0),
(N'Nam', 37, 18.2),
(N'Nam', 38, 18.4),
(N'Nam', 39, 18.6),
(N'Nam', 40, 18.8),
(N'Nam', 41, 19),
(N'Nam', 42, 19.4),
(N'Nam', 43, 19.6),
(N'Nam', 44, 19.8),
(N'Nam', 45, 20),
(N'Nam', 46, 20.2),
(N'Nam', 47, 20.4),
(N'Nam', 48, 20.9),
(N'Nam', 49, 21.1),
(N'Nam', 50, 21.3),
(N'Nam', 51, 21.5),
(N'Nam', 52, 21.7),
(N'Nam', 53, 21.9),
(N'Nam', 54, 22.3),
(N'Nam', 55, 22.5),
(N'Nam', 56, 22.7),
(N'Nam', 57, 22.9),
(N'Nam', 58, 23.1),
(N'Nam', 59, 23.3),
(N'Nam', 60, 23.8)

-- Select * from KhuPho
-- Select * from HoGiaDinh
-- Select * from TaiKhoanDangNhap
-- Select * from ThanhVien
-- Select * from ThongBao
-- Select * from Vaccine
-- Select * from TiemChung
-- Select * from DinhDuong
-- Select * from ThaiKy
-- Select * from PhongKham
-- Select * from LichTiemVaccine
-- Select * from TreSuyĐinhuong
-- Select * from TreBeoPhi
-- Tô đen bỏ phần --  rồi nhấn Ctrl E để hiện bảng