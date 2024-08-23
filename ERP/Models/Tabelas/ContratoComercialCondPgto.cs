using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("CONTRATOCOMERCIALCONDPGTO", Schema = "DBO")]
    public class ContratoComercialCondPgto
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDCONTRATOCOMERCIALCONDPGTO")]
        public int IdContratoComercialCondPgto { get; set; }

        [DisplayName("Id Contrato Comercial")]
        [Column("IDCONTRATOCOMERCIAL")]
        public int IdContratoComercial { get; set; }

        [DisplayName("Id Condição Pagamento")]
        [Column("IDCONDICAOPAGAMENTO")]
        public int IdCondicaoPagamento { get; set; }

        [DisplayName("Juros")]
        [Column("JUROS")]
        public decimal Juros { get; set; }
    }
}
