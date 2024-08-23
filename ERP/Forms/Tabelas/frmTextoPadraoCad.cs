using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmTextoPadraoCad : RibbonForm
    {
        public TextoPadraoDAL dal;
        TextoPadrao tp = new TextoPadrao();

        public frmTextoPadraoCad(TextoPadrao pTP)
        {
            tp = pTP;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmTextoPadraoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarAgencia();
            CarregarRestricao();

            if (tp.IdTextoPadrao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmTextoPadraoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = tp.IdTextoPadrao.ToString();
            txtCodigo.Text = tp.Codigo;
            txtDescricao.Text = tp.Descricao;
            cboRestricao.SelectedValue = tp.Restricao.ToString();
            cboAgencia.SelectedValue = tp.Agencia.ToString();
            chkInformacoesFiscais.Checked = tp.InformacoesFiscais;
            txtNumeroProcesso.Text = tp.NumeroProcesso;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarAgencia()
        {
            List<DropList> lista = Util.EnumERP.CarregarAutoridadesAgencia();

            cboAgencia.DisplayMember = "Text";
            cboAgencia.ValueMember = "Value";
            cboAgencia.DataSource = lista;
            cboAgencia.SelectedIndex = -1;
        }

        private void CarregarRestricao()
        {
            List<DropList> lista = Util.EnumERP.CarregarRestricao();

            cboRestricao.DisplayMember = "Text";
            cboRestricao.ValueMember = "Value";
            cboRestricao.DataSource = lista;
            cboRestricao.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            tp = new TextoPadrao();
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

                    tp.Codigo = txtCodigo.Text;
                    tp.Descricao = txtDescricao.Text;

                    if (!String.IsNullOrEmpty(cboRestricao.Text))
                        tp.Restricao = Convert.ToInt32(cboRestricao.SelectedValue);

                    if (!String.IsNullOrEmpty(cboAgencia.Text))
                        tp.Agencia = Convert.ToInt32(cboAgencia.SelectedValue);

                    tp.InformacoesFiscais = chkInformacoesFiscais.Checked;

                    tp.NumeroProcesso = txtNumeroProcesso.Text;

                    if (tp.IdTextoPadrao == 0)
                    {
                        dal.Insert(tp);
                    }
                    else
                    {
                        dal.Update(tp);
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
                    int id = tp.IdTextoPadrao;
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