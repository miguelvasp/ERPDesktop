CREATE VIEW vwEstoqueSintetico
as

SELECT A.IdEmpresa
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
      ,D.Nome AS Depósito
      ,AR.Nome AS Armazem
      ,l.Nome as Localizacao
      ,c.Descricao as Cor
      ,t.Descricao as Tamanho
      ,e.Descricao as Estilo
      ,cf.Descricao as Configuracao
      ,u.UnidadeMedida as Unidade
      ,Sum(A.Quantidade) as Quantidade
  FROM Inventario A
  LEFT OUTER JOIN Produto P ON A.IdProduto = P.IdProduto
  LEFT OUTER JOIN Deposito D ON A.IdDeposito = D.IdDeposito
  LEFT OUTER JOIN Armazem AR ON A.IdArmazem = AR.IdArmazem
  LEFT OUTER JOIN Localizacao L ON A.IdLocalizacao = L.IdLocalizacao
  LEFT OUTER JOIN VariantesCor C ON A.IdVariantesCor = C.IdVariantesCor
  LEFT OUTER JOIN VariantesTamanho T ON A.IdVariantesTamanho = T.IdVariantesTamanho
  LEFT OUTER JOIN VariantesEstilo E ON A.IdVariantesEstilo = E.IdVariantesEstilo
  LEFT OUTER JOIN VariantesConfig CF ON A.IdVariantesConfig = CF.IdVariantesConfig
  LEFT OUTER JOIN Unidade U ON A.IdUnidade = U.IdUnidade
  WHERE IdTipoDocumento = 3 -- nota fiscal de entrada
  AND (QuantidadeRetirada is null or QuantidadeRetirada = 0)
  group by 
       A.IdEmpresa
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
      ,D.Nome 
      ,AR.Nome 
      ,l.Nome 
      ,c.Descricao 
      ,t.Descricao 
      ,e.Descricao 
      ,cf.Descricao 
      ,u.UnidadeMedida 


