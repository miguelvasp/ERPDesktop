USE [master]
GO
/****** Object:  Database [ERP2]    Script Date: 01/20/2015 15:38:30 ******/
CREATE DATABASE [ERP2] ON  PRIMARY 
( NAME = N'ERP2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ERP2.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ERP2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ERP2_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ERP2] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ERP2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ERP2] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ERP2] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ERP2] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ERP2] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ERP2] SET ARITHABORT OFF
GO
ALTER DATABASE [ERP2] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ERP2] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ERP2] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ERP2] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ERP2] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ERP2] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ERP2] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ERP2] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ERP2] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ERP2] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ERP2] SET  DISABLE_BROKER
GO
ALTER DATABASE [ERP2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ERP2] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ERP2] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ERP2] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ERP2] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ERP2] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ERP2] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ERP2] SET  READ_WRITE
GO
ALTER DATABASE [ERP2] SET RECOVERY FULL
GO
ALTER DATABASE [ERP2] SET  MULTI_USER
GO
ALTER DATABASE [ERP2] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ERP2] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'ERP2', N'ON'
GO
USE [ERP2]
GO
/****** Object:  Table [dbo].[UnidadeFederacao]    Script Date: 01/20/2015 15:38:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UnidadeFederacao](
	[IdUF] [int] IDENTITY(1,1) NOT NULL,
	[UF] [varchar](2) NOT NULL,
	[Nome] [varchar](20) NOT NULL,
	[AliquotaICMS] [float] NULL,
	[IVA] [float] NULL,
	[AliquotaICMSSubs] [float] NULL,
	[IBGE] [int] NOT NULL,
 CONSTRAINT [PK_UnidadeFederacao] PRIMARY KEY CLUSTERED 
(
	[IdUF] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Unidade]    Script Date: 01/20/2015 15:38:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Unidade](
	[IdUnidade] [int] IDENTITY(1,1) NOT NULL,
	[UnidadeMedida] [varchar](3) NULL,
	[Descricao] [varchar](max) NULL,
 CONSTRAINT [PK_Unidade] PRIMARY KEY CLUSTERED 
(
	[IdUnidade] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 01/20/2015 15:38:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perfil](
	[IdPerfil] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Descricao] [varchar](255) NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[vwTableRelations]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwTableRelations]
AS

SELECT  
     KCU1.TABLE_NAME AS TABLE_NAME 
    ,KCU1.COLUMN_NAME AS FK_COLUMN_NAME     
    ,KCU2.TABLE_NAME AS REFERENCED_TABLE_NAME 
    ,KCU2.COLUMN_NAME AS REFERENCED_COLUMN_NAME 

FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS AS RC 

INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KCU1 
    ON KCU1.CONSTRAINT_CATALOG = RC.CONSTRAINT_CATALOG  
    AND KCU1.CONSTRAINT_SCHEMA = RC.CONSTRAINT_SCHEMA 
    AND KCU1.CONSTRAINT_NAME = RC.CONSTRAINT_NAME 

INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KCU2 
    ON KCU2.CONSTRAINT_CATALOG = RC.UNIQUE_CONSTRAINT_CATALOG  
    AND KCU2.CONSTRAINT_SCHEMA = RC.UNIQUE_CONSTRAINT_SCHEMA 
    AND KCU2.CONSTRAINT_NAME = RC.UNIQUE_CONSTRAINT_NAME 
    AND KCU2.ORDINAL_POSITION = KCU1.ORDINAL_POSITION
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[IdPais] [int] IDENTITY(1,1) NOT NULL,
	[Alpha2Code] [nvarchar](2) NOT NULL,
	[Alpha3Code] [nvarchar](3) NOT NULL,
	[Codigo] [nvarchar](5) NOT NULL,
	[NomePais] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[IdPais] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetFields]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TargetFields](
	[TableName] [varchar](max) NULL,
	[FieldName] [varchar](max) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Programa]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Programa](
	[IdPrograma] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Descricao] [varchar](255) NOT NULL,
	[Formulario] [varchar](50) NULL,
	[Manutencao] [bit] NULL,
 CONSTRAINT [PK_Programa] PRIMARY KEY CLUSTERED 
(
	[IdPrograma] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transportadora]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transportadora](
	[IdTransportadora] [int] IDENTITY(1,1) NOT NULL,
	[RazaoSocial] [varchar](50) NULL,
	[NomeFantasia] [varchar](50) NULL,
	[CNPJ] [varchar](14) NULL,
	[InscricaoEstadual] [varchar](20) NULL,
	[email] [varchar](100) NULL,
	[RNTRC] [varchar](20) NULL,
 CONSTRAINT [PK_tbTransportadoras] PRIMARY KEY CLUSTERED 
(
	[IdTransportadora] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoTelefone]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoTelefone](
	[IdTipoTelefone] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoTelefone] PRIMARY KEY CLUSTERED 
(
	[IdTipoTelefone] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoProduto]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoProduto](
	[IdTipoProduto] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](max) NULL,
	[Descricao] [varchar](max) NULL,
 CONSTRAINT [PK_TipoProduto] PRIMARY KEY CLUSTERED 
(
	[IdTipoProduto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoEndereco]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoEndereco](
	[IdTipoEndereco] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoEndereco] PRIMARY KEY CLUSTERED 
(
	[IdTipoEndereco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoDocumento](
	[IdDocumento] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](max) NULL,
	[Descricao] [text] NULL,
 CONSTRAINT [PK_TPDOC] PRIMARY KEY CLUSTERED 
(
	[IdDocumento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Fornecedor]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Fornecedor](
	[IdFornecedor] [int] IDENTITY(1,1) NOT NULL,
	[NomeFantasia] [varchar](max) NULL,
	[CNPJ] [char](14) NOT NULL,
	[InscricaoEstadual] [varchar](30) NULL,
	[Email] [varchar](255) NULL,
	[Internet] [varchar](255) NULL,
 CONSTRAINT [PK_Fornecedor] PRIMARY KEY CLUSTERED 
(
	[IdFornecedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Feriado]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Feriado](
	[IdFeriado] [int] IDENTITY(1,1) NOT NULL,
	[DataFeriado] [date] NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Feriado] PRIMARY KEY CLUSTERED 
(
	[IdFeriado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Modulo]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Modulo](
	[IdModulo] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](20) NOT NULL,
	[Descricao] [varchar](100) NULL,
 CONSTRAINT [PK_Modulo] PRIMARY KEY CLUSTERED 
(
	[IdModulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Moeda]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Moeda](
	[IdMoeda] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
	[Codigo] [varchar](5) NULL,
 CONSTRAINT [PK_Moeda] PRIMARY KEY CLUSTERED 
(
	[IdMoeda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogForm] [nvarchar](max) NULL,
	[SamId] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[KeyValue] [nvarchar](max) NULL,
	[MasterKey] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Logs] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banco]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banco](
	[IdBanco] [int] IDENTITY(1,1) NOT NULL,
	[NumeroBanco] [nvarchar](10) NULL,
	[NomeBanco] [nvarchar](100) NULL,
 CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED 
(
	[IdBanco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContaContabil]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContaContabil](
	[IdContaContabil] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Descricao] [varchar](max) NULL,
 CONSTRAINT [PK_ContasContaveis] PRIMARY KEY CLUSTERED 
(
	[IdContaContabil] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CondicaoPagamento]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CondicaoPagamento](
	[IdCondicao] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](30) NULL,
	[QtdeParcelas] [int] NULL,
	[ForaSemana] [bit] NULL,
 CONSTRAINT [PK_CondicaoPagamento] PRIMARY KEY CLUSTERED 
(
	[IdCondicao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IU_CONDICAO_PAGTO] UNIQUE NONCLUSTERED 
(
	[Descricao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CodigoFaturamento]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CodigoFaturamento](
	[IdCFOP] [int] IDENTITY(1,1) NOT NULL,
	[CFOP] [varchar](4) NULL,
	[Descricao] [varchar](max) NULL,
	[DescricaoComplementar] [varchar](max) NULL,
	[ICMSTributacao] [varchar](2) NOT NULL,
	[ICMSReducao] [float] NULL,
	[FormaCalculo] [varchar](1) NOT NULL,
	[IPIIncide] [varchar](1) NOT NULL,
	[IPITributacao] [varchar](1) NULL,
	[ISSIncide] [varchar](1) NOT NULL,
	[ISSAliquota] [float] NULL,
	[PISCST] [varchar](3) NULL,
	[PISAliquota] [float] NULL,
	[CofinsCST] [varchar](3) NULL,
	[CofinsAliquota] [float] NULL,
 CONSTRAINT [PK_CodigoFaturamento] PRIMARY KEY CLUSTERED 
(
	[IdCFOP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[RazaoSocial] [varchar](max) NOT NULL,
	[NomeFantasia] [varchar](max) NULL,
	[CNPJ] [char](14) NOT NULL,
	[InscricaoEstadual] [varchar](30) NULL,
	[Email] [char](50) NULL,
	[Internet] [char](50) NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClassificacaoFiscal]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassificacaoFiscal](
	[IdNCM] [int] IDENTITY(1,1) NOT NULL,
	[NCM] [varchar](10) NOT NULL,
	[IPI] [decimal](4, 2) NULL,
 CONSTRAINT [PK_ClassificacaoFiscal_1] PRIMARY KEY CLUSTERED 
(
	[IdNCM] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cidade]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cidade](
	[IdCidade] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](200) NOT NULL,
	[IBGE] [int] NOT NULL,
	[IdUF] [int] NOT NULL,
 CONSTRAINT [PK_Cidade] PRIMARY KEY CLUSTERED 
(
	[IdCidade] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContaBancaria]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContaBancaria](
	[IdConta] [int] IDENTITY(1,1) NOT NULL,
	[IdBanco] [int] NOT NULL,
	[Agencia] [char](6) NOT NULL,
	[DigitoAgencia] [char](20) NULL,
	[Conta] [varchar](10) NOT NULL,
	[DigitoConta] [varchar](20) NULL,
	[DataInicio] [datetime] NULL,
	[SaldoInicial] [decimal](18, 2) NULL,
	[UltimoCheque] [int] NULL,
	[DataConciliacao] [datetime] NULL,
 CONSTRAINT [PK_ContaBancaria] PRIMARY KEY CLUSTERED 
(
	[IdConta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CondicaoPagamentoIntervalo]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CondicaoPagamentoIntervalo](
	[IdIntervalo] [int] IDENTITY(1,1) NOT NULL,
	[IdCondicao] [int] NULL,
	[Percentual] [decimal](5, 2) NULL,
	[Dias] [int] NULL,
 CONSTRAINT [PK_CondicaoPagamentoIntervalo] PRIMARY KEY CLUSTERED 
(
	[IdIntervalo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContasReceber]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContasReceber](
	[IdRecebimento] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](50) NULL,
	[IdContaContabil] [int] NOT NULL,
	[ValorTitulo] [float] NOT NULL,
	[ValorDesconto] [float] NULL,
	[ValorLiquido] [float] NOT NULL,
	[Vencimento] [datetime] NOT NULL,
	[TipoPagamento] [char](1) NULL,
	[Emissao] [datetime] NULL,
	[Saldo] [float] NULL,
	[DataCompetencia] [datetime] NULL,
	[IdFornecedor] [int] NOT NULL,
	[Observacao] [ntext] NULL,
	[Acrescimo] [float] NULL,
	[ValorPago] [float] NULL,
	[TipoCobranca] [varchar](30) NULL,
	[IdCliente] [int] NULL,
 CONSTRAINT [PK_tbFinRecebimentos] PRIMARY KEY CLUSTERED 
(
	[IdRecebimento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContasPagar]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContasPagar](
	[IdPagamento] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [varchar](50) NULL,
	[IdContaContabil] [int] NOT NULL,
	[ValorTitulo] [float] NOT NULL,
	[Desconto] [float] NULL,
	[ValorLiquido] [float] NOT NULL,
	[Vencimento] [datetime] NOT NULL,
	[TipoPagamento] [char](1) NULL,
	[Emissao] [datetime] NULL,
	[Saldo] [float] NULL,
	[DataCompetencia] [datetime] NULL,
	[IdFornecedor] [int] NOT NULL,
	[Observacao] [ntext] NULL,
	[Acrescimo] [float] NULL,
	[ValorPago] [float] NULL,
 CONSTRAINT [PK_tbPagamentos] PRIMARY KEY CLUSTERED 
(
	[IdPagamento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LogItems]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogItems](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[LogId] [int] NOT NULL,
	[LgiField] [nvarchar](max) NULL,
	[LgiOldValue] [nvarchar](max) NULL,
	[LgiNewValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.LogItems] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MoedaCotacao]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MoedaCotacao](
	[IdMoedaCotacao] [int] IDENTITY(1,1) NOT NULL,
	[IdMoeda] [int] NULL,
	[Data] [datetime] NULL,
	[Valor] [decimal](18, 4) NULL,
 CONSTRAINT [PK_MoedaCotacao] PRIMARY KEY CLUSTERED 
(
	[IdMoedaCotacao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FornecedorContaBancaria]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FornecedorContaBancaria](
	[IdFornecedorContaBancaria] [int] IDENTITY(1,1) NOT NULL,
	[IdBanco] [int] NOT NULL,
	[Agencia] [varchar](6) NOT NULL,
	[DigitoAgencia] [varchar](20) NULL,
	[Conta] [varchar](10) NULL,
	[DigitoConta] [varchar](20) NULL,
 CONSTRAINT [PK_FornecedorContaBancaria] PRIMARY KEY CLUSTERED 
(
	[IdFornecedorContaBancaria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ModuloPrograma]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModuloPrograma](
	[IdModuloPrograma] [int] IDENTITY(1,1) NOT NULL,
	[IdModulo] [int] NOT NULL,
	[IdPrograma] [int] NOT NULL,
 CONSTRAINT [PK_ModuloPrograma] PRIMARY KEY CLUSTERED 
(
	[IdModuloPrograma] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telefone]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Telefone](
	[IdTelefone] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoTelefone] [int] NOT NULL,
	[CodigoPais] [varchar](50) NULL,
	[DDD] [varchar](10) NULL,
	[NumeroTelefone] [varchar](255) NULL,
 CONSTRAINT [PK_Telefone] PRIMARY KEY CLUSTERED 
(
	[IdTelefone] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Produto](
	[IdProduto] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](max) NULL,
	[Descricao] [varchar](max) NULL,
	[IdTipoProduto] [int] NULL,
	[Origem] [varchar](1) NULL,
	[IdUnidadeVenda] [int] NULL,
	[IdUnidadeExpedicao] [int] NULL,
	[PesoLiquido] [float] NULL,
	[PesoBruto] [float] NULL,
	[ProdutoDescontinuado] [varchar](1) NULL,
	[ReducaoICMS] [float] NULL,
	[Embalagem] [varchar](50) NULL,
	[IdNCM] [int] NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[IdProduto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[vwTargetFields]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwTargetFields]
AS
SELECT
    --indice = ROW_NUMBER() OVER (ORDER BY TABLE_NAME),
	TABLE_NAME ,
    FK_COLUMN_NAME ,
    REFERENCED_TABLE_NAME ,
    FieldName
FROM vwTableRelations A INNER JOIN TargetFields B
on A.TABLE_NAME = B.TableName or A.TABLE_NAME = B.TableName + 's'
GO
/****** Object:  Table [dbo].[PerfilModulo]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilModulo](
	[IdPerfilModulo] [int] IDENTITY(1,1) NOT NULL,
	[IdPerfil] [int] NOT NULL,
	[idModulo] [int] NOT NULL,
 CONSTRAINT [PK_PerfilModulo] PRIMARY KEY CLUSTERED 
(
	[IdPerfilModulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoCompra]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PedidoCompra](
	[IdPedidoCompra] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime] NOT NULL,
	[IdFornecedor] [int] NOT NULL,
	[IdMoeda] [int] NOT NULL,
	[DataEntrega] [datetime] NOT NULL,
	[Observacao] [varchar](255) NULL,
	[PrazoEntrega] [varchar](255) NULL,
	[IdCondicao] [int] NOT NULL,
	[Emissao] [datetime] NULL,
	[Status] [char](1) NULL,
	[IdComprador] [int] NULL,
 CONSTRAINT [PK_OrdemCompra] PRIMARY KEY CLUSTERED 
(
	[IdPedidoCompra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdPerfil] [int] NOT NULL,
	[NomeCompleto] [varchar](200) NULL,
	[Login] [varchar](50) NOT NULL,
	[Senha] [varchar](50) NOT NULL,
	[EMail] [varchar](255) NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UnidadeFederacaoNCM]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadeFederacaoNCM](
	[IdUFNCM] [int] IDENTITY(1,1) NOT NULL,
	[IdUF] [int] NOT NULL,
	[IdNCM] [int] NOT NULL,
 CONSTRAINT [PK_UnidadeFederacaoNCM] PRIMARY KEY CLUSTERED 
(
	[IdUFNCM] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoCompraItem]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PedidoCompraItem](
	[IdPedidoCompraItem] [int] IDENTITY(1,1) NOT NULL,
	[IdPedidoCompra] [int] NOT NULL,
	[IdProduto] [int] NOT NULL,
	[Quantidade] [float] NOT NULL,
	[QuantidadeRecebida] [float] NULL,
	[Ipi] [float] NOT NULL,
	[PrecoUnitario] [float] NOT NULL,
	[QtdeRecebida] [float] NOT NULL,
	[Status] [varchar](1) NULL,
 CONSTRAINT [PK_PedidoCompraItem] PRIMARY KEY CLUSTERED 
(
	[IdPedidoCompraItem] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TransportadoraTelefone]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportadoraTelefone](
	[IdTransportadoraTelefone] [int] IDENTITY(1,1) NOT NULL,
	[IdTransportadora] [int] NOT NULL,
	[IdTelefone] [int] NOT NULL,
 CONSTRAINT [PK_TransportadoraTelefone] PRIMARY KEY CLUSTERED 
(
	[IdTransportadoraTelefone] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissao]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissao](
	[IdPermissao] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdPerfil] [int] NOT NULL,
	[IdPrograma] [int] NOT NULL,
	[Visualizar] [bit] NOT NULL,
	[Incluir] [bit] NOT NULL,
	[Excluir] [bit] NOT NULL,
	[Alterar] [bit] NOT NULL,
 CONSTRAINT [PK_Permissao] PRIMARY KEY CLUSTERED 
(
	[IdPermissao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotaFiscal]    Script Date: 01/20/2015 15:38:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NotaFiscal](
	[IdNota] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [varchar](10) NULL,
	[IdDocumento] [int] NOT NULL,
	[IdEmitente] [int] NULL,
	[IdDestinatario] [int] NULL,
	[RazaoSocial] [varchar](max) NULL,
	[NomeFantasia] [varchar](max) NULL,
	[Endereco] [varchar](max) NULL,
	[Complemento] [varchar](20) NULL,
	[Bairro] [varchar](100) NULL,
	[UF] [varchar](2) NULL,
	[CEP] [varchar](8) NULL,
	[IdTelefone] [int] NULL,
	[CNPJ] [varchar](14) NULL,
	[InscricaoEstadual] [varchar](20) NULL,
	[ValorDesconto] [float] NULL,
	[ValorFrete] [float] NULL,
	[ValorSeguro] [float] NULL,
	[BaseIPI] [float] NULL,
	[ValorIPI] [float] NULL,
	[BaseICMS] [float] NULL,
	[ValorICMS] [float] NULL,
	[BaseICMSSubs] [float] NULL,
	[ValorICMSSubs] [float] NULL,
	[ValorMercadoria] [float] NULL,
	[TotalNota] [float] NULL,
	[DataSaida] [datetime] NULL,
	[IdTransportadora] [int] NULL,
	[TransPlaca] [varchar](50) NULL,
	[TransUF] [varchar](2) NULL,
	[Quantidade] [float] NULL,
	[Especie] [varchar](15) NULL,
	[PesoLiquido] [float] NULL,
	[PesoBruto] [float] NULL,
	[Volumes] [float] NULL,
	[TipoFrete] [varchar](1) NULL,
	[DataEmissao] [datetime] NULL,
	[IdCFOP] [int] NOT NULL,
	[IdCidade] [int] NULL,
	[DataEntrega] [datetime] NULL,
	[NotaStatus] [varchar](1) NULL,
	[Serie] [varchar](2) NULL,
	[ChaveNfe] [varchar](44) NULL,
	[IdPedidoCompra] [int] NULL,
 CONSTRAINT [PK_NF] PRIMARY KEY CLUSTERED 
(
	[IdNota] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[LogView]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LogView]
	@LogForm nvarchar(max),
	@KeyValue nvarchar(max),
	@targetField nvarchar(max)
AS
	
SELECT
	   LogId
      ,LogDate
      ,LogForm
      ,SamId
      ,Type
      ,KeyValue
FROM Logs 
where LogForm = @LogForm
and LogId in (
	select LogId from LogItems 
	where LgiField = @targetField
	and LgiOldValue = @KeyValue
)
ORDER BY LogDate DESC
GO
/****** Object:  Table [dbo].[FornecedorTelefone]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FornecedorTelefone](
	[IdFornecedorTelefone] [int] IDENTITY(1,1) NOT NULL,
	[IdFornecedor] [int] NOT NULL,
	[IdTelefone] [int] NOT NULL,
 CONSTRAINT [PK_FornecedorTelefone] PRIMARY KEY CLUSTERED 
(
	[IdFornecedorTelefone] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Endereco]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Endereco](
	[IdEndereco] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoEndereco] [int] NOT NULL,
	[IdPais] [int] NOT NULL,
	[IdUF] [int] NOT NULL,
	[IdCidade] [int] NOT NULL,
	[Logradouro] [varchar](255) NOT NULL,
	[Bairro] [varchar](255) NULL,
	[CodigoPostal] [varchar](10) NULL,
	[Numero] [varchar](100) NULL,
	[Complemento] [varchar](100) NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[IdEndereco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContatoTelefone]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContatoTelefone](
	[IdContatoTelefone] [int] IDENTITY(1,1) NOT NULL,
	[IdContato] [int] NOT NULL,
	[IdTelefone] [int] NOT NULL,
 CONSTRAINT [PK_ContatoTelefone] PRIMARY KEY CLUSTERED 
(
	[IdContatoTelefone] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContasReceberBaixa]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContasReceberBaixa](
	[IdBaixa] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime] NOT NULL,
	[Documento] [varchar](30) NOT NULL,
	[tipoPagamento] [char](1) NOT NULL,
	[Observacao] [varchar](250) NULL,
	[IdRecebimento] [int] NOT NULL,
	[Valor] [float] NULL,
	[IdConta] [int] NULL,
 CONSTRAINT [PK_tbRecebBaixa] PRIMARY KEY CLUSTERED 
(
	[IdBaixa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContasReceberAcresDesc]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContasReceberAcresDesc](
	[IdAcresDesc] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [char](1) NOT NULL,
	[Valor] [float] NOT NULL,
	[IdRecebimento] [int] NOT NULL,
	[Historico] [varchar](30) NULL,
 CONSTRAINT [PK_ContasReceberAcresDesc] PRIMARY KEY CLUSTERED 
(
	[IdAcresDesc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContasPagarBaixa]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContasPagarBaixa](
	[IdBaixa] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime] NOT NULL,
	[Documento] [varchar](30) NOT NULL,
	[Tipo] [char](1) NOT NULL,
	[Observacao] [varchar](250) NULL,
	[IdPagamento] [int] NOT NULL,
	[Valor] [float] NULL,
	[IdConta] [int] NULL,
 CONSTRAINT [PK_tbPagBaixa] PRIMARY KEY CLUSTERED 
(
	[IdBaixa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContasPagarAcresDesc]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContasPagarAcresDesc](
	[IdAcresDesc] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [char](1) NOT NULL,
	[Valor] [float] NOT NULL,
	[IdPagamento] [int] NOT NULL,
	[Historico] [varchar](30) NULL,
 CONSTRAINT [PK_tbPgtoAcresDesc] PRIMARY KEY CLUSTERED 
(
	[IdAcresDesc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AjusteEstoque]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AjusteEstoque](
	[IdAjuste] [int] IDENTITY(1,1) NOT NULL,
	[IdProduto] [int] NOT NULL,
	[Tipo] [char](1) NOT NULL,
	[Quantidade] [float] NOT NULL,
	[Motivo] [varchar](100) NOT NULL,
	[Lote] [varchar](100) NOT NULL,
	[Validade] [datetime] NULL,
	[Documento] [varchar](20) NULL,
	[Data] [datetime] NULL,
	[IdUsuario] [int] NULL,
 CONSTRAINT [PK_tbAjuste] PRIMARY KEY CLUSTERED 
(
	[IdAjuste] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClienteTelefone]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteTelefone](
	[IdClienteTelefone] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdTelefone] [int] NOT NULL,
 CONSTRAINT [PK_ClienteTelefone] PRIMARY KEY CLUSTERED 
(
	[IdClienteTelefone] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteEndereco]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteEndereco](
	[IdClienteEndereco] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdEndereco] [int] NOT NULL,
 CONSTRAINT [PK_ClienteEndereco] PRIMARY KEY CLUSTERED 
(
	[IdClienteEndereco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estoque]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estoque](
	[IdEstoque] [int] IDENTITY(1,1) NOT NULL,
	[IdProduto] [int] NOT NULL,
	[IdNota] [int] NULL,
	[Quantidade] [float] NOT NULL,
	[QuantidadeRetirada] [float] NULL,
	[Lote] [varchar](20) NULL,
	[Validade] [datetime] NULL,
	[DataEntrada] [datetime] NULL,
	[CustoReposicao] [float] NULL,
	[CustoMedio] [float] NULL,
	[DocumentoMovimentacao] [varchar](max) NULL,
 CONSTRAINT [PK_TB_ESTOQUE] PRIMARY KEY CLUSTERED 
(
	[IdEstoque] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContatoEndereco]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContatoEndereco](
	[IdContatoEndereco] [int] IDENTITY(1,1) NOT NULL,
	[IdContato] [int] NOT NULL,
	[IdEndereco] [int] NOT NULL,
 CONSTRAINT [PK_ContatoEndereco] PRIMARY KEY CLUSTERED 
(
	[IdContatoEndereco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contato]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contato](
	[IdContato] [int] IDENTITY(1,1) NOT NULL,
	[IdEndereco] [int] NULL,
	[IdTelefone] [int] NULL,
	[Nome] [varchar](255) NULL,
	[CPF] [varchar](20) NULL,
	[EMail] [varchar](255) NULL,
 CONSTRAINT [PK_Contato] PRIMARY KEY CLUSTERED 
(
	[IdContato] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FornecedorEndereco]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FornecedorEndereco](
	[FornecedorEndereco] [int] IDENTITY(1,1) NOT NULL,
	[IdFornecedor] [int] NOT NULL,
	[IdEndereco] [int] NOT NULL,
 CONSTRAINT [PK_FornecedorEndereco] PRIMARY KEY CLUSTERED 
(
	[FornecedorEndereco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotaFiscalObs]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NotaFiscalObs](
	[IdNFObs] [int] IDENTITY(1,1) NOT NULL,
	[IdNota] [int] NOT NULL,
	[Observacao] [varchar](max) NULL,
 CONSTRAINT [PK_NotaFiscalObs] PRIMARY KEY CLUSTERED 
(
	[IdNFObs] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NotaFiscalItem]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NotaFiscalItem](
	[IdNFItem] [int] IDENTITY(1,1) NOT NULL,
	[Item] [int] NULL,
	[IdNota] [int] NOT NULL,
	[IdProduto] [int] NULL,
	[Codigo] [varchar](16) NOT NULL,
	[Descricao] [varchar](60) NOT NULL,
	[Quantidade] [float] NULL,
	[ValorUnitario] [float] NULL,
	[AliquotaIPI] [float] NULL,
	[ValorIPI] [float] NULL,
	[AliquotaICMS] [float] NULL,
	[BaseICMS] [float] NULL,
	[ValorICMS] [float] NULL,
	[ValorTotal] [float] NULL,
	[PesoLiquido] [float] NULL,
	[PesoBruto] [float] NULL,
	[Volumes] [float] NULL,
	[IdUnidade] [int] NULL,
	[IdNCM] [int] NULL,
 CONSTRAINT [PK_NF_ITENS] PRIMARY KEY CLUSTERED 
(
	[IdNFItem] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TransportadoraEndereco]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportadoraEndereco](
	[IdTransportadoraEndereco] [int] IDENTITY(1,1) NOT NULL,
	[IdTransportadora] [int] NOT NULL,
	[IdEndereco] [int] NOT NULL,
 CONSTRAINT [PK_TransportadoraEndereco] PRIMARY KEY CLUSTERED 
(
	[IdTransportadoraEndereco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransportadoraContato]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportadoraContato](
	[IdTransportadoraContato] [int] IDENTITY(1,1) NOT NULL,
	[IdTransportadora] [int] NOT NULL,
	[IdContato] [int] NOT NULL,
 CONSTRAINT [PK_TransportadoraContato] PRIMARY KEY CLUSTERED 
(
	[IdTransportadoraContato] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimentoEstoque]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MovimentoEstoque](
	[IdMovimento] [int] IDENTITY(1,1) NOT NULL,
	[IdEstoque] [int] NULL,
	[IdProduto] [int] NOT NULL,
	[Data] [datetime] NOT NULL,
	[Quantidade] [float] NOT NULL,
	[TipoEntrSaida] [varchar](1) NOT NULL,
	[Historico] [varchar](max) NOT NULL,
	[Documento] [varchar](20) NOT NULL,
	[Saldo] [float] NULL,
	[QuantidadeEstoque] [float] NULL,
 CONSTRAINT [PK_MovimentoEstoque] PRIMARY KEY CLUSTERED 
(
	[IdMovimento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FornecedorContato]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FornecedorContato](
	[IdFornecedorContato] [int] IDENTITY(1,1) NOT NULL,
	[IdFornecedor] [int] NOT NULL,
	[IdContato] [int] NOT NULL,
 CONSTRAINT [PK_ForncedorContato] PRIMARY KEY CLUSTERED 
(
	[IdFornecedorContato] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteContato]    Script Date: 01/20/2015 15:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteContato](
	[IdClienteContato] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdContato] [int] NOT NULL,
 CONSTRAINT [PK_ClienteContato] PRIMARY KEY CLUSTERED 
(
	[IdClienteContato] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Cidade_UnidadeFederacao]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[Cidade]  WITH CHECK ADD  CONSTRAINT [FK_Cidade_UnidadeFederacao] FOREIGN KEY([IdUF])
REFERENCES [dbo].[UnidadeFederacao] ([IdUF])
GO
ALTER TABLE [dbo].[Cidade] CHECK CONSTRAINT [FK_Cidade_UnidadeFederacao]
GO
/****** Object:  ForeignKey [FK_ContaBancaria_Banco]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[ContaBancaria]  WITH CHECK ADD  CONSTRAINT [FK_ContaBancaria_Banco] FOREIGN KEY([IdBanco])
REFERENCES [dbo].[Banco] ([IdBanco])
GO
ALTER TABLE [dbo].[ContaBancaria] CHECK CONSTRAINT [FK_ContaBancaria_Banco]
GO
/****** Object:  ForeignKey [FK_CondicaoPagamentoIntervalo_CondicaoPagamento]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[CondicaoPagamentoIntervalo]  WITH CHECK ADD  CONSTRAINT [FK_CondicaoPagamentoIntervalo_CondicaoPagamento] FOREIGN KEY([IdCondicao])
REFERENCES [dbo].[CondicaoPagamento] ([IdCondicao])
GO
ALTER TABLE [dbo].[CondicaoPagamentoIntervalo] CHECK CONSTRAINT [FK_CondicaoPagamentoIntervalo_CondicaoPagamento]
GO
/****** Object:  ForeignKey [FK_ContasReceber_Cliente]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[ContasReceber]  WITH CHECK ADD  CONSTRAINT [FK_ContasReceber_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[ContasReceber] CHECK CONSTRAINT [FK_ContasReceber_Cliente]
GO
/****** Object:  ForeignKey [FK_ContasReceber_ContasContabil]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[ContasReceber]  WITH CHECK ADD  CONSTRAINT [FK_ContasReceber_ContasContabil] FOREIGN KEY([IdContaContabil])
REFERENCES [dbo].[ContaContabil] ([IdContaContabil])
GO
ALTER TABLE [dbo].[ContasReceber] CHECK CONSTRAINT [FK_ContasReceber_ContasContabil]
GO
/****** Object:  ForeignKey [FK_ContasReceber_Fornecedor]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[ContasReceber]  WITH CHECK ADD  CONSTRAINT [FK_ContasReceber_Fornecedor] FOREIGN KEY([IdFornecedor])
REFERENCES [dbo].[Fornecedor] ([IdFornecedor])
GO
ALTER TABLE [dbo].[ContasReceber] CHECK CONSTRAINT [FK_ContasReceber_Fornecedor]
GO
/****** Object:  ForeignKey [FK_ContasPagar_ContaContabil]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[ContasPagar]  WITH CHECK ADD  CONSTRAINT [FK_ContasPagar_ContaContabil] FOREIGN KEY([IdFornecedor])
REFERENCES [dbo].[Fornecedor] ([IdFornecedor])
GO
ALTER TABLE [dbo].[ContasPagar] CHECK CONSTRAINT [FK_ContasPagar_ContaContabil]
GO
/****** Object:  ForeignKey [FK_ContasPagar_ContaContabil1]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[ContasPagar]  WITH CHECK ADD  CONSTRAINT [FK_ContasPagar_ContaContabil1] FOREIGN KEY([IdContaContabil])
REFERENCES [dbo].[ContaContabil] ([IdContaContabil])
GO
ALTER TABLE [dbo].[ContasPagar] CHECK CONSTRAINT [FK_ContasPagar_ContaContabil1]
GO
/****** Object:  ForeignKey [FK_dbo.LogItems_dbo.Logs_LogId]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[LogItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LogItems_dbo.Logs_LogId] FOREIGN KEY([LogId])
REFERENCES [dbo].[Logs] ([LogId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LogItems] CHECK CONSTRAINT [FK_dbo.LogItems_dbo.Logs_LogId]
GO
/****** Object:  ForeignKey [FK_MoedaCotacao_Moeda]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[MoedaCotacao]  WITH CHECK ADD  CONSTRAINT [FK_MoedaCotacao_Moeda] FOREIGN KEY([IdMoeda])
REFERENCES [dbo].[Moeda] ([IdMoeda])
GO
ALTER TABLE [dbo].[MoedaCotacao] CHECK CONSTRAINT [FK_MoedaCotacao_Moeda]
GO
/****** Object:  ForeignKey [FK_FornecedorContaBancaria_Banco]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[FornecedorContaBancaria]  WITH CHECK ADD  CONSTRAINT [FK_FornecedorContaBancaria_Banco] FOREIGN KEY([IdBanco])
REFERENCES [dbo].[Banco] ([IdBanco])
GO
ALTER TABLE [dbo].[FornecedorContaBancaria] CHECK CONSTRAINT [FK_FornecedorContaBancaria_Banco]
GO
/****** Object:  ForeignKey [FK_ModuloPrograma_Modulo]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[ModuloPrograma]  WITH CHECK ADD  CONSTRAINT [FK_ModuloPrograma_Modulo] FOREIGN KEY([IdModulo])
REFERENCES [dbo].[Modulo] ([IdModulo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ModuloPrograma] CHECK CONSTRAINT [FK_ModuloPrograma_Modulo]
GO
/****** Object:  ForeignKey [FK_ModuloPrograma_Programa]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[ModuloPrograma]  WITH CHECK ADD  CONSTRAINT [FK_ModuloPrograma_Programa] FOREIGN KEY([IdPrograma])
REFERENCES [dbo].[Programa] ([IdPrograma])
GO
ALTER TABLE [dbo].[ModuloPrograma] CHECK CONSTRAINT [FK_ModuloPrograma_Programa]
GO
/****** Object:  ForeignKey [FK_Telefone_TipoTelefone]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[Telefone]  WITH CHECK ADD  CONSTRAINT [FK_Telefone_TipoTelefone] FOREIGN KEY([IdTipoTelefone])
REFERENCES [dbo].[TipoTelefone] ([IdTipoTelefone])
GO
ALTER TABLE [dbo].[Telefone] CHECK CONSTRAINT [FK_Telefone_TipoTelefone]
GO
/****** Object:  ForeignKey [FK_Produto_ClassificacaoFiscal]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [FK_Produto_ClassificacaoFiscal] FOREIGN KEY([IdNCM])
REFERENCES [dbo].[ClassificacaoFiscal] ([IdNCM])
GO
ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [FK_Produto_ClassificacaoFiscal]
GO
/****** Object:  ForeignKey [FK_Produto_TipoProduto]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [FK_Produto_TipoProduto] FOREIGN KEY([IdTipoProduto])
REFERENCES [dbo].[TipoProduto] ([IdTipoProduto])
GO
ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [FK_Produto_TipoProduto]
GO
/****** Object:  ForeignKey [FK_Produto_UnidadeExpedicao]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [FK_Produto_UnidadeExpedicao] FOREIGN KEY([IdUnidadeExpedicao])
REFERENCES [dbo].[Unidade] ([IdUnidade])
GO
ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [FK_Produto_UnidadeExpedicao]
GO
/****** Object:  ForeignKey [FK_Produto_UnidadeVenda]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [FK_Produto_UnidadeVenda] FOREIGN KEY([IdUnidadeVenda])
REFERENCES [dbo].[Unidade] ([IdUnidade])
GO
ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [FK_Produto_UnidadeVenda]
GO
/****** Object:  ForeignKey [FK_PerfilModulo_Modulo]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[PerfilModulo]  WITH CHECK ADD  CONSTRAINT [FK_PerfilModulo_Modulo] FOREIGN KEY([idModulo])
REFERENCES [dbo].[Modulo] ([IdModulo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PerfilModulo] CHECK CONSTRAINT [FK_PerfilModulo_Modulo]
GO
/****** Object:  ForeignKey [FK_PedidoCompra_CondicaoPagamento]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[PedidoCompra]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompra_CondicaoPagamento] FOREIGN KEY([IdCondicao])
REFERENCES [dbo].[CondicaoPagamento] ([IdCondicao])
GO
ALTER TABLE [dbo].[PedidoCompra] CHECK CONSTRAINT [FK_PedidoCompra_CondicaoPagamento]
GO
/****** Object:  ForeignKey [FK_PedidoCompra_Fornecedor]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[PedidoCompra]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompra_Fornecedor] FOREIGN KEY([IdFornecedor])
REFERENCES [dbo].[Fornecedor] ([IdFornecedor])
GO
ALTER TABLE [dbo].[PedidoCompra] CHECK CONSTRAINT [FK_PedidoCompra_Fornecedor]
GO
/****** Object:  ForeignKey [FK_Usuario_Perfil]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([IdPerfil])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Perfil]
GO
/****** Object:  ForeignKey [FK_UnidadeFederacaoNCM_ClassificacaoFiscal]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[UnidadeFederacaoNCM]  WITH CHECK ADD  CONSTRAINT [FK_UnidadeFederacaoNCM_ClassificacaoFiscal] FOREIGN KEY([IdUFNCM])
REFERENCES [dbo].[ClassificacaoFiscal] ([IdNCM])
GO
ALTER TABLE [dbo].[UnidadeFederacaoNCM] CHECK CONSTRAINT [FK_UnidadeFederacaoNCM_ClassificacaoFiscal]
GO
/****** Object:  ForeignKey [FK_UnidadeFederacaoNCM_UnidadeFederacao]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[UnidadeFederacaoNCM]  WITH CHECK ADD  CONSTRAINT [FK_UnidadeFederacaoNCM_UnidadeFederacao] FOREIGN KEY([IdUF])
REFERENCES [dbo].[UnidadeFederacao] ([IdUF])
GO
ALTER TABLE [dbo].[UnidadeFederacaoNCM] CHECK CONSTRAINT [FK_UnidadeFederacaoNCM_UnidadeFederacao]
GO
/****** Object:  ForeignKey [FK_PedidoCompraItem_PedidoCompra]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[PedidoCompraItem]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItem_PedidoCompra] FOREIGN KEY([IdPedidoCompra])
REFERENCES [dbo].[PedidoCompra] ([IdPedidoCompra])
GO
ALTER TABLE [dbo].[PedidoCompraItem] CHECK CONSTRAINT [FK_PedidoCompraItem_PedidoCompra]
GO
/****** Object:  ForeignKey [FK_PedidoCompraItem_Produto]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[PedidoCompraItem]  WITH CHECK ADD  CONSTRAINT [FK_PedidoCompraItem_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([IdProduto])
GO
ALTER TABLE [dbo].[PedidoCompraItem] CHECK CONSTRAINT [FK_PedidoCompraItem_Produto]
GO
/****** Object:  ForeignKey [FK_TransportadoraTelefone_Telefone]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[TransportadoraTelefone]  WITH CHECK ADD  CONSTRAINT [FK_TransportadoraTelefone_Telefone] FOREIGN KEY([IdTelefone])
REFERENCES [dbo].[Telefone] ([IdTelefone])
GO
ALTER TABLE [dbo].[TransportadoraTelefone] CHECK CONSTRAINT [FK_TransportadoraTelefone_Telefone]
GO
/****** Object:  ForeignKey [FK_TransportadoraTelefone_Transportadora]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[TransportadoraTelefone]  WITH CHECK ADD  CONSTRAINT [FK_TransportadoraTelefone_Transportadora] FOREIGN KEY([IdTransportadora])
REFERENCES [dbo].[Transportadora] ([IdTransportadora])
GO
ALTER TABLE [dbo].[TransportadoraTelefone] CHECK CONSTRAINT [FK_TransportadoraTelefone_Transportadora]
GO
/****** Object:  ForeignKey [FK_Permissao_Perfil]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[Permissao]  WITH CHECK ADD  CONSTRAINT [FK_Permissao_Perfil] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([IdPerfil])
GO
ALTER TABLE [dbo].[Permissao] CHECK CONSTRAINT [FK_Permissao_Perfil]
GO
/****** Object:  ForeignKey [FK_Permissao_Programa]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[Permissao]  WITH CHECK ADD  CONSTRAINT [FK_Permissao_Programa] FOREIGN KEY([IdPrograma])
REFERENCES [dbo].[Programa] ([IdPrograma])
GO
ALTER TABLE [dbo].[Permissao] CHECK CONSTRAINT [FK_Permissao_Programa]
GO
/****** Object:  ForeignKey [FK_Permissao_Usuario]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[Permissao]  WITH CHECK ADD  CONSTRAINT [FK_Permissao_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Permissao] CHECK CONSTRAINT [FK_Permissao_Usuario]
GO
/****** Object:  ForeignKey [FK_NotaFiscal_Cidade]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[NotaFiscal]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscal_Cidade] FOREIGN KEY([IdCidade])
REFERENCES [dbo].[Cidade] ([IdCidade])
GO
ALTER TABLE [dbo].[NotaFiscal] CHECK CONSTRAINT [FK_NotaFiscal_Cidade]
GO
/****** Object:  ForeignKey [FK_NotaFiscal_CodigoFaturamento]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[NotaFiscal]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscal_CodigoFaturamento] FOREIGN KEY([IdCFOP])
REFERENCES [dbo].[CodigoFaturamento] ([IdCFOP])
GO
ALTER TABLE [dbo].[NotaFiscal] CHECK CONSTRAINT [FK_NotaFiscal_CodigoFaturamento]
GO
/****** Object:  ForeignKey [FK_NotaFiscal_PedidoCompra]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[NotaFiscal]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscal_PedidoCompra] FOREIGN KEY([IdPedidoCompra])
REFERENCES [dbo].[PedidoCompra] ([IdPedidoCompra])
GO
ALTER TABLE [dbo].[NotaFiscal] CHECK CONSTRAINT [FK_NotaFiscal_PedidoCompra]
GO
/****** Object:  ForeignKey [FK_NotaFiscal_Telefone]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[NotaFiscal]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscal_Telefone] FOREIGN KEY([IdTelefone])
REFERENCES [dbo].[Telefone] ([IdTelefone])
GO
ALTER TABLE [dbo].[NotaFiscal] CHECK CONSTRAINT [FK_NotaFiscal_Telefone]
GO
/****** Object:  ForeignKey [FK_NotaFiscal_TipoDocumento]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[NotaFiscal]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscal_TipoDocumento] FOREIGN KEY([IdDocumento])
REFERENCES [dbo].[TipoDocumento] ([IdDocumento])
GO
ALTER TABLE [dbo].[NotaFiscal] CHECK CONSTRAINT [FK_NotaFiscal_TipoDocumento]
GO
/****** Object:  ForeignKey [FK_NotaFiscal_Transportadora]    Script Date: 01/20/2015 15:38:32 ******/
ALTER TABLE [dbo].[NotaFiscal]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscal_Transportadora] FOREIGN KEY([IdTransportadora])
REFERENCES [dbo].[Transportadora] ([IdTransportadora])
GO
ALTER TABLE [dbo].[NotaFiscal] CHECK CONSTRAINT [FK_NotaFiscal_Transportadora]
GO
/****** Object:  ForeignKey [FK_FornecedorTelefone_Fornecedor]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[FornecedorTelefone]  WITH CHECK ADD  CONSTRAINT [FK_FornecedorTelefone_Fornecedor] FOREIGN KEY([IdFornecedor])
REFERENCES [dbo].[Fornecedor] ([IdFornecedor])
GO
ALTER TABLE [dbo].[FornecedorTelefone] CHECK CONSTRAINT [FK_FornecedorTelefone_Fornecedor]
GO
/****** Object:  ForeignKey [FK_FornecedorTelefone_Telefone]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[FornecedorTelefone]  WITH CHECK ADD  CONSTRAINT [FK_FornecedorTelefone_Telefone] FOREIGN KEY([IdTelefone])
REFERENCES [dbo].[Telefone] ([IdTelefone])
GO
ALTER TABLE [dbo].[FornecedorTelefone] CHECK CONSTRAINT [FK_FornecedorTelefone_Telefone]
GO
/****** Object:  ForeignKey [FK_Endereco_Cidade]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Endereco_Cidade] FOREIGN KEY([IdCidade])
REFERENCES [dbo].[Cidade] ([IdCidade])
GO
ALTER TABLE [dbo].[Endereco] CHECK CONSTRAINT [FK_Endereco_Cidade]
GO
/****** Object:  ForeignKey [FK_Endereco_Pais]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Endereco_Pais] FOREIGN KEY([IdPais])
REFERENCES [dbo].[Pais] ([IdPais])
GO
ALTER TABLE [dbo].[Endereco] CHECK CONSTRAINT [FK_Endereco_Pais]
GO
/****** Object:  ForeignKey [FK_Endereco_TipoEndereco]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Endereco_TipoEndereco] FOREIGN KEY([IdTipoEndereco])
REFERENCES [dbo].[TipoEndereco] ([IdTipoEndereco])
GO
ALTER TABLE [dbo].[Endereco] CHECK CONSTRAINT [FK_Endereco_TipoEndereco]
GO
/****** Object:  ForeignKey [FK_Endereco_UnidadeFederacao]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Endereco_UnidadeFederacao] FOREIGN KEY([IdUF])
REFERENCES [dbo].[UnidadeFederacao] ([IdUF])
GO
ALTER TABLE [dbo].[Endereco] CHECK CONSTRAINT [FK_Endereco_UnidadeFederacao]
GO
/****** Object:  ForeignKey [FK_ContatoTelefone_Telefone]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[ContatoTelefone]  WITH CHECK ADD  CONSTRAINT [FK_ContatoTelefone_Telefone] FOREIGN KEY([IdTelefone])
REFERENCES [dbo].[Telefone] ([IdTelefone])
GO
ALTER TABLE [dbo].[ContatoTelefone] CHECK CONSTRAINT [FK_ContatoTelefone_Telefone]
GO
/****** Object:  ForeignKey [FK_ContasReceberBaixa_ContaBancaria]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[ContasReceberBaixa]  WITH CHECK ADD  CONSTRAINT [FK_ContasReceberBaixa_ContaBancaria] FOREIGN KEY([IdConta])
REFERENCES [dbo].[ContaBancaria] ([IdConta])
GO
ALTER TABLE [dbo].[ContasReceberBaixa] CHECK CONSTRAINT [FK_ContasReceberBaixa_ContaBancaria]
GO
/****** Object:  ForeignKey [FK_ContasReceberBaixa_ContasReceber]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[ContasReceberBaixa]  WITH CHECK ADD  CONSTRAINT [FK_ContasReceberBaixa_ContasReceber] FOREIGN KEY([IdRecebimento])
REFERENCES [dbo].[ContasReceber] ([IdRecebimento])
GO
ALTER TABLE [dbo].[ContasReceberBaixa] CHECK CONSTRAINT [FK_ContasReceberBaixa_ContasReceber]
GO
/****** Object:  ForeignKey [FK_ContasReceberAcresDesc_ContasReceber]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[ContasReceberAcresDesc]  WITH CHECK ADD  CONSTRAINT [FK_ContasReceberAcresDesc_ContasReceber] FOREIGN KEY([IdRecebimento])
REFERENCES [dbo].[ContasReceber] ([IdRecebimento])
GO
ALTER TABLE [dbo].[ContasReceberAcresDesc] CHECK CONSTRAINT [FK_ContasReceberAcresDesc_ContasReceber]
GO
/****** Object:  ForeignKey [FK_ContasPagarBaixa_ContaBancaria]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[ContasPagarBaixa]  WITH CHECK ADD  CONSTRAINT [FK_ContasPagarBaixa_ContaBancaria] FOREIGN KEY([IdConta])
REFERENCES [dbo].[ContaBancaria] ([IdConta])
GO
ALTER TABLE [dbo].[ContasPagarBaixa] CHECK CONSTRAINT [FK_ContasPagarBaixa_ContaBancaria]
GO
/****** Object:  ForeignKey [FK_ContasPagarBaixa_ContasPagar]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[ContasPagarBaixa]  WITH CHECK ADD  CONSTRAINT [FK_ContasPagarBaixa_ContasPagar] FOREIGN KEY([IdPagamento])
REFERENCES [dbo].[ContasPagar] ([IdPagamento])
GO
ALTER TABLE [dbo].[ContasPagarBaixa] CHECK CONSTRAINT [FK_ContasPagarBaixa_ContasPagar]
GO
/****** Object:  ForeignKey [FK_ContasPagarAcresDesc_ContasPagar]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[ContasPagarAcresDesc]  WITH CHECK ADD  CONSTRAINT [FK_ContasPagarAcresDesc_ContasPagar] FOREIGN KEY([IdPagamento])
REFERENCES [dbo].[ContasPagar] ([IdPagamento])
GO
ALTER TABLE [dbo].[ContasPagarAcresDesc] CHECK CONSTRAINT [FK_ContasPagarAcresDesc_ContasPagar]
GO
/****** Object:  ForeignKey [FK_AjusteEstoque_Produto]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[AjusteEstoque]  WITH CHECK ADD  CONSTRAINT [FK_AjusteEstoque_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([IdProduto])
GO
ALTER TABLE [dbo].[AjusteEstoque] CHECK CONSTRAINT [FK_AjusteEstoque_Produto]
GO
/****** Object:  ForeignKey [FK_AjusteEstoque_Usuario]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[AjusteEstoque]  WITH CHECK ADD  CONSTRAINT [FK_AjusteEstoque_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[AjusteEstoque] CHECK CONSTRAINT [FK_AjusteEstoque_Usuario]
GO
/****** Object:  ForeignKey [FK_ClienteTelefone_Cliente]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[ClienteTelefone]  WITH CHECK ADD  CONSTRAINT [FK_ClienteTelefone_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[ClienteTelefone] CHECK CONSTRAINT [FK_ClienteTelefone_Cliente]
GO
/****** Object:  ForeignKey [FK_ClienteTelefone_Telefone]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[ClienteTelefone]  WITH CHECK ADD  CONSTRAINT [FK_ClienteTelefone_Telefone] FOREIGN KEY([IdTelefone])
REFERENCES [dbo].[Telefone] ([IdTelefone])
GO
ALTER TABLE [dbo].[ClienteTelefone] CHECK CONSTRAINT [FK_ClienteTelefone_Telefone]
GO
/****** Object:  ForeignKey [FK_ClienteEndereco_Cliente]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[ClienteEndereco]  WITH CHECK ADD  CONSTRAINT [FK_ClienteEndereco_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[ClienteEndereco] CHECK CONSTRAINT [FK_ClienteEndereco_Cliente]
GO
/****** Object:  ForeignKey [FK_ClienteEndereco_Endereco]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[ClienteEndereco]  WITH CHECK ADD  CONSTRAINT [FK_ClienteEndereco_Endereco] FOREIGN KEY([IdEndereco])
REFERENCES [dbo].[Endereco] ([IdEndereco])
GO
ALTER TABLE [dbo].[ClienteEndereco] CHECK CONSTRAINT [FK_ClienteEndereco_Endereco]
GO
/****** Object:  ForeignKey [FK_Estoque_NotaFiscal]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[Estoque]  WITH CHECK ADD  CONSTRAINT [FK_Estoque_NotaFiscal] FOREIGN KEY([IdNota])
REFERENCES [dbo].[NotaFiscal] ([IdNota])
GO
ALTER TABLE [dbo].[Estoque] CHECK CONSTRAINT [FK_Estoque_NotaFiscal]
GO
/****** Object:  ForeignKey [FK_Estoque_Produto]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[Estoque]  WITH CHECK ADD  CONSTRAINT [FK_Estoque_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([IdProduto])
GO
ALTER TABLE [dbo].[Estoque] CHECK CONSTRAINT [FK_Estoque_Produto]
GO
/****** Object:  ForeignKey [FK_ContatoEndereco_Endereco]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[ContatoEndereco]  WITH CHECK ADD  CONSTRAINT [FK_ContatoEndereco_Endereco] FOREIGN KEY([IdEndereco])
REFERENCES [dbo].[Endereco] ([IdEndereco])
GO
ALTER TABLE [dbo].[ContatoEndereco] CHECK CONSTRAINT [FK_ContatoEndereco_Endereco]
GO
/****** Object:  ForeignKey [FK_Contato_Endereco]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[Contato]  WITH CHECK ADD  CONSTRAINT [FK_Contato_Endereco] FOREIGN KEY([IdEndereco])
REFERENCES [dbo].[Endereco] ([IdEndereco])
GO
ALTER TABLE [dbo].[Contato] CHECK CONSTRAINT [FK_Contato_Endereco]
GO
/****** Object:  ForeignKey [FK_Contato_Telefone]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[Contato]  WITH CHECK ADD  CONSTRAINT [FK_Contato_Telefone] FOREIGN KEY([IdTelefone])
REFERENCES [dbo].[Telefone] ([IdTelefone])
GO
ALTER TABLE [dbo].[Contato] CHECK CONSTRAINT [FK_Contato_Telefone]
GO
/****** Object:  ForeignKey [FK_FornecedorEndereco_Endereco]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[FornecedorEndereco]  WITH CHECK ADD  CONSTRAINT [FK_FornecedorEndereco_Endereco] FOREIGN KEY([IdEndereco])
REFERENCES [dbo].[Endereco] ([IdEndereco])
GO
ALTER TABLE [dbo].[FornecedorEndereco] CHECK CONSTRAINT [FK_FornecedorEndereco_Endereco]
GO
/****** Object:  ForeignKey [FK_FornecedorEndereco_Fornecedor]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[FornecedorEndereco]  WITH CHECK ADD  CONSTRAINT [FK_FornecedorEndereco_Fornecedor] FOREIGN KEY([IdFornecedor])
REFERENCES [dbo].[Fornecedor] ([IdFornecedor])
GO
ALTER TABLE [dbo].[FornecedorEndereco] CHECK CONSTRAINT [FK_FornecedorEndereco_Fornecedor]
GO
/****** Object:  ForeignKey [FK_NotaFiscalObs_NotaFiscal]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[NotaFiscalObs]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscalObs_NotaFiscal] FOREIGN KEY([IdNota])
REFERENCES [dbo].[NotaFiscal] ([IdNota])
GO
ALTER TABLE [dbo].[NotaFiscalObs] CHECK CONSTRAINT [FK_NotaFiscalObs_NotaFiscal]
GO
/****** Object:  ForeignKey [FK_NotaFiscalItem_ClassificacaoFiscal]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[NotaFiscalItem]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscalItem_ClassificacaoFiscal] FOREIGN KEY([IdNCM])
REFERENCES [dbo].[ClassificacaoFiscal] ([IdNCM])
GO
ALTER TABLE [dbo].[NotaFiscalItem] CHECK CONSTRAINT [FK_NotaFiscalItem_ClassificacaoFiscal]
GO
/****** Object:  ForeignKey [FK_NotaFiscalItem_NotaFiscal]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[NotaFiscalItem]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscalItem_NotaFiscal] FOREIGN KEY([IdNota])
REFERENCES [dbo].[NotaFiscal] ([IdNota])
GO
ALTER TABLE [dbo].[NotaFiscalItem] CHECK CONSTRAINT [FK_NotaFiscalItem_NotaFiscal]
GO
/****** Object:  ForeignKey [FK_NotaFiscalItem_Produto]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[NotaFiscalItem]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscalItem_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([IdProduto])
GO
ALTER TABLE [dbo].[NotaFiscalItem] CHECK CONSTRAINT [FK_NotaFiscalItem_Produto]
GO
/****** Object:  ForeignKey [FK_NotaFiscalItem_Unidade]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[NotaFiscalItem]  WITH CHECK ADD  CONSTRAINT [FK_NotaFiscalItem_Unidade] FOREIGN KEY([IdUnidade])
REFERENCES [dbo].[Unidade] ([IdUnidade])
GO
ALTER TABLE [dbo].[NotaFiscalItem] CHECK CONSTRAINT [FK_NotaFiscalItem_Unidade]
GO
/****** Object:  ForeignKey [FK_TransportadoraEndereco_Endereco]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[TransportadoraEndereco]  WITH CHECK ADD  CONSTRAINT [FK_TransportadoraEndereco_Endereco] FOREIGN KEY([IdEndereco])
REFERENCES [dbo].[Endereco] ([IdEndereco])
GO
ALTER TABLE [dbo].[TransportadoraEndereco] CHECK CONSTRAINT [FK_TransportadoraEndereco_Endereco]
GO
/****** Object:  ForeignKey [FK_TransportadoraEndereco_Transportadora]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[TransportadoraEndereco]  WITH CHECK ADD  CONSTRAINT [FK_TransportadoraEndereco_Transportadora] FOREIGN KEY([IdTransportadora])
REFERENCES [dbo].[Transportadora] ([IdTransportadora])
GO
ALTER TABLE [dbo].[TransportadoraEndereco] CHECK CONSTRAINT [FK_TransportadoraEndereco_Transportadora]
GO
/****** Object:  ForeignKey [FK_TransportadoraContato_Contato]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[TransportadoraContato]  WITH CHECK ADD  CONSTRAINT [FK_TransportadoraContato_Contato] FOREIGN KEY([IdContato])
REFERENCES [dbo].[Contato] ([IdContato])
GO
ALTER TABLE [dbo].[TransportadoraContato] CHECK CONSTRAINT [FK_TransportadoraContato_Contato]
GO
/****** Object:  ForeignKey [FK_TransportadoraContato_Transportadora]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[TransportadoraContato]  WITH CHECK ADD  CONSTRAINT [FK_TransportadoraContato_Transportadora] FOREIGN KEY([IdTransportadora])
REFERENCES [dbo].[Transportadora] ([IdTransportadora])
GO
ALTER TABLE [dbo].[TransportadoraContato] CHECK CONSTRAINT [FK_TransportadoraContato_Transportadora]
GO
/****** Object:  ForeignKey [FK_MovimentoEstoque_Estoque]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[MovimentoEstoque]  WITH CHECK ADD  CONSTRAINT [FK_MovimentoEstoque_Estoque] FOREIGN KEY([IdEstoque])
REFERENCES [dbo].[Estoque] ([IdEstoque])
GO
ALTER TABLE [dbo].[MovimentoEstoque] CHECK CONSTRAINT [FK_MovimentoEstoque_Estoque]
GO
/****** Object:  ForeignKey [FK_MovimentoEstoque_Produto]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[MovimentoEstoque]  WITH CHECK ADD  CONSTRAINT [FK_MovimentoEstoque_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([IdProduto])
GO
ALTER TABLE [dbo].[MovimentoEstoque] CHECK CONSTRAINT [FK_MovimentoEstoque_Produto]
GO
/****** Object:  ForeignKey [FK_FornecedorContato_Contato]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[FornecedorContato]  WITH CHECK ADD  CONSTRAINT [FK_FornecedorContato_Contato] FOREIGN KEY([IdContato])
REFERENCES [dbo].[Contato] ([IdContato])
GO
ALTER TABLE [dbo].[FornecedorContato] CHECK CONSTRAINT [FK_FornecedorContato_Contato]
GO
/****** Object:  ForeignKey [FK_FornecedorContato_Fornecedor]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[FornecedorContato]  WITH CHECK ADD  CONSTRAINT [FK_FornecedorContato_Fornecedor] FOREIGN KEY([IdFornecedor])
REFERENCES [dbo].[Fornecedor] ([IdFornecedor])
GO
ALTER TABLE [dbo].[FornecedorContato] CHECK CONSTRAINT [FK_FornecedorContato_Fornecedor]
GO
/****** Object:  ForeignKey [FK_ClienteContato_Cliente]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[ClienteContato]  WITH CHECK ADD  CONSTRAINT [FK_ClienteContato_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[ClienteContato] CHECK CONSTRAINT [FK_ClienteContato_Cliente]
GO
/****** Object:  ForeignKey [FK_ClienteContato_Contato]    Script Date: 01/20/2015 15:38:33 ******/
ALTER TABLE [dbo].[ClienteContato]  WITH CHECK ADD  CONSTRAINT [FK_ClienteContato_Contato] FOREIGN KEY([IdContato])
REFERENCES [dbo].[Contato] ([IdContato])
GO
ALTER TABLE [dbo].[ClienteContato] CHECK CONSTRAINT [FK_ClienteContato_Contato]
GO
