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
    public class PedidoCompraEncargosDAL : Repository<PedidoCompraEncargos>
    {
        public List<PedidoCompraEncargos> GetPedidoCompraEncargos(int pIdPedidoCompra)
        {
            var lista = (from e in db.PedidoCompraEncargos
                         where e.IdPedidoCompra == pIdPedidoCompra
                         select e).ToList();
            return lista;
        }

        public void GeraEncargos(int pIdPedidoCompra, int? pIdGrupoEncargos)
        {
            int GrupoEncargos = pIdGrupoEncargos == null ? 0 : Convert.ToInt32(pIdGrupoEncargos);
            List<PedidoCompraEncargos> lista = GetPedidoCompraEncargos(pIdPedidoCompra);
            if (lista.Count == 0)
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
                foreach (var e in Encargos)
                {
                    PedidoCompraEncargos p = new PedidoCompraEncargos();
                    p.IdPedidoCompra = pIdPedidoCompra;
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
