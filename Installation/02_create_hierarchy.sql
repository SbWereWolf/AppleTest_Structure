USE [AppleStructure]
GO

/****** Object:  Table [dbo].[Hierarchy]    Script Date: 01.11.2016 13:36:04 ******/
DROP TABLE [dbo].[Hierarchy]
GO

/****** Object:  Table [dbo].[Hierarchy]    Script Date: 01.11.2016 13:36:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Hierarchy](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Parent] [bigint] NULL,
 CONSTRAINT [PK_Hierarchy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


