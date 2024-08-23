using ERP.DAL;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmListaMateriaisLinhas : RibbonForm
    {
        public ListaMateriaisLinhasDAL dal = new ListaMateriaisLinhasDAL();
        ListaMateriaisLinhas ll = new ListaMateriaisLinhas();
        List<MultiComboItem> Produtos = new List<MultiComboItem>();

        public frmListaMateriaisLinhas()
        {
          
            InitializeComponent();
        }

        public frmListaMateriaisLinhas(ListaMateriaisLinhas pLinha)
        {
            ll = pLinha;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Util.Aplicacao.CorrigeLabels(this);
        }

        private void frmCodigoMultasCad_Load(object sender, EventArgs e)
        {
            CarregaCombos();
            if (ll.IdListaMateriaisLinhas == 0)
            {
                Util.Aplicacao.DesbloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
            else
            {
                CarregaDados();
            }
        }

        private void CarregaDados()
        {
            cboArmazem.SelectedValue = ll.IdArmazem == null ? 0 : ll.IdArmazem;
            cboConfiguracao.SelectedValue = ll.IdConfiguracao == null ? 0 : ll.IdConfiguracao;
            cboConsumo.SelectedValue = ll.Consumo == null ? 0 : ll.Consumo;
            cboContaFornecedor.SelectedValue = ll.IdFornecedor == null ? 0 : ll.IdFornecedor;
            cboCor.SelectedValue = ll.IdCor == null ? 0 : ll.IdCor;
            cboDeposito.SelectedValue = ll.IdDeposito == null ? 0 : ll.IdDeposito;
            cboEstilo.SelectedValue = ll.IdEstilo == null ? 0 : ll.IdEstilo;
            cboFormula.SelectedValue = ll.Formula == null ? 0 : ll.Formula;
            cboLocalizacao.SelectedValue = ll.IdLocalizacao == null ? 0 : ll.IdLocalizacao;
            cboLote.SelectedValue = ll.IdLote == null ? 0 : ll.IdLote;
            cboPrincipioLiberacao.SelectedValue = ll.PrincipioLiberacao == null ? 0 : ll.PrincipioLiberacao;
            cboProduto.SelectedValue = ll.IdProduto == null ? 0 : ll.IdProduto;
            cboSubBom.SelectedValue = ll.SubBOM == null ? 0 : ll.SubBOM;
            cboSubRoteiro.SelectedValue = ll.SubRoteiro == null ? 0 : ll.SubRoteiro;
            cboTamanho.SelectedValue = ll.IdTamanho == null ? 0 : ll.IdTamanho;
            cboTipo.SelectedValue = ll.TipoItem == null ? 0 : ll.TipoItem;
            cboTipoIngrediente.SelectedValue = ll.TipoIngrediente == null ? 0 : ll.TipoIngrediente;
            cboTipoLinha.SelectedValue = ll.TipoLinha == null ? 0 : ll.TipoLinha;
            cboTipoProducao.SelectedValue = ll.TipoProducao == null ? 0 : ll.TipoProducao;
            cboUnidade.SelectedValue = ll.IdUnidade == null ? 0 : ll.IdUnidade;
            chkAlocacaodeCusto.Checked = Convert.ToBoolean(ll.AlocacaoCusto);
            chkCalculo.Checked = Convert.ToBoolean(ll.Calculo);
            chkConsumoderecurso.Checked = Convert.ToBoolean(ll.ConsumoRecurso);
            chkDefinirSubproducao.Checked = Convert.ToBoolean(ll.DefinirSubProducaoComoConsumo);
            chkEscalonavel.Checked = Convert.ToBoolean(ll.Escalonavel);
            chkFim.Checked = Convert.ToBoolean(ll.Fim);
            chkHerdarlotescoproduto.Checked = Convert.ToBoolean(ll.HerdaLoteCoProduto);
            chkHerdarlotesparaprodutofinal.Checked = Convert.ToBoolean(ll.HerdaLoteProdutoFinal);
            chkHerdarvalidadecoproduto.Checked = Convert.ToBoolean(ll.HerdaValidadeCoproduto);
            chkHerdarvalidadeparaprodutofinal.Checked = Convert.ToBoolean(ll.HerdaValidadeProdutoFinal);
            chkPorcentagemcontrolada.Checked = Convert.ToBoolean(ll.PorcentagemContraolada);
            dtpAte.Text = ll.Ate == null ? "" : ll.Ate.ToString();
            dtpDe.Text = ll.De == null ? "" : ll.De.ToString();
            txtAltura.Text = ll.Altura == null ? "" : ll.Altura.ToString();
            txtDensidade.Text = ll.Densidade == null ? "" : ll.Densidade.ToString();
            txtLargura.Text = ll.Largura == null ? "" : ll.Largura.ToString();
            txtNOperacao.Text = ll.NumeroOperacao == null ? "" : ll.NumeroOperacao.ToString();
            txtPercentual.Text = ll.Percentual == null ? "" : ll.Percentual.ToString();
            txtPercentualCusto.Text = ll.PercentualCustos == null ? "" : ll.PercentualCustos.ToString();
            txtPercentualRecuperacao.Text = ll.PorcentagemRecuperacao == null ? "" : ll.PorcentagemRecuperacao.ToString();
            txtPorSerie.Text = ll.Porserie == null ? "" : ll.Porserie.ToString();
            txtPrioridade.Text = ll.Prioridade == null ? "" : ll.Prioridade.ToString();
            txtProfundidade.Text = ll.Profundidade == null ? "" : ll.Profundidade.ToString();
            txtQuantidade.Text = ll.Quantidade == null ? "" : ll.Quantidade.ToString();
            txtSerie.Text = ll.Serie == null ? "" : ll.Serie;
            txtSucata.Text = ll.SucataConstante == null ? "" : ll.SucataConstante.ToString();
            txtValordecustoindiretosubprodutos.Text = ll.ValorCustoIndiretoSubProduto == null ? "" : ll.ValorCustoIndiretoSubProduto.ToString();

            Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
        }

        private void CarregaCombos()
        {
            string sEmpresa = Util.Util.GetAppSettings("IdEmpresa");

            Produtos = new ProdutoDAL().getProdutosMultiCombo();
            cboProduto.DataSource = Produtos;
            cboProduto.DisplayMember = "Text2";
            cboProduto.ValueMember = "iValue";
            cboProduto.SelectedIndex = -1;

            cboConfiguracao.DataSource = new VariantesConfigDAL().GetCombo();
            cboConfiguracao.DisplayMember = "Text";
            cboConfiguracao.ValueMember = "iValue";
            cboConfiguracao.SelectedIndex = -1;

            cboEstilo.DataSource = new VariantesEstiloDAL().GetCombo();
            cboEstilo.DisplayMember = "Text";
            cboEstilo.ValueMember = "iValue";
            cboEstilo.SelectedIndex = -1;

            cboCor.DataSource = new VariantesCorDAL().GetCombo();
            cboCor.DisplayMember = "Text";
            cboCor.ValueMember = "iValue";
            cboCor.SelectedIndex = -1;

            cboTamanho.DataSource = new VariantesTamanhoDAL().GetCombo();
            cboTamanho.DisplayMember = "Text";
            cboTamanho.ValueMember = "iValue";
            cboTamanho.SelectedIndex = -1;

            cboArmazem.DataSource = new ArmazemDAL().GetCombo();
            cboArmazem.DisplayMember = "Text";
            cboArmazem.ValueMember = "iValue";
            cboArmazem.SelectedIndex = -1;

            cboUnidade.DataSource = new UnidadeDAL().GetCombo();
            cboUnidade.DisplayMember = "Text";
            cboUnidade.ValueMember = "iValue";
            cboUnidade.SelectedIndex = -1;

            List<ComboItem> Consumo = new List<ComboItem>();
            Consumo.Add(new ComboItem() { iValue = 1, Text = "Variavel" });
            Consumo.Add(new ComboItem() { iValue = 2, Text = "Constânte" });
            cboConsumo.DataSource = Consumo;
            cboConsumo.DisplayMember = "Text";
            cboConsumo.ValueMember = "iValue";
            cboConsumo.SelectedIndex = -1;

            cboContaFornecedor.DataSource = new FornecedorDAL().GetCombo2(sEmpresa);
            cboContaFornecedor.DisplayMember = "Text";
            cboContaFornecedor.ValueMember = "iValue";
            cboContaFornecedor.SelectedIndex = -1;
        
            cboDeposito.DataSource = new DepositoDAL().GetCombo();
            cboDeposito.DisplayMember = "Text";
            cboDeposito.ValueMember = "iValue";
            cboDeposito.SelectedIndex = -1;

            List<ComboItem> Formulas = new List<ComboItem>();
            Formulas.Add(new ComboItem() { iValue = 1, Text = "Padrão" });
            Formulas.Add(new ComboItem() { iValue = 2, Text = "Altura * Constante" });
            Formulas.Add(new ComboItem() { iValue = 3, Text = "Altura * Largura * Constante" });
            Formulas.Add(new ComboItem() { iValue = 4, Text = "Altuta * Largura * Profundade * Constante" });
            Formulas.Add(new ComboItem() { iValue = 5, Text = "(Altura * Largura * Profundidade/Densidade) * Constante" });
            Formulas.Add(new ComboItem() { iValue = 6, Text = "Etapa" });
            cboFormula.DataSource = Formulas;
            cboFormula.DisplayMember = "Text";
            cboFormula.ValueMember = "iValue";
            cboFormula.SelectedIndex = -1;

            cboLocalizacao.DataSource = new LocalizacaoDAL().GetCombo();
            cboLocalizacao.DisplayMember = "Text";
            cboLocalizacao.ValueMember = "iValue";
            cboLocalizacao.SelectedIndex = -1;

            cboLote.DataSource = new RecebimentoItemLoteDAL().GetCombo();
            cboLote.DisplayMember = "Text";
            cboLote.ValueMember = "iValue";
            cboLote.SelectedIndex = -1;

            List<ComboItem> Principiol = new List<ComboItem>();
            Principiol.Add(new ComboItem() { iValue = 1, Text = "Inciar" });
            Principiol.Add(new ComboItem() { iValue = 2, Text = "Concluir" });
            Principiol.Add(new ComboItem() { iValue = 3, Text = "Manual" });
            cboPrincipioLiberacao.DataSource = Principiol;
            cboPrincipioLiberacao.DisplayMember = "Text";
            cboPrincipioLiberacao.ValueMember = "iValue";
            cboPrincipioLiberacao.SelectedIndex = -1;

            cboSubBom.DataSource = new ListaMateriaisDAL().GetCombo();
            cboSubBom.DisplayMember = "Text";
            cboSubBom.ValueMember = "iValue";
            cboSubBom.SelectedIndex = -1;

            cboSubRoteiro.DataSource = new RoteiroDAL().GetCombo();
            cboSubRoteiro.DisplayMember = "Text";
            cboSubRoteiro.ValueMember = "iValue";
            cboSubRoteiro.SelectedIndex = -1;

            List<ComboItem> TipoItem = new List<ComboItem>();
            TipoItem.Add(new ComboItem() { iValue = 1, Text = "Item" });
            TipoItem.Add(new ComboItem() { iValue = 2, Text = "Serviço" });
            cboTipo.DataSource = TipoItem;
            cboTipo.DisplayMember = "Text";
            cboTipo.ValueMember = "iValue";
            cboTipo.SelectedIndex = -1;
             
            List<ComboItem> TipoIng = new List<ComboItem>();
            TipoIng.Add(new ComboItem() { iValue = 1, Text = "Nenhum" });
            TipoIng.Add(new ComboItem() { iValue = 2, Text = "Ativo" });
            TipoIng.Add(new ComboItem() { iValue = 3, Text = "Compensação" });
            TipoIng.Add(new ComboItem() { iValue = 4, Text = "Preenchedor" });
            cboTipoIngrediente.DataSource = TipoIng;
            cboTipoIngrediente.DisplayMember = "Text";
            cboTipoIngrediente.ValueMember = "iValue";
            cboTipoIngrediente.SelectedIndex = -1; 

            List<ComboItem> TipoLinha = new List<ComboItem>();
            TipoLinha.Add(new ComboItem() { iValue = 1, Text = "Item" });
            TipoLinha.Add(new ComboItem() { iValue = 2, Text = "Fantasma" });
            TipoLinha.Add(new ComboItem() { iValue = 3, Text = "Fornecimento vinculado" });
            TipoLinha.Add(new ComboItem() { iValue = 4, Text = "Fornecedor" });
            cboTipoLinha.DataSource = TipoLinha;
            cboTipoLinha.DisplayMember = "Text";
            cboTipoLinha.ValueMember = "iValue";
            cboTipoLinha.SelectedIndex = -1;

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
             
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            ll = new ListaMateriaisLinhas();
        
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
                    if (!String.IsNullOrEmpty(cboArmazem.Text)) ll.IdArmazem = Convert.ToInt32(cboArmazem.SelectedValue);
                    if (!String.IsNullOrEmpty(cboConfiguracao.Text)) ll.IdConfiguracao = Convert.ToInt32(cboConfiguracao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboConsumo.Text)) ll.Consumo = Convert.ToInt32(cboConsumo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboContaFornecedor.Text)) ll.IdFornecedor = Convert.ToInt32(cboContaFornecedor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboCor.Text)) ll.IdCor = Convert.ToInt32(cboCor.SelectedValue);
                    if (!String.IsNullOrEmpty(cboDeposito.Text)) ll.IdDeposito = Convert.ToInt32(cboDeposito.SelectedValue);
                    if (!String.IsNullOrEmpty(cboEstilo.Text)) ll.IdEstilo = Convert.ToInt32(cboEstilo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboFormula.Text)) ll.Formula = Convert.ToInt32(cboFormula.SelectedValue);
                    if (!String.IsNullOrEmpty(cboLocalizacao.Text)) ll.IdLocalizacao = Convert.ToInt32(cboLocalizacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboLote.Text)) ll.IdLote = Convert.ToInt32(cboLote.SelectedValue);
                    if (!String.IsNullOrEmpty(cboPrincipioLiberacao.Text)) ll.PrincipioLiberacao = Convert.ToInt32(cboPrincipioLiberacao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboProduto.Text)) ll.IdProduto = Convert.ToInt32(cboProduto.SelectedValue);
                    if (!String.IsNullOrEmpty(cboSubBom.Text)) ll.SubBOM = Convert.ToInt32(cboSubBom.SelectedValue);
                    if (!String.IsNullOrEmpty(cboSubRoteiro.Text)) ll.SubRoteiro = Convert.ToInt32(cboSubRoteiro.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTamanho.Text)) ll.IdTamanho = Convert.ToInt32(cboTamanho.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipo.Text)) ll.TipoItem = Convert.ToInt32(cboTipo.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoIngrediente.Text)) ll.TipoIngrediente = Convert.ToInt32(cboTipoIngrediente.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoLinha.Text)) ll.TipoLinha = Convert.ToInt32(cboTipoLinha.SelectedValue);
                    if (!String.IsNullOrEmpty(cboTipoProducao.Text)) ll.TipoProducao = Convert.ToInt32(cboTipoProducao.SelectedValue);
                    if (!String.IsNullOrEmpty(cboUnidade.Text)) ll.IdUnidade = Convert.ToInt32(cboUnidade.SelectedValue);
                    ll.Ate = dtpAte.Value;
                    ll.De = dtpDe.Value;
                    if (!String.IsNullOrEmpty(txtAltura.Text)) ll.Altura = Convert.ToDecimal(txtAltura.Text);
                    if (!String.IsNullOrEmpty(txtDensidade.Text)) ll.Densidade = Convert.ToDecimal(txtDensidade.Text);
                    if (!String.IsNullOrEmpty(txtLargura.Text)) ll.Largura = Convert.ToDecimal(txtLargura.Text);
                    if (!String.IsNullOrEmpty(txtNOperacao.Text)) ll.NumeroOperacao = Convert.ToInt32(txtNOperacao.Text);
                    if (!String.IsNullOrEmpty(txtPercentual.Text)) ll.Percentual = Convert.ToDecimal(txtPercentual.Text);
                    if (!String.IsNullOrEmpty(txtPercentualCusto.Text)) ll.PercentualCustos = Convert.ToDecimal(txtPercentualCusto.Text);
                    if (!String.IsNullOrEmpty(txtPercentualRecuperacao.Text)) ll.PorcentagemRecuperacao = Convert.ToDecimal(txtPercentualRecuperacao.Text);
                    if (!String.IsNullOrEmpty(txtPorSerie.Text)) ll.Porserie = Convert.ToInt32(txtPorSerie.Text);
                    if (!String.IsNullOrEmpty(txtPrioridade.Text)) ll.Prioridade = Convert.ToInt32(txtPrioridade.Text);
                    if (!String.IsNullOrEmpty(txtProfundidade.Text)) ll.Profundidade = Convert.ToDecimal(txtProfundidade.Text);
                    if (!String.IsNullOrEmpty(txtQuantidade.Text)) ll.Quantidade = Convert.ToDecimal(txtQuantidade.Text);
                    if (!String.IsNullOrEmpty(txtSerie.Text)) ll.Serie = txtSerie.Text;
                    if (!String.IsNullOrEmpty(txtSucata.Text)) ll.SucataConstante = Convert.ToDecimal(txtSucata.Text);
                    if (!String.IsNullOrEmpty(txtValordecustoindiretosubprodutos.Text)) ll.ValorCustoIndiretoSubProduto = Convert.ToDecimal(txtValordecustoindiretosubprodutos.Text);
                    ll.AlocacaoCusto = chkAlocacaodeCusto.Checked;
                    ll.Calculo = chkCalculo.Checked;
                    ll.ConsumoRecurso = chkConsumoderecurso.Checked;
                    ll.DefinirSubProducaoComoConsumo = chkDefinirSubproducao.Checked;
                    ll.Escalonavel = chkEscalonavel.Checked;
                    ll.Fim = chkFim.Checked;
                    ll.HerdaLoteCoProduto = chkHerdarlotescoproduto.Checked;
                    ll.HerdaLoteProdutoFinal = chkHerdarlotesparaprodutofinal.Checked;
                    ll.HerdaValidadeCoproduto = chkHerdarvalidadecoproduto.Checked;
                    ll.HerdaValidadeProdutoFinal = chkHerdarvalidadeparaprodutofinal.Checked;
                    ll.PorcentagemContraolada = chkPorcentagemcontrolada.Checked;

                    if (ll.IdListaMateriaisLinhas == 0)
                    {
                        dal.Insert(ll);
                    }
                    else
                    {
                        dal.Update(ll);
                    }

                    dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                    CarregaDados();
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
                Util.Aplicacao.BloqueiaControles(this, btnAdiciona, btnAlterar, btnGrava, btnCancelar, btnExcluir);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Util.Aplicacao.ShowQuestionMessage("Deseja excluir este registro?") == System.Windows.Forms.DialogResult.Yes)
            {
                int id = Convert.ToInt32(ll.IdListaMateriaisLinhas);
                dal.Delete(id);
                dal.Save(Util.Util.GetAppSettings("IdUsuario"));
                this.Close();
            }
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPercentual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || (char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back))
            {
                if (Regex.IsMatch(txtPercentual.Text, "^\\d*\\,\\d{4}$"))
                    e.Handled = true;
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCombo combo = new frmCombo(Produtos);
            combo.Top = this.Top + tabControl1.Top + cboProduto.Top + 18;
            combo.Left = this.Left + cboProduto.Left + 12;
            combo.ShowDialog();
            if (!String.IsNullOrEmpty(combo.Id))
            {
                cboProduto.SelectedValue = Convert.ToInt32(combo.Id);
                BuscaProdutoDados();
            }
        }

        private void BuscaProdutoDados()
        {
            if (cboProduto.Text != "")
            {
                Produto pr = new ProdutoDAL().ProdutoRepository.GetByID(Convert.ToInt32(cboProduto.SelectedValue));
                if (pr != null)
                {
                    cboConfiguracao.SelectedValue = pr.IdVariantesConfig == null ? 0 : Convert.ToInt32(pr.IdVariantesConfig);
                    cboEstilo.SelectedValue = pr.IdVariantesEstilo == null ? 0 : Convert.ToInt32(pr.IdVariantesEstilo);
                    cboCor.SelectedValue = pr.IdVariantesCor == null ? 0 : Convert.ToInt32(pr.IdVariantesCor);
                    cboTamanho.SelectedValue = pr.IdVariantesTamanho == null ? 0 : Convert.ToInt32(pr.IdVariantesTamanho);
                    cboUnidade.SelectedValue = pr.ProducaoIdUnidade == null ? 0 : Convert.ToInt32(pr.ProducaoIdUnidade);
                    cboTipo.SelectedValue = pr.IdTipoProduto;
                    txtAltura.Text = pr.ProducaoAltura == null? "": pr.ProducaoAltura.ToString();
                    txtProfundidade.Text = pr.ProducaoProfundidade == null ? "" : pr.ProducaoProfundidade.ToString();
                    txtDensidade.Text = pr.ProducaoDensidade == null ? "" : pr.ProducaoDensidade.ToString();
                    txtLargura.Text = pr.ProducaoLargura == null ? "" : pr.ProducaoLargura.ToString();
                    cboTipoProducao.SelectedValue = pr.ProducaoTipoProducao == null ? 0 : Convert.ToInt32(pr.ProducaoTipoProducao);
                }
            }
        }
    }
}