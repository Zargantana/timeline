USE [TimeMachine2]
GO

/************************************************************/
/* OBJECT PARTS ANIMATIONS									*/
/************************************************************/

--Brasero_switched_off
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('BB35CE58-78E8-4523-A3F7-85F74F5C9931','Brasero_switched_off')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('BB35CE58-78E8-4523-A3F7-85F74F5C9931','D:\Olles\TimeLine\TimeLine\Images\ObjectPartsAnimations\Bases\Brasero0.gif',1)
GO

--Brasero_switched_on
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('95A6AEA9-99EC-466C-8B40-6D75CF241E78','Brasero_switched_on')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('95A6AEA9-99EC-466C-8B40-6D75CF241E78','D:\Olles\TimeLine\TimeLine\Images\ObjectPartsAnimations\Bases\Brasero1.gif',1)
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('95A6AEA9-99EC-466C-8B40-6D75CF241E78','D:\Olles\TimeLine\TimeLine\Images\ObjectPartsAnimations\Bases\Brasero2.gif',2)
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('95A6AEA9-99EC-466C-8B40-6D75CF241E78','D:\Olles\TimeLine\TimeLine\Images\ObjectPartsAnimations\Bases\Brasero3.gif',3)
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('95A6AEA9-99EC-466C-8B40-6D75CF241E78','D:\Olles\TimeLine\TimeLine\Images\ObjectPartsAnimations\Bases\Brasero4.gif',4)
GO


--AlaY1
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('13f6ed37-82e7-4fee-96c5-9a0e75bc707f','AlaY1')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('13f6ed37-82e7-4fee-96c5-9a0e75bc707f','D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\AlaY1.gif',1)
GO


--AlaY2
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('2f94a50a-1c57-4bb3-8ecb-40239fec28b4','AlaY2')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('2f94a50a-1c57-4bb3-8ecb-40239fec28b4','D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\AlaY2.gif',1)
GO

--Pant-Y
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('4b350966-359e-4d30-a05f-95bd76a87107','Pant-Y')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('4b350966-359e-4d30-a05f-95bd76a87107','D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\Pant-Y.gif',1)
GO

--Pata-Y
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('214c6855-525c-47eb-bbf2-218aa9773b48','Pata-Y')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('214c6855-525c-47eb-bbf2-218aa9773b48','D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\Pata-Y.gif',1)
GO

--PC-Y
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('92f5bb43-03e0-45f1-a192-5e5407e4a510','PC-Y')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('92f5bb43-03e0-45f1-a192-5e5407e4a510','D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\PC-Y.gif',1)
GO

--AlaX1
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('fdcfc2f0-4b09-48d8-9d25-f650c67c1305','AlaX1')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('fdcfc2f0-4b09-48d8-9d25-f650c67c1305','D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\AlaX1.gif',1)
GO

--AlaX2
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('fd6373b2-2f27-467e-9df8-bad1ba7899b5','AlaX2')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('fd6373b2-2f27-467e-9df8-bad1ba7899b5','D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\AlaX2.gif',1)
GO

--Pant-X
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('67fd6166-2470-499b-b9f5-8e02f5983e7f','Pant-X')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('67fd6166-2470-499b-b9f5-8e02f5983e7f','D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\Pant-X.gif',1)
GO

--Pata-X
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('2d1d6907-c4de-466e-a3ff-caf251f8865b','Pata-X')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('2d1d6907-c4de-466e-a3ff-caf251f8865b','D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\Pata-X.gif',1)
GO

--PC-X
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('3a05933a-3ae3-47d6-8b11-10a02d1aa28e','PC-X')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('3a05933a-3ae3-47d6-8b11-10a02d1aa28e','D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\PC-X.gif',1)
GO

--AlaYO
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('635ba364-2bf5-4c12-acc1-ea33248911a0','AlaYO')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('635ba364-2bf5-4c12-acc1-ea33248911a0','D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\AlaYO.gif',1)
GO

--AlaXO
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('cf16ef90-881c-41ea-99be-59de75927c62','AlaXO')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('cf16ef90-881c-41ea-99be-59de75927c62','D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\AlaXO.gif',1)
GO

--Silla
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('823126d8-7b9c-444a-93fd-2780573a68f6','Silla')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('823126d8-7b9c-444a-93fd-2780573a68f6','D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\Silla.gif',1)
GO

--PalmeraCopa
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('22E381F0-11B3-44A3-A549-DA943E662145','PalmeraCopa')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('22E381F0-11B3-44A3-A549-DA943E662145','D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\PalmeraCopa.gif',1)
GO

--PalmeraTronc
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('4B1D5AE0-46EA-489A-8B09-D29E736D1758','PalmeraTronc')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('4B1D5AE0-46EA-489A-8B09-D29E736D1758','D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\PalmeraTronc.gif',1)
GO

--PalmeraFull
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('485DE9A3-4352-4DD3-B985-2805CC2F3CD6','PalmeraFull')
GO
INSERT INTO [dbo].[OBJECT_PART_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
     VALUES ('485DE9A3-4352-4DD3-B985-2805CC2F3CD6','D:\Olles\TimeLine\TimeLine\Images\ObjectParts\Bases\PalmeraFull.gif',1)
GO

/************************************************************/
/* OBJECT PARTS TYPES										*/
/************************************************************/

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('eec63e49-4f11-4917-9fa0-db25f062a898','Brasero'
		   ,100,'false','false','false'
		   ,175,3,'0,5','true','false'
		   ,'BB35CE58-78E8-4523-A3F7-85F74F5C9931','95A6AEA9-99EC-466C-8B40-6D75CF241E78','1,0')
GO

--MESAS

----------Mesa-AlaY
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('403f8a74-937d-4de2-ac1b-ff52078c81f6','Mesa-AlaY1'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false'
		   ,'13f6ed37-82e7-4fee-96c5-9a0e75bc707f','13f6ed37-82e7-4fee-96c5-9a0e75bc707f','1,0')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('1d901739-76ba-46ba-a3b1-222b7a6006c9','Mesa-AlaY2'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false'
		   ,'2f94a50a-1c57-4bb3-8ecb-40239fec28b4','2f94a50a-1c57-4bb3-8ecb-40239fec28b4','1,0')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('f8713aa3-e3b0-4999-97d8-b172f2683421','Mesa-PC-Y'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false'
		   ,'92f5bb43-03e0-45f1-a192-5e5407e4a510','92f5bb43-03e0-45f1-a192-5e5407e4a510','1,0')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('4ec367a9-3a4f-4a1a-abeb-56d46f685375','Mesa-Pant-Y'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false'
		   ,'4b350966-359e-4d30-a05f-95bd76a87107','4b350966-359e-4d30-a05f-95bd76a87107','1,0')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('953640b1-fb54-4864-971a-290db3f372f1','Mesa-Pata-Y'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false'
		   ,'214c6855-525c-47eb-bbf2-218aa9773b48','214c6855-525c-47eb-bbf2-218aa9773b48','1,0')
GO

----------Mesa-AlaX
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('8220f6bf-af7e-4a91-aef8-905397b712fd','Mesa-AlaX1'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false'
		   ,'fdcfc2f0-4b09-48d8-9d25-f650c67c1305','fdcfc2f0-4b09-48d8-9d25-f650c67c1305','1,0')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('747f3d8d-a792-4253-a1a3-1e4ef0ba92e5','Mesa-AlaX2'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false'
		   ,'fd6373b2-2f27-467e-9df8-bad1ba7899b5','fd6373b2-2f27-467e-9df8-bad1ba7899b5','1,0')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('30838451-90ef-4855-b59f-17213ae4ebbe','Mesa-PC-X'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false'
		   ,'3a05933a-3ae3-47d6-8b11-10a02d1aa28e','3a05933a-3ae3-47d6-8b11-10a02d1aa28e','1,0')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('e728f304-a81d-4092-8dbd-080df64fac21','Mesa-Pant-X'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false'
		   ,'67fd6166-2470-499b-b9f5-8e02f5983e7f','67fd6166-2470-499b-b9f5-8e02f5983e7f','1,0')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('8a9f5b0a-37ee-4ec3-bee8-2b16dac49776','Mesa-Pata-X'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false'
		   ,'2d1d6907-c4de-466e-a3ff-caf251f8865b','2d1d6907-c4de-466e-a3ff-caf251f8865b','1,0')
GO

----------Mesa-AlaYO
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('c3c5fe98-fa52-460d-8e29-8da72e2946cb','Mesa-AlaYO'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false'
		   ,'635ba364-2bf5-4c12-acc1-ea33248911a0','635ba364-2bf5-4c12-acc1-ea33248911a0','1,0')
GO

----------Mesa-AlaXO
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('b09a3788-4869-44d1-9cf7-8862b011c1f7','Mesa-AlaXO'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false'
		   ,'cf16ef90-881c-41ea-99be-59de75927c62','cf16ef90-881c-41ea-99be-59de75927c62','1,0')
GO

--SILLAS
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('fde178ed-7e6a-411e-9644-77a65e3f2cb4','Silla'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false'
		   ,'823126d8-7b9c-444a-93fd-2780573a68f6','823126d8-7b9c-444a-93fd-2780573a68f6','1,0')
GO

--PALMERA
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('25BD929B-560D-45D3-B0EF-ACEB9B1D4BA6','PalmeraCopa'
		   ,100,'false','false','true'
		   ,0,0,'0','false','true'
		   ,'22E381F0-11B3-44A3-A549-DA943E662145','22E381F0-11B3-44A3-A549-DA943E662145','1,0')
GO

INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('9F217B30-9D73-4DB9-AA75-8866C4FB1187','PalmeraTronc'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false'
		   ,'4B1D5AE0-46EA-489A-8B09-D29E736D1758','4B1D5AE0-46EA-489A-8B09-D29E736D1758','1,0')
GO

--PALMERA FULL
INSERT INTO [dbo].[OBJECT_PART_TYPES]
           ([UID],[NAME]
		   ,[PV],[INVULNERABLE],[CUTVIEW],[TRASPASSABLE]
		   ,[LIGHTNING],[LIGHTNING_TILES],[LIGHTNING_FACTOR],[LIGHTSWITCH],[ABOVE]
		   ,[ANIMATION], [ANIMATION_LIGHT_ON], [ANIMATION_SPEED])
     VALUES
           ('598ECAC1-237A-4C7C-AB29-E057C8DE411A','PalmeraFull'
		   ,100,'false','false','false'
		   ,0,0,'0','false','false'
		   ,'485DE9A3-4352-4DD3-B985-2805CC2F3CD6','485DE9A3-4352-4DD3-B985-2805CC2F3CD6','1,0')
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

--PALMERA FULL
INSERT INTO [dbo].[OBJECT_TYPES]
           ([UID],[NAME],[PV],[INVULNERABLE])
     VALUES
           ('233F666B-C21F-4058-B1BC-643486DFB7B8','PalmeraFull',100,'false')
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

--------PalmeraFull
INSERT INTO [dbo].[REL_OBJECT_TYPES_AND_OBJECT_PART_TYPES]
           ([OBJECT_TYPE],[OBJECT_PART_TYPE],[OFFSET_X],[OFFSET_Y])
     VALUES
           ('233F666B-C21F-4058-B1BC-643486DFB7B8','598ECAC1-237A-4C7C-AB29-E057C8DE411A',0,0)
GO

