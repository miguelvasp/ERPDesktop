/*
   quinta-feira, 4 de fevereiro de 201616:11:20
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
CREATE TABLE dbo.PedidoVendaItemEncargo
	(
	IdPedidoVendaItemEncargo int NOT NULL IDENTITY (1, 1),
	IdPedidoVendaItem int NULL,
	IdTransacao int NULL,
	IdCodigoEncargo int NULL,
	IdMoeda int NULL,
	ValorEncargo decimal(18, 4) NULL,
	TipoEncargo int NULL,
	IdGrupoImposto int NULL,
	IdGrupoImpostoItem int NULL,
	IncluiNotaFiscal bit NULL,
	IncluiImposto bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.PedidoVendaItemEncargo ADD CONSTRAINT
	PK_PedidoVendaItemEncargo PRIMARY KEY CLUSTERED 
	(
	IdPedidoVendaItemEncargo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.PedidoVendaItemEncargo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoVendaItemEncargo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItemEncargo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItemEncargo', 'Object', 'CONTROL') as Contr_Per 