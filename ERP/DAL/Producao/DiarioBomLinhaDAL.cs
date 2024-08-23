using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ERP.ModelView;

namespace ERP.DAL
{
    public class DiarioBomLinhaDAL : Repository<DiarioBomLinha>
    {
        public List<DiarioBomLinha> getLinhas(int id)
        {
            var lista = (from di in db.DiarioBomLinha
                         where di.IdDiarioBom == id
                         select di).ToList();
            return lista;
        }
    }
}
