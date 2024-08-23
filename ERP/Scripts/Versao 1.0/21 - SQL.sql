/*
   quarta-feira, 17 de junho de 201519:13:40
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
ALTER TABLE dbo.CodigoImposto
	DROP CONSTRAINT FK_CodigoImposto_JuridicaoImposto
GO
ALTER TABLE dbo.JuridicaoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.JuridicaoImposto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.JuridicaoImposto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.JuridicaoImposto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CodigoImposto
	DROP COLUMN IdPercentualValor
GO
ALTER TABLE dbo.CodigoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoImposto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoImposto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoImposto', 'Object', 'CONTROL') as Contr_Per 