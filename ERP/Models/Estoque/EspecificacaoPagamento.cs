using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("ESPECIFICACAOPAGAMENTO", Schema = "DBO")]
    public class EspecificacaoPagamento
    {
        [Key]
        [DisplayName("Id Especificação Pagamento")]
        [Column("IDESPECIFICACAOPAGAMENTO")]
        public int IdEspecificacaoPagamento { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Id Método Pagamento")]
        [Column("IDMETODOPAGAMENTO")]
        public int? IdMetodoPagamento { get; set; }
        public virtual MetodoPagamento MetodoPagamento { get; set; }

        [DisplayName("Controle de Exportação")]
        [Column("CONTROLEEXPORTACAO")]
        public int ControleExportacao { get; set; }

        [DisplayName("Id Tipo de Pagamento")]
        [Column("IDTIPOPAGAMENTO")]
        public int? IdTipoPagamento { get; set; }
        public virtual TipoPagamento TipoPagamento { get; set; }

        [DisplayName("Id Forma de Pagamento")]
        [Column("IDFORMAPAGAMENTO")]
        public int? IdFormaPagamento { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }

        [DisplayName("Id Segmento")]
        [Column("IDSEGMENTOBANCARIO")]
        public int? IdSegmentoBancario { get; set; } 
    }
}
