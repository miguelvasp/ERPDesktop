/*
   segunda-feira, 25 de janeiro de 201616:12:46
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
EXECUTE sp_rename N'dbo.PedidoVendaItemApuracaoImposto.IdPedidoItem', N'Tmp_IdPedidoVendaItem', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.PedidoVendaItemApuracaoImposto.Tmp_IdPedidoVendaItem', N'IdPedidoVendaItem', 'COLUMN' 
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoVendaItemApuracaoImposto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItemApuracaoImposto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItemApuracaoImposto', 'Object', 'CONTROL') as Contr_Per 