USE [master]
GO
/****** Object:  Database [DB_A63881_easybill]    Script Date: 13-07-2020 15:46:33 ******/
CREATE DATABASE [DB_A63881_easybill]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_A63881_easybill_Data', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DB_A63881_easybill_DATA.mdf' , SIZE = 8192KB , MAXSIZE = 1024000KB , FILEGROWTH = 10%)
 LOG ON 
( NAME = N'DB_A63881_easybill_Log', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DB_A63881_easybill_Log.LDF' , SIZE = 3072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DB_A63881_easybill] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_A63881_easybill].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_A63881_easybill] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_A63881_easybill] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_A63881_easybill] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_A63881_easybill] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_A63881_easybill] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_A63881_easybill] SET  MULTI_USER 
GO
ALTER DATABASE [DB_A63881_easybill] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_A63881_easybill] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_A63881_easybill] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_A63881_easybill] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_A63881_easybill] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_A63881_easybill] SET QUERY_STORE = OFF
GO
USE [DB_A63881_easybill]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 13-07-2020 15:46:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[billNumber] [nvarchar](30) NULL,
	[billerName] [nvarchar](30) NULL,
	[billType] [int] NULL,
	[billDate] [date] NULL,
	[billTotalAmount] [numeric](18, 3) NULL,
	[billTotalTax] [numeric](18, 3) NULL,
	[billTotalSGST] [numeric](18, 3) NULL,
	[billTotalCGST] [numeric](18, 3) NULL,
	[refPartyId] [int] NULL,
	[refPaymentId] [int] NULL,
	[refDeliveryId] [int] NULL,
	[createdAt] [date] NULL,
	[updatedAt] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[billNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryDetails]    Script Date: 13-07-2020 15:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[deliveryAddress] [nvarchar](max) NULL,
	[deliveryMode] [nvarchar](20) NULL,
	[deliveryCharge] [numeric](13, 3) NULL,
	[deliveryDate] [date] NULL,
	[createdAt] [date] NULL,
	[updatedAt] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartyDetails]    Script Date: 13-07-2020 15:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartyDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[partyName] [nvarchar](max) NULL,
	[gstNumber] [nvarchar](30) NULL,
	[panNumber] [nvarchar](12) NULL,
	[addressLine] [nvarchar](200) NULL,
	[city] [nvarchar](50) NULL,
	[stateInformation] [nvarchar](50) NULL,
	[zipcode] [int] NULL,
	[mobileNumber] [numeric](12, 0) NULL,
	[createdAt] [date] NULL,
	[updatedAt] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[panNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[gstNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentDetails]    Script Date: 13-07-2020 15:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[paymentAmount] [numeric](15, 3) NULL,
	[paymentDate] [date] NULL,
	[paymentMode] [int] NULL,
	[paymentReferenceNumber] [nvarchar](100) NULL,
	[paymentType] [nvarchar](100) NULL,
	[paymentStatus] [int] NULL,
	[billAmount] [numeric](15, 3) NULL,
	[createdAt] [date] NULL,
	[updatedAt] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentStatusMaster]    Script Date: 13-07-2020 15:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentStatusMaster](
	[paymentStatus] [nvarchar](30) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [date] NULL,
	[updatedAt] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentTypeMaster]    Script Date: 13-07-2020 15:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentTypeMaster](
	[paymentType] [nvarchar](30) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[createdAt] [date] NULL,
	[updatedAt] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [billType]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [billDate]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [updatedAt]
GO
ALTER TABLE [dbo].[DeliveryDetails] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[DeliveryDetails] ADD  DEFAULT (getdate()) FOR [updatedAt]
GO
ALTER TABLE [dbo].[PartyDetails] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[PartyDetails] ADD  DEFAULT (getdate()) FOR [updatedAt]
GO
ALTER TABLE [dbo].[PaymentDetails] ADD  DEFAULT (getdate()) FOR [paymentDate]
GO
ALTER TABLE [dbo].[PaymentDetails] ADD  DEFAULT ('NA') FOR [paymentReferenceNumber]
GO
ALTER TABLE [dbo].[PaymentDetails] ADD  DEFAULT ('Expense') FOR [paymentType]
GO
ALTER TABLE [dbo].[PaymentDetails] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[PaymentDetails] ADD  DEFAULT (getdate()) FOR [updatedAt]
GO
ALTER TABLE [dbo].[PaymentStatusMaster] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[PaymentStatusMaster] ADD  DEFAULT (getdate()) FOR [updatedAt]
GO
ALTER TABLE [dbo].[PaymentTypeMaster] ADD  DEFAULT (getdate()) FOR [createdAt]
GO
ALTER TABLE [dbo].[PaymentTypeMaster] ADD  DEFAULT (getdate()) FOR [updatedAt]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([refDeliveryId])
REFERENCES [dbo].[DeliveryDetails] ([Id])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([refDeliveryId])
REFERENCES [dbo].[DeliveryDetails] ([Id])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([refPartyId])
REFERENCES [dbo].[PartyDetails] ([Id])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([refPartyId])
REFERENCES [dbo].[PartyDetails] ([Id])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([refPaymentId])
REFERENCES [dbo].[PaymentDetails] ([Id])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([refPaymentId])
REFERENCES [dbo].[PaymentDetails] ([Id])
GO
ALTER TABLE [dbo].[PaymentDetails]  WITH CHECK ADD FOREIGN KEY([paymentMode])
REFERENCES [dbo].[PaymentTypeMaster] ([Id])
GO
ALTER TABLE [dbo].[PaymentDetails]  WITH CHECK ADD FOREIGN KEY([paymentStatus])
REFERENCES [dbo].[PaymentStatusMaster] ([Id])
GO
ALTER TABLE [dbo].[PaymentDetails]  WITH CHECK ADD FOREIGN KEY([paymentMode])
REFERENCES [dbo].[PaymentTypeMaster] ([Id])
GO
ALTER TABLE [dbo].[PaymentDetails]  WITH CHECK ADD FOREIGN KEY([paymentStatus])
REFERENCES [dbo].[PaymentStatusMaster] ([Id])
GO
USE [master]
GO
ALTER DATABASE [DB_A63881_easybill] SET  READ_WRITE 
GO
