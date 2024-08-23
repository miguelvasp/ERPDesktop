
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
 
        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Obrigatório")]
        [Column("OBRIGATORIO")]
        public bool Obrigatorio { get; set; }
 
        [DisplayName("Site Ativo")]
        [Column("SITEATIVO")]
        public bool SiteAtivo { get; set; }
 
        [DisplayName("Site Saída")]
        [Column("SITESAIDA")]
        public bool SiteSaida { get; set; }
 
        [DisplayName("Site Entrada")]
        [Column("SITEENTRADA")]
        public bool SiteEntrada { get; set; }
 
        [DisplayName("Depósito Ativo")]
        [Column("DEPOSITOATIVO")]
        public bool DepositoAtivo { get; set; }
 
        [DisplayName("Depósito Saída")]
        [Column("DEPOSITOSAIDA")]
        public bool DepositoSaida { get; set; }
 
        [DisplayName("Depósito Entrada")]
        [Column("DEPOSITOENTRADA")]
        public bool DepositoEntrada { get; set; }
 
        [DisplayName("Localização Ativo")]
        [Column("LOCALIZACAOATIVO")]
        public bool LocalizacaoAtivo { get; set; }
 
        [DisplayName("Localização Saída")]
        [Column("LOCALIZACAOSAIDA")]
        public bool LocalizacaoSaida { get; set; }
 
        [DisplayName("Localização Entrada")]
        [Column("LOCALIZACAOENTRADA")]
        public bool LocalizacaoEntrada { get; set; }
 
    }
}
