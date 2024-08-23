using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class TextoPadraoDAL : Repository<TextoPadrao>
    {
        public List<TextoPadrao> getByParams(string prtCodigo, string prtDescricao)
        {
            List<TextoPadrao> tp = new List<TextoPadrao>();
            tp = (from t in db.TextoPadrao
                  where (prtCodigo == "" || t.Codigo.Contains(prtCodigo)) &&
                   (prtDescricao == "" || t.Descricao.Contains(prtDescricao))
                  select t).OrderBy(o => o.Codigo).ToList();

            return tp;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.TextoPadrao
                                     select new ComboItem()
                                     {
                                         Text = c.Codigo + " - " + c.Descricao,
                                         iValue = c.IdTextoPadrao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
