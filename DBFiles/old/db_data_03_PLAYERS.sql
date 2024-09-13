USE [TimeMachine]
GO

/************************************************************/
/* Connecting IMAGES/ANIMATIONS									*/
/************************************************************/

--Left
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('48c848bb-04ce-4598-9178-75ef60f130c7','ConnectingLeft')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('7f62ed27-83d7-4d10-9d59-5750d8e853f7','ConnectingLeft','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\ConnectingLeft.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('ce67feac-7f8e-4d0f-8222-3a2010c7968b','ConnectingLeft1','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\ConnectingLeft1.gif')
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('48c848bb-04ce-4598-9178-75ef60f130c7','ce67feac-7f8e-4d0f-8222-3a2010c7968b',1)
GO

--Right
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('b19c9c21-f225-4617-afcc-357de238b017','ConnectingRight')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('dcee17fa-119f-4200-a5ec-14eb2b2b2d1f','ConnectingRight','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\ConnectingRight.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('98c5067f-da75-46f4-ac72-d82f77e35604','ConnectingRight1','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\ConnectingRight1.gif')
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('b19c9c21-f225-4617-afcc-357de238b017','98c5067f-da75-46f4-ac72-d82f77e35604',1)
GO

--Up
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('bd785007-64ee-448d-888b-09914d3999c6','ConnectingUp')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('b217b20b-b63b-4bdd-b4d7-0cb419a42cab','ConnectingUp','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\ConnectingUp.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('bb3fcec1-5d53-4401-a675-caabc0e9b05d','ConnectingUp1','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\ConnectingUp1.gif')
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('bd785007-64ee-448d-888b-09914d3999c6','bb3fcec1-5d53-4401-a675-caabc0e9b05d',1)
GO

--Down
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('d1ac19bf-d310-4fba-a0ea-409097168b88','ConnectingDown')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('be8add73-36e5-43ec-8f1e-e0c53b047515','ConnectingDown','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\ConnectingDown.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('36b63b3a-bd14-4799-a524-2b2478ee0a8f','ConnectingDown1','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\ConnectingDown1.gif')
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('d1ac19bf-d310-4fba-a0ea-409097168b88','36b63b3a-bd14-4799-a524-2b2478ee0a8f',1)
GO

/************************************************************/
/* BOLITA IMAGES/ANIMATIONS									*/
/************************************************************/

--Left
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('fd737e71-cfdc-4378-aca5-63c77e45335b','BolitaLeft')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('78c136c9-4a81-466e-82e9-12696b09aa7e','BolitaLeft','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaLeft.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('d434e80b-a9d0-4f2e-abf8-de1ace8fbab7','BolitaLeft1','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaLeft1.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('a250860e-37df-4492-b14e-251557043162','BolitaLeft2','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaLeft2.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('085939fe-7063-4435-909a-3da502a37107','BolitaLeft3','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaLeft3.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('d8c0906e-2191-42c7-8be6-319cb871735c','BolitaLeft4','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaLeft4.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('128ec8f6-8721-403e-8e48-399f60dab699','BolitaLeft5','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaLeft5.gif')
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('fd737e71-cfdc-4378-aca5-63c77e45335b','d434e80b-a9d0-4f2e-abf8-de1ace8fbab7',1)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('fd737e71-cfdc-4378-aca5-63c77e45335b','a250860e-37df-4492-b14e-251557043162',2)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('fd737e71-cfdc-4378-aca5-63c77e45335b','085939fe-7063-4435-909a-3da502a37107',3)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('fd737e71-cfdc-4378-aca5-63c77e45335b','d8c0906e-2191-42c7-8be6-319cb871735c',4)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('fd737e71-cfdc-4378-aca5-63c77e45335b','128ec8f6-8721-403e-8e48-399f60dab699',5)
GO

--Right
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('a2ffab99-45e3-4811-9bcd-2a6e6cf306d6','BolitaRight')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('d877ecf6-d643-46d3-9351-bf7d4ccd8eb4','BolitaRight','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaRight.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('74668f08-5e2c-4986-a3c3-a3b0f3016527','BolitaRight1','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaRight1.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('c85e8546-368b-4855-917b-dd7b7d25361f','BolitaRight2','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaRight2.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('ef4dd2de-b871-4190-8aa3-4595041bd592','BolitaRight3','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaRight3.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('4ec7b92b-e648-4f96-8dbc-3d3449cec21c','BolitaRight4','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaRight4.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('1dd7ef3e-f752-4705-81a2-1bf96ba53d40','BolitaRight5','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaRight5.gif')
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('a2ffab99-45e3-4811-9bcd-2a6e6cf306d6','74668f08-5e2c-4986-a3c3-a3b0f3016527',1)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('a2ffab99-45e3-4811-9bcd-2a6e6cf306d6','c85e8546-368b-4855-917b-dd7b7d25361f',2)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('a2ffab99-45e3-4811-9bcd-2a6e6cf306d6','ef4dd2de-b871-4190-8aa3-4595041bd592',3)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('a2ffab99-45e3-4811-9bcd-2a6e6cf306d6','4ec7b92b-e648-4f96-8dbc-3d3449cec21c',4)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('a2ffab99-45e3-4811-9bcd-2a6e6cf306d6','1dd7ef3e-f752-4705-81a2-1bf96ba53d40',5)
GO

--Up
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('491b87de-a713-4921-be57-eda910d5ac94','BolitaUp')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('7e19b9b9-b7e8-4adb-aa6a-1a61e20fdb81','BolitaUp','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaUp.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('469f14eb-d223-4d4c-973b-6fc6eacc36a1','BolitaUp1','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaUp1.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('05828ea2-35f9-4033-9c66-ef5587f35b24','BolitaUp2','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaUp2.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('d7b4c209-8382-4327-bf37-f1d99ead6c92','BolitaUp3','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaUp3.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('a4094b71-1e3b-4b49-b260-b022b1966ef7','BolitaUp4','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaUp4.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('8d6c45fe-f03b-4c1e-badb-ca4969bbc12e','BolitaUp5','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaUp5.gif')
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('491b87de-a713-4921-be57-eda910d5ac94','469f14eb-d223-4d4c-973b-6fc6eacc36a1',1)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('491b87de-a713-4921-be57-eda910d5ac94','05828ea2-35f9-4033-9c66-ef5587f35b24',2)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('491b87de-a713-4921-be57-eda910d5ac94','d7b4c209-8382-4327-bf37-f1d99ead6c92',3)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('491b87de-a713-4921-be57-eda910d5ac94','a4094b71-1e3b-4b49-b260-b022b1966ef7',4)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('491b87de-a713-4921-be57-eda910d5ac94','8d6c45fe-f03b-4c1e-badb-ca4969bbc12e',5)
GO

--Down
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('24d83307-67df-47ff-96e5-7c8135e5346b','BolitaDown')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('38f7e481-1208-4d2d-93de-cfdaa11f0825','BolitaDown','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaDown.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('87e6271f-92a2-4837-b421-208292ea9d3e','BolitaDown1','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaDown1.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('1e45a18e-0736-4ad3-8a80-8c8b0590869a','BolitaDown2','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaDown2.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('04d50205-1c8e-4869-9b10-d71b827fd7dd','BolitaDown3','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaDown3.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('8b57d5ac-66e6-47f1-96de-2d4344d76c5e','BolitaDown4','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaDown4.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('d99c9004-a8e9-41b3-bfc2-cdf72e95fbe5','BolitaDown5','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\BolitaDown5.gif')
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('24d83307-67df-47ff-96e5-7c8135e5346b','87e6271f-92a2-4837-b421-208292ea9d3e',1)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('24d83307-67df-47ff-96e5-7c8135e5346b','1e45a18e-0736-4ad3-8a80-8c8b0590869a',2)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('24d83307-67df-47ff-96e5-7c8135e5346b','04d50205-1c8e-4869-9b10-d71b827fd7dd',3)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('24d83307-67df-47ff-96e5-7c8135e5346b','8b57d5ac-66e6-47f1-96de-2d4344d76c5e',4)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('24d83307-67df-47ff-96e5-7c8135e5346b','d99c9004-a8e9-41b3-bfc2-cdf72e95fbe5',5)
GO

/************************************************************/
/* CAPUCHA IMAGES/ANIMATIONS									*/
/************************************************************/

--Left
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('bec41dcc-c1b4-4cb9-b5a1-9bdcdf0d0944','CapuchaLeft')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('5ca194a0-d5e0-41a6-b9cc-f61966805b12','CapuchaLeft','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaLeft.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('f0942d10-0595-46d6-840f-699b71e7538d','CapuchaLeft1','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaLeft1.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('7e5df09a-d780-46b1-ae63-f90a28bb634a','CapuchaLeft2','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaLeft2.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('544b29bd-5369-49e5-b922-14d25a556a24','CapuchaLeft3','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaLeft3.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('6ca5170a-8031-4571-9455-2ba67b0b43d9','CapuchaLeft4','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaLeft4.gif')
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('bec41dcc-c1b4-4cb9-b5a1-9bdcdf0d0944','f0942d10-0595-46d6-840f-699b71e7538d',1)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('bec41dcc-c1b4-4cb9-b5a1-9bdcdf0d0944','7e5df09a-d780-46b1-ae63-f90a28bb634a',2)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('bec41dcc-c1b4-4cb9-b5a1-9bdcdf0d0944','544b29bd-5369-49e5-b922-14d25a556a24',3)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('bec41dcc-c1b4-4cb9-b5a1-9bdcdf0d0944','6ca5170a-8031-4571-9455-2ba67b0b43d9',4)
GO

--Right
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('d54f26a9-6b7d-4a6b-9a93-456df60831d3','CapuchaRight')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('9a967388-b9fb-4a63-b88a-932c026f161d','CapuchaRight','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaRight.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('0cd77084-f9ac-495b-aafd-532142a60d5f','CapuchaRight1','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaRight1.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('47328805-0931-4b17-a5db-0aad2ea7f006','CapuchaRight2','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaRight2.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('7312a1d6-5893-442c-9bb9-26596406a56b','CapuchaRight3','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaRight3.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('b6481e55-b5f6-48d2-a856-eb173d939a55','CapuchaRight4','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaRight4.gif')
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('d54f26a9-6b7d-4a6b-9a93-456df60831d3','0cd77084-f9ac-495b-aafd-532142a60d5f',1)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('d54f26a9-6b7d-4a6b-9a93-456df60831d3','47328805-0931-4b17-a5db-0aad2ea7f006',2)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('d54f26a9-6b7d-4a6b-9a93-456df60831d3','7312a1d6-5893-442c-9bb9-26596406a56b',3)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('d54f26a9-6b7d-4a6b-9a93-456df60831d3','b6481e55-b5f6-48d2-a856-eb173d939a55',4)
GO

--Up
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('0903ad94-42e0-400d-8b05-481d84dd0b03','CapuchaUp')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('fb722e13-6ac3-4221-ac16-3afa9cf8d843','CapuchaUp','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaUp.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('b11e781b-8b89-47e9-ac9e-1856ae718796','CapuchaUp1','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaUp1.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('c2dd6dc1-8ad2-432a-b633-51dec884f2e4','CapuchaUp2','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaUp2.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('80696bf7-a530-44d3-8044-9c51dd1fb2e0','CapuchaUp3','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaUp3.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('628ea8ef-4b46-402a-8b94-f55c432a9857','CapuchaUp4','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaUp4.gif')
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('0903ad94-42e0-400d-8b05-481d84dd0b03','b11e781b-8b89-47e9-ac9e-1856ae718796',1)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('0903ad94-42e0-400d-8b05-481d84dd0b03','c2dd6dc1-8ad2-432a-b633-51dec884f2e4',2)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('0903ad94-42e0-400d-8b05-481d84dd0b03','80696bf7-a530-44d3-8044-9c51dd1fb2e0',3)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('0903ad94-42e0-400d-8b05-481d84dd0b03','628ea8ef-4b46-402a-8b94-f55c432a9857',4)
GO

--Down
INSERT INTO [dbo].[ANIMATIONS] ([UID],[NAME])
     VALUES ('2993d5d6-006e-484b-9c5d-07e3aa54af81','CapuchaDown')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('9e0f1363-30db-45a4-a9bd-2e43209e2f3e','CapuchaDown','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaDown.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('4c8bf818-7350-4bf5-9ae6-7818ff418669','CapuchaDown1','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaDown1.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('ef1ec38a-ba57-4fd6-af22-c009bf62b2ff','CapuchaDown2','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaDown2.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('8a880c36-ca7f-4fe2-9042-4a62739630fb','CapuchaDown3','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaDown3.gif')
GO
INSERT INTO [dbo].[PLAYER_IMAGES] ([UID],[NAME],[IMAGE])
     VALUES ('e337a42e-c823-47b3-88d0-66c39661f14d','CapuchaDown4','D:\Olles\TimeLine\TimeLine\Images\Players\Bases\CapuchaDown4.gif')
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('2993d5d6-006e-484b-9c5d-07e3aa54af81','4c8bf818-7350-4bf5-9ae6-7818ff418669',1)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('2993d5d6-006e-484b-9c5d-07e3aa54af81','ef1ec38a-ba57-4fd6-af22-c009bf62b2ff',2)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('2993d5d6-006e-484b-9c5d-07e3aa54af81','8a880c36-ca7f-4fe2-9042-4a62739630fb',3)
GO
INSERT INTO [dbo].[PLAYER_ANIMATION_IMAGES] ([ANIMATION],[IMAGE],[STEP])
	 VALUES ('2993d5d6-006e-484b-9c5d-07e3aa54af81','e337a42e-c823-47b3-88d0-66c39661f14d',4)
GO

/************************************************************/
/* PLAYERS    												*/
/************************************************************/

INSERT INTO [dbo].[PLAYERS] ([UID], [NAME], [ROOM_TILE_GRID_X], [ROOM_TILE_GRID_Y], [MOVEMENT_SPEED], 
	[MOVEMENT], [MOVEMENT_TIMESTAMP], [MOVED], [FACING], [FACING_TIMESTAMP], [INITIATIVE], 
	[LIGHTNING], [LIGHTNING_TILES], [LIGHTNING_FACTOR], [ATTACK_SPEED], [ATTACK_TIMESTAMP], [ATTACKED], INTERACT_TIMESTAMP,
	[ANIMATION_LEFT],[ANIMATION_RIGHT],
	[ANIMATION_UP],[ANIMATION_DOWN],
	[IMAGE_LEFT],[IMAGE_RIGHT],
	[IMAGE_UP],[IMAGE_DOWN])
VALUES ('e8b6d65a-aa79-4c7a-8c07-f8b064f60d74', 'Player1', 5, 5, '0,75', 
	0, CURRENT_TIMESTAMP, 'true', 2, CURRENT_TIMESTAMP, 1,
	255, 5, '0,5', '0,75', CURRENT_TIMESTAMP, 'true', CURRENT_TIMESTAMP,
	'fd737e71-cfdc-4378-aca5-63c77e45335b', 'a2ffab99-45e3-4811-9bcd-2a6e6cf306d6',
	'491b87de-a713-4921-be57-eda910d5ac94', '24d83307-67df-47ff-96e5-7c8135e5346b',
	'78c136c9-4a81-466e-82e9-12696b09aa7e', 'd877ecf6-d643-46d3-9351-bf7d4ccd8eb4',
	'7e19b9b9-b7e8-4adb-aa6a-1a61e20fdb81','38f7e481-1208-4d2d-93de-cfdaa11f0825');
GO



INSERT INTO [dbo].[PLAYERS] ([UID], [NAME], [ROOM_TILE_GRID_X], [ROOM_TILE_GRID_Y], [MOVEMENT_SPEED], 
	[MOVEMENT], [MOVEMENT_TIMESTAMP], [MOVED], [FACING], [FACING_TIMESTAMP], [INITIATIVE], 
	[LIGHTNING], [LIGHTNING_TILES], [LIGHTNING_FACTOR], [ATTACK_SPEED], [ATTACK_TIMESTAMP], [ATTACKED], INTERACT_TIMESTAMP,
	[ANIMATION_LEFT],[ANIMATION_RIGHT],
	[ANIMATION_UP],[ANIMATION_DOWN],
	[IMAGE_LEFT],[IMAGE_RIGHT],
	[IMAGE_UP],[IMAGE_DOWN])
VALUES ('8b0224d8-4f1b-4742-a282-a38c50b001d9', 'Player2', 6, 5, '0,75', 
	0, CURRENT_TIMESTAMP, 'true', 2, CURRENT_TIMESTAMP, 1,
	255, 5, '0,5', '0,75', CURRENT_TIMESTAMP, 'true', CURRENT_TIMESTAMP,
	'bec41dcc-c1b4-4cb9-b5a1-9bdcdf0d0944', 'd54f26a9-6b7d-4a6b-9a93-456df60831d3',
	'0903ad94-42e0-400d-8b05-481d84dd0b03', '2993d5d6-006e-484b-9c5d-07e3aa54af81',
	'5ca194a0-d5e0-41a6-b9cc-f61966805b12', '9a967388-b9fb-4a63-b88a-932c026f161d',
	'fb722e13-6ac3-4221-ac16-3afa9cf8d843','9e0f1363-30db-45a4-a9bd-2e43209e2f3e');
GO

INSERT INTO [dbo].[PLAYERS] ([UID], [NAME], [ROOM_TILE_GRID_X], [ROOM_TILE_GRID_Y], [MOVEMENT_SPEED], 
	[MOVEMENT], [MOVEMENT_TIMESTAMP], [MOVED], [FACING], [FACING_TIMESTAMP], [INITIATIVE], 
	[LIGHTNING], [LIGHTNING_TILES], [LIGHTNING_FACTOR], [ATTACK_SPEED], [ATTACK_TIMESTAMP], [ATTACKED], INTERACT_TIMESTAMP,
	[ANIMATION_LEFT],[ANIMATION_RIGHT],
	[ANIMATION_UP],[ANIMATION_DOWN],
	[IMAGE_LEFT],[IMAGE_RIGHT],
	[IMAGE_UP],[IMAGE_DOWN])
VALUES ('479F256B-6327-4301-9824-D37713ABD472', 'GOD', 6, 5, '0,75', 
	0, CURRENT_TIMESTAMP, 'true', 2, CURRENT_TIMESTAMP, 1,
	255, 5, '0,5', '0,75', CURRENT_TIMESTAMP, 'true', CURRENT_TIMESTAMP,
	'bec41dcc-c1b4-4cb9-b5a1-9bdcdf0d0944', 'd54f26a9-6b7d-4a6b-9a93-456df60831d3',
	'0903ad94-42e0-400d-8b05-481d84dd0b03', '2993d5d6-006e-484b-9c5d-07e3aa54af81',
	'5ca194a0-d5e0-41a6-b9cc-f61966805b12', '9a967388-b9fb-4a63-b88a-932c026f161d',
	'fb722e13-6ac3-4221-ac16-3afa9cf8d843','9e0f1363-30db-45a4-a9bd-2e43209e2f3e');
GO