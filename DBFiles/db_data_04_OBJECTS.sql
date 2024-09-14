USE [TimeMachine2]
GO

/************************************************************/
/* OBJECT PARTS TYPES										*/
/************************************************************/

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE])
     VALUES
           ('eec63e49-4f11-4917-9fa0-db25f062a898','Brasero','Brasero1'
		   ,100,'false','false','false'
		   ,175,3,'0,5','true','false')
GO

--MESAS

----------Mesa-AlaY
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE])
     VALUES
           ('403f8a74-937d-4de2-ac1b-ff52078c81f6','Mesa-AlaY1','AlaY1'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE])
     VALUES
           ('1d901739-76ba-46ba-a3b1-222b7a6006c9','Mesa-AlaY2','AlaY2'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE])
     VALUES
           ('f8713aa3-e3b0-4999-97d8-b172f2683421','Mesa-PC-Y','PC-Y'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE])
     VALUES
           ('4ec367a9-3a4f-4a1a-abeb-56d46f685375','Mesa-Pant-Y','Pant-Y'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE])
     VALUES
           ('953640b1-fb54-4864-971a-290db3f372f1','Mesa-Pata-Y','Pata-Y'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false')
GO

----------Mesa-AlaX
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE])
     VALUES
           ('8220f6bf-af7e-4a91-aef8-905397b712fd','Mesa-AlaX1','AlaX1'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE])
     VALUES
           ('747f3d8d-a792-4253-a1a3-1e4ef0ba92e5','Mesa-AlaX2','AlaX2'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE])
     VALUES
           ('30838451-90ef-4855-b59f-17213ae4ebbe','Mesa-PC-X','PC-X'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE])
     VALUES
           ('e728f304-a81d-4092-8dbd-080df64fac21','Mesa-Pant-X','Pant-X'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE])
     VALUES
           ('8a9f5b0a-37ee-4ec3-bee8-2b16dac49776','Mesa-Pata-X','Pata-X'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false')
GO

----------Mesa-AlaYO
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE])
     VALUES
           ('c3c5fe98-fa52-460d-8e29-8da72e2946cb','Mesa-AlaYO','AlaYO'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false')
GO

----------Mesa-AlaXO
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE])
     VALUES
           ('b09a3788-4869-44d1-9cf7-8862b011c1f7','Mesa-AlaXO','AlaXO'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false')
GO

--SILLAS
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE])
     VALUES
           ('fde178ed-7e6a-411e-9644-77a65e3f2cb4','Silla','Silla'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false')
GO

--PALMERA
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE])
     VALUES
           ('25BD929B-560D-45D3-B0EF-ACEB9B1D4BA6','PalmeraCopa','PalmeraCopa'
		   ,100,'false','false','true'
		   ,0,0,'0','false','true')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE])
     VALUES
           ('9F217B30-9D73-4DB9-AA75-8866C4FB1187','PalmeraTronc','PalmeraTronc'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false')
GO


/************************************************************/
/* OBJECTS TYPES											*/
/************************************************************/

INSERT INTO [dbo].[OBJECT_TYPES]
           ([UID],[NAME],[PV],[INVULNERABLE])
     VALUES
           ('ceb864e4-afa4-40de-a89e-f5cf672cb8e3','Brasero1',100,'false')
GO

--MESAS
INSERT INTO [dbo].[OBJECT_TYPES]
           ([UID],[NAME],[PV],[INVULNERABLE])
     VALUES
           ('1aa06bb8-e288-449b-befe-b9250a71d627','Mesa-AlaY',100,'false')
GO

INSERT INTO [dbo].[OBJECT_TYPES]
           ([UID],[NAME],[PV],[INVULNERABLE])
     VALUES
           ('0b1f1d2d-cde2-4207-9d16-77f4c7d2e7f3','Mesa-AlaX',100,'false')
GO

INSERT INTO [dbo].[OBJECT_TYPES]
           ([UID],[NAME],[PV],[INVULNERABLE])
     VALUES
           ('9dfb1a23-9e6d-4e64-a8b8-ee472101ae7c','Mesa',100,'false')
GO

--PALMERA
INSERT INTO [dbo].[OBJECT_TYPES]
           ([UID],[NAME],[PV],[INVULNERABLE])
     VALUES
           ('BBEE9FB3-795B-4909-83CA-C9549D2BDEB7','Palmera',100,'false')
GO

/************************************************************/
/* REL OBJECTS TYPES AND OBJECT TYPE PARTS                  */
/************************************************************/

INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('ceb864e4-afa4-40de-a89e-f5cf672cb8e3','eec63e49-4f11-4917-9fa0-db25f062a898',0,0)
GO

----------Mesa-AlaY
INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('1aa06bb8-e288-449b-befe-b9250a71d627','403f8a74-937d-4de2-ac1b-ff52078c81f6',-1,-1)
GO

INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('1aa06bb8-e288-449b-befe-b9250a71d627','1d901739-76ba-46ba-a3b1-222b7a6006c9',-1,0)
GO

INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('1aa06bb8-e288-449b-befe-b9250a71d627','f8713aa3-e3b0-4999-97d8-b172f2683421',0,-1)
GO

INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('1aa06bb8-e288-449b-befe-b9250a71d627','fde178ed-7e6a-411e-9644-77a65e3f2cb4',0,0)
GO

INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('1aa06bb8-e288-449b-befe-b9250a71d627','4ec367a9-3a4f-4a1a-abeb-56d46f685375',1,-1)
GO

INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('1aa06bb8-e288-449b-befe-b9250a71d627','953640b1-fb54-4864-971a-290db3f372f1',1,0)
GO

----------Mesa-AlaX
INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('0b1f1d2d-cde2-4207-9d16-77f4c7d2e7f3','8220f6bf-af7e-4a91-aef8-905397b712fd',1,-1)
GO

INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('0b1f1d2d-cde2-4207-9d16-77f4c7d2e7f3','747f3d8d-a792-4253-a1a3-1e4ef0ba92e5',1,0)
GO

INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('0b1f1d2d-cde2-4207-9d16-77f4c7d2e7f3','e728f304-a81d-4092-8dbd-080df64fac21',0,-1)
GO

INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('0b1f1d2d-cde2-4207-9d16-77f4c7d2e7f3','fde178ed-7e6a-411e-9644-77a65e3f2cb4',0,0)
GO

INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('0b1f1d2d-cde2-4207-9d16-77f4c7d2e7f3','30838451-90ef-4855-b59f-17213ae4ebbe',-1,-1)
GO

INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('0b1f1d2d-cde2-4207-9d16-77f4c7d2e7f3','8a9f5b0a-37ee-4ec3-bee8-2b16dac49776',-1,0)
GO

----------Mesa
INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('9dfb1a23-9e6d-4e64-a8b8-ee472101ae7c','8220f6bf-af7e-4a91-aef8-905397b712fd',-1,-1)
GO

INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('9dfb1a23-9e6d-4e64-a8b8-ee472101ae7c','e728f304-a81d-4092-8dbd-080df64fac21',0,-1)
GO

INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('9dfb1a23-9e6d-4e64-a8b8-ee472101ae7c','fde178ed-7e6a-411e-9644-77a65e3f2cb4',0,0)
GO

INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('9dfb1a23-9e6d-4e64-a8b8-ee472101ae7c','30838451-90ef-4855-b59f-17213ae4ebbe',1,-1)
GO

--------Palmera
INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('BBEE9FB3-795B-4909-83CA-C9549D2BDEB7','25BD929B-560D-45D3-B0EF-ACEB9B1D4BA6',0,-1)
GO

INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('BBEE9FB3-795B-4909-83CA-C9549D2BDEB7','9F217B30-9D73-4DB9-AA75-8866C4FB1187',0,0)
GO

