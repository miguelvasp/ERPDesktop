--Miguel altera status do pedido compras para varchar(255)






/*
   terça-feira, 23 de junho de 201500:11:40
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
ALTER TABLE dbo.PedidoCompra
	DROP CONSTRAINT FK_PedidoCompra_GrupoImpostoRetido
GO
ALTER TABLE dbo.GrupoImpostoRetido SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoImpostoRetido', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoImpostoRetido', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoImpostoRetido', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompra
	DROP CONSTRAINT FK_PedidoCompra_Empresa
GO
ALTER TABLE dbo.Empresa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Empresa', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Empresa', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Empresa', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompra
	DROP CONSTRAINT FK_PedidoCompra_Fornecedor
GO
ALTER TABLE dbo.Fornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompra
	DROP CONSTRAINT FK_PedidoCompra_TextoPadrao
GO
ALTER TABLE dbo.TextoPadrao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.TextoPadrao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.TextoPadrao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.TextoPadrao', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompra
	DROP CONSTRAINT FK_PedidoCompra_Usuario
GO
ALTER TABLE dbo.Usuario SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Usuario', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Usuario', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Usuario', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompra
	DROP CONSTRAINT FK_PedidoCompra_Royalties
GO
ALTER TABLE dbo.Royalties SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Royalties', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Royalties', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Royalties', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompra
	DROP CONSTRAINT FK_PedidoCompra_GrupoDescontos
GO
ALTER TABLE dbo.GrupoDescontos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoDescontos', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoDescontos', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoDescontos', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompra
	DROP CONSTRAINT FK_PedidoCompra_GrupoEncargos
GO
ALTER TABLE dbo.GrupoEncargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoEncargos', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoEncargos', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoEncargos', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompra
	DROP CONSTRAINT FK_PedidoCompra_CFPS
GO
ALTER TABLE dbo.CFPS SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CFPS', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CFPS', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CFPS', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompra
	DROP CONSTRAINT FK_PedidoCompra_PerfilFornecedor
GO
ALTER TABLE dbo.PerfilFornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PerfilFornecedor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PerfilFornecedor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PerfilFornecedor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompra
	DROP CONSTRAINT FK_PedidoCompra_GrupoFornecedor
GO
ALTER TABLE dbo.GrupoFornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.GrupoFornecedor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.GrupoFornecedor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.GrupoFornecedor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompra
	DROP CONSTRAINT FK_PedidoCompra_CondicaoPagamento
GO
ALTER TABLE dbo.CondicaoPagamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CondicaoPagamento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CondicaoPagamento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CondicaoPagamento', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompra
	DROP CONSTRAINT FK_PedidoCompra_Moeda
GO
ALTER TABLE dbo.Moeda SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Moeda', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_PedidoCompra
	(
	IdPedidoCompra int NOT NULL IDENTITY (1, 1),
	Data datetime NOT NULL,
	IdFornecedor int NOT NULL,
	IdMoeda int NOT NULL,
	DataEntrega datetime NOT NULL,
	Observacao varchar(255) NULL,
	PrazoEntrega varchar(255) NULL,
	IdCondicaoPagamento int NOT NULL,
	Emissao datetime NULL,
	Status varchar(255) NULL,
	IdComprador int NULL,
	IdEmpresa int NULL,
	IdGrupoFornecedor int NULL,
	IdPerfilFornecedor int NULL,
	IdTipoOprecacao int NULL,
	IdCFPS int NULL,
	IdGrupoEncargos int NULL,
	IdGrupoDesconto int NULL,
	IdGrupoFretes int NULL,
	IdRoyalties int NULL,
	IdTextoPadrao int NULL,
	TipoOrdem int NULL,
	IdMetodoPagamento int NULL,
	IdPlanoPagamento int NULL,
	StatusAprovacao int NULL,
	MovimentaEstoque bit NULL,
	CriaTransContabeis bit NULL,
	CalculaRetencao bit NULL,
	DescontaPisCofins bit NULL,
	TituloFinanceiro varchar(255) NULL,
	IdGrupoImposto int NULL,
	IdGrupoImpostoRetido int NULL,
	IdCentroCusto1 int NULL,
	IdCentroCusto2 int NULL,
	IdCentroCusto3 int NULL,
	IdCentroCusto4 int NULL,
	IdCentroCusto5 int NULL,
	IdTransportadora int NULL,
	IdArmazem int NULL,
	IdDeposito int NULL,
	MotivoDevolucao varchar(255) NULL,
	IdContratoComercial int NULL,
	IdOrdemReferencia int NULL,
	NFSE bit NULL,
	RPA bit NULL,
	IdModoEntrega int NULL,
	IdCondicaoEntrega int NULL,
	TipoFrete int NULL,
	PedidoNumero int NULL,
	IdOperacao int NULL,
	CriaTransFinanceiras bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_PedidoCompra SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_PedidoCompra ON
GO
IF EXISTS(SELECT * FROM dbo.PedidoCompra)
	 EXEC('INSERT INTO dbo.Tmp_PedidoCompra (IdPedidoCompra, Data, IdFornecedor, IdMoeda, DataEntrega, Observacao, PrazoEntrega, IdCondicaoPagamento, Emissao, Status, IdComprador, IdEmpresa, IdGrupoFornecedor, IdPerfilFornecedor, IdTipoOprecacao, IdCFPS, IdGrupoEncargos, IdGrupoDesconto, IdGrupoFretes, IdRoyalties, IdTextoPadrao, TipoOrdem, IdMetodoPagamento, IdPlanoPagamento, StatusAprovacao, MovimentaEstoque, CriaTransContabeis, CalculaRetencao, DescontaPisCofins, TituloFinanceiro, IdGrupoImposto, IdGrupoImpostoRetido, IdCentroCusto1, IdCentroCusto2, IdCentroCusto3, IdCentroCusto4, IdCentroCusto5, IdTransportadora, IdArmazem, IdDeposito, MotivoDevolucao, IdContratoComercial, IdOrdemReferencia, NFSE, RPA, IdModoEntrega, IdCondicaoEntrega, TipoFrete, PedidoNumero, IdOperacao, CriaTransFinanceiras)
		SELECT IdPedidoCompra, Data, IdFornecedor, IdMoeda, DataEntrega, Observacao, PrazoEntrega, IdCondicaoPagamento, Emissao, CONVERT(varchar(255), Status), IdComprador, IdEmpresa, IdGrupoFornecedor, IdPerfilFornecedor, IdTipoOprecacao, IdCFPS, IdGrupoEncargos, IdGrupoDesconto, IdGrupoFretes, IdRoyalties, IdTextoPadrao, TipoOrdem, IdMetodoPagamento, IdPlanoPagamento, StatusAprovacao, MovimentaEstoque, CriaTransContabeis, CalculaRetencao, DescontaPisCofins, TituloFinanceiro, IdGrupoImposto, IdGrupoImpostoRetido, IdCentroCusto1, IdCentroCusto2, IdCentroCusto3, IdCentroCusto4, IdCentroCusto5, IdTransportadora, IdArmazem, IdDeposito, MotivoDevolucao, IdContratoComercial, IdOrdemReferencia, NFSE, RPA, IdModoEntrega, IdCondicaoEntrega, TipoFrete, PedidoNumero, IdOperacao, CriaTransFinanceiras FROM dbo.PedidoCompra WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_PedidoCompra OFF
GO
ALTER TABLE dbo.PedidoCompraItem
	DROP CONSTRAINT FK_PedidoCompraItem_PedidoCompra
GO
ALTER TABLE dbo.NotaFiscal
	DROP CONSTRAINT FK_NotaFiscal_PedidoCompra
GO
DROP TABLE dbo.PedidoCompra
GO
EXECUTE sp_rename N'dbo.Tmp_PedidoCompra', N'PedidoCompra', 'OBJECT' 
GO
ALTER TABLE dbo.PedidoCompra ADD CONSTRAINT
	PK_OrdemCompra PRIMARY KEY CLUSTERED 
	(
	IdPedidoCompra
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.PedidoCompra ADD CONSTRAINT
	FK_PedidoCompra_Moeda FOREIGN KEY
	(
	IdMoeda
	) REFERENCES dbo.Moeda
	(
	IdMoeda
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompra ADD CONSTRAINT
	FK_PedidoCompra_CondicaoPagamento FOREIGN KEY
	(
	IdCondicaoPagamento
	) REFERENCES dbo.CondicaoPagamento
	(
	IdCondicaoPagamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompra ADD CONSTRAINT
	FK_PedidoCompra_GrupoFornecedor FOREIGN KEY
	(
	IdGrupoFornecedor
	) REFERENCES dbo.GrupoFornecedor
	(
	IdGrupoFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompra ADD CONSTRAINT
	FK_PedidoCompra_PerfilFornecedor FOREIGN KEY
	(
	IdPerfilFornecedor
	) REFERENCES dbo.PerfilFornecedor
	(
	IdPerfilFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompra ADD CONSTRAINT
	FK_PedidoCompra_CFPS FOREIGN KEY
	(
	IdCFPS
	) REFERENCES dbo.CFPS
	(
	IdCFPS
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompra ADD CONSTRAINT
	FK_PedidoCompra_GrupoEncargos FOREIGN KEY
	(
	IdGrupoEncargos
	) REFERENCES dbo.GrupoEncargos
	(
	IdGrupoEncargos
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompra ADD CONSTRAINT
	FK_PedidoCompra_GrupoDescontos FOREIGN KEY
	(
	IdGrupoDesconto
	) REFERENCES dbo.GrupoDescontos
	(
	IdGrupoDescontos
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompra ADD CONSTRAINT
	FK_PedidoCompra_Royalties FOREIGN KEY
	(
	IdRoyalties
	) REFERENCES dbo.Royalties
	(
	IdRoyalties
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompra ADD CONSTRAINT
	FK_PedidoCompra_Usuario FOREIGN KEY
	(
	IdComprador
	) REFERENCES dbo.Usuario
	(
	IdUsuario
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompra ADD CONSTRAINT
	FK_PedidoCompra_TextoPadrao FOREIGN KEY
	(
	IdTextoPadrao
	) REFERENCES dbo.TextoPadrao
	(
	IdTextoPadrao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompra ADD CONSTRAINT
	FK_PedidoCompra_Fornecedor FOREIGN KEY
	(
	IdFornecedor
	) REFERENCES dbo.Fornecedor
	(
	IdFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompra ADD CONSTRAINT
	FK_PedidoCompra_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompra ADD CONSTRAINT
	FK_PedidoCompra_GrupoImpostoRetido FOREIGN KEY
	(
	IdGrupoImpostoRetido
	) REFERENCES dbo.GrupoImpostoRetido
	(
	IdGrupoImpostoRetido
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoCompra', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoCompra', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoCompra', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.NotaFiscal ADD CONSTRAINT
	FK_NotaFiscal_PedidoCompra FOREIGN KEY
	(
	IdPedidoCompra
	) REFERENCES dbo.PedidoCompra
	(
	IdPedidoCompra
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.NotaFiscal SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.NotaFiscal', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.NotaFiscal', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.NotaFiscal', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompraItem ADD CONSTRAINT
	FK_PedidoCompraItem_PedidoCompra FOREIGN KEY
	(
	IdPedidoCompra
	) REFERENCES dbo.PedidoCompra
	(
	IdPedidoCompra
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompraItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PedidoCompraItem', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PedidoCompraItem', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PedidoCompraItem', 'Object', 'CONTROL') as Contr_Per 