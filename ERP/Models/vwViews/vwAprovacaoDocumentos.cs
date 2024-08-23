
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("VWAPROVACAODOCUMENTOS", Schema = "DBO")]
    public class vwAprovacaoDocumentos
    {
        [Key]
        [DisplayName("Documento")]
        [Column("DOCUMENTO")]
        public string Documento { get; set; }

        [DisplayName("Id")]
        [Column("ID")]
        public int? Id { get; set; }
 
        [DisplayName("TipoDocumento")]
        [Column("TIPODOCUMENTO")]
        public int? TipoDocumento { get; set; }
 
        
 
        [DisplayName("Data")]
        [Column("DATA")]
        public DateTime? Data { get; set; }
 
        [DisplayName("Responsavel")]
        [Column("RESPONSAVEL")]
        public string Responsavel { get; set; }
 
        [DisplayName("Status")]
        [Column("STATUS")]
        public string Status { get; set; }
 
        [DisplayName("Sequencia")]
        [Column("SEQUENCIA")]
        public int? Sequencia { get; set; }
 
        [DisplayName("IdUsuario")]
        [Column("IDUSUARIO")]
        public int? IdUsuario { get; set; }
 
        [DisplayName("Valor")]
        [Column("VALOR")]
        public decimal? Valor { get; set; }
 
    }
}
