using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class OperacaoDAL : Repository<Operacao>
    {
        public List<Operacao> getByParams(string prtCodigo, string prtDescricao)
        {
            List<Operacao> op = new List<Operacao>();
            op = (from p in db.Operacao
                  where (prtCodigo == "" || p.Codigo.Contains(prtCodigo)) &&
                  (prtDescricao == "" || p.Descricao.Contains(prtDescricao))
                  select p).OrderBy(o => o.Codigo).ToList();

            return op;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from o in db.Operacao
                                     select new ComboItem
                                     {
                                         iValue = o.IdOperacao,
                                         Text = o.Codigo + " - " + o.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
