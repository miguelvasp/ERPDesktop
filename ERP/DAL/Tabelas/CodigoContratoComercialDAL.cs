using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class CodigoContratoComercialDAL : Repository<CodigoContratoComercial>
    {
        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.CodigoContratoComercial
                                     select new ComboItem
                                     {
                                         Value = c.IdCodigoContratoComercial.ToString(),
                                         iValue = c.IdCodigoContratoComercial,
                                         Text = c.Codigo + " - " + c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from c in db.CodigoContratoComercial
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
