using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace ERP.Relatorios
{
    public partial class frmRepMovimentacaoBancaria : Form
    {
        DataTable dt = new DataTable();
        string Titulo;
        string Texto1;
        string Texto2;
        string Texto3;

        public frmRepMovimentacaoBancaria(DataTable ReportDataSource, string sTitulo, string T1, string T2, string T3)
        {
            Titulo = sTitulo;
            Texto1 = T1;
            Texto2 = T2;
            Texto3 = T3;
            dt = ReportDataSource;
            InitializeComponent();
        }


        private void frmReportMovimentacaoBancaria_Load(object sender, EventArgs e)
        {

            ReportParameter PT = new ReportParameter("Titulo", Titulo);
            ReportParameter P1 = new ReportParameter("Texto1", Texto1);
            ReportParameter P2 = new ReportParameter("Texto2", Texto2);
            ReportParameter P3 = new ReportParameter("Texto3", Texto3);

            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportDataSource rds = new ReportDataSource("dsMovimentacaoBancaria", dt);

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { PT, P1, P2, P3 });
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();

        }
    }
}
