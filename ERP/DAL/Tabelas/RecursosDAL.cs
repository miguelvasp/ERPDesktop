using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class RecursosDAL : Repository<Recursos>
    {
        public List<Recursos> getByParams(string Descricao)
        {
            var lista = (from r in db.Recursos
                         where r.Descricao.Contains(Descricao)
                         select r).OrderBy(x => x.Descricao).ToList();
            return lista;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.Recursos
                                     select new ComboItem
                                     {
                                         iValue = c.IdRecurso,
                                         Text = c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
