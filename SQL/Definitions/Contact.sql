CREATE TABLE Contact
(
	[Id] UNIQUEIDENTIFIER PRIMARY KEY,
	[Name] NVARCHAR(50),
	[Surname] NVARCHAR(50),
	[Patronymic] NVARCHAR(50)
);

INSERT INTO Contact
(
	Id,
	Name,
	Surname,
	Patronymic
)
VALUES
(NEWID(), 'Lei', 'Jun', ''),
(NEWID(), 'Kim', 'Hyun', 'Suk')