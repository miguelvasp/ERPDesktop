using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class OrdemProducaoDAL : Repository<OrdemProducao>
    {
        public int getNumeroOP()
        {
            var op = db.OrdemProducao.Max(x => x.NumeroOP);
            int numero = 1;
            if(op != null && op > 0)
            {
                numero = Convert.ToInt32(op) + 1;
            }
            return numero;
        }

        public OrdemProducao getByNumeroOp(int numeroOP)
        {
            return (from o in db.OrdemProducao
                    where o.NumeroOP == numeroOP
                    select o).FirstOrDefault();
        }

        public List<OrdemProducaoModelView> getByParams(int NumeroOP, int IdProduto, int Status)
        {
            db = new DB_ERPContext(); 
            return (from o in db.OrdemProducao
                    join pp in db.PlanoProducao on o.IdPlanoProducao equals pp.IdPlanoProducao
                    join op in db.OrdemProducaoProduto on o.IdOrdemProducao equals op.IdOrdemProducao
                    join p in db.Produto on op.IdProduto equals p.IdProduto
                    join c in db.VariantesCor on pp.IdVariantesCor equals c.IdVariantesCor
                    where op.Qtde > 0
                    && (NumeroOP == 0 || o.NumeroOP == NumeroOP)
                    && (IdProduto == 0 || op.IdProduto == IdProduto)
                    && (Status == 0 || o.StatusProducao == Status)
                   
                    orderby o.NumeroOP
                    select new OrdemProducaoModelView
                    {
                        IdOrdemProducao = o.IdOrdemProducao,
                        CodigoProduto = p.Codigo,
                        DataProgramada = o.DataProgramada,
                        NomePlano = pp.Nome,
                        NomeProduto = p.NomeProduto,
                        NumeroOP = o.NumeroOP,
                        Quantidade = op.Qtde,
                        Cor = c.Descricao,
                        TipoProducao = o.TipoProducao == 2 ? "Urgente" : "Normal",
                        Status = o.StatusProducao == 1 ? "Aguardando Liberação" :
                                 o.StatusProducao == 2 ? "Em Produção" :
                                 o.StatusProducao == 3 ? "Controle de Qualidade" :
                                 o.StatusProducao == 4 ? "Embalagem" :
                                 o.StatusProducao == 5 ? "Finalizada" : ""
                    }).ToList();

        }

        public List<ComboItem> getStatus()
        {
            List<ComboItem> status = new List<ComboItem>();
            status.Add(new ComboItem() { iValue = 1, Text = "Aguardando Liberação" });
            status.Add(new ComboItem() { iValue = 2, Text = "Em Produção" });
            status.Add(new ComboItem() { iValue = 3, Text = "Controle de Qualidade" });
            status.Add(new ComboItem() { iValue = 4, Text = "Embalagem" });
            status.Add(new ComboItem() { iValue = 5, Text = "Finalizada" });
            status.Add(new ComboItem() { iValue = 6, Text = "Cancelada" });
            return status;
        }

        public string getPlanoNome(int id) 
        {
            var px = (from p in db.PlanoProducao
                      join v in db.VariantesCor on p.IdVariantesCor equals v.IdVariantesCor
                      where p.IdPlanoProducao == id
                      select new {
                          p.Nome,
                          v.Descricao
                      }).FirstOrDefault();
            if(px != null)
            {
                return px.Nome + " " + px.Descricao;
            }
            else
            {
                return "Plano não encontrado";
            }
        }

        public List<OrdemProducaoModelView> getCalendar(DateTime di, DateTime df, int Status, int Local)
        {
            var lista = (from o in db.OrdemProducao
                         join pp in db.PlanoProducao on o.IdPlanoProducao equals pp.IdPlanoProducao
                         join op in db.OrdemProducaoProduto on o.IdOrdemProducao equals op.IdOrdemProducao
                         join c in db.VariantesCor on pp.IdVariantesCor equals c.IdVariantesCor
                         where op.Qtde > 0
                         && (o.DataProgramada >= di)
                         && (o.DataProgramada <= df)
                         && (Status == 0 || o.StatusProducao == Status)
                         && (Local == 0 || o.IdLocalProducao == Local) 
                         orderby o.NumeroOP

                         from l in db.LocalProducao.Where(x => x.IdLocalProducao == o.IdLocalProducao).DefaultIfEmpty()

                         select new OrdemProducaoModelView
                         {
                             IdOrdemProducao = o.IdOrdemProducao,
                             DataProgramada = o.DataProgramada,
                             NomePlano = pp.Nome,
                             NumeroOP = o.NumeroOP,
                             Quantidade = op.Qtde,
                             Cor = c.Descricao,
                             TipoProducao = o.TipoProducao == 2 ? "Urgente" : "Normal",
                             Local = l.Descricao
                         }).ToList(); 
            foreach(var a in lista)
            {
                a.Hora = Convert.ToDateTime(a.DataProgramada).Hour;
                a.dtstr = Convert.ToDateTime(a.DataProgramada).ToShortDateString();
            }
            return lista; 
        }

        public void MovimentaEstoque(int Id)
        {

        }
    }
}
