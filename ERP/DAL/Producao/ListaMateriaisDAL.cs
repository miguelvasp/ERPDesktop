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
    public class ListaMateriaisDAL : Repository<ListaMateriais>
    {
        public List<ListaMateriaisModelView> GetByParams(string Nome, int Tipo, int Armazem, int Produto, int Empresa)
        {
            List<ListaMateriaisModelView> lista = (from l in db.ListaMateriais  
                                                   where l.IdEmpresa == Empresa &
                                                   (Nome == "" || l.Nome.Contains(Nome)) &
                                                   (Tipo == 0 || l.Bom_Formula == Tipo)  
                                                   

                                                   from a in db.Armazem
                                                   .Where(x => x.IdArmazem == l.IdArmazem & (Armazem == 0 || l.IdArmazem == Armazem))
                                                   .DefaultIfEmpty()

                                                   from gl in db.GrupoLancamento
                                                   .Where(x => x.IdGrupoLancamento == l.IdGrupoLancamento)
                                                   .DefaultIfEmpty()

                                                   from li in db.ListaMateriaisItem
                                                   .Where(x => x.IdListaMateriais == l.IdListaMateriais & (Produto == 0 || x.IdProduto == Produto))
                                                   .DefaultIfEmpty()

                                                   select new ListaMateriaisModelView
                                                   {
                                                       IdListaMateriais = l.IdListaMateriais,
                                                       Nome = l.Nome,
                                                       Aprovado = l.Aprovado,
                                                       Tipo = l.Bom_Formula == 1 ? "Nenhum" : 
                                                              l.Bom_Formula == 2 ? "Co-Produto":
                                                              l.Bom_Formula == 3 ? "Sub-Produto":
                                                              l.Bom_Formula == 4 ? "Item de Planejamento":
                                                              l.Bom_Formula == 5 ? "BOM":
                                                              l.Bom_Formula == 6 ? "Formula": "",
                                                       GrupoLancamento = gl.Descricao,
                                                       Armazem = a.Nome
                                                   }).OrderBy(x => x.Nome).ToList();
            return lista;

        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.ListaMateriais
                                     select new ComboItem()
                                     {
                                         Text = c.Nome,
                                         iValue = c.IdListaMateriais
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
