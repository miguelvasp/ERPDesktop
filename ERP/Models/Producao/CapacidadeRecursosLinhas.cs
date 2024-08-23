using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("CAPACIDADERECURSOSLINHAS", Schema = "DBO")]
    public class CapacidadeRecursosLinhas
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCAPACIDADERECURSOSLINHAS")]
        public int IdCapacidadeRecursosLinhas { get; set; }

        [DisplayName("IdCapacidadeRecursos")]
        [Column("IDCAPACIDADERECURSOS")]
        public int? IdCapacidadeRecursos { get; set; }

        [DisplayName("DataEfetivacao")]
        [Column("DATAEFETIVACAO")]
        public DateTime? DataEfetivacao { get; set; }

        [DisplayName("DataVencimento")]
        [Column("DATAVENCIMENTO")]
        public DateTime? DataVencimento { get; set; }

        [DisplayName("Recurso")]
        [Column("IDRECURSO")]
        public int? IdRecurso { get; set; }

        [DisplayName("Prioridade")]
        [Column("PRIORIDADE")]
        public int? Prioridade { get; set; }

        [DisplayName("Nivel")]
        [Column("NIVEL")]
        public int? Nivel { get; set; }

    }
}
