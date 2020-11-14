/**
	ѕри любых действи€х с рекламным блоком вызываетс€ хранима€ процедура
	котора€ измен€ет тип партнерской компании в зависимости от его параметров.
*/
CREATE OR ALTER TRIGGER PartnerCompany_UpdatepartnerType ON AdBlock
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	DECLARE @CompanyId UNIQUEIDENTIFIER = (
		SELECT 
			CompanyId
		FROM INSERTED
	);
	EXECUTE UpdatePartnerType
	@CompanyId = @CompanyId
END;