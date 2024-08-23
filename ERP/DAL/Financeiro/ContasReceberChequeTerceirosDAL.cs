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
    public class ContasReceberChequeTerceirosDAL : Repository<ContasReceberChequeTerceiros>
    {
        public void ApagaChequesPorBaixa(int IdContasReceberBaixa)
        {
            var lista = (from c in db.ContasReceberChequeTerceiros
                         where c.IdContasReceberBaixa == IdContasReceberBaixa
                         select c).ToList();
            foreach (var c in lista)
            {
                Delete((int)c.IdContasReceberChequeTerceiro);
                Save();
            }
        }
    }
}
