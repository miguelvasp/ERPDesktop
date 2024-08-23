using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class ArmazemDAL : Repository<Armazem>
    {
        public override IEnumerable<Armazem> Get()
        {
            var am = db.Armazem.OrderBy(x => x.Nome).ToList();
            return am.ToList();
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from a in db.Armazem
                                         select new GenericReport
                                         {
                                             Text1 = a.Nome,
                                             Text2 = a.Descricao,
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }

        public List<Armazem> getByParams(string prtNome, string prtDescricao)
        {
            List<Armazem> am = new List<Armazem>();
            am = (from m in db.Armazem
                  where m.Nome.Contains(prtNome) &&
                  (prtDescricao == "" || m.Descricao.Contains(prtDescricao))
                  select m).OrderBy(o => o.Nome).ToList();

            return am;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from am in db.Armazem
                                     select new ComboItem
                                     {
                                         iValue = am.IdArmazem,
                                         Text = am.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
