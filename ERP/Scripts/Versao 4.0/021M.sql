

/****** Object:  View [dbo].[vwPedidoVendaSeparacao]    Script Date: 11/15/2015 14:40:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





ALTER VIEW [dbo].[vwPedidoVendaSeparacao]

AS

SELECT
    ROW_NUMBER() OVER (ORDER BY pv.IdPedidoVenda) as LineId,
    pv.IdPedidoVenda,
    pi.IdPedidoVendaItem,
	pv.PedidoNumero,
	pv.Data,
	pv.DataEntrega,
	cl.NomeFantasia,
	cl.RazaoSocial,
	e.Logradouro,
	e.Numero,
	e.Complemento,
	e.Bairro,
	e.CodigoPostal as CEP,
	ci.Nome as Cidade,
	u.UF,
	pr.Codigo,
	pr.NomeProduto,
	vf.Descricao as Config,
	vc.Descricao as Cor,
	ve.Descricao as Estilo,
	vt.Descricao as Tamanho,
	isnull(pi.Quantidade, 0.000) - ISNULL(pi.QuantidadeFaturada, 0.0000) as QuantidadeSeparacao,
	ISNULL(pi.QuantidadePorFaturar, 0.0000) as QuantidadePorFaturar
	
FROM PedidoVenda pv
inner join PedidoVendaItem pi
on pv.IdPedidoVenda = pi.IdPedidoVenda

inner join Produto pr
on pi.IdProduto = pr.IdProduto

inner join Cliente cl
on pv.IdCliente = cl.IdCliente

left outer join ClienteEndereco ce
on cl.IdCliente = ce.IdCliente

left outer join Endereco e
on ce.IdEndereco = e.IdEndereco and e.IdTipoEndereco = 2

left outer join TipoEndereco t 
on e.IdTipoEndereco = t.IdTipoEndereco

left outer join UnidadeFederacao u
on e.IdUF = u.IdUF

left outer join Cidade ci
on e.IdCidade = ci.IdCidade

left outer join VariantesConfig vf
on pi.IdVariantesConfig = vf.IdVariantesConfig

left outer join VariantesCor vc
on pi.IdVariantesCor = vc.IdVariantesCor

left outer join VariantesEstilo ve
on pi.IdVariantesEstilo = ve.IdVariantesEstilo

left outer join VariantesTamanho vt
on pi.IdVariantesTamanho = vt.IdVariantesTamanho

where isnull(pi.QuantidadeSeparacao, 0.000) > 0




GO


