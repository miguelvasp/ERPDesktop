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
    [Table("ENDERECO", Schema = "DBO")]
    public class Endereco
    {
        [Key]
        [DisplayName("Id Endereço")]
        [Column("IDENDERECO")]
        public int IdEndereco { get; set; }

        [DisplayName("Id Tipo Endereço")]
        [Column("IDTIPOENDERECO")]
        public int IdTipoEndereco { get; set; }
        public virtual TipoEndereco TipoEndereco { get; set; }

        [DisplayName("Id Pais")]
        [Column("IDPAIS")]
        public int IdPais { get; set; }
        public virtual Pais Pais { get; set; }

        [DisplayName("Id UF")]
        [Column("IDUF")]
        public int IdUF { get; set; }
        public virtual UnidadeFederacao UnidadeFederacao { get; set; }

        [DisplayName("Id Cidade")]
        [Column("IDCIDADE")]
        public int IdCidade { get; set; }
        public virtual Cidade Cidade { get; set; }

        [DisplayName("Logradouro")]
        [Column("LOGRADOURO")]
        public string Logradouro { get; set; }

        [DisplayName("Bairro")]
        [Column("BAIRRO")]
        public string Bairro { get; set; }

        [DisplayName("Código Postal")]
        [Column("CODIGOPOSTAL")]
        public string CodigoPostal { get; set; }

        [DisplayName("Número")]
        [Column("NUMERO")]
        public string Numero { get; set; }

        [DisplayName("Complemento")]
        [Column("COMPLEMENTO")]
        public string Complemento { get; set; }

        public virtual ICollection<ClienteEndereco> ClienteEndereco { get; set; }
        public virtual ICollection<ContatoEndereco> ContatoEndereco { get; set; }
        public virtual ICollection<FornecedorEndereco> FornecedorEndereco { get; set; }
    }
}
