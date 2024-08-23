using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.DAL;
using ERP.Models;
using ERP.BLL;

namespace ERP.Faturamento
{
    public partial class frmNotaFiscalEnviaEmail : Form
    {
        List<int> NotasSelecionadas = new List<int>();
        public frmNotaFiscalEnviaEmail(List<int> pNotasSelecionadas)
        {
            NotasSelecionadas = pNotasSelecionadas;
            InitializeComponent();
        }

        private void frmNotaFiscalEnviaEmail_Load(object sender, EventArgs e)
        {
            //Verifica se a pasta ERP / Temp existe nos documentos
            string Path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            if (!Directory.Exists(Path + "\\ERP MGA\\Temp"))
            {
                Directory.CreateDirectory(Path + "\\ERP MGA");
                Directory.CreateDirectory(Path + "\\ERP MGA\\Temp");
            }


            foreach(int i in NotasSelecionadas)
            {
                //Gera os arquivos
                NotaFiscalDAL ndal = new NotaFiscalDAL();
                NotaFiscal n = ndal.GetByID(i);
                BLNFe blNFE = new BLNFe("", n, ndal);
                var Danfe = blNFE.GetDanfeData(true);
                textBox1.Text += "Preparando os arquivos para envio da nota " + blNFE.strChaveNotaFiscal + "\r\n";
                frmDanfePreview pv = new frmDanfePreview(Danfe, 3);
                pv.Path = Path + "\\ERP MGA\\Temp"; 
                pv.ShowDialog();
                //Aguarda 
                System.Threading.Thread.Sleep(3000);

                var Emails = blNFE.GetNotaFiscalEmails();
                if(Emails != null && Emails.Count > 0)
                {
                    textBox1.Text += "Enviando email para ";
                    foreach(string s in Emails)
                    {
                        textBox1.Text += s + ", ";
                    }
                    textBox1.Text += "\r\n";
                    Util.Util.EnviarEmailNFe(Emails, blNFE.strChaveNotaFiscal);
                }
                else
                {
                    textBox1.Text += "Não foi localizado um email valido para envio dos arquivos.";
                }
                textBox1.Text += "\r\n";
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}
