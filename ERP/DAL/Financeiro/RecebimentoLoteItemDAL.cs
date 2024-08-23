using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class RecebimentoLoteItemDAL : Repository<RecebimentoLoteItem>
    {
        public List<RecebimentoLoteItem> GetByRecebimentoLoteId(int IdRecebimentoLote)
        {
            return (from i in db.RecebimentoLoteItem
                    where i.IdRecebimentoLote == IdRecebimentoLote
                    select i).ToList();
        }
    }
}
