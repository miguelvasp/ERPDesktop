

/****** Object:  Table [dbo].[PedidoCompraItemApuracaoImposto]    Script Date: 01/25/2016 16:17:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PedidoCompraItemApuracaoImposto](
	[IdPedidoCompraItemApuracaoImposto] [int] IDENTITY(1,1) NOT NULL,
	[IdPedidoCompraItem] [int] NULL,
	[DataLancamento] [datetime] NULL,
	[DataDocumento] [datetime] NULL,
	[IdNotaFiscal] [int] NULL,
	[NotaFiscalNumero] [varchar](255) NULL,
	[DataVencimentoImposto] [datetime] NULL,
	[DataRegistroIVA] [datetime] NULL,
	[IdCodigoImposto] [int] NULL,
	[IdCodigoTributacao] [int] NULL,
	[IdCodigoTributacaoAjustado] [int] NULL,
	[ValorFiscal] [decimal](18, 4) NULL,
	[ValorFiscalAjustado] [decimal](18, 4) NULL,
	[Aliquota] [decimal](18, 2) NULL,
	[Quantidade] [decimal](18, 4) NULL,
	[IdMoeda] [int] NULL,
	[PercentualDaDiferencaICMS] [decimal](18, 4) NULL,
	[PercentualDeReducaoImposto] [decimal](18, 4) NULL,
	[EncargoImposto] [decimal](18, 4) NULL,
	[BaseValor] [decimal](18, 4) NULL,
	[BaseValorAjustado] [decimal](18, 4) NULL,
	[OutroValorBase] [decimal](18, 4) NULL,
	[OutroValorImposto] [decimal](18, 4) NULL,
	[ValorBaseIsencao] [decimal](18, 4) NULL,
	[ValorIsencaoImposto] [decimal](18, 4) NULL,
	[ValorImposto] [decimal](18, 4) NULL,
	[ValorAjustado] [decimal](18, 4) NULL,
	[IdCodigoIsencao] [int] NULL,
	[IdJurisdicaoImposto] [int] NULL,
	[DirecaoImposto] [int] NULL,
	[Automatico] [bit] NULL,
	[IdContaContabil] [int] NULL,
	[ImpostoRetido] [bit] NULL,
	[ImpostoImportacaoDireta] [bit] NULL,
	[EntidadeLancamentoImpostoIntercompanhia] [int] NULL,
	[IdGrupoImposto] [int] NULL,
	[IdGrupoImpostoItem] [int] NULL,
	[GST_HST] [int] NULL,
	[Isencao] [bit] NULL,
	[LancarImpostoAReceberLongoPrazo] [bit] NULL,
	[MetodoSubstituicaoTributaria] [int] NULL,
	[DiferencialICMS] [bit] NULL,
	[IdMoedaComprovante] [int] NULL,
	[Origem] [int] NULL,
	[FiscalOrigem] [int] NULL,
	[IdPeriodoLiquidacaoImposto] [int] NULL,
	[TipoImposto] [int] NULL,
	[UsuarioFinal] [bit] NULL,
 CONSTRAINT [PK_PedidoCompraItemApuracaoImposto] PRIMARY KEY CLUSTERED 
(
	[IdPedidoCompraItemApuracaoImposto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_CodigoImposto] FOREIGN KEY([IdCodigoImposto])
REFERENCES [dbo].[CodigoImposto] ([IdCodigoImposto])
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto] CHECK CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_CodigoImposto]
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_CodigoIsencao] FOREIGN KEY([IdCodigoIsencao])
REFERENCES [dbo].[CodigoIsencao] ([IdCodigoIsencao])
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto] CHECK CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_CodigoIsencao]
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_CodigoTributacao] FOREIGN KEY([IdCodigoTributacao])
REFERENCES [dbo].[CodigoTributacao] ([IdCodigoTributacao])
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto] CHECK CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_CodigoTributacao]
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_ContaContabil] FOREIGN KEY([IdContaContabil])
REFERENCES [dbo].[ContaContabil] ([IdContaContabil])
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto] CHECK CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_ContaContabil]
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_GrupoImposto] FOREIGN KEY([IdGrupoImposto])
REFERENCES [dbo].[GrupoImposto] ([IdGrupoImposto])
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto] CHECK CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_GrupoImposto]
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_GrupoImpostoItem] FOREIGN KEY([IdGrupoImpostoItem])
REFERENCES [dbo].[GrupoImpostoItem] ([IdGrupoImpostoItem])
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto] CHECK CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_GrupoImpostoItem]
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_JuridicaoImposto] FOREIGN KEY([IdJurisdicaoImposto])
REFERENCES [dbo].[JuridicaoImposto] ([IdJuridicaoImposto])
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto] CHECK CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_JuridicaoImposto]
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_Moeda] FOREIGN KEY([IdMoeda])
REFERENCES [dbo].[Moeda] ([IdMoeda])
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto] CHECK CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_Moeda]
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_Moeda1] FOREIGN KEY([IdMoedaComprovante])
REFERENCES [dbo].[Moeda] ([IdMoeda])
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto] CHECK CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_Moeda1]
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_NotaFiscal] FOREIGN KEY([IdNotaFiscal])
REFERENCES [dbo].[NotaFiscal] ([IdNotaFiscal])
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto] CHECK CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_NotaFiscal]
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_PedidoCompraItem] FOREIGN KEY([IdPedidoCompraItem])
REFERENCES [dbo].[PedidoCompraItem] ([IdPedidoCompraItem])
GO

ALTER TABLE [dbo].[PedidoCompraItemApuracaoImposto] CHECK CONSTRAINT [FK_PedidoCompraItemApuracaoImposto_PedidoCompraItem]
GO


