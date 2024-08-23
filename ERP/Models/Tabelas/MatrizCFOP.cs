using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    [Table("MATRIZCFOP", Schema = "DBO")]
   public class MatrizCFOP
    {
        [Key]
        [DisplayName("Id Matriz CFOP")]
        [Column("IDMATRIZCFOP")]
        public int IdMatrizCFOP { get; set; }

        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [DisplayName("Tipo Transação")]
        [Column("TIPOTRANSACAO")]
        public int? TipoTransacao { get; set; }

        [DisplayName("Id CFOP")]
        [Column("IDCFOP")]
        public int IdCFOP { get; set; }
        public virtual CFOP CFOP { get; set; }

        [DisplayName("Id Grupo CFOP")]
        [Column("IDGRUPOCFOP")]
        public int IdGrupoCFOP { get; set; }
        public virtual GrupoCFOP GrupoCFOP { get; set; }

        [DisplayName("Id Operação")]
        [Column("IDOPERACAO")]
        public int IdOperacao { get; set; }
        public virtual Operacao Operacao { get; set; }
    }
}
