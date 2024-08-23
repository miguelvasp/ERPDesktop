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
    public partial class frmCodigoFaturamentoCad : RibbonForm
    {
        public CodigoFaturamentoDAL dal;
        CodigoFaturamento cf = new CodigoFaturamento();

        public frmCodigoFaturamentoCad(CodigoFaturamento pcf)
        {
            cf = pcf;
            InitializeComponent();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCodigoFaturamentoCad_Load(object sender, EventArgs e)
        {
            if (cf.IdCFOP == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void CarregaDados()
        {
            lbCodigo.Text = cf.IdCFOP.ToString();
            txtCFOP.Text = cf.CFOP;
            txtDescricao.Text = cf.Descricao;
            txtDescComplementar.Text = cf.DescricaoComplementar;
            txtICMSTributacao.Text = cf.ICMSTributacao;
            txtICMSReducao.Text = cf.ICMSReducao.ToString("N4");
            chkFormaCalculo.Checked = cf.FormaCalculo;
            chkIncideIPI.Checked = cf.IPIIncide;
            chkIPITributacao.Checked = cf.IPITributacao;
            chkIncideISS.Checked = cf.ISSIncide;
            txtAliquotaISS.Text = cf.ISSAliquota.ToString("N4");
            lblAliquotaISS.Visible = false;
            txtAliquotaISS.Visible = false;
            if (chkIncideISS.Checked)
            {
                lblAliquotaISS.Visible = true;
                txtAliquotaISS.Visible = true;
            }

            txtPISCTS.Text = cf.PISCST;
            txtAliquotaPIS.Text = cf.PISAliquota.ToString("N4");
            txtCofinsCTS.Text = cf.CofinsCST;
            txtAliquotaCofins.Text = cf.CofinsAliquota.ToString("N4");
            txtTexto1.Text = cf.Texto1;
            txtTexto2.Text = cf.Texto2;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cf = new CodigoFaturamento();
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
                    cf.CFOP = txtCFOP.Text;
                    cf.Descricao = txtDescricao.Text;
                    cf.DescricaoComplementar = txtDescComplementar.Text;

                    cf.ICMSTributacao = txtICMSTributacao.Text;
                    if (!String.IsNullOrEmpty(txtICMSReducao.Text))
                        cf.ICMSReducao = Convert.ToDecimal(txtICMSReducao.Text);
    
                    cf.FormaCalculo = chkFormaCalculo.Checked;
                    cf.IPIIncide = chkIncideIPI.Checked;
                    cf.IPITributacao = chkIPITributacao.Checked;
                    cf.ISSIncide = chkIncideISS.Checked;
                    if (!String.IsNullOrEmpty(txtAliquotaISS.Text))
                        cf.ISSAliquota = Convert.ToDecimal(txtAliquotaISS.Text);
                    
                    cf.PISCST = txtPISCTS.Text;
                    if (!String.IsNullOrEmpty(txtAliquotaPIS.Text))
                        cf.PISAliquota = Convert.ToDecimal(txtAliquotaPIS.Text);
    
                    cf.CofinsCST = txtCofinsCTS.Text;
                    if (!String.IsNullOrEmpty(txtAliquotaCofins.Text))
                        cf.CofinsAliquota = Convert.ToDecimal(txtAliquotaCofins.Text);
                    
                    cf.Texto1 = txtTexto1.Text;
                    cf.Texto2 = txtTexto2.Text;

                    if (cf.IdCFOP == 0)
                    {
                        dal.Insert(cf);
                    }
                    else
                    {
                        dal.Update(cf);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
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
                int id = cf.IdCFOP;
                dal.Delete(id);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }

        private void txtICMSReducao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtICMSReducao.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtAliquotaISS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtAliquotaISS.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtAliquotaPIS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtAliquotaPIS.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtAliquotaCofins_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtAliquotaCofins.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void chkIncideISS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIncideISS.Checked)
            {
                lblAliquotaISS.Visible = true;
                txtAliquotaISS.Visible = true;
                txtAliquotaISS.Text = "";
            }
            else
            {
                lblAliquotaISS.Visible = false;
                txtAliquotaISS.Visible = false;
            }
        }
    }
}
