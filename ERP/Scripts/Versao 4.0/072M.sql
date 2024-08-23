/*
   quinta-feira, 4 de fevereiro de 201616:16:43
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
ALTER TABLE dbo.Moeda SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CodigoEncargo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoEncargo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoEncargo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoEncargo', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoVendaItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItem', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItemEncargo ADD CONSTRAINT
	FK_PedidoVendaItemEncargo_PedidoVendaItem FOREIGN KEY
	(
	IdPedidoVendaItem
	) REFERENCES dbo.PedidoVendaItem
	(
	IdPedidoVendaItem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemEncargo ADD CONSTRAINT
	FK_PedidoVendaItemEncargo_CodigoEncargo FOREIGN KEY
	(
	IdCodigoEncargo
	) REFERENCES dbo.CodigoEncargo
	(
	IdCodigoEncargo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemEncargo ADD CONSTRAINT
	FK_PedidoVendaItemEncargo_Moeda FOREIGN KEY
	(
	IdMoeda
	) REFERENCES dbo.Moeda
	(
	IdMoeda
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemEncargo ADD CONSTRAINT
	FK_PedidoVendaItemEncargo_GrupoImposto FOREIGN KEY
	(
	IdGrupoImposto
	) REFERENCES dbo.GrupoImposto
	(
	IdGrupoImposto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemEncargo ADD CONSTRAINT
	FK_PedidoVendaItemEncargo_GrupoImpostoItem FOREIGN KEY
	(
	IdGrupoImpostoItem
	) REFERENCES dbo.GrupoImpostoItem
	(
	IdGrupoImpostoItem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemEncargo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoVendaItemEncargo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItemEncargo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItemEncargo', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVenda SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoVenda', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoVenda', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoVenda', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaEncargos ADD CONSTRAINT
	FK_PedidoVendaEncargos_PedidoVenda FOREIGN KEY
	(
	IdPedidoVenda
	) REFERENCES dbo.PedidoVenda
	(
	IdPedidoVenda
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaEncargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoVendaEncargos', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoVendaEncargos', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoVendaEncargos', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaAlocacaoEncargos ADD CONSTRAINT
	FK_PedidoVendaAlocacaoEncargos_PedidoVenda FOREIGN KEY
	(
	IdPedidoVenda
	) REFERENCES dbo.PedidoVenda
	(
	IdPedidoVenda
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaAlocacaoEncargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoVendaAlocacaoEncargos', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoVendaAlocacaoEncargos', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoVendaAlocacaoEncargos', 'Object', 'CONTROL') as Contr_Per 