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
    public class EncargosAutomaticos
    {
        [Key]
        [DisplayName("Id Encargos Automáticos")]
        [Column("IDENCARGOSAUTOMATICOS")]
        public int IdEncargosAutomaticos { get; set; }

        [DisplayName("Id Cliente")]
        [Column("IDCLIENTE")]
        public int? IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        [DisplayName("Id Fornecedor")]
        [Column("IDFORNECEDOR")]
        public int? IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        [DisplayName("Id Grupo Cliente")]
        [Column("IDGRUPOCLIENTE")]
        public int? IdGrupoCliente { get; set; }
        public virtual GrupoCliente GrupoCliente { get; set; }

        [DisplayName("Id Grupo Fornecedor")]
        [Column("IDGRUPOFORNECEDOR")]
        public int? IdGrupoFornecedor { get; set; }
        public virtual GrupoFornecedor GrupoFornecedor { get; set; }

        [DisplayName("Id Produto")]
        [Column("IDPRODUTO")]
        public int? IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        [DisplayName("Id Grupo Produto")]
        [Column("IDGRUPOPRODUTO")]
        public int? IdGrupoProduto { get; set; }

        [DisplayName("Relação Grupo")]
        [Column("RELACAOGRUPO")]
        public int? RelacaoGrupo { get; set; }

        [DisplayName("Relação de Item")]
        [Column("RELACAOITEM")]
        public int? RelacaoItem { get; set; }

        [DisplayName("Id Modo Entrega")]
        [Column("IDMODOENTREGA")]
        public int? IdModoEntrega { get; set; }

        [DisplayName("Id Relacao Modo Entrega")]
        [Column("IDMODELOENTREGA")]
        public int? IdRelacaoModoEntrega { get; set; }

        [DisplayName("Id Grupo Encargos")]
        [Column("IDGRUPOENCARGOS")]
        public int? IdGrupoEncargos { get; set; }
        public virtual GrupoEncargos GrupoEncargos { get; set; }

        [DisplayName("Categoria")]
        [Column("CATEGORIA")]
        public int? Categoria { get; set; }

        [DisplayName("Valor Encargos")]
        [Column("VALORENCARGOS")]
        public decimal ValorEncargos { get; set; }

        [DisplayName("Id Moeda")]
        [Column("IDMOEDA")]
        public int? IdMoeda { get; set; }
        public virtual Moeda Moeda { get; set; }

        [DisplayName("Id Grupo Imposto")]
        [Column("IDGRUPOIMPOSTO")]
        public int? IdGrupoImposto { get; set; }
        public virtual GrupoImposto GrupoImposto { get; set; }
    }
}
