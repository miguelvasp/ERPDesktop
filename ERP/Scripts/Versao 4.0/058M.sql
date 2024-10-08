/*
   sábado, 16 de janeiro de 201600:52:28
   User: 
   Server: MIKE-PC
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
ALTER TABLE dbo.AjusteEstoque ADD
	Usuario_IdUsuario int NULL
GO
ALTER TABLE dbo.AjusteEstoque SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.AjusteEstoque', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.AjusteEstoque', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.AjusteEstoque', 'Object', 'CONTROL') as Contr_Per 