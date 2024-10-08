/*
   segunda-feira, 13 de julho de 201514:47:57
   User: mgasoftware
   Server: mssql.mgasolucoes.com.br
   Database: mgasoftware
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Fornecedor
	DROP CONSTRAINT FK_Fornecedor_CentroCusto
GO
ALTER TABLE dbo.Fornecedor
	DROP CONSTRAINT FK_Fornecedor_CentroCusto1
GO
ALTER TABLE dbo.Fornecedor
	DROP CONSTRAINT FK_Fornecedor_CentroCusto2
GO
ALTER TABLE dbo.Fornecedor
	DROP CONSTRAINT FK_Fornecedor_CentroCusto3
GO
ALTER TABLE dbo.Fornecedor
	DROP CONSTRAINT FK_Fornecedor_CentroCusto4
GO
ALTER TABLE dbo.CentroCusto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CentroCusto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CentroCusto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CentroCusto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Fornecedor
	DROP COLUMN IdCentroCusto1, IdCentroCusto2, IdCentroCusto3, IdCentroCusto4, IdCentroCusto5
GO
ALTER TABLE dbo.Fornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'CONTROL') as Contr_Per 