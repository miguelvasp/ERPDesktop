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
    public class ListaMateriaisItemDAL : Repository<ListaMateriaisItem>
    {
        public List<ListaMateriaisItemModelView> GetByLista(int Id)
        {
            List<ListaMateriaisItemModelView> lista = (from li in db.ListaMateriaisItem
                                                       join p in db.Produto on li.IdProduto equals p.IdProduto
                                                       where li.IdListaMateriais == Id

                                                       from c in db.VariantesConfig
                                                       .Where(x => x.IdVariantesConfig == li.IdConfiguracao)
                                                       .DefaultIfEmpty()

                                                       from e in db.VariantesEstilo
                                                       .Where(x => x.IdVariantesEstilo == li.IdEstilo)
                                                       .DefaultIfEmpty()

                                                       from cr in db.VariantesCor
                                                       .Where(x => x.IdVariantesCor == li.IdCor)
                                                       .DefaultIfEmpty()

                                                       from t in db.VariantesTamanho
                                                       .Where(x => x.IdVariantesTamanho == li.IdTamanho)
                                                       .DefaultIfEmpty()

                                                       select new ListaMateriaisItemModelView
                                                       {
                                                           IdListaMateriaisItem = li.IdListaMateriaisItem,
                                                           Produto = p.NomeProduto,
                                                           Config = c.Descricao,
                                                           Estilo = e.Descricao,
                                                           Cor = cr.Descricao,
                                                           Tamanho = t.Descricao,
                                                           De = li.De,
                                                           Ate = li.Ate
                                                       }).OrderBy(x => x.Produto).ToList();
            return lista;
        }
    }
}
