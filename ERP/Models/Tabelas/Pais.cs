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
        [DisplayName("Id País")]
        [Column("IDPAIS")]
        public int IdPais { get; set; }

        [DisplayName("Alpha2Code")]
        [Column("ALPHA2CODE")]
        public string Alpha2Code { get; set; }

        [DisplayName("Alpha3Code")]
        [Column("ALPHA3CODE")]
        public string Alpha3Code { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Nome País")]
        [Column("NOMEPAIS")]
        public string NomePais { get; set; }

        [DisplayName("Código IBGE")]
        [Column("CODIGOIBGE")]
        public string CodigoIBGE { get; set; }

        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}
