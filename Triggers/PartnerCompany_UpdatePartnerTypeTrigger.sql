/**
	��� ����� ��������� � ��������� ������ ���������� �������� ���������
	������� �������� ��� ����������� �������� � ����������� �� ��� ����������.
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