/*
   terça-feira, 21 de junho de 201618:31:49
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
ALTER TABLE dbo.NotaFiscalItem ADD
	SituacaoTribPIS varchar(50) NULL,
	BasePIS decimal(18, 4) NULL,
	AliquotaPIS decimal(18, 2) NULL,
	ValorPIS decimal(18, 4) NULL,
	SituacaoTribCOFINS varchar(50) NULL,
	BaseCOFINS decimal(18, 4) NULL,
	AliquotaCOFINS decimal(18, 2) NULL,
	ValorCOFINS decimal(18, 4) NULL,
	EAN varchar(50) NULL,
	indTot int NULL,
	Origem int NULL
GO
ALTER TABLE dbo.NotaFiscalItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.NotaFiscalItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.NotaFiscalItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.NotaFiscalItem', 'Object', 'CONTROL') as Contr_Per 