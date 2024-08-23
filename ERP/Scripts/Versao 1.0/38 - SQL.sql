/*
   sexta-feira, 26 de junho de 201522:04:14
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
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_ImpostoRetido
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_ImpostoRetido1
GO
ALTER TABLE dbo.ImpostoRetido SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ImpostoRetido', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ImpostoRetido', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ImpostoRetido', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Produto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Produto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Produto', 'Object', 'CONTROL') as Contr_Per 