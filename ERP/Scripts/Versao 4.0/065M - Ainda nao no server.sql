/*
   segunda-feira, 25 de janeiro de 201616:16:47
   User: 
   Server: MIKE-PC
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
ALTER TABLE dbo.GrupoImpostoItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoImpostoItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoImpostoItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoImpostoItem', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoImposto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoImposto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoImposto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.JuridicaoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.JuridicaoImposto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.JuridicaoImposto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.JuridicaoImposto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CodigoIsencao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoIsencao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoIsencao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoIsencao', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContaContabil SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Moeda SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CodigoTributacao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoTributacao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoTributacao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoTributacao', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CodigoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoImposto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoImposto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoImposto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.NotaFiscal SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.NotaFiscal', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.NotaFiscal', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.NotaFiscal', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoVendaItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItem', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto ADD CONSTRAINT
	FK_PedidoVendaItemApuracaoImposto_PedidoVendaItem FOREIGN KEY
	(
	IdPedidoVendaItem
	) REFERENCES dbo.PedidoVendaItem
	(
	IdPedidoVendaItem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto ADD CONSTRAINT
	FK_PedidoVendaItemApuracaoImposto_NotaFiscal FOREIGN KEY
	(
	IdNotaFiscal
	) REFERENCES dbo.NotaFiscal
	(
	IdNotaFiscal
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto ADD CONSTRAINT
	FK_PedidoVendaItemApuracaoImposto_CodigoImposto FOREIGN KEY
	(
	IdCodigoImposto
	) REFERENCES dbo.CodigoImposto
	(
	IdCodigoImposto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto ADD CONSTRAINT
	FK_PedidoVendaItemApuracaoImposto_CodigoTributacao FOREIGN KEY
	(
	IdCodigoTributacao
	) REFERENCES dbo.CodigoTributacao
	(
	IdCodigoTributacao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto ADD CONSTRAINT
	FK_PedidoVendaItemApuracaoImposto_Moeda FOREIGN KEY
	(
	IdMoeda
	) REFERENCES dbo.Moeda
	(
	IdMoeda
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto ADD CONSTRAINT
	FK_PedidoVendaItemApuracaoImposto_Moeda1 FOREIGN KEY
	(
	IdMoedaComprovante
	) REFERENCES dbo.Moeda
	(
	IdMoeda
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto ADD CONSTRAINT
	FK_PedidoVendaItemApuracaoImposto_ContaContabil FOREIGN KEY
	(
	IdContaContabil
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto ADD CONSTRAINT
	FK_PedidoVendaItemApuracaoImposto_CodigoIsencao FOREIGN KEY
	(
	IdCodigoIsencao
	) REFERENCES dbo.CodigoIsencao
	(
	IdCodigoIsencao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto ADD CONSTRAINT
	FK_PedidoVendaItemApuracaoImposto_JuridicaoImposto FOREIGN KEY
	(
	IdJurisdicaoImposto
	) REFERENCES dbo.JuridicaoImposto
	(
	IdJuridicaoImposto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto ADD CONSTRAINT
	FK_PedidoVendaItemApuracaoImposto_GrupoImposto FOREIGN KEY
	(
	IdGrupoImposto
	) REFERENCES dbo.GrupoImposto
	(
	IdGrupoImposto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto ADD CONSTRAINT
	FK_PedidoVendaItemApuracaoImposto_GrupoImpostoItem FOREIGN KEY
	(
	IdGrupoImpostoItem
	) REFERENCES dbo.GrupoImpostoItem
	(
	IdGrupoImpostoItem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoVendaItemApuracaoImposto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItemApuracaoImposto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItemApuracaoImposto', 'Object', 'CONTROL') as Contr_Per 