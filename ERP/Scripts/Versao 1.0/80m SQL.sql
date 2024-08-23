/*
   segunda-feira, 13 de julho de 201519:26:06
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
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoDescontos3
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoDescontos
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoDescontos1
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoDescontos2
GO
ALTER TABLE dbo.GrupoDescontos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoDescontos', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoDescontos', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoDescontos', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Produto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Produto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Produto', 'Object', 'CONTROL') as Contr_Per 