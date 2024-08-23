using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmMetodoDepreciacaoCad : RibbonForm
    {
        public MetodoDepreciacaoDAL dal;
        MetodoDepreciacao md = new MetodoDepreciacao();

        public frmMetodoDepreciacaoCad(MetodoDepreciacao pMD)
        {
            md = pMD;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmMetodoDepreciacaoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaPerfilDepreciacaoComum();
            CarregaPerfilDepreciacaoAlternativa();
            CarregaPerfilDepreciacaoExtraordinaria();
            CarregarNivelDeLancamento();
            CarregarConvencao();

            if (md.IdMetodoDepreciacao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmMetodoDepreciacaoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = md.IdMetodoDepreciacao.ToString();
            txtDescricao.Text = md.Descricao;
            if (md.IdPerfilDepreciacaoComum != null)
                cboPerfilDepreciacaoComum.SelectedValue = md.IdPerfilDepreciacaoComum;
            if (md.IdPerfilDepreciacaoAlternativa != null)
                cboPerfilDepreciacaoAlternativa.SelectedValue = md.IdPerfilDepreciacaoAlternativa;
            if (md.IdPerfilDepreciacaoExtraordinaria != null)
                cboPerfilDepreciacaoExtraordinaria.SelectedValue = md.IdPerfilDepreciacaoExtraordinaria;
            txtArredondamento.Text = md.Arredondamento.Value.ToString("N4");
            txtManterValorLiquidoEm.Text = md.ManterValorLiquidoEm.Value.ToString("N4");
            if (md.NivelLancamento != null)
                cboNivelLancamento.SelectedValue = md.NivelLancamento.ToString();
            chkPermitirCustoSuperiorAquisicao.Checked = md.PermitirCustoSuperiorAquisicao;
            chkPermitirValorNegativo.Checked = md.PermitirValorNegativo;
            if (md.Convencao != null)
                cboConvencao.SelectedValue = md.Convencao.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        protected void CarregaPerfilDepreciacaoComum()
        {
            cboPerfilDepreciacaoComum.DataSource = new PerfilDepreciacaoDAL().GetCombo();
            cboPerfilDepreciacaoComum.DisplayMember = "Text";
            cboPerfilDepreciacaoComum.ValueMember = "iValue";
            cboPerfilDepreciacaoComum.SelectedIndex = -1;
        }

        protected void CarregaPerfilDepreciacaoAlternativa()
        {
            cboPerfilDepreciacaoAlternativa.DataSource = new PerfilDepreciacaoDAL().GetCombo();
            cboPerfilDepreciacaoAlternativa.DisplayMember = "Text";
            cboPerfilDepreciacaoAlternativa.ValueMember = "iValue";
            cboPerfilDepreciacaoAlternativa.SelectedIndex = -1;
        }

        protected void CarregaPerfilDepreciacaoExtraordinaria()
        {
            cboPerfilDepreciacaoExtraordinaria.DataSource = new PerfilDepreciacaoDAL().GetCombo();
            cboPerfilDepreciacaoExtraordinaria.DisplayMember = "Text";
            cboPerfilDepreciacaoExtraordinaria.ValueMember = "iValue";
            cboPerfilDepreciacaoExtraordinaria.SelectedIndex = -1;
        }

        private void CarregarNivelDeLancamento()
        {
            List<DropList> lista = Util.EnumERP.CarregarNivelDeLancamento();

            cboNivelLancamento.DisplayMember = "Text";
            cboNivelLancamento.ValueMember = "Value";
            cboNivelLancamento.DataSource = lista;
            cboNivelLancamento.SelectedIndex = -1;
        }

        private void CarregarConvencao()
        {
            List<DropList> lista = Util.EnumERP.CarregarConvencao();

            cboConvencao.DisplayMember = "Text";
            cboConvencao.ValueMember = "Value";
            cboConvencao.DataSource = lista;
            cboConvencao.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            md = new MetodoDepreciacao();
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

                    md.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboPerfilDepreciacaoComum.Text))
                        md.IdPerfilDepreciacaoComum = Convert.ToInt32(cboPerfilDepreciacaoComum.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPerfilDepreciacaoAlternativa.Text))
                        md.IdPerfilDepreciacaoAlternativa = Convert.ToInt32(cboPerfilDepreciacaoAlternativa.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPerfilDepreciacaoExtraordinaria.Text))
                        md.IdPerfilDepreciacaoExtraordinaria = Convert.ToInt32(cboPerfilDepreciacaoExtraordinaria.SelectedValue);
                    md.Arredondamento = Convert.ToDecimal(txtArredondamento.Text);
                    md.ManterValorLiquidoEm = Convert.ToDecimal(txtManterValorLiquidoEm.Text);
                    if (!String.IsNullOrEmpty(cboNivelLancamento.Text))
                        md.NivelLancamento = Convert.ToInt32(cboNivelLancamento.SelectedValue);
                    md.PermitirCustoSuperiorAquisicao = chkPermitirCustoSuperiorAquisicao.Checked;
                    md.PermitirValorNegativo = chkPermitirValorNegativo.Checked;
                    if (!String.IsNullOrEmpty(cboConvencao.Text))
                        md.Convencao = Convert.ToInt32(cboConvencao.SelectedValue);

                    if (md.IdMetodoDepreciacao == 0)
                    {
                        dal.Insert(md);
                    }
                    else
                    {
                        dal.Update(md);
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
                    int id = md.IdMetodoDepreciacao;
                    dal.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    this.Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
                }
            }
        }

        private void txtArredondamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtArredondamento.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtManterValorLiquidoEm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtManterValorLiquidoEm.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
    }
}