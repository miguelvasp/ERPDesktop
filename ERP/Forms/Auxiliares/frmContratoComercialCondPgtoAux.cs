using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmContratoComercialCondPgtoAux : RibbonForm
    {
        public ContratoComercialCondPgtoDAL dal = new ContratoComercialCondPgtoDAL();
        ContratoComercialCondPgto cc = new ContratoComercialCondPgto();

        public frmContratoComercialCondPgtoAux(ContratoComercialCondPgto pCC, int pIdContratoComercial)
        {
            cc = pCC;
            cc.IdContratoComercial = pIdContratoComercial;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmContratoComercialCad_Load(object sender, EventArgs e)
        {
            CarregaCombos();

            if (cc.IdContratoComercialCondPgto == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }
        
        private void frmContratoComercialCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaCombos()
        {
            cboCondicao.DataSource = new CondicaoPagamentoDAL().GetCombo();
            cboCondicao.DisplayMember = "Text";
            cboCondicao.ValueMember = "iValue";
            cboCondicao.SelectedIndex = -1;
        }

        private void CarregaDados()
        {
            cboCondicao.SelectedValue = cc.IdCondicaoPagamento == null ? 0 : cc.IdCondicaoPagamento;
            txtJuros.Text = cc.Juros.ToString("N4");

           Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void txtJuros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtJuros.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cc = new ContratoComercialCondPgto();
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
                    cc.Juros = Convert.ToDecimal(txtJuros.Text);
                    cc.IdCondicaoPagamento = Convert.ToInt32(cboCondicao.SelectedValue);

                    if (cc.IdContratoComercialCondPgto == 0)
                    {
                        dal.Insert(cc);
                    }
                    else
                    {
                        dal.Update(cc);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    this.Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
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
                    int id = cc.IdContratoComercialCondPgto;

                    dal.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));

                    this.Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowErrorMessage(ex);
                }
            }
        }
    }
}
