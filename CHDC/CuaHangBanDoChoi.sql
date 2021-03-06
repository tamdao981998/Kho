Create database CuaHangDoChoi
USE [CuaHangDoChoi]
GO
/****** Object:  StoredProcedure [dbo].[Proc_DemSoHDBan]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Proc_DemSoHDBan]
as
Select count (MaHDBan) AS SOHD From HOA_DON_BAN Where  Day(GETDATE()) - Day(NgayLapHD) =0
	And Month(GETDATE()) - Month(NgayLapHD) =0 And Year(GETDATE()) - Year(NgayLapHD) =0
GO
/****** Object:  StoredProcedure [dbo].[Proc_DemSoHDHuy]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Proc_DemSoHDHuy]
as
Select count (MaHDBan) AS SOHD From HOA_DON_BAN Where TinhTrang = 0 AND Day(GETDATE()) - Day(NgayLapHD) =0
	And Month(GETDATE()) - Month(NgayLapHD) =0 And Year(GETDATE()) - Year(NgayLapHD) =0

GO
/****** Object:  StoredProcedure [dbo].[Proc_DemSoHDNhap]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Proc_DemSoHDNhap]
as
Select count (MaHDNhap) AS SOHD From HOA_DON_Nhap Where  Day(GETDATE()) - Day(NgayNhapHang) =0
	And Month(GETDATE()) - Month(NgayNhapHang) =0 And Year(GETDATE()) - Year(NgayNhapHang) =0

GO
/****** Object:  StoredProcedure [dbo].[Proc_DemSoSPDaBan]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Proc_DemSoSPDaBan]
as


Select IsNULL(Sum (ct.SoLuong),0) AS SOSP  From HOA_DON_Ban hdb , CHI_TIET_HDBAN ct Where hdb.MaHDBan = ct.MaHDBan AND Day(GETDATE()) - Day(NgayLapHD) =0
	And Month(GETDATE()) - Month(NgayLapHD) =0 And Year(GETDATE()) - Year(NgayLapHD) =0	

GO
/****** Object:  StoredProcedure [dbo].[Proc_DemSoSPDaNhap]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Proc_DemSoSPDaNhap]
as


Select IsNULL(Sum (ct.SoLuong),0) AS SOSP  From HOA_DON_Nhap hdn , CHI_TIET_HDNHAP ct Where hdn.MaHDNhap = ct.MaHDNhap AND Day(GETDATE()) - Day(NgayNhapHang) =0
	And Month(GETDATE()) - Month(NgayNhapHang) =0 And Year(GETDATE()) - Year(NgayNhapHang) =0	

GO
/****** Object:  StoredProcedure [dbo].[Proc_HienThiCTHDX]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC  [dbo].[Proc_HienThiCTHDX]
(
	@mahdx varchar(10)
)
as
Begin
Select sp.TenSP,Sum(cthdb.SoLuong) AS TongSL,cthdb.DonGia,(Sum(cthdb.SoLuong)*cthdb.DonGia) AS ThanhTien from SAN_PHAM SP , CHI_TIET_HDBAN cthdb where sp.MaSP =  cthdb.MaSP AND MaHDBan=@mahdx
Group by sp.TenSP,cthdb.DonGia
END


GO
/****** Object:  StoredProcedure [dbo].[Proc_HienThiSanPhamNhapTheoNgay]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Proc_HienThiSanPhamNhapTheoNgay]
(
	@TimeTu date,
	@TimeDen date
)
as
	Begin
		Select sp.MaSP,sp.TenSP,lsp.TenLoaiSP,cthdn.DonGia,SUM(cthdn.SoLuong)AS TONGSL,(SUM(cthdn.SoLuong)*cthdn.DonGia) AS TongTien  From SAN_PHAM sp ,LOAI_SAN_PHAM lsp ,CHI_TIET_HDNHAP cthdn,HOA_DON_NHAP hdn Where sp.MaLoaiSP = lsp.MaLoaiSP
			And sp.MaSP = cthdn.MaSP And hdn.MaHDNhap = cthdn.MaHDNhap
			And hdn.NgayNhapHang between @TimeTu AND @TimeDen
		Group by sp.MaSP,sp.TenSP,lsp.TenLoaiSP,cthdn.DonGia
	End


GO
/****** Object:  StoredProcedure [dbo].[Proc_HienThiTongDoanhThuTheoThang]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[Proc_HienThiTongDoanhThuTheoThang]
(
	@ThangTu date,
	@ThangDen date
)
as
begin
Select NgayLapHD ,Sum(TongTien) AS TongDoanhThu  From HOA_DON_BAN Where NgayLapHD between @ThangTu AND @ThangDen
group by NgayLapHD
order by TongDoanhThu DESC
end

GO
/****** Object:  StoredProcedure [dbo].[Proc_HienThiTongDoanhThuTheoThoiGian]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[Proc_HienThiTongDoanhThuTheoThoiGian]
(
	@ThangTu date,
	@ThangDen date
)
as
begin
Select NgayLapHD ,Sum(TongTien) AS TongDoanhThu  From HOA_DON_BAN Where NgayLapHD between @ThangTu AND @ThangDen
group by NgayLapHD
order by TongDoanhThu DESC
end

GO
/****** Object:  StoredProcedure [dbo].[Proc_SPBanChayNhat]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE Proc [dbo].[Proc_SPBanChayNhat]
 (
	@TimeTu date,
	@TimeDen date
 )
 as
 Begin
Select tOP 5 Sum(cthdb.SoLuong) AS SLSP,SP.TenSP,(Sum(cthdb.SoLuong)*cthdb.DonGia) as TongTien From SAN_PHAM sp , CHI_TIET_HDBAN cthdb,HOA_DON_BAN hdb Where hdb.MaHDBan = cthdb.MaHDBan AND sp.MaSP = cthdb.MaSP 
	And NgayLapHD >= @TimeTu AND NgayLapHD<= @TimeDen
Group by sp.TenSP,cthdb.DonGia
Order by   SLSP desc,sp.TenSP DESC
end


GO
/****** Object:  StoredProcedure [dbo].[Proc_TongDoanhThuTrongNgay]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Proc_TongDoanhThuTrongNgay]
as
Select ISNUll(Sum (TongTien),0) AS TongDT From HOA_DON_BAN Where Day(GETDATE()) - Day(NgayLapHD) =0
	And Month(GETDATE()) - Month(NgayLapHD) =0 And Year(GETDATE()) - Year(NgayLapHD) =0

GO
/****** Object:  Table [dbo].[CHI_TIET_DON_DH]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHI_TIET_DON_DH](
	[MaDonDH] [nvarchar](10) NOT NULL,
	[MaSP] [char](5) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
 CONSTRAINT [PK__CHI_TIET__0FD6C24AA75E05E6] PRIMARY KEY CLUSTERED 
(
	[MaDonDH] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHI_TIET_HDBAN]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHI_TIET_HDBAN](
	[MaHDBan] [varchar](10) NOT NULL,
	[MaSP] [char](5) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
 CONSTRAINT [PK__CHI_TIET__91623EABDDFAD339] PRIMARY KEY CLUSTERED 
(
	[MaHDBan] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHI_TIET_HDNHAP]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHI_TIET_HDNHAP](
	[MaHDNhap] [varchar](10) NOT NULL,
	[MaSP] [char](5) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
 CONSTRAINT [PK__CHI_TIET__AACEFCF57CD9014A] PRIMARY KEY CLUSTERED 
(
	[MaHDNhap] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DON_DAT_HANG]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DON_DAT_HANG](
	[MaDonDH] [varchar](10) NOT NULL,
	[NgayDat] [datetime] NULL,
	[NgayGiao] [datetime] NULL,
	[DiaChiGiao] [nvarchar](max) NULL,
	[SoDienThoai] [int] NULL,
	[TongTien] [decimal](18, 0) NULL,
	[KhachHangDat] [varchar](10) NULL,
	[NVLap] [varchar](10) NULL,
	[TinhTrang] [int] NULL,
 CONSTRAINT [PK__DON_DAT___DDA492CBF4139949] PRIMARY KEY CLUSTERED 
(
	[MaDonDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HOA_DON_BAN]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOA_DON_BAN](
	[MaHDBan] [varchar](10) NOT NULL,
	[NgayLapHD] [date] NULL,
	[TongTien] [decimal](18, 0) NULL,
	[MaKH] [varchar](10) NULL,
	[NVLapHD] [varchar](10) NULL,
	[TinhTrang] [int] NULL,
	[TienKhachTra] [decimal](18, 0) NULL,
	[TienDu] [decimal](18, 0) NULL,
 CONSTRAINT [PK__HOA_DON___43106E2AAA1186A2] PRIMARY KEY CLUSTERED 
(
	[MaHDBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HOA_DON_NHAP]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOA_DON_NHAP](
	[MaHDNhap] [varchar](10) NOT NULL,
	[NgayNhapHang] [datetime] NULL,
	[TongTien] [decimal](18, 0) NULL,
	[NVLap] [varchar](10) NULL,
	[MaNSX] [varchar](10) NULL,
	[TinhTrang] [tinyint] NULL,
 CONSTRAINT [PK__HOA_DON___78BCAC748444856D] PRIMARY KEY CLUSTERED 
(
	[MaHDNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KHACH_HANG]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACH_HANG](
	[MaKH] [varchar](10) NOT NULL,
	[HoTenKH] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Email] [nchar](50) NULL,
	[SoDienThoai] [int] NULL,
	[CMND] [char](11) NULL,
	[NgayMuaHang] [date] NULL,
	[TinhTrang] [int] NULL,
 CONSTRAINT [PK__KHACH_HA__2725CF1EEC3B5CF1] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOAI_SAN_PHAM]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOAI_SAN_PHAM](
	[MaLoaiSP] [varchar](10) NOT NULL,
	[TenLoaiSP] [nvarchar](50) NULL,
	[TinhTrang] [tinyint] NULL,
 CONSTRAINT [PK__LOAI_SAN__1224CA7CD61B14E6] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOAI_TAi_KHOAN]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOAI_TAi_KHOAN](
	[MaLoaiTK] [varchar](10) NOT NULL,
	[TenLoaiTK] [nvarchar](50) NULL,
	[TinhTrang] [int] NULL,
 CONSTRAINT [PK__LOAI_TAi__1224F25458D5DAFD] PRIMARY KEY CLUSTERED 
(
	[MaLoaiTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHA_SAN_XUAT]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHA_SAN_XUAT](
	[MaNSX] [varchar](10) NOT NULL,
	[TenNSX] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[SoDienThoai] [int] NULL,
	[TinhTrang] [int] NULL,
 CONSTRAINT [PK__NHA_SAN___3A1BDBD2FC059578] PRIMARY KEY CLUSTERED 
(
	[MaNSX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SAN_PHAM]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SAN_PHAM](
	[MaSP] [char](5) NOT NULL,
	[TenSP] [nvarchar](50) NULL,
	[DoTuoi] [nvarchar](20) NULL,
	[MoTa] [nvarchar](max) NULL,
	[Gia] [int] NULL,
	[SoLuongTonKho] [int] NULL,
	[HinhAnh] [nvarchar](50) NULL,
	[MaLoaiSP] [varchar](10) NULL,
	[MaNSX] [varchar](10) NULL,
	[TinhTrang] [int] NULL,
 CONSTRAINT [PK__SAN_PHAM__2725081C45067612] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TAI_KHOAN]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TAI_KHOAN](
	[MaNV] [varchar](10) NOT NULL,
	[MatKhau] [varchar](15) NULL,
	[HoTenNV] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[Email] [nchar](50) NULL,
	[SoDienThoai] [int] NULL,
	[CMND] [char](11) NULL,
	[AnhDaiDien] [varchar](50) NULL,
	[MaLoaiTK] [varchar](10) NULL,
	[TinhTrang] [int] NULL,
	[TenDangNhap] [varchar](50) NULL,
 CONSTRAINT [PK__TAI_KHOA__2725D70ADACDE7A2] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[HienThiDSHoaDonBan]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[HienThiDSHoaDonBan]
as
	Select tk.HoTenNV,kh.HoTenKH,hdb.* From HOA_DON_BAN hdb,TAI_KHOAN tk , KHACH_HANG kh WHERE hdb.NVLapHD = tk.MaNV AND hdb.MaKH = kh.MaKH



GO
/****** Object:  View [dbo].[HienThiDSHoaDonNhap]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[HienThiDSHoaDonNhap]
as
	Select tk.HoTenNV , nsx.TenNSX,hdn.* From TAI_KHOAN tk , HOA_DON_NHAP hdn , NHA_SAN_XUAT nsx Where tk.MaNV = hdn.NVLap AND hdn.MaNSX = nsx.MaNSX


GO
/****** Object:  View [dbo].[HienThiDSSanPhamDaBan]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create View [dbo].[HienThiDSSanPhamDaBan]
as 
 select sp.MaSP,sp.TenSP,lsp.TenLoaiSP,cthdb.DonGia, Sum(cthdb.SoLuong) as SLSP,(Sum(cthdb.SoLuong)*cthdb.DonGia) as TongTien,hdb.NgayLapHD from SAN_PHAM sp , CHI_TIET_HDBAN cthdb, HOA_DON_BAN hdb ,LOAI_SAN_PHAM lsp Where sp.MaSP = cthdb.MaSP And sp.MaLoaiSP = lsp.MaLoaiSP AND hdb.MaHDBan=cthdb.MaHDBan
 group by sp.MaSP,sp.TenSP,cthdb.DonGia,lsp.TenLoaiSP,hdb.NgayLapHD


GO
/****** Object:  View [dbo].[HienThiDSTaiKhoan]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create View [dbo].[HienThiDSTaiKhoan]
as
	Select tk.*,ltk.TenLoaiTK From TAI_KHOAN tk ,LOAI_TAi_KHOAN ltk Where tk.MaLoaiTK = ltk.MaLoaiTK


GO
/****** Object:  View [dbo].[HienThiTongDoanhThuTheoNV]    Script Date: 21-Dec-18 9:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create View [dbo].[HienThiTongDoanhThuTheoNV]
as 
select NVLapHD,hdb.NgayLapHD AS NgayLap ,tk.HoTenNV,Sum(cthd.SoLuong) as 'SLSP' ,Sum(TongTien)as 'TongDoanhThu' From HOA_DON_BAN hdb,CHI_TIET_HDBAN cthd,TAI_KHOAN tk where hdb.MaHDBan
 = cthd.MaHDBan AND TK.MaNV = hdb.NVLapHD AND hdb.TinhTrang =1
 Group by NVLapHD,HoTenNV,hdb.NgayLapHD


GO
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB001', N'SP005', 1, CAST(49000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB001', N'SP006', 1, CAST(49000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB002', N'SP016', 1, CAST(13000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB002', N'SP017', 2, CAST(13000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB003', N'SP005', 10, CAST(24000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB004', N'SP005', 1, CAST(150000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB005', N'SP006', 1, CAST(159000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB005', N'SP007', 1, CAST(159000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB006', N'SP004', 1, CAST(120000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB006', N'SP005', 1, CAST(150000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB007', N'SP001', 1, CAST(90000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB008', N'SP001', 8, CAST(90000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB010', N'SP001', 3, CAST(90000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB010', N'SP003', 3, CAST(90000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB010', N'SP005', 1, CAST(150000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB011', N'SP018', 1, CAST(39000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB011', N'SP019', 4, CAST(51000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB011', N'SP029', 1, CAST(133000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB012', N'SP004', 1, CAST(120000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB012', N'SP006', 1, CAST(49000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB012', N'SP007', 1, CAST(159000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDBAN] ([MaHDBan], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDB012', N'SP008', 1, CAST(27000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN006', N'SP027', 1, CAST(132000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN006', N'SP030', 1, CAST(125000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN006', N'SP031', 1, CAST(121000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN007', N'SP015', 1, CAST(79000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN008', N'SP013', 1, CAST(230000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN009', N'SP013', 1, CAST(230000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP004', 1, CAST(120000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP006', 1, CAST(49000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP012', 1, CAST(151000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP013', 1, CAST(230000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP015', 1, CAST(79000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP017', 1, CAST(13000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP019', 1, CAST(51000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP020', 1, CAST(15000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP027', 1, CAST(132000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP030', 1, CAST(125000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP031', 1, CAST(121000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP034', 1, CAST(99000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP035', 1, CAST(159000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP036', 1, CAST(40000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP037', 1, CAST(140000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP038', 1, CAST(130000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP042', 1, CAST(80000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP043', 1, CAST(169000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP048', 1, CAST(75000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN010', N'SP050', 1, CAST(333000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN011', N'SP004', 1, CAST(120000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN011', N'SP006', 1, CAST(49000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN011', N'SP012', 1, CAST(151000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN012', N'SP019', 1, CAST(51000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN012', N'SP020', 1, CAST(15000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN012', N'SP027', 1, CAST(132000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN012', N'SP030', 1, CAST(125000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN013', N'SP004', 1, CAST(120000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN014', N'SP004', 6, CAST(120000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN014', N'SP006', 4, CAST(49000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN015', N'SP004', 1, CAST(120000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN016', N'SP004', 3, CAST(120000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN016', N'SP006', 5, CAST(49000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN016', N'SP012', 10, CAST(151000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN016', N'SP013', 3, CAST(230000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN016', N'SP015', 1, CAST(79000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN017', N'SP001', 64, CAST(90000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN018', N'SP049', 2, CAST(113000 AS Decimal(18, 0)))
INSERT [dbo].[CHI_TIET_HDNHAP] ([MaHDNhap], [MaSP], [SoLuong], [DonGia]) VALUES (N'HDN018', N'SP050', 15, CAST(333000 AS Decimal(18, 0)))
INSERT [dbo].[HOA_DON_BAN] ([MaHDBan], [NgayLapHD], [TongTien], [MaKH], [NVLapHD], [TinhTrang], [TienKhachTra], [TienDu]) VALUES (N'HDB001', CAST(0x063F0B00 AS Date), CAST(199000 AS Decimal(18, 0)), N'KH002', N'TK001', 1, CAST(200000 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)))
INSERT [dbo].[HOA_DON_BAN] ([MaHDBan], [NgayLapHD], [TongTien], [MaKH], [NVLapHD], [TinhTrang], [TienKhachTra], [TienDu]) VALUES (N'HDB002', CAST(0x063F0B00 AS Date), CAST(75000 AS Decimal(18, 0)), N'KH006', N'TK001', 1, CAST(100000 AS Decimal(18, 0)), CAST(25000 AS Decimal(18, 0)))
INSERT [dbo].[HOA_DON_BAN] ([MaHDBan], [NgayLapHD], [TongTien], [MaKH], [NVLapHD], [TinhTrang], [TienKhachTra], [TienDu]) VALUES (N'HDB003', CAST(0x073F0B00 AS Date), CAST(2655000 AS Decimal(18, 0)), N'KH001', N'TK001', 0, CAST(3000000 AS Decimal(18, 0)), CAST(345000 AS Decimal(18, 0)))
INSERT [dbo].[HOA_DON_BAN] ([MaHDBan], [NgayLapHD], [TongTien], [MaKH], [NVLapHD], [TinhTrang], [TienKhachTra], [TienDu]) VALUES (N'HDB004', CAST(0x073F0B00 AS Date), CAST(150000 AS Decimal(18, 0)), N'KH003', N'TK001', 1, CAST(2000000 AS Decimal(18, 0)), CAST(1850000 AS Decimal(18, 0)))
INSERT [dbo].[HOA_DON_BAN] ([MaHDBan], [NgayLapHD], [TongTien], [MaKH], [NVLapHD], [TinhTrang], [TienKhachTra], [TienDu]) VALUES (N'HDB005', CAST(0x073F0B00 AS Date), CAST(208000 AS Decimal(18, 0)), N'KH003', N'TK001', 1, CAST(300000 AS Decimal(18, 0)), CAST(92000 AS Decimal(18, 0)))
INSERT [dbo].[HOA_DON_BAN] ([MaHDBan], [NgayLapHD], [TongTien], [MaKH], [NVLapHD], [TinhTrang], [TienKhachTra], [TienDu]) VALUES (N'HDB006', CAST(0x073F0B00 AS Date), CAST(270000 AS Decimal(18, 0)), N'KH006', N'TK001', 1, CAST(300000 AS Decimal(18, 0)), CAST(30000 AS Decimal(18, 0)))
INSERT [dbo].[HOA_DON_BAN] ([MaHDBan], [NgayLapHD], [TongTien], [MaKH], [NVLapHD], [TinhTrang], [TienKhachTra], [TienDu]) VALUES (N'HDB007', CAST(0x103F0B00 AS Date), CAST(90000 AS Decimal(18, 0)), N'KH002', N'TK001', 1, CAST(1000000 AS Decimal(18, 0)), CAST(910000 AS Decimal(18, 0)))
INSERT [dbo].[HOA_DON_BAN] ([MaHDBan], [NgayLapHD], [TongTien], [MaKH], [NVLapHD], [TinhTrang], [TienKhachTra], [TienDu]) VALUES (N'HDB008', CAST(0x103F0B00 AS Date), CAST(720000 AS Decimal(18, 0)), N'KH002', N'TK001', 1, CAST(100000000 AS Decimal(18, 0)), CAST(99280000 AS Decimal(18, 0)))
INSERT [dbo].[HOA_DON_BAN] ([MaHDBan], [NgayLapHD], [TongTien], [MaKH], [NVLapHD], [TinhTrang], [TienKhachTra], [TienDu]) VALUES (N'HDB009', CAST(0x103F0B00 AS Date), CAST(810000 AS Decimal(18, 0)), N'KH002', N'TK001', 1, CAST(1000000 AS Decimal(18, 0)), CAST(190000 AS Decimal(18, 0)))
INSERT [dbo].[HOA_DON_BAN] ([MaHDBan], [NgayLapHD], [TongTien], [MaKH], [NVLapHD], [TinhTrang], [TienKhachTra], [TienDu]) VALUES (N'HDB010', CAST(0x163F0B00 AS Date), CAST(690000 AS Decimal(18, 0)), N'KH001', N'TK001', 1, CAST(700000 AS Decimal(18, 0)), CAST(10000 AS Decimal(18, 0)))
INSERT [dbo].[HOA_DON_BAN] ([MaHDBan], [NgayLapHD], [TongTien], [MaKH], [NVLapHD], [TinhTrang], [TienKhachTra], [TienDu]) VALUES (N'HDB011', CAST(0x163F0B00 AS Date), CAST(376000 AS Decimal(18, 0)), N'KH001', N'TK001', 0, CAST(400000 AS Decimal(18, 0)), CAST(24000 AS Decimal(18, 0)))
INSERT [dbo].[HOA_DON_BAN] ([MaHDBan], [NgayLapHD], [TongTien], [MaKH], [NVLapHD], [TinhTrang], [TienKhachTra], [TienDu]) VALUES (N'HDB012', CAST(0x183F0B00 AS Date), CAST(355000 AS Decimal(18, 0)), N'KH001', N'TK001', 1, CAST(500000 AS Decimal(18, 0)), CAST(145000 AS Decimal(18, 0)))
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN001', CAST(0x0000A99200D47768 AS DateTime), CAST(169000 AS Decimal(18, 0)), N'TK001', N'NSX001', 0)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN002', CAST(0x0000A9A40143C88F AS DateTime), CAST(198000 AS Decimal(18, 0)), N'TK001', N'NSX001', 1)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN003', CAST(0x0000A9A401442CD7 AS DateTime), CAST(524000 AS Decimal(18, 0)), N'TK001', N'NSX001', 1)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN004', CAST(0x0000A9A4014444AD AS DateTime), CAST(79000 AS Decimal(18, 0)), N'TK001', N'NSX001', 1)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN005', CAST(0x0000A9A40144C28D AS DateTime), CAST(51000 AS Decimal(18, 0)), N'TK001', N'NSX001', 1)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN006', CAST(0x0000A9A40145BF70 AS DateTime), CAST(378000 AS Decimal(18, 0)), N'TK001', N'NSX001', 1)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN007', CAST(0x0000A9A40163FA0B AS DateTime), CAST(158000 AS Decimal(18, 0)), N'TK001', N'NSX001', 1)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN008', CAST(0x0000A9A40164374A AS DateTime), CAST(230000 AS Decimal(18, 0)), N'TK001', N'NSX001', 1)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN009', CAST(0x0000A9A401643DAE AS DateTime), CAST(296000 AS Decimal(18, 0)), N'TK001', N'NSX001', 1)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN010', CAST(0x0000A9A500974AB2 AS DateTime), CAST(2311000 AS Decimal(18, 0)), N'TK001', N'NSX001', 1)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN011', CAST(0x0000A9A500996D3B AS DateTime), CAST(320000 AS Decimal(18, 0)), N'TK001', N'NSX001', 1)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN012', CAST(0x0000A9A5009973F7 AS DateTime), CAST(323000 AS Decimal(18, 0)), N'TK001', N'NSX001', 1)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN013', CAST(0x0000A9A500A726CA AS DateTime), CAST(120000 AS Decimal(18, 0)), N'TK001', N'NSX001', 1)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN014', CAST(0x0000A9A500AC5F3C AS DateTime), CAST(916000 AS Decimal(18, 0)), N'TK001', N'NSX001', 1)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN015', CAST(0x0000A9A500ACBA79 AS DateTime), CAST(120000 AS Decimal(18, 0)), N'TK001', N'NSX001', 1)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN016', CAST(0x0000A9A60098DD30 AS DateTime), CAST(2884000 AS Decimal(18, 0)), N'TK001', N'NSX001', 1)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN017', CAST(0x0000A9A60099302E AS DateTime), CAST(5760000 AS Decimal(18, 0)), N'TK001', N'NSX001', 1)
INSERT [dbo].[HOA_DON_NHAP] ([MaHDNhap], [NgayNhapHang], [TongTien], [NVLap], [MaNSX], [TinhTrang]) VALUES (N'HDN018', CAST(0x0000A9A600A369F1 AS DateTime), CAST(5221000 AS Decimal(18, 0)), N'TK001', N'NSX008', 1)
INSERT [dbo].[KHACH_HANG] ([MaKH], [HoTenKH], [DiaChi], [Email], [SoDienThoai], [CMND], [NgayMuaHang], [TinhTrang]) VALUES (N'KH001', N'Nguyễn Thàqweqwe', N'150/7 cầu ánh sao', N'thanhluc2008@gmail.com                            ', 93783188, N'123456789  ', CAST(0xFF3E0B00 AS Date), 1)
INSERT [dbo].[KHACH_HANG] ([MaKH], [HoTenKH], [DiaChi], [Email], [SoDienThoai], [CMND], [NgayMuaHang], [TinhTrang]) VALUES (N'KH002', N'Nguyễn Thanh Tâm', N'152/335 cầu ông lãnh', N'thanhtam2012@gmail.com                            ', 92789211, N'123456788  ', CAST(0xFF3E0B00 AS Date), 1)
INSERT [dbo].[KHACH_HANG] ([MaKH], [HoTenKH], [DiaChi], [Email], [SoDienThoai], [CMND], [NgayMuaHang], [TinhTrang]) VALUES (N'KH003', N'Lê Hữu Thắng ', N'151/6 cầu cống', N'huuthang2016@gmail.com                            ', 91783921, N'123456787  ', CAST(0xFF3E0B00 AS Date), 1)
INSERT [dbo].[KHACH_HANG] ([MaKH], [HoTenKH], [DiaChi], [Email], [SoDienThoai], [CMND], [NgayMuaHang], [TinhTrang]) VALUES (N'KH005', N'Lực Tâm Thắng', N'1231231', N'lucthangtam                                       ', 123123, N'123123     ', CAST(0xFF3E0B00 AS Date), 1)
INSERT [dbo].[KHACH_HANG] ([MaKH], [HoTenKH], [DiaChi], [Email], [SoDienThoai], [CMND], [NgayMuaHang], [TinhTrang]) VALUES (N'KH006', N'tamocchi', N'efgfdgfd', N'dfd@gmail.com                                     ', 1232, N'3432423432 ', CAST(0xFF3E0B00 AS Date), 1)
INSERT [dbo].[LOAI_SAN_PHAM] ([MaLoaiSP], [TenLoaiSP], [TinhTrang]) VALUES (N'LSP001', N'Xếp hình,lắp ráp', 1)
INSERT [dbo].[LOAI_SAN_PHAM] ([MaLoaiSP], [TenLoaiSP], [TinhTrang]) VALUES (N'LSP002', N'đồ chơi trẻ nhỏ', 1)
INSERT [dbo].[LOAI_SAN_PHAM] ([MaLoaiSP], [TenLoaiSP], [TinhTrang]) VALUES (N'LSP003', N'đồ chơi giải trí', 1)
INSERT [dbo].[LOAI_SAN_PHAM] ([MaLoaiSP], [TenLoaiSP], [TinhTrang]) VALUES (N'LSP004', N'Đồ chơi gỗ', 1)
INSERT [dbo].[LOAI_SAN_PHAM] ([MaLoaiSP], [TenLoaiSP], [TinhTrang]) VALUES (N'LSP005', N'Búp bê gấu bông', 1)
INSERT [dbo].[LOAI_SAN_PHAM] ([MaLoaiSP], [TenLoaiSP], [TinhTrang]) VALUES (N'LSP006', N'Đồ chơi ngoài trời', 1)
INSERT [dbo].[LOAI_SAN_PHAM] ([MaLoaiSP], [TenLoaiSP], [TinhTrang]) VALUES (N'LSP007', N'Đồ chơi phát nhạc', 1)
INSERT [dbo].[LOAI_SAN_PHAM] ([MaLoaiSP], [TenLoaiSP], [TinhTrang]) VALUES (N'LSP008', N'Đồ chơi giáo dục', 1)
INSERT [dbo].[LOAI_TAi_KHOAN] ([MaLoaiTK], [TenLoaiTK], [TinhTrang]) VALUES (N'LTK001', N'Quản Lý', 1)
INSERT [dbo].[LOAI_TAi_KHOAN] ([MaLoaiTK], [TenLoaiTK], [TinhTrang]) VALUES (N'LTK002', N'Nhân Viên', 1)
INSERT [dbo].[NHA_SAN_XUAT] ([MaNSX], [TenNSX], [DiaChi], [SoDienThoai], [TinhTrang]) VALUES (N'NSX001', N'LeGo1', N'123', 123, 1)
INSERT [dbo].[NHA_SAN_XUAT] ([MaNSX], [TenNSX], [DiaChi], [SoDienThoai], [TinhTrang]) VALUES (N'NSX002', N'Phước Thành', N'Quận 7, TP. Hồ Chí Minh', 123456789, 1)
INSERT [dbo].[NHA_SAN_XUAT] ([MaNSX], [TenNSX], [DiaChi], [SoDienThoai], [TinhTrang]) VALUES (N'NSX003', N'No brand', N'Huyện Quế Võ, Bắc Ninh', 123456789, 1)
INSERT [dbo].[NHA_SAN_XUAT] ([MaNSX], [TenNSX], [DiaChi], [SoDienThoai], [TinhTrang]) VALUES (N'NSX004', N'Việt Mỹ', N'số 9 đường Song hành,phường Tân Hưng Thuận,Quận 12', 902333196, 1)
INSERT [dbo].[NHA_SAN_XUAT] ([MaNSX], [TenNSX], [DiaChi], [SoDienThoai], [TinhTrang]) VALUES (N'NSX005', N'AMEN', N'937831884', 123, 1)
INSERT [dbo].[NHA_SAN_XUAT] ([MaNSX], [TenNSX], [DiaChi], [SoDienThoai], [TinhTrang]) VALUES (N'NSX006', N'ANU', N'09037831884', 123, 1)
INSERT [dbo].[NHA_SAN_XUAT] ([MaNSX], [TenNSX], [DiaChi], [SoDienThoai], [TinhTrang]) VALUES (N'NSX007', N'ada', N'qwe', 12312, 1)
INSERT [dbo].[NHA_SAN_XUAT] ([MaNSX], [TenNSX], [DiaChi], [SoDienThoai], [TinhTrang]) VALUES (N'NSX008', N'123', N'123', 123, 1)
INSERT [dbo].[NHA_SAN_XUAT] ([MaNSX], [TenNSX], [DiaChi], [SoDienThoai], [TinhTrang]) VALUES (N'NSX009', N'123', N'123', 123, 1)
INSERT [dbo].[NHA_SAN_XUAT] ([MaNSX], [TenNSX], [DiaChi], [SoDienThoai], [TinhTrang]) VALUES (N'NSX010', N'TAM', N'123', 1111, 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP001', N'Bộ Học Kỹ Năng IQ Cho Bé Mẫu Giáo', N'Từ 5 tuổi', N'Bộ đồ chơi cho bé luyện tập kỹ năng tự lập trước khi đến trường rất hay và ý nghĩa.
Bộ đồ chơi gồm:
1 cặp đi học: cặp bằng xốp eva dán giấy bóng, khóa gài bằng nhựa + dây vải.
1 giày thể thao dây rút: giày bằng xốp eva dán giấy bóng, dây rút bằng vải + nhựa (như dây giày thể thao)
1 áo dài tay chui đầu có khóa kéo: áo bằng xốp eva dán giấy bóng, dây khóa kéo bằng nhựa.
1 quần yếm có dây nịt và nút bấm: dây nịt bằng simili chốt xi, nút bấm bằng inox.
Hàng quà tặng từ sữa Similac Abbott.
', 90000, 0, N'SP001.JPG', N'LSP008', N'NSX004', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP002', N'Bộ Mẫu Giáo', N'Từ 5 tuổi', N'Bộ đồ chơi cho bé luyện tập kỹ năng tự lập trước khi đến trường rất hay và ý nghĩa.
Bộ đồ chơi gồm:
1 cặp đi học: cặp bằng xốp eva dán giấy bóng, khóa gài bằng nhựa + dây vải.
1 giày thể thao dây rút: giày bằng xốp eva dán giấy bóng, dây rút bằng vải + nhựa (như dây giày thể thao)
1 áo dài tay chui đầu có khóa kéo: áo bằng xốp eva dán giấy bóng, dây khóa kéo bằng nhựa.
1 quần yếm có dây nịt và nút bấm: dây nịt bằng simili chốt xi, nút bấm bằng inox.
Hàng quà tặng từ sữa Similac Abbott.
', 90000, -2, N'sp002.JPG', N'LSP003', N'NSX004', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP003', N'Bộ Học Kỹ Năng IQ Cho ', N'Từ 5 tuổi', N'Bộ đồ chơi cho bé luyện tập kỹ năng tự lập trước khi đến trường rất hay và ý nghĩa.
Bộ đồ chơi gồm:
1 cặp đi học: cặp bằng xốp eva dán giấy bóng, khóa gài bằng nhựa + dây vải.
1 giày thể thao dây rút: giày bằng xốp eva dán giấy bóng, dây rút bằng vải + nhựa (như dây giày thể thao)
1 áo dài tay chui đầu có khóa kéo: áo bằng xốp eva dán giấy bóng, dây khóa kéo bằng nhựa.
1 quần yếm có dây nịt và nút bấm: dây nịt bằng simili chốt xi, nút bấm bằng inox.
Hàng quà tặng từ sữa Similac Abbott.
', 90000, 0, N'SP003.JPG', N'LSP004', N'NSX004', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP004', N'Bộ Đồ Chơi Lắp Ghép Tàu Lửa Số', N'Từ 3 tuổi', N'Bộ đồ chơi lắp ghép Tàu lửa số
-Bộ tàu hoả : 50 chi tiết 
- Kích thước hộp : 38.5 X 25 X 6.5 cm
', 120000, 99, N'sp004.JPG', N'LSP001', N'NSX001', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP005', N'Đồ Chơi Lắp Ráp Mô Hình Thành Phố', N'Từ 5 tuổi', N'Mỗi bộ gồm 40 chi tiết to lắp ráp thành 1 mô hình thành phố. 1 tàu nhỏ chạy bằng pin, chạy quanh mô hình thành phố.
Trọn bộ có 3 bộ, xếp riêng từng bộ hoặc xếp 3 bộ với nhau để được thành phố lớn đầy đủ.
', 150000, 87, N'sp005.JPG', N'LSP001', N'NSX001', 0)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP006', N'Đồ chơi búp bê công chúa dễ thương ', N'Từ 2 tuổi', N'Sản phẩm được cấu tạo bởi 12 khớp tạo độ linh hoạt cho búp bê
•	Dễ dàng thay đồ, mặc quần áo, tăng sức sáng tạo cho bé.
•	Được tặng kèm bộ phụ trang sức kiện gồm 8 món
•	Chất liệu cao cấp, màu sắc tươi sáng.
•	Bộ váy kèm theo được chế tác rất đẹp
', 49000, 101, N'sp006.JPG', N'LSP005', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP007', N'Lắp Ráp Lego Mô Hình Đồ Chơi Tàu Chiến Hạm Hùng Vĩ', N'Từ 6 tuổi', N'hộp màu kích thước 35x5.5x25cm', 159000, 197, N'sp007.JPG', N'LSP001', N'NSX001', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP008', N'Đồ Chơi Đâm Hải Tặc (Nâu)', N'Từ 7 tuổi
', N'•	Thiết kế độc đáo – sáng tạo
•	Tạo không khí vui nhộn, càng đông càng vui
•	Phù hợp chơi theo nhóm, rất cân não
•	Thích hợp làm trò giải trí trong các quán café, book shop, giải trí tại nhà….
', 27000, 97, N'sp008.JPG', N'LSP004', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP009', N'Bộ đồ chơi rút gỗ 48 miếng (Nâu)', N'Từ 3 tuổi', N'•	Gỗ tự nhiên an toàn
•	Dễ sử dụng
•	Có thể chơi 2 hay nhiều người
•	Rèn sự cẩn thận khéo léo
•	Gia công mịn màng
', 24000, 99, N'sp009.JPG', N'LSP004', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP010', N'Đồ Chơi Khám Răng Cá Sấu ', N'Từ 3 tuổi', N'•	Mang tính giải trí cao.
•	Màu sắc tươi sáng bắt mắt.
•	Số người chơi : 1 > 10 người.
•	Phù hợp cho cả người lớn và trẻ
•	Loại Lớn chơi hấp dẫn hơn
', 57000, 101, N'sp010.JPG', N'LSP002', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP011', N'Hộp đồ chơi xe ong nhào lộn 12 bánh lật', N'Từ 3 tuổi', N'Hộp đồ chơi xe ong nhào lộn 12 bánh lật là loại đồ chơi mô hình hình chú ong ngộ nghĩnh dễ thương đáng yêu với thiết kế bánh xe khi đụng vào tường sẽ lật ngược lại chắc chắn sẽ là món đồ chơi được các bé thích thú', 29000, 100, N'sp011.JPG', N'LSP003', N'NSX002', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP012', N'Xe Ô Tô Mô Hình Tomica Toyota ', N'Từ 4 tuổi', N'Hợp kim cao cấp, một số ít bộ phận bằng nhựa
•	- Có thiết kế giảm sóc, chịu va đập tốt
•	- Thiết kế mở cửa kéo bên hông rất đặc sắc
', 151000, 112, N'sp012.JPG', N'LSP006', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP013', N'Tàu cano điều khiển từ xa', N'Từ 5 tuổi', N'Đặc tính sản phẩm: bốn kênh (trước, sau, trái, phải) Màu sắc: đỏ, xanh Khỏang cách từ xa: 80-100 m bán kính Chạy thời gian: 10-15 phút Tốc độ : 15km/h', 230000, 105, N'sp013.JPG', N'LSP006', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP014', N'Bộ Trò chơi Phá Băng Bẫy Chim Cánh Cụt ', N'Từ 4 tuổi', N'•	Bộ đồ chơi dành cho trẻ phát triển sự thông minh và tính tư duy Logic
•	Người lớn có thể chơi cùng để giúp trẻ sáng tạo và tư suy tốt hơn
•	Giúp phát huy khả năng tư duy, sự khéo léo trong mỗi hành động của trẻ
•	Bộ đồ chơi là một lựa chọn tuyệt vời cho bạn và cả gia đình cùng vui chơi với bé
', 49000, 100, N'sp014.JPG', N'LSP008', N'NSX004', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP015', N'Xe Đồ Chơi Mô Hình Disney Car ', N'Từ 4 tuổi', N'•	Thiết kế tinh xảo,ngộ nghĩnh 
•	Chất Liệu: Nhựa an toàn
•	Kích thước :20x15x5cm
•	Bộ đồ chơi là món quà thú vị cho các bé trai hiếu động
•	Tính Năng: Chạy bánh đà
•	Gồm 8 nhân vật với 8 loại xe khác nhau tạo thành bộ sưu tập xe hơi ngộ nghĩnh
•	Giúp bé phát triển trí tưởng tượng và giải trí tránh xa điện thoại Ipad
', 79000, 102, N'sp015.JPG', N'LSP006', N'NSX002', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP016', N'Bộ đồ chơi xếp hình', N'Từ 2 tuổi', N'•	Đồ chơi ghép hình kết hợp một cách hoàn hảo giữa học tập, giải trí và trưng bày dành cho trẻ em!
•	Chất liệu nhựa cao cấp không chứa BPA an toàn cho bé và thân thiện môi trường.
•	Tăng khả năng tư duy và trí tưởng tượng phong phú cho bé yêu nhà bạn.
•	Rèn luyện tính kiên trì, sự khéo léo cho bé ngay từ khi còn nhỏ.
•	Giúp cho các bé yêu tự do thể hiện sự tạo không giới hạn từ những đồ vật quen thuộc trong gia đình.
', 49000, 99, N'sp016.JPG', N'LSP008', N'NSX004', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP017', N'Đồ chơi lò xo cầu vồng ma thuật ', N'Từ 3 tuổi', N'Đồ chơi lò xo cầu vồng ma thuật bằng nhựa (đường kính 7 cm) hay còn gọi là lò xo xoắn ốc, Slinky là loại đồ chơi có thể kéo dài hoặc uốn dẻo đủ mọi hình dáng với màu sắc tươi sáng, bắt mắt, chắc chắn sẽ là món đồ chơi thú vị cho bé.', 13000, 93, N'sp017.JPG', N'LSP002', N'NSX002', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP018', N'Đồ chơi gà bóp kêu Shrilling Chicken ', N'Từ 3 tuổi', N'Đồ chơi gà bóp kêu Shrilling Chicken size 40 cm S6758 là loại đồ chơi mô hình động vật hình chú gà Shrilling Chicken với thiết kế dễ thương xinh xắn đặc biệt phát ra âm thanh vui tai và kéo dài liên tục khi bóp chắc chắn sẽ là món đồ chơi phát ra âm thanh được các bé yêu thích', 39000, 99, N'sp018.JPG', N'LSP007', N'NSX002', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP019', N'Đồ Chơi Câu Cá Bằng Nhựa ', N'Từ 2 tuổi', N'•	4 Hồ 4 cần có thể cho nhiều bé chơi 1 lúc
•	Tăng khả năng khéo léo, luyện cho bé nhanh tay, nhanh mắt
•	Chạy bằng pin dễ sử dụng
•	An toàn cho trẻ
•	Phát nhạc cho trẻ chơi vui hơn
•	Hút bằng nam châm tăng độ chính xác
', 51000, 98, N'sp019.JPG', N'LSP003', N'NSX002', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP020', N'Đồ chơi đồng xu nhỏ bằng nhựa ', N'Từ 2 tuổi', N'là loại đồ chơi dành cho các bé chơi cùng bạn bé, với các đồng thu bé có thể sáng tạo ra có trò chơi khác nhau với các đồng xu này, như thảy đồng xu, tạt đồng xu,.v....', 15000, 102, N'sp020.JPG', N'LSP002', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP021', N'Đồ chơi quả trứng lưới nhiều màu, phát sáng', N'Từ 2 tuổi', N'Đồ chơi quả trứng lưới bằng nhựa dẻo, có các hạt nhỏ nhiều màu sắn bên trong. Bạn bóp quả trứng là những hạt bên trong sẽ nở ra nhiều màu sắc cực kỳ thú vị.Bên trong có đèn phát sáng nhiều màu sắc bắt mắt', 18000, 100, N'sp021.JPG', N'LSP002', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP022', N'Đồ chơi siêu xe ô tô biến hình thành Robot', N'Từ 7 tuổi', N'•	Làm từ chất liệu cao cấp an toàn cho trẻ em
•	Giúp trẻ sáng tạo và tư duy cao
•	Giải trí sau những giờ học căng thẳng.
', 30000, 99, N'sp022.JPG', N'LSP006', N'NSX002', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP023', N'Bộ 16 Con Đồ Chơi Squishy Mochi', N'Từ 6 tuổi', N'•	Hình ngộ nghĩnh đáng yêu, sành điệu.
•	Rất dẻo nên sờ, nắn, bóp, véo thoãi mái
•	Chất liệu silicone mềm dẻo, không độc hại.
•	Mô hình sáng tạo kute đến từ Nhật bản
', 89000, 100, N'sp023.JPG', N'LSP005', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP024', N'Đồ chơi lắp ráp gỗ 3D Mô hình DIY Doll House', N'Từ 6 tuổi', N'•	Mô hình DIY Doll House Kit Cathy is Flower House kèm đèn LED
•	Mô hình: Bao gồm Hộp Pin có công tắc, Đèn Led và nhiều mô hình thu nhỏ như: Thực vật, hoa và lọ, kệ hoa, slatted thùng,tủ gỗ, hộp giấy, khung ảnh, thuổng, chổi, sơn và giá ....
•	Quà tặng: Với các công cụ lắp ráp cần thiết: Keo, Cọ, Nhíp chuyên dụng,
', 479000, 100, N'sp024.JPG', N'LSP001', N'NSX004', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP025', N'Hộp đồ chơi xe tăng 4 bánh chạy pin có đèn nhạc', N'Từ 4 tuổi', N'Hộp đồ chơi xe tăng 4 bánh chạy pin có đèn nhạc là loại đồ chơi mô hình xe tank với thiết kế màu sắc chân thật được trang bị tên lửa, súng với đèn, nhạc đẹp mắt. Chắc chắn sẽ là món đồ chơi trẻ em được các bé yêu thích.', 45000, 101, N'sp025.JPG', N'LSP002', N'NSX001', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP026', N'Bộ đồ chơi lắp ráp nút tròn ', N'Từ 5 tuổi', N'•	Chất liệu: nhựa an toàn sản xuất tại Việt NamBộ sản phẩm: gồm nhiều nút tròn khoảng 760 nút - trọng lượng 500 gram Kích thước nút cao 2 cm
Bộ đồ chơi lắp ráp nút tròn (500 gram -  khoảng 760 nút là loại đồ chơi phát triển trí tưởng tượng, sáng tạo của bé với các nút tròn bé có thể lắp ráp đa chiều thành nhiều thứ khác nhau tùy theo sự sáng tạo của bé.
', 50000, 100, N'sp026.JPG', N'LSP001', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP027', N'Bộ 4 hộp đồ chơi lắp ráp công chúa Frozen', N'Từ 5 tuổi ', N'Là loại đồ chơi xếp hình mô hình lâu đài công chúa Frozen với các mảnh ghép nhỏ đa dạng với nhiều kích thước khác nhau, giúp bé phát huy khả năng tư duy, sáng tạo để lắp ghép các mảnh ghép với nhau tạo thành 1 mẫu lâu đài công chúa hoản chỉnh', 132000, 102, N'sp027.JPG', N'LSP001', N'NSX004', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP028', N'Đồ chơi đội trưởng mỹ', N'Từ 3 tuổi', N'•	Được làm từ chất liệu nhựa ABS an toàn tuyệt đối cho trẻ nhỏ
•	Sản phẩm có các khớp cử động linh hoạt
•	Giúp bé giải trí sau những giờ học trên lớp
•	Kích thích âm nhạc cho trẻ ngay từ nhỏ
•	Khi đi chuyển có đèn có nhạc
', 142000, 100, N'sp028.JPG', N'LSP002', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP029', N'Đồ chơi người nhện GH979', N'Từ 5 tuổi', N'•	Được làm từ chất liêu nhựa nguyên sinh không chất độc hại,an toan toàn tuyệt đối với trẻ
•	Thiết kế chắc chắn,chịu va đập mạnh
•	Khi sử dụng phát nhạc,tạo cảm giác thích thú cho trẻ
•	Giúp bé giải trí sau giờ học trên lớp
', 133000, 99, N'sp029.JPG', N'LSP003', N'NSX004', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP030', N'Đồ chơi máy bay dùng pin biến hình', N'Từ 3 tuổi', N'•	Được làm từ chất liệu nhựa nguyên sinh , an toàn tuyệt đối với trẻ nhỏ
•	Sản phẩm bền đẹp,chắc chắn
•	Sản phẩm có đèn nhạc
•	Từ xe tăng biến hình thành máy bay chiến đấu và ngược lại dễ dàng
', 125000, 102, N'sp030.JPG', N'LSP002', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP031', N'Đồ chơi khủng long đẻ trứng cao cấp cho bé', N'Từ 3 tuổi', N'•	Được làm từ chất liệu nhựa ABS an toàn tuyệt đối với trẻ nhỏ
•	Màu sắc bắt mắt,các cạnh được mài nhẵn
•	Sản phẩm sử dụng 3 pin AA
•	Khi di chuyển phát nhạc,đẻ trứng.Tạo cảm giác thích thú cho trẻ khi chơi
', 121000, 101, N'sp031.JPG', N'LSP002', N'NSX002', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP032', N'Robot Thông Minh Biết Nhảy', N'Từ 2 tuổi', N'•	Robot có thể di chuyển nhảy, hát theo điệu nhạc và có khả năng xoay được nên tới 360 độ
•	Thiết kế tinh tế với các đèn flashing nhấp nháy tạo những vòng ánh sáng đẹp mắt xung quanh robot
•	Hệ thống âm thanh của robot khá rõ nét
', 95000, 100, N'sp032.JPG', N'LSP002', N'NSX002', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP033', N'Hộp đồ chơi mèo Tom thông minh biết nói cảm ứng', N'Từ 3 tuổi', N'Các chức năng chính: ghi âm, kể chuyện, cảm ứng, âm nhạc.
+ Chạm vào tai trái mèo sẽ hát các bài hát: Alibaba, Bố là tất cả, Bắc kim thang, Bé khỏe bé ngoan, Ba thương con, Cây trúc xinh, Cháu lên ba, Cháu yêu bà, Con cò bé bé.
+ Chạm vào tai phải mèo sẽ kể các câu chuyện như: Cóc kiện trời, Sơn tinh - Thủy tinh
', 69000, 100, N'sp033.JPG', N'LSP002', N'NSX001', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP034', N'Hộp đồ chơi khủng long leo thang ', N'Từ 3 tuổi', N'Hộp đồ chơi khủng long leo thang Prehistoric Tunnel có đèn nhạc 0903 với thiết kế dễ thương, ngộ nghĩnh hình chú khủng long mẹ với 2 chú khủng long con leo thang với màu sắc tươi sáng chắc chắn sẽ là món đồ chơi khủng long leo thang được các bé yêu thích. ', 99000, 101, N'sp034.JPG', N'LSP003', N'NSX001', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP035', N'Đồ chơi nhạc cụ - Đàn mộc cầm 7 thanh ', N'Từ 5 tuổi', N'Trò chơi này còn giúp bé: Phân biệt được các màu sắc khác nhau: đỏ, xanh, vàng... Phát triển trí não, tâm hồn trẻ một cách toàn diện hơn. Kết hợp tốt giữa tay và mắt, tạo sự khéo léo, nhanh nhẹn', 159000, 101, N'sp035.JPG', N'LSP007', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP036', N'Đồ chơi nhạc cụ kèn hamonica', N'Từ 6 tuổi', N'Kích thích tò mò của trẻ, tạo âm thanh sống động', 40000, 101, N'sp036.JPG', N'LSP007', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP037', N'Đồ chơi piano mini', N'Từ 3 tuổi', N'Tạo âm thanh vui tai gây hứng thú cho bé', 140000, 101, N'sp037.JPG', N'LSP007', N'NSX001', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP038', N'Đồ chơi đàn ghita', N'Từ 3 tuổi', N'Loại bấm phím giúp bé làm quen được với nhạc cụ', 130000, 101, N'sp038.JPG', N'LSP007', N'NSX004', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP039', N'Voi Đồ Chơi Âm Nhạc ', N'Từ 2 tuổi', N'Cảm ứng "CHƠI" phải chân, bạn có thể nghe thấy thú vị đối thoại
Cảm ứng "HÁT" trái chân, một vui vẻ bài hát Tiếng Anh sẽ ra', 79000, 100, N'sp039.JPG', N'LSP007', N'NSX004', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP040', N'Bộ trống mini cho trẻ em', N'Từ 5 tuổi', N'Bộ dễ thương mini 5 trống phân bộ âm nhạc bộ gõ đồ chơi dành cho trẻ em
MỘT hình thức giải trí, đồ chơi hoàn hảo cho trẻ nhỏ và trẻ mẫu giáo
Tăng cường mẹ-con giao tiếp', 154000, 100, N'sp040.JPG', N'LSP007', N'NSX002', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP041', N'Gỗ Đàn Gõ Xylophone Cho Cho Trẻ Em', N'Từ 3 tuổi ', N'Dụng cụ tạo âm thanh kích thích sự phát triển của trẻ em', 139000, 100, N'sp041.JPG', N'LSP007', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP042', N'Con lật đật đáng yêu phát ra âm thanh cho bé', N'Từ 1 tuổi', N'Búp bê lật đật dễ thương ngộ nghĩnh, màu sắc tươi tắn, sinh động, phù hợp với độ tuổi tò mò, ưa khám phá của các bé.
Búp bê lật đật phát ra những âm thanh vui tai, cái đầu lúc lắc với thật nhiều biểu cảm khuôn mặt vô cùng dễ thương, có 5 mẫu để Ba Mẹ có thể lựa chọn cho bé yêu của mình: cam, hồng, xanh lá, vàng, xanh dương.', 80000, 101, N'sp042.JPG', N'LSP007', N'NSX001', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP043', N'Robot Metal Phát Âm Cảm', N'Từ 1 tuổi', N' Có khả năng phát ra âm thanh thú vị khi chạm vào đầu của robot

• Kích thích tính tò mò, tư duy sáng tạo của trẻ

• Các điểm sắc cạnh đều được bo tròn hay loại bỏ để bảo đảm an toàn cho bé.

• Không một bé nào có thể cưỡng lại được sự mê hoặc của các loại đồ chơi tự động.', 169000, 101, N'sp043.JPG', N'LSP007', N'NSX001', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP044', N'Bộ đồ chơi legoo lắp ráp 1000 chi tiết', N'Từ 4 tuổi ', N'Không chứa BPA, tuyệt đối an toàn với sức khỏe của bé.
Sản phẩm có 1000 chi tiết gạch giúp bé có thể thỏa sức lắp ráp nên những ngôi nhà, quán ăn, lâu đài hay bất kì công trình gì mà bé có thể sáng tạo ra.', 159000, 100, N'sp044.JPG', N'LSP001', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP045', N'Bộ lắp ráp năng lượng mặt trời', N'Từ 5 tuổi', N'Bộ sản phẩm lắp ráp được 14 mô hình làm việc khác nhau
Vui chơi thỏa thích cùng năng lượng mặt trời và không cần pin
Dễ dàng lắp ráp bằng cách làm theo các bước trong hướng dẫn', 110000, 100, N'sp045.JPG', N'LSP001', N'NSX004', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP046', N'Đồ chơi lắp ráp gỗ 3D Mô hình Nhà cổ ', N'Từ 5 tuổi', N'Có thể nói rằng, lắp ráp là một trong những hình thức đồ chơi được trẻ con trên khắp thế giới yêu thích.', 79000, 100, N'sp046.JPG', N'LSP001', N'NSX002', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP047', N'Bộ đồ chơi lắp ráp 8 trong 1 xe chiến binh', N'Từ 6 tuổi', N'ồ chơi lắp ráp, giúp rèn luyện khả năng quan sát, kiên trì của trẻ, kích thích sự sáng tạo

Bộ lắp ráp có 8 hộp nhỏ: mỗi hộp lắp thành 1 xe khác nhau, gộp 8 hộp tạo thành xe chiến binhPuzzle Boy Toy', 210000, 100, N'sp047.JPG', N'LSP001', N'NSX003', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP048', N' Mô Hình Lắp Ráp Bandai High Grade Pacific Rim', N'Từ 3 tuổi', N'Công việc lắp ráp tạo cho bạn tính tỉ mỉ; óc sáng tạo và tính kiên trì.
Mô hình lắp ráp xong cao khoảng 14cm; có khả năng thay đổi nhiều tư thế; có thể trưng bày hoặc chụp ảnh show hàng.
Mô hình được lắp theo kiểu bấm khớp; không phải dùng keo dán.', 75000, 101, N'sp048.JPG', N'LSP001', N'NSX004', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP049', N'Hộp lắp ráp 4 trong 1 ', N'Từ 3 tuổi', N'Hộp đồ chơi lắp ráp trẻ có thể lắp ráp thành 6 mẫu khác nhau

Giúp phát triển khả năng quan sát, sự tư duy , sáng tạo và sự kiên trì của bé

Trẻ có thể chơi cùng bạn bè và người thân', 113000, 102, N'sp049.JPG', N'LSP001', N'NSX001', 0)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP050', N'Hộp Lego Classic ', N'Từ 5 tuổi ', N'Rèn luyện sự khéo léo, tỉ mỉ. Kích thích tư duy sáng tạo', 333000, 116, N'sp050.JPG', N'LSP001', N'NSX003', 0)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP051', N'asd', N'1', N'1', 1, 0, N'SP051.JPG', N'LSP002', N'NSX002', 1)
INSERT [dbo].[SAN_PHAM] ([MaSP], [TenSP], [DoTuoi], [MoTa], [Gia], [SoLuongTonKho], [HinhAnh], [MaLoaiSP], [MaNSX], [TinhTrang]) VALUES (N'SP052', N'123', N'123', N'123', 123, 0, N'SP052.JPG', N'LSP001', N'NSX002', 1)
INSERT [dbo].[TAI_KHOAN] ([MaNV], [MatKhau], [HoTenNV], [DiaChi], [Email], [SoDienThoai], [CMND], [AnhDaiDien], [MaLoaiTK], [TinhTrang], [TenDangNhap]) VALUES (N'TK001', N'123', N'Nguyễn Thành Lực', N'150/57/51', N'thanhluc@gmail.com                                ', 123456789, N'123123123  ', N'thanhluc.PNG', N'LTK001', 1, N'ThanhLuc')
INSERT [dbo].[TAI_KHOAN] ([MaNV], [MatKhau], [HoTenNV], [DiaChi], [Email], [SoDienThoai], [CMND], [AnhDaiDien], [MaLoaiTK], [TinhTrang], [TenDangNhap]) VALUES (N'TK002', N'123', N'Lê Hữu Thắng', N'150/57/51', N'huuthang@gmail.com                                ', 123456789, N'123123123  ', N'huuthang.JPG', N'LTK002', 1, N'HuuThang')
INSERT [dbo].[TAI_KHOAN] ([MaNV], [MatKhau], [HoTenNV], [DiaChi], [Email], [SoDienThoai], [CMND], [AnhDaiDien], [MaLoaiTK], [TinhTrang], [TenDangNhap]) VALUES (N'TK003', N'123', N'Nguyễn Thanh Tâm', N'150/51/52', N'thanhtam@gmail.com                                ', 123456789, N'123123123  ', N'thanhtam.JPG', N'LTK002', 1, N'ThanhTam')
ALTER TABLE [dbo].[CHI_TIET_DON_DH]  WITH CHECK ADD  CONSTRAINT [FK_CHI_TIET_DON_DH_SAN_PHAM] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SAN_PHAM] ([MaSP])
GO
ALTER TABLE [dbo].[CHI_TIET_DON_DH] CHECK CONSTRAINT [FK_CHI_TIET_DON_DH_SAN_PHAM]
GO
ALTER TABLE [dbo].[CHI_TIET_HDBAN]  WITH CHECK ADD  CONSTRAINT [FK_CHI_TIET_HDBAN_HOA_DON_BAN] FOREIGN KEY([MaHDBan])
REFERENCES [dbo].[HOA_DON_BAN] ([MaHDBan])
GO
ALTER TABLE [dbo].[CHI_TIET_HDBAN] CHECK CONSTRAINT [FK_CHI_TIET_HDBAN_HOA_DON_BAN]
GO
ALTER TABLE [dbo].[CHI_TIET_HDBAN]  WITH CHECK ADD  CONSTRAINT [FK_CHI_TIET_HDBAN_SAN_PHAM] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SAN_PHAM] ([MaSP])
GO
ALTER TABLE [dbo].[CHI_TIET_HDBAN] CHECK CONSTRAINT [FK_CHI_TIET_HDBAN_SAN_PHAM]
GO
ALTER TABLE [dbo].[CHI_TIET_HDNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CHI_TIET_HDNHAP_HOA_DON_NHAP] FOREIGN KEY([MaHDNhap])
REFERENCES [dbo].[HOA_DON_NHAP] ([MaHDNhap])
GO
ALTER TABLE [dbo].[CHI_TIET_HDNHAP] CHECK CONSTRAINT [FK_CHI_TIET_HDNHAP_HOA_DON_NHAP]
GO
ALTER TABLE [dbo].[CHI_TIET_HDNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CHI_TIET_HDNHAP_SAN_PHAM] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SAN_PHAM] ([MaSP])
GO
ALTER TABLE [dbo].[CHI_TIET_HDNHAP] CHECK CONSTRAINT [FK_CHI_TIET_HDNHAP_SAN_PHAM]
GO
ALTER TABLE [dbo].[DON_DAT_HANG]  WITH CHECK ADD  CONSTRAINT [FK_DON_DAT_HANG_KHACH_HANG] FOREIGN KEY([KhachHangDat])
REFERENCES [dbo].[KHACH_HANG] ([MaKH])
GO
ALTER TABLE [dbo].[DON_DAT_HANG] CHECK CONSTRAINT [FK_DON_DAT_HANG_KHACH_HANG]
GO
ALTER TABLE [dbo].[DON_DAT_HANG]  WITH CHECK ADD  CONSTRAINT [FK_DON_DAT_HANG_TAI_KHOAN] FOREIGN KEY([NVLap])
REFERENCES [dbo].[TAI_KHOAN] ([MaNV])
GO
ALTER TABLE [dbo].[DON_DAT_HANG] CHECK CONSTRAINT [FK_DON_DAT_HANG_TAI_KHOAN]
GO
ALTER TABLE [dbo].[HOA_DON_BAN]  WITH CHECK ADD  CONSTRAINT [FK_HOA_DON_BAN_KHACH_HANG] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACH_HANG] ([MaKH])
GO
ALTER TABLE [dbo].[HOA_DON_BAN] CHECK CONSTRAINT [FK_HOA_DON_BAN_KHACH_HANG]
GO
ALTER TABLE [dbo].[HOA_DON_BAN]  WITH CHECK ADD  CONSTRAINT [FK_HOA_DON_BAN_TAI_KHOAN] FOREIGN KEY([NVLapHD])
REFERENCES [dbo].[TAI_KHOAN] ([MaNV])
GO
ALTER TABLE [dbo].[HOA_DON_BAN] CHECK CONSTRAINT [FK_HOA_DON_BAN_TAI_KHOAN]
GO
ALTER TABLE [dbo].[HOA_DON_NHAP]  WITH CHECK ADD  CONSTRAINT [FK_HOA_DON_NHAP_NHA_SAN_XUAT] FOREIGN KEY([MaNSX])
REFERENCES [dbo].[NHA_SAN_XUAT] ([MaNSX])
GO
ALTER TABLE [dbo].[HOA_DON_NHAP] CHECK CONSTRAINT [FK_HOA_DON_NHAP_NHA_SAN_XUAT]
GO
ALTER TABLE [dbo].[HOA_DON_NHAP]  WITH CHECK ADD  CONSTRAINT [FK_HOA_DON_NHAP_TAI_KHOAN] FOREIGN KEY([NVLap])
REFERENCES [dbo].[TAI_KHOAN] ([MaNV])
GO
ALTER TABLE [dbo].[HOA_DON_NHAP] CHECK CONSTRAINT [FK_HOA_DON_NHAP_TAI_KHOAN]
GO
ALTER TABLE [dbo].[SAN_PHAM]  WITH CHECK ADD  CONSTRAINT [FK_SAN_PHAM_LOAI_SAN_PHAM] FOREIGN KEY([MaLoaiSP])
REFERENCES [dbo].[LOAI_SAN_PHAM] ([MaLoaiSP])
GO
ALTER TABLE [dbo].[SAN_PHAM] CHECK CONSTRAINT [FK_SAN_PHAM_LOAI_SAN_PHAM]
GO
ALTER TABLE [dbo].[SAN_PHAM]  WITH CHECK ADD  CONSTRAINT [FK_SAN_PHAM_NHA_SAN_XUAT] FOREIGN KEY([MaNSX])
REFERENCES [dbo].[NHA_SAN_XUAT] ([MaNSX])
GO
ALTER TABLE [dbo].[SAN_PHAM] CHECK CONSTRAINT [FK_SAN_PHAM_NHA_SAN_XUAT]
GO
ALTER TABLE [dbo].[TAI_KHOAN]  WITH CHECK ADD  CONSTRAINT [FK_TAI_KHOAN_LOAI_TAI_KHOAN] FOREIGN KEY([MaLoaiTK])
REFERENCES [dbo].[LOAI_TAi_KHOAN] ([MaLoaiTK])
GO
ALTER TABLE [dbo].[TAI_KHOAN] CHECK CONSTRAINT [FK_TAI_KHOAN_LOAI_TAI_KHOAN]
GO
