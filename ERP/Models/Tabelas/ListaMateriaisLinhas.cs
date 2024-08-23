using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("LISTAMATERIAISLINHAS", Schema = "DBO")]
    public class ListaMateriaisLinhas
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDLISTAMATERIAISLINHAS")]
        public int IdListaMateriaisLinhas { get; set; }
 
        [DisplayName("IdListaMateriaisItem")]
        [Column("IDLISTAMATERIAISITEM")]
        public int? IdListaMateriaisItem { get; set; }
 
        [DisplayName("Id Produto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }
 
        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("IdConfiguracao")]
        [Column("IDCONFIGURACAO")]
        public int? IdConfiguracao { get; set; }
 
        [DisplayName("IdTamanho")]
        [Column("IDTAMANHO")]
        public int? IdTamanho { get; set; }
 
        [DisplayName("IdCor")]
        [Column("IDCOR")]
        public int? IdCor { get; set; }
 
        [DisplayName("IdEstilo")]
        [Column("IDESTILO")]
        public int? IdEstilo { get; set; }
 
        [DisplayName("IdLote")]
        [Column("IDLOTE")]
        public int? IdLote { get; set; }
 
        [DisplayName("Id Localização")]
        [Column("IDLOCALIZACAO")]
        public int? IdLocalizacao { get; set; }
 
        [DisplayName("Série")]
        [Column("SERIE")]
        public string Serie { get; set; }
 
        [DisplayName("Id Armazém")]
        [Column("IDARMAZEM")]
        public int? IdArmazem { get; set; }
 
        [DisplayName("Id Depósito")]
        [Column("IDDEPOSITO")]
        public int? IdDeposito { get; set; }
 
        [DisplayName("IdUnidade")]
        [Column("IDUNIDADE")]
        public int? IdUnidade { get; set; }
 
        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal? Quantidade { get; set; }
 
        [DisplayName("Porserie")]
        [Column("PORSERIE")]
        public int? Porserie { get; set; }
 
        [DisplayName("TipoItem")]
        [Column("TIPOITEM")]
        public int? TipoItem { get; set; }
 
        [DisplayName("Fórmula")]
        [Column("FORMULA")]
        public int? Formula { get; set; }
 
        [DisplayName("Consumo")]
        [Column("CONSUMO")]
        public int? Consumo { get; set; }
 
        [DisplayName("PrincipioLiberacao")]
        [Column("PRINCIPIOLIBERACAO")]
        public int? PrincipioLiberacao { get; set; }
 
        [DisplayName("SucataConstante")]
        [Column("SUCATACONSTANTE")]
        public decimal? SucataConstante { get; set; }
 
        [DisplayName("Altura")]
        [Column("ALTURA")]
        public decimal? Altura { get; set; }
 
        [DisplayName("Profundidade")]
        [Column("PROFUNDIDADE")]
        public decimal? Profundidade { get; set; }
 
        [DisplayName("Densidade")]
        [Column("DENSIDADE")]
        public decimal? Densidade { get; set; }
 
        [DisplayName("Largura")]
        [Column("LARGURA")]
        public decimal? Largura { get; set; }
 
        [DisplayName("TipoLinha")]
        [Column("TIPOLINHA")]
        public int? TipoLinha { get; set; }
 
        [DisplayName("Calculo")]
        [Column("CALCULO")]
        public bool Calculo { get; set; }
 
        [DisplayName("IdFornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }
 
        [DisplayName("DefinirSubProducaoComoConsumo")]
        [Column("DEFINIRSUBPRODUCAOCOMOCONSUMO")]
        public bool DefinirSubProducaoComoConsumo { get; set; }
 
        [DisplayName("SubBOM")]
        [Column("SUBBOM")]
        public int? SubBOM { get; set; }
 
        [DisplayName("SubRoteiro")]
        [Column("SUBROTEIRO")]
        public int? SubRoteiro { get; set; }
 
        [DisplayName("Escalonável")]
        [Column("ESCALONAVEL")]
        public bool Escalonavel { get; set; }
 
        [DisplayName("De")]
        [Column("DE")]
        public DateTime? De { get; set; }
 
        [DisplayName("Até")]
        [Column("ATE")]
        public DateTime? Ate { get; set; }
 
        [DisplayName("Número Operação")]
        [Column("NUMEROOPERACAO")]
        public int? NumeroOperacao { get; set; }
 
        [DisplayName("Fim")]
        [Column("FIM")]
        public bool Fim { get; set; }
 
        [DisplayName("Prioridade")]
        [Column("PRIORIDADE")]
        public int? Prioridade { get; set; }
 
        [DisplayName("HerdaLoteCoProduto")]
        [Column("HERDALOTECOPRODUTO")]
        public bool HerdaLoteCoProduto { get; set; }
 
        [DisplayName("HerdaLoteProdutoFinal")]
        [Column("HERDALOTEPRODUTOFINAL")]
        public bool HerdaLoteProdutoFinal { get; set; }
 
        [DisplayName("HerdaValidadeCoproduto")]
        [Column("HERDAVALIDADECOPRODUTO")]
        public bool HerdaValidadeCoproduto { get; set; }
 
        [DisplayName("HerdaValidadeProdutoFinal")]
        [Column("HERDAVALIDADEPRODUTOFINAL")]
        public bool HerdaValidadeProdutoFinal { get; set; }
 
        [DisplayName("Percentual")]
        [Column("PERCENTUAL")]
        public decimal? Percentual { get; set; }
 
        [DisplayName("PercentualCustos")]
        [Column("PERCENTUALCUSTOS")]
        public decimal? PercentualCustos { get; set; }
 
        [DisplayName("PorcentagemContraolada")]
        [Column("PORCENTAGEMCONTRAOLADA")]
        public bool PorcentagemContraolada { get; set; }
 
        [DisplayName("PorcentagemRecuperacao")]
        [Column("PORCENTAGEMRECUPERACAO")]
        public decimal? PorcentagemRecuperacao { get; set; }
 
        [DisplayName("TipoIngrediente")]
        [Column("TIPOINGREDIENTE")]
        public int? TipoIngrediente { get; set; }
 
        [DisplayName("TipoProducao")]
        [Column("TIPOPRODUCAO")]
        public int? TipoProducao { get; set; }
 
        [DisplayName("AlocacaoCusto")]
        [Column("ALOCACAOCUSTO")]
        public bool AlocacaoCusto { get; set; }
 
        [DisplayName("ConsumoRecurso")]
        [Column("CONSUMORECURSO")]
        public bool ConsumoRecurso { get; set; }
 
        [DisplayName("ValorCustoIndiretoSubProduto")]
        [Column("VALORCUSTOINDIRETOSUBPRODUTO")]
        public decimal? ValorCustoIndiretoSubProduto { get; set; }
 
    }
}
