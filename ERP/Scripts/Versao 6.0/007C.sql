/*
   terça-feira, 12 de julho de 201622:41:05
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
ALTER TABLE dbo.Empresa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Empresa', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Empresa', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Empresa', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContaBancaria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContaBancaria', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContaBancaria', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContaBancaria', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Fornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Creche
	(
	IdCheque int NOT NULL IDENTITY (1, 1),
	IdContaBancaria int NULL,
	NumeroCheque varchar(255) NULL,
	Data datetime NULL,
	Status int NULL,
	IdEmpresa int NULL,
	Conciliado int NULL,
	Moeda varchar(255) NULL,
	Valor decimal(18, 4) NULL,
	ValorMoedaTransacao decimal(18, 4) NULL,
	IdTransacao int NULL,
	IdFornecedor int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Creche SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Creche ON
GO
IF EXISTS(SELECT * FROM dbo.Creche)
	 EXEC('INSERT INTO dbo.Tmp_Creche (IdCheque, IdContaBancaria, NumeroCheque, Data, Status, IdEmpresa, Conciliado, Moeda, Valor, ValorMoedaTransacao, IdTransacao, IdFornecedor)
		SELECT IdCheque, IDContaBancaria, NumeroCheque, Data, Status, IdEmpresa, Conciliado, Moeda, Valor, ValorMoedaTransacao, IdTransacao, IdFornecedor FROM dbo.Creche WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Creche OFF
GO
DROP TABLE dbo.Creche
GO
EXECUTE sp_rename N'dbo.Tmp_Creche', N'Creche', 'OBJECT' 
GO
ALTER TABLE dbo.Creche ADD CONSTRAINT
	PK_Creche PRIMARY KEY CLUSTERED 
	(
	IdCheque
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Creche ADD CONSTRAINT
	FK_Creche_Fornecedor FOREIGN KEY
	(
	IdFornecedor
	) REFERENCES dbo.Fornecedor
	(
	IdFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Creche ADD CONSTRAINT
	FK_Creche_ContaBancaria FOREIGN KEY
	(
	IdContaBancaria
	) REFERENCES dbo.ContaBancaria
	(
	IdContaBancaria
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Creche ADD CONSTRAINT
	FK_Creche_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Creche', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Creche', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Creche', 'Object', 'CONTROL') as Contr_Per 