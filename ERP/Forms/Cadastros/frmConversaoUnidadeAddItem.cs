using ERP.DAL;
using ERP.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmConversaoUnidadeAddItem : Form
    {
        ProdutoDAL dal = new ProdutoDAL();
        ConversaoUnidade cu = new ConversaoUnidade();

        int IdProduto = 0;

        public frmConversaoUnidadeAddItem(ProdutoDAL pDal, ConversaoUnidade pCU)
        {
            dal = pDal;
            cu = pCU;
            IdProduto = cu.IdProduto;
            InitializeComponent();
        }

        private void frmConversaoUnidadeAddItem_Load(object sender, EventArgs e)
        {
            CarregaUnidadeDe();
            CarregaUnidadePara();

            if (cu.IdConversaoUnidade != 0)
            {
                CarregaDados();
            }

            txtFator.Focus();
        }

        private void frmConversaoUnidadeAddItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        protected void CarregaDados()
        {
            txtFator.Text = cu.Fator.ToString("N4");
            txtNumerador.Text = cu.Numerador.ToString();
            txtDenominador.Text = cu.Denominador.ToString();
            if (cu.IdUnidadeDe != null)
                cboUnidadeDe.SelectedValue = cu.IdUnidadeDe;
            if (cu.IdUnidadePara != null)
                cboUnidadePara.SelectedValue = cu.IdUnidadePara;
        }

        protected void CarregaUnidadeDe()
        {
            cboUnidadeDe.DataSource = new UnidadeDAL().GetCombo();
            cboUnidadeDe.DisplayMember = "Text";
            cboUnidadeDe.ValueMember = "iValue";
            cboUnidadeDe.SelectedIndex = -1;
        }

        protected void CarregaUnidadePara()
        {
            cboUnidadePara.DataSource = new UnidadeDAL().GetCombo();
            cboUnidadePara.DisplayMember = "Text";
            cboUnidadePara.ValueMember = "iValue";
            cboUnidadePara.SelectedIndex = -1;
        }

        private void LimpaControles()
        {
            txtFator.Text = "";
            txtNumerador.Text = "";
            txtDenominador.Text = "";
            cboUnidadeDe.SelectedIndex = -1;
            cboUnidadePara.SelectedIndex = -1;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                cu.Fator = Convert.ToDecimal(txtFator.Text);
                cu.Numerador = Convert.ToInt32(txtNumerador.Text);
                cu.Denominador = Convert.ToInt32(txtDenominador.Text);
                if (!String.IsNullOrEmpty(cboUnidadeDe.Text))
                    cu.IdUnidadeDe = Convert.ToInt32(cboUnidadeDe.SelectedValue);
                if (!String.IsNullOrEmpty(cboUnidadePara.Text))
                    cu.IdUnidadePara = Convert.ToInt32(cboUnidadePara.SelectedValue);

                if (cu.IdConversaoUnidade == 0)
                {
                    dal.ConversaoRepository.Insert(cu);
                }
                else
                {
                    dal.ConversaoRepository.Update(cu);
                }

                dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                btnIncluir.Focus();
            }
            else
            {
                Util.Aplicacao.ShowMessage("Por favor verifique as informações faltantes.");
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            LimpaControles();
            cu = new ConversaoUnidade();
            cu.IdConversaoUnidade = 0;
            cu.IdProduto = IdProduto;
            txtFator.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (cu.IdConversaoUnidade != 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este item?") == DialogResult.Yes)
                {
                    try
                    {
                        dal.ConversaoRepository.Delete(cu.IdConversaoUnidade);
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

        private void txtFator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtFator.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtDenominador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumerador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
