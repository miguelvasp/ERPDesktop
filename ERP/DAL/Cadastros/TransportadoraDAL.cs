using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class TransportadoraDAL : IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();
        private GenericRepository<Transportadora> tRepository;
        private GenericRepository<TransportadoraContato> tcRepository;
        private GenericRepository<TransportadoraEndereco> teRepository;
        private GenericRepository<TransportadoraTelefone> ttRepository;

        public GenericRepository<Transportadora> TRepository
        {
            get
            {
                if (this.tRepository == null)
                {
                    this.tRepository = new GenericRepository<Transportadora>(db);
                }
                return tRepository;
            }
        }

        

        public GenericRepository<TransportadoraContato> TCRepository
        {
            get
            {
                if (this.tcRepository == null)
                {
                    this.tcRepository = new GenericRepository<TransportadoraContato>(db);
                }
                return tcRepository;
            }
        }

        public GenericRepository<TransportadoraEndereco> TERepository
        {
            get
            {
                if (this.teRepository == null)
                {
                    this.teRepository = new GenericRepository<TransportadoraEndereco>(db);
                }
                return teRepository;
            }
        }

        public GenericRepository<TransportadoraTelefone> TTRepository
        {
            get
            {
                if (this.ttRepository == null)
                {
                    this.ttRepository = new GenericRepository<TransportadoraTelefone>(db);
                }
                return ttRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }


        public bool ConsultaCNPJ(string CNPJ)
        {
            Transportadora t = db.Transportadora.Where(x => x.CNPJ == CNPJ).FirstOrDefault();
            if(t == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Transportadora> getByParams(string Razao, string CNPJ)
        {
            string xCNPJ = CNPJ.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "");
            List<Transportadora> transp = new List<Transportadora>();
            transp = (from t in db.Transportadora
                      where t.RazaoSocial.Contains(Razao) &&
                      (xCNPJ == "" || t.CNPJ == CNPJ) 
                      select t).OrderBy(x => x.RazaoSocial).Take(200).ToList();
            return transp;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from f in db.Transportadora
                                     select new ComboItem
                                     {
                                         iValue = f.IdTransportadora,
                                         Text = f.RazaoSocial
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
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
