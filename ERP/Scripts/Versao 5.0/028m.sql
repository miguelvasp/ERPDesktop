/*
   domingo, 17 de abril de 201610:27:12
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
CREATE TABLE dbo.PagamentoLoteItem
	(
	IdPagamentoLoteItem int NOT NULL IDENTITY (1, 1),
	IdPagamentoLote int NULL,
	IdContasPagarAberto int NULL,
	IdContasPagarBaixa int NULL,
	Valor decimal(18, 4) NULL,
	StatusBaixa int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.PagamentoLoteItem ADD CONSTRAINT
	PK_PagamentoLoteItem PRIMARY KEY CLUSTERED 
	(
	IdPagamentoLoteItem
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.PagamentoLoteItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PagamentoLoteItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PagamentoLoteItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PagamentoLoteItem', 'Object', 'CONTROL') as Contr_Per 