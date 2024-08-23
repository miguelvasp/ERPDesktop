using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace ERP.Relatorios
{
    public partial class frmRepPedidoVendas : Form
    {
        DataTable dt = new DataTable();
        string Filtros;

        public frmRepPedidoVendas(DataTable prtdt, string prtFiltros)
        {
            dt = prtdt;
            Filtros = prtFiltros;
            InitializeComponent();
        }

        private void frmRepPedidoVendas_Load(object sender, EventArgs e)
        {
            ReportParameter FL = new ReportParameter("Filtros", Filtros);

            ReportDataSource rds = new ReportDataSource("dsRepPedidoVendas", dt);
            
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
