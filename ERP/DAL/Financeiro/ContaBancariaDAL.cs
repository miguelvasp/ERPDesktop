using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ERP.DAL
{
    public class ContaBancariaDAL : Repository<ContaBancaria>
    {
        public List<ContaBancariaModelView> GetList()
        {
            List<ContaBancariaModelView> Lista = new List<ContaBancariaModelView>();
            var aux = (from b in db.Banco
                       join c in db.ContaBancaria on b.IdBanco equals c.IdBanco
                       select new
                       {
                           IdConta = c.IdContaBancaria,
                           NomeBanco = b.NomeBanco,
                           NumeroBanco = b.NumeroBanco,
                           Agencia = c.Agencia,
                           DigitoAgencia = c.DigitoAgencia,
                           Conta = c.Conta,
                           DigitoConta = c.DigitoConta,
                           NossoNumero = c.NossoNumero,
                           Carteria = c.Carteira
                       }).ToList();

            foreach (var it in aux)
            {
                ContaBancariaModelView c = new ContaBancariaModelView();
                c.IdConta = it.IdConta;
                c.NomeBanco = it.NomeBanco;
                c.NumeroBanco = it.NumeroBanco;
                c.Agencia = it.Agencia;
                c.DigitoAgencia = it.DigitoAgencia;
                c.Conta = it.Conta;
                c.DigitoConta = it.DigitoConta;
                c.NossoNumero = it.NossoNumero;
                c.Carteira = it.Carteria;
                Lista.Add(c);
            }

            return Lista;
        }

        public List<ContaBancariaModelView> GetListaEmpresa()
        {
            int idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            List<ContaBancariaModelView> Lista = new List<ContaBancariaModelView>();
            var aux = (from b in db.Banco
                       join c in db.ContaBancaria on b.IdBanco equals c.IdBanco 
                       join ep in db.EmpresaContaBancaria on c.IdContaBancaria equals ep.IdContaBancaria
                       where ep.IdEmpresa == idEmpresa 
                       select new
                       {
                           IdConta = c.IdContaBancaria,
                           NomeBanco = b.NomeBanco,
                           NumeroBanco = b.NumeroBanco,
                           Agencia = c.Agencia,
                           DigitoAgencia = c.DigitoAgencia,
                           Conta = c.Conta,
                           DigitoConta = c.DigitoConta,
                           NossoNumero = c.NossoNumero,
                           Carteria = c.Carteira
                       }).ToList();

            foreach (var it in aux)
            {
                ContaBancariaModelView c = new ContaBancariaModelView();
                c.IdConta = it.IdConta;
                c.NomeBanco = it.NomeBanco;
                c.NumeroBanco = it.NumeroBanco;
                c.Agencia = it.Agencia;
                c.DigitoAgencia = it.DigitoAgencia;
                c.Conta = it.Conta;
                c.DigitoConta = it.DigitoConta;
                c.NossoNumero = it.NossoNumero;
                c.Carteira = it.Carteria;
                Lista.Add(c);
            }

            return Lista;
        }

        public List<ClienteContaBancaria> getCliente(int Id)
        {
            List<ClienteContaBancaria> lista = (from c in db.ClienteContaBancaria
                                                where c.IdCliente == Id
                                                select c).ToList();
            return lista;
        }

        public List<EmpresaContaBancaria> getEmpresa(int Id)
        {
            List<EmpresaContaBancaria> lista = (from e in db.EmpresaContaBancaria
                                                where e.IdEmpresa == Id
                                                select e).ToList();
            return lista;
        }

        public List<FornecedorContaBancaria> getFornecedor(int Id)
        {
            List<FornecedorContaBancaria> lista = (from f in db.FornecedorContaBancaria
                                                   where f.IdFornecedor == Id
                                                   select f).ToList();
            return lista;
        }

        public List<FuncionarioContaBancaria> getFuncionario(int Id)
        {
            List<FuncionarioContaBancaria> lista = (from f in db.FuncionarioContaBancaria
                                                    where f.IdFuncionario == Id
                                                    select f).ToList();
            return lista;
        }
    }
}
