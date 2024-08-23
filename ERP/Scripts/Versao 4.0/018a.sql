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
ALTER TABLE dbo.Empresa
	DROP CONSTRAINT FK_Empresa_Contador
GO
ALTER TABLE dbo.Contador SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Empresa
	(
	IdEmpresa int NOT NULL IDENTITY (1, 1),
	RazaoSocial varchar(150) NULL,
	Fantasia varchar(150) NULL,
	CNPJ varchar(15) NULL,
	IE varchar(15) NULL,
	Endereco varchar(255) NULL,
	Numero varchar(100) NULL,
	Complemento varchar(100) NULL,
	Bairro varchar(255) NULL,
	IdCidade int NULL,
	IdUF int NULL,
	CEP varchar(9) NULL,
	Telefone varchar(14) NULL,
	Telefone2 varchar(14) NULL,
	Fax varchar(14) NULL,
	Email varchar(150) NULL,
	UltimaFatura int NULL,
	UltimaNotaFiscal int NULL,
	UltimoConhecimento int NULL,
	Logo varbinary(MAX) NULL,
	UltimaNotaServico int NULL,
	IdContador int NULL,
	UltimoPedidoCompras int NULL,
	UltimaNotaFiscalProvisoria int NULL,
	UltimoPedidoVendas int NULL,
	UltimoRecebimento int NULL,
	UltimoContratoComercial int NULL,
	UltimaOrdemProducao int NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Empresa SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Empresa ON
GO
IF EXISTS(SELECT * FROM dbo.Empresa)
	 EXEC('INSERT INTO dbo.Tmp_Empresa (IdEmpresa, RazaoSocial, Fantasia, CNPJ, IE, Endereco, Numero, Complemento, Bairro, IdCidade, IdUF, CEP, Telefone, Telefone2, Fax, Email, UltimaFatura, UltimaNotaFiscal, UltimoConhecimento, Logo, UltimaNotaServico, IdContador, UltimoPedidoCompras, UltimaNotaFiscalProvisoria, UltimoPedidoVendas, UltimoRecebimento, UltimoContratoComercial, UltimaOrdemProducao)
		SELECT IdEmpresa, RazaoSocial, Fantasia, CNPJ, IE, Endereco, Numero, Complemento, Bairro, IdCidade, IdUF, CEP, Telefone, Telefone2, Fax, Email, UltimaFatura, UltimaNotaFiscal, UltimoConhecimento, CONVERT(varbinary(MAX), Logo), UltimaNotaServico, IdContador, UltimoPedidoCompras, UltimaNotaFiscalProvisoria, UltimoPedidoVendas, UltimoRecebimento, UltimoContratoComercial, UltimaOrdemProducao FROM dbo.Empresa WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Empresa OFF
GO
ALTER TABLE dbo.PedidoCompra
	DROP CONSTRAINT FK_PedidoCompra_Empresa
GO
ALTER TABLE dbo.MatrizImpostos
	DROP CONSTRAINT FK_MatrizImpostos_Empresa
GO
ALTER TABLE dbo.PedidoVenda
	DROP CONSTRAINT FK_PedidoVenda_Empresa
GO
ALTER TABLE dbo.Fornecedor
	DROP CONSTRAINT FK_Fornecedor_Empresa
GO
ALTER TABLE dbo.Cliente
	DROP CONSTRAINT FK_Cliente_Empresa
GO
ALTER TABLE dbo.OrdemProducao
	DROP CONSTRAINT FK_OrdemProducao_Empresa
GO
ALTER TABLE dbo.Inventario
	DROP CONSTRAINT FK_Inventario_Empresa
GO
ALTER TABLE dbo.ContaBancaria
	DROP CONSTRAINT FK_ContaBancaria_Empresa
GO
ALTER TABLE dbo.Recebimento
	DROP CONSTRAINT FK_Recebimento_Empresa
GO
ALTER TABLE dbo.Produto
	DROP CONSTRAINT FK_Produto_Empresa
GO
ALTER TABLE dbo.ContratoComercial
	DROP CONSTRAINT FK_ContratoComercial_Empresa
GO
DROP TABLE dbo.Empresa
GO
EXECUTE sp_rename N'dbo.Tmp_Empresa', N'Empresa', 'OBJECT' 
GO
ALTER TABLE dbo.Empresa ADD CONSTRAINT
	PK_Empresa2 PRIMARY KEY CLUSTERED 
	(
	IdEmpresa
	) WITH( PAD_INDEX = OFF, FILLFACTOR = 90, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Empresa ADD CONSTRAINT
	FK_Empresa_Contador FOREIGN KEY
	(
	IdContador
	) REFERENCES dbo.Contador
	(
	IdContador
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContratoComercial ADD CONSTRAINT
	FK_ContratoComercial_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContratoComercial SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produto ADD CONSTRAINT
	FK_Produto_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
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
ALTER TABLE dbo.Recebimento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContaBancaria ADD CONSTRAINT
	FK_ContaBancaria_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContaBancaria SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Inventario ADD CONSTRAINT
	FK_Inventario_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Inventario SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.OrdemProducao ADD CONSTRAINT
	FK_OrdemProducao_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OrdemProducao SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cliente ADD CONSTRAINT
	FK_Cliente_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Cliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Fornecedor ADD CONSTRAINT
	FK_Fornecedor_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Fornecedor SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoVenda ADD CONSTRAINT
	FK_PedidoVenda_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoVenda SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MatrizImpostos ADD CONSTRAINT
	FK_MatrizImpostos_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MatrizImpostos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidoCompra ADD CONSTRAINT
	FK_PedidoCompra_Empresa FOREIGN KEY
	(
	IdEmpresa
	) REFERENCES dbo.Empresa
	(
	IdEmpresa
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidoCompra SET (LOCK_ESCALATION = TABLE)
GO
COMMIT