using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("RECURSOS", Schema = "DBO")]
    public class Recursos
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDRECURSO")]
        public int IdRecurso { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Tipo")]
        [Column("TIPO")]
        public int? Tipo { get; set; }

        [DisplayName("UnidadeCapacidade")]
        [Column("UNIDADECAPACIDADE")]
        public int? UnidadeCapacidade { get; set; }

        [DisplayName("Capacidade")]
        [Column("CAPACIDADE")]
        public decimal? Capacidade { get; set; }

        [DisplayName("CapacidadeLote")]
        [Column("CAPACIDADELOTE")]
        public decimal? CapacidadeLote { get; set; }

        [DisplayName("PorcentagemEficiencia")]
        [Column("PORCENTAGEMEFICIENCIA")]
        public decimal? PorcentagemEficiencia { get; set; }

        [DisplayName("PorcentagemPlanoOperacao")]
        [Column("PORCENTAGEMPLANOOPERACAO")]
        public decimal? PorcentagemPlanoOperacao { get; set; }

        [DisplayName("CapacidadeFinita")]
        [Column("CAPACIDADEFINITA")]
        public bool CapacidadeFinita { get; set; }

        [DisplayName("PropriedadeFinita")]
        [Column("PROPRIEDADEFINITA")]
        public bool PropriedadeFinita { get; set; }

        [DisplayName("Exclusivo")]
        [Column("EXCLUSIVO")]
        public bool Exclusivo { get; set; }

        [DisplayName("IdGrupoRoteiro")]
        [Column("IDGRUPOROTEIRO")]
        public int? IdGrupoRoteiro { get; set; }

        [DisplayName("PorcentagemSucata")]
        [Column("PORCENTAGEMSUCATA")]
        public int? PorcentagemSucata { get; set; }

        [DisplayName("TempoEsperaAnterior")]
        [Column("TEMPOESPERAANTERIOR")]
        public int? TempoEsperaAnterior { get; set; }

        [DisplayName("TempoEsperaPosterior")]
        [Column("TEMPOESPERAPOSTERIOR")]
        public int? TempoEsperaPosterior { get; set; }

        [DisplayName("TempoExecusao")]
        [Column("TEMPOEXECUSAO")]
        public int? TempoExecusao { get; set; }

        [DisplayName("TempoPreparacao")]
        [Column("TEMPOPREPARACAO")]
        public int? TempoPreparacao { get; set; }

        [DisplayName("TempoTransito")]
        [Column("TEMPOTRANSITO")]
        public int? TempoTransito { get; set; }

        [DisplayName("IdFuncionario")]
        [Column("IDFUNCIONARIO")]
        public int? IdFuncionario { get; set; }

        [DisplayName("HorasTempo")]
        [Column("HORASTEMPO")]
        public int? HorasTempo { get; set; }

        [DisplayName("IdLocalProducao")]
        [Column("IDLOCALPRODUCAO")]
        public int? IdLocalProducao { get; set; }

        [DisplayName("IdContaContabilCusto")]
        [Column("IDCONTACONTABILCUSTO")]
        public int? IdContaContabilCusto { get; set; }

        [DisplayName("IdContaContabilContraCusto")]
        [Column("IDCONTACONTABILCONTRACUSTO")]
        public int? IdContaContabilContraCusto { get; set; }

        [DisplayName("IdContaContabilWIP")]
        [Column("IDCONTACONTABILWIP")]
        public int? IdContaContabilWIP { get; set; }

        [DisplayName("IdContaContabilContaPartidaWIP")]
        [Column("IDCONTACONTABILCONTAPARTIDAWIP")]
        public int? IdContaContabilContaPartidaWIP { get; set; }

    }
}
