

/****** Object:  Table [dbo].[LocalizacaoAtivo]    Script Date: 03/06/2015 14:41:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LocalizacaoAtivo](
	[IdLocalizacaoAtivo] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](40) NOT NULL,
	[IdDepartamento] [int] NULL,
	[Sala] [varchar](10) NULL,
	[Endereco] [varchar](255) NULL,
	[Numero] [varchar](100) NULL,
	[Complemento] [varchar](100) NULL,
	[Bairro] [varchar](255) NULL,
	[IdCidade] [int] NULL,
	[IdUF] [int] NULL,
	[CEP] [varchar](9) NULL,
 CONSTRAINT [PK_LocalizacaoAtivo] PRIMARY KEY CLUSTERED 
(
	[IdLocalizacaoAtivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[LocalizacaoAtivo]  WITH CHECK ADD  CONSTRAINT [FK_LocalizacaoAtivo_Departamento] FOREIGN KEY([IdDepartamento])
REFERENCES [dbo].[Departamento] ([IdDepartamento])
GO

ALTER TABLE [dbo].[LocalizacaoAtivo] CHECK CONSTRAINT [FK_LocalizacaoAtivo_Departamento]
GO

ALTER TABLE [dbo].[LocalizacaoAtivo]  WITH CHECK ADD  CONSTRAINT [FK_LocalizacaoAtivo_UnidadeFederacao] FOREIGN KEY([IdUF])
REFERENCES [dbo].[UnidadeFederacao] ([IdUF])
GO

ALTER TABLE [dbo].[LocalizacaoAtivo] CHECK CONSTRAINT [FK_LocalizacaoAtivo_UnidadeFederacao]
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cidade SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.LocalizacaoAtivo ADD CONSTRAINT
	FK_LocalizacaoAtivo_Cidade FOREIGN KEY
	(
	IdCidade
	) REFERENCES dbo.Cidade
	(
	IdCidade
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.LocalizacaoAtivo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

