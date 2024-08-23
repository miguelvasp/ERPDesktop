/*
   segunda-feira, 26 de janeiro de 201516:24:04
   User: SA
   Server: MIKE-PC
   Database: ERP2
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
ALTER TABLE dbo.CodigoFaturamento ADD
	Texto1 varchar(250) NULL,
	Texto2 varchar(250) NULL
GO
ALTER TABLE dbo.CodigoFaturamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoFaturamento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoFaturamento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoFaturamento', 'Object', 'CONTROL') as Contr_Per 