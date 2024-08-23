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
    public class MovimentacaoAtivoDAL : Repository<MovimentacaoAtivo>, IDisposable
    {
        public List<MovimentacaoAtivoModelView> GetAll()
        {
            List<MovimentacaoAtivoModelView> lista = (from m in db.MovimentacaoAtivo
                                                      join c in db.Cliente on m.IDCliente equals c.IdCliente
                                                      join f in db.Fornecedor on m.IDFornecedor equals f.IdFornecedor
                                                      join g in db.GrupoAtivo on m.IDGrupoAtivo equals g.IdGrupoAtivo

                                                      select new MovimentacaoAtivoModelView
                                                      {
                                                          IdMovimentacaoAtivo = m.IdMovimentacaoAtivo,
                                                          MovimentacaoAtivoStatus = (m.IdMovimentacaoAtivoStatus == 1 ? "Ainda não adquirido" : 
                                                                                    (m.IdMovimentacaoAtivoStatus == 2 ? "Em aberto" : 
                                                                                    (m.IdMovimentacaoAtivoStatus == 3 ? "Suspenso" : 
                                                                                    (m.IdMovimentacaoAtivoStatus == 4 ? "Fechada" : 
                                                                                    (m.IdMovimentacaoAtivoStatus == 5 ? "Vendido" : 
                                                                                    (m.IdMovimentacaoAtivoStatus == 6 ? "Sucateado" : 
                                                                                    (m.IdMovimentacaoAtivoStatus == 7 ? "Transferido para o grupo de valor baixo" : "Adquirido"))))))),
                                                          NomeFantasia = c.NomeFantasia,
                                                          RazaoSocial = f.RazaoSocial,
                                                          DescricaoGrupo = g.Descricao

                                                      }).ToList();
            return lista;

        }
    }
}
