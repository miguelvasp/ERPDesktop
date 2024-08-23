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
    public class ClienteCentroCustoDAL : Repository<ClienteCentroCusto>
    {
        public List<int?> GetValoresCadastrados(int IdCliente)
        {
            List<int?> lista = (from v in db.ClienteCentroCusto
                                where v.IdCliente == IdCliente
                                select v.IdValoresCentroCusto).ToList();
            return lista;
        }

        public List<CentroCustoValoresModelView> GetByCliente(int Id)
        {
            List<CentroCustoValoresModelView> lista = (from c in db.CentroCusto
                                                       join v in db.ValoresCentroCusto on c.IdCentroCusto equals v.IdCentroCusto
                                                       join cf in db.ClienteCentroCusto on v.IdValoresCentroCusto equals cf.IdValoresCentroCusto
                                                       where cf.IdCliente == Id
                                                       select new CentroCustoValoresModelView
                                                       {
                                                           Id = cf.IdClienteCentroCusto,
                                                           CentroCusto = c.Descricao,
                                                           Nome = v.Nome
                                                       }).OrderBy(x => x.CentroCusto).ToList();
            return lista;
        }
    }
}
