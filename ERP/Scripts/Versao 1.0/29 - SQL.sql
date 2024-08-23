/*
   segunda-feira, 22 de junho de 201511:43:35
   User: 
   Server: MIKE-PC
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
CREATE TABLE dbo.Tmp_AprovacaoNivel
	(
	IdAprovacaoNivel int NOT NULL IDENTITY (1, 1),
	IdAprovacaoDocumento int NULL,
	Nome varchar(255) NULL,
	Sequencia int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_AprovacaoNivel SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_AprovacaoNivel ON
GO
IF EXISTS(SELECT * FROM dbo.AprovacaoNivel)
	 EXEC('INSERT INTO dbo.Tmp_AprovacaoNivel (IdAprovacaoNivel, IdAprovacaoDocumento, Nome, Sequencia)
		SELECT IdAprovacaoNivel, IdAprovacaoDocumento, Nome, Sequencia FROM dbo.AprovacaoNivel WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_AprovacaoNivel OFF
GO
DROP TABLE dbo.AprovacaoNivel
GO
EXECUTE sp_rename N'dbo.Tmp_AprovacaoNivel', N'AprovacaoNivel', 'OBJECT' 
GO
ALTER TABLE dbo.AprovacaoNivel ADD CONSTRAINT
	PK_AprovacaoNivel PRIMARY KEY CLUSTERED 
	(
	IdAprovacaoNivel
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.AprovacaoNivel', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.AprovacaoNivel', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.AprovacaoNivel', 'Object', 'CONTROL') as Contr_Per 