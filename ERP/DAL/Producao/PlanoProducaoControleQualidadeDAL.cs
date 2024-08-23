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
    public class PlanoProducaoControleQualidadeDAL : Repository<PlanoProducaoControleQualidade>
    {
        public List<PlanoProducaoControleQualidade> getByPlano(int IdPlano)
        {
            return (from c in db.PlanoProducaoControleQualidade
                    where c.IdPlanoProducao == IdPlano
                    select c).ToList();
        }
    }
}
