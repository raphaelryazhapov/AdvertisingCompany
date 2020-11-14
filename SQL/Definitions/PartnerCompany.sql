CREATE TABLE PartnerCompany
(
	[Id] UNIQUEIDENTIFIER PRIMARY KEY,
	[Name] NVARCHAR(50),
	[OwnerId] UNIQUEIDENTIFIER,
	[PartnerTypeId] UNIQUEIDENTIFIER,
	[AdBlockCount] INT,
	FOREIGN KEY (OwnerId) REFERENCES Contact(Id),
	FOREIGN KEY (PartnerTypeId) REFERENCES PartnerType(Id)
);

DECLARE @Mass UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM PartnerType WHERE Name = N'Mass');
DECLARE @XiaomiOwnwer UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Contact WHERE Name = 'Lei' AND Surname = 'Jun');
DECLARE @SamsungOwner UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Contact WHERE Name = 'Kim' AND Surname = 'Hyun' AND Patronymic = 'Suk');

INSERT INTO PartnerCompany
	(Id, Name, PartnerTypeId, OwnerId)
VALUES
	(NEWID(), N'HUANANZHI', @Mass, NULL),
	(NEWID(), N'JINGSHA', @Mass, NULL),
	(NEWID(), N'RAID SHADOW LEGENDS', @Mass, NULL),
	(NEWID(), N'1xBet', @Mass, NULL),
	(NEWID(), N'Xiaomi', @Mass, @XiaomiOwnwer),
	(NEWID(), N'UP-X', @Mass, NULL),
	(NEWID(), N'Samsung', @Mass, @SamsungOwner)