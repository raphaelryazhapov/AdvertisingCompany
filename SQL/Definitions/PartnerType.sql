CREATE TABLE PartnerType
(
	[Id] UNIQUEIDENTIFIER PRIMARY KEY,
	[Name] NVARCHAR(50)
);

INSERT INTO PartnerType
	(Id, Name)
VALUES
	(NEWID(), N'Mass'),
	(NEWID(), N'Affluent'),
	(NEWID(), N'VIP')