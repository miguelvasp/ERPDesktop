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
ALTER TABLE dbo.TipoLancamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Lancamento
	DROP CONSTRAINT FK_Lancamento_Produto
GO
ALTER TABLE dbo.Produto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Lancamento
	DROP CONSTRAINT FK_Lancamento_ContaContabil
GO
ALTER TABLE dbo.ContaContabil SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Lancamento
	DROP CONSTRAINT FK_Lancamento_Cliente
GO
ALTER TABLE dbo.Cliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Lancamento
	DROP CONSTRAINT FK_Lancamento_GrupoProduto
GO
ALTER TABLE dbo.GrupoProduto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Lancamento
	DROP CONSTRAINT FK_Lancamento_GrupoImposto
GO
ALTER TABLE dbo.GrupoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Lancamento
	DROP CONSTRAINT FK_Lancamento_GrupoFornecedor
GO
ALTER TABLE dbo.GrupoFornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Lancamento
	DROP CONSTRAINT FK_Lancamento_Fornecedor
GO
ALTER TABLE dbo.Fornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Lancamento
	DROP CONSTRAINT FK_Lancamento_GrupoCliente
GO
ALTER TABLE dbo.GrupoCliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Lancamento
	(
	IdLancamento int NOT NULL IDENTITY (1, 1),
	IdTipoLancamento int NULL,
	Descricao varchar(255) NULL,
	TipoConta int NULL,
	RelacaoItem int NULL,
	RelacaoGrupo int NULL,
	IdProduto int NULL,
	IdGrupoProduto int NULL,
	IdCliente int NULL,
	IdFornecedor int NULL,
	IdGrupoCliente int NULL,
	IdGrupoFornecedor int NULL,
	IdGrupoImposto int NULL,
	IdContaContabil int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Lancamento SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Lancamento ON
GO
IF EXISTS(SELECT * FROM dbo.Lancamento)
	 EXEC('INSERT INTO dbo.Tmp_Lancamento (IdLancamento, Descricao, TipoConta, RelacaoItem, RelacaoGrupo, IdProduto, IdGrupoProduto, IdCliente, IdFornecedor, IdGrupoCliente, IdGrupoFornecedor, IdGrupoImposto, IdContaContabil)
		SELECT IdLancamento, Descricao, TipoConta, RelacaoItem, RelacaoGrupo, IdProduto, IdGrupoProduto, IdCliente, IdFornecedor, IdGrupoCliente, IdGrupoFornecedor, IdGrupoImposto, IdContaContabil FROM dbo.Lancamento WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Lancamento OFF
GO
DROP TABLE dbo.Lancamento
GO
EXECUTE sp_rename N'dbo.Tmp_Lancamento', N'Lancamento', 'OBJECT' 
GO
ALTER TABLE dbo.Lancamento ADD CONSTRAINT
	PK_Lancamento PRIMARY KEY CLUSTERED 
	(
	IdLancamento
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Lancamento ADD CONSTRAINT
	FK_Lancamento_GrupoCliente FOREIGN KEY
	(
	IdGrupoCliente
	) REFERENCES dbo.GrupoCliente
	(
	IdGrupoCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Lancamento ADD CONSTRAINT
	FK_Lancamento_Fornecedor FOREIGN KEY
	(
	IdFornecedor
	) REFERENCES dbo.Fornecedor
	(
	IdFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Lancamento ADD CONSTRAINT
	FK_Lancamento_GrupoFornecedor FOREIGN KEY
	(
	IdGrupoFornecedor
	) REFERENCES dbo.GrupoFornecedor
	(
	IdGrupoFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Lancamento ADD CONSTRAINT
	FK_Lancamento_GrupoImposto FOREIGN KEY
	(
	IdGrupoImposto
	) REFERENCES dbo.GrupoImposto
	(
	IdGrupoImposto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Lancamento ADD CONSTRAINT
	FK_Lancamento_GrupoProduto FOREIGN KEY
	(
	IdGrupoProduto
	) REFERENCES dbo.GrupoProduto
	(
	IdGrupoProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Lancamento ADD CONSTRAINT
	FK_Lancamento_Cliente FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Cliente
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Lancamento ADD CONSTRAINT
	FK_Lancamento_ContaContabil FOREIGN KEY
	(
	IdContaContabil
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
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
ALTER TABLE dbo.Lancamento ADD CONSTRAINT
	FK_Lancamento_TipoLancamento FOREIGN KEY
	(
	IdTipoLancamento
	) REFERENCES dbo.TipoLancamento
	(
	IdTipoLancamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
