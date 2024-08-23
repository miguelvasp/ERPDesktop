using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class TipoPagamentoDAL : Repository<TipoPagamento>
    {
        public List<TipoPagamento> getByParams(string prtCodigo, string prtDescricao)
        {
            List<TipoPagamento> tp = new List<TipoPagamento>();
            tp = (from t in db.TipoPagamento
                  where (prtCodigo == "" || t.Codigo.Contains(prtCodigo)) &&
                  (prtDescricao == "" || t.Descricao.Contains(prtDescricao))
                  select t).OrderBy(o => o.Codigo).ToList();

            return tp;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from t in db.TipoPagamento
                                     select new ComboItem
                                     {
                                         iValue = t.IdTipoPagamento,
                                         Text = t.Codigo + " - " + t.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from t in db.TipoPagamento
                                         select new GenericReport
                                         {
                                             Text1 = t.Codigo,
                                             Text2 = t.Descricao,
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}