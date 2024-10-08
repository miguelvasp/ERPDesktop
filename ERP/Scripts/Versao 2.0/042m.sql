/*
   domingo, 27 de setembro de 201521:03:27
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
ALTER TABLE dbo.FornecedorContaBancaria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.FornecedorContaBancaria', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.FornecedorContaBancaria', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.FornecedorContaBancaria', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CodigoMultas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoMultas', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoMultas', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoMultas', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CodigoJuros SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoJuros', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoJuros', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoJuros', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PerfilFornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PerfilFornecedor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PerfilFornecedor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PerfilFornecedor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.EspecificacaoPagamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.EspecificacaoPagamento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.EspecificacaoPagamento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.EspecificacaoPagamento', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.MetodoPagamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.MetodoPagamento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.MetodoPagamento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.MetodoPagamento', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Moeda SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Fornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContaContabil SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompra SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoCompra', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoCompra', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoCompra', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContasPagar ADD CONSTRAINT
	FK_ContasPagar_PedidoCompra FOREIGN KEY
	(
	IdPedidoCompra
	) REFERENCES dbo.PedidoCompra
	(
	IdPedidoCompra
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasPagar ADD CONSTRAINT
	FK_ContasPagar_ContaContabil FOREIGN KEY
	(
	IdContaContabil
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasPagar ADD CONSTRAINT
	FK_ContasPagar_Fornecedor FOREIGN KEY
	(
	IdFornecedor
	) REFERENCES dbo.Fornecedor
	(
	IdFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasPagar ADD CONSTRAINT
	FK_ContasPagar_Moeda FOREIGN KEY
	(
	IdMoeda
	) REFERENCES dbo.Moeda
	(
	IdMoeda
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasPagar ADD CONSTRAINT
	FK_ContasPagar_MetodoPagamento FOREIGN KEY
	(
	IdMetodoPagamento
	) REFERENCES dbo.MetodoPagamento
	(
	IdMetodoPagamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasPagar ADD CONSTRAINT
	FK_ContasPagar_EspecificacaoPagamento FOREIGN KEY
	(
	IdEspecificacaoPagamento
	) REFERENCES dbo.EspecificacaoPagamento
	(
	IdEspecificacaoPagamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasPagar ADD CONSTRAINT
	FK_ContasPagar_PerfilFornecedor FOREIGN KEY
	(
	IdPerfilFornecedor
	) REFERENCES dbo.PerfilFornecedor
	(
	IdPerfilFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasPagar SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasPagar', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasPagar', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasPagar', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContasPagarAberto ADD CONSTRAINT
	FK_ContasPagarAberto_ContasPagar FOREIGN KEY
	(
	IdContasPagar
	) REFERENCES dbo.ContasPagar
	(
	IdContasPagar
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasPagarAberto ADD CONSTRAINT
	FK_ContasPagarAberto_Fornecedor FOREIGN KEY
	(
	IdFornecedor
	) REFERENCES dbo.Fornecedor
	(
	IdFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasPagarAberto ADD CONSTRAINT
	FK_ContasPagarAberto_CodigoJuros FOREIGN KEY
	(
	IdCodigoJuros
	) REFERENCES dbo.CodigoJuros
	(
	IdCodigoJuros
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasPagarAberto ADD CONSTRAINT
	FK_ContasPagarAberto_CodigoMultas FOREIGN KEY
	(
	IdCodigoMulta
	) REFERENCES dbo.CodigoMultas
	(
	IdCodigoMultas
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasPagarAberto ADD CONSTRAINT
	FK_ContasPagarAberto_FornecedorContaBancaria FOREIGN KEY
	(
	IdFornecedorContaBancaria
	) REFERENCES dbo.FornecedorContaBancaria
	(
	IdFornecedorContaBancaria
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasPagarAberto ADD CONSTRAINT
	FK_ContasPagarAberto_PerfilFornecedor FOREIGN KEY
	(
	IdPerfilFornecedor
	) REFERENCES dbo.PerfilFornecedor
	(
	IdPerfilFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasPagarAberto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasPagarAberto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasPagarAberto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasPagarAberto', 'Object', 'CONTROL') as Contr_Per 