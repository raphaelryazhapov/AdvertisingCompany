/**
	Проверяет, чтобы стоимость рекламных блоков была всегда положительна.
*/
CREATE OR ALTER TRIGGER AdBlock_CostIsPositive ON AdBlock
INSTEAD OF INSERT, UPDATE
AS
BEGIN
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
END;