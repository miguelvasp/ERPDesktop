

/****** Object:  Table [dbo].[Recebimento]    Script Date: 06/22/2015 21:31:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Recebimento](
	[IdRecebimento] [int] IDENTITY(1,1) NOT NULL,
	[IdLoteRecebimento] [int] NOT NULL,
	[IdFornecedor] [int] NULL,
	[DataFisica] [date] NOT NULL,
	[IdPedidoCompra] [int] NULL,
 CONSTRAINT [PK_Recebimento] PRIMARY KEY CLUSTERED 
(
	[IdRecebimento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[RecebimentoItem]    Script Date: 06/22/2015 21:32:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RecebimentoItem](
	[IdRecebimentoItem] [int] IDENTITY(1,1) NOT NULL,
	[IdRecebimento] [int] NOT NULL,
	[IdLoteRecebimento] [int] NOT NULL,
	[IdProduto] [int] NULL,
	[NomeProduto] [varchar](255) NULL,
	[Quantidade] [int] NOT NULL,
	[QuantidadeRecebida] [int] NOT NULL,
	[Unidade] [int] NULL,
	[ValorUnitario] [decimal](18, 5) NULL,
	[ValorTotal] [decimal](18, 5) NULL,
	[Desconto] [decimal](18, 5) NULL,
	[Seguro] [decimal](18, 5) NULL,
	[Frete] [decimal](18, 5) NULL,
	[DespesasAcessorias] [decimal](18, 5) NULL,
	[Royalties] [decimal](18, 5) NULL,
	[ValorLiquido] [decimal](18, 5) NULL,
	[IdEstilo] [int] NULL,
	[IdCor] [int] NULL,
	[IdTamanho] [int] NULL,
	[IdLote] [int] NULL,
	[IdSeries] [int] NULL,
	[IdArmazem] [int] NULL,
	[IdDeposito] [int] NULL,
	[IdLocalizacao] [int] NULL,
	[IdGrupoAtivo] [int] NULL,
	[IdMetodoDepreciacao] [int] NULL,
	[IdAtivoFixo] [int] NULL,
	[DataVencimento] [datetime] NULL,
	[DataLoteFornecedor] [datetime] NULL,
 CONSTRAINT [PK_RecebimentoItem] PRIMARY KEY CLUSTERED 
(
	[IdRecebimentoItem] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[RecebimentoItem]  WITH CHECK ADD  CONSTRAINT [FK_RecebimentoItem_Recebimento] FOREIGN KEY([IdRecebimento])
REFERENCES [dbo].[Recebimento] ([IdRecebimento])
GO

ALTER TABLE [dbo].[RecebimentoItem] CHECK CONSTRAINT [FK_RecebimentoItem_Recebimento]
GO

