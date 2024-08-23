using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmChequeTerceiro : RibbonForm
    {
        public ChequeTerceirosDAL dal = new ChequeTerceirosDAL();
        public ChequeTerceiros c = new ChequeTerceiros();

        public frmChequeTerceiro(ChequeTerceiros pC)
        {
            c = pC;
            InitializeComponent();
        }

        public frmChequeTerceiro()
        {
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
            if (c.IdChequeTerceiro == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void CarregaCombos()
        {
            cboBanco.DataSource = new BancoDAL().GetCombo();
            cboBanco.ValueMember = "iValue";
            cboBanco.DisplayMember = "Text";
            cboBanco.SelectedIndex = -1;

            List<ComboItem> lStatus = new List<ComboItem>(); 
            lStatus.Add(new ComboItem() { iValue = 1, Text = "Em transito" });
            lStatus.Add(new ComboItem() { iValue = 2, Text = "Custodia" });
            lStatus.Add(new ComboItem() { iValue = 3, Text = "Depositado" });
            lStatus.Add(new ComboItem() { iValue = 4, Text = "Devolvido Custodia" });
            lStatus.Add(new ComboItem() { iValue = 5, Text = "Devolvido" });
            lStatus.Add(new ComboItem() { iValue = 6, Text = "Reapresentado" });
            lStatus.Add(new ComboItem() { iValue = 7, Text = "Protestado" });
            lStatus.Add(new ComboItem() { iValue = 8, Text = "Baixado" });
            cboStatus.DataSource = lStatus;
            cboStatus.ValueMember = "iValue";
            cboStatus.DisplayMember = "Text";
            cboStatus.SelectedIndex = -1;
        }

        private void frmAutoridadeCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {

            cboBanco.SelectedValue = c.IdBanco == null ? 0 : c.IdBanco;
            cboStatus.SelectedValue = c.Status == null ? 0 : c.Status;
            txtAgencia.Text = c.Agencia == null ? "" : c.Agencia.ToString();
            txtCheque.Text = c.NumeroCheque;
            txtConta.Text = c.Conta == null ? "" : c.Conta.ToString();
            txtCPF.Text = c.CPF == null ? "" : c.CPF.ToString();
            txtDataCompensacao.Text = c.DataCompensacao == null ? "" : c.DataCompensacao.ToString();
            txtEmissao.Text = c.Emissao == null ? "" : c.Emissao.ToString();
            txtNome.Text = c.Nome == null ? "" : c.Nome.ToString();
            txtValor.Text = c.Valor == null ? "" : c.Valor.ToString();
            //Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
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
                    c.Agencia = null;
                    c.NumeroCheque = null;
                    c.Conta = null;
                    c.CPF = null;
                    c.DataCompensacao = null;
                    c.Emissao = null;
                    c.IdBanco = null;
                    c.Status = null;
                    c.Nome = null;
                    c.Valor = null;
                    if (!String.IsNullOrEmpty(cboBanco.Text)) c.IdBanco = Convert.ToInt32(cboBanco.SelectedValue);
                    if (!String.IsNullOrEmpty(cboStatus.Text)) c.Status = Convert.ToInt32(cboStatus.SelectedValue);
                    if (!String.IsNullOrEmpty(txtAgencia.Text)) c.Agencia = txtAgencia.Text;
                    if (!String.IsNullOrEmpty(txtCheque.Text)) c.NumeroCheque = txtCheque.Text;
                    if (!String.IsNullOrEmpty(txtConta.Text)) c.Conta = txtConta.Text;
                    if (!String.IsNullOrEmpty(txtCPF.Text)) c.CPF = txtCPF.Text;
                    c.DataCompensacao = Util.Validacao.IsDateTime(txtDataCompensacao.Text);
                    if (!String.IsNullOrEmpty(txtEmissao.Text)) c.Emissao = Convert.ToDateTime(txtEmissao.Text);
                    if (!String.IsNullOrEmpty(txtNome.Text)) c.Nome = txtNome.Text;
                    if (!String.IsNullOrEmpty(txtValor.Text)) c.Valor = Convert.ToDecimal(txtValor.Text);

                    if (c.IdChequeTerceiro == 0)
                    {
                        dal.Insert(c);
                    }
                    else
                    {
                        dal.Update(c);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaDados();
                    this.Close();
                    //Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
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
                this.Close();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
            {
                int id = c.IdChequeTerceiro;
                dal.Delete(id);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CarregaGrid()
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {

        }
    }
}

