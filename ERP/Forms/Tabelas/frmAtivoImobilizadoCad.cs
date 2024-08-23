using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmAtivoImobilizadoCad : RibbonForm
    {
        public AtivoImobilizadoDAL dal;
        AtivoImobilizado ai = new AtivoImobilizado();

        public frmAtivoImobilizadoCad(AtivoImobilizado pAI)
        {
            ai = pAI;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmAtivoImobilizadoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            LimparCamposDatas();
            CarregaGrupoAtivo();
            CarregarTipoGrupoAtivo();
            CarregarTipoPropriedade();
            CarregaFuncionario();

            if (ai.IdAtivoImobilizado == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmAtivoImobilizadoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void LimparCamposDatas()
        {
            dtpDataGarantia.Checked = true;
            dtpDataGarantia.CustomFormat = " ";
            dtpDataGarantia.Format = DateTimePickerFormat.Custom;

            dtpDataApolice.Checked = true;
            dtpDataApolice.CustomFormat = " ";
            dtpDataApolice.Format = DateTimePickerFormat.Custom;
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = ai.IdAtivoImobilizado.ToString();
            txtNome.Text = ai.Nome;
            txtDescricao.Text = ai.Descricao;
            if (ai.IdGrupoAtivo != null)
                cboGrupoAtivo.SelectedValue = ai.IdGrupoAtivo;

            txtNumeroFisico.Text = ai.NumeroFisico;
            cboTipo.SelectedValue = ai.Tipo.ToString();
            cboTipoPropriedade.SelectedValue = ai.TipoPropriedade.ToString();
            txtMarca.Text = ai.Marca;
            txtModelo.Text = ai.Modelo;
            txtAno.Text = ai.Ano.ToString();
            txtNumeroSerie.Text = ai.NumeroSerie;
            if (ai.DataGarantia != null && ai.DataGarantia != DateTime.MinValue)
                dtpDataGarantia.Value = ai.DataGarantia.Value;

            txtApolice.Text = ai.Apolice;
            if (ai.DataApolice != null && ai.DataApolice != DateTime.MinValue)
                dtpDataApolice.Value = ai.DataApolice.Value;

            if (ai.ValorSegurado != null)
                txtValorSegurado.Text = ai.ValorSegurado.Value.ToString("N4");

            if (ai.IdFuncionario != null)
                cboFuncionario.SelectedValue = ai.IdFuncionario;

            txtCodigoBarras.Text = ai.CodigoBarras;
            chkAtivoNaoLocalizado.Checked = ai.AtivoNaoLocalizado;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        protected void CarregaGrupoAtivo()
        {
            cboGrupoAtivo.DataSource = new GrupoAtivoDAL().GetCombo();
            cboGrupoAtivo.DisplayMember = "Text";
            cboGrupoAtivo.ValueMember = "iValue";
            cboGrupoAtivo.SelectedIndex = -1;
        }

        private void CarregarTipoGrupoAtivo()
        {
            List<DropList> lista = Util.EnumERP.CarregarTipoGrupoAtivo();

            cboTipo.DisplayMember = "Text";
            cboTipo.ValueMember = "Value";
            cboTipo.DataSource = lista;
            cboTipo.SelectedIndex = -1;
        }

        private void CarregarTipoPropriedade()
        {
            List<DropList> lista = Util.EnumERP.CarregarTipoPropriedade();

            cboTipoPropriedade.DisplayMember = "Text";
            cboTipoPropriedade.ValueMember = "Value";
            cboTipoPropriedade.DataSource = lista;
            cboTipoPropriedade.SelectedIndex = -1;
        }

        protected void CarregaFuncionario()
        {
            cboFuncionario.DataSource = new FuncionarioDAL().GetCombo();
            cboFuncionario.DisplayMember = "Text";
            cboFuncionario.ValueMember = "iValue";
            cboFuncionario.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            ai = new AtivoImobilizado();
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

                    ai.Nome = txtNome.Text;
                    ai.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(cboGrupoAtivo.Text))
                        ai.IdGrupoAtivo = Convert.ToInt32(cboGrupoAtivo.SelectedValue);

                    ai.NumeroFisico = txtNumeroFisico.Text;
                    if (!String.IsNullOrEmpty(cboTipo.Text))
                        ai.Tipo = Convert.ToInt32(cboTipo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoPropriedade.Text))
                        ai.TipoPropriedade = Convert.ToInt32(cboTipoPropriedade.SelectedValue);

                    ai.Marca = txtMarca.Text;
                    ai.Modelo = txtModelo.Text;
                    ai.Ano = Convert.ToInt32(txtAno.Text);
                    ai.NumeroSerie = txtNumeroSerie.Text;
                    ai.DataGarantia = DateTime.Parse(dtpDataGarantia.Value.ToString("dd/MM/yyyy"));
                    ai.Apolice = txtApolice.Text;
                    ai.DataApolice = DateTime.Parse(dtpDataApolice.Value.ToString("dd/MM/yyyy"));
                    if (!string.IsNullOrEmpty(txtValorSegurado.Text))
                        ai.ValorSegurado = Convert.ToDecimal(txtValorSegurado.Text);

                    if (!String.IsNullOrEmpty(cboFuncionario.Text))
                        ai.IdFuncionario = Convert.ToInt32(cboFuncionario.SelectedValue);

                    ai.CodigoBarras = txtCodigoBarras.Text;
                    ai.AtivoNaoLocalizado = chkAtivoNaoLocalizado.Checked;

                    if (ai.IdAtivoImobilizado == 0)
                    {
                        dal.Insert(ai);
                    }
                    else
                    {
                        dal.Update(ai);
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
                    int id = ai.IdAtivoImobilizado;
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

        private void txtAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dtpDataGarantia_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpDataGarantia.Checked)
            {
                dtpDataGarantia.CustomFormat = " ";
                dtpDataGarantia.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpDataGarantia.CustomFormat = null;
                dtpDataGarantia.Format = DateTimePickerFormat.Short;
            }
        }

        private void dtpDataApolice_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpDataApolice.Checked)
            {
                dtpDataApolice.CustomFormat = " ";
                dtpDataApolice.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpDataApolice.CustomFormat = null;
                dtpDataApolice.Format = DateTimePickerFormat.Short;
            }
        }

        private void txtValorSegurado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtValorSegurado.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
    }
}
