CREATE DATABASE [20200305034] 
GO

USE [20200305034]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 22.05.2023 20:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[AdminName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 22.05.2023 20:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[bill_id] [int] NULL,
	[medication_id] [int] NULL,
	[customer_id] [int] NULL,
	[quantity] [int] NULL,
	[total_price] [decimal](10, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 22.05.2023 20:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customer_id] [int] NOT NULL,
	[first_name] [varchar](50) NULL,
	[last_name] [varchar](50) NULL,
	[phone] [varchar](20) NULL,
	[email] [varchar](100) NULL,
	[customer_adress] [varchar](200) NULL,
	[birthday] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 22.05.2023 20:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[Manufacturer_id] [int] NOT NULL,
	[Manufacturer_name] [varchar](50) NULL,
	[Manufacturer_adress] [varchar](100) NULL,
	[joindate] [date] NULL,
	[phone] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Manufacturer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicationTypes]    Script Date: 22.05.2023 20:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicationTypes](
	[MedicationType_id] [int] NOT NULL,
	[MedicationType_name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicationType_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicines]    Script Date: 22.05.2023 20:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicines](
	[medication_id] [int] NOT NULL,
	[medication_name] [varchar](100) NULL,
	[MedicationType_id] [int] NULL,
	[Manufacturer_id] [int] NULL,
	[stock_quantity] [int] NULL,
	[price] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[medication_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Selling]    Script Date: 22.05.2023 20:04:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Selling](
	[Selling_id] [int] NOT NULL,
	[medication_id] [int] NULL,
	[customer_id] [int] NULL,
	[sale_date] [date] NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Selling_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Admin] ([AdminName], [Password]) VALUES (N'deneme', N'admin123')
GO
INSERT [dbo].[Customers] ([customer_id], [first_name], [last_name], [phone], [email], [customer_adress], [birthday]) VALUES (1, N'Alice', N'Johnson', N'1234567890', N'alice@example.com', N'123 Main St, City', CAST(N'1990-01-01' AS Date))
INSERT [dbo].[Customers] ([customer_id], [first_name], [last_name], [phone], [email], [customer_adress], [birthday]) VALUES (2, N'Bob', N'Smith', N'9876543210', N'bob@example.com', N'456 Elm St, Town', CAST(N'1985-05-10' AS Date))
INSERT [dbo].[Customers] ([customer_id], [first_name], [last_name], [phone], [email], [customer_adress], [birthday]) VALUES (3, N'Charlie', N'Brown', N'5555555555', N'charlie@example.com', N'789 Oak St, Village', CAST(N'1992-08-15' AS Date))
INSERT [dbo].[Customers] ([customer_id], [first_name], [last_name], [phone], [email], [customer_adress], [birthday]) VALUES (4, N'Daisy', N'Davis', N'9998887777', N'daisy@example.com', N'321 Pine St, County', CAST(N'1998-12-20' AS Date))
INSERT [dbo].[Customers] ([customer_id], [first_name], [last_name], [phone], [email], [customer_adress], [birthday]) VALUES (5, N'Ethan', N'Wilson', N'1112223333', N'ethan@example.com', N'654 Cedar St, Borough', CAST(N'1995-06-25' AS Date))
GO
INSERT [dbo].[Manufacturer] ([Manufacturer_id], [Manufacturer_name], [Manufacturer_adress], [joindate], [phone]) VALUES (1, N'ABC Pharmaceuticals', N'123 Main St, City', CAST(N'2020-01-15' AS Date), N'1234567890')
INSERT [dbo].[Manufacturer] ([Manufacturer_id], [Manufacturer_name], [Manufacturer_adress], [joindate], [phone]) VALUES (2, N'XYZ Biotech', N'456 Elm St, Town', CAST(N'2019-05-20' AS Date), N'9876543210')
INSERT [dbo].[Manufacturer] ([Manufacturer_id], [Manufacturer_name], [Manufacturer_adress], [joindate], [phone]) VALUES (3, N'PQR Health Solutions', N'789 Oak St, Village', CAST(N'2018-07-10' AS Date), N'5555555555')
INSERT [dbo].[Manufacturer] ([Manufacturer_id], [Manufacturer_name], [Manufacturer_adress], [joindate], [phone]) VALUES (4, N'MNO Pharma', N'321 Pine St, County', CAST(N'2017-12-01' AS Date), N'9998887777')
INSERT [dbo].[Manufacturer] ([Manufacturer_id], [Manufacturer_name], [Manufacturer_adress], [joindate], [phone]) VALUES (5, N'DEF Medicines', N'654 Cedar St, Borough', CAST(N'2016-09-05' AS Date), N'1112223333')
INSERT [dbo].[Manufacturer] ([Manufacturer_id], [Manufacturer_name], [Manufacturer_adress], [joindate], [phone]) VALUES (6, N'GHI Laboratories', N'789 Maple Ave, District', CAST(N'2015-03-12' AS Date), N'7777777777')
INSERT [dbo].[Manufacturer] ([Manufacturer_id], [Manufacturer_name], [Manufacturer_adress], [joindate], [phone]) VALUES (7, N'JKL Healthcare', N'987 Oakwood Ln, Township', CAST(N'2014-06-30' AS Date), N'8888888888')
INSERT [dbo].[Manufacturer] ([Manufacturer_id], [Manufacturer_name], [Manufacturer_adress], [joindate], [phone]) VALUES (8, N'RST Pharmaceuticals', N'456 Willow Dr, Municipality', CAST(N'2013-09-18' AS Date), N'4444444444')
GO
INSERT [dbo].[MedicationTypes] ([MedicationType_id], [MedicationType_name]) VALUES (1, N'Painkillers')
INSERT [dbo].[MedicationTypes] ([MedicationType_id], [MedicationType_name]) VALUES (2, N'Antibiotics')
INSERT [dbo].[MedicationTypes] ([MedicationType_id], [MedicationType_name]) VALUES (3, N'Antidepressants')
INSERT [dbo].[MedicationTypes] ([MedicationType_id], [MedicationType_name]) VALUES (4, N'Antihistamines')
GO
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (1, N'Paracetamol', 1, 1, 75, CAST(10.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (2, N'Amoxicillin', 2, 2, 10, CAST(19.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (3, N'Ibuprofen', 1, 1, 68, CAST(8.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (4, N'Prozac', 3, 3, 60, CAST(15.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (5, N'Loratadine', 2, 4, 20, CAST(12.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (6, N'Zoloft', 3, 3, 30, CAST(9.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (7, N'Aspirin', 1, 2, 82, CAST(11.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (8, N'Penicillin', 2, 4, 35, CAST(17.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (9, N'Sertraline', 3, 3, 65, CAST(14.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (10, N'Naproxen', 1, 1, 106, CAST(16.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (11, N'Ciprofloxacin', 2, 2, 25, CAST(7.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (12, N'Fluoxetine', 3, 3, 40, CAST(13.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (13, N'Acetaminophen', 1, 2, 60, CAST(9.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (14, N'Metformin', 2, 4, 70, CAST(18.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (15, N'Escitalopram', 3, 3, 35, CAST(12.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (16, N'Omeprazole', 1, 1, 55, CAST(14.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (17, N'Simvastatin', 2, 2, 30, CAST(9.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (18, N'Lisinopril', 3, 3, 40, CAST(11.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (19, N'Atorvastatin', 1, 2, 65, CAST(16.99 AS Decimal(10, 2)))
INSERT [dbo].[Medicines] ([medication_id], [medication_name], [MedicationType_id], [Manufacturer_id], [stock_quantity], [price]) VALUES (20, N'Metoprolol', 2, 4, 45, CAST(13.99 AS Decimal(10, 2)))
GO
INSERT [dbo].[Selling] ([Selling_id], [medication_id], [customer_id], [sale_date], [quantity]) VALUES (1, 1, 1, CAST(N'2023-05-18' AS Date), 3)
INSERT [dbo].[Selling] ([Selling_id], [medication_id], [customer_id], [sale_date], [quantity]) VALUES (2, 2, 2, CAST(N'2023-05-18' AS Date), 2)
INSERT [dbo].[Selling] ([Selling_id], [medication_id], [customer_id], [sale_date], [quantity]) VALUES (3, 3, 3, CAST(N'2023-05-19' AS Date), 1)
INSERT [dbo].[Selling] ([Selling_id], [medication_id], [customer_id], [sale_date], [quantity]) VALUES (4, 4, 4, CAST(N'2023-05-19' AS Date), 4)
INSERT [dbo].[Selling] ([Selling_id], [medication_id], [customer_id], [sale_date], [quantity]) VALUES (5, 5, 5, CAST(N'2023-05-20' AS Date), 2)
INSERT [dbo].[Selling] ([Selling_id], [medication_id], [customer_id], [sale_date], [quantity]) VALUES (6, 6, 1, CAST(N'2023-05-20' AS Date), 3)
INSERT [dbo].[Selling] ([Selling_id], [medication_id], [customer_id], [sale_date], [quantity]) VALUES (7, 7, 2, CAST(N'2023-05-20' AS Date), 1)
INSERT [dbo].[Selling] ([Selling_id], [medication_id], [customer_id], [sale_date], [quantity]) VALUES (8, 8, 3, CAST(N'2023-05-20' AS Date), 2)
INSERT [dbo].[Selling] ([Selling_id], [medication_id], [customer_id], [sale_date], [quantity]) VALUES (9, 9, 4, CAST(N'2023-05-20' AS Date), 1)
INSERT [dbo].[Selling] ([Selling_id], [medication_id], [customer_id], [sale_date], [quantity]) VALUES (10, 10, 5, CAST(N'2023-05-20' AS Date), 4)
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Customers] FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customers] ([customer_id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Customers]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Medicines] FOREIGN KEY([medication_id])
REFERENCES [dbo].[Medicines] ([medication_id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Medicines]
GO
ALTER TABLE [dbo].[Medicines]  WITH CHECK ADD FOREIGN KEY([Manufacturer_id])
REFERENCES [dbo].[Manufacturer] ([Manufacturer_id])
GO
ALTER TABLE [dbo].[Medicines]  WITH CHECK ADD FOREIGN KEY([MedicationType_id])
REFERENCES [dbo].[MedicationTypes] ([MedicationType_id])
GO
ALTER TABLE [dbo].[Selling]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customers] ([customer_id])
GO
ALTER TABLE [dbo].[Selling]  WITH CHECK ADD FOREIGN KEY([medication_id])
REFERENCES [dbo].[Medicines] ([medication_id])
GO
