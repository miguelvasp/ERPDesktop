
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CFOP", Schema = "DBO")]
    public class CFOP
    {
        [Key]
        [DisplayName("IdCFOP")]
        [Column("IDCFOP")]
        public int IdCFOP { get; set; }
 
        [DisplayName("CFOP")]
        [Column("CFOPCOD")]
        public string CFOPCOD { get; set; }

        [DisplayName("Descri��o")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Localiza��o")]
        [Column("LOCALIZACAO")]
        public int? Localizacao { get; set; }
 
        [DisplayName("Dire��o")]
        [Column("DIRECAO")]
        public int? Direcao { get; set; }
 
        [DisplayName("Id Texto Padr�o")]
        [Column("IDTEXTOPADRAO")]
        public int? IdTextoPadrao { get; set; }
        public virtual TextoPadrao TextoPadrao { get; set; }
 
        [DisplayName("Finalidade")]
        [Column("FINALIDADE")]
        public int? Finalidade { get; set; }
 
        [DisplayName("Considerar CIAP")]
        [Column("CONSIDERARCIAP")]
        public bool? ConsiderarCIAP { get; set; }
    }
}
