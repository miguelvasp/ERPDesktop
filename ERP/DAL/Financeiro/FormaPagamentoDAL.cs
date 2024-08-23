using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class FormaPagamentoDAL : Repository<FormaPagamento>
    {
        public List<FormaPagamento> getByParams(string prtCodigo, string prtDescricao)
        {
            List<FormaPagamento> fp = new List<FormaPagamento>();
            fp = (from f in db.FormaPagamento
                  where (prtCodigo == "" || f.Codigo.Contains(prtCodigo)) &&
                  (prtDescricao == "" || f.Descricao.Contains(prtDescricao))
                  select f).OrderBy(o => o.Codigo).ToList();

            return fp;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from f in db.FormaPagamento
                                     select new ComboItem
                                     {
                                         iValue = f.IdFormaPagamento,
                                         Text = f.Codigo + " - " + f.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }


        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from f in db.FormaPagamento
                                         select new GenericReport
                                         {
                                             Text1 = f.Codigo,
                                             Text2 = f.Descricao,
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}