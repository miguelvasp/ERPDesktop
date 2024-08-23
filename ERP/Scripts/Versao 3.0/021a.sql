/****** Object:  Table [dbo].[DescontoVarejista]    Script Date: 10/18/2015 18:25:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DescontoVarejista](
	[IdDescontoVarejista] [int] IDENTITY(1,1) NOT NULL,
	[IdPedidoVenda] [int] NOT NULL,
	[IdPedidoVendaItem] [int] NOT NULL,
	[IdNotaFiscal] [int] NULL,
	[IdNotaFiscalItem] [int] NULL,
	[IdCliente] [int] NOT NULL,
	[DataPedido] [datetime] NOT NULL,
	[Valor] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_DescontoVarejista] PRIMARY KEY CLUSTERED 
(
	[IdDescontoVarejista] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[DescontoVarejista]  WITH CHECK ADD  CONSTRAINT [FK_DescontoVarejista_NotaFiscal] FOREIGN KEY([IdNotaFiscal])
REFERENCES [dbo].[NotaFiscal] ([IdNotaFiscal])
GO

ALTER TABLE [dbo].[DescontoVarejista] CHECK CONSTRAINT [FK_DescontoVarejista_NotaFiscal]
GO

ALTER TABLE [dbo].[DescontoVarejista]  WITH CHECK ADD  CONSTRAINT [FK_DescontoVarejista_PedidoVenda] FOREIGN KEY([IdPedidoVenda])
REFERENCES [dbo].[PedidoVenda] ([IdPedidoVenda])
GO

ALTER TABLE [dbo].[DescontoVarejista] CHECK CONSTRAINT [FK_DescontoVarejista_PedidoVenda]
GO

ALTER TABLE [dbo].[DescontoVarejista]  WITH CHECK ADD  CONSTRAINT [FK_DescontoVarejista_PedidoVendaItem] FOREIGN KEY([IdPedidoVendaItem])
REFERENCES [dbo].[PedidoVendaItem] ([IdPedidoVendaItem])
GO

ALTER TABLE [dbo].[DescontoVarejista] CHECK CONSTRAINT [FK_DescontoVarejista_PedidoVendaItem]
GO

