/*
   terça-feira, 30 de junho de 201518:29:09
   User: 
   Server: MIKE-PC
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
ALTER TABLE dbo.ListaMateriaisLinhas
	DROP CONSTRAINT FK_ListadeMateriaisLinhas_Fornecedor
GO
ALTER TABLE dbo.Fornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisLinhas
	DROP CONSTRAINT FK_ListadeMateriaisLinhas_Unidade
GO
ALTER TABLE dbo.Unidade SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Unidade', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Unidade', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Unidade', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisLinhas
	DROP CONSTRAINT FK_ListadeMateriaisLinhas_Deposito
GO
ALTER TABLE dbo.Deposito SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Deposito', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Deposito', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Deposito', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisLinhas
	DROP CONSTRAINT FK_ListadeMateriaisLinhas_Armazem
GO
ALTER TABLE dbo.Armazem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Armazem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Armazem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Armazem', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisLinhas
	DROP CONSTRAINT FK_ListadeMateriaisLinhas_Localizacao
GO
ALTER TABLE dbo.Localizacao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Localizacao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Localizacao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Localizacao', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisLinhas
	DROP CONSTRAINT FK_ListadeMateriaisLinhas_Lote
GO
ALTER TABLE dbo.Lote SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Lote', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Lote', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Lote', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisLinhas
	DROP CONSTRAINT FK_ListadeMateriaisLinhas_VariantesEstilo
GO
ALTER TABLE dbo.VariantesEstilo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesEstilo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesEstilo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesEstilo', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisLinhas
	DROP CONSTRAINT FK_ListadeMateriaisLinhas_VariantesCor
GO
ALTER TABLE dbo.VariantesCor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesCor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesCor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesCor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisLinhas
	DROP CONSTRAINT FK_ListadeMateriaisLinhas_VariantesTamanho
GO
ALTER TABLE dbo.VariantesTamanho SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesTamanho', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesTamanho', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesTamanho', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisLinhas
	DROP CONSTRAINT FK_ListadeMateriaisLinhas_VariantesConfig
GO
ALTER TABLE dbo.VariantesConfig SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesConfig', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesConfig', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesConfig', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisLinhas
	DROP CONSTRAINT FK_ListadeMateriaisLinhas_Produto
GO
ALTER TABLE dbo.Produto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Produto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Produto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Produto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisLinhas
	DROP CONSTRAINT FK_ListaMateriaisLinhas_ListaMateriaisItem
GO
ALTER TABLE dbo.ListaMateriaisItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ListaMateriaisItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ListaMateriaisItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ListaMateriaisItem', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_ListaMateriaisLinhas
	(
	IdListaMateriaisLinhas int NOT NULL IDENTITY (1, 1),
	IdListaMateriaisItem int NULL,
	IdProduto int NULL,
	Descricao varchar(255) NULL,
	IdConfiguracao int NULL,
	IdTamanho int NULL,
	IdCor int NULL,
	IdEstilo int NULL,
	IdLote int NULL,
	IdLocalizacao int NULL,
	Serie varchar(255) NULL,
	IdArmazem int NULL,
	IdDeposito int NULL,
	IdUnidade int NULL,
	Quantidade decimal(18, 4) NULL,
	Porserie int NULL,
	TipoItem int NULL,
	Formula int NULL,
	Consumo int NULL,
	PrincipioLiberacao int NULL,
	SucataConstante decimal(18, 4) NULL,
	Altura decimal(18, 4) NULL,
	Profundidade decimal(18, 4) NULL,
	Densidade decimal(18, 4) NULL,
	Largura decimal(18, 4) NULL,
	TipoLinha int NULL,
	Calculo bit NULL,
	IdFornecedor int NULL,
	DefinirSubProducaoComoConsumo bit NULL,
	SubBOM int NULL,
	SubRoteiro int NULL,
	Escalonavel bit NULL,
	De datetime NULL,
	Ate datetime NULL,
	NumeroOperacao int NULL,
	Fim bit NULL,
	Prioridade int NULL,
	HerdaLoteCoProduto bit NULL,
	HerdaLoteProdutoFinal bit NULL,
	HerdaValidadeCoproduto bit NULL,
	HerdaValidadeProdutoFinal bit NULL,
	Percentual decimal(18, 4) NULL,
	PercentualCustos decimal(18, 4) NULL,
	PorcentagemContraolada bit NULL,
	PorcentagemRecuperacao decimal(18, 4) NULL,
	TipoIngrediente int NULL,
	TipoProducao int NULL,
	AlocacaoCusto bit NULL,
	ConsumoRecurso bit NULL,
	ValorCustoIndiretoSubProduto decimal(18, 4) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_ListaMateriaisLinhas SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_ListaMateriaisLinhas ON
GO
IF EXISTS(SELECT * FROM dbo.ListaMateriaisLinhas)
	 EXEC('INSERT INTO dbo.Tmp_ListaMateriaisLinhas (IdListaMateriaisLinhas, IdListaMateriaisItem, IdProduto, Descricao, IdConfiguracao, IdTamanho, IdCor, IdEstilo, IdLote, IdLocalizacao, Serie, IdArmazem, IdDeposito, IdUnidade, Quantidade, Porserie, TipoItem, Formula, Consumo, PrincipioLiberacao, SucataConstante, Altura, Profundidade, Densidade, Largura, TipoLinha, Calculo, IdFornecedor, DefinirSubProducaoComoConsumo, SubBOM, SubRoteiro, Escalonavel, De, Ate, NumeroOperacao, Fim, Prioridade, HerdaLoteCoProduto, HerdaLoteProdutoFinal, HerdaValidadeCoproduto, HerdaValidadeProdutoFinal, Percentual, PercentualCustos, PorcentagemContraolada, PorcentagemRecuperacao, TipoIngrediente, TipoProducao, AlocacaoCusto, ConsumoRecurso, ValorCustoIndiretoSubProduto)
		SELECT IdListaMateriaisLinhas, IdListaMateriaisItem, IdProduto, Descricao, IdConfiguracao, IdTamanho, IdCor, IdEstilo, IdLote, IdLocalizacao, Serie, IdArmazem, IdDeposito, IdUnidade, Quantidade, Porserie, TipoItem, Formula, Consumo, PrincipioLiberacao, SucataConstante, Altura, Profundidade, Densidade, Largura, TipoLinha, CONVERT(bit, Calculo), IdFornecedor, DefinirSubProducaoComoConsumo, SubBOM, SubRoteiro, Escalonavel, De, Ate, NumeroOperacao, Fim, Prioridade, HerdaLoteCoProduto, HerdaLoteProdutoFinal, HerdaValidadeCoproduto, HerdaValidadeProdutoFinal, Percentual, PercentualCustos, PorcentagemContraolada, PorcentagemRecuperacao, TipoIngrediente, TipoProducao, AlocacaoCusto, ConsumoRecurso, ValorCustoIndiretoSubProduto FROM dbo.ListaMateriaisLinhas WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_ListaMateriaisLinhas OFF
GO
DROP TABLE dbo.ListaMateriaisLinhas
GO
EXECUTE sp_rename N'dbo.Tmp_ListaMateriaisLinhas', N'ListaMateriaisLinhas', 'OBJECT' 
GO
ALTER TABLE dbo.ListaMateriaisLinhas ADD CONSTRAINT
	PK_ListadeMateriaisLinhas PRIMARY KEY CLUSTERED 
	(
	IdListaMateriaisLinhas
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ListaMateriaisLinhas ADD CONSTRAINT
	FK_ListaMateriaisLinhas_ListaMateriaisItem FOREIGN KEY
	(
	IdListaMateriaisItem
	) REFERENCES dbo.ListaMateriaisItem
	(
	IdListaMateriaisItem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
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
ALTER TABLE dbo.ListaMateriaisLinhas ADD CONSTRAINT
	FK_ListadeMateriaisLinhas_VariantesConfig FOREIGN KEY
	(
	IdConfiguracao
	) REFERENCES dbo.VariantesConfig
	(
	IdVariantesConfig
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ListaMateriaisLinhas ADD CONSTRAINT
	FK_ListadeMateriaisLinhas_VariantesTamanho FOREIGN KEY
	(
	IdTamanho
	) REFERENCES dbo.VariantesTamanho
	(
	IdVariantesTamanho
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ListaMateriaisLinhas ADD CONSTRAINT
	FK_ListadeMateriaisLinhas_VariantesCor FOREIGN KEY
	(
	IdCor
	) REFERENCES dbo.VariantesCor
	(
	IdVariantesCor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ListaMateriaisLinhas ADD CONSTRAINT
	FK_ListadeMateriaisLinhas_VariantesEstilo FOREIGN KEY
	(
	IdEstilo
	) REFERENCES dbo.VariantesEstilo
	(
	IdVariantesEstilo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ListaMateriaisLinhas ADD CONSTRAINT
	FK_ListadeMateriaisLinhas_Lote FOREIGN KEY
	(
	IdLote
	) REFERENCES dbo.Lote
	(
	IdLote
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ListaMateriaisLinhas ADD CONSTRAINT
	FK_ListadeMateriaisLinhas_Localizacao FOREIGN KEY
	(
	IdLocalizacao
	) REFERENCES dbo.Localizacao
	(
	IdLocalizacao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ListaMateriaisLinhas ADD CONSTRAINT
	FK_ListadeMateriaisLinhas_Armazem FOREIGN KEY
	(
	IdArmazem
	) REFERENCES dbo.Armazem
	(
	IdArmazem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ListaMateriaisLinhas ADD CONSTRAINT
	FK_ListadeMateriaisLinhas_Deposito FOREIGN KEY
	(
	IdDeposito
	) REFERENCES dbo.Deposito
	(
	IdDeposito
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ListaMateriaisLinhas ADD CONSTRAINT
	FK_ListadeMateriaisLinhas_Unidade FOREIGN KEY
	(
	IdUnidade
	) REFERENCES dbo.Unidade
	(
	IdUnidade
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ListaMateriaisLinhas ADD CONSTRAINT
	FK_ListadeMateriaisLinhas_Fornecedor FOREIGN KEY
	(
	IdFornecedor
	) REFERENCES dbo.Fornecedor
	(
	IdFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ListaMateriaisLinhas', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ListaMateriaisLinhas', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ListaMateriaisLinhas', 'Object', 'CONTROL') as Contr_Per 