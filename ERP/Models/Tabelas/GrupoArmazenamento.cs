
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("GRUPOARMAZENAMENTO", Schema = "DBO")]
    public class GrupoArmazenamento
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDGRUPOARMAZENAMENTO")]
        public int IdGrupoArmazenamento { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("Descri��o")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Obrigat�rio")]
        [Column("OBRIGATORIO")]
        public bool Obrigatorio { get; set; }
 
        [DisplayName("Site Ativo")]
        [Column("SITEATIVO")]
        public bool SiteAtivo { get; set; }
 
        [DisplayName("Site Sa�da")]
        [Column("SITESAIDA")]
        public bool SiteSaida { get; set; }
 
        [DisplayName("Site Entrada")]
        [Column("SITEENTRADA")]
        public bool SiteEntrada { get; set; }
 
        [DisplayName("Dep�sito Ativo")]
        [Column("DEPOSITOATIVO")]
        public bool DepositoAtivo { get; set; }
 
        [DisplayName("Dep�sito Sa�da")]
        [Column("DEPOSITOSAIDA")]
        public bool DepositoSaida { get; set; }
 
        [DisplayName("Dep�sito Entrada")]
        [Column("DEPOSITOENTRADA")]
        public bool DepositoEntrada { get; set; }
 
        [DisplayName("Localiza��o Ativo")]
        [Column("LOCALIZACAOATIVO")]
        public bool LocalizacaoAtivo { get; set; }
 
        [DisplayName("Localiza��o Sa�da")]
        [Column("LOCALIZACAOSAIDA")]
        public bool LocalizacaoSaida { get; set; }
 
        [DisplayName("Localiza��o Entrada")]
        [Column("LOCALIZACAOENTRADA")]
        public bool LocalizacaoEntrada { get; set; }
 
    }
}
