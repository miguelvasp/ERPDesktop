/*
   sábado, 5 de março de 201611:09:35
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
CREATE TABLE dbo.ConfiguracaoCheque
	(
	IdConfiguracaoCheque int NOT NULL IDENTITY (1, 1),
	Descricao varchar(255) NULL,
	Ordem varchar(50) NULL,
	HabilitadoContabilizacaoPrincipal bit NULL,
	TextoTransacao varchar(255) NULL,
	TipoContaDebito int NULL,
	IdContaContabilDebito int NULL,
	IdContaContabilCredito int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.ConfiguracaoCheque ADD CONSTRAINT
	PK_ConfiguracaoCheque PRIMARY KEY CLUSTERED 
	(
	IdConfiguracaoCheque
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ConfiguracaoCheque SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ConfiguracaoCheque', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ConfiguracaoCheque', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ConfiguracaoCheque', 'Object', 'CONTROL') as Contr_Per 