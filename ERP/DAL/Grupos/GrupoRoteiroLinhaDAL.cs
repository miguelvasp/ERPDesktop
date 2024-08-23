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
    public class GrupoRoteiroLinhaDAL : IRepository<GrupoRoteiroLinha>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public GrupoRoteiroLinhaDAL()
        {
        }

        public IEnumerable<GrupoRoteiroLinha> Get()
        {
            var tb = db.GrupoRoteiroLinha.ToList();
            return tb.ToList();
        }

        public List<GrupoRoteiroLinhasModelView> GetByGrupoId(int id)
        {
            List<GrupoRoteiroLinhasModelView> tb = (from x in db.GrupoRoteiroLinha
                      where x.IdGrupoRoteiro == id
                      select new GrupoRoteiroLinhasModelView
                     {
                         Id = x.IdGrupoRoteiroLinha,
                         Tipo = x.TipoRoteiroTrabalho == null ? "" :
                                x.TipoRoteiroTrabalho == 1 ? "Fila antes" :
                                x.TipoRoteiroTrabalho == 2 ? "Instalação" :
                                x.TipoRoteiroTrabalho == 3 ? "Processar" :
                                x.TipoRoteiroTrabalho == 4 ? "Sobrepor" :
                                x.TipoRoteiroTrabalho == 5 ? "Transporte" :
                                x.TipoRoteiroTrabalho == 6 ? "Fila Depois" :
                                x.TipoRoteiroTrabalho == 7 ? "Custo Indireto" : "",
                         Ativacao = x.Ativacao == true ? "Sim" : "Não",
                         Capacidade = x.Capacidade == true ? "Sim" : "Não",
                         Gerenciamento = x.GerenciamentoTrabalho == true ? "Sim" : "Não",
                         Horario = x.HorarioTrabalho == true ? "Sim" : "Não"
                     }).ToList();
            return tb;
        }

        public GrupoRoteiroLinha GetByID(int id)
        {
            return db.GrupoRoteiroLinha.Find(id);
        }

        public void Insert(GrupoRoteiroLinha entidade)
        {
            db.GrupoRoteiroLinha.Add(entidade);
        }

        public void Delete(int id)
        {
            GrupoRoteiroLinha tb = db.GrupoRoteiroLinha.Find(id);
            db.GrupoRoteiroLinha.Remove(tb);
        }

        public void Update(GrupoRoteiroLinha entidade)
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
