/*
   sexta-feira, 11 de março de 201623:13:01
   User: CristianPC
   Server: DESKTOP-ABRC2BB
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
ALTER TABLE dbo.GrupoAtivo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoAtivo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoAtivo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoAtivo', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
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
ALTER TABLE dbo.MovimentacaoAtivo ADD CONSTRAINT
	FK_MovimentacaoAtivo_Cliente FOREIGN KEY
	(
	IDCliente
	) REFERENCES dbo.Cliente
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MovimentacaoAtivo ADD CONSTRAINT
	FK_MovimentacaoAtivo_Fornecedor FOREIGN KEY
	(
	IDFornecedor
	) REFERENCES dbo.Fornecedor
	(
	IdFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MovimentacaoAtivo ADD CONSTRAINT
	FK_MovimentacaoAtivo_GrupoAtivo FOREIGN KEY
	(
	IDGrupoAtivo
	) REFERENCES dbo.GrupoAtivo
	(
	IdGrupoAtivo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MovimentacaoAtivo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.MovimentacaoAtivo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.MovimentacaoAtivo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.MovimentacaoAtivo', 'Object', 'CONTROL') as Contr_Per 