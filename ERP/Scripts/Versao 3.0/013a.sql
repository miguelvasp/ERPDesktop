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
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_CentroCusto
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_CentroCusto1
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_CentroCusto2
GO
ALTER TABLE dbo.CentroCusto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_Royalties
GO
ALTER TABLE dbo.Royalties SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_GrupoDescontos
GO
ALTER TABLE dbo.GrupoDescontos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_GrupoEncargos
GO
ALTER TABLE dbo.GrupoEncargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_GrupoImpostoItem
GO
ALTER TABLE dbo.GrupoImpostoItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_GrupoImposto
GO
ALTER TABLE dbo.GrupoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_Localizacao
GO
ALTER TABLE dbo.Localizacao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_Deposito
GO
ALTER TABLE dbo.Deposito SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_Armazem
GO
ALTER TABLE dbo.Armazem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_GrupoSeries
GO
ALTER TABLE dbo.GrupoSeries SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_GrupoLotes
GO
ALTER TABLE dbo.GrupoLotes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_ClassificacaoFiscal
GO
ALTER TABLE dbo.ClassificacaoFiscal SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_CFOP
GO
ALTER TABLE dbo.CFOP SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_GrupoImpostoRetido
GO
ALTER TABLE dbo.GrupoImpostoRetido SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_VariantesTamanho
GO
ALTER TABLE dbo.VariantesTamanho SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_VariantesEstilo
GO
ALTER TABLE dbo.VariantesEstilo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_VariantesCor
GO
ALTER TABLE dbo.VariantesCor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_PedidoCompra
GO
ALTER TABLE dbo.PedidoCompra SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_Produto
GO
ALTER TABLE dbo.Produto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_GrupoAtivo
GO
ALTER TABLE dbo.GrupoAtivo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_PedidoCompraItem
	(
	IdPedidoCompraItem int NOT NULL IDENTITY (1, 1),
	IdPedidoCompra int NOT NULL,
	IdProduto int NOT NULL,
	Quantidade decimal(18, 4) NOT NULL,
	QuantidadeRecebida decimal(18, 4) NULL,
	Ipi decimal(18, 4) NOT NULL,
	PrecoUnitario decimal(18, 4) NOT NULL,
	Status varchar(1) NULL,
	IdCFOP int NULL,
	IdVariantesConfig int NULL,
	IdVariantesEstilo int NULL,
	IdVariantesCor int NULL,
	IdVariantesTamanho int NULL,
	IdGrupoLotes int NULL,
	IdGrupoSeries int NULL,
	IdArmazem int NULL,
	IdDeposito int NULL,
	IdLocalizacao int NULL,
	AtivoFixo bit NULL,
	IdGrupodeAtivo int NULL,
	IdAtivoFixo int NULL,
	IdGrupoImposto int NULL,
	IdGrupoImpostosItem int NULL,
	IdNCM int NULL,
	IdGrupoEncargos int NULL,
	IdGrupoDescontos int NULL,
	IdGrupoFrete int NULL,
	IdRoyalties int NULL,
	IdCentroCusto1 int NULL,
	IdCentroCusto2 int NULL,
	IdCentroCusto3 int NULL,
	IdCentroCusto4 int NULL,
	IdCentroCusto5 int NULL,
	QuantidadeAReceber decimal(18, 4) NULL,
	IdUnidade int NULL,
	PrecoTabela decimal(18, 4) NULL,
	DescontoPercentual decimal(18, 4) NULL,
	DescontoValor decimal(18, 4) NULL,
	ValorEncargos decimal(18, 4) NULL,
	ValorLiquido decimal(18, 4) NULL,
	IdCodigoServico int NULL,
	IdTipoDocumentoFiscal int NULL,
	MovimentaEstoque bit NULL,
	TipoOrdem int NULL,
	IdCodigoExternoFornecedor int NULL,
	IdMetodoPreciacao int NULL,
	CreditoICMSAtivo bit NULL,
	CreditoPisCofins bit NULL,
	ParcelaICMS int NULL,
	TipoTransacaoAtivo int NULL,
	IdGrupoImpostoRetido int NULL,
	IdGrupoImpostoItemRetido int NULL,
	PesoUnitario decimal(18, 4) NULL,
	IdOrdemPlanejada int NULL,
	IdPlanoMestre int NULL,
	IdOrdemDevolvida int NULL,
	StatusLinha int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_PedidoCompraItem SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_PedidoCompraItem ON
GO
IF EXISTS(SELECT * FROM dbo.PedidoCompraItem)
	 EXEC('INSERT INTO dbo.Tmp_PedidoCompraItem (IdPedidoCompraItem, IdPedidoCompra, IdProduto, Quantidade, QuantidadeRecebida, Ipi, PrecoUnitario, Status, IdCFOP, IdVariantesEstilo, IdVariantesCor, IdVariantesTamanho, IdGrupoLotes, IdGrupoSeries, IdArmazem, IdDeposito, IdLocalizacao, AtivoFixo, IdGrupodeAtivo, IdAtivoFixo, IdGrupoImposto, IdGrupoImpostosItem, IdNCM, IdGrupoEncargos, IdGrupoDescontos, IdGrupoFrete, IdRoyalties, IdCentroCusto1, IdCentroCusto2, IdCentroCusto3, IdCentroCusto4, IdCentroCusto5, QuantidadeAReceber, IdUnidade, PrecoTabela, DescontoPercentual, DescontoValor, ValorEncargos, ValorLiquido, IdCodigoServico, IdTipoDocumentoFiscal, MovimentaEstoque, TipoOrdem, IdCodigoExternoFornecedor, IdMetodoPreciacao, CreditoICMSAtivo, CreditoPisCofins, ParcelaICMS, TipoTransacaoAtivo, IdGrupoImpostoRetido, IdGrupoImpostoItemRetido, PesoUnitario, IdOrdemPlanejada, IdPlanoMestre, IdOrdemDevolvida, StatusLinha)
		SELECT IdPedidoCompraItem, IdPedidoCompra, IdProduto, Quantidade, QuantidadeRecebida, Ipi, PrecoUnitario, Status, IdCFOP, IdVariantesEstilo, IdVariantesCor, IdVariantesTamanho, IdGrupoLotes, IdGrupoSeries, IdArmazem, IdDeposito, IdLocalizacao, AtivoFixo, IdGrupodeAtivo, IdAtivoFixo, IdGrupoImposto, IdGrupoImpostosItem, IdNCM, IdGrupoEncargos, IdGrupoDescontos, IdGrupoFrete, IdRoyalties, IdCentroCusto1, IdCentroCusto2, IdCentroCusto3, IdCentroCusto4, IdCentroCusto5, QuantidadeAReceber, IdUnidade, PrecoTabela, DescontoPercentual, DescontoValor, ValorEncargos, ValorLiquido, IdCodigoServico, IdTipoDocumentoFiscal, MovimentaEstoque, TipoOrdem, IdCodigoExternoFornecedor, IdMetodoPreciacao, CreditoICMSAtivo, CreditoPisCofins, ParcelaICMS, TipoTransacaoAtivo, IdGrupoImpostoRetido, IdGrupoImpostoItemRetido, PesoUnitario, IdOrdemPlanejada, IdPlanoMestre, IdOrdemDevolvida, StatusLinha FROM dbo.PedidoCompraItem WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_PedidoCompraItem OFF
GO
ALTER TABLE dbo.PedidoCompraItemCentroCusto
	DROP CONSTRAINT FK_PedidoCompraItemCentroCusto_PedidoCompraItem
GO
DROP TABLE dbo.PedidoCompraItem
GO
EXECUTE sp_rename N'dbo.Tmp_PedidoCompraItem', N'PedidoCompraItem', 'OBJECT' 
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	PK_PedidoCompraItem PRIMARY KEY CLUSTERED 
	(
	IdPedidoCompraItem
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_GrupoAtivo FOREIGN KEY
	(
	IdGrupodeAtivo
	) REFERENCES dbo.GrupoAtivo
	(
	IdGrupoAtivo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_PedidoCompra FOREIGN KEY
	(
	IdPedidoCompra
	) REFERENCES dbo.PedidoCompra
	(
	IdPedidoCompra
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_VariantesCor FOREIGN KEY
	(
	IdVariantesCor
	) REFERENCES dbo.VariantesCor
	(
	IdVariantesCor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_VariantesEstilo FOREIGN KEY
	(
	IdVariantesEstilo
	) REFERENCES dbo.VariantesEstilo
	(
	IdVariantesEstilo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_VariantesTamanho FOREIGN KEY
	(
	IdVariantesTamanho
	) REFERENCES dbo.VariantesTamanho
	(
	IdVariantesTamanho
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_GrupoImpostoRetido FOREIGN KEY
	(
	IdGrupoImpostoRetido
	) REFERENCES dbo.GrupoImpostoRetido
	(
	IdGrupoImpostoRetido
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_CFOP FOREIGN KEY
	(
	IdCFOP
	) REFERENCES dbo.CFOP
	(
	IdCFOP
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_ClassificacaoFiscal FOREIGN KEY
	(
	IdNCM
	) REFERENCES dbo.ClassificacaoFiscal
	(
	IdNCM
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_GrupoLotes FOREIGN KEY
	(
	IdGrupoLotes
	) REFERENCES dbo.GrupoLotes
	(
	IdGrupoLotes
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_GrupoSeries FOREIGN KEY
	(
	IdGrupoSeries
	) REFERENCES dbo.GrupoSeries
	(
	IdGrupoSeries
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_Armazem FOREIGN KEY
	(
	IdArmazem
	) REFERENCES dbo.Armazem
	(
	IdArmazem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_Deposito FOREIGN KEY
	(
	IdDeposito
	) REFERENCES dbo.Deposito
	(
	IdDeposito
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_Localizacao FOREIGN KEY
	(
	IdLocalizacao
	) REFERENCES dbo.Localizacao
	(
	IdLocalizacao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_GrupoImposto FOREIGN KEY
	(
	IdGrupoImposto
	) REFERENCES dbo.GrupoImposto
	(
	IdGrupoImposto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_GrupoImpostoItem FOREIGN KEY
	(
	IdGrupoImpostosItem
	) REFERENCES dbo.GrupoImpostoItem
	(
	IdGrupoImpostoItem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_GrupoEncargos FOREIGN KEY
	(
	IdGrupoEncargos
	) REFERENCES dbo.GrupoEncargos
	(
	IdGrupoEncargos
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_GrupoDescontos FOREIGN KEY
	(
	IdGrupoDescontos
	) REFERENCES dbo.GrupoDescontos
	(
	IdGrupoDescontos
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_Royalties FOREIGN KEY
	(
	IdRoyalties
	) REFERENCES dbo.Royalties
	(
	IdRoyalties
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_CentroCusto FOREIGN KEY
	(
	IdCentroCusto1
	) REFERENCES dbo.CentroCusto
	(
	IdCentroCusto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_CentroCusto1 FOREIGN KEY
	(
	IdCentroCusto2
	) REFERENCES dbo.CentroCusto
	(
	IdCentroCusto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_CentroCusto2 FOREIGN KEY
	(
	IdCentroCusto3
	) REFERENCES dbo.CentroCusto
	(
	IdCentroCusto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_VariantesConfig FOREIGN KEY
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
ALTER TABLE dbo.PedidoCompraItemCentroCusto ADD CONSTRAINT
	FK_PedidoCompraItemCentroCusto_PedidoCompraItem FOREIGN KEY
	(
	IdPedidoCompraItem
	) REFERENCES dbo.PedidoCompraItem
	(
	IdPedidoCompraItem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItemCentroCusto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
