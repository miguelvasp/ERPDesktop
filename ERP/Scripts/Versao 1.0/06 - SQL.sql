/*
   terça-feira, 9 de junho de 201518:43:22
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
CREATE TABLE dbo.GrupoArmazenamento
	(
	IdGrupoArmazenamento int NOT NULL IDENTITY (1, 1),
	Nome varchar(255) NULL,
	Descricao varchar(255) NULL,
	Obrigatorio bit NULL,
	SiteAtivo bit NULL,
	SiteSaida bit NULL,
	SiteEntrada bit NULL,
	DepositoAtivo bit NULL,
	DepositoSaida bit NULL,
	DepositoEntrada bit NULL,
	LocalizacaoAtivo bit NULL,
	LocalizacaoSaida bit NULL,
	LocalizacaoEntrada bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.GrupoArmazenamento ADD CONSTRAINT
	PK_GrupoArmazenamento PRIMARY KEY CLUSTERED 
	(
	IdGrupoArmazenamento
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.GrupoArmazenamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoArmazenamento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoArmazenamento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoArmazenamento', 'Object', 'CONTROL') as Contr_Per 