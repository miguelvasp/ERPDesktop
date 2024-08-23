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
    [Table("MODOENTREGA", Schema = "DBO")]
    public class ModoEntrega
    {
        [Key]
        [DisplayName("Id Modo Entrega")]
        [Column("IDMODOENTREGA")]
        public int IdModoEntrega { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Id Grupo Encargos")]
        [Column("IDGRUPOENCARGOS")]
        public int? IdGrupoEncargos { get; set; }
        public virtual GrupoEncargos GrupoEncargos { get; set; }

        [DisplayName("Serviços")]
        [Column("SERVICOS")]
        public int? Servicos { get; set; }

        [DisplayName("Id Transportadora")]
        [Column("IDTRANSPORTADORA")]
        public int? IdTransportadora { get; set; }
        public virtual Transportadora Transportadora { get; set; }
    }
}
