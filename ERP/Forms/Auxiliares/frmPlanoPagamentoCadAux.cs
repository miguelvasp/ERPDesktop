using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmPlanoPagamentoCadAux : RibbonForm
    {
        public PlanoPagamentoItemDAL dal;
        PlanoPagamentoItem pp = new PlanoPagamentoItem();

        public frmPlanoPagamentoCadAux(PlanoPagamentoItem pPag)
        {
            pp = pPag;
            InitializeComponent(); 
            CarregarPorcentagemValor();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCidadeCad_Load(object sender, EventArgs e)
        {
            if (pp.IdPlanoPagamentoItem == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void frmPlanoPagamentoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            
            txtQuantidade.Text = pp.Quantidade.ToString();
            txtValorTransacao.Text = pp.ValorTransacao.ToString();
            cboPorcentagemValor.SelectedValue = pp.PorcentagemValor.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            pp = new PlanoPagamentoItem();
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
                pp.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                pp.ValorTransacao = Convert.ToDecimal(txtValorTransacao.Text);
                pp.PorcentagemValor = Convert.ToInt32(cboPorcentagemValor.SelectedValue);

                if (pp.IdPlanoPagamentoItem == 0)
                {
                    dal.Insert(pp);
                }
                else
                {
                    dal.Update(pp);
                }

                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
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
                    int id = pp.IdPlanoPagamentoItem;

                    dal.Delete(id);
                    dal.Save();

                    this.Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
            }
        }

        

        private void CarregarPorcentagemValor()
        {
            List<DropList> lista = Util.EnumERP.CarregarPorcentagemValor();

            cboPorcentagemValor.DisplayMember = "Text";
            cboPorcentagemValor.ValueMember = "Value";
            cboPorcentagemValor.DataSource = lista;
            cboPorcentagemValor.SelectedIndex = -1;
        }

        private void txtPeriodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumeroPagamentos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtValorMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtValorTransacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtValorTransacao.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
    }
}
