using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmConfiguracaoChequeCad : RibbonForm
    {
        public ConfiguracaoChequeDAL dal = new ConfiguracaoChequeDAL();
        ConfiguracaoCheque c = new ConfiguracaoCheque();

        public frmConfiguracaoChequeCad(ConfiguracaoCheque pC)
        {
            c = pC;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmAutoridadeCad_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            if (c.IdConfiguracaoCheque == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void frmAutoridadeCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaCombos()
        {
            List<ComboItem> TipoDebito = new List<ComboItem>();
            TipoDebito.Add(new ComboItem() { iValue = 1, Text = "Conta Contábil" });
            TipoDebito.Add(new ComboItem() { iValue = 2, Text = "Cliente" });
            TipoDebito.Add(new ComboItem() { iValue = 3, Text = "Banco" });
            cboTipoContaDebito.DataSource = TipoDebito;
            cboTipoContaDebito.DisplayMember = "Text";
            cboTipoContaDebito.ValueMember = "iValue";
            cboTipoContaDebito.SelectedIndex = -1;

            List<ComboItem> TipoCredito = new List<ComboItem>();
            TipoCredito.Add(new ComboItem() { iValue = 1, Text = "Conta Contábil" });
            TipoCredito.Add(new ComboItem() { iValue = 2, Text = "Cliente" });
            TipoCredito.Add(new ComboItem() { iValue = 3, Text = "Banco" });
            cboTipoContaCredito.DataSource = TipoCredito;
            cboTipoContaCredito.DisplayMember = "Text";
            cboTipoContaCredito.ValueMember = "iValue";
            cboTipoContaCredito.SelectedIndex = -1;

            cboContaCredito.DataSource = new ContaContabilDAL().GetComboByTipo(1);//cnntas analiticas
            cboContaCredito.DisplayMember = "Text";
            cboContaCredito.ValueMember = "iValue";
            cboContaCredito.SelectedIndex = -1;

            cboContaDebito.DataSource = new ContaContabilDAL().GetComboByTipo(1);//cnntas analiticas
            cboContaDebito.DisplayMember = "Text";
            cboContaDebito.ValueMember = "iValue";
            cboContaDebito.SelectedIndex = -1; 
        }

        private void CarregaDados()
        {
            txtDescricao.Text = c.Descricao;
            txtOrdem.Text = c.Ordem;
            chkHabilitadoContabilizacaoPrincipal.Checked = Convert.ToBoolean(c.HabilitadoContabilizacaoPrincipal);
            txtTextoTransacao.Text = c.TextoTransacao;
            cboTipoContaDebito.SelectedValue = c.TipoContaDebito == null ? 0 : (int)c.TipoContaDebito;
            cboContaDebito.SelectedValue = c.IdContaContabilDebito == null ? 0 : (int)c.IdContaContabilDebito;
            cboTipoContaCredito.SelectedValue = c.TipoContaCredito == null ? 0 : (int)c.TipoContaCredito;
            cboContaCredito.SelectedValue = c.IdContaContabilCredito == null ? 0 : (int)c.IdContaContabilCredito; 
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }



        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            c = new ConfiguracaoCheque();
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
                    c.Descricao = txtDescricao.Text;
                    c.Ordem = txtOrdem.Text;
                    c.HabilitadoContabilizacaoPrincipal = chkHabilitadoContabilizacaoPrincipal.Checked;
                    c.TextoTransacao = txtTextoTransacao.Text;

                    c.TipoContaDebito = null;
                    if (!String.IsNullOrEmpty(cboTipoContaDebito.Text)) c.TipoContaDebito = Convert.ToInt32(cboTipoContaDebito.SelectedValue);
                    c.TipoContaCredito = null;
                    if (!String.IsNullOrEmpty(cboTipoContaCredito.Text)) c.TipoContaCredito = Convert.ToInt32(cboTipoContaCredito.SelectedValue);

                    c.IdContaContabilCredito = null;
                    if (!String.IsNullOrEmpty(cboContaCredito.Text)) c.IdContaContabilCredito = Convert.ToInt32(cboContaCredito.SelectedValue);

                    c.IdContaContabilDebito = null;
                    if (!String.IsNullOrEmpty(cboContaDebito.Text)) c.IdContaContabilDebito = Convert.ToInt32(cboContaDebito.SelectedValue);

                    if (c.IdConfiguracaoCheque == 0)
                    {
                        dal.Insert(c);
                    }
                    else
                    {
                        dal.Update(c);
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
                int id = (int)c.IdConfiguracaoCheque;
                dal.Delete(id);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }

     
    }
}

