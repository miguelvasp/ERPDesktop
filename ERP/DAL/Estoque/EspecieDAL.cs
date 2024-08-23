using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class EspecieDAL : Repository<Especie>
    {
        public override IEnumerable<Especie> Get()
        {
            var esp = db.Especie.OrderBy(x => x.Nome).ToList();
            return esp.ToList();
        }

        public List<Especie> getByParams(string prtNome, string prtDescricao)
        {
            List<Especie> esp = new List<Especie>();
            esp = (from e in db.Especie
                   where (prtNome == "" || e.Nome.Contains(prtNome)) &&
                         (prtDescricao == "" || e.Descricao.Contains(prtDescricao))
                   select e).OrderBy(o => o.Nome).ToList();

            return esp;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from esp in db.Especie
                                     select new ComboItem
                                     {
                                         iValue = esp.IdEspecie,
                                         Text = esp.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from e in db.Especie
                                         select new GenericReport
                                         {
                                             Text1 = e.Nome,
                                             Text2 = e.Descricao,
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}