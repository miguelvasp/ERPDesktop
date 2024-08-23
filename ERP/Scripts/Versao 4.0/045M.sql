USE [mgasoftware]
GO

/****** Object:  View [dbo].[vwAprovacaoDocumentos]    Script Date: 12/26/2015 22:21:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[vwAprovacaoDocumentos]
as

select 
	PC.IdPedidoCompra AS Id,
	1 as TipoDocumento,
	'Pedido de Compras ' + CAST(PC.PedidoNumero as varchar) as Documento,
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
    PC.PedidoNumero,
	PC.Data,
	F.NomeFantasia,
	b.Nome,
	B.Sequencia,
	c.IdUsuario
	
	
union

select 
	PV.IdPedidoVenda AS Id,
	2 as TipoDocumento,
	'Pedido de Vendas ' + CAST(PV.PedidoNumero as varchar) as Documento,
	PV.DATA,
	CL.NomeFantasia as Responsavel,
	b.Nome as Status,
	B.Sequencia,
	c.IdUsuario,
	CAST(SUM(I.PrecoUnitario * I.Quantidade) AS DECIMAL(18, 4)) AS Valor
from AprovacaoDocumento A

INNER JOIN AprovacaoNivel B
ON A.IdAprovacaoDocumento = B.IdAprovacaoDocumento

INNER JOIN AprovacaoUsuario C
ON B.IdAprovacaoNivel = C.IdAprovacaoNivel

INNER JOIN PedidoVenda PV
ON PV.StatusAprovacao = B.IdAprovacaoNivel

INNER JOIN PedidoVendaItem I
ON PV.IdPedidoVenda = I.IdPedidoVenda

INNER JOIN Cliente CL
ON PV.IdCliente = CL.IdCliente

where A.Sigla = 'PV'
AND B.Nome <> 'Liberado'

GROUP BY 
    pv.IdPedidoVenda,
    PV.PedidoNumero,
	PV.Data,
	CL.NomeFantasia,
	b.Nome,
	B.Sequencia,
	c.IdUsuario


GO


