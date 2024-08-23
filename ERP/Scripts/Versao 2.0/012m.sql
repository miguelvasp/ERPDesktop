/*
   domingo, 26 de julho de 201516:57:12
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
ALTER TABLE dbo.RoteiroOperacao
	DROP CONSTRAINT FK_RoteiroOperacao_Roteiro
GO
ALTER TABLE dbo.Roteiro SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Roteiro', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Roteiro', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Roteiro', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_RoteiroOperacao
	(
	IdRoteiroOperacao int NOT NULL IDENTITY (1, 1),
	IdRoteiro int NULL,
	Atividade varchar(255) NULL,
	Prioridade int NULL,
	Sequencia int NULL,
	Acumulado decimal(18, 4) NULL,
	PorcentagemSucata int NULL,
	Proximo int NULL,
	TaxaHoraTrabalhoTarefa int NULL,
	TipoVinculo int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_RoteiroOperacao SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_RoteiroOperacao ON
GO
IF EXISTS(SELECT * FROM dbo.RoteiroOperacao)
	 EXEC('INSERT INTO dbo.Tmp_RoteiroOperacao (IdRoteiroOperacao, IdRoteiro, Atividade, Prioridade, Sequencia, Acumulado, PorcentagemSucata, Proximo, TaxaHoraTrabalhoTarefa, TipoVinculo)
		SELECT IdRoteiroOperacao, IdRoteiro, CONVERT(varchar(255), Atividade), Prioridade, Sequencia, Acumulado, PorcentagemSucata, Proximo, TaxaHoraTrabalhoTarefa, TipoVinculo FROM dbo.RoteiroOperacao WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_RoteiroOperacao OFF
GO
ALTER TABLE dbo.RoteiroOperacaoLinhas
	DROP CONSTRAINT FK_RoteiroOperacaoLinhas_RoteiroOperacao
GO
DROP TABLE dbo.RoteiroOperacao
GO
EXECUTE sp_rename N'dbo.Tmp_RoteiroOperacao', N'RoteiroOperacao', 'OBJECT' 
GO
ALTER TABLE dbo.RoteiroOperacao ADD CONSTRAINT
	PK_RoteiroOperacao PRIMARY KEY CLUSTERED 
	(
	IdRoteiroOperacao
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.RoteiroOperacao ADD CONSTRAINT
	FK_RoteiroOperacao_Roteiro FOREIGN KEY
	(
	IdRoteiro
	) REFERENCES dbo.Roteiro
	(
	IdRoteiro
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.RoteiroOperacao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.RoteiroOperacao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.RoteiroOperacao', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.RoteiroOperacaoLinhas ADD CONSTRAINT
	FK_RoteiroOperacaoLinhas_RoteiroOperacao FOREIGN KEY
	(
	IdRoteiroOperacao
	) REFERENCES dbo.RoteiroOperacao
	(
	IdRoteiroOperacao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RoteiroOperacaoLinhas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.RoteiroOperacaoLinhas', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.RoteiroOperacaoLinhas', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.RoteiroOperacaoLinhas', 'Object', 'CONTROL') as Contr_Per 