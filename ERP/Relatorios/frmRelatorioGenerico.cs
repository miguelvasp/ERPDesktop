using ERP.DAL;
using ERP.Models;
using ERP.Util;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Relatorios
{
    public partial class frmRelatorioGenerico : Form
    {
        SegmentoDAL segDAL = new SegmentoDAL();

        private DataTable dt;
        private DataSet m_dataSet;
        private MemoryStream m_rdl;

        public frmRelatorioGenerico(DataTable dtb)
        {
            dt = dtb;
            InitializeComponent();
        }

        private void frmRelatorioGenerico_Load(object sender, EventArgs e)
        {
           //var am = segDAL.Get().OrderBy(x => x.Nome).ToList();
            //DataTable dt = LINQToDataTable(am);



            m_dataSet = new DataSet();
            m_dataSet.Tables.Add(dt);

            List<string> allFields = GetAvailableFields();

            if (m_rdl != null)
                m_rdl.Dispose();
            m_rdl = GenerateRdl(allFields, allFields);

            ShowReport();
        }

        private void ShowReport()
        {
            this.rptViewer.Reset();
            this.rptViewer.LocalReport.LoadReportDefinition(m_rdl);
            this.rptViewer.LocalReport.DataSources.Add(new ReportDataSource("MyData", m_dataSet.Tables[0]));
            this.rptViewer.RefreshReport();
        }

        private MemoryStream GenerateRdl(List<string> allFields, List<string> selectedFields)
        {
            MemoryStream ms = new MemoryStream();
            RdlGenerator gen = new RdlGenerator();
            gen.AllFields = allFields;
            gen.SelectedFields = selectedFields;
            gen.WriteXml(ms);
            ms.Position = 0;
            return ms;
        }

        private List<string> GetAvailableFields()
        {
            DataTable dataTable = m_dataSet.Tables[0];
            List<string> availableFields = new List<string>();
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                availableFields.Add(dataTable.Columns[i].ColumnName);
            }
            return availableFields;
        }
    }
}
