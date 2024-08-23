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
    public class FluxoCaixaDAL : Repository<FluxoCaixa>
    {
        public List<FluxoCaixa> getByUserId(int IdUsuario)
        {
            return (from f in db.FluxoCaixa
                         where f.IdUsuario == IdUsuario
                         select f).OrderBy(x => x.Tipo).ToList(); 
        }
    }
}
