/*
   terça-feira, 12 de abril de 201621:23:31
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
ALTER TABLE dbo.Configuracao ADD
	PrazoEntrega int NULL,
	IdModoEntrega int NULL,
	IdGrupoArmazenamento int NULL,
	IdGrupoRastreabilidade int NULL,
	IdGrupoEstoque int NULL
GO
ALTER TABLE dbo.Configuracao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Configuracao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Configuracao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Configuracao', 'Object', 'CONTROL') as Contr_Per 