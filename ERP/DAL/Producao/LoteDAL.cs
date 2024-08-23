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
    public class LoteDAL : Repository<Lote>
    {
        public int geraLote()
        {
            int ano = DateTime.Now.Year;
            var l = db.Lote.Where(x => x.Ano == ano).Max(x => x.numero);
            var numero = 1;
            if(l != null && l > 0)
            {
                numero = Convert.ToInt32(l) + 1;
            }

            Lote lote = new Lote();
            lote.Ano = ano;
            lote.numero = numero;
            this.Insert(lote);
            this.Save();
            return lote.IdLote;
        }
    }
}
