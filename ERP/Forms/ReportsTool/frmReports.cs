using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.DAL;
using ERP.Models;

namespace ERP.Forms.ReportsTool
{
    public partial class frmReports : Form
    {
        ReportCuboDAL odal = new ReportCuboDAL();
        ReportFieldsDAL idal = new ReportFieldsDAL();
        ReportHeaderDAL dal = new ReportHeaderDAL();
        ReportCubo origem = new ReportCubo();
        List<ReportCuboFields> CamposDisponiveis = new List<ReportCuboFields>();
        ReportHeader r = new ReportHeader();
        List<ReportFields> campos = new List<ReportFields>();
        List<string> Filtros = new List<string>();


        string html = "";

        List<ReportHeader> relatorios = new List<ReportHeader>();

        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            pnlFiltros.Height = 0;
            CarregaRelatorios();
        }

        private void CarregaRelatorios()
        {
            relatorios = dal.Get().OrderBy(x => x.Nome).ToList();
            cboReport.Items.Clear();
            foreach (var i in relatorios)
            {
                cboReport.Items.Add(i.Nome);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmAddReport frma = new frmAddReport();
            frma.ShowDialog();
            CarregaRelatorios();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Control[] a = this.Controls.Find("comboBox4", true);
            if (a.Count() > 0)
            {
                MessageBox.Show((a[0] as ComboBox).Text);
            }

        }

        private Panel createPanel(string Origem, string Nome, string Titulo, string Tipo, string range)
        {
            int largura = this.Width / 5;
            Panel p = new Panel();
            p.Width = largura - 10;
            p.Height = 50;
            p.Controls.Add(new Label() { Left = 11, Top = 4, Text = Titulo });

            if (Tipo == "TextBox")
            {
                TextBox t = new TextBox() { Name = "txt" + Nome, Left = 11, Top = 24, Width = largura - 24, Tag = range };
                Filtros.Add("txt" + Nome);
                p.Controls.Add(t);
                t.BringToFront();
            }

            if (Tipo == "Combo")
            {
                var ds = idal.getFiltroCombo(Origem, Nome);
                ComboBox cb = new ComboBox() { Name = "cbo" + Nome, Left = 11, Top = 24, Width = largura - 24, DropDownWidth = 500, DataSource = ds, Tag = range };
                Filtros.Add("cbo" + Nome);
                cb.SelectedIndex = -1;
                p.Controls.Add(cb);
                cb.BringToFront();
            }

            if (Tipo == "maskedTextBox")
            {
                MaskedTextBox mk = new MaskedTextBox() { Name = "txt" + Nome, Left = 11, Top = 24, Width = largura - 24, Mask = "99/99/9999", Tag = range };
                Filtros.Add("txt" + Nome);
                p.Controls.Add(mk);
                mk.BringToFront();
            }


            return p;
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            var rep = relatorios.Where(x => x.Nome == cboReport.Text).FirstOrDefault();
            campos = idal.getByReportId(rep.IdReportHeader);
            origem = odal.GetByID(Convert.ToInt32(rep.IdRepCubo));
            CamposDisponiveis = origem.Campos.ToList();
            Filtros.Clear();


            //Monta a tela de filtros
            tbl.Controls.Clear();
            foreach (var z in campos.Where(x => !string.IsNullOrEmpty(x.Filtro)).ToList())
            {
                var c = CamposDisponiveis.Where(x => x.IdReportCuboFields == z.IdReportCuboFields).FirstOrDefault();
                if (c != null)
                {
                    //um campo pode ter mais de um filtro, eles sao agrupados separados por pornto e virgula
                    string[] filtros = z.Filtro.Split(';');
                    foreach (var s in filtros)
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            tbl.Controls.Add(createPanel(origem.NomeView, c.Nome, c.Titulo, c.TipoFiltro, s));
                        }
                    }
                }
            }
            Panel p = new Panel();
            p.Width = 300;
            p.Height = 50;
            Button btn = btnPesquisar;
            p.Controls.Add(btn);
            btn.Top = 24;
            btn.Left = 11;
            tbl.Controls.Add(p);
            pnlFiltros.Height = 450;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string sql = "SELECT ";
            //monta o select
            foreach(var i in campos)
            {
                var cp = CamposDisponiveis.Where(x => x.IdReportCuboFields == i.IdReportCuboFields).FirstOrDefault();
                sql += " " + cp.Nome + ",";
            }

            sql = sql.TrimEnd(',');

            sql += $" FROM {origem.NomeView} WHERE 1 = 1";

            foreach(string s in Filtros)
            {
                Control[] a = this.Controls.Find(s, true);
                if (a.Count() > 0)
                {
                    if(!string.IsNullOrEmpty(a[0].Text))
                    {
                        string aux = s.Remove(0, 3);
                        var cp = CamposDisponiveis.Where(x => x.Nome == aux).FirstOrDefault();
                        var cmp = campos.Where(x => x.IdReportCuboFields == cp.IdReportCuboFields).FirstOrDefault();
                        string[] qtdFiltros = cmp.Filtro.Split(';');
                        foreach(var f in qtdFiltros)
                        {
                            if (!string.IsNullOrEmpty(f))
                            {
                                if (cp.TipoCampo == "data")
                                {
                                    DateTime dt = Convert.ToDateTime(a[0].Text);
                                    sql += $" AND convert(varchar, {aux}, 112) {f} '{dt.ToString("yyyyMMdd")}'";
                                }
                                else if(cp.TipoCampo == "número")
                                {
                                    sql += $" AND {aux} {f} {a[0].Text.Replace(".", "").Replace(",", ".")}";
                                }
                                else
                                {
                                    if(f == "=")
                                    {
                                        sql += $" AND {aux} like '%{a[0].Text}%'";
                                    }
                                    else
                                    {
                                        sql += $" AND {aux} {f} '{a[0].Text}'";
                                    }
                                }
                            }
                        } 
                    } 
                }
            }

            DataTable dtC = dal.getReportData(sql);
            string header = "";
            string rows = "";

            //Monta o html

            //Verifica se existe algum agrupamento
            if(campos.Where(x => x.Agrupamento == true).Count() == 0)
            {
                //Carrega os dados sem agrupamentos
            }


            pnlFiltros.Height = 0;
            CarregaHTML("");
        }


        private void CarregaHTML(string Campos)
        {
            html = "";
            html += "<!DOCTYPE html> ";
            html += "<html lang='en' xmlns='http://www.w3.org/1999/xhtml'>";
            html += "<head>";
            html += "    <meta charset='utf-8' />";
            html += "    <title></title>";
            html += "</head>";
            html += "";
            html += "<style>";
            html += "    table#customers {";
            html += "        font-size: 12px;";
            html += "        font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif;";
            html += "        border-collapse: collapse;";
            html += "        border-spacing: 0;";
            html += "        width: 100%;";
            html += "    }";
            html += "";
            html += "    #customers td, #customers th {";
            html += "        border: 1px solid #ddd;";
            html += "        text-align: left;";
            html += "        padding: 3px;";
            html += "    }";
            html += "";
            html += "    #customers tr:nth-child(even) {";
            html += "        background-color: #f2f2f2";
            html += "    }";
            html += "";
            html += "    #customers th {";
            html += "        padding-top: 11px;";
            html += "        padding-bottom: 11px;";
            html += "        background-color: #385372;";
            html += "        color: white;";
            html += "    }";
            html += "";
            html += "    .tabletest {";
            html += "        margin-top: 20px;";
            html += "        margin-bottom: 40px;";
            html += "        border-collapse: collapse;";
            html += "        border-spacing: 0;";
            html += "        width: 100%;";
            html += "    }";
            html += "        .tabletest,";
            html += "        .tabletest th,";
            html += "        .tabletest td {";
            html += "            padding: 3px;";
            html += "            text-align: left;";
            html += "        }";
            html += "    .tabletest2 {";
            html += "        font-size: 15px;";
            html += "        margin-top: 20px;";
            html += "        margin-bottom: 40px;";
            html += "        border-collapse: collapse;";
            html += "        width: 100%;";
            html += "    }";
            html += "";
            html += "        .tabletest2,";
            html += "        .tabletest2 th,";
            html += "        .tabletest2 td {";
            html += "            padding: 3px;";
            html += "            text-align: left;";
            html += "            border-bottom: 1px solid #ddd;";
            html += "        }";
            html += "";
            html += "    .tabletest3 {";
            html += "        border: 1px solid #ddd;";
            html += "        margin-top: 20px;";
            html += "        margin-bottom: 40px;";
            html += "        border-collapse: collapse;";
            html += "        border-spacing: 0;";
            html += "        width: 100%;";
            html += "    }";
            html += "";
            html += "        .tabletest3,";
            html += "        .tabletest3 th,";
            html += "        .tabletest3 td {";
            html += "            padding: 8px;";
            html += "            text-align: left;";
            html += "            border-bottom: 1px solid #ddd;";
            html += "        }";
            html += "";
            html += "    .tabletest4 {";
            html += "        margin-top: 20px;";
            html += "        margin-bottom: 40px;";
            html += "        border-collapse: collapse;";
            html += "        width: 100%;";
            html += "    }";
            html += "";
            html += "        .tabletest4,";
            html += "        .tabletest4 th,";
            html += "        .tabletest4 td {";
            html += "            padding: 8px;";
            html += "            text-align: left;";
            html += "            border-bottom: 1px solid #ddd;";
            html += "        }";
            html += "";
            html += "            .tabletest4 tr:hover {";
            html += "                background-color: #f5f5f5";
            html += "            }";
            html += "";
            html += "    .tabler2 {";
            html += "        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19) !important;";
            html += "        margin-top: 20px;";
            html += "        margin-bottom: 40px;";
            html += "        border-collapse: collapse;";
            html += "        border-spacing: 0;";
            html += "        width: 100%;";
            html += "    }";
            html += "";
            html += "        .tabler2,";
            html += "        .tabler2 th,";
            html += "        .tabler2 td {";
            html += "            border: none;";
            html += "            text-align: left;";
            html += "            padding: 8px;";
            html += "        }";
            html += "";
            html += "            .tabler2 tbody tr:nth-child(even) {";
            html += "                background-color: #f2f2f2";
            html += "            }";
            html += "";
            html += "    .tabler {";
            html += "        margin-top: 20px;";
            html += "        margin-bottom: 40px;";
            html += "        border-collapse: collapse;";
            html += "        border-spacing: 0;";
            html += "        width: 100%;";
            html += "    }";
            html += "";
            html += "        .tabler,";
            html += "        .tabler th,";
            html += "        .tabler td {";
            html += "            border: none;";
            html += "            text-align: left;";
            html += "            padding: 8px;";
            html += "        }";
            html += "";
            html += "            .tabler tbody tr:nth-child(even) {";
            html += "                background-color: #f2f2f2";
            html += "            }";
            html += "</style>";
            html += "";
            html += "";
            html += "<body>";
            html += "    <table id='customers'>";
            html += "        <tbody>";
            html += "            <tr>";
            html += "                <th>Company</th>";
            html += "                <th>Contact</th>";
            html += "                <th>Country</th>";
            html += "            </tr>";
            html += "            <tr>";
            html += "                <td>Alfreds Futterkiste</td>";
            html += "                <td>Maria Anders</td>";
            html += "                <td>Germany</td>";
            html += "            </tr>";
            html += "            <tr class='alt'>";
            html += "                <td>Berglunds snabbköp</td>";
            html += "                <td>Christina Berglund</td>";
            html += "                <td>Sweden</td>";
            html += "            </tr>";
            html += "            <tr>";
            html += "                <td>Centro comercial Moctezuma</td>";
            html += "                <td>Francisco Chang</td>";
            html += "                <td>Mexico</td>";
            html += "            </tr>";
            html += "            <tr class='alt'>";
            html += "                <td>Ernst Handel</td>";
            html += "                <td>Roland Mendel</td>";
            html += "                <td>Austria</td>";
            html += "            </tr>";
            html += "            <tr>";
            html += "                <td>Island Trading</td>";
            html += "                <td>Helen Bennett</td>";
            html += "                <td>UK</td>";
            html += "            </tr>";
            html += "            <tr class='alt'>";
            html += "                <td>Königlich Essen</td>";
            html += "                <td>Philip Cramer</td>";
            html += "                <td>Germany</td>";
            html += "            </tr>";
            html += "            <tr>";
            html += "                <td>Laughing Bacchus Winecellars</td>";
            html += "                <td>Yoshi Tannamuri</td>";
            html += "                <td>Canada</td>";
            html += "            </tr>";
            html += "            <tr class='alt'>";
            html += "                <td>Magazzini Alimentari Riuniti</td>";
            html += "                <td>Giovanni Rovelli</td>";
            html += "                <td>Italy</td>";
            html += "            </tr>";
            html += "        </tbody>";
            html += "    </table>";
            html += "</body>";
            html += "</html>";

            webBrowser1.Navigate("about:blank");
            if (webBrowser1.Document != null)
            {
                webBrowser1.Document.Write(string.Empty);
            }
            webBrowser1.DocumentText = html;
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
           // PrintHelpPage();
        }

        //private void PrintHelpPage()
        //{
        //    // Create a WebBrowser instance. 
        //    WebBrowser webBrowserForPrinting = new WebBrowser();

        //    // Add an event handler that prints the document after it loads.
        //    webBrowserForPrinting.DocumentCompleted +=
        //        new WebBrowserDocumentCompletedEventHandler(PrintDocument);

        //    // Set the Url property to load the document. 
        //    webBrowserForPrinting.Navigate("about:blank");
        //    if (webBrowserForPrinting.Document != null)
        //    {
        //        webBrowserForPrinting.Document.Write(string.Empty);
        //    }
        //    webBrowserForPrinting.DocumentText = html;
        //}

        //private void PrintDocument(object sender,
        //    WebBrowserDocumentCompletedEventArgs e)
        //{
        //    // Print the document now that it is fully loaded.
        //    ((WebBrowser)sender).ShowPrintDialog();

        //    // Dispose the WebBrowser now that the task is complete. 
        //    ((WebBrowser)sender).Dispose();
        //}
    }
}
