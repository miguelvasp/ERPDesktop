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
using Microsoft.Reporting.WinForms;
using ERP.Properties;

namespace ERP.Relatorios
{
    public partial class VisualizadorGenerico : Form
    {
        public string Parametro1 = "";
        public string Tipo { get; set; }
        //Listas de dados
        public List<vwEstoqueSintetico> ConsultaEstoque = new List<vwEstoqueSintetico>();
        public List<InventarioEstoque> InventarioEstoque = new List<Models.InventarioEstoque>();
        public List<BoletoBancario> Boletos = new List<BoletoBancario>();
        public VisualizadorGenerico(string pTipo)
        {
            Tipo = pTipo;
            InitializeComponent();
        }

        private void VisualizadorGenerico_Load(object sender, EventArgs e)
        {
           
            reportViewer1.Reset();
            reportViewer1.ProcessingMode = ProcessingMode.Local; 
            switch(Tipo)
            {
                case "Boleto":
                    {
                        reportViewer1.LocalReport.ReportPath = @"Relatorios/RepBoleto.rdlc";
                        ReportDataSource rds = new ReportDataSource("ds", Boletos);
                        ReportParameter[] reportParams = new ReportParameter[1];
                        reportParams[0] = new ReportParameter("Img", "File://" + Parametro1);
                        reportViewer1.LocalReport.EnableExternalImages = true;
                        this.reportViewer1.LocalReport.SetParameters(reportParams);
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(rds);
                    }
                    break;
                case "ConsultaEstoque":
                    { 
                        reportViewer1.LocalReport.ReportPath = @"Relatorios/rpConsultaEstoque.rdlc";
                        ReportDataSource rds = new ReportDataSource("ds", ConsultaEstoque);
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(rds);
                    }
                    break;
                case "InventarioEstoque":
                    {
                        reportViewer1.LocalReport.ReportPath = @"Relatorios/InventarioEstoque.rdlc";
                        var inv = InventarioEstoque.Select(x => new {
                            Deposito = x.Deposito == null ? "" : x.Deposito.Descricao,
                            Armazem = x.Armazem == null ? "" : x.Armazem.Descricao,
                            Produto = x.Produto.NomeProduto,
                            VariantesCor = x.VariantesCor == null ? "" : x.VariantesCor.Descricao,
                            VariantesEstilo = x.VariantesEstilo == null ? "" : x.VariantesEstilo.Descricao,
                            VariantesTamanho = x.VariantesTamanho == null ? "" : x.VariantesTamanho.Descricao,
                            Unidade = x.Unidade == null ? "" : x.Unidade.UnidadeMedida,
                            QtdeEstoque = x.QtdeEstoque,
                            QtdeInventario = x.QtdeInventario,
                            Status = x.Status
                        }).ToList();
                        ReportDataSource rds = new ReportDataSource("ds", inv);
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(rds);
                    }
                    break;
            }
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout); 
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
           
        }
    }
}
