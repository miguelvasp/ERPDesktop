using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class AprovacaoNivelDAL : Repository<AprovacaoNivel>
    {
        public List<AprovacaoNivel> GetByDocumentoId(int id)
        {
            var lista = (from a in db.AprovacaoNivel
                         where a.IdAprovacaoDocumento == id
                         select a).OrderBy(x => x.Sequencia).ToList();
            return lista;
        }

        public List<ComboItem> GetComboByTipoDocumento(int idTipoDocumento)
        {
            List<ComboItem> lista = (from an in db.AprovacaoNivel
                                     where an.IdAprovacaoDocumento == idTipoDocumento
                                     select new ComboItem
                                     {
                                         iValue = an.IdAprovacaoNivel,
                                         Text = an.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
