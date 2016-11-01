USE [AppleStructure]
GO

ALTER TABLE [dbo].[Content] DROP CONSTRAINT [FK_Content_Hierarchy]
GO

/****** Object:  Table [dbo].[Content]    Script Date: 01.11.2016 13:35:56 ******/
DROP TABLE [dbo].[Content]
GO

/****** Object:  Table [dbo].[Content]    Script Date: 01.11.2016 13:35:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Content](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Content] [real] NULL,
	[Hierarchy] [bigint] NOT NULL,
 CONSTRAINT [PK_Content] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Content]  WITH CHECK ADD  CONSTRAINT [FK_Content_Hierarchy] FOREIGN KEY([Hierarchy])
REFERENCES [dbo].[Hierarchy] ([Id])
GO

ALTER TABLE [dbo].[Content] CHECK CONSTRAINT [FK_Content_Hierarchy]
GO


