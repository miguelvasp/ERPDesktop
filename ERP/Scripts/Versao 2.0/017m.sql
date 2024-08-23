/*
   terça-feira, 28 de julho de 201515:41:57
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
ALTER TABLE dbo.Unidade SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Unidade', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Unidade', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Unidade', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ValoresCentroCusto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ValoresCentroCusto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ValoresCentroCusto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ValoresCentroCusto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Localizacao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Localizacao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Localizacao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Localizacao', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Lote SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Lote', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Lote', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Lote', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Armazem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Armazem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Armazem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Armazem', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.VariantesEstilo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesEstilo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesEstilo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesEstilo', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.VariantesCor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesCor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesCor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesCor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.VariantesTamanho SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesTamanho', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesTamanho', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesTamanho', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.VariantesConfig SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VariantesConfig', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VariantesConfig', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VariantesConfig', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PerfilProducao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PerfilProducao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PerfilProducao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PerfilProducao', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Roteiro SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Roteiro', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Roteiro', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Roteiro', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Produto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Produto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Produto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListaMateriais SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ListaMateriais', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ListaMateriais', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ListaMateriais', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.OrdemProducao ADD CONSTRAINT
	FK_OrdemProducao_ListaMateriais FOREIGN KEY
	(
	IdListaMateriais
	) REFERENCES dbo.ListaMateriais
	(
	IdListaMateriais
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducao ADD CONSTRAINT
	FK_OrdemProducao_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducao ADD CONSTRAINT
	FK_OrdemProducao_Roteiro FOREIGN KEY
	(
	IdRoteiro
	) REFERENCES dbo.Roteiro
	(
	IdRoteiro
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducao ADD CONSTRAINT
	FK_OrdemProducao_PerfilProducao FOREIGN KEY
	(
	IdPerfilProducao
	) REFERENCES dbo.PerfilProducao
	(
	IdPerfilProducao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducao ADD CONSTRAINT
	FK_OrdemProducao_VariantesConfig FOREIGN KEY
	(
	IdConfiguracao
	) REFERENCES dbo.VariantesConfig
	(
	IdVariantesConfig
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducao ADD CONSTRAINT
	FK_OrdemProducao_VariantesTamanho FOREIGN KEY
	(
	IdTamanho
	) REFERENCES dbo.VariantesTamanho
	(
	IdVariantesTamanho
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducao ADD CONSTRAINT
	FK_OrdemProducao_VariantesCor FOREIGN KEY
	(
	IdCor
	) REFERENCES dbo.VariantesCor
	(
	IdVariantesCor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducao ADD CONSTRAINT
	FK_OrdemProducao_VariantesEstilo FOREIGN KEY
	(
	IdEstilo
	) REFERENCES dbo.VariantesEstilo
	(
	IdVariantesEstilo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducao ADD CONSTRAINT
	FK_OrdemProducao_Armazem FOREIGN KEY
	(
	IdArmazem
	) REFERENCES dbo.Armazem
	(
	IdArmazem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducao ADD CONSTRAINT
	FK_OrdemProducao_Lote FOREIGN KEY
	(
	IdLote
	) REFERENCES dbo.Lote
	(
	IdLote
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducao ADD CONSTRAINT
	FK_OrdemProducao_Localizacao FOREIGN KEY
	(
	IdLocalizacao
	) REFERENCES dbo.Localizacao
	(
	IdLocalizacao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.OrdemProducao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.OrdemProducao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.OrdemProducao', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.OrdemProducaoLinha ADD CONSTRAINT
	FK_OrdemProducaoLinha_OrdemProducao FOREIGN KEY
	(
	IdOrdemProducao
	) REFERENCES dbo.OrdemProducao
	(
	IdOrdemProducao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducaoLinha ADD CONSTRAINT
	FK_OrdemProducaoLinha_ListaMateriais FOREIGN KEY
	(
	IdListaMateriais
	) REFERENCES dbo.ListaMateriais
	(
	IdListaMateriais
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducaoLinha ADD CONSTRAINT
	FK_OrdemProducaoLinha_Unidade FOREIGN KEY
	(
	IdUnidade
	) REFERENCES dbo.Unidade
	(
	IdUnidade
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducaoLinha ADD CONSTRAINT
	FK_OrdemProducaoLinha_VariantesConfig FOREIGN KEY
	(
	IdConfiguracao
	) REFERENCES dbo.VariantesConfig
	(
	IdVariantesConfig
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducaoLinha ADD CONSTRAINT
	FK_OrdemProducaoLinha_VariantesTamanho FOREIGN KEY
	(
	IdTamanho
	) REFERENCES dbo.VariantesTamanho
	(
	IdVariantesTamanho
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducaoLinha ADD CONSTRAINT
	FK_OrdemProducaoLinha_VariantesCor FOREIGN KEY
	(
	IdCor
	) REFERENCES dbo.VariantesCor
	(
	IdVariantesCor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducaoLinha ADD CONSTRAINT
	FK_OrdemProducaoLinha_VariantesEstilo FOREIGN KEY
	(
	IdEstilo
	) REFERENCES dbo.VariantesEstilo
	(
	IdVariantesEstilo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducaoLinha ADD CONSTRAINT
	FK_OrdemProducaoLinha_Armazem FOREIGN KEY
	(
	IdArmazem
	) REFERENCES dbo.Armazem
	(
	IdArmazem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducaoLinha ADD CONSTRAINT
	FK_OrdemProducaoLinha_Lote FOREIGN KEY
	(
	IdLote
	) REFERENCES dbo.Lote
	(
	IdLote
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducaoLinha ADD CONSTRAINT
	FK_OrdemProducaoLinha_Localizacao FOREIGN KEY
	(
	IdLocalizacao
	) REFERENCES dbo.Localizacao
	(
	IdLocalizacao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducaoLinha SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.OrdemProducaoLinha', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.OrdemProducaoLinha', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.OrdemProducaoLinha', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.OrdemProducaoLinhaCentroCusto ADD CONSTRAINT
	FK_OrdemProducaoLinhaCentroCusto_OrdemProducaoLinha FOREIGN KEY
	(
	IdOrdemProducaoLinha
	) REFERENCES dbo.OrdemProducaoLinha
	(
	IdOrdemProducaoLinha
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducaoLinhaCentroCusto ADD CONSTRAINT
	FK_OrdemProducaoLinhaCentroCusto_ValoresCentroCusto FOREIGN KEY
	(
	IdValoresCentroCusto
	) REFERENCES dbo.ValoresCentroCusto
	(
	IdValoresCentroCusto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducaoLinhaCentroCusto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.OrdemProducaoLinhaCentroCusto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.OrdemProducaoLinhaCentroCusto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.OrdemProducaoLinhaCentroCusto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.OrdemProducaoCentroCusto ADD CONSTRAINT
	FK_OrdemProducaoCentroCusto_OrdemProducao FOREIGN KEY
	(
	IdOrdemProducao
	) REFERENCES dbo.OrdemProducao
	(
	IdOrdemProducao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducaoCentroCusto ADD CONSTRAINT
	FK_OrdemProducaoCentroCusto_ValoresCentroCusto FOREIGN KEY
	(
	IdValoresCentroCusto
	) REFERENCES dbo.ValoresCentroCusto
	(
	IdValoresCentroCusto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducaoCentroCusto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.OrdemProducaoCentroCusto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.OrdemProducaoCentroCusto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.OrdemProducaoCentroCusto', 'Object', 'CONTROL') as Contr_Per 