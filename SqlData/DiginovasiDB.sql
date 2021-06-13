USE [master]
GO
/****** Object:  Database [DiginovasiDB]    Script Date: 6/14/2021 3:42:29 AM ******/
CREATE DATABASE [DiginovasiDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DiginovasiDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MIRZAEVOLUTION\MSSQL\DATA\DiginovasiDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DiginovasiDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MIRZAEVOLUTION\MSSQL\DATA\DiginovasiDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DiginovasiDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DiginovasiDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DiginovasiDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DiginovasiDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DiginovasiDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DiginovasiDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DiginovasiDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DiginovasiDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DiginovasiDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DiginovasiDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DiginovasiDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DiginovasiDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DiginovasiDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DiginovasiDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DiginovasiDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DiginovasiDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DiginovasiDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DiginovasiDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DiginovasiDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DiginovasiDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DiginovasiDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DiginovasiDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DiginovasiDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DiginovasiDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DiginovasiDB] SET RECOVERY FULL 
GO
ALTER DATABASE [DiginovasiDB] SET  MULTI_USER 
GO
ALTER DATABASE [DiginovasiDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DiginovasiDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DiginovasiDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DiginovasiDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DiginovasiDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DiginovasiDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DiginovasiDB', N'ON'
GO
ALTER DATABASE [DiginovasiDB] SET QUERY_STORE = OFF
GO
USE [DiginovasiDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/14/2021 3:42:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6/14/2021 3:42:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NoCustomer] [varchar](100) NOT NULL,
	[Nama] [varchar](100) NOT NULL,
	[NoKontak] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material]    Script Date: 6/14/2021 3:42:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Kode] [varchar](50) NOT NULL,
	[Deskripsi] [varchar](200) NULL,
	[UrlGambar] [varchar](max) NULL,
	[SatuanId] [int] NULL,
	[Harga] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrder]    Script Date: 6/14/2021 3:42:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NoSalesOrder] [varchar](20) NULL,
	[Tanggal] [datetime2](7) NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_SalesOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrderItems]    Script Date: 6/14/2021 3:42:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrderItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Jumlah] [int] NOT NULL,
	[MaterialId] [int] NULL,
	[SalesOrderId] [int] NULL,
 CONSTRAINT [PK_SalesOrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Satuan]    Script Date: 6/14/2021 3:42:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Satuan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Kode] [varchar](50) NOT NULL,
	[Deskripsi] [varchar](200) NULL,
 CONSTRAINT [PK_Satuan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210613010512_InitDB', N'3.1.16')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210613014543_UpdateEntities', N'3.1.16')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210613103434_ChangeSalesOrderItemEntity', N'3.1.16')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210613105143_ChangeNullableOnSalesOrderItemEntity', N'3.1.16')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210613111118_ChangeSeveralEntityColumns', N'3.1.16')
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([Id], [NoCustomer], [Nama], [NoKontak]) VALUES (1, N'Cust0001', N'Mirza Ghulam Rasyid', N'089616482113')
GO
INSERT [dbo].[Customer] ([Id], [NoCustomer], [Nama], [NoKontak]) VALUES (3, N'Cust0002', N'Rara Anjani', N'0896787899')
GO
INSERT [dbo].[Customer] ([Id], [NoCustomer], [Nama], [NoKontak]) VALUES (6, N'0000006', N'Beggi Mammad', N'087912312312')
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Material] ON 
GO
INSERT [dbo].[Material] ([Id], [Kode], [Deskripsi], [UrlGambar], [SatuanId], [Harga]) VALUES (2, N'Mat0001', N'Material 0001', N'Uploads\717d174a-a86a-4348-b0c6-d3973cd67934.jpg', 3, CAST(90000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Material] ([Id], [Kode], [Deskripsi], [UrlGambar], [SatuanId], [Harga]) VALUES (3, N'Mat00002', N'Material 00002', N'Uploads\32170480-203e-4915-b292-09a002df1bd4.jpg', 3, CAST(24000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Material] OFF
GO
SET IDENTITY_INSERT [dbo].[SalesOrder] ON 
GO
INSERT [dbo].[SalesOrder] ([Id], [NoSalesOrder], [Tanggal], [CustomerId]) VALUES (2, N'202106SL0000002', CAST(N'2021-06-13T00:00:00.0000000' AS DateTime2), 1)
GO
INSERT [dbo].[SalesOrder] ([Id], [NoSalesOrder], [Tanggal], [CustomerId]) VALUES (4, N'202106SL0000004', CAST(N'2021-06-04T00:00:00.0000000' AS DateTime2), 6)
GO
INSERT [dbo].[SalesOrder] ([Id], [NoSalesOrder], [Tanggal], [CustomerId]) VALUES (7, N'202106SL0000007', CAST(N'2021-06-05T00:00:00.0000000' AS DateTime2), 3)
GO
SET IDENTITY_INSERT [dbo].[SalesOrder] OFF
GO
SET IDENTITY_INSERT [dbo].[SalesOrderItems] ON 
GO
INSERT [dbo].[SalesOrderItems] ([Id], [Jumlah], [MaterialId], [SalesOrderId]) VALUES (6, 99, 3, 4)
GO
INSERT [dbo].[SalesOrderItems] ([Id], [Jumlah], [MaterialId], [SalesOrderId]) VALUES (7, 66, 2, 2)
GO
INSERT [dbo].[SalesOrderItems] ([Id], [Jumlah], [MaterialId], [SalesOrderId]) VALUES (8, 44, 2, 2)
GO
SET IDENTITY_INSERT [dbo].[SalesOrderItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Satuan] ON 
GO
INSERT [dbo].[Satuan] ([Id], [Kode], [Deskripsi]) VALUES (3, N'KG', N'Kilogram')
GO
INSERT [dbo].[Satuan] ([Id], [Kode], [Deskripsi]) VALUES (5, N'Gram', N'Gram')
GO
SET IDENTITY_INSERT [dbo].[Satuan] OFF
GO
/****** Object:  Index [IX_Material_SatuanId]    Script Date: 6/14/2021 3:42:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_Material_SatuanId] ON [dbo].[Material]
(
	[SatuanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SalesOrder_CustomerId]    Script Date: 6/14/2021 3:42:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_SalesOrder_CustomerId] ON [dbo].[SalesOrder]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SalesOrderItems_MaterialId]    Script Date: 6/14/2021 3:42:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_SalesOrderItems_MaterialId] ON [dbo].[SalesOrderItems]
(
	[MaterialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SalesOrderItems_SalesOrderId]    Script Date: 6/14/2021 3:42:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_SalesOrderItems_SalesOrderId] ON [dbo].[SalesOrderItems]
(
	[SalesOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Material] ADD  DEFAULT ((0.0)) FOR [Harga]
GO
ALTER TABLE [dbo].[Material]  WITH CHECK ADD  CONSTRAINT [FK_Material_Satuan_SatuanId] FOREIGN KEY([SatuanId])
REFERENCES [dbo].[Satuan] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Material] CHECK CONSTRAINT [FK_Material_Satuan_SatuanId]
GO
ALTER TABLE [dbo].[SalesOrder]  WITH CHECK ADD  CONSTRAINT [FK_SalesOrder_Customer_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SalesOrder] CHECK CONSTRAINT [FK_SalesOrder_Customer_CustomerId]
GO
ALTER TABLE [dbo].[SalesOrderItems]  WITH CHECK ADD  CONSTRAINT [FK_SalesOrderItems_Material_MaterialId] FOREIGN KEY([MaterialId])
REFERENCES [dbo].[Material] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[SalesOrderItems] CHECK CONSTRAINT [FK_SalesOrderItems_Material_MaterialId]
GO
ALTER TABLE [dbo].[SalesOrderItems]  WITH CHECK ADD  CONSTRAINT [FK_SalesOrderItems_SalesOrder_SalesOrderId] FOREIGN KEY([SalesOrderId])
REFERENCES [dbo].[SalesOrder] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SalesOrderItems] CHECK CONSTRAINT [FK_SalesOrderItems_SalesOrder_SalesOrderId]
GO
USE [master]
GO
ALTER DATABASE [DiginovasiDB] SET  READ_WRITE 
GO
