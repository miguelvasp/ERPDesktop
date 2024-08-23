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
ALTER TABLE dbo.Inventario
	DROP CONSTRAINT FK_Inventario_Unidade
GO
ALTER TABLE dbo.Unidade SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Inventario
	DROP CONSTRAINT FK_Inventario_Produto
GO
ALTER TABLE dbo.Produto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Inventario
	DROP CONSTRAINT FK_Inventario_VariantesTamanho
GO
ALTER TABLE dbo.VariantesTamanho SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Inventario
	DROP CONSTRAINT FK_Inventario_VariantesEstilo
GO
ALTER TABLE dbo.VariantesEstilo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Inventario
	DROP CONSTRAINT FK_Inventario_VariantesCor
GO
ALTER TABLE dbo.VariantesCor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Inventario
	DROP CONSTRAINT FK_Inventario_VariantesConfig
GO
ALTER TABLE dbo.VariantesConfig SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Inventario
	DROP CONSTRAINT FK_Inventario_TipoDocumento
GO
ALTER TABLE dbo.TipoDocumento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Inventario
	DROP CONSTRAINT FK_Inventario_Empresa
GO
ALTER TABLE dbo.Empresa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Inventario
	(
	IdInventario int NOT NULL IDENTITY (1, 1),
	IdEmpresa int NOT NULL,
	IdProduto int NOT NULL,
	IdDeposito int NULL,
	IdArmazem int NULL,
	IdLocalizacao int NULL,
	IdVariantesCor int NULL,
	IdVariantesTamanho int NULL,
	IdVariantesEstilo int NULL,
	IdVariantesConfig int NULL,
	IdUnidade int NULL,
	IdDocumento int NOT NULL,
	IdTipoDocumento int NOT NULL,
	TipoMovimentoFinanceiro char(1) NOT NULL,
	Quantidade decimal(18, 4) NULL,
	DataEntrada datetime NULL,
	IdLote int NOT NULL,
	IdLoteFornecedor int NULL,
	DataValidade datetime NULL,
	DataSaida datetime NULL,
	QuantidadeRetirada decimal(18, 4) NULL,
	CustoReposicao decimal(18, 4) NULL,
	CustoMedio decimal(18, 4) NULL,
	Saldo decimal(18, 4) NULL,
	EstoqueAnterior decimal(18, 4) NULL,
	ValorUnitario decimal(18, 4) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Inventario SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Inventario ON
GO
IF EXISTS(SELECT * FROM dbo.Inventario)
	 EXEC('INSERT INTO dbo.Tmp_Inventario (IdInventario, IdEmpresa, IdProduto, IdDeposito, IdArmazem, IdLocalizacao, IdVariantesCor, IdVariantesTamanho, IdVariantesEstilo, IdVariantesConfig, IdUnidade, IdDocumento, IdTipoDocumento, TipoMovimentoFinanceiro, Quantidade, DataEntrada, IdLote, IdLoteFornecedor, DataValidade, DataSaida, QuantidadeRetirada, CustoReposicao, CustoMedio, Saldo, ValorUnitario)
		SELECT IdInventario, IdEmpresa, IdProduto, IdDeposito, IdArmazem, IdLocalizacao, IdVariantesCor, IdVariantesTamanho, IdVariantesEstilo, IdVariantesConfig, IdUnidade, IdDocumento, IdTipoDocumento, TipoMovimentoFinanceiro, Quantidade, DataEntrada, IdLote, IdLoteFornecedor, DataValidade, DataSaida, QuantidadeRetirada, CustoReposicao, CustoMedio, Saldo, ValorUnitario FROM dbo.Inventario WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Inventario OFF
GO
DROP TABLE dbo.Inventario
GO
EXECUTE sp_rename N'dbo.Tmp_Inventario', N'Inventario', 'OBJECT' 
GO
ALTER TABLE dbo.Inventario ADD CONSTRAINT
	PK_Inventario PRIMARY KEY CLUSTERED 
	(
	IdInventario
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Inventario ADD CONSTRAINT
	FK_Inventario_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Inventario ADD CONSTRAINT
	FK_Inventario_TipoDocumento FOREIGN KEY
	(
	IdTipoDocumento
	) REFERENCES dbo.TipoDocumento
	(
	IdDocumento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Inventario ADD CONSTRAINT
	FK_Inventario_VariantesConfig FOREIGN KEY
	(
	IdVariantesConfig
	) REFERENCES dbo.VariantesConfig
	(
	IdVariantesConfig
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Inventario ADD CONSTRAINT
	FK_Inventario_VariantesCor FOREIGN KEY
	(
	IdVariantesCor
	) REFERENCES dbo.VariantesCor
	(
	IdVariantesCor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Inventario ADD CONSTRAINT
	FK_Inventario_VariantesEstilo FOREIGN KEY
	(
	IdVariantesEstilo
	) REFERENCES dbo.VariantesEstilo
	(
	IdVariantesEstilo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Inventario ADD CONSTRAINT
	FK_Inventario_VariantesTamanho FOREIGN KEY
	(
	IdVariantesTamanho
	) REFERENCES dbo.VariantesTamanho
	(
	IdVariantesTamanho
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
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
ALTER TABLE dbo.Inventario ADD CONSTRAINT
	FK_Inventario_Unidade FOREIGN KEY
	(
	IdUnidade
	) REFERENCES dbo.Unidade
	(
	IdUnidade
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
