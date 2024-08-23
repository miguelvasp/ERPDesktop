using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class CFOPDAL : Repository<CFOP>
    {
        public List<CFOP> getByParams(string prtCodigo, string prtDescricao)
        {
            List<CFOP> cfop = new List<CFOP>();
            cfop = (from c in db.CFOP
                    where (prtCodigo == "" || c.CFOPCOD.Contains(prtCodigo)) &&
                    (prtDescricao == "" || c.Descricao.Contains(prtDescricao))
                    select c).OrderBy(o => o.CFOPCOD).ToList();

            return cfop;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.CFOP
                                     select new ComboItem()
                                     {
                                         Text = c.CFOPCOD,
                                         iValue = c.IdCFOP
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        /// <summary>
        /// Retorna Combo Com inicio 1. - 2. etc..
        /// </summary>
        /// <param name="filtro">Exemplo de parametro: new[] { "1.", "2.","3." }</param>
        /// <returns></returns>
        public List<ComboItem> GetComboValido(string[] filtro )
        {
            
            List<ComboItem> lista = (from c in db.CFOP
                                     where filtro.Contains(c.CFOPCOD.Substring(0, 2))
                                     select new ComboItem()
                                     {
                                         Text = c.CFOPCOD,
                                         iValue = c.IdCFOP
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public CFOP getByCFOPCodigo(string cfop)
        {
            return (from c in db.CFOP
                    where c.CFOPCOD == cfop
                    select c).FirstOrDefault();
        }
    }
}
