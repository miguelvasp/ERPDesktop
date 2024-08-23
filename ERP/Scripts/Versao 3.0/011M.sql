/*
   quarta-feira, 7 de outubro de 201523:27:08
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
ALTER TABLE dbo.ContasPagarAberto
	DROP CONSTRAINT FK_ContasPagarAberto_PerfilFornecedor
GO
ALTER TABLE dbo.PerfilFornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PerfilFornecedor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PerfilFornecedor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PerfilFornecedor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContasPagarAberto
	DROP COLUMN IdPerfilFornecedor
GO
ALTER TABLE dbo.ContasPagarAberto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasPagarAberto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasPagarAberto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasPagarAberto', 'Object', 'CONTROL') as Contr_Per 