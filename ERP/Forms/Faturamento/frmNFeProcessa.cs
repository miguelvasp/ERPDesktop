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
using ERP.BLL;
using NFe_Util_2G;
using System.Threading;

namespace ERP.Faturamento
{
    public partial class frmNFeProcessa : Form
    {
        List<int> Notas;
        string Evento;
        public NotaFiscalDAL nfDal = new NotaFiscalDAL();
        string NomeCertificado;
        string XMLPath;
        public frmNFeProcessa(List<int> pNotas, string pEvento)
        {
            InitializeComponent();
            Notas = pNotas;
            Evento = pEvento;
        }

        private void frmNFeProcessa_Load(object sender, EventArgs e)
        {
            //Pega o nome do certificado
            if(Evento != "Impressao")
            {
                NomeCertificado = GetNomeCertificado();
                if (String.IsNullOrEmpty(NomeCertificado))
                {
                    Util.Aplicacao.ShowMessage("Nenhum certificado selecionado.");
                    this.Close();
                }
            }
            

            if(Evento == "Salvar")
            {
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog();
                XMLPath = f.SelectedPath;//@"C:\Users\migue\Desktop\Nova pasta (3)";// 
                if(String.IsNullOrEmpty(XMLPath))
                {
                    Util.Aplicacao.ShowMessage("Selecione o caminho onde os arquivos serão salvos.");
                    this.Close();
                }
            }

            


            //Processa as notas dependendo do evento.
            foreach(int id in Notas)
            {
                NotaFiscal nf = nfDal.GetByID(id);
                BLNFe blNfe = new BLNFe(NomeCertificado, nf, nfDal);
                switch(Evento)
                {
                    case "Salvar": SalvarXML(blNfe); break;
                    case "Validar": Validar(blNfe); break;
                    case "Transmitir": Transmitir(blNfe, nf); break;
                    case "Email": Email(nf); break;
                    case "Consultar": Consultar(blNfe, nf); break;
                    case "Impressao": Danfe(blNfe, nf); break;
                }
            }

            if(Evento == "Impressao")
            {
                this.Close();
            }
        }

        private void ImprimirDanfe(List<int> NotasSelecionadas)
        {

        }

        private void Danfe(BLNFe blNfe, NotaFiscal NF)
        {
            string FileName = blNfe.GeraDanfe();
            System.Diagnostics.Process.Start(FileName);
        }

        private void Consultar(BLNFe blNfe, NotaFiscal NF)
        {
            if (NF.Protocolo == null && NF.NFConfirmada)
            {
                txtProcessa.Text += blNfe.ConsultarProcessamento(); 
                Thread.Sleep(2000);
            }
            else
            {
                txtProcessa.Text += $"A NF {NF.Numero} já possui um protocolo de autorização";
            }
        }

        private void Email(NotaFiscal nf)
        {
            throw new NotImplementedException();
        }

        private void Transmitir(BLNFe blNfe, NotaFiscal NF)
        {
            if(NF.Protocolo == null && NF.NFConfirmada)
            {
                txtProcessa.Text += "Transmitindo a NF "+ NF.Numero + "\r\n";
                txtProcessa.Text += blNfe.TransmitirNFe()+"\r\n";
                Thread.Sleep(2000);
                txtProcessa.Text += blNfe.ConsultarProcessamento() + "\r\n";
                txtProcessa.Text += "\r\n";
            } 
            else
            {
                txtProcessa.Text += "A NF " + NF.Numero + " já possui um protocolo de autorização\r\n";
            }
        }

        private void Validar(BLNFe blNfe)
        {
            string Msg = "";
            blNfe.ValidarXML(out Msg);
            txtProcessa.Text += Msg + "\r\n";
        }

        private void SalvarXML(BLNFe blNfe)
        {
            txtProcessa.Text += blNfe.SalvarXML(XMLPath) + "\r\n";
        }

        private string GetNomeCertificado()
        {
            NFe_Util_2G.Util objUtil = new NFe_Util_2G.Util();
            string Nome = "";
            string MsgResultado = "";
            objUtil.PegaNomeCertificado(ref Nome, out MsgResultado);
            //frmSelecionaCertificado frmCertif = new frmSelecionaCertificado();
            //frmCertif.ShowDialog();
            //Nome = frmCertif.NomeCertificado;
            return Nome;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
