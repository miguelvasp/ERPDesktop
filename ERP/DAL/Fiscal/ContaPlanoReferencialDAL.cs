using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class ContaPlanoReferencialDAL : Repository<ContaPlanoReferencial>
    {
        public List<ContaPlanoReferencial> getByParams(string prtCodigo, string prtDescricao)
        {
            List<ContaPlanoReferencial> cpr = new List<ContaPlanoReferencial>();
            cpr = (from c in db.ContaPlanoReferencial
                   where c.Codigo.Contains(prtCodigo) &&
                       (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                   select c).OrderBy(o => o.Codigo).ToList();

            return cpr;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from cpr in db.ContaPlanoReferencial
                                     select new ComboItem
                                     {
                                         iValue = cpr.IdContaPlanoReferencial,
                                         Text = cpr.Codigo
                                     }).OrderBy(x => x.Text).ToList();



            return lista;
        }

        public List<MultiComboItem> GetMultiCombo()
        {
            List<MultiComboItem> lista = (from cpr in db.ContaPlanoReferencial
                                          select new MultiComboItem
                                     {
                                         iValue = cpr.IdContaPlanoReferencial,
                                         Text1 = cpr.Codigo,
                                         Text2 = cpr.Descricao
                                     }).OrderBy(x => x.Text1).ToList();
            return lista;
        }


        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from c in db.ContaPlanoReferencial
                                         select new GenericReport
                                         {
                                             Text1 = c.Codigo,
                                             Text2 = c.Descricao,
                                             Text3 = c.DataIni.Value.ToShortDateString(),
                                             Text4 = c.DataFim.Value.ToShortDateString()
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}