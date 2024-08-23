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
    public class GrupoEncargosCodigoEncargoDAL : Repository<GrupoEncargosCodigoEncargo>
    {
        public List<GrupoEncargosCodigosModelView> GetGrupoEncargosCodigos(int pIdGrupoEncargos)
        {
            List<GrupoEncargosCodigosModelView> lista = (from g in db.GrupoEncargos
                                                         join gi in db.GrupoEncargosCodigoEncargo on g.IdGrupoEncargos equals gi.IdGrupoEncargos
                                                         join c in db.CodigoEncargo on gi.IdCodigoEncargo equals c.IdCodigoEncargo
                                                         where g.IdGrupoEncargos == pIdGrupoEncargos
                                                         select new GrupoEncargosCodigosModelView
                                                         {
                                                             Id = gi.IdGrupoEncargosCodigoEncargo,
                                                             Nome = c.Nome,
                                                             Descricao = c.Descricao
                                                         }).OrderBy(x => x.Nome).ToList();
            return lista;
        }
    }
}
