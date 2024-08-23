using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class CodigoIsencaoDAL : Repository<CodigoIsencao>
    {
        public List<CodigoIsencao> getByParams(string prtCodigo, string prtDescricao)
        {
            List<CodigoIsencao> ci = new List<CodigoIsencao>();
            ci = (from c in db.CodigoIsencao
                  where c.Codigo.Contains(prtCodigo) &&
                      (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                  select c).OrderBy(o => o.Codigo).ToList();

            return ci;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.CodigoIsencao
                                     select new ComboItem()
                                     {
                                         Text = c.Descricao,
                                         iValue = c.IdCodigoIsencao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from c in db.CodigoIsencao
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