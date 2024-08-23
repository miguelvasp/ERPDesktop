using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("CONDICAOPAGAMENTO", Schema = "DBO")]
    public class CondicaoPagamento
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCONDICAOPAGAMENTO")]
        public int IdCondicaoPagamento { get; set; }

        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
        
        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Método Pagamento")]
        [Column("METODOPAGAMENTO")]
        public int? MetodoPagamento { get; set; }

        [DisplayName("Mês")]
        [Column("MES")]
        public int Mes { get; set; }

        [DisplayName("Dias")]
        [Column("DIAS")]
        public int? Dias { get; set; }

        [DisplayName("Id Plano Pagamento")]
        [Column("IDPLANOPAGAMENTO")]
        public int? IdPlanoPagamento { get; set; }
        public virtual PlanoPagamento PlanoPagamento { get; set; }

        [DisplayName("Id Dias Pagamento")]
        [Column("IDDIASPAGAMENTO")]
        public int? IdDiasPagamento { get; set; }
        public virtual DiasPagamento DiasPagamento { get; set; }

        [DisplayName("Data de Corte")]
        [Column("DATACORTE")]
        public DateTime? DataCorte { get; set; }

        [DisplayName("Mês Adicional")]
        [Column("MESADICIONAL")]
        public int MesAdicional { get; set; }
        
        [DisplayName("Qtde Parcelas")]
        [Column("QTDEPARCELAS")]
        public int QtdeParcelas { get; set; }
 
        [DisplayName("ForaSemana")]
        [Column("FORASEMANA")]
        public bool ForaSemana { get; set; }

        [Column("CONDICAOVENDAS")]
        public bool? CondicaoVendas { get; set; }

        //public virtual ICollection<CondicaoPagamentoIntervalo> CondicaoPagamentoIntervalo { get; set; }
        //public virtual ICollection<PedidoCompra> PedidoCompra { get; set; }
    }
}
