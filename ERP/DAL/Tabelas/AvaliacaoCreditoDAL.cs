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
    public class AvaliacaoCreditoDAL : Repository<AvaliacaoCredito>
    {
        public List<AvaliacaoCredito> getByParams(string prtNome)
        {
            List<AvaliacaoCredito> ac = new List<AvaliacaoCredito>();
            ac = (from p in db.AvaliacaoCredito
                  where (prtNome == "" || p.Nome.Contains(prtNome)) 
                  select p).OrderBy(o => o.Nome).ToList();

            return ac;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from ac in db.AvaliacaoCredito
                                     select new ComboItem
                                     {
                                         iValue = ac.IdAvaliacaoCredito,
                                         Text = ac.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from a in db.AvaliacaoCredito
                                         select new GenericReport
                                         {
                                             Text1 = a.IdAvaliacaoCredito.ToString(),
                                             Text2 = a.Nome,
                                             Text3 = a.Valor.ToString(),
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}
