CREATE TABLE AdBlockType
(
	[Id] UNIQUEIDENTIFIER PRIMARY KEY,
	[Name] NVARCHAR(50) 
);

INSERT INTO AdBlockType
	(Id, Name)
VALUES
	(NEWID(), N'TEXT Small'),
	(NEWID(), N'TEXT Standart'),
	(NEWID(), N'TEXT Long'),
	(NEWID(), N'VOICE ONLY Small '),
	(NEWID(), N'VOICE ONLY Standart'),
	(NEWID(), N'VOICE ONLY Long'),
	(NEWID(), N'VIDEO Small'),
	(NEWID(), N'VIDEO Standart'),
	(NEWID(), N'VIDEO Long')