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
    public class RoteiroOperacaoLinhasDAL : Repository<RoteiroOperacaoLinhas>
    {
        public List<RoteiroOperacaoLinhasModelView> GetByOperacaoLinhasId(int id)
        {
            List<RoteiroOperacaoLinhasModelView> lista = (from r in db.RoteiroOperacaoLinhas

                                                          from p in db.Produto
                                                          .Where(x => x.IdProduto == r.IdProduto)
                                                          .DefaultIfEmpty()

                                                          from gl in db.GrupoLancamento
                                                          .Where(x => x.IdGrupoLancamento == r.IdGrupoLancamento)
                                                          .DefaultIfEmpty()

                                                          from gr in db.GrupoRoteiro
                                                          .Where(x => x.IdGrupoRoteiro == r.IdGrupoRoteiros)
                                                          .DefaultIfEmpty()

                                                          select new RoteiroOperacaoLinhasModelView
                                                          {
                                                              Id = r.IdRoteiroOperacaoLinhas,
                                                              CodigoItem = r.CodigoItem == null ? "" :
                                                                           r.CodigoItem == 1 ? "Tabela" :
                                                                           r.CodigoItem == 2 ? "Grupos" :
                                                                           r.CodigoItem == 3 ? "Todos" : "",
                                                              Produto = p.Descricao,
                                                              GrupoLancamento = gl.Descricao,
                                                              GrupoRoteiro = gr.Descricao
                                                          }).ToList();
            return lista;

        }
    }
}
