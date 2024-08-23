 
/****** Object:  Table [dbo].[PedidoVendaItem]    Script Date: 08/22/2015 18:27:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PedidoVendaItem](
	[IdPedidoVendaItem] [int] IDENTITY(1,1) NOT NULL,
	[IdPedidoVenda] [int] NOT NULL,
	[IdProduto] [int] NOT NULL,
	[Quantidade] [decimal](18, 4) NOT NULL,
	[QuantidadeEntregue] [decimal](18, 4) NULL,
	[IdUnidade] [int] NOT NULL,
	[Ipi] [decimal](18, 4) NOT NULL,
	[PrecoTabela] [decimal](18, 4) NOT NULL,
	[PrecoUnitario] [decimal](18, 4) NOT NULL,
	[DescontoVarejista] [decimal](18, 4) NOT NULL,
	[DescontoPercentual] [decimal](18, 4) NULL,
	[DescontoValor] [decimal](18, 4) NULL,
	[DescontoSuframa] [decimal](18, 4) NULL,
	[ValorLiquido] [decimal](18, 4) NULL,
	[ValorEncargos] [decimal](18, 4) NULL,
	[TipoOrdem] [int] NULL,
	[IdCFOP] [int] NULL,
	[IdCodigoServico] [int] NULL,
	[IdTipoDocumentoFiscal] [int] NULL,
	[IdVariantesEstilo] [int] NULL,
	[IdVariantesCor] [int] NULL,
	[IdVariantesTamanho] [int] NULL,
	[IdGrupoLotes] [int] NULL,
	[IdGrupoSeries] [int] NULL,
	[IdArmazem] [int] NULL,
	[IdDeposito] [int] NULL,
	[IdLocalizacao] [int] NULL,
	[IdCodigoExternoFornecedor] [int] NULL,
	[IdOrdemDevolvida] [int] NULL,
	[StatusLinha] [int] NULL,
	[OrigemTributacao] [varchar](1) NULL,
	[AtivoFixo] [bit] NULL,
	[IdGrupodeAtivo] [int] NULL,
	[IdAtivoFixo] [int] NULL,
	[IdGrupoImposto] [int] NULL,
	[IdMetodoPreciacao] [int] NULL,
	[TipoTransacaoAtivo] [int] NULL,
	[IdGrupoImpostosItem] [int] NULL,
	[IdGrupoImpostoRetido] [int] NULL,
	[IdGrupoImpostoItemRetido] [int] NULL,
	[IdNCM] [int] NULL,
	[IdGrupoEncargos] [int] NULL,
	[IdGrupoDescontos] [int] NULL,
	[PesoUnitario] [decimal](18, 4) NULL,
	[IdCentroCusto1] [int] NULL,
	[IdCentroCusto2] [int] NULL,
	[IdCentroCusto3] [int] NULL,
	[IdCentroCusto4] [int] NULL,
	[IdCentroCusto5] [int] NULL,
 CONSTRAINT [PK_PedidoVendaItem] PRIMARY KEY CLUSTERED 
(
	[IdPedidoVendaItem] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PedidoVendaItem]  WITH CHECK ADD  CONSTRAINT [FK_PedidoVendaItem_CFOP] FOREIGN KEY([IdCFOP])
REFERENCES [dbo].[CFOP] ([IdCFOP])
GO

ALTER TABLE [dbo].[PedidoVendaItem] CHECK CONSTRAINT [FK_PedidoVendaItem_CFOP]
GO

ALTER TABLE [dbo].[PedidoVendaItem]  WITH CHECK ADD  CONSTRAINT [FK_PedidoVendaItem_VariantesCor] FOREIGN KEY([IdVariantesCor])
REFERENCES [dbo].[VariantesCor] ([IdVariantesCor])
GO

ALTER TABLE [dbo].[PedidoVendaItem] CHECK CONSTRAINT [FK_PedidoVendaItem_VariantesCor]
GO

ALTER TABLE [dbo].[PedidoVendaItem]  WITH CHECK ADD  CONSTRAINT [FK_PedidoVendaItem_VariantesEstilo] FOREIGN KEY([IdVariantesEstilo])
REFERENCES [dbo].[VariantesEstilo] ([IdVariantesEstilo])
GO

ALTER TABLE [dbo].[PedidoVendaItem] CHECK CONSTRAINT [FK_PedidoVendaItem_VariantesEstilo]
GO

ALTER TABLE [dbo].[PedidoVendaItem]  WITH CHECK ADD  CONSTRAINT [FK_PedidoVendaItem_VariantesTamanho] FOREIGN KEY([IdVariantesTamanho])
REFERENCES [dbo].[VariantesTamanho] ([IdVariantesTamanho])
GO

ALTER TABLE [dbo].[PedidoVendaItem] CHECK CONSTRAINT [FK_PedidoVendaItem_VariantesTamanho]
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
ALTER TABLE dbo.GrupoDescontos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoEncargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoAtivo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Armazem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Deposito SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoSeries SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoLotes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoImpostoRetido SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.GrupoImposto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CodigoServico SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MetodoDepreciacao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Localizacao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Unidade SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
EXECUTE sp_rename N'dbo.PedidoVendaItem.IdGrupodeAtivo', N'Tmp_IdGrupoAtivo_2', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.PedidoVendaItem.IdMetodoPreciacao', N'Tmp_IdMetodoDepreciacao_3', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.PedidoVendaItem.Tmp_IdGrupoAtivo_2', N'IdGrupoAtivo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.PedidoVendaItem.Tmp_IdMetodoDepreciacao_3', N'IdMetodoDepreciacao', 'COLUMN' 
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_Unidade FOREIGN KEY
	(
	IdUnidade
	) REFERENCES dbo.Unidade
	(
	IdUnidade
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_Produto FOREIGN KEY
	(
	IdProduto
	) REFERENCES dbo.Produto
	(
	IdProduto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_Localizacao FOREIGN KEY
	(
	IdLocalizacao
	) REFERENCES dbo.Localizacao
	(
	IdLocalizacao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_MetodoDepreciacao FOREIGN KEY
	(
	IdMetodoDepreciacao
	) REFERENCES dbo.MetodoDepreciacao
	(
	IdMetodoDepreciacao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_CodigoServico FOREIGN KEY
	(
	IdCodigoServico
	) REFERENCES dbo.CodigoServico
	(
	IdCodigoServico
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_GrupoImposto FOREIGN KEY
	(
	IdGrupoImposto
	) REFERENCES dbo.GrupoImposto
	(
	IdGrupoImposto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_GrupoImpostoRetido FOREIGN KEY
	(
	IdGrupoImpostoRetido
	) REFERENCES dbo.GrupoImpostoRetido
	(
	IdGrupoImpostoRetido
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_GrupoLotes FOREIGN KEY
	(
	IdGrupoLotes
	) REFERENCES dbo.GrupoLotes
	(
	IdGrupoLotes
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_GrupoSeries FOREIGN KEY
	(
	IdGrupoSeries
	) REFERENCES dbo.GrupoSeries
	(
	IdGrupoSeries
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_Deposito FOREIGN KEY
	(
	IdDeposito
	) REFERENCES dbo.Deposito
	(
	IdDeposito
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_Armazem FOREIGN KEY
	(
	IdArmazem
	) REFERENCES dbo.Armazem
	(
	IdArmazem
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_GrupoAtivo FOREIGN KEY
	(
	IdGrupoAtivo
	) REFERENCES dbo.GrupoAtivo
	(
	IdGrupoAtivo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_GrupoEncargos FOREIGN KEY
	(
	IdGrupoEncargos
	) REFERENCES dbo.GrupoEncargos
	(
	IdGrupoEncargos
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_GrupoDescontos FOREIGN KEY
	(
	IdGrupoDescontos
	) REFERENCES dbo.GrupoDescontos
	(
	IdGrupoDescontos
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

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
ALTER TABLE dbo.PedidoVenda SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVendaItem ADD CONSTRAINT
	FK_PedidoVendaItem_PedidoVenda FOREIGN KEY
	(
	IdPedidoVenda
	) REFERENCES dbo.PedidoVenda
	(
	IdPedidoVenda
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVendaItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

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
EXECUTE sp_rename N'dbo.PedidoVendaItem.IdCodigoExternoFornecedor', N'Tmp_IdCodigoExternoCliente_6', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.PedidoVendaItem.Tmp_IdCodigoExternoCliente_6', N'IdCodigoExternoCliente', 'COLUMN' 
GO
ALTER TABLE dbo.PedidoVendaItem SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
