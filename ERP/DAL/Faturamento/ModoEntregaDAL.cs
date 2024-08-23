using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class ModoEntregaDAL : Repository<ModoEntrega>
    {
        public List<ModoEntrega> getByParams(string prtNome, string prtDescricao)
        {
            List<ModoEntrega> me = new List<ModoEntrega>();
            me = (from m in db.ModoEntrega
                  where (prtNome == "" || m.Nome.Contains(prtNome)) &&
                  (prtDescricao == "" || m.Descricao.Contains(prtDescricao))
                  select m).OrderBy(o => o.Nome).ToList();

            return me;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from m in db.ModoEntrega
                                     select new ComboItem
                                     {
                                         iValue = m.IdModoEntrega,
                                         Text = m.Nome
                                     }).OrderBy(o => o.Text).ToList();
            return lista;
        }
    }
}