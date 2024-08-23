using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class ModuloProgramaDAL
    {

        DB_ERPContext db = new DB_ERPContext();

        private GenericRepository<Modulo> mRepository;
        private GenericRepository<Programa> pRepository;
        private GenericRepository<ModuloPrograma> mpRepository;
        private GenericRepository<Permissao> puRepository;

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

        public GenericRepository<Programa> PRepository
        {
            get
            {

                if (this.pRepository == null)
                {
                    this.pRepository = new GenericRepository<Programa>(db);
                }
                return pRepository;
            }
        }

        public GenericRepository<ModuloPrograma> MPRepository
        {
            get
            {

                if (this.mpRepository == null)
                {
                    this.mpRepository = new GenericRepository<ModuloPrograma>(db);
                }
                return mpRepository;
            }
        }

        public GenericRepository<Permissao> PURepository
        {
            get
            {

                if (this.puRepository == null)
                {
                    this.puRepository = new GenericRepository<Permissao>(db);
                }
                return puRepository;
            }
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
