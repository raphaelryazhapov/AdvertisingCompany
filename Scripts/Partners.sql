/**
	Партнерская компания с указанием типа партнера.
*/
SELECT
	PartnerCompany.Id AS CompanyId,
	PartnerCompany.Name AS CompanyName,
	PartnerType.Name AS PartnerType
FROM PartnerCompany
INNER JOIN PartnerType ON PartnerTypeId = PartnerType.Id
ORDER BY PartnerType.Name DESC