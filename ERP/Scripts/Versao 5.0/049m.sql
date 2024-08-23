/*
   sexta-feira, 20 de maio de 201620:12:29
   User: mgasoftware
   Server: mssql.mgasolucoes.com.br
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
ALTER TABLE dbo.Contabilidade
	DROP CONSTRAINT FK_Contabilidade_Empresa
GO
ALTER TABLE dbo.Empresa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Empresa', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Empresa', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Empresa', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Contabilidade
	DROP CONSTRAINT FK_Contabilidade_Cliente
GO
ALTER TABLE dbo.Cliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Contabilidade
	DROP CONSTRAINT FK_Contabilidade_Fornecedor
GO
ALTER TABLE dbo.Fornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Contabilidade
	DROP CONSTRAINT FK_Contabilidade_Moeda
GO
ALTER TABLE dbo.Moeda SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Contabilidade
	DROP CONSTRAINT FK_Contabilidade_OrigemLancamento
GO
ALTER TABLE dbo.OrigemLancamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.OrigemLancamento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.OrigemLancamento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.OrigemLancamento', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Contabilidade
	DROP CONSTRAINT FK_Contabilidade_ContaContabil
GO
ALTER TABLE dbo.ContaContabil SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Contabilidade
	(
	IdContabilidade int NOT NULL IDENTITY (1, 1),
	IdOrigemLancamento int NULL,
	IdContaContabil int NULL,
	IdLote varchar(255) NULL,
	ValorCredito decimal(18, 4) NULL,
	ValorDebito decimal(18, 4) NULL,
	DataHora datetime NULL,
	Usuario varchar(200) NULL,
	IdCentroCusto int NULL,
	IdMoeda int NULL,
	ValorAjusteDebito decimal(18, 4) NULL,
	ValorAjusteCredito decimal(18, 4) NULL,
	Preco decimal(18, 4) NULL,
	IdRegraDistribuicao int NULL,
	IdFornecedor int NULL,
	IdCliente int NULL,
	IdEmpresa int NULL,
	Aprovado bit NULL,
	Data datetime NULL,
	Aprovador varchar(255) NULL,
	NumeroCheque int NULL,
	Origem varchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Contabilidade SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Contabilidade ON
GO
IF EXISTS(SELECT * FROM dbo.Contabilidade)
	 EXEC('INSERT INTO dbo.Tmp_Contabilidade (IdContabilidade, IdOrigemLancamento, IdContaContabil, IdLote, ValorCredito, ValorDebito, DataHora, Usuario, IdCentroCusto, IdMoeda, ValorAjusteDebito, ValorAjusteCredito, Preco, IdRegraDistribuicao, IdFornecedor, IdCliente, IdEmpresa, Aprovado, Data, Aprovador, NumeroCheque, Origem)
		SELECT IdContabilidade, IdOrigemLancamento, IdContaContabil, CONVERT(varchar(255), IdLote), ValorCredito, ValorDebito, DataHora, Usuario, IdCentroCusto, IdMoeda, ValorAjusteDebito, ValorAjusteCredito, Preco, IdRegraDistribuicao, IdFornecedor, IdCliente, IdEmpresa, Aprovado, Data, Aprovador, NumeroCheque, Origem FROM dbo.Contabilidade WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Contabilidade OFF
GO
DROP TABLE dbo.Contabilidade
GO
EXECUTE sp_rename N'dbo.Tmp_Contabilidade', N'Contabilidade', 'OBJECT' 
GO
ALTER TABLE dbo.Contabilidade ADD CONSTRAINT
	PK_Contabilidade PRIMARY KEY CLUSTERED 
	(
	IdContabilidade
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Contabilidade ADD CONSTRAINT
	FK_Contabilidade_ContaContabil FOREIGN KEY
	(
	IdContaContabil
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Contabilidade ADD CONSTRAINT
	FK_Contabilidade_OrigemLancamento FOREIGN KEY
	(
	IdOrigemLancamento
	) REFERENCES dbo.OrigemLancamento
	(
	IdOrigemLancamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Contabilidade ADD CONSTRAINT
	FK_Contabilidade_Moeda FOREIGN KEY
	(
	IdMoeda
	) REFERENCES dbo.Moeda
	(
	IdMoeda
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Contabilidade ADD CONSTRAINT
	FK_Contabilidade_Fornecedor FOREIGN KEY
	(
	IdFornecedor
	) REFERENCES dbo.Fornecedor
	(
	IdFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Contabilidade ADD CONSTRAINT
	FK_Contabilidade_Cliente FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Cliente
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Contabilidade ADD CONSTRAINT
	FK_Contabilidade_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Contabilidade', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Contabilidade', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Contabilidade', 'Object', 'CONTROL') as Contr_Per 