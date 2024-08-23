using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL.Cadastros
{
    public class ProdutoCentroCustoDAL: Repository<ProdutoCentroCusto>
    {
        public List<int?> GetValoresCadastrados(int idProduto)
        {
            List<int?> lista = (from p in db.ProdutoCentroCusto
                                where p.IdProduto == idProduto
                                select p.IdValoresCentroCusto).ToList();
            return lista;
        }

        public List<CentroCustoValoresModelView> GetByProduto(int Id)
        {
            List<CentroCustoValoresModelView> lista = (from c in db.CentroCusto
                                                       join v in db.ValoresCentroCusto on c.IdCentroCusto equals v.IdCentroCusto
                                                       join p in db.ProdutoCentroCusto on v.IdValoresCentroCusto equals p.IdValoresCentroCusto
                                                       where p.IdProduto == Id
                                                       select new CentroCustoValoresModelView
                                                       {
                                                           Id = p.IdProdutoCentroCusto,
                                                           CentroCusto = c.Descricao,
                                                           Nome = v.Nome
                                                       }).OrderBy(x => x.CentroCusto).ToList();
            return lista;
        }
    }    
}
