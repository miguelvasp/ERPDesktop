/*
   terça-feira, 27 de setembro de 201620:35:46
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
CREATE TABLE dbo.Cheque
	(
	IdCheque int NOT NULL IDENTITY (1, 1),
	NumeroCheque int NULL,
	IdContaBancaria int NULL,
	Status int NULL,
	Valor decimal(18, 4) NULL,
	Vencimento datetime NULL,
	Emissao datetime NULL,
	IdFornecedor int NULL,
	ComprovantePagamento varchar(255) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Cheque ADD CONSTRAINT
	PK_Cheque PRIMARY KEY CLUSTERED 
	(
	IdCheque
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Cheque SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Cheque', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Cheque', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Cheque', 'Object', 'CONTROL') as Contr_Per 