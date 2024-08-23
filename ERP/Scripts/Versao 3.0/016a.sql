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
ALTER TABLE dbo.RecebimentoItem
	DROP CONSTRAINT FK_RecebimentoItem_GrupoSeries
GO
ALTER TABLE dbo.GrupoSeries SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RecebimentoItem
	DROP CONSTRAINT FK_RecebimentoItem_GrupoLotes
GO
ALTER TABLE dbo.GrupoLotes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RecebimentoItem
	DROP CONSTRAINT FK_RecebimentoItem_GrupoAtivo
GO
ALTER TABLE dbo.GrupoAtivo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RecebimentoItem
	DROP CONSTRAINT FK_RecebimentoItem_MetodoDepreciacao
GO
ALTER TABLE dbo.MetodoDepreciacao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RecebimentoItem
	DROP CONSTRAINT FK_RecebimentoItem_Localizacao
GO
ALTER TABLE dbo.Localizacao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RecebimentoItem
	DROP CONSTRAINT FK_RecebimentoItem_Deposito
GO
ALTER TABLE dbo.Deposito SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RecebimentoItem
	DROP CONSTRAINT FK_RecebimentoItem_Armazem
GO
ALTER TABLE dbo.Armazem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RecebimentoItem
	DROP CONSTRAINT FK_RecebimentoItem_VariantesTamanho
GO
ALTER TABLE dbo.VariantesTamanho SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RecebimentoItem
	DROP CONSTRAINT FK_RecebimentoItem_VariantesEstilo
GO
ALTER TABLE dbo.VariantesEstilo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RecebimentoItem
	DROP CONSTRAINT FK_RecebimentoItem_VariantesCor
GO
ALTER TABLE dbo.VariantesCor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RecebimentoItem
	DROP CONSTRAINT FK_RecebimentoItem_Unidade
GO
ALTER TABLE dbo.Unidade SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_RecebimentoItem
	(
	IdRecebimentoItem int NOT NULL IDENTITY (1, 1),
	IdRecebimento int NOT NULL,
	IdPedidoCompra int NULL,
	IdPedidoCompraItem int NULL,
	IdLoteRecebimento int NOT NULL,
	IdProduto int NULL,
	NomeProduto varchar(255) NULL,
	Quantidade decimal(18, 4) NOT NULL,
	QuantidadeRecebida decimal(18, 4) NULL,
	IdUnidade int NULL,
	ValorUnitario decimal(18, 5) NULL,
	ValorTotal decimal(18, 5) NULL,
	Desconto decimal(18, 5) NULL,
	Seguro decimal(18, 5) NULL,
	Frete decimal(18, 5) NULL,
	DespesasAcessorias decimal(18, 5) NULL,
	Royalties decimal(18, 5) NULL,
	ValorLiquido decimal(18, 5) NULL,
	IdVariantesEstilo int NULL,
	IdVariantesCor int NULL,
	IdVariantesTamanho int NULL,
	IdGrupoLotes int NULL,
	IdGrupoSeries int NULL,
	IdArmazem int NULL,
	IdDeposito int NULL,
	IdLocalizacao int NULL,
	IdGrupoAtivo int NULL,
	IdMetodoDepreciacao int NULL,
	IdAtivoFixo int NULL,
	DataVencimento datetime NULL,
	DataLoteFornecedor datetime NULL,
	IdNotaFiscal int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_RecebimentoItem SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_RecebimentoItem ON
GO
IF EXISTS(SELECT * FROM dbo.RecebimentoItem)
	 EXEC('INSERT INTO dbo.Tmp_RecebimentoItem (IdRecebimentoItem, IdRecebimento, IdPedidoCompra, IdLoteRecebimento, IdProduto, NomeProduto, Quantidade, QuantidadeRecebida, IdUnidade, ValorUnitario, ValorTotal, Desconto, Seguro, Frete, DespesasAcessorias, Royalties, ValorLiquido, IdVariantesEstilo, IdVariantesCor, IdVariantesTamanho, IdGrupoLotes, IdGrupoSeries, IdArmazem, IdDeposito, IdLocalizacao, IdGrupoAtivo, IdMetodoDepreciacao, IdAtivoFixo, DataVencimento, DataLoteFornecedor, IdNotaFiscal)
		SELECT IdRecebimentoItem, IdRecebimento, IdPedidoCompra, IdLoteRecebimento, IdProduto, NomeProduto, Quantidade, QuantidadeRecebida, IdUnidade, ValorUnitario, ValorTotal, Desconto, Seguro, Frete, DespesasAcessorias, Royalties, ValorLiquido, IdVariantesEstilo, IdVariantesCor, IdVariantesTamanho, IdGrupoLotes, IdGrupoSeries, IdArmazem, IdDeposito, IdLocalizacao, IdGrupoAtivo, IdMetodoDepreciacao, IdAtivoFixo, DataVencimento, DataLoteFornecedor, IdNotaFiscal FROM dbo.RecebimentoItem WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_RecebimentoItem OFF
GO
ALTER TABLE dbo.RecebimentoItem
	DROP CONSTRAINT FK_RecebimentoItem_RecebimentoItem
GO
DROP TABLE dbo.RecebimentoItem
GO
EXECUTE sp_rename N'dbo.Tmp_RecebimentoItem', N'RecebimentoItem', 'OBJECT' 
GO
ALTER TABLE dbo.RecebimentoItem ADD CONSTRAINT
	PK_RecebimentoItem PRIMARY KEY CLUSTERED 
	(
	IdRecebimentoItem
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.RecebimentoItem ADD CONSTRAINT
	FK_RecebimentoItem_Unidade FOREIGN KEY
	(
	IdUnidade
	) REFERENCES dbo.Unidade
	(
	IdUnidade
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RecebimentoItem ADD CONSTRAINT
	FK_RecebimentoItem_VariantesCor FOREIGN KEY
	(
	IdVariantesCor
	) REFERENCES dbo.VariantesCor
	(
	IdVariantesCor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RecebimentoItem ADD CONSTRAINT
	FK_RecebimentoItem_VariantesEstilo FOREIGN KEY
	(
	IdVariantesEstilo
	) REFERENCES dbo.VariantesEstilo
	(
	IdVariantesEstilo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RecebimentoItem ADD CONSTRAINT
	FK_RecebimentoItem_VariantesTamanho FOREIGN KEY
	(
	IdVariantesTamanho
	) REFERENCES dbo.VariantesTamanho
	(
	IdVariantesTamanho
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RecebimentoItem ADD CONSTRAINT
	FK_RecebimentoItem_Armazem FOREIGN KEY
	(
	IdArmazem
	) REFERENCES dbo.Armazem
	(
	IdArmazem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RecebimentoItem ADD CONSTRAINT
	FK_RecebimentoItem_Deposito FOREIGN KEY
	(
	IdDeposito
	) REFERENCES dbo.Deposito
	(
	IdDeposito
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RecebimentoItem ADD CONSTRAINT
	FK_RecebimentoItem_Localizacao FOREIGN KEY
	(
	IdLocalizacao
	) REFERENCES dbo.Localizacao
	(
	IdLocalizacao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RecebimentoItem ADD CONSTRAINT
	FK_RecebimentoItem_MetodoDepreciacao FOREIGN KEY
	(
	IdMetodoDepreciacao
	) REFERENCES dbo.MetodoDepreciacao
	(
	IdMetodoDepreciacao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RecebimentoItem ADD CONSTRAINT
	FK_RecebimentoItem_GrupoAtivo FOREIGN KEY
	(
	IdGrupoAtivo
	) REFERENCES dbo.GrupoAtivo
	(
	IdGrupoAtivo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RecebimentoItem ADD CONSTRAINT
	FK_RecebimentoItem_RecebimentoItem FOREIGN KEY
	(
	IdRecebimentoItem
	) REFERENCES dbo.RecebimentoItem
	(
	IdRecebimentoItem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RecebimentoItem ADD CONSTRAINT
	FK_RecebimentoItem_GrupoLotes FOREIGN KEY
	(
	IdGrupoLotes
	) REFERENCES dbo.GrupoLotes
	(
	IdGrupoLotes
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RecebimentoItem ADD CONSTRAINT
	FK_RecebimentoItem_GrupoSeries FOREIGN KEY
	(
	IdGrupoSeries
	) REFERENCES dbo.GrupoSeries
	(
	IdGrupoSeries
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
