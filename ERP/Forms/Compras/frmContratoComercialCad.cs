using ERP.DAL;
using ERP.Models;
using ERP.ModelView;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmContratoComercialCad : RibbonForm
    {
        ContratoComercialDAL dal = new ContratoComercialDAL();
        ContratoComercial cc = new ContratoComercial();

        public frmContratoComercialCad(ContratoComercialDAL pDal, ContratoComercial pCC)
        {
            dal = pDal;
            cc = pCC;

            InitializeComponent();
        }

        public frmContratoComercialCad()
        {
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

            if (cc.IdContratoComercial == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

                cboCliente.SelectedIndex = -1;
                cboGrupoDescontoVarejista.SelectedIndex = -1;
                cboFornecedor.SelectedIndex = -1;
                cboGrupoPrecoDesconto.SelectedIndex = -1;
                cboProduto.SelectedIndex = -1;
                cboGrupoPrecoDescontoProduto.SelectedIndex = -1;

                BloquearCombos();
                ValidacaoCodigo();
                ValidacaoRelacaoItem();
            }
            else
            {
                CarregaDados();
            }
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            cc = new ContratoComercial();
            lbCodigo.Text = "0";
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);

            cboCliente.SelectedIndex = -1;
            cboGrupoDescontoVarejista.SelectedIndex = -1;
            cboFornecedor.SelectedIndex = -1;
            cboGrupoPrecoDesconto.SelectedIndex = -1;
            cboProduto.SelectedIndex = -1;
            cboGrupoPrecoDescontoProduto.SelectedIndex = -1;

            BloquearCombos();
            ValidacaoCodigo();
            ValidacaoRelacaoItem();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            BloquearCombos();
            ValidacaoCodigoAlterar();
            ValidacaoRelacaoItem();
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            // Validação
            // O Desconto varejista não pode ser criado caso haja algum contrato de desconto total (vendas) ativo e vise e versa 
            // não podemos criar um contrato de desconto total (vendas) caso haja algum Contrato de desconto varejista ativo.
            if (cc.IdContratoComercial == 0)
            {
                int relacao = 0;
                if (!String.IsNullOrEmpty(cboRelacao.Text))
                    relacao = Convert.ToInt32(cboRelacao.SelectedValue);

                if (relacao == 9) // Desconto Varejista
                {
                    if (dal.ExisteContratoDescontoTotalVendas(sEmpresa))
                    {
                        Util.Aplicacao.ShowMessage("Contrato Comercial de desconto varejista não pode ser criado, pois existe um contrato de desconto total (vendas) ativo.");
                        return;
                    }
                }
                else if (relacao == 8) // Desconto Total Vendas
                {
                    if (dal.ExisteContratoDescontoVarejista(sEmpresa))
                    {
                        Util.Aplicacao.ShowMessage("Contrato Comercial de desconto total (Vendas) não pode ser criado, pois existe um contrato de desconto varejista ativo.");
                        return;
                    }
                }
            }

            if (String.IsNullOrEmpty(txtValor.Text) || String.IsNullOrEmpty(txtValorPercentual.Text))
            {
                Util.Aplicacao.ShowMessage("Favor verifique o campo Valor e Valor Percentual.");
                return;
            }

            if (Convert.ToDecimal(txtValor.Text) == 0 && Convert.ToDecimal(txtValorPercentual.Text) == 0)
            {
                Util.Aplicacao.ShowMessage("Favor verifique o campo Valor e Valor Percentual.");
                return;
            }

            if (Util.Validacao.ValidaCampos(this))
            {
                try
                {
                    cc.IdEmpresa = Convert.ToInt32(sEmpresa);

                    if (!String.IsNullOrEmpty(cboCodigoContratoComercial.Text))
                        cc.IdCodigoContratoComercial = Convert.ToInt32(cboCodigoContratoComercial.SelectedValue);

                    cc.Ativo = chkAtivo.Checked;

                    if (!String.IsNullOrEmpty(cboRelacao.Text))
                        cc.Relacao = Convert.ToInt32(cboRelacao.SelectedValue);

                    if (!String.IsNullOrEmpty(cboCodigo.Text))
                        cc.CodigoTipo = Convert.ToInt32(cboCodigo.SelectedValue);

                    if (!String.IsNullOrEmpty(cboCliente.Text))
                        cc.IdCliente = Convert.ToInt32(cboCliente.SelectedValue);
                    else
                        cc.IdCliente = null;

                    if (!String.IsNullOrEmpty(cboGrupoDescontoVarejista.Text))
                        cc.IdGrupoDescontoVarejista = Convert.ToInt32(cboGrupoDescontoVarejista.SelectedValue);
                    else
                        cc.IdGrupoDescontoVarejista = null;

                    if (!String.IsNullOrEmpty(cboFornecedor.Text))
                        cc.IdFornecedor = Convert.ToInt32(cboFornecedor.SelectedValue);
                    else
                        cc.IdFornecedor = null;

                    if (!String.IsNullOrEmpty(cboGrupoPrecoDesconto.Text))
                        cc.IdGrupoPrecoDesconto = Convert.ToInt32(cboGrupoPrecoDesconto.SelectedValue);
                    else
                        cc.IdGrupoPrecoDesconto = null;

                    if (!String.IsNullOrEmpty(cboRelacaoItem.Text))
                        cc.RelacaoItem = Convert.ToInt32(cboRelacaoItem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboProduto.Text))
                        cc.IdProduto = Convert.ToInt32(cboProduto.SelectedValue);
                    else
                        cc.IdProduto = null;

                    cc.IdEstilo = null;
                    cc.IdCor = null;
                    cc.IdTamanho = null;
                    cc.IdConfig = null;
                    if (!String.IsNullOrEmpty(cboEstilo.Text)) cc.IdEstilo = Convert.ToInt32(cboEstilo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCor.Text)) cc.IdCor = Convert.ToInt32(cboCor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTamanho.Text)) cc.IdTamanho = Convert.ToInt32(cboTamanho.SelectedValue);
                    if (!String.IsNullOrEmpty(cboConfig.Text)) cc.IdConfig = Convert.ToInt32(cboConfig.SelectedValue);
                    cc.De = null;
                    cc.Ate = null;
                    cc.De = String.IsNullOrEmpty(txtDe.Text) ? 0 : Convert.ToInt32(txtDe.Text);
                    cc.Ate = String.IsNullOrEmpty(txtAte.Text) ? 0 : Convert.ToInt32(txtAte.Text);

                    cc.DeData = Util.Validacao.IsDateTime(txtDataDe.Text);
                    cc.AteData = Util.Validacao.IsDateTime(txtDataAte.Text);

                    if (!String.IsNullOrEmpty(cboUnidade.Text)) cc.IdUnidade = Convert.ToInt32(cboUnidade.SelectedValue);

                    if (!String.IsNullOrEmpty(txtValor.Text)) cc.Valor = Convert.ToDecimal(txtValor.Text);
                    if (!String.IsNullOrEmpty(txtValorPercentual.Text)) cc.ValorPercentual = Convert.ToDecimal(txtValorPercentual.Text);

                    if (!String.IsNullOrEmpty(cboUnidadePreco.Text)) cc.IdUnidadePreco = Convert.ToInt32(cboUnidadePreco.SelectedValue);

                    if (!String.IsNullOrEmpty(cboGrupoPrecoDescontoProduto.Text))
                        cc.IdGrupoPrecoDescontoProduto = Convert.ToInt32(cboGrupoPrecoDescontoProduto.SelectedValue);
                    else
                        cc.IdGrupoPrecoDescontoProduto = null;


                    if (cboGrupoPrecoDesconto.Text != "") cc.IdGrupoPrecoDesconto = Convert.ToInt32(cboGrupoPrecoDesconto.SelectedValue);

                    if (cc.IdContratoComercial == 0)
                    {
                        EmpresaDAL empDal = new EmpresaDAL();
                        Empresa empresa = empDal.ERepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
                        int ultimoContratoComercial = empresa.UltimoContratoComercial.HasValue ? empresa.UltimoContratoComercial.Value + 1 : 1;
                        empresa.UltimoContratoComercial = ultimoContratoComercial;
                        empDal.ERepository.Update(empresa);
                        empDal.Save();

                        cc.ContratoNumero = ultimoContratoComercial;
                        dal.Insert(cc);
                    }
                    else
                    {
                        dal.Update(cc);
                    }

                    dal.Save();
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
            int id = cc.IdContratoComercial;
            
            if (id > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
                {
                    dal.Delete(id);
                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    this.Close();
                }
            }
        }

        private void cboProduto_Leave(object sender, EventArgs e)
        {
            cboUnidade.Tag = "";

            cboEstilo.Enabled = false;
            cboEstilo.SelectedIndex = -1;
            cboCor.Enabled = false;
            cboCor.SelectedIndex = -1;
            cboTamanho.Enabled = false;
            cboTamanho.SelectedIndex = -1;

            if (!String.IsNullOrEmpty(cboProduto.Text))
            {
                cboUnidade.Tag = "1";

                cboEstilo.Enabled = true;
                cboCor.Enabled = true;
                cboTamanho.Enabled = true;

                cboEstilo.SelectedValue = cc.IdEstilo == null ? 0 : cc.IdEstilo;
                cboCor.SelectedValue = cc.IdCor == null ? 0 : cc.IdCor;
                cboTamanho.SelectedValue = cc.IdTamanho == null ? 0 : cc.IdTamanho;
            }
        }

        private void CarregaDados()
        {
            lbCodigo.Text = cc.IdContratoComercial.ToString();
            cboCodigoContratoComercial.SelectedValue = cc.IdCodigoContratoComercial;

            chkAtivo.Checked = cc.Ativo;

            if (cc.Relacao != null)
                cboRelacao.SelectedValue = cc.Relacao.ToString();

            if (cc.CodigoTipo != null)
                cboCodigo.SelectedValue = cc.CodigoTipo.ToString();

            if (cc.IdCliente != null)
            {
                cboCliente.SelectedValue = cc.IdCliente;
            }

            if (cc.IdGrupoDescontoVarejista != null)
            {
                cboGrupoDescontoVarejista.SelectedValue = cc.IdGrupoDescontoVarejista;
            }

            if (cc.IdFornecedor != null)
            {
                cboFornecedor.SelectedValue = cc.IdFornecedor;
            }

            if (cc.IdGrupoPrecoDesconto != null)
                cboGrupoPrecoDesconto.SelectedValue = cc.IdGrupoPrecoDesconto;

            cboRelacaoItem.SelectedValue = cc.RelacaoItem.ToString();

            if (cc.IdProduto != null)
            {
                cboUnidade.Tag = "1";
                cboProduto.SelectedValue = cc.IdProduto;
            }

            if (cc.IdGrupoPrecoDescontoProduto != null)
                cboGrupoPrecoDescontoProduto.SelectedValue = cc.IdGrupoPrecoDescontoProduto;

            cboEstilo.SelectedValue = cc.IdEstilo == null ? 0 : cc.IdEstilo;
            cboCor.SelectedValue = cc.IdCor == null ? 0 : cc.IdCor;
            cboTamanho.SelectedValue = cc.IdTamanho == null ? 0 : cc.IdTamanho;

            txtDe.Text = cc.De.ToString();
            txtAte.Text = cc.Ate.ToString();

            if (cc.DeData != null && cc.DeData != DateTime.MinValue)
                txtDataDe.Text = cc.DeData.Value.ToShortDateString();

            if (cc.AteData != null && cc.AteData != DateTime.MinValue)
                txtDataAte.Text = cc.AteData.Value.ToShortDateString();

            if (cc.Valor.HasValue) txtValor.Text = cc.Valor.Value.ToString("N4");
            if (cc.ValorPercentual.HasValue) txtValorPercentual.Text = cc.ValorPercentual.Value.ToString("N4");

            cboUnidade.SelectedValue = cc.IdUnidade == null ? 0 : cc.IdUnidade;
            cboUnidadePreco.SelectedValue = cc.IdUnidadePreco == null ? 0 : cc.IdUnidadePreco;

            //recarrega o grupo
            CarregaGrupoPrecoDesconto();
            cboGrupoPrecoDesconto.SelectedValue = cc.IdGrupoPrecoDesconto == null ? 0 : cc.IdGrupoPrecoDesconto;
            cboConfig.SelectedValue = cc.IdConfig == null ? 0 : cc.IdConfig;
            CarregaGrid();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void BloquearCombos()
        {
            cboCliente.Enabled = false;
            cboGrupoDescontoVarejista.Enabled = false;
            cboFornecedor.Enabled = false;
            cboGrupoPrecoDesconto.Enabled = false;
            cboProduto.Enabled = false;
            cboGrupoPrecoDescontoProduto.Enabled = false;
        }

        private void CarregaCombos()
        {
            CarregarCodigoContratoComercial();
            CarregarRelacao();
            CarregaCliente();
            CarregaGrupoDescontoVarejista();
            CarregaFornecedor();
            CarregarCodigo();
            CarregarRelacaoAoItem();
            CarregaProduto();
            CarregaGrupoPrecoDesconto();

            cboEstilo.DataSource = new VariantesEstiloDAL().GetCombo();
            cboEstilo.DisplayMember = "Text";
            cboEstilo.ValueMember = "iValue";
            cboEstilo.SelectedIndex = -1;

            cboConfig.DataSource = new VariantesConfigDAL().GetCombo();
            cboConfig.DisplayMember = "Text";
            cboConfig.ValueMember = "iValue";
            cboConfig.SelectedIndex = -1;

            cboCor.DataSource = new VariantesCorDAL().GetCombo();
            cboCor.DisplayMember = "Text";
            cboCor.ValueMember = "iValue";
            cboCor.SelectedIndex = -1;

            cboTamanho.DataSource = new VariantesTamanhoDAL().GetCombo();
            cboTamanho.DisplayMember = "Text";
            cboTamanho.ValueMember = "iValue";
            cboTamanho.SelectedIndex = -1;

            cboUnidade.DataSource = new UnidadeDAL().GetCombo();
            cboUnidade.DisplayMember = "Text";
            cboUnidade.ValueMember = "iValue";
            cboUnidade.SelectedIndex = -1;

            cboUnidadePreco.DataSource = new UnidadeDAL().GetCombo();
            cboUnidadePreco.DisplayMember = "Text";
            cboUnidadePreco.ValueMember = "iValue";
            cboUnidadePreco.SelectedIndex = -1;
        }

        private void CarregarCodigoContratoComercial()
        {
            cboCodigoContratoComercial.DataSource = new CodigoContratoComercialDAL().GetCombo();
            cboCodigoContratoComercial.DisplayMember = "Text";
            cboCodigoContratoComercial.ValueMember = "iValue";
            cboCodigoContratoComercial.SelectedIndex = -1;
        }

        private void CarregarRelacao()
        {
            List<DropList> lista = Util.EnumERP.CarregarRelacaoContratoComercial();

            cboRelacao.DisplayMember = "Text";
            cboRelacao.ValueMember = "Value";
            cboRelacao.DataSource = lista;
            cboRelacao.SelectedIndex = -1;
        }

        private void CarregarCodigo()
        {
            List<DropList> lista = Util.EnumERP.CarregarRelacaoDeItem();

            cboCodigo.DisplayMember = "Text";
            cboCodigo.ValueMember = "Value";
            cboCodigo.DataSource = lista;
            cboCodigo.SelectedIndex = -1;
        }

        protected void CarregaCliente()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboCliente.DataSource = new ClienteDAL().GetCombo(sEmpresa);
            cboCliente.DisplayMember = "Text";
            cboCliente.ValueMember = "iValue";
            cboCliente.SelectedIndex = -1;
        }

        protected void CarregaFornecedor()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            cboFornecedor.DataSource = new FornecedorDAL().GetCombo2(sEmpresa);
            cboFornecedor.DisplayMember = "Text";
            cboFornecedor.ValueMember = "iValue";
            cboFornecedor.SelectedIndex = -1;
        }

        private void CarregarRelacaoAoItem()
        {
            List<DropList> lista = Util.EnumERP.CarregarRelacaoDeItem();

            cboRelacaoItem.DisplayMember = "Text";
            cboRelacaoItem.ValueMember = "Value";
            cboRelacaoItem.DataSource = lista;
            cboRelacaoItem.SelectedIndex = -1;
        }

        protected void CarregaProduto()
        {
            cboProduto.DataSource = new ProdutoDAL().GetComboCompras();
            cboProduto.DisplayMember = "Text";
            cboProduto.ValueMember = "iValue";
            cboProduto.SelectedIndex = -1;
        }

        protected void CarregaGrupoDescontoVarejista()
        {
            cboGrupoDescontoVarejista.DataSource = new GrupoDescontoVarejistaDAL().GetCombo();// new GrupoPrecoDescontoDAL().GetCombo(ERP.Util.EnumERP.TipoGrupoPrecoDesconto.GrupoDescontoVarejo);
            cboGrupoDescontoVarejista.DisplayMember = "Text";
            cboGrupoDescontoVarejista.ValueMember = "iValue";
            cboGrupoDescontoVarejista.SelectedIndex = -1;
        }

        protected void CarregaGrupoPrecoDesconto()
        {
            int relacao = 0;
            if (!String.IsNullOrEmpty(cboRelacao.Text))
                relacao = Convert.ToInt32(cboRelacao.SelectedValue);

            if (relacao == 5 || relacao == 6 || relacao == 7 || relacao == 8)
            {
                cboGrupoPrecoDesconto.DataSource = new GrupoPrecoDescontoDAL().GetCombo(ERP.Util.EnumERP.TipoGrupoPrecoDesconto.GrupoPreços, ERP.Util.EnumERP.ModuloGrupoPrecoDesconto.Vendas);
            }
            else if (relacao == 1 || relacao == 2 || relacao == 3 || relacao == 4)
            {
                cboGrupoPrecoDesconto.DataSource = new GrupoPrecoDescontoDAL().GetCombo(ERP.Util.EnumERP.TipoGrupoPrecoDesconto.GrupoPreços, ERP.Util.EnumERP.ModuloGrupoPrecoDesconto.Compras);
            }

            //if (rdbProduto.Checked == true)
            //{
            //    cboGrupoPrecoDesconto.DataSource = new GrupoPrecoDescontoDAL().GetComboByModulo(3);
            //}

            cboGrupoPrecoDesconto.DisplayMember = "Text";
            cboGrupoPrecoDesconto.ValueMember = "iValue";
            cboGrupoPrecoDesconto.SelectedIndex = -1;
        }

        protected void CarregaGrupoPrecoDesconto(string Tipo)
        {
            if (Tipo == "Vendas")
            {
                cboGrupoPrecoDesconto.DataSource = new GrupoPrecoDescontoDAL().GetCombo(ERP.Util.EnumERP.TipoGrupoPrecoDesconto.GrupoPreços, ERP.Util.EnumERP.ModuloGrupoPrecoDesconto.Vendas);
            }
            else if (Tipo == "Compras")
            {
                cboGrupoPrecoDesconto.DataSource = new GrupoPrecoDescontoDAL().GetCombo(ERP.Util.EnumERP.TipoGrupoPrecoDesconto.GrupoPreços, ERP.Util.EnumERP.ModuloGrupoPrecoDesconto.Compras);
            }
            else if (Tipo == "Produtos")
            {
                cboGrupoPrecoDesconto.DataSource = new GrupoPrecoDescontoDAL().GetComboByModulo(3);
            }

            cboGrupoPrecoDesconto.DisplayMember = "Text";
            cboGrupoPrecoDesconto.ValueMember = "iValue";
            cboGrupoPrecoDesconto.SelectedIndex = -1;
        }

        protected void CarregaGrupoPrecoDescontoProduto()
        {
            cboGrupoPrecoDescontoProduto.DataSource = new GrupoPrecoDescontoDAL().GetComboByModulo(3);
            cboGrupoPrecoDescontoProduto.DisplayMember = "Text";
            cboGrupoPrecoDescontoProduto.ValueMember = "iValue";
            cboGrupoPrecoDescontoProduto.SelectedIndex = -1;
        }

        private void CarregaGrid()
        {
            var lista = dal.GetItens(cc.IdContratoComercial);

            dgv.DataSource = lista;
            dgv.AutoGenerateColumns = false;
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtValor.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtValorPercentual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtValorPercentual.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtDe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboRelacao_Leave(object sender, EventArgs e)
        {
            ValidacaoCodigo();
            ValidacaoRelacaoItem();
        }

        private void cboCodigo_Leave(object sender, EventArgs e)
        {
            cboCliente.SelectedIndex = -1;
            cboGrupoDescontoVarejista.SelectedIndex = -1;
            cboFornecedor.SelectedIndex = -1;
            cboGrupoPrecoDesconto.SelectedIndex = -1;

            ValidacaoCodigo();
        }

        private void ValidacaoCodigo()
        {
            int relacao = 0;
            if (!String.IsNullOrEmpty(cboRelacao.Text))
                relacao = Convert.ToInt32(cboRelacao.SelectedValue);

            cboCliente.Enabled = false;
            cboCliente.Tag = "";
            cboGrupoDescontoVarejista.Enabled = false;
            cboGrupoDescontoVarejista.Tag = "";
            cboFornecedor.Enabled = false;
            cboFornecedor.Tag = "";
            cboGrupoPrecoDesconto.Enabled = false;
            cboGrupoPrecoDesconto.Tag = "";

            // 1 - Preço de Compra, 2 - Desconto de linha (Compras), 3 - DescontoCombinadoCompras, 4 - DescontoTotal (Compras)
            // Ao selecionar o Código:
            // Tabela: Se selecionada essa opção o ID Fornecedor, passa a ser obrigatório;
            // Grupo: se selecionada essa opção o IDGrupoPreçosedesconto, passa a ser obrigatório, só deverá aparecer na tela os grupos correspondentes a baseenum Grupo de preços, com baseenum do Compras.
            // Todos: Os campos ID Fornecedor e ID de Grupo ficam fechado para a seleção.

            // 5 - Preço de Venda, 6 - Desconto de linha (Vendas), 7 - DescontoCombinadoVendas, 8 - DescontoTotal (Vendas)
            // Tabela: se selecionada essa opção o ID Cliente, passa a ser obrigatório;
            // Grupo: se selecionada essa opção o IDGrupoPreçosedesconto, passa a ser obrigatório, só deverá aparecer na tela os grupos correspondentes a baseenum Grupo de preços, com baseenum do Vendas.
            // Todos: Os campos ID Cliente e ID de Grupo ficam fechados para a seleção.

            // 9 - Desconto Varejista
            // Tabela: se selecionada essa opção o ID Cliente, passa a ser obrigatório;
            // Grupo: essa opção não será considera para desconto varejo.
            // Todos: essa opção não será considera para desconto varejo.

            if (relacao == 1 || relacao == 2 || relacao == 3 || relacao == 4)
            {
                if (Convert.ToInt32(cboCodigo.SelectedValue) == 1)     // Tabela
                {
                    cboFornecedor.Enabled = true;
                    cboFornecedor.Tag = "1";
                }
                else if (Convert.ToInt32(cboCodigo.SelectedValue) == 2) // Grupo
                {
                    cboFornecedor.Enabled = true;

                    if (relacao != 2)
                    {
                        cboGrupoPrecoDesconto.Enabled = true;
                        cboGrupoPrecoDesconto.Tag = "1";

                        CarregaGrupoPrecoDesconto("Compras");
                    }
                }
                else if (Convert.ToInt32(cboCodigo.SelectedValue) == 3) // Todos
                {
                }
            }
            else if (relacao == 5 || relacao == 6 || relacao == 7 || relacao == 8)
            {
                if (Convert.ToInt32(cboCodigo.SelectedValue) == 1)     // Tabela
                {
                    cboCliente.Enabled = true;
                    cboCliente.Tag = "1";
                }
                else if (Convert.ToInt32(cboCodigo.SelectedValue) == 2) // Grupo
                {
                    cboCliente.Enabled = true;

                    cboGrupoPrecoDesconto.Enabled = true;
                    cboGrupoPrecoDesconto.Tag = "1";

                    CarregaGrupoPrecoDesconto("Vendas");
                }
                else if (Convert.ToInt32(cboCodigo.SelectedValue) == 3) // Todos
                {
                }
            }
            if (relacao == 9)
            {
                if (Convert.ToInt32(cboCodigo.SelectedValue) == 1)     // Tabela
                {
                    cboCliente.Enabled = true;
                    cboCliente.Tag = "1";
                    //cboGrupoDescontoVarejista.Enabled = false;
                    cboGrupoDescontoVarejista.Tag = "0";
                }
                else if (Convert.ToInt32(cboCodigo.SelectedValue) == 2)     // Grupo
                {
                    Util.Aplicacao.ShowMessage("A opção Grupo não se aplica para desconto de varejo!");
                    cboCodigo.SelectedIndex = -1;
                }
                else if (Convert.ToInt32(cboCodigo.SelectedValue) == 3)     // Todos
                {
                    Util.Aplicacao.ShowMessage("A opção Todos não se aplica para desconto de varejo!");
                    cboCodigo.SelectedIndex = -1;
                }
            }
        }

        private void ValidacaoCodigoAlterar()
        {
            int relacao = 0;
            if (!String.IsNullOrEmpty(cboRelacao.Text))
                relacao = Convert.ToInt32(cboRelacao.SelectedValue);

            cboCliente.Enabled = false;
            cboCliente.Tag = "";
            cboGrupoDescontoVarejista.Enabled = false;
            cboGrupoDescontoVarejista.Tag = "";
            cboFornecedor.Enabled = false;
            cboFornecedor.Tag = "";
            cboGrupoPrecoDesconto.Enabled = false;
            cboGrupoPrecoDesconto.Tag = "";

            // 1 - Preço de Compra, 2 - Desconto de linha (Compras), 3 - DescontoCombinadoCompras, 4 - DescontoTotal (Compras)
            // Ao selecionar o Código:
            // Tabela: Se selecionada essa opção o ID Fornecedor, passa a ser obrigatório;
            // Grupo: se selecionada essa opção o IDGrupoPreçosedesconto, passa a ser obrigatório, só deverá aparecer na tela os grupos correspondentes a baseenum Grupo de preços, com baseenum do Compras.
            // Todos: Os campos ID Fornecedor e ID de Grupo ficam fechado para a seleção.

            // 5 - Preço de Venda, 6 - Desconto de linha (Vendas), 7 - DescontoCombinadoVendas, 8 - DescontoTotal (Vendas)
            // Tabela: se selecionada essa opção o ID Cliente, passa a ser obrigatório;
            // Grupo: se selecionada essa opção o IDGrupoPreçosedesconto, passa a ser obrigatório, só deverá aparecer na tela os grupos correspondentes a baseenum Grupo de preços, com baseenum do Vendas.
            // Todos: Os campos ID Cliente e ID de Grupo ficam fechados para a seleção.

            // 9 - Desconto Varejista
            // Tabela: se selecionada essa opção o ID Cliente, passa a ser obrigatório;
            // Grupo: essa opção não será considera para desconto varejo.
            // Todos: essa opção não será considera para desconto varejo.

            if (relacao == 1 || relacao == 2 || relacao == 3 || relacao == 4)
            {
                if (Convert.ToInt32(cboCodigo.SelectedValue) == 1)     // Tabela
                {
                    cboFornecedor.Enabled = true;
                    cboFornecedor.Tag = "1";
                }
                else if (Convert.ToInt32(cboCodigo.SelectedValue) == 2) // Grupo
                {
                    cboFornecedor.Enabled = true;

                    if (relacao != 2)
                    {
                        cboGrupoPrecoDesconto.Enabled = true;
                        cboGrupoPrecoDesconto.Tag = "1";

                        
                    }
                }
                else if (Convert.ToInt32(cboCodigo.SelectedValue) == 3) // Todos
                {
                }
            }
            else if (relacao == 5 || relacao == 6 || relacao == 7 || relacao == 8)
            {
                if (Convert.ToInt32(cboCodigo.SelectedValue) == 1)     // Tabela
                {
                    cboCliente.Enabled = true;
                    cboCliente.Tag = "1";
                }
                else if (Convert.ToInt32(cboCodigo.SelectedValue) == 2) // Grupo
                {
                    cboCliente.Enabled = true;

                    cboGrupoPrecoDesconto.Enabled = true;
                    cboGrupoPrecoDesconto.Tag = "1";
                    
                }
                else if (Convert.ToInt32(cboCodigo.SelectedValue) == 3) // Todos
                {
                }
            }
            if (relacao == 9)
            {
                if (Convert.ToInt32(cboCodigo.SelectedValue) == 1)     // Tabela
                {
                    cboCliente.Enabled = true;
                    cboCliente.Tag = "1";
                    cboGrupoDescontoVarejista.Enabled = true;
                    cboGrupoDescontoVarejista.Tag = "1";
                }
                else if (Convert.ToInt32(cboCodigo.SelectedValue) == 2)     // Grupo
                {
                    Util.Aplicacao.ShowMessage("A opção Grupo não se aplica para desconto de varejo!");
                    cboCodigo.SelectedIndex = -1;
                }
                else if (Convert.ToInt32(cboCodigo.SelectedValue) == 3)     // Todos
                {
                    Util.Aplicacao.ShowMessage("A opção Todos não se aplica para desconto de varejo!");
                    cboCodigo.SelectedIndex = -1;
                }
            }
        }

        private void cboRelacaoItem_Leave(object sender, EventArgs e)
        {
            cboProduto.SelectedIndex = -1;
            cboGrupoPrecoDescontoProduto.SelectedIndex = -1;

            ValidacaoRelacaoItem();
        }

        private void ValidacaoRelacaoItem()
        {
            int relacao = 0;
            if (!String.IsNullOrEmpty(cboRelacao.Text))
                relacao = Convert.ToInt32(cboRelacao.SelectedValue);

            cboProduto.Enabled = false;
            cboProduto.Tag = "";
            cboGrupoPrecoDescontoProduto.Enabled = false;
            cboGrupoPrecoDescontoProduto.Tag = "";

            cboUnidade.Tag = "";

            // 1 - Preço de Compra, 2 - Desconto de linha (Compras), 3 - DescontoCombinadoCompras, 4 - DescontoTotal (Compras)
            // 5 - Preço de Venda, 6 - Desconto de linha (Vendas), 7 - DescontoCombinadoVendas, 8 - DescontoTotal (Vendas)
            // Tabela: se selecionada essa opção o ID Produto, passa a ser obrigatório;
            // Grupo : se selecionada essa opção o IDGrupoPrecoeDesconto, passa a ser obrigatório, só deverá aparecer na tela os grupos correspondentes a baseenum Grupo Desconto, com baseenum do Produto.
            // Todos: Os campos ID Produto e IDGrupoProduto ficam fechado para a seleção.

            if (relacao == 1 || relacao == 2 || relacao == 3 || relacao == 4 || relacao == 5 || relacao == 6 || relacao == 7 || relacao == 8)
            {
                if (Convert.ToInt32(cboRelacaoItem.SelectedValue) == 1) // Tabela
                {
                    cboProduto.Enabled = true;
                    cboProduto.Tag = "1";
                }
                else if (Convert.ToInt32(cboRelacaoItem.SelectedValue) == 2) // Grupo
                {
                    cboProduto.Enabled = true;

                    cboGrupoPrecoDescontoProduto.Enabled = true;
                    cboGrupoPrecoDescontoProduto.Tag = "";

                    CarregaGrupoPrecoDescontoProduto();
                }
                else if (Convert.ToInt32(cboRelacaoItem.SelectedValue) == 3) // Todos
                {
                }
            }
            else
            {
                if(cboRelacao.Text != "")
                {
                    cboGrupoDescontoVarejista.Enabled = true;
                }
                
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cc.IdContratoComercial == 0)
            {
                Util.Aplicacao.ShowMessage("O contrato comercial não se encontra disponível para edição.");
                return;
            }

            ContratoComercialCondPgto cccp = new ContratoComercialCondPgto();

            frmContratoComercialCondPgtoAux cad = new frmContratoComercialCondPgtoAux(cccp, cc.IdContratoComercial);
            cad.ShowDialog();
            CarregaGrid();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    
                    ContratoComercialCondPgtoDAL cccpDAL = new ContratoComercialCondPgtoDAL();
                    ContratoComercialCondPgto cccp = new ContratoComercialCondPgto();
                    cccp = cccpDAL.GetByID(id);

                    frmContratoComercialCondPgtoAux cad = new frmContratoComercialCondPgtoAux(cccp, cc.IdContratoComercial);
                    cad.ShowDialog();
                    CarregaGrid();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }

        private void cboCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidacaoCodigo();
            cboCliente.SelectedIndex = -1;
            cboGrupoDescontoVarejista.SelectedIndex = -1;
            cboFornecedor.SelectedIndex = -1;
            cboGrupoPrecoDesconto.SelectedIndex = -1;
        }

        private void cboRelacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboRelacao.SelectedValue.ToString() == "9")
                {
                    cboGrupoDescontoVarejista.Enabled = true;
                }
            }
            catch
            {
                 
            }
            
        }

        private void frmContratoComercialCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");

            }
        }
    }
}
