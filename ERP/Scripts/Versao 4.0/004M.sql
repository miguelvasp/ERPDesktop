/*
   domingo, 1 de novembro de 201514:09:14
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
ALTER TABLE dbo.Banco SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Banco', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Banco', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Banco', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContasPagar SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasPagar', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasPagar', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasPagar', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ChequeTerceiros ADD CONSTRAINT
	FK_ChequeTerceiros_ContasPagar FOREIGN KEY
	(
	IdContasPagar
	) REFERENCES dbo.ContasPagar
	(
	IdContasPagar
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ChequeTerceiros ADD CONSTRAINT
	FK_ChequeTerceiros_Banco FOREIGN KEY
	(
	IdBanco
	) REFERENCES dbo.Banco
	(
	IdBanco
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ChequeTerceiros SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ChequeTerceiros', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ChequeTerceiros', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ChequeTerceiros', 'Object', 'CONTROL') as Contr_Per 