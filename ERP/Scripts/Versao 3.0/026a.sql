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
ALTER TABLE dbo.Recebimento
	DROP CONSTRAINT FK_Recebimento_Usuario
GO
ALTER TABLE dbo.Usuario SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Recebimento
	DROP CONSTRAINT FK_Recebimento_Empresa
GO
ALTER TABLE dbo.Empresa SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Recebimento
	(
	IdRecebimento int NOT NULL IDENTITY (1, 1),
	IdLoteRecebimento int NOT NULL,
	IdFornecedor int NULL,
	IdEmpresa int NULL,
	IdUsuario int NULL,
	DataFisica datetime NOT NULL,
	DataRecebimento datetime NULL,
	IdPedidoCompra int NULL,
	RecebimentoNumero int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Recebimento SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Recebimento ON
GO
IF EXISTS(SELECT * FROM dbo.Recebimento)
	 EXEC('INSERT INTO dbo.Tmp_Recebimento (IdRecebimento, IdLoteRecebimento, IdFornecedor, IdEmpresa, IdUsuario, DataFisica, IdPedidoCompra, RecebimentoNumero)
		SELECT IdRecebimento, IdLoteRecebimento, IdFornecedor, IdEmpresa, IdUsuario, CONVERT(datetime, DataFisica), IdPedidoCompra, RecebimentoNumero FROM dbo.Recebimento WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Recebimento OFF
GO
DROP TABLE dbo.Recebimento
GO
EXECUTE sp_rename N'dbo.Tmp_Recebimento', N'Recebimento', 'OBJECT' 
GO
ALTER TABLE dbo.Recebimento ADD CONSTRAINT
	PK_Recebimento PRIMARY KEY CLUSTERED 
	(
	IdRecebimento
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Recebimento ADD CONSTRAINT
	FK_Recebimento_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Recebimento ADD CONSTRAINT
	FK_Recebimento_Usuario FOREIGN KEY
	(
	IdUsuario
	) REFERENCES dbo.Usuario
	(
	IdUsuario
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
