/*
   domingo, 27 de setembro de 201521:11:16
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
CREATE TABLE dbo.ContasPagarBaixa
	(
	IdContasPagarBaixa int NOT NULL IDENTITY (1, 1),
	IdContasPagarAberto int NULL,
	TipoTransacao int NULL,
	DataPagamento datetime NULL,
	Documento varchar(255) NULL,
	Observacao varchar(MAX) NULL,
	IdPagamento int NULL,
	Valor decimal(18, 4) NULL,
	NumeroCheque varchar(255) NULL,
	IdContaBancaria int NULL,
	NumeroParcela int NULL,
	NumeroParcelaOriginal int NULL,
	Retencao bit NULL,
	Liquidada bit NULL,
	NumeroRemessa varchar(255) NULL,
	NumeroDocumentoBancario varchar(255) NULL,
	IdChequeTerceiros int NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.ContasPagarBaixa ADD CONSTRAINT
	PK_ContasPagarBaixa PRIMARY KEY CLUSTERED 
	(
	IdContasPagarBaixa
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ContasPagarBaixa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasPagarBaixa', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasPagarBaixa', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasPagarBaixa', 'Object', 'CONTROL') as Contr_Per 