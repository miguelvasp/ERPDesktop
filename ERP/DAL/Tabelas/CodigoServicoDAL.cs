using ERP.Models;
using ERP.ModelView;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class CodigoServicoDAL : Repository<CodigoServico>
    {
        public override IEnumerable<CodigoServico> Get()
        {
            var cs = db.CodigoServico.OrderBy(x => x.Nome).ToList();
            return cs.ToList();
        }

        public List<CodigoServico> getByParams(string prtCodigo, string prtDescricao, string prtNome)
        {
            List<CodigoServico> cs = new List<CodigoServico>();
            cs = (from a in db.CodigoServico
                  where (prtCodigo == "" || a.Codigo.Contains(prtCodigo)) &&
                  (prtDescricao == "" || a.Descricao.Contains(prtDescricao)) &&
                  (prtNome == "" || a.Nome.Contains(prtNome))
                  select a).OrderBy(o => o.Codigo).ToList();

            return cs;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.CodigoServico
                                     select new ComboItem
                                     {
                                         iValue = c.IdCodigoServico,
                                         Text = c.Descricao
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<GenericReport> GetDataReport()
        {
            List<GenericReport> lista = (from c in db.CodigoServico
                                         select new GenericReport
                                         {
                                             Text1 = c.Codigo,
                                             Text2 = c.Nome,
                                             Text3 = c.Descricao,
                                             Text4 = ""
                                         }).OrderBy(x => x.Text1).ToList();

            return lista;
        }
    }
}
