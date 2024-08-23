
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CONTRATOCOMERCIAL", Schema = "DBO")]
    public class ContratoComercial
    {
        [Key]
        [DisplayName("IdContratoComercial")]
        [Column("IDCONTRATOCOMERCIAL")]
        public int IdContratoComercial { get; set; }

        [DisplayName("IdCodigoContratoComercial")]
        [Column("IDCODIGOCONTRATOCOMERCIAL")]
        public int? IdCodigoContratoComercial { get; set; }

        [DisplayName("Ativo")]
        [Column("ATIVO")]
        public bool Ativo { get; set; }

        [DisplayName("Relacao")]
        [Column("RELACAO")]
        public int? Relacao { get; set; }

        [DisplayName("CodigoTipo")]
        [Column("CODIGOTIPO")]
        public int? CodigoTipo { get; set; }

        [DisplayName("IdCliente")]
        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }

        [DisplayName("IdGrupoDescontoVarejista")]
        [Column("IDGRUPODESCONTOVAREJISTA")]
        public int? IdGrupoDescontoVarejista { get; set; }

        [DisplayName("IdFornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }

        [DisplayName("IdGrupoPrecoDesconto")]
        [Column("IDGRUPOPRECODESCONTO")]
        public int? IdGrupoPrecoDesconto { get; set; }

        [DisplayName("RelacaoItem")]
        [Column("RELACAOITEM")]
        public int? RelacaoItem { get; set; }

        [DisplayName("IdProduto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }

        [DisplayName("IdGrupoProduto")]
        [Column("IDGRUPOPRODUTO")]
        public int? IdGrupoProduto { get; set; }

        [DisplayName("IdEstilo")]
        [Column("IDESTILO")]
        public int? IdEstilo { get; set; }

        [DisplayName("IdTamanho")]
        [Column("IDTAMANHO")]
        public int? IdTamanho { get; set; }

        [DisplayName("IdCor")]
        [Column("IDCOR")]
        public int? IdCor { get; set; }

        [DisplayName("De")]
        [Column("DE")]
        public int? De { get; set; }

        [DisplayName("Ate")]
        [Column("ATE")]
        public int? Ate { get; set; }

        [DisplayName("IdUnidade")]
        [Column("IDUNIDADE")]
        public int? IdUnidade { get; set; }

        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }

        [DisplayName("ValorPercentual")]
        [Column("VALORPERCENTUAL")]
        public decimal? ValorPercentual { get; set; }

        [DisplayName("IdUnidadePreco")]
        [Column("IDUNIDADEPRECO")]
        public int? IdUnidadePreco { get; set; }

        [DisplayName("DeData")]
        [Column("DEDATA")]
        public DateTime? DeData { get; set; }

        [DisplayName("AteData")]
        [Column("ATEDATA")]
        public DateTime? AteData { get; set; }

        [DisplayName("IdGrupoPrecoDescontoProduto")]
        [Column("IDGRUPOPRECODESCONTOPRODUTO")]
        public int? IdGrupoPrecoDescontoProduto { get; set; }

        [DisplayName("IdEmpresa")]
        [Column("IDEMPRESA")]
        public int? IdEmpresa { get; set; }

        [DisplayName("ContratoNumero")]
        [Column("CONTRATONUMERO")]
        public int? ContratoNumero { get; set; }

        [Column("IDCONFIG")]
        public int? IdConfig { get; set; }

    }
}
