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
using ERP.DAL;
using ERP.Financeiro;

namespace ERP
{
    public partial class frmContaBancariaCad : RibbonForm
    {
        public ContaBancariaDAL dal = new ContaBancariaDAL();
        ContaBancaria conta = new ContaBancaria();
        BancoDAL dalb = new BancoDAL();

        public frmContaBancariaCad(ContaBancaria pconta)
        {
            conta = pconta;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            conta = new ContaBancaria();
            lbCodigo.Text = "0";
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            Salvar();    
        }

        private void Salvar()
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                conta.IdContaContabil = null;
                conta.IdPais = null;
                 
                conta.IdBanco = Convert.ToInt32(cboBanco.SelectedValue);
                conta.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                conta.NomeConta = txtNomeConta.Text;
                conta.Agencia = txtAgencia.Text;
                conta.DigitoAgencia = txtDigitoAgencia.Text;
                conta.Conta = txtConta.Text;
                conta.DigitoConta = txtDigitoConta.Text;
                conta.DataInicio = DateTime.Parse(txtInicio.Text);
                conta.SaldoInicial = Convert.ToDecimal(txtSaldo.Text);
                conta.UltimoCheque = Convert.ToInt32(txtCheque.Text);
                conta.DataConciliacao = DateTime.Parse(txtConciliacao.Text);
                conta.IdContaBancaria = Convert.ToInt32(lbCodigo.Text);
                conta.CodigoSwift = txtCodigoSwift.Text;
                conta.IBAN = txtIban.Text;
                conta.EmiteBoleto = chkEmiteBoleto.Checked;
                conta.BoletoCarteira = txtBoletoCarteira.Text;
                conta.BoletoModalidade = txtBoletoModalidade.Text;
                conta.BoletoConvenio = txtBoletoConvenio.Text;
                conta.BoletoCodCedente = txtCodigoCedente.Text;

                conta.ConciliacaoAutomatica = Convert.ToInt32(cboConciliacaoAutomatica.SelectedValue);
                if (!String.IsNullOrEmpty(cboContaContabil.Text))
                    conta.IdContaContabil = Convert.ToInt32(cboContaContabil.SelectedValue);

                if (!String.IsNullOrEmpty(cboPais.Text))
                    conta.IdPais = Convert.ToInt32(cboPais.SelectedValue);

                if (conta.IdContaBancaria == 0)
                {
                    dal.Insert(conta);
                }
                else
                {
                    dal.Update(conta);
                }

                dal.Save();
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                Util.Aplicacao.ShowMessage("Por favor verifique as informações faltantes.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Qualquer alteração efetuada será perdida, deseja continuar?") == System.Windows.Forms.DialogResult.Yes)
            {
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
            {
                int id = conta.IdContaBancaria;
                dal.Delete(id);
                dal.Save();
                this.Close();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregaDados();
        }

        private void frmContaBancariaCad_Load(object sender, EventArgs e)
        {
            //Carrega o combo
            var bancos = dalb.Get().OrderBy(x => x.NomeBanco).ToList();
            cboBanco.DataSource = bancos;
            cboBanco.ValueMember = "IdBanco";
            cboBanco.DisplayMember = "NomeBanco";
            cboBanco.SelectedIndex = -1;

            //carrega paises
            cboPais.DataSource = new PaisDAL().GetCombo();
            cboPais.DisplayMember = "Text";
            cboPais.ValueMember = "iValue";
            cboPais.SelectedIndex = -1;

            List<ComboItem> ConsolidacaoAutomatica = new List<ComboItem>();
            ConsolidacaoAutomatica.Add(new ComboItem() { iValue = 1, Text = "Sim" });
            ConsolidacaoAutomatica.Add(new ComboItem() { iValue = 2, Text = "Não" });
            cboConciliacaoAutomatica.DataSource = ConsolidacaoAutomatica;
            cboConciliacaoAutomatica.DisplayMember = "Text";
            cboConciliacaoAutomatica.ValueMember = "iValue";

            cboContaContabil.DataSource = new ContaContabilDAL().GetCombo();
            cboContaContabil.DisplayMember = "Text";
            cboContaContabil.ValueMember = "iValue";
            cboContaContabil.SelectedIndex = -1;

            if (conta.IdContaBancaria == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void CarregaDados()
        {
            cboBanco.SelectedValue = conta.IdBanco;
            txtNomeConta.Text = conta.NomeConta;
            txtAgencia.Text = conta.Agencia;
            txtDigitoAgencia.Text = conta.DigitoAgencia;
            txtConta.Text = conta.Conta;
            txtDigitoConta.Text = conta.DigitoConta;
            txtInicio.Text = conta.DataInicio.ToShortDateString();
            txtSaldo.Text = conta.SaldoInicial.ToString();
            txtCheque.Text = conta.UltimoCheque.ToString();
            txtConciliacao.Text = conta.DataConciliacao.ToShortDateString();
            lbCodigo.Text = conta.IdContaBancaria.ToString();
            cboPais.SelectedValue = conta.IdPais == null ? 0 : Convert.ToInt32(conta.IdPais);
            txtCodigoSwift.Text = conta.CodigoSwift;
            txtIban.Text = conta.IBAN;
            cboConciliacaoAutomatica.SelectedValue = conta.ConciliacaoAutomatica == null ? 0 : Convert.ToInt32(conta.ConciliacaoAutomatica);
            cboContaContabil.SelectedValue = conta.IdContaContabil == null ? 0 : Convert.ToInt32(conta.IdContaContabil);
            chkEmiteBoleto.Checked = conta.EmiteBoleto == null ? false : Convert.ToBoolean(conta.EmiteBoleto);
            txtBoletoCarteira.Text = conta.BoletoCarteira;
            txtBoletoModalidade.Text = conta.BoletoModalidade;
            txtBoletoConvenio.Text = conta.BoletoConvenio;
            txtCodigoCedente.Text = conta.BoletoCodCedente;

            ChequeDAL chDal = new ChequeDAL();
            txtCheque.Text = chDal.UltimoCheque(Convert.ToInt32(conta.IdContaBancaria)).ToString();
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            if(conta.IdContaBancaria == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados da conta bancária antes de adicionar cheques.");
                return;
            }

            int Cheque = 0;
            if(!String.IsNullOrEmpty(txtCheque.Text))
            {
                Cheque = Convert.ToInt32(txtCheque.Text);
            }
            Cheque++;
            string NomeConta = String.IsNullOrEmpty(txtNomeConta.Text) ? cboBanco.Text + " Ag:" + txtAgencia.Text + " CC: " + txtConta.Text : txtNomeConta.Text; 
            frmGeraCheque frmCheque = new frmGeraCheque(conta.IdContaBancaria, Cheque, txtNomeConta.Text);
            frmCheque.ShowDialog();
            Cheque = frmCheque.UltimoCheque;
            CarregaDados(); 
        }
    }
}
