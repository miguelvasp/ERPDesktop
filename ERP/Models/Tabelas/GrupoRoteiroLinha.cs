
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("GRUPOROTEIROLINHA", Schema = "DBO")]
    public class GrupoRoteiroLinha
    {
        [Key]
        [DisplayName("IdGrupoRoteiroLinha")]
        [Column("IDGRUPOROTEIROLINHA")]
        public int IdGrupoRoteiroLinha { get; set; }
 
        [DisplayName("IdGrupoRoteiro")]
        [Column("IDGRUPOROTEIRO")]
        public int? IdGrupoRoteiro { get; set; }
 
        [DisplayName("TipoRoteiroTrabalho")]
        [Column("TIPOROTEIROTRABALHO")]
        public int? TipoRoteiroTrabalho { get; set; }
 
        [DisplayName("Ativacao")]
        [Column("ATIVACAO")]
        public bool Ativacao { get; set; }
 
        [DisplayName("Capacidade")]
        [Column("CAPACIDADE")]
        public bool Capacidade { get; set; }
 
        [DisplayName("GerenciamentoTrabalho")]
        [Column("GERENCIAMENTOTRABALHO")]
        public bool GerenciamentoTrabalho { get; set; }
 
        [DisplayName("HorarioTrabalho")]
        [Column("HORARIOTRABALHO")]
        public bool HorarioTrabalho { get; set; }
 
    }
}
