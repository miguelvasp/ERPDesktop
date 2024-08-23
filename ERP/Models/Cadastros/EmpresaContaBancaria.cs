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
    [Table("EMPRESACONTABANCARIA", Schema = "DBO")]
    public class EmpresaContaBancaria
    {
        [Key]
        [DisplayName("Id Empresa Conta Bancária")]
        [Column("IDEMPRESACONTABANCARIA")]
        public int IdEmpresaContaBancari { get; set; }

        [DisplayName("Id Empresa")]
        [Column("IDEMPRESA")]
        public int IdEmpresa { get; set; }

        [DisplayName("Id Conta Bancária")]
        [Column("IDCONTABANCARIA")]
        public int IdContaBancaria { get; set; }
        public virtual ContaBancaria ContaBancaria { get; set; } 
    }
}
