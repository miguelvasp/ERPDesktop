using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ERP.ModelView;

namespace ERP.DAL
{
    public class SegmentoBancarioDAL : Repository<SegmentoBancario>
    {
        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.SegmentoBancario
                                     select new ComboItem
                                     {
                                         iValue = c.IdSegmentoBancario,
                                         Text = c.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<SegmentoBancario> getByParams(string prtNome, string prtDescricao)
        {
            List<SegmentoBancario> aut = new List<SegmentoBancario>();
            aut = (from a in db.SegmentoBancario
                   where (prtNome == "" || a.Nome.Contains(prtNome)) &&
                   (prtDescricao == "" || a.Descricao.Contains(prtDescricao))
                   select a).OrderBy(o => o.Nome).ToList();

            return aut;
        }
        
        public List<GenericReport> GetDataReport(List<SegmentoBancario> prtLst)
        {
            List<GenericReport> lista = (from s in prtLst
                                         select new GenericReport
                                           {
                                               Text1 = s.Nome,
                                               Text2 = s.Descricao,
                                               Text3 = s.Obrigatorio == true ? "Sim" : "Não",
                                               Text4 = ""
                                           }).OrderBy(o => o.Text1).ToList();

            return lista;
        }
    }
}
