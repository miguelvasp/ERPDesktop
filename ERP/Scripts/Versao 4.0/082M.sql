

/****** Object:  Table [dbo].[PedidoCompraAlocacaoEncargos]    Script Date: 03/12/2016 18:13:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PedidoCompraAlocacaoEncargos](
	[IdPedidoCompra] [int] NOT NULL,
	[DistribuirPor] [int] NULL,
	[Linhas] [int] NULL,
	[DistribuirTudo] [bit] NULL,
	[Recebido_Separado] [bit] NULL,
	[IDPEDIDOCompraALOCAENCARGOS] [int] NULL,
 CONSTRAINT [PK_PedidoCompraAlocacaoEncargos] PRIMARY KEY CLUSTERED 
(
	[IdPedidoCompra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PedidoCompraAlocacaoEncargos]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraAlocacaoEncargos_PedidoCompra] FOREIGN KEY([IdPedidoCompra])
REFERENCES [dbo].[PedidoCompra] ([IdPedidoCompra])
GO

ALTER TABLE [dbo].[PedidoCompraAlocacaoEncargos] CHECK CONSTRAINT [FK_PedidoCompraAlocacaoEncargos_PedidoCompra]
GO


