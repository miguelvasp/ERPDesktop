using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ERP.DAL
{
    public class ContadorDAL : IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();
        private GenericRepository<Contador> cRepository;
        private GenericRepository<ContadorEndereco> ceRepository;
        private GenericRepository<ContadorTelefone> ctRepository;

        public GenericRepository<Contador> CRepository
        {
            get
            {
                if (this.cRepository == null)
                {
                    this.cRepository = new GenericRepository<Contador>(db);
                }
                return cRepository;
            }
        }

        public GenericRepository<ContadorEndereco> CERepository
        {
            get
            {
                if (this.ceRepository == null)
                {
                    this.ceRepository = new GenericRepository<ContadorEndereco>(db);
                }
                return ceRepository;
            }
        }

        public GenericRepository<ContadorTelefone> CTRepository
        {
            get
            {
                if (this.ctRepository == null)
                {
                    this.ctRepository = new GenericRepository<ContadorTelefone>(db);
                }
                return ctRepository;
            }
        }

        public List<Contador> getByParams(string prtNome)
        {
            List<Contador> cont = new List<Contador>();
            cont = (from c in db.Contador
                   where (prtNome == "" || c.Nome.Contains(prtNome))
                   select c).OrderBy(o => o.Nome).ToList();

            return cont;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.Contador
                                     select new ComboItem
                                     {
                                         iValue = c.IdContador,
                                         Text = c.Nome + " - " + c.CRC
                                     }).OrderBy(x => x.Text).ToList();
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
