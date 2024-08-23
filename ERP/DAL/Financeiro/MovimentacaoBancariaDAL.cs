using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Globalization;

namespace ERP.DAL
{
    public class MovimentacaoBancariaDAL : Repository<MovimentacaoBancaria>
    {
        public List<MovimentacaoBancariaModelView> getByParams(DateTime dtIni, DateTime dtFim, int IdContaBancaria)
        {
            DateTime DI = Convert.ToDateTime(dtIni.ToShortDateString() + " 00:00:00");
            DateTime DF = Convert.ToDateTime(dtFim.ToShortDateString() + " 23:59:00");
            List<MovimentacaoBancariaModelView> lista = (from m in db.MovimentacaoBancaria
                                                         join c in db.ContaBancaria on m.IdContaBancaria equals c.IdContaBancaria
                                                         where (m.DataMovimentacao >= DI && m.DataMovimentacao <= DF)
                                                         && m.IdContaBancaria == IdContaBancaria
                                                         select new MovimentacaoBancariaModelView
                                                         {
                                                             Id = m.IdMovimentacao,
                                                             ContaBancaria = c.NomeConta,
                                                             Data = m.DataMovimentacao,
                                                             Tipo = m.TipoMovimento == 1 ? "Entrada" : "Saida",
                                                             Documento = m.NumeroDocumento,
                                                             Historico = m.Historico,
                                                             Valor = m.Valor
                                                         }).OrderBy(x => x.Data).ToList();
            return lista;

        }
    }
}
