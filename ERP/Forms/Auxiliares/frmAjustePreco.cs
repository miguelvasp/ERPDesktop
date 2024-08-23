using ERP.DAL;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmAjustePreco : RibbonForm
    {
        ContratoComercialDAL dal = new ContratoComercialDAL();

        public frmAjustePreco()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmAjustePreco_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Util.Aplicacao.BloqueiaControles(this, btnGrava);
            CarregaCombos();

            Cursor.Current = Cursors.Default;
        }

        private void CarregaCombos()
        {
            CarregarAtivo();
            CarregarCodigoContratoComercial();
            CarregaCliente();
            CarregaFornecedor();
            CarregaProduto();
            CarregarRelacao();
            CarregarTipoAjusteContrato();
        }

        private void CarregarCodigoContratoComercial()
        {
            cboCodigoContratoComercial.DataSource = new CodigoContratoComercialDAL().GetCombo();
            cboCodigoContratoComercial.DisplayMember = "Text";
            cboCodigoContratoComercial.ValueMember = "iValue";
            cboCodigoContratoComercial.SelectedIndex = -1;
        }

        private void CarregarAtivo()
        {
            cboAtivo.Items.Insert(0, "Sim");
            cboAtivo.Items.Insert(1, "Não");
            cboAtivo.Items.Insert(2, "Ambos");
        }

        protected void CarregaCliente()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboCliente.DataSource = new ClienteDAL().GetCombo(sEmpresa);
            cboCliente.DisplayMember = "Text";
            cboCliente.ValueMember = "iValue";
            cboCliente.SelectedIndex = -1;
        }

        protected void CarregaFornecedor()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(sEmpresa);
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;
        }

        protected void CarregaProduto()
        {
            cboProduto.DataSource = new ProdutoDAL().GetComboCompras();
            cboProduto.DisplayMember = "Text";
            cboProduto.ValueMember = "iValue";
            cboProduto.SelectedIndex = -1;
        }

        private void CarregarRelacao()
        {
            List<DropList> lista = Util.EnumERP.CarregarRelacaoContratoComercial();

            cboRelacao.DisplayMember = "Text";
            cboRelacao.ValueMember = "Value";
            cboRelacao.DataSource = lista;
            cboRelacao.SelectedIndex = -1;
        }

        private void CarregarTipoAjusteContrato()
        {
            List<DropList> lista = Util.EnumERP.CarregarTipoAjusteContrato();

            cboAjuste.DisplayMember = "Text";
            cboAjuste.ValueMember = "Value";
            cboAjuste.DataSource = lista;
            cboAjuste.SelectedIndex = -1;
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtValor.Text, "^\\d*\\,\\d{2}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtPorcentagemValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '-' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtPorcentagemValor.Text, "^\\-\\d*\\,\\d{2}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtPorcentagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtPorcentagem.Text, "^\\d*\\,\\d{2}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtPorcentagemPercentual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '-' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtPorcentagemPercentual.Text, "^\\-\\d*\\,\\d{2}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Realmente deseja realizar o ajusta de preço em todos os contratos, conforme as características selecionadas?") == System.Windows.Forms.DialogResult.Yes)
            {
                if (String.IsNullOrEmpty(cboAjuste.Text))
                {
                    Util.Aplicacao.ShowMessage("Deve-se selecionar o tipo de ajuste, verifique!");

                    return;
                }

                if (Convert.ToInt32(cboAjuste.SelectedValue) == 1 && Convert.ToDecimal(txtValor.Text) <= 0)
                {
                    Util.Aplicacao.ShowMessage("O Valor deve ser maior que zero (0), verifique!");

                    return;
                }

                if (Convert.ToInt32(cboAjuste.SelectedValue) == 2 && Convert.ToDecimal(txtPorcentagemValor.Text) == 0)
                {
                    Util.Aplicacao.ShowMessage("A Porcentagem em Valor deve ser maior que zero (0), verifique!");

                    return;
                }

                if (Convert.ToInt32(cboAjuste.SelectedValue) == 3 && Convert.ToDecimal(txtPorcentagem.Text) <= 0)
                {
                    Util.Aplicacao.ShowMessage("A Porcentagem deve ser maior que zero (0), verifique!");

                    return;
                }

                if (Convert.ToInt32(cboAjuste.SelectedValue) == 4 && Convert.ToDecimal(txtPorcentagemPercentual.Text) == 0)
                {
                    Util.Aplicacao.ShowMessage("A Porcentagem em percentual deve ser maior que zero (0), verifique!");

                    return;
                }

                string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");
                string retorno = "";
                switch (Convert.ToInt32(cboAjuste.SelectedValue))
                {
                    case 1:
                        retorno = dal.CalcularAjustePreco(sEmpresa, Convert.ToInt32(cboCodigoContratoComercial.SelectedValue), cboAtivo.SelectedItem.ToString(), Convert.ToInt32(cboCliente.SelectedValue),
                            Convert.ToInt32(cboRelacao.SelectedValue), Convert.ToInt32(cboFornecedor.SelectedValue), Convert.ToInt32(cboProduto.SelectedValue),
                            Convert.ToInt32(cboAjuste.SelectedValue), Convert.ToDecimal(txtValor.Text));
                        break;

                    case 2:
                        retorno = dal.CalcularAjustePreco(sEmpresa, Convert.ToInt32(cboCodigoContratoComercial.SelectedValue), cboAtivo.SelectedItem.ToString(), Convert.ToInt32(cboCliente.SelectedValue),
                            Convert.ToInt32(cboRelacao.SelectedValue), Convert.ToInt32(cboFornecedor.SelectedValue), Convert.ToInt32(cboProduto.SelectedValue),
                            Convert.ToInt32(cboAjuste.SelectedValue), Convert.ToDecimal(txtPorcentagemValor.Text));
                        break;

                    case 3:
                        retorno = dal.CalcularAjustePreco(sEmpresa, Convert.ToInt32(cboCodigoContratoComercial.SelectedValue), cboAtivo.SelectedItem.ToString(), Convert.ToInt32(cboCliente.SelectedValue),
                            Convert.ToInt32(cboRelacao.SelectedValue), Convert.ToInt32(cboFornecedor.SelectedValue), Convert.ToInt32(cboProduto.SelectedValue),
                            Convert.ToInt32(cboAjuste.SelectedValue), Convert.ToDecimal(txtPorcentagem.Text));
                        break;

                    case 4:
                        retorno = dal.CalcularAjustePreco(sEmpresa, Convert.ToInt32(cboCodigoContratoComercial.SelectedValue), cboAtivo.SelectedItem.ToString(), Convert.ToInt32(cboCliente.SelectedValue),
                            Convert.ToInt32(cboRelacao.SelectedValue), Convert.ToInt32(cboFornecedor.SelectedValue), Convert.ToInt32(cboProduto.SelectedValue),
                            Convert.ToInt32(cboAjuste.SelectedValue), Convert.ToDecimal(txtPorcentagemPercentual.Text));
                        break;
                }

                if (!string.IsNullOrEmpty(retorno))
                {
                    Util.Aplicacao.ShowMessage(retorno);
                }
                else
                {
                    Close();
                }
            }
        }

        private void cboRelacao_Leave(object sender, EventArgs e)
        {
            int relacao = 0;
            if (!String.IsNullOrEmpty(cboRelacao.Text))
                relacao = Convert.ToInt32(cboRelacao.SelectedValue);

            txtPorcentagem.Enabled = true;
            txtPorcentagemPercentual.Enabled = true;

            if (relacao == 1 || relacao == 5)
            {
                txtPorcentagem.Enabled = false;
                txtPorcentagem.Text = "";
                txtPorcentagemPercentual.Enabled = false;
                txtPorcentagemPercentual.Text = "";
            }
        }

        private void cboAjuste_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ajuste = 0;
            if (!String.IsNullOrEmpty(cboAjuste.Text))
                ajuste = Convert.ToInt32(cboAjuste.SelectedValue);

            txtValor.Enabled = false;
            txtValor.Text = "";
            txtPorcentagemValor.Enabled = false;
            txtPorcentagemValor.Text = "";
            txtPorcentagem.Enabled = false;
            txtPorcentagem.Text = "";
            txtPorcentagemPercentual.Enabled = false;
            txtPorcentagemPercentual.Text = "";

            if (ajuste == 1)
            {
                txtValor.Enabled = true;
            }
            else if (ajuste == 2)
            {
                txtPorcentagemValor.Enabled = true;
            }
            else if (ajuste == 3)
            {
                txtPorcentagem.Enabled = true;
            }
            else if (ajuste == 4)
            {
                txtPorcentagemPercentual.Enabled = true;
            }
        }
    }
}
