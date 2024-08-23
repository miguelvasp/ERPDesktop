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
    public class SegmentoDAL : Repository<Segmento>
    {
        public List<Segmento> getByParams(string prtNome, string prtDescricao)
        {
            List<Segmento> aut = new List<Segmento>();
            aut = (from a in db.Segmento
                   where (prtNome == "" || a.Nome.Contains(prtNome)) &&
                   (prtDescricao == "" || a.Descricao.Contains(prtDescricao))
                   select a).OrderBy(o => o.Nome).ToList();

            return aut;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.Segmento
                                     select new ComboItem
                                     {
                                         iValue = c.IdSegmento,
                                         Text = c.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
