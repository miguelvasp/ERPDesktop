using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ERP.DAL
{
    public class CodigoProdutoExternoDAL : IRepository<CodigoProdutoExterno>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public CodigoProdutoExternoDAL()
        {
        }

        public IEnumerable<CodigoProdutoExterno> Get()
        {
            var cpe = db.CodigoProdutoExterno.ToList();
            return cpe.ToList();
        }

        public CodigoProdutoExterno GetByID(int id)
        {
            return db.CodigoProdutoExterno.Find(id);
        }

        public CodigoProdutoExterno ConsultaPorProdutoFornecedor(int pIdFornecedor, int pIdProduto)
        {
            var c = (from ce in db.CodigoProdutoExterno
                     where ce.IdFornecedor == pIdFornecedor
                     && ce.IdProduto == pIdProduto
                     select ce).FirstOrDefault();
            return c;
        }

        public List<CodigoProdutoExterno> getByParams(string prtNumeroExterno, string prtDescricao)
        {
            List<CodigoProdutoExterno> aut = new List<CodigoProdutoExterno>();
            aut = (from c in db.CodigoProdutoExterno
                   where (prtNumeroExterno== "" || c.NumeroExterno.Contains(prtNumeroExterno)) &&
                   (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                   select c).OrderBy(o => o.NumeroExterno).ToList();

            return aut;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.CodigoProdutoExterno
                                     select new ComboItem()
                                     {
                                         Text = c.Descricao,
                                         iValue = c.IdCodigoProdutoExterno
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<ComboItem> GetCombo(int pIdFornecedor, int pIdProduto)
        {
            List<ComboItem> lista = (from c in db.CodigoProdutoExterno
                                     where c.IdFornecedor == pIdFornecedor &&
                                     c.IdProduto == pIdProduto
                                     select new ComboItem()
                                     {
                                         Text = c.Descricao,
                                         iValue = c.IdCodigoProdutoExterno
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(CodigoProdutoExterno entidade)
        {
            db.CodigoProdutoExterno.Add(entidade);
        }

        public void Delete(int id)
        {
            CodigoProdutoExterno cpe = db.CodigoProdutoExterno.Find(id);
            db.CodigoProdutoExterno.Remove(cpe);
        }

        public void Update(CodigoProdutoExterno entidade)
        {
            db.Entry(entidade).State = EntityState.Modified;
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