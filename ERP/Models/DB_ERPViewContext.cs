using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class DB_ERPViewContext : DbContext
    {
        public DB_ERPViewContext()
            : base("DB_ERPContext")
        {
            Database.SetInitializer<DB_ERPViewContext>(null);
        }

        public DbSet<vwAjusteEstoque> vwAjusteEstoque { get; set; }
        public DbSet<vwAprovacaoDocumentos> vwAprovacaoDocumentos { get; set; }
        public DbSet<vwTargetFields> vwTargetFields { get; set; }
        public DbSet<vwTableRelations> vwTableRelations { get; set; }
        public DbSet<vwPesquisaProduto> vwPesquisaProduto { get; set; }
        public DbSet<vwPedidoVendaSeparacao> vwPedidoVendaSeparacao { get; set; }
        public DbSet<vwEstoqueAnalitico> vwEstoqueAnalitico { get; set; }
        public DbSet<vwEstoqueSintetico> vwEstoqueSintetico { get; set; }
        public DbSet<vwChequeTerceiros> vwChequeTerceiros { get; set; }
        public DbSet<vwVencimentos> vwVencimentos { get; set; }
        public DbSet<vwVencimentosrecebimentos> vwVencimentosrecebimentos { get; set; }
        public DbSet<vwPedidoVendasRel> vwPedidoVendasRel { get; set; }
        public DbSet<vwPedidosCompraRecebimento> vwPedidosCompraRecebimento { get; set; }
        public DbSet<vwTabelaOrcamento> vwTabelaOrcamento { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}