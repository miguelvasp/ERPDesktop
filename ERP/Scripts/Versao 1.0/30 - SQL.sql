/*
   segunda-feira, 22 de junho de 201511:44:56
   User: 
   Server: MIKE-PC
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
CREATE TABLE dbo.AprovacaoUsuario
	(
	IdAprovacaoUsuario int NOT NULL IDENTITY (1, 1),
	IdAprovacaoNivel int NULL,
	IdUsuario int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.AprovacaoUsuario ADD CONSTRAINT
	PK_AprovacaoUsuario PRIMARY KEY CLUSTERED 
	(
	IdAprovacaoUsuario
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.AprovacaoUsuario SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.AprovacaoUsuario', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.AprovacaoUsuario', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.AprovacaoUsuario', 'Object', 'CONTROL') as Contr_Per 