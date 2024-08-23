
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("INVENTARIO", Schema = "DBO")]
    public class Inventario
    {
        [Key]
        [DisplayName("IdInventario")]
        [Column("IDINVENTARIO")]
        public int? IdInventario { get; set; }

        [DisplayName("IdEmpresa")]
        [Column("IDEMPRESA")]
        public int? IdEmpresa { get; set; }

        [DisplayName("IdProduto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }

        [DisplayName("IdDeposito")]
        [Column("IDDEPOSITO")]
        public int? IdDeposito { get; set; }

        [DisplayName("IdArmazem")]
        [Column("IDARMAZEM")]
        public int? IdArmazem { get; set; }

        [DisplayName("IdLocalizacao")]
        [Column("IDLOCALIZACAO")]
        public int? IdLocalizacao { get; set; }

        [DisplayName("IdVariantesCor")]
        [Column("IDVARIANTESCOR")]
        public int? IdVariantesCor { get; set; }

        [DisplayName("IdVariantesTamanho")]
        [Column("IDVARIANTESTAMANHO")]
        public int? IdVariantesTamanho { get; set; }

        [DisplayName("IdVariantesEstilo")]
        [Column("IDVARIANTESESTILO")]
        public int? IdVariantesEstilo { get; set; }

        [DisplayName("IdVariantesConfig")]
        [Column("IDVARIANTESCONFIG")]
        public int? IdVariantesConfig { get; set; }

        [DisplayName("IdUnidade")]
        [Column("IDUNIDADE")]
        public int? IdUnidade { get; set; }

        [DisplayName("IdDocumento")]
        [Column("IDDOCUMENTO")]
        public int? IdDocumento { get; set; }

        [DisplayName("IdTipoDocumento")]
        [Column("IDTIPODOCUMENTO")]
        public int? IdTipoDocumento { get; set; }

        [DisplayName("IdNCM")]
        [Column("IDNCM")]
        public int? IdNCM { get; set; }

        [DisplayName("TipoMovimentoFinanceiro")]
        [Column("TIPOMOVIMENTOFINANCEIRO")]
        public string TipoMovimentoFinanceiro { get; set; }

        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal? Quantidade { get; set; }

        [DisplayName("DataFisica")]
        [Column("DATAFISICA")]
        public DateTime? DataFisica { get; set; }

        [DisplayName("DataSaida")]
        [Column("DATASAIDA")]
        public DateTime? DataSaida { get; set; }

        [DisplayName("DataFinanceira")]
        [Column("DATAFINANCEIRA")]
        public DateTime? DataFinanceira { get; set; }

        [DisplayName("QuantidadeRetirada")]
        [Column("QUANTIDADERETIRADA")]
        public decimal? QuantidadeRetirada { get; set; }

        [DisplayName("CustoReposicao")]
        [Column("CUSTOREPOSICAO")]
        public decimal? CustoReposicao { get; set; }

        [DisplayName("Saldo")]
        [Column("SALDO")]
        public decimal? Saldo { get; set; }

        [DisplayName("EstoqueAnterior")]
        [Column("ESTOQUEANTERIOR")]
        public decimal? EstoqueAnterior { get; set; }

        [DisplayName("DataEmissaoNF")]
        [Column("DATAEMISSAONF")]
        public DateTime? DataEmissaoNF { get; set; }

        [DisplayName("NumeroDocumentoNF")]
        [Column("NUMERODOCUMENTONF")]
        public string NumeroDocumentoNF { get; set; }

        [DisplayName("Serie")]
        [Column("SERIE")]
        public string Serie { get; set; }

        [Column("IDLOTE")]
        public int? IdLote { get; set; }

        [Column("IDNOTASAIDA")]
        public int? IdNotaSaida { get; set; }

        [DisplayName("DataVencimento")]
        [Column("DATAVENCIMENTO")]
        public DateTime? DataVencimento { get; set; }

        [DisplayName("DataFabricacao")]
        [Column("DATAFABRICACAO")]
        public DateTime? DataFabricacao { get; set; }

        [DisplayName("DataAvisoPrateleira")]
        [Column("DATAAVISOPRATELEIRA")]
        public DateTime? DataAvisoPrateleira { get; set; }

        [DisplayName("DataValidade")]
        [Column("DATAVALIDADE")]
        public DateTime? DataValidade { get; set; }

        [DisplayName("LoteFornecedor")]
        [Column("LOTEFORNECEDOR")]
        public string LoteFornecedor { get; set; }

        [DisplayName("LoteInterno")]
        [Column("LOTEINTERNO")]
        public string LoteInterno { get; set; }
    }
}
