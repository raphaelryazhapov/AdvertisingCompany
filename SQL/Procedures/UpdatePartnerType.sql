/**
	Изменяет тип партнера 
	в зависимости от его количества приобретенных рекламных блоков и их средней стоимости.
*/
CREATE OR ALTER PROCEDURE UpdatePartnerType
@CompanyId UNIQUEIDENTIFIER
AS
BEGIN
	DECLARE @VIP UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM PartnerType WHERE Name = N'VIP');
	DECLARE @Affluent UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM PartnerType WHERE Name = N'Affluent');
	DECLARE @AdBlocksCountNeededToChangeType INT = 5;
	DECLARE @AvgAdBlockCostForVIP INT = 1200;
	DECLARE @AvgAdBlockCostForAffluent INT = 750;
	DECLARE @PartnerAdBlockCount INT = (
		SELECT
			COUNT(*)
		FROM AdBlock
		WHERE AdBlock.CompanyId = @CompanyId
	);
	DECLARE @AvgAdBlockCost FLOAT = (
		SELECT
			AVG(AdBlock.Cost)
		FROM AdBlock
		WHERE AdBlock.CompanyId = @CompanyId
	);

	IF @PartnerAdBlockCount >= @AdBlocksCountNeededToChangeType
		AND @AvgAdBlockCost >= @AvgAdBlockCostForVIP
		UPDATE PartnerCompany
		SET PartnerTypeId = @VIP
		WHERE PartnerCompany.Id = @CompanyId
	ELSE IF @PartnerAdBlockCount >= @AdBlocksCountNeededToChangeType
		AND @AvgAdBlockCost >= @AvgAdBlockCostForAffluent
		UPDATE PartnerCompany
		SET PartnerTypeId = @Affluent
		WHERE PartnerCompany.Id = @CompanyId
END;