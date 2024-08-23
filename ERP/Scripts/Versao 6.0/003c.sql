/*
   quinta-feira, 23 de junho de 201601:21:38
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
ALTER TABLE dbo.DiasPagamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.DiasPagamento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.DiasPagamento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.DiasPagamento', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompra ADD
	IdDiasPagamento int NULL
GO
ALTER TABLE dbo.PedidoCompra ADD CONSTRAINT
	FK_PedidoCompra_DiasPagamento FOREIGN KEY
	(
	IdDiasPagamento
	) REFERENCES dbo.DiasPagamento
	(
	IdDiasPagamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompra SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoCompra', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoCompra', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoCompra', 'Object', 'CONTROL') as Contr_Per 