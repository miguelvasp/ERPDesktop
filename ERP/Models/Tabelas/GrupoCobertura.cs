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
    [Table("GRUPOCOBERTURA", Schema = "DBO")]
    public class GrupoCobertura
    {
        [Key]
        [DisplayName("IdGrupoCobertura")]
        [Column("IDGRUPOCOBERTURA")]
        public int IdGrupoCobertura { get; set; }

        [DisplayName("Código")]
        [Column("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Cobertura")]
        [Column("COBERTURA")]
        public int Cobertura { get; set; }

        [DisplayName("Período")]
        [Column("PERIODO")]
        public int Periodo { get; set; }

        [DisplayName("Limite de Tempo")]
        [Column("LIMITETEMPO")]
        public int LimiteTempo { get; set; }

        [DisplayName("Dias Negativo")]
        [Column("DIASNEGATIVO")]
        public int DiasNegativo { get; set; }

        [DisplayName("Dias Positivo")]
        [Column("DIASPOSITIVO")]
        public int DiasPositivo { get; set; }

        [DisplayName("Status Produção")]
        [Column("STATUSPRODUCAO")]
        public int StatusProducao { get; set; }

        [DisplayName("Limite Tempo de Cobertura")]
        [Column("LIMITETEMPOCOBERTURA")]
        public int LimiteTempoCobertura { get; set; }

        [DisplayName("Limite Tempo de Detalhamento")]
        [Column("LIMITETEMPODETALHAMENTO")]
        public int LimiteTempoDetalhamento { get; set; }

        [DisplayName("Limite Tempo de Capacidade")]
        [Column("LIMITETEMPOCAPACIDADE")]
        public int LimiteTempoCapacidade { get; set; }

        [DisplayName("Limite Plano Previsão")]
        [Column("LIMITEPLANOPREVISAO")]
        public int LimitePlanoPrevisao { get; set; }

        [DisplayName("Reduzir Previsão")]
        [Column("REDUZIRPREVISAO")]
        public int ReduziPrevisao { get; set; }
    }
}
