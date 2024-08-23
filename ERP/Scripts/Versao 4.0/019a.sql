USE [mgasoftware]
GO

/****** Object:  View [dbo].[vwPedidoComprasRel]    Script Date: 11/20/2015 12:42:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[vwPedidoComprasRel]
AS

SELECT DISTINCT
    ROW_NUMBER() OVER (ORDER BY pc.IdPedidoCompra) as LineId,
	PC.PedidoNumero as NumeroPedido,
    PC.IdPedidoCompra as Pedido,
    PC.Data as Data,
    M.Codigo as Moeda,
    CP.NOME AS CondicaoPgto,
    PC.DataEntrega,
    PC.PrazoEntrega,
    PC.Observacao,
    PC.Emissao,
    round(I.Quantidade, 2) Quantidade,
    round(I.Ipi, 2) Ipi,
    round(I.PrecoUnitario, 2) PrecoUnitario,
    round(I.Quantidade * I.PrecoUnitario, 2) AS TOTAL,
    E.RazaoSocial as EmpresaRazaoSocial,
    E.Endereco as EmpresaEndereco,
    E.Numero EmpresaNumero,
    E.CEP EmpresaCEP,
    'CNPJ ' + E.CNPJ EmpresaCNPJ,
    C.Nome as EmpresaCidade,
    EUF.UF as EmpresaUF,
    ISNULL(E.Email, '') as EmpresaEmail,
    E.Bairro as EmpresaBairro,
    E.Logo as EmpresaLogo,
    F.RazaoSocial as FornecedorRazaoSocial,
    ISNULL(ED.Logradouro, '-') as FornecedorEndereco,
    ISNULL(ED.Numero, '-') as FornecedorNumero,
    ISNULL(ED.CodigoPostal, '-') as FornecedorCEP,
    ISNULL(CD.Nome, '-') as FornecedorCidade,
    ISNULL(TL.DDD, '') + ' ' + ISNULL(TL.NumeroTelefone, '-') as FornecedorTelefone,
    ISNULL(UF.UF, '-') as FornecedorUF,
    P.CODIGO,
    P.NomeProduto,
    U.UnidadeMedida,
    US.NomeCompleto as Comprador,
    (
	   SELECT SUM(Quantidade * PrecoUnitario) FROM PedidoCompraItem pci where pci.IdPedidoCompra = PC.IdPedidoCompra 
    ) as totalPedido
FROM PedidoCompra PC 

LEFT OUTER JOIN PedidoCompraItem I ON PC.IdPedidoCompra = I.IdPedidoCompra

LEFT OUTER JOIN EMPRESA E ON PC.IdEmpresa = E.IdEmpresa

LEFT OUTER JOIN FORNECEDOR F ON PC.IdFornecedor = F.IdFornecedor

LEFT OUTER JOIN FORNECEDORENDERECO FE ON F.IdFornecedor = FE.IdFornecedor 

LEFT OUTER JOIN Endereco ED ON FE.IdEndereco = ED.IdEndereco AND ED.IdTipoEndereco = 1

LEFT OUTER JOIN Cidade CD ON ED.IdCidade = CD.IdCidade

LEFT OUTER JOIN UnidadeFederacao UF  ON ED.IdUF = UF.IdUF

LEFT OUTER JOIN FornecedorTelefone FT ON F.IdFornecedor = FT.IdFornecedor

LEFT OUTER JOIN Telefone TL ON FT.IdTelefone = TL.IdTelefone

LEFT OUTER JOIN Produto P ON I.IdProduto = P.IdProduto

LEFT OUTER JOIN Cidade C ON E.IdCidade = C.IdCidade

LEFT OUTER JOIN UNIDADEFEDERACAO EUF ON E.IdUF = EUF.IdUF

LEFT OUTER JOIN Unidade U ON P.ComprasIdUnidade = U.IdUnidade

LEFT OUTER JOIN Moeda M ON PC.IdMoeda = M.IdMoeda

LEFT OUTER JOIN CondicaoPagamento CP ON PC.IdCondicaoPagamento = CP.IdCondicaoPagamento

LEFT OUTER JOIN Usuario US ON PC.IdComprador = US.IdUsuario


GO

