

/****** Object:  Table [dbo].[OrdemProducaoCentroCusto]    Script Date: 07/28/2015 15:27:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrdemProducaoCentroCusto](
	[IdOrdemProducaoCentroCusto] [int] IDENTITY(1,1) NOT NULL,
	[IdOrdemProducao] [int] NULL,
	[IdValoresCentroCusto] [int] NULL,
 CONSTRAINT [PK_OrdemProducaCentroCusto] PRIMARY KEY CLUSTERED 
(
	[IdOrdemProducaoCentroCusto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


