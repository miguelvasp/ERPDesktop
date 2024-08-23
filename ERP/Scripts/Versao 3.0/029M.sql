/*
   quinta-feira, 22 de outubro de 201517:53:21
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
ALTER TABLE dbo.RecebimentoItemLote
	DROP COLUMN Numero, LoteFornecedor, NumeroFornecedor
GO
ALTER TABLE dbo.RecebimentoItemLote SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.RecebimentoItemLote', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.RecebimentoItemLote', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.RecebimentoItemLote', 'Object', 'CONTROL') as Contr_Per 