/*
   sábado, 1 de outubro de 201618:54:53
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
ALTER TABLE dbo.Cheque SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Cheque', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Cheque', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Cheque', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Fornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ChequeItem ADD CONSTRAINT
	FK_ChequeItem_Cheque FOREIGN KEY
	(
	IdCheque
	) REFERENCES dbo.Cheque
	(
	IdCheque
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ChequeItem ADD CONSTRAINT
	FK_ChequeItem_Cliente FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Cliente
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ChequeItem ADD CONSTRAINT
	FK_ChequeItem_Fornecedor FOREIGN KEY
	(
	IdFornecedor
	) REFERENCES dbo.Fornecedor
	(
	IdFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ChequeItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ChequeItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ChequeItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ChequeItem', 'Object', 'CONTROL') as Contr_Per 