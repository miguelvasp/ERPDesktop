using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCodigoEncargosCad : RibbonForm
    {
        public CodigoEncargoDAL dal;
        CodigoEncargo ce = new CodigoEncargo();

        public frmCodigoEncargosCad(CodigoEncargo pce)
        {
            ce = pce;
            InitializeComponent();
        }

        public frmCodigoEncargosCad()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCodigoEncargosCad_Load(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;

            CarregaCombos();

            if (ce.IdCodigoEncargo == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

        }

        private void frmCodigoEncargosCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            cboContaContabilCredito.SelectedValue = ce.IdContaContabilCredito == null ? 0 : ce.IdContaContabilCredito;
            cboContaContabilDebito.SelectedValue = ce.IdContaContabilDebito == null ? 0 : ce.IdContaContabilDebito;
            cboGrupoImpostos.SelectedValue = ce.IdGrupoImposto == null ? 0 : ce.IdGrupoImposto;
            cboLancamentoTipo.SelectedValue = ce.LancamentoTipo == null ? 0 : ce.LancamentoTipo;
            cboTipo.SelectedValue = ce.Tipo == null ? 0 : ce.Tipo;
            chkIncluiImposto.Checked = Convert.ToBoolean(ce.IncluiImpostos);
            chkIncluiNotaFiscal.Checked = Convert.ToBoolean(ce.IncluiNotaFiscal);
            cboTipoLancamentoCredito.SelectedValue = ce.CreditoTipoLancamento == null ? 0 : ce.CreditoTipoLancamento;
            txtDescricao.Text = ce.Descricao == null ? "" : ce.Descricao.ToString();
            txtNome.Text = ce.Nome == null ? "" : ce.Nome.ToString();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

           
        }

        protected void CarregaGrupoImposto()
        {
            
        }

        private void CarregaCombos()
        {
            cboGrupoImpostos.DataSource = new GrupoImpostoDAL().getCombo();
            cboGrupoImpostos.DisplayMember = "Text";
            cboGrupoImpostos.ValueMember = "iValue";
            cboGrupoImpostos.SelectedIndex = -1;

            cboContaContabilDebito.DataSource = new ContaContabilDAL().GetComboByTipo(1);
            cboContaContabilDebito.DisplayMember = "Text";
            cboContaContabilDebito.ValueMember = "iValue";
            cboContaContabilDebito.SelectedIndex = -1;

            cboContaContabilCredito.DataSource = new ContaContabilDAL().GetComboByTipo(1);
            cboContaContabilCredito.DisplayMember = "Text";
            cboContaContabilCredito.ValueMember = "iValue";
            cboContaContabilCredito.SelectedIndex = -1;

            List<ComboItem> lista = new List<ComboItem>();
            lista.Add(new ComboItem() { iValue = 1, Text = "Item" });
            lista.Add(new ComboItem() { iValue = 2, Text = "Conta Contabil" });
            lista.Add(new ComboItem() { iValue = 3, Text = "Fornecedor/ Cliente" });
            cboLancamentoTipo.DisplayMember = "Text";
            cboLancamentoTipo.ValueMember = "iValue";
            cboLancamentoTipo.DataSource = lista;
            cboLancamentoTipo.SelectedIndex = -1;

            List<ComboItem> lista2 = new List<ComboItem>();
            lista2.Add(new ComboItem() { iValue = 1, Text = "Item" });
            lista2.Add(new ComboItem() { iValue = 2, Text = "Conta Contabil" });
            lista2.Add(new ComboItem() { iValue = 3, Text = "Fornecedor/ Cliente" });
            cboTipoLancamentoCredito.DisplayMember = "Text";
            cboTipoLancamentoCredito.ValueMember = "iValue";
            cboTipoLancamentoCredito.DataSource = lista2;
            cboTipoLancamentoCredito.SelectedIndex = -1;

            List<ComboItem> tipos = new List<ComboItem>();
            tipos.Add(new ComboItem() { iValue = 1, Text = "Frete" });
            tipos.Add(new ComboItem() { iValue = 2, Text = "Seguro" });
            tipos.Add(new ComboItem() { iValue = 3, Text = "Siscomex" });
            tipos.Add(new ComboItem() { iValue = 4, Text = "Cota Patronal" });
            tipos.Add(new ComboItem() { iValue = 5, Text = "Outros Encargos" });
            cboTipo.DisplayMember = "Text";
            cboTipo.ValueMember = "iValue";
            cboTipo.DataSource = tipos;
            cboTipo.SelectedIndex = -1;
        }
         

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            ce = new CodigoEncargo(); 
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            //Caso o tipo de lançamento seja conta contabil o combo conta contabil fica obrigatorio
            if(!String.IsNullOrEmpty(cboLancamentoTipo.Text))
            {
                if (Convert.ToInt32(cboLancamentoTipo.SelectedValue) == 2)
                {
                    cboContaContabilDebito.Tag = "1";
                }
                else
                {
                    cboContaContabilDebito.Tag = "";
                }
            }

            if (!String.IsNullOrEmpty(cboTipoLancamentoCredito.Text))
            {
                if (Convert.ToInt32(cboTipoLancamentoCredito.SelectedValue) == 2)
                {
                    cboContaContabilCredito.Tag = "1";
                }
                else
                {
                    cboContaContabilCredito.Tag = "";
                }
            }




            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    ce.CreditoTipoLancamento = null;
                    ce.Descricao = null;
                    ce.IdContaContabilCredito = null;
                    ce.IdContaContabilDebito = null;
                    ce.IdGrupoImposto = null;
                    ce.LancamentoTipo = null;
                    ce.Tipo = null;
                    ce.IncluiImpostos = chkIncluiImposto.Checked;
                    ce.IncluiNotaFiscal = chkIncluiNotaFiscal.Checked;
                    ce.Nome = null;
                    if (!String.IsNullOrEmpty(cboContaContabilCredito.Text)) ce.IdContaContabilCredito = Convert.ToInt32(cboContaContabilCredito.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContaContabilDebito.Text)) ce.IdContaContabilDebito = Convert.ToInt32(cboContaContabilDebito.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoImpostos.Text)) ce.IdGrupoImposto = Convert.ToInt32(cboGrupoImpostos.SelectedValue);
                    if (!String.IsNullOrEmpty(cboLancamentoTipo.Text)) ce.LancamentoTipo = Convert.ToInt32(cboLancamentoTipo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipo.Text)) ce.Tipo = Convert.ToInt32(cboTipo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoLancamentoCredito.Text)) ce.CreditoTipoLancamento = Convert.ToInt32(cboTipoLancamentoCredito.SelectedValue);
                    if (!String.IsNullOrEmpty(txtDescricao.Text)) ce.Descricao = txtDescricao.Text;
                    if (!String.IsNullOrEmpty(txtNome.Text)) ce.Nome = txtNome.Text;
                    if (ce.IdCodigoEncargo == 0)
                    {
                        dal.Insert(ce);
                    }
                    else
                    {
                        dal.Update(ce);
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
                try
                {
                    int id = ce.IdCodigoEncargo;
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
    }
}