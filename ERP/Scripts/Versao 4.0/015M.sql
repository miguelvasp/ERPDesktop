 

/****** Object:  View [dbo].[vwPedidoVendaSeparacao]    Script Date: 11/14/2015 18:58:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[vwPedidoVendaSeparacao]

AS

SELECT
    ROW_NUMBER() OVER (ORDER BY pv.IdPedidoVenda) as LineId,
    pv.IdPedidoVenda,
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
	ci.Nome,
	u.UF,
	pr.Codigo,
	pr.NomeProduto,
	vf.Descricao as Config,
	vc.Descricao as Cor,
	ve.Descricao as Estilo,
	vt.Descricao as Tamanho,
	pi.QuantidadeSeparacao
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

 

GO


