/*
   segunda-feira, 5 de outubro de 201520:08:18
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
ALTER TABLE dbo.Pais SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Pais', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Pais', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Pais', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cidade SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Cidade', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Cidade', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Cidade', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CFOP SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CFOP', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CFOP', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CFOP', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Transportadora SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Transportadora', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Transportadora', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Transportadora', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Telefone SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Telefone', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Telefone', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Telefone', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.TipoDocumento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.TipoDocumento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.TipoDocumento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.TipoDocumento', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.NotaFiscal ADD CONSTRAINT
	FK_NotaFiscal_TipoDocumento FOREIGN KEY
	(
	IdDocumento
	) REFERENCES dbo.TipoDocumento
	(
	IdDocumento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.NotaFiscal ADD CONSTRAINT
	FK_NotaFiscal_Telefone FOREIGN KEY
	(
	IdTelefone
	) REFERENCES dbo.Telefone
	(
	IdTelefone
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.NotaFiscal ADD CONSTRAINT
	FK_NotaFiscal_Transportadora FOREIGN KEY
	(
	IdTransportadora
	) REFERENCES dbo.Transportadora
	(
	IdTransportadora
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.NotaFiscal ADD CONSTRAINT
	FK_NotaFiscal_CFOP FOREIGN KEY
	(
	IdCFOP
	) REFERENCES dbo.CFOP
	(
	IdCFOP
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.NotaFiscal ADD CONSTRAINT
	FK_NotaFiscal_Cidade FOREIGN KEY
	(
	IdCidade
	) REFERENCES dbo.Cidade
	(
	IdCidade
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.NotaFiscal ADD CONSTRAINT
	FK_NotaFiscal_Pais FOREIGN KEY
	(
	IdPais
	) REFERENCES dbo.Pais
	(
	IdPais
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.NotaFiscal SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.NotaFiscal', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.NotaFiscal', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.NotaFiscal', 'Object', 'CONTROL') as Contr_Per 