using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmCalculoComissaoCad : RibbonForm
    {
        public CalculoComissaoDAL dal;
        CalculoComissao cc = new CalculoComissao();

        public frmCalculoComissaoCad(CalculoComissao pCC)
        {
            cc = pCC;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCalculoComissaoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaGrupoComissao();
            CarregarRelacaoAoItem();
            CarregarRelacaoAoGrupo();
            CarregaCliente();
            CarregaGrupoCliente();
            CarregaFornecedor();
            CarregaGrupoFornecedor();
            CarregaGrupoProduto();
            CarregaGrupoPrecoDesconto();
            CarregaFuncionario();
            CarregarCalculoDeComissaoDesconto();
            CarregarCalculoDeComissaoAplicacao();
            CarregarCalculoDeComissaoPagamento();

            if (cc.IdCalculoComissao == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmCalculoComissaoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = cc.IdCalculoComissao.ToString();

            if (cc.IdGrupoComissao != null)
                cboGrupoComissao.SelectedValue = cc.IdGrupoComissao;

            cboRelacaoItem.SelectedValue = cc.RelacaoItem.ToString();
            cboRelacaoGrupo.SelectedValue = cc.RelacaoGrupo.ToString();

            if (cc.IdCliente != null)
            {
                rdbCliente.Checked = true;
                cboCliente.SelectedValue = cc.IdCliente;
            }

            if (cc.IdGrupoCliente != null)
                cboGrupoCliente.SelectedValue = cc.IdGrupoCliente;

            if (cc.IdFornecedor != null)
            {
                rdbFornecedor.Checked = true;
                cboFornecedor.SelectedValue = cc.IdFornecedor;
            }

            if (cc.IdGrupoFornecedor != null)
                cboGrupoFornecedor.SelectedValue = cc.IdGrupoFornecedor;

            if (cc.IdGrupoProduto != null)
            {
                rdbProduto.Checked = true;
                cboGrupoProduto.SelectedValue = cc.IdGrupoProduto;
                CarregaProduto(cc.IdGrupoProduto.Value);
            }

            if (cc.IdProduto != null)
                cboProduto.SelectedValue = cc.IdProduto;

            if (cc.IdGrupoPrecoDesconto != null)
                cboGrupoPrecoDesconto.SelectedValue = cc.IdGrupoPrecoDesconto;

            if (cc.IdFuncionario != null)
                cboFuncionario.SelectedValue = cc.IdFuncionario;

            if (cc.Desconto != null)
                cboDesconto.SelectedValue = cc.Desconto.ToString();

            if (cc.Aplicacao != null)
                cboAplicacao.SelectedValue = cc.Aplicacao.ToString();

            if (cc.Pagamento != null)
                cboPagamento.SelectedValue = cc.Pagamento.ToString();


            if (cc.De != null && cc.De != DateTime.MinValue)
                dtpDe.Value = cc.De.Value;

            if (cc.Ate != null && cc.Ate != DateTime.MinValue)
                dtpAte.Value = cc.Ate.Value;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        protected void CarregaGrupoComissao()
        {
            cboGrupoComissao.DataSource = new GrupoComissaoDAL().GetCombo();
            cboGrupoComissao.DisplayMember = "Text";
            cboGrupoComissao.ValueMember = "iValue";
            cboGrupoComissao.SelectedIndex = -1;
        }

        private void CarregarRelacaoAoItem()
        {
            List<DropList> lista = Util.EnumERP.CarregarRelacaoDeItem();

            cboRelacaoItem.DisplayMember = "Text";
            cboRelacaoItem.ValueMember = "Value";
            cboRelacaoItem.DataSource = lista;
            cboRelacaoItem.SelectedIndex = -1;
        }

        private void CarregarRelacaoAoGrupo()
        {
            List<DropList> lista = Util.EnumERP.CarregarRelacaoAoGrupo();

            cboRelacaoGrupo.DisplayMember = "Text";
            cboRelacaoGrupo.ValueMember = "Value";
            cboRelacaoGrupo.DataSource = lista;
            cboRelacaoGrupo.SelectedIndex = -1;
        }

        protected void CarregaCliente()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboCliente.DataSource = new ClienteDAL().GetCombo(sEmpresa);
            cboCliente.DisplayMember = "Text";
            cboCliente.ValueMember = "iValue";
            cboCliente.SelectedIndex = -1;
        }

        protected void CarregaGrupoCliente()
        {
            cboGrupoCliente.DataSource = new GrupoClienteDAL().GetCombo();
            cboGrupoCliente.DisplayMember = "Text";
            cboGrupoCliente.ValueMember = "iValue";
            cboGrupoCliente.SelectedIndex = -1;
        }

        protected void CarregaFornecedor()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(sEmpresa);
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;
        }

        protected void CarregaGrupoFornecedor()
        {
            cboGrupoFornecedor.DataSource = new GrupoFornecedorDAL().GetCombo();
            cboGrupoFornecedor.DisplayMember = "Text";
            cboGrupoFornecedor.ValueMember = "iValue";
            cboGrupoFornecedor.SelectedIndex = -1;
        }

        protected void CarregaProduto(int pIdGrupoProduto)
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboProduto.DataSource = new ProdutoDAL().getProdutosGruposCombo(pIdGrupoProduto, sEmpresa);
            cboProduto.DisplayMember = "Codigo";
            cboProduto.ValueMember = "IdProduto";
            cboProduto.SelectedIndex = -1;
        }

        protected void CarregaGrupoProduto()
        {
            cboGrupoProduto.DataSource = new GrupoProdutoDAL().GetCombo();
            cboGrupoProduto.DisplayMember = "Text";
            cboGrupoProduto.ValueMember = "iValue";
            cboGrupoProduto.SelectedIndex = -1;
        }

        protected void CarregaGrupoPrecoDesconto()
        {
            if (rdbCliente.Checked == true)
            {
                cboGrupoPrecoDesconto.DataSource = new GrupoPrecoDescontoDAL().GetCombo(ERP.Util.EnumERP.TipoGrupoPrecoDesconto.GrupoPreços, ERP.Util.EnumERP.ModuloGrupoPrecoDesconto.Vendas);
            }

            if (rdbFornecedor.Checked == true)
            {
                cboGrupoPrecoDesconto.DataSource = new GrupoPrecoDescontoDAL().GetCombo(ERP.Util.EnumERP.TipoGrupoPrecoDesconto.GrupoPreços, ERP.Util.EnumERP.ModuloGrupoPrecoDesconto.Compras); ;
            }

            if (rdbProduto.Checked == true)
            {
                cboGrupoPrecoDesconto.DataSource = new GrupoPrecoDescontoDAL().GetComboByModulo(3);
            }

            cboGrupoPrecoDesconto.DisplayMember = "Text";
            cboGrupoPrecoDesconto.ValueMember = "iValue";
            cboGrupoPrecoDesconto.SelectedIndex = -1;
        }

        protected void CarregaFuncionario()
        {
            cboFuncionario.DataSource = new FuncionarioDAL().GetCombo();
            cboFuncionario.DisplayMember = "Text";
            cboFuncionario.ValueMember = "iValue";
            cboFuncionario.SelectedIndex = -1;
        }

        private void CarregarCalculoDeComissaoDesconto()
        {
            List<DropList> lista = Util.EnumERP.CarregarCalculoDeComissaoDesconto();

            cboDesconto.DisplayMember = "Text";
            cboDesconto.ValueMember = "Value";
            cboDesconto.DataSource = lista;
            cboDesconto.SelectedIndex = -1;
        }

        private void CarregarCalculoDeComissaoAplicacao()
        {
            List<DropList> lista = Util.EnumERP.CarregarCalculoDeComissaoAplicacao();

            cboAplicacao.DisplayMember = "Text";
            cboAplicacao.ValueMember = "Value";
            cboAplicacao.DataSource = lista;
            cboAplicacao.SelectedIndex = -1;
        }

        private void CarregarCalculoDeComissaoPagamento()
        {
            List<DropList> lista = Util.EnumERP.CarregarCalculoDeComissaoPagamento();

            cboPagamento.DisplayMember = "Text";
            cboPagamento.ValueMember = "Value";
            cboPagamento.DataSource = lista;
            cboPagamento.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cc = new CalculoComissao();
            lbCodigo.Text = "0";
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            rdbCliente.Checked = true;
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

                    if (!String.IsNullOrEmpty(cboGrupoComissao.Text))
                        cc.IdGrupoComissao = Convert.ToInt32(cboGrupoComissao.SelectedValue);

                    if (!String.IsNullOrEmpty(cboRelacaoItem.Text))
                        cc.RelacaoItem = Convert.ToInt32(cboRelacaoItem.SelectedValue);

                    if (!String.IsNullOrEmpty(cboRelacaoGrupo.Text))
                        cc.RelacaoGrupo = Convert.ToInt32(cboRelacaoGrupo.SelectedValue);

                    if (!String.IsNullOrEmpty(cboCliente.Text))
                        cc.IdCliente = Convert.ToInt32(cboCliente.SelectedValue);
                    else
                        cc.IdCliente = null;

                    if (!String.IsNullOrEmpty(cboGrupoCliente.Text))
                        cc.IdGrupoCliente = Convert.ToInt32(cboGrupoCliente.SelectedValue);
                    else
                        cc.IdGrupoCliente = null;

                    if (!String.IsNullOrEmpty(cboFornecedor.Text))
                        cc.IdFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);
                    else
                        cc.IdFornecedor = null;

                    if (!String.IsNullOrEmpty(cboGrupoFornecedor.Text))
                        cc.IdGrupoFornecedor = Convert.ToInt32(cboGrupoFornecedor.SelectedValue);
                    else
                        cc.IdGrupoFornecedor = null;

                    if (!String.IsNullOrEmpty(cboGrupoProduto.Text))
                        cc.IdGrupoProduto = Convert.ToInt32(cboGrupoProduto.SelectedValue);
                    else
                        cc.IdGrupoProduto = null;

                    if (!String.IsNullOrEmpty(cboProduto.Text))
                        cc.IdProduto = Convert.ToInt32(cboProduto.SelectedValue);
                    else
                        cc.IdProduto = null;

                    if (!String.IsNullOrEmpty(cboGrupoPrecoDesconto.Text))
                        cc.IdGrupoPrecoDesconto = Convert.ToInt32(cboGrupoPrecoDesconto.SelectedValue);
                    else
                        cc.IdGrupoPrecoDesconto = null;

                    if (!String.IsNullOrEmpty(cboFuncionario.Text))
                        cc.IdFuncionario = Convert.ToInt32(cboFuncionario.SelectedValue);

                    if (!String.IsNullOrEmpty(cboDesconto.Text))
                        cc.Desconto = Convert.ToInt32(cboDesconto.SelectedValue);
                    else
                        cc.Desconto = null;

                    if (!String.IsNullOrEmpty(cboAplicacao.Text))
                        cc.Aplicacao = Convert.ToInt32(cboAplicacao.SelectedValue);

                    if (!String.IsNullOrEmpty(cboPagamento.Text))
                        cc.Pagamento = Convert.ToInt32(cboPagamento.SelectedValue);

                    cc.De = DateTime.Parse(dtpDe.Value.ToString("dd/MM/yyyy"));
                    cc.Ate = DateTime.Parse(dtpAte.Value.ToString("dd/MM/yyyy"));

                    if (cc.IdCalculoComissao == 0)
                    {
                        dal.Insert(cc);
                    }
                    else
                    {
                        dal.Update(cc);
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
                    int id = cc.IdCalculoComissao;
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

        private void cboGrupoProduto_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboGrupoProduto.Text))
            {
                int idGP = Convert.ToInt32(cboGrupoProduto.SelectedValue);
                CarregaProduto(idGP);
            }
        }

        private void rdbCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCliente.Checked == true)
            {
                CarregaGrupoPrecoDesconto();

                cboCliente.Enabled = true;
                cboCliente.SelectedIndex = -1;
                cboGrupoCliente.Enabled = true;
                cboGrupoCliente.SelectedIndex = -1;
                cboFornecedor.Enabled = false;
                cboFornecedor.SelectedIndex = -1;
                cboGrupoFornecedor.Enabled = false;
                cboGrupoFornecedor.SelectedIndex = -1;
                cboProduto.Enabled = false;
                cboProduto.SelectedIndex = -1;
                cboGrupoProduto.Enabled = false;
                cboGrupoProduto.SelectedIndex = -1;
            }
        }

        private void rdbFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFornecedor.Checked == true)
            {
                CarregaGrupoPrecoDesconto();

                cboCliente.Enabled = false;
                cboCliente.SelectedIndex = -1;
                cboGrupoCliente.Enabled = false;
                cboGrupoCliente.SelectedIndex = -1;
                cboFornecedor.Enabled = true;
                cboFornecedor.SelectedIndex = -1;
                cboGrupoFornecedor.Enabled = true;
                cboGrupoFornecedor.SelectedIndex = -1;
                cboProduto.Enabled = false;
                cboProduto.SelectedIndex = -1;
                cboGrupoProduto.Enabled = false;
                cboGrupoProduto.SelectedIndex = -1;
            }
        }

        private void rdbProduto_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbProduto.Checked == true)
            {
                CarregaGrupoPrecoDesconto();

                cboCliente.Enabled = false;
                cboCliente.SelectedIndex = -1;
                cboGrupoCliente.Enabled = false;
                cboGrupoCliente.SelectedIndex = -1;
                cboFornecedor.Enabled = false;
                cboFornecedor.SelectedIndex = -1;
                cboGrupoFornecedor.Enabled = false;
                cboGrupoFornecedor.SelectedIndex = -1;
                cboProduto.Enabled = true;
                cboProduto.SelectedIndex = -1;
                cboGrupoProduto.Enabled = true;
                cboGrupoProduto.SelectedIndex = -1;
            }
        }
    }
}
