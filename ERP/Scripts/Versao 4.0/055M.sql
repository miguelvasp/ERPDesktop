/*
   segunda-feira, 11 de janeiro de 201612:18:34
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
CREATE TABLE dbo.MovimentacaoBancaria
	(
	IdMovimentacao int NOT NULL IDENTITY (1, 1),
	IdEmpresa int NULL,
	IdBanco int NULL,
	IdContaBancaria int NULL,
	DataMovimentacao datetime NULL,
	TipoMovimento int NULL,
	NumeroDocumento varchar(255) NULL,
	IdContasPagarBaixa int NULL,
	IdContasReceberBaixa int NULL,
	Historico varchar(255) NULL,
	Valor decimal(18, 4) NULL,
	IdContaContabil int NULL,
	Conciliado bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.MovimentacaoBancaria ADD CONSTRAINT
	PK_MovimentacaoBancaria PRIMARY KEY CLUSTERED 
	(
	IdMovimentacao
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.MovimentacaoBancaria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.MovimentacaoBancaria', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.MovimentacaoBancaria', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.MovimentacaoBancaria', 'Object', 'CONTROL') as Contr_Per 