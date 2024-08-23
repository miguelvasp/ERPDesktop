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
    public class BancoDAL : Repository<Banco>
    {
        public List<Banco> getByParams(string prtNumero, string prtNome)
        {
            List<Banco> banco = new List<Banco>();
            banco = (from b in db.Banco
                     where b.NumeroBanco.Contains(prtNumero) &&
                     (prtNome == "" || b.NomeBanco.Contains(prtNome))
                     select b).OrderBy(o => o.NumeroBanco).ToList();

            return banco;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from b in db.Banco
                                     select new ComboItem
                                     {
                                         iValue = b.IdBanco,
                                         Text = b.NomeBanco
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
