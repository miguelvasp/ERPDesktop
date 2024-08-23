DROP TABLE RECEBIMENTOITEMLOTE
GO

USE [mgasoftware]
GO

/****** Object:  Table [dbo].[RecebimentoItemLote]    Script Date: 10/22/2015 17:55:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RecebimentoItemLote](
	[IdLote] [int] IDENTITY(1,1) NOT NULL,
	[IdRecebimentoItem] [int] NOT NULL,
	[Quantidade] [decimal](18, 4) NOT NULL,
	[DataVencimento] [datetime] NULL,
	[DataFabricacao] [datetime] NULL,
	[DataAvisoPrateleira] [datetime] NULL,
	[DataValidade] [datetime] NULL,
	[LoteFornecedor] [varchar](255) NULL,
	[LoteInterno] [varchar](255) NULL,
 CONSTRAINT [PK_Lote] PRIMARY KEY CLUSTERED 
(
	[IdLote] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

