using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmEspecificacaoPagamentoCad : RibbonForm
    {
        public EspecificacaoPagamentoDAL dal;
        EspecificacaoPagamento ep = new EspecificacaoPagamento();

        public frmEspecificacaoPagamentoCad(EspecificacaoPagamento pEP)
        {
            ep = pEP;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmEspecificacaoPagamentoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarControleDeExportacao();
            CarregaSegmento();
            CarregaMetodoPagamento();
            CarregaFormaPagamento();
            CarregaTipoPagamento();

            if (ep.IdMetodoPagamento != null)
            {
                cboMetodoPagamento.SelectedValue = Convert.ToInt32(ep.IdMetodoPagamento);
            }

            if (ep.IdEspecificacaoPagamento == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmEspecificacaoPagamentoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = ep.IdEspecificacaoPagamento.ToString();
            txtNome.Text = ep.Nome;
            if (ep.IdMetodoPagamento != null)
                cboMetodoPagamento.SelectedValue = ep.IdMetodoPagamento;
            if (ep.ControleExportacao != null)
                cboControleDeExportacao.SelectedValue = ep.ControleExportacao.ToString();
            if (ep.IdSegmentoBancario != null)
                cboSegmento.SelectedValue = ep.IdSegmentoBancario;
            if (ep.IdFormaPagamento != null)
                cboFormaPagamento.SelectedValue = ep.IdFormaPagamento;
            if (ep.IdTipoPagamento != null)
                cboTipoPagamento.SelectedValue = ep.IdTipoPagamento;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            ep = new EspecificacaoPagamento();
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
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    ep.Nome = txtNome.Text;

                    if (!String.IsNullOrEmpty(cboMetodoPagamento.Text))
                        ep.IdMetodoPagamento = Convert.ToInt32(cboMetodoPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboControleDeExportacao.Text))
                        ep.ControleExportacao = Convert.ToInt32(cboControleDeExportacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboSegmento.Text))
                        ep.IdSegmentoBancario = Convert.ToInt32(cboSegmento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboFormaPagamento.Text))
                        ep.IdFormaPagamento = Convert.ToInt32(cboFormaPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoPagamento.Text))
                        ep.IdTipoPagamento = Convert.ToInt32(cboTipoPagamento.SelectedValue);

                    if (ep.IdEspecificacaoPagamento == 0)
                    {
                        dal.Insert(ep);
                    }
                    else
                    {
                        dal.Update(ep);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
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
                try
                {
                    int id = ep.IdEspecificacaoPagamento;
                    dal.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
                }
            }
        }

        private void CarregarControleDeExportacao()
        {
            List<DropList> lista = Util.EnumERP.CarregarControleDeExportacao();

            cboControleDeExportacao.DisplayMember = "Text";
            cboControleDeExportacao.ValueMember = "Value";
            cboControleDeExportacao.DataSource = lista;
            cboControleDeExportacao.SelectedIndex = -1;
        }

        protected void CarregaSegmento()
        {
            SegmentoBancarioDAL sdal = new SegmentoBancarioDAL();

            var s = sdal.GetCombo();
            cboSegmento.DataSource = s;
            cboSegmento.ValueMember = "iValue";
            cboSegmento.DisplayMember = "Text";
            cboSegmento.SelectedIndex = -1;
        }

        protected void CarregaMetodoPagamento()
        {
            cboMetodoPagamento.DataSource = new MetodoPagamentoDAL().GetCombo();
            cboMetodoPagamento.DisplayMember = "Text";
            cboMetodoPagamento.ValueMember = "iValue";
            cboMetodoPagamento.SelectedIndex = -1;
        }

        protected void CarregaFormaPagamento()
        {
            cboFormaPagamento.DataSource = new FormaPagamentoDAL().GetCombo();
            cboFormaPagamento.DisplayMember = "Text";
            cboFormaPagamento.ValueMember = "iValue";
            cboFormaPagamento.SelectedIndex = -1;
        }

        protected void CarregaTipoPagamento()
        {
            cboTipoPagamento.DataSource = new TipoPagamentoDAL().GetCombo();
            cboTipoPagamento.DisplayMember = "Text";
            cboTipoPagamento.ValueMember = "iValue";
            cboTipoPagamento.SelectedIndex = -1;
        }
    }
}