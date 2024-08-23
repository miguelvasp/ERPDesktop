USE [mgasoftware]
GO

/****** Object:  Table [dbo].[PedidoVenda]    Script Date: 08/22/2015 17:32:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PedidoVenda](
	[IdPedidoVenda] [int] IDENTITY(1,1) NOT NULL,
	[PedidoNumero] [int] NULL,
	[Data] [datetime] NOT NULL,
	[IdEmpresa] [int] NULL,
	[IdCliente] [int] NOT NULL,
	[IdMoeda] [int] NOT NULL,
	[DataEntrega] [datetime] NOT NULL,
	[PrazoEntrega] [int] NOT NULL,
	[IdEndereco] [int] NOT NULL,
	[IdEnderecoEntrega] [int] NOT NULL,
	[EMail] [varchar] (255) NULL,
	[IdCondicaoPagamento] [int] NOT NULL,
	[IdMetodoPagamento] [int] NULL,
	[IdPlanoPagamento] [int] NULL,
	[DataVencimento] [datetime] NOT NULL,
	[Emissao] [datetime] NULL,
	[Status] [int] NULL,
	[IdGrupoCliente] [int] NULL,
	[IdPerfilCliente] [int] NULL,
	[StatusAprovacao] [int] NULL,
	[IdGrupoEncargos] [int] NULL,
	[IdGrupoDesconto] [int] NULL,
    [DescontoPercentual] [decimal](18, 4) NULL,
    [DescontoVarejista] [decimal](18, 4) NULL,
	[Observacao] [varchar](255) NULL,
	[IdVendedor] [int] NULL,
	[IdGrupoVendas] [int] NULL,
	[IdCodigoJuros] [int] NULL,
	[IdCodigoMultas] [int] NULL,
	[IdCentroCusto1] [int] NULL,
	[IdCentroCusto2] [int] NULL,
	[IdCentroCusto3] [int] NULL,
	[IdCentroCusto4] [int] NULL,
	[IdCentroCusto5] [int] NULL,
	[IdGrupoImposto] [int] NULL,
	[IdGrupoImpostoRetido] [int] NULL,
	[MovimentaEstoque] [bit] NULL,
	[IdModoEntrega] [int] NULL,
	[IdCondicaoEntrega] [int] NULL,
	[TipoFrete] [int] NULL,
	[IdTransportadora] [int] NULL,
    [PlacaVeiculo] [varchar] (15) NULL,
	[IdArmazem] [int] NULL,
	[IdDeposito] [int] NULL,
	[IdOperacao] [int] NULL,
	[IdDocumento] [int] NULL,
	[IdEspecie] [int] NULL,
	[IdCFPS] [int] NULL,
	[Serie] [varchar] (10) NULL,
	[TipoOrdem] [int] NULL,
	[TituloFinanceiro] [bit] NOT NULL,
	[ServicoNoEnderecoEntrega] [varchar] (255) NULL,
	[UsuarioFinal] [bit] NOT NULL,
    [NumeroSuframa] [varchar]  (255) NULL,
    [Suframa] [bit] NOT NULL,
	[MotivoDevolucao] [varchar](255) NULL,
    [CriarTransacoesContabeis] [bit] NOT NULL,
    [CalcularRetencao] [bit] NOT NULL,
    [DescontarPiseCofins] [bit] NOT NULL,
	[IdContratoComercial] [int] NULL,
	[IdOrdemReferencia] [int] NULL,
	[SubstituicaoAdiantada] [varchar](255) NULL,
    [IdTextoPadrao] [int] NULL,
 CONSTRAINT [PK_PedidoVenta] PRIMARY KEY CLUSTERED 
(
	[IdPedidoVenda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
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
ALTER TABLE dbo.Armazem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.DocumentoFiscal SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CFPS SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CodigoJuros SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CondicaoPagamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContratoComercial SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CodigoMultas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Deposito SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Empresa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Especie SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoCliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoDescontos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoEncargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoImpostoRetido SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoVendas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MetodoPagamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ModoEntrega SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Vendedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Transportadora SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TextoPadrao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PlanoPagamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PerfilCliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Moeda SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_PedidoVenda
	(
	IdPedidoVenda int NOT NULL IDENTITY (1, 1),
	PedidoNumero int NULL,
	Data datetime NOT NULL,
	IdEmpresa int NULL,
	IdCliente int NOT NULL,
	IdMoeda int NOT NULL,
	DataEntrega datetime NOT NULL,
	PrazoEntrega int NOT NULL,
	IdEndereco int NOT NULL,
	IdEnderecoEntrega int NOT NULL,
	EMail varchar(255) NULL,
	IdCondicaoPagamento int NOT NULL,
	IdMetodoPagamento int NULL,
	IdPlanoPagamento int NULL,
	DataVencimento datetime NOT NULL,
	Emissao datetime NULL,
	Status int NULL,
	IdGrupoCliente int NULL,
	IdPerfilCliente int NULL,
	StatusAprovacao int NULL,
	IdGrupoEncargos int NULL,
	IdGrupoDesconto int NULL,
	DescontoPercentual decimal(18, 4) NULL,
	DescontoVarejista decimal(18, 4) NULL,
	Observacao varchar(255) NULL,
	IdVendedor int NULL,
	IdGrupoVendas int NULL,
	IdCodigoJuros int NULL,
	IdCodigoMultas int NULL,
	IdCentroCusto1 int NULL,
	IdCentroCusto2 int NULL,
	IdCentroCusto3 int NULL,
	IdCentroCusto4 int NULL,
	IdCentroCusto5 int NULL,
	IdGrupoImposto int NULL,
	IdGrupoImpostoRetido int NULL,
	MovimentaEstoque bit NOT NULL,
	IdModoEntrega int NULL,
	IdCondicaoEntrega int NULL,
	TipoFrete int NULL,
	IdTransportadora int NULL,
	PlacaVeiculo varchar(15) NULL,
	IdArmazem int NULL,
	IdDeposito int NULL,
	IdOperacao int NULL,
	IdDocumentoFiscal int NULL,
	IdEspecie int NULL,
	IdCFPS int NULL,
	Serie varchar(10) NULL,
	TipoOrdem int NULL,
	TituloFinanceiro bit NOT NULL,
	ServicoNoEnderecoEntrega varchar(255) NULL,
	UsuarioFinal bit NOT NULL,
	NumeroSuframa varchar(255) NULL,
	Suframa bit NOT NULL,
	MotivoDevolucao varchar(255) NULL,
	CriarTransacoesContabeis bit NOT NULL,
	CalcularRetencao bit NOT NULL,
	DescontarPiseCofins bit NOT NULL,
	IdContratoComercial int NULL,
	IdOrdemReferencia int NULL,
	SubstituicaoAdiantada varchar(255) NULL,
	IdTextoPadrao int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_PedidoVenda SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_PedidoVenda ON
GO
IF EXISTS(SELECT * FROM dbo.PedidoVenda)
	 EXEC('INSERT INTO dbo.Tmp_PedidoVenda (IdPedidoVenda, PedidoNumero, Data, IdEmpresa, IdCliente, IdMoeda, DataEntrega, PrazoEntrega, IdEndereco, IdEnderecoEntrega, EMail, IdCondicaoPagamento, IdMetodoPagamento, IdPlanoPagamento, DataVencimento, Emissao, Status, IdGrupoCliente, IdPerfilCliente, StatusAprovacao, IdGrupoEncargos, IdGrupoDesconto, DescontoPercentual, DescontoVarejista, Observacao, IdVendedor, IdGrupoVendas, IdCodigoJuros, IdCodigoMultas, IdCentroCusto1, IdCentroCusto2, IdCentroCusto3, IdCentroCusto4, IdCentroCusto5, IdGrupoImposto, IdGrupoImpostoRetido, MovimentaEstoque, IdModoEntrega, IdCondicaoEntrega, TipoFrete, IdTransportadora, PlacaVeiculo, IdArmazem, IdDeposito, IdOperacao, IdDocumentoFiscal, IdEspecie, IdCFPS, Serie, TipoOrdem, TituloFinanceiro, ServicoNoEnderecoEntrega, UsuarioFinal, NumeroSuframa, Suframa, MotivoDevolucao, CriarTransacoesContabeis, CalcularRetencao, DescontarPiseCofins, IdContratoComercial, IdOrdemReferencia, SubstituicaoAdiantada, IdTextoPadrao)
		SELECT IdPedidoVenda, PedidoNumero, Data, IdEmpresa, IdCliente, IdMoeda, DataEntrega, PrazoEntrega, IdEndereco, IdEnderecoEntrega, EMail, IdCondicaoPagamento, IdMetodoPagamento, IdPlanoPagamento, DataVencimento, Emissao, Status, IdGrupoCliente, IdPerfilCliente, StatusAprovacao, IdGrupoEncargos, IdGrupoDesconto, DescontoPercentual, DescontoVarejista, Observacao, IdVendedor, IdGrupoVendas, IdCodigoJuros, IdCodigoMultas, IdCentroCusto1, IdCentroCusto2, IdCentroCusto3, IdCentroCusto4, IdCentroCusto5, IdGrupoImposto, IdGrupoImpostoRetido, MovimentaEstoque, IdModoEntrega, IdCondicaoEntrega, TipoFrete, IdTransportadora, PlacaVeiculo, IdArmazem, IdDeposito, IdOperacao, IdDocumento, IdEspecie, IdCFPS, Serie, TipoOrdem, TituloFinanceiro, ServicoNoEnderecoEntrega, UsuarioFinal, NumeroSuframa, Suframa, MotivoDevolucao, CriarTransacoesContabeis, CalcularRetencao, DescontarPiseCofins, IdContratoComercial, IdOrdemReferencia, SubstituicaoAdiantada, IdTextoPadrao FROM dbo.PedidoVenda WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_PedidoVenda OFF
GO
DROP TABLE dbo.PedidoVenda
GO
EXECUTE sp_rename N'dbo.Tmp_PedidoVenda', N'PedidoVenda', 'OBJECT' 
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	PK_PedidoVenta PRIMARY KEY CLUSTERED 
	(
	IdPedidoVenda
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_Moeda FOREIGN KEY
	(
	IdMoeda
	) REFERENCES dbo.Moeda
	(
	IdMoeda
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_PerfilCliente FOREIGN KEY
	(
	IdPerfilCliente
	) REFERENCES dbo.PerfilCliente
	(
	IdPerfilCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_PlanoPagamento FOREIGN KEY
	(
	IdPlanoPagamento
	) REFERENCES dbo.PlanoPagamento
	(
	IdPlanoPagamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_TextoPadrao FOREIGN KEY
	(
	IdTextoPadrao
	) REFERENCES dbo.TextoPadrao
	(
	IdTextoPadrao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_Transportadora FOREIGN KEY
	(
	IdTransportadora
	) REFERENCES dbo.Transportadora
	(
	IdTransportadora
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_Vendedor FOREIGN KEY
	(
	IdVendedor
	) REFERENCES dbo.Vendedor
	(
	IdVendedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_Cliente FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Cliente
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_ModoEntrega FOREIGN KEY
	(
	IdModoEntrega
	) REFERENCES dbo.ModoEntrega
	(
	IdModoEntrega
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_MetodoPagamento FOREIGN KEY
	(
	IdMetodoPagamento
	) REFERENCES dbo.MetodoPagamento
	(
	IdMetodoPagamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_GrupoVendas FOREIGN KEY
	(
	IdGrupoVendas
	) REFERENCES dbo.GrupoVendas
	(
	IdGrupoVendas
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_GrupoImpostoRetido FOREIGN KEY
	(
	IdGrupoImpostoRetido
	) REFERENCES dbo.GrupoImpostoRetido
	(
	IdGrupoImpostoRetido
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_GrupoImposto FOREIGN KEY
	(
	IdGrupoImposto
	) REFERENCES dbo.GrupoImposto
	(
	IdGrupoImposto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_GrupoEncargos FOREIGN KEY
	(
	IdGrupoEncargos
	) REFERENCES dbo.GrupoEncargos
	(
	IdGrupoEncargos
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_GrupoDescontos FOREIGN KEY
	(
	IdGrupoDesconto
	) REFERENCES dbo.GrupoDescontos
	(
	IdGrupoDescontos
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_GrupoCliente FOREIGN KEY
	(
	IdGrupoCliente
	) REFERENCES dbo.GrupoCliente
	(
	IdGrupoCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_Especie FOREIGN KEY
	(
	IdEspecie
	) REFERENCES dbo.Especie
	(
	IdEspecie
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_Deposito FOREIGN KEY
	(
	IdDeposito
	) REFERENCES dbo.Deposito
	(
	IdDeposito
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_CodigoMultas FOREIGN KEY
	(
	IdCodigoMultas
	) REFERENCES dbo.CodigoMultas
	(
	IdCodigoMultas
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_ContratoComercial FOREIGN KEY
	(
	IdContratoComercial
	) REFERENCES dbo.ContratoComercial
	(
	IdContratoComercial
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_CondicaoPagamento FOREIGN KEY
	(
	IdCondicaoPagamento
	) REFERENCES dbo.CondicaoPagamento
	(
	IdCondicaoPagamento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_CodigoJuros FOREIGN KEY
	(
	IdCodigoJuros
	) REFERENCES dbo.CodigoJuros
	(
	IdCodigoJuros
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_CFPS FOREIGN KEY
	(
	IdCFPS
	) REFERENCES dbo.CFPS
	(
	IdCFPS
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_DocumentoFiscal FOREIGN KEY
	(
	IdDocumentoFiscal
	) REFERENCES dbo.DocumentoFiscal
	(
	IdDocumentoFiscal
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_Armazem FOREIGN KEY
	(
	IdArmazem
	) REFERENCES dbo.Armazem
	(
	IdArmazem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
