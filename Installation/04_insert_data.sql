USE [AppleStructure]
GO

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('����� ��������'
           ,NULL)

		   INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('������'
           ,NULL)

select * from [Hierarchy];

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('����� ���'
           ,1)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('������� ��������'
           ,1)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('�������'
           ,1)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('�������� ���'
           ,4)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('�����������'
           ,4)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('��������'
           ,4)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('���� �����'
           ,3)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('���� ��������'
           ,3)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('���� ��������'
           ,3)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('�����������������'
           ,2)

INSERT INTO [dbo].[Hierarchy]
           ([Name]
           ,[Parent])
     VALUES
           ('�� �����������������'
           ,2)

INSERT INTO [dbo].[Content]
           ([Name]
           ,[Content]
           ,[Hierarchy])
     VALUES
           ('����'
           ,0
           ,12)

INSERT INTO [dbo].[Content]
           ([Name]
           ,[Content]
           ,[Hierarchy])
     VALUES
           ('����'
           ,0
           ,12)

INSERT INTO [dbo].[Content]
           ([Name]
           ,[Content]
           ,[Hierarchy])
     VALUES
           ('������'
           ,0
           ,12)

INSERT INTO [dbo].[Content]
           ([Name]
           ,[Content]
           ,[Hierarchy])
     VALUES
           ('��������'
           ,0
           ,13)

INSERT INTO [dbo].[Content]
           ([Name]
           ,[Content]
           ,[Hierarchy])
     VALUES
           ('���������'
           ,0
           ,13)

INSERT INTO [dbo].[Content]
           ([Name]
           ,[Content]
           ,[Hierarchy])
     VALUES
           ('�����'
           ,0
           ,13)
