using ERP.Datasets;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace ERP.Relatorios
{
    public partial class frmRepPedidoComprasViewer : Form
    {
        int IdPedidoCompras;
        public frmRepPedidoComprasViewer(int pPedidoCompras)
        {
            this.IdPedidoCompras = pPedidoCompras;
            InitializeComponent();
        }

        private void frmRepPedidoComprasViewer_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            ERP.Datasets.dsRepPedidoComprasTableAdapters.vwPedidoComprasRelTableAdapter ta = new Datasets.dsRepPedidoComprasTableAdapters.vwPedidoComprasRelTableAdapter();
            ERP.Datasets.dsRepPedidoCompras ds = new dsRepPedidoCompras();

            try
            {
                ta.FillBy(ds.vwPedidoComprasRel, IdPedidoCompras);
            }
            catch (Exception)
            {
            }
            finally
            {
                dt = ds.vwPedidoComprasRel;

                ReportDataSource rds = new ReportDataSource("dsRepPedidoCompras", dt);
                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout); 
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
