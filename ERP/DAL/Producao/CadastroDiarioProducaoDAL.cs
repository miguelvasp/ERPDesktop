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
    public class CadastroDiarioProducaoDAL : Repository<CadastroDiarioProducao>
    {

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from am in db.CadastroDiarioProducao
                                     select new ComboItem
                                     {
                                         iValue = am.IdCadastroDiarioProducao,
                                         Text = am.NomeDiario
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
