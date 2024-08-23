using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class MoedaDAL : IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();
        private GenericRepository<Moeda> mRepository;
        private GenericRepository<MoedaCotacao> mcRepository;

        public GenericRepository<Moeda> MRepository
        {
            get
            {
                if (this.mRepository == null)
                {
                    this.mRepository = new GenericRepository<Moeda>(db);
                }
                return mRepository;
            }
        }

        public GenericRepository<MoedaCotacao> MCRepository
        {
            get
            {
                if (this.mcRepository == null)
                {
                    this.mcRepository = new GenericRepository<MoedaCotacao>(db);
                }
                return mcRepository;
            }
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.Moeda
                                     select new ComboItem
                                     {
                                         iValue = c.IdMoeda,
                                         Text = c.Codigo + " - " + c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from m in db.Moeda
                                         select new GenericReport
                                         {
                                             Text1 = m.Codigo,
                                             Text2 = m.Descricao,
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

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
