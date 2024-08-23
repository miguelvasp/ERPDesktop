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
    public class CapacidadeRecursosLinhasDAL : Repository<CapacidadeRecursosLinhas>
    {
        public List<CapacidadeRecursosLinhasModelView> GetByCapacidadeId(int id)
        {
            List<CapacidadeRecursosLinhasModelView> lista = (from c in db.CapacidadeRecursosLinhas
                                                             join r in db.Recursos on c.IdRecurso equals r.IdRecurso
                                                             select new CapacidadeRecursosLinhasModelView
                                                             {
                                                                 Id = c.IdCapacidadeRecursosLinhas,
                                                                 Recurso = r.Descricao,
                                                                 DataEfetivacao = c.DataEfetivacao,
                                                                 DataVencimento = c.DataVencimento,
                                                                 Prioridade = c.Prioridade,
                                                                 Nivel = c.Nivel
                                                             }).ToList();
            return lista;
        }
    }
}
