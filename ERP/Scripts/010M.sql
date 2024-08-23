CREATE VIEW vwChequeTerceiros

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
	C.Status
FROM ContasPagar A
INNER JOIN Fornecedor F ON A.IdFornecedor = F.IdFornecedor 
INNER JOIN ContasPagarChequeTerceiros CH ON A.IdContasPagar = CH.IdContasPagar
INNER JOIN ChequeTerceiros C ON CH.IdChequeTerceiro = c.IdChequeTerceiro
INNER JOIN ContasPagarBaixa B ON CH.IdContasPagarBaixa = B.IdContasPagarBaixa
INNER JOIN Banco BN ON C.IdBanco = BN.IdBanco


GO