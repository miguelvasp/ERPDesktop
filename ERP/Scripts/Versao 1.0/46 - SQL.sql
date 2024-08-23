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
ALTER TABLE dbo.Usuario SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Empresa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Recebimento
	(
	IdRecebimento int NOT NULL IDENTITY (1, 1),
	IdLoteRecebimento int NOT NULL,
	IdFornecedor int NULL,
	IdEmpresa int NULL,
	IdUsuario int NULL,
	DataFisica date NOT NULL,
	IdPedidoCompra int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Recebimento SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Recebimento ON
GO
IF EXISTS(SELECT * FROM dbo.Recebimento)
	 EXEC('INSERT INTO dbo.Tmp_Recebimento (IdRecebimento, IdLoteRecebimento, IdFornecedor, DataFisica, IdPedidoCompra)
		SELECT IdRecebimento, IdLoteRecebimento, IdFornecedor, DataFisica, IdPedidoCompra FROM dbo.Recebimento WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Recebimento OFF
GO
ALTER TABLE dbo.RecebimentoItem
	DROP CONSTRAINT FK_RecebimentoItem_Recebimento
GO
DROP TABLE dbo.Recebimento
GO
EXECUTE sp_rename N'dbo.Tmp_Recebimento', N'Recebimento', 'OBJECT' 
GO
ALTER TABLE dbo.Recebimento ADD CONSTRAINT
	PK_Recebimento PRIMARY KEY CLUSTERED 
	(
	IdRecebimento
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Recebimento ADD CONSTRAINT
	FK_Recebimento_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Recebimento ADD CONSTRAINT
	FK_Recebimento_Usuario FOREIGN KEY
	(
	IdUsuario
	) REFERENCES dbo.Usuario
	(
	IdUsuario
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RecebimentoItem ADD CONSTRAINT
	FK_RecebimentoItem_Recebimento FOREIGN KEY
	(
	IdRecebimento
	) REFERENCES dbo.Recebimento
	(
	IdRecebimento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RecebimentoItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

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
	DROP CONSTRAINT FK_RecebimentoItem_Recebimento
GO
ALTER TABLE dbo.Recebimento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_RecebimentoItem
	(
	IdRecebimentoItem int NOT NULL IDENTITY (1, 1),
	IdRecebimento int NOT NULL,
	IdPedido int NULL,
	IdLoteRecebimento int NOT NULL,
	IdProduto int NULL,
	NomeProduto varchar(255) NULL,
	Quantidade int NOT NULL,
	QuantidadeRecebida int NOT NULL,
	Unidade int NULL,
	ValorUnitario decimal(18, 5) NULL,
	ValorTotal decimal(18, 5) NULL,
	Desconto decimal(18, 5) NULL,
	Seguro decimal(18, 5) NULL,
	Frete decimal(18, 5) NULL,
	DespesasAcessorias decimal(18, 5) NULL,
	Royalties decimal(18, 5) NULL,
	ValorLiquido decimal(18, 5) NULL,
	IdEstilo int NULL,
	IdCor int NULL,
	IdTamanho int NULL,
	IdLote int NULL,
	IdSeries int NULL,
	IdArmazem int NULL,
	IdDeposito int NULL,
	IdLocalizacao int NULL,
	IdGrupoAtivo int NULL,
	IdMetodoDepreciacao int NULL,
	IdAtivoFixo int NULL,
	DataVencimento datetime NULL,
	DataLoteFornecedor datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_RecebimentoItem SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_RecebimentoItem ON
GO
IF EXISTS(SELECT * FROM dbo.RecebimentoItem)
	 EXEC('INSERT INTO dbo.Tmp_RecebimentoItem (IdRecebimentoItem, IdRecebimento, IdLoteRecebimento, IdProduto, NomeProduto, Quantidade, QuantidadeRecebida, Unidade, ValorUnitario, ValorTotal, Desconto, Seguro, Frete, DespesasAcessorias, Royalties, ValorLiquido, IdEstilo, IdCor, IdTamanho, IdLote, IdSeries, IdArmazem, IdDeposito, IdLocalizacao, IdGrupoAtivo, IdMetodoDepreciacao, IdAtivoFixo, DataVencimento, DataLoteFornecedor)
		SELECT IdRecebimentoItem, IdRecebimento, IdLoteRecebimento, IdProduto, NomeProduto, Quantidade, QuantidadeRecebida, Unidade, ValorUnitario, ValorTotal, Desconto, Seguro, Frete, DespesasAcessorias, Royalties, ValorLiquido, IdEstilo, IdCor, IdTamanho, IdLote, IdSeries, IdArmazem, IdDeposito, IdLocalizacao, IdGrupoAtivo, IdMetodoDepreciacao, IdAtivoFixo, DataVencimento, DataLoteFornecedor FROM dbo.RecebimentoItem WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_RecebimentoItem OFF
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
	FK_RecebimentoItem_Recebimento FOREIGN KEY
	(
	IdRecebimento
	) REFERENCES dbo.Recebimento
	(
	IdRecebimento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT

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
EXECUTE sp_rename N'dbo.RecebimentoItem.IdPedido', N'Tmp_IdPedidoCompra', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.RecebimentoItem.Tmp_IdPedidoCompra', N'IdPedidoCompra', 'COLUMN' 
GO
ALTER TABLE dbo.RecebimentoItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
