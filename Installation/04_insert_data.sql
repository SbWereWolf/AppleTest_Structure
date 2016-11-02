USE [AppleStructure]
GO

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('Места хранения'
           ,NULL)

		   INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('Товары'
           ,NULL)

select * from [Hierarchy];

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('Склад опт'
           ,1)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('магазин кольцово'
           ,1)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('полигон'
           ,1)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('торговый зал'
           ,4)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('холодильник'
           ,4)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('кладовая'
           ,4)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('зона приёма'
           ,3)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('зона хранения'
           ,3)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('зона отгрузки'
           ,3)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('продовольственные'
           ,2)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('не продовольственные'
           ,2)

INSERT INTO [dbo].[Content]
           ([Name]
           ,[Content]
           ,[Hierarchy])
     VALUES
           ('мясо'
           ,0
           ,12)

INSERT INTO [dbo].[Content]
           ([Name]
           ,[Content]
           ,[Hierarchy])
     VALUES
           ('хлеб'
           ,0
           ,12)

INSERT INTO [dbo].[Content]
           ([Name]
           ,[Content]
           ,[Hierarchy])
     VALUES
           ('молоко'
           ,0
           ,12)

INSERT INTO [dbo].[Content]
           ([Name]
           ,[Content]
           ,[Hierarchy])
     VALUES
           ('сигареты'
           ,0
           ,13)

INSERT INTO [dbo].[Content]
           ([Name]
           ,[Content]
           ,[Hierarchy])
     VALUES
           ('батарейки'
           ,0
           ,13)

INSERT INTO [dbo].[Content]
           ([Name]
           ,[Content]
           ,[Hierarchy])
     VALUES
           ('уголь'
           ,0
           ,13)
