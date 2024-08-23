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
    public class ReportHeaderDAL : Repository<ReportHeader>
    {
        public DataTable getReportData(string sql)
        {
            return new SQLDataLayer().getReportData(sql);
        }
    }
}
