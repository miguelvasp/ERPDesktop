
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ERP.Models
{
    [Table("LISTAMATERIAIS", Schema = "DBO")]
    public class ListaMateriais
    {
        [Key]
        [DisplayName("IdListaMateriais")]
        [Column("IDLISTAMATERIAIS")]
        public int IdListaMateriais { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("Aprovado")]
        [Column("APROVADO")]
        public bool Aprovado { get; set; }
 
        [DisplayName("NomeAprovador")]
        [Column("NOMEAPROVADOR")]
        public string NomeAprovador { get; set; }
 
        [DisplayName("Bom_Formula")]
        [Column("BOM_FORMULA")]
        public int? Bom_Formula { get; set; }
 
        [DisplayName("IdGrupoLancamento")]
        [Column("IDGRUPOLANCAMENTO")]
        public int? IdGrupoLancamento { get; set; }
 
        [DisplayName("IdArmazem")]
        [Column("IDARMAZEM")]
        public int? IdArmazem { get; set; }

        [DisplayName("IdEmpresa")]
        [Column("IDEMPRESA")]
        public int? IdEmpresa { get; set; }
 
    }
}
