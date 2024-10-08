/*
   quinta-feira, 5 de maio de 201619:28:18
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
ALTER TABLE dbo.OrigemLancamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.OrigemLancamento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.OrigemLancamento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.OrigemLancamento', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.TextoTransacao ADD CONSTRAINT
	FK_TextoTransacao_OrigemLancamento FOREIGN KEY
	(
	IdOrigemLancamento
	) REFERENCES dbo.OrigemLancamento
	(
	IdOrigemLancamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TextoTransacao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.TextoTransacao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.TextoTransacao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.TextoTransacao', 'Object', 'CONTROL') as Contr_Per 