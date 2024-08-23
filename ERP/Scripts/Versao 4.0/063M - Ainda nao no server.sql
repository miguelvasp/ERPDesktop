/*
   segunda-feira, 25 de janeiro de 201616:10:52
   User: 
   Server: MIKE-PC
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
CREATE TABLE dbo.PedidoVendaItemApuracaoImposto
	(
	IdPedidoVendaItemApuracaoImposto int NOT NULL IDENTITY (1, 1),
	IdPedidoItem int NULL,
	DataLancamento datetime NULL,
	DataDocumento datetime NULL,
	IdNotaFiscal int NULL,
	NotaFiscalNumero varchar(255) NULL,
	DataVencimentoImposto datetime NULL,
	DataRegistroIVA datetime NULL,
	IdCodigoImposto int NULL,
	IdCodigoTributacao int NULL,
	IdCodigoTributacaoAjustado int NULL,
	ValorFiscal decimal(18, 4) NULL,
	ValorFiscalAjustado decimal(18, 4) NULL,
	Aliquota decimal(18, 2) NULL,
	Quantidade decimal(18, 4) NULL,
	IdMoeda int NULL,
	PercentualDaDiferencaICMS decimal(18, 4) NULL,
	PercentualDeReducaoImposto decimal(18, 4) NULL,
	EncargoImposto decimal(18, 4) NULL,
	BaseValor decimal(18, 4) NULL,
	BaseValorAjustado decimal(18, 4) NULL,
	OutroValorBase decimal(18, 4) NULL,
	OutroValorImposto decimal(18, 4) NULL,
	ValorBaseIsencao decimal(18, 4) NULL,
	ValorIsencaoImposto decimal(18, 4) NULL,
	ValorImposto decimal(18, 4) NULL,
	ValorAjustado decimal(18, 4) NULL,
	IdCodigoIsencao int NULL,
	IdJurisdicaoImposto int NULL,
	DirecaoImposto int NULL,
	Automatico bit NULL,
	IdContaContabil int NULL,
	ImpostoRetido bit NULL,
	ImpostoImportacaoDireta bit NULL,
	EntidadeLancamentoImpostoIntercompanhia int NULL,
	IdGrupoImposto int NULL,
	IdGrupoImpostoItem int NULL,
	GST_HST int NULL,
	Isencao bit NULL,
	LancarImpostoAReceberLongoPrazo bit NULL,
	MetodoSubstituicaoTributaria int NULL,
	DiferencialICMS bit NULL,
	IdMoedaComprovante int NULL,
	Origem int NULL,
	FiscalOrigem int NULL,
	IdPeriodoLiquidacaoImposto int NULL,
	TipoImposto int NULL,
	UsuarioFinal bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto ADD CONSTRAINT
	PK_PedidoVendaItemApuracaoImposto PRIMARY KEY CLUSTERED 
	(
	IdPedidoVendaItemApuracaoImposto
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoVendaItemApuracaoImposto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItemApuracaoImposto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItemApuracaoImposto', 'Object', 'CONTROL') as Contr_Per 