/*
   sábado, 25 de julho de 201520:12:04
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
ALTER TABLE dbo.Recursos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Recursos', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Recursos', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Recursos', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CapacidadeRecursosLinhas ADD CONSTRAINT
	FK_CapacidadeRecursosLinhas_Recursos FOREIGN KEY
	(
	IdRecurso
	) REFERENCES dbo.Recursos
	(
	IdRecurso
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CapacidadeRecursosLinhas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CapacidadeRecursosLinhas', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CapacidadeRecursosLinhas', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CapacidadeRecursosLinhas', 'Object', 'CONTROL') as Contr_Per 