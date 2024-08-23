
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("VWPESQUISAPRODUTO", Schema = "DBO")]
    public class vwPesquisaProduto
    {
        [Key]
        [DisplayName("ID")]
        [Column("ID")]
        public long ID { get; set; }

        [DisplayName("IdEmpresa")]
        [Column("IDEMPRESA")]
        public int? IdEmpresa { get; set; }

        [DisplayName("IdProduto")]
        [Column("IDPRODUTO")]
        public int IdProduto { get; set; }

        [DisplayName("Codigo")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descricao")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        public string NomeProduto { get; set; }

        [DisplayName("IdVariantesGrupo")]
        [Column("IDVARIANTESGRUPO")]
        public int? IdVariantesGrupo { get; set; }

        [DisplayName("Grupo")]
        [Column("GRUPO")]
        public string Grupo { get; set; }

        [DisplayName("IdVariantesCor")]
        [Column("IDVARIANTESCOR")]
        public int? IdVariantesCor { get; set; }

        [DisplayName("COR")]
        [Column("COR")]
        public string COR { get; set; }

        [DisplayName("IdVariantesEstilo")]
        [Column("IDVARIANTESESTILO")]
        public int? IdVariantesEstilo { get; set; }

        [DisplayName("ESTILO")]
        [Column("ESTILO")]
        public string ESTILO { get; set; }

        [DisplayName("IdVariantesTamanho")]
        [Column("IDVARIANTESTAMANHO")]
        public int? IdVariantesTamanho { get; set; }

        [DisplayName("TAMANHO")]
        [Column("TAMANHO")]
        public string TAMANHO { get; set; }

        [DisplayName("IdVariantesConfig")]
        [Column("IDVARIANTESCONFIG")]
        public int? IdVariantesConfig { get; set; }

        [DisplayName("CONFIG")]
        [Column("CONFIG")]
        public string CONFIG { get; set; }

        public int? ProdutoAcabadoMateriaPrima { get; set; }

        public int? IdUnidade { get; set; }

    }
}
