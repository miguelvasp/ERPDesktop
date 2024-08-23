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
ALTER TABLE dbo.VariantesConfig SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_Produto
GO
ALTER TABLE dbo.Produto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_Unidade
GO
ALTER TABLE dbo.Unidade SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_VariantesTamanho
GO
ALTER TABLE dbo.VariantesTamanho SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_VariantesEstilo
GO
ALTER TABLE dbo.VariantesEstilo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_VariantesCor
GO
ALTER TABLE dbo.VariantesCor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_CFOP
GO
ALTER TABLE dbo.CFOP SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_PedidoVenda
GO
ALTER TABLE dbo.PedidoVenda SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_GrupoDescontos
GO
ALTER TABLE dbo.GrupoDescontos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_GrupoEncargos
GO
ALTER TABLE dbo.GrupoEncargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_GrupoAtivo
GO
ALTER TABLE dbo.GrupoAtivo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_Armazem
GO
ALTER TABLE dbo.Armazem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_Deposito
GO
ALTER TABLE dbo.Deposito SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_GrupoSeries
GO
ALTER TABLE dbo.GrupoSeries SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_GrupoLotes
GO
ALTER TABLE dbo.GrupoLotes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_GrupoImpostoRetido
GO
ALTER TABLE dbo.GrupoImpostoRetido SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_GrupoImposto
GO
ALTER TABLE dbo.GrupoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_CodigoServico
GO
ALTER TABLE dbo.CodigoServico SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_MetodoDepreciacao
GO
ALTER TABLE dbo.MetodoDepreciacao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_Localizacao
GO
ALTER TABLE dbo.Localizacao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_PedidoVendaItem
	(
	IdPedidoVendaItem int NOT NULL IDENTITY (1, 1),
	IdPedidoVenda int NOT NULL,
	IdProduto int NOT NULL,
	Quantidade decimal(18, 4) NOT NULL,
	QuantidadeEntregue decimal(18, 4) NULL,
	IdUnidade int NOT NULL,
	Ipi decimal(18, 4) NOT NULL,
	PrecoTabela decimal(18, 4) NOT NULL,
	PrecoUnitario decimal(18, 4) NOT NULL,
	DescontoVarejista decimal(18, 4) NOT NULL,
	DescontoPercentual decimal(18, 4) NULL,
	DescontoValor decimal(18, 4) NULL,
	DescontoSuframa decimal(18, 4) NULL,
	ValorLiquido decimal(18, 4) NULL,
	ValorEncargos decimal(18, 4) NULL,
	TipoOrdem int NULL,
	IdCFOP int NULL,
	IdCodigoServico int NULL,
	IdTipoDocumentoFiscal int NULL,
	IdVariantesConfig int NULL,
	IdVariantesEstilo int NULL,
	IdVariantesCor int NULL,
	IdVariantesTamanho int NULL,
	IdGrupoLotes int NULL,
	IdGrupoSeries int NULL,
	IdArmazem int NULL,
	IdDeposito int NULL,
	IdLocalizacao int NULL,
	IdCodigoExternoCliente int NULL,
	IdOrdemDevolvida int NULL,
	StatusLinha int NULL,
	OrigemTributacao varchar(1) NULL,
	AtivoFixo bit NULL,
	IdGrupoAtivo int NULL,
	IdAtivoFixo int NULL,
	IdGrupoImposto int NULL,
	IdMetodoDepreciacao int NULL,
	TipoTransacaoAtivo int NULL,
	IdGrupoImpostosItem int NULL,
	IdGrupoImpostoRetido int NULL,
	IdGrupoImpostoItemRetido int NULL,
	IdNCM int NULL,
	IdGrupoEncargos int NULL,
	IdGrupoDescontos int NULL,
	PesoUnitario decimal(18, 4) NULL,
	IdCentroCusto1 int NULL,
	IdCentroCusto2 int NULL,
	IdCentroCusto3 int NULL,
	IdCentroCusto4 int NULL,
	IdCentroCusto5 int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_PedidoVendaItem SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_PedidoVendaItem ON
GO
IF EXISTS(SELECT * FROM dbo.PedidoVendaItem)
	 EXEC('INSERT INTO dbo.Tmp_PedidoVendaItem (IdPedidoVendaItem, IdPedidoVenda, IdProduto, Quantidade, QuantidadeEntregue, IdUnidade, Ipi, PrecoTabela, PrecoUnitario, DescontoVarejista, DescontoPercentual, DescontoValor, DescontoSuframa, ValorLiquido, ValorEncargos, TipoOrdem, IdCFOP, IdCodigoServico, IdTipoDocumentoFiscal, IdVariantesEstilo, IdVariantesCor, IdVariantesTamanho, IdGrupoLotes, IdGrupoSeries, IdArmazem, IdDeposito, IdLocalizacao, IdCodigoExternoCliente, IdOrdemDevolvida, StatusLinha, OrigemTributacao, AtivoFixo, IdGrupoAtivo, IdAtivoFixo, IdGrupoImposto, IdMetodoDepreciacao, TipoTransacaoAtivo, IdGrupoImpostosItem, IdGrupoImpostoRetido, IdGrupoImpostoItemRetido, IdNCM, IdGrupoEncargos, IdGrupoDescontos, PesoUnitario, IdCentroCusto1, IdCentroCusto2, IdCentroCusto3, IdCentroCusto4, IdCentroCusto5)
		SELECT IdPedidoVendaItem, IdPedidoVenda, IdProduto, Quantidade, QuantidadeEntregue, IdUnidade, Ipi, PrecoTabela, PrecoUnitario, DescontoVarejista, DescontoPercentual, DescontoValor, DescontoSuframa, ValorLiquido, ValorEncargos, TipoOrdem, IdCFOP, IdCodigoServico, IdTipoDocumentoFiscal, IdVariantesEstilo, IdVariantesCor, IdVariantesTamanho, IdGrupoLotes, IdGrupoSeries, IdArmazem, IdDeposito, IdLocalizacao, IdCodigoExternoCliente, IdOrdemDevolvida, StatusLinha, OrigemTributacao, AtivoFixo, IdGrupoAtivo, IdAtivoFixo, IdGrupoImposto, IdMetodoDepreciacao, TipoTransacaoAtivo, IdGrupoImpostosItem, IdGrupoImpostoRetido, IdGrupoImpostoItemRetido, IdNCM, IdGrupoEncargos, IdGrupoDescontos, PesoUnitario, IdCentroCusto1, IdCentroCusto2, IdCentroCusto3, IdCentroCusto4, IdCentroCusto5 FROM dbo.PedidoVendaItem WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_PedidoVendaItem OFF
GO
ALTER TABLE dbo.PedidoVendaItemCentroCusto
	DROP CONSTRAINT FK_PedidoVendaItemCentroCusto_PedidoVendaItem
GO
DROP TABLE dbo.PedidoVendaItem
GO
EXECUTE sp_rename N'dbo.Tmp_PedidoVendaItem', N'PedidoVendaItem', 'OBJECT' 
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	PK_PedidoVendaItem PRIMARY KEY CLUSTERED 
	(
	IdPedidoVendaItem
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_Localizacao FOREIGN KEY
	(
	IdLocalizacao
	) REFERENCES dbo.Localizacao
	(
	IdLocalizacao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_MetodoDepreciacao FOREIGN KEY
	(
	IdMetodoDepreciacao
	) REFERENCES dbo.MetodoDepreciacao
	(
	IdMetodoDepreciacao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_CodigoServico FOREIGN KEY
	(
	IdCodigoServico
	) REFERENCES dbo.CodigoServico
	(
	IdCodigoServico
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_GrupoImposto FOREIGN KEY
	(
	IdGrupoImposto
	) REFERENCES dbo.GrupoImposto
	(
	IdGrupoImposto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_GrupoImpostoRetido FOREIGN KEY
	(
	IdGrupoImpostoRetido
	) REFERENCES dbo.GrupoImpostoRetido
	(
	IdGrupoImpostoRetido
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_GrupoLotes FOREIGN KEY
	(
	IdGrupoLotes
	) REFERENCES dbo.GrupoLotes
	(
	IdGrupoLotes
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_GrupoSeries FOREIGN KEY
	(
	IdGrupoSeries
	) REFERENCES dbo.GrupoSeries
	(
	IdGrupoSeries
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_Deposito FOREIGN KEY
	(
	IdDeposito
	) REFERENCES dbo.Deposito
	(
	IdDeposito
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_Armazem FOREIGN KEY
	(
	IdArmazem
	) REFERENCES dbo.Armazem
	(
	IdArmazem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_GrupoAtivo FOREIGN KEY
	(
	IdGrupoAtivo
	) REFERENCES dbo.GrupoAtivo
	(
	IdGrupoAtivo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_GrupoEncargos FOREIGN KEY
	(
	IdGrupoEncargos
	) REFERENCES dbo.GrupoEncargos
	(
	IdGrupoEncargos
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_GrupoDescontos FOREIGN KEY
	(
	IdGrupoDescontos
	) REFERENCES dbo.GrupoDescontos
	(
	IdGrupoDescontos
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_PedidoVenda FOREIGN KEY
	(
	IdPedidoVenda
	) REFERENCES dbo.PedidoVenda
	(
	IdPedidoVenda
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_CFOP FOREIGN KEY
	(
	IdCFOP
	) REFERENCES dbo.CFOP
	(
	IdCFOP
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_VariantesCor FOREIGN KEY
	(
	IdVariantesCor
	) REFERENCES dbo.VariantesCor
	(
	IdVariantesCor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_VariantesEstilo FOREIGN KEY
	(
	IdVariantesEstilo
	) REFERENCES dbo.VariantesEstilo
	(
	IdVariantesEstilo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_VariantesTamanho FOREIGN KEY
	(
	IdVariantesTamanho
	) REFERENCES dbo.VariantesTamanho
	(
	IdVariantesTamanho
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_Unidade FOREIGN KEY
	(
	IdUnidade
	) REFERENCES dbo.Unidade
	(
	IdUnidade
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_VariantesConfig FOREIGN KEY
	(
	IdVariantesConfig
	) REFERENCES dbo.VariantesConfig
	(
	IdVariantesConfig
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItemCentroCusto ADD CONSTRAINT
	FK_PedidoVendaItemCentroCusto_PedidoVendaItem FOREIGN KEY
	(
	IdPedidoVendaItem
	) REFERENCES dbo.PedidoVendaItem
	(
	IdPedidoVendaItem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemCentroCusto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
