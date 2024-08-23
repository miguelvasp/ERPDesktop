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
    [Table("TRANSPORTADORA", Schema = "DBO")]
    public class Transportadora
    {
        [Key]
        [DisplayName("Id Transportadora")]
        [Column("IDTRANSPORTADORA")]
        public int IdTransportadora { get; set; }

        [DisplayName("Razão Social")]
        [Column("RAZAOSOCIAL")]
        public string RazaoSocial { get; set; }

        [DisplayName("Nome Fantasia")]
        [Column("NOMEFANTASIA")]
        public string NomeFantasia { get; set; }

        [DisplayName("CNPJ")]
        [Column("CNPJ")]
        public string CNPJ { get; set; }

        [DisplayName("Inscrição Estadual")]
        [Column("INSCRICAOESTADUAL")]
        public string InscricaoEstadual { get; set; }

        [DisplayName("E-Mail")]
        [Column("EMAIL")]
        public string email { get; set; }

        [DisplayName("RNTRC")]
        [Column("RNTRC")]
        public string RNTRC { get; set; }

        public virtual ICollection<NotaFiscal> NotaFiscal { get; set; }
    }
}
