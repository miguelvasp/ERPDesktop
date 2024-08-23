using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class PerfilDAL : IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();
        private GenericRepository<Perfil> pRepository;
        private GenericRepository<Permissao> peRepository;

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

        public GenericRepository<Permissao> PERepository
        {
            get
            {
                if (this.peRepository == null)
                {
                    this.peRepository = new GenericRepository<Permissao>(db);
                }
                return peRepository;
            }
        }

        public List<Perfil> getByParams(string prtNome, string prtDescricao)
        {
            List<Perfil> perfil = new List<Perfil>();
            perfil = (from p in db.Perfil
                       where p.Nome.Contains(prtNome) &&
                       (prtDescricao == "" || p.Descricao.Contains(prtDescricao)) &&
                       p.Ativo == true
                       select p).OrderBy(o => o.Nome).Take(200).ToList();

            return perfil;
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
