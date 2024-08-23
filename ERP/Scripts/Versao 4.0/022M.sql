
/****** Object:  Table [dbo].[ContasPagar]    Script Date: 11/18/2015 15:11:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ContasReceber](
	[IdContasReceber] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](255) NULL,
	[IdContaContabil] [int] NULL, 
	[ValorTitulo] [decimal](18, 4) NULL,
	[Desconto] [decimal](18, 4) NULL,
	[ValorLiquido] [decimal](18, 4) NULL,
	[Vencimento] [datetime] NULL,
	[VencimentoOriginal] [datetime] NULL,
	[Emissao] [datetime] NULL,
	[Saldo] [decimal](18, 4) NULL,
	[Correcao] [bit] NULL,
	[DataDocumento] [datetime] NULL,
	[IdCliente] [int] NULL,
	[Observacao] [varchar](max) NULL,
	[Acrecimo] [decimal](18, 4) NULL,
	[ValorPago] [decimal](18, 4) NULL,
	[Cancelamento] [bit] NULL,
	[Cancelado] [bit] NULL,
	[IdMoeda] [int] NULL,
	[UltimoPagamento] [datetime] NULL,
	[CalculaRetencao] [bit] NULL,
	[IdMetodoPagamento] [int] NULL,
	[IdEspecificacaoPagamento] [int] NULL,
	[IdPerfilCliente] [int] NULL,
	[Status] [int] NULL,
	[TipoTransacao] [int] NULL,  
	[IdNotaFiscal] [int] NULL,
	[Parcelas] [int] NULL,
	[ParcelasPagas] [int] NULL,
 CONSTRAINT [PK_ContasReceber] PRIMARY KEY CLUSTERED 
(
	[IdContasReceber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
