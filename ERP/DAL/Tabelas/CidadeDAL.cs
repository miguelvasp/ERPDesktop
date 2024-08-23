using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ERP.DAL
{
    public class CidadeDAL : Repository<Cidade>
    {
        public List<Cidade> getByParams(string prtUF, string prtNome)
        {
            List<Cidade> cidade = new List<Cidade>();
            cidade = (from c in db.Cidade
                      where c.UnidadeFederacao.UF.Contains(prtUF) &&
                      (prtNome == "" || c.Nome.Contains(prtNome))
                      select c).OrderBy(o => o.Nome).ToList();

            return cidade;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.Cidade
                                     select new ComboItem()
                                     {
                                         Text = c.Nome,
                                         iValue = c.IdCidade
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<Cidade> GetByIdUF(int idUF)
        {
            List<Cidade> lista = (from c in db.Cidade
                                  where c.IdUF == idUF
                                  select c).OrderBy(o => o.UnidadeFederacao.UF).ThenBy(t => t.Nome).ToList();

            return lista;
        }

        public List<GenericReport> GetDataReport(List<Cidade> prtLst)
        {
            List<GenericReport> lista = (from r in prtLst
                                         select new GenericReport
                                         {
                                             Text1 = r.Nome,
                                             Text2 = r.UnidadeFederacao.Nome,
                                             Text3 = r.Pais.NomePais,
                                             Text4 = r.IBGE.ToString()
                                         }).OrderBy(o => o.Text2).ToList();

            return lista;
        }
    }
}
