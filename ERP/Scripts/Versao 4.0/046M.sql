/*
   domingo, 3 de janeiro de 201619:03:57
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
ALTER TABLE dbo.Inventario ADD
	DataVencimento datetime NULL,
	DataFabricacao datetime NULL,
	DataAvisoPrateleira datetime NULL,
	DataValidade datetime NULL,
	LoteFornecedor varchar(255) NULL,
	LoteInterno varchar(255) NULL
GO
ALTER TABLE dbo.Inventario SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Inventario', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Inventario', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Inventario', 'Object', 'CONTROL') as Contr_Per 