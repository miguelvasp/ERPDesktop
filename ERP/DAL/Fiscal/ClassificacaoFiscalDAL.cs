using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ERP.DAL
{
    public class ClassificacaoFiscalDAL : IRepository<ClassificacaoFiscal>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public ClassificacaoFiscalDAL()
        {
        }

        public IEnumerable<ClassificacaoFiscal> Get()
        {
            var cf = db.ClassificacaoFiscal.OrderBy(x => x.NCM).ToList();
            return cf;
        }

        public ClassificacaoFiscal GetByID(int id)
        {
            return db.ClassificacaoFiscal.Find(id);
        }
        

        public List<ClassificacaoFiscal> getByParams(string prtNCM, string prtDescricao)
        {
            List<ClassificacaoFiscal> cf = new List<ClassificacaoFiscal>();
            cf = (from c in db.ClassificacaoFiscal
                  where (prtNCM == "" || c.NCM.Contains(prtNCM)) &&
                   (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                  select c).OrderBy(o => o.NCM).ToList();

            return cf;
        }

        public ClassificacaoFiscal getByNCM(string prtNCM)
        { 
            return (from c in db.ClassificacaoFiscal
                  where  c.NCM == prtNCM
                  select c).FirstOrDefault();
 
        }


        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.ClassificacaoFiscal
                                     select new ComboItem()
                                     {
                                         Text = c.NCM + " - " + c.Descricao.Substring(0, 20) + "...",
                                         iValue = c.IdNCM
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }


        public void Insert(ClassificacaoFiscal entidade)
        {
            db.ClassificacaoFiscal.Add(entidade);
        }

        public void Delete(int id)
        {
            ClassificacaoFiscal cf = db.ClassificacaoFiscal.Find(id);
            db.ClassificacaoFiscal.Remove(cf);
        }

        public void Update(ClassificacaoFiscal entidade)
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
