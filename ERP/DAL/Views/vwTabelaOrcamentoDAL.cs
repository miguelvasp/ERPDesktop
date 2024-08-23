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
    public class vwTabelaOrcamentoDAL 
    {
        DB_ERPViewContext db = new DB_ERPViewContext();

        public vwTabelaOrcamento getByCodigo(string Codigo)
        {
            return (from t in db.vwTabelaOrcamento
                    where t.CODIGO1 == Codigo
                    || t.CODIGO1semSimbolos == Codigo
                    || t.CODIGO1semZero == Codigo
                    || t.CODIGO2 == Codigo
                    || t.CODIGO2semSimbolos == Codigo
                    || t.CODIGO2semZero == Codigo
                    select t).FirstOrDefault();
        }
    }
}
