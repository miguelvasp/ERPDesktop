/*
   sábado, 25 de julho de 201518:05:31
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
ALTER TABLE dbo.CalendarioData SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CalendarioData', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CalendarioData', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CalendarioData', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CalendarioDataLinhas ADD CONSTRAINT
	FK_CalendarioDataLinhas_CalendarioData FOREIGN KEY
	(
	IdCalendarioData
	) REFERENCES dbo.CalendarioData
	(
	IdCalendarioData
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CalendarioDataLinhas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CalendarioDataLinhas', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CalendarioDataLinhas', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CalendarioDataLinhas', 'Object', 'CONTROL') as Contr_Per 