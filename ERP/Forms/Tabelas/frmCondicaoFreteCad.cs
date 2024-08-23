using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCondicaoFreteCad : RibbonForm
    {
        public CondicaoFreteDAL dal;
        CondicaoFrete cf = new CondicaoFrete();
        TipoEnderecoDAL teDal = new TipoEnderecoDAL(new DB_ERPContext());

        public frmCondicaoFreteCad(CondicaoFrete pCF)
        {
            cf = pCF;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCondicaoFreteCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaTipoEndereco();
            CarregarCondicoesEncargoDeFrete();

            if (cf.IdCondicaoFrete == 0)
            {
                lblMinimoGratis.Visible = false;
                txtMinimoGratis.Visible = false;
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmCondicaoFreteCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = cf.IdCondicaoFrete.ToString();
            txtNome.Text = cf.Nome;
            txtDescricao.Text = cf.Descricao;
            if (cf.IdTipoEndereco != null)
                cboTpEnd.SelectedValue = cf.IdTipoEndereco;
            txtCodigoIntrastat.Text = cf.CodigoIntrastat;
            if (cf.CondicaoEncargoFrete != null)
                cboCondicaoEncargoFrete.SelectedValue = cf.CondicaoEncargoFrete.ToString();
            chkAplicarMinimoGratis.Checked = cf.AplicarMinimoGratis;
            if (cf.MinimoGratis != null)
                txtMinimoGratis.Text = cf.MinimoGratis.Value.ToString("N4");

            lblMinimoGratis.Visible = false;
            txtMinimoGratis.Visible = false;
            if (chkAplicarMinimoGratis.Checked)
            {
                lblMinimoGratis.Visible = true;
                txtMinimoGratis.Visible = true;
            }

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregaTipoEndereco()
        {
            //carrega tipo endereço
            var tpe = teDal.Get().OrderBy(x => x.Descricao).ToList();
            cboTpEnd.DataSource = tpe;
            cboTpEnd.DisplayMember = "Descricao";
            cboTpEnd.ValueMember = "IdTipoEndereco";
            cboTpEnd.SelectedIndex = -1;
        }

        private void CarregarCondicoesEncargoDeFrete()
        {
            List<DropList> lista = Util.EnumERP.CarregarCondicoesEncargoDeFrete();

            cboCondicaoEncargoFrete.DisplayMember = "Text";
            cboCondicaoEncargoFrete.ValueMember = "Value";
            cboCondicaoEncargoFrete.DataSource = lista;
            cboCondicaoEncargoFrete.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cf = new CondicaoFrete();
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

                    cf.Nome = txtNome.Text;
                    cf.Descricao = txtDescricao.Text;
                    cf.IdTipoEndereco = Convert.ToInt32(cboTpEnd.SelectedValue);
                    cf.CodigoIntrastat = txtCodigoIntrastat.Text;
                    if (!String.IsNullOrEmpty(cboCondicaoEncargoFrete.Text))
                        cf.CondicaoEncargoFrete = Convert.ToInt32(cboCondicaoEncargoFrete.SelectedValue);
                    cf.AplicarMinimoGratis = chkAplicarMinimoGratis.Checked;
                    if (!String.IsNullOrEmpty(txtMinimoGratis.Text))
                        cf.MinimoGratis = Convert.ToDecimal(txtMinimoGratis.Text);

                    if (cf.IdCondicaoFrete == 0)
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
                    int id = cf.IdCondicaoFrete;
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

        private void txtMinimoGratis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtMinimoGratis.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void chkAplicarMinimoGratis_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAplicarMinimoGratis.Checked)
            {
                lblMinimoGratis.Visible = true;
                txtMinimoGratis.Visible = true;
                txtMinimoGratis.Text = "";
            }
            else
            {
                lblMinimoGratis.Visible = false;
                txtMinimoGratis.Visible = false;
            }
        }
    }
}
