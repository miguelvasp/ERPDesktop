using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class FornecedorDAL : IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();
        private GenericRepository<Fornecedor> fRepository;
        private GenericRepository<FornecedorContato> fcRepository;
        private GenericRepository<FornecedorEndereco> feRepository;
        private GenericRepository<FornecedorTelefone> ftRepository;
        private GenericRepository<FornecedorContaBancaria> fcbRepository;

        public GenericRepository<Fornecedor> FRepository
        {
            get
            {
                if (this.fRepository == null)
                {
                    this.fRepository = new GenericRepository<Fornecedor>(db);
                }
                return fRepository;
            }
        }

        public GenericRepository<FornecedorContato> FCRepository
        {
            get
            {
                if (this.fcRepository == null)
                {
                    this.fcRepository = new GenericRepository<FornecedorContato>(db);
                }
                return fcRepository;
            }
        }

        public GenericRepository<FornecedorEndereco> FERepository
        {
            get
            {
                if (this.feRepository == null)
                {
                    this.feRepository = new GenericRepository<FornecedorEndereco>(db);
                }
                return feRepository;
            }
        }

        public GenericRepository<FornecedorTelefone> FTRepository
        {
            get
            {
                if (this.ftRepository == null)
                {
                    this.ftRepository = new GenericRepository<FornecedorTelefone>(db);
                }
                return ftRepository;
            }
        }

        public GenericRepository<FornecedorContaBancaria> FCBRepository
        {
            get
            {
                if (this.fcbRepository == null)
                {
                    this.fcbRepository = new GenericRepository<FornecedorContaBancaria>(db);
                }
                return fcbRepository;
            }
        }

        public bool ConsultaCNPJ(string CNPJ, int IdFornecedor)
        {
            Fornecedor f = db.Fornecedor.Where(x => x.CNPJ == CNPJ && x.IdFornecedor != IdFornecedor).FirstOrDefault();
            if (f == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Fornecedor> getByParams(string Razao, string CNPJ)
        {
            int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            string xCNPJ = CNPJ.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "");
            List<Fornecedor> fornecedor = new List<Fornecedor>();
            fornecedor = (from f in db.Fornecedor
                          where (f.RazaoSocial.Contains(Razao) || f.NomeFantasia.Contains(Razao))  &&
                          (xCNPJ == "" || f.CNPJ == CNPJ) 
                          & f.IdEmpresa == idEmpresa
                          select f).OrderBy(x => x.RazaoSocial).Take(200).ToList();
            return fornecedor;
        }

        public List<ComboItem> GetCombo()
        {
            int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            List<ComboItem> lista = (from f in db.Fornecedor
                                     where f.IdEmpresa == idEmpresa
                                     select new ComboItem
                                     {
                                         iValue = f.IdFornecedor,
                                         Text = f.RazaoSocial
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<ComboItem> GetCombo2(string IdEmpresa)
        {
            int empresa = IdEmpresa == "" ? 0 : Convert.ToInt32(IdEmpresa);

            List<ComboItem> lista = (from f in db.Fornecedor
                                     where (empresa == 0 || f.IdEmpresa == empresa)

                                     select new ComboItem
                                     {
                                         iValue = f.IdFornecedor,
                                         Text = f.RazaoSocial
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<ComboItem> GetContasBancarias(int IdFornecedor)
        {
            var aux = (from f in db.FornecedorContaBancaria
                       join c in db.ContaBancaria on f.IdContaBancaria equals c.IdContaBancaria
                       join b in db.Banco on c.IdBanco equals b.IdBanco
                       where f.IdFornecedor == IdFornecedor
                       select new
                       {
                           f.IdFornecedorContaBancaria,
                           b.NomeBanco,
                           c.Agencia,
                           c.Conta,
                           c.DigitoConta
                       }).ToList();




            List<ComboItem> lista = new List<ComboItem>();
            foreach(var item in aux)
            {
                ComboItem c = new ComboItem();
                c.iValue = item.IdFornecedorContaBancaria;
                c.Text = item.NomeBanco + " Ag:" + item.Agencia + "Cc:" + item.Conta + "-" + item.DigitoConta;
                lista.Add(c);
            }
            return lista;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Save(string IdUsuarioCorrente)
        {
            db.SaveChanges(IdUsuarioCorrente);
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

