/*
   quinta-feira, 4 de fevereiro de 201616:02:41
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
CREATE TABLE dbo.PedidoVendaAlocacaoEncargos
	(
	IdPedidoVenda int NOT NULL,
	DistribuirPor int NULL,
	Linhas int NULL,
	DistribuirTudo bit NULL,
	Recebido_Separado bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.PedidoVendaAlocacaoEncargos ADD CONSTRAINT
	PK_PedidoVendaAlocacaoEncargos PRIMARY KEY CLUSTERED 
	(
	IdPedidoVenda
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.PedidoVendaAlocacaoEncargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoVendaAlocacaoEncargos', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoVendaAlocacaoEncargos', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoVendaAlocacaoEncargos', 'Object', 'CONTROL') as Contr_Per 