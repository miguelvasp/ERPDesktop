/*
   segunda-feira, 15 de fevereiro de 201611:33:09
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
ALTER TABLE dbo.ContaContabil
	DROP CONSTRAINT FK_ContaContabil_ContaPlanoReferencial
GO
ALTER TABLE dbo.ContaPlanoReferencial SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContaPlanoReferencial', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContaPlanoReferencial', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContaPlanoReferencial', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContaContabil
	DROP CONSTRAINT FK_ContaContabil_ContaGerencial
GO
ALTER TABLE dbo.ContaContabil
	DROP CONSTRAINT FK_ContaContabil_ContaGerencial2
GO
ALTER TABLE dbo.ContaGerencial SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContaGerencial', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContaGerencial', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContaGerencial', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContaContabil
	DROP CONSTRAINT FK_ContaContabil_Moeda
GO
ALTER TABLE dbo.Moeda SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_ContaContabil
	(
	IdContaContabil int NOT NULL IDENTITY (1, 1),
	Codigo varchar(255) NULL,
	Descricao varchar(255) NULL,
	IdContaTipoLancamento int NULL,
	PropostaDEBCRE int NULL,
	Fechar bit NULL,
	IdContaHierarquia int NULL,
	IdContaConsolidacao int NULL,
	IdMoeda int NULL,
	IdTipoConta int NULL,
	IdContaPlanoReferencial int NULL,
	DePara varchar(255) NULL,
	Natureza int NULL,
	Nivel int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_ContaContabil SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_ContaContabil ON
GO
IF EXISTS(SELECT * FROM dbo.ContaContabil)
	 EXEC('INSERT INTO dbo.Tmp_ContaContabil (IdContaContabil, Codigo, Descricao, IdContaTipoLancamento, PropostaDEBCRE, Fechar, IdContaHierarquia, IdContaConsolidacao, IdMoeda, IdTipoConta, IdContaPlanoReferencial, DePara, Natureza, Nivel)
		SELECT IdContaContabil, Codigo, Descricao, IdContaTipoLancamento, PropostaDEBCRE, Fechar, IdContaHierarquia, IdContaConsolidacao, IdMoeda, IdTipoConta, IdContaPlanoReferencial, DePara, Natureza, Nivel FROM dbo.ContaContabil WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_ContaContabil OFF
GO
ALTER TABLE dbo.MovimentacaoBancaria
	DROP CONSTRAINT FK_MovimentacaoBancaria_ContaContabil
GO
ALTER TABLE dbo.ContasPagar
	DROP CONSTRAINT FK_ContasPagar_ContaContabil
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto
	DROP CONSTRAINT FK_PedidoVendaItemApuracaoImposto_ContaContabil
GO
ALTER TABLE dbo.CodigoImpostoRetido
	DROP CONSTRAINT FK_CodigoImpostoRetido_ContaContabil
GO
ALTER TABLE dbo.CodigoImpostoRetido
	DROP CONSTRAINT FK_CodigoImpostoRetido_ContaContabil1
GO
ALTER TABLE dbo.CodigoImpostoRetido
	DROP CONSTRAINT FK_CodigoImpostoRetido_ContaContabil2
GO
ALTER TABLE dbo.CodigoImpostoRetido
	DROP CONSTRAINT FK_CodigoImpostoRetido_ContaContabil3
GO
ALTER TABLE dbo.PedidoCompraItemApuracaoImposto
	DROP CONSTRAINT FK_PedidoCompraItemApuracaoImposto_ContaContabil
GO
ALTER TABLE dbo.GrupoLancamentoContabil
	DROP CONSTRAINT FK_GrupoLancamentoContabil_ContaContabil
GO
ALTER TABLE dbo.GrupoLancamentoContabil
	DROP CONSTRAINT FK_GrupoLancamentoContabil_ContaContabil1
GO
ALTER TABLE dbo.GrupoLancamentoContabil
	DROP CONSTRAINT FK_GrupoLancamentoContabil_ContaContabil2
GO
ALTER TABLE dbo.GrupoLancamentoContabil
	DROP CONSTRAINT FK_GrupoLancamentoContabil_ContaContabil3
GO
ALTER TABLE dbo.GrupoLancamentoContabil
	DROP CONSTRAINT FK_GrupoLancamentoContabil_ContaContabil4
GO
ALTER TABLE dbo.GrupoLancamentoContabil
	DROP CONSTRAINT FK_GrupoLancamentoContabil_ContaContabil5
GO
ALTER TABLE dbo.GrupoLancamentoContabil
	DROP CONSTRAINT FK_GrupoLancamentoContabil_ContaContabil6
GO
ALTER TABLE dbo.GrupoLancamentoContabil
	DROP CONSTRAINT FK_GrupoLancamentoContabil_ContaContabil7
GO
ALTER TABLE dbo.DescontoaVista
	DROP CONSTRAINT FK_DescontoaVista_ContaContabil
GO
ALTER TABLE dbo.DescontoaVista
	DROP CONSTRAINT FK_DescontoaVista_ContaContabil1
GO
ALTER TABLE dbo.LancamentoAtivo
	DROP CONSTRAINT FK_LancamentoAtivo_ContaContabil
GO
ALTER TABLE dbo.LancamentoAtivo
	DROP CONSTRAINT FK_LancamentoAtivo_ContaContabil1
GO
ALTER TABLE dbo.Recursos
	DROP CONSTRAINT FK_Recursos_ContaContabil
GO
ALTER TABLE dbo.Lancamento
	DROP CONSTRAINT FK_Lancamento_ContaContabil
GO
ALTER TABLE dbo.Recursos
	DROP CONSTRAINT FK_Recursos_ContaContabil1
GO
ALTER TABLE dbo.Recursos
	DROP CONSTRAINT FK_Recursos_ContaContabil2
GO
ALTER TABLE dbo.Recursos
	DROP CONSTRAINT FK_Recursos_ContaContabil3
GO
ALTER TABLE dbo.TipoOperacaoBancaria
	DROP CONSTRAINT FK_TipoOperacaoBancaria_ContaContabil
GO
ALTER TABLE dbo.ContasReceber
	DROP CONSTRAINT FK_ContasReceber_ContaContabil
GO
DROP TABLE dbo.ContaContabil
GO
EXECUTE sp_rename N'dbo.Tmp_ContaContabil', N'ContaContabil', 'OBJECT' 
GO
ALTER TABLE dbo.ContaContabil ADD CONSTRAINT
	PK_ContasContaveis PRIMARY KEY CLUSTERED 
	(
	IdContaContabil
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ContaContabil ADD CONSTRAINT
	FK_ContaContabil_Moeda FOREIGN KEY
	(
	IdMoeda
	) REFERENCES dbo.Moeda
	(
	IdMoeda
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContaContabil ADD CONSTRAINT
	FK_ContaContabil_ContaGerencial FOREIGN KEY
	(
	IdContaConsolidacao
	) REFERENCES dbo.ContaGerencial
	(
	IdContaGerencial
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContaContabil ADD CONSTRAINT
	FK_ContaContabil_ContaGerencial2 FOREIGN KEY
	(
	IdContaTipoLancamento
	) REFERENCES dbo.ContaGerencial
	(
	IdContaGerencial
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContaContabil ADD CONSTRAINT
	FK_ContaContabil_ContaPlanoReferencial FOREIGN KEY
	(
	IdContaPlanoReferencial
	) REFERENCES dbo.ContaPlanoReferencial
	(
	IdContaPlanoReferencial
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContaContabil', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContasReceber ADD CONSTRAINT
	FK_ContasReceber_ContaContabil FOREIGN KEY
	(
	IdContaContabil
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasReceber SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasReceber', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasReceber', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasReceber', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.TipoOperacaoBancaria ADD CONSTRAINT
	FK_TipoOperacaoBancaria_ContaContabil FOREIGN KEY
	(
	IdContaContabil
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TipoOperacaoBancaria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.TipoOperacaoBancaria', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.TipoOperacaoBancaria', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.TipoOperacaoBancaria', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Lancamento ADD CONSTRAINT
	FK_Lancamento_ContaContabil FOREIGN KEY
	(
	IdContaContabil
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Lancamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Lancamento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Lancamento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Lancamento', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Recursos ADD CONSTRAINT
	FK_Recursos_ContaContabil FOREIGN KEY
	(
	IdContaContabilCusto
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Recursos ADD CONSTRAINT
	FK_Recursos_ContaContabil1 FOREIGN KEY
	(
	IdContaContabilContraCusto
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Recursos ADD CONSTRAINT
	FK_Recursos_ContaContabil2 FOREIGN KEY
	(
	IdContaContabilWIP
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Recursos ADD CONSTRAINT
	FK_Recursos_ContaContabil3 FOREIGN KEY
	(
	IdContaContabilContaPartidaWIP
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Recursos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Recursos', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Recursos', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Recursos', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.LancamentoAtivo ADD CONSTRAINT
	FK_LancamentoAtivo_ContaContabil FOREIGN KEY
	(
	IdContaContabilPartida
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.LancamentoAtivo ADD CONSTRAINT
	FK_LancamentoAtivo_ContaContabil1 FOREIGN KEY
	(
	IdContaContabilContraPartida
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.LancamentoAtivo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.LancamentoAtivo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.LancamentoAtivo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.LancamentoAtivo', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.DescontoaVista ADD CONSTRAINT
	FK_DescontoaVista_ContaContabil FOREIGN KEY
	(
	IdContaContabilCliente
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.DescontoaVista ADD CONSTRAINT
	FK_DescontoaVista_ContaContabil1 FOREIGN KEY
	(
	IdContaContabilFornecedor
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.DescontoaVista SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.DescontoaVista', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.DescontoaVista', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.DescontoaVista', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoLancamentoContabil ADD CONSTRAINT
	FK_GrupoLancamentoContabil_ContaContabil FOREIGN KEY
	(
	IdContaLiquidacao
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.GrupoLancamentoContabil ADD CONSTRAINT
	FK_GrupoLancamentoContabil_ContaContabil1 FOREIGN KEY
	(
	IdDespesaComImposto
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.GrupoLancamentoContabil ADD CONSTRAINT
	FK_GrupoLancamentoContabil_ContaContabil2 FOREIGN KEY
	(
	IdDespesasImpostoUso
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.GrupoLancamentoContabil ADD CONSTRAINT
	FK_GrupoLancamentoContabil_ContaContabil3 FOREIGN KEY
	(
	IdImpostoAPagar
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.GrupoLancamentoContabil ADD CONSTRAINT
	FK_GrupoLancamentoContabil_ContaContabil4 FOREIGN KEY
	(
	IdImpostoAReceber
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.GrupoLancamentoContabil ADD CONSTRAINT
	FK_GrupoLancamentoContabil_ContaContabil5 FOREIGN KEY
	(
	IdImpostoReceberCurtoPrazo
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.GrupoLancamentoContabil ADD CONSTRAINT
	FK_GrupoLancamentoContabil_ContaContabil6 FOREIGN KEY
	(
	IdImpostoReceberLongoPrazo
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.GrupoLancamentoContabil ADD CONSTRAINT
	FK_GrupoLancamentoContabil_ContaContabil7 FOREIGN KEY
	(
	IdImpostoSobreOUsoPagar
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.GrupoLancamentoContabil SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoLancamentoContabil', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoLancamentoContabil', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoLancamentoContabil', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItemApuracaoImposto ADD CONSTRAINT
	FK_PedidoCompraItemApuracaoImposto_ContaContabil FOREIGN KEY
	(
	IdContaContabil
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItemApuracaoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoCompraItemApuracaoImposto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoCompraItemApuracaoImposto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoCompraItemApuracaoImposto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CodigoImpostoRetido ADD CONSTRAINT
	FK_CodigoImpostoRetido_ContaContabil FOREIGN KEY
	(
	IdContaContabil
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CodigoImpostoRetido ADD CONSTRAINT
	FK_CodigoImpostoRetido_ContaContabil1 FOREIGN KEY
	(
	IdContaContabilLiquidacao
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CodigoImpostoRetido ADD CONSTRAINT
	FK_CodigoImpostoRetido_ContaContabil2 FOREIGN KEY
	(
	IdContaContabilParametrosCalculo
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CodigoImpostoRetido ADD CONSTRAINT
	FK_CodigoImpostoRetido_ContaContabil3 FOREIGN KEY
	(
	IdContaContabilRetidoAReceber
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CodigoImpostoRetido SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CodigoImpostoRetido', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CodigoImpostoRetido', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CodigoImpostoRetido', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto ADD CONSTRAINT
	FK_PedidoVendaItemApuracaoImposto_ContaContabil FOREIGN KEY
	(
	IdContaContabil
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItemApuracaoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoVendaItemApuracaoImposto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItemApuracaoImposto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoVendaItemApuracaoImposto', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContasPagar ADD CONSTRAINT
	FK_ContasPagar_ContaContabil FOREIGN KEY
	(
	IdContaContabil
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContasPagar SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContasPagar', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContasPagar', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContasPagar', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.MovimentacaoBancaria ADD CONSTRAINT
	FK_MovimentacaoBancaria_ContaContabil FOREIGN KEY
	(
	IdContaContabil
	) REFERENCES dbo.ContaContabil
	(
	IdContaContabil
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MovimentacaoBancaria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.MovimentacaoBancaria', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.MovimentacaoBancaria', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.MovimentacaoBancaria', 'Object', 'CONTROL') as Contr_Per 