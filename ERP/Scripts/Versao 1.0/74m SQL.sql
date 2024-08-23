

/****** Object:  Table [dbo].[ClienteCentroCusto]    Script Date: 07/13/2015 14:45:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ClienteCentroCusto](
	[IdClienteCentroCusto] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[IdValoresCentroCusto] [int] NULL,
 CONSTRAINT [PK_ClienteCentroCusto] PRIMARY KEY CLUSTERED 
(
	[IdClienteCentroCusto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


