
/****** Object:  Table [dbo].[LimiteImposto]    Script Date: 07/04/2015 08:55:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LimiteImpostoRetido](
	[IdLimiteImpostoRetido] [int] IDENTITY(1,1) NOT NULL,
	[LimiteMaximo] [decimal](18, 5) NULL,
	[LimiteMinimo] [decimal](18, 5) NULL,
	[De] [date] NULL,
	[Ate] [date] NULL,
	[IdCodigoImpostoretido] [int] NULL,
 CONSTRAINT [PK_LimiteImpostoRetido] PRIMARY KEY CLUSTERED 
(
	[IdLimiteImpostoRetido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


