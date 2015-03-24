
if(Exists(SELECT * FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='bill.sage@tylertech.com'))
BEGIN
DECLARE @existingguid As uniqueidentifier
SET @existingguid = (select ID FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='bill.sage@tylertech.com')
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D',@existingGuid)
END
ELSE
BEGIN
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('bc480807-c824-4659-9d3e-7f27383973fb' , 'bill.sage','bill.sage@tylertech.com',1,1,'bill.sage','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','bc480807-c824-4659-9d3e-7f27383973fb')
END
GO
if(Exists(SELECT * FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='travis.jorge@tylertech.com'))
BEGIN
DECLARE @existingguid As uniqueidentifier
SET @existingguid = (select ID FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='travis.jorge@tylertech.com')
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D',@existingGuid)
END
ELSE
BEGIN
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('f9d6ca3d-322e-4c64-b059-cd4f92c63a8a' , 'travis.jorge','travis.jorge@tylertech.com',1,1,'travis.jorge','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','f9d6ca3d-322e-4c64-b059-cd4f92c63a8a')
END
GO
if(Exists(SELECT * FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='carol.newell@tylertech.com'))
BEGIN
DECLARE @existingguid As uniqueidentifier
SET @existingguid = (select ID FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='carol.newell@tylertech.com')
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D',@existingGuid)
END
ELSE
BEGIN
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('3f35476e-cd56-4c6f-90c5-b923494bea45' , 'carol.newell','carol.newell@tylertech.com',1,1,'carol.newell','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','3f35476e-cd56-4c6f-90c5-b923494bea45')
END
GO
if(Exists(SELECT * FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='wyatt.goodman@tylertech.com'))
BEGIN
DECLARE @existingguid As uniqueidentifier
SET @existingguid = (select ID FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='wyatt.goodman@tylertech.com')
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D',@existingGuid)
END
ELSE
BEGIN
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('8a9b2e4e-3c27-4041-a6dd-af3547b0bc69' , 'wyatt.goodman','wyatt.goodman@tylertech.com',1,1,'wyatt.goodman','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','8a9b2e4e-3c27-4041-a6dd-af3547b0bc69')
END
GO
if(Exists(SELECT * FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='tracy.thomason@tylertech.com'))
BEGIN
DECLARE @existingguid As uniqueidentifier
SET @existingguid = (select ID FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='tracy.thomason@tylertech.com')
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D',@existingGuid)
END
ELSE
BEGIN
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('0419187a-340d-4685-9f28-f3f28d1aa0d9' , 'tracy.thomason','tracy.thomason@tylertech.com',1,1,'tracy.thomason','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','0419187a-340d-4685-9f28-f3f28d1aa0d9')
END
GO
if(Exists(SELECT * FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='john.bridges@tylertech.com'))
BEGIN
DECLARE @existingguid As uniqueidentifier
SET @existingguid = (select ID FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='john.bridges@tylertech.com')
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D',@existingGuid)
END
ELSE
BEGIN
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('220bd453-fa52-43a0-8fd3-aa22387eab50' , 'john.bridges','john.bridges@tylertech.com',1,1,'john.bridges','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','220bd453-fa52-43a0-8fd3-aa22387eab50')
END
GO
if(Exists(SELECT * FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='travis.taylor@tylertech.com'))
BEGIN
DECLARE @existingguid As uniqueidentifier
SET @existingguid = (select ID FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='travis.taylor@tylertech.com')
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D',@existingGuid)
END
ELSE
BEGIN
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('fd6b5f6a-17c5-4ca2-96d5-100042b3cf5f' , 'travis.taylor','travis.taylor@tylertech.com',1,1,'travis.taylor','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','fd6b5f6a-17c5-4ca2-96d5-100042b3cf5f')
END
GO
if(Exists(SELECT * FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='dan.ferguson@tylertech.com'))
BEGIN
DECLARE @existingguid As uniqueidentifier
SET @existingguid = (select ID FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='dan.ferguson@tylertech.com')
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D',@existingGuid)
END
ELSE
BEGIN
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('017ff489-bfab-4864-89db-f18aca8ff8a8' , 'dan.ferguson','dan.ferguson@tylertech.com',1,1,'dan.ferguson','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','017ff489-bfab-4864-89db-f18aca8ff8a8')
END
GO
if(Exists(SELECT * FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='jd.davenport@tylertech.com'))
BEGIN
DECLARE @existingguid As uniqueidentifier
SET @existingguid = (select ID FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='jd.davenport@tylertech.com')
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D',@existingGuid)
END
ELSE
BEGIN
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('40a53555-f37b-4aca-921d-fcf507e87b30' , 'jd.davenport','jd.davenport@tylertech.com',1,1,'jd.davenport','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','40a53555-f37b-4aca-921d-fcf507e87b30')
END
GO
if(Exists(SELECT * FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='eric.hybner@tylertech.com'))
BEGIN
DECLARE @existingguid As uniqueidentifier
SET @existingguid = (select ID FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='eric.hybner@tylertech.com')
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D',@existingGuid)
END
ELSE
BEGIN
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('9d97ddd0-ecbc-4934-83e4-f2720f5f4fab' , 'eric.hybner','eric.hybner@tylertech.com',1,1,'eric.hybner','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','9d97ddd0-ecbc-4934-83e4-f2720f5f4fab')
END
GO
if(Exists(SELECT * FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='mic.quintanilla@tylertech.com'))
BEGIN
DECLARE @existingguid As uniqueidentifier
SET @existingguid = (select ID FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='mic.quintanilla@tylertech.com')
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D',@existingGuid)
END
ELSE
BEGIN
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('a7cc6980-4c3c-41e0-b405-b373ec548472' , 'mic.quintanilla','mic.quintanilla@tylertech.com',1,1,'mic.quintanilla','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','a7cc6980-4c3c-41e0-b405-b373ec548472')
END
GO
if(Exists(SELECT * FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='nathan.lewis@tylertech.com'))
BEGIN
DECLARE @existingguid As uniqueidentifier
SET @existingguid = (select ID FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='nathan.lewis@tylertech.com')
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D',@existingGuid)
END
ELSE
BEGIN
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('65018b46-11cf-4f98-a292-fe480aaa25d6' , 'nathan.lewis','nathan.lewis@tylertech.com',1,1,'nathan.lewis','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','65018b46-11cf-4f98-a292-fe480aaa25d6')
END
GO
if(Exists(SELECT * FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='sean.redfearn@tylertech.com'))
BEGIN
DECLARE @existingguid As uniqueidentifier
SET @existingguid = (select ID FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='sean.redfearn@tylertech.com')
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D',@existingGuid)
END
ELSE
BEGIN
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('b8158701-2f5d-44f5-8ea4-849133c4d404' , 'sean.redfearn','sean.redfearn@tylertech.com',1,1,'sean.redfearn','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','b8158701-2f5d-44f5-8ea4-849133c4d404')
END
GO
