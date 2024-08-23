using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ERP.ModelView;

namespace ERP.DAL
{
    public class ChequeDAL : Repository<Cheque>
    {
        public bool ConsultaDisponibilidade(int IdContaBancaria, int NumeroCheque, int Quantidade)
        {
            bool Resultado = true;

            var lista = (from c in db.Cheque
                         where c.IdContaBancaria == IdContaBancaria
                         && (c.NumeroCheque >= NumeroCheque && c.NumeroCheque <= (NumeroCheque + Quantidade))
                         select c).Count();

            if(lista > 0)
            {
                Resultado = false;
            }

            return Resultado;
        }

        public int UltimoCheque(int IdContaBancaria)
        {
            var cheque = (from c in db.Cheque
                          where c.IdContaBancaria == IdContaBancaria
                          select c.NumeroCheque).Max();

            return Convert.ToInt32(cheque);
        }

        public void GeraNumeracaoCheques(int IdContaBancaria, int NumeroCheque, int Quantidade)
        {
            int Contador = NumeroCheque;
            while(Contador < NumeroCheque + Quantidade)
            {
                Cheque c = new Cheque();
                c.IdContaBancaria = IdContaBancaria;
                c.NumeroCheque = Contador;
                c.Status = 1;
                Insert(c);
                Save();
                Contador++;
            }
        }

        public List<ComboItem> BuscaCheques(int idContaBancaria)
        {
            var lista = (from c in db.Cheque
                         where c.IdContaBancaria == idContaBancaria
                         && c.Valor == null
                         select new { c.IdCheque, c.NumeroCheque }).ToList();
            List<ComboItem> list = new List<ComboItem>();
            foreach (var i in lista)
            {
                list.Add(new ComboItem() { iValue = (int)i.IdCheque, Text = i.NumeroCheque.ToString() });
            }
            return list;
        }

        public List<ChequeModelView> GetList(DateTime De, DateTime Ate, int IdFornecedor = 0, int IdCliente = 0, int IdContaBancaria = 0, bool Todos = false)
        {
            return (from c in db.Cheque
                    where (Todos ||  (c.Emissao >= De && c.Emissao <= Ate))
                    && (IdContaBancaria == 0 || c.IdContaBancaria == IdContaBancaria)

                    from ci in db.ChequeItem.Where(x => x.IdCheque == c.IdCheque
                                                   && (IdFornecedor == 0 || x.IdFornecedor == IdFornecedor)
                                                   && (IdCliente == 0 || x.IdCliente == IdCliente)).DefaultIfEmpty()

                    from cl in db.Cliente.Where(x => x.IdCliente == ci.IdCliente).DefaultIfEmpty()
                    from f in db.Fornecedor.Where(x => x.IdFornecedor == ci.IdFornecedor).DefaultIfEmpty()
                    from cb in db.ContaBancaria.Where(x => x.IdContaBancaria == c.IdContaBancaria).DefaultIfEmpty()

                    select new ChequeModelView
                    {
                        Id = c.IdCheque,
                        Data = c.Emissao,
                        Cliente = cl.RazaoSocial,
                        Fornecedor = f.RazaoSocial,
                        ContaBancaria = cb.NomeConta,
                        Valor = c.Valor,
                        NumeroCheque = c.NumeroCheque,
                        Status = c.Status == 1 ? "Criado" :
                                 c.Status == 2 ? "Testar Impressão" :
                                 c.Status == 3 ? "Nulo" :
                                 c.Status == 4 ? "Pago" :
                                 c.Status == 5 ? "Cancelado" :
                                 c.Status == 6 ? "Compensado" : ""
                    }).Distinct().ToList(); 
        }

        public ChequeModelView GetChequeById(int id)
        {
            return (from c in db.Cheque
                    where c.IdCheque == id

                    from ci in db.ChequeItem.Where(x => x.IdCheque == c.IdCheque).DefaultIfEmpty()
                    from cl in db.Cliente.Where(x => x.IdCliente == ci.IdCliente).DefaultIfEmpty()
                    from f in db.Fornecedor.Where(x => x.IdFornecedor == ci.IdFornecedor).DefaultIfEmpty()
                    from cb in db.ContaBancaria.Where(x => x.IdContaBancaria == c.IdContaBancaria).DefaultIfEmpty()

                    select new ChequeModelView
                    {
                        Id = c.IdCheque,
                        Data = c.Emissao, 
                        Fornecedor = ci.Fornecedor,
                        ContaBancaria = cb.NomeConta,
                        Valor = c.Valor,
                        NumeroCheque = c.NumeroCheque,
                        Status = c.Status == 1 ? "Criado" :
                                 c.Status == 2 ? "Testar Impressão" :
                                 c.Status == 3 ? "Nulo" :
                                 c.Status == 4 ? "Pago" :
                                 c.Status == 5 ? "Cancelado" :
                                 c.Status == 6 ? "Compensado" : ""
                    }).FirstOrDefault();
        }

        public List<ChequeModelView> GetChequeItens(int id)
        {
            return (from c in db.Cheque
                    where c.IdCheque == id
                    from ci in db.ChequeItem.Where(x => x.IdCheque == c.IdCheque).DefaultIfEmpty()
                    from cl in db.Cliente.Where(x => x.IdCliente == ci.IdCliente).DefaultIfEmpty()
                    from f in db.Fornecedor.Where(x => x.IdFornecedor == ci.IdFornecedor).DefaultIfEmpty()

                    select new ChequeModelView
                    {  
                        Fornecedor = ci.Fornecedor, 
                        Valor = ci.Valor, 
                    }).ToList();
        }
    }
}
