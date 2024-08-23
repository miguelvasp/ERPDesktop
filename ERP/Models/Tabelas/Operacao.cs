using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("OPERACAO", Schema = "DBO")]
    public class Operacao
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDOPERACAO")]
        public int IdOperacao { get; set; }
 
        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("MovimentaEstoque")]
        [Column("MOVIMENTAESTOQUE")]
        public bool? MovimentaEstoque { get; set; }
 
        [DisplayName("Transações Financeiras")]
        [Column("TRANSACOESFINANCEIRAS")]
        public bool? TransacoesFinanceiras { get; set; }

        [DisplayName("Id Conta Contábil")]
        [Column("IDCONTACONTABIL")]
        public int? IdContaContabil { get; set; }
        public virtual ContaContabil ContaContabil { get; set; }
 
        [DisplayName("IdPerfilFornecedor")]
        [Column("IDPERFILFORNECEDOR")]
        public int? IdPerfilFornecedor { get; set; }
        public virtual PerfilFornecedor PerfilFornecedor { get; set; }
 
        [DisplayName("IdPerfilCliente")]
        [Column("IDPERFILCLIENTE")]
        public int? IdPerfilCliente { get; set; }

        [DisplayName("Transações Contábeis")]
        [Column("TRANSACOESCONTABEIS")]
        public bool? TransacoesContabeis { get; set; }

        [DisplayName("IdTipoDirecaoNF")]
        [Column("IDTIPODIRECAONF")]
        public int? IdTipoDirecaoNF { get; set; }

        [DisplayName("IdDirecaoNF")]
        [Column("IDDIRECAONF")]
        public int? IdDirecaoNF { get; set; }

        public int? IdCFOPInterno { get; set; }

        public int? IDCFOPExterno { get; set; }

        public bool? Bonificacao { get; set; }

        public virtual PerfilCliente PerfilCliente { get; set; } 
     }
}
