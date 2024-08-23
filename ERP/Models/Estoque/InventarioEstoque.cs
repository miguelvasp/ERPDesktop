
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("INVENTARIOESTOQUE", Schema = "DBO")]
    public class InventarioEstoque
    {
        [Key]
        [DisplayName("IdInventarioEstoque")]
        [Column("IDINVENTARIOESTOQUE")]
        public int? IdInventarioEstoque { get; set; }

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

        [DisplayName("IdCor")] 
        public int? IdVariantesCor { get; set; }

        [DisplayName("IdTamanho")] 
        public int? IdVariantesTamanho { get; set; }

        [DisplayName("IdEstilo")] 
        public int? IdVariantesEstilo { get; set; }

        [DisplayName("IdConfig")] 
        public int? IdVariantesConfig { get; set; }

        [DisplayName("IdUnidade")]
        [Column("IDUNIDADE")]
        public int? IdUnidade { get; set; }

        [DisplayName("QtdeEstoque")]
        [Column("QTDEESTOQUE")]
        public decimal? QtdeEstoque { get; set; }

        [DisplayName("QtdeInventario")]
        [Column("QTDEINVENTARIO")]
        public decimal? QtdeInventario { get; set; }

        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime? Data { get; set; }

        [DisplayName("Status")]
        [Column("STATUS")]
        public string Status { get; set; }

        public int? Numero { get; set; }

        public virtual VariantesConfig VariantesConfig { get; set; }
        public virtual VariantesTamanho VariantesTamanho { get; set; }
        public virtual VariantesEstilo VariantesEstilo { get; set; }
        public virtual VariantesCor VariantesCor { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Deposito Deposito { get; set; }
        public virtual Armazem Armazem { get; set; }
        public virtual Localizacao Localizacao { get; set; }
        public virtual Unidade Unidade { get; set; }

    }
}
