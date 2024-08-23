USE [mgasoftware]
GO

/****** Object:  Table [dbo].[CodigoEncargo]    Script Date: 02/04/2016 09:32:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CodigoEncargo](
	[IdCodigoEncargo] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NULL,
	[Descricao] [varchar](255) NULL,
	[Tipo] [int] NULL,
	[IdGrupoImposto] [int] NULL,
	[LancamentoTipo] [int] NULL,
	[IdContaContabilDebito] [int] NULL,
	[CreditoTipoLancamento] [int] NULL,
	[IdContaContabilCredito] [int] NULL,
	[IncluiNotaFiscal] [bit] NULL,
	[IncluiImpostos] [bit] NULL,
 CONSTRAINT [PK_CodigoEncargo] PRIMARY KEY CLUSTERED 
(
	[IdCodigoEncargo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


