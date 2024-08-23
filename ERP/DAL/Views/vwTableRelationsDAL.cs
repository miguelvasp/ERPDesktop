using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class vwTableRelationsDAL
    {
        private DB_ERPViewContext db = new DB_ERPViewContext();

        public vwTableRelationsDAL(DB_ERPViewContext context)
        {
            this.db = context;
        }

        public vwTableRelations GetMasterKey(string EntityName)
        {
            //add s at the end of the EntityName for pluralization
            return db.vwTableRelations.Where(u => u.TABLE_NAME == EntityName || u.TABLE_NAME == EntityName + "s").FirstOrDefault();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}