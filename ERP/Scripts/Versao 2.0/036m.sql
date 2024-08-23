/*
   domingo, 30 de agosto de 201514:41:22
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
CREATE TABLE dbo.Tmp_DiarioBOM
	(
	IdDiarioBom int NOT NULL IDENTITY (1, 1),
	TipoDiario int NULL,
	NomeDiario varchar(255) NULL,
	IdOrdemProducao int NULL,
	AceitaErro bit NULL,
	AguardandoCriacao bit NULL,
	ConsumoAutomaticoBOM bit NULL,
	Lancado bit NULL,
	DataLancamento datetime NULL,
	IdSequenciaComprovante int NULL,
	IdSequenciaDiario int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_DiarioBOM SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_DiarioBOM ON
GO
IF EXISTS(SELECT * FROM dbo.DiarioBOM)
	 EXEC('INSERT INTO dbo.Tmp_DiarioBOM (IdDiarioBom, TipoDiario, NomeDiario, IdOrdemProducao, AceitaErro, AguardandoCriacao, ConsumoAutomaticoBOM, Lancado, DataLancamento, IdSequenciaComprovante, IdSequenciaDiario)
		SELECT IdDiarioBom, TipoDiario, NomeDiario, IdOrdemProducao, AceitaErro, AguardandoCriacao, ConsumoAutomaticoBOM, Lancado, DataLancamento, IdSequenciaComprovante, IdSequenciaDiario FROM dbo.DiarioBOM WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_DiarioBOM OFF
GO
DROP TABLE dbo.DiarioBOM
GO
EXECUTE sp_rename N'dbo.Tmp_DiarioBOM', N'DiarioBOM', 'OBJECT' 
GO
COMMIT
select Has_Perms_By_Name(N'dbo.DiarioBOM', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.DiarioBOM', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.DiarioBOM', 'Object', 'CONTROL') as Contr_Per 