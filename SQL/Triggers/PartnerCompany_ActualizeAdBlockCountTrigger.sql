/**
	Поддержка актуальности данных о количестве рекламных блоков компании.
*/
CREATE OR ALTER TRIGGER PartnerCompany_ActualizeAdBlockCount ON AdBlock
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
	IF EXISTS (
		SELECT TOP 1 
			PartnerCompany.Id
		FROM PartnerCompany, INSERTED
		WHERE PartnerCompany.Id = INSERTED.CompanyId
	)
		UPDATE PartnerCompany
		SET AdBlockCount = (
			SELECT COUNT(*)
			FROM AdBlock, INSERTED
			WHERE AdBlock.CompanyId = INSERTED.CompanyId
		)
		FROM INSERTED
		WHERE PartnerCompany.Id = INSERTED.CompanyId
END;