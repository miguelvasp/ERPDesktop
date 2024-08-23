using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ERP.Models
{
    [Table("GRUPOESTOQUE", Schema = "DBO")]
    public class GrupoEstoque
    {
        [Key]
        [DisplayName("Id")]
        [Column("IDGRUPOESTOQUE")]
        public int IdGrupoEstoque { get; set; }
 
        [DisplayName("Nome")]
        [Column("NOME")]
        public string Nome { get; set; }
 
        [DisplayName("Descrição")]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
 
        [DisplayName("Estoque")]
        [Column("ESTOQUE")]
        public bool Estoque { get; set; }
 
        [DisplayName("Estoque Negativo")]
        [Column("ESTOQUENEGATIVO")]
        public bool EstoqueNegativo { get; set; }
 
        [DisplayName("Estoque Físico")]
        [Column("ESTOQUEFISICO")]
        public bool EstoqueFisico { get; set; }
 
        [DisplayName("Estoque Financeiro")]
        [Column("ESTOQUEFINANCEIRO")]
        public bool EstoqueFinanceiro { get; set; }
 
        [DisplayName("Modelo Estoque")]
        [Column("MODELOESTOQUE")]
        public int ModeloEstoque { get; set; }
 
        [DisplayName("Lote Fornecedor")]
        [Column("LOTEFORNECEDOR")]
        public bool LoteFornecedor { get; set; }
    }
}
