
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("KARDEX", Schema = "DBO")]
    public class Kardex
    {
        [Key]
        [DisplayName("IdKardex")]
        [Column("IDKARDEX")]
        public int? IdKardex { get; set; }
 
        [DisplayName("IdUsuario")]
        [Column("IDUSUARIO")]
        public int? IdUsuario { get; set; }
 
        [DisplayName("Produto")]
        [Column("PRODUTO")]
        public string Produto { get; set; }
 
        [DisplayName("Cor")]
        [Column("COR")]
        public string Cor { get; set; }
 
        [DisplayName("Estilo")]
        [Column("ESTILO")]
        public string Estilo { get; set; }
 
        [DisplayName("Tamanho")]
        [Column("TAMANHO")]
        public string Tamanho { get; set; }
 
        [DisplayName("Config")]
        [Column("CONFIG")]
        public string Config { get; set; }
 
        [DisplayName("Documento")]
        [Column("DOCUMENTO")]
        public int? Documento { get; set; }
 
        [DisplayName("Quantidade")]
        [Column("QUANTIDADE")]
        public decimal? Quantidade { get; set; }
 
        [DisplayName("Saldo")]
        [Column("SALDO")]
        public decimal? Saldo { get; set; }
 
        [DisplayName("EntradaSaida")]
        [Column("ENTRADASAIDA")]
        public string EntradaSaida { get; set; }
 
        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime? Data { get; set; }
 
        [DisplayName("TipoDocumento")]
        [Column("TIPODOCUMENTO")]
        public string TipoDocumento { get; set; }
 
        [DisplayName("SaldoAnterior")]
        [Column("SALDOANTERIOR")]
        public decimal? SaldoAnterior { get; set; }
 
    }
}
