using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class FornecedorCentroCustoDAL : Repository<FornecedorCentroCusto>
    {
        public List<int?> GetValoresCadastrados(int idFornecedor)
        {
            List<int?> lista = (from v in db.FornecedorCentroCusto
                               where v.IdFornecedor == idFornecedor
                               select v.IdValoresCentroCusto).ToList();
            return lista;           
        }

        public List<CentroCustoValoresModelView> GetByFornecedor(int Id)
        {
            List<CentroCustoValoresModelView> lista = (from c in db.CentroCusto
                                                       join v in db.ValoresCentroCusto on c.IdCentroCusto equals v.IdCentroCusto
                                                       join cf in db.FornecedorCentroCusto on v.IdValoresCentroCusto equals cf.IdValoresCentroCusto
                                                       where cf.IdFornecedor == Id
                                                       select new CentroCustoValoresModelView
                                                       {
                                                           Id = cf.IdFornecedorCentroCusto,
                                                           CentroCusto = c.Descricao,
                                                           Nome = v.Nome
                                                       }).OrderBy(x => x.CentroCusto).ToList();
            return lista;
        }
    }
}
