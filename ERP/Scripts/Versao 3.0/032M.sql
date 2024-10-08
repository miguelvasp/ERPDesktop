/*
   sexta-feira, 23 de outubro de 201514:40:02
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
	LoteInterno varchar(255) NULL,
	LoteFornecedor varchar(255) NULL,
	DataVencimento datetime NULL,
	DataFabricacao datetime NULL,
	DataAvisoPrateleira datetime NULL,
	DataValidade datetime NULL
GO
ALTER TABLE dbo.Inventario SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Inventario', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Inventario', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Inventario', 'Object', 'CONTROL') as Contr_Per 