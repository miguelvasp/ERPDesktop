using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ERP.DAL
{
    public class PedidoCompraAprovacaoDAL : IRepository<PedidoCompraAprovacao>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public PedidoCompraAprovacaoDAL()
        {
        }

        public IEnumerable<PedidoCompraAprovacao> Get()
        {
            var tb = db.PedidoCompraAprovacao.ToList();
            return tb.ToList();
        }

        public PedidoCompraAprovacao GetByID(int id)
        {
            return db.PedidoCompraAprovacao.Find(id);
        }

        public List<PedidoCompraAprovacao> GetByIdPedido(int IdPedido)
        {
            var lista = (from p in db.PedidoCompraAprovacao
                         where p.IdPedidoCompra == IdPedido
                         select p).OrderBy(x => x.Data).ToList();
            return lista;
        }

        public void Insert(PedidoCompraAprovacao entidade)
        {
            db.PedidoCompraAprovacao.Add(entidade);
        }

        public void Delete(int id)
        {
            PedidoCompraAprovacao tb = db.PedidoCompraAprovacao.Find(id);
            db.PedidoCompraAprovacao.Remove(tb);
        }

        public void Update(PedidoCompraAprovacao entidade)
        {
            db.Entry(entidade).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
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
