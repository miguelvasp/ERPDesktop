
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
 
        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Obrigatório")]
        [Column("OBRIGATORIO")]
        public bool Obrigatorio { get; set; }
 
        [DisplayName("Número Lote Ativo")]
        [Column("NUMEROLOTEATIVO")]
        public bool NumeroLoteAtivo { get; set; }

        [DisplayName("Número Lote Saída")]
        [Column("NUMEROLOTESAIDA")]
        public bool NumeroLoteSaida { get; set; }

        [DisplayName("Número Lote Entrada")]
        [Column("NUMEROLOTEENTRADA")]
        public bool NumeroLoteEntrada { get; set; }

        [DisplayName("Número Série Ativo")]
        [Column("NUMEROSERIEATIVO")]
        public bool NumeroSerieAtivo { get; set; }

        [DisplayName("Número Série Saída")]
        [Column("NUMEROSERIESAIDA")]
        public bool NumeroSerieSaida { get; set; }

        [DisplayName("Número Série Entrada")]
        [Column("NUMEROSERIEENTRADA")]
        public bool NumeroSerieEntrada { get; set; }
 
    }
}
