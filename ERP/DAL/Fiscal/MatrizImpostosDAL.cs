using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class MatrizImpostosDAL : Repository<MatrizImpostos>
    {
        public List<MatrizImpostos> getByParams(string prtDescricao)
        {
            List<MatrizImpostos> mi = new List<MatrizImpostos>();
            mi = (from a in db.MatrizImpostos
                  where (prtDescricao == "" || a.Descricao.Contains(prtDescricao))
                  select a).OrderBy(o => o.Descricao).ToList();

            return mi;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.MatrizImpostos
                                     select new ComboItem
                                     {
                                         iValue = c.IdMatrizImpostos,
                                         Text = c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}