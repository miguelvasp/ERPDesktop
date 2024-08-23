/*
   quarta-feira, 17 de junho de 201518:41:43
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
ALTER TABLE dbo.ConfGrupoImposto ADD CONSTRAINT
	FK_ConfGrupoImposto_CodigoImposto FOREIGN KEY
	(
	IdCodigoImposto
	) REFERENCES dbo.CodigoImposto
	(
	IdCodigoImposto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ConfGrupoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ConfGrupoImposto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ConfGrupoImposto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ConfGrupoImposto', 'Object', 'CONTROL') as Contr_Per 