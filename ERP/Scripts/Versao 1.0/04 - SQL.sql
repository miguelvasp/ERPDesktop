

/****** Object:  Table [dbo].[TempoDepreciacao]    Script Date: 03/06/2015 15:01:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TempoDepreciacao](
	[IdTempoDepreciacao] [int] IDENTITY(1,1) NOT NULL,
	[IdGrupoAtivo] [int] NULL,
	[NivelLancamento] [int] NULL,
	[IdPerfilDepreciacaoComum] [int] NULL,
	[IdPerfilDepreciacaoAlternativa] [int] NULL,
	[IdPerfilDepreciacaoExtraordinaria] [int] NULL,
	[Arredondamento] [decimal](18, 5) NOT NULL,
	[Convencao] [int] NULL,
	[Depreciacao] [int] NULL,
	[Periodo] [int] NOT NULL,
	[VidaUtil] [int] NOT NULL,
 CONSTRAINT [PK_TempoDepreciacao] PRIMARY KEY CLUSTERED 
(
	[IdTempoDepreciacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TempoDepreciacao]  WITH CHECK ADD  CONSTRAINT [FK_TempoDepreciacao_GrupoAtivo] FOREIGN KEY([IdGrupoAtivo])
REFERENCES [dbo].[GrupoAtivo] ([IdGrupoAtivo])
GO

ALTER TABLE [dbo].[TempoDepreciacao] CHECK CONSTRAINT [FK_TempoDepreciacao_GrupoAtivo]
GO

