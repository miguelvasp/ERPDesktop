
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CONFIGURACAOCHEQUE", Schema = "DBO")]
    public class ConfiguracaoCheque
    {
        [Key]
        [DisplayName("IdConfiguracaoCheque")]
        [Column("IDCONFIGURACAOCHEQUE")]
        public int? IdConfiguracaoCheque { get; set; }
 
        [DisplayName("Descricao")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Ordem")]
        [Column("ORDEM")]
        public string Ordem { get; set; }
 
        [DisplayName("HabilitadoContabilizacaoPrincipal")]
        [Column("HABILITADOCONTABILIZACAOPRINCIPAL")]
        public bool? HabilitadoContabilizacaoPrincipal { get; set; }
 
        [DisplayName("TextoTransacao")]
        [Column("TEXTOTRANSACAO")]
        public string TextoTransacao { get; set; }
 
        [DisplayName("TipoContaDebito")]
        [Column("TIPOCONTADEBITO")]
        public int? TipoContaDebito { get; set; }

        [DisplayName("TipoContaCredito")]
        [Column("TIPOCONTACREDITO")]
        public int? TipoContaCredito { get; set; }

        [DisplayName("IdContaContabilDebito")]
        [Column("IDCONTACONTABILDEBITO")]
        public int? IdContaContabilDebito { get; set; }
 
        [DisplayName("IdContaContabilCredito")]
        [Column("IDCONTACONTABILCREDITO")]
        public int? IdContaContabilCredito { get; set; }
 
    }
}
