using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class RoyaltiesDAL : Repository<Royalties>
    {
        public override IEnumerable<Royalties> Get()
        {
            var roy = db.Royalties.OrderBy(x => x.Descricao).ToList();
            return roy.ToList();
        }

        public List<Royalties> getByParams(string prtDescricao)
        {
            List<Royalties> roy = new List<Royalties>();
            roy = (from m in db.Royalties
                   where (prtDescricao == "" || m.Descricao.Contains(prtDescricao))
                   select m).OrderBy(o => o.Descricao).ToList();

            return roy;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from ac in db.Royalties
                                     select new ComboItem
                                     {
                                         iValue = ac.IdRoyalties,
                                         Text = ac.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
