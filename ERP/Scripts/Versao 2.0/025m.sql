/*
   sexta-feira, 31 de julho de 201509:34:31
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
ALTER TABLE dbo.Fornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.OrdemProducao ADD CONSTRAINT
	FK_OrdemProducao_Fornecedor FOREIGN KEY
	(
	IdFornecedor
	) REFERENCES dbo.Fornecedor
	(
	IdFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.OrdemProducao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.OrdemProducao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.OrdemProducao', 'Object', 'CONTROL') as Contr_Per 