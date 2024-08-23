/*
   sexta-feira, 26 de junho de 201518:06:53
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
CREATE TABLE dbo.GrupoImpostoRetidoItem
	(
	IdGrupoImpostoRetidoItem int NOT NULL IDENTITY (1, 1),
	Descricao varchar(255) NULL,
	Codigo varchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.GrupoImpostoRetidoItem ADD CONSTRAINT
	PK_GrupoImpostoRetidoItem PRIMARY KEY CLUSTERED 
	(
	IdGrupoImpostoRetidoItem
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.GrupoImpostoRetidoItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoImpostoRetidoItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoImpostoRetidoItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoImpostoRetidoItem', 'Object', 'CONTROL') as Contr_Per 