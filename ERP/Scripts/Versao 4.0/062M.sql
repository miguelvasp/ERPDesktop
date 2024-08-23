/*
   segunda-feira, 25 de janeiro de 201614:06:21
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
ALTER TABLE dbo.GrupoEncargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoEncargos', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoEncargos', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoEncargos', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CodigoEncargo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoEncargo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoEncargo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoEncargo', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoEncargosCodigoEncargo ADD CONSTRAINT
	FK_GrupoEncargosCodigoEncargo_GrupoEncargos FOREIGN KEY
	(
	IdGrupoEncargos
	) REFERENCES dbo.GrupoEncargos
	(
	IdGrupoEncargos
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.GrupoEncargosCodigoEncargo ADD CONSTRAINT
	FK_GrupoEncargosCodigoEncargo_CodigoEncargo FOREIGN KEY
	(
	IdCodigoEncargo
	) REFERENCES dbo.CodigoEncargo
	(
	IdCodigoEncargo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.GrupoEncargosCodigoEncargo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoEncargosCodigoEncargo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoEncargosCodigoEncargo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoEncargosCodigoEncargo', 'Object', 'CONTROL') as Contr_Per 