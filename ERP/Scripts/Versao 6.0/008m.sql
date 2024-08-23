

/****** Object:  Table [dbo].[NotaFiscalItemApuracaoImposto]    Script Date: 07/17/2016 16:53:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[NotaFiscalItemApuracaoImposto](
	[IdNotaFiscalItemApuracaoImposto] [int] IDENTITY(1,1) NOT NULL,
	[IdNotaFiscalItem] [int] NULL,
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
	[ManterDadosAjustados] [bit] NULL,
	[ImpostoIncluso] [bit] NULL,
 CONSTRAINT [PK_NotaFiscalItemApuracaoImposto] PRIMARY KEY CLUSTERED 
(
	[IdNotaFiscalItemApuracaoImposto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_CodigoImposto] FOREIGN KEY([IdCodigoImposto])
REFERENCES [dbo].[CodigoImposto] ([IdCodigoImposto])
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto] CHECK CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_CodigoImposto]
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_CodigoIsencao] FOREIGN KEY([IdCodigoIsencao])
REFERENCES [dbo].[CodigoIsencao] ([IdCodigoIsencao])
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto] CHECK CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_CodigoIsencao]
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_CodigoTributacao] FOREIGN KEY([IdCodigoTributacao])
REFERENCES [dbo].[CodigoTributacao] ([IdCodigoTributacao])
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto] CHECK CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_CodigoTributacao]
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_ContaContabil] FOREIGN KEY([IdContaContabil])
REFERENCES [dbo].[ContaContabil] ([IdContaContabil])
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto] CHECK CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_ContaContabil]
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_GrupoImposto] FOREIGN KEY([IdGrupoImposto])
REFERENCES [dbo].[GrupoImposto] ([IdGrupoImposto])
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto] CHECK CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_GrupoImposto]
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_GrupoImpostoItem] FOREIGN KEY([IdGrupoImpostoItem])
REFERENCES [dbo].[GrupoImpostoItem] ([IdGrupoImpostoItem])
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto] CHECK CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_GrupoImpostoItem]
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_JuridicaoImposto] FOREIGN KEY([IdJurisdicaoImposto])
REFERENCES [dbo].[JuridicaoImposto] ([IdJuridicaoImposto])
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto] CHECK CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_JuridicaoImposto]
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_Moeda] FOREIGN KEY([IdMoeda])
REFERENCES [dbo].[Moeda] ([IdMoeda])
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto] CHECK CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_Moeda]
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_Moeda1] FOREIGN KEY([IdMoedaComprovante])
REFERENCES [dbo].[Moeda] ([IdMoeda])
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto] CHECK CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_Moeda1]
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_NotaFiscal] FOREIGN KEY([IdNotaFiscal])
REFERENCES [dbo].[NotaFiscal] ([IdNotaFiscal])
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto] CHECK CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_NotaFiscal]
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_NotaFiscalItem] FOREIGN KEY([IdNotaFiscalItem])
REFERENCES [dbo].[NotaFiscalItem] ([IdNotaFiscalItem])
GO

ALTER TABLE [dbo].[NotaFiscalItemApuracaoImposto] CHECK CONSTRAINT [FK_NotaFiscalItemApuracaoImposto_NotaFiscalItem]
GO


