using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class GrupoImpostoRetidoItemDAL : Repository<GrupoImpostoRetidoItem>
    {
        public List<GrupoImpostoRetidoItem> getByParams(string prtCodigo, string prtDescricao)
        {
            List<GrupoImpostoRetidoItem> gir = new List<GrupoImpostoRetidoItem>();
            gir = (from g in db.GrupoImpostoRetidoItem
                   where (prtCodigo == "" || g.Codigo.Contains(prtCodigo)) &&
                   (prtDescricao == "" || g.Descricao.Contains(prtDescricao))
                   select g).OrderBy(o => o.Codigo).ToList();

            return gir;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.GrupoImpostoRetidoItem
                                     select new ComboItem()
                                     {
                                         Text = c.Descricao,
                                         iValue = c.IdGrupoImpostoRetidoItem
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
