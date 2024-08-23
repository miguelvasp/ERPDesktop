using ERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class PaisDAL : Repository<Pais>
    {
        public override IEnumerable<Pais> Get()
        {
            var pais = db.Pais.OrderBy(x => x.NomePais).ToList();
            return pais.ToList();
        }

        public List<Pais> getByParams(string prtNome, string prtCodigo, string prtCodigoIBGE)
        {
            List<Pais> pais = new List<Pais>();
            pais = (from p in db.Pais
                    where p.NomePais.Contains(prtNome) &&
                    (prtCodigo == "" || p.Codigo.Contains(prtCodigo)) &&
                    (prtCodigoIBGE == "" || p.CodigoIBGE.Contains(prtCodigoIBGE))
                    select p).OrderBy(o => o.NomePais).ToList();

            return pais;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from p in db.Pais
                                     select new ComboItem
                                     {
                                         iValue = p.IdPais,
                                         Text = p.NomePais
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }
    }
}
