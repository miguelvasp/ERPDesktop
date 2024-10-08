/*
   terça-feira, 20 de janeiro de 201518:01:53
   User: SA
   Server: MIKE-PC
   Database: ERP2
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
CREATE TABLE dbo.VendedorMetas
	(
	IdMetaVendedor int NOT NULL IDENTITY (1, 1),
	IdVendedor int NULL,
	Sequencia varchar(5) NULL,
	ValorInicial decimal(18, 2) NULL,
	ValorFinal decimal(18, 2) NULL,
	TipoMeta varchar(15) NULL,
	ValorPremio decimal(18, 2) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.VendedorMetas ADD CONSTRAINT
	PK_VendedorMetas PRIMARY KEY CLUSTERED 
	(
	IdMetaVendedor
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.VendedorMetas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VendedorMetas', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VendedorMetas', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VendedorMetas', 'Object', 'CONTROL') as Contr_Per 