/**
	Проверяет, чтобы стоимость рекламных блоков была всегда положительна.
*/
CREATE OR ALTER TRIGGER AdBlock_CostIsPositive ON AdBlock
INSTEAD OF INSERT, UPDATE
AS
BEGIN
	DECLARE @Operation NVARCHAR(10);

	IF EXISTS 
		(
			SELECT TOP 1
				AdBlock.Id
			FROM AdBlock, INSERTED
			WHERE AdBlock.Id = INSERTED.Id
		)
		SET @Operation = 'Update';
	ELSE
		SET @Operation = 'Insert';

	DECLARE @InsertedCost INT = (
		SELECT Cost
		FROM INSERTED
	);

	DECLARE @InsertedId NVARCHAR(50) = (
		SELECT 
			Id
		FROM INSERTED
	);

	IF @InsertedCost <= 0
		DECLARE @ErrorMessage NVARCHAR(50) = N'Cost should be positive, Id = %s';
		RAISERROR (@ErrorMessage, 10, 1, @InsertedId)
	
	IF @Operation = 'Insert'
		INSERT INTO AdBlock
		SELECT
			*
		FROM INSERTED
	ELSE
		UPDATE AdBlock
		SET Id = INSERTED.Id,
			AdBlockTypeId = INSERTED.AdBlockTypeId,
			CompanyId = INSERTED.CompanyId,
			Cost = INSERTED.Cost
		FROM INSERTED
END;