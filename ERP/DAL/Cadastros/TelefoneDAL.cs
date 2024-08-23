using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class TelefoneDAL : IRepository<Telefone>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public TelefoneDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<Telefone> Get()
        {
            var t = db.Telefone.ToList();
            return t.ToList();
        }

        public Telefone GetByID(int id)
        {
            return db.Telefone.Find(id);
        }

        public void Insert(Telefone entidade)
        {
            db.Telefone.Add(entidade);
        }

        public void Delete(int id)
        {
            Telefone t = db.Telefone.Find(id);
            db.Telefone.Remove(t);
        }

        public void Update(Telefone entidade)
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

        public List<ClienteTelefone> getCliente(int IdCliente)
        {
            List<ClienteTelefone> lista = (from c in db.ClienteTelefone
                                                  where c.IdCliente == IdCliente
                                                  select c).ToList();
            return lista;
        }

        public List<ContadorTelefone> getContador(int IdContador)
        {
            List<ContadorTelefone> lista = (from c in db.ContadorTelefone
                                           where c.IdContador == IdContador
                                           select c).ToList();
            return lista;
        }

        public List<FornecedorTelefone> getFornecedor(int IdFornecedor)
        {
            List<FornecedorTelefone> lista = (from f in db.FornecedorTelefone
                                              where f.IdFornecedor == IdFornecedor
                                           select f).ToList();
            return lista;
        }

        public List<FuncionarioTelefone> getFuncionario(int IdFuncionario)
        {
            List<FuncionarioTelefone> lista = (from f in db.FuncionarioTelefone
                                               where f.IdFuncionario == IdFuncionario
                                              select f).ToList();
            return lista;
        }

        public List<TransportadoraTelefone> getTranporte(int IdTransportadora)
        {
            List<TransportadoraTelefone> lista = (from t in db.TransportadoraTelefone
                                                 where t.IdTransportadora == IdTransportadora
                                                  select t).ToList();
            return lista;
        }

        public List<ContatoTelefone> getContato(int Id)
        {
            List<ContatoTelefone> lista = (from t in db.ContatoTelefone
                                                  where t.IdContato == Id
                                                  select t).ToList();
            return lista;

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