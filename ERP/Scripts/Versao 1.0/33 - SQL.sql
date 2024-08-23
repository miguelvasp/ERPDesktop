/*
   quarta-feira, 24 de junho de 201510:41:38
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
CREATE TABLE dbo.ConfGrupoImpostoRetido
	(
	IdConfGrupoImpostoRetido int NOT NULL IDENTITY (1, 1),
	IdGrupoImpostoRetido int NULL,
	IdCodigoImpostoRetido int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.ConfGrupoImpostoRetido ADD CONSTRAINT
	PK_ConfGrupoImpostoRetido PRIMARY KEY CLUSTERED 
	(
	IdConfGrupoImpostoRetido
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ConfGrupoImpostoRetido SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ConfGrupoImpostoRetido', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ConfGrupoImpostoRetido', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ConfGrupoImpostoRetido', 'Object', 'CONTROL') as Contr_Per 