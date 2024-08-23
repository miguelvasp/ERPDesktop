using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class ContaGerencialDAL : Repository<ContaGerencial>
    {
        public List<ContaGerencial> getByParams(string prtCodigo, string prtDescricao)
        {
            List<ContaGerencial> cg = new List<ContaGerencial>();
            cg = (from c in db.ContaGerencial
                  where c.Codigo.Contains(prtCodigo) &&
                      (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                  select c).OrderBy(o => o.Codigo).ToList();

            return cg;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from cg in db.ContaGerencial
                                     select new ComboItem
                                     {
                                         iValue = cg.IdContaGerencial,
                                         Text = cg.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
        
        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from c in db.ContaGerencial
                                         select new GenericReport
                                         {
                                             Text1 = c.Codigo,
                                             Text2 = c.Descricao,
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}
