/*
   quinta-feira, 2 de julho de 201520:38:03
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
ALTER TABLE dbo.AvaliacaoCredito ADD
	Valor decimal(18, 4) NULL
GO
ALTER TABLE dbo.AvaliacaoCredito SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.AvaliacaoCredito', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.AvaliacaoCredito', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.AvaliacaoCredito', 'Object', 'CONTROL') as Contr_Per 