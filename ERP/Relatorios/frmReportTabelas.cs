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
using ERP.ModelView;
using ERP.Models;
using ERP.DAL;
using System.Collections;

namespace ERP.Relatorios
{
    public partial class frmReportTabelas : Form
    {
        DataTable dt = new DataTable();
        string Titulo;
        string Texto1;
        string Texto2;
        string Texto3;
        string Texto4;

        public frmReportTabelas(DataTable ReportDataSource, string sTitulo, string T1, string T2, string T3, string T4)
        {
            Titulo = sTitulo;
            Texto1 = T1;
            Texto2 = T2;
            Texto3 = T3;
            Texto4 = T4;
            dt = ReportDataSource;
            InitializeComponent();
        }

        private void frmReportTabelas_Load(object sender, EventArgs e)
        {
            this.Text = Titulo;
            ReportParameter PT = new ReportParameter("Titulo", Titulo);
            ReportParameter P1 = new ReportParameter("Texto1", Texto1);
            ReportParameter P2 = new ReportParameter("Texto2", Texto2);
            ReportParameter P3 = new ReportParameter("Texto3", Texto3);
            ReportParameter P4 = new ReportParameter("Texto4", Texto4);

            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportDataSource rds = new ReportDataSource("dsReport", dt);

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { PT, P1, P2, P3, P4 });
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
