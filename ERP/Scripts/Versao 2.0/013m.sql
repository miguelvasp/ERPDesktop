

/****** Object:  Table [dbo].[OrdemProducao]    Script Date: 07/28/2015 15:24:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OrdemProducao](
	[IdOrdemProducao] [int] IDENTITY(1,1) NOT NULL,
	[IdListaMateriais] [int] NULL,
	[DataListaMateriais] [datetime] NULL,
	[IdProduto] [int] NULL,
	[TipoProducao] [int] NULL,
	[Quantidade] [decimal](18, 4) NULL,
	[ContaFornecedor] [varchar](255) NULL,
	[IdRoteiro] [int] NULL,
	[DataEntrega] [datetime] NULL,
	[HoraEntrega] [time](7) NULL,
	[StatusProducao] [int] NULL,
	[StatusPlano] [int] NULL,
	[StatusPendente] [int] NULL,
	[DataProgramada] [datetime] NULL,
	[DataInicial] [datetime] NULL,
	[DataFinal] [datetime] NULL,
	[HoraInicial] [time](7) NULL,
	[HoraFinal] [time](7) NULL,
	[IdPerfilProducao] [int] NULL,
	[Reserva] [int] NULL,
	[Razao] [int] NULL,
	[DefinicaoLucro] [int] NULL,
	[AlocacaoCustoTotal] [bit] NULL,
	[IdConfiguracao] [int] NULL,
	[IdTamanho] [int] NULL,
	[IdCor] [int] NULL,
	[IdEstilo] [int] NULL,
	[IdArmazem] [int] NULL,
	[IdLote] [int] NULL,
	[IdLocalizacao] [int] NULL,
	[Serie] [varchar](255) NULL,
	[HerdarAtributosLoteCoProdutos] [bit] NULL,
	[HerdarAtributosLoteItemFinal] [bit] NULL,
	[HerdarDatasValidadeCoProdutos] [bit] NULL,
	[HerdarDatasValidadeItemFinal] [bit] NULL,
 CONSTRAINT [PK_OrdemProducao] PRIMARY KEY CLUSTERED 
(
	[IdOrdemProducao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


