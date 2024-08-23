using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmOperacaoCad : RibbonForm
    {
        public OperacaoDAL dal;
        Operacao op = new Operacao();

        public frmOperacaoCad(Operacao pOp)
        {
            op = pOp;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmOperacaoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarContaContabil();
            CarregarPerfilCliente();
            CarregarPerfilFornecedor();
            CarregaTipoDirecaoNotaFiscal();
            CarregaDirecaoNotaFiscal();

            cboCFOPInterno.DataSource = new CFOPDAL().GetCombo();
            cboCFOPInterno.DisplayMember = "Text";
            cboCFOPInterno.ValueMember = "iValue";
            cboCFOPInterno.SelectedIndex = -1;

            cboCFOPExterno.DataSource = new CFOPDAL().GetCombo();
            cboCFOPExterno.DisplayMember = "Text";
            cboCFOPExterno.ValueMember = "iValue";
            cboCFOPExterno.SelectedIndex = -1;

            if (op.IdOperacao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmOperacaoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = op.IdOperacao.ToString();
            txtCodigo.Text = op.Codigo;
            txtDescricao.Text = op.Descricao;
            if (op.MovimentaEstoque != null)
                chkMovimentoEstoque.Checked = op.MovimentaEstoque.Value;
            if (op.TransacoesFinanceiras != null)
                chkTransacoesFinanceiras.Checked = op.TransacoesFinanceiras.Value;
            if (op.IdContaContabil != null)
                cboContaContabil.SelectedValue = op.IdContaContabil;
            if (op.IdPerfilCliente != null)
                cboPerfilCliente.SelectedValue = op.IdPerfilCliente;
            if (op.IdPerfilFornecedor != null)
                cboPerfilFornecedor.SelectedValue = op.IdPerfilFornecedor;
            if (op.IdTipoDirecaoNF != null)
                cboTipoDirNota.SelectedValue = op.IdTipoDirecaoNF;
            if (op.IdDirecaoNF != null)
                cboDirecaoNotaFiscal.SelectedValue = op.IdDirecaoNF;
            chkBonificacao.Checked = Convert.ToBoolean(op.Bonificacao);
            cboCFOPExterno.SelectedValue = op.IDCFOPExterno == null ? 0 : op.IDCFOPExterno;
            cboCFOPInterno.SelectedValue = op.IdCFOPInterno == null ? 0 : op.IdCFOPInterno;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        protected void CarregarContaContabil()
        {
            cboContaContabil.DataSource = new ContaContabilDAL().GetCombo();
            cboContaContabil.DisplayMember = "Text";
            cboContaContabil.ValueMember = "iValue";
            cboContaContabil.SelectedIndex = -1;
        }

        protected void CarregarPerfilCliente()
        {
            cboPerfilCliente.DataSource = new PerfilClienteDAL().GetCombo();
            cboPerfilCliente.DisplayMember = "Text";
            cboPerfilCliente.ValueMember = "iValue";
            cboPerfilCliente.SelectedIndex = -1;
        }

        protected void CarregarPerfilFornecedor()
        {
            cboPerfilFornecedor.DataSource = new PerfilFornecedorDAL().GetCombo();
            cboPerfilFornecedor.DisplayMember = "Text";
            cboPerfilFornecedor.ValueMember = "iValue";
            cboPerfilFornecedor.SelectedIndex = -1;
        }

        protected void CarregaTipoDirecaoNotaFiscal()
        {
            List<ComboItem> Tipo = new List<ComboItem>();
            Tipo.Add(new ComboItem() { iValue = 1, Text = "Nota fiscal de entrada terceiros" });
            Tipo.Add(new ComboItem() { iValue = 2, Text = "Nota fiscal de entrada própria" });
            Tipo.Add(new ComboItem() { iValue = 3, Text = "Nota fiscal de saída" });
            Tipo.Add(new ComboItem() { iValue = 4, Text = "Nota de Devolução de saída" });
            Tipo.Add(new ComboItem() { iValue = 5, Text = "Nota de Devolução de entrada" });
            cboTipoDirNota.DataSource = Tipo;
            cboTipoDirNota.DisplayMember = "Text";
            cboTipoDirNota.ValueMember = "iValue";
            cboTipoDirNota.SelectedIndex = -1;
        }

        protected void CarregaDirecaoNotaFiscal()
        {
            List<ComboItem> DirecaoNota = new List<ComboItem>();
            DirecaoNota.Add(new ComboItem() { iValue = 1, Text = "Nota fiscal de entrada terceiros. (Realiza entrada de Nota de Terceiro)" });
            DirecaoNota.Add(new ComboItem() { iValue = 2, Text = "Nota fiscal de entrada própria. (Realiza e emissão de entrada no lugar de uma Nota de Terceiro)" });
            DirecaoNota.Add(new ComboItem() { iValue = 3, Text = "Nota fiscal de saída. (Emissão de saída)" });
            DirecaoNota.Add(new ComboItem() { iValue = 4, Text = "Nota de Devolução de saída.  (Realiza entrada de uma nota de terceiros) " });
            DirecaoNota.Add(new ComboItem() { iValue = 5, Text = "Nota de Devolução de entrada.  (Realiza a emissão de uma nota de saída) " });
        
            cboDirecaoNotaFiscal.DataSource = DirecaoNota;
            cboDirecaoNotaFiscal.DisplayMember = "Text";
            cboDirecaoNotaFiscal.ValueMember = "iValue";
            cboDirecaoNotaFiscal.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            op = new Operacao();
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

                    op.Codigo = txtCodigo.Text;
                    op.Descricao = txtDescricao.Text;
                    op.MovimentaEstoque = chkMovimentoEstoque.Checked;
                    op.TransacoesFinanceiras = chkTransacoesFinanceiras.Checked;
                    if (!String.IsNullOrEmpty(cboContaContabil.Text))
                        op.IdContaContabil = Convert.ToInt32(cboContaContabil.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPerfilCliente.Text))
                        op.IdPerfilCliente = Convert.ToInt32(cboPerfilCliente.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPerfilFornecedor.Text))
                        op.IdPerfilFornecedor = Convert.ToInt32(cboPerfilFornecedor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoDirNota.Text))
                        op.IdTipoDirecaoNF = Convert.ToInt32(cboTipoDirNota.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDirecaoNotaFiscal.Text))
                        op.IdDirecaoNF = Convert.ToInt32(cboDirecaoNotaFiscal.SelectedValue);

                    op.Bonificacao = chkBonificacao.Checked;

                    op.IDCFOPExterno = null;
                    op.IdCFOPInterno = null;

                    if (!String.IsNullOrEmpty(cboCFOPExterno.Text)) op.IDCFOPExterno = Convert.ToInt32(cboCFOPExterno.SelectedValue);

                    if (!String.IsNullOrEmpty(cboCFOPInterno.Text)) op.IdCFOPInterno = Convert.ToInt32(cboCFOPInterno.SelectedValue);

                    if (op.IdOperacao == 0)
                    {
                        dal.Insert(op);
                    }
                    else
                    {
                        dal.Update(op);
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
                    int id = op.IdOperacao;
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
