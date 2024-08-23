USE [mgasoftware]
GO

/****** Object:  Table [dbo].[PedidoVendaAprovacao]    Script Date: 08/22/2015 20:09:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PedidoVendaAprovacao](
	[IdPedidoVendaAprovacao] [int] IDENTITY(1,1) NOT NULL,
	[IdPedidoVenda] [int] NULL,
	[Data] [datetime] NULL,
	[NovoStatus] [varchar](255) NULL,
	[Usuario] [varchar](255) NULL,
 CONSTRAINT [PK_PedidoVendaAprovacao] PRIMARY KEY CLUSTERED 
(
	[IdPedidoVendaAprovacao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

