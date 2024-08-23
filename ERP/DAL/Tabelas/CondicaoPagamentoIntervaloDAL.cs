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
    public class CondicaoPagamentoIntervaloDAL : Repository<CondicaoPagamentoIntervalo>
    {
        public List<CondicaoPagamentoIntervalo> GetByCondicaoPagamentoId(int id)
        {
            return db.CondicaoPagamentoIntervalo.Where(x => x.IdCondicaoPagamento == id).ToList();
        }

        public void ApagaIntervalos(int id)
        {
            var lista = db.CondicaoPagamentoIntervalo.Where(x => x.IdCondicaoPagamento == id).ToList();
            foreach(CondicaoPagamentoIntervalo c in lista)
            {
                db.CondicaoPagamentoIntervalo.Remove(c);
                db.SaveChanges();
            }
        }
    }
}
