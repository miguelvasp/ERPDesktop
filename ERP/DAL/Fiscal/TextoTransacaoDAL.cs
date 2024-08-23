using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ERP.Models;

namespace ERP.DAL
{
    public class TextoTransacaoDAL : Repository<TextoTransacao>
    {
        public List<TextoTransacaoSubs> GetTextoTransacaoSubs()
        { 
            return (from s in db.TextoTransacaoSubs orderby s.Simbolo select s).ToList();
        }

        public string GetTextoTransacao(int IdOrigemLancamento)
        {
            return (from t in db.TextoTransacao
                    where t.IdOrigemLancamento == IdOrigemLancamento
                    select t.Texto).FirstOrDefault();
        }

        public List<ComboItem> GetComboOrigemLancamento()
        {
            var lista = (from o in db.OrigemLancamento
                         orderby o.Descricao
                         select new ComboItem
                         {
                             iValue = o.IdOrigemLancamento,
                             Text = o.Descricao
                         }).ToList();
            return lista;
        }
    }
}
