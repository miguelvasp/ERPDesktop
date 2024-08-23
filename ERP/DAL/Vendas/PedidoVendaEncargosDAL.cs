using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ERP.DAL
{
    public class PedidoVendaEncargosDAL : Repository<PedidoVendaEncargos>
    {
        public List<PedidoVendaEncargos> GetPedidoVendaEncargos(int pIdPedidoVenda)
        {
            var lista = (from e in db.PedidoVendaEncargos
                         where e.IdPedidoVenda == pIdPedidoVenda
                         select e).ToList();
            return lista;
        }

        public void GeraEncargos(int pIdPedidoVenda, int? pIdGrupoEncargos)
        {
            int GrupoEncargos = pIdGrupoEncargos == null ? 0 : Convert.ToInt32(pIdGrupoEncargos);
            List<PedidoVendaEncargos> lista = GetPedidoVendaEncargos(pIdPedidoVenda);
            if(lista.Count == 0)
            {
                //Consulta os encargos
                var Encargos = (from g in db.GrupoEncargosCodigoEncargo
                                join c in db.CodigoEncargo on g.IdCodigoEncargo equals c.IdCodigoEncargo
                                where g.IdGrupoEncargos == GrupoEncargos
                                select new
                                {
                                    c.Tipo,
                                    c.Nome
                                }).ToList();
                foreach(var e in Encargos)
                {
                    PedidoVendaEncargos p = new PedidoVendaEncargos();
                    p.IdPedidoVenda = pIdPedidoVenda;
                    p.TipoEncargo = e.Tipo;
                    p.Descricao = e.Nome;
                    p.Valor = 0;
                    this.Insert(p);
                    this.Save();
                }
            }
        }
    }
}
