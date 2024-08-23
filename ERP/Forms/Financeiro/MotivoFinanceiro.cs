using ERP.Util;
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
    [Table("MOTIVOFINANCEIRO", Schema = "DBO")]
    public class MotivoFinanceiro
    {
        [Key]
        [DisplayName("Id Motivo Financeiro")]
        [Column("IDMOTIVOFINANCEIRO")]
        public int IdMotivoFinanceiro { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Ativo")]
        [Column("ATIVO")]
        public bool Ativo { get; set; }

        [DisplayName("Banco")]
        [Column("BANCO")]
        public bool Banco { get; set; }

        [DisplayName("Cliente")]
        [Column("CLIENTE")]
        public bool Cliente { get; set; }

        [DisplayName("Fornecedor")]
        [Column("FORNECEDOR")]
        public bool Fornecedor { get; set; }

        [DisplayName("ContaContabil")]
        [Column("CONTACONTABIL")]
        public bool ContaContabil { get; set; }
    }
}
