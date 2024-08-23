/*
   segunda-feira, 11 de janeiro de 201612:35:17
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
ALTER TABLE dbo.ContasPagarBaixa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasPagarBaixa', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasPagarBaixa', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasPagarBaixa', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContasReceberBaixa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasReceberBaixa', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasReceberBaixa', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasReceberBaixa', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContaContabil SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContaBancaria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContaBancaria', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContaBancaria', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContaBancaria', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Banco SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Banco', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Banco', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Banco', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
EXECUTE sp_rename N'dbo.MovimentacaoBancaria.IdPagamento', N'Tmp_IdContasPagarBaixa', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.MovimentacaoBancaria.IdRecebimento', N'Tmp_IdContasReceberBaixa_1', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.MovimentacaoBancaria.Tmp_IdContasPagarBaixa', N'IdContasPagarBaixa', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.MovimentacaoBancaria.Tmp_IdContasReceberBaixa_1', N'IdContasReceberBaixa', 'COLUMN' 
GO
ALTER TABLE dbo.MovimentacaoBancaria ADD CONSTRAINT
	FK_MovimentacaoBancaria_ContasReceberBaixa FOREIGN KEY
	(
	IdContasReceberBaixa
	) REFERENCES dbo.ContasReceberBaixa
	(
	IdContasReceberBaixa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MovimentacaoBancaria ADD CONSTRAINT
	FK_MovimentacaoBancaria_ContasPagarBaixa FOREIGN KEY
	(
	IdContasPagarBaixa
	) REFERENCES dbo.ContasPagarBaixa
	(
	IdContasPagarBaixa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MovimentacaoBancaria ADD CONSTRAINT
	FK_MovimentacaoBancaria_Banco FOREIGN KEY
	(
	IdBanco
	) REFERENCES dbo.Banco
	(
	IdBanco
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MovimentacaoBancaria ADD CONSTRAINT
	FK_MovimentacaoBancaria_ContaBancaria FOREIGN KEY
	(
	IdContaBancaria
	) REFERENCES dbo.ContaBancaria
	(
	IdContaBancaria
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MovimentacaoBancaria ADD CONSTRAINT
	FK_MovimentacaoBancaria_ContaContabil FOREIGN KEY
	(
	IdContaContabil
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MovimentacaoBancaria ADD CONSTRAINT
	FK_MovimentacaoBancaria_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MovimentacaoBancaria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.MovimentacaoBancaria', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.MovimentacaoBancaria', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.MovimentacaoBancaria', 'Object', 'CONTROL') as Contr_Per 