CREATE TABLE [Customers]
(
	[ID] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](72) NULL,
	[TaxID] [nvarchar](20) NULL,
	[ContactName] [nvarchar](30) NULL,
	[ContactTitle] [nvarchar](10) NULL,
	[CellPhone] [nvarchar](15) NULL,
	[Tel] [nvarchar](30) NULL,
	[Fax] [nvarchar](30) NULL,
	[EMail] [nvarchar](40) NULL,
	[ZipCode] [nvarchar](6) NULL,
	[City] [nvarchar](20) NULL,
	[District] [nvarchar](20) NULL,
	[Address] [nvarchar](80) NULL,
	[Memo] [nvarchar](255) NULL,
	[Str1] [nvarchar](255) NULL,
	[Str2] [nvarchar](255) NULL,
	[Str3] [nvarchar](255) NULL,
	[Str4] [nvarchar](255) NULL,
	[Int1] int NULL,
	[Int2] int NULL,
	[Mon1] money NULL,
	[Mon2] money NULL,
	CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)
)
ON [PRIMARY]
