/*
   domingo, 1 de novembro de 201514:07:29
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
CREATE TABLE dbo.ChequeTerceiros
	(
	IdChequeTerceiro int NOT NULL IDENTITY (1, 1),
	IdContasPagar int NULL,
	IdContasReceber int NULL,
	IdBanco int NULL,
	Agencia varchar(50) NULL,
	Conta varchar(50) NULL,
	Nome varchar(255) NULL,
	CPF varchar(20) NULL,
	NumeroCheque varchar(50) NULL,
	Emissao datetime NULL,
	DataCompensacao datetime NULL,
	Status int NULL,
	Valor decimal(18, 4) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.ChequeTerceiros ADD CONSTRAINT
	PK_ChequeTerceiros PRIMARY KEY CLUSTERED 
	(
	IdChequeTerceiro
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ChequeTerceiros SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ChequeTerceiros', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ChequeTerceiros', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ChequeTerceiros', 'Object', 'CONTROL') as Contr_Per 