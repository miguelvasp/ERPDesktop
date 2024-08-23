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
    [Table("CHAVEREDUCAO", Schema = "DBO")]
    public class ChaveReducao
    {
        [Key]
        [DisplayName("Id Chave Redução")]
        [Column("IDCHAVEREDUCAO")]
        public int IdChaveReducao { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Fixo")]
        [Column("FIXO")]
        public bool Fixo { get; set; }

        [DisplayName("Data Inicial")]
        [Column("DATAINICIAL")]
        public DateTime DataInicial { get; set; }

        [DisplayName("Unidade")]
        [Column("UNIDADE")]
        public int? Unidade { get; set; }

        [DisplayName("Fator")]
        [Column("FATOR")]
        public decimal Fator { get; set; }

        [DisplayName("De")]
        [Column("DE")]
        public DateTime De { get; set; }

        [DisplayName("Até")]
        [Column("ATE")]
        public DateTime Ate { get; set; }

        [DisplayName("Mês")]
        [Column("MES")]
        public int Mes { get; set; }
    }
}