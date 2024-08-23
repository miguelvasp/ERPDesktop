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
    public class GrupoPrecoDescontoDAL : Repository<GrupoPrecoDesconto>
    {
        public List<GrupoPrecoDesconto> getByParams(string prtNome, string prtDescricao)
        {
            List<GrupoPrecoDesconto> gpd = new List<GrupoPrecoDesconto>();
            gpd = (from g in db.GrupoPrecoDesconto
                   where (prtNome == "" || g.Nome.Contains(prtNome)) &&
                   (prtDescricao == "" || g.Descricao.Contains(prtDescricao))
                   select g).OrderBy(o => o.Nome).ToList();

            return gpd;
        }

        public List<ComboItem> GetComboByModulo(int? pModulo)
        {
            List<ComboItem> lista = (from c in db.GrupoPrecoDesconto
                                     where c.Modulo == pModulo
                                     select new ComboItem()
                                     {
                                         Text = c.Nome,
                                         iValue = c.IdGrupoPrecoDesconto
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }


        public List<ComboItem> GetComboByModuloDesconto(int? pModulo)
        {
            List<ComboItem> lista = (from c in db.GrupoPrecoDesconto
                                     where c.Modulo == pModulo &&
                                           c.Tipo != 1
                                     select new ComboItem()
                                     {
                                         Text = c.Nome,
                                         iValue = c.IdGrupoPrecoDesconto
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<ComboItem> GetComboByModuloPreco(int? pModulo)
        {
            List<ComboItem> lista = (from c in db.GrupoPrecoDesconto
                                     where c.Modulo == pModulo &&
                                           c.Tipo == 1
                                     select new ComboItem()
                                     {
                                         Text = c.Nome,
                                         iValue = c.IdGrupoPrecoDesconto
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.GrupoPrecoDesconto
                                     select new ComboItem()
                                     {
                                         Text = c.Nome,
                                         iValue = c.IdGrupoPrecoDesconto
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<ComboItem> GetCombo(ERP.Util.EnumERP.ModuloGrupoPrecoDesconto prtModulo)
        {
            int modulo = (int)prtModulo;

            List<ComboItem> lista = (from c in db.GrupoPrecoDesconto
                                     where c.Modulo == modulo
                                     select new ComboItem()
                                     {
                                         Text = c.Nome,
                                         iValue = c.IdGrupoPrecoDesconto
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<ComboItem> GetCombo(ERP.Util.EnumERP.TipoGrupoPrecoDesconto prtTipo)
        {
            int tipo = (int)prtTipo;

            List<ComboItem> lista = (from c in db.GrupoPrecoDesconto
                                     where c.Tipo == tipo 
                                     select new ComboItem()
                                     {
                                         Text = c.Nome,
                                         iValue = c.IdGrupoPrecoDesconto
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<ComboItem> GetCombo(ERP.Util.EnumERP.TipoGrupoPrecoDesconto prtTipo, ERP.Util.EnumERP.ModuloGrupoPrecoDesconto prtModulo)
        {
            int tipo = (int)prtTipo;
            int modulo = (int)prtModulo;

            List<ComboItem> lista = (from c in db.GrupoPrecoDesconto
                                     where c.Tipo == tipo &&
                                           c.Modulo == modulo  
                                     select new ComboItem()
                                     {
                                         Text = c.Nome,
                                         iValue = c.IdGrupoPrecoDesconto
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
