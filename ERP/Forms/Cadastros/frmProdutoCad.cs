using ERP.Auxiliares;
using ERP.DAL;
using ERP.DAL.Cadastros;
using ERP.DAL.Fiscal;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmProdutoCad : RibbonForm
    {
        Produto p = new Produto();
        ProdutoCentroCustoDAL ccDal = new ProdutoCentroCustoDAL();
        DB_ERPContext dbcontext = new DB_ERPContext();
        public ProdutoDAL dal = new ProdutoDAL();
        Configuracao confEmpresa = new ConfiguracaoDAL().GetByEmpresa(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));

        public frmProdutoCad(Produto pProd, ProdutoDAL pdal)
        {
            p = pProd;
            this.dal = pdal;
            InitializeComponent();

        }

        public frmProdutoCad()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void CarregaDados()
        {
            Cursor.Current = Cursors.WaitCursor;
            
            //Carrega os dados
            txtCodigo.Text = p.Codigo;
            txtDescricao.Text = p.Descricao;
            txtNomeProduto.Text = p.NomeProduto;
            //cboEmpresa.SelectedValue = p.IdEmpresa;
            cboTipoProduto.SelectedValue = p.IdTipoProduto == null ? 0 : p.IdTipoProduto;

            if (p.IdVariantesGrupo != null)
                cboVariantesGrupo.SelectedValue = p.IdVariantesGrupo;
            if (p.IdVariantesConfig != null)
                cboVariantesConfig.SelectedValue = p.IdVariantesConfig;
            if (p.IdVariantesTamanho != null)
                cboVariantesTamanho.SelectedValue = p.IdVariantesTamanho;
            if (p.IdVariantesCor != null)
                cboVariantesCor.SelectedValue = p.IdVariantesCor;
            if (p.IdVariantesEstilo != null)
                cboVariantesEstilo.SelectedValue = p.IdVariantesEstilo;
            if (p.ComprasIdUnidade != null)
                cboUnidadeCompras.SelectedValue = p.ComprasIdUnidade;
            txtEntregaExcedente.Text = p.ComprasEntregaExcedente.ToString();
            txtEntregaInsuficiente.Text = p.ComprasEntregaInsuficiente.ToString();
            if (p.ComprasIdGrupoImposto != null)
                cboComprasGrupoImpostos.SelectedValue = p.ComprasIdGrupoImposto;
            chkComprasRetencaoNaFonte.Checked = p.ComprasRetencaoFonte;
            if (p.ComprasIdGrupoImpostoRetiro != null)
                cboComprasGrupoImpostoRetiro.SelectedValue = p.ComprasIdGrupoImpostoRetiro;
            if (p.ComprasIdGrupoEncargos != null)
                cboComprasGrupoEncargos.SelectedValue = p.ComprasIdGrupoEncargos;
            txtEncargosSobrePreco.Text = p.ComprasEncargosSobrePreco.ToString();
            chkComprasIncluirNoPrecoUnitario.Checked = p.ComprasIncluiNoPrecoUnitario;
            if (p.ComprasIdGrupoDesconto != null)
            {
                cboComprasGrupoDescontos.SelectedValue = p.ComprasIdGrupoDesconto == null ? 0 : p.ComprasIdGrupoDesconto;
            }
            if (p.ComprasIdGrupoPreco != null)
            {
                cboComprasGrupoPreco.SelectedValue = p.ComprasIdGrupoPreco == null ? 0 : p.ComprasIdGrupoPreco;
            }
            if (p.ComprasIdGrupoItensSuplementares != null)
                cboComprasGrupoItensSuplementares.SelectedValue = p.ComprasIdGrupoItensSuplementares;
            chkComprasProdutoDescontinuado.Checked = p.CompraProdDescontinuado;
            if (p.VendaIdUnidade != null)
                cboVendasUnidade.SelectedValue = p.VendaIdUnidade;
            txtVendasEntregaExcedente.Text = p.VendaEntregaExcedente.ToString();
            txtVendasEntregaInsuficiente.Text = p.VendaEntregaInsuficiente.ToString();
            if (p.VendaIdGrupoImposto != null)
                cboVendasGrupoImpostos.SelectedValue = p.VendaIdGrupoImposto;
            chkVendasRetencaoFonte.Checked = p.VendaRetencaoFonte;
            if (p.VendaGrupoImpostoRetido != null)
                cboVendasGrupoImpostosRetido.SelectedValue = p.VendaGrupoImpostoRetido;
            if (p.VendaIdGrupoEncargos != null)
                cboVendasGrupoEncargos.SelectedValue = p.VendaIdGrupoEncargos;
            txtVendaEncargoSobrePreco.Text = p.VendaEncargosSobrePreco.ToString();
            chkVendasIncluirNoPrecoUnitario.Checked = p.VendaIncluirNoPrecoUnitario;
            if (p.VendaIdGrupoDesconto != null)
                //cboVendasGrupoDescontos.SelectedValue = p.VendaIdGrupoDesconto;
                cboMarkup.SelectedValue = p.VendaMarkup == null ? 0 : p.VendaMarkup;
            txtVendasIndiceContribuicao.Text = p.VendaIndiceContribuicao.ToString();
            txtVendasPercentualEncargos.Text = p.VendaPercentualEncargos.ToString();
            cboVendasUsarProdutoAlternativo.SelectedValue = p.VendaUsarProdutoAlternativo.ToString();
            cboVendasProdutoAlternativo.SelectedValue = p.VendaIdProdutoAlternativo == null ? 0 : p.VendaIdProdutoAlternativo;
            txtVendasPreco.Text = p.VendaPreco.ToString();
            txtVendasPrecoUnidade.Text = p.VendaPrecoUnidade.ToString();
            txtVendasPrecoQuantidade.Text = p.VendaPrecoQuantidade.ToString();
            cboProdutoAcabadoMateriaPrima.SelectedValue = p.ProdutoAcabadoMateriaPrima == null ? 0 : p.ProdutoAcabadoMateriaPrima;
            txtEstoqueMinimo.Text = p.EstoqueMinimo == null ? "" : p.EstoqueMinimo.ToString();
            txtVendaPrecoUnit.Text = p.VendaPrecoUnit.ToString();
            txtVendaMargemLucro.Text = p.VendaMagemLucro.ToString();

            if (p.VendaPrecoIdGrupoDesconto != null)
            {
                cboVendasGrupoDesconto.SelectedValue = p.VendaPrecoIdGrupoDesconto == null ? 0 : p.VendaPrecoIdGrupoDesconto;
            }
            if (p.VendaIdGrupoPreco != null)
            {
                cboVendasGrupoPreco.SelectedValue = p.VendaIdGrupoPreco == null ? 0 : p.VendaIdGrupoPreco;
            }

            if (p.VendaPrecoIdGrupoAlocacaoFrete != null)
                cboVendasPrecoGrupoAlocacaoFrete.SelectedValue = p.VendaPrecoIdGrupoAlocacaoFrete;
            cboVendasAtualizaPrecoBase.SelectedValue = p.VendaAtualizaPrecoBase.ToString();
            chkVendasProdDescontinuado.Checked = p.VendaProdDescontinuado;
            txtExtCodMercadoria.Text = p.ComExtCodMercadoria;
            txtExtPercentualEncargos.Text = p.ComExtPercentualEncargos.ToString();
            if (p.ComExtIdPais != null)
                cboExtIdPais.SelectedValue = p.ComExtIdPais;
            txtExtCidade.Text = p.ComExtCidade;
            if (p.EstoqueIdUnidade != null)
                cboEstoqueUnidade.SelectedValue = p.EstoqueIdUnidade;
            txtEstoquePeso.Text = p.EstoquePeso.ToString();
            txtEstoqueTara.Text = p.EstoqueTara.ToString();
            txtEstoquePesoBruto.Text = p.EstqouePesoBruto.ToString();
            txtEstoqueProdundidade.Text = p.EstoqueProfundidade.ToString();
            txtEstoqueLargura.Text = p.EstoqueLargura.ToString();
            txtEstoqueAltura.Text = p.EstoqueAltura.ToString();
            txtEstoqueVolume.Text = p.EstoqueVolume.ToString();
            if (p.EstoqueIdGrupoLotes != null)
                cboEstoqueGrupoLotes.SelectedValue = p.EstoqueIdGrupoLotes;
            if (p.EstoqueIdGrupoSeries != null)
                cboEstoqueGrupoSeries.SelectedValue = p.EstoqueIdGrupoSeries;
            if (p.EstoqueIdEmbalagem != null)
                cboEstoqueEmbalagem.SelectedValue = p.EstoqueIdEmbalagem;
            txtEstoqueQtdeEmbalagem.Text = p.EstoqueQtdeEmbalagem.ToString();
            txtEstoqueTempoManuseio.Text = p.EstoqueTempoManuseio.ToString();
            txtEstoqueTempoPrateleira.Text = p.EstoqueTempoPrateleira.ToString();
            txtEstoqueValidadeDias.Text = p.EstoqueValidadeDias.ToString();
            if (p.ProducaoIdUnidade != null)
                cboProducaoUnidade.SelectedValue = p.ProducaoIdUnidade;
            txtQuantidadeProducao.Text = p.QtdeProducao.ToString();
            txtProducaoLargura.Text = p.ProducaoLargura.ToString();
            txtProducaoAltura.Text = p.ProducaoAltura.ToString();
            txtProducaoDensidade.Text = p.ProducaoDensidade.ToString();
            txtProducaoSucataConstante.Text = p.ProducaoSucataConstante.ToString();
            txtProducaoSucataVariavel.Text = p.ProducaoSucataVariavel.ToString();
            if (p.ProducaoIdPerfil != null)
                cboProducaoPerfil.SelectedValue = p.ProducaoIdPerfil;
            if (p.ProducaoIdGrupoProducao != null)
                cboProducaoGrupoProducao.SelectedValue = p.ProducaoIdGrupoProducao;
            cboProducaoLiberacao.SelectedValue = p.ProducaoLiberacao == null ? 0 : p.ProducaoLiberacao;
            cboTipoProducao.SelectedValue = p.ProducaoTipoProducao == null ? 0 : p.ProducaoTipoProducao;
            cboItemPlanejamento.SelectedValue = p.ProducaoItemPlanejamento == null ? 0 : Convert.ToInt32(p.ProducaoItemPlanejamento);
            if (p.ProducaoIdPlanoMestre != null)
                cboProducaoPlanoMestre.SelectedValue = p.ProducaoIdPlanoMestre;
            if (p.CustoIdGrupoLancamento != null)
                cboCustoGrupoLancamento.SelectedValue = p.CustoIdGrupoLancamento;
            if (p.CustoIdGrupoCusto != null)
                cboCustoGrupoCusto.SelectedValue = p.CustoIdGrupoCusto;
            txtCustoCustoVariante.Text = p.CustoCustoVariante.ToString();
            chkCustoAtualizarUltimoCusto.Checked = p.CustoAtualizarUltimoCusto;
            cboABCAliquota.SelectedIndex = p.CustoABCAliquota != null ? Convert.ToInt32(p.CustoABCAliquota) : -1;
            cboABCMargem.SelectedIndex = p.CustoABCMargem != null ? Convert.ToInt32(p.CustoABCMargem) : -1;
            cboABCReceita.SelectedIndex = p.CustoABCReceita != null ? Convert.ToInt32(p.CustoABCReceita) : -1;
            cboABCManutencao.SelectedIndex = p.CustoABCManutencao != null ? Convert.ToInt32(p.CustoABCManutencao) : -1;
            if (p.FiscalOrigem != null)
                cboFiscalOrigem.SelectedValue = p.FiscalOrigem;
            if (p.FiscalIdNCM != null)
                cboFiscalNCM.SelectedValue = p.FiscalIdNCM;
            txtFiscalNCMExcessao.Text = p.FiscalNCMExcecao.ToString();
            if (p.FicalIdTipoItem != null)
                cboFiscalTipoItem.SelectedValue = p.FicalIdTipoItem;
            if (p.FiscalIdCodigoServico != null)
                cboFiscalCodigoServico.SelectedValue = p.FiscalIdCodigoServico;
            chkFiscalICMSServico.Checked = p.FiscalICMSServico;
            txtFiscalPercentualAproximando.Text = p.FiscalPercentualAprox.ToString();
            chkEstoqueProdDescontinuado.Checked = p.EstoqueProdDescontinuado;
            chkProducaoProdDescontinuado.Checked = p.ProducaoProdDescontinuado;
            cboGrupoEstoque.SelectedValue = p.IdGrupoEstoque == null ? 0 : p.IdGrupoEstoque;
            cboGrupoRastreamento.SelectedValue = p.IdGrupoRastreamento == null ? 0 : p.IdGrupoRastreamento;
            cboGrupoArmazenamento.SelectedValue = p.IdGrupoArmazenamento == null ? 0 : p.IdGrupoArmazenamento;
            cboGrupoProduto.SelectedValue = p.IdGrupoProduto == null ? 0 : Convert.ToInt32(p.IdGrupoProduto);
            cboCest.SelectedValue = p.IdCest == null ? 0 : p.IdCest;

            CarregaGridConversao();
            CarregaCentrosdeCusto();

            Cursor.Current = Cursors.Default;
        }

        protected void CarregaCentrosdeCusto()
        {
            var lista = ccDal.GetByProduto(p.IdProduto);
            dgCentros.AutoGenerateColumns = false;
            dgCentros.DataSource = lista;
        }

        private void CarregaCombos()
        {
            List<ComboItem> ListaSim = new List<ComboItem>();
            ListaSim.Add(new ComboItem { Value = "Sim", Text = "Sim" });
            ListaSim.Add(new ComboItem { Value = "Não", Text = "Não" });

            cboTipoProduto.DataSource = new TipoProdutoDAL().Get();
            cboTipoProduto.ValueMember = "IdTipoProduto";
            cboTipoProduto.DisplayMember = "Nome";
            cboTipoProduto.SelectedIndex = -1;


            cboProducaoUnidade.DataSource = new UnidadeDAL().Get();
            cboProducaoUnidade.DisplayMember = "Descricao";
            cboProducaoUnidade.ValueMember = "IdUnidade";
            cboProducaoUnidade.SelectedIndex = -1;

            cboUnidadeCompras.DataSource = new UnidadeDAL().Get();
            cboUnidadeCompras.DisplayMember = "Descricao";
            cboUnidadeCompras.ValueMember = "IdUnidade";
            cboUnidadeCompras.SelectedIndex = -1;

            cboVendasUnidade.DataSource = new UnidadeDAL().Get();
            cboVendasUnidade.DisplayMember = "Descricao";
            cboVendasUnidade.ValueMember = "IdUnidade";
            cboVendasUnidade.SelectedIndex = -1;

            cboEstoqueUnidade.DataSource = new UnidadeDAL().Get();
            cboEstoqueUnidade.DisplayMember = "Descricao";
            cboEstoqueUnidade.ValueMember = "IdUnidade";
            cboEstoqueUnidade.SelectedIndex = -1;

            cboVariantesGrupo.DataSource = new VariantesGrupoDAL().Get();
            cboVariantesGrupo.DisplayMember = "Descricao";
            cboVariantesGrupo.ValueMember = "IdVariantesGrupo";
            cboVariantesGrupo.SelectedIndex = -1;

            cboVariantesConfig.DataSource = new VariantesConfigDAL().Get();
            cboVariantesConfig.ValueMember = "IdVariantesConfig";
            cboVariantesConfig.DisplayMember = "Descricao";
            cboVariantesConfig.SelectedIndex = -1;

            cboVariantesTamanho.DataSource = new VariantesTamanhoDAL().Get();
            cboVariantesTamanho.ValueMember = "IdVariantesTamanho";
            cboVariantesTamanho.DisplayMember = "Descricao";
            cboVariantesTamanho.SelectedIndex = -1;

            cboVariantesCor.DataSource = new VariantesCorDAL().Get();
            cboVariantesCor.ValueMember = "IdVariantesCor";
            cboVariantesCor.DisplayMember = "Descricao";
            cboVariantesCor.SelectedIndex = -1;

            cboGrupoProduto.DataSource = new GrupoProdutoDAL().GetCombo();
            cboGrupoProduto.DisplayMember = "Text";
            cboGrupoProduto.ValueMember = "iValue";
            cboGrupoProduto.SelectedIndex = -1;

            cboVariantesEstilo.DataSource = new VariantesEstiloDAL().Get();
            cboVariantesEstilo.ValueMember = "IdVariantesEstilo";
            cboVariantesEstilo.DisplayMember = "Descricao";
            cboVariantesEstilo.SelectedIndex = -1;

            cboComprasGrupoImpostos.DataSource = new GrupoImpostoItemDAL().GetCombo();
            cboComprasGrupoImpostos.DisplayMember = "Text";
            cboComprasGrupoImpostos.ValueMember = "iValue";
            cboComprasGrupoImpostos.SelectedIndex = -1;

            cboVendasGrupoImpostos.DataSource = new GrupoImpostoItemDAL().GetCombo();
            cboVendasGrupoImpostos.DisplayMember = "Text";
            cboVendasGrupoImpostos.ValueMember = "iValue";
            cboVendasGrupoImpostos.SelectedIndex = -1;

            cboComprasGrupoImpostoRetiro.DataSource = new GrupoImpostoRetidoItemDAL().GetCombo();
            cboComprasGrupoImpostoRetiro.DisplayMember = "Text";
            cboComprasGrupoImpostoRetiro.ValueMember = "iValue";
            cboComprasGrupoImpostoRetiro.SelectedIndex = -1;

            cboVendasGrupoImpostosRetido.DataSource = new GrupoImpostoRetidoItemDAL().GetCombo();
            cboVendasGrupoImpostosRetido.DisplayMember = "Text";
            cboVendasGrupoImpostosRetido.ValueMember = "iValue";
            cboVendasGrupoImpostosRetido.SelectedIndex = -1;

            cboComprasGrupoEncargos.DataSource = new GrupoEncargosDAL().getCombo();
            cboComprasGrupoEncargos.DisplayMember = "Text";
            cboComprasGrupoEncargos.ValueMember = "iValue";
            cboComprasGrupoEncargos.SelectedIndex = -1;

            cboComprasGrupoItensSuplementares.DataSource = new GrupoItensSuplementaresDAL().getCombo();
            cboComprasGrupoItensSuplementares.DisplayMember = "Text";
            cboComprasGrupoItensSuplementares.ValueMember = "iValue";
            cboComprasGrupoItensSuplementares.SelectedIndex = -1;

            cboVendasProdutoAlternativo.DataSource = new ProdutoDAL().GetComboVendas();
            cboVendasProdutoAlternativo.DisplayMember = "Text";
            cboVendasProdutoAlternativo.ValueMember = "iValue";
            cboVendasProdutoAlternativo.SelectedIndex = -1;

            cboVendasPrecoGrupoAlocacaoFrete.DataSource = new GrupoAlocacaoFreteDAL().GetCombo();
            cboVendasPrecoGrupoAlocacaoFrete.DisplayMember = "Text";
            cboVendasPrecoGrupoAlocacaoFrete.ValueMember = "iValue";
            cboVendasPrecoGrupoAlocacaoFrete.SelectedIndex = -1;

            cboVendasGrupoEncargos.DataSource = new GrupoEncargosDAL().getCombo();
            cboVendasGrupoEncargos.DisplayMember = "Text";
            cboVendasGrupoEncargos.ValueMember = "iValue";
            cboVendasGrupoEncargos.SelectedIndex = -1;

            cboComprasGrupoDescontos.DataSource = new GrupoPrecoDescontoDAL().GetComboByModuloDesconto(3);
            cboComprasGrupoDescontos.DisplayMember = "Text";
            cboComprasGrupoDescontos.ValueMember = "iValue";
            cboComprasGrupoDescontos.SelectedIndex = -1;

            cboComprasGrupoPreco.DataSource = new GrupoPrecoDescontoDAL().GetComboByModuloPreco(3);
            cboComprasGrupoPreco.DisplayMember = "Text";
            cboComprasGrupoPreco.ValueMember = "iValue";
            cboComprasGrupoPreco.SelectedIndex = -1;

            cboVendasGrupoDesconto.DataSource = new GrupoPrecoDescontoDAL().GetComboByModuloDesconto(3);
            cboVendasGrupoDesconto.DisplayMember = "Text";
            cboVendasGrupoDesconto.ValueMember = "iValue";
            cboVendasGrupoDesconto.SelectedIndex = -1;

            cboVendasGrupoPreco.DataSource = new GrupoPrecoDescontoDAL().GetComboByModuloPreco(3);
            cboVendasGrupoPreco.DisplayMember = "Text";
            cboVendasGrupoPreco.ValueMember = "iValue";
            cboVendasGrupoPreco.SelectedIndex = -1;

            cboComprasGrupoItensSuplementares.DataSource = new GrupoItensSuplementaresDAL().Get();
            cboComprasGrupoItensSuplementares.DisplayMember = "Descricao";
            cboComprasGrupoItensSuplementares.ValueMember = "IdGrupoItensSuplementares";
            cboComprasGrupoItensSuplementares.SelectedIndex = -1;

            List<ComboItem> ListaItemAlternativo = new List<ComboItem>();
            ListaItemAlternativo.Add(new ComboItem() { Text = "Sempre", Value = "1" });
            ListaItemAlternativo.Add(new ComboItem() { Text = "Sem Estoque", Value = "2" });
            ListaItemAlternativo.Add(new ComboItem() { Text = "Nunca", Value = "3" });

            cboVendasUsarProdutoAlternativo.DataSource = ListaItemAlternativo;
            cboVendasUsarProdutoAlternativo.DisplayMember = "Text";
            cboVendasUsarProdutoAlternativo.ValueMember = "Value";
            cboVendasUsarProdutoAlternativo.SelectedIndex = -1;

            cboVendasPrecoGrupoAlocacaoFrete.DataSource = new GrupoAlocacaoFreteDAL().Get();
            cboVendasPrecoGrupoAlocacaoFrete.DisplayMember = "Descricao";
            cboVendasPrecoGrupoAlocacaoFrete.ValueMember = "IdGrupoAlocacaoFrete";
            cboVendasPrecoGrupoAlocacaoFrete.SelectedIndex = -1;

            List<ComboItem> ListaAtualizaPreco = new List<ComboItem>();
            ListaAtualizaPreco.Add(new ComboItem() { Text = "Preço compra", Value = "1" });
            ListaAtualizaPreco.Add(new ComboItem() { Text = "Custo", Value = "2" });

            cboVendasAtualizaPrecoBase.DataSource = ListaAtualizaPreco;
            cboVendasAtualizaPrecoBase.DisplayMember = "Text";
            cboVendasAtualizaPrecoBase.ValueMember = "Value";
            cboVendasAtualizaPrecoBase.SelectedIndex = -1;

            cboExtIdPais.DataSource = new PaisDAL().Get();
            cboExtIdPais.DisplayMember = "NomePais";
            cboExtIdPais.ValueMember = "IdPais";
            cboExtIdPais.SelectedIndex = -1;

            cboEstoqueEmbalagem.DataSource = new EmbalagemDAL().Get();
            cboEstoqueEmbalagem.DisplayMember = "Descricao";
            cboEstoqueEmbalagem.ValueMember = "IdEmbalagem";
            cboEstoqueEmbalagem.SelectedIndex = -1;

            cboEstoqueGrupoLotes.DataSource = new GrupoLotesDAL().Get();
            cboEstoqueGrupoLotes.DisplayMember = "Descricao";
            cboEstoqueGrupoLotes.ValueMember = "IdGrupoLotes";
            cboEstoqueGrupoLotes.SelectedIndex = -1;

            cboEstoqueGrupoSeries.DataSource = new GrupoSeriesDAL().Get();
            cboEstoqueGrupoSeries.DisplayMember = "Descricao";
            cboEstoqueGrupoSeries.ValueMember = "IdGrupoSeries";
            cboEstoqueGrupoSeries.SelectedIndex = -1;

            cboCustoGrupoLancamento.DataSource = new GrupoLancamentoDAL().Get();
            cboCustoGrupoLancamento.DisplayMember = "Descricao";
            cboCustoGrupoLancamento.ValueMember = "IdGrupoLancamento";
            cboCustoGrupoLancamento.SelectedIndex = -1;

            cboCustoGrupoCusto.DataSource = new GrupoCustoDAL().Get();
            cboCustoGrupoCusto.DisplayMember = "Descricao";
            cboCustoGrupoCusto.ValueMember = "IdGrupoCusto";
            cboCustoGrupoCusto.SelectedIndex = -1;

            cboProducaoGrupoProducao.DataSource = new GrupoProducaoDAL().Get();
            cboProducaoGrupoProducao.DisplayMember = "Descricao";
            cboProducaoGrupoProducao.ValueMember = "IdGrupoProducao";
            cboProducaoGrupoProducao.SelectedIndex = -1;

            cboProducaoPlanoMestre.DataSource = new PlanoMestreDAL().Get();
            cboProducaoPlanoMestre.DisplayMember = "Descricao";
            cboProducaoPlanoMestre.ValueMember = "IdPlanoMestre";
            cboProducaoPlanoMestre.SelectedIndex = -1;

            cboProducaoPerfil.DataSource = new PerfilProducaoDAL().GetCombo();
            cboProducaoPerfil.DisplayMember = "Text";
            cboProducaoPerfil.ValueMember = "iValue";
            cboProducaoPerfil.SelectedIndex = -1;

            cboItemPlanejamento.DataSource = new ProdutoDAL().GetComboProducao();
            cboItemPlanejamento.DisplayMember = "Text";
            cboItemPlanejamento.ValueMember = "iValue";
            cboItemPlanejamento.SelectedIndex = -1;

            cboFiscalNCM.DataSource = new ClassificacaoFiscalDAL().GetCombo();
            cboFiscalNCM.DisplayMember = "Text";
            cboFiscalNCM.ValueMember = "iValue";
            cboFiscalNCM.SelectedIndex = -1;

            cboCest.DataSource = new CESTDAL().GetCombo();
            cboCest.ValueMember = "iValue";
            cboCest.DisplayMember = "Text";
            cboCest.SelectedIndex = -1;


            List<ComboItem> ficaltpitem = new List<ComboItem>();
            ficaltpitem.Add(new ComboItem() { iValue = 1, Text = "00- Mercadoria para Revenda" });
            ficaltpitem.Add(new ComboItem() { iValue = 2, Text = "01-Matéria Prima" });
            ficaltpitem.Add(new ComboItem() { iValue = 3, Text = "02- Embalagem" });
            ficaltpitem.Add(new ComboItem() { iValue = 4, Text = "03-Produto em Processo" });
            ficaltpitem.Add(new ComboItem() { iValue = 5, Text = "04- Produto Acabado" });
            ficaltpitem.Add(new ComboItem() { iValue = 6, Text = "05- Subproduto" });
            ficaltpitem.Add(new ComboItem() { iValue = 7, Text = "06- Produto Intermediario" });
            ficaltpitem.Add(new ComboItem() { iValue = 8, Text = "07- Material de uso/ Consumo" });
            ficaltpitem.Add(new ComboItem() { iValue = 9, Text = "08- Ativo Imobilizado" });
            ficaltpitem.Add(new ComboItem() { iValue = 10, Text = "09 - Serviços" });
            ficaltpitem.Add(new ComboItem() { iValue = 11, Text = "10- Outros Insumos" });
            ficaltpitem.Add(new ComboItem() { iValue = 12, Text = "99- Outros" });
            cboFiscalTipoItem.DataSource = ficaltpitem;
            cboFiscalTipoItem.DisplayMember = "Text";
            cboFiscalTipoItem.ValueMember = "iValue";
            cboFiscalTipoItem.SelectedIndex = -1;

            cboFiscalCodigoServico.DataSource = new CodigoServicoDAL().Get();
            cboFiscalCodigoServico.DisplayMember = "Nome";
            cboFiscalCodigoServico.ValueMember = "IdCodigoServico";
            cboFiscalCodigoServico.SelectedIndex = -1;


            cboGrupoEstoque.DataSource = new GrupoEstoqueDAL().GetCombo();
            cboGrupoEstoque.DisplayMember = "Text";
            cboGrupoEstoque.ValueMember = "iValue";
            cboGrupoEstoque.SelectedIndex = -1;

            cboGrupoRastreamento.DataSource = new GrupoRastreamentoDAL().GetCombo();
            cboGrupoRastreamento.DisplayMember = "Text";
            cboGrupoRastreamento.ValueMember = "iValue";
            cboGrupoRastreamento.SelectedIndex = -1;

            cboGrupoArmazenamento.DataSource = new GrupoArmazenamentoDAL().GetCombo();
            cboGrupoArmazenamento.DisplayMember = "Text";
            cboGrupoArmazenamento.ValueMember = "iValue";
            cboGrupoArmazenamento.SelectedIndex = -1;

            List<ComboItem> ProdutoAcabado = new List<ComboItem>();
            ProdutoAcabado.Add(new ComboItem() { iValue = 1, Text = "Matéria Prima" });
            ProdutoAcabado.Add(new ComboItem() { iValue = 2, Text = "Produto Acabado" });
            ProdutoAcabado.Add(new ComboItem() { iValue = 3, Text = "Insumos" });

            cboProdutoAcabadoMateriaPrima.DataSource = ProdutoAcabado;
            cboProdutoAcabadoMateriaPrima.DisplayMember = "Text";
            cboProdutoAcabadoMateriaPrima.ValueMember = "iValue";
            //cboProdutoAcabadoMateriaPrima.SelectedIndex = -1;



            List<ComboItem> Markup = new List<ComboItem>();
            Markup.Add(new ComboItem() { iValue = 1, Text = "Nenhum" });
            Markup.Add(new ComboItem() { iValue = 2, Text = "Índice de contribuição" });
            Markup.Add(new ComboItem() { iValue = 3, Text = "Percentual Encargos" });
            cboMarkup.DataSource = Markup;
            cboMarkup.DisplayMember = "Text";
            cboMarkup.ValueMember = "iValue";
            cboMarkup.SelectedIndex = -1;

            List<ComboItem> LiberacaoProducao = new List<ComboItem>();
            LiberacaoProducao.Add(new ComboItem() { iValue = 1, Text = "Inicio" });
            LiberacaoProducao.Add(new ComboItem() { iValue = 2, Text = "Conclusão" });
            LiberacaoProducao.Add(new ComboItem() { iValue = 3, Text = "Manual" });
            cboProducaoLiberacao.DataSource = LiberacaoProducao;
            cboProducaoLiberacao.DisplayMember = "Text";
            cboProducaoLiberacao.ValueMember = "iValue";
            cboProducaoLiberacao.SelectedIndex = -1;


            List<ComboItem> TipoProducao = new List<ComboItem>();
            TipoProducao.Add(new ComboItem() { iValue = 1, Text = "Nenhum" });
            TipoProducao.Add(new ComboItem() { iValue = 2, Text = "Co-Produto" });
            TipoProducao.Add(new ComboItem() { iValue = 3, Text = "Sub-Produto" });
            TipoProducao.Add(new ComboItem() { iValue = 4, Text = "Item de planejamento" });
            TipoProducao.Add(new ComboItem() { iValue = 5, Text = "BOM" });
            TipoProducao.Add(new ComboItem() { iValue = 6, Text = "Formula" });
            cboTipoProducao.DataSource = TipoProducao;
            cboTipoProducao.DisplayMember = "Text";
            cboTipoProducao.ValueMember = "iValue";
            cboTipoProducao.SelectedIndex = -1;

            List<ComboItem> FiscalOrigem = new List<ComboItem>();
            FiscalOrigem.Add(new ComboItem() { iValue = 0, Text = "Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8" });
            FiscalOrigem.Add(new ComboItem() { iValue = 1, Text = "Estrangeira - Importação direta, exceto a indicada no código 6" });
            FiscalOrigem.Add(new ComboItem() { iValue = 2, Text = "Estrangeira - Adquirida no mercado interno, exceto a indicada no código 7. " });
            FiscalOrigem.Add(new ComboItem() { iValue = 3, Text = "Nacional, mercadoria ou bem com Conteúdo de Importação superior a 40% (quarenta por cento) e inferior ou igual a 70% (setenta por cento)" });
            FiscalOrigem.Add(new ComboItem() { iValue = 4, Text = "Nacional, cuja produção tenha sido feita em conformidade com os processos produtivos básicos de que tratam o Decreto-Lei nº 288/67, e as Leis nºs 8.248/91, 8.387/91, 10.176/01 e 11.484/ 07" });
            FiscalOrigem.Add(new ComboItem() { iValue = 5, Text = "Nacional, mercadoria ou bem com Conteúdo de Importação inferior ou igual a 40% (quarenta por cento)" });
            FiscalOrigem.Add(new ComboItem() { iValue = 6, Text = "Estrangeira - Importação direta, sem similar nacional, constante em lista da Resolução CAMEX nº 79/2012 e gás natural." });
            FiscalOrigem.Add(new ComboItem() { iValue = 7, Text = "Estrangeira - Adquirida no mercado interno, sem similar nacional, constante em lista da Resolução CAMEX nº 79/2012 e gás natural" });
            FiscalOrigem.Add(new ComboItem() { iValue = 8, Text = "Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70% (setenta por cento)." });
            cboFiscalOrigem.DataSource = FiscalOrigem;
            cboFiscalOrigem.DisplayMember = "Text";
            cboFiscalOrigem.ValueMember = "iValue";
            cboFiscalOrigem.SelectedIndex = -1;


            if (p.IdProduto != 0)
            {
                btnAddConversao.Enabled = true;
                dgvConversao.Enabled = true;
            }
            else
            {
                btnAddConversao.Enabled = false;
                dgvConversao.Enabled = false;
            }
        }

        #region ConversaoUnidade
        private void CarregaGridConversao()
        {
            var lista = dal.getItensConversao(p.IdProduto).ToList();
            dgvConversao.DataSource = lista;
            dgvConversao.AutoGenerateColumns = false;
            dgvConversao.RowHeadersVisible = false;
        }

        private void btnAddConversao_Click(object sender, EventArgs e)
        {
            ConversaoUnidade cu = new ConversaoUnidade();
            cu.IdProduto = p.IdProduto;
            frmConversaoUnidadeAddItem addItem = new frmConversaoUnidadeAddItem(dal, cu);
            addItem.ShowDialog();
            CarregaGridConversao();
        }

        private void dgvConversao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvConversao.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dgvConversao.Rows[e.RowIndex].Cells[0].Value.ToString());
                    ConversaoUnidade cu = dal.ConversaoRepository.GetByID(id);
                    frmConversaoUnidadeAddItem cad = new frmConversaoUnidadeAddItem(dal, cu);
                    cad.ShowDialog();
                    CarregaGridConversao();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
            }
        }


        #endregion

        private void frmProdutoCad_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregaCombos();
            if (p.IdProduto == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmProdutoCad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            p = new Produto();
            Util.Aplicacao.LimpaControles(this);
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            try
            {
                txtVendasIndiceContribuicao.Tag = "";
                txtVendasPercentualEncargos.Tag = "";
                if (!String.IsNullOrEmpty(cboMarkup.Text))
                {
                    if (cboMarkup.SelectedValue == "2")
                    {
                        txtVendasIndiceContribuicao.Tag = 1;
                    }

                    if (cboMarkup.SelectedValue == "3")
                    {
                        txtVendasPercentualEncargos.Tag = 1;
                    }
                }

                if(!String.IsNullOrEmpty(cboTipoProduto.Text))
                {
                    if (cboTipoProduto.SelectedValue.ToString() == "1")
                    {
                        cboFiscalOrigem.Tag = "1";
                        cboFiscalNCM.Tag = "1";
                        cboFiscalCodigoServico.Tag = "";
                    }
                    else
                    {
                        cboFiscalOrigem.Tag = "";
                        cboFiscalNCM.Tag = "";
                        cboFiscalCodigoServico.Tag = "1";
                    }
                }
                

                if (Util.Validacao.ValidaCampos(this))
                {
                    //limpa os campos antes de atribuir valor
                    p.Codigo = null;
                    p.CustoCustoVariante = null;
                    p.Descricao = null;
                    p.ComprasEncargosSobrePreco = null;
                    p.ComprasEntregaExcedente = null;
                    p.ComprasEntregaInsuficiente = null;
                    p.EstoqueAltura = null;
                    p.EstoqueLargura = null;
                    p.EstoquePeso = null;
                    p.EstqouePesoBruto = null;
                    p.EstoqueProfundidade = null;
                    p.EstoqueQtdeEmbalagem = null;
                    p.EstoqueTara = null;
                    p.EstoqueTempoManuseio = null;
                    p.EstoqueTempoPrateleira = null;
                    p.EstoqueValidadeDias = null;
                    p.EstoqueVolume = null;
                    p.ComExtCidade = null;
                    p.ComExtCodMercadoria = null;
                    p.ComExtPercentualEncargos = null;
                    p.FiscalNCMExcecao = null;
                    p.FiscalPercentualAprox = null;
                    p.CustoABCAliquota = null;
                    p.CustoABCManutencao = null;
                    p.CustoABCMargem = null;
                    p.CustoABCReceita = null;
                    p.ComprasIdGrupoEncargos = null;
                    p.ComprasIdGrupoImpostoRetiro = null;
                    p.ComprasIdGrupoImposto = null;
                    p.ComprasIdGrupoItensSuplementares = null;
                    p.CustoIdGrupoCusto = null;
                    p.CustoIdGrupoLancamento = null;
                    p.EstoqueIdEmbalagem = null;
                    p.EstoqueIdGrupoLotes = null;
                    p.EstoqueIdGrupoSeries = null;
                    p.EstoqueIdUnidade = null;
                    p.ComExtIdPais = null;
                    p.FiscalIdCodigoServico = null;
                    p.FiscalIdNCM = null;
                    p.FiscalOrigem = null;
                    p.FicalIdTipoItem = null;
                    p.IdGrupoArmazenamento = null;
                    p.IdGrupoEstoque = null;
                    p.IdGrupoProduto = null;
                    p.IdGrupoRastreamento = null;
                    p.VendaMarkup = null;
                    p.ProducaoIdGrupoProducao = null;
                    p.ProducaoLiberacao = null;
                    p.ProducaoIdPerfil = null;
                    p.ProducaoIdPlanoMestre = null;
                    p.ProducaoIdUnidade = null;
                    p.ProducaoTipoProducao = null;
                    p.IdTipoProduto = null;
                    p.ComprasIdUnidade = null;
                    p.IdVariantesConfig = null;
                    p.IdVariantesCor = null;
                    p.IdVariantesEstilo = null;
                    p.IdVariantesGrupo = null;
                    p.IdVariantesTamanho = null;
                    p.VendaAtualizaPrecoBase = null;
                    p.VendaIdGrupoEncargos = null;
                    p.VendaIdGrupoImposto = null;
                    p.VendaGrupoImpostoRetido = null;
                    p.VendaPrecoIdGrupoAlocacaoFrete = null;
                    p.VendaPrecoIdGrupoDesconto = null;
                    p.VendaIdProdutoAlternativo = null;
                    p.VendaIdUnidade = null;
                    p.VendaUsarProdutoAlternativo = null;
                    p.NomeProduto = null;
                    p.ProducaoAltura = null;
                    p.ProducaoDensidade = null;
                    p.ProducaoItemPlanejamento = null;
                    p.ProducaoLargura = null;
                    p.ProducaoProfundidade = null;
                    p.ProducaoSucataConstante = null;
                    p.ProducaoSucataVariavel = null;
                    p.VendaEncargosSobrePreco = null;
                    p.VendaEntregaExcedente = null;
                    p.VendaEntregaInsuficiente = null;
                    p.VendaIndiceContribuicao = null;
                    p.VendaPercentualEncargos = null;
                    p.VendaPreco = null;
                    p.VendaPrecoQuantidade = null;
                    p.VendaPrecoUnidade = null;
                    p.ProdutoAcabadoMateriaPrima = null;
                    p.IdCest = null;
                    //Carrega os dados
                    p.IdEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
                    p.Codigo = txtCodigo.Text;
                    p.Descricao = txtDescricao.Text;
                    p.NomeProduto = txtNomeProduto.Text;

                    if (!String.IsNullOrEmpty(cboTipoProduto.Text)) p.IdTipoProduto = Convert.ToInt32(cboTipoProduto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboVariantesGrupo.Text)) p.IdVariantesGrupo = Convert.ToInt32(cboVariantesGrupo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboVariantesConfig.Text)) p.IdVariantesConfig = Convert.ToInt32(cboVariantesConfig.SelectedValue);
                    if (!String.IsNullOrEmpty(cboVariantesTamanho.Text)) p.IdVariantesTamanho = Convert.ToInt32(cboVariantesTamanho.SelectedValue);
                    if (!String.IsNullOrEmpty(cboVariantesCor.Text)) p.IdVariantesCor = Convert.ToInt32(cboVariantesCor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboVariantesEstilo.Text)) p.IdVariantesEstilo = Convert.ToInt32(cboVariantesEstilo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboUnidadeCompras.Text)) p.ComprasIdUnidade = Convert.ToInt32(cboUnidadeCompras.SelectedValue);
                    if (!String.IsNullOrEmpty(txtEntregaExcedente.Text)) p.ComprasEntregaExcedente = Convert.ToDecimal(txtEntregaExcedente.Text);
                    if (!String.IsNullOrEmpty(txtEntregaInsuficiente.Text)) p.ComprasEntregaInsuficiente = Convert.ToDecimal(txtEntregaInsuficiente.Text);
                    if (!String.IsNullOrEmpty(cboComprasGrupoImpostos.Text)) p.ComprasIdGrupoImposto = Convert.ToInt32(cboComprasGrupoImpostos.SelectedValue);
                    if (!String.IsNullOrEmpty(cboProdutoAcabadoMateriaPrima.Text)) p.ProdutoAcabadoMateriaPrima = Convert.ToInt32(cboProdutoAcabadoMateriaPrima.SelectedValue);

                    p.ComprasRetencaoFonte = chkComprasRetencaoNaFonte.Checked;
                    if (!String.IsNullOrEmpty(cboComprasGrupoImpostoRetiro.Text))
                        p.ComprasIdGrupoImpostoRetiro = Convert.ToInt32(cboComprasGrupoImpostoRetiro.SelectedValue);
                    if (!String.IsNullOrEmpty(cboComprasGrupoEncargos.Text))
                        p.ComprasIdGrupoEncargos = Convert.ToInt32(cboComprasGrupoEncargos.SelectedValue);
                    if (!String.IsNullOrEmpty(txtEncargosSobrePreco.Text))
                        p.ComprasEncargosSobrePreco = Convert.ToDecimal(txtEncargosSobrePreco.Text);
                    p.ComprasIncluiNoPrecoUnitario = chkComprasIncluirNoPrecoUnitario.Checked;
                    if (!String.IsNullOrEmpty(cboComprasGrupoDescontos.Text))
                        p.ComprasIdGrupoDesconto = Convert.ToInt32(cboComprasGrupoDescontos.SelectedValue);
                    if (!String.IsNullOrEmpty(cboComprasGrupoPreco.Text))
                        p.ComprasIdGrupoPreco = Convert.ToInt32(cboComprasGrupoPreco.SelectedValue);
                    if (!String.IsNullOrEmpty(cboComprasGrupoItensSuplementares.Text))
                        p.ComprasIdGrupoItensSuplementares = Convert.ToInt32(cboComprasGrupoItensSuplementares.SelectedValue);
                    if (!String.IsNullOrEmpty(cboVendasUnidade.Text))
                        p.VendaIdUnidade = Convert.ToInt32(cboVendasUnidade.SelectedValue);
                    if (!String.IsNullOrEmpty(txtVendasEntregaExcedente.Text))
                        p.VendaEntregaExcedente = Convert.ToDecimal(txtVendasEntregaExcedente.Text);
                    if (!String.IsNullOrEmpty(txtVendasEntregaInsuficiente.Text))
                        p.VendaEntregaInsuficiente = Convert.ToDecimal(txtVendasEntregaInsuficiente.Text);
                    if (!String.IsNullOrEmpty(cboVendasGrupoImpostos.Text))
                        p.VendaIdGrupoImposto = Convert.ToInt32(cboVendasGrupoImpostos.SelectedValue);
                    p.VendaRetencaoFonte = chkVendasRetencaoFonte.Checked;
                    if (!String.IsNullOrEmpty(cboVendasGrupoImpostosRetido.Text))
                        p.VendaGrupoImpostoRetido = Convert.ToInt32(cboVendasGrupoImpostosRetido.SelectedValue);
                    if (!String.IsNullOrEmpty(cboVendasGrupoEncargos.Text))
                        p.VendaIdGrupoEncargos = Convert.ToInt32(cboVendasGrupoEncargos.SelectedValue);
                    if (!String.IsNullOrEmpty(txtVendaEncargoSobrePreco.Text))
                        p.VendaEncargosSobrePreco = Convert.ToDecimal(txtVendaEncargoSobrePreco.Text);
                    p.VendaIncluirNoPrecoUnitario = chkVendasIncluirNoPrecoUnitario.Checked;

                    if (!String.IsNullOrEmpty(cboMarkup.Text)) p.VendaMarkup = Convert.ToInt32(cboMarkup.SelectedValue);
                    if (!String.IsNullOrEmpty(txtVendasIndiceContribuicao.Text))
                        p.VendaIndiceContribuicao = Convert.ToDecimal(txtVendasIndiceContribuicao.Text);
                    if (!String.IsNullOrEmpty(txtVendasPercentualEncargos.Text))
                        p.VendaPercentualEncargos = Convert.ToDecimal(txtVendasPercentualEncargos.Text);
                    if (!String.IsNullOrEmpty(cboVendasUsarProdutoAlternativo.Text))
                        p.VendaUsarProdutoAlternativo = Convert.ToInt32(cboVendasUsarProdutoAlternativo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboVendasProdutoAlternativo.Text))
                        p.VendaIdProdutoAlternativo = Convert.ToInt32(cboVendasProdutoAlternativo.SelectedValue);
                    if (!String.IsNullOrEmpty(txtVendasPreco.Text))
                        p.VendaPreco = Convert.ToDecimal(txtVendasPreco.Text);
                    if (!String.IsNullOrEmpty(txtVendasPrecoUnidade.Text))
                        p.VendaPrecoUnidade = Convert.ToDecimal(txtVendasPrecoUnidade.Text);
                    if (!String.IsNullOrEmpty(txtVendasPrecoQuantidade.Text))
                        p.VendaPrecoQuantidade = Convert.ToDecimal(txtVendasPrecoQuantidade.Text);
                    if (!String.IsNullOrEmpty(cboVendasGrupoDesconto.Text))
                        p.VendaPrecoIdGrupoDesconto = Convert.ToInt32(cboVendasGrupoDesconto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboVendasGrupoPreco.Text))
                        p.VendaIdGrupoPreco = Convert.ToInt32(cboVendasGrupoPreco.SelectedValue);
                    if (!String.IsNullOrEmpty(cboVendasPrecoGrupoAlocacaoFrete.Text))
                        p.VendaPrecoIdGrupoAlocacaoFrete = Convert.ToInt32(cboVendasPrecoGrupoAlocacaoFrete.SelectedValue);
                    if (!String.IsNullOrEmpty(cboVendasAtualizaPrecoBase.Text))
                        p.VendaAtualizaPrecoBase = Convert.ToInt32(cboVendasAtualizaPrecoBase.SelectedValue);

                    p.EstoqueMinimo = null;
                    if (!string.IsNullOrEmpty(txtEstoqueMinimo.Text))
                    {
                        p.EstoqueMinimo = Convert.ToDecimal(txtEstoqueMinimo.Text);
                    }

                    p.VendaProdDescontinuado = chkVendasProdDescontinuado.Checked;
                    p.ComExtCodMercadoria = txtExtCodMercadoria.Text;
                    if (!String.IsNullOrEmpty(txtExtPercentualEncargos.Text))
                        p.ComExtPercentualEncargos = Convert.ToDecimal(txtExtPercentualEncargos.Text);
                    if (!String.IsNullOrEmpty(cboExtIdPais.Text))
                        p.ComExtIdPais = Convert.ToInt32(cboExtIdPais.SelectedValue);
                    p.ComExtCidade = txtExtCidade.Text;
                    if (!String.IsNullOrEmpty(cboEstoqueUnidade.Text))
                        p.EstoqueIdUnidade = Convert.ToInt32(cboEstoqueUnidade.SelectedValue);
                    if (!String.IsNullOrEmpty(txtEstoquePeso.Text))
                        p.EstoquePeso = Convert.ToDecimal(txtEstoquePeso.Text);
                    if (!String.IsNullOrEmpty(txtEstoqueTara.Text))
                        p.EstoqueTara = Convert.ToDecimal(txtEstoqueTara.Text);
                    if (!String.IsNullOrEmpty(txtEstoquePesoBruto.Text))
                        p.EstqouePesoBruto = Convert.ToDecimal(txtEstoquePesoBruto.Text);
                    if (!String.IsNullOrEmpty(txtEstoqueProdundidade.Text))
                        p.EstoqueProfundidade = Convert.ToDecimal(txtEstoqueProdundidade.Text);
                    if (!String.IsNullOrEmpty(txtEstoqueLargura.Text))
                        p.EstoqueLargura = Convert.ToDecimal(txtEstoqueLargura.Text);
                    if (!String.IsNullOrEmpty(txtEstoqueAltura.Text))
                        p.EstoqueAltura = Convert.ToDecimal(txtEstoqueAltura.Text);
                    if (!String.IsNullOrEmpty(txtEstoqueVolume.Text))
                        p.EstoqueVolume = Convert.ToDecimal(txtEstoqueVolume.Text);
                    if (!String.IsNullOrEmpty(cboEstoqueGrupoLotes.Text))
                        p.EstoqueIdGrupoLotes = Convert.ToInt32(cboEstoqueGrupoLotes.SelectedValue);
                    if (!String.IsNullOrEmpty(cboEstoqueGrupoSeries.Text))
                        p.EstoqueIdGrupoSeries = Convert.ToInt32(cboEstoqueGrupoSeries.SelectedValue);
                    if (!String.IsNullOrEmpty(cboEstoqueEmbalagem.Text))
                        p.EstoqueIdEmbalagem = Convert.ToInt32(cboEstoqueEmbalagem.SelectedValue);
                    if (!String.IsNullOrEmpty(txtEstoqueQtdeEmbalagem.Text))
                        p.EstoqueQtdeEmbalagem = Convert.ToDecimal(txtEstoqueQtdeEmbalagem.Text);
                    if (!String.IsNullOrEmpty(txtEstoqueTempoManuseio.Text))
                        p.EstoqueTempoManuseio = Convert.ToInt32(txtEstoqueTempoManuseio.Text);
                    if (!String.IsNullOrEmpty(txtEstoqueTempoPrateleira.Text))
                        p.EstoqueTempoPrateleira = Convert.ToInt32(txtEstoqueTempoPrateleira.Text);
                    if (!String.IsNullOrEmpty(txtEstoqueValidadeDias.Text))
                        p.EstoqueValidadeDias = Convert.ToInt32(txtEstoqueValidadeDias.Text);
                    if (!String.IsNullOrEmpty(cboProducaoUnidade.Text))
                        p.ProducaoIdUnidade = Convert.ToInt32(cboProducaoUnidade.SelectedValue);
                    if (!String.IsNullOrEmpty(txtQuantidadeProducao.Text))
                        p.QtdeProducao = Convert.ToDecimal(txtQuantidadeProducao.Text);
                    if (!String.IsNullOrEmpty(txtProducaoLargura.Text))
                        p.ProducaoLargura = Convert.ToDecimal(txtProducaoLargura.Text);
                    if (!String.IsNullOrEmpty(txtProducaoAltura.Text))
                        p.ProducaoAltura = Convert.ToDecimal(txtProducaoAltura.Text);
                    if (!String.IsNullOrEmpty(txtProducaoDensidade.Text))
                        p.ProducaoDensidade = Convert.ToDecimal(txtProducaoDensidade.Text);
                    if (!String.IsNullOrEmpty(txtProducaoSucataConstante.Text))
                        p.ProducaoSucataConstante = Convert.ToDecimal(txtProducaoSucataConstante.Text);
                    if (!String.IsNullOrEmpty(txtProducaoSucataVariavel.Text))
                        p.ProducaoSucataVariavel = Convert.ToDecimal(txtProducaoSucataVariavel.Text);
                    if (!String.IsNullOrEmpty(cboProducaoPerfil.Text))
                        p.ProducaoIdPerfil = Convert.ToInt32(cboProducaoPerfil.SelectedValue);
                    if (!String.IsNullOrEmpty(cboProducaoGrupoProducao.Text))
                        p.ProducaoIdGrupoProducao = Convert.ToInt32(cboProducaoGrupoProducao.SelectedValue);

                    if (!String.IsNullOrEmpty(cboProducaoLiberacao.Text)) p.ProducaoLiberacao = Convert.ToInt32(cboProducaoLiberacao.SelectedValue);

                    if (!String.IsNullOrEmpty(cboTipoProducao.Text)) p.ProducaoTipoProducao = Convert.ToInt32(cboTipoProducao.SelectedValue);

                    if (!String.IsNullOrEmpty(cboItemPlanejamento.Text))
                        p.ProducaoItemPlanejamento = Convert.ToInt32(cboItemPlanejamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboProducaoPlanoMestre.Text))
                        p.ProducaoIdPlanoMestre = Convert.ToInt32(cboProducaoPlanoMestre.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCustoGrupoLancamento.Text))
                        p.CustoIdGrupoLancamento = Convert.ToInt32(cboCustoGrupoLancamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCustoGrupoCusto.Text))
                        p.CustoIdGrupoCusto = Convert.ToInt32(cboCustoGrupoCusto.SelectedValue);
                    if (!String.IsNullOrEmpty(txtCustoCustoVariante.Text))
                        p.CustoCustoVariante = Convert.ToDecimal(txtCustoCustoVariante.Text);
                    p.CustoAtualizarUltimoCusto = chkCustoAtualizarUltimoCusto.Checked;
                    if (!String.IsNullOrEmpty(cboABCAliquota.Text)) p.CustoABCAliquota = cboABCAliquota.SelectedIndex;
                    if (!String.IsNullOrEmpty(cboABCMargem.Text)) p.CustoABCMargem = cboABCMargem.SelectedIndex;
                    if (!String.IsNullOrEmpty(cboABCReceita.Text)) p.CustoABCReceita = cboABCReceita.SelectedIndex;
                    if (!String.IsNullOrEmpty(cboABCManutencao.Text)) p.CustoABCManutencao = cboABCManutencao.SelectedIndex;
                    if (!String.IsNullOrEmpty(cboFiscalOrigem.Text)) p.FiscalOrigem = Convert.ToInt32(cboFiscalOrigem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboFiscalNCM.Text))
                        p.FiscalIdNCM = Convert.ToInt32(cboFiscalNCM.SelectedValue);
                    if (!String.IsNullOrEmpty(txtFiscalNCMExcessao.Text))
                        p.FiscalNCMExcecao = Convert.ToInt32(txtFiscalNCMExcessao.Text);
                    if (!String.IsNullOrEmpty(cboFiscalTipoItem.Text))
                        p.FicalIdTipoItem = Convert.ToInt32(cboFiscalTipoItem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboFiscalCodigoServico.Text))
                        p.FiscalIdCodigoServico = Convert.ToInt32(cboFiscalCodigoServico.SelectedValue);
                    p.FiscalICMSServico = chkFiscalICMSServico.Checked;
                    if (!String.IsNullOrEmpty(txtFiscalPercentualAproximando.Text))
                        p.FiscalPercentualAprox = Convert.ToDecimal(txtFiscalPercentualAproximando.Text);

                    p.EstoqueProdDescontinuado = chkEstoqueProdDescontinuado.Checked;
                    p.ProducaoProdDescontinuado = chkProducaoProdDescontinuado.Checked;
                    p.CompraProdDescontinuado = chkComprasProdutoDescontinuado.Checked;

                    if (!String.IsNullOrEmpty(cboGrupoEstoque.Text)) p.IdGrupoEstoque = Convert.ToInt32(cboGrupoEstoque.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoRastreamento.Text)) p.IdGrupoRastreamento = Convert.ToInt32(cboGrupoRastreamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoArmazenamento.Text)) p.IdGrupoArmazenamento = Convert.ToInt32(cboGrupoArmazenamento.SelectedValue);
                    if (!String.IsNullOrEmpty(cboGrupoProduto.Text)) p.IdGrupoProduto = Convert.ToInt32(cboGrupoProduto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCest.Text)) p.IdCest = Convert.ToInt32(cboCest.SelectedValue);

                    p.VendaPrecoUnit = Convert.ToDecimal(txtVendaPrecoUnit.Text);
                    p.VendaMagemLucro = Convert.ToDecimal(txtVendaMargemLucro.Text);


                    p.ComprasIdUnidade = p.VendaIdUnidade;
                    p.EstoqueIdUnidade = p.VendaIdUnidade;
                    p.ProducaoIdUnidade = p.VendaIdUnidade;
                    p.IdEmpresa = 1;

                    if (p.IdProduto == 0)
                    {
                        //verifica se o codigo ou nome do produto existe
                        if (dal.Exist(p.Codigo, p.NomeProduto) != null)
                        {
                            Util.Aplicacao.ShowMessage("Existe um produto com o mesmo código ou nome.");
                            return;
                        }

                        dal.ProdutoRepository.Insert(p);
                    }
                    else
                    {
                        dal.ProdutoRepository.Update(p);
                    }

                    dal.Save();
                    CarregaDados();
                    Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
                }
                else
                {
                    Util.Aplicacao.ShowMessage("Por favor verifique as informações faltantes.");
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowErrorMessage(ex);
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
            try
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = p.IdProduto;
                    dal.ProdutoRepository.Delete(id);
                    dal.Save();
                    Close();
                }
            }
            catch (Exception ex)
            {
                Util.Aplicacao.ShowMessage("Este registro não pode ser excluído." + "\n" + "\n" + "Erro: " + ex.Message);
            }
        }

        private void txtEntregaExcedente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtEntregaExcedente.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtEntregaInsuficiente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtEntregaInsuficiente.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtEncargosSobrePreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtEncargosSobrePreco.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtVendasEntregaExcedente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtVendasEntregaExcedente.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtVendasEntregaInsuficiente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtVendasEntregaInsuficiente.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtVendaEncargoSobrePreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtVendaEncargoSobrePreco.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtVendasIndiceContribuicao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtVendasIndiceContribuicao.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtVendasPercentualEncargos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtVendasPercentualEncargos.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtVendasPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtVendasPreco.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtVendasPrecoUnidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtVendasPrecoUnidade.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtVendasPrecoQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtVendasPrecoQuantidade.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtExtPercentualEncargos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtExtPercentualEncargos.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtEstoquePeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtEstoquePeso.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtEstoqueTara_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtEstoqueTara.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtEstoquePesoBruto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtEstoquePesoBruto.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtEstoqueProdundidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtEstoqueProdundidade.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtEstoqueLargura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtEstoqueLargura.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtEstoqueAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtEstoqueAltura.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtEstoqueVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtEstoqueVolume.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtEstoqueQtdeEmbalagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtEstoqueQtdeEmbalagem.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtEstoqueTempoManuseio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEstoqueTempoPrateleira_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEstoqueValidadeDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtProducaoProfundidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtQuantidadeProducao.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtProducaoLargura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtProducaoLargura.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtProducaoAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtProducaoAltura.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtProducaoDensidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtProducaoDensidade.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtProducaoSucataConstante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtProducaoSucataConstante.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtProducaoSucataVariavel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtProducaoSucataVariavel.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtCustoCustoVariante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtCustoCustoVariante.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtFiscalPercentualAproximando_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtFiscalPercentualAproximando.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void tabEstoque_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTipoProduto_Leave(object sender, EventArgs e)
        {
            if (confEmpresa == null) confEmpresa = new Configuracao();
            if (cboTipoProduto.Text != "")
            {
                if (cboTipoProduto.SelectedValue.ToString() == "1")//item
                {
                    cboFiscalCodigoServico.Tag = "";
                    if(Convert.ToBoolean(confEmpresa.UsarPadraoEstoque))
                    {
                        if (String.IsNullOrEmpty(cboGrupoRastreamento.Text)) cboGrupoRastreamento.SelectedValue = confEmpresa.IdGrupoRastreabilidadeProduto == null ? 0 : Convert.ToInt32(confEmpresa.IdGrupoRastreabilidadeProduto);
                        if (String.IsNullOrEmpty(cboGrupoArmazenamento.Text)) cboGrupoArmazenamento.SelectedValue = confEmpresa.IdGrupoArmazenamentoProduto == null ? 0 : Convert.ToInt32(confEmpresa.IdGrupoArmazenamentoProduto);
                        if (String.IsNullOrEmpty(cboGrupoEstoque.Text)) cboGrupoEstoque.SelectedValue = confEmpresa.IdGrupoEstoqueProduto == null ? 0 : Convert.ToInt32(confEmpresa.IdGrupoEstoqueProduto);
                    }
                }
                else
                {
                    cboFiscalCodigoServico.Tag = "1";
                    {
                        if (String.IsNullOrEmpty(cboGrupoRastreamento.Text)) cboGrupoRastreamento.SelectedValue = confEmpresa.IdGrupoRastreabilidadeServico == null ? 0 : Convert.ToInt32(confEmpresa.IdGrupoRastreabilidadeServico);
                        if (String.IsNullOrEmpty(cboGrupoArmazenamento.Text)) cboGrupoArmazenamento.SelectedValue = confEmpresa.IdGrupoArmazemServico == null ? 0 : Convert.ToInt32(confEmpresa.IdGrupoArmazemServico);
                        if (String.IsNullOrEmpty(cboGrupoEstoque.Text)) cboGrupoEstoque.SelectedValue = confEmpresa.IdGrupoEstoqueServico == null ? 0 : Convert.ToInt32(confEmpresa.IdGrupoEstoqueServico);
                    }
                }
            }
        }

        private void cboFiscalNCM_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboFiscalNCM.Text))
            {
                int IdNCM = Convert.ToInt32(cboFiscalNCM.SelectedValue);
                ClassificacaoFiscal cl = new ClassificacaoFiscal();
                cl = new ClassificacaoFiscalDAL().GetByID(IdNCM);
                cboCest.SelectedValue = cl.IdCest == null ? 0 : cl.IdCest;

            }
        }

        private void toolStripBtAdicionar_Click(object sender, EventArgs e)
        {
            if (p.IdProduto == 0)
            {
                Util.Aplicacao.ShowMessage("Salve os dados do produto antes de adicionar centros de custo.");
                return;
            }
            frmCentroCustoAux frmCC = new frmCentroCustoAux("PR", p.IdProduto);
            frmCC.prdal = ccDal;
            frmCC.ShowDialog();
            CarregaCentrosdeCusto();
        }

        private void toolStripBtExcluir_Click(object sender, EventArgs e)
        {
            if (dgCentros.Rows.Count > 0)
            {
                if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir o centro de custo selecionado?") == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgCentros.Rows[dgCentros.SelectedRows[0].Index].Cells[0].Value);
                    try
                    {
                        ccDal.Delete(id);
                        ccDal.Save();
                        CarregaCentrosdeCusto();
                    }
                    catch (Exception ex)
                    {
                        Util.Aplicacao.ShowErrorMessage(ex);
                    }
                }
            }
        }
    }
}
