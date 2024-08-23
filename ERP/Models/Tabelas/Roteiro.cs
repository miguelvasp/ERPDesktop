using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("ROTEIRO", Schema = "DBO")]
    public class Roteiro
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDROTEIRO")]
        public int IdRoteiro { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Aprovado")]
        [Column("APROVADO")]
        public bool Aprovado { get; set; }
 
        [DisplayName("Id Funcionário Aprovador")]
        [Column("IDFUNCIONARIOAPROVADOR")]
        public int? IdFuncionarioAprovador { get; set; }
 
        [DisplayName("Aprovar Roteiro")]
        [Column("APROVARROTEIRO")]
        public int? AprovarRoteiro { get; set; }
 
        [DisplayName("Id Grupo Lançamento")]
        [Column("IDGRUPOLANCAMENTO")]
        public int? IdGrupoLancamento { get; set; }
 
        [DisplayName("Verificar Roteiro")]
        [Column("VERIFICARROTEIRO")]
        public bool VerificarRoteiro { get; set; } 
    }
}
