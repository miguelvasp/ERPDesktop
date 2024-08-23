/*
   domingo, 22 de maio de 201617:14:25
   User: 
   Server: DESKTOP-A5U70DL
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
ALTER TABLE dbo.Cest SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Cest', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Cest', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Cest', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem ADD
	IdCest int NULL
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_Cest FOREIGN KEY
	(
	IdCest
	) REFERENCES dbo.Cest
	(
	IdCest
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoVendaItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItem', 'Object', 'CONTROL') as Contr_Per 