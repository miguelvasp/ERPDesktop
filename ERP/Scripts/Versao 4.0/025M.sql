

/****** Object:  Table [dbo].[ContasReceberChequeTerceiros]    Script Date: 11/18/2015 15:31:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContasReceberChequeTerceiros](
	[IdContasReceberChequeTerceiro] [int] IDENTITY(1,1) NOT NULL,
	[IdContasReceber] [int] NOT NULL,
	[IdContasReceberBaixa] [int] NOT NULL,
	[IdChequeTerceiro] [int] NOT NULL,
 CONSTRAINT [PK_ContasReceberChequeTerceiros] PRIMARY KEY CLUSTERED 
(
	[IdContasReceberChequeTerceiro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


