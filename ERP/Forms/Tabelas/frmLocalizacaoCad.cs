using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmLocalizacaoCad : RibbonForm
    {
        public LocalizacaoDAL dal;
        Localizacao local = new Localizacao();

        public frmLocalizacaoCad(Localizacao pLocal)
        {
            local = pLocal;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmLocalizacaoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarCorredor();
            CarregarDeposito();
            CarregarTipodeLocalizacao();

            if (local.IdLocalizacao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = local.IdLocalizacao.ToString();
            txtNome.Text = local.Nome;
            cboDeposito.SelectedValue = local.IdDeposito == null ? 0 : local.IdDeposito;
            cboCorredor.SelectedValue = local.IdCorredor == null ? 0 : local.IdCorredor;
            cboTipoLocalizacao.SelectedValue = local.TipoLocalizacao.ToString();
            txtRack.Text = local.Rack.ToString();
            txtPrateleira.Text = local.Prateleira.ToString();
            txtLocalizacao.Text = local.LocalizacaoDesc.ToString();
            txtMaxPaletes.Text = local.MaxDePaletes.ToString();
            txtAltura.Text = local.Altura.Value.ToString("N4");
            txtLargura.Text = local.Largura.Value.ToString("N4");
            txtProfundidade.Text = local.Profundidade.Value.ToString("N4");
            txtVolume.Text = local.Volume.Value.ToString("N4");
            txtAlturaAbsoluta.Text = local.AlturaAbsoluta.Value.ToString("N4");
            txtPesoMaximo.Text = local.PesoMaximo.Value.ToString("N4");
            txtVolumeMaximo.Text = local.VolumeMaximo.Value.ToString("N4");

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarCorredor()
        {
            cboCorredor.DataSource = new CorredorDAL().GetCombo();
            cboCorredor.DisplayMember = "Text";
            cboCorredor.ValueMember = "iValue";
            cboCorredor.SelectedIndex = -1;
        }

        private void CarregarDeposito()
        {
            cboDeposito.DataSource = new DepositoDAL().GetCombo();
            cboDeposito.DisplayMember = "Text";
            cboDeposito.ValueMember = "iValue";
            cboDeposito.SelectedIndex = -1;
        }

        private void CarregarTipodeLocalizacao()
        {
            List<DropList> lista = Util.EnumERP.CarregarTipodeLocalizacao();

            cboTipoLocalizacao.DisplayMember = "Text";
            cboTipoLocalizacao.ValueMember = "Value";
            cboTipoLocalizacao.DataSource = lista;
            cboTipoLocalizacao.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            local = new Localizacao();
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

                    local.Nome = txtNome.Text;
                    if (!String.IsNullOrEmpty(cboDeposito.Text)) local.IdDeposito = Convert.ToInt32(cboDeposito.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCorredor.Text)) local.IdCorredor = Convert.ToInt32(cboCorredor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoLocalizacao.Text))
                        local.TipoLocalizacao = Convert.ToInt32(cboTipoLocalizacao.SelectedValue);
                    local.Rack = Convert.ToInt32(txtRack.Text);
                    local.Prateleira = Convert.ToInt32(txtPrateleira.Text);
                    local.LocalizacaoDesc = Convert.ToInt32(txtLocalizacao.Text);
                    local.MaxDePaletes = Convert.ToInt32(txtMaxPaletes.Text);
                    local.Altura = Convert.ToDecimal(txtAltura.Text);
                    local.Largura = Convert.ToDecimal(txtLargura.Text);
                    local.Profundidade = Convert.ToDecimal(txtProfundidade.Text);
                    local.Volume = Convert.ToDecimal(txtVolume.Text);
                    local.AlturaAbsoluta = Convert.ToDecimal(txtAlturaAbsoluta.Text);
                    local.PesoMaximo = Convert.ToDecimal(txtPesoMaximo.Text);
                    local.VolumeMaximo = Convert.ToDecimal(txtVolumeMaximo.Text);

                    if (local.IdLocalizacao == 0)
                    {
                        dal.Insert(local);
                    }
                    else
                    {
                        dal.Update(local);
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
                    int id = local.IdLocalizacao;
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

        private void txtRack_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrateleira_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLocalizacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMaxPaletes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtAltura.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtLargura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtLargura.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtProfundidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtProfundidade.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtVolume.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtAlturaAbsoluta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtAlturaAbsoluta.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtPesoMaximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtPesoMaximo.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtVolumeMaximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtVolumeMaximo.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
    }
}
