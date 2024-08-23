
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("LOCALIZACAO", Schema = "DBO")]
    public class Localizacao
    {
        [Key]
        [DisplayName("IdLocalizacao")]
        [Column("IDLOCALIZACAO")]
        public int IdLocalizacao { get; set; }
 
        [DisplayName("IdDeposito")]
        [Column("IDDEPOSITO")]
        public int? IdDeposito { get; set; }
        public virtual Deposito Deposito { get; set; }

        [DisplayName("IdCorredor")]
        [Column("IDCORREDOR")]
        public int? IdCorredor { get; set; }
        public virtual Corredor Corredor { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("TipoLocalizacao")]
        [Column("TIPOLOCALIZACAO")]
        public int? TipoLocalizacao { get; set; }
 
        [DisplayName("Rack")]
        [Column("RACK")]
        public int? Rack { get; set; }
 
        [DisplayName("Prateleira")]
        [Column("PRATELEIRA")]
        public int? Prateleira { get; set; }
 
        [DisplayName("Localizacao")]
        [Column("LOCALIZACAODESC")]
        public int? LocalizacaoDesc { get; set; }
 
        [DisplayName("MaxDePaletes")]
        [Column("MAXDEPALETES")]
        public int? MaxDePaletes { get; set; }
 
        [DisplayName("Altura")]
        [Column("ALTURA")]
        public decimal? Altura { get; set; }
 
        [DisplayName("Largura")]
        [Column("LARGURA")]
        public decimal? Largura { get; set; }
 
        [DisplayName("Profundidade")]
        [Column("PROFUNDIDADE")]
        public decimal? Profundidade { get; set; }
 
        [DisplayName("Volume")]
        [Column("VOLUME")]
        public decimal? Volume { get; set; }
 
        [DisplayName("AlturaAbsoluta")]
        [Column("ALTURAABSOLUTA")]
        public decimal? AlturaAbsoluta { get; set; }
 
        [DisplayName("PesoMaximo")]
        [Column("PESOMAXIMO")]
        public decimal? PesoMaximo { get; set; }
 
        [DisplayName("VolumeMaximo")]
        [Column("VOLUMEMAXIMO")]
        public decimal? VolumeMaximo { get; set; }
 
    }
}
