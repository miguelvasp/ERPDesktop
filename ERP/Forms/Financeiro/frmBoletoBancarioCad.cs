using ERP.DAL;
using ERP.Models;
using ERP.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmBoletoBancarioCad : Form
    {
        public BoletoBancarioDAL dal = new BoletoBancarioDAL();
        public ContasReceberDAL pDal = new ContasReceberDAL();
        BoletoBancario b = new BoletoBancario();
        public frmBoletoBancarioCad(BoletoBancario pb)
        {
            b = pb;
            InitializeComponent(); 
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void frmAutoridadeCad_Load(object sender, EventArgs e)
        {
            CarregaDados();
        }

        private void frmAutoridadeCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            var rec = new ContasReceberDAL().getRecebimentoForBoleto(Convert.ToInt32(b.IdContasReceber));
            txtCliente.Text = rec.RazaoSocial;
            txtDocumento.Text = rec.Documento;
            txtValorTitulo.Text = rec.ValorTitulo.ToString();
            txtValorLiquido.Text = rec.ValorLiquido.ToString();

            txtCNome.Text = b.CedenteNome;
            txtCNPJ.Text = b.CedenteCNPJ;
            txtCEndereco.Text = b.CedenteEndereco;
            txtBanco.Text = b.CedenteBanco;
            txtAgencia.Text = b.CedenteAgencia;
            txtConta.Text = b.CedenteConta;
            txtCarteira.Text = b.CedenteCarteira;
            txtModalidade.Text = b.CedenteModalidade;
            txtConvenio.Text = b.CedenteConvenio;
            txtCodCedente.Text = b.CedenteCodCedente;

            txtSNome.Text = b.SacadoNome;
            txtSDocumento.Text = b.SacadoDocumento;
            txtSEndereco.Text = b.SacadoEndereco;
            txtCidade.Text = b.SacadoCidade;
            txtBairro.Text = b.SacadoBairro;
            txtCEP.Text = b.SacadoCEP;
            txtUF.Text = b.SacadoUF;

            txtNossoNumero.Text = b.BoletoNossoNumero;
            txtParcela.Text = b.BoletoParcelaNumero.ToString();
            txtNumParcelas.Text = b.BoletoParcelaTotal.ToString();
            txtQuantidade.Text = b.BoletoQuantidade.ToString();
            TXTValorUnitario.Text = b.BoletoValorUnitario.ToString();
            txtValorDocumento.Text = b.BoletoValorDocumento.ToString();
            txtDataDocumento.Text = Convert.ToDateTime(b.BoletoDataDocumento).ToShortDateString();
            txtVencimento.Text = Convert.ToDateTime(b.BoletoDataVencimento).ToShortDateString();
            txtDataProcessamento.Text = Convert.ToDateTime(b.BoletoDataProcessamento).ToShortDateString();
            lbStatus.Text = "Status: " + b.BoletoStatus;
            lbBoleto.Text = "Boleto N°:" + b.IdBoleto.ToString().PadLeft(7, '0');
            lbData.Text = b.BoletoDataPagamento == null ? "" : "Data Pagamento:" + Convert.ToDateTime(b.BoletoDataPagamento).ToShortDateString();

            if(b.BoletoStatus != "Emitido")
            {
                toolStripButton1.Enabled = false;
                btnConfirma.Enabled = false;
                btnCancelaPagamento.Enabled = false;
                button1.Enabled = false;
            }

        }
        

         

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if(Util.Aplicacao.ShowQuestionMessage("Deseja confirmar pagamento do Boleto?") == DialogResult.Yes)
            {
                ContasReceber cp = pDal.GetByID(Convert.ToInt32(b.IdContasReceber));
                ContasReceberBaixa r = new ContasReceberBaixa();
                r.IdContasReceberAberto = b.IdContasReceberAberto;
                r.DataPagamento = DateTime.Now;
                r.Documento = "BL" + b.IdBoleto.ToString().PadLeft(6, '0');
                r.Observacao = "Pagamento efetuado por meio de boleto bancário";
                r.Valor = b.BoletoValorDocumento;
                r.IdContaBancaria = b.IdContaBancaria;
                r.Liquidada = true;
                pDal.BaixasDal.Insert(r);
                pDal.BaixasDal.Save();
                 

                b.IdContasReceberBaixa = r.IdContasReceberBaixa;
                b.BoletoDataPagamento = DateTime.Now;
                b.BoletoStatus = "Pago";
                dal.Update(b);
                dal.Save(); 
                pDal.CalculaRecebimento(cp);

                Util.Aplicacao.ShowMessage("Boleto confirmado com sucesso!");

                toolStripButton1.Enabled = false;
                btnConfirma.Enabled = false;
                btnCancelaPagamento.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void btnCancelaPagamento_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja cancelar o boleto bancário?") == DialogResult.Yes)
            {
                b.BoletoStatus = "Cancelado";
                dal.Update(b);
                dal.Save();
                toolStripButton1.Enabled = false;
                btnConfirma.Enabled = false;
                btnCancelaPagamento.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            BLL.BLBoletoBancario bl = new BLL.BLBoletoBancario();
            string path = bl.GerarBoleto(b);
           // VisualizadorGenerico frmv = new VisualizadorGenerico(b.IdBoleto);
           // frmv.ShowDialog();
            Financeiro.frmImprimeBoleto frmi = new Financeiro.frmImprimeBoleto();
            frmi.pictureBox1.ImageLocation = path;
            frmi.ShowDialog();
            //List<BoletoBancario> lista = new List<BoletoBancario>();
            //lista.Add(b);
            //VisualizadorGenerico frm = new VisualizadorGenerico("Boleto");
            //frm.Parametro1 = path;
            //frm.Boletos = lista;
            //frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b.BoletoInstrucoes = txtInstrucoes.Text;
            dal.Update(b);
            dal.Save();
            Util.Aplicacao.ShowMessage("Instruções salvas");
        }
    }
}

