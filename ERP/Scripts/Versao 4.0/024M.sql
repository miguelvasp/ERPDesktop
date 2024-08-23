

/****** Object:  Table [dbo].[ContasReceberBaixa]    Script Date: 11/18/2015 15:31:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ContasReceberBaixa](
	[IdContasReceberBaixa] [int] IDENTITY(1,1) NOT NULL,
	[IdContasReceberAberto] [int] NULL,
	[TipoTransacao] [int] NULL,
	[DataPagamento] [datetime] NULL,
	[Documento] [varchar](255) NULL,
	[Observacao] [varchar](max) NULL,
	[Valor] [decimal](18, 4) NULL,
	[NumeroCheque] [varchar](255) NULL,
	[IdContaBancaria] [int] NULL,
	[Liquidada] [bit] NULL,
 CONSTRAINT [PK_ContasReceberBaixa] PRIMARY KEY CLUSTERED 
(
	[IdContasReceberBaixa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
