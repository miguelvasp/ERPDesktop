using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class PermissaoDAL
    {
        DB_ERPContext db = new DB_ERPContext();

        private GenericRepository<Usuario> uRepository;
        private GenericRepository<Perfil> pfRepository;
        private GenericRepository<ModuloDAL> mRepository;
        private GenericRepository<Programa> pRepository;
        private GenericRepository<Permissao> puRepository;

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

        public GenericRepository<Perfil> PFRepository
        {
            get
            {

                if (this.pfRepository == null)
                {
                    this.pfRepository = new GenericRepository<Perfil>(db);
                }
                return pfRepository;
            }
        }

        public GenericRepository<ModuloDAL> MRepository
        {
            get
            {

                if (this.mRepository == null)
                {
                    this.mRepository = new GenericRepository<ModuloDAL>(db);
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

        public Permissao GetUsuarioAcessoFormulario(string NomeFormulario, int idUsuario)
        {
            var permissao = (from p in db.Permissao
                             select p).Where(w => w.Programa.Formulario.ToLower() == NomeFormulario.ToLower() && w.IdUsuario.Equals(idUsuario)).FirstOrDefault();

            return permissao;
        }

        public List<UsuarioPermissao> GetListUsuarioAcesso(int idUsuario)
        {
            var aux = (from u in db.Usuario
                       join pf in db.Perfil on u.IdPerfil equals pf.IdPerfil
                       join pfm in db.PerfilModulo on pf.IdPerfil equals pfm.IdPerfil
                       join m in db.Modulo on pfm.IdModulo equals m.IdModulo
                       join mp in db.ModuloPrograma on m.IdModulo equals mp.IdModulo
                       join p in db.Programa on mp.IdPrograma equals p.IdPrograma

                       select new
                       {
                           IdUsuario = u.IdUsuario,
                           NomeUsuario = u.NomeCompleto,
                           IdPerfil = pf.IdPerfil,
                           DescricaoPerfil = pf.Nome,
                           IdModulo = m.IdModulo,
                           DescricaoModulo = m.Nome,
                           IdPrograma = p.IdPrograma,
                           DescricaoPrograma = p.Nome,
                           PermiteManutencao = p.Manutencao
                       }).Where(w => w.IdUsuario.Equals(idUsuario)).OrderBy(o => o.DescricaoModulo).ThenBy(t => t.DescricaoPrograma).ToList();

            List<UsuarioPermissao> lista = new List<UsuarioPermissao>();
            foreach (var i in aux)
            {
                var existePrograma = lista.Where(w => w.IdPrograma == i.IdPrograma).FirstOrDefault();
                if (existePrograma == null)
                {
                    UsuarioPermissao uavm = new UsuarioPermissao();
                    uavm.IdUsuario = i.IdUsuario;
                    uavm.NomeUsuario = i.NomeUsuario;
                    uavm.IdPerfil = i.IdPerfil;
                    uavm.DescricaoPerfil = i.DescricaoPerfil;
                    uavm.IdPrograma = i.IdPrograma;
                    uavm.DescricaoPrograma = i.DescricaoPrograma;
                    uavm.PermiteManutencao = i.PermiteManutencao;

                    lista.Add(uavm);
                }
            }

            // Pesquisar os acesso do usuário //
            var uPermissao = (from ua in db.Permissao
                           where ua.IdUsuario == idUsuario
                           select ua).ToList();

            if (uPermissao != null && uPermissao.Count > 0)
            {
                foreach (var i in lista)
                {
                    foreach (var item in uPermissao)
                    {
                        if (i.IdPerfil == item.IdPerfil && i.IdPrograma == item.IdPrograma)
                        {
                            i.IdPermissao = item.IdPermissao;
                            i.Visual = item.Visualizar;
                            i.Incluir = item.Incluir;
                            i.Excluir = item.Excluir;
                            i.Alterar = item.Alterar;

                            break;
                        }
                    }
                }
            }

            return lista;
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
