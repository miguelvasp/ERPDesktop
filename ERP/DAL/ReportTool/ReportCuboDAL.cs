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
    public class ReportCuboDAL : Repository<ReportCubo>
    {
        public List<ComboItem> getCombo()
        {
            return (from r in db.ReportCubo
                    orderby r.Nome
                    select new ComboItem
                    {
                        iValue = r.IdReportCubo,
                        Text = r.Nome
                    }).ToList();
        } 



    }
}
