USE [mgasoftware]
GO

/****** Object:  Table [dbo].[PedidoVendaContabilidade]    Script Date: 05/16/2016 20:12:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PedidoVendaContabilidade](
	[IdPedidoVendaContabilidade] [int] IDENTITY(1,1) NOT NULL,
	[IdOrigemLancamento] [int] NULL,
	[IdContaContabil] [int] NULL,
	[IdLote] [int] NULL,
	[ValorCredito] [decimal](18, 4) NULL,
	[ValorDebito] [decimal](18, 4) NULL,
	[DataHora] [datetime] NULL,
	[Usuario] [varchar](200) NULL,
	[IdCentroCusto] [int] NULL,
	[IdMoeda] [int] NULL,
	[ValorAjusteDebito] [decimal](18, 4) NULL,
	[ValorAjusteCredito] [decimal](18, 4) NULL,
	[Preco] [decimal](18, 4) NULL,
	[IdRegraDistribuicao] [int] NULL,
	[IdFornecedor] [int] NULL,
	[IdCliente] [int] NULL,
	[IdEmpresa] [int] NULL,
	[Aprovado] [bit] NULL,
	[Data] [datetime] NULL,
	[Aprovador] [varchar](255) NULL,
	[NumeroCheque] [int] NULL,
	[Origem] [varchar](255) NULL,
 CONSTRAINT [PK_PedidoVendaContabilidade] PRIMARY KEY CLUSTERED 
(
	[IdPedidoVendaContabilidade] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PedidoVendaContabilidade]  WITH CHECK ADD  CONSTRAINT [FK_PedidoVendaContabilidade_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO

ALTER TABLE [dbo].[PedidoVendaContabilidade] CHECK CONSTRAINT [FK_PedidoVendaContabilidade_Cliente]
GO

ALTER TABLE [dbo].[PedidoVendaContabilidade]  WITH CHECK ADD  CONSTRAINT [FK_PedidoVendaContabilidade_ContaContabil] FOREIGN KEY([IdContaContabil])
REFERENCES [dbo].[ContaContabil] ([IdContaContabil])
GO

ALTER TABLE [dbo].[PedidoVendaContabilidade] CHECK CONSTRAINT [FK_PedidoVendaContabilidade_ContaContabil]
GO

ALTER TABLE [dbo].[PedidoVendaContabilidade]  WITH CHECK ADD  CONSTRAINT [FK_PedidoVendaContabilidade_Empresa] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresa] ([IdEmpresa])
GO

ALTER TABLE [dbo].[PedidoVendaContabilidade] CHECK CONSTRAINT [FK_PedidoVendaContabilidade_Empresa]
GO

ALTER TABLE [dbo].[PedidoVendaContabilidade]  WITH CHECK ADD  CONSTRAINT [FK_PedidoVendaContabilidade_Fornecedor] FOREIGN KEY([IdFornecedor])
REFERENCES [dbo].[Fornecedor] ([IdFornecedor])
GO

ALTER TABLE [dbo].[PedidoVendaContabilidade] CHECK CONSTRAINT [FK_PedidoVendaContabilidade_Fornecedor]
GO

ALTER TABLE [dbo].[PedidoVendaContabilidade]  WITH CHECK ADD  CONSTRAINT [FK_PedidoVendaContabilidade_Moeda] FOREIGN KEY([IdMoeda])
REFERENCES [dbo].[Moeda] ([IdMoeda])
GO

ALTER TABLE [dbo].[PedidoVendaContabilidade] CHECK CONSTRAINT [FK_PedidoVendaContabilidade_Moeda]
GO

ALTER TABLE [dbo].[PedidoVendaContabilidade]  WITH CHECK ADD  CONSTRAINT [FK_PedidoVendaContabilidade_OrigemLancamento] FOREIGN KEY([IdOrigemLancamento])
REFERENCES [dbo].[OrigemLancamento] ([IdOrigemLancamento])
GO

ALTER TABLE [dbo].[PedidoVendaContabilidade] CHECK CONSTRAINT [FK_PedidoVendaContabilidade_OrigemLancamento]
GO


