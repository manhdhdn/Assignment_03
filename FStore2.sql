USE [master]
GO
/****** Object:  Database [FStore2]    Script Date: 20/07/2022 10:37:57 PM ******/
CREATE DATABASE [FStore2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FStore2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FStore2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FStore2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FStore2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FStore2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FStore2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FStore2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FStore2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FStore2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FStore2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FStore2] SET ARITHABORT OFF 
GO
ALTER DATABASE [FStore2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FStore2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FStore2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FStore2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FStore2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FStore2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FStore2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FStore2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FStore2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FStore2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FStore2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FStore2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FStore2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FStore2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FStore2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FStore2] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [FStore2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FStore2] SET RECOVERY FULL 
GO
ALTER DATABASE [FStore2] SET  MULTI_USER 
GO
ALTER DATABASE [FStore2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FStore2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FStore2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FStore2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FStore2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FStore2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FStore2', N'ON'
GO
ALTER DATABASE [FStore2] SET QUERY_STORE = OFF
GO
USE [FStore2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 20/07/2022 10:37:58 PM ******/
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
/****** Object:  Table [dbo].[Members]    Script Date: 20/07/2022 10:37:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[MemberId] [int] NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[CompanyName] [nvarchar](40) NOT NULL,
	[City] [nvarchar](15) NOT NULL,
	[Country] [nvarchar](15) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 20/07/2022 10:37:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [float] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 20/07/2022 10:37:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[RequiredDate] [datetime2](7) NULL,
	[ShippedDate] [datetime2](7) NULL,
	[Freight] [money] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 20/07/2022 10:37:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProductName] [nvarchar](40) NOT NULL,
	[Weight] [nvarchar](20) NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[UnitInStock] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220629023504_InitDatabase', N'6.0.6')
GO
INSERT [dbo].[Members] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (1, N'manhdh@gmail.com', N'FPT', N'HCM', N'Vietnam', N'123')
INSERT [dbo].[Members] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (2, N'thientlp@gmail.com', N'Hutech', N'Hanoi', N'Vietnam', N'123')
INSERT [dbo].[Members] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (3, N'locnq@gmail.com', N'Apple', N'Tokyo', N'Japan', N'123')
INSERT [dbo].[Members] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (4, N'tamnt@gmail.com', N'Shiba', N'Seoul', N'Korea', N'123')
GO
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (1, 2, 32000.0000, 2, 0.03)
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (2, 2, 32000.0000, 2, 0.03)
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (3, 4, 12000.0000, 5, 0.05)
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (4, 8, 28400.0000, 1, 0)
GO
INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (1, 1, CAST(N'2022-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-02T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-02T12:15:00.0000000' AS DateTime2), 10000.0000)
INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (2, 2, CAST(N'2022-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-02T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-03T00:00:00.0000000' AS DateTime2), 11000.0000)
INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (3, 3, CAST(N'2022-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-02T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-03T00:00:00.0000000' AS DateTime2), 12000.0000)
INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (4, 4, CAST(N'2022-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-02T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-03T00:00:00.0000000' AS DateTime2), 13000.0000)
GO
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (1, 1, N'Pork two slices', N'150g', 26000.0000, 80)
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (2, 1, N'Beef 2 slices', N'170g', 32000.0000, 10)
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (3, 1, N'Beef stew', N'150g', 36800.0000, 22)
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (4, 1, N'Ketchup fish', N'150g', 12000.0000, 30)
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (5, 2, N'Da Lat cabbage', N'1kg', 23125.0000, 28)
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (6, 2, N'Phuoc An gourd fruit', N'500g', 10500.0000, 25)
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (7, 3, N'KitKat', N'38g', 15200.0000, 24)
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitInStock]) VALUES (8, 3, N'Xylitol', N'58g', 28400.0000, 23)
GO
/****** Object:  Index [IX_OrderDetails_OrderId]    Script Date: 20/07/2022 10:37:58 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderId] ON [dbo].[OrderDetails]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_ProductId]    Script Date: 20/07/2022 10:37:58 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductId] ON [dbo].[OrderDetails]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_MemberId]    Script Date: 20/07/2022 10:37:58 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_MemberId] ON [dbo].[Orders]
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Members_MemberId] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Members_MemberId]
GO
USE [master]
GO
ALTER DATABASE [FStore2] SET  READ_WRITE 
GO
