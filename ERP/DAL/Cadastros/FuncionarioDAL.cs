using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class FuncionarioDAL : IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();
        private GenericRepository<Funcionario> fRepository;
        private GenericRepository<FuncionarioEndereco> feRepository;
        private GenericRepository<FuncionarioTelefone> ftRepository;
        private GenericRepository<FuncionarioContaBancaria> fcbRepository;

        public GenericRepository<Funcionario> FRepository
        {
            get
            {
                if (this.fRepository == null)
                {
                    this.fRepository = new GenericRepository<Funcionario>(db);
                }
                return fRepository;
            }
        }

        public GenericRepository<FuncionarioEndereco> FERepository
        {
            get
            {
                if (this.feRepository == null)
                {
                    this.feRepository = new GenericRepository<FuncionarioEndereco>(db);
                }
                return feRepository;
            }
        }

        public GenericRepository<FuncionarioTelefone> FTRepository
        {
            get
            {
                if (this.ftRepository == null)
                {
                    this.ftRepository = new GenericRepository<FuncionarioTelefone>(db);
                }
                return ftRepository;
            }
        }

        public GenericRepository<FuncionarioContaBancaria> FCBRepository
        {
            get
            {
                if (this.fcbRepository == null)
                {
                    this.fcbRepository = new GenericRepository<FuncionarioContaBancaria>(db);
                }
                return fcbRepository;
            }
        }

        public List<Funcionario> getByParams(string prtNome, string prtNomeFantasia, string prtCPF)
        {
            string cpf = prtCPF.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "");

            List<Funcionario> func = new List<Funcionario>();
            func = (from f in db.Funcionario
                   where (prtNome == "" || f.Nome.Contains(prtNome)) &&
                   (prtNomeFantasia == "" || f.NomeFantasia.Contains(prtNomeFantasia)) &&
                   (cpf == "" || f.CPF.Contains(cpf)) 
                   select f).OrderBy(o => o.Nome).ToList();

            return func;
        }


        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.Funcionario
                                     select new ComboItem
                                     {
                                         iValue = c.IdFuncionario,
                                         Text = c.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<ComboItem> GetComboTelevendas()
        {
            List<ComboItem> lista = (from c in db.Funcionario
                                     where c.Televendas == true
                                     select new ComboItem
                                     {
                                         iValue = c.IdFuncionario,
                                         Text = c.Nome
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