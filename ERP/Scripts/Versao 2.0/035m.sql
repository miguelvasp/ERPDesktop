/*
   sábado, 29 de agosto de 201517:08:52
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
EXECUTE sp_rename N'dbo.DiarioBomLinha.IdSequenciaConsumo', N'Tmp_IdSequenciaComprovante', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.DiarioBomLinha.Tmp_IdSequenciaComprovante', N'IdSequenciaComprovante', 'COLUMN' 
GO
ALTER TABLE dbo.DiarioBomLinha SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.DiarioBomLinha', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.DiarioBomLinha', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.DiarioBomLinha', 'Object', 'CONTROL') as Contr_Per 