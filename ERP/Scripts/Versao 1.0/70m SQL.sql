/*
   sexta-feira, 10 de julho de 201514:55:54
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
ALTER TABLE dbo.VariantesGrupo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesGrupo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesGrupo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesGrupo', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.VariantesGrupoItem ADD CONSTRAINT
	FK_VariantesGrupoItem_VariantesGrupo FOREIGN KEY
	(
	IdVariantesGrupo
	) REFERENCES dbo.VariantesGrupo
	(
	IdVariantesGrupo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.VariantesGrupoItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesGrupoItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesGrupoItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesGrupoItem', 'Object', 'CONTROL') as Contr_Per 