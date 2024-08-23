/*
   terça-feira, 12 de julho de 201622:23:16
   User: mgasoftware
   Server: mssql.mgasolucoes.com.br
   Database: mgasoftware
   Application: 
*/

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
ALTER TABLE dbo.ContaBancaria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ContaBancaria', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ContaBancaria', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ContaBancaria', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Fornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Fornecedor', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_TransacaoBancaria
	(
	IdTransacaoBanco int NOT NULL IDENTITY (1, 1),
	IdContaBancaria int NULL,
	Data datetime NULL,
	DataTransacao datetime NULL,
	IDComprovante int NULL,
	DataReconciliacao datetime NULL,
	Moeda varchar(255) NULL,
	ContaContabil varchar(255) NULL,
	Cancelado int NULL,
	Conciliado int NULL,
	CodigoFinalidadeBancoCentral varchar(255) NULL,
	ExtratoBancario varchar(255) NULL,
	DataExtratoBancario datetime NULL,
	MetodoPagamento varchar(255) NULL,
	NumeroCheque varchar(255) NULL,
	TipoTransacaoOrigem int NULL,
	TextoTransacao int NULL,
	TipoPagamento int NULL,
	Valor decimal(18, 4) NULL,
	ValorMoedaTransacao decimal(18, 4) NULL,
	CodigoSWIFT varchar(255) NULL,
	IBAN varchar(255) NULL,
	IdFornecedor int NULL,
	IdCliente int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_TransacaoBancaria SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_TransacaoBancaria ON
GO
IF EXISTS(SELECT * FROM dbo.TransacaoBancaria)
	 EXEC('INSERT INTO dbo.Tmp_TransacaoBancaria (IdTransacaoBanco, IdContaBancaria, Data, DataTransacao, IDComprovante, DataReconciliacao, Moeda, ContaContabil, Cancelado, Conciliado, CodigoFinalidadeBancoCentral, ExtratoBancario, DataExtratoBancario, MetodoPagamento, NumeroCheque, TipoTransacaoOrigem, TextoTransacao, TipoPagamento, Valor, ValorMoedaTransacao, CodigoSWIFT, IBAN, IdFornecedor, IdCliente)
		SELECT IdTransacaoBanco, IdContaBancaria, Data, DataTransacao, IDComprovante, DataReconciliacao, Moeda, ContaContabil, Cancelado, Conciliado, CodigoFinalidadeBancoCentral, ExtratoBancario, DataExtratoBancario, MetodoPagamento, NumeroCheque, TipoTransacaoOrigem, TextoTransacao, TipoPagamento, Valor, ValorMoedaTransacao, CodigoSWIFT, IBAN, IdFornecedor, IdCliente FROM dbo.TransacaoBancaria WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_TransacaoBancaria OFF
GO
DROP TABLE dbo.TransacaoBancaria
GO
EXECUTE sp_rename N'dbo.Tmp_TransacaoBancaria', N'TransacaoBancaria', 'OBJECT' 
GO
ALTER TABLE dbo.TransacaoBancaria ADD CONSTRAINT
	PK_TransacaoBancaria PRIMARY KEY CLUSTERED 
	(
	IdTransacaoBanco
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.TransacaoBancaria ADD CONSTRAINT
	FK_TransacaoBancaria_Cliente FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Cliente
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TransacaoBancaria ADD CONSTRAINT
	FK_TransacaoBancaria_Fornecedor FOREIGN KEY
	(
	IdFornecedor
	) REFERENCES dbo.Fornecedor
	(
	IdFornecedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TransacaoBancaria ADD CONSTRAINT
	FK_TransacaoBancaria_ContaBancaria FOREIGN KEY
	(
	IdContaBancaria
	) REFERENCES dbo.ContaBancaria
	(
	IdContaBancaria
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.TransacaoBancaria', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.TransacaoBancaria', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.TransacaoBancaria', 'Object', 'CONTROL') as Contr_Per 