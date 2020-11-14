CREATE TABLE AdBlock
(
	[Id] UNIQUEIDENTIFIER PRIMARY KEY,
	[AdBlockTypeId] UNIQUEIDENTIFIER,
	[Cost] INT,
	[CompanyId] UNIQUEIDENTIFIER,
	FOREIGN KEY (AdBlockTypeId) REFERENCES AdBlockType(Id),
	FOREIGN KEY (CompanyId) REFERENCES PartnerCompany(Id)
);

DECLARE @TextLong UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM AdBlockType WHERE Name = N'Text Long');
DECLARE @VoiceOnlyStandart UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM AdBlockType WHERE Name = N'VOICE ONLY Standart');
DECLARE @VideoSmall UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM AdBlockType WHERE Name = N'Video Small');
DECLARE @VideoLong UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM AdBlockType WHERE Name = N'Video Long');

DECLARE @Xiaomi UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM PartnerCompany WHERE NAME = N'Xiaomi');
DECLARE @HUANANZHI UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM PartnerCompany WHERE NAME = N'HUANANZHI');
DECLARE @1xBet UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM PartnerCompany WHERE NAME = N'1xBet');
DECLARE @Samsung UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM PartnerCompany WHERE NAME = N'Samsung');


INSERT INTO AdBlock
(
	Id,
	AdBlockTypeId,
	Cost,
	CompanyId
)
VALUES
(NEWID(), @TextLong, 300, @Xiaomi),
(NEWID(), @VideoLong, 1300, @Xiaomi),
(NEWID(), @VideoSmall, 800, @Xiaomi),
(NEWID(), @VideoLong, 2430, @Xiaomi),
(NEWID(), @VideoSmall, 740, @HUANANZHI),
(NEWID(), @VideoLong, 1430, @HUANANZHI),
(NEWID(), @VoiceOnlyStandart, 510, @1xBet),
(NEWID(), @TextLong, 280, @1xBet),
(NEWID(), @VideoSmall, 810, @1xBet),
(NEWID(), @VideoLong, 3100, @Samsung),
(NEWID(), @VideoSmall, 900, @Samsung),
(NEWID(), @VideoLong, 2900, @Samsung),
(NEWID(), @VideoLong, 1900, @Samsung),
(NEWID(), @VideoSmall, 843, @Samsung)