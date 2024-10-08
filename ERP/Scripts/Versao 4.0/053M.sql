/*
   terça-feira, 5 de janeiro de 201610:19:30
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
ALTER TABLE dbo.AjusteEstoque
	DROP CONSTRAINT FK_AjusteEstoque_RecebimentoItemLote
GO
ALTER TABLE dbo.RecebimentoItemLote SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.RecebimentoItemLote', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.RecebimentoItemLote', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.RecebimentoItemLote', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.AjusteEstoque
	DROP CONSTRAINT FK_AjusteEstoque_ClassificacaoFiscal
GO
ALTER TABLE dbo.ClassificacaoFiscal SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ClassificacaoFiscal', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ClassificacaoFiscal', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ClassificacaoFiscal', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.AjusteEstoque
	DROP CONSTRAINT FK_AjusteEstoque_Unidade
GO
ALTER TABLE dbo.Unidade SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Unidade', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Unidade', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Unidade', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.AjusteEstoque
	DROP CONSTRAINT FK_AjusteEstoque_VariantesConfig
GO
ALTER TABLE dbo.VariantesConfig SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesConfig', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesConfig', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesConfig', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.AjusteEstoque
	DROP CONSTRAINT FK_AjusteEstoque_VariantesEstilo
GO
ALTER TABLE dbo.VariantesEstilo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesEstilo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesEstilo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesEstilo', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.AjusteEstoque
	DROP CONSTRAINT FK_AjusteEstoque_VariantesTamanho
GO
ALTER TABLE dbo.VariantesTamanho SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesTamanho', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesTamanho', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesTamanho', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.AjusteEstoque
	DROP CONSTRAINT FK_AjusteEstoque_VariantesCor
GO
ALTER TABLE dbo.VariantesCor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesCor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesCor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesCor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.AjusteEstoque
	DROP CONSTRAINT FK_AjusteEstoque_Localizacao
GO
ALTER TABLE dbo.Localizacao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Localizacao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Localizacao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Localizacao', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.AjusteEstoque
	DROP CONSTRAINT FK_AjusteEstoque_Armazem
GO
ALTER TABLE dbo.Armazem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Armazem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Armazem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Armazem', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.AjusteEstoque
	DROP CONSTRAINT FK_AjusteEstoque_Deposito
GO
ALTER TABLE dbo.Deposito SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Deposito', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Deposito', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Deposito', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.AjusteEstoque
	DROP CONSTRAINT FK_AjusteEstoque_Produto
GO
ALTER TABLE dbo.Produto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Produto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Produto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Produto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.AjusteEstoque
	DROP CONSTRAINT FK_AjusteEstoque_Empresa
GO
ALTER TABLE dbo.Empresa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Empresa', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Empresa', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Empresa', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_AjusteEstoque
	(
	IdAjusteEstoque int NOT NULL IDENTITY (1, 1),
	IdEmpresa int NULL,
	IdProduto int NULL,
	IdDeposito int NULL,
	IdArmazem int NULL,
	IdLocalizacao int NULL,
	IdVariantesCor int NULL,
	IdVariantesTamanho int NULL,
	IdVariantesEstilo int NULL,
	IdVariantesConfig int NULL,
	IdUnidade int NULL,
	IdDocumento int NULL,
	IdNCM int NULL,
	TipoMovimento int NULL,
	Quantidade decimal(18, 4) NULL,
	IdLote int NULL,
	DataVencimento datetime NULL,
	DataFabricacao datetime NULL,
	DataAvisoPrateleira datetime NULL,
	DataValidade datetime NULL,
	LoteFornecedor varchar(255) NULL,
	LoteInterno varchar(255) NULL,
	Motivo varchar(255) NULL,
	IdInventario int NULL,
	Data datetime NULL,
	QtdeLote decimal(18, 4) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_AjusteEstoque SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_AjusteEstoque ON
GO
IF EXISTS(SELECT * FROM dbo.AjusteEstoque)
	 EXEC('INSERT INTO dbo.Tmp_AjusteEstoque (IdAjusteEstoque, IdEmpresa, IdProduto, IdDeposito, IdArmazem, IdLocalizacao, IdVariantesCor, IdVariantesTamanho, IdVariantesEstilo, IdVariantesConfig, IdUnidade, IdDocumento, IdNCM, TipoMovimento, Quantidade, IdLote, DataVencimento, DataFabricacao, DataAvisoPrateleira, DataValidade, LoteFornecedor, LoteInterno, Motivo, IdInventario, Data, QtdeLote)
		SELECT IdAjusteEstoque, IdEmpresa, IdProduto, IdDeposito, IdArmazem, IdLocalizacao, IdVariantesCor, IdVariantesTamanho, IdVariantesEstilo, IdVariantesConfig, IdUnidade, IdDocumento, IdNCM, TipoMovimento, CONVERT(decimal(18, 4), Quantidade), IdLote, CONVERT(datetime, DataVencimento), CONVERT(datetime, DataFabricacao), CONVERT(datetime, DataAvisoPrateleira), CONVERT(datetime, DataValidade), LoteFornecedor, LoteInterno, Motivo, IdInventario, Data, QtdeLote FROM dbo.AjusteEstoque WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_AjusteEstoque OFF
GO
DROP TABLE dbo.AjusteEstoque
GO
EXECUTE sp_rename N'dbo.Tmp_AjusteEstoque', N'AjusteEstoque', 'OBJECT' 
GO
ALTER TABLE dbo.AjusteEstoque ADD CONSTRAINT
	PK_AjusteEstoque PRIMARY KEY CLUSTERED 
	(
	IdAjusteEstoque
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.AjusteEstoque ADD CONSTRAINT
	FK_AjusteEstoque_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
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
ALTER TABLE dbo.AjusteEstoque ADD CONSTRAINT
	FK_AjusteEstoque_Deposito FOREIGN KEY
	(
	IdDeposito
	) REFERENCES dbo.Deposito
	(
	IdDeposito
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.AjusteEstoque ADD CONSTRAINT
	FK_AjusteEstoque_Armazem FOREIGN KEY
	(
	IdArmazem
	) REFERENCES dbo.Armazem
	(
	IdArmazem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.AjusteEstoque ADD CONSTRAINT
	FK_AjusteEstoque_Localizacao FOREIGN KEY
	(
	IdLocalizacao
	) REFERENCES dbo.Localizacao
	(
	IdLocalizacao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.AjusteEstoque ADD CONSTRAINT
	FK_AjusteEstoque_VariantesCor FOREIGN KEY
	(
	IdVariantesCor
	) REFERENCES dbo.VariantesCor
	(
	IdVariantesCor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.AjusteEstoque ADD CONSTRAINT
	FK_AjusteEstoque_VariantesTamanho FOREIGN KEY
	(
	IdVariantesTamanho
	) REFERENCES dbo.VariantesTamanho
	(
	IdVariantesTamanho
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.AjusteEstoque ADD CONSTRAINT
	FK_AjusteEstoque_VariantesEstilo FOREIGN KEY
	(
	IdVariantesEstilo
	) REFERENCES dbo.VariantesEstilo
	(
	IdVariantesEstilo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.AjusteEstoque ADD CONSTRAINT
	FK_AjusteEstoque_VariantesConfig FOREIGN KEY
	(
	IdVariantesConfig
	) REFERENCES dbo.VariantesConfig
	(
	IdVariantesConfig
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.AjusteEstoque ADD CONSTRAINT
	FK_AjusteEstoque_Unidade FOREIGN KEY
	(
	IdUnidade
	) REFERENCES dbo.Unidade
	(
	IdUnidade
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.AjusteEstoque ADD CONSTRAINT
	FK_AjusteEstoque_ClassificacaoFiscal FOREIGN KEY
	(
	IdNCM
	) REFERENCES dbo.ClassificacaoFiscal
	(
	IdNCM
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.AjusteEstoque ADD CONSTRAINT
	FK_AjusteEstoque_RecebimentoItemLote FOREIGN KEY
	(
	IdLote
	) REFERENCES dbo.RecebimentoItemLote
	(
	IdLote
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.AjusteEstoque', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.AjusteEstoque', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.AjusteEstoque', 'Object', 'CONTROL') as Contr_Per 