USE [TimeMachine]
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('30df5cc4-49a4-491c-a95c-4200425ac093'
		   ,'Pared1'
           ,'D:\Olles\TimeLine\TimeLine\Images\Tiles\Bases\Pared1.gif')
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('6c9b70c6-bfdc-4b83-b92e-6bc6bebdc2be'
		   ,'Suelo1'
           ,'D:\Olles\TimeLine\TimeLine\Images\Tiles\Bases\Suelo1.gif')
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('a8c1af4f-a93b-4654-aff0-a8051c4fa150'
		   ,'Suelo2'
           ,'D:\Olles\TimeLine\TimeLine\Images\Tiles\Bases\Suelo2.gif')
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('4d25fbbd-a5a9-4b4c-b664-1d02201dfb6b'
		   ,'Brasero1'
           ,'D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\Brasero1.gif')
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('13f6ed37-82e7-4fee-96c5-9a0e75bc707f'
		   ,'AlaY1'
           ,'D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\AlaY1.gif')
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('2f94a50a-1c57-4bb3-8ecb-40239fec28b4'
		   ,'AlaY2'
           ,'D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\AlaY2.gif')
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('4b350966-359e-4d30-a05f-95bd76a87107'
		   ,'Pant-Y'
           ,'D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\Pant-Y.gif')
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('214c6855-525c-47eb-bbf2-218aa9773b48'
		   ,'Pata-Y'
           ,'D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\Pata-Y.gif')
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('92f5bb43-03e0-45f1-a192-5e5407e4a510'
		   ,'PC-Y'
           ,'D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\PC-Y.gif')
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('fdcfc2f0-4b09-48d8-9d25-f650c67c1305'
		   ,'AlaX1'
           ,'D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\AlaX1.gif')
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('fd6373b2-2f27-467e-9df8-bad1ba7899b5'
		   ,'AlaX2'
           ,'D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\AlaX2.gif')
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('67fd6166-2470-499b-b9f5-8e02f5983e7f'
		   ,'Pant-X'
           ,'D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\Pant-X.gif')
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('2d1d6907-c4de-466e-a3ff-caf251f8865b'
		   ,'Pata-X'
           ,'D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\Pata-X.gif')
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('3a05933a-3ae3-47d6-8b11-10a02d1aa28e'
		   ,'PC-X'
           ,'D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\PC-X.gif')
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('635ba364-2bf5-4c12-acc1-ea33248911a0'
		   ,'AlaYO'
           ,'D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\AlaYO.gif')
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('cf16ef90-881c-41ea-99be-59de75927c62'
		   ,'AlaXO'
           ,'D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\AlaXO.gif')
GO

INSERT INTO [dbo].[IMAGES]
           ([UID]
		   ,[NAME]
           ,[IMAGE])
     VALUES
           ('823126d8-7b9c-444a-93fd-2780573a68f6'
		   ,'Silla'
           ,'D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\Silla.gif')
GO


INSERT INTO [dbo].[TILE_TYPES]
           ([UID]
           ,[NAME]
           ,[IMAGE]
           ,[CUTVIEW]
           ,[DARKNESS]
           ,[TRASPASSABLE])
     VALUES
           ('eb047e83-9588-4583-b4fa-56476df3c38c'
		   ,'Suelo1'
           ,'Suelo1'
           ,'false'
           ,255
           ,'true')
GO

INSERT INTO [dbo].[TILE_TYPES]
           ([UID]
           ,[NAME]
           ,[IMAGE]
           ,[CUTVIEW]
           ,[DARKNESS]
           ,[TRASPASSABLE])
     VALUES
           ('044827dd-4352-417d-96b2-593246877377'
		   ,'Suelo2'
           ,'Suelo2'
           ,'false'
           ,255
           ,'true')
GO


INSERT INTO [dbo].[TILE_TYPES]
           ([UID]
		   ,[NAME]
           ,[IMAGE]           
           ,[CUTVIEW]
           ,[DARKNESS]
           ,[TRASPASSABLE])
     VALUES
           ('037afd2f-c55d-4b61-aa81-8887c8f50296'
		   ,'Pared1'
           ,'Pared1'
           ,'true'
           ,255
           ,'false')
GO
