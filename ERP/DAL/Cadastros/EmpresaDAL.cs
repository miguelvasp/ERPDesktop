using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP.DAL
{
    public class EmpresaDAL : IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();
        private GenericRepository<Empresa> eRepository;
        private GenericRepository<EmpresaContaBancaria> ecbRepository;

        public GenericRepository<Empresa> ERepository
        {
            get
            {
                if (this.eRepository == null)
                {
                    this.eRepository = new GenericRepository<Empresa>(db);
                }
                return eRepository;
            }
        }

        public GenericRepository<EmpresaContaBancaria> ECBRepository
        {
            get
            {
                if (this.ecbRepository == null)
                {
                    this.ecbRepository = new GenericRepository<EmpresaContaBancaria>(db);
                }
                return ecbRepository;
            }
        }

        public Empresa getByIdEmpresa(int prtIdEmpresa)
        {
            Empresa emp = new Empresa();
            emp = (from e in db.Empresa
                   where e.IdEmpresa == prtIdEmpresa
                   select e).FirstOrDefault();

            return emp;
        }

        public List<Empresa> getByParams(string prtRazaoSocial, string prtNomeFantasia)
        {
            List<Empresa> emp = new List<Empresa>();
            emp = (from e in db.Empresa
                   where e.RazaoSocial.Contains(prtRazaoSocial) &&
                   (prtNomeFantasia == "" || e.Fantasia.Contains(prtNomeFantasia))
                   select e).OrderBy(o => o.RazaoSocial).ToList();

            return emp;
        }

        public IEnumerable<ComboItem> getCombo()
        {
            List<ComboItem> lista = (from e in db.Empresa
                                     select new ComboItem
                                     {
                                         iValue = e.IdEmpresa,
                                         Text = e.Fantasia
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public bool ConsultaCNPJ(string CNPJ, int id)
        {
            Empresa e = db.Empresa.Where(x => x.CNPJ == CNPJ && x.IdEmpresa != id).FirstOrDefault();
            if (e == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from e in db.Empresa
                                     select new ComboItem
                                     {
                                         iValue = e.IdEmpresa,
                                         Text = e.RazaoSocial
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public ContaBancariaModelView GetContaBancariaByEmpresa(int IdEmpresa, int IdContaBancaria)
        {
            var cb = (from f in db.EmpresaContaBancaria
                      join c in db.ContaBancaria on f.IdContaBancaria equals c.IdContaBancaria
                      join b in db.Banco on c.IdBanco equals b.IdBanco
                      where f.IdEmpresa == IdEmpresa
                        && c.IdContaBancaria == IdContaBancaria
                      select new ContaBancariaModelView
                      {
                          IdConta = f.IdEmpresaContaBancari,
                          NomeBanco = b.NomeBanco,
                          NumeroBanco = b.NumeroBanco,
                          Agencia = c.Agencia,
                          DigitoAgencia = c.DigitoAgencia,
                          Conta = c.Conta,
                          DigitoConta = c.DigitoConta,
                          NossoNumero = c.NossoNumero,
                          Carteira = c.Carteira
                      }).FirstOrDefault();

            return cb;
        }

        public List<ComboItem> GetContasBancarias(int IdEmpresa)
        {
            //var aux = (from f in db.EmpresaContaBancaria
            //           join c in db.ContaBancaria on f.IdContaBancaria equals c.IdContaBancaria
            //           join b in db.Banco on c.IdBanco equals b.IdBanco
            //           where f.IdEmpresa == IdEmpresa
            //           select new
            //           {
            //               f.IdEmpresaContaBancari,
            //               b.NomeBanco,
            //               c.Agencia,
            //               c.Conta,
            //               c.DigitoConta
            //           }).ToList();

            //List<ComboItem> lista = new List<ComboItem>();
            //foreach (var item in aux)
            //{
            //    ComboItem c = new ComboItem();
            //    c.iValue = item.IdEmpresaContaBancari;
            //    c.Text = item.NomeBanco + " Ag:" + item.Agencia + "Cc:" + item.Conta + "-" + item.DigitoConta;
            //    lista.Add(c);
            //}

            List<ComboItem> lista = (from e in db.Empresa
                                     join ec in db.EmpresaContaBancaria on e.IdEmpresa equals ec.IdEmpresa
                                     join c in db.ContaBancaria on ec.IdContaBancaria equals c.IdContaBancaria
                                     where e.IdEmpresa == IdEmpresa
                                     select new ComboItem
                                     {
                                         iValue = c.IdContaBancaria,
                                         Text = c.NomeConta
                                     }).OrderBy(x => x.Text).ToList();
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
