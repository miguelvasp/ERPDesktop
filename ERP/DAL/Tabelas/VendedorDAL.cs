using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class VendedorDAL : IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();
        private GenericRepository<Vendedor> VRepository;
        private GenericRepository<VendedorMetas> VMRepository;

        public decimal ComissaoPrincipal(int id, int? IdTelevendas)
        {
            decimal TotalComissao = 6;
            decimal ComissaoTelevendas = 0;
            var Percentual = (from v in db.Vendedor
                              where v.IdVendedor == id
                              select v.ComissaoPrincipal).FirstOrDefault();


            //Pesquisa a comissão do televendas
            if(IdTelevendas != null)
            {
                Funcionario f = new FuncionarioDAL().FRepository.GetByID(IdTelevendas);
                if(f != null)
                {
                    if(f.IdVendedor != null)
                    {
                        Vendedor vend = new VendedorDAL().VendedorRepository.GetByID(f.IdVendedor);
                        if(vend.ComissaoAdicional != null)
                        {
                            ComissaoTelevendas = Convert.ToDecimal(vend.ComissaoAdicional);
                        }
                    }
                }
            }

            decimal TotalSoma = Convert.ToDecimal(Percentual) + ComissaoTelevendas;

            if(TotalSoma > TotalComissao)
            {
                var sobra = TotalComissao - TotalSoma;
                Percentual = Percentual - sobra;
            }

            return (decimal)Percentual;
        }

        public Vendedor GetVendedorById(int Id)
        {
            return (from v in db.Vendedor where v.IdVendedor == Id select v).FirstOrDefault();
        }

        public GenericRepository<Vendedor> VendedorRepository
        {
            get
            {
                if (this.VRepository == null)
                {
                    this.VRepository = new GenericRepository<Vendedor>(db);
                }
                return VRepository;
            }
        }

        public GenericRepository<VendedorMetas> VendedorMetaRepository
        {
            get
            {
                if (this.VMRepository == null)
                {
                    this.VMRepository = new GenericRepository<VendedorMetas>(db);
                }
                return VMRepository;
            }
        }

        public List<Vendedor> getByParams(string Vendedor)
        {
            var vendedores = (from v in db.Vendedor
                              where v.Nome.Contains(Vendedor)
                              orderby v.Nome
                              select v).ToList();
            return vendedores;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from v in db.Vendedor
                                     select new ComboItem
                                     {
                                         iValue = v.IdVendedor,
                                         Text = v.Nome
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public void Save(string IdUsuarioCorrente)
        {
            db.SaveChanges(IdUsuarioCorrente);
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
