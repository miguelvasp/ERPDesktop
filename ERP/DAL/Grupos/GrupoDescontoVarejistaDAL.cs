using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class GrupoDescontoVarejistaDAL : Repository<GrupoDescontoVarejista>
    {
        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.GrupoDescontoVarejista
                                     select new ComboItem()
                                     {
                                         Text = c.Descricao,
                                         iValue = c.IdGrupoDescontoVarejista
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GrupoDescontoVarejista> getByParams(string prtNome, string prtDescricao)
        {
            List<GrupoDescontoVarejista> gpd = new List<GrupoDescontoVarejista>();
            gpd = (from g in db.GrupoDescontoVarejista
                   where (prtNome == "" || g.Nome.Contains(prtNome)) &&
                   (prtDescricao == "" || g.Descricao.Contains(prtDescricao))
                   select g).OrderBy(o => o.Nome).ToList();

            return gpd;
        }
    }
}
