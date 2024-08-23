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
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_TipoProduto
GO
ALTER TABLE dbo.TipoProduto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_PlanoMestre
GO
ALTER TABLE dbo.PlanoMestre SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoLancamento
GO
ALTER TABLE dbo.GrupoLancamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoCusto
GO
ALTER TABLE dbo.GrupoCusto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoProducao
GO
ALTER TABLE dbo.GrupoProducao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_Embalagem
GO
ALTER TABLE dbo.Embalagem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoSeries
GO
ALTER TABLE dbo.GrupoSeries SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_VariantesTamanho
GO
ALTER TABLE dbo.VariantesTamanho SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoLotes
GO
ALTER TABLE dbo.GrupoLotes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_Pais
GO
ALTER TABLE dbo.Pais SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_VariantesEstilo
GO
ALTER TABLE dbo.VariantesEstilo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_VariantesCor
GO
ALTER TABLE dbo.VariantesCor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoRastreamento
GO
ALTER TABLE dbo.GrupoRastreamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoEstoque
GO
ALTER TABLE dbo.GrupoEstoque SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoArmazenamento
GO
ALTER TABLE dbo.GrupoArmazenamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_Empresa
GO
ALTER TABLE dbo.Empresa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoProduto
GO
ALTER TABLE dbo.GrupoProduto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoAlocacaoFrete
GO
ALTER TABLE dbo.GrupoAlocacaoFrete SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_VariantesGrupo
GO
ALTER TABLE dbo.VariantesGrupo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_VariantesConfig
GO
ALTER TABLE dbo.VariantesConfig SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoItensSuplementares
GO
ALTER TABLE dbo.GrupoItensSuplementares SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_CodigoServico
GO
ALTER TABLE dbo.CodigoServico SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_Unidade3
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_Unidade
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_Unidade1
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_Unidade2
GO
ALTER TABLE dbo.Unidade SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoEncargos1
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_GrupoEncargos
GO
ALTER TABLE dbo.GrupoEncargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Produto
	(
	IdProduto int NOT NULL IDENTITY (1, 1),
	IdEmpresa int NULL,
	Codigo varchar(255) NULL,
	Descricao varchar(255) NULL,
	NomeProduto varchar(255) NULL,
	IdGrupoProduto int NULL,
	IdTipoProduto int NULL,
	IdVariantesGrupo int NULL,
	IdVariantesConfig int NULL,
	IdVariantesTamanho int NULL,
	IdVariantesCor int NULL,
	IdVariantesEstilo int NULL,
	ComprasIdUnidade int NULL,
	ComprasEntregaExcedente decimal(18, 5) NULL,
	ComprasEntregaInsuficiente decimal(18, 5) NULL,
	ComprasIdGrupoImposto int NULL,
	ComprasRetencaoFonte bit NULL,
	ComprasIdGrupoImpostoRetiro int NULL,
	ComprasIdGrupoEncargos int NULL,
	ComprasEncargosSobrePreco decimal(18, 5) NULL,
	ComprasIncluiNoPrecoUnitario bit NULL,
	ComprasIdGrupoDesconto int NULL,
	ComprasIdGrupoPreco int NULL,
	ComprasIdGrupoItensSuplementares int NULL,
	CompraProdDescontinuado bit NULL,
	VendaIdUnidade int NULL,
	VendaEntregaExcedente decimal(18, 5) NULL,
	VendaEntregaInsuficiente decimal(18, 5) NULL,
	VendaIdGrupoImposto int NULL,
	VendaRetencaoFonte bit NULL,
	VendaGrupoImpostoRetido int NULL,
	VendaIdGrupoEncargos int NULL,
	VendaEncargosSobrePreco decimal(18, 5) NULL,
	VendaIncluirNoPrecoUnitario bit NULL,
	VendaIdGrupoDesconto int NULL,
	VendaIdGrupoPreco int NULL,
	VendaMarkup int NULL,
	VendaIndiceContribuicao decimal(18, 5) NULL,
	VendaPercentualEncargos decimal(18, 5) NULL,
	VendaUsarProdutoAlternativo int NULL,
	VendaIdProdutoAlternativo int NULL,
	VendaPreco decimal(18, 5) NULL,
	VendaPrecoUnidade decimal(18, 5) NULL,
	VendaPrecoQuantidade decimal(18, 5) NULL,
	VendaPrecoIdGrupoDesconto int NULL,
	VendaPrecoIdGrupoAlocacaoFrete int NULL,
	VendaAtualizaPrecoBase int NULL,
	VendaProdDescontinuado bit NULL,
	ComExtCodMercadoria varchar(50) NULL,
	ComExtPercentualEncargos decimal(18, 5) NULL,
	ComExtIdPais int NULL,
	ComExtCidade varchar(255) NULL,
	EstoqueIdUnidade int NULL,
	EstoquePeso decimal(18, 5) NULL,
	EstoqueTara decimal(18, 5) NULL,
	EstqouePesoBruto decimal(18, 5) NULL,
	EstoqueProfundidade decimal(18, 5) NULL,
	EstoqueLargura decimal(18, 5) NULL,
	EstoqueAltura decimal(18, 5) NULL,
	EstoqueVolume decimal(18, 5) NULL,
	EstoqueIdGrupoLotes int NULL,
	EstoqueIdGrupoSeries int NULL,
	EstoqueIdEmbalagem int NULL,
	EstoqueQtdeEmbalagem decimal(18, 5) NULL,
	EstoqueTempoManuseio int NULL,
	EstoqueTempoPrateleira int NULL,
	EstoqueValidadeDias int NULL,
	ProducaoIdUnidade int NULL,
	ProducaoProfundidade decimal(18, 5) NULL,
	ProducaoLargura decimal(18, 5) NULL,
	ProducaoAltura decimal(18, 5) NULL,
	ProducaoDensidade decimal(18, 5) NULL,
	ProducaoSucataConstante decimal(18, 5) NULL,
	ProducaoSucataVariavel decimal(18, 5) NULL,
	ProducaoIdPerfil int NULL,
	ProducaoIdGrupoProducao int NULL,
	ProducaoLiberacao int NULL,
	ProducaoTipoProducao int NULL,
	ProducaoItemPlanejamento int NULL,
	ProducaoIdPlanoMestre int NULL,
	CustoIdGrupoLancamento int NULL,
	CustoIdGrupoCusto int NULL,
	CustoCustoVariante decimal(18, 5) NULL,
	CustoAtualizarUltimoCusto bit NULL,
	CustoABCAliquota int NULL,
	CustoABCMargem int NULL,
	CustoABCReceita int NULL,
	CustoABCManutencao int NULL,
	FiscalOrigem int NULL,
	FiscalIdNCM int NULL,
	FiscalNCMExcecao int NULL,
	FicalIdTipoItem int NULL,
	FiscalIdCodigoServico int NULL,
	FiscalICMSServico bit NULL,
	FiscalPercentualAprox decimal(18, 5) NULL,
	EstoqueProdDescontinuado bit NULL,
	ProducaoProdDescontinuado bit NULL,
	IdGrupoEstoque int NULL,
	IdGrupoRastreamento int NULL,
	IdGrupoArmazenamento int NULL,
	ProdutoAcabadoMateriaPrima int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Produto SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Produto ON
GO
IF EXISTS(SELECT * FROM dbo.Produto)
	 EXEC('INSERT INTO dbo.Tmp_Produto (IdProduto, IdEmpresa, Codigo, Descricao, NomeProduto, IdGrupoProduto, IdTipoProduto, IdVariantesGrupo, IdVariantesConfig, IdVariantesTamanho, IdVariantesCor, IdVariantesEstilo, ComprasIdUnidade, ComprasEntregaExcedente, ComprasEntregaInsuficiente, ComprasIdGrupoImposto, ComprasRetencaoFonte, ComprasIdGrupoImpostoRetiro, ComprasIdGrupoEncargos, ComprasEncargosSobrePreco, ComprasIncluiNoPrecoUnitario, ComprasIdGrupoDesconto, ComprasIdGrupoItensSuplementares, CompraProdDescontinuado, VendaIdUnidade, VendaEntregaExcedente, VendaEntregaInsuficiente, VendaIdGrupoImposto, VendaRetencaoFonte, VendaGrupoImpostoRetido, VendaIdGrupoEncargos, VendaEncargosSobrePreco, VendaIncluirNoPrecoUnitario, VendaIdGrupoDesconto, VendaMarkup, VendaIndiceContribuicao, VendaPercentualEncargos, VendaUsarProdutoAlternativo, VendaIdProdutoAlternativo, VendaPreco, VendaPrecoUnidade, VendaPrecoQuantidade, VendaPrecoIdGrupoDesconto, VendaPrecoIdGrupoAlocacaoFrete, VendaAtualizaPrecoBase, VendaProdDescontinuado, ComExtCodMercadoria, ComExtPercentualEncargos, ComExtIdPais, ComExtCidade, EstoqueIdUnidade, EstoquePeso, EstoqueTara, EstqouePesoBruto, EstoqueProfundidade, EstoqueLargura, EstoqueAltura, EstoqueVolume, EstoqueIdGrupoLotes, EstoqueIdGrupoSeries, EstoqueIdEmbalagem, EstoqueQtdeEmbalagem, EstoqueTempoManuseio, EstoqueTempoPrateleira, EstoqueValidadeDias, ProducaoIdUnidade, ProducaoProfundidade, ProducaoLargura, ProducaoAltura, ProducaoDensidade, ProducaoSucataConstante, ProducaoSucataVariavel, ProducaoIdPerfil, ProducaoIdGrupoProducao, ProducaoLiberacao, ProducaoTipoProducao, ProducaoItemPlanejamento, ProducaoIdPlanoMestre, CustoIdGrupoLancamento, CustoIdGrupoCusto, CustoCustoVariante, CustoAtualizarUltimoCusto, CustoABCAliquota, CustoABCMargem, CustoABCReceita, CustoABCManutencao, FiscalOrigem, FiscalIdNCM, FiscalNCMExcecao, FicalIdTipoItem, FiscalIdCodigoServico, FiscalICMSServico, FiscalPercentualAprox, EstoqueProdDescontinuado, ProducaoProdDescontinuado, IdGrupoEstoque, IdGrupoRastreamento, IdGrupoArmazenamento, ProdutoAcabadoMateriaPrima)
		SELECT IdProduto, IdEmpresa, Codigo, Descricao, NomeProduto, IdGrupoProduto, IdTipoProduto, IdVariantesGrupo, IdVariantesConfig, IdVariantesTamanho, IdVariantesCor, IdVariantesEstilo, ComprasIdUnidade, ComprasEntregaExcedente, ComprasEntregaInsuficiente, ComprasIdGrupoImposto, ComprasRetencaoFonte, ComprasIdGrupoImpostoRetiro, ComprasIdGrupoEncargos, ComprasEncargosSobrePreco, ComprasIncluiNoPrecoUnitario, ComprasIdGrupoDesconto, ComprasIdGrupoItensSuplementares, CompraProdDescontinuado, VendaIdUnidade, VendaEntregaExcedente, VendaEntregaInsuficiente, VendaIdGrupoImposto, VendaRetencaoFonte, VendaGrupoImpostoRetido, VendaIdGrupoEncargos, VendaEncargosSobrePreco, VendaIncluirNoPrecoUnitario, VendaIdGrupoDesconto, VendaMarkup, VendaIndiceContribuicao, VendaPercentualEncargos, VendaUsarProdutoAlternativo, VendaIdProdutoAlternativo, VendaPreco, VendaPrecoUnidade, VendaPrecoQuantidade, VendaPrecoIdGrupoDesconto, VendaPrecoIdGrupoAlocacaoFrete, VendaAtualizaPrecoBase, VendaProdDescontinuado, ComExtCodMercadoria, ComExtPercentualEncargos, ComExtIdPais, ComExtCidade, EstoqueIdUnidade, EstoquePeso, EstoqueTara, EstqouePesoBruto, EstoqueProfundidade, EstoqueLargura, EstoqueAltura, EstoqueVolume, EstoqueIdGrupoLotes, EstoqueIdGrupoSeries, EstoqueIdEmbalagem, EstoqueQtdeEmbalagem, EstoqueTempoManuseio, EstoqueTempoPrateleira, EstoqueValidadeDias, ProducaoIdUnidade, ProducaoProfundidade, ProducaoLargura, ProducaoAltura, ProducaoDensidade, ProducaoSucataConstante, ProducaoSucataVariavel, ProducaoIdPerfil, ProducaoIdGrupoProducao, ProducaoLiberacao, ProducaoTipoProducao, ProducaoItemPlanejamento, ProducaoIdPlanoMestre, CustoIdGrupoLancamento, CustoIdGrupoCusto, CustoCustoVariante, CustoAtualizarUltimoCusto, CustoABCAliquota, CustoABCMargem, CustoABCReceita, CustoABCManutencao, FiscalOrigem, FiscalIdNCM, FiscalNCMExcecao, FicalIdTipoItem, FiscalIdCodigoServico, FiscalICMSServico, FiscalPercentualAprox, EstoqueProdDescontinuado, ProducaoProdDescontinuado, IdGrupoEstoque, IdGrupoRastreamento, IdGrupoArmazenamento, ProdutoAcabadoMateriaPrima FROM dbo.Produto WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Produto OFF
GO
ALTER TABLE dbo.ListaMateriaisLinhas
	DROP CONSTRAINT FK_ListadeMateriaisLinhas_Produto
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_Produto
GO
ALTER TABLE dbo.CodigoProdutoExterno
	DROP CONSTRAINT FK_CodigoProdutoExterno_Produto
GO
ALTER TABLE dbo.CalculoComissao
	DROP CONSTRAINT FK_CalculoComissao_Produto
GO
ALTER TABLE dbo.MatrizImpostos
	DROP CONSTRAINT FK_MatrizImpostos_Produto
GO
ALTER TABLE dbo.AjusteEstoque
	DROP CONSTRAINT FK_AjusteEstoque_Produto
GO
ALTER TABLE dbo.EncargosAutomaticos
	DROP CONSTRAINT FK_EncargosAutomaticos_Produto
GO
ALTER TABLE dbo.ConversaoUnidade
	DROP CONSTRAINT FK_ConversaoUnidade_Produto
GO
ALTER TABLE dbo.Lancamento
	DROP CONSTRAINT FK_Lancamento_Produto
GO
ALTER TABLE dbo.RoteiroOperacaoLinhas
	DROP CONSTRAINT FK_RoteiroOperacaoLinhas_Produto
GO
ALTER TABLE dbo.OrdemProducao
	DROP CONSTRAINT FK_OrdemProducao_Produto
GO
ALTER TABLE dbo.Inventario
	DROP CONSTRAINT FK_Inventario_Produto
GO
ALTER TABLE dbo.ListaMateriaisItem
	DROP CONSTRAINT FK_ListadeMateriaisItem_Produto
GO
ALTER TABLE dbo.NotaFiscalItem
	DROP CONSTRAINT FK_NotaFiscalItem_Produto
GO
ALTER TABLE dbo.ContratoComercial
	DROP CONSTRAINT FK_ContratoComercial_Produto
GO
ALTER TABLE dbo.PedidoVendaItem
	DROP CONSTRAINT FK_PedidoVendaItem_Produto
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_Produto
GO
DROP TABLE dbo.Produto
GO
EXECUTE sp_rename N'dbo.Tmp_Produto', N'Produto', 'OBJECT' 
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	PK_Produto PRIMARY KEY CLUSTERED 
	(
	IdProduto
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE UNIQUE NONCLUSTERED INDEX IX_Produto ON dbo.Produto
	(
	Codigo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_GrupoEncargos1 FOREIGN KEY
	(
	VendaIdGrupoEncargos
	) REFERENCES dbo.GrupoEncargos
	(
	IdGrupoEncargos
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_Unidade3 FOREIGN KEY
	(
	VendaIdUnidade
	) REFERENCES dbo.Unidade
	(
	IdUnidade
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_CodigoServico FOREIGN KEY
	(
	FiscalIdCodigoServico
	) REFERENCES dbo.CodigoServico
	(
	IdCodigoServico
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_GrupoItensSuplementares FOREIGN KEY
	(
	ComprasIdGrupoItensSuplementares
	) REFERENCES dbo.GrupoItensSuplementares
	(
	IdGrupoItensSuplementares
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_VariantesConfig FOREIGN KEY
	(
	IdVariantesConfig
	) REFERENCES dbo.VariantesConfig
	(
	IdVariantesConfig
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_VariantesGrupo FOREIGN KEY
	(
	IdVariantesGrupo
	) REFERENCES dbo.VariantesGrupo
	(
	IdVariantesGrupo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_Produto FOREIGN KEY
	(
	VendaIdProdutoAlternativo
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_GrupoAlocacaoFrete FOREIGN KEY
	(
	VendaPrecoIdGrupoAlocacaoFrete
	) REFERENCES dbo.GrupoAlocacaoFrete
	(
	IdGrupoAlocacaoFrete
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_GrupoProduto FOREIGN KEY
	(
	IdGrupoProduto
	) REFERENCES dbo.GrupoProduto
	(
	IdGrupoProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_GrupoArmazenamento FOREIGN KEY
	(
	IdGrupoArmazenamento
	) REFERENCES dbo.GrupoArmazenamento
	(
	IdGrupoArmazenamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_GrupoEstoque FOREIGN KEY
	(
	IdGrupoEstoque
	) REFERENCES dbo.GrupoEstoque
	(
	IdGrupoEstoque
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_GrupoRastreamento FOREIGN KEY
	(
	IdGrupoRastreamento
	) REFERENCES dbo.GrupoRastreamento
	(
	IdGrupoRastreamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_VariantesCor FOREIGN KEY
	(
	IdVariantesCor
	) REFERENCES dbo.VariantesCor
	(
	IdVariantesCor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_VariantesEstilo FOREIGN KEY
	(
	IdVariantesEstilo
	) REFERENCES dbo.VariantesEstilo
	(
	IdVariantesEstilo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_Pais FOREIGN KEY
	(
	ComExtIdPais
	) REFERENCES dbo.Pais
	(
	IdPais
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_GrupoLotes FOREIGN KEY
	(
	EstoqueIdGrupoLotes
	) REFERENCES dbo.GrupoLotes
	(
	IdGrupoLotes
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_VariantesTamanho FOREIGN KEY
	(
	IdVariantesTamanho
	) REFERENCES dbo.VariantesTamanho
	(
	IdVariantesTamanho
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_GrupoSeries FOREIGN KEY
	(
	EstoqueIdGrupoSeries
	) REFERENCES dbo.GrupoSeries
	(
	IdGrupoSeries
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_Embalagem FOREIGN KEY
	(
	EstoqueIdEmbalagem
	) REFERENCES dbo.Embalagem
	(
	IdEmbalagem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_GrupoProducao FOREIGN KEY
	(
	ProducaoIdGrupoProducao
	) REFERENCES dbo.GrupoProducao
	(
	IdGrupoProducao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_GrupoCusto FOREIGN KEY
	(
	CustoIdGrupoCusto
	) REFERENCES dbo.GrupoCusto
	(
	IdGrupoCusto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_GrupoLancamento FOREIGN KEY
	(
	CustoIdGrupoLancamento
	) REFERENCES dbo.GrupoLancamento
	(
	IdGrupoLancamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_PlanoMestre FOREIGN KEY
	(
	ProducaoIdPlanoMestre
	) REFERENCES dbo.PlanoMestre
	(
	IdPlanoMestre
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_TipoProduto FOREIGN KEY
	(
	IdTipoProduto
	) REFERENCES dbo.TipoProduto
	(
	IdTipoProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_Unidade FOREIGN KEY
	(
	ComprasIdUnidade
	) REFERENCES dbo.Unidade
	(
	IdUnidade
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_Unidade1 FOREIGN KEY
	(
	EstoqueIdUnidade
	) REFERENCES dbo.Unidade
	(
	IdUnidade
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_Unidade2 FOREIGN KEY
	(
	ProducaoIdUnidade
	) REFERENCES dbo.Unidade
	(
	IdUnidade
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_GrupoEncargos FOREIGN KEY
	(
	ComprasIdGrupoEncargos
	) REFERENCES dbo.GrupoEncargos
	(
	IdGrupoEncargos
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
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
ALTER TABLE dbo.PedidoCompraItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
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
ALTER TABLE dbo.PedidoVendaItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContratoComercial ADD CONSTRAINT
	FK_ContratoComercial_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContratoComercial SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.NotaFiscalItem ADD CONSTRAINT
	FK_NotaFiscalItem_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.NotaFiscalItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisItem ADD CONSTRAINT
	FK_ListadeMateriaisItem_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ListaMateriaisItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Inventario ADD CONSTRAINT
	FK_Inventario_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Inventario SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.OrdemProducao ADD CONSTRAINT
	FK_OrdemProducao_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RoteiroOperacaoLinhas ADD CONSTRAINT
	FK_RoteiroOperacaoLinhas_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RoteiroOperacaoLinhas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Lancamento ADD CONSTRAINT
	FK_Lancamento_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Lancamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ConversaoUnidade ADD CONSTRAINT
	FK_ConversaoUnidade_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ConversaoUnidade SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.EncargosAutomaticos ADD CONSTRAINT
	FK_EncargosAutomaticos_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.EncargosAutomaticos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.AjusteEstoque ADD CONSTRAINT
	FK_AjusteEstoque_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.AjusteEstoque SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MatrizImpostos ADD CONSTRAINT
	FK_MatrizImpostos_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MatrizImpostos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CalculoComissao ADD CONSTRAINT
	FK_CalculoComissao_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CalculoComissao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CodigoProdutoExterno ADD CONSTRAINT
	FK_CodigoProdutoExterno_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CodigoProdutoExterno SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisLinhas ADD CONSTRAINT
	FK_ListadeMateriaisLinhas_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ListaMateriaisLinhas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
