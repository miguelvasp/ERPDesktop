
/****** Object:  Table [dbo].[PedidoCompraEncargos]    Script Date: 03/12/2016 18:14:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PedidoCompraEncargos](
	[IdPedidoCompraEncargos] [int] IDENTITY(1,1) NOT NULL,
	[IdPedidoCompra] [int] NULL,
	[TipoEncargo] [int] NULL,
	[Descricao] [varchar](255) NULL,
	[Valor] [decimal](18, 4) NULL,
 CONSTRAINT [PK_PedidoCompraEncargos] PRIMARY KEY CLUSTERED 
(
	[IdPedidoCompraEncargos] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PedidoCompraEncargos]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraEncargos_PedidoCompra] FOREIGN KEY([IdPedidoCompra])
REFERENCES [dbo].[PedidoCompra] ([IdPedidoCompra])
GO

ALTER TABLE [dbo].[PedidoCompraEncargos] CHECK CONSTRAINT [FK_PedidoCompraEncargos_PedidoCompra]
GO


