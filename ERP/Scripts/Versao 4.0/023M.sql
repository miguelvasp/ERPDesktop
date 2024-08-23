
/****** Object:  Table [dbo].[ContasReceberAberto]    Script Date: 11/18/2015 15:30:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ContasReceberAberto](
	[IdContasReceberAberto] [int] IDENTITY(1,1) NOT NULL,
	[IdContasReceber] [int] NULL,
	[IdCodigoMulta] [int] NULL,
	[IdCodigoJuros] [int] NULL, 
	[Correcao] [bit] NULL,
	[Vencimento] [datetime] NULL,
	[VencimentoOriginal] [datetime] NULL,
	[NumeroParcela] [int] NULL,
	[NumeroParcelaOriginal] [int] NULL,
	[Liquidada] [bit] NULL,
	[NumeroRemessa] [varchar](255) NULL,
	[NumeroDocumentoBancario] [varchar](255) NULL,
	[ValorTitulo] [decimal](18, 4) NULL,
	[Desconto] [decimal](18, 4) NULL,
	[ValorJuros] [decimal](18, 4) NULL,
	[ValorMulta] [decimal](18, 4) NULL,
	[ValorDescontoVista] [decimal](18, 4) NULL,
	[ValorLiquido] [decimal](18, 4) NULL,
	[Retencao] [bit] NULL,
	[Historico] [varchar](max) NULL, 
 CONSTRAINT [PK_ContasReceberAberto] PRIMARY KEY CLUSTERED 
(
	[IdContasReceberAberto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
