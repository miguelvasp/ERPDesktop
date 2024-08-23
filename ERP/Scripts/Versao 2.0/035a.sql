CREATE VIEW vwPedidoVendasRel
AS

SELECT DISTINCT
    ROW_NUMBER() OVER (ORDER BY PV.IdPedidoVenda) as LineId,
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
    CL.RazaoSocial as ClienteRazaoSocial,
    'Endereço' as ClienteEndereco,
    '1111' as ClienteNumero,
    '18016516' as ClienteCEP,
    '119843475551' as ClienteTelefone,
    'Sorocaba' as ClienteCidade,
    'SP' as ClienteUF,
    P.CODIGO,
    P.NomeProduto,
    U.UnidadeMedida,
    US.NomeCompleto as Vendedor,
    (
	   SELECT SUM(Quantidade * PrecoUnitario) FROM PedidoVendaItem pvi where pvi.IdPedidoVenda = PV.IdPedidoVenda 
    ) as totalPedido
FROM PedidoVenda PV 
LEFT OUTER JOIN PedidoVendaItem I
ON PV.IdPedidoVenda = I.IdPedidoVenda

LEFT OUTER JOIN EMPRESA E
ON PV.IdEmpresa = E.IdEmpresa

LEFT OUTER JOIN UNIDADEFEDERACAO EUF
on E.IdUF = EUF.IdUF

LEFT OUTER JOIN CLIENTE CL
ON PV.IdCliente = CL.IdCliente

LEFT OUTER JOIN Produto P
ON I.IdProduto = P.IdProduto

LEFT OUTER JOIN Cidade C
on E.IdCidade = C.IdCidade

LEFT OUTER JOIN Unidade U
on P.VendaIdUnidade = U.IdUnidade

LEFT OUTER JOIN Moeda M
ON PV.IdMoeda = M.IdMoeda

LEFT OUTER JOIN CondicaoPagamento CP
ON PV.IdCondicaoPagamento = CP.IdCondicaoPagamento

LEFT OUTER JOIN Usuario US
ON PV.IdVendedor = US.IdUsuario
GO

ALTER VIEW vwPedidoComprasRel
AS

SELECT DISTINCT
    ROW_NUMBER() OVER (ORDER BY pc.IdPedidoCompra) as LineId,
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
    E.Email as EmpresaEmail,
    E.Bairro AS EmpresaBairro,
    F.RazaoSocial as FornecedorRazaoSocial,
    'Endereço' as FornecedorEndereco,
    '1111' as FornecedorNumero,
    '18016516' as FornecedorCEP,
    '119843475551' as FornecedorTelefone,
    'Sorocaba' as FornecedorCidade,
    'SP' as FornecedorUF,
    P.CODIGO,
    P.NomeProduto,
    U.UnidadeMedida,
    US.NomeCompleto as Comprador,
    (
	   SELECT SUM(Quantidade * PrecoUnitario) FROM PedidoCompraItem pci where pci.IdPedidoCompra = PC.IdPedidoCompra 
    ) as totalPedido
FROM PedidoCompra PC 
LEFT OUTER JOIN PedidoCompraItem I
ON PC.IdPedidoCompra = I.IdPedidoCompra

LEFT OUTER JOIN EMPRESA E
ON PC.IdEmpresa = E.IdEmpresa

LEFT OUTER JOIN FORNECEDOR F
ON PC.IdFornecedor = F.IdFornecedor

LEFT OUTER JOIN Produto P
ON I.IdProduto = P.IdProduto

LEFT OUTER JOIN Cidade C
on E.IdCidade = C.IdCidade

LEFT OUTER JOIN UNIDADEFEDERACAO EUF
on E.IdUF = EUF.IdUF

LEFT OUTER JOIN Unidade U
on P.ComprasIdUnidade = U.IdUnidade

LEFT OUTER JOIN Moeda M
ON PC.IdMoeda = M.IdMoeda

LEFT OUTER JOIN CondicaoPagamento CP
ON PC.IdCondicaoPagamento = CP.IdCondicaoPagamento

LEFT OUTER JOIN Usuario US
ON PC.IdComprador = US.IdUsuario
GO

