
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("CONTABILIDADE", Schema = "DBO")]
    public class Contabilidade
    {
        [Key]
        [DisplayName("IdContabilidade")]
        [Column("IDCONTABILIDADE")]
        public int IdContabilidade { get; set; }
 
        [DisplayName("IdOrigemLancamento")]
        [Column("IDORIGEMLANCAMENTO")]
        public int? IdOrigemLancamento { get; set; }
 
        [DisplayName("IdContaContabil")]
        [Column("IDCONTACONTABIL")]
        public int? IdContaContabil { get; set; }
 
        [DisplayName("IdLote")]
        [Column("IDLOTE")]
        public int? IdLote { get; set; }
 
        [DisplayName("ValorCredito")]
        [Column("VALORCREDITO")]
        public decimal? ValorCredito { get; set; }
 
        [DisplayName("ValorDebito")]
        [Column("VALORDEBITO")]
        public decimal? ValorDebito { get; set; }
 
        [DisplayName("DataHora")]
        [Column("DATAHORA")]
        public DateTime? DataHora { get; set; }
 
        [DisplayName("Usuario")]
        [Column("USUARIO")]
        public string Usuario { get; set; }
 
        [DisplayName("IdCentroCusto")]
        [Column("IDCENTROCUSTO")]
        public int? IdCentroCusto { get; set; }
 
        [DisplayName("IdMoeda")]
        [Column("IDMOEDA")]
        public int? IdMoeda { get; set; }
 
        [DisplayName("ValorAjusteDebito")]
        [Column("VALORAJUSTEDEBITO")]
        public decimal? ValorAjusteDebito { get; set; }
 
        [DisplayName("ValorAjusteCredito")]
        [Column("VALORAJUSTECREDITO")]
        public decimal? ValorAjusteCredito { get; set; }
 
        [DisplayName("Preco")]
        [Column("PRECO")]
        public decimal? Preco { get; set; }
 
        [DisplayName("IdRegraDistribuicao")]
        [Column("IDREGRADISTRIBUICAO")]
        public int? IdRegraDistribuicao { get; set; }
 
        [DisplayName("IdFornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }
 
        [DisplayName("IdCliente")]
        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }
 
        [DisplayName("IdEmpresa")]
        [Column("IDEMPRESA")]
        public int? IdEmpresa { get; set; }
 
        [DisplayName("Aprovado")]
        [Column("APROVADO")]
        public bool Aprovado { get; set; }
 
        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime? Data { get; set; }
 
        [DisplayName("Aprovador")]
        [Column("APROVADOR")]
        public string Aprovador { get; set; }
 
        [DisplayName("NumeroCheque")]
        [Column("NUMEROCHEQUE")]
        public int? NumeroCheque { get; set; }
 
        [DisplayName("Origem")]
        [Column("ORIGEM")]
        public string Origem { get; set; }
 
    }
}
