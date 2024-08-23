

/****** Object:  Table [dbo].[OrdemProducaoLinha]    Script Date: 07/28/2015 15:28:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[OrdemProducaoLinha](
	[IdOrdemProducaoLinha] [int] IDENTITY(1,1) NOT NULL,
	[IdOrdemProducao] [int] NULL,
	[IdListaMateriais] [int] NULL,
	[IdDiarioEstoqueSaida] [int] NULL,
	[IdDiarioEstoqueEntrada] [int] NULL,
	[IdDiarioEstoqueQualidade] [int] NULL,
	[DataCricao] [datetime] NULL,
	[DataPrevisto] [datetime] NULL,
	[DataIniciado] [datetime] NULL,
	[DataInformadoConcluido] [datetime] NULL,
	[DataConcluido] [datetime] NULL,
	[QuantidadeIniciada] [decimal](18, 4) NULL,
	[QuantidadePendente] [decimal](18, 4) NULL,
	[QuantidadeLiberada] [decimal](18, 4) NULL,
	[QuantidadeRestante] [decimal](18, 4) NULL,
	[QuantidadeConcluida] [decimal](18, 4) NULL,
	[IdUnidade] [int] NULL,
	[PrecoCusto] [decimal](18, 4) NULL,
	[PrecoVenda] [decimal](18, 4) NULL,
	[PrecoUnitario] [decimal](18, 4) NULL,
	[IdDiarioCusto] [int] NULL,
	[CustoIndiretoLancado] [varchar](255) NULL,
	[SeparacaoConcluida] [bit] NULL,
	[SucataConstante] [int] NULL,
	[SucataVariavel] [int] NULL,
	[CustoIndireto] [decimal](18, 4) NULL,
	[Formula] [int] NULL,
	[IdConfiguracao] [int] NULL,
	[IdTamanho] [int] NULL,
	[IdCor] [int] NULL,
	[IdEstilo] [int] NULL,
	[IdArmazem] [int] NULL,
	[IdLote] [int] NULL,
	[IdLocalizacao] [int] NULL,
	[Serie] [varchar](255) NULL,
	[HerdarAtributosLoteCoProduto] [bit] NULL,
	[HerdarAtributosLoteItemFinal] [bit] NULL,
	[HerdarDataValidadeCoProduto] [bit] NULL,
	[HerdarDataValidadeItemFinal] [bit] NULL,
	[Prioridade] [int] NULL,
 CONSTRAINT [PK_OrdemProducaoLinha] PRIMARY KEY CLUSTERED 
(
	[IdOrdemProducaoLinha] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


