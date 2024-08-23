

/****** Object:  Table [dbo].[OrdemProducaoLinhaCentroCusto]    Script Date: 07/28/2015 15:28:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrdemProducaoLinhaCentroCusto](
	[IdOrdemProducaoLinhaCentroCusto] [int] IDENTITY(1,1) NOT NULL,
	[IdOrdemProducaoLinha] [int] NULL,
	[IdValoresCentroCusto] [int] NULL,
 CONSTRAINT [PK_OrdemProducaoLinhaCentroCusto] PRIMARY KEY CLUSTERED 
(
	[IdOrdemProducaoLinhaCentroCusto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


