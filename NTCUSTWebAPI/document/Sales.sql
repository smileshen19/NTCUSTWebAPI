CREATE TABLE [Sales](
	[No] [nvarchar](11) NOT NULL,
	[TradeDate] [date] NULL,
	[CustomerID] [nvarchar](10) NULL,
	[TaxRate] [decimal](5, 4) NULL,
	[TaxID] [nvarchar](20) NULL,
	[ZipCode] [nvarchar](6) NULL,
	[City] [nvarchar](20) NULL,
	[District] [nvarchar](20) NULL,
	[Address] [nvarchar](80) NULL,
	[TotalAmount] [money] NULL,
	[TotalTax] [money] NULL,
	[Memo] [nvarchar](255) NULL,
	[Str1] [nvarchar](255) NULL,
	[Str2] [nvarchar](255) NULL,
	[Str3] [nvarchar](255) NULL,
	[Str4] [nvarchar](255) NULL,
	[Int1] int NULL,
	[Int2] int NULL,
	[Mon1] money NULL,
	[Mon2] money NULL,
	CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
	(
		[No] ASC
	) ON [PRIMARY]
)


CREATE TABLE [SaleDetails](
	[No] [nvarchar](11) NOT NULL,
	[Seq] [int] NOT NULL,
	[ItemID] [nvarchar](16) NULL,
	[ItemName] [nvarchar](40) NULL,
	[Unit] [nvarchar](4) NULL,
	[Qty] [decimal](12, 4) NULL,
	[SalePrice] [money] NULL,
	[Discount] [decimal](5, 4) NULL,
	[Price] [money] NULL,
	[Amount] [money] NULL,
	[IsFree] [bit] NULL,
	[Memo] [nvarchar](255) NULL,
	[Str1] [nvarchar](255) NULL,
	[Str2] [nvarchar](255) NULL,
	[Str3] [nvarchar](255) NULL,
	[Str4] [nvarchar](255) NULL,
	[Int1] int NULL,
	[Int2] int NULL,
	[Mon1] money NULL,
	[Mon2] money NULL,
	CONSTRAINT [PK_SaleDetails] PRIMARY KEY CLUSTERED 
	(
		[No] ASC,
		[Seq] ASC
	)ON [PRIMARY]
)
