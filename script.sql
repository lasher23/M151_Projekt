USE [master]
GO
/****** Object:  Database [mortgage]    Script Date: 01.05.2018 09:26:45 ******/
CREATE DATABASE [mortgage]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'mortgage', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\mortgage.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'mortgage_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\mortgage_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [mortgage] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mortgage].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [mortgage] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [mortgage] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [mortgage] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [mortgage] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [mortgage] SET ARITHABORT OFF 
GO
ALTER DATABASE [mortgage] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [mortgage] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [mortgage] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [mortgage] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [mortgage] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [mortgage] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [mortgage] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [mortgage] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [mortgage] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [mortgage] SET  ENABLE_BROKER 
GO
ALTER DATABASE [mortgage] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [mortgage] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [mortgage] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [mortgage] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [mortgage] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [mortgage] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [mortgage] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [mortgage] SET RECOVERY FULL 
GO
ALTER DATABASE [mortgage] SET  MULTI_USER 
GO
ALTER DATABASE [mortgage] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [mortgage] SET DB_CHAINING OFF 
GO
ALTER DATABASE [mortgage] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [mortgage] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [mortgage] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'mortgage', N'ON'
GO
ALTER DATABASE [mortgage] SET QUERY_STORE = OFF
GO
USE [mortgage]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [mortgage]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 01.05.2018 09:26:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[prename] [varchar](255) NULL,
	[familyName] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mortgage]    Script Date: 01.05.2018 09:26:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mortgage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[morgageName] [varchar](255) NULL,
	[rate] [float] NULL,
	[fk_risk] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MortgageCustomerAssignment]    Script Date: 01.05.2018 09:26:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MortgageCustomerAssignment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fk_customer] [int] NULL,
	[fk_mortgage] [int] NULL,
	[paidState] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Risk]    Script Date: 01.05.2018 09:26:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Risk](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[daysPlus] [int] NULL,
	[riskName] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([id], [prename], [familyName]) VALUES (2, N'fränzu', N'asd')
INSERT [dbo].[Customer] ([id], [prename], [familyName]) VALUES (3, N'fränzu', N'asd')
INSERT [dbo].[Customer] ([id], [prename], [familyName]) VALUES (1004, N'Hansi', N'Arschkucker')
INSERT [dbo].[Customer] ([id], [prename], [familyName]) VALUES (1005, N'Devin', N'Rüttimann')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Mortgage] ON 

INSERT [dbo].[Mortgage] ([id], [morgageName], [rate], [fk_risk]) VALUES (1, N'asfasdfsdf', 4.4444444444444446E+105, 3)
INSERT [dbo].[Mortgage] ([id], [morgageName], [rate], [fk_risk]) VALUES (2, N'Gute', 5, 1003)
SET IDENTITY_INSERT [dbo].[Mortgage] OFF
SET IDENTITY_INSERT [dbo].[MortgageCustomerAssignment] ON 

INSERT [dbo].[MortgageCustomerAssignment] ([id], [fk_customer], [fk_mortgage], [paidState]) VALUES (1003, 3, 1, NULL)
INSERT [dbo].[MortgageCustomerAssignment] ([id], [fk_customer], [fk_mortgage], [paidState]) VALUES (1004, 3, 1, NULL)
INSERT [dbo].[MortgageCustomerAssignment] ([id], [fk_customer], [fk_mortgage], [paidState]) VALUES (1005, 2, 1, NULL)
INSERT [dbo].[MortgageCustomerAssignment] ([id], [fk_customer], [fk_mortgage], [paidState]) VALUES (1006, 2, 1, NULL)
INSERT [dbo].[MortgageCustomerAssignment] ([id], [fk_customer], [fk_mortgage], [paidState]) VALUES (1007, 1005, 2, 0)
SET IDENTITY_INSERT [dbo].[MortgageCustomerAssignment] OFF
SET IDENTITY_INSERT [dbo].[Risk] ON 

INSERT [dbo].[Risk] ([id], [daysPlus], [riskName]) VALUES (1, 16, N'dasd')
INSERT [dbo].[Risk] ([id], [daysPlus], [riskName]) VALUES (2, 16, N'dasd')
INSERT [dbo].[Risk] ([id], [daysPlus], [riskName]) VALUES (3, 16, N'dasd')
INSERT [dbo].[Risk] ([id], [daysPlus], [riskName]) VALUES (1003, 100, N'Low')
SET IDENTITY_INSERT [dbo].[Risk] OFF
ALTER TABLE [dbo].[MortgageCustomerAssignment] ADD  DEFAULT ((0)) FOR [paidState]
GO
ALTER TABLE [dbo].[Mortgage]  WITH CHECK ADD FOREIGN KEY([fk_risk])
REFERENCES [dbo].[Risk] ([id])
GO
ALTER TABLE [dbo].[MortgageCustomerAssignment]  WITH CHECK ADD FOREIGN KEY([fk_customer])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[MortgageCustomerAssignment]  WITH CHECK ADD FOREIGN KEY([fk_mortgage])
REFERENCES [dbo].[Mortgage] ([id])
GO
USE [master]
GO
ALTER DATABASE [mortgage] SET  READ_WRITE 
GO
