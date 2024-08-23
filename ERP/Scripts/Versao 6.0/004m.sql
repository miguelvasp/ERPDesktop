/*
   quinta-feira, 23 de junho de 201619:36:04
   User: 
   Server: MIKE-PC
   Database: ACRILPLUS
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
ALTER TABLE dbo.ModuloPrograma
	DROP CONSTRAINT FK_ModuloPrograma_Programa
GO
ALTER TABLE dbo.Programa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Programa', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Programa', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Programa', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ModuloPrograma
	DROP CONSTRAINT FK_ModuloPrograma_Modulo
GO
ALTER TABLE dbo.Modulo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Modulo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Modulo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Modulo', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_ModuloPrograma
	(
	IdModuloPrograma int NOT NULL IDENTITY (1, 1),
	IdModulo int NOT NULL,
	IdPrograma int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_ModuloPrograma SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_ModuloPrograma ON
GO
IF EXISTS(SELECT * FROM dbo.ModuloPrograma)
	 EXEC('INSERT INTO dbo.Tmp_ModuloPrograma (IdModuloPrograma, IdModulo, IdPrograma)
		SELECT IdModuloPrograma, IdModulo, IdPrograma FROM dbo.ModuloPrograma WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_ModuloPrograma OFF
GO
DROP TABLE dbo.ModuloPrograma
GO
EXECUTE sp_rename N'dbo.Tmp_ModuloPrograma', N'ModuloPrograma', 'OBJECT' 
GO
ALTER TABLE dbo.ModuloPrograma ADD CONSTRAINT
	PK_ModuloPrograma PRIMARY KEY CLUSTERED 
	(
	IdModuloPrograma
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ModuloPrograma ADD CONSTRAINT
	FK_ModuloPrograma_Modulo FOREIGN KEY
	(
	IdModulo
	) REFERENCES dbo.Modulo
	(
	IdModulo
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.ModuloPrograma ADD CONSTRAINT
	FK_ModuloPrograma_Programa FOREIGN KEY
	(
	IdPrograma
	) REFERENCES dbo.Programa
	(
	IdPrograma
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ModuloPrograma', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ModuloPrograma', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ModuloPrograma', 'Object', 'CONTROL') as Contr_Per 