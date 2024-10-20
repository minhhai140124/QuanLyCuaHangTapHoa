CREATE DATABASE [quantaphoa]
USE [quantaphoa]
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CatalogId] [int] NULL,
	[Picture] [nvarchar](max) NULL,
	[ProductName] [nvarchar](250) NULL,
	[ProductCode] [nvarchar](50) NULL,
	[PriceOld] [float] NULL,
	[ProductSale] [nvarchar](50) NULL,
	[UnitPrice] [float] NULL,
	[SoLuong] [int] NULL,
	[ProductSold] [int] NULL,
	[NgayNhapHang] [date] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[UF_SelectAllProduct]    Script Date: 7/11/2024 2:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[UF_SelectAllProduct]()
RETURNS TABLE 
AS RETURN SELECT * FROM dbo.Product
GO
/****** Object:  Table [dbo].[Catalog]    Script Date: 7/11/2024 2:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Catalog](
	[ID] [int] NOT NULL,
	[CatalogCode] [nvarchar](50) NULL,
	[CatalogName] [nvarchar](250) NULL,
	[ProductOrigin] [nvarchar](50) NULL,
 CONSTRAINT [PK_Catalog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 7/11/2024 2:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaChucVu] [int] IDENTITY(1,1) NOT NULL,
	[ChucVu] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 7/11/2024 2:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Picture] [nvarchar](max) NULL,
	[Address] [nvarchar](250) NULL,
	[NgaySinh] [date] NULL,
	[CMT] [nvarchar](50) NULL,
	[Sdt] [char](10) NULL,
	[TichLuy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 7/11/2024 2:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](250) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[NgaySinh] [date] NULL,
	[Password] [nvarchar](50) NULL,
	[MaChucVu] [int] NULL,
	[Picture] [nvarchar](max) NULL,
	[Sex] [bit] NULL,
	[Sdt] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 7/11/2024 2:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Payment] [bit] NULL,
	[NgayDat] [datetime] NULL,
	[NgayGiao] [datetime] NULL,
	[ThanhTien] [float] NULL,
	[TongSoLuong] [int] NULL,
	[Id_NV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Detail]    Script Date: 7/11/2024 2:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Detail](
	[ID_Order] [int] NOT NULL,
	[ID_Product] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[Price] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Order] ASC,
	[ID_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Status]    Script Date: 7/11/2024 2:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Status](
	[Status] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Catalog] ([ID], [CatalogCode], [CatalogName], [ProductOrigin]) VALUES (1, N'1', N'Các loại đồ ăn lạnh', N'Mỹ')
INSERT [dbo].[Catalog] ([ID], [CatalogCode], [CatalogName], [ProductOrigin]) VALUES (2, N'2', N'Các loại đồ ăn nhanh', NULL)
INSERT [dbo].[Catalog] ([ID], [CatalogCode], [CatalogName], [ProductOrigin]) VALUES (3, N'3', N'Các loại đồ uống', NULL)
INSERT [dbo].[Catalog] ([ID], [CatalogCode], [CatalogName], [ProductOrigin]) VALUES (4, N'4', N'Thực phẩm khô', NULL)
INSERT [dbo].[Catalog] ([ID], [CatalogCode], [CatalogName], [ProductOrigin]) VALUES (5, N'5', N'Thực phẩm đóng hộp', NULL)
INSERT [dbo].[Catalog] ([ID], [CatalogCode], [CatalogName], [ProductOrigin]) VALUES (6, N'6', N'Gia vị', NULL)
GO
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([MaChucVu], [ChucVu]) VALUES (1, N'Nhân Viên Bán Hàng')
INSERT [dbo].[ChucVu] ([MaChucVu], [ChucVu]) VALUES (2, N'Quản Trị Viên')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([idUser], [FirstName], [LastName], [Email], [Password], [Picture], [Address], [NgaySinh], [CMT], [Sdt], [TichLuy]) VALUES (1053, N'Lam', N'Quy', N'lamphuquy265@gmail.com', N'Quy123456@', N'hinhquy.png', N'Tô Hiến Thành', NULL, N'084202007390', N'0822654123', 0)
INSERT [dbo].[KhachHang] ([idUser], [FirstName], [LastName], [Email], [Password], [Picture], [Address], [NgaySinh], [CMT], [Sdt], [TichLuy]) VALUES (1055, N'Bảo', N'Huy', N'baohuy@gmail.com', N'123456Baohuy', N'user.jpg', NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[KhachHang] ([idUser], [FirstName], [LastName], [Email], [Password], [Picture], [Address], [NgaySinh], [CMT], [Sdt], [TichLuy]) VALUES (1056, N'Bao', N'Huy', N'baohuy2002@gmail.com', N'123456Baohuy@', N'T1.jpg', N'Cộng Hòa', CAST(N'2023-11-28' AS Date), N'4556564645', N'0329075634', 0)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([Id], [FullName], [Email], [Address], [NgaySinh], [Password], [MaChucVu], [Picture], [Sex], [Sdt]) VALUES (0, N'Quang Minh', N'Quangminh@gmail.com', N'881 sư vạn hanh', CAST(N'2003-01-01' AS Date), N'Minh123', 2, N'hinhquy.png', 1, N'098999999 ')
INSERT [dbo].[NhanVien] ([Id], [FullName], [Email], [Address], [NgaySinh], [Password], [MaChucVu], [Picture], [Sex], [Sdt]) VALUES (12, N'Minh Quang', N'Minhquang@gmail.com', N'Cộng Hòa', NULL, N'Minh123', 1, N'323889835_1206297369985547_6904271767357515890_n.jpg', 1, N'098999999 ')
INSERT [dbo].[NhanVien] ([Id], [FullName], [Email], [Address], [NgaySinh], [Password], [MaChucVu], [Picture], [Sex], [Sdt]) VALUES (15, N'Minh', N'Minhdeptrai@gmail.com', N'229/66 Tây Thạnh', CAST(N'2024-06-19' AS Date), N'Minh123', 1, N'user.jpg', 1, N'098444444 ')
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [Status], [Address], [Payment], [NgayDat], [NgayGiao], [ThanhTien], [TongSoLuong], [Id_NV]) VALUES (4, N'Chưa giao hàng', N'285 Cộng Hòa', NULL, CAST(N'2024-07-10T00:00:00.000' AS DateTime), CAST(N'2024-11-11T00:00:00.000' AS DateTime), 150000, 5, 12)
INSERT [dbo].[Order] ([ID], [Status], [Address], [Payment], [NgayDat], [NgayGiao], [ThanhTien], [TongSoLuong], [Id_NV]) VALUES (5, N'Chưa giao hàng', N'881 sư vạn hanh', 0, CAST(N'2024-07-10T08:09:11.670' AS DateTime), CAST(N'2024-07-13T08:09:11.670' AS DateTime), 2505000, 2, 0)
INSERT [dbo].[Order] ([ID], [Status], [Address], [Payment], [NgayDat], [NgayGiao], [ThanhTien], [TongSoLuong], [Id_NV]) VALUES (6, N'Chưa giao hàng', N'881 sư vạn hanh', 0, CAST(N'2024-07-11T13:47:43.593' AS DateTime), CAST(N'2024-07-14T13:47:43.593' AS DateTime), 2505000, 2, 0)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[Order_Detail] ([ID_Order], [ID_Product], [SoLuong], [Price]) VALUES (5, 3, 1, 5000)
INSERT [dbo].[Order_Detail] ([ID_Order], [ID_Product], [SoLuong], [Price]) VALUES (5, 4, 1, 2500000)
INSERT [dbo].[Order_Detail] ([ID_Order], [ID_Product], [SoLuong], [Price]) VALUES (6, 3, 1, 5000)
INSERT [dbo].[Order_Detail] ([ID_Order], [ID_Product], [SoLuong], [Price]) VALUES (6, 4, 1, 2500000)
GO
INSERT [dbo].[Order_Status] ([Status]) VALUES (N'Chưa giao hàng')
INSERT [dbo].[Order_Status] ([Status]) VALUES (N'Đã hủy')
INSERT [dbo].[Order_Status] ([Status]) VALUES (N'Đang giao hàng')
INSERT [dbo].[Order_Status] ([Status]) VALUES (N'Hoàn thành')
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [CatalogId], [Picture], [ProductName], [ProductCode], [PriceOld], [ProductSale], [UnitPrice], [SoLuong], [ProductSold], [NgayNhapHang]) VALUES (3, 2, N'031040_10072024.png', N'Mì tôm 3 miền', N'PR6000', 5000, N'0', 5000, 100, 0, CAST(N'2024-07-10' AS Date))
INSERT [dbo].[Product] ([Id], [CatalogId], [Picture], [ProductName], [ProductCode], [PriceOld], [ProductSale], [UnitPrice], [SoLuong], [ProductSold], [NgayNhapHang]) VALUES (4, 2, N'071628_10072024.png', N'MÌ 3 MIỀN', N'PR5125', 2500000, N'0', 2500000, 52, 0, CAST(N'2024-07-10' AS Date))
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[ChucVu] ([MaChucVu])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order] FOREIGN KEY([Id_NV])
REFERENCES [dbo].[NhanVien] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([CatalogId])
REFERENCES [dbo].[Catalog] ([ID])

