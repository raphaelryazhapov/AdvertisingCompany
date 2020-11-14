/**
	 омпани¤ и ее минимальна¤, максимальна¤, средн¤¤ и сумма стоимостей рекламных блоков
	если она приобрела уже более 20 рекламных блоков и при этом еЄ тип все ещЄ "ќбычный"
*/

DECLARE @Mass UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM PartnerType WHERE NAME = N'Mass');
DECLARE @AdBlockCountEnoughForAnalytics INT = 20;

SELECT
	MIN(Cost) AS MinAdBlockCost,
	MAX(Cost) AS MaxAdBlockCost,
	SUM(Cost) AS AdBlockCostSum,
	AVG(Cost) AS AvgAdBlockCost,
	PartnerCompany.Name AS CompanyName
FROM AdBlock
INNER JOIN PartnerCompany ON AdBlock.CompanyId = PartnerCompany.Id
WHERE PartnerTypeId = @Mass
GROUP BY PartnerCompany.Name
HAVING COUNT(*) > @AdBlockCountEnoughForAnalytics;