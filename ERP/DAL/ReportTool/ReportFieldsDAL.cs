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
    public class ReportFieldsDAL : Repository<ReportFields>
    {
        public List<ReportFields> getByReportId(int Id)
        {
            return (from r in db.ReportFields
                    where r.IdReportHeader == Id
                    select r).ToList();
        }

        public void DeleteByReportId(int Id)
        {
            var lista = (from r in db.ReportFields
                         where r.IdReportHeader == Id
                         select r).ToList();
            foreach(var i in lista)
            {
                this.Delete(i.IdReportFields);
                this.Save();
            }
        }

        public List<string> getFiltroCombo(string nomeView, string Campo)
        {
            return new SQLDataLayer().getFiltroCombo(nomeView, Campo);
        }


    }
}
