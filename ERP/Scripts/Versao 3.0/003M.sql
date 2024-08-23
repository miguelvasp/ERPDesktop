/*
   segunda-feira, 5 de outubro de 201520:00:42
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
CREATE TABLE dbo.NotaFiscal
	(
	IdNotaFiscal int NOT NULL IDENTITY (1, 1),
	Numero varchar(255) NULL,
	IdDocumento int NULL,
	IdEmitente int NULL,
	ClienteFornecedor varchar(1) NULL,
	IdDestinatario int NULL,
	RazaoSocial varchar(255) NULL,
	NomeFantasia varchar(255) NULL,
	Endereco varchar(255) NULL,
	Complemento varchar(255) NULL,
	Bairro varchar(255) NULL,
	UF varchar(2) NULL,
	CEP varchar(255) NULL,
	IdTelefone int NULL,
	CNPJ varchar(255) NULL,
	IE varchar(255) NULL,
	DirecaoCFOP int NULL,
	FormaEmissao int NULL,
	TipoAtendimento int NULL,
	FinalidadeEmissao int NULL,
	NomeOperacao varchar(255) NULL,
	ValorDesconto decimal(18, 4) NULL,
	ValorFrete decimal(18, 4) NULL,
	ValorSeguro decimal(18, 4) NULL,
	BaseIPI decimal(18, 4) NULL,
	ValorIPI decimal(18, 4) NULL,
	BaseICMS decimal(18, 4) NULL,
	ValorICMS decimal(18, 4) NULL,
	BaseICMSSubs decimal(18, 4) NULL,
	ValorICMSSubs decimal(18, 4) NULL,
	ValorMercadoria decimal(18, 4) NULL,
	TotalNF decimal(18, 4) NULL,
	DataSaida datetime NULL,
	DataEntrada datetime NULL,
	IdTransportadora int NULL,
	TransPlaca varchar(255) NULL,
	TransUF varchar(2) NULL,
	Quantidade decimal(18, 4) NULL,
	Especie varchar(255) NULL,
	PesoLiquido decimal(18, 4) NULL,
	PesoBruto decimal(18, 4) NULL,
	Volumes decimal(18, 4) NULL,
	TipoFrete int NULL,
	DataEmissao datetime NULL,
	IdCFOP int NULL,
	IdCidade int NULL,
	DataEntrega int NULL,
	NotaStatus int NULL,
	Serie varchar(255) NULL,
	ChaveNFe varchar(255) NULL,
	IdPais int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.NotaFiscal ADD CONSTRAINT
	PK_NotaFiscal PRIMARY KEY CLUSTERED 
	(
	IdNotaFiscal
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.NotaFiscal SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.NotaFiscal', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.NotaFiscal', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.NotaFiscal', 'Object', 'CONTROL') as Contr_Per 