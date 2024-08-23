using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class LogRepository : IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();
        private GenericRepository<Log> logRepository;
        private GenericRepository<LogItem> logItemRepository;

        public GenericRepository<Log> LRepository
        {
            get
            {

                if (this.logRepository == null)
                {
                    this.logRepository = new GenericRepository<Log>(db);
                }
                return logRepository;
            }
        }

        public List<Log> GetBySpecificField(string Logform, string KeyValue, string TargetField)
        {
            List<Log> Logs = new List<Log>();
            var parameters = new[] { 
                new SqlParameter("@LogForm", Logform), 
                new SqlParameter("@KeyValue", KeyValue), 
                new SqlParameter("@targetField", TargetField)
            };
            var Lista = db.Log.SqlQuery("Exec LogView @LogForm, @KeyValue, @targetField", parameters).ToList();

            foreach (var item in (List<Log>)Lista)
            {
                Log log = new Log();
                log.LogId = item.LogId;
                log.LogDate = item.LogDate;
                log.LogForm = item.LogForm;
                log.SamId = item.SamId;
                log.Type = item.Type;
                log.KeyValue = item.KeyValue;
                Logs.Add(log);
            }
            return Logs;
        }

        public GenericRepository<LogItem> LitemRepository
        {
            get
            {

                if (this.logItemRepository == null)
                {
                    this.logItemRepository = new GenericRepository<LogItem>(db);
                }
                return logItemRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
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