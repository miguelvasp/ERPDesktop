
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CADASTRODIARIOPRODUCAO", Schema = "DBO")]
    public class CadastroDiarioProducao
    {
        [Key]
        [DisplayName("IdCadastroDiarioProducao")]
        [Column("IDCADASTRODIARIOPRODUCAO")]
        public int IdCadastroDiarioProducao { get; set; }
 
        [DisplayName("NomeDiario")]
        [Column("NOMEDIARIO")]
        public string NomeDiario { get; set; }
 
        [DisplayName("IdSequenciaDiario")]
        [Column("IDSEQUENCIADIARIO")]
        public int? IdSequenciaDiario { get; set; }
 
        [DisplayName("IdSequenciaComprovante")]
        [Column("IDSEQUENCIACOMPROVANTE")]
        public int? IdSequenciaComprovante { get; set; }
 
        [DisplayName("TipoDiario")]
        [Column("TIPODIARIO")]
        public int? TipoDiario { get; set; }
 
    }
}
