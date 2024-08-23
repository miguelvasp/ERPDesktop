
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("FAVORITOS", Schema = "DBO")]
    public class Favoritos
    {
        [Key]
        [DisplayName("IdFavorito")]
        [Column("IDFAVORITO")]
        public int IdFavorito { get; set; }
 
        [DisplayName("IdUsuario")]
        [Column("IDUSUARIO")]
        public int? IdUsuario { get; set; }
 
        [DisplayName("Form")]
        [Column("FORM")]
        public string Form { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("Grupo")]
        [Column("GRUPO")]
        public string Grupo { get; set; }
 
    }
}
