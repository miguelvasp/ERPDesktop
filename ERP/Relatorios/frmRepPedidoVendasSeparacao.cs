using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.Models;
using ERP.DAL;

namespace ERP.Relatorios
{
    public partial class frmRepPedidoVendasSeparacao : Form
    {
        int idPedido = 0;
        public frmRepPedidoVendasSeparacao(int pIdPedido)
        {
            idPedido = pIdPedido;
            InitializeComponent();
        }

        private void frmRepPedidoVendasSeparacao_Load(object sender, EventArgs e)
        {
            List<vwPedidoVendaSeparacao> lista = new vwPedidoVendaSeparacaoDAL().GetByPedidoId(idPedido);
            ReportDataSource rds = new ReportDataSource("dsPedidoVendasSeparacao", lista);
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport(); 
        }
    }
}
