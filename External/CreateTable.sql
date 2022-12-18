USE [RandomDataGeneratorDb]
GO

/****** Object:  Table [dbo].[FileEntries]    Script Date: 12/18/2022 3:49:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FileEntries](
	[Id] [nvarchar](450) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[LatinString] [nvarchar](max) NOT NULL,
	[RussianString] [nvarchar](max) NOT NULL,
	[IntegerNumber] [int] NOT NULL,
	[FloatingNumber] [float] NOT NULL,
 CONSTRAINT [PK_FileEntries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

