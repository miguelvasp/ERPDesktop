USE [ACRILPLUS]
GO

/****** Object:  View [dbo].[vwPedidoVendasRel]    Script Date: 06/27/2016 21:32:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[vwPedidoVendasRel]
AS

SELECT ROW_NUMBER() OVER (ORDER BY PV.PEDIDO) as LineId,
       PV.*
FROM ( 

SELECT distinct
    
	PV.PedidoNumero as PedidoNumero,
    PV.IdPedidoVenda as Pedido,
    PV.Data as Data,
    M.Codigo as Moeda,
    CP.NOME AS CondicaoPgto,
    PV.DataEntrega,
    PV.PrazoEntrega,
    PV.Observacao,
    PV.Emissao,
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
    E.Email as EmpresaEmail,
    E.Bairro AS EmpresaBairro,
    NULL as EmpresaLogo,
    CL.RazaoSocial as ClienteRazaoSocial,
    ISNULL(ED.Logradouro, '-') as ClienteEndereco,
    ISNULL(ED.Numero, '-') as ClienteNumero,
    ISNULL(ED.CodigoPostal, '-') as ClienteCEP,
    ISNULL(CD.Nome, '-') as ClienteCidade,
    '' as ClienteTelefone,
    ISNULL(UF.UF, '-') as ClienteUF,
    P.CODIGO,
    P.NomeProduto,
    U.UnidadeMedida,    
    (
	   SELECT ROUND(SUM(Quantidade * PrecoUnitario), 2) FROM PedidoVendaItem pvi where pvi.IdPedidoVenda = PV.IdPedidoVenda 
    ) as totalPedido,
	(I.PesoUnitario * I.Quantidade) as PesoUnitario,
	VC.Descricao as Cor,
	I.DescontoVarejista,
	(select Nome from Vendedor where IdVendedor = PV.IdVendedor) AS Vendedor,
	(select Nome from Funcionario where Televendas = 1 and IdFuncionario = PV.IdTeleVendas) as TeleVendas

FROM PedidoVenda PV 
LEFT OUTER JOIN PedidoVendaItem I ON PV.IdPedidoVenda = I.IdPedidoVenda

LEFT OUTER JOIN EMPRESA E ON PV.IdEmpresa = E.IdEmpresa

LEFT OUTER JOIN UNIDADEFEDERACAO EUF ON E.IdUF = EUF.IdUF

LEFT OUTER JOIN CLIENTE CL ON PV.IdCliente = CL.IdCliente

LEFT OUTER JOIN CLIENTEENDERECO CE ON CL.IdCliente = CE.IdCliente 

LEFT OUTER JOIN Endereco ED ON CE.IdEndereco = ED.IdEndereco AND ED.IdTipoEndereco = 1

LEFT OUTER JOIN Cidade CD ON ED.IdCidade = CD.IdCidade

LEFT OUTER JOIN UnidadeFederacao UF  ON ED.IdUF = UF.IdUF

--LEFT OUTER JOIN ClienteTelefone CT ON CL.IdCliente = CT.IdCliente

--LEFT OUTER JOIN Telefone TL ON CT.IdTelefone = TL.IdTelefone

LEFT OUTER JOIN Produto P ON I.IdProduto = P.IdProduto

LEFT OUTER JOIN Cidade C ON E.IdCidade = C.IdCidade

LEFT OUTER JOIN Unidade U ON P.VendaIdUnidade = U.IdUnidade

LEFT OUTER JOIN Moeda M ON PV.IdMoeda = M.IdMoeda

LEFT OUTER JOIN CondicaoPagamento CP ON PV.IdCondicaoPagamento = CP.IdCondicaoPagamento

LEFT OUTER JOIN Usuario US ON PV.IdVendedor = US.IdUsuario

LEFT OUTER JOIN VariantesCor VC on VC.IdVariantesCor = I.IdVariantesCor
) AS PV




GO


