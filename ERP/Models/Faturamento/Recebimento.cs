using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("RECEBIMENTO", Schema = "DBO")]
    public class Recebimento
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDRECEBIMENTO")]
        public int IdRecebimento { get; set; }

        [DisplayName("Recebimento Número")]
        [Column("RECEBIMENTONUMERO")]
        public int RecebimentoNumero { get; set; }
        
        [DisplayName("IdLoteRecebimento")]
        [Column("IDLOTERECEBIMENTO")]
        public int IdLoteRecebimento { get; set; }

        [DisplayName("IdFornecedor")]
        [Column("IDFORNECEDOR")]
        public int IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        [DisplayName("Data Física")]
        [Column("DATAFISICA")]
        public DateTime DataFisica { get; set; }

        [DisplayName("Data Recebimento")]
        [Column("DATARECEBIMENTO")]
        public DateTime? DataRecebimento { get; set; }

        [DisplayName("IdPedidoCompra")]
        [Column("IDPEDIDOCOMPRA")]
        public int IdPedidoCompra { get; set; }

        [Column("CONFIRMADO")]
        public bool? Confirmado { get; set; }    


        [DisplayName("Id")]
        [Column("IDEMPRESA")]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }

        [DisplayName("Id Usuário")]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }



    }
}
