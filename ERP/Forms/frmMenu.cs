using ERP.Aprovacao;
using ERP.Cadastros;
using ERP.DAL;
using ERP.Estoques;
using ERP.Financeiro;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmMenu : RibbonForm
    {
        public int idUsuario = 0;
        public int idEmpresa = 0;

        public frmMenu()
        {
            InitializeComponent();
           // naviBar1.Collapsed = true;
            Util.ErrorUtil.ValidaUsoMenu(DateTime.Now);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            idUsuario = Convert.ToInt32(Util.Util.GetAppSettings("IdUsuario"));
            idEmpresa = Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa"));
            Util.Aplicacao.Permissao(this, idUsuario);
            MontaFavoritos();

            //
            ConfiguracaoDAL confDal = new ConfiguracaoDAL();
            decimal? Versao = confDal.ConsultaVersao();
            lbVersao.Text = "ERP MGA Soluções - Versão do Sistema: " + Versao.ToString().Replace(",", ".");
        }

        private void chamarFormulario<T>() where T : Form, new()
        {
            var form = new T();

            pnlMenus.Visible = false;
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == form.GetType())
                {
                    f.Activate();
                    return;
                }
            }
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            ListaJanelas();
            form.Show();
        }

        private void chamarTabelaPadrao(string formulario, string tag, string tituloFormulario)
        {
            pnlMenus.Visible = false;
            Form form = new frmTabelas(formulario);
            form.MdiParent = this;
            form.Tag = tag;
            form.Text = tituloFormulario;
            form.WindowState = FormWindowState.Maximized;
            ListaJanelas();
            form.Show();
        }

        //Monta a lisatagem de favoritos
        private void MontaFavoritos()
        {
            List<Favoritos> Favoritos = new FavoritosDAL().getByUsuario(idUsuario);
            treeView1.Nodes.Clear();

            List<TreeNode> treeNodes = new List<TreeNode>();
            List<TreeNode> Forms = new List<TreeNode>();
            List<TreeNode> Reports = new List<TreeNode>();

            //Adiciona os menus Principal e Configurações
            //TreeNode Principal = new TreeNode();
            //Principal.Text = "Principal";
            //Principal.Tag = "Principal";
            //Principal.ImageIndex = 2;
            //Principal.SelectedImageIndex = 2;
            //treeNodes.Add(Principal);

            if (idUsuario == 1)
            {
                TreeNode Config = new TreeNode();
                Config.Text = "Configurações";
                Config.Tag = "Configurações";
                Config.ImageIndex = 3;
                Config.SelectedImageIndex = 3;
                treeNodes.Add(Config);
            }

            TreeNode Manuais = new TreeNode();
            Manuais.Text = "Manuais";
            Manuais.Tag = "Manuais";
            Manuais.ImageIndex = 4;
            Manuais.SelectedImageIndex = 4;
            treeNodes.Add(Manuais);

            TreeNode favoritos = new TreeNode();
            favoritos.Text = "Favoritos";
            favoritos.Tag = "Favoritos";
            favoritos.ImageIndex = 3;
            favoritos.SelectedImageIndex = 3;
            treeNodes.Add(favoritos);

            //adiciona os forms
            foreach (Favoritos f in Favoritos.Where(x => x.Grupo == "Forms").OrderBy(x => x.Nome).ToList())
            {
                TreeNode t = new TreeNode();
                t.Text = f.Nome;
                t.Tag = f.Form;
                t.ImageIndex = 0;
                t.SelectedImageIndex = 0;
                t.ContextMenuStrip = contextMenuStrip1;
                Forms.Add(t);
            }
            treeNodes.Add(new TreeNode("Formulários", 0, 0, Forms.ToArray()));

            foreach (Favoritos f in Favoritos.Where(x => x.Grupo == "Reports").OrderBy(x => x.Nome).ToList())
            {
                TreeNode t = new TreeNode();
                t.Text = f.Nome;
                t.Tag = f.Form;
                t.ImageIndex = 1;
                t.SelectedImageIndex = 1;
                t.ContextMenuStrip = contextMenuStrip1;
                Reports.Add(t);
            }
            treeNodes.Add(new TreeNode("Relatórios", 1, 1, Reports.ToArray()));

            treeView1.Nodes.AddRange(treeNodes.ToArray());
            treeView1.ExpandAll();
        }


        //Monta os botoes da barra de janelas
        protected void ListaJanelas()
        {
            //Limpa a listagem
            statusStrip1.Items.Clear();

            //Adiciona um botão para cada janela aberta.
            foreach (Form f in this.MdiChildren)
            {
                for (int i = 0; i < statusStrip1.Items.Count; i++)
                {
                    if (statusStrip1.Items[i] is ToolStripDropDownButton)
                        (statusStrip1.Items[i] as ToolStripDropDownButton).Font = new Font("Segoe UI", 9, FontStyle.Regular);
                }


                ToolStripDropDownButton btn = new ToolStripDropDownButton();
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                ToolStripSeparator s = new ToolStripSeparator();
                btn.Text = f.Text;
                btn.Click += new EventHandler(toolStripSplitButton1_ButtonClick);
                btn.ShowDropDownArrow = false;
                statusStrip1.Items.Add(btn);

                //botao fechar
                var bmp = new Bitmap(ERP.Properties.Resources.FecharBotao);
                ToolStripDropDownButton btnClose = new ToolStripDropDownButton();
                btnClose.Text = "Fechar " + f.Text;
                btnClose.Click += new EventHandler(toolStripSplitButton1_ButtonClick);
                btnClose.ShowDropDownArrow = false;
                btnClose.DisplayStyle = ToolStripItemDisplayStyle.Image;
                btnClose.ToolTipText = "Fechar " + f.Text;
                btnClose.Image = bmp;
                statusStrip1.Items.Add(btnClose);

                statusStrip1.Items.Add(s);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveMdiChild.Close();
                ListaJanelas();

                if (this.MdiChildren.Count() == 0)
                {
                    pnlMenus.Visible = true;
                }
            }
            catch { }
        }

        private void cboForms_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            foreach (Form f in this.MdiChildren)
            {
                if (f.Text == e.ClickedItem.Text)
                {
                    f.Activate();
                    return;
                }
            }
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            toolStripDropDownButton1.ShowDropDownArrow = false;
            var empresa = new EmpresaDAL().ERepository.GetByID(Convert.ToInt32(Util.Util.GetAppSettings("IdEmpresa")));
            lbEmpresa.Text = "Empresa logada: " + empresa.Fantasia;


            //rotinas de manutenção

            //ajusta o estoque idDeposito
            //SQLDataLayer odal = new SQLDataLayer();
            //odal.corrigeDepositoEstoque();
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {


            for (int i = 0; i < statusStrip1.Items.Count; i++ )
            {
                if (statusStrip1.Items[i] is ToolStripDropDownButton)
                    (statusStrip1.Items[i] as ToolStripDropDownButton).Font = new Font("Segoe UI", 9, FontStyle.Regular);
            }

            (sender as ToolStripDropDownButton).Font = new Font("Segoe UI", 9, FontStyle.Bold);

            foreach (Form f in this.MdiChildren)
            {
                //se for botão de seleção
                if (f.Text == sender.ToString())
                {
                    f.Activate();
                    return;
                }


                //se contem a palavra fechar
                if ("Fechar " + f.Text == sender.ToString())
                {
                    f.Close();
                    ListaJanelas();
                }

                if (this.MdiChildren.Count() == 0)
                {
                    pnlMenus.Visible = true;
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void btnMoedaCotacao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmMoedaCotacao>();
        }

        #region Compras
        private void btPedidoCompra_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPedidoCompras1>();
        }

        private void btRecebimento_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmRecebimentoCompra>();
        }
        #endregion

        #region Cadastros

        private void btnCliente_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCliente>();
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmEmpresa>();
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmFornecedor>();
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmFuncionario>();
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmProduto>();
        }

        private void btnTranportadora_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmTransportadora>();
        }

        #region Acessos
        private void btnModulo_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmModulo>();
        }
        private void btnPerfil_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPerfil>();
        }

        private void btnPrograma_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPrograma>();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmUsuario>();
        }

        #endregion

        #endregion

        #region TabelaGeral
        private void rbbTabGeralCidade_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCidade>();
        }

        private void rbbTabGeralCodigoContratoComercial_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("CodigoContratoComercial", "frmCodigoContratoComercial", "Cadastro de Código Contrato Comercial");
        }

        private void rbbTabGeralCodigoServico_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCodigoServico>();
        }

        private void rbbTabGeralDepartamento_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("Departamento", "frmDepartamento", "Cadastro de Departamentos");
        }

        private void rbbTabGeralFeriado_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmFeriado>();
        }

        private void rbbTabGeralGrupoVendas_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("GrupoVendas", "frmGrupoVendas", "Cadastro de Grupo de Vendas");
        }

        private void rbbTabGeralLinhaNegocio_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("LinhaNegocio", "frmlinhanegocio", "Cadastro de Linhas de Negócio");
        }

        private void rbbTabGeralPais_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPais>();
        }

        private void rbbTabGeralPlanoPrevisao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPlanoPrevisao>();
        }

        private void rbbTabGeralRamoAtividade_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmRamoAtividade>();
        }

        private void rbbTabGeralRepresentanteVendas_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmRepresentanteVendas>();
        }

        private void rbbTabGeralTipoEndereco_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmTipoEndereco>();
        }

        private void rbbTabGeralTipoTelefone_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmTipoTelefone>();
        }

        private void rbbTabGeralUnidadeFederacao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmUnidadeFederacao>();
        }

        private void rbbTabGeralVendedor_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmVendedor>();
        }
        #endregion

        #region TabelaAtivo
        private void rbbTabAtivoAtivoImobilizado_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmAtivoImobilizado>();
        }

        private void rbbTabAtivoDepreciacaoEspecial_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmDepreciacaoEspecial>();
        }

        private void rbbTabAtivoGrupoAtivo_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmGrupoAtivo>();
        }

        private void rbbTabAtivoLancamentoAtivo_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmLancamentoAtivo>();
        }

        private void rbbTabAtivoLocalizacaoAtivo_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmLocalizacaoAtivo>();
        }

        private void rbbTabAtivoMetodoDepreciacao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmMetodoDepreciacao>();
        }

        private void rbbTabAtivoPerfilDepreciacao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPerfilDepreciacao>();
        }

        private void rbbTabAtivoTempoDepreciacao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmTempoDepreciacao>();
        }

        private void rbbTabMovimentacaoAtivo_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmMovimentacaoAtivo>();
        }

        #endregion

        #region TabelaCliente
        private void rbbTabClienteGrupoCliente_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmGrupoCliente>();
        }

        private void rbbTabClientePerfilCliente_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPerfilCliente>();
        }
        #endregion

        #region TabelaEstoque
        private void rbbTabEstoqueArmazem_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("Armazem", "frmArmazem", "Cadastro de Armazéns");
        }

        private void rbbTabEstoqueChaveMinMax_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmChaveMinemax>();
        }

        private void rbbTabEstoqueChaveReducao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmChaveReducao>();
        }

        private void rbbTabEstoqueCorredor_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCorredor>();
        }

        private void rbbTabEstoqueDeposito_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("Deposito", "frmDeposito", "Cadastro de Depósitos");
        }

        private void rbbTabEstoqueEmbalagem_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("Embalagem", "frmEmbalagem", "Cadastro de Embalagens");
        }

        private void rbbTabEstoqueGrupoSeries_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("GrupoSeries", "frmGrupoSeries", "Cadastro de Grupos de Séries");
        }

        private void rbbTabEstoqueGrupoLotes_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("GrupoLotes", "frmGrupoLotes", "Cadastro de Grupos de Lotes");
        }

        private void rbbTabEstoqueLocalizacao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmLocalizacao>();
        }

        private void rbbTabEstoquePerfilProducao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPerfilProducao>();
        }

        private void rbbTabEstoqueSegmento_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmSegmento>();
        }

        private void rbbTabEstoqueSubSegmento_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmSubSegmento>();
        }

        private void rbbTabEstoqueVariantesCor_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("VariantesCor", "frmVariantesCor", "Cadastro de Variantes Cor");
        }

        private void rbbTabEstoqueVariantesEstilo_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("VariantesEstilo", "frmVariantesEstilo", "Cadastro de Variantes Estilo");
        }

        private void rbbTabEstoqueVariantesTamanho_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("VariantesTamanho", "frmVariantesTamanho", "Cadastro de Variantes Tamanho");
        }
        #endregion

        #region TabelaFornecedor

        private void rbbTabFornecedorGrupoCompras_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("GrupoCompras", "frmGrupoCompras", "Cadastro de Grupo de Compras");
        }

        private void rbbTabFornecedorGrupoFornecedor_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmGrupoFornecedor>();
        }

        private void rbbTabFornecedorPerfilFornecedor_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPerfilFornecedor>();
        }
        #endregion

        #region TabelaFinanceiro
        private void rbbTabFinanceiroAvaliacaoCredito_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("AvaliacaoCredito", "frmAvaliacaoCredito", "Cadastro de Avaliação de Crédito");
        }

        private void rbbTabFinanceiroBanco_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmBancos>();
        }

        private void rbbTabFinanceiroCalculoComissao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCalculoComissao>();
        }

        private void rbbTabFinanceiroCodigoEncargos_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCodigoEncargos>();
        }

        private void rbbTabFinanceiroCodigoJuros_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCodigoJuros>();
        }

        private void rbbTabFinanceiroCodigoMultas_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCodigoMultas>();
        }

        private void rbbTabFinanceiroCondPgto_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCondPgto>();
        }

        private void rbbTabFinanceiroContaGerencial_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("ContaGerencial", "frmContaGerencial", "Cadastro de Contas Gerenciais");
        }

        private void rbbTabFinanceiroDescontoAVista_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmDescontoaVista>();
        }

        private void rbbTabFinanceiroDiasPagamento_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmDiasPagamento>();
        }

        private void rbbTabFinanceiroEspecificacaoPagamento_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmEspecificacaoPagamento>();
        }

        private void rbbTabFinanceiroFormaPagamento_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("FormaPagamento", "frmformapagamento", "Cadastro de Forma de Pagamento");
        }

        private void rbbTabFinanceiroGrupoComissao_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("GrupoComissao", "frmgrupocomissao", "Cadastro de Grupo de Comissão");
        }

        private void rbbTabFinanceiroGrupoCusto_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("GrupoCusto", "frmGrupoCusto", "Cadastro de Grupo de Custo");
        }

        private void rbbTabFinanceiroGrupoDesconto_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("GrupoDesconto", "frmGrupoDesconto", "Cadastro de Grupo de Desconto");
        }

        private void rbbTabFinanceiroGrupoDescontoVarejista_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmGrupoDescontoVarejista>();
        }

        private void rbbTabFinanceiroGrupoEncargos_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmGrupoEncargos>();
           // chamarTabelaPadrao("GrupoEncargos", "frmgrupoencargos", "Cadastro de Grupo de Encargos");
        }

        private void rbbTabFinanceiroGrupoPrecoDesconto_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmGrupoPrecoDesconto>();
        }

        private void rbbTabFinanceiroMetodoPagamento_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmMetodoPagamento>();
        }

        private void rbbTabFinanceiroMotivoFinanceiro_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmMotivoFinanceiro>();
        }

        private void rbbTabFinanceiroPlanoPagamento_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPlanoPagamento>();
        }

        private void rbbTabFinanceiroRoyalties_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmRoyalties>();
        }

        private void rbbTabFinanceiroTipoOperacaoBancaria_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmTipoOperacaoBancaria>();
        }

        private void rbbTabFinanceiroTipoPagamento_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("TipoPagamento", "frmtipopagamento", "Cadastro de Tipo de Pagamento");
        }

        private void rbbTabFinanceiroTipoTransacaoBancaria_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("TipoTransacaoBancaria", "frmtipotransacaobancaria", "Cadastro de Tipos de Transação Bancária");
        }

        #endregion

        #region TabelaFiscal
        private void rbbTabFiscalAutoridade_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmAutoridade>();
        }

        private void rbbTabFiscalCFOP_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCFOP>();
        }

        private void rbbTabFiscalCFPS_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCFPS>();
        }

        private void rbbTabFiscalClassificacao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmClassificacao>();
        }

        private void rbbTabFiscalCodigoImposto_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCodigoImposto>();
        }

        private void rbbTabFiscalCodigoImpostoRetido_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCodigoImpostoRetido>();
        }

        private void rbbTabFiscalCodigoIsencao_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("CodigoIsencao", "frmCodigoIsencao", "Cadastro de Código de Isenção");
        }

        private void rbbTabFiscalCodigoServico_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("CodigoServico", "frmCodigoServico", "Cadastro de Código de Serviço");
        }

        private void rbbTabFiscalCodigoTributacao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCodigoTributacao>();
        }

        private void rbbTabFiscalCondicaoFrete_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCondicaoFrete>();
        }

        private void rbbTabFiscalConfGrupoImposto_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmConfGrupoImposto>();
        }

        private void rbbTabFiscalConfGrupoImpostoItem_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmConfGrupoImpostoItem>();
        }

        private void rbbTabFiscalGrupoCFOP_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("GrupoCFOP", "frmGrupoCFOP", "Cadastro de Grupo CFOP");
        }

        private void rbbTabFiscalGrupoImpostos_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmGrupoImpostos>();
        }

        private void rbbTabFiscalGrupoImpostoRetido_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmGrupoImpostoRetido>();
        }

        private void rbbTabFiscalGrupoImpostoItem_Click(object sender, EventArgs e)
        {

            chamarFormulario<frmGrupoImpostoItem>();
            //chamarTabelaPadrao("GrupoImpostoItem", "frmGrupoImpostoItem", "Cadastro de Grupo de Impostos Item");
        }

        private void rbbTabFiscalImpostoRetido_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("ImpostoRetido", "frmImpostoRetido", "Cadastro de Imposto Retido");
        }

        private void rbbTabFiscalJuridicaoImposto_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmJuridicaoImposto>();
        }

        private void rbbTabFiscalLimiteImposto_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmLimiteImposto>();
        }

        private void rbbTabFiscalMatrizCFOP_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmMatrizCFOP>();
        }

        private void rbbTabFiscalMatrizImposto_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmMatrizImposto>();
        }

        private void rbbTabFiscalModeloDocumento_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmModeloDocumento>();
        }

        private void rbbTabFiscalNumeroIsencao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmNumeroIsencao>();
        }

        private void rbbTabFiscalOperacao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmOperacao>();
        }

        private void rbbTabFiscalPeriodoLiquidacaoImposto_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPeriodoLiquidacaoImposto>();
        }

        private void rbbTabFiscalPeriodoLiquidacaoImpostoVenc_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPeriodoLiquidacaoImpostoVenc>();
        }

        private void rbbTabFiscalTextoPadrao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmTextoPadrao>();
        }

        private void rbbTabFiscalTipoDocumento_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmTipoDocumento>();
        }

        private void rbbTabFiscalUnidadeFederacoNCM_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmUnidadeFederacaoNCM>();
        }

        private void rbbTabFiscalValoresImposto_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmValoresImposto>();
        }

        private void rbbTabFiscalValoresImpostoRetido_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmValoresImpostoRetido>();
        }

        #endregion

        #region TabelaContabilidade
        private void rbbTabContabilidadeCentroCusto_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCentroCusto>();
        }

        private void rbbTabContabilidadeContaContabil_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmContaContabil>();
        }

        private void rbbTabContabilidadeContador_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmContador>();
        }

        private void rbbTabContabilidadeContaPlanoReferencial_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmContaPlanoReferencial>();
            //chamarTabelaPadrao("ContaPlanoReferencial", "frmContaPlanoReferencial", "Cadastro Conta Plano Referencial");
        }

        private void rbbTabContabilidadeGrupoLancamento_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("GrupoLancamento", "frmGrupoLancamento", "Cadastro de Grupos de Lançamento");
        }

        private void rbbTabContabilidadeGrupoLancamentoContabil_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmGrupoLancamentoContabil>();
        }

        private void rbbTabContabilidadeLancamento_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmLancamento>();
        }

        private void rbbTabContabilidadeMoeda_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("Moeda", "frmMoedaCad", "Cadastro de Moedas");
        }

        private void rbbTabContabilidadeValoresCentroCusto_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmValoresCentroCusto>();
        }
        #endregion

        #region TabelaProducao
        private void rbbTabProducaoPlanoMestre_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPlanoMestre>();
        }

        private void rbbTabProducaoGrupoCobertura_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmGrupoCobertura>();
        }

        private void rbbTabProducaoGrupoProducao_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("GrupoProducao", "frmGrupoProducao", "Cadastro de grupo de produção");
        }

        private void rbbTabProducaoPerfilProducao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPerfilProducao>();
        }

        private void rbbTabProducaoTempoTrabalho_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmTempoTrabalho>();
        }
        #endregion

        #region TabelaProduto
        private void rbbTabProdutoCodigoProdutoExterno_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCodigoProdutoExterno>();
        }

        private void rbbTabProdutoGrupoItensSuplementares_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("GrupoItensSuplementares", "frmGrupoItensSuplementares", "Cadastro de Grupos de Itens Suplementares");
        }

        private void rbbTabProdutoGrupoArmazenamento_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmGrupoArmazenamento>();
        }

        private void rbbTabProdutoGrupoProduto_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("GrupoProduto", "frmGrupoProduto", "Cadastro de Grupos Produto");
        }

        private void rbbTabProdutoGrupoEstoque_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmGrupoEstoque>();
        }

        private void rbbTabProdutoGrupoRastreamento_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmGrupoRastreamento>();
        }

        private void rbbTabProdutoTipoItem_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("TipoItem", "frmTipoItem", "Cadastro de Tipo Item");
        }

        private void rbbTabProdutoTipoProduto_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmTipoProduto>();
        }

        private void rbbTabProdutoUnidade_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmUnidade>();
        }

        private void rbbTabProdutoVariantesConfig_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("VariantesConfig", "frmVariantesConfig", "Cadastro de Variantes Config");
        }

        private void rbbTabProdutoVariantesGrupo_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmVariantesGrupo>();
            //chamarTabelaPadrao("VariantesGrupo", "frmVariantesGrupo", "Cadastro de Variantes Grupo");
        }
        #endregion

        #region TabelaTransportadora
        private void rbbTabTransportadoraEspecie_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("Especie", "frmespecie", "Cadastro de Espécies");
        }

        private void rbbTabTransportadoraGrupoAlocacaoFrete_Click(object sender, EventArgs e)
        {
            chamarTabelaPadrao("GrupoAlocacaoFrete", "frmGrupoAlocacaoFrete", "Cadastro de Grupo Alocação Frete");
        }

        private void rbbTabTransportadoraModoEntrega_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmModoEntrega>();
        }

        #endregion

        #region Vendas
        private void btPedidoVendas_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPedidoVendas>();
        }
        
        private void btnAprovacaoVendas_Click(object sender, EventArgs e)
        {
            using (frmAprovacao frmAprov = new frmAprovacao(2))
            {
                frmAprov.ShowDialog();
            }
        }

        private void btnSeparacaoVendas_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPedidoVendaSeparacao>();
        }
        #endregion

        private void AbreFormByString(string frm)
        {
            switch (frm)
            {
                case "Manuais":
                    {
                        try
                        {
                            Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Manuais");
                        }
                        catch
                        {
                            Util.Aplicacao.ShowMessage("A pasta: " + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Manuais não foi localizada");
                            return;
                        }

                    }; break;
                case "Favoritos": { frmFavoritos f = new frmFavoritos(idUsuario); f.ShowDialog(); MontaFavoritos(); } break;
                case "Configurações": { frmDeveloperTools d = new frmDeveloperTools(); d.Show(); }; break; 
                case "frmArmazem": chamarTabelaPadrao("Armazem", "frmArmazem", "Cadastro de Armazéns"); break;
                case "frmAtivoImobilizado": chamarFormulario<frmAtivoImobilizado>(); break;
                case "frmAutoridade": chamarFormulario<frmAutoridade>(); break;
                case "frmAvaliacaoCredito": chamarTabelaPadrao("AvaliacaoCredito", "frmAvaliacaoCredito", "Cadastro de Avaliação de Crédito"); break;
                case "frmBancos": chamarFormulario<frmBancos>(); break; 
                case "frmBoletoBancario": chamarFormulario<frmBoletoBancario>(); break;
                case "frmCadastrodiarioProducao": chamarFormulario<frmCadastrodiarioProducao>(); break;
                case "frmCalculoComissao": chamarFormulario<frmCalculoComissao>(); break;
                case "frmCalendario": chamarFormulario<frmCalendario>(); break;
                case "frmCapacidadeRecursos": chamarFormulario<frmCapacidadeRecursos>(); break;
                case "frmCentroCusto": chamarFormulario<frmCentroCusto>(); break; 
                case "frmCEST": chamarFormulario<frmCEST>(); break;
                case "frmCFOP": chamarFormulario<frmCFOP>(); break;
                case "frmCFPS": chamarFormulario<frmCFPS>(); break;
                case "frmChaveMinemax": chamarFormulario<frmChaveMinemax>(); break;
                case "frmChaveReducao": chamarFormulario<frmChaveReducao>(); break;
                case "frmChequeEmpresa": chamarFormulario<frmChequeEmpresa>();break;
                case "frmCidade": chamarFormulario<frmCidade>(); break;
                case "frmClassificacao": chamarFormulario<frmClassificacao>(); break;
                case "frmCliente": chamarFormulario<frmCliente>(); break;
                case "frmCodigoContratoComercial": chamarTabelaPadrao("CodigoContratoComercial", "frmCodigoContratoComercial", "Cadastro de Código Contrato Comercial"); break;
                case "frmCodigoEncargos": chamarFormulario<frmCodigoEncargos>(); break;
                case "frmCodigoImposto": chamarFormulario<frmCodigoImposto>(); break;
                case "frmCodigoImpostoRetido": chamarFormulario<frmCodigoImpostoRetido>(); break;
                case "frmCodigoIsencao": chamarTabelaPadrao("CodigoIsencao", "frmCodigoIsencao", "Cadastro de Código de Isenção"); break;
                case "frmCodigoJuros": chamarFormulario<frmCodigoJuros>(); break;
                case "frmCodigoMultas": chamarFormulario<frmCodigoMultas>(); break;
                case "frmCodigoProdutoExterno": chamarFormulario<frmCodigoProdutoExterno>(); break;
                case "frmCodigoServico": chamarFormulario<frmCodigoServico>(); break;// chamarTabelaPadrao("CodigoServico", "frmCodigoServico", "Cadastro de Código de Serviço"); break;
                case "frmCodigoTributacao": chamarFormulario<frmCodigoTributacao>(); break;
                case "frmCondicaoFrete": chamarFormulario<frmCondicaoFrete>(); break;
                case "frmCondPgto": chamarFormulario<frmCondPgto>(); break;
                case "frmConfGrupoImposto": chamarFormulario<frmConfGrupoImposto>(); break;
                case "frmConfGrupoImpostoItem": chamarFormulario<frmConfGrupoImpostoItem>(); break;
                case "frmContaContabil": chamarFormulario<frmContaContabil>(); break;
                case "frmContador": chamarFormulario<frmContador>(); break;
                case "frmContaGerencial": chamarTabelaPadrao("ContaGerencial", "frmContaGerencial", "Cadastro de Contas Gerenciais"); break;
                case "frmContaPlanoReferencial": chamarFormulario<frmContaPlanoReferencial>(); break;
                case "frmContasPagar": chamarFormulario<frmContasPagar>(); break;
                case "frmContratoComercial": chamarFormulario<frmContratoComercial>(); break;
                case "frmCorredor": chamarFormulario<frmCorredor>(); break;
                case "frmDepartamento": chamarTabelaPadrao("Departamento", "frmDepartamento", "Cadastro de Departamentos"); break;
                case "frmDeposito": chamarTabelaPadrao("Deposito", "frmDeposito", "Cadastro de Depósitos"); break;
                case "frmDepreciacaoEspecial": chamarFormulario<frmDepreciacaoEspecial>(); break;
                case "frmDescontoaVista": chamarFormulario<frmDescontoaVista>(); break;
                case "frmDiarioBom": chamarFormulario<frmDiarioBom>(); break;
                case "frmDiasPagamento": chamarFormulario<frmDiasPagamento>(); break;
                case "frmEmbalagem": chamarTabelaPadrao("Embalagem", "frmEmbalagem", "Cadastro de Embalagens"); break;
                case "frmEmpresa": chamarFormulario<frmEmpresa>(); break;
                case "frmespecie": chamarTabelaPadrao("Especie", "frmespecie", "Cadastro de Espécies"); break;
                case "frmEspecificacaoPagamento": chamarFormulario<frmEspecificacaoPagamento>(); break;
                case "frmFeriado": chamarFormulario<frmFeriado>(); break; 
                case "frmFluxoCaixa": chamarFormulario<frmFluxoCaixa>(); break;
                case "frmformapagamento": chamarTabelaPadrao("FormaPagamento", "frmformapagamento", "Cadastro de Forma de Pagamento"); break;
                case "frmFornecedor": chamarFormulario<frmFornecedor>(); break;
                case "frmFuncionario": chamarFormulario<frmFuncionario>(); break;
                case "frmGrupoAlocacaoFrete": chamarTabelaPadrao("GrupoAlocacaoFrete", "frmGrupoAlocacaoFrete", "Cadastro de Grupo Alocação Frete"); break;
                case "frmGrupoArmazenamento": chamarFormulario<frmGrupoArmazenamento>(); break;
                case "frmGrupoAtivo": chamarFormulario<frmGrupoAtivo>(); break;
                case "frmGrupoCFOP": chamarTabelaPadrao("GrupoCFOP", "frmGrupoCFOP", "Cadastro de Grupo CFOP"); break;
                case "frmGrupoCliente": chamarFormulario<frmGrupoCliente>(); break;
                case "frmGrupoCobertura": chamarFormulario<frmGrupoCobertura>(); break;
                case "frmgrupocomissao": chamarTabelaPadrao("GrupoComissao", "frmgrupocomissao", "Cadastro de Grupo de Comissão"); break;
                case "frmGrupoCompras": chamarTabelaPadrao("GrupoCompras", "frmGrupoCompras", "Cadastro de Grupo de Compras"); break;
                case "frmGrupoCusto": chamarTabelaPadrao("GrupoCusto", "frmGrupoCusto", "Cadastro de Grupo de Custo"); break;
                case "frmGrupoDesconto": chamarTabelaPadrao("GrupoDesconto", "frmGrupoDesconto", "Cadastro de Grupo de Desconto"); break;
                case "frmGrupoDescontoVarejista": chamarFormulario<frmGrupoDescontoVarejista>(); break;
                case "frmGrupoEncargos": chamarFormulario<frmGrupoEncargos>(); break;
                case "frmGrupoEstoque": chamarFormulario<frmGrupoEstoque>(); break;
                case "frmGrupoFornecedor": chamarFormulario<frmGrupoFornecedor>(); break;
                case "frmGrupoImpostoItem": chamarFormulario<frmGrupoImpostoItem>(); break;//chamarTabelaPadrao("GrupoImpostoItem", "frmGrupoImpostoItem", "Cadastro de Grupo de Impostos Item"); break;
                case "frmGrupoImpostoRetido": chamarFormulario<frmGrupoImpostoRetido>(); break;
                case "frmGrupoImpostoRetidoItem": chamarFormulario<frmGrupoImpostoRetidoItem>(); break;
                case "frmGrupoImpostos": chamarFormulario<frmGrupoImpostos>(); break;
                case "frmGrupoItensSuplementares": chamarTabelaPadrao("GrupoItensSuplementares", "frmGrupoItensSuplementares", "Cadastro de Grupos de Itens Suplementares"); break;
                case "frmGrupoLancamento": chamarTabelaPadrao("GrupoLancamento", "frmGrupoLancamento", "Cadastro de Grupos de Lançamento"); break;
                case "frmGrupoLancamentoContabil": chamarFormulario<frmGrupoLancamentoContabil>(); break;
                case "frmGrupoLotes": chamarTabelaPadrao("GrupoLotes", "frmGrupoLotes", "Cadastro de Grupos de Lotes"); break;
                case "frmGrupoPrecoDesconto": chamarFormulario<frmGrupoPrecoDesconto>(); break;
                case "frmGrupoProducao": chamarTabelaPadrao("GrupoProducao", "frmGrupoProducao", "Cadastro de grupo de produção"); break;
                case "frmGrupoProduto": chamarTabelaPadrao("GrupoProduto", "frmGrupoProduto", "Cadastro de Grupos Produto"); break;
                case "frmGrupoRastreamento": chamarFormulario<frmGrupoRastreamento>(); break;
                case "frmGrupoRecursos": chamarFormulario<frmGrupoRecursos>(); break;
                case "frmGrupoRoteiro": chamarFormulario<frmGrupoRoteiro>(); break;
                case "frmGrupoSeries": chamarTabelaPadrao("GrupoSeries", "frmGrupoSeries", "Cadastro de Grupos de Séries"); break;
                case "frmGrupoVendas": chamarTabelaPadrao("GrupoVendas", "frmGrupoVendas", "Cadastro de Grupo de Vendas"); break;
                case "frmJuridicaoImposto": chamarFormulario<frmJuridicaoImposto>(); break;
                case "frmInventarioEstoque": chamarFormulario<ERP.Estoques.frmInventarioPesquisa>(); break;
                case "frmLancamento": chamarFormulario<frmLancamento>(); break;
                case "frmLancamentoAtivo": chamarFormulario<frmLancamentoAtivo>(); break;
                case "frmLimiteImposto": chamarFormulario<frmLimiteImposto>(); break;
                case "frmLinhaNegocio": chamarTabelaPadrao("LinhaNegocio", "frmlinhanegocio", "Cadastro de Linhas de Negócio"); break;
                case "frmListaMateriais1": chamarFormulario<frmListaMateriais1>(); break;
                case "frmLocalizacao": chamarFormulario<frmLocalizacao>(); break;
                case "frmLocalizacaoAtivo": chamarFormulario<frmLocalizacaoAtivo>(); break;
                case "frmLocalProducao": chamarFormulario<frmLocalProducao>(); break;
                case "frmMatrizCFOP": chamarFormulario<frmMatrizCFOP>(); break;
                case "frmMatrizImposto": chamarFormulario<frmMatrizImposto>(); break;
                case "frmMetodoDepreciacao": chamarFormulario<frmMetodoDepreciacao>(); break;
                case "frmMetodoPagamento": chamarFormulario<frmMetodoPagamento>(); break;
                case "frmModeloDocumento": chamarFormulario<frmModeloDocumento>(); break;
                case "frmModoEntrega": chamarFormulario<frmModoEntrega>(); break;
                case "frmMoeda": chamarTabelaPadrao("Moeda", "frmMoedaCad", "Cadastro de Moedas"); break;
                case "frmMotivoFinanceiro": chamarFormulario<frmMotivoFinanceiro>(); break;
                case "frmMovimentacaoAtivo": chamarFormulario<frmMovimentacaoAtivo>(); break;
                case "frmMovimentacaoBancaria": chamarFormulario<frmMovimentacaoBancaria>(); break;
                case "frmNumeroIsencao": chamarFormulario<frmNumeroIsencao>(); break;
                case "frmOperacao": chamarFormulario<frmOperacao>(); break;
                //case "frmOrdemProducao": chamarFormulario<frmOrdemProducao>(); break;
                case "frmPagamentoLote": chamarFormulario<frmPagamentoLote>(); break;
                case "frmPedidoCompras": chamarFormulario<frmPedidoCompras1>(); break;
                case "frmPedidoVendas": chamarFormulario<frmPedidoVendas>(); break;
                case "frmPerfilCliente": chamarFormulario<frmPerfilCliente>(); break;
                case "frmPerfilDepreciacao": chamarFormulario<frmPerfilDepreciacao>(); break;
                case "frmPerfilFornecedor": chamarFormulario<frmPerfilFornecedor>(); break;
                case "frmPerfilProducao": chamarFormulario<frmPerfilProducao>(); break;
                case "frmPeriodoLiquidacaoImposto": chamarFormulario<frmPeriodoLiquidacaoImposto>(); break;
                case "frmPeriodoLiquidacaoImpostoVenc": chamarFormulario<frmPeriodoLiquidacaoImpostoVenc>(); break;
                case "frmPlanoMestre": chamarFormulario<frmPlanoMestre>(); break;
                case "frmPlanoPagamento": chamarFormulario<frmPlanoPagamento>(); break;
                case "frmPlanoPrevisao": chamarFormulario<frmPlanoPrevisao>(); break;
                case "frmProduto": chamarFormulario<frmProduto>(); break;
                case "frmRamoAtividade": chamarFormulario<frmRamoAtividade>(); break;
                case "frmRecebimentoLote": chamarFormulario<frmRecebimentoLote>(); break;
                case "frmRecurso": chamarFormulario<frmRecurso>(); break;
                case "frmRepresentanteVendas": chamarFormulario<frmRepresentanteVendas>(); break;
                case "frmRoteiro": chamarFormulario<frmRoteiro>(); break;
                case "frmRoyalties": chamarFormulario<frmRoyalties>(); break;
                case "frmSegmento": chamarFormulario<frmSegmento>(); break;
                case "frmSegmentoBancario": chamarFormulario<frmSegmentoBancario>(); break;
                case "frmSubSegmento": chamarFormulario<frmSubSegmento>(); break;
                case "frmTempoDepreciacao": chamarFormulario<frmTempoDepreciacao>(); break;
                case "frmTempoTrabalho": chamarFormulario<frmTempoTrabalho>(); break;
                case "frmTextoPadrao": chamarFormulario<frmTextoPadrao>(); break;
                case "frmTextoTransacao": chamarFormulario<frmTextoTransacao>(); break;
                case "frmTipoDocumento": chamarFormulario<frmTipoDocumento>(); break;
                case "frmTipoEndereco": chamarFormulario<frmTipoEndereco>(); break;
                case "frmTipoItem": chamarTabelaPadrao("TipoItem", "frmTipoItem", "Cadastro de Tipo Item"); break;
                case "frmTipoOperacaoBancaria": chamarFormulario<frmTipoOperacaoBancaria>(); break;
                case "frmtipopagamento": chamarTabelaPadrao("TipoPagamento", "frmtipopagamento", "Cadastro de Tipo de Pagamento"); break;
                case "frmTipoProduto": chamarFormulario<frmTipoProduto>(); break;
                case "frmTipoTelefone": chamarFormulario<frmTipoTelefone>(); break;
                case "frmtipotransacaobancaria": chamarTabelaPadrao("TipoTransacaoBancaria", "frmtipotransacaobancaria", "Cadastro de Tipos de Transação Bancária"); break;
                case "frmTransportadora": chamarFormulario<frmTransportadora>(); break;
                case "frmUnidade": chamarFormulario<frmUnidade>(); break;
                case "frmUnidadeFederacao": chamarFormulario<frmUnidadeFederacao>(); break;
                case "frmUnidadeFederacaoNCM": chamarFormulario<frmUnidadeFederacaoNCM>(); break;
                case "frmUsuario": chamarFormulario<frmUsuario>(); break;
                case "frmValoresImposto": chamarFormulario<frmValoresImposto>(); break;
                case "frmValoresImpostoRetido": chamarFormulario<frmValoresImpostoRetido>(); break;
                case "frmVariantesConfig": chamarTabelaPadrao("VariantesConfig", "frmVariantesConfig", "Cadastro de Variantes Config"); break;
                case "frmVariantesCor": chamarTabelaPadrao("VariantesCor", "frmVariantesCor", "Cadastro de Variantes Cor"); break;
                case "frmVariantesEstilo": chamarTabelaPadrao("VariantesEstilo", "frmVariantesEstilo", "Cadastro de Variantes Estilo"); break;
                case "frmVariantesGrupo": chamarFormulario<frmVariantesGrupo>(); ; break;
                case "frmVariantesTamanho": chamarTabelaPadrao("VariantesTamanho", "frmVariantesTamanho", "Cadastro de Variantes Tamanho"); break;
                case "frmVendedor": chamarFormulario<frmVendedor>(); break;



            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            string Selecionado = treeView1.SelectedNode.Tag.ToString();
            this.AbreFormByString(Selecionado);
        }

        private void removerDosMeusFavoritosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir o menu dos seus favoritos?") == DialogResult.Yes)
            {
                var node = treeView1.SelectedNode;
                string frm = node.Tag.ToString();
                new FavoritosDAL().Delete(frm, idUsuario);
                MontaFavoritos();
            }
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearchForm f = new frmSearchForm(idUsuario);
                f.ShowDialog();
                if (!String.IsNullOrEmpty(f.frmNome))
                {
                    this.AbreFormByString(f.frmNome);
                }

            }
            catch (Exception ex)
            { }
        }

        private void frmMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                try
                {
                    frmSearchForm f = new frmSearchForm(idUsuario);
                    f.ShowDialog();
                    if (!String.IsNullOrEmpty(f.frmNome))
                    {
                        this.AbreFormByString(f.frmNome);
                    }

                }
                catch (Exception ex)
                { }
            }
        }

        private void btnAprovacaoDocs_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmAprovacaoDocumentos>();
        }

        private void rbbTabGrupoImpostoRetidoItem_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmGrupoImpostoRetidoItem>();
        }

        private void rbListaMateriais_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPlanoProducao>();
        }

        private void rbbTabFinanceiroSegmentoBancario_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmSegmentoBancario>();
        }

        private void rbRecursos_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmRecurso>();
        }

        private void rbbTabProducaoCalendario_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCalendario>();
        }

        private void rbbTabProducaoCapacidadeRecurso_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCapacidadeRecursos>();
        }

        private void rbbTabProducaoGrupoRecurso_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmGrupoRecursos>();
        }

        private void rbRoteiro_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmRoteiro>();
        }

        private void rbbTabProducaoLocalProducao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmLocalProducao>();
        }

        private void rbbTabProducaoGrupoRoteiro_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmGrupoRoteiro>();
        }

        private void rbOrdemProducao_Click(object sender, EventArgs e)
        {
            //chamarFormulario<frmOrdemProducao>();
        }

        private void rbCadastroDiarioProducao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCadastrodiarioProducao>();
        }

        private void rbDiarioBOM_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmDiarioBom>();
        }

        private void btnContasPagar_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmContasPagar>();
        }

        private void rbbNotaFiscal_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmNotaFiscal>();
        }

        private void btnContratoComercial_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmContratoComercial>();
        }

        private void rbAprovacao_Click(object sender, EventArgs e)
        {
            using(frmAprovacao frmAprov = new frmAprovacao(1))
            {
                frmAprov.ShowDialog();
            }
        }

        private void rbConsultaEstoque_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmConsultaEstoque>();
            //using(frmConsultaEstoque frmConsEstoque = new frmConsultaEstoque())
            //{
            //    frmConsEstoque.ShowDialog();
            //}
        }

        private void btnChequeTerceiros_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmControlChequeTerceiros>();
            //using(frmControlChequeTerceiros frmcheq = new frmControlChequeTerceiros())
            //{
            //    frmcheq.ShowDialog();
            //}
        }

        private void btnContasReceber_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmContasReceber>();
        }

        private void btnAjusteEstoque_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmAjusteEstoque>();
        }

        private void btnMovimentacaoBancaria_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmMovimentacaoBancaria>();
        }

        private void ribbonButton4_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmConfiguracaoCheque>();
        }

        private void rbbTabContaBancaria_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmContaBancariaPesq>();
        }

        private void btnContaCorrenteVendedor_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmComissaoVendedorContaCorrente>(); 
        }

        private void btnPagamentoLote_Click(object sender, EventArgs e)
        {
            
                chamarFormulario<frmPagamentoLote>();
        }

        private void rbbTextoTransacao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmTextoTransacao>();
        }

        private void rbTabCEST_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmCEST>();
        }

        private void ribbonButton7_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmChequeEmpresa>();
        }

        private void btnRecebimentoLote_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmRecebimentoLote>();
        }

        private void btnBoletoBancario_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmBoletoBancario>();
        }

        private void btnFluxoCaixa_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmFluxoCaixa>();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmInventarioPesquisa>(); 
        }

        private void rbDemandaProducao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmDemandaProducao>();
        }

        private void rbOrdemProducao_Click_1(object sender, EventArgs e)
        {
            chamarFormulario<frmOrdemProducao>();
        }

        private void rbControleProducao_Click(object sender, EventArgs e)
        {
            ERP.Forms.Produção.frmControleProducaoDiaria frmp = new Forms.Produção.frmControleProducaoDiaria();
            frmp.ShowDialog();
        }

        private void rbKardex_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmKardex>();
        }

        private void btnPedidoBalcao_Click(object sender, EventArgs e)
        {
            chamarFormulario<frmPedidoVendaPesq>();
        }

        private void rbImprimir_Click(object sender, EventArgs e)
        {
            frmImprimir frmi = new frmImprimir(new List<Util.Etiqueta>());
            frmi.Show();
        }
    }
}
