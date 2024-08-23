using System;

namespace ERP.ModelView
{
    public class PedidoComprasModelView
    {
        public int IdPedidoCompras { get; set; }
        public int? PedidoNumero { get; set; }
        public DateTime Data { get; set; }
        public string Fantasia { get; set; }
        public string NomeFantasia { get; set; }
        public DateTime DataEntrega { get; set; }
        public string StatusAprovacao { get; set; }
        public string Status { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public decimal Total { get; set; }

        public Byte[] LogoEmpresa { get; set; }
    }
}
