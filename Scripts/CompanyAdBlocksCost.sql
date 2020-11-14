/**
	Стоимость рекламных блоков по каждой компании сгруппированные по типу рекламного блока.
*/
SELECT
	PartnerCompany.Name AS CompanyName,
	AdBlockType.Name AS AdBlockType,
	SUM(Cost) AS Cost
FROM PartnerCompany
INNER JOIN AdBlock ON PartnerCompany.Id = CompanyId
INNER JOIN AdBlockType ON AdBlockType.Id = AdBlockTypeId
GROUP BY PartnerCompany.Name, AdBlockType.Name
