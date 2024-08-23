/*
   sábado, 25 de julho de 201518:03:54
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
ALTER TABLE dbo.CalendarioDataLinhas
	DROP CONSTRAINT FK_CalandarioDataLinhas_Calendario
GO
ALTER TABLE dbo.Calendario SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Calendario', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Calendario', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Calendario', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CalendarioDataLinhas
	DROP COLUMN IdCalendario
GO
ALTER TABLE dbo.CalendarioDataLinhas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CalendarioDataLinhas', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CalendarioDataLinhas', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CalendarioDataLinhas', 'Object', 'CONTROL') as Contr_Per 