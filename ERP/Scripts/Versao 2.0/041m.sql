/*
   domingo, 27 de setembro de 201520:56:52
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
CREATE TABLE dbo.ContasPagarAberto
	(
	IdContasPagarAberto int NOT NULL IDENTITY (1, 1),
	IdContasPagar int NULL,
	Documento varchar(255) NULL,
	IdFornecedor int NULL,
	IdCodigoMulta int NULL,
	IdCodigoJuros int NULL,
	IdFornecedorContaBancaria int NULL,
	Correcao bit NULL,
	Vencimento datetime NULL,
	VencimentoOriginal datetime NULL,
	NumeroParcela int NULL,
	NumeroParcelaOriginal int NULL,
	Liquidada bit NULL,
	NumeroRemessa varchar(255) NULL,
	NumeroDocumentoBancario varchar(255) NULL,
	ValorTitulo decimal(18, 4) NULL,
	Desconto decimal(18, 4) NULL,
	ValorJuros decimal(18, 4) NULL,
	ValorMulta decimal(18, 4) NULL,
	ValorDescontoVista decimal(18, 4) NULL,
	ValorLiquido decimal(18, 4) NULL,
	Retencao bit NULL,
	Historico varchar(MAX) NULL,
	IdPerfilFornecedor int NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.ContasPagarAberto ADD CONSTRAINT
	PK_ContasPagarAberto PRIMARY KEY CLUSTERED 
	(
	IdContasPagarAberto
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ContasPagarAberto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasPagarAberto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasPagarAberto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasPagarAberto', 'Object', 'CONTROL') as Contr_Per 