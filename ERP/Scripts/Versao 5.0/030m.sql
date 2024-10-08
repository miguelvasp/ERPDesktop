/*
   domingo, 17 de abril de 201610:40:21
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
ALTER TABLE dbo.ChequeTerceiros SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ChequeTerceiros', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ChequeTerceiros', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ChequeTerceiros', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContasPagarAberto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasPagarAberto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasPagarAberto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasPagarAberto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.MetodoPagamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.MetodoPagamento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.MetodoPagamento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.MetodoPagamento', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Fornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContaBancaria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContaBancaria', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContaBancaria', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContaBancaria', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContaContabil SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PagamentoLote ADD CONSTRAINT
	FK_PagamentoLote_ContaBancaria FOREIGN KEY
	(
	IdContaBancaria
	) REFERENCES dbo.ContaBancaria
	(
	IdContaBancaria
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PagamentoLote ADD CONSTRAINT
	FK_PagamentoLote_Fornecedor FOREIGN KEY
	(
	IdFornecedor
	) REFERENCES dbo.Fornecedor
	(
	IdFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PagamentoLote ADD CONSTRAINT
	FK_PagamentoLote_Cliente FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Cliente
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PagamentoLote ADD CONSTRAINT
	FK_PagamentoLote_ContaContabil FOREIGN KEY
	(
	IdContaContabil
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PagamentoLote ADD CONSTRAINT
	FK_PagamentoLote_MetodoPagamento FOREIGN KEY
	(
	IdMetodoPagamento
	) REFERENCES dbo.MetodoPagamento
	(
	IdMetodoPagamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PagamentoLote SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PagamentoLote', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PagamentoLote', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PagamentoLote', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PagamentoLoteChequeTerceiro ADD CONSTRAINT
	FK_PagamentoLoteChequeTerceiro_PagamentoLote FOREIGN KEY
	(
	IdPagamentoLote
	) REFERENCES dbo.PagamentoLote
	(
	IdPagamentoLote
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PagamentoLoteChequeTerceiro ADD CONSTRAINT
	FK_PagamentoLoteChequeTerceiro_ChequeTerceiros FOREIGN KEY
	(
	IdChequeTerceiro
	) REFERENCES dbo.ChequeTerceiros
	(
	IdChequeTerceiro
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PagamentoLoteChequeTerceiro SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PagamentoLoteChequeTerceiro', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PagamentoLoteChequeTerceiro', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PagamentoLoteChequeTerceiro', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContasPagarBaixa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasPagarBaixa', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasPagarBaixa', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasPagarBaixa', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PagamentoLoteItem ADD CONSTRAINT
	FK_PagamentoLoteItem_PagamentoLote FOREIGN KEY
	(
	IdPagamentoLote
	) REFERENCES dbo.PagamentoLote
	(
	IdPagamentoLote
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PagamentoLoteItem ADD CONSTRAINT
	FK_PagamentoLoteItem_ContasPagarBaixa FOREIGN KEY
	(
	IdContasPagarBaixa
	) REFERENCES dbo.ContasPagarBaixa
	(
	IdContasPagarBaixa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PagamentoLoteItem ADD CONSTRAINT
	FK_PagamentoLoteItem_ContasPagarAberto FOREIGN KEY
	(
	IdContasPagarAberto
	) REFERENCES dbo.ContasPagarAberto
	(
	IdContasPagarAberto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PagamentoLoteItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PagamentoLoteItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PagamentoLoteItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PagamentoLoteItem', 'Object', 'CONTROL') as Contr_Per 