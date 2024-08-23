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
    public class EnderecoDAL : IRepository<Endereco>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public EnderecoDAL(DB_ERPContext context)
        {
            this.db = context;
        }

        public IEnumerable<Endereco> Get()
        {
            var endereco = db.Endereco.ToList();
            return endereco.ToList();
        }

        public Endereco GetByID(int id)
        {
            return db.Endereco.Find(id);
        }

        public void Insert(Endereco entidade)
        {
            db.Endereco.Add(entidade);
        }

        public void Delete(int id)
        {
            Endereco endereco = db.Endereco.Find(id);
            db.Endereco.Remove(endereco);
        }

        public void Update(Endereco entidade)
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

        public List<ClienteEndereco> getCliente(int IdCliente)
        {
            List<ClienteEndereco> lista = (from c in db.ClienteEndereco
                                                  where c.IdCliente == IdCliente
                                                  select c).ToList();
            return lista;

        }

        public List<ContadorEndereco> getContador(int IdContador)
        {
            List<ContadorEndereco> lista = (from c in db.ContadorEndereco
                                            where c.IdContador == IdContador
                                           select c).ToList();
            return lista;

        }

        public List<FornecedorEndereco> getFornecedor(int IdFornecedor)
        {
            List<FornecedorEndereco> lista = (from f in db.FornecedorEndereco
                                           where f.IdFornecedor == IdFornecedor
                                           select f).ToList();
            return lista;
        }

        public List<FuncionarioEndereco> getFuncionario(int IdFuncionario)
        {
            List<FuncionarioEndereco> lista = (from f in db.FuncionarioEndereco
                                               where f.IdFuncionario == IdFuncionario
                                              select f).ToList();
            return lista;
        }

        public List<TransportadoraEndereco> getTranporte(int IdTransportadora)
        {
            List<TransportadoraEndereco> lista = (from t in db.TransportadoraEndereco
                                                  where t.IdTransportadora == IdTransportadora
                                                  select t).ToList();
            return lista;

        }

        public List<ContatoEndereco> getContato(int Id)
        {
            List<ContatoEndereco> lista = (from t in db.ContatoEndereco
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
