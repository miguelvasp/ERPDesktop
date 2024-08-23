CREATE VIEW vwAjusteEstoque

AS

SELECT  
       A.IdAjusteEstoque
      ,A.Data
      ,A.IdInventario 
      ,A.IdEmpresa
      ,A.IdProduto
      ,A.IdDeposito
      ,A.IdArmazem
      ,A.IdLocalizacao
      ,A.IdVariantesCor
      ,A.IdVariantesTamanho
      ,A.IdVariantesEstilo
      ,A.IdVariantesConfig
      ,A.IdUnidade 
      ,P.Codigo 
      ,P.NomeProduto
      ,P.Descricao
      ,D.Nome AS Deposito
      ,AR.Nome AS Armazem
      ,l.Nome as Localizacao
      ,c.Descricao as Cor
      ,t.Descricao as Tamanho
      ,e.Descricao as Estilo
      ,cf.Descricao as Configuracao
      ,u.UnidadeMedida as Unidade 
      ,Quantidade
      ,DataAvisoPrateleira
      ,DataFabricacao
      ,DataValidade
      ,DataVencimento
      ,LoteFornecedor
      ,LoteInterno
  FROM AjusteEstoque A
  LEFT OUTER JOIN Produto P ON A.IdProduto = P.IdProduto
  LEFT OUTER JOIN Deposito D ON A.IdDeposito = D.IdDeposito
  LEFT OUTER JOIN Armazem AR ON A.IdArmazem = AR.IdArmazem
  LEFT OUTER JOIN Localizacao L ON A.IdLocalizacao = L.IdLocalizacao
  LEFT OUTER JOIN VariantesCor C ON A.IdVariantesCor = C.IdVariantesCor
  LEFT OUTER JOIN VariantesTamanho T ON A.IdVariantesTamanho = T.IdVariantesTamanho
  LEFT OUTER JOIN VariantesEstilo E ON A.IdVariantesEstilo = E.IdVariantesEstilo
  LEFT OUTER JOIN VariantesConfig CF ON A.IdVariantesConfig = CF.IdVariantesConfig
  LEFT OUTER JOIN Unidade U ON A.IdUnidade = U.IdUnidade 


GO

