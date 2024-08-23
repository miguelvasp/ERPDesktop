/*
   segunda-feira, 15 de junho de 201520:04:11
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
ALTER TABLE dbo.CodigoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoImposto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoImposto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoImposto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoImposto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoImposto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoImposto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoImpostoCodigos ADD CONSTRAINT
	FK_GrupoImpostoCodigos_GrupoImposto FOREIGN KEY
	(
	IdGrupoImposto
	) REFERENCES dbo.GrupoImposto
	(
	IdGrupoImposto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.GrupoImpostoCodigos ADD CONSTRAINT
	FK_GrupoImpostoCodigos_CodigoImposto FOREIGN KEY
	(
	IdCodigoImposto
	) REFERENCES dbo.CodigoImposto
	(
	IdCodigoImposto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.GrupoImpostoCodigos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoImpostoCodigos', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoImpostoCodigos', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoImpostoCodigos', 'Object', 'CONTROL') as Contr_Per 