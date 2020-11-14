DECLARE @Mass UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM PartnerType WHERE Name = N'Mass');
DECLARE @Affluent UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM PartnerType WHERE Name = N'Affluent');
DECLARE @Vip UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM PartnerType WHERE Name = N'VIP');

INSERT INTO PartnerCompany
	(Id, Name, PartnerTypeId)
VALUES
	(NEWID(), N'HUANANZHI', @Mass),
	(NEWID(), N'JINGSHA', @Mass),
	(NEWID(), N'RAID SHADOW LEGENDS', @Affluent),
	(NEWID(), N'1xBet', @Affluent),
	(NEWID(), N'Xiaomi', @Affluent),
	(NEWID(), N'UP-X', @Affluent),
	(NEWID(), N'Samsung', @Vip)