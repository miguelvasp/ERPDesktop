/*
   sábado, 16 de abril de 201610:12:28
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
EXECUTE sp_rename N'dbo.Configuracao.IdModoEntrega', N'Tmp_IdModoEntregaVendas', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Configuracao.IdGrupoArmazenamento', N'Tmp_IdGrupoArmazenamentoProduto_1', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Configuracao.IdGrupoRastreabilidade', N'Tmp_IdGrupoRastreabilidadeProduto_2', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Configuracao.IdGrupoEstoque', N'Tmp_IdGrupoEstoqueProduto_3', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Configuracao.Tmp_IdModoEntregaVendas', N'IdModoEntregaVendas', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Configuracao.Tmp_IdGrupoArmazenamentoProduto_1', N'IdGrupoArmazenamentoProduto', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Configuracao.Tmp_IdGrupoRastreabilidadeProduto_2', N'IdGrupoRastreabilidadeProduto', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Configuracao.Tmp_IdGrupoEstoqueProduto_3', N'IdGrupoEstoqueProduto', 'COLUMN' 
GO
ALTER TABLE dbo.Configuracao ADD
	IdModoEntregaCompras int NULL,
	IdGrupoRastreabilidadeServico int NULL,
	IdGrupoArmazemServico int NULL,
	IdGrupoEstoqueServico int NULL,
	UsarPadraoEstoque bit NULL,
	UsarPadraoCompras bit NULL,
	UsarPadraoVendas bit NULL
GO
ALTER TABLE dbo.Configuracao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Configuracao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Configuracao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Configuracao', 'Object', 'CONTROL') as Contr_Per 