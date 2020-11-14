/**
	Компания и минимальная стоимость её рекламного блока для компаний, 
	у которых минимальная стоимость рекламного блока больше, чем средняя стоимость по всем компаниям.
*/

SELECT
	Name,
	MIN(Cost)
FROM AdBlock
INNER JOIN PartnerCompany company ON CompanyId = company.Id
WHERE 
	(
		SELECT
			MIN(Cost)
		FROM AdBlock
		WHERE CompanyId = company.Id
	) >
	(
		SELECT
			AVG(Cost)
		FROM AdBlock
	)
GROUP BY Name