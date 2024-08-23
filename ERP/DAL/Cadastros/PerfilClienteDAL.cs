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
    public class PerfilClienteDAL: IRepository<PerfilCliente>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public PerfilClienteDAL()
        {
            
        }

        public IEnumerable<PerfilCliente> Get()
        {
            var pc = db.PerfilCliente.ToList();
            return pc.ToList();
        }

        public PerfilCliente GetByID(int id)
        {
            return db.PerfilCliente.Find(id);
        }

        public List<PerfilCliente> getByParams(string prtNome, string prtDescricao)
        {
            List<PerfilCliente> pc = new List<PerfilCliente>();
            pc = (from p in db.PerfilCliente
                  where (prtNome == "" || p.Nome.Contains(prtNome)) &&
                  (prtDescricao == "" || p.Descricao.Contains(prtDescricao))
                  select p).OrderBy(o => o.Nome).ToList();

            return pc;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from pc in db.PerfilCliente
                                     select new ComboItem()
                                     {
                                         Text = pc.Nome,
                                         iValue = pc.IdPerfilCliente
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Insert(PerfilCliente entidade)
        {
            db.PerfilCliente.Add(entidade);
        }

        public void Delete(int id)
        {
            PerfilCliente pc = db.PerfilCliente.Find(id);
            db.PerfilCliente.Remove(pc);
        }

        public void Update(PerfilCliente entidade)
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