/*
   segunda-feira, 25 de abril de 201609:42:56
   User: 
   Server: MIKE-PC
   Database: Metso_ProcessamentoFiscal
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
ALTER TABLE dbo.ProcFiscal ADD
	Responsavel varchar(255) NULL,
	DataChegada datetime NULL
GO
ALTER TABLE dbo.ProcFiscal SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ProcFiscal', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ProcFiscal', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ProcFiscal', 'Object', 'CONTROL') as Contr_Per 