
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("GRUPORASTREAMENTO", Schema = "DBO")]
    public class GrupoRastreamento
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDGRUPORASTREAMENTO")]
        public int IdGrupoRastreamento { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("Descri��o")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Obrigat�rio")]
        [Column("OBRIGATORIO")]
        public bool Obrigatorio { get; set; }
 
        [DisplayName("N�mero Lote Ativo")]
        [Column("NUMEROLOTEATIVO")]
        public bool NumeroLoteAtivo { get; set; }

        [DisplayName("N�mero Lote Sa�da")]
        [Column("NUMEROLOTESAIDA")]
        public bool NumeroLoteSaida { get; set; }

        [DisplayName("N�mero Lote Entrada")]
        [Column("NUMEROLOTEENTRADA")]
        public bool NumeroLoteEntrada { get; set; }

        [DisplayName("N�mero S�rie Ativo")]
        [Column("NUMEROSERIEATIVO")]
        public bool NumeroSerieAtivo { get; set; }

        [DisplayName("N�mero S�rie Sa�da")]
        [Column("NUMEROSERIESAIDA")]
        public bool NumeroSerieSaida { get; set; }

        [DisplayName("N�mero S�rie Entrada")]
        [Column("NUMEROSERIEENTRADA")]
        public bool NumeroSerieEntrada { get; set; }
 
    }
}
