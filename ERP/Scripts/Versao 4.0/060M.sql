/*
   sexta-feira, 22 de janeiro de 201610:56:35
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
ALTER TABLE dbo.CodigoEncargo ADD
	LancamentoTipo int NULL,
	IdContaContabilDebito int NULL,
	CreditoTipoLancamento varchar(255) NULL,
	IdContaContabilCredito int NULL,
	IncluiNotaFiscal bit NULL,
	IncluiImpostos bit NULL
GO
ALTER TABLE dbo.CodigoEncargo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoEncargo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoEncargo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoEncargo', 'Object', 'CONTROL') as Contr_Per 