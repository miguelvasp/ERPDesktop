
CREATE TABLE [dbo].[ProdutoCentroCusto](
	[IdProdutoCentroCusto] [int] IDENTITY(1,1) NOT NULL,
	[IdProduto] [int] NULL,
	[IdValoresCentroCusto] [int] NULL,
 CONSTRAINT [PK_ProdutoCentroCusto] PRIMARY KEY CLUSTERED 
(
	[IdProdutoCentroCusto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ProdutoCentroCusto]  WITH CHECK ADD  CONSTRAINT [FK_ProdutoCentroCusto_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([IdProduto])
GO

ALTER TABLE [dbo].[ProdutoCentroCusto] CHECK CONSTRAINT [FK_ProdutoCentroCusto_Produto]
GO

ALTER TABLE [dbo].[ProdutoCentroCusto]  WITH CHECK ADD  CONSTRAINT [FK_ProdutoCentroCusto_ValoresCentroCusto] FOREIGN KEY([IdValoresCentroCusto])
REFERENCES [dbo].[ValoresCentroCusto] ([IdValoresCentroCusto])
GO

ALTER TABLE [dbo].[ProdutoCentroCusto] CHECK CONSTRAINT [FK_ProdutoCentroCusto_ValoresCentroCusto]
GO


