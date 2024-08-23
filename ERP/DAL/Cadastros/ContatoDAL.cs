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
    public class ContatoDAL : IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();
        private GenericRepository<Contato> cRepository;
        private GenericRepository<ContatoEndereco> ceRepository;
        private GenericRepository<ContatoTelefone> ctRepository;

        public GenericRepository<Contato> CRepository
        {
            get
            {
                if (this.cRepository == null)
                {
                    this.cRepository = new GenericRepository<Contato>(db);
                }
                return cRepository;
            }
        }

        public GenericRepository<ContatoEndereco> CERepository
        {
            get
            {
                if (this.ceRepository == null)
                {
                    this.ceRepository = new GenericRepository<ContatoEndereco>(db);
                }
                return ceRepository;
            }
        }

        public GenericRepository<ContatoTelefone> CTRepository
        {
            get
            {
                if (this.ctRepository == null)
                {
                    this.ctRepository = new GenericRepository<ContatoTelefone>(db);
                }
                return ctRepository;
            }
        }

        public List<ClienteContato> getCliente(int Id)
        {
            List<ClienteContato> lista = (from c in db.ClienteContato
                                                 where c.IdCliente == Id
                                                 select c).ToList();
            return lista;
        }

        public List<FornecedorContato> getFornecedor(int Id)
        {
            List<FornecedorContato> lista = (from f in db.FornecedorContato
                                          where f.IdFornecedor == Id
                                          select f).ToList();
            return lista;
        }

        public List<TransportadoraContato> getTransporte(int Id)
        {
            List<TransportadoraContato> lista = (from t in db.TransportadoraContato
                                                 where t.IdTransportadora == Id
                                                 select t).ToList();
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
