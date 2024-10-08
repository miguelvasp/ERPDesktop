/*
   terça-feira, 20 de janeiro de 201518:06:24
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
CREATE TABLE dbo.RamoAtividade
	(
	IdRamoAtividade int NOT NULL IDENTITY (1, 1),
	Nome varchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.RamoAtividade ADD CONSTRAINT
	PK_RamoAtividade PRIMARY KEY CLUSTERED 
	(
	IdRamoAtividade
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.RamoAtividade SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.RamoAtividade', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.RamoAtividade', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.RamoAtividade', 'Object', 'CONTROL') as Contr_Per 