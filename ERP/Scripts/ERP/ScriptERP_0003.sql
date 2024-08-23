/*
   terça-feira, 20 de janeiro de 201517:52:38
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
CREATE TABLE dbo.Vendedor
	(
	IdVendedor int NOT NULL IDENTITY (1, 1),
	Nome varchar(50) NULL,
	ComissaoPrincipal decimal(18, 2) NULL,
	ComissaoAdicional decimal(18, 2) NULL,
	IdGerente int NULL,
	Bloqueado bit NULL,
	MotivoBloqueio varchar(150) NULL,
	Gerencia bit NULL,
	CPF_CNPJ varchar(14) NULL,
	IE_RG varchar(30) NULL,
	Endereco varchar(50) NULL,
	Numero varchar(10) NULL,
	Complemento varchar(20) NULL,
	Bairro varchar(50) NULL,
	IdUF int NULL,
	IdCidade int NULL,
	Telefone varchar(20) NULL,
	Telefone2 varchar(20) NULL,
	Celular varchar(20) NULL,
	Site varchar(150) NULL,
	Email varchar(150) NULL,
	Obs varchar(MAX) NULL,
	Representante bit NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Vendedor ADD CONSTRAINT
	PK_Vendedor PRIMARY KEY CLUSTERED 
	(
	IdVendedor
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Vendedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Vendedor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Vendedor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Vendedor', 'Object', 'CONTROL') as Contr_Per 