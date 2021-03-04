create database quanlybangdia

use quanlybangdia

create table BangDia(
MaBD char(5) not null,
Tenbangdia nvarchar(20) not null,
Soluong int not null
primary key(MaBD)
)

create table KhachHang (
MaKH char(5) not null,
MaBD char(5) not null,
Hoten nvarchar(30) not null,
Dienthoai int not null,
Soluongthue int not null,
Ngaythue datetime not null,
Songaythue int,
Thanhtien float
primary key(MaKH,MaBD)
)

insert into BangDia values('BD01',N'Cải lương',10)
insert into BangDia values('BD02',N'Ca nhạc',15)
insert into BangDia values('BD03',N'Hài kịch',20)

insert into KhachHang values('KH01','BD01',N'Cao Tiến Đạt',0111222333,1,'2021/3/4',1,10000)
insert into KhachHang values('KH02','BD02',N'Phan Cư Chánh ',0222333444,2,'2021/3/5',1,20000)
insert into KhachHang values('KH03','BD03',N'Nguyễn Quốc Việt',0333444555,4,'2021/3/5',1,17000)