/*
   sábado, 26 de setembro de 201520:15:16
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
CREATE TABLE dbo.ContasPagar
	(
	IdContasPagar int NOT NULL IDENTITY (1, 1),
	IdPedidoCompra int NULL,
	Documento varchar(255) NULL,
	IdContaContabil int NULL,
	IdDiario int NULL,
	ValorTitulo decimal(18, 4) NULL,
	Desconto decimal(18, 4) NULL,
	ValorLiquido decimal(18, 4) NULL,
	Vencimento datetime NULL,
	VencimentoOriginal datetime NULL,
	Emissao datetime NULL,
	Saldo decimal(18, 4) NULL,
	Correcao bit NULL,
	DataDocumento datetime NULL,
	IdFornecedor int NULL,
	Observacao varchar(MAX) NULL,
	Acrecimo decimal(18, 4) NULL,
	ValorPago decimal(18, 4) NULL,
	Cancelamento bit NULL,
	Cancelado bit NULL,
	IdMoeda int NULL,
	UltimoPagamento datetime NULL,
	CalculaRetencao bit NULL,
	IdMetodoPagamento int NULL,
	IdEspecificacaoPagamento int NULL,
	IdPerfilFornecedor int NULL,
	Status int NULL,
	TipoTransacao int NULL,
	NFSE varchar(255) NULL,
	ValorTotalServico decimal(18, 4) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.ContasPagar ADD CONSTRAINT
	PK_ContasPagar PRIMARY KEY CLUSTERED 
	(
	IdContasPagar
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ContasPagar SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasPagar', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasPagar', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasPagar', 'Object', 'CONTROL') as Contr_Per 