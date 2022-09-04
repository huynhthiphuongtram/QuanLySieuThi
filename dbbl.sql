USE [master]
GO
/****** Object:  Database [dbbl]    Script Date: 9/1/2022 11:10:31 PM ******/
CREATE DATABASE [dbbl]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbbl', FILENAME = N'E:\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dbbl.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbbl_log', FILENAME = N'E:\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dbbl_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbbl] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbbl].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbbl] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbbl] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbbl] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbbl] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbbl] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbbl] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbbl] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbbl] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbbl] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbbl] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbbl] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbbl] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbbl] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbbl] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbbl] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbbl] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbbl] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbbl] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbbl] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbbl] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbbl] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbbl] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbbl] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbbl] SET  MULTI_USER 
GO
ALTER DATABASE [dbbl] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbbl] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbbl] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbbl] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbbl] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbbl] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [dbbl] SET QUERY_STORE = OFF
GO
USE [dbbl]
GO
/****** Object:  Table [dbo].[hanghoa]    Script Date: 9/1/2022 11:10:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hanghoa](
	[id_hh] [int] NOT NULL,
	[tenhang] [nvarchar](45) NULL,
	[giahang] [nvarchar](45) NULL,
	[xuatxu] [nvarchar](45) NULL,
	[mota] [nvarchar](45) NULL,
	[soluong] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hoadon]    Script Date: 9/1/2022 11:10:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hoadon](
	[idhd] [int] NOT NULL,
	[namenv] [nvarchar](45) NULL,
	[idhh] [nvarchar](45) NULL,
	[namehh] [nvarchar](45) NULL,
	[soluonghh] [nvarchar](45) NULL,
	[giahh] [nvarchar](45) NULL,
	[thanhtien] [float] NULL,
	[loaikhach] [nvarchar](45) NULL,
	[xuatxu] [nvarchar](45) NULL,
	[idkh] [nvarchar](45) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khachhang]    Script Date: 9/1/2022 11:10:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachhang](
	[idkhachhang] [int] NOT NULL,
	[tenkh] [nvarchar](45) NULL,
	[ngaysinh] [nvarchar](45) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 9/1/2022 11:10:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[user_id] [int] NOT NULL,
	[username] [nvarchar](45) NULL,
	[password] [nvarchar](45) NULL,
	[role] [nvarchar](45) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[hanghoa] ([id_hh], [tenhang], [giahang], [xuatxu], [mota], [soluong]) VALUES (1, N'Mít', N'20000', N'Vườn', N'-1000', 1)
INSERT [dbo].[hanghoa] ([id_hh], [tenhang], [giahang], [xuatxu], [mota], [soluong]) VALUES (2, N'Cam', N'10000', N'Vườn', N'-1000', 1)
INSERT [dbo].[hanghoa] ([id_hh], [tenhang], [giahang], [xuatxu], [mota], [soluong]) VALUES (3, N'Cam sành', N'10000', N'Vườn', N'-1000', 1)
GO
INSERT [dbo].[hoadon] ([idhd], [namenv], [idhh], [namehh], [soluonghh], [giahh], [thanhtien], [loaikhach], [xuatxu], [idkh]) VALUES (1, N'khoa', N'02c368e7-12a3-4fbb-b141-3016ebfe1f04', N'Cam sành', N'1', N'9000.0', 18000, N'', NULL, N'Đã tính')
INSERT [dbo].[hoadon] ([idhd], [namenv], [idhh], [namehh], [soluonghh], [giahh], [thanhtien], [loaikhach], [xuatxu], [idkh]) VALUES (2, N'1', N'2025fd18-ceb5-4437-ba76-5700222429ee', N'Mít', N'1', N'19000.0', 9848000, N'', NULL, N'Đã tính')
INSERT [dbo].[hoadon] ([idhd], [namenv], [idhh], [namehh], [soluonghh], [giahh], [thanhtien], [loaikhach], [xuatxu], [idkh]) VALUES (3, N'khoa', N'97afedec-5394-474a-918e-b2146a87a448', N'Cam sành', N'10', N'9000.0', 10000, N'', NULL, N'Đã tính')
INSERT [dbo].[hoadon] ([idhd], [namenv], [idhh], [namehh], [soluonghh], [giahh], [thanhtien], [loaikhach], [xuatxu], [idkh]) VALUES (4, N'khoa', N'9bbc1106-f487-4f13-a595-200e35f38fc2', N'Cam', N'1', N'9000.0', 18000, N'', NULL, N'Đã tính')
INSERT [dbo].[hoadon] ([idhd], [namenv], [idhh], [namehh], [soluonghh], [giahh], [thanhtien], [loaikhach], [xuatxu], [idkh]) VALUES (5, N'khoa', N'b8839ff0-cfef-46c5-85b3-43d60221c4f4', N'Cam sành', N'5', N'9000.0', 4400, N'VIP', N'Vườn', N'2')
GO
INSERT [dbo].[khachhang] ([idkhachhang], [tenkh], [ngaysinh]) VALUES (1, N'Khoa', N'12/7/2001')
INSERT [dbo].[khachhang] ([idkhachhang], [tenkh], [ngaysinh]) VALUES (2, N'Hùng', N'1/1/1111')
INSERT [dbo].[khachhang] ([idkhachhang], [tenkh], [ngaysinh]) VALUES (3, N'Trâm', N'1/1/1111')
GO
INSERT [dbo].[user] ([user_id], [username], [password], [role]) VALUES (1, N'1', N'1', N'Admin')
INSERT [dbo].[user] ([user_id], [username], [password], [role]) VALUES (2, N'cde', N'1', N'Nhân Viên')
INSERT [dbo].[user] ([user_id], [username], [password], [role]) VALUES (3, N'khoa', N'', N'Admin')
INSERT [dbo].[user] ([user_id], [username], [password], [role]) VALUES (4, N'q', N'1', N'Admin')
INSERT [dbo].[user] ([user_id], [username], [password], [role]) VALUES (5, N'meow', N'1', N'Admin')
INSERT [dbo].[user] ([user_id], [username], [password], [role]) VALUES (6, N'Hùng', N'1', N'Nhân Viên')
INSERT [dbo].[user] ([user_id], [username], [password], [role]) VALUES (7, N'khoa', N'1', N'Nhân Viên')
INSERT [dbo].[user] ([user_id], [username], [password], [role]) VALUES (8, N'khoa', N'1', N'Admin')
GO
USE [master]
GO
ALTER DATABASE [dbbl] SET  READ_WRITE 
GO
