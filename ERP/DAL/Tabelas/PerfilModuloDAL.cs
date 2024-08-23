using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class PerfilModuloDAL
    {
        DB_ERPContext db = new DB_ERPContext();

        private GenericRepository<Perfil> pRepository;
        private GenericRepository<Modulo> mRepository;
        private GenericRepository<PerfilModulo> pmRepository;

        public GenericRepository<Perfil> PRepository
        {
            get
            {

                if (this.pRepository == null)
                {
                    this.pRepository = new GenericRepository<Perfil>(db);
                }
                return pRepository;
            }
        }

        public GenericRepository<Modulo> MRepository
        {
            get
            {

                if (this.mRepository == null)
                {
                    this.mRepository = new GenericRepository<Modulo>(db);
                }
                return mRepository;
            }
        }

        public GenericRepository<PerfilModulo> PMRepository
        {
            get
            {

                if (this.pmRepository == null)
                {
                    this.pmRepository = new GenericRepository<PerfilModulo>(db);
                }
                return pmRepository;
            }
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
