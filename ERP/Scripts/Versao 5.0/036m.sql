/*
   segunda-feira, 25 de abril de 201609:41:44
   User: 
   Server: MIKE-PC
   Database: Metso_ProcessamentoFiscal
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
CREATE TABLE dbo.MotivoCorrecao
	(
	IdMotivoCorrecao int NOT NULL IDENTITY (1, 1),
	Titulo varchar(255) NULL,
	Descricao varchar(255) NULL,
	TipoDocumento varchar(255) NULL,
	Classificacao varchar(255) NULL,
	Responsavel varchar(255) NULL,
	IdGroup int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.MotivoCorrecao ADD CONSTRAINT
	PK_MotivoCorrecao PRIMARY KEY CLUSTERED 
	(
	IdMotivoCorrecao
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.MotivoCorrecao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.MotivoCorrecao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.MotivoCorrecao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.MotivoCorrecao', 'Object', 'CONTROL') as Contr_Per 