/*
   segunda-feira, 5 de outubro de 201520:20:02
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
CREATE TABLE dbo.NotaFiscalItem
	(
	IdNotaFiscalItem int NOT NULL IDENTITY (1, 1),
	IdNotaFiscal int NULL,
	Item int NULL,
	IdProduto int NULL,
	Codigo varchar(255) NULL,
	Descricao varchar(255) NULL,
	Quantidade decimal(18, 4) NULL,
	ValorUnitario decimal(18, 4) NULL,
	Desconto decimal(18, 4) NULL,
	Seguro decimal(18, 4) NULL,
	Frete decimal(18, 4) NULL,
	DespesasAcessorias decimal(18, 4) NULL,
	CodigoCliente varchar(255) NULL,
	CodigoFornecedor varchar(255) NULL,
	SituacaoTribIPI varchar(50) NULL,
	AliquotaIPI decimal(18, 2) NULL,
	ValorIPI decimal(18, 4) NULL,
	EnquadramentoIPI int NULL,
	SituacaoTribICMS varchar(50) NULL,
	BaseICMS decimal(18, 4) NULL,
	AliquotaICMS decimal(18, 2) NULL,
	ValorICMS decimal(18, 4) NULL,
	ValorTotal decimal(18, 4) NULL,
	PesoLiquido decimal(18, 4) NULL,
	PesoBruto decimal(18, 4) NULL,
	Volumes decimal(18, 4) NULL,
	IdUnidade int NULL,
	IdNCM int NULL,
	Observacao varchar(MAX) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.NotaFiscalItem ADD CONSTRAINT
	PK_NotaFiscalItem PRIMARY KEY CLUSTERED 
	(
	IdNotaFiscalItem
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.NotaFiscalItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.NotaFiscalItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.NotaFiscalItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.NotaFiscalItem', 'Object', 'CONTROL') as Contr_Per 