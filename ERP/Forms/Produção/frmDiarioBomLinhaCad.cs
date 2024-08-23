using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmDiarioBomLinhaCad : RibbonForm
    {
        public DiarioBomLinhaDAL dal = new DiarioBomLinhaDAL();
        DiarioBomLinha c = new DiarioBomLinha();

        public frmDiarioBomLinhaCad(DiarioBomLinha pC)
        {
            c = pC;
            InitializeComponent();
        }

        public frmDiarioBomLinhaCad()
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

            if (c.IdDiarioBomLinha == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void frmAutoridadeCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaCombos()
        {

            cboArmazem.DataSource = new ArmazemDAL().GetCombo();
            cboArmazem.DisplayMember = "Text";
            cboArmazem.ValueMember = "iValue";
            cboArmazem.SelectedIndex = -1;

            cboConfiguracao.DataSource = new VariantesConfigDAL().GetCombo();
            cboConfiguracao.DisplayMember = "Text";
            cboConfiguracao.ValueMember = "iValue";
            cboConfiguracao.SelectedIndex = -1;

            cboCor.DataSource = new VariantesCorDAL().GetCombo();
            cboCor.DisplayMember = "Text";
            cboCor.ValueMember = "iValue";
            cboCor.SelectedIndex = -1;

            cboDeposito.DataSource = new DepositoDAL().GetCombo();
            cboDeposito.DisplayMember = "Text";
            cboDeposito.ValueMember = "iValue";
            cboDeposito.SelectedIndex = -1;

            cboEstilo.DataSource = new VariantesEstiloDAL().GetCombo();
            cboEstilo.DisplayMember = "Text";
            cboEstilo.ValueMember = "iValue";
            cboEstilo.SelectedIndex = -1;

            cboLocalizacao.DataSource = new LocalizacaoDAL().GetCombo();
            cboLocalizacao.DisplayMember = "Text";
            cboLocalizacao.ValueMember = "iValue";
            cboLocalizacao.SelectedIndex = -1;

            cboLote.DataSource = new RecebimentoItemLoteDAL().GetCombo();
            cboLote.DisplayMember = "Text";
            cboLote.ValueMember = "iValue";
            cboLote.SelectedIndex = -1;
            //1-2-3-;4-
            List<ComboItem> Referencias = new List<ComboItem>();
            Referencias.Add(new ComboItem() { iValue = 1, Text = "Ordem de saída" });
            Referencias.Add(new ComboItem() { iValue = 2, Text = "Diário de listas de sep. de produção" });
            Referencias.Add(new ComboItem() { iValue = 3, Text = "Diário de conclusões de produção" });
            Referencias.Add(new ComboItem() { iValue = 4, Text = "Estoque - Diário de listas de separação" });

            cboReferenciaEstoque.DataSource = Referencias;
            cboReferenciaEstoque.DisplayMember = "Text";
            cboReferenciaEstoque.ValueMember = "iValue";
            cboReferenciaEstoque.SelectedIndex = -1;


            cboTamanho.DataSource = new VariantesTamanhoDAL().GetCombo();
            cboTamanho.DisplayMember = "Text";
            cboTamanho.ValueMember = "iValue";
            cboTamanho.SelectedIndex = -1;

            cboUnidade.DataSource = new UnidadeDAL().GetCombo();
            cboUnidade.DisplayMember = "Text";
            cboUnidade.ValueMember = "iValue";
            cboUnidade.SelectedIndex = -1;

        }

        private void CarregaDados()
        {
            cboArmazem.SelectedValue = c.IdArmazem == null ? 0 : c.IdArmazem;
            cboConfiguracao.SelectedValue = c.IdConfiguracao == null ? 0 : c.IdConfiguracao;
            cboCor.SelectedValue = c.IdCor == null ? 0 : c.IdCor;
            cboDeposito.SelectedValue = c.IdDeposito == null ? 0 : c.IdDeposito;
            cboEstilo.SelectedValue = c.IdEstilo == null ? 0 : c.IdEstilo;
            cboLocalizacao.SelectedValue = c.IdLocalizacao == null ? 0 : c.IdLocalizacao;
            cboLote.SelectedValue = c.IdLote == null ? 0 : c.IdLote;
            cboReferenciaEstoque.SelectedValue = c.ReferenciaEstoque == null ? 0 : c.ReferenciaEstoque;
            cboTamanho.SelectedValue = c.IdTamanho == null ? 0 : c.IdTamanho;
            cboUnidade.SelectedValue = c.IdUnidade == null ? 0 : c.IdUnidade;
            chkDevolucao.Checked = Convert.ToBoolean(c.Devolucao);
            chkFim.Checked = Convert.ToBoolean(c.Fim);
            txtData.Text = c.Data == null ? "" : c.Data.ToString();
            txtNumeroItem.Text = c.NumeroItem == null ? "" : c.NumeroItem.ToString();
            txtNumeroLinha.Text = c.NumeroLinha == null ? "" : c.NumeroLinha.ToString();
            txtOrdemProducao.Text = c.IdOrdemProducao == null ? "" : c.IdOrdemProducao.ToString();
            txtPrecoCusto.Text = c.PrecoCusto == null ? "" : c.PrecoCusto.ToString();
            txtPrecoVenda.Text = c.PrecoVenda == null ? "" : c.PrecoVenda.ToString();
            txtQtdeConsumo.Text = c.QtdeConsumo == null ? "" : c.QtdeConsumo.ToString();
            txtQtdeConsumoEstoque.Text = c.QtdeConsumoEstoque == null ? "" : c.QtdeConsumoEstoque.ToString(); 
            txtQtdeDevolucao.Text = c.QtdeDevolucao == null ? "" : c.QtdeDevolucao.ToString();
            txtQtdeProposta.Text = c.QtdeProposta == null ? "" : c.QtdeProposta.ToString();
            txtSequenciaComprovante.Text = c.IdSequenciaComprovante == null ? "" : c.IdSequenciaComprovante.ToString();
            txtSerie.Text = c.Serie == null ? "" : c.Serie.ToString();
            txtSucata.Text = c.Sucata == null ? "" : c.Sucata.ToString();
            txtValorCusto.Text = c.ValorCusto == null ? "" : c.ValorCusto.ToString(); 
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new DiarioBomLinha(); 
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    c.Data = null;
                    c.Devolucao = chkDevolucao.Checked;
                    c.Fim = chkFim.Checked;
                    c.IdArmazem = null;
                    c.IdConfiguracao = null;
                    c.IdCor = null;
                    c.IdDeposito = null;
                    c.IdEstilo = null;
                    c.IdLocalizacao = null;
                    c.IdLote = null;
                    c.ReferenciaEstoque = null;
                    c.IdTamanho = null;
                    c.IdUnidade = null;
                    c.NumeroItem = null;
                    c.NumeroLinha = null;
                    c.IdOrdemProducao = null;
                    c.PrecoCusto = null;
                    c.PrecoVenda = null;
                    c.QtdeConsumo = null;
                    c.QtdeConsumoEstoque = null; 
                    c.QtdeDevolucao = null;
                    c.QtdeProposta = null;
                    c.IdSequenciaComprovante = null;
                    c.Serie = null;
                    c.Sucata = null;
                    c.ValorCusto = null;
                    if (!String.IsNullOrEmpty(cboArmazem.Text)) c.IdArmazem = Convert.ToInt32(cboArmazem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboConfiguracao.Text)) c.IdConfiguracao = Convert.ToInt32(cboConfiguracao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCor.Text)) c.IdCor = Convert.ToInt32(cboCor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDeposito.Text)) c.IdDeposito = Convert.ToInt32(cboDeposito.SelectedValue);
                    if (!String.IsNullOrEmpty(cboEstilo.Text)) c.IdEstilo = Convert.ToInt32(cboEstilo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboLocalizacao.Text)) c.IdLocalizacao = Convert.ToInt32(cboLocalizacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboLote.Text)) c.IdLote = Convert.ToInt32(cboLote.SelectedValue);
                    if (!String.IsNullOrEmpty(cboReferenciaEstoque.Text)) c.ReferenciaEstoque = Convert.ToInt32(cboReferenciaEstoque.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTamanho.Text)) c.IdTamanho = Convert.ToInt32(cboTamanho.SelectedValue);
                    if (!String.IsNullOrEmpty(cboUnidade.Text)) c.IdUnidade = Convert.ToInt32(cboUnidade.SelectedValue);
                    if (!String.IsNullOrEmpty(txtData.Text)) c.Data = Convert.ToDateTime(txtData.Text);
                    if (!String.IsNullOrEmpty(txtNumeroItem.Text)) c.NumeroItem = Convert.ToInt32(txtNumeroItem.Text);
                    if (!String.IsNullOrEmpty(txtNumeroLinha.Text)) c.NumeroLinha = Convert.ToInt32(txtNumeroLinha.Text);
                    if (!String.IsNullOrEmpty(txtOrdemProducao.Text)) c.IdOrdemProducao = Convert.ToInt32(txtOrdemProducao.Text);
                    if (!String.IsNullOrEmpty(txtPrecoCusto.Text)) c.PrecoCusto = Convert.ToDecimal(txtPrecoCusto.Text);
                    if (!String.IsNullOrEmpty(txtPrecoVenda.Text)) c.PrecoVenda = Convert.ToDecimal(txtPrecoVenda.Text);
                    if (!String.IsNullOrEmpty(txtQtdeConsumo.Text)) c.QtdeConsumo = Convert.ToDecimal(txtQtdeConsumo.Text);
                    if (!String.IsNullOrEmpty(txtQtdeConsumoEstoque.Text)) c.QtdeConsumoEstoque = Convert.ToDecimal(txtQtdeConsumoEstoque.Text);
                    if (!String.IsNullOrEmpty(txtQtdeDevolucao.Text)) c.QtdeDevolucao = Convert.ToDecimal(txtQtdeDevolucao.Text);
                    if (!String.IsNullOrEmpty(txtQtdeProposta.Text)) c.QtdeProposta = Convert.ToDecimal(txtQtdeProposta.Text);
                    if (!String.IsNullOrEmpty(txtSequenciaComprovante.Text)) c.IdSequenciaComprovante = Convert.ToInt32(txtSequenciaComprovante.Text);
                    if (!String.IsNullOrEmpty(txtSerie.Text)) c.Serie = txtSerie.Text;
                    if (!String.IsNullOrEmpty(txtSucata.Text)) c.Sucata = Convert.ToDecimal(txtSucata.Text);
                    if (!String.IsNullOrEmpty(txtValorCusto.Text)) c.ValorCusto = Convert.ToDecimal(txtValorCusto.Text);
                    if (c.IdDiarioBomLinha == 0)
                    {
                        dal.Insert(c);
                    }
                    else
                    {
                        dal.Update(c);
                    }

                    dal.Save();
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
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
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
            {
                int id = c.IdDiarioBomLinha;
                dal.Delete(id); 
                dal.Save();
                this.Close();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

         

    }
}

