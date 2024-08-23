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
    public class NotaFiscalNFeDAL : Repository<NotaFiscalNFe>
    {
        public NotaFiscalNFe GetNFeById(int pIdNotaFiscal)
        {
            return (from n in db.NotaFiscalNFe
                    where n.IdNotaFiscal == pIdNotaFiscal
                    select n).FirstOrDefault();
        }
    }
}
