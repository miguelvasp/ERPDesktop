/*
   sexta-feira, 10 de julho de 201510:06:58
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
ALTER TABLE dbo.EspecificacaoPagamento
	DROP CONSTRAINT FK_EspecificacaoPagamento_Segmento
GO
ALTER TABLE dbo.Segmento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Segmento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Segmento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Segmento', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.EspecificacaoPagamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.EspecificacaoPagamento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.EspecificacaoPagamento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.EspecificacaoPagamento', 'Object', 'CONTROL') as Contr_Per 