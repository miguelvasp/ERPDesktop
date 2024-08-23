using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("CONTAPLANOREFERENCIAL", Schema = "DBO")]
    public class ContaPlanoReferencial
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCONTAPLANOREFERENCIAL")]
        public int IdContaPlanoReferencial { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Data Inicial")]
        [Column("DATAINI")]
        public DateTime? DataIni { get; set; }

        [DisplayName("Data Fim")]
        [Column("DATAFIM")]
        public DateTime? DataFim { get; set; }

        [DisplayName("Ordem")]
        [Column("ORDEM")]
        public int? Ordem { get; set; }

        [DisplayName("Tipo")]
        [Column("TIPO")]
        public int? Tipo { get; set; }

        [DisplayName("Conta Pai")]
        [Column("IDCONTAPAI")]
        public int? IdContaPai { get; set; }

        [DisplayName("Nível")]
        [Column("NIVEL")]
        public int? Nivel { get; set; }

        [DisplayName("Natureza")]
        [Column("NATUREZA")]
        public int? Natureza { get; set; }
    }
}
