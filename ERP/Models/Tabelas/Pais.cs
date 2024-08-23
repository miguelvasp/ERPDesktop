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
    [Table("PAIS", Schema = "DBO")]
    public class Pais
    {
        [Key]
        [DisplayName("Id Pa�s")]
        [Column("IDPAIS")]
        public int IdPais { get; set; }

        [DisplayName("Alpha2Code")]
        [Column("ALPHA2CODE")]
        public string Alpha2Code { get; set; }

        [DisplayName("Alpha3Code")]
        [Column("ALPHA3CODE")]
        public string Alpha3Code { get; set; }

        [DisplayName("C�digo")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Nome Pa�s")]
        [Column("NOMEPAIS")]
        public string NomePais { get; set; }

        [DisplayName("C�digo IBGE")]
        [Column("CODIGOIBGE")]
        public string CodigoIBGE { get; set; }

        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}
