/*
   sábado, 4 de julho de 201521:35:43
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
ALTER TABLE dbo.GrupoImpostoRetido
	DROP CONSTRAINT FK_GrupoImpostoRetido_CodigoImpostoRetido
GO
ALTER TABLE dbo.CodigoImpostoRetido SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoImpostoRetido', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoImpostoRetido', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoImpostoRetido', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CodigoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoImposto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoImposto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoImposto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ConfGrupoImpostoRetido ADD CONSTRAINT
	FK_ConfGrupoImpostoRetido_CodigoImpostoRetido FOREIGN KEY
	(
	IdCodigoImpostoRetido
	) REFERENCES dbo.CodigoImpostoRetido
	(
	IdCodigoImpostoRetido
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ConfGrupoImpostoRetido SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ConfGrupoImpostoRetido', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ConfGrupoImpostoRetido', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ConfGrupoImpostoRetido', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ConfGrupoImpostoItem ADD CONSTRAINT
	FK_ConfGrupoImpostoItem_CodigoImposto FOREIGN KEY
	(
	IdCodigoImposto
	) REFERENCES dbo.CodigoImposto
	(
	IdCodigoImposto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ConfGrupoImpostoItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ConfGrupoImpostoItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ConfGrupoImpostoItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ConfGrupoImpostoItem', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoImpostoRetidoItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoImpostoRetidoItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoImpostoRetidoItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoImpostoRetidoItem', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ConfGrupoImpostosItemRetido ADD CONSTRAINT
	FK_ConfGrupoImpostosItemRetido_GrupoImpostoRetidoItem FOREIGN KEY
	(
	IdGrupoImpostoRetido
	) REFERENCES dbo.GrupoImpostoRetidoItem
	(
	IdGrupoImpostoRetidoItem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ConfGrupoImpostosItemRetido ADD CONSTRAINT
	FK_ConfGrupoImpostosItemRetido_CodigoImpostoRetido FOREIGN KEY
	(
	IdCodigoImpostoRetido
	) REFERENCES dbo.CodigoImpostoRetido
	(
	IdCodigoImpostoRetido
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ConfGrupoImpostosItemRetido SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ConfGrupoImpostosItemRetido', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ConfGrupoImpostosItemRetido', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ConfGrupoImpostosItemRetido', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoImpostoRetido
	DROP COLUMN IdCodigoImpostoRetido
GO
ALTER TABLE dbo.GrupoImpostoRetido SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoImpostoRetido', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoImpostoRetido', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoImpostoRetido', 'Object', 'CONTROL') as Contr_Per 