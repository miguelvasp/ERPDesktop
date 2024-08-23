 CONSTRAINT
	FK_FornecedorContaBancaria_ContaBancaria FOREIGN KEY
	(
	IdContaBancaria
	) REFERENCES dbo.ContaBancaria
	(
	IdContaBancaria
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.FornecedorContaBancaria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ClienteContaBancaria ADD CONSTRAINT
	FK_ClienteContaBancaria_ContaBancaria FOREIGN KEY
	(
	IdContaBancaria
	) REFERENCES dbo.ContaBancaria
	(
	IdContaBancaria
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ClienteContaBancaria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContasPagarBaixa ADD CONSTRAINT
	FK_ContasPagarBaixa_ContaBancaria FOREIGN KEY
	(
	IdContaBancaria
	) REFERENCES dbo.ContaBancaria
	(
	IdContaBancaria
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasPagarBaixa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Fornecedor ADD CONSTRAINT
	FK_Fornecedor_ContaBancaria FOREIGN KEY
	(
	IdContaBancaria
	) REFERENCES dbo.ContaBancaria
	(
	IdContaBancaria
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Fornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.FuncionarioContaBancaria ADD CONSTRAINT
	FK_FuncionarioContaBancaria_ContaBancaria FOREIGN KEY
	(
	IdContaBancaria
	) REFERENCES dbo.ContaBancaria
	(
	IdContaBancaria
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.FuncionarioContaBancaria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

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
ALTER TABLE dbo.Pais SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContaBancaria ADD
	IdPais int NULL
GO
ALTER TABLE dbo.ContaBancaria ADD CONSTRAINT
	FK_ContaBancaria_Pais FOREIGN KEY
	(
	IdPais
	) REFERENCES dbo.Pais
	(
	IdPais
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContaBancaria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
