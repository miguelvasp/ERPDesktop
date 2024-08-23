/*
   segunda-feira, 24 de agosto de 201521:23:12
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
CREATE TABLE dbo.DiarioBomLinha
	(
	IdDiarioBomLinha int NOT NULL IDENTITY (1, 1),
	IdDiarioBom int NULL,
	Data datetime NULL,
	NumeroLinha int NULL,
	NumeroItem int NULL,
	IdOrdemProducao int NULL,
	IdUnidade int NULL,
	IdSequenciaConsumo int NULL,
	QtdeConsumo decimal(18, 4) NULL,
	QtdeConsumoEstoque decimal(18, 4) NULL,
	QtdeDevolucao decimal(18, 4) NULL,
	Fim bit NULL,
	Devolucao bit NULL,
	IdConfiguracao int NULL,
	IdTamanho int NULL,
	IdCor int NULL,
	IdEstilo int NULL,
	IdLote int NULL,
	IdLocalizacao int NULL,
	Serie varchar(255) NULL,
	IdArmazem int NULL,
	IdDeposito int NULL,
	IdDiarioEstoque int NULL,
	QtdeProposta decimal(18, 4) NULL,
	PrecoCusto decimal(18, 4) NULL,
	PrecoVenda decimal(18, 4) NULL,
	ReferenciaEstoque int NULL,
	Sucara decimal(18, 4) NULL,
	ValorCusto decimal(18, 4) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.DiarioBomLinha ADD CONSTRAINT
	PK_DiarioBomLinha PRIMARY KEY CLUSTERED 
	(
	IdDiarioBomLinha
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.DiarioBomLinha SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.DiarioBomLinha', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.DiarioBomLinha', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.DiarioBomLinha', 'Object', 'CONTROL') as Contr_Per 