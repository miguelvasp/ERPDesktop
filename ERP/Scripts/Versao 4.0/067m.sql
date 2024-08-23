/*
   quinta-feira, 4 de fevereiro de 201609:28:00
   User: mgasoftware
   Server: mssql.mgasolucoes.com.br
   Database: mgasoftware
   Application: 
*/



-------- miguel ---------
--trocar tipo de dado do tipo de lançamento credito de varchar para inteiro.





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
CREATE TABLE dbo.Tmp_CodigoEncargo
	(
	IdCodigoEncargo int NOT NULL IDENTITY (1, 1),
	Nome varchar(255) NULL,
	Descricao varchar(255) NULL,
	Tipo int NULL,
	IdGrupoImposto int NULL,
	LancamentoTipo int NULL,
	IdContaContabilDebito int NULL,
	CreditoTipoLancamento int NULL,
	IdContaContabilCredito int NULL,
	IncluiNotaFiscal bit NULL,
	IncluiImpostos bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_CodigoEncargo SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_CodigoEncargo ON
GO
IF EXISTS(SELECT * FROM dbo.CodigoEncargo)
	 EXEC('INSERT INTO dbo.Tmp_CodigoEncargo (IdCodigoEncargo, Nome, Descricao, Tipo, IdGrupoImposto, LancamentoTipo, IdContaContabilDebito, CreditoTipoLancamento, IdContaContabilCredito, IncluiNotaFiscal, IncluiImpostos)
		SELECT IdCodigoEncargo, Nome, Descricao, Tipo, IdGrupoImposto, LancamentoTipo, IdContaContabilDebito, CONVERT(int, CreditoTipoLancamento), IdContaContabilCredito, IncluiNotaFiscal, IncluiImpostos FROM dbo.CodigoEncargo WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_CodigoEncargo OFF
GO
ALTER TABLE dbo.GrupoEncargosCodigoEncargo
	DROP CONSTRAINT FK_GrupoEncargosCodigoEncargo_CodigoEncargo
GO
DROP TABLE dbo.CodigoEncargo
GO
EXECUTE sp_rename N'dbo.Tmp_CodigoEncargo', N'CodigoEncargo', 'OBJECT' 
GO
ALTER TABLE dbo.CodigoEncargo ADD CONSTRAINT
	PK_CodigoEncargo PRIMARY KEY CLUSTERED 
	(
	IdCodigoEncargo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoEncargo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoEncargo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoEncargo', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoEncargosCodigoEncargo ADD CONSTRAINT
	FK_GrupoEncargosCodigoEncargo_CodigoEncargo FOREIGN KEY
	(
	IdCodigoEncargo
	) REFERENCES dbo.CodigoEncargo
	(
	IdCodigoEncargo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.GrupoEncargosCodigoEncargo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoEncargosCodigoEncargo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoEncargosCodigoEncargo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoEncargosCodigoEncargo', 'Object', 'CONTROL') as Contr_Per 