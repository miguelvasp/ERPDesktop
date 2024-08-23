using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ERP.DAL
{
    public class CalculoComissaoDAL : Repository<CalculoComissao>
    {
        public List<CalculoComissao> getByParams(string prtGrupoCalculoComisao)
        {
            List<CalculoComissao> cc = new List<CalculoComissao>();
            cc = (from c in db.CalculoComissao
                  where (prtGrupoCalculoComisao == "" || c.GrupoComissao.Descricao.Contains(prtGrupoCalculoComisao))
                  select c).OrderBy(o => o.GrupoComissao.Descricao).ToList();

            return cc;
        }
    }
}
