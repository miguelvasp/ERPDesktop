using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmLancamentoAtivoCad : RibbonForm
    {
        public LancamentoAtivoDAL dal;
        LancamentoAtivo la = new LancamentoAtivo();

        public frmLancamentoAtivoCad(LancamentoAtivo pLA)
        {
            la = pLA;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmLancamentoAtivoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarTipoContaAtivo();
            CarregarRelacaoAtivo();
            CarregarRelacaoOperacao();
            CarregaGrupoAtivo();
            CarregaOperacao();
            CarregarRelacaoValores();
            CarregaContaContabilPartida();
            CarregaContaContabilContraPartida();

            if (la.IdLancamentoAtivo == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmLancamentoAtivoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = la.IdLancamentoAtivo.ToString();
            txtDescricao.Text = la.Descricao;
            if (la.TipoContaAtivo != null)
                cboTipoContaAtivo.SelectedValue = la.TipoContaAtivo.ToString();

            if (la.RelacaoAtivo != null)
                cboRelacaoAtivo.SelectedValue = la.RelacaoAtivo.ToString();

            if (la.IdGrupoAtivo != null)
                cboGrupoAtivo.SelectedValue = la.IdGrupoAtivo;

            if (la.RelacaoOperacao != null)
                cboRelacaoOperacao.SelectedValue = la.RelacaoOperacao.ToString();

            if (la.IdOperacao != null)
                cboOperacao.SelectedValue = la.IdOperacao;

            if (la.RelacaoValores != null)
                cboRelacaoValores.SelectedValue = la.RelacaoValores.ToString();

            if (la.IdContaContabilPartida != null)
                cboContaContabilPartida.SelectedValue = la.IdContaContabilPartida;

            if (la.IdContaContabilContraPartida != null)
                cboContaContabilContraPartida.SelectedValue = la.IdContaContabilContraPartida;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarTipoContaAtivo()
        {
            List<DropList> lista = Util.EnumERP.CarregarTipoContaAtivo();

            cboTipoContaAtivo.DisplayMember = "Text";
            cboTipoContaAtivo.ValueMember = "Value";
            cboTipoContaAtivo.DataSource = lista;
            cboTipoContaAtivo.SelectedIndex = -1;
        }

        private void CarregarRelacaoAtivo()
        {
            List<DropList> lista = Util.EnumERP.CarregarRelacaoAtivo();

            cboRelacaoAtivo.DisplayMember = "Text";
            cboRelacaoAtivo.ValueMember = "Value";
            cboRelacaoAtivo.DataSource = lista;
            cboRelacaoAtivo.SelectedIndex = -1;
        }

        private void CarregarRelacaoOperacao()
        {
            List<DropList> lista = Util.EnumERP.CarregarGrupoAtivo();

            cboRelacaoOperacao.DisplayMember = "Text";
            cboRelacaoOperacao.ValueMember = "Value";
            cboRelacaoOperacao.DataSource = lista;
            cboRelacaoOperacao.SelectedIndex = -1;
        }

        protected void CarregaGrupoAtivo()
        {
            cboGrupoAtivo.DataSource = new GrupoAtivoDAL().GetCombo();
            cboGrupoAtivo.DisplayMember = "Text";
            cboGrupoAtivo.ValueMember = "iValue";
            cboGrupoAtivo.SelectedIndex = -1;
        }

        protected void CarregaOperacao()
        {
            cboOperacao.DataSource = new OperacaoDAL().GetCombo();
            cboOperacao.DisplayMember = "Text";
            cboOperacao.ValueMember = "iValue";
            cboOperacao.SelectedIndex = -1;
        }

        private void CarregarRelacaoValores()
        {
            List<DropList> lista = Util.EnumERP.CarregarOperacao();

            cboRelacaoValores.DisplayMember = "Text";
            cboRelacaoValores.ValueMember = "Value";
            cboRelacaoValores.DataSource = lista;
            cboRelacaoValores.SelectedIndex = -1;
        }

        protected void CarregaContaContabilPartida()
        {
            cboContaContabilPartida.DataSource = new ContaContabilDAL().GetCombo();
            cboContaContabilPartida.DisplayMember = "Text";
            cboContaContabilPartida.ValueMember = "iValue";
            cboContaContabilPartida.SelectedIndex = -1;
        }

        protected void CarregaContaContabilContraPartida()
        {
            cboContaContabilContraPartida.DataSource = new ContaContabilDAL().GetCombo();
            cboContaContabilContraPartida.DisplayMember = "Text";
            cboContaContabilContraPartida.ValueMember = "iValue";
            cboContaContabilContraPartida.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            la = new LancamentoAtivo();
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

                    la.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboTipoContaAtivo.Text))
                        la.TipoContaAtivo = Convert.ToInt32(cboTipoContaAtivo.SelectedValue);
                    else
                        la.TipoContaAtivo = null;

                    if (!String.IsNullOrEmpty(cboRelacaoAtivo.Text))
                        la.RelacaoAtivo = Convert.ToInt32(cboRelacaoAtivo.SelectedValue);
                    else
                        la.RelacaoAtivo = null;

                    if (!String.IsNullOrEmpty(cboGrupoAtivo.Text))
                        la.IdGrupoAtivo = Convert.ToInt32(cboGrupoAtivo.SelectedValue);
                    else
                        la.IdGrupoAtivo = null;

                    if (!String.IsNullOrEmpty(cboRelacaoOperacao.Text))
                        la.RelacaoOperacao = Convert.ToInt32(cboRelacaoOperacao.SelectedValue);
                    else
                        la.RelacaoOperacao = null;

                    if (!String.IsNullOrEmpty(cboRelacaoValores.Text))
                        la.RelacaoValores = Convert.ToInt32(cboRelacaoValores.SelectedValue);
                    else
                        la.RelacaoValores = null;

                    if (!String.IsNullOrEmpty(cboOperacao.Text))
                        la.IdOperacao = Convert.ToInt32(cboOperacao.SelectedValue);
                    else
                        la.IdOperacao = null;

                    if (!String.IsNullOrEmpty(cboContaContabilPartida.Text))
                        la.IdContaContabilPartida = Convert.ToInt32(cboContaContabilPartida.SelectedValue);
                    else
                        la.IdContaContabilPartida = null;

                    if (!String.IsNullOrEmpty(cboContaContabilContraPartida.Text))
                        la.IdContaContabilContraPartida = Convert.ToInt32(cboContaContabilContraPartida.SelectedValue);
                    else
                        la.IdContaContabilContraPartida = null;

                    if (la.IdLancamentoAtivo == 0)
                    {
                        dal.Insert(la);
                    }
                    else
                    {
                        dal.Update(la);
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
                    int id = la.IdLancamentoAtivo;
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
    }
}
