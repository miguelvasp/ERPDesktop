

/****** Object:  Table [dbo].[PARAMETRO]    Script Date: 01/21/2015 14:01:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Empresa](
	IdEmpresa [int] IDENTITY(1,1) NOT NULL,
	RazaoSocial [varchar](150) NULL,
	Fantasia [varchar](150) NULL,
	CNPJ [varchar](15) NULL,
	IE [varchar](15) NULL,
	Endereco [varchar](90) NULL,
	Numero varchar(10) null,
	Complemento [varchar](30) NULL,
	Bairro [varchar](40) NULL,
	IdUF int NULL,
	CEP [varchar](9) NULL,
	Telefone [varchar](14) NULL,
	Telefone2 [varchar](14) NULL,
	Fax [varchar](14) NULL,
	Email [varchar](150) NULL,
	UltimaFatura [int] NULL,
	UltimaNotaFiscal [int] NULL,
	UltimoConhecimento [int] NULL,
	Logo [image] NULL,
	UltimaNotaServico [int] NULL,
 CONSTRAINT [PK_Empresa2] PRIMARY KEY CLUSTERED 
(
	IdEmpresa ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
