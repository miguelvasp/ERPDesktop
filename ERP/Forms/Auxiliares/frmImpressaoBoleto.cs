using ERP.Util;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERP.Auxiliares
{
    public partial class frmImpressaoBoleto : Form
    {
        public frmImpressaoBoleto()
        {
            InitializeComponent();
        }

        private string GerarImagem()
        {
            string address = webBrowser.Url.ToString();
            int width = 670;
            int height = 805;

            int webBrowserWidth = 670;
            int webBrowserHeight = 805;

            Bitmap bmp = WebsiteThumbnailImageGenerator.GetWebSiteThumbnail(address, webBrowserWidth, webBrowserHeight, width, height);

            string file = Path.Combine(Environment.CurrentDirectory, "boleto.bmp");

            bmp.Save(file);

            return file;
        }

        private void visualizarImagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisualizarImagem frm = new frmVisualizarImagem(GerarImagem());
            frm.ShowDialog();
        }
    }
}
