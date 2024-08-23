CREATE VIEW vwPesquisaProduto
AS
SELECT 
	A.IdProduto,
	A.Codigo,
	A.Descricao,
	'' AS Grupo,
	A.IdVariantesCor,
	C.Descricao AS COR,
	A.IdVariantesEstilo,
	E.Descricao AS ESTILO,
	A.IdVariantesTamanho,
	T.Descricao AS TAMANHO,
	A.IdVariantesConfig,
	CF.Descricao AS CONFIG
FROM Produto A
LEFT JOIN VariantesCor C
ON A.IdVariantesCor = C.IdVariantesCor
LEFT JOIN VariantesEstilo E
ON A.IdVariantesEstilo = E.IdVariantesEstilo
LEFT JOIN VariantesTamanho T
ON A.IdVariantesTamanho = T.IdVariantesTamanho
LEFT JOIN VariantesConfig CF
ON A.IdVariantesConfig = CF.IdVariantesConfig
WHERE IdVariantesGrupo IS NULL

UNION 

SELECT
	P.IdProduto,
	P.Codigo,
	P.Descricao,
	G.Descricao,
	A.IdCor,
	C.Descricao AS COR,
	A.IdEstilo,
	E.Descricao AS ESTILO,
	A.IdTamanho,
	T.Descricao AS TAMANHO,
	A.IdConfiguracao,
	CF.Descricao AS CONFIG
FROM Produto P
LEFT JOIN VariantesGrupo G
ON P.IdVariantesGrupo = G.IdVariantesGrupo
LEFT JOIN VariantesGrupoItem A
ON G.IdVariantesGrupo = A.IdVariantesGrupo
LEFT JOIN VariantesCor C
ON A.IdCor = C.IdVariantesCor
LEFT JOIN VariantesEstilo E
ON A.IdEstilo = E.IdVariantesEstilo
LEFT JOIN VariantesTamanho T
ON A.IdTamanho = T.IdVariantesTamanho
LEFT JOIN VariantesConfig CF
ON A.IdConfiguracao = CF.IdVariantesConfig
WHERE P.IdVariantesGrupo IS NOT NULL


GO