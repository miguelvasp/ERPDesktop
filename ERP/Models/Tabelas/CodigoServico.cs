using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("CODIGOSERVICO", Schema = "DBO")]
    public class CodigoServico
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCODIGOSERVICO")]
        public int IdCodigoServico { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Id País")]
        [Column("IDPAIS")]
        public int? IdPais { get; set; }
        public virtual Pais Pais { get; set; }

        [DisplayName("Id UF")]
        [Column("IDUF")]
        public int? IdUF { get; set; }
        public virtual UnidadeFederacao UnidadeFederacao { get; set; }

        [DisplayName("Id Cidade")]
        [Column("IDCIDADE")]
        public int? IdCidade { get; set; }
        public virtual Cidade Cidade { get; set; }
    }
}
