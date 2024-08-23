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
using ERP.BLL;
using ERP.ModelView;
using ERP.DAL;
using System.Drawing.Printing;

namespace ERP.Faturamento
{
    public partial class frmSelecionaDanfe : Form
    {
        List<int> NotasSelecionadas;
        NotaFiscalDAL ndal = new NotaFiscalDAL();
        public frmSelecionaDanfe(List<int> pNotasSelecionadas)
        {
            NotasSelecionadas = pNotasSelecionadas;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "";
            int Option = 0;
            PrinterSettings p = new PrinterSettings();
            if (rbImprimir.Checked)
            {
                //PrintDialog print = new PrintDialog();
                //print.ShowDialog();
                //p = print.PrinterSettings;
                Option = 1;
            }
            if (rbVizualizar.Checked) Option = 2;
            if (rbPDF.Checked)
            {
                Option = 3;
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog();
                path = f.SelectedPath;
            }
             

            foreach(int id in NotasSelecionadas)
            {
                NotaFiscal n = ndal.GetByID(id);
                BLNFe blNFE = new BLNFe("", n, ndal);
                var Danfe = blNFE.GetDanfeData();
                frmDanfePreview pv = new frmDanfePreview(Danfe, Option);
                pv.Path = path;
                pv.p = p;
                pv.ShowDialog();
            } 
            
            
            this.Close();
            
        }

        private void frmSelecionaDanfe_Load(object sender, EventArgs e)
        {
            //if(NotasSelecionadas.Count > 1)
            //{
            //    rbVizualizar.Enabled = false;
            //}
        }
    }
}
