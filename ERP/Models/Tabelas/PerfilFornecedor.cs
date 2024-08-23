using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("PERFILFORNECEDOR", Schema = "DBO")]
    public class PerfilFornecedor
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPERFILFORNECEDOR")]
        public int IdPerfilFornecedor { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Relação Grupo")]
        [Column("RELACAOGRUPO")]
        public int? RelacaoGrupo { get; set; }
 
        [DisplayName("Id Fornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
 
        [DisplayName("Id Grupo Fornecedor")]
        [Column("IDGRUPOFORNECEDOR")]
        public int? IdGrupoFornecedor { get; set; }
        public virtual GrupoFornecedor GrupoFornecedor { get; set; }
 
        [DisplayName("IdContaContabil")]
        [Column("IDCONTACONTABIL")]
        public int? IdContaContabil { get; set; }
 
        [DisplayName("IdContaContabilLiquidar")]
        [Column("IDCONTACONTABILLIQUIDAR")]
        public int? IdContaContabilLiquidar { get; set; }
 
        [DisplayName("IdContaContabilPagamentoAntecipado")]
        [Column("IDCONTACONTABILPAGAMENTOANTECIPADO")]
        public int? IdContaContabilPagamentoAntecipado { get; set; }
 
        [DisplayName("IdContaContabilContraPartida")]
        [Column("IDCONTACONTABILCONTRAPARTIDA")]
        public int? IdContaContabilContraPartida { get; set; }
 
        [DisplayName("IdContaContabilTransferenciaImposto")]
        [Column("IDCONTACONTABILTRANSFERENCIAIMPOSTO")]
        public int? IdContaContabilTransferenciaImposto { get; set; }
 
        [DisplayName("IdContaContabilJuros")]
        [Column("IDCONTACONTABILJUROS")]
        public int? IdContaContabilJuros { get; set; }
 
        [DisplayName("IdContaContabilMulta")]
        [Column("IDCONTACONTABILMULTA")]
        public int? IdContaContabilMulta { get; set; }

        [DisplayName("Baixa")]
        [Column("BAIXA")]
        public bool Baixa { get; set; }
    }
}
