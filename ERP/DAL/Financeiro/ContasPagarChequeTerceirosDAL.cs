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
    public class ContasPagarChequeTerceirosDAL : Repository<ContasPagarChequeTerceiros>
    {
        public void ApagaChequesPorBaixa(int IdContasPagarBaixa)
        {
            var lista = (from c in db.ContasPagarChequeTerceiros
                         where c.IdContasPagarBaixa == IdContasPagarBaixa
                         select c).ToList();
            foreach(var c in lista)
            {
                Delete((int)c.IdContasPagarChequeTerceiro);
                Save();
            }
        }
    }
}
