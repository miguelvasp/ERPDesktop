/****** Object:  Table [dbo].[ContratoComercialCondPgto]    Script Date: 10/20/2015 21:42:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContratoComercialCondPgto](
	[IdContratoComercialCondPgto] [int] IDENTITY(1,1) NOT NULL,
	[IdContratoComercial] [int] NOT NULL,
	[IdCondicaoPagamento] [int] NOT NULL,
	[Juros] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_ContratoComercialCondPgto] PRIMARY KEY CLUSTERED 
(
	[IdContratoComercialCondPgto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ContratoComercialCondPgto]  WITH CHECK ADD  CONSTRAINT [FK_ContratoComercialCondPgto_CondicaoPagamento] FOREIGN KEY([IdCondicaoPagamento])
REFERENCES [dbo].[CondicaoPagamento] ([IdCondicaoPagamento])
GO

ALTER TABLE [dbo].[ContratoComercialCondPgto] CHECK CONSTRAINT [FK_ContratoComercialCondPgto_CondicaoPagamento]
GO

ALTER TABLE [dbo].[ContratoComercialCondPgto]  WITH CHECK ADD  CONSTRAINT [FK_ContratoComercialCondPgto_ContratoComercial] FOREIGN KEY([IdContratoComercial])
REFERENCES [dbo].[ContratoComercial] ([IdContratoComercial])
GO

ALTER TABLE [dbo].[ContratoComercialCondPgto] CHECK CONSTRAINT [FK_ContratoComercialCondPgto_ContratoComercial]
GO

