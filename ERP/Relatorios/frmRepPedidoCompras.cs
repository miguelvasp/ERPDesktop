using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace ERP.Relatorios
{
    public partial class frmRepPedidoCompras : Form
    {
        DataTable dt = new DataTable();
        string Filtros;

        public frmRepPedidoCompras(DataTable prtdt, string prtFiltros)
        {
            dt = prtdt;
            Filtros = prtFiltros;
            InitializeComponent();
        }

        private void frmRepPedidoCompras_Load(object sender, EventArgs e)
        {
            ReportParameter FL = new ReportParameter("Filtros", Filtros);

            ReportDataSource rds = new ReportDataSource("dsRepPedidoCompras", dt);

            this.rptPedidos.LocalReport.SetParameters(new ReportParameter[] { FL });
            this.rptPedidos.SetDisplayMode(DisplayMode.PrintLayout);
            rptPedidos.LocalReport.DataSources.Clear();
            rptPedidos.LocalReport.DataSources.Add(rds);
            this.rptPedidos.LocalReport.Refresh();
            this.rptPedidos.RefreshReport();
            this.rptPedidos.RefreshReport();
        }
    }
}
