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
using ERP.ModelView;
using ERP.CrystalReports;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System.IO;

namespace ERP.CrystalReports
{
    public partial class frmCrystalReportViewer : Form
    {
        //Lista de Classes que podem alimentar um Report
        //public IEnumerable<vwEstoqueSintetico> ConsultaEstoque;
        //public int Id = 0;
        public List<FiltroRelatorio> FiltrosRelatorio = new List<FiltroRelatorio>();

        private string path = AppDomain.CurrentDomain.BaseDirectory + "CrystalReports\\";

        string TipoRelatorio = "";
        public frmCrystalReportViewer(string pTipoRelatorio)
        {
            TipoRelatorio = pTipoRelatorio;
            InitializeComponent();
        }

        private void frmCrystalReportViewer_Load(object sender, EventArgs e)
        { 
            ReportDocument rep = new ReportDocument();
            string Server = Util.Util.GetAppSettings("Server");
            string Banco = Util.Util.GetAppSettings("Banco");
            string Usuario = Util.Util.GetAppSettings("Usuario");
            string Senha = Util.Util.GetAppSettings("Senha");
            string ReportName = ""; 

            switch (TipoRelatorio)
            {
                case "ComissaoVendedor": ReportName = "repComissaoVendedores.rpt"; break; 
                case "ContasPagarList":  ReportName = "repContasPagarList.rpt"; break; 
                case "ContasReceberList": ReportName = "repContasReceberList.rpt";  break; 
                case "Kardex": ReportName = "repKardex.rpt";  break; 
                case "NotaFiscalLista": ReportName = "repNotaFiscalLista.rpt"; break; 
                case "OrdemCompra": ReportName = "repOrdemCompra.rpt";  break; 
                case "OrdemProducao":  ReportName = "repOrdemProducao.rpt";  break; 
                case "PlanoProducao":  ReportName = "repPlanoProducao.rpt";  break;
                case "PedidoBalcao": ReportName = "PedidoVendaBalcao.rpt"; break;
                case "PedidoBalcaoLista": ReportName = "rptPedidoVendaBalcaoListaVendedor.rpt"; break;
                case "NotaPromissoria": ReportName = "rptNotaPromisoria.rpt"; break;
                case "relContasReceberAnalitico": ReportName = "rptContasRecebereAnalitico.rpt"; break;
                case "relContasReceberSintetico": ReportName = "rptContasRecebereSintetico.rpt"; break;
            }
            
            rep.Load(path + ReportName);
            rep.Database.Dispose();
            rep.SetDatabaseLogon(Usuario, Senha, Server, Banco);
            foreach (var i in FiltrosRelatorio)
            {
                rep.SetParameterValue(i.Nome, i.Valor);
            } 
            crystalReportViewer1.ToolPanelView = ToolPanelViewType.GroupTree; 
            crystalReportViewer1.ReportSource = rep;  
            var connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = Server;
            connectionInfo.DatabaseName = Banco;
            connectionInfo.Password = Senha;
            connectionInfo.UserID = Usuario;
            connectionInfo.Type = ConnectionInfoType.SQL;
            for (int i = 0; i < crystalReportViewer1.LogOnInfo.Count; i++)
            {
                crystalReportViewer1.LogOnInfo[i].ConnectionInfo = connectionInfo;
            }
            foreach (CrystalDecisions.CrystalReports.Engine.Table tbl in rep.Database.Tables)
            {
                TableLogOnInfo logon = tbl.LogOnInfo;
                logon.ConnectionInfo = connectionInfo;
                tbl.ApplyLogOnInfo(logon);
                tbl.Location = tbl.Location;
            }

            crystalReportViewer1.Refresh();

             
        }
    }
}
