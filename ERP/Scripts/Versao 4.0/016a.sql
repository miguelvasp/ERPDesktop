USE [mgasoftware]
GO

/****** Object:  Table [dbo].[TipoLancamento]    Script Date: 11/14/2015 15:45:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TipoLancamento](
	[IdTipoLancamento] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoDocumento] [int] NOT NULL,
	[Descricao] [varchar](255) NOT NULL,
 CONSTRAINT [PK_TipoLancamento] PRIMARY KEY CLUSTERED 
(
	[IdTipoLancamento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

Delete from TipoLancamento

/* Pedido de Vendas */
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (1, 'Guia de Remessa');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (1, 'Compensação de Guia de Remessa');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (1, 'Saída');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (1, 'Consumo');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (1, 'Desconto');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (1, 'Comissão');

/* Pedido de Compras */
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (2, 'Recebimento de Produtos');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (2, 'Despesa de compra não faturada');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (2, 'Recebimento de estoque');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (2, 'Despesa de compra produto');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (2, 'Desconto');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (2, 'Encargo');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (2, 'Variação de Estoque');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (2, 'Recebimento de Ativo Imobilizado');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (2, 'Despesa de compra para despesa');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (2, 'Pagamento Antecipado');

/* Estoque */
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (3, 'Saída');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (3, 'Entrada');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (3, 'Lucro');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (3, 'Perda');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (3, 'Emissão de Ativo');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (3, 'Diferença de preço em média de movimento');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (3, 'Reavaliação de preço em média de movimento');

/* Produção */
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (4, 'Saída lista de separação');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (4, 'Contrapartida lista de separação');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (4, 'Recebimento de Relatório de conclusão');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (4, 'Contrapartida de Relatório de conclusão');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (4, 'Saída');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (4, 'Contrapartida de Saída');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (4, 'Recebimento');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (4, 'Contrapartida de Recebimento');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (4, 'Recebimento WIP');
INSERT INTO TipoLancamento ([IdTipoDocumento], [Descricao]) VALUES (4, 'Contrapartida de Recebimento WIP');
GO
