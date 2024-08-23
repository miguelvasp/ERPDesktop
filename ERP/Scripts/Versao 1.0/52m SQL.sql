/*
   sexta-feira, 3 de julho de 201514:41:50
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
CREATE TABLE dbo.PlanoPagamentoItem
	(
	IdPlanoPagamentoItem int NOT NULL IDENTITY (1, 1),
	IdPlanoPagamento int NULL,
	Quantidade decimal(18, 4) NULL,
	ValorTransacao decimal(18, 4) NULL,
	PorcentagemValor int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.PlanoPagamentoItem ADD CONSTRAINT
	PK_PlanoPagamentoItem PRIMARY KEY CLUSTERED 
	(
	IdPlanoPagamentoItem
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.PlanoPagamentoItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PlanoPagamentoItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PlanoPagamentoItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PlanoPagamentoItem', 'Object', 'CONTROL') as Contr_Per 