/*
   terça-feira, 20 de janeiro de 201517:12:10
   User: SA
   Server: MIKE-PC
   Database: ERP2
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
CREATE TABLE dbo.Tmp_Cliente
	(
	IdCliente int NOT NULL IDENTITY (1, 1),
	RazaoSocial varchar(MAX) NOT NULL,
	NomeFantasia varchar(MAX) NULL,
	CNPJ char(14) NOT NULL,
	InscricaoEstadual varchar(30) NULL,
	Email varchar(150) NULL,
	Internet varchar(150) NULL,
	IdVendedor int NULL,
	IdTipoCliente int NULL,
	TipoPessoa varchar(1) NULL,
	DataInclusao datetime NULL,
	IdRamoAtividade int NULL,
	IdRepresentante int NULL,
	IdTransportadora int NULL,
	CanalConsumo varchar(1) NULL,
	CodigoSuframa varchar(50) NULL,
	MicroEmpresa bit NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Cliente SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Cliente ON
GO
IF EXISTS(SELECT * FROM dbo.Cliente)
	 EXEC('INSERT INTO dbo.Tmp_Cliente (IdCliente, RazaoSocial, NomeFantasia, CNPJ, InscricaoEstadual, Email, Internet)
		SELECT IdCliente, RazaoSocial, NomeFantasia, CNPJ, InscricaoEstadual, CONVERT(varchar(150), Email), CONVERT(varchar(150), Internet) FROM dbo.Cliente WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Cliente OFF
GO
ALTER TABLE dbo.ContasReceber
	DROP CONSTRAINT FK_ContasReceber_Cliente
GO
ALTER TABLE dbo.ClienteContato
	DROP CONSTRAINT FK_ClienteContato_Cliente
GO
ALTER TABLE dbo.ClienteEndereco
	DROP CONSTRAINT FK_ClienteEndereco_Cliente
GO
ALTER TABLE dbo.ClienteTelefone
	DROP CONSTRAINT FK_ClienteTelefone_Cliente
GO
DROP TABLE dbo.Cliente
GO
EXECUTE sp_rename N'dbo.Tmp_Cliente', N'Cliente', 'OBJECT' 
GO
ALTER TABLE dbo.Cliente ADD CONSTRAINT
	PK_Empresa PRIMARY KEY CLUSTERED 
	(
	IdCliente
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ClienteTelefone ADD CONSTRAINT
	FK_ClienteTelefone_Cliente FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Cliente
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ClienteTelefone SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ClienteTelefone', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ClienteTelefone', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ClienteTelefone', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ClienteEndereco ADD CONSTRAINT
	FK_ClienteEndereco_Cliente FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Cliente
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ClienteEndereco SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ClienteEndereco', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ClienteEndereco', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ClienteEndereco', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ClienteContato ADD CONSTRAINT
	FK_ClienteContato_Cliente FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Cliente
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ClienteContato SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ClienteContato', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ClienteContato', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ClienteContato', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
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
ALTER TABLE dbo.ContasReceber SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasReceber', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasReceber', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasReceber', 'Object', 'CONTROL') as Contr_Per 