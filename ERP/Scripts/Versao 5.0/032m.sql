create VIEW vwVencimentos
AS

select DISTINCT
    
	A.IdContasPagarAberto,
	P.IdContasPagar,
	F.RazaoSocial,
	A.Vencimento,
	A.ValorLiquido, 
	P.IdMetodoPagamento,
	P.Documento,
	P.IdFornecedor, 
	m.Nome,
	isnull(SUM(Valor), 0) Saldo
	
from ContasPagar P

inner join Fornecedor F
on P.IdFornecedor = F.IdFornecedor

inner join ContasPagarAberto A
ON P.IdContasPagar = A.IdContasPagar

left outer join ContasPagarBaixa b
on a.IdContasPagarAberto = b.IdContasPagarAberto

left outer join MetodoPagamento m
on p.IdMetodoPagamento = m.IdMetodoPagamento

group by 
    P.IdContasPagar,
    A.IdContasPagarAberto,
	F.RazaoSocial,
	A.Vencimento,
	A.ValorLiquido,
	m.Nome,
	P.IdMetodoPagamento,
	P.Documento ,
	P.IdFornecedor
having isnull(SUM(Valor), 0) < a.ValorLiquido