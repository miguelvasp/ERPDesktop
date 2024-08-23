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
    public class NotaFiscalVencimentosDAL : Repository<NotaFiscalVencimentos>
    {
        public List<NotaFiscalVencimentos> GetByNF(int pIdNotaFiscal)
        {
            return (from v in db.NotaFiscalVencimentos
                    where v.IdNotaFiscal == pIdNotaFiscal
                    select v).OrderBy(x => x.Data).ToList();
        }

        public void ApagaVencimentos(int IdNotaFiscal)
        {
            var lista = (from v in db.NotaFiscalVencimentos
                         where v.IdNotaFiscal == IdNotaFiscal
                         select v).ToList();
            foreach(var i in lista)
            {
                this.Delete(i.IdNotaFiscalVencimento);
                this.Save();
            }
        }
    }
}
