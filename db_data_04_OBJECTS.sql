USE [TimeMachine]
GO

/************************************************************/
/* OBJECT PARTS TYPES										*/
/************************************************************/

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH])
     VALUES
           ('eec63e49-4f11-4917-9fa0-db25f062a898','Brasero','Brasero1'
		   ,100,'false','false','false'
		   ,175,3,'0,5','true')
GO

--MESAS

----------Mesa-AlaY
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH])
     VALUES
           ('403f8a74-937d-4de2-ac1b-ff52078c81f6','Mesa-AlaY1','AlaY1'
		   ,100,'false','false','false'
		   ,0,0,'0','false')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH])
     VALUES
           ('1d901739-76ba-46ba-a3b1-222b7a6006c9','Mesa-AlaY2','AlaY2'
		   ,100,'false','false','false'
		   ,0,0,'0','false')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH])
     VALUES
           ('f8713aa3-e3b0-4999-97d8-b172f2683421','Mesa-PC-Y','PC-Y'
		   ,100,'false','false','false'
		   ,0,0,'0','false')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH])
     VALUES
           ('4ec367a9-3a4f-4a1a-abeb-56d46f685375','Mesa-Pant-Y','Pant-Y'
		   ,100,'false','false','false'
		   ,0,0,'0','false')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH])
     VALUES
           ('953640b1-fb54-4864-971a-290db3f372f1','Mesa-Pata-Y','Pata-Y'
		   ,100,'false','false','false'
		   ,0,0,'0','false')
GO

----------Mesa-AlaX
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH])
     VALUES
           ('8220f6bf-af7e-4a91-aef8-905397b712fd','Mesa-AlaX1','AlaX1'
		   ,100,'false','false','false'
		   ,0,0,'0','false')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH])
     VALUES
           ('747f3d8d-a792-4253-a1a3-1e4ef0ba92e5','Mesa-AlaX2','AlaX2'
		   ,100,'false','false','false'
		   ,0,0,'0','false')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH])
     VALUES
           ('30838451-90ef-4855-b59f-17213ae4ebbe','Mesa-PC-X','PC-X'
		   ,100,'false','false','false'
		   ,0,0,'0','false')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH])
     VALUES
           ('e728f304-a81d-4092-8dbd-080df64fac21','Mesa-Pant-X','Pant-X'
		   ,100,'false','false','false'
		   ,0,0,'0','false')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH])
     VALUES
           ('8a9f5b0a-37ee-4ec3-bee8-2b16dac49776','Mesa-Pata-X','Pata-X'
		   ,100,'false','false','false'
		   ,0,0,'0','false')
GO

----------Mesa-AlaYO
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH])
     VALUES
           ('c3c5fe98-fa52-460d-8e29-8da72e2946cb','Mesa-AlaYO','AlaYO'
		   ,100,'false','false','false'
		   ,0,0,'0','false')
GO

----------Mesa-AlaXO
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH])
     VALUES
           ('b09a3788-4869-44d1-9cf7-8862b011c1f7','Mesa-AlaXO','AlaXO'
		   ,100,'false','false','false'
		   ,0,0,'0','false')
GO

--SILLAS
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME],[IMAGE]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH])
     VALUES
           ('fde178ed-7e6a-411e-9644-77a65e3f2cb4','Silla','Silla'
		   ,100,'false','false','false'
		   ,0,0,'0','false')
GO


/************************************************************/
/* OBJECT PARTS 										*/
/************************************************************/

INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('43c00040-ebfb-43a3-869e-5df44cbc2254','Brasero1',7,9,'eec63e49-4f11-4917-9fa0-db25f062a898'
           ,'Brasero1',100,'false','false','false'
           ,255,7,'0,8','true','false')          
GO

--MESA ET
INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('26520007-5fe4-4cb6-979a-f7e1031d0697','Mesa-ET-AlaY1',1,1,'403f8a74-937d-4de2-ac1b-ff52078c81f6'
           ,'AlaY1',100,'false','false','false'
           ,0,0,'0','false','false')          
GO

INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('71d2f116-38f0-4a01-99f8-5467ae901c9e','Mesa-ET-AlaY2',1,2,'1d901739-76ba-46ba-a3b1-222b7a6006c9'
           ,'AlaY2',100,'false','false','true'
           ,0,0,'0','false','false')          
GO

INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('0784ff64-9440-4b06-b15c-2e62d865435e','Mesa-ET-PC-Y',3,1,'f8713aa3-e3b0-4999-97d8-b172f2683421'
           ,'PC-Y',100,'false','false','false'
           ,0,0,'0','false','false')          
GO

INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('4315f5de-cce8-4d5c-96c6-d8b344b0d8ac','Mesa-ET-Pant-Y',2,1,'953640b1-fb54-4864-971a-290db3f372f1'
           ,'Pant-Y',100,'false','false','false'
           ,0,0,'0','false','false')          
GO

INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('4a9a7580-f9a1-4dae-85ae-b6e507fc70f2','Mesa-ET-Pata-Y',3,2,'1d901739-76ba-46ba-a3b1-222b7a6006c9'
           ,'Pata-Y',100,'false','false','true'
           ,0,0,'0','false','false')          
GO

INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('c7d69403-674b-440c-b425-e414fe8ad84b','Silla-ET',2,2,'fde178ed-7e6a-411e-9644-77a65e3f2cb4'
           ,'Silla',100,'false','false','true'
           ,0,0,'0','false','false')          
GO

--MESA JE
INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('afcf94aa-1578-4895-8d1e-b0f243de60bf','Mesa-JE-AlaXO',6,1,'b09a3788-4869-44d1-9cf7-8862b011c1f7'
           ,'AlaXO',100,'false','false','false'
           ,0,0,'0','false','false')          
GO

INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('b12dc396-f3f4-446e-8f4d-3542eefc915f','Mesa-JE-Pata-X',4,2,'8a9f5b0a-37ee-4ec3-bee8-2b16dac49776'
           ,'Pata-X',100,'false','false','true'
           ,0,0,'0','false','false')          
GO

INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('aef478aa-7011-447f-9bd4-db082a1dbb84','Mesa-JE-PC-X',4,1,'30838451-90ef-4855-b59f-17213ae4ebbe'
           ,'PC-X',100,'false','false','false'
           ,0,0,'0','false','false')          
GO

INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('ecafc5be-2b1c-4950-99e3-6987a825b862','Mesa-JE-Pant-X',5,1,'e728f304-a81d-4092-8dbd-080df64fac21'
           ,'Pant-X',100,'false','false','false'
           ,0,0,'0','false','false')          
GO

INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('031ce17b-59f7-4534-b23c-bcc65aa40b51','Mesa-JE-Pata-Y',6,2,'1d901739-76ba-46ba-a3b1-222b7a6006c9'
           ,'Pata-Y',100,'false','false','true'
           ,0,0,'0','false','false')          
GO

INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('a869323e-c1c0-4946-9b97-b8921ac31628','Silla-JE',5,2,'fde178ed-7e6a-411e-9644-77a65e3f2cb4'
           ,'Silla',100,'false','false','true'
           ,0,0,'0','false','false')          
GO

--MESA PS
INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('9fb9b29d-5e54-4e2d-9e11-a680eaadfa46','Mesa-PS-AlaX1',9,1,'8220f6bf-af7e-4a91-aef8-905397b712fd'
           ,'AlaX1',100,'false','false','false'
           ,0,0,'0','false','false')          
GO

INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('ee39e1a8-a494-4356-ac5b-f9bf7fee031c','Mesa-PS-AlaX2',9,2,'747f3d8d-a792-4253-a1a3-1e4ef0ba92e5'
           ,'AlaX2',100,'false','false','true'
           ,0,0,'0','false','false')          
GO

INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('fe6ea566-9241-429f-9dc4-d388dce0cf87','Mesa-PS-PC-X',7,1,'30838451-90ef-4855-b59f-17213ae4ebbe'
           ,'PC-X',100,'false','false','false'
           ,0,0,'0','false','false')          
GO

INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('9d69dd51-bee0-4e05-ae97-f2e6bfabb211','Mesa-PS-Pant-X',8,1,'e728f304-a81d-4092-8dbd-080df64fac21'
           ,'Pant-X',100,'false','false','false'
           ,0,0,'0','false','false')          
GO

INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('f47f20ee-12f5-413d-bb76-fe9c6bfc627e','Mesa-PS-Pata-X',7,2,'8a9f5b0a-37ee-4ec3-bee8-2b16dac49776'
           ,'Pata-X',100,'false','false','true'
           ,0,0,'0','false','false')          
GO

INSERT INTO [dbo].[OBJECT_PARTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION]
		   ,[IMAGE],[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH], [LIGHTSWITCH_STATUS])
     VALUES
           ('010bc5cb-0b2a-46e1-a3c8-60a34a6da8a8','Silla-PS',8,2,'fde178ed-7e6a-411e-9644-77a65e3f2cb4'
           ,'Silla',100,'false','false','true'
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
           ('c244fec9-ff51-459c-bc6a-e061721df370','Mesa-Y',100,'false')
GO

INSERT INTO [dbo].[OBJECT_TYPES]
           ([UID],[NAME],[PV],[INVULNERABLE])
     VALUES
           ('b0eed47c-e57e-438e-ad2e-634d0c61b8cb','Mesa-X',100,'false')
GO

INSERT INTO [dbo].[OBJECT_TYPES]
           ([UID],[NAME],[PV],[INVULNERABLE])
     VALUES
           ('85b14179-074f-47de-9269-d2544b5cbef4','MesaPanel-AlaY',100,'false')
GO

INSERT INTO [dbo].[OBJECT_TYPES]
           ([UID],[NAME],[PV],[INVULNERABLE])
     VALUES
           ('0384e71e-c58b-436b-99a2-019c75dc97b7','MesaPanel-AlaX',100,'false')
GO

INSERT INTO [dbo].[OBJECT_TYPES]
           ([UID],[NAME],[PV],[INVULNERABLE])
     VALUES
           ('9dfb1a23-9e6d-4e64-a8b8-ee472101ae7c','MesaPanel',100,'false')
GO


/************************************************************/
/* OBJECTS													*/
/************************************************************/

INSERT INTO [dbo].[OBJECTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION],[PV],[INVULNERABLE])
     VALUES
           ('f219e5a1-4a7a-437a-afd8-c4adf3566a7d','Brasero1_1',7,9,'ceb864e4-afa4-40de-a89e-f5cf672cb8e3',100,'false')
GO

INSERT INTO [dbo].[OBJECTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION],[PV],[INVULNERABLE])
     VALUES
           ('7b4ed087-50ee-486c-b3b9-66b868919194','Mesa_AlaY_ET',2,1,'1aa06bb8-e288-449b-befe-b9250a71d627',100,'false')
GO

INSERT INTO [dbo].[OBJECTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION],[PV],[INVULNERABLE])
     VALUES
           ('5daee1e3-f654-41e2-b8dd-942502b7cf62','Mesa_Y_JE',5,1,'c244fec9-ff51-459c-bc6a-e061721df370',100,'false')
GO

INSERT INTO [dbo].[OBJECTS]
           ([UID],[NAME],[ROOM_TILE_GRID_X],[ROOM_TILE_GRID_Y],[TYPE_DEFINITION],[PV],[INVULNERABLE])
     VALUES
           ('88fce8cf-1e19-49b6-9d74-452251edf6cc','Mesa_AlaX_PS',8,1,'0b1f1d2d-cde2-4207-9d16-77f4c7d2e7f3',100,'false')
GO

/************************************************************/
/* OBJECTS AND PARTS										*/
/************************************************************/

INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('f219e5a1-4a7a-437a-afd8-c4adf3566a7d','43c00040-ebfb-43a3-869e-5df44cbc2254')
GO

--MESA ET
INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('7b4ed087-50ee-486c-b3b9-66b868919194','26520007-5fe4-4cb6-979a-f7e1031d0697')
GO

INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('7b4ed087-50ee-486c-b3b9-66b868919194','71d2f116-38f0-4a01-99f8-5467ae901c9e')
GO

INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('7b4ed087-50ee-486c-b3b9-66b868919194','0784ff64-9440-4b06-b15c-2e62d865435e')
GO

INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('7b4ed087-50ee-486c-b3b9-66b868919194','4315f5de-cce8-4d5c-96c6-d8b344b0d8ac')
GO

INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('7b4ed087-50ee-486c-b3b9-66b868919194','4a9a7580-f9a1-4dae-85ae-b6e507fc70f2')
GO

INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('7b4ed087-50ee-486c-b3b9-66b868919194','c7d69403-674b-440c-b425-e414fe8ad84b')
GO

--MESA JE
INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('5daee1e3-f654-41e2-b8dd-942502b7cf62','afcf94aa-1578-4895-8d1e-b0f243de60bf')
GO

INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('5daee1e3-f654-41e2-b8dd-942502b7cf62','b12dc396-f3f4-446e-8f4d-3542eefc915f')
GO

INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('5daee1e3-f654-41e2-b8dd-942502b7cf62','aef478aa-7011-447f-9bd4-db082a1dbb84')
GO

INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('5daee1e3-f654-41e2-b8dd-942502b7cf62','ecafc5be-2b1c-4950-99e3-6987a825b862')
GO

INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('5daee1e3-f654-41e2-b8dd-942502b7cf62','031ce17b-59f7-4534-b23c-bcc65aa40b51')
GO

INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('5daee1e3-f654-41e2-b8dd-942502b7cf62','a869323e-c1c0-4946-9b97-b8921ac31628')
GO

--MESA PS
INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('88fce8cf-1e19-49b6-9d74-452251edf6cc','9fb9b29d-5e54-4e2d-9e11-a680eaadfa46')
GO

INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('88fce8cf-1e19-49b6-9d74-452251edf6cc','ee39e1a8-a494-4356-ac5b-f9bf7fee031c')
GO

INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('88fce8cf-1e19-49b6-9d74-452251edf6cc','fe6ea566-9241-429f-9dc4-d388dce0cf87')
GO

INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('88fce8cf-1e19-49b6-9d74-452251edf6cc','9d69dd51-bee0-4e05-ae97-f2e6bfabb211')
GO

INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('88fce8cf-1e19-49b6-9d74-452251edf6cc','f47f20ee-12f5-413d-bb76-fe9c6bfc627e')
GO

INSERT INTO [dbo].[REL_OBJECTS_AND_PARTS]
           ([OBJECT],[OBJECT_PART])
     VALUES
           ('88fce8cf-1e19-49b6-9d74-452251edf6cc','010bc5cb-0b2a-46e1-a3c8-60a34a6da8a8')
GO
