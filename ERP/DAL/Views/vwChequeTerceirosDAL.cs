using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class vwChequeTerceirosDAL
    {
        private DB_ERPViewContext db = new DB_ERPViewContext();

        public vwChequeTerceirosDAL()
        { 
        }

        public List<vwChequeTerceiros> GetListaChequeTerceiros(string TipoMovimento, string Razao, string Nome, string Banco, string Cheque, string Status)
        {
            List<vwChequeTerceiros> lista = (from v in db.vwChequeTerceiros
                                             where (TipoMovimento == "" || v.Origem == TipoMovimento)
                                             && (v.RazaoSocial.Contains(Razao))
                                             && (v.Nome.Contains(Nome))
                                             && (Banco == "" || v.NomeBanco == Banco)
                                             && (Cheque == "" || v.NumeroCheque == Cheque)
                                             && (Status == "" || v.Status == Status)
                                             select v).ToList();
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