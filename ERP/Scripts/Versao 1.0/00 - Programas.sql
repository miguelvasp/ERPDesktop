USE [mgasoftware]
GO

INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'C�lculo Comiss�o', N'C�lculo Comiss�o', N'frmCalculoComissao', 0, 1)
GO
INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'C�lculo Comiss�o Cadastro', N'C�lculo Comiss�o Cadastro', N'frmCalculoComissaoCad', 1, 2)
GO


INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Departamento', N'Departamento', N'frmDepartamento', 1, 2)
GO


INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Localiza��o Ativo', N'Localiza��o Ativo', N'frmLocalizacaoAtivo', 0, 1)
GO
INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Localiza��o Ativo Cadastro', N'Localiza��o Ativo Cadastro', N'frmLocalizacaoAtivoCad', 1, 2)
GO


INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Lan�amento Ativo', N'Lan�amento Ativo', N'frmLancamentoAtivo', 0, 1)
GO
INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Lan�amento Ativo Cadastro', N'Lan�amento Ativo Cadastro', N'frmLancamentoAtivoCad', 1, 2)
GO

INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Tempo Deprecia��o', N'Tempo Deprecia��o', N'frmTempoDepreciacao', 0, 1)
GO
INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Tempo Deprecia��o Cadastro', N'Tempo Deprecia��o Cadastro', N'frmTempoDepreciacaoCad', 1, 2)
GO

INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Grupo Armazenamento', N'Grupo Armazenamento', N'frmGrupoArmazenamento', 0, 1)
GO
INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Grupo Armazenamento Cadastro', N'Grupo Armazenamento Cadastro', N'frmGrupoArmazenamentoCad', 1, 2)
GO

INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Grupo Rastreamento', N'Grupo Rastreamento', N'frmGrupoRastreamento', 0, 1)
GO
INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Grupo Rastreamento Cadastro', N'Grupo Rastreamento Cadastro', N'frmGrupoRastreamentoCad', 1, 2)
GO

INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Grupo Estoque', N'Grupo Estoque', N'frmGrupoEstoque', 0, 1)
GO
INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Grupo Estoque Cadastro', N'Grupo Estoque Cadastro', N'frmGrupoEstoqueCad', 1, 2)
GO

INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Tempo Trabalho', N'Tempo Trabalho', N'frmTempoTrabalho', 0, 1)
GO
INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Tempo Trabalho Cadastro', N'Tempo Trabalho Cadastro', N'frmTempoTrabalhoCad', 1, 2)
GO


Delete from ModuloPrograma
where IdPrograma in (select IdPrograma from Programa
where Nome like 'Grupo de Vendas')
GO

Delete from Permissao
where IdPrograma in (select IdPrograma from Programa
where Nome like 'Grupo de Vendas') 
GO

Delete from Programa
where Nome like 'Grupo de Vendas'
GO

Delete from ModuloPrograma
where IdPrograma in (select IdPrograma from Programa
where Nome like 'Grupo de Compras')
GO

Delete from Permissao
where IdPrograma in (select IdPrograma from Programa
where Nome like 'Grupo de Compras') 
GO

Delete from Programa
where Nome like 'Grupo de Compras'
GO


INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Recebimento Compra', N'Recebimento Compra', N'frmRecebimentoCompra', 0, 1)
GO
INSERT [dbo].[Programa] ([Nome], [Descricao], [Formulario], [Manutencao], [TipoPrograma]) VALUES (N'Recebimento Compra Cadastro', N'Recebimento Compra Cadastro', N'frmRecebimentoCompraCad', 1, 2)
GO