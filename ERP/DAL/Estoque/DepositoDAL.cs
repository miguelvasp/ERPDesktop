using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class DepositoDAL : Repository<Deposito>
    {
        public List<Deposito> getByParams(string prtNome, string prtDescricao)
        {
            List<Deposito> dp = new List<Deposito>();
            dp = (from m in db.Deposito
                      where m.Nome.Contains(prtNome) &&
                      (prtDescricao == "" || m.Descricao.Contains(prtDescricao))
                      select m).OrderBy(o => o.Nome).ToList();

            return dp;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from ac in db.Deposito
                                     select new ComboItem
                                     {
                                         iValue = ac.IdDeposito,
                                         Text = ac.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from d in db.Deposito
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