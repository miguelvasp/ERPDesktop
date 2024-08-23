using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmLancamentoCadItem : RibbonForm
    {
        public LancamentoDAL dal;
        public int idTipoLancamento = 0;
        int idTipoDocumento = 0;
        Lancamento lanc = new Lancamento();

        public frmLancamentoCadItem(Lancamento pLanc, int prtIdTipoDocumento)
        {
            lanc = pLanc;
            idTipoDocumento = prtIdTipoDocumento;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmLancamentoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarRelacaoAoGrupo();
            CarregaCliente();
            CarregaFornecedor();
            CarregaGrupoImpostos();

            CarregarRelacaoDeItem();
            CarregaProduto();

            CarregaContaContabilAnalitica();

            if (lanc.IdLancamento == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

                cboCliente.SelectedIndex = -1;
                cboGrupoCliente.SelectedIndex = -1;
                cboFornecedor.SelectedIndex = -1;
                cboGrupoFornecedor.SelectedIndex = -1;
                cboGrupoImpostos.SelectedIndex = -1;

                cboProduto.SelectedIndex = -1;
                cboGrupoProduto.SelectedIndex = -1;

                BloquearCombos();
                ValidacaoCodigo();
                ValidacaoRelacaoItem();
            }
            else
            {
                CarregaDados();
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmLancamentoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;

            lbCodigo.Text = lanc.IdLancamento.ToString();
            txtDescricao.Text = lanc.Descricao;

            if (lanc.RelacaoItem != null)
                cboRelacaoItem.SelectedValue = lanc.RelacaoItem.ToString();

            if (lanc.RelacaoGrupo != null)
                cboRelacaoGrupo.SelectedValue = lanc.RelacaoGrupo.ToString();

            if (lanc.IdGrupoProduto != null)
            {
                cboGrupoProduto.SelectedValue = lanc.IdGrupoProduto;
            }

            if (lanc.IdProduto != null)
                cboProduto.SelectedValue = lanc.IdProduto;

            if (lanc.IdCliente != null)
                cboCliente.SelectedValue = lanc.IdCliente;

            if (lanc.IdGrupoCliente != null)
                cboGrupoCliente.SelectedValue = lanc.IdGrupoCliente;

            if (lanc.IdFornecedor != null)
                cboFornecedor.SelectedValue = lanc.IdFornecedor;

            if (lanc.IdGrupoFornecedor != null)
                cboGrupoFornecedor.SelectedValue = lanc.IdGrupoFornecedor;

            if (lanc.IdGrupoImposto != null)
                cboGrupoImpostos.SelectedValue = lanc.IdGrupoImposto;

            if (lanc.IdContaContabil != null)
                cboContaContabil.SelectedValue = lanc.IdContaContabil;

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            Cursor.Current = Cursors.Default;
        }

        private void CarregarRelacaoDeItem()
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

        protected void CarregaProduto()
        {
            cboProduto.DataSource = new ProdutoDAL().GetComboCompras();
            cboProduto.DisplayMember = "Text";
            cboProduto.ValueMember = "iValue";
            cboProduto.SelectedIndex = -1;
        }

        protected void CarregaGrupoProduto()
        {
            cboGrupoProduto.DataSource = new GrupoProdutoDAL().GetCombo();
            cboGrupoProduto.DisplayMember = "Text";
            cboGrupoProduto.ValueMember = "iValue";
            cboGrupoProduto.SelectedIndex = -1;
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

        protected void CarregaGrupoImpostos()
        {
            cboGrupoImpostos.DataSource = new GrupoImpostoDAL().getCombo();
            cboGrupoImpostos.DisplayMember = "Text";
            cboGrupoImpostos.ValueMember = "iValue";
            cboGrupoImpostos.SelectedIndex = -1;
        }

        protected void CarregaContaContabilAnalitica()
        {
            cboContaContabil.DataSource = new ContaContabilDAL().GetComboByTipo(1);
            cboContaContabil.DisplayMember = "Text";
            cboContaContabil.ValueMember = "iValue";
            cboContaContabil.SelectedIndex = -1;
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            lanc = new Lancamento();
            lbCodigo.Text = "0";
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            cboCliente.SelectedIndex = -1;
            cboGrupoCliente.SelectedIndex = -1;
            cboFornecedor.SelectedIndex = -1;
            cboGrupoFornecedor.SelectedIndex = -1;
            cboGrupoImpostos.SelectedIndex = -1;

            cboProduto.SelectedIndex = -1;
            cboGrupoProduto.SelectedIndex = -1;

            BloquearCombos();
            ValidacaoCodigo();
            ValidacaoRelacaoItem();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            BloquearCombos();
            ValidacaoCodigo();
            ValidacaoRelacaoItem();
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    lanc.Descricao = txtDescricao.Text;
                    lanc.IdTipoLancamento = idTipoLancamento;

                    if (!String.IsNullOrEmpty(cboRelacaoItem.Text))
                        lanc.RelacaoItem = Convert.ToInt32(cboRelacaoItem.SelectedValue);

                    if (!String.IsNullOrEmpty(cboRelacaoGrupo.Text))
                        lanc.RelacaoGrupo = Convert.ToInt32(cboRelacaoGrupo.SelectedValue);

                    if (!String.IsNullOrEmpty(cboGrupoProduto.Text))
                        lanc.IdGrupoProduto = Convert.ToInt32(cboGrupoProduto.SelectedValue);
                    else
                        lanc.IdGrupoProduto = null;

                    if (!String.IsNullOrEmpty(cboProduto.Text))
                        lanc.IdProduto = Convert.ToInt32(cboProduto.SelectedValue);
                    else
                        lanc.IdProduto = null;

                    if (!String.IsNullOrEmpty(cboCliente.Text))
                        lanc.IdCliente = Convert.ToInt32(cboCliente.SelectedValue);
                    else
                        lanc.IdCliente = null;

                    if (!String.IsNullOrEmpty(cboGrupoCliente.Text))
                        lanc.IdGrupoCliente = Convert.ToInt32(cboGrupoCliente.SelectedValue);
                    else
                        lanc.IdGrupoCliente = null;

                    if (!String.IsNullOrEmpty(cboFornecedor.Text))
                        lanc.IdFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);
                    else
                        lanc.IdFornecedor = null;

                    if (!String.IsNullOrEmpty(cboGrupoFornecedor.Text))
                        lanc.IdGrupoFornecedor = Convert.ToInt32(cboGrupoFornecedor.SelectedValue);
                    else
                        lanc.IdGrupoFornecedor = null;

                    if (!String.IsNullOrEmpty(cboGrupoImpostos.Text))
                        lanc.IdGrupoImposto = Convert.ToInt32(cboGrupoImpostos.SelectedValue);

                    if (!String.IsNullOrEmpty(cboContaContabil.Text))
                        lanc.IdContaContabil = Convert.ToInt32(cboContaContabil.SelectedValue);

                    if (lanc.IdLancamento == 0)
                    {
                        dal.Insert(lanc);
                    }
                    else
                    {
                        dal.Update(lanc);
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
                    int id = lanc.IdLancamento;
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

        private void cboRelacaoItem_Leave(object sender, EventArgs e)
        {
            cboProduto.SelectedIndex = -1;
            cboGrupoProduto.SelectedIndex = -1;

            ValidacaoRelacaoItem();
        }

        private void cboRelacaoItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboProduto.SelectedIndex = -1;
            cboGrupoProduto.SelectedIndex = -1;

            ValidacaoRelacaoItem();
        }

        private void cboRelacaoGrupo_Leave(object sender, EventArgs e)
        {
            cboCliente.SelectedIndex = -1;
            cboGrupoCliente.SelectedIndex = -1;
            cboFornecedor.SelectedIndex = -1;
            cboGrupoFornecedor.SelectedIndex = -1;
            cboGrupoImpostos.SelectedIndex = -1;

            ValidacaoCodigo();
        }

        private void cboRelacaoGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCliente.SelectedIndex = -1;
            cboGrupoCliente.SelectedIndex = -1;
            cboFornecedor.SelectedIndex = -1;
            cboGrupoFornecedor.SelectedIndex = -1;
            cboGrupoImpostos.SelectedIndex = -1;

            ValidacaoCodigo();
        }

        private void BloquearCombos()
        {
            // Pedido de Vendas e Pedido de Compras
            cboRelacaoGrupo.Enabled = false;
            cboCliente.Enabled = false;
            cboGrupoCliente.Enabled = false;
            cboFornecedor.Enabled = false;
            cboGrupoFornecedor.Enabled = false;
            cboGrupoImpostos.Enabled = false;

            // Estoque e Produção
            cboRelacaoItem.Enabled = false;
            cboProduto.Enabled = false;
            cboGrupoProduto.Enabled = false;

            if (idTipoDocumento == 1 || idTipoDocumento == 2)
            {
                // Pedido de Vendas e Pedido de Compras
                cboRelacaoGrupo.Enabled = true;
                cboCliente.Enabled = true;
                cboFornecedor.Enabled = true;
                cboGrupoImpostos.Enabled = true;
                if (idTipoDocumento == 2 && idTipoLancamento == 15)
                    cboRelacaoItem.Enabled = true;//Disponibiliza o Combo so para esse tipo de lancamento
            }
            else if (idTipoDocumento == 3 || idTipoDocumento == 4)
            {
                // Estoque e Produção
                cboRelacaoItem.Enabled = true;
            }
        }

        private void ValidacaoRelacaoItem()
        {
            cboRelacaoItem.Tag = "";
            cboProduto.Enabled = false;
            cboProduto.Tag = "";
            cboGrupoProduto.Enabled = false;
            cboGrupoProduto.Tag = "";

            if (Convert.ToInt32(cboRelacaoItem.SelectedValue) == 1) // Tabela
            {
                cboRelacaoItem.Tag = "1";
                cboProduto.Enabled = true;
                cboProduto.Tag = "1";
            }
            else if (Convert.ToInt32(cboRelacaoItem.SelectedValue) == 2) // Grupo
            {
                cboRelacaoItem.Tag = "1";
                cboProduto.Enabled = true;

                cboGrupoProduto.Enabled = true;
                cboGrupoProduto.Tag = "";

                CarregaGrupoProduto();
            }
            else if (Convert.ToInt32(cboRelacaoItem.SelectedValue) == 3) // Todos
            {
            }
        }

        private void ValidacaoCodigo()
        {
            cboRelacaoGrupo.Tag = "";
            cboCliente.Enabled = false;
            cboCliente.Tag = "";
            cboGrupoCliente.Enabled = false;
            cboGrupoCliente.Tag = "";
            cboFornecedor.Enabled = false;
            cboFornecedor.Tag = "";
            cboGrupoFornecedor.Enabled = false;
            cboGrupoFornecedor.Tag = "";
            //cboGrupoImpostos.Enabled = true;
            //cboGrupoImpostos.Tag = "1";

            if (Convert.ToInt32(cboRelacaoGrupo.SelectedValue) == 1)     // Tabela
            {
                cboRelacaoGrupo.Tag = "1";
                cboCliente.Enabled = true;
                cboCliente.Tag = "1";
                cboFornecedor.Enabled = true;
                cboFornecedor.Tag = "1";
            }
            else if (Convert.ToInt32(cboRelacaoGrupo.SelectedValue) == 2) // Grupo
            {
                cboRelacaoGrupo.Tag = "1";

                cboCliente.Enabled = true;
                cboFornecedor.Enabled = true;

                cboGrupoCliente.Enabled = true;
                cboGrupoCliente.Tag = "1";
                cboGrupoFornecedor.Enabled = true;
                cboGrupoFornecedor.Tag = "1";

                CarregaGrupoCliente();
                CarregaGrupoFornecedor();
            }
            else if (Convert.ToInt32(cboRelacaoGrupo.SelectedValue) == 3) // Todos
            {
            }
        }
    }
}
