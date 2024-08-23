using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ERP.DAL
{
    public class ClienteDAL : IDisposable
    {
        private DB_ERPContext db = new DB_ERPContext();
        private GenericRepository<Cliente> cRepository;
        private GenericRepository<ClienteContato> ccRepository;
        private GenericRepository<ClienteEndereco> ceRepository;
        private GenericRepository<ClienteTelefone> ctRepository;
        private GenericRepository<ClienteContaBancaria> ccbRepository;

        public GenericRepository<Cliente> CRepository
        {
            get
            {
                if (this.cRepository == null)
                {
                    this.cRepository = new GenericRepository<Cliente>(db);
                }
                return cRepository;
            }
        }

        public GenericRepository<ClienteContato> CCRepository
        {
            get
            {
                if (this.ccRepository == null)
                {
                    this.ccRepository = new GenericRepository<ClienteContato>(db);
                }
                return ccRepository;
            }
        }

        public GenericRepository<ClienteEndereco> CERepository
        {
            get
            {
                if (this.ceRepository == null)
                {
                    this.ceRepository = new GenericRepository<ClienteEndereco>(db);
                }
                return ceRepository;
            }
        }

        public GenericRepository<ClienteTelefone> CTRepository
        {
            get
            {
                if (this.ctRepository == null)
                {
                    this.ctRepository = new GenericRepository<ClienteTelefone>(db);
                }
                return ctRepository;
            }
        }

        public GenericRepository<ClienteContaBancaria> CCBRepository
        {
            get
            {
                if (this.ccbRepository == null)
                {
                    this.ccbRepository = new GenericRepository<ClienteContaBancaria>(db);
                }
                return ccbRepository;
            }
        }

        public bool ConsultaCNPJ(string CNPJ, int IdCliente)
        {
            Cliente c = db.Cliente.Where(x => x.CNPJ == CNPJ && x.IdCliente != IdCliente).FirstOrDefault();
            if (c == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Cliente ConsultaCNPJ(string CNPJ)
        {
            return db.Cliente.Where(x => x.CNPJ == CNPJ).FirstOrDefault();
             
        }

        public Endereco GetEnderecoEntrega(int pIdCliente)
        {
            Endereco end = (from c in db.Cliente
                            join ce in db.ClienteEndereco on c.IdCliente equals ce.IdCliente
                            join e in db.Endereco on ce.IdEndereco equals e.IdEndereco
                            join t in db.TipoEndereco on e.IdTipoEndereco equals t.IdTipoEndereco
                            where c.IdCliente == pIdCliente
                            & t.Nome == "Entrega"
                            select e).FirstOrDefault();
            return end;
        }

        public string GetTelefoneNFe(int pIdCliente)
        {
            try
            {
                var tel = (from c in db.Cliente
                           join ct in db.ClienteTelefone on c.IdCliente equals ct.IdCliente
                           join t in db.Telefone on ct.IdTelefone equals t.IdTelefone
                           where c.IdCliente == pIdCliente
                           select t).FirstOrDefault();
                string Telefone = tel.DDD.TrimStart('0');
                Telefone += tel.NumeroTelefone.Length > 9 ? tel.NumeroTelefone.Substring(0, 9) : tel.NumeroTelefone;
                return Telefone;
            }
            catch (Exception ex)
            {
                return "";
            }
            
        }

        public Endereco GetEnderecoFiscal(int pIdCliente)
        {
            Endereco end = (from c in db.Cliente
                            join ce in db.ClienteEndereco on c.IdCliente equals ce.IdCliente
                            join e in db.Endereco on ce.IdEndereco equals e.IdEndereco
                            join t in db.TipoEndereco on e.IdTipoEndereco equals t.IdTipoEndereco
                            where c.IdCliente == pIdCliente
                            & t.Nome == "Fiscal"
                            select e).FirstOrDefault();
            return end;
        }

        public List<Cliente> getByParams(string Razao, string CNPJ)
        {
            string xCNPJ = CNPJ.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "");
            List<Cliente> cliente = new List<Cliente>();
            cliente = (from c in db.Cliente
                       where (c.RazaoSocial.Contains(Razao) || c.NomeFantasia.Contains(Razao)) &&
                       (xCNPJ == "" || c.CNPJ == CNPJ) 
                       select c).OrderBy(x => x.RazaoSocial).ToList();
            return cliente;
        }

        public List<ComboItem> GetCombo()
        {
            List<ComboItem> lista = (from c in db.Cliente
                                     select new ComboItem
                                     {
                                         iValue = c.IdCliente,
                                         Text = c.RazaoSocial
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<ComboItem> GetCombo(string IdEmpresa)
        {
            int empresa = IdEmpresa == "" ? 0 : Convert.ToInt32(IdEmpresa);

            List<ComboItem> lista = (from c in db.Cliente
                                     where (empresa == 0 || c.IdEmpresa == empresa)
                                     
                                     select new ComboItem
                                     {
                                         iValue = c.IdCliente,
                                         Text = c.RazaoSocial
                                     }).OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<Cliente> getPesquisaPedidoBalcao(string valor)
        {
            return (from c in db.Cliente
                    where c.RazaoSocial.Contains(valor)
                    || c.NomeFantasia.Contains(valor)
                    || c.CNPJ.Contains(valor)
                    select c).ToList();
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
