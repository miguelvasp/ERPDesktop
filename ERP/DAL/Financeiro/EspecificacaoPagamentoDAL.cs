using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ERP.ModelView;

namespace ERP.DAL
{
    public class EspecificacaoPagamentoDAL : IRepository<EspecificacaoPagamento>, IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();

        public EspecificacaoPagamentoDAL()
        {

        }

        public IEnumerable<EspecificacaoPagamento> Get()
        {
            var ep = db.EspecificacaoPagamento.ToList();
            return ep.ToList();
        }

        public EspecificacaoPagamento GetByID(int id)
        {
            return db.EspecificacaoPagamento.Find(id);
        }

        public List<EspecificacaoPagamento> getByParams(string prtNome)
        {
            List<EspecificacaoPagamento> ep = new List<EspecificacaoPagamento>();
            ep = (from p in db.EspecificacaoPagamento
                  where prtNome == "" || p.Nome.Contains(prtNome)
                    select p).OrderBy(o => o.Nome).ToList();

            return ep;
        }

        public List<EspecificacaoModelView> GetByMetodoPagamentoId(int id)
        {
            List<EspecificacaoModelView> lista = (from e in db.EspecificacaoPagamento
                                                  where e.IdMetodoPagamento == id

                                                  from tp in db.TipoPagamento
                                                  .Where(x => x.IdTipoPagamento == e.IdTipoPagamento)
                                                  .DefaultIfEmpty()

                                                  from fp in db.FormaPagamento
                                                  .Where(x => x.IdFormaPagamento == e.IdFormaPagamento)
                                                  .DefaultIfEmpty()

                                                  from s in db.SegmentoBancario
                                                  .Where(x => x.IdSegmentoBancario == e.IdSegmentoBancario)
                                                  .DefaultIfEmpty()
                                                  select new EspecificacaoModelView
                                                  {
                                                      IdEspecificacaoPagamento = e.IdEspecificacaoPagamento,
                                                      Nome = e.Nome,
                                                      ControleExportacao = e.ControleExportacao == 0 ? "" :
                                                                           e.ControleExportacao == 1 ? "Conta Bancária Fornecedor" : "Código de Barras",
                                                      TipoPagamento = tp.Descricao,
                                                      FormaPagamento = fp.Descricao,
                                                      Segmento = s.Nome
                                                  }).Distinct().OrderBy(x => x.Nome).ToList();
            return lista;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from pp in db.EspecificacaoPagamento
                                     select new ComboItem
                                     {
                                         iValue = pp.IdEspecificacaoPagamento,
                                         Text = pp.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }



        public void Insert(EspecificacaoPagamento entidade)
        {
            db.EspecificacaoPagamento.Add(entidade);
        }

        public void Delete(int id)
        {
            EspecificacaoPagamento ep = db.EspecificacaoPagamento.Find(id);
            db.EspecificacaoPagamento.Remove(ep);
        }

        public void Update(EspecificacaoPagamento entidade)
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
