using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class GrupoProdutoDAL : Repository<GrupoProduto>
    {
        public List<GrupoProduto> getByParams(string prtNome, string prtDescricao)
        {
            List<GrupoProduto> gp = new List<GrupoProduto>();
            gp = (from g in db.GrupoProduto
                  where (prtNome == "" || g.Nome.Contains(prtNome)) &&
                  (prtDescricao == "" || g.Descricao.Contains(prtDescricao))
                  select g).OrderBy(o => o.Nome).ToList();

            return gp;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from g in db.GrupoProduto
                                     select new ComboItem
                                     {
                                         iValue = g.IdGrupoProduto,
                                         Text = g.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public GrupoProduto getByNome(string nome)
        {
            return (from g in db.GrupoProduto
                    where g.Nome == nome
                    select g).FirstOrDefault();
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from g in db.GrupoProduto
                                         select new GenericReport
                                         {
                                             Text1 = g.Nome,
                                             Text2 = g.Descricao,
                                             Text3 = "",
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}