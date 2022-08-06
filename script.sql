USE [master]
GO
/****** Object:  Database [MetroDB]    Script Date: 06.08.2022 14:44:44 ******/
CREATE DATABASE [MetroDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MetroDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MetroDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MetroDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MetroDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MetroDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MetroDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MetroDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MetroDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MetroDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MetroDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MetroDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MetroDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MetroDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MetroDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MetroDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MetroDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MetroDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MetroDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MetroDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MetroDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MetroDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MetroDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MetroDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MetroDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MetroDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MetroDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MetroDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MetroDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MetroDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MetroDB] SET  MULTI_USER 
GO
ALTER DATABASE [MetroDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MetroDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MetroDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MetroDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MetroDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MetroDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MetroDB] SET QUERY_STORE = OFF
GO
USE [MetroDB]
GO
/****** Object:  Table [dbo].[Depot]    Script Date: 06.08.2022 14:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Depot](
	[IdDepot] [int] IDENTITY(1,1) NOT NULL,
	[NameDepot] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_Depot] PRIMARY KEY CLUSTERED 
(
	[IdDepot] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepotMetroLine]    Script Date: 06.08.2022 14:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepotMetroLine](
	[IdMetroLineDepot] [int] IDENTITY(1,1) NOT NULL,
	[IdDepot] [int] NOT NULL,
	[IdMetroLine] [int] NOT NULL,
 CONSTRAINT [PK_DepotMetroLine] PRIMARY KEY CLUSTERED 
(
	[IdMetroLineDepot] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MetroLine]    Script Date: 06.08.2022 14:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MetroLine](
	[IdMetroLine] [int] IDENTITY(1,1) NOT NULL,
	[NameMetroLine] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_MetroLines] PRIMARY KEY CLUSTERED 
(
	[IdMetroLine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 06.08.2022 14:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[IdReport] [int] IDENTITY(1,1) NOT NULL,
	[TextReport] [nvarchar](max) NOT NULL,
	[DateOfReport] [date] NOT NULL,
	[IdStaff] [int] NOT NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[IdReport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 06.08.2022 14:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[NameRole] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 06.08.2022 14:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[IdStaff] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](40) NOT NULL,
	[NameStaff] [nvarchar](40) NOT NULL,
	[Patronymic] [nvarchar](40) NULL,
	[IdDepot] [int] NOT NULL,
	[DateOfBitrh] [date] NOT NULL,
	[Photo] [varbinary](max) NULL,
	[IdUser] [int] NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[IdStaff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 06.08.2022 14:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[IdStatus] [int] IDENTITY(1,1) NOT NULL,
	[NameStatus] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[IdStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeTrain]    Script Date: 06.08.2022 14:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeTrain](
	[IdTypeTrain] [int] IDENTITY(1,1) NOT NULL,
	[NumberTypeTrain] [nvarchar](20) NOT NULL,
	[NameTypeTrain] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TypeTrain] PRIMARY KEY CLUSTERED 
(
	[IdTypeTrain] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 06.08.2022 14:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](35) NOT NULL,
	[Password] [nvarchar](35) NOT NULL,
	[IdRole] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VanTrain]    Script Date: 06.08.2022 14:44:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VanTrain](
	[IdVanTrain] [int] IDENTITY(1,1) NOT NULL,
	[SerialNumber] [nvarchar](10) NOT NULL,
	[DateOfRelease] [date] NOT NULL,
	[IdDepot] [int] NOT NULL,
	[IdStatus] [int] NOT NULL,
	[IdTypeTrain] [int] NOT NULL,
 CONSTRAINT [PK_VanTrain] PRIMARY KEY CLUSTERED 
(
	[IdVanTrain] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Depot] ON 

INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (1, N'Братеево')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (2, N'Варшавское')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (3, N'Владыкино')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (4, N'Выхино')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (5, N'Замоскворецкое')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (6, N'Измайлово')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (7, N'Калужское')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (8, N'Красная Пресня')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (9, N'Лихоборы')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (10, N'Митино')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (11, N'Новогиреево')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (12, N'Печатники')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (13, N'Планерное')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (14, N'Руднево')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (15, N'Свиблово')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (16, N'Северное')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (17, N'Сокол')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (18, N'Солнцево')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (19, N'Фили')
INSERT [dbo].[Depot] ([IdDepot], [NameDepot]) VALUES (20, N'Черкизово')
SET IDENTITY_INSERT [dbo].[Depot] OFF
GO
SET IDENTITY_INSERT [dbo].[DepotMetroLine] ON 

INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (1, 1, 2)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (2, 2, 9)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (3, 2, 12)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (4, 3, 9)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (5, 4, 7)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (6, 5, 2)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (7, 5, 11)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (8, 6, 3)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (9, 7, 6)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (10, 8, 5)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (11, 9, 10)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (12, 10, 3)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (13, 11, 8)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (14, 12, 10)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (15, 13, 7)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (16, 14, 13)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (17, 15, 6)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (18, 16, 1)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (19, 17, 2)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (20, 18, 8)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (21, 19, 4)
INSERT [dbo].[DepotMetroLine] ([IdMetroLineDepot], [IdDepot], [IdMetroLine]) VALUES (22, 20, 1)
SET IDENTITY_INSERT [dbo].[DepotMetroLine] OFF
GO
SET IDENTITY_INSERT [dbo].[MetroLine] ON 

INSERT [dbo].[MetroLine] ([IdMetroLine], [NameMetroLine]) VALUES (3, N'Арбатско-Покровская')
INSERT [dbo].[MetroLine] ([IdMetroLine], [NameMetroLine]) VALUES (11, N'Большая Кольцевая')
INSERT [dbo].[MetroLine] ([IdMetroLine], [NameMetroLine]) VALUES (12, N'Бутовская')
INSERT [dbo].[MetroLine] ([IdMetroLine], [NameMetroLine]) VALUES (2, N'Замоскворецкая')
INSERT [dbo].[MetroLine] ([IdMetroLine], [NameMetroLine]) VALUES (8, N'Калининско-Солнцевская')
INSERT [dbo].[MetroLine] ([IdMetroLine], [NameMetroLine]) VALUES (6, N'Калужско-Рижская')
INSERT [dbo].[MetroLine] ([IdMetroLine], [NameMetroLine]) VALUES (5, N'Кольцевая')
INSERT [dbo].[MetroLine] ([IdMetroLine], [NameMetroLine]) VALUES (10, N'Люблинско-Дмитровская')
INSERT [dbo].[MetroLine] ([IdMetroLine], [NameMetroLine]) VALUES (13, N'Некрасовская')
INSERT [dbo].[MetroLine] ([IdMetroLine], [NameMetroLine]) VALUES (9, N'Серпуховско-Тимирязевская')
INSERT [dbo].[MetroLine] ([IdMetroLine], [NameMetroLine]) VALUES (1, N'Сокольническая')
INSERT [dbo].[MetroLine] ([IdMetroLine], [NameMetroLine]) VALUES (7, N'Таганско-Краснопресненская')
INSERT [dbo].[MetroLine] ([IdMetroLine], [NameMetroLine]) VALUES (4, N'Филевская')
SET IDENTITY_INSERT [dbo].[MetroLine] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([IdRole], [NameRole]) VALUES (1, N'Администратор')
INSERT [dbo].[Role] ([IdRole], [NameRole]) VALUES (2, N'Сотрудник')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([IdStaff], [Surname], [NameStaff], [Patronymic], [IdDepot], [DateOfBitrh], [Photo], [IdUser]) VALUES (1, N'Васильев', N'Антон', N'Павлович', 1, CAST(N'1998-12-19' AS Date), NULL, 2)
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([IdStatus], [NameStatus]) VALUES (2, N'Капитальный ремонт')
INSERT [dbo].[Status] ([IdStatus], [NameStatus]) VALUES (1, N'На линии')
INSERT [dbo].[Status] ([IdStatus], [NameStatus]) VALUES (4, N'Порезан')
INSERT [dbo].[Status] ([IdStatus], [NameStatus]) VALUES (3, N'Списан')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeTrain] ON 

INSERT [dbo].[TypeTrain] ([IdTypeTrain], [NumberTypeTrain], [NameTypeTrain]) VALUES (1, N'81-717', N'Номерной')
INSERT [dbo].[TypeTrain] ([IdTypeTrain], [NumberTypeTrain], [NameTypeTrain]) VALUES (2, N'81-714', N'Номерной')
INSERT [dbo].[TypeTrain] ([IdTypeTrain], [NumberTypeTrain], [NameTypeTrain]) VALUES (3, N'81-740', N'Русич')
INSERT [dbo].[TypeTrain] ([IdTypeTrain], [NumberTypeTrain], [NameTypeTrain]) VALUES (4, N'81-741', N'Русич')
INSERT [dbo].[TypeTrain] ([IdTypeTrain], [NumberTypeTrain], [NameTypeTrain]) VALUES (5, N'81-765', N'Москва')
SET IDENTITY_INSERT [dbo].[TypeTrain] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([IdUser], [Login], [Password], [IdRole]) VALUES (1, N'admin', N'admin', 1)
INSERT [dbo].[User] ([IdUser], [Login], [Password], [IdRole]) VALUES (2, N'user', N'user', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[VanTrain] ON 

INSERT [dbo].[VanTrain] ([IdVanTrain], [SerialNumber], [DateOfRelease], [IdDepot], [IdStatus], [IdTypeTrain]) VALUES (1, N'2141331', CAST(N'1995-12-12' AS Date), 1, 1, 1)
INSERT [dbo].[VanTrain] ([IdVanTrain], [SerialNumber], [DateOfRelease], [IdDepot], [IdStatus], [IdTypeTrain]) VALUES (2, N'5754685', CAST(N'1998-09-09' AS Date), 1, 2, 2)
SET IDENTITY_INSERT [dbo].[VanTrain] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Depot_NameDepot]    Script Date: 06.08.2022 14:44:44 ******/
ALTER TABLE [dbo].[Depot] ADD  CONSTRAINT [UQ_Depot_NameDepot] UNIQUE NONCLUSTERED 
(
	[NameDepot] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_MetroLines_NameMetroLines]    Script Date: 06.08.2022 14:44:44 ******/
ALTER TABLE [dbo].[MetroLine] ADD  CONSTRAINT [UQ_MetroLines_NameMetroLines] UNIQUE NONCLUSTERED 
(
	[NameMetroLine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Role_NameRole]    Script Date: 06.08.2022 14:44:44 ******/
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [UQ_Role_NameRole] UNIQUE NONCLUSTERED 
(
	[NameRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Staff_IdUser]    Script Date: 06.08.2022 14:44:44 ******/
ALTER TABLE [dbo].[Staff] ADD  CONSTRAINT [UQ_Staff_IdUser] UNIQUE NONCLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Status_NameStatus]    Script Date: 06.08.2022 14:44:44 ******/
ALTER TABLE [dbo].[Status] ADD  CONSTRAINT [UQ_Status_NameStatus] UNIQUE NONCLUSTERED 
(
	[NameStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_NumberTypeTrain_TypeTrain]    Script Date: 06.08.2022 14:44:44 ******/
ALTER TABLE [dbo].[TypeTrain] ADD  CONSTRAINT [UQ_NumberTypeTrain_TypeTrain] UNIQUE NONCLUSTERED 
(
	[NumberTypeTrain] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_User_Login]    Script Date: 06.08.2022 14:44:44 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UQ_User_Login] UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_SerialNumber_VanTrain]    Script Date: 06.08.2022 14:44:44 ******/
ALTER TABLE [dbo].[VanTrain] ADD  CONSTRAINT [UQ_SerialNumber_VanTrain] UNIQUE NONCLUSTERED 
(
	[SerialNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DepotMetroLine]  WITH CHECK ADD  CONSTRAINT [FK_DepotMetroLine_Depot] FOREIGN KEY([IdDepot])
REFERENCES [dbo].[Depot] ([IdDepot])
GO
ALTER TABLE [dbo].[DepotMetroLine] CHECK CONSTRAINT [FK_DepotMetroLine_Depot]
GO
ALTER TABLE [dbo].[DepotMetroLine]  WITH CHECK ADD  CONSTRAINT [FK_DepotMetroLine_MetroLine] FOREIGN KEY([IdMetroLine])
REFERENCES [dbo].[MetroLine] ([IdMetroLine])
GO
ALTER TABLE [dbo].[DepotMetroLine] CHECK CONSTRAINT [FK_DepotMetroLine_MetroLine]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_Staff] FOREIGN KEY([IdStaff])
REFERENCES [dbo].[Staff] ([IdStaff])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_Staff]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Depot] FOREIGN KEY([IdDepot])
REFERENCES [dbo].[Depot] ([IdDepot])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Depot]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([IdRole])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[VanTrain]  WITH CHECK ADD  CONSTRAINT [FK_VanTrain_Depot] FOREIGN KEY([IdDepot])
REFERENCES [dbo].[Depot] ([IdDepot])
GO
ALTER TABLE [dbo].[VanTrain] CHECK CONSTRAINT [FK_VanTrain_Depot]
GO
ALTER TABLE [dbo].[VanTrain]  WITH CHECK ADD  CONSTRAINT [FK_VanTrain_Status] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[Status] ([IdStatus])
GO
ALTER TABLE [dbo].[VanTrain] CHECK CONSTRAINT [FK_VanTrain_Status]
GO
ALTER TABLE [dbo].[VanTrain]  WITH CHECK ADD  CONSTRAINT [FK_VanTrain_TypeTrain] FOREIGN KEY([IdTypeTrain])
REFERENCES [dbo].[TypeTrain] ([IdTypeTrain])
GO
ALTER TABLE [dbo].[VanTrain] CHECK CONSTRAINT [FK_VanTrain_TypeTrain]
GO
USE [master]
GO
ALTER DATABASE [MetroDB] SET  READ_WRITE 
GO
