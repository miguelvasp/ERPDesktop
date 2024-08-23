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
    public class TempoTrabalhoDAL : Repository<TempoTrabalho>
    {
        public List<TempoTrabalho> getByParams(string prtDescricao)
        {
            List<TempoTrabalho> tt = new List<TempoTrabalho>();
            tt = (from t in db.TempoTrabalho
                   where (prtDescricao == "" || t.Descricao.Contains(prtDescricao))
                   select t).OrderBy(o => o.Descricao).ToList();

            return tt;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.TempoTrabalho
                                     select new ComboItem
                                     {
                                         iValue = c.IdTempoTrabalho,
                                         Text = c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
