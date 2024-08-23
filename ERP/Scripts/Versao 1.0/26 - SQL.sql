
/****** Object:  Table [dbo].[RoteiroOperacaoRecursos]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoteiroOperacaoRecursos](
	[IdRoteiroOperacaoRecurso] [int] IDENTITY(1,1) NOT NULL,
	[IdRoteiroOperacao] [int] NULL,
	[IdRoteiroOperacaoLinha] [int] NULL,
	[Tipo] [int] NULL,
	[IdRecurso] [int] NULL,
	[IdCapacidadeRecurso] [int] NULL,
	[IdGrupoRecurso] [int] NULL,
	[IdRecursoAvaliacaoCusto] [int] NULL,
	[PlanejamentoTrabalho] [bit] NULL,
	[PlanejamentoOperacao] [bit] NULL,
 CONSTRAINT [PK_RoteiroOperacaoRecursos] PRIMARY KEY CLUSTERED 
(
	[IdRoteiroOperacaoRecurso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TempoTrabalho]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TempoTrabalho](
	[IdTempoTrabalho] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[Fechado] [bit] NULL,
 CONSTRAINT [PK_TempoTrabalho] PRIMARY KEY CLUSTERED 
(
	[IdTempoTrabalho] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Calendario]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Calendario](
	[IdCalendario] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[PadraoHoraDiaTrabalho] [int] NULL,
 CONSTRAINT [PK_Calendario] PRIMARY KEY CLUSTERED 
(
	[IdCalendario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CapacidadeRecursos]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CapacidadeRecursos](
	[IdCapacidadeRecursos] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
 CONSTRAINT [PK_CapacidadeRecursos] PRIMARY KEY CLUSTERED 
(
	[IdCapacidadeRecursos] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GrupoRoteiro]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GrupoRoteiro](
	[IdGrupoRoteiro] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[CalcularTempoPreparacao] [bit] NULL,
	[CalcularTempoExecusao] [bit] NULL,
	[CalcularQuantidade] [bit] NULL,
	[ConsumoAutomaticoTempoExecusao] [bit] NULL,
	[ConsumoAutomaticoTempoPreparacao] [bit] NULL,
	[RelatarQuantidadeComoConcluida] [bit] NULL,
	[RelatarOperacaoComoConcluida] [bit] NULL,
 CONSTRAINT [PK_GrupoRoteiro] PRIMARY KEY CLUSTERED 
(
	[IdGrupoRoteiro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ListaMateriais]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ListaMateriais](
	[IdListaMateriais] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NULL,
	[Aprovado] [bit] NULL,
	[NomeAprovador] [varchar](255) NULL,
	[Bom_Formula] [int] NULL,
	[IdGrupoLancamento] [int] NULL,
	[IdArmazem] [int] NULL,
 CONSTRAINT [PK_ListaMateriais] PRIMARY KEY CLUSTERED 
(
	[IdListaMateriais] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GrupoRoteiroLinha]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupoRoteiroLinha](
	[IdGrupoRoteiroLinha] [int] IDENTITY(1,1) NOT NULL,
	[IdGrupoRoteiro] [int] NULL,
	[TipoRoteiroTrabalho] [int] NULL,
	[Ativacao] [bit] NULL,
	[Capacidade] [bit] NULL,
	[GerenciamentoTrabalho] [bit] NULL,
	[HorarioTrabalho] [bit] NULL,
 CONSTRAINT [PK_GrupoRoteiroLinha] PRIMARY KEY CLUSTERED 
(
	[IdGrupoRoteiroLinha] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrupoRecursos]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GrupoRecursos](
	[IdGrupoRecursos] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[IdArmazem] [int] NULL,
 CONSTRAINT [PK_GrupoRecursos] PRIMARY KEY CLUSTERED 
(
	[IdGrupoRecursos] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LocalProducao]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocalProducao](
	[IdLocalProducao] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[IdArmazem] [int] NULL,
	[IdDepositoEntrada] [int] NULL,
	[IdDepositoSaida] [int] NULL,
 CONSTRAINT [PK_UnidadeProducao] PRIMARY KEY CLUSTERED 
(
	[IdLocalProducao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CapacidadeRecursosLinhas]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CapacidadeRecursosLinhas](
	[IdCapacidadeRecursosLinhas] [int] IDENTITY(1,1) NOT NULL,
	[IdCapacidadeRecursos] [int] NULL,
	[DataEfetivacao] [datetime] NULL,
	[DataVencimento] [datetime] NULL,
	[Prioridade] [int] NULL,
	[Nivel] [int] NULL,
 CONSTRAINT [PK_CapacidadeRecursosLinhas] PRIMARY KEY CLUSTERED 
(
	[IdCapacidadeRecursosLinhas] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalendarioDataLinhas]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalendarioDataLinhas](
	[IdCalendarioDataLinhas] [int] IDENTITY(1,1) NOT NULL,
	[IdCalendario] [int] NULL,
	[IdTempoTrabalho] [int] NULL,
	[Descricao] [int] NULL,
	[De] [datetime] NULL,
	[Ate] [datetime] NULL,
	[PorcentagemEficiencia] [decimal](18, 4) NULL,
 CONSTRAINT [PK_CalandarioDataLinhas] PRIMARY KEY CLUSTERED 
(
	[IdCalendarioDataLinhas] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalendarioData]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalendarioData](
	[IdCalendarioData] [int] IDENTITY(1,1) NOT NULL,
	[IdCalendario] [int] NULL,
	[Data] [datetime] NULL,
	[DiaSemana] [int] NULL,
	[IdFeriado] [int] NULL,
	[Controle] [int] NULL,
 CONSTRAINT [PK_CalendarioData] PRIMARY KEY CLUSTERED 
(
	[IdCalendarioData] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TempoTrabalhoLinhas]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempoTrabalhoLinhas](
	[IdTempoTrabalhoLinha] [int] IDENTITY(1,1) NOT NULL,
	[IdTempoTrabalho] [int] NULL,
	[DiaSemana] [int] NULL,
	[De] [datetime] NULL,
	[Ate] [datetime] NULL,
	[PorcentagemEficiencia] [decimal](18, 4) NULL,
 CONSTRAINT [PK_TempoTrabalhoLinhas] PRIMARY KEY CLUSTERED 
(
	[IdTempoTrabalhoLinha] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roteiro]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roteiro](
	[IdRoteiro] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[Aprovado] [bit] NULL,
	[IdFuncionarioAprovador] [int] NULL,
	[AprovarRoteiro] [int] NULL,
	[IdGrupoLancamento] [int] NULL,
	[VerificarRoteiro] [bit] NULL,
 CONSTRAINT [PK_Roteiro] PRIMARY KEY CLUSTERED 
(
	[IdRoteiro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoteiroOperacao]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoteiroOperacao](
	[IdRoteiroOperacao] [int] IDENTITY(1,1) NOT NULL,
	[IdRoteiro] [int] NULL,
	[Atividade] [int] NULL,
	[Prioridade] [int] NULL,
	[Sequencia] [int] NULL,
	[Acumulado] [decimal](18, 4) NULL,
	[PorcentagemSucata] [int] NULL,
	[Proximo] [int] NULL,
	[TaxaHoraTrabalhoTarefa] [int] NULL,
	[TipoVinculo] [int] NULL,
 CONSTRAINT [PK_RoteiroOperacao] PRIMARY KEY CLUSTERED 
(
	[IdRoteiroOperacao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recursos]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recursos](
	[IdRecurso] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[Tipo] [int] NULL,
	[UnidadeCapacidade] [int] NULL,
	[Capacidade] [decimal](18, 4) NULL,
	[CapacidadeLote] [decimal](18, 4) NULL,
	[PorcentagemEficiencia] [decimal](18, 4) NULL,
	[PorcentagemPlanoOperacao] [decimal](18, 4) NULL,
	[CapacidadeFinita] [bit] NULL,
	[PropriedadeFinita] [bit] NULL,
	[Exclusivo] [bit] NULL,
	[IdGrupoRoteiro] [int] NULL,
	[PorcentagemSucata] [int] NULL,
	[TempoEsperaAnterior] [int] NULL,
	[TempoEsperaPosterior] [int] NULL,
	[TempoExecusao] [int] NULL,
	[TempoPreparacao] [int] NULL,
	[TempoTransito] [int] NULL,
	[IdFuncionario] [int] NULL,
	[HorasTempo] [int] NULL,
	[IdLocalProducao] [int] NULL,
	[IdContaContabilCusto] [int] NULL,
	[IdContaContabilContraCusto] [int] NULL,
	[IdContaContabilWIP] [int] NULL,
	[IdContaContabilContaPartidaWIP] [int] NULL,
 CONSTRAINT [PK_Recursos] PRIMARY KEY CLUSTERED 
(
	[IdRecurso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GrupoRecursoLinha]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GrupoRecursoLinha](
	[IdGrupoRecursoLinha] [int] IDENTITY(1,1) NOT NULL,
	[IdGrupoRecurso] [int] NULL,
	[IdRecurso] [int] NULL,
	[Descricao] [varchar](255) NULL,
	[Ate] [datetime] NULL,
	[IdCalendario] [int] NULL,
	[IdDeposito] [int] NULL,
 CONSTRAINT [PK_GrupoRecursoLinha] PRIMARY KEY CLUSTERED 
(
	[IdGrupoRecursoLinha] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoteiroOperacaoLinhas]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoteiroOperacaoLinhas](
	[IdRoteiroOperacaoLinhas] [int] IDENTITY(1,1) NOT NULL,
	[IdRoteiroOperacao] [int] NULL,
	[CodigoItem] [int] NULL,
	[IdProduto] [int] NULL,
	[IdGrupoLancamento] [int] NULL,
	[IdGrupoRoteiros] [int] NULL,
	[IdArmazem] [int] NULL,
	[Carregar] [int] NULL,
	[QtdeRecursos] [int] NULL,
	[ValorCustoOperacao] [decimal](18, 4) NULL,
	[VAlorCustoQuantidade] [decimal](18, 4) NULL,
	[Fator] [decimal](18, 4) NULL,
	[Formula] [decimal](18, 4) NULL,
 CONSTRAINT [PK_RoteiroOperacaoLinhas] PRIMARY KEY CLUSTERED 
(
	[IdRoteiroOperacaoLinhas] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaMateriaisItem]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ListaMateriaisItem](
	[IdListaMateriaisItem] [int] IDENTITY(1,1) NOT NULL,
	[IdListaMateriais] [int] NULL,
	[IdProduto] [int] NULL,
	[Descricao] [varchar](255) NULL,
	[IdConfiguracao] [int] NULL,
	[IdEstilo] [int] NULL,
	[IdCor] [int] NULL,
	[IdTamanho] [int] NULL,
	[IdArmazem] [int] NULL,
	[De] [datetime] NULL,
	[Ate] [datetime] NULL,
	[QuantidadeOrigem] [int] NULL,
	[IdUnidadeBom] [int] NULL,
	[Ativo] [bit] NULL,
	[AlocacaoCustoTotal] [bit] NULL,
	[Construcao] [bit] NULL,
	[DataFormula] [datetime] NULL,
	[MultiploFormula] [int] NULL,
	[Prioridade] [int] NULL,
	[QuantidadeProducao] [decimal](18, 4) NULL,
	[TamanhoFormula] [decimal](18, 4) NULL,
	[UsarParaCalculo] [bit] NULL,
	[VariacoesCoProdutos] [bit] NULL,
 CONSTRAINT [PK_ListadeMateriaisItem] PRIMARY KEY CLUSTERED 
(
	[IdListaMateriaisItem] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ListaMateriaisLinhas]    Script Date: 06/21/2015 23:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ListaMateriaisLinhas](
	[IdListaMateriaisLinhas] [int] IDENTITY(1,1) NOT NULL,
	[IdListaMateriaisItem] [int] NULL,
	[IdProduto] [int] NULL,
	[Descricao] [varchar](255) NULL,
	[IdConfiguracao] [int] NULL,
	[IdTamanho] [int] NULL,
	[IdCor] [int] NULL,
	[IdEstilo] [int] NULL,
	[IdLote] [int] NULL,
	[IdLocalizacao] [int] NULL,
	[Serie] [varchar](255) NULL,
	[IdArmazem] [int] NULL,
	[IdDeposito] [int] NULL,
	[IdUnidade] [int] NULL,
	[Quantidade] [decimal](18, 4) NULL,
	[Porserie] [int] NULL,
	[TipoItem] [int] NULL,
	[Formula] [int] NULL,
	[Consumo] [int] NULL,
	[PrincipioLiberacao] [int] NULL,
	[SucataConstante] [decimal](18, 4) NULL,
	[Altura] [decimal](18, 4) NULL,
	[Profundidade] [decimal](18, 4) NULL,
	[Densidade] [decimal](18, 4) NULL,
	[Largura] [decimal](18, 4) NULL,
	[TipoLinha] [int] NULL,
	[Calculo] [int] NULL,
	[IdFornecedor] [int] NULL,
	[DefinirSubProducaoComoConsumo] [bit] NULL,
	[SubBOM] [int] NULL,
	[SubRoteiro] [int] NULL,
	[Escalonavel] [bit] NULL,
	[De] [datetime] NULL,
	[Ate] [datetime] NULL,
	[NumeroOperacao] [int] NULL,
	[Fim] [bit] NULL,
	[Prioridade] [int] NULL,
	[HerdaLoteCoProduto] [bit] NULL,
	[HerdaLoteProdutoFinal] [bit] NULL,
	[HerdaValidadeCoproduto] [bit] NULL,
	[HerdaValidadeProdutoFinal] [bit] NULL,
	[Percentual] [decimal](18, 4) NULL,
	[PercentualCustos] [decimal](18, 4) NULL,
	[PorcentagemContraolada] [bit] NULL,
	[PorcentagemRecuperacao] [decimal](18, 4) NULL,
	[TipoIngrediente] [int] NULL,
	[TipoProducao] [int] NULL,
	[AlocacaoCusto] [bit] NULL,
	[ConsumoRecurso] [bit] NULL,
	[ValorCustoIndiretoSubProduto] [decimal](18, 4) NULL,
 CONSTRAINT [PK_ListadeMateriaisLinhas] PRIMARY KEY CLUSTERED 
(
	[IdListaMateriaisLinhas] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_CalendarioData_Calendario]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[CalendarioData]  WITH CHECK ADD  CONSTRAINT [FK_CalendarioData_Calendario] FOREIGN KEY([IdCalendario])
REFERENCES [dbo].[Calendario] ([IdCalendario])
GO
ALTER TABLE [dbo].[CalendarioData] CHECK CONSTRAINT [FK_CalendarioData_Calendario]
GO
/****** Object:  ForeignKey [FK_CalandarioDataLinhas_Calendario]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[CalendarioDataLinhas]  WITH CHECK ADD  CONSTRAINT [FK_CalandarioDataLinhas_Calendario] FOREIGN KEY([IdCalendario])
REFERENCES [dbo].[Calendario] ([IdCalendario])
GO
ALTER TABLE [dbo].[CalendarioDataLinhas] CHECK CONSTRAINT [FK_CalandarioDataLinhas_Calendario]
GO
/****** Object:  ForeignKey [FK_CalandarioDataLinhas_TempoTrabalho]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[CalendarioDataLinhas]  WITH CHECK ADD  CONSTRAINT [FK_CalandarioDataLinhas_TempoTrabalho] FOREIGN KEY([IdTempoTrabalho])
REFERENCES [dbo].[TempoTrabalho] ([IdTempoTrabalho])
GO
ALTER TABLE [dbo].[CalendarioDataLinhas] CHECK CONSTRAINT [FK_CalandarioDataLinhas_TempoTrabalho]
GO
/****** Object:  ForeignKey [FK_CapacidadeRecursosLinhas_CapacidadeRecursos]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[CapacidadeRecursosLinhas]  WITH CHECK ADD  CONSTRAINT [FK_CapacidadeRecursosLinhas_CapacidadeRecursos] FOREIGN KEY([IdCapacidadeRecursos])
REFERENCES [dbo].[CapacidadeRecursos] ([IdCapacidadeRecursos])
GO
ALTER TABLE [dbo].[CapacidadeRecursosLinhas] CHECK CONSTRAINT [FK_CapacidadeRecursosLinhas_CapacidadeRecursos]
GO
/****** Object:  ForeignKey [FK_GrupoRecursoLinha_Calendario]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[GrupoRecursoLinha]  WITH CHECK ADD  CONSTRAINT [FK_GrupoRecursoLinha_Calendario] FOREIGN KEY([IdCalendario])
REFERENCES [dbo].[Calendario] ([IdCalendario])
GO
ALTER TABLE [dbo].[GrupoRecursoLinha] CHECK CONSTRAINT [FK_GrupoRecursoLinha_Calendario]
GO
/****** Object:  ForeignKey [FK_GrupoRecursoLinha_Deposito]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[GrupoRecursoLinha]  WITH CHECK ADD  CONSTRAINT [FK_GrupoRecursoLinha_Deposito] FOREIGN KEY([IdDeposito])
REFERENCES [dbo].[Deposito] ([IdDeposito])
GO
ALTER TABLE [dbo].[GrupoRecursoLinha] CHECK CONSTRAINT [FK_GrupoRecursoLinha_Deposito]
GO
/****** Object:  ForeignKey [FK_GrupoRecursoLinha_Recursos]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[GrupoRecursoLinha]  WITH CHECK ADD  CONSTRAINT [FK_GrupoRecursoLinha_Recursos] FOREIGN KEY([IdRecurso])
REFERENCES [dbo].[Recursos] ([IdRecurso])
GO
ALTER TABLE [dbo].[GrupoRecursoLinha] CHECK CONSTRAINT [FK_GrupoRecursoLinha_Recursos]
GO
/****** Object:  ForeignKey [FK_GrupoRecursos_Armazem]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[GrupoRecursos]  WITH CHECK ADD  CONSTRAINT [FK_GrupoRecursos_Armazem] FOREIGN KEY([IdArmazem])
REFERENCES [dbo].[Armazem] ([IdArmazem])
GO
ALTER TABLE [dbo].[GrupoRecursos] CHECK CONSTRAINT [FK_GrupoRecursos_Armazem]
GO
/****** Object:  ForeignKey [FK_GrupoRoteiroLinha_GrupoRoteiro]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[GrupoRoteiroLinha]  WITH CHECK ADD  CONSTRAINT [FK_GrupoRoteiroLinha_GrupoRoteiro] FOREIGN KEY([IdGrupoRoteiro])
REFERENCES [dbo].[GrupoRoteiro] ([IdGrupoRoteiro])
GO
ALTER TABLE [dbo].[GrupoRoteiroLinha] CHECK CONSTRAINT [FK_GrupoRoteiroLinha_GrupoRoteiro]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisItem_Armazem]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisItem]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisItem_Armazem] FOREIGN KEY([IdArmazem])
REFERENCES [dbo].[Armazem] ([IdArmazem])
GO
ALTER TABLE [dbo].[ListaMateriaisItem] CHECK CONSTRAINT [FK_ListadeMateriaisItem_Armazem]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisItem_ListaMateriais]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisItem]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisItem_ListaMateriais] FOREIGN KEY([IdListaMateriais])
REFERENCES [dbo].[ListaMateriais] ([IdListaMateriais])
GO
ALTER TABLE [dbo].[ListaMateriaisItem] CHECK CONSTRAINT [FK_ListadeMateriaisItem_ListaMateriais]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisItem_Produto]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisItem]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisItem_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([IdProduto])
GO
ALTER TABLE [dbo].[ListaMateriaisItem] CHECK CONSTRAINT [FK_ListadeMateriaisItem_Produto]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisItem_Unidade]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisItem]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisItem_Unidade] FOREIGN KEY([IdUnidadeBom])
REFERENCES [dbo].[Unidade] ([IdUnidade])
GO
ALTER TABLE [dbo].[ListaMateriaisItem] CHECK CONSTRAINT [FK_ListadeMateriaisItem_Unidade]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisItem_VariantesConfig]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisItem]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisItem_VariantesConfig] FOREIGN KEY([IdConfiguracao])
REFERENCES [dbo].[VariantesConfig] ([IdVariantesConfig])
GO
ALTER TABLE [dbo].[ListaMateriaisItem] CHECK CONSTRAINT [FK_ListadeMateriaisItem_VariantesConfig]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisItem_VariantesCor]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisItem]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisItem_VariantesCor] FOREIGN KEY([IdCor])
REFERENCES [dbo].[VariantesCor] ([IdVariantesCor])
GO
ALTER TABLE [dbo].[ListaMateriaisItem] CHECK CONSTRAINT [FK_ListadeMateriaisItem_VariantesCor]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisItem_VariantesEstilo]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisItem]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisItem_VariantesEstilo] FOREIGN KEY([IdEstilo])
REFERENCES [dbo].[VariantesEstilo] ([IdVariantesEstilo])
GO
ALTER TABLE [dbo].[ListaMateriaisItem] CHECK CONSTRAINT [FK_ListadeMateriaisItem_VariantesEstilo]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisItem_VariantesTamanho]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisItem]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisItem_VariantesTamanho] FOREIGN KEY([IdTamanho])
REFERENCES [dbo].[VariantesTamanho] ([IdVariantesTamanho])
GO
ALTER TABLE [dbo].[ListaMateriaisItem] CHECK CONSTRAINT [FK_ListadeMateriaisItem_VariantesTamanho]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisLinhas_Armazem]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisLinhas]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisLinhas_Armazem] FOREIGN KEY([IdArmazem])
REFERENCES [dbo].[Armazem] ([IdArmazem])
GO
ALTER TABLE [dbo].[ListaMateriaisLinhas] CHECK CONSTRAINT [FK_ListadeMateriaisLinhas_Armazem]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisLinhas_Deposito]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisLinhas]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisLinhas_Deposito] FOREIGN KEY([IdDeposito])
REFERENCES [dbo].[Deposito] ([IdDeposito])
GO
ALTER TABLE [dbo].[ListaMateriaisLinhas] CHECK CONSTRAINT [FK_ListadeMateriaisLinhas_Deposito]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisLinhas_Fornecedor]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisLinhas]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisLinhas_Fornecedor] FOREIGN KEY([IdFornecedor])
REFERENCES [dbo].[Fornecedor] ([IdFornecedor])
GO
ALTER TABLE [dbo].[ListaMateriaisLinhas] CHECK CONSTRAINT [FK_ListadeMateriaisLinhas_Fornecedor]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisLinhas_Localizacao]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisLinhas]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisLinhas_Localizacao] FOREIGN KEY([IdLocalizacao])
REFERENCES [dbo].[Localizacao] ([IdLocalizacao])
GO
ALTER TABLE [dbo].[ListaMateriaisLinhas] CHECK CONSTRAINT [FK_ListadeMateriaisLinhas_Localizacao]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisLinhas_Lote]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisLinhas]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisLinhas_Lote] FOREIGN KEY([IdLote])
REFERENCES [dbo].[Lote] ([IdLote])
GO
ALTER TABLE [dbo].[ListaMateriaisLinhas] CHECK CONSTRAINT [FK_ListadeMateriaisLinhas_Lote]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisLinhas_Produto]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisLinhas]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisLinhas_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([IdProduto])
GO
ALTER TABLE [dbo].[ListaMateriaisLinhas] CHECK CONSTRAINT [FK_ListadeMateriaisLinhas_Produto]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisLinhas_Unidade]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisLinhas]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisLinhas_Unidade] FOREIGN KEY([IdUnidade])
REFERENCES [dbo].[Unidade] ([IdUnidade])
GO
ALTER TABLE [dbo].[ListaMateriaisLinhas] CHECK CONSTRAINT [FK_ListadeMateriaisLinhas_Unidade]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisLinhas_VariantesConfig]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisLinhas]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisLinhas_VariantesConfig] FOREIGN KEY([IdConfiguracao])
REFERENCES [dbo].[VariantesConfig] ([IdVariantesConfig])
GO
ALTER TABLE [dbo].[ListaMateriaisLinhas] CHECK CONSTRAINT [FK_ListadeMateriaisLinhas_VariantesConfig]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisLinhas_VariantesCor]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisLinhas]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisLinhas_VariantesCor] FOREIGN KEY([IdCor])
REFERENCES [dbo].[VariantesCor] ([IdVariantesCor])
GO
ALTER TABLE [dbo].[ListaMateriaisLinhas] CHECK CONSTRAINT [FK_ListadeMateriaisLinhas_VariantesCor]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisLinhas_VariantesEstilo]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisLinhas]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisLinhas_VariantesEstilo] FOREIGN KEY([IdEstilo])
REFERENCES [dbo].[VariantesEstilo] ([IdVariantesEstilo])
GO
ALTER TABLE [dbo].[ListaMateriaisLinhas] CHECK CONSTRAINT [FK_ListadeMateriaisLinhas_VariantesEstilo]
GO
/****** Object:  ForeignKey [FK_ListadeMateriaisLinhas_VariantesTamanho]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisLinhas]  WITH CHECK ADD  CONSTRAINT [FK_ListadeMateriaisLinhas_VariantesTamanho] FOREIGN KEY([IdTamanho])
REFERENCES [dbo].[VariantesTamanho] ([IdVariantesTamanho])
GO
ALTER TABLE [dbo].[ListaMateriaisLinhas] CHECK CONSTRAINT [FK_ListadeMateriaisLinhas_VariantesTamanho]
GO
/****** Object:  ForeignKey [FK_ListaMateriaisLinhas_ListaMateriaisItem]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[ListaMateriaisLinhas]  WITH CHECK ADD  CONSTRAINT [FK_ListaMateriaisLinhas_ListaMateriaisItem] FOREIGN KEY([IdListaMateriaisItem])
REFERENCES [dbo].[ListaMateriaisItem] ([IdListaMateriaisItem])
GO
ALTER TABLE [dbo].[ListaMateriaisLinhas] CHECK CONSTRAINT [FK_ListaMateriaisLinhas_ListaMateriaisItem]
GO
/****** Object:  ForeignKey [FK_UnidadeProducao_Armazem]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[LocalProducao]  WITH CHECK ADD  CONSTRAINT [FK_UnidadeProducao_Armazem] FOREIGN KEY([IdArmazem])
REFERENCES [dbo].[Armazem] ([IdArmazem])
GO
ALTER TABLE [dbo].[LocalProducao] CHECK CONSTRAINT [FK_UnidadeProducao_Armazem]
GO
/****** Object:  ForeignKey [FK_UnidadeProducao_Deposito]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[LocalProducao]  WITH CHECK ADD  CONSTRAINT [FK_UnidadeProducao_Deposito] FOREIGN KEY([IdDepositoEntrada])
REFERENCES [dbo].[Deposito] ([IdDeposito])
GO
ALTER TABLE [dbo].[LocalProducao] CHECK CONSTRAINT [FK_UnidadeProducao_Deposito]
GO
/****** Object:  ForeignKey [FK_UnidadeProducao_Deposito1]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[LocalProducao]  WITH CHECK ADD  CONSTRAINT [FK_UnidadeProducao_Deposito1] FOREIGN KEY([IdDepositoSaida])
REFERENCES [dbo].[Deposito] ([IdDeposito])
GO
ALTER TABLE [dbo].[LocalProducao] CHECK CONSTRAINT [FK_UnidadeProducao_Deposito1]
GO
/****** Object:  ForeignKey [FK_Recursos_ContaContabil]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[Recursos]  WITH CHECK ADD  CONSTRAINT [FK_Recursos_ContaContabil] FOREIGN KEY([IdContaContabilCusto])
REFERENCES [dbo].[ContaContabil] ([IdContaContabil])
GO
ALTER TABLE [dbo].[Recursos] CHECK CONSTRAINT [FK_Recursos_ContaContabil]
GO
/****** Object:  ForeignKey [FK_Recursos_ContaContabil1]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[Recursos]  WITH CHECK ADD  CONSTRAINT [FK_Recursos_ContaContabil1] FOREIGN KEY([IdContaContabilContraCusto])
REFERENCES [dbo].[ContaContabil] ([IdContaContabil])
GO
ALTER TABLE [dbo].[Recursos] CHECK CONSTRAINT [FK_Recursos_ContaContabil1]
GO
/****** Object:  ForeignKey [FK_Recursos_ContaContabil2]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[Recursos]  WITH CHECK ADD  CONSTRAINT [FK_Recursos_ContaContabil2] FOREIGN KEY([IdContaContabilWIP])
REFERENCES [dbo].[ContaContabil] ([IdContaContabil])
GO
ALTER TABLE [dbo].[Recursos] CHECK CONSTRAINT [FK_Recursos_ContaContabil2]
GO
/****** Object:  ForeignKey [FK_Recursos_ContaContabil3]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[Recursos]  WITH CHECK ADD  CONSTRAINT [FK_Recursos_ContaContabil3] FOREIGN KEY([IdContaContabilContaPartidaWIP])
REFERENCES [dbo].[ContaContabil] ([IdContaContabil])
GO
ALTER TABLE [dbo].[Recursos] CHECK CONSTRAINT [FK_Recursos_ContaContabil3]
GO
/****** Object:  ForeignKey [FK_Recursos_Funcionario]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[Recursos]  WITH CHECK ADD  CONSTRAINT [FK_Recursos_Funcionario] FOREIGN KEY([IdFuncionario])
REFERENCES [dbo].[Funcionario] ([IdFuncionario])
GO
ALTER TABLE [dbo].[Recursos] CHECK CONSTRAINT [FK_Recursos_Funcionario]
GO
/****** Object:  ForeignKey [FK_Recursos_GrupoRoteiro]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[Recursos]  WITH CHECK ADD  CONSTRAINT [FK_Recursos_GrupoRoteiro] FOREIGN KEY([IdGrupoRoteiro])
REFERENCES [dbo].[GrupoRoteiro] ([IdGrupoRoteiro])
GO
ALTER TABLE [dbo].[Recursos] CHECK CONSTRAINT [FK_Recursos_GrupoRoteiro]
GO
/****** Object:  ForeignKey [FK_Recursos_UnidadeProducao]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[Recursos]  WITH CHECK ADD  CONSTRAINT [FK_Recursos_UnidadeProducao] FOREIGN KEY([IdLocalProducao])
REFERENCES [dbo].[LocalProducao] ([IdLocalProducao])
GO
ALTER TABLE [dbo].[Recursos] CHECK CONSTRAINT [FK_Recursos_UnidadeProducao]
GO
/****** Object:  ForeignKey [FK_Roteiro_Funcionario]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[Roteiro]  WITH CHECK ADD  CONSTRAINT [FK_Roteiro_Funcionario] FOREIGN KEY([IdFuncionarioAprovador])
REFERENCES [dbo].[Funcionario] ([IdFuncionario])
GO
ALTER TABLE [dbo].[Roteiro] CHECK CONSTRAINT [FK_Roteiro_Funcionario]
GO
/****** Object:  ForeignKey [FK_Roteiro_GrupoLancamento]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[Roteiro]  WITH CHECK ADD  CONSTRAINT [FK_Roteiro_GrupoLancamento] FOREIGN KEY([IdGrupoLancamento])
REFERENCES [dbo].[GrupoLancamento] ([IdGrupoLancamento])
GO
ALTER TABLE [dbo].[Roteiro] CHECK CONSTRAINT [FK_Roteiro_GrupoLancamento]
GO
/****** Object:  ForeignKey [FK_RoteiroOperacao_Roteiro]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[RoteiroOperacao]  WITH CHECK ADD  CONSTRAINT [FK_RoteiroOperacao_Roteiro] FOREIGN KEY([IdRoteiro])
REFERENCES [dbo].[Roteiro] ([IdRoteiro])
GO
ALTER TABLE [dbo].[RoteiroOperacao] CHECK CONSTRAINT [FK_RoteiroOperacao_Roteiro]
GO
/****** Object:  ForeignKey [FK_RoteiroOperacaoLinhas_Armazem]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[RoteiroOperacaoLinhas]  WITH CHECK ADD  CONSTRAINT [FK_RoteiroOperacaoLinhas_Armazem] FOREIGN KEY([IdArmazem])
REFERENCES [dbo].[Armazem] ([IdArmazem])
GO
ALTER TABLE [dbo].[RoteiroOperacaoLinhas] CHECK CONSTRAINT [FK_RoteiroOperacaoLinhas_Armazem]
GO
/****** Object:  ForeignKey [FK_RoteiroOperacaoLinhas_GrupoLancamento]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[RoteiroOperacaoLinhas]  WITH CHECK ADD  CONSTRAINT [FK_RoteiroOperacaoLinhas_GrupoLancamento] FOREIGN KEY([IdGrupoLancamento])
REFERENCES [dbo].[GrupoLancamento] ([IdGrupoLancamento])
GO
ALTER TABLE [dbo].[RoteiroOperacaoLinhas] CHECK CONSTRAINT [FK_RoteiroOperacaoLinhas_GrupoLancamento]
GO
/****** Object:  ForeignKey [FK_RoteiroOperacaoLinhas_GrupoRoteiro]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[RoteiroOperacaoLinhas]  WITH CHECK ADD  CONSTRAINT [FK_RoteiroOperacaoLinhas_GrupoRoteiro] FOREIGN KEY([IdGrupoRoteiros])
REFERENCES [dbo].[GrupoRoteiro] ([IdGrupoRoteiro])
GO
ALTER TABLE [dbo].[RoteiroOperacaoLinhas] CHECK CONSTRAINT [FK_RoteiroOperacaoLinhas_GrupoRoteiro]
GO
/****** Object:  ForeignKey [FK_RoteiroOperacaoLinhas_Produto]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[RoteiroOperacaoLinhas]  WITH CHECK ADD  CONSTRAINT [FK_RoteiroOperacaoLinhas_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([IdProduto])
GO
ALTER TABLE [dbo].[RoteiroOperacaoLinhas] CHECK CONSTRAINT [FK_RoteiroOperacaoLinhas_Produto]
GO
/****** Object:  ForeignKey [FK_RoteiroOperacaoLinhas_RoteiroOperacao]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[RoteiroOperacaoLinhas]  WITH CHECK ADD  CONSTRAINT [FK_RoteiroOperacaoLinhas_RoteiroOperacao] FOREIGN KEY([IdRoteiroOperacao])
REFERENCES [dbo].[RoteiroOperacao] ([IdRoteiroOperacao])
GO
ALTER TABLE [dbo].[RoteiroOperacaoLinhas] CHECK CONSTRAINT [FK_RoteiroOperacaoLinhas_RoteiroOperacao]
GO
/****** Object:  ForeignKey [FK_TempoTrabalhoLinhas_TempoTrabalho]    Script Date: 06/21/2015 23:28:33 ******/
ALTER TABLE [dbo].[TempoTrabalhoLinhas]  WITH CHECK ADD  CONSTRAINT [FK_TempoTrabalhoLinhas_TempoTrabalho] FOREIGN KEY([IdTempoTrabalho])
REFERENCES [dbo].[TempoTrabalho] ([IdTempoTrabalho])
GO
ALTER TABLE [dbo].[TempoTrabalhoLinhas] CHECK CONSTRAINT [FK_TempoTrabalhoLinhas_TempoTrabalho]
GO
