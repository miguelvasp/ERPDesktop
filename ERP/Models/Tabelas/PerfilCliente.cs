using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("PERFILCLIENTE", Schema = "DBO")]
    public class PerfilCliente
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDPERFILCLIENTE")]
        public int IdPerfilCliente { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Relação Grupo")]
        [Column("RELACAOGRUPO")]
        public int? RelacaoGrupo { get; set; }

        [DisplayName("Id Cliente")]
        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        [DisplayName("Id Grupo Cliente")]
        [Column("IDGRUPOCLIENTE")]
        public int? IdGrupoCliente { get; set; }
        public virtual GrupoCliente GrupoCliente { get; set; }

        [DisplayName("IdContaContabil")]
        [Column("IDCONTACONTABIL")]
        public int? IdContaContabil { get; set; }

        [DisplayName("IdContaContabilLiquidar")]
        [Column("IDCONTACONTABILLIQUIDAR")]
        public int? IdContaContabilLiquidar { get; set; }

        [DisplayName("IdContaContabilPagamentoAntecipado")]
        [Column("IDCONTACONTABILPAGAMENTOANTECIPADO")]
        public int? IdContaContabilPagamentoAntecipado { get; set; }

        [DisplayName("IdContaContabilDesconto")]
        [Column("IDCONTACONTABILDESCONTO")]
        public int? IdContaContabilDesconto { get; set; }

        [DisplayName("IdContaContabilBaixa")]
        [Column("IDCONTACONTABILBAIXA")]
        public int? IdContaContabilBaixa { get; set; }

        [DisplayName("IdContaContabilJuros")]
        [Column("IDCONTACONTABILJUROS")]
        public int? IdContaContabilJuros { get; set; }

        [DisplayName("IdContaContabilMulta")]
        [Column("IDCONTACONTABILMULTA")]
        public int? IdContaContabilMulta { get; set; }

        [DisplayName("IdContaContabilTransferenciaImposto")]
        [Column("IDCONTACONTABILTRANSFERENCIAIMPOSTO")]
        public int? IdContaContabilTransferenciaImposto { get; set; }

        [DisplayName("Baixa")]
        [Column("BAIXA")]
        public bool Baixa { get; set; }
    }
}
