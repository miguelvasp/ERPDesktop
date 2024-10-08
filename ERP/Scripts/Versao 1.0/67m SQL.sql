/*
   sexta-feira, 10 de julho de 201510:08:41
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
EXECUTE sp_rename N'dbo.EspecificacaoPagamento.IdSegmento', N'Tmp_IdSegmentoBancario', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.EspecificacaoPagamento.Tmp_IdSegmentoBancario', N'IdSegmentoBancario', 'COLUMN' 
GO
ALTER TABLE dbo.EspecificacaoPagamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.EspecificacaoPagamento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.EspecificacaoPagamento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.EspecificacaoPagamento', 'Object', 'CONTROL') as Contr_Per 