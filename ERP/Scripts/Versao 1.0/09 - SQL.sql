/*
   terça-feira, 9 de junho de 201518:59:37
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
ALTER TABLE dbo.GrupoEstoque SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoEstoque', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoEstoque', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoEstoque', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoRastreamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoRastreamento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoRastreamento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoRastreamento', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoArmazenamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoArmazenamento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoArmazenamento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoArmazenamento', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_GrupoArmazenamento FOREIGN KEY
	(
	IdGrupoArmazenamento
	) REFERENCES dbo.GrupoArmazenamento
	(
	IdGrupoArmazenamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_GrupoEstoque FOREIGN KEY
	(
	IdGrupoEstoque
	) REFERENCES dbo.GrupoEstoque
	(
	IdGrupoEstoque
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_GrupoRastreamento FOREIGN KEY
	(
	IdGrupoRastreamento
	) REFERENCES dbo.GrupoRastreamento
	(
	IdGrupoRastreamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Produto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Produto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Produto', 'Object', 'CONTROL') as Contr_Per 