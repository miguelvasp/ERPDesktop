using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ERP.ModelView;

namespace ERP.DAL
{
    public class AprovacaoUsuarioDAL : IRepository<AprovacaoUsuario>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public AprovacaoUsuarioDAL()
        {
        }

        public IEnumerable<AprovacaoUsuario> Get()
        {
            var tb = db.AprovacaoUsuario.ToList();
            return tb.ToList();
        }

        public AprovacaoUsuario GetByID(int id)
        {
            return db.AprovacaoUsuario.Find(id);
        }

        public List<AprovacaoUsuarioModelView> GetByNivel(int pNivel)
        {
            List<AprovacaoUsuarioModelView> lista = (from au in db.AprovacaoUsuario
                                                     join u in db.Usuario on au.IdUsuario equals u.IdUsuario
                                                     join p in db.Perfil on u.IdPerfil equals p.IdPerfil
                                                     where au.IdAprovacaoNivel == pNivel
                                                     select new AprovacaoUsuarioModelView
                                                     {
                                                         IdAprovacaoUsuario = au.IdAprovacaoUsuario,
                                                         Nome = p.Nome,
                                                         NomeCompleto = u.NomeCompleto
                                                     }).OrderBy(x => x.Nome).ThenBy(x => x.NomeCompleto).Distinct().ToList();
            return lista;
        }

        public void Insert(AprovacaoUsuario entidade)
        {
            db.AprovacaoUsuario.Add(entidade);
        }

        public void Delete(int id)
        {
            AprovacaoUsuario tb = db.AprovacaoUsuario.Find(id);
            db.AprovacaoUsuario.Remove(tb);
        }

        public void Update(AprovacaoUsuario entidade)
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
