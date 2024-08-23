/*
   sexta-feira, 10 de julho de 201509:39:57
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
CREATE TABLE dbo.SegmentoBancario
	(
	IdSegmentoBancario int NOT NULL IDENTITY (1, 1),
	Nome varchar(255) NULL,
	Descricao varchar(255) NULL,
	IdProximoSegmento int NULL,
	Obrigatorio bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.SegmentoBancario ADD CONSTRAINT
	PK_SegmentoBancario PRIMARY KEY CLUSTERED 
	(
	IdSegmentoBancario
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.SegmentoBancario SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.SegmentoBancario', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.SegmentoBancario', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.SegmentoBancario', 'Object', 'CONTROL') as Contr_Per 