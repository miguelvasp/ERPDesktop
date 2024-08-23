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
    public class PlanoProducaoEtapaDAL : Repository<PlanoProducaoEtapa>
    {
        public List<PlanoProducaoEtapa> getByPlano(int id)
        {
            return (from p in db.PlanoProducaoEtapa
                    where p.IdPlanoProducao == id
                    select p).ToList();
        }

        public void DeletaEtapa(int id)
        {
            PlanoProducaoMateriaPrimaDAL mdal = new PlanoProducaoMateriaPrimaDAL();
            var lista = mdal.getByEtapa(id);
            foreach(var m in lista)
            {
                mdal.Delete(m.IdPlanoProducaoMateriaPrima);
                mdal.Save();
            }

            this.Delete(id);
        }
    }
}
