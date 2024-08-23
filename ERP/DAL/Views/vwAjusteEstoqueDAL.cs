using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class vwAjusteEstoqueDAL
    {
        private DB_ERPViewContext db = new DB_ERPViewContext();

        public vwAjusteEstoqueDAL()
        { 
        }

        public List<vwAjusteEstoque> getByParams(DateTime DataInicial, DateTime DataFinal)
        {
            int IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            DateTime DI = Convert.ToDateTime(DataInicial.ToShortDateString() + " 00:00:00");
            DateTime DF = Convert.ToDateTime(DataFinal.ToShortDateString() + " 23:59:00");
            List<vwAjusteEstoque> lista = (from a in db.vwAjusteEstoque
                                           where (a.Data >= DI && a.Data < DF)
                                           && a.IdEmpresa == IdEmpresa
                                           select a).ToList();
            return lista;
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
