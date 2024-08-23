/*
   domingo, 28 de junho de 201503:17:35
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
ALTER TABLE dbo.ListaMateriaisItem
	DROP CONSTRAINT FK_ListadeMateriaisItem_VariantesEstilo
GO
ALTER TABLE dbo.VariantesEstilo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesEstilo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesEstilo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesEstilo', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisItem
	DROP CONSTRAINT FK_ListadeMateriaisItem_VariantesCor
GO
ALTER TABLE dbo.VariantesCor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesCor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesCor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesCor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisItem
	DROP CONSTRAINT FK_ListadeMateriaisItem_VariantesConfig
GO
ALTER TABLE dbo.VariantesConfig SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesConfig', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesConfig', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesConfig', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisItem
	DROP CONSTRAINT FK_ListadeMateriaisItem_Unidade
GO
ALTER TABLE dbo.Unidade SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Unidade', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Unidade', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Unidade', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisItem
	DROP CONSTRAINT FK_ListadeMateriaisItem_Produto
GO
ALTER TABLE dbo.Produto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Produto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Produto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Produto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisItem
	DROP CONSTRAINT FK_ListadeMateriaisItem_ListaMateriais
GO
ALTER TABLE dbo.ListaMateriais SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ListaMateriais', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ListaMateriais', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ListaMateriais', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisItem
	DROP CONSTRAINT FK_ListadeMateriaisItem_Armazem
GO
ALTER TABLE dbo.Armazem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Armazem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Armazem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Armazem', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriaisItem
	DROP CONSTRAINT FK_ListadeMateriaisItem_VariantesTamanho
GO
ALTER TABLE dbo.VariantesTamanho SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesTamanho', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesTamanho', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesTamanho', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_ListaMateriaisItem
	(
	IdListaMateriaisItem int NOT NULL IDENTITY (1, 1),
	IdListaMateriais int NULL,
	IdProduto int NULL,
	Descricao varchar(255) NULL,
	IdConfiguracao int NULL,
	IdEstilo int NULL,
	IdCor int NULL,
	IdTamanho int NULL,
	IdArmazem int NULL,
	De datetime NULL,
	Ate datetime NULL,
	QuantidadeOrigem int NULL,
	IdUnidadeBom int NULL,
	Ativo bit NULL,
	AlocacaoCustoTotal int NULL,
	Construcao bit NULL,
	DataFormula datetime NULL,
	MultiploFormula int NULL,
	Prioridade int NULL,
	QuantidadeProducao decimal(18, 4) NULL,
	TamanhoFormula decimal(18, 4) NULL,
	UsarParaCalculo bit NULL,
	VariacoesCoProdutos bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_ListaMateriaisItem SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_ListaMateriaisItem ON
GO
IF EXISTS(SELECT * FROM dbo.ListaMateriaisItem)
	 EXEC('INSERT INTO dbo.Tmp_ListaMateriaisItem (IdListaMateriaisItem, IdListaMateriais, IdProduto, Descricao, IdConfiguracao, IdEstilo, IdCor, IdTamanho, IdArmazem, De, Ate, QuantidadeOrigem, IdUnidadeBom, Ativo, AlocacaoCustoTotal, Construcao, DataFormula, MultiploFormula, Prioridade, QuantidadeProducao, TamanhoFormula, UsarParaCalculo, VariacoesCoProdutos)
		SELECT IdListaMateriaisItem, IdListaMateriais, IdProduto, Descricao, IdConfiguracao, IdEstilo, IdCor, IdTamanho, IdArmazem, De, Ate, QuantidadeOrigem, IdUnidadeBom, Ativo, CONVERT(int, AlocacaoCustoTotal), Construcao, DataFormula, MultiploFormula, Prioridade, QuantidadeProducao, TamanhoFormula, UsarParaCalculo, VariacoesCoProdutos FROM dbo.ListaMateriaisItem WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_ListaMateriaisItem OFF
GO
ALTER TABLE dbo.ListaMateriaisLinhas
	DROP CONSTRAINT FK_ListaMateriaisLinhas_ListaMateriaisItem
GO
DROP TABLE dbo.ListaMateriaisItem
GO
EXECUTE sp_rename N'dbo.Tmp_ListaMateriaisItem', N'ListaMateriaisItem', 'OBJECT' 
GO
ALTER TABLE dbo.ListaMateriaisItem ADD CONSTRAINT
	PK_ListadeMateriaisItem PRIMARY KEY CLUSTERED 
	(
	IdListaMateriaisItem
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ListaMateriaisItem ADD CONSTRAINT
	FK_ListadeMateriaisItem_VariantesTamanho FOREIGN KEY
	(
	IdTamanho
	) REFERENCES dbo.VariantesTamanho
	(
	IdVariantesTamanho
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ListaMateriaisItem ADD CONSTRAINT
	FK_ListadeMateriaisItem_Armazem FOREIGN KEY
	(
	IdArmazem
	) REFERENCES dbo.Armazem
	(
	IdArmazem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ListaMateriaisItem ADD CONSTRAINT
	FK_ListadeMateriaisItem_ListaMateriais FOREIGN KEY
	(
	IdListaMateriais
	) REFERENCES dbo.ListaMateriais
	(
	IdListaMateriais
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
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
ALTER TABLE dbo.ListaMateriaisItem ADD CONSTRAINT
	FK_ListadeMateriaisItem_Unidade FOREIGN KEY
	(
	IdUnidadeBom
	) REFERENCES dbo.Unidade
	(
	IdUnidade
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ListaMateriaisItem ADD CONSTRAINT
	FK_ListadeMateriaisItem_VariantesConfig FOREIGN KEY
	(
	IdConfiguracao
	) REFERENCES dbo.VariantesConfig
	(
	IdVariantesConfig
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ListaMateriaisItem ADD CONSTRAINT
	FK_ListadeMateriaisItem_VariantesCor FOREIGN KEY
	(
	IdCor
	) REFERENCES dbo.VariantesCor
	(
	IdVariantesCor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ListaMateriaisItem ADD CONSTRAINT
	FK_ListadeMateriaisItem_VariantesEstilo FOREIGN KEY
	(
	IdEstilo
	) REFERENCES dbo.VariantesEstilo
	(
	IdVariantesEstilo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ListaMateriaisItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ListaMateriaisItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ListaMateriaisItem', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
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
ALTER TABLE dbo.ListaMateriaisLinhas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ListaMateriaisLinhas', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ListaMateriaisLinhas', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ListaMateriaisLinhas', 'Object', 'CONTROL') as Contr_Per 