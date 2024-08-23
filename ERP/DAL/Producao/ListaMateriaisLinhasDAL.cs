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
    public class ListaMateriaisLinhasDAL : Repository<ListaMateriaisLinhas>
    {
        public List<ListaMateriaisLinhasModelView> GetLinhasByItem(int Id)
        {
            List<ListaMateriaisLinhasModelView> lista = (from c in db.ListaMateriaisLinhas
                                                         join p in db.Produto on c.IdProduto equals p.IdProduto
                                                         where c.IdListaMateriaisItem == Id
                                                         select new ListaMateriaisLinhasModelView()
                                                         {
                                                             IdListaMateriaisLinhas = c.IdListaMateriaisLinhas,
                                                             Codigo = p.Codigo,
                                                             Nome = p.NomeProduto,
                                                             Quantidade = c.Quantidade
                                                         }).OrderBy(x => x.Codigo).ToList();
            return lista;
        }
    }
}
