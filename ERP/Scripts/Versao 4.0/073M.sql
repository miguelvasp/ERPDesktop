/*
   sábado, 6 de fevereiro de 201618:13:14
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
ALTER TABLE dbo.PedidoVendaAlocacaoEncargos
	DROP CONSTRAINT FK_PedidoVendaAlocacaoEncargos_PedidoVenda
GO
ALTER TABLE dbo.PedidoVenda SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoVenda', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoVenda', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoVenda', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_PedidoVendaAlocacaoEncargos
	(
	IdPedidoVenda int NOT NULL,
	DistribuirPor int NULL,
	Linhas int NULL,
	DistribuirTudo bit NULL,
	Recebido_Separado bit NULL,
	IdPedidoVendaAlocaEncargos int NOT NULL IDENTITY (1, 1)
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_PedidoVendaAlocacaoEncargos SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_PedidoVendaAlocacaoEncargos OFF
GO
IF EXISTS(SELECT * FROM dbo.PedidoVendaAlocacaoEncargos)
	 EXEC('INSERT INTO dbo.Tmp_PedidoVendaAlocacaoEncargos (IdPedidoVenda, DistribuirPor, Linhas, DistribuirTudo, Recebido_Separado)
		SELECT IdPedidoVenda, DistribuirPor, Linhas, DistribuirTudo, Recebido_Separado FROM dbo.PedidoVendaAlocacaoEncargos WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.PedidoVendaAlocacaoEncargos
GO
EXECUTE sp_rename N'dbo.Tmp_PedidoVendaAlocacaoEncargos', N'PedidoVendaAlocacaoEncargos', 'OBJECT' 
GO
ALTER TABLE dbo.PedidoVendaAlocacaoEncargos ADD CONSTRAINT
	PK_PedidoVendaAlocacaoEncargos_1 PRIMARY KEY CLUSTERED 
	(
	IdPedidoVendaAlocaEncargos
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

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
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoVendaAlocacaoEncargos', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoVendaAlocacaoEncargos', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoVendaAlocacaoEncargos', 'Object', 'CONTROL') as Contr_Per 