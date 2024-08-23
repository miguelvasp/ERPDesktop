

CREATE TABLE [dbo].[Cest](
	[IdCest] [int] IDENTITY(1,1) NOT NULL,
	[Cest] [varchar](9) NULL,
	[Descricao] [varchar](max) NULL,
	[NCM] [varchar](60) NULL,
 CONSTRAINT [PK_Cest] PRIMARY KEY CLUSTERED 
(
	[IdCest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


