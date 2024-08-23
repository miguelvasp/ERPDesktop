using ERP.Auxiliares;
using ERP.DAL;
using ERP.Models;
using System;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmConfGrupoImpostoCad : RibbonForm
    {
        public ConfGrupoImpostoDAL dal = new ConfGrupoImpostoDAL();
        ConfGrupoImposto cgi = new ConfGrupoImposto();

        public frmConfGrupoImpostoCad(ConfGrupoImposto pCGI)
        {
            cgi = pCGI;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmConfGrupoImpostoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarCodigoTributacao();
            CarregarCodigoIsencao();
            CarregarCodigoImposto();

            if (cgi.IdConfGrupoImposto == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmConfGrupoImpostoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            cboCodigoImposto.SelectedValue = cgi.IdCodigoImposto == null ? 0 : cgi.IdCodigoImposto;
            cboCodigoTributacao.SelectedValue = cgi.IdCodigoTributacao == null ? 0 : cgi.IdCodigoTributacao;
            chkImpostoSobreUso.Checked = Convert.ToBoolean(cgi.ImpostoSobreUso);
            chkIsento.Checked = Convert.ToBoolean(cgi.Isento);
            cboCodigoIsencao.SelectedValue = cgi.IdCodigoIsencao == null ? 0 : cgi.IdCodigoIsencao;
            var Aliq = new CodigoImpostoDAL().ConsultaPercentualPorData(cgi.IdCodigoImposto);
            if (Aliq != null)
            {
                txtPercentual.Text = Aliq.Aliquota.ToString();
            }
            

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarCodigoImposto()
        {
            var codigos = new CodigoImpostoDAL().GetCombo();
            cboCodigoImposto.DataSource = codigos;
            cboCodigoImposto.DisplayMember = "Text";
            cboCodigoImposto.ValueMember = "iValue";
            cboCodigoImposto.SelectedIndex = -1;
        }

        private void CarregarCodigoTributacao()
        {
            cboCodigoTributacao.DataSource = new CodigoTributacaoDAL().GetCombo();
            cboCodigoTributacao.DisplayMember = "Text";
            cboCodigoTributacao.ValueMember = "iValue";
            cboCodigoTributacao.SelectedIndex = -1;
        }

        private void CarregarCodigoIsencao()
        {
            cboCodigoIsencao.DataSource = new CodigoIsencaoDAL().GetCombo();
            cboCodigoIsencao.DisplayMember = "Text";
            cboCodigoIsencao.ValueMember = "iValue";
            cboCodigoIsencao.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cgi = new ConfGrupoImposto();
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

                    if (!String.IsNullOrEmpty(cboCodigoImposto.Text)) cgi.IdCodigoImposto = Convert.ToInt32(cboCodigoImposto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCodigoTributacao.Text)) cgi.IdCodigoTributacao = Convert.ToInt32(cboCodigoTributacao.SelectedValue);
                    cgi.ImpostoSobreUso = chkImpostoSobreUso.Checked;
                    cgi.Isento = chkIsento.Checked;
                    if (!String.IsNullOrEmpty(cboCodigoIsencao.Text)) cgi.IdCodigoIsencao = Convert.ToInt32(cboCodigoIsencao.SelectedValue);
                    if (!String.IsNullOrEmpty(txtPercentual.Text)) cgi.Percentual = Convert.ToDecimal(txtPercentual.Text);

                    if (cgi.IdConfGrupoImposto == 0)
                    {
                        dal.Insert(cgi);
                    }
                    else
                    {
                        dal.Update(cgi);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    this.Close();
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
                    int id = cgi.IdConfGrupoImposto;
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

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            CodigoImposto c = new CodigoImposto();
            frmCodigoImpostoCad f = new frmCodigoImpostoCad(c);
            f.ShowDialog();
            CarregarCodigoImposto();
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            frmCodigoIsencaoAux f = new frmCodigoIsencaoAux();
            f.ShowDialog();
            CarregarCodigoIsencao();

        }

        private void ribbonButton3_Click(object sender, EventArgs e)
        {
            CodigoTributacao c = new CodigoTributacao();
            frmCodigoTributacaoCad f = new frmCodigoTributacaoCad(c);
            f.ShowDialog();
            CarregarCodigoTributacao();
        }

        private void cboCodigoImposto_Leave(object sender, EventArgs e)
        {
            if (cboCodigoImposto.Text != "")
            {
                CodigoImposto ci = new CodigoImpostoDAL().GetByID(Convert.ToInt32(cboCodigoImposto.SelectedValue));
                if (ci != null)
                {
                    txtPercentual.Text = ci.PercentualValor.ToString();
                }

                //Pesquisa os codigos de tributo do mesmo tipo de imposto que o codigo
                cboCodigoTributacao.DataSource = new CodigoTributacaoDAL().GetComboTipoImposto((int)ci.TipoImposto);
                cboCodigoTributacao.DisplayMember = "Text";
                cboCodigoTributacao.ValueMember = "iValue";
                cboCodigoTributacao.SelectedIndex = -1;
            }
        }
    }
}
