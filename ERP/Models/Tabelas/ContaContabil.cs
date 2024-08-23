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
    [Table("CONTACONTABIL", Schema = "DBO")]
    public class ContaContabil
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCONTACONTABIL")]
        public int IdContaContabil { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Id Conta Tipo Lançamento")]
        [Column("IDCONTATIPOLANCAMENTO")]
        public int? IdContaTipoLancamento { get; set; }
        //public virtual ContaGerencial ContaTipoLancamento { get; set; }

        [DisplayName("Proposta Débito/Crédito")]
        [Column("PROPOSTADEBCRE")]
        public int? PropostaDEBCRE { get; set; }

        [DisplayName("Fechar")]
        [Column("FECHAR")]
        public bool Fechar { get; set; }

        [DisplayName("Id Conta Hierarquia")]
        [Column("IDCONTAHIERARQUIA")]
        public int? IdContaHierarquia { get; set; }
        //public virtual ContaGerencial ContaHierarquia { get; set; }

        [DisplayName("Id Conta Consolidação")]
        [Column("IDCONTACONSOLIDACAO")]
        public int? IdContaConsolidacao { get; set; }
        //public virtual ContaGerencial ContaConsolidacao { get; set; }

        [DisplayName("Id Moeda")]
        [Column("IDMOEDA")]
        public int? IdMoeda { get; set; }
        public virtual Moeda Moeda { get; set; }

        [DisplayName("Id Tipo Conta")]
        [Column("IDTIPOCONTA")]
        public int? IdTipoConta { get; set; }
        //public virtual ContaGerencial TipoConta { get; set; }

        [DisplayName("Id Conta Plano Referencial")]
        [Column("IDCONTAPLANOREFERENCIAL")]
        public int? IdContaPlanoReferencial { get; set; }
        public virtual ContaPlanoReferencial ContaPlanoReferencial { get; set; }

        [Column("DEPARA")]
        public string DePara { get; set; }

        [Column("NATUREZA")]
        public int? Natureza { get; set; }

        [Column("NIVEL")]
        public int? Nivel { get; set; }

        [Column("TIPORECEITADESPESA")]
        public int? TipoReceitaDespesa { get; set; }


    }
}
