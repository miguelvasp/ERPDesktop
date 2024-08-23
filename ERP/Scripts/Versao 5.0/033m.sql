USE [mgasoftware]
GO

/****** Object:  View [dbo].[vwVencimentos]    Script Date: 04/21/2016 22:59:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[vwVencimentos]
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
	A.ValorLiquido - isnull(SUM(Valor), 0) Saldo
	
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

GO


