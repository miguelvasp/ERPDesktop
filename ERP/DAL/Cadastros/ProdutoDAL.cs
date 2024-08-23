using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.ModelView;
using System.Data;

namespace ERP.DAL
{
    public class ProdutoDAL : IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();
        private GenericRepository<Produto> produtoRepository;
        private GenericRepository<ConversaoUnidade> conversaoRepository;

        public GenericRepository<Produto> ProdutoRepository
        {
            get
            {
                if (this.produtoRepository == null)
                {
                    this.produtoRepository = new GenericRepository<Produto>(db);
                }
                return produtoRepository;
            }
        }

        public GenericRepository<ConversaoUnidade> ConversaoRepository
        {
            get
            {
                if (this.conversaoRepository == null)
                {
                    this.conversaoRepository = new GenericRepository<ConversaoUnidade>(db);
                }
                return conversaoRepository;
            }
        }

        public List<ProdutoComboModelView> getProdutosCombo(int TipoProduto)
        {
            int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            List<ProdutoComboModelView> lista = (from p in db.Produto
                                                 where p.CompraProdDescontinuado == false
                                                     & p.IdTipoProduto == TipoProduto
                                                     & p.IdEmpresa == idEmpresa
                                                 select new ProdutoComboModelView
                                                 {
                                                     IdProduto = p.IdProduto,
                                                     Codigo = p.Codigo,
                                                     NomeProduto = p.NomeProduto
                                                 }
                    ).OrderBy(x => x.Codigo).ToList();
            return lista;
        }

        public List<ProdutoComboModelView> getProdutosCombo(int TipoProduto, string IdEmpresa)
        {
            int empresa = IdEmpresa == "" ? 0 : Convert.ToInt32(IdEmpresa);

            List<ProdutoComboModelView> lista = (from p in db.Produto
                                                 where  p.CompraProdDescontinuado == false
                                                     & (p.IdTipoProduto == TipoProduto)
                                                     & (empresa == 0 || p.IdEmpresa == empresa)

                                                 select new ProdutoComboModelView
                                                 {
                                                     IdProduto = p.IdProduto,
                                                     Codigo = p.Codigo,
                                                     NomeProduto = p.NomeProduto
                                                 }
                    ).OrderBy(x => x.Codigo).ToList();
            return lista;
        }

        public List<ProdutoComboModelView> getProdutosGruposCombo(int pIdGrupoProduto)
        {
            int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            List<ProdutoComboModelView> lista = (from p in db.Produto
                                                 where p.CompraProdDescontinuado == false
                                                     & p.IdGrupoProduto == pIdGrupoProduto
                                                     & p.IdEmpresa == idEmpresa
                                                 select new ProdutoComboModelView
                                                 {
                                                     IdProduto = p.IdProduto,
                                                     Codigo = p.Codigo,
                                                     NomeProduto = p.NomeProduto
                                                 }
                    ).OrderBy(x => x.Codigo).ToList();
            return lista;
        }

        public List<ProdutoComboModelView> getProdutosGruposCombo(int pIdGrupoProduto, string IdEmpresa)
        {
            int empresa = IdEmpresa == "" ? 0 : Convert.ToInt32(IdEmpresa);

            List<ProdutoComboModelView> lista = (from p in db.Produto
                                                 where p.CompraProdDescontinuado == false
                                                     & (p.IdGrupoProduto == pIdGrupoProduto) 
                                                     & (empresa == 0 || p.IdEmpresa == empresa)

                                                 select new ProdutoComboModelView
                                                 {
                                                     IdProduto = p.IdProduto,
                                                     Codigo = p.Codigo,
                                                     NomeProduto = p.NomeProduto
                                                 }
                    ).OrderBy(x => x.Codigo).ToList();
            return lista;
        }

        public List<ConversaoUnidadeModelView> getItensConversao(int IdProduto)
        {
            
            List<ConversaoUnidadeModelView> lista = (from c in db.ConversaoUnidade
                                                     join d in db.Unidade on c.IdUnidadeDe equals d.IdUnidade into d1
                                                     from d2 in d1.DefaultIfEmpty()
                                                     join p in db.Unidade on c.IdUnidadePara equals p.IdUnidade into p1
                                                     from p2 in p1.DefaultIfEmpty()
                                                     where c.IdProduto == IdProduto
                                                     select new ConversaoUnidadeModelView
                                                     {
                                                         IdConversaoUnidade = c.IdConversaoUnidade,
                                                         IdProduto = c.IdProduto,
                                                         Fator = c.Fator,
                                                         Denominador = c.Denominador,
                                                         Numerador = c.Numerador,
                                                         UnidadeDe = d2.UnidadeMedida,
                                                         UnidadePara = p2.UnidadeMedida
                                                     }).OrderBy(o => o.IdConversaoUnidade).ToList();

            return lista;
        }

        public Produto Exist(string codigo, string nome)
        {
            int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            Produto p = (from pr in db.Produto
                         where (pr.Codigo.Contains(codigo) || pr.NomeProduto.Contains(nome))
                         && pr.IdEmpresa == idEmpresa
                         select pr).FirstOrDefault();
            return p;
        }

        public Produto GetByID(int id)
        {
            return db.Produto.Find(id);
        }

        public Produto GetByCodigoIdFornecedor(string codigo, int CompraIdFornecedor)
        {
            return (from p in db.Produto
                    where p.Codigo == codigo
                    && p.ComprasIdFornecedor == CompraIdFornecedor
                    select p).FirstOrDefault();
        }

        public IEnumerable<ComboItem> GetComboCompras()
        {
            int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));

            List<ComboItem> lista = (from p in db.Produto
                                     where p.CompraProdDescontinuado == false
                                         & p.IdEmpresa == idEmpresa
                                     select new ComboItem
                                     {
                                         iValue = p.IdProduto,
                                         Text = p.Codigo
                                     }).OrderBy(x => x.Text).ToList();

            return lista;
        }

        public List<Produto> getByGrupo(int IdGrupo, string Codigo)
        {
            return (from p in db.Produto
                    where 1 == 1
                    && (IdGrupo == 0 || p.IdGrupoProduto == IdGrupo)
                    && (string.IsNullOrEmpty(Codigo) || p.Codigo.Contains(Codigo)) 
                    select p).OrderBy(x => x.NomeProduto).ToList();
        }

        public List<Produto> getSemGrupo()
        {
            return (from p in db.Produto
                    where p.IdGrupoProduto == null
                    select p).OrderBy(x => x.NomeProduto).ToList();
        }

        public List<Produto> getDuplicados()
        {
            SQLDataLayer odal = new SQLDataLayer();
            List<string> Duplicados = odal.getProdutoDuplicado();
            return (from p in db.Produto
                    where Duplicados.Contains(p.Codigo)
                    select p).OrderBy(x => x.NomeProduto).ToList();
        }

        public DataTable getMulticomboCompras()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("IdProduto");
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Descricao");
            dt.Columns.Add("NomeProduto");
            var lista = (from p in db.Produto
                         where (p.ProdutoAcabadoMateriaPrima == 1 || p.ProdutoAcabadoMateriaPrima == 3)
                         select p).OrderBy(x => x.Codigo).ToList();

            foreach(var p in lista)
            {
                DataRow dr = dt.NewRow();
                dr["IdProduto"] = p.IdProduto;
                dr["Codigo"] = p.Codigo;
                dr["Descricao"] = p.Descricao;
                dr["NomeProduto"] = p.NomeProduto;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public IEnumerable<ComboItem> GetComboProducao()
        {
           
            int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            List<ComboItem> lista = (from ge in db.Produto
                                     where ge.CompraProdDescontinuado == false
                                     & ge.IdTipoProduto == 1
                                     & ge.IdEmpresa == idEmpresa
                                     select new ComboItem
                                     {
                                         iValue = ge.IdProduto,
                                         Text = ge.Codigo
                                     }).OrderBy(x => x.Text).ToList();

            return lista;
        }

        public List<ComboItem> GetComboMateriaPrima()
        {

            int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            List<ComboItem> lista = (from ge in db.Produto
                                     where ge.CompraProdDescontinuado == false 
                                     && ge.IdEmpresa == idEmpresa
                                     && ge.ProdutoAcabadoMateriaPrima == 1 
                                     select new ComboItem
                                     {
                                         iValue = ge.IdProduto,
                                         Text = ge.NomeProduto
                                     }).OrderBy(x => x.Text).ToList();

            return lista;
        }

        public List<MultiComboItem> getProdutosMultiCombo()
        {
            int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            List<MultiComboItem> lista = (from p in db.Produto
                                          where p.IdTipoProduto == 1
                                          & p.IdEmpresa == idEmpresa
                                          select new MultiComboItem
                                                 {
                                                     iValue = p.IdProduto,
                                                     Text1 = p.Codigo,
                                                     Text2 = p.NomeProduto
                                                 }
                    ).OrderBy(x => x.Text1).ToList();
            return lista;
        }

        public IEnumerable<ComboItem> GetTodos()
        {
            int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            List<ComboItem> lista = (from ge in db.Produto
                                     where ge.VendaProdDescontinuado == false
                                     & ge.IdEmpresa == idEmpresa
                                     select new ComboItem
                                     {
                                         iValue = ge.IdProduto,
                                         Text = ge.NomeProduto
                                     }).OrderBy(x => x.Text).ToList();

            return lista;
        }

        public IEnumerable<ComboItem> GetComboVendas()
        {
            int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            List<ComboItem> lista = (from ge in db.Produto
                                     where ge.VendaProdDescontinuado == false
                                     & ge.IdEmpresa == idEmpresa
                                     select new ComboItem
                                     {
                                         iValue = ge.IdProduto,
                                         Text = ge.NomeProduto
                                     }).OrderBy(x => x.Text).ToList();

            return lista;
        }

        public List<Produto> getProdutos(string Codigo, string Nome, string Descricao, int IdGrupoProduto)
        {
            int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            List<Produto> lista = (from p in db.Produto 
                                   where (Codigo == "" || p.Codigo.Contains(Codigo))
                                   & (Nome == "" || p.NomeProduto.Contains(Nome))
                                   & (Descricao == "" || p.Descricao == Descricao)
                                   & (IdGrupoProduto == 0 || p.IdGrupoProduto == IdGrupoProduto)
                                   & p.IdEmpresa == idEmpresa
                                   select p).OrderBy(x => x.NomeProduto).ToList();
            return lista;
        }


        public List<vwPesquisaProduto> PesquisaProdutos(string Codigo, string Descricao, int VariantesGrupo, int Cor, int Estilo, int Tamanho, int Config, int tipodeproduto)
        {
            int Empresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            DB_ERPViewContext dbv = new DB_ERPViewContext();
            var lista = (from p in dbv.vwPesquisaProduto
                         where p.IdEmpresa == Empresa
                         && p.Codigo.Contains(Codigo)
                         && p.Descricao.Contains(Descricao)
                         && (VariantesGrupo == 0 || p.IdVariantesGrupo == VariantesGrupo)
                         && (Cor == 0 || p.IdVariantesCor == Cor)
                         && (Estilo == 0 || p.IdVariantesEstilo == Estilo)
                         && (Tamanho == 0 || p.IdVariantesTamanho == Tamanho)
                         && (Config == 0 || p.IdVariantesConfig == Config)
                         && (tipodeproduto == 0 || p.ProdutoAcabadoMateriaPrima == tipodeproduto)
                         select p).OrderBy(x => x.Codigo).ToList();
            return lista;
        }

        public List<ComboItem> getProdutosAcabados(int IdCor)
        {
            int Empresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            DB_ERPViewContext dbv = new DB_ERPViewContext();
            var lista = (from p in dbv.vwPesquisaProduto
                         where p.IdEmpresa == Empresa
                         && (IdCor == 0 || p.IdVariantesCor == IdCor)
                         && (p.ProdutoAcabadoMateriaPrima == 2)
                         orderby p.NomeProduto
                         select new ComboItem
                         {
                             iValue = p.IdProduto,
                             Text = p.NomeProduto
                         }

                         ).ToList();
            return lista;
        }




        public void Save()
        {
            db.SaveChanges();
        }

        public void Save(string IdUsuarioCorrente)
        {
            db.SaveChanges(IdUsuarioCorrente);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
