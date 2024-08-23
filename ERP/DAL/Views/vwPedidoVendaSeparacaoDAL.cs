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
    public class vwPedidoVendaSeparacaoDAL : Repository<vwPedidoVendaSeparacao>
    {
        DB_ERPViewContext db = new DB_ERPViewContext();
        public List<vwPedidoVendaSeparacao> GetByPedidoId(int pIdPedido)
        {
            var lista = (from l in db.vwPedidoVendaSeparacao
                         where l.IdPedidoVenda == pIdPedido
                         select l).ToList();
            return lista;
        }

        public List<ComboItem> GetComboClientesEmSeparacao()
        {
            List<ComboItem> lista = (from v in db.vwPedidoVendaSeparacao
                                     select new ComboItem
                                     {
                                         Text = v.RazaoSocial,
                                         Value = v.RazaoSocial,
                                         iValue = v.IdCliente
                                     }).Distinct().OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<ComboItem> GetComboClientesPorFaturar()
        {
            List<ComboItem> lista = (from v in db.vwPedidoVendaSeparacao
                                     where v.QuantidadePorFaturar > 0
                                     select new ComboItem
                                     {
                                         Text = v.RazaoSocial,
                                         Value = v.RazaoSocial,
                                         iValue = v.IdCliente
                                     }).Distinct().OrderBy(x => x.Text).ToList();
            return lista;
        }

        public List<vwPedidoVendaSeparacao> GetByCliente(int  pCliente)
        {
            var lista = (from l in db.vwPedidoVendaSeparacao
                         where l.IdCliente == pCliente
                         && l.QuantidadePorFaturar == 0
                         select l).OrderBy(x => x.PedidoNumero).ToList();
            return lista;
        }

        public List<vwPedidoVendaSeparacao> GetByClientePorFaturar(int pCliente)
        {
            var lista = (from l in db.vwPedidoVendaSeparacao
                         where l.IdCliente == pCliente
                         && l.QuantidadePorFaturar > 0
                         select l).OrderBy(x => x.PedidoNumero).ToList();
            return lista;
        }

    }
}
