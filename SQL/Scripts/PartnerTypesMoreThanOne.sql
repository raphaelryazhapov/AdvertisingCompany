/**
	Типы партнеров с более, чем одной записью о партнере такого типа. 
*/
SELECT
	PartnerType.Name AS PartnerType,
	COUNT(*) AS PartnerCount
FROM PartnerCompany
INNER JOIN PartnerType ON PartnerTypeId = PartnerType.Id
GROUP BY PartnerType.Name
HAVING COUNT(*) > 1