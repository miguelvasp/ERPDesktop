/*
   terça-feira, 15 de março de 201602:06:35
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
ALTER TABLE dbo.PedidoCompraAlocacaoEncargos
	DROP CONSTRAINT FK_PedidoCompraAlocacaoEncargos_PedidoCompra
GO
ALTER TABLE dbo.PedidoCompra SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoCompra', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoCompra', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoCompra', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_PedidoCompraAlocacaoEncargos
	(
	IdPedidoCompra int NOT NULL,
	DistribuirPor int NULL,
	Linhas int NULL,
	DistribuirTudo bit NULL,
	Recebido_Separado bit NULL,
	IdPedidoCompraAlocacaoEncargos int NOT NULL IDENTITY (1, 1)
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_PedidoCompraAlocacaoEncargos SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_PedidoCompraAlocacaoEncargos ON
GO
IF EXISTS(SELECT * FROM dbo.PedidoCompraAlocacaoEncargos)
	 EXEC('INSERT INTO dbo.Tmp_PedidoCompraAlocacaoEncargos (IdPedidoCompra, DistribuirPor, Linhas, DistribuirTudo, Recebido_Separado, IdPedidoCompraAlocacaoEncargos)
		SELECT IdPedidoCompra, DistribuirPor, Linhas, DistribuirTudo, Recebido_Separado, IDPEDIDOCompraALOCAENCARGOS FROM dbo.PedidoCompraAlocacaoEncargos WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_PedidoCompraAlocacaoEncargos OFF
GO
DROP TABLE dbo.PedidoCompraAlocacaoEncargos
GO
EXECUTE sp_rename N'dbo.Tmp_PedidoCompraAlocacaoEncargos', N'PedidoCompraAlocacaoEncargos', 'OBJECT' 
GO
ALTER TABLE dbo.PedidoCompraAlocacaoEncargos ADD CONSTRAINT
	PK_PedidoCompraAlocacaoEncargos PRIMARY KEY CLUSTERED 
	(
	IdPedidoCompraAlocacaoEncargos
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.PedidoCompraAlocacaoEncargos ADD CONSTRAINT
	FK_PedidoCompraAlocacaoEncargos_PedidoCompra FOREIGN KEY
	(
	IdPedidoCompra
	) REFERENCES dbo.PedidoCompra
	(
	IdPedidoCompra
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoCompraAlocacaoEncargos', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoCompraAlocacaoEncargos', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoCompraAlocacaoEncargos', 'Object', 'CONTROL') as Contr_Per 