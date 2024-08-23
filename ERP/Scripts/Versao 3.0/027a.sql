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
CREATE TABLE dbo.Tmp_RecebimentoItemLote
	(
	IdLote int NOT NULL IDENTITY (1, 1),
	IdRecebimentoItem int NOT NULL,
	Quantidade decimal(18, 4) NOT NULL,
	Numero int NOT NULL,
	DataVencimento datetime NOT NULL,
	DataFabricacao datetime NOT NULL,
	DataAvisoPrateleira datetime NOT NULL,
	DataValidade datetime NOT NULL,
	DataUltimoTeste datetime NOT NULL,
	LoteFornecedor bit NOT NULL,
	NumeroFornecedor int NOT NULL,
	DataVencimentoFornecedor datetime NOT NULL,
	DataFabricacaoFornecedor datetime NOT NULL,
	DataAvisoPrateleiraFornecedor datetime NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_RecebimentoItemLote SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_RecebimentoItemLote ON
GO
IF EXISTS(SELECT * FROM dbo.RecebimentoItemLote)
	 EXEC('INSERT INTO dbo.Tmp_RecebimentoItemLote (IdLote, IdRecebimentoItem, Numero, DataVencimento, DataFabricacao, DataAvisoPrateleira, DataValidade, DataUltimoTeste, LoteFornecedor, NumeroFornecedor, DataVencimentoFornecedor, DataFabricacaoFornecedor, DataAvisoPrateleiraFornecedor)
		SELECT IdLote, IdRecebimentoItem, Numero, DataVencimento, DataFabricacao, DataAvisoPrateleira, DataValidade, DataUltimoTeste, LoteFornecedor, NumeroFornecedor, DataVencimentoFornecedor, DataFabricacaoFornecedor, DataAvisoPrateleiraFornecedor FROM dbo.RecebimentoItemLote WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_RecebimentoItemLote OFF
GO
DROP TABLE dbo.RecebimentoItemLote
GO
EXECUTE sp_rename N'dbo.Tmp_RecebimentoItemLote', N'RecebimentoItemLote', 'OBJECT' 
GO
ALTER TABLE dbo.RecebimentoItemLote ADD CONSTRAINT
	PK_Lote PRIMARY KEY CLUSTERED 
	(
	IdLote
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
