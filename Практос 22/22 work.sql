USE [master]
GO
/****** Object:  Database [EditionsCity]    Script Date: 21.04.2025 10:53:41 ******/
CREATE DATABASE [EditionsCity]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EditionsCity', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EditionsCity.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'EditionsCity_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EditionsCity_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EditionsCity] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EditionsCity].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EditionsCity] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EditionsCity] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EditionsCity] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EditionsCity] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EditionsCity] SET ARITHABORT OFF 
GO
ALTER DATABASE [EditionsCity] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EditionsCity] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EditionsCity] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EditionsCity] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EditionsCity] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EditionsCity] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EditionsCity] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EditionsCity] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EditionsCity] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EditionsCity] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EditionsCity] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EditionsCity] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EditionsCity] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EditionsCity] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EditionsCity] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EditionsCity] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EditionsCity] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EditionsCity] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EditionsCity] SET  MULTI_USER 
GO
ALTER DATABASE [EditionsCity] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EditionsCity] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EditionsCity] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EditionsCity] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [EditionsCity] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EditionsCity] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EditionsCity] SET QUERY_STORE = OFF
GO
USE [EditionsCity]
GO
/****** Object:  Table [dbo].[Edition]    Script Date: 21.04.2025 10:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Edition](
	[Index] [int] IDENTITY(1,1) NOT NULL,
	[TitleEdition] [nvarchar](255) NOT NULL,
	[Type] [nvarchar](255) NULL,
	[PageCount] [int] NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Photo] [image] NULL,
 CONSTRAINT [PK_Editions] PRIMARY KEY CLUSTERED 
(
	[Index] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 21.04.2025 10:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[Code] [int] IDENTITY(1,1) NOT NULL,
	[TitleOrganization] [nvarchar](255) NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[NumberEmployees] [int] NOT NULL,
 CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 21.04.2025 10:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscription]    Script Date: 21.04.2025 10:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscription](
	[SubscriptionNumber] [int] IDENTITY(1,1) NOT NULL,
	[SubscriptionDate] [datetime] NOT NULL,
	[NumberMonths] [int] NOT NULL,
	[Discount] [numeric](12, 2) NOT NULL,
	[Index] [int] NOT NULL,
	[Code] [int] NOT NULL,
 CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED 
(
	[SubscriptionNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 21.04.2025 10:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] NOT NULL,
	[UserSurname] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserPatronymic] [nvarchar](50) NULL,
	[UserLogin] [nvarchar](50) NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
	[UserRole] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Edition] ON 

INSERT [dbo].[Edition] ([Index], [TitleEdition], [Type], [PageCount], [Price], [Photo]) VALUES (1, N'Панорама', N'газета', 30, CAST(12.0000 AS Decimal(18, 4)), NULL)
INSERT [dbo].[Edition] ([Index], [TitleEdition], [Type], [PageCount], [Price], [Photo]) VALUES (2, N'Телесемь', N'газета', 40, CAST(15.0000 AS Decimal(18, 4)), NULL)
INSERT [dbo].[Edition] ([Index], [TitleEdition], [Type], [PageCount], [Price], [Photo]) VALUES (3, N'I Love You', NULL, 60, CAST(30.0000 AS Decimal(18, 4)), NULL)
INSERT [dbo].[Edition] ([Index], [TitleEdition], [Type], [PageCount], [Price], [Photo]) VALUES (4, N'Лиза', N'журнал', 70, CAST(35.0000 AS Decimal(18, 4)), NULL)
INSERT [dbo].[Edition] ([Index], [TitleEdition], [Type], [PageCount], [Price], [Photo]) VALUES (5, N'Из рук в руки', N'газета', 50, CAST(7.0000 AS Decimal(18, 4)), NULL)
INSERT [dbo].[Edition] ([Index], [TitleEdition], [Type], [PageCount], [Price], [Photo]) VALUES (6, N'Ярмарка', NULL, 100, CAST(10.0000 AS Decimal(18, 4)), NULL)
INSERT [dbo].[Edition] ([Index], [TitleEdition], [Type], [PageCount], [Price], [Photo]) VALUES (7, N'Maxim', N'журнал', 150, CAST(90.0000 AS Decimal(18, 4)), NULL)
INSERT [dbo].[Edition] ([Index], [TitleEdition], [Type], [PageCount], [Price], [Photo]) VALUES (8, N'Мир новостей', N'газета', 70, CAST(15.0000 AS Decimal(18, 4)), NULL)
INSERT [dbo].[Edition] ([Index], [TitleEdition], [Type], [PageCount], [Price], [Photo]) VALUES (9, N'Cosmo', N'журнал', 100, CAST(100.0000 AS Decimal(18, 4)), NULL)
INSERT [dbo].[Edition] ([Index], [TitleEdition], [Type], [PageCount], [Price], [Photo]) VALUES (10, N'Yoi', N'журнал', 80, CAST(60.0000 AS Decimal(18, 4)), NULL)
SET IDENTITY_INSERT [dbo].[Edition] OFF
GO
SET IDENTITY_INSERT [dbo].[Organization] ON 

INSERT [dbo].[Organization] ([Code], [TitleOrganization], [Address], [Phone], [NumberEmployees]) VALUES (1, N'ООО МобПро', N'Декабристов, 12', N'745504', 100)
INSERT [dbo].[Organization] ([Code], [TitleOrganization], [Address], [Phone], [NumberEmployees]) VALUES (2, N'ООО Опекс', N'Ленинградский пр-т, 62', N'771619', 50)
INSERT [dbo].[Organization] ([Code], [TitleOrganization], [Address], [Phone], [NumberEmployees]) VALUES (3, N'ООО Росгидромет', N'Кутузовский пр-ь,26', NULL, 30)
INSERT [dbo].[Organization] ([Code], [TitleOrganization], [Address], [Phone], [NumberEmployees]) VALUES (4, N'ООО Балттекстиль', N'Мичуринский пр-т,3', N'925116', 150)
INSERT [dbo].[Organization] ([Code], [TitleOrganization], [Address], [Phone], [NumberEmployees]) VALUES (5, N'ООО СторойДом', N'Ленина, 3', N'854128', 40)
INSERT [dbo].[Organization] ([Code], [TitleOrganization], [Address], [Phone], [NumberEmployees]) VALUES (6, N'ЗАО Виаско', N'Первомайский пр-т, 7', N'651298', 15)
INSERT [dbo].[Organization] ([Code], [TitleOrganization], [Address], [Phone], [NumberEmployees]) VALUES (7, N'ООО Интертехно', N'Гагарина,5', N'123456', 10)
INSERT [dbo].[Organization] ([Code], [TitleOrganization], [Address], [Phone], [NumberEmployees]) VALUES (8, N'ОООАвиаценна', N'Почтовая, 9', NULL, 25)
INSERT [dbo].[Organization] ([Code], [TitleOrganization], [Address], [Phone], [NumberEmployees]) VALUES (9, N'ООО Артурпроект', N'Полевая, 3', N'883356', 30)
INSERT [dbo].[Organization] ([Code], [TitleOrganization], [Address], [Phone], [NumberEmployees]) VALUES (10, N'ОАО Биопрепарат', N'Первомайский пр-т, 14', NULL, 90)
SET IDENTITY_INSERT [dbo].[Organization] OFF
GO
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Администратор')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Менеджер')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (3, N'Зарегестрированный пользователь')
GO
SET IDENTITY_INSERT [dbo].[Subscription] ON 

INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (1, CAST(N'2020-01-06T00:00:00.000' AS DateTime), 5, CAST(0.02 AS Numeric(12, 2)), 1, 3)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (2, CAST(N'2020-01-06T00:00:00.000' AS DateTime), 3, CAST(0.01 AS Numeric(12, 2)), 9, 5)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (3, CAST(N'2020-01-08T00:00:00.000' AS DateTime), 7, CAST(0.12 AS Numeric(12, 2)), 1, 7)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (4, CAST(N'2020-02-21T00:00:00.000' AS DateTime), 3, CAST(0.00 AS Numeric(12, 2)), 2, 5)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (5, CAST(N'2020-03-15T00:00:00.000' AS DateTime), 3, CAST(0.02 AS Numeric(12, 2)), 2, 8)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (6, CAST(N'2020-03-29T00:00:00.000' AS DateTime), 7, CAST(0.00 AS Numeric(12, 2)), 3, 6)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (7, CAST(N'2020-04-03T00:00:00.000' AS DateTime), 4, CAST(0.50 AS Numeric(12, 2)), 3, 10)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (8, CAST(N'2020-03-12T00:00:00.000' AS DateTime), 2, CAST(0.40 AS Numeric(12, 2)), 5, 3)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (9, CAST(N'2020-03-22T00:00:00.000' AS DateTime), 8, CAST(0.07 AS Numeric(12, 2)), 2, 7)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (10, CAST(N'2020-04-07T00:00:00.000' AS DateTime), 5, CAST(0.56 AS Numeric(12, 2)), 1, 9)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (11, CAST(N'2020-04-11T00:00:00.000' AS DateTime), 12, CAST(0.02 AS Numeric(12, 2)), 10, 1)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (12, CAST(N'2020-04-19T00:00:00.000' AS DateTime), 11, CAST(0.00 AS Numeric(12, 2)), 3, 6)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (13, CAST(N'2020-04-27T00:00:00.000' AS DateTime), 4, CAST(0.09 AS Numeric(12, 2)), 7, 9)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (14, CAST(N'2020-05-08T00:00:00.000' AS DateTime), 8, CAST(0.08 AS Numeric(12, 2)), 8, 8)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (15, CAST(N'2020-05-14T00:00:00.000' AS DateTime), 12, CAST(0.30 AS Numeric(12, 2)), 5, 3)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (16, CAST(N'2020-05-23T00:00:00.000' AS DateTime), 8, CAST(0.00 AS Numeric(12, 2)), 6, 1)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (17, CAST(N'2020-06-09T00:00:00.000' AS DateTime), 10, CAST(0.60 AS Numeric(12, 2)), 5, 2)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (18, CAST(N'2020-06-15T00:00:00.000' AS DateTime), 6, CAST(0.45 AS Numeric(12, 2)), 2, 7)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (19, CAST(N'2020-06-19T00:00:00.000' AS DateTime), 4, CAST(0.01 AS Numeric(12, 2)), 1, 1)
INSERT [dbo].[Subscription] ([SubscriptionNumber], [SubscriptionDate], [NumberMonths], [Discount], [Index], [Code]) VALUES (20, CAST(N'2020-06-25T00:00:00.000' AS DateTime), 12, CAST(0.90 AS Numeric(12, 2)), 10, 10)
SET IDENTITY_INSERT [dbo].[Subscription] OFF
GO
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (1, N'Gott', N'mit', N'ust', N'Admi', N'333', 1)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (2, N'Veni', N'vidi', N'vici', N'Men', N'999', 2)
INSERT [dbo].[User] ([UserID], [UserSurname], [UserName], [UserPatronymic], [UserLogin], [UserPassword], [UserRole]) VALUES (3, N'Андрианов', N'Алексей', N'Олегович', N'Player', N'666', 3)
GO
ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_Edition] FOREIGN KEY([Index])
REFERENCES [dbo].[Edition] ([Index])
GO
ALTER TABLE [dbo].[Subscription] CHECK CONSTRAINT [FK_Subscription_Edition]
GO
ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_Organization] FOREIGN KEY([Code])
REFERENCES [dbo].[Organization] ([Code])
GO
ALTER TABLE [dbo].[Subscription] CHECK CONSTRAINT [FK_Subscription_Organization]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([UserRole])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [EditionsCity] SET  READ_WRITE 
GO
