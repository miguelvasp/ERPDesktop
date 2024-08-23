/*
   segunda-feira, 25 de janeiro de 201614:05:12
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
CREATE TABLE dbo.GrupoEncargosCodigoEncargo
	(
	IdGrupoEncargosCodigoEncargo int NOT NULL IDENTITY (1, 1),
	IdGrupoEncargos int NULL,
	IdCodigoEncargo int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.GrupoEncargosCodigoEncargo ADD CONSTRAINT
	PK_GrupoEncargosCodigoEncargo PRIMARY KEY CLUSTERED 
	(
	IdGrupoEncargosCodigoEncargo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.GrupoEncargosCodigoEncargo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoEncargosCodigoEncargo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoEncargosCodigoEncargo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoEncargosCodigoEncargo', 'Object', 'CONTROL') as Contr_Per 