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
    [Table("TELEFONE", Schema = "DBO")]
    public class Telefone
    {
        [Key]
        [DisplayName("Id Telefone")]
        [Column("IDTELEFONE")]
        public int IdTelefone { get; set; }

        [DisplayName("Id Tipo Telefone")]
        [Column("IDTIPOTELEFONE")]
        public int IdTipoTelefone { get; set; }
        public virtual TipoTelefone TipoTelefone { get; set; }

        [DisplayName("Código País")]
        [Column("CODIGOPAIS")]
        public string CodigoPais { get; set; }

        [DisplayName("DDD")]
        [Column("DDD")]
        public string DDD { get; set; }

        [DisplayName("Telefone")]
        [Column("NUMEROTELEFONE")]
        public string NumeroTelefone { get; set; }

        //public virtual ICollection<ClienteTelefone> ClienteTelefone { get; set; }
        //public virtual ICollection<Contato> ContatoTelefone { get; set; }
        //public virtual ICollection<FornecedorTelefone> FornecedorTelefone { get; set; }
        //public virtual ICollection<NotaFiscal> NotaFiscal { get; set; }
    }
}
