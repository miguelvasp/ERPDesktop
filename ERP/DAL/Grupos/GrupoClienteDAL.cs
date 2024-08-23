using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class GrupoClienteDAL : Repository<GrupoCliente>
    {
        public List<GrupoCliente> getByParams(string prtDescricao)
        {
            List<GrupoCliente> gc = new List<GrupoCliente>();
            gc = (from gcli in db.GrupoCliente
                  where (prtDescricao == "" || gcli.Descricao.Contains(prtDescricao))
                  select gcli).OrderBy(o => o.Descricao).ToList();

            return gc;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.GrupoCliente
                                     select new ComboItem()
                                     {
                                         Text = c.Descricao,
                                         iValue = c.IdGrupoCliente
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
