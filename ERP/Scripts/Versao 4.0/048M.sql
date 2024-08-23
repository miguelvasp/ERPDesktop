/*
   terça-feira, 5 de janeiro de 201609:11:11
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
CREATE TABLE dbo.AjusteEstoque
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
	Quantidade int NULL,
	IdLote int NULL,
	DataVencimento int NULL,
	DataFabricacao int NULL,
	DataAvisoPrateleira int NULL,
	DataValidade int NULL,
	LoteFornecedor varchar(255) NULL,
	LoteInterno varchar(255) NULL,
	Motivo varchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.AjusteEstoque ADD CONSTRAINT
	PK_AjusteEstoque PRIMARY KEY CLUSTERED 
	(
	IdAjusteEstoque
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.AjusteEstoque SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.AjusteEstoque', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.AjusteEstoque', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.AjusteEstoque', 'Object', 'CONTROL') as Contr_Per 