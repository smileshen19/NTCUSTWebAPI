CREATE TABLE [Items](
	[ID] [nvarchar](16) NOT NULL,
	[Name] [nvarchar](40) NULL,
	[Unit] [nvarchar](4) NULL,
	[Category] [nvarchar](12) NULL,
	[Price] [money] NULL,
	[Description] [nvarchar](600) NULL,
	[Barcode] [nvarchar](20) NULL,
	[SafetyStock] [decimal](12, 4) NULL,
	[StopDate] [date] NULL,
	[Str1] [nvarchar](255) NULL,
	[Str2] [nvarchar](255) NULL,
	[Str3] [nvarchar](255) NULL,
	[Str4] [nvarchar](255) NULL,
	[Int1] int NULL,
	[Int2] int NULL,
	[Mon1] money NULL,
	[Mon2] money NULL,
	CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)
) ON [PRIMARY]
