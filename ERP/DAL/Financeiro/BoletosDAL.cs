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
    public class BoletoBancarioDAL : Repository<BoletoBancario>
    {
        public BoletoBancario getBoletoGerado(int idContasReceber, int IdContasReceberAberto)
        {
            var bol = (from b in db.BoletoBancario
                       where b.IdContasReceber == idContasReceber
                       && b.IdContasReceberAberto == IdContasReceberAberto
                       && b.BoletoStatus != "Cancelado"
                       && b.IdContasReceberBaixa == null
                       select b).FirstOrDefault();
            return bol;
        }

        public List<BoletoBancario> getByParams(string dateDe, string DataAte, string Status)
        {
            DateTime de = Convert.ToDateTime(dateDe + " 00:00:00");
            DateTime ate = Convert.ToDateTime(DataAte + " 23:59:00");
            var lista = (from b in db.BoletoBancario
                         where b.BoletoDataVencimento >= de
                         && b.BoletoDataVencimento <= ate
                         && (String.IsNullOrEmpty(Status) || b.BoletoStatus == Status)
                         select b).OrderByDescending(x => x.BoletoDataVencimento).ToList();
            return lista;
        }

        public List<BoletoBancario> getByIdConta(int Id)
        { 
            var lista = (from b in db.BoletoBancario
                         where b.IdContasReceber == Id
                         select b).OrderByDescending(x => x.BoletoDataVencimento).ToList();
            return lista;
        }
    }
}
