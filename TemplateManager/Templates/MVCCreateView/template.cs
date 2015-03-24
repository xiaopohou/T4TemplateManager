
if(Exists(SELECT * FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='bill.sage@tylertech.com'))
BEGIN
DECLARE @existingguid As uniqueidentifier
SET @existingguid = (select ID FROM [Tyler_CDC].CDC.ServiceContact WHERE ContactEMail='bill.sage@tylertech.com')
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D',@existingGuid)
END
ELSE
BEGIN
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('80b57f7e-d920-494e-8504-99579d494c2b' , 'bill.sage','bill.sage@tylertech.com',1,1,'bill.sage','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','80b57f7e-d920-494e-8504-99579d494c2b')
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
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('36650f23-ff3f-42a5-95c4-83c096183499' , 'travis.jorge','travis.jorge@tylertech.com',1,1,'travis.jorge','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','36650f23-ff3f-42a5-95c4-83c096183499')
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
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('d12316ff-aed6-4265-8a6a-98ae1e09f22c' , 'carol.newell','carol.newell@tylertech.com',1,1,'carol.newell','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','d12316ff-aed6-4265-8a6a-98ae1e09f22c')
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
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('1981583f-cdeb-470a-a64b-a079eda60da7' , 'wyatt.goodman','wyatt.goodman@tylertech.com',1,1,'wyatt.goodman','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','1981583f-cdeb-470a-a64b-a079eda60da7')
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
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('296cfda6-641f-4f0e-adfb-bdffb25dbe10' , 'tracy.thomason','tracy.thomason@tylertech.com',1,1,'tracy.thomason','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','296cfda6-641f-4f0e-adfb-bdffb25dbe10')
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
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('bf6378e3-1207-4fbb-a521-324f0884a845' , 'john.bridges','john.bridges@tylertech.com',1,1,'john.bridges','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','bf6378e3-1207-4fbb-a521-324f0884a845')
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
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('b7cea36f-d934-462f-ae98-f3afe52cca0e' , 'travis.taylor','travis.taylor@tylertech.com',1,1,'travis.taylor','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','b7cea36f-d934-462f-ae98-f3afe52cca0e')
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
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('d5b3a806-cdd4-4ef0-9353-3341edc538fe' , 'dan.ferguson','dan.ferguson@tylertech.com',1,1,'dan.ferguson','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','d5b3a806-cdd4-4ef0-9353-3341edc538fe')
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
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('1d25d6c3-3935-436f-93b1-73396ad581cc' , 'jd.davenport','jd.davenport@tylertech.com',1,1,'jd.davenport','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','1d25d6c3-3935-436f-93b1-73396ad581cc')
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
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('9a6dfd92-b868-4aee-b03b-fd66e9750865' , 'eric.hybner','eric.hybner@tylertech.com',1,1,'eric.hybner','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','9a6dfd92-b868-4aee-b03b-fd66e9750865')
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
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('542dda0e-d6f9-43f7-ad91-12b0e7faa96e' , 'mic.quintanilla','mic.quintanilla@tylertech.com',1,1,'mic.quintanilla','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','542dda0e-d6f9-43f7-ad91-12b0e7faa96e')
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
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('0b314ab9-f10e-40a5-a191-c2db6744c9ff' , 'nathan.lewis','nathan.lewis@tylertech.com',1,1,'nathan.lewis','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','0b314ab9-f10e-40a5-a191-c2db6744c9ff')
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
INSERT INTO [Tyler_CDC].CDC.ServiceContact Values('ac29b7ef-21f2-4d71-899c-f16a93536e4c' , 'sean.redfearn','sean.redfearn@tylertech.com',1,1,'sean.redfearn','',0,0,2)
INSERT INTO [Tyler_CDC].[CDC].[ServiceContactApplication] VALUES('A56F04B7-1E37-44C4-90C1-FA5F839C782D','ac29b7ef-21f2-4d71-899c-f16a93536e4c')
END
GO
