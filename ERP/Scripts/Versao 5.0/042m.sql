/*
   segunda-feira, 16 de maio de 201619:47:11
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
CREATE TABLE dbo.Contabilidade
	(
	IdContabilidade int NOT NULL IDENTITY (1, 1),
	IdTipoLancamento int NULL,
	IdContaContabil int NULL,
	IdTransacao int NULL,
	IdLote int NULL,
	ValorCredito decimal(18, 4) NULL,
	ValorDebito decimal(18, 4) NULL,
	DataHora datetime NULL,
	Usuario varchar(200) NULL,
	IdCentroCusto int NULL,
	IdMoeda int NULL,
	ValorAjusteDebito decimal(18, 4) NULL,
	ValorAjusteCredito decimal(18, 4) NULL,
	Preco decimal(18, 4) NULL,
	IdRegraDistribuicao int NULL,
	IdFornecedor int NULL,
	IdCliente int NULL,
	IdEmpresa int NULL,
	Aprovado bit NULL,
	Data datetime NULL,
	Aprovador varchar(255) NULL,
	NumeroCheque int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Contabilidade ADD CONSTRAINT
	PK_Contabilidade PRIMARY KEY CLUSTERED 
	(
	IdContabilidade
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Contabilidade SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Contabilidade', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Contabilidade', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Contabilidade', 'Object', 'CONTROL') as Contr_Per 