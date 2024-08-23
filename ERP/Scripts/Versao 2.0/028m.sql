/*
   segunda-feira, 24 de agosto de 201520:47:43
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
CREATE TABLE dbo.CadastroDiarioProducao
	(
	IdCadastroDiarioProducao int NOT NULL IDENTITY (1, 1),
	NomeDiario varchar(255) NULL,
	IdSequenciaDiario int NULL,
	IdSequenciaComprovante int NULL,
	TipoDiario int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.CadastroDiarioProducao ADD CONSTRAINT
	PK_CadastroDiarioProducao PRIMARY KEY CLUSTERED 
	(
	IdCadastroDiarioProducao
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.CadastroDiarioProducao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CadastroDiarioProducao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CadastroDiarioProducao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CadastroDiarioProducao', 'Object', 'CONTROL') as Contr_Per 