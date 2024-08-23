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
    [Table("PROGRAMA", Schema = "DBO")]
    public class Programa
    {
        [Key]
        [DisplayName("Id Programa")]
        [Column("IDPROGRAMA")]
        public int IdPrograma { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Formulário")]
        [Column("FORMULARIO")]
        public string Formulario { get; set; }

        [DisplayName("Manutenção")]
        [Column("MANUTENCAO")]
        public bool Manutencao { get; set; }

        [DisplayName("Tipo de Programa")]
        [Column("TIPOPROGRAMA")]
        public int? TipoPrograma { get; set; }
        
        public virtual ICollection<Permissao> Permissao { get; set; }
        public virtual ICollection<ModuloPrograma> ModuloPrograma { get; set; }
    }
}
