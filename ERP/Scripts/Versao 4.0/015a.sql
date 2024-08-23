USE [mgasoftware]
GO

/****** Object:  Table [dbo].[ComissaoContaCorrente]    Script Date: 11/08/2015 15:53:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ComissaoContaCorrente](
	[IdComissaoContaCorrente] [int] IDENTITY(1,1) NOT NULL,
	[IdVendedor] [int] NOT NULL,
	[IdNotaFiscal] [int] NULL,
	[DataNotaFiscal] [datetime] NULL,
	[ComissaoPercentual] [decimal](18, 4) NOT NULL,
	[Comissao] [decimal](18, 4) NOT NULL,
	[ValorAPagar] [decimal](18, 4) NOT NULL,
	[Acrescimo] [decimal](18, 4) NULL,
	[ValorPago] [decimal](18, 4) NULL,
	[TipoComissao] [int] NULL,
	[Observacao] [varchar](max) NULL,
 CONSTRAINT [PK_ComissaoContaCorrente] PRIMARY KEY CLUSTERED 
(
	[IdComissaoContaCorrente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ComissaoContaCorrente]  WITH CHECK ADD  CONSTRAINT [FK_ComissaoContaCorrente_NotaFiscal] FOREIGN KEY([IdNotaFiscal])
REFERENCES [dbo].[NotaFiscal] ([IdNotaFiscal])
GO

ALTER TABLE [dbo].[ComissaoContaCorrente] CHECK CONSTRAINT [FK_ComissaoContaCorrente_NotaFiscal]
GO

ALTER TABLE [dbo].[ComissaoContaCorrente]  WITH CHECK ADD  CONSTRAINT [FK_ComissaoContaCorrente_Vendedor] FOREIGN KEY([IdVendedor])
REFERENCES [dbo].[Vendedor] ([IdVendedor])
GO

ALTER TABLE [dbo].[ComissaoContaCorrente] CHECK CONSTRAINT [FK_ComissaoContaCorrente_Vendedor]
GO

