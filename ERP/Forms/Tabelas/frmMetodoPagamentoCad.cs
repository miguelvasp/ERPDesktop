using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmMetodoPagamentoCad : RibbonForm
    {
        public MetodoPagamentoDAL dal;
        MetodoPagamento mp = new MetodoPagamento();
        EspecificacaoPagamentoDAL edal = new EspecificacaoPagamentoDAL();

        public frmMetodoPagamentoCad(MetodoPagamento pMP)
        {
            mp = pMP;
            InitializeComponent();
        }

        public frmMetodoPagamentoCad()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmMetodoPagamentoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarMetodoPagamentoPeriodo();
            CarregarMetodoPagamentoStatusDoPagamento();
            CarregarMetodoPagamentoTipoDePagamento();
            CarregarMetodoPagamentoTipoDeConta();
            CarregaBanco();
            CarregaContaContabil();
            CarregaClientes();
            CarregaFornecedores();
            CarregaTipoTransacaoBancaria();
            CarregaContaTransicao();
            CarregaGrupoLayoutExportacao();
            CarregaGrupoLayoutRetorno();

            if (mp.IdMetodoPagamento == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmMetodoPagamentoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = mp.IdMetodoPagamento.ToString();
            txtNome.Text = mp.Nome;
            if (mp.Periodo != null)
                cboPeriodo.SelectedValue = mp.Periodo.ToString();
            txtCarencia.Text = mp.Carencia.ToString();
            if (mp.StatusPagamento != null)
                cboStatusPagamento.SelectedValue = mp.StatusPagamento.ToString();
            if (mp.TipoPagamento != null)
                cboTipoPagamento.SelectedValue = mp.TipoPagamento.ToString();
            if (mp.TipoConta != null)
                cboTipoConta.SelectedValue = mp.TipoConta.ToString();
            if (mp.IdBanco != null)
                cboBanco.SelectedValue = mp.IdBanco;
            if (mp.IdContaContabil != null)
                cboContaContabil.SelectedValue = mp.IdContaContabil;
            if (mp.IdCliente != null)
                cboCliente.SelectedValue = mp.IdCliente;
            if (mp.IdFornecedor != null)
                cboFornecedor.SelectedValue = mp.IdFornecedor;
            if (mp.IdTipoTransacaoBancaria != null)
                cboTransacaoBancaria.SelectedValue = mp.IdTipoTransacaoBancaria.Value;
            if (mp.LancamentoTransicao != null)
                chkLancamentoTransicao.Checked = mp.LancamentoTransicao.Value;
            if (mp.LancamentoCompesacaoCheque != null)
                chkLancamentoCheque.Checked = mp.LancamentoCompesacaoCheque.Value;
            if (mp.IdContaTransicao != null)
                cboContaTransicao.SelectedValue = mp.IdContaTransicao;
            if (mp.IdGrupoLayoutExportacao != null)
                cboGrupoLayoutExportacao.SelectedValue = mp.IdGrupoLayoutExportacao;
            if (mp.IdGrupoLayoutRetorno != null)
                cboGrupoLayoutRetorno.SelectedValue = mp.IdGrupoLayoutRetorno;
            CarregaGrid();
            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            mp = new MetodoPagamento();
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
            if (!String.IsNullOrEmpty(cboTipoConta.Text))
            {
                cboBanco.Tag = "";
                cboContaContabil.Tag = "";
                cboCliente.Tag = "";
                cboFornecedor.Tag = "";
                //switch(Convert.ToInt32(cboTipoConta.SelectedValue))
                //{
                //    case 1: cboContaContabil.Tag = "1"; break;
                //    case 2: cboCliente.Tag = "1"; break;
                //    case 3: cboFornecedor.Tag = "1"; break;
                //    case 4: cboBanco.Tag = "1"; break;  
                //}
            }

            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    //limpa as variaveis de combos
                    mp.IdBanco = null;
                    mp.IdCliente = null;
                    mp.IdContaContabil = null;
                    mp.IdContaTransicao = null;
                    mp.IdFornecedor = null;
                    mp.IdGrupoLayoutExportacao = null;
                    mp.IdGrupoLayoutRetorno = null;
                    mp.IdTipoTransacaoBancaria = null;

                    mp.Nome = txtNome.Text;
                    if (!String.IsNullOrEmpty(cboPeriodo.Text)) mp.Periodo = Convert.ToInt32(cboPeriodo.SelectedValue);
                    if (!String.IsNullOrEmpty(txtCarencia.Text)) mp.Carencia = Convert.ToInt32(txtCarencia.Text);
                    if (!String.IsNullOrEmpty(cboStatusPagamento.Text)) mp.StatusPagamento = Convert.ToInt32(cboStatusPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoPagamento.Text)) mp.TipoPagamento = Convert.ToInt32(cboTipoPagamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoConta.Text)) mp.TipoConta = Convert.ToInt32(cboTipoConta.SelectedValue);
                    if (!String.IsNullOrEmpty(cboBanco.Text)) mp.IdBanco = Convert.ToInt32(cboBanco.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContaContabil.Text))
                        mp.IdContaContabil = Convert.ToInt32(cboContaContabil.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCliente.Text))
                        mp.IdCliente = Convert.ToInt32(cboCliente.SelectedValue);
                    else
                        mp.IdCliente = null;

                    if (!String.IsNullOrEmpty(cboFornecedor.Text))
                        mp.IdFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);
                    else
                        mp.IdFornecedor = null;

                    if (!String.IsNullOrEmpty(cboTransacaoBancaria.Text))
                        mp.IdTipoTransacaoBancaria = Convert.ToInt32(cboTransacaoBancaria.SelectedValue);
                    mp.LancamentoTransicao = chkLancamentoTransicao.Checked;
                    mp.LancamentoCompesacaoCheque = chkLancamentoCheque.Checked;
                    if (!String.IsNullOrEmpty(cboContaTransicao.Text))
                        mp.IdContaTransicao = Convert.ToInt32(cboContaTransicao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoLayoutExportacao.Text))
                        mp.IdGrupoLayoutExportacao = Convert.ToInt32(cboGrupoLayoutExportacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoLayoutRetorno.Text))
                        mp.IdGrupoLayoutRetorno = Convert.ToInt32(cboGrupoLayoutRetorno.SelectedValue);

                    if (mp.IdMetodoPagamento == 0)
                    {
                        dal.Insert(mp);
                    }
                    else
                    {
                        dal.Update(mp);
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
                    int id = mp.IdMetodoPagamento;
                    dal.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    this.Close();
                }
                catch (Exception ex)
                {
                    Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
                }
            }
        }

        private void CarregarMetodoPagamentoPeriodo()
        {
            List<DropList> lista = Util.EnumERP.CarregarMetodoPagamentoPeriodo();

            cboPeriodo.DisplayMember = "Text";
            cboPeriodo.ValueMember = "Value";
            cboPeriodo.DataSource = lista;
            cboPeriodo.SelectedIndex = -1;
        }

        private void CarregarMetodoPagamentoStatusDoPagamento()
        {
            List<DropList> lista = Util.EnumERP.CarregarMetodoPagamentoStatusDoPagamento();

            cboStatusPagamento.DisplayMember = "Text";
            cboStatusPagamento.ValueMember = "Value";
            cboStatusPagamento.DataSource = lista;
            cboStatusPagamento.SelectedIndex = -1;
        }

        private void CarregarMetodoPagamentoTipoDePagamento()
        {
            List<DropList> lista = Util.EnumERP.CarregarMetodoPagamentoTipoDePagamento();

            cboTipoPagamento.DisplayMember = "Text";
            cboTipoPagamento.ValueMember = "Value";
            cboTipoPagamento.DataSource = lista;
            cboTipoPagamento.SelectedIndex = -1;
        }

        private void CarregarMetodoPagamentoTipoDeConta()
        {
            List<DropList> lista = Util.EnumERP.CarregarMetodoPagamentoTipoDeConta();

            cboTipoConta.DisplayMember = "Text";
            cboTipoConta.ValueMember = "Value";
            cboTipoConta.DataSource = lista;
            cboTipoConta.SelectedIndex = -1;
        }

        protected void CarregaBanco()
        {
            cboBanco.DataSource = new BancoDAL().GetCombo();
            cboBanco.DisplayMember = "Text";
            cboBanco.ValueMember = "iValue";
            cboBanco.SelectedIndex = -1;
        }

        protected void CarregaContaContabil()
        {
            cboContaContabil.DataSource = new ContaContabilDAL().GetCombo();
            cboContaContabil.DisplayMember = "Text";
            cboContaContabil.ValueMember = "iValue";
            cboContaContabil.SelectedIndex = -1;
        }

        protected void CarregaFornecedores()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(sEmpresa);
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;
        }

        protected void CarregaClientes()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboCliente.DataSource = new ClienteDAL().GetCombo(sEmpresa);
            cboCliente.DisplayMember = "Text";
            cboCliente.ValueMember = "iValue";
            cboCliente.SelectedIndex = -1;
        }

        protected void CarregaTipoTransacaoBancaria()
        {
            cboTransacaoBancaria.DataSource = new TipoTransacaoBancariaDAL().GetCombo();
            cboTransacaoBancaria.DisplayMember = "Text";
            cboTransacaoBancaria.ValueMember = "iValue";
            cboTransacaoBancaria.SelectedIndex = -1;
        }

        protected void CarregaContaTransicao()
        {
            cboContaTransicao.DataSource = new ContaContabilDAL().GetCombo();
            cboContaTransicao.DisplayMember = "Text";
            cboContaTransicao.ValueMember = "iValue";
            cboContaTransicao.SelectedIndex = -1;
        }

        protected void CarregaGrupoLayoutExportacao()
        {
            //cboGrupoLayoutExportacao.DataSource = new ContaContabilDAL().GetCombo();
            //cboGrupoLayoutExportacao.DisplayMember = "Text";
            //cboGrupoLayoutExportacao.ValueMember = "iValue";
            //cboGrupoLayoutExportacao.SelectedIndex = -1;
        }

        protected void CarregaGrupoLayoutRetorno()
        {
            //cboGrupoLayoutRetorno.DataSource = new ContaContabilDAL().GetCombo();
            //cboGrupoLayoutRetorno.DisplayMember = "Text";
            //cboGrupoLayoutRetorno.ValueMember = "iValue";
            //cboGrupoLayoutRetorno.SelectedIndex = -1;
        }

        private void txtCarencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mp.IdMetodoPagamento == 0)
            {
                Util.Aplicacao.ShowMessage("Deve salvar as informações do metodo de pagamento antes de adicionar especificações.");
                return;
            }

            EspecificacaoPagamento ep = new EspecificacaoPagamento();
            ep.IdMetodoPagamento = mp.IdMetodoPagamento;
            frmEspecificacaoPagamentoCad f = new frmEspecificacaoPagamentoCad(ep);
            f.dal = edal;
            f.cboMetodoPagamento.SelectedValue = mp.IdMetodoPagamento;
            f.cboMetodoPagamento.Visible = false;
            f.lblMetodoPagamento.Visible = false;
            f.ShowDialog();
            CarregaGrid();
        }


        private void CarregaGrid()
        {
            var lista = edal.GetByMetodoPagamentoId(mp.IdMetodoPagamento);
            dgEspecificacao.AutoGenerateColumns = false;
            dgEspecificacao.DataSource = lista;
        }

        private void dgEspecificacao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgEspecificacao.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dgEspecificacao.Rows[dgEspecificacao.SelectedRows[0].Index].Cells[0].Value);
                EspecificacaoPagamento ep = edal.GetByID(id);
                ep.IdMetodoPagamento = mp.IdMetodoPagamento;
                frmEspecificacaoPagamentoCad f = new frmEspecificacaoPagamentoCad(ep);
                f.dal = edal;
                f.cboMetodoPagamento.SelectedValue = mp.IdMetodoPagamento;
                f.cboMetodoPagamento.Visible = false;
                f.lblMetodoPagamento.Visible = false;
                f.ShowDialog();
                CarregaGrid();
            }
        }
    }
}