using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPedidoVendaApuracaoImposto : RibbonForm
    {
        public PedidoVendaItemApuracaoImpostoDAL dal;
        PedidoVendaItemApuracaoImposto ai = new PedidoVendaItemApuracaoImposto();
        int IdItem;
        public frmPedidoVendaApuracaoImposto(int Id)
        {

            IdItem = Id;
            InitializeComponent();

            
        }

        public frmPedidoVendaApuracaoImposto()
        { 
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmAutoridadeCad_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            ai = dal.GetByID(IdItem); 
            CarregaDados();  
        }

        private void CarregaCombos()
        {
            cboCodigoImposto.DataSource = new CodigoImpostoDAL().GetCombo();
            cboCodigoImposto.DisplayMember = "Text";
            cboCodigoImposto.ValueMember = "iValue";
            cboCodigoImposto.SelectedIndex = -1;

            cboCodigoTributacao.DataSource = new CodigoTributacaoDAL().GetCombo();
            cboCodigoTributacao.DisplayMember = "Text";
            cboCodigoTributacao.ValueMember = "iValue";
            cboCodigoTributacao.SelectedIndex = -1;

            cboCodigoTributacaoAjustado.DataSource = new CodigoTributacaoDAL().GetCombo();
            cboCodigoTributacaoAjustado.DisplayMember = "Text";
            cboCodigoTributacaoAjustado.ValueMember = "iValue";
            cboCodigoTributacaoAjustado.SelectedIndex = -1;
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
            cboCodigoImposto.SelectedValue = ai.IdCodigoImposto == null ? 0 : ai.IdCodigoImposto;
            cboCodigoTributacao.SelectedValue = ai.IdCodigoTributacao == null ? 0 : ai.IdCodigoTributacao;
            cboCodigoTributacaoAjustado.SelectedValue = ai.IdCodigoTributacaoAjustado == null ? 0 : ai.IdCodigoTributacaoAjustado;
            txtAliquota.Text = ai.Aliquota == null ? "" : ai.Aliquota.ToString();
            txtBaseValor.Text = ai.BaseValor == null ? "" : ai.BaseValor.ToString();
            txtBaseValorAjustado.Text = ai.BaseValorAjustado == null ? "" : ai.BaseValorAjustado.ToString();
            txtDataDocumento.Text = ai.DataDocumento == null ? "" : ai.DataDocumento.ToString();
            txtDataLancamento.Text = ai.DataLancamento == null ? "" : ai.DataLancamento.ToString();
            txtDataRegistroIVA.Text = ai.DataRegistroIVA == null ? "" : ai.DataRegistroIVA.ToString();
            txtDataVencimentoImposto.Text = ai.DataVencimentoImposto == null ? "" : ai.DataVencimentoImposto.ToString();
            txtEncargoImposto.Text = ai.EncargoImposto == null ? "" : ai.EncargoImposto.ToString();
            txtOutroValorBase.Text = ai.OutroValorBase == null ? "" : ai.OutroValorBase.ToString();
            txtOutroValorImposto.Text = ai.OutroValorImposto == null ? "" : ai.OutroValorImposto.ToString();
            txtPercentualReducaoImposto.Text = ai.PercentualDeReducaoImposto == null ? "" : ai.PercentualDeReducaoImposto.ToString();
            txtQuantidade.Text = ai.Quantidade == null ? "" : ai.Quantidade.ToString();
            txtValorAjustado.Text = ai.ValorAjustado == null ? "" : ai.ValorAjustado.ToString();
            txtValorBaseIsencao.Text = ai.ValorBaseIsencao == null ? "" : ai.ValorBaseIsencao.ToString();
            txtValorFiscal.Text = ai.ValorFiscal == null ? "" : ai.ValorFiscal.ToString();
            txtValorFiscalAjustado.Text = ai.ValorFiscalAjustado == null ? "" : ai.ValorFiscalAjustado.ToString();
            txtValorImposto.Text = ai.ValorImposto == null ? "" : ai.ValorImposto.ToString();
            txtValorIsencaoImposto.Text = ai.ValorIsencaoImposto == null ? "" : ai.ValorIsencaoImposto.ToString();
            chkManterDadosAjustados.Checked = Convert.ToBoolean(ai.ManterDadosAjustados);
            // Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

        }   

        private void btnAdiciona_Click(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    //Set Values//
                    ai.Aliquota = null;
                    ai.BaseValor = null;
                    ai.BaseValorAjustado = null;
                    ai.DataDocumento = null;
                    ai.DataLancamento = null;
                    ai.DataRegistroIVA = null;
                    ai.DataVencimentoImposto = null;
                    ai.EncargoImposto = null;
                    ai.IdCodigoImposto = null;
                    ai.IdCodigoTributacao = null;
                    ai.IdCodigoTributacaoAjustado = null;
                    ai.OutroValorBase = null;
                    ai.OutroValorImposto = null;
                    ai.PercentualDeReducaoImposto = null;
                    ai.Quantidade = null;
                    ai.ValorAjustado = null;
                    ai.ValorBaseIsencao = null;
                    ai.ValorFiscal = null;
                    ai.ValorFiscalAjustado = null;
                    ai.ValorImposto = null;
                    ai.ValorIsencaoImposto = null;
                    if (!String.IsNullOrEmpty(cboCodigoImposto.Text)) ai.IdCodigoImposto = Convert.ToInt32(cboCodigoImposto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCodigoTributacao.Text)) ai.IdCodigoTributacao = Convert.ToInt32(cboCodigoTributacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCodigoTributacaoAjustado.Text)) ai.IdCodigoTributacaoAjustado = Convert.ToInt32(cboCodigoTributacaoAjustado.SelectedValue);
                    if (!String.IsNullOrEmpty(txtAliquota.Text)) ai.Aliquota = Convert.ToDecimal(txtAliquota.Text);
                    if (!String.IsNullOrEmpty(txtBaseValor.Text)) ai.BaseValor = Convert.ToDecimal(txtBaseValor.Text);
                    if (!String.IsNullOrEmpty(txtBaseValorAjustado.Text)) ai.BaseValorAjustado = Convert.ToDecimal(txtBaseValorAjustado.Text);
                    if (!String.IsNullOrEmpty(txtDataDocumento.Text)) ai.DataDocumento = Convert.ToDateTime(txtDataDocumento.Text);
                    if (!String.IsNullOrEmpty(txtDataLancamento.Text)) ai.DataLancamento = Convert.ToDateTime(txtDataLancamento.Text);
                    if (!String.IsNullOrEmpty(txtDataRegistroIVA.Text)) ai.DataRegistroIVA = Convert.ToDateTime(txtDataRegistroIVA.Text);
                    if (!String.IsNullOrEmpty(txtDataVencimentoImposto.Text)) ai.DataVencimentoImposto = Convert.ToDateTime(txtDataVencimentoImposto.Text);
                    if (!String.IsNullOrEmpty(txtEncargoImposto.Text)) ai.EncargoImposto = Convert.ToDecimal(txtEncargoImposto.Text);
                    if (!String.IsNullOrEmpty(txtOutroValorBase.Text)) ai.OutroValorBase = Convert.ToDecimal(txtOutroValorBase.Text);
                    if (!String.IsNullOrEmpty(txtOutroValorImposto.Text)) ai.OutroValorImposto = Convert.ToDecimal(txtOutroValorImposto.Text);
                    if (!String.IsNullOrEmpty(txtPercentualReducaoImposto.Text)) ai.PercentualDeReducaoImposto = Convert.ToDecimal(txtPercentualReducaoImposto.Text);
                    if (!String.IsNullOrEmpty(txtQuantidade.Text)) ai.Quantidade = Convert.ToDecimal(txtQuantidade.Text);
                    if (!String.IsNullOrEmpty(txtValorAjustado.Text)) ai.ValorAjustado = Convert.ToDecimal(txtValorAjustado.Text);
                    if (!String.IsNullOrEmpty(txtValorBaseIsencao.Text)) ai.ValorBaseIsencao = Convert.ToDecimal(txtValorBaseIsencao.Text);
                    if (!String.IsNullOrEmpty(txtValorFiscal.Text)) ai.ValorFiscal = Convert.ToDecimal(txtValorFiscal.Text);
                    if (!String.IsNullOrEmpty(txtValorFiscalAjustado.Text)) ai.ValorFiscalAjustado = Convert.ToDecimal(txtValorFiscalAjustado.Text);
                    if (!String.IsNullOrEmpty(txtValorImposto.Text)) ai.ValorImposto = Convert.ToDecimal(txtValorImposto.Text);
                    if (!String.IsNullOrEmpty(txtValorIsencaoImposto.Text)) ai.ValorIsencaoImposto = Convert.ToDecimal(txtValorIsencaoImposto.Text);
                    ai.ManterDadosAjustados = chkManterDadosAjustados.Checked;
                    if (ai.IdPedidoVendaItemApuracaoImposto == 0)
                    {
                        dal.Insert(ai);
                    }
                    else
                    {
                        dal.Update(ai);
                    }

                    dal.Save();


                    BLL.BLImpostoEncargosVendas blimposto = new BLL.BLImpostoEncargosVendas();
                    blimposto.dal = dal;
                    blimposto.GeraImpostos((int)ai.IdPedidoVendaItem);

                    CarregaDados();
                    this.Close();
                   // Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                } 
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
                this.Close();
                CarregaDados();
                //Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            
        } 
    }
}

