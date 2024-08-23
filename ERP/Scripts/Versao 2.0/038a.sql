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
ALTER TABLE dbo.CodigoContratoComercial SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContratoComercial
	DROP CONSTRAINT FK_ContratoComercial_GrupoDescontoVarejista
GO
ALTER TABLE dbo.GrupoDescontoVarejista SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContratoComercial
	DROP CONSTRAINT FK_ContratoComercial_GrupoPrecoDesconto
GO
ALTER TABLE dbo.GrupoPrecoDesconto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContratoComercial
	DROP CONSTRAINT FK_ContratoComercial_Unidade
GO
ALTER TABLE dbo.Unidade SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContratoComercial
	DROP CONSTRAINT FK_ContratoComercial_Fornecedor
GO
ALTER TABLE dbo.Fornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContratoComercial
	DROP CONSTRAINT FK_ContratoComercial_Cliente
GO
ALTER TABLE dbo.Cliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContratoComercial
	DROP CONSTRAINT FK_ContratoComercial_VariantesTamanho
GO
ALTER TABLE dbo.VariantesTamanho SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContratoComercial
	DROP CONSTRAINT FK_ContratoComercial_VariantesEstilo
GO
ALTER TABLE dbo.VariantesEstilo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContratoComercial
	DROP CONSTRAINT FK_ContratoComercial_VariantesCor
GO
ALTER TABLE dbo.VariantesCor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContratoComercial
	DROP CONSTRAINT FK_ContratoComercial_Produto
GO
ALTER TABLE dbo.Produto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContratoComercial
	DROP CONSTRAINT FK_ContratoComercial_Empresa
GO
ALTER TABLE dbo.Empresa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_ContratoComercial
	(
	IdContratoComercial int NOT NULL IDENTITY (1, 1),
	IdCodigoContratoComercial int NULL,
	Ativo bit NOT NULL,
	Relacao int NULL,
	CodigoTipo int NULL,
	IdCliente int NULL,
	IdGrupoDescontoVarejista int NULL,
	IdFornecedor int NULL,
	IdGrupoPrecoDesconto int NULL,
	RelacaoItem int NULL,
	IdProduto int NULL,
	IdGrupoProduto int NULL,
	IdEstilo int NULL,
	IdTamanho int NULL,
	IdCor int NULL,
	De int NULL,
	Ate int NULL,
	IdUnidade int NULL,
	Valor decimal(18, 4) NULL,
	ValorPercentual decimal(18, 4) NULL,
	IdUnidadePreco int NULL,
	DeData datetime NULL,
	AteData datetime NULL,
	IdGrupoPrecoDescontoProduto int NULL,
	IdEmpresa int NULL,
	ContratoNumero int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_ContratoComercial SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_ContratoComercial ON
GO
IF EXISTS(SELECT * FROM dbo.ContratoComercial)
	 EXEC('INSERT INTO dbo.Tmp_ContratoComercial (IdContratoComercial, Ativo, Relacao, CodigoTipo, IdCliente, IdGrupoDescontoVarejista, IdFornecedor, IdGrupoPrecoDesconto, RelacaoItem, IdProduto, IdGrupoProduto, IdEstilo, IdTamanho, IdCor, De, Ate, IdUnidade, Valor, ValorPercentual, IdUnidadePreco, DeData, AteData, IdGrupoPrecoDescontoProduto, IdEmpresa, ContratoNumero)
		SELECT IdContratoComercial, Ativo, Relacao, CodigoTipo, IdCliente, IdGrupoDescontoVarejista, IdFornecedor, IdGrupoPrecoDesconto, RelacaoItem, IdProduto, IdGrupoProduto, IdEstilo, IdTamanho, IdCor, De, Ate, IdUnidade, Valor, ValorPercentual, IdUnidadePreco, DeData, AteData, IdGrupoPrecoDescontoProduto, IdEmpresa, ContratoNumero FROM dbo.ContratoComercial WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_ContratoComercial OFF
GO
ALTER TABLE dbo.ContratoComercial
	DROP CONSTRAINT FK_ContratoComercial_ContratoComercial
GO
ALTER TABLE dbo.PedidoVenda
	DROP CONSTRAINT FK_PedidoVenda_ContratoComercial
GO
DROP TABLE dbo.ContratoComercial
GO
EXECUTE sp_rename N'dbo.Tmp_ContratoComercial', N'ContratoComercial', 'OBJECT' 
GO
ALTER TABLE dbo.ContratoComercial ADD CONSTRAINT
	PK_ContratoComercial PRIMARY KEY CLUSTERED 
	(
	IdContratoComercial
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ContratoComercial ADD CONSTRAINT
	FK_ContratoComercial_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
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
ALTER TABLE dbo.ContratoComercial ADD CONSTRAINT
	FK_ContratoComercial_VariantesCor FOREIGN KEY
	(
	IdCor
	) REFERENCES dbo.VariantesCor
	(
	IdVariantesCor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContratoComercial ADD CONSTRAINT
	FK_ContratoComercial_VariantesEstilo FOREIGN KEY
	(
	IdEstilo
	) REFERENCES dbo.VariantesEstilo
	(
	IdVariantesEstilo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContratoComercial ADD CONSTRAINT
	FK_ContratoComercial_VariantesTamanho FOREIGN KEY
	(
	IdTamanho
	) REFERENCES dbo.VariantesTamanho
	(
	IdVariantesTamanho
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContratoComercial ADD CONSTRAINT
	FK_ContratoComercial_Cliente FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Cliente
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContratoComercial ADD CONSTRAINT
	FK_ContratoComercial_Fornecedor FOREIGN KEY
	(
	IdFornecedor
	) REFERENCES dbo.Fornecedor
	(
	IdFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContratoComercial ADD CONSTRAINT
	FK_ContratoComercial_Unidade FOREIGN KEY
	(
	IdUnidade
	) REFERENCES dbo.Unidade
	(
	IdUnidade
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContratoComercial ADD CONSTRAINT
	FK_ContratoComercial_GrupoPrecoDesconto FOREIGN KEY
	(
	IdGrupoPrecoDesconto
	) REFERENCES dbo.GrupoPrecoDesconto
	(
	IdGrupoPrecoDesconto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContratoComercial ADD CONSTRAINT
	FK_ContratoComercial_ContratoComercial FOREIGN KEY
	(
	IdContratoComercial
	) REFERENCES dbo.ContratoComercial
	(
	IdContratoComercial
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContratoComercial ADD CONSTRAINT
	FK_ContratoComercial_GrupoDescontoVarejista FOREIGN KEY
	(
	IdGrupoDescontoVarejista
	) REFERENCES dbo.GrupoDescontoVarejista
	(
	IdGrupoDescontoVarejista
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContratoComercial ADD CONSTRAINT
	FK_ContratoComercial_CodigoContratoComercial FOREIGN KEY
	(
	IdCodigoContratoComercial
	) REFERENCES dbo.CodigoContratoComercial
	(
	IdCodigoContratoComercial
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_ContratoComercial FOREIGN KEY
	(
	IdContratoComercial
	) REFERENCES dbo.ContratoComercial
	(
	IdContratoComercial
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
