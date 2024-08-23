/****** Object:  Table [dbo].[Configuracao]    Script Date: 11/30/2015 20:49:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Configuracao](
	[IdConfiguracao] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpresa] [int] NOT NULL,
	[EMailUserName] [varchar](255) NULL,
	[EMailPassword] [varchar](255) NULL,
	[EMailSMTP] [varchar](255) NULL,
	[EMailPort] [varchar](255) NULL,
	[EMailSSL] [bit] NOT NULL,
 CONSTRAINT [PK_Configuracao] PRIMARY KEY CLUSTERED 
(
	[IdConfiguracao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Configuracao]  WITH CHECK ADD  CONSTRAINT [FK_Configuracao_Empresa] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresa] ([IdEmpresa])
GO

ALTER TABLE [dbo].[Configuracao] CHECK CONSTRAINT [FK_Configuracao_Empresa]
GO

