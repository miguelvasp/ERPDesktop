USE [mgasoftware]
GO

/****** Object:  View [dbo].[vwChequeTerceiros]    Script Date: 11/02/2015 03:28:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[vwChequeTerceiros]

AS

SELECT
    C.IdChequeTerceiro,
	'Pago a' as Origem,
	F.RazaoSocial,
	B.DataPagamento,
	C.Nome,
	BN.NomeBanco,
	C.Agencia,
	C.Conta,
	C.NumeroCheque,
	C.Valor,
	Case 
	When C.Status = 1 Then 'Em transito'
	When C.Status = 2 Then 'Custodia'
	When C.Status = 3 Then 'Depositado'
	When C.Status = 4 Then 'Devolvido Custodia'
	When C.Status = 5 Then 'Devolvido'
	When C.Status = 6 Then 'Reapresentado'
	When C.Status = 7 Then 'Protestado'
	When C.Status = 8 Then 'Baixado' End as Status,
	C.DataCompensacao
	
FROM ContasPagar A
INNER JOIN Fornecedor F ON A.IdFornecedor = F.IdFornecedor 
INNER JOIN ContasPagarChequeTerceiros CH ON A.IdContasPagar = CH.IdContasPagar
INNER JOIN ChequeTerceiros C ON CH.IdChequeTerceiro = c.IdChequeTerceiro
INNER JOIN ContasPagarBaixa B ON CH.IdContasPagarBaixa = B.IdContasPagarBaixa
INNER JOIN Banco BN ON C.IdBanco = BN.IdBanco




GO


