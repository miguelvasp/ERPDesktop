using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class UsuarioDAL : IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();
        private GenericRepository<Usuario> uRepository;

        public GenericRepository<Usuario> URepository
        {
            get
            {
                if (this.uRepository == null)
                {
                    this.uRepository = new GenericRepository<Usuario>(db);
                }
                return uRepository;
            }
        }


        public List<MultiComboItem> GetMultiCombo()
        {
            List<MultiComboItem> lista = (from u in db.Usuario
                                          join p in db.Perfil on u.IdPerfil equals p.IdPerfil
                                          select new MultiComboItem
                                          {
                                              iValue = u.IdUsuario,
                                              Text1 = p.Nome,
                                              Text2 = u.NomeCompleto
                                          }).OrderBy(x => x.Text1).ThenBy(x => x.Text2).ToList();
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

       

        public Usuario ConsultaLogin(string Login)
        {
            Usuario usu = db.Usuario.Where(x => x.Login == Login).FirstOrDefault();
            return usu;
        }

        public List<Usuario> getByParams(string prtNome, string prtLogin, string prtEMail)
        {
            List<Usuario> usuario = new List<Usuario>();
            usuario = (from u in db.Usuario
                      where u.NomeCompleto.Contains(prtNome) &&
                      (prtLogin == "" || u.Login.Contains(prtLogin)) &&
                      (prtEMail == "" || u.EMail.Contains(prtEMail)) &&
                      u.Ativo == true
                      select u).OrderBy(o => o.Login).Take(200).ToList();
            return usuario;
        }

        public Usuario Login(string Login, string Senha)
        {
            string cSenha = Util.Util.Criptografar(Senha);
            Usuario usu = db.Usuario.Where(x => x.Login.ToLower() == Login.ToLower() && x.Senha == cSenha && x.Ativo == true).FirstOrDefault();
            return usu;
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
