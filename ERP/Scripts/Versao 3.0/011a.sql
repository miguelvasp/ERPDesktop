/****** Object:  Table [dbo].[Inventario]    Script Date: 10/12/2015 18:00:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Inventario](
	[IdInventario] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpresa] [int] NOT NULL,
	[IdProduto] [int] NOT NULL,
	[IdDeposito] [int] NULL,
	[IdArmazem] [int] NULL,
	[IdLocalizacao] [int] NULL,
	[IdVariantesCor] [int] NULL,
	[IdVariantesTamanho] [int] NULL,
	[IdVariantesEstilo] [int] NULL,
	[IdVariantesConfig] [int] NULL,
	[IdUnidade] [int] NULL,
	[IdDocumento] [int] NOT NULL,
	[IdTipoDocumento] [int] NOT NULL,
	[TipoMovimentoFinanceiro] [char](1) NOT NULL,
	[Quantidade] [decimal](18, 4) NULL,
	[DataEntrada] [datetime] NULL,
	[IdLote] [int] NOT NULL,
	[IdLoteFornecedor] [int] NULL,
	[DataValidade] [datetime] NULL,
	[DataSaida] [datetime] NULL,
	[QuantidadeRetirada] [decimal](18, 4) NULL,
	[CustoReposicao] [decimal](18, 4) NULL,
	[CustoMedio] [decimal](18, 4) NULL,
	[Saldo] [decimal](18, 4) NULL,
	[ValorUnitario] [decimal](18, 4) NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[IdInventario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Empresa] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresa] ([IdEmpresa])
GO

ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Empresa]
GO

ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([IdProduto])
GO

ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Produto]
GO

ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_TipoDocumento] FOREIGN KEY([IdTipoDocumento])
REFERENCES [dbo].[TipoDocumento] ([IdDocumento])
GO

ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_TipoDocumento]
GO

ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Unidade] FOREIGN KEY([IdUnidade])
REFERENCES [dbo].[Unidade] ([IdUnidade])
GO

ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Unidade]
GO

ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_VariantesConfig] FOREIGN KEY([IdVariantesConfig])
REFERENCES [dbo].[VariantesConfig] ([IdVariantesConfig])
GO

ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_VariantesConfig]
GO

ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_VariantesCor] FOREIGN KEY([IdVariantesCor])
REFERENCES [dbo].[VariantesCor] ([IdVariantesCor])
GO

ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_VariantesCor]
GO

ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_VariantesEstilo] FOREIGN KEY([IdVariantesEstilo])
REFERENCES [dbo].[VariantesEstilo] ([IdVariantesEstilo])
GO

ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_VariantesEstilo]
GO

ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_VariantesTamanho] FOREIGN KEY([IdVariantesTamanho])
REFERENCES [dbo].[VariantesTamanho] ([IdVariantesTamanho])
GO

ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_VariantesTamanho]
GO

