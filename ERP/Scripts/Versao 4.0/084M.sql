
/****** Object:  Table [dbo].[PedidoCompraItemEncargo]    Script Date: 03/12/2016 18:16:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PedidoCompraItemEncargo](
	[IdPedidoCompraItemEncargo] [int] IDENTITY(1,1) NOT NULL,
	[IdPedidoCompraItem] [int] NULL,
	[IdTransacao] [int] NULL,
	[IdCodigoEncargo] [int] NULL,
	[IdMoeda] [int] NULL,
	[ValorEncargo] [decimal](18, 4) NULL,
	[TipoEncargo] [int] NULL,
	[IdGrupoImposto] [int] NULL,
	[IdGrupoImpostoItem] [int] NULL,
	[IncluiNotaFiscal] [bit] NULL,
	[IncluiImposto] [bit] NULL,
 CONSTRAINT [PK_PedidoCompraItemEncargo] PRIMARY KEY CLUSTERED 
(
	[IdPedidoCompraItemEncargo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PedidoCompraItemEncargo]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItemEncargo_CodigoEncargo] FOREIGN KEY([IdCodigoEncargo])
REFERENCES [dbo].[CodigoEncargo] ([IdCodigoEncargo])
GO

ALTER TABLE [dbo].[PedidoCompraItemEncargo] CHECK CONSTRAINT [FK_PedidoCompraItemEncargo_CodigoEncargo]
GO

ALTER TABLE [dbo].[PedidoCompraItemEncargo]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItemEncargo_GrupoImposto] FOREIGN KEY([IdGrupoImposto])
REFERENCES [dbo].[GrupoImposto] ([IdGrupoImposto])
GO

ALTER TABLE [dbo].[PedidoCompraItemEncargo] CHECK CONSTRAINT [FK_PedidoCompraItemEncargo_GrupoImposto]
GO

ALTER TABLE [dbo].[PedidoCompraItemEncargo]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItemEncargo_GrupoImpostoItem] FOREIGN KEY([IdGrupoImpostoItem])
REFERENCES [dbo].[GrupoImpostoItem] ([IdGrupoImpostoItem])
GO

ALTER TABLE [dbo].[PedidoCompraItemEncargo] CHECK CONSTRAINT [FK_PedidoCompraItemEncargo_GrupoImpostoItem]
GO

ALTER TABLE [dbo].[PedidoCompraItemEncargo]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItemEncargo_Moeda] FOREIGN KEY([IdMoeda])
REFERENCES [dbo].[Moeda] ([IdMoeda])
GO

ALTER TABLE [dbo].[PedidoCompraItemEncargo] CHECK CONSTRAINT [FK_PedidoCompraItemEncargo_Moeda]
GO

ALTER TABLE [dbo].[PedidoCompraItemEncargo]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItemEncargo_PedidoCompraItem] FOREIGN KEY([IdPedidoCompraItem])
REFERENCES [dbo].[PedidoCompraItem] ([IdPedidoCompraItem])
GO

ALTER TABLE [dbo].[PedidoCompraItemEncargo] CHECK CONSTRAINT [FK_PedidoCompraItemEncargo_PedidoCompraItem]
GO


