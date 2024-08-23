using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ERP.ModelView;

namespace ERP.DAL
{
    public class DepartamentoDAL : Repository<Departamento>
    {
        public List<Departamento> getByParams(string prtNome, string prtDescricao)
        {
            List<Departamento> dp = new List<Departamento>();
            dp = (from d in db.Departamento
                  where (prtNome == "" || d.Nome.Contains(prtNome)) &&
                  (prtDescricao == "" || d.Descricao.Contains(prtDescricao))
                  select d).OrderBy(o => o.Nome).ToList();

            return dp;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from ac in db.Departamento
                                     select new ComboItem
                                     {
                                         iValue = ac.IdDepartamento,
                                         Text = ac.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
        
        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from d in db.Departamento
                                         select new GenericReport
                                         {
                                             Text1 = d.Nome,
                                             Text2 = d.Descricao,
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}
