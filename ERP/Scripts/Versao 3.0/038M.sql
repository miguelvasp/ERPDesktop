CREATE VIEW vwAprovacaoDocumentos
as

select 
	PC.IdPedidoCompra AS Id,
	1 as TipoDocumento,
	'Pedido de Compras ' + CAST(PC.IdPedidoCompra as varchar) as Documento,
	PC.Data,
	F.NomeFantasia as Responsavel,
	b.Nome as Status,
	B.Sequencia,
	c.IdUsuario,
	CAST(SUM(I.PrecoUnitario * I.Quantidade) AS DECIMAL(18, 4)) AS Valor
from AprovacaoDocumento A

INNER JOIN AprovacaoNivel B
ON A.IdAprovacaoDocumento = B.IdAprovacaoDocumento

INNER JOIN AprovacaoUsuario C
ON B.IdAprovacaoNivel = C.IdAprovacaoNivel

INNER JOIN PedidoCompra PC
ON PC.StatusAprovacao = B.IdAprovacaoNivel

INNER JOIN PedidoCompraItem I
ON PC.IdPedidoCompra = I.IdPedidoCompra

INNER JOIN Fornecedor F
ON PC.IdFornecedor = F.IdFornecedor

where A.Sigla = 'PC'
AND B.Nome <> 'Liberado'

GROUP BY 
    PC.IdPedidoCompra,
	PC.Data,
	F.NomeFantasia,
	b.Nome,
	B.Sequencia,
	c.IdUsuario
	
GO