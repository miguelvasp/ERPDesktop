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
ALTER TABLE dbo.GrupoProduto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Funcionario SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CalculoComissao ADD CONSTRAINT
	FK_CalculoComissao_Funcionario FOREIGN KEY
	(
	IdFuncionario
	) REFERENCES dbo.Funcionario
	(
	IdFuncionario
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CalculoComissao ADD CONSTRAINT
	FK_CalculoComissao_GrupoProduto FOREIGN KEY
	(
	IdGrupoProduto
	) REFERENCES dbo.GrupoProduto
	(
	IdGrupoProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CalculoComissao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

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
ALTER TABLE dbo.GrupoVendas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO

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
EXECUTE sp_rename N'dbo.CalculoComissao.IdGrupoFornecdor', N'Tmp_IdGrupoFornecedor_2', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.CalculoComissao.Tmp_IdGrupoFornecedor_2', N'IdGrupoFornecedor', 'COLUMN' 
GO
ALTER TABLE dbo.CalculoComissao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

EXECUTE sp_rename N'dbo.CalculoComissao.IdGrupoVenda', N'Tmp_IdGrupoVendas', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.CalculoComissao.Tmp_IdGrupoVendas', N'IdGrupoVendas', 'COLUMN' 
GO
ALTER TABLE dbo.CalculoComissao ADD CONSTRAINT
	FK_CalculoComissao_GrupoVendas FOREIGN KEY
	(
	IdGrupoVendas
	) REFERENCES dbo.GrupoVendas
	(
	IdGrupoVendas
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CalculoComissao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

