/*
   quarta-feira, 18 de novembro de 201515:49:33
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
ALTER TABLE dbo.ContaBancaria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContaBancaria', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContaBancaria', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContaBancaria', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CodigoJuros SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoJuros', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoJuros', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoJuros', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CodigoMultas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoMultas', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoMultas', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoMultas', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ChequeTerceiros SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ChequeTerceiros', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ChequeTerceiros', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ChequeTerceiros', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.NotaFiscal SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.NotaFiscal', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.NotaFiscal', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.NotaFiscal', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PerfilCliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PerfilCliente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PerfilCliente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PerfilCliente', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
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
ALTER TABLE dbo.Cliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContaContabil SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContasReceber ADD CONSTRAINT
	FK_ContasReceber_ContaContabil FOREIGN KEY
	(
	IdContaContabil
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasReceber ADD CONSTRAINT
	FK_ContasReceber_Cliente FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Cliente
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasReceber ADD CONSTRAINT
	FK_ContasReceber_Moeda FOREIGN KEY
	(
	IdMoeda
	) REFERENCES dbo.Moeda
	(
	IdMoeda
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasReceber ADD CONSTRAINT
	FK_ContasReceber_MetodoPagamento FOREIGN KEY
	(
	IdMetodoPagamento
	) REFERENCES dbo.MetodoPagamento
	(
	IdMetodoPagamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasReceber ADD CONSTRAINT
	FK_ContasReceber_EspecificacaoPagamento FOREIGN KEY
	(
	IdEspecificacaoPagamento
	) REFERENCES dbo.EspecificacaoPagamento
	(
	IdEspecificacaoPagamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasReceber ADD CONSTRAINT
	FK_ContasReceber_PerfilCliente FOREIGN KEY
	(
	IdPerfilCliente
	) REFERENCES dbo.PerfilCliente
	(
	IdPerfilCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasReceber ADD CONSTRAINT
	FK_ContasReceber_NotaFiscal FOREIGN KEY
	(
	IdNotaFiscal
	) REFERENCES dbo.NotaFiscal
	(
	IdNotaFiscal
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasReceber SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasReceber', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasReceber', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasReceber', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContasReceberAberto ADD CONSTRAINT
	FK_ContasReceberAberto_ContasReceber FOREIGN KEY
	(
	IdContasReceber
	) REFERENCES dbo.ContasReceber
	(
	IdContasReceber
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasReceberAberto ADD CONSTRAINT
	FK_ContasReceberAberto_CodigoMultas FOREIGN KEY
	(
	IdCodigoMulta
	) REFERENCES dbo.CodigoMultas
	(
	IdCodigoMultas
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasReceberAberto ADD CONSTRAINT
	FK_ContasReceberAberto_CodigoJuros FOREIGN KEY
	(
	IdCodigoJuros
	) REFERENCES dbo.CodigoJuros
	(
	IdCodigoJuros
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasReceberAberto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasReceberAberto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasReceberAberto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasReceberAberto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContasReceberBaixa ADD CONSTRAINT
	FK_ContasReceberBaixa_ContasReceberAberto FOREIGN KEY
	(
	IdContasReceberAberto
	) REFERENCES dbo.ContasReceberAberto
	(
	IdContasReceberAberto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasReceberBaixa ADD CONSTRAINT
	FK_ContasReceberBaixa_ContaBancaria FOREIGN KEY
	(
	IdContaBancaria
	) REFERENCES dbo.ContaBancaria
	(
	IdContaBancaria
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasReceberBaixa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasReceberBaixa', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasReceberBaixa', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasReceberBaixa', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContasReceberChequeTerceiros ADD CONSTRAINT
	FK_ContasReceberChequeTerceiros_ContasReceber FOREIGN KEY
	(
	IdContasReceber
	) REFERENCES dbo.ContasReceber
	(
	IdContasReceber
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasReceberChequeTerceiros ADD CONSTRAINT
	FK_ContasReceberChequeTerceiros_ContasReceberBaixa FOREIGN KEY
	(
	IdContasReceberBaixa
	) REFERENCES dbo.ContasReceberBaixa
	(
	IdContasReceberBaixa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasReceberChequeTerceiros ADD CONSTRAINT
	FK_ContasReceberChequeTerceiros_ChequeTerceiros FOREIGN KEY
	(
	IdChequeTerceiro
	) REFERENCES dbo.ChequeTerceiros
	(
	IdChequeTerceiro
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasReceberChequeTerceiros SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasReceberChequeTerceiros', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasReceberChequeTerceiros', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasReceberChequeTerceiros', 'Object', 'CONTROL') as Contr_Per 