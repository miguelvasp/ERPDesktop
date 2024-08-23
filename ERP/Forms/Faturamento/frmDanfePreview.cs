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
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.IO;
using System.Drawing.Imaging;

namespace ERP.Faturamento
{
    public partial class frmDanfePreview : Form
    {
        List<vwDanfe> lista;
        public string Path;
        public PrinterSettings p;
        int Option;

        private int m_currentPageIndex;
        private IList<Stream> m_streams;


        public frmDanfePreview(List<vwDanfe> plista, int pOption)
        {
            lista = plista;
            Option = pOption; // 1 Imprime ; 2 - Vizualiza; 3 - Gera PDF
            InitializeComponent();
        }

        private string GetDefaultPrinter()
        {
            string PrinterName = "";
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                    return settings.PrinterName;
            }
            return PrinterName;
        }

        private void frmDanfePreview_Load(object sender, EventArgs e)
        {

            ReportDataSource rds = new ReportDataSource("vDanfe", lista);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();

            if (Option == 1)
            {
                //reportViewer1.PrinterSettings = p;
                //// this.reportViewer1.PrintDialog(p);
                //// ReportPrintDocument RP = new ReportPrintDocument(reportViewer1.ServerReport);
                //RP.Print();
                ReportPrint rp = new ReportPrint();
                rp.Run(reportViewer1.LocalReport, rds);
                rp.Dispose();
                this.Close();
            }

            if (Option == 2) this.WindowState = FormWindowState.Maximized;


            if (Option == 3)
            {
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string filenameExtension;

                byte[] bytes = reportViewer1.LocalReport.Render(
                    "PDF", null, out mimeType, out encoding, out filenameExtension,
                    out streamids, out warnings);

                string Nome = Path + "\\" + lista[0].ChaveAut + ".pdf";

                using (FileStream fs = new FileStream(Nome, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
                this.Close();
            }
        }





        private void Export(LocalReport report)
        {
            string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
              "  <PageWidth>8.5in</PageWidth>" +
              "  <PageHeight>11in</PageHeight>" +
              "  <MarginTop>0.25in</MarginTop>" +
              "  <MarginLeft>0.25in</MarginLeft>" +
              "  <MarginRight>0.25in</MarginRight>" +
              "  <MarginBottom>0.25in</MarginBottom>" +
              "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        private Stream CreateStream(string name,  string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new FileStream(@"..\..\" + name +
               "." + fileNameExtension, FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new  Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Run(LocalReport report, ReportDataSource ds)
        { 
            report.DataSources.Add(ds);
            Export(report);
            m_currentPageIndex = 0;
            Print();
        }

        private void Print()
        {
            string printerName = GetDefaultPrinter();
            if (m_streams == null || m_streams.Count == 0)
                return;
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;
            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format( "Can't find printer \"{0}\".", printerName);
                MessageBox.Show(msg, "Print Error");
                return;
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.Print();
        }
    }
}
