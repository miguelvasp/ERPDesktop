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
	DROP CONSTRAINT FK_ContratoComercial_GrupoFornecedor
GO
ALTER TABLE dbo.GrupoFornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContratoComercial
	DROP CONSTRAINT FK_ContratoComercial_GrupoCliente
GO
ALTER TABLE dbo.GrupoCliente SET (LOCK_ESCALATION = TABLE)
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
	Codigo varchar(255) NULL,
	Descricao varchar(255) NULL,
	Ativo int NULL,
	Relacao int NULL,
	IdCliente int NULL,
	IdFornecedor int NULL,
	IdGrupoCliente int NULL,
	IdGrupoFornecedor int NULL,
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
	EncargoFixo decimal(18, 4) NULL,
	UnidadePreco int NULL,
	DeData datetime NULL,
	AteData datetime NULL,
	IdGrupoPrecoDesconto int NULL,
	IdEmpresa int NULL,
	ContratoNumero int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_ContratoComercial SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_ContratoComercial ON
GO
IF EXISTS(SELECT * FROM dbo.ContratoComercial)
	 EXEC('INSERT INTO dbo.Tmp_ContratoComercial (IdContratoComercial, Codigo, Descricao, Ativo, Relacao, IdCliente, IdFornecedor, IdGrupoCliente, IdGrupoFornecedor, RelacaoItem, IdProduto, IdGrupoProduto, IdEstilo, IdTamanho, IdCor, De, Ate, IdUnidade, Valor, EncargoFixo, UnidadePreco, DeData, AteData, IdEmpresa, ContratoNumero)
		SELECT IdContratoComercial, Codigo, Descricao, Ativo, Relacao, IdCliente, IdFornecedor, IdGrupoCliente, IdGrupoFornecedor, RelacaoItem, IdProduto, IdGrupoProduto, IdEstilo, IdTamanho, IdCor, De, Ate, IdUnidade, Valor, EncargoFixo, UnidadePreco, DeData, AteData, IdEmpresa, ContratoNumero FROM dbo.ContratoComercial WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_ContratoComercial OFF
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
	FK_ContratoComercial_GrupoCliente FOREIGN KEY
	(
	IdGrupoCliente
	) REFERENCES dbo.GrupoCliente
	(
	IdGrupoCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContratoComercial ADD CONSTRAINT
	FK_ContratoComercial_GrupoFornecedor FOREIGN KEY
	(
	IdGrupoFornecedor
	) REFERENCES dbo.GrupoFornecedor
	(
	IdGrupoFornecedor
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
EXECUTE sp_rename N'dbo.ContratoComercial.EncargoFixo', N'Tmp_ValorPercentual', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.ContratoComercial.Tmp_ValorPercentual', N'ValorPercentual', 'COLUMN' 
GO
ALTER TABLE dbo.ContratoComercial SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
