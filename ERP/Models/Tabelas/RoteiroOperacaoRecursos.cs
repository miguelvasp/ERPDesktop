
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("ROTEIROOPERACAORECURSOS", Schema = "DBO")]
    public class RoteiroOperacaoRecursos
    {
        [Key]
        [DisplayName("IdRoteiroOperacaoRecurso")]
        [Column("IDROTEIROOPERACAORECURSO")]
        public int IdRoteiroOperacaoRecurso { get; set; }
 
        [DisplayName("IdRoteiroOperacao")]
        [Column("IDROTEIROOPERACAO")]
        public int? IdRoteiroOperacao { get; set; }
 
        [DisplayName("IdRoteiroOperacaoLinha")]
        [Column("IDROTEIROOPERACAOLINHA")]
        public int? IdRoteiroOperacaoLinha { get; set; }
 
        [DisplayName("Tipo")]
        [Column("TIPO")]
        public int? Tipo { get; set; }
 
        [DisplayName("IdRecurso")]
        [Column("IDRECURSO")]
        public int? IdRecurso { get; set; }
 
        [DisplayName("IdCapacidadeRecurso")]
        [Column("IDCAPACIDADERECURSO")]
        public int? IdCapacidadeRecurso { get; set; }
 
        [DisplayName("IdGrupoRecurso")]
        [Column("IDGRUPORECURSO")]
        public int? IdGrupoRecurso { get; set; }
 
        [DisplayName("IdRecursoAvaliacaoCusto")]
        [Column("IDRECURSOAVALIACAOCUSTO")]
        public int? IdRecursoAvaliacaoCusto { get; set; }
 
        [DisplayName("PlanejamentoTrabalho")]
        [Column("PLANEJAMENTOTRABALHO")]
        public bool PlanejamentoTrabalho { get; set; }
 
        [DisplayName("PlanejamentoOperacao")]
        [Column("PLANEJAMENTOOPERACAO")]
        public bool PlanejamentoOperacao { get; set; }
 
    }
}
