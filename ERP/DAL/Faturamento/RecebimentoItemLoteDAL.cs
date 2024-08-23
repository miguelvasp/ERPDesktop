using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class RecebimentoItemLoteDAL : Repository<RecebimentoItemLote>
    {
        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.RecebimentoItemLote
                                     select new ComboItem()
                                     {
                                         Text = c.LoteFornecedor.ToString(),
                                         iValue = (int)c.IdLote
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<RecebimentoItemLote> GetLotes(int pRecebimentoItemId)
        {
            return (from l in db.RecebimentoItemLote
                    where l.IdRecebimentoItem == pRecebimentoItemId
                    select l).ToList();
        }
    }
}