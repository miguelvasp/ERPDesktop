namespace ERP
{
    partial class frmMovimentacaoAtivoCad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovimentacaoAtivoCad));
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.btnImprimir = new System.Windows.Forms.RibbonButton();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonOrbOptionButton1 = new System.Windows.Forms.RibbonOrbOptionButton();
            this.lbMovimentacaoAtivo = new System.Windows.Forms.Label();
            this.cboMovimentacaoAtivo = new System.Windows.Forms.ComboBox();
            this.lbTransacaoAtivo = new System.Windows.Forms.Label();
            this.cboTransacaoAtivo = new System.Windows.Forms.ComboBox();
            this.lbAtivo = new System.Windows.Forms.Label();
            this.cboAtivo = new System.Windows.Forms.ComboBox();
            this.lbPerfilLancamento = new System.Windows.Forms.Label();
            this.cboPerfilLancamento = new System.Windows.Forms.ComboBox();
            this.lbCliente = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lbFornecedor = new System.Windows.Forms.Label();
            this.cboFornecedor = new System.Windows.Forms.ComboBox();
            this.lbConvencao = new System.Windows.Forms.Label();
            this.cboConvencao = new System.Windows.Forms.ComboBox();
            this.txtDataUltimaDepreciacao = new System.Windows.Forms.Label();
            this.lbExecucaoDepreciacao = new System.Windows.Forms.Label();
            this.lbGrupoAtivo = new System.Windows.Forms.Label();
            this.cboGrupoAtivo = new System.Windows.Forms.ComboBox();
            this.lbPermitirValorNegativo = new System.Windows.Forms.Label();
            this.cboPermitirValorNegativo = new System.Windows.Forms.ComboBox();
            this.lbPeriodo = new System.Windows.Forms.Label();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.lbPeriodoDepreciacaoRestante = new System.Windows.Forms.Label();
            this.cboPeriodoDepreciacaoRestante = new System.Windows.Forms.ComboBox();
            this.lbValorAquisicao = new System.Windows.Forms.Label();
            this.txtValorAquisicao = new System.Windows.Forms.TextBox();
            this.txtRevisaoAquisicao = new System.Windows.Forms.TextBox();
            this.txtValorSucata = new System.Windows.Forms.TextBox();
            this.txtValorVenda = new System.Windows.Forms.TextBox();
            this.txtValorICMS = new System.Windows.Forms.TextBox();
            this.lbRevisaoAquisicao = new System.Windows.Forms.Label();
            this.lbValorSucata = new System.Windows.Forms.Label();
            this.lbValorVenda = new System.Windows.Forms.Label();
            this.lbValorICMS = new System.Windows.Forms.Label();
            this.cboStatusAtivo = new System.Windows.Forms.ComboBox();
            this.lbStatusAtivo = new System.Windows.Forms.Label();
            this.lbVidaUtil = new System.Windows.Forms.Label();
            this.txtVidaUtil = new System.Windows.Forms.TextBox();
            this.txtNotaFiscal = new System.Windows.Forms.TextBox();
            this.lbDataTrasacao = new System.Windows.Forms.Label();
            this.lbDataDocumento = new System.Windows.Forms.Label();
            this.lbNotaFiscal = new System.Windows.Forms.Label();
            this.lbNivelLancamento = new System.Windows.Forms.Label();
            this.cboNivelLancamento = new System.Windows.Forms.ComboBox();
            this.lbDepreciacao = new System.Windows.Forms.Label();
            this.cboDepreciacao = new System.Windows.Forms.ComboBox();
            this.txtDataUltimaDepre = new System.Windows.Forms.MaskedTextBox();
            this.txtDataExecucaoDepreciacao = new System.Windows.Forms.MaskedTextBox();
            this.txtDataTrasação = new System.Windows.Forms.MaskedTextBox();
            this.txtDataDocumento = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.btnAdiciona);
            this.ribbonPanel1.Items.Add(this.btnAlterar);
            this.ribbonPanel1.Items.Add(this.btnGrava);
            this.ribbonPanel1.Items.Add(this.btnCancelar);
            this.ribbonPanel1.Items.Add(this.btnExcluir);
            this.ribbonPanel1.Text = "Informações";
            // 
            // btnAdiciona
            // 
            this.btnAdiciona.Image = ((System.Drawing.Image)(resources.GetObject("btnAdiciona.Image")));
            this.btnAdiciona.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAdiciona.SmallImage")));
            this.btnAdiciona.Text = "Adicionar";
            this.btnAdiciona.Click += new System.EventHandler(this.btnAdiciona_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAlterar.SmallImage")));
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnGrava
            // 
            this.btnGrava.Enabled = false;
            this.btnGrava.Image = ((System.Drawing.Image)(resources.GetObject("btnGrava.Image")));
            this.btnGrava.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGrava.SmallImage")));
            this.btnGrava.Text = "Gravar";
            this.btnGrava.Click += new System.EventHandler(this.btnGrava_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.SmallImage")));
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnExcluir.SmallImage")));
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // rbOpcoes
            // 
            this.rbOpcoes.Panels.Add(this.ribbonPanel1);
            this.rbOpcoes.Panels.Add(this.ribbonPanel2);
            this.rbOpcoes.Text = "Documento";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.btnImprimir);
            this.ribbonPanel2.Text = "Relatórios";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.SmallImage")));
            this.btnImprimir.Text = "Imprimir";
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.OptionItems.Add(this.ribbonOrbOptionButton1);
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbVisible = false;
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(856, 125);
            this.ribbon1.TabIndex = 30;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // ribbonOrbOptionButton1
            // 
            this.ribbonOrbOptionButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbOptionButton1.Image")));
            this.ribbonOrbOptionButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbOptionButton1.SmallImage")));
            this.ribbonOrbOptionButton1.Text = "ribbonOrbOptionButton1";
            // 
            // lbMovimentacaoAtivo
            // 
            this.lbMovimentacaoAtivo.AutoSize = true;
            this.lbMovimentacaoAtivo.Location = new System.Drawing.Point(13, 142);
            this.lbMovimentacaoAtivo.Name = "lbMovimentacaoAtivo";
            this.lbMovimentacaoAtivo.Size = new System.Drawing.Size(104, 13);
            this.lbMovimentacaoAtivo.TabIndex = 31;
            this.lbMovimentacaoAtivo.Text = "Movimentação Ativo";
            // 
            // cboMovimentacaoAtivo
            // 
            this.cboMovimentacaoAtivo.FormattingEnabled = true;
            this.cboMovimentacaoAtivo.Location = new System.Drawing.Point(16, 159);
            this.cboMovimentacaoAtivo.Name = "cboMovimentacaoAtivo";
            this.cboMovimentacaoAtivo.Size = new System.Drawing.Size(263, 21);
            this.cboMovimentacaoAtivo.TabIndex = 32;
            this.cboMovimentacaoAtivo.Tag = "1";
            // 
            // lbTransacaoAtivo
            // 
            this.lbTransacaoAtivo.AutoSize = true;
            this.lbTransacaoAtivo.Location = new System.Drawing.Point(299, 142);
            this.lbTransacaoAtivo.Name = "lbTransacaoAtivo";
            this.lbTransacaoAtivo.Size = new System.Drawing.Size(85, 13);
            this.lbTransacaoAtivo.TabIndex = 33;
            this.lbTransacaoAtivo.Text = "Transação Ativo";
            // 
            // cboTransacaoAtivo
            // 
            this.cboTransacaoAtivo.FormattingEnabled = true;
            this.cboTransacaoAtivo.Location = new System.Drawing.Point(302, 158);
            this.cboTransacaoAtivo.Name = "cboTransacaoAtivo";
            this.cboTransacaoAtivo.Size = new System.Drawing.Size(264, 21);
            this.cboTransacaoAtivo.TabIndex = 34;
            // 
            // lbAtivo
            // 
            this.lbAtivo.AutoSize = true;
            this.lbAtivo.Location = new System.Drawing.Point(584, 142);
            this.lbAtivo.Name = "lbAtivo";
            this.lbAtivo.Size = new System.Drawing.Size(31, 13);
            this.lbAtivo.TabIndex = 35;
            this.lbAtivo.Text = "Ativo";
            // 
            // cboAtivo
            // 
            this.cboAtivo.FormattingEnabled = true;
            this.cboAtivo.Location = new System.Drawing.Point(587, 159);
            this.cboAtivo.Name = "cboAtivo";
            this.cboAtivo.Size = new System.Drawing.Size(248, 21);
            this.cboAtivo.TabIndex = 36;
            // 
            // lbPerfilLancamento
            // 
            this.lbPerfilLancamento.AutoSize = true;
            this.lbPerfilLancamento.Location = new System.Drawing.Point(12, 188);
            this.lbPerfilLancamento.Name = "lbPerfilLancamento";
            this.lbPerfilLancamento.Size = new System.Drawing.Size(92, 13);
            this.lbPerfilLancamento.TabIndex = 37;
            this.lbPerfilLancamento.Text = "Perfil Lançamento";
            // 
            // cboPerfilLancamento
            // 
            this.cboPerfilLancamento.FormattingEnabled = true;
            this.cboPerfilLancamento.Location = new System.Drawing.Point(16, 204);
            this.cboPerfilLancamento.Name = "cboPerfilLancamento";
            this.cboPerfilLancamento.Size = new System.Drawing.Size(263, 21);
            this.cboPerfilLancamento.TabIndex = 38;
            // 
            // lbCliente
            // 
            this.lbCliente.AutoSize = true;
            this.lbCliente.Location = new System.Drawing.Point(302, 188);
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Size = new System.Drawing.Size(39, 13);
            this.lbCliente.TabIndex = 39;
            this.lbCliente.Text = "Cliente";
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(302, 205);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(264, 21);
            this.cboCliente.TabIndex = 40;
            this.cboCliente.Tag = "1";
            // 
            // lbFornecedor
            // 
            this.lbFornecedor.AutoSize = true;
            this.lbFornecedor.Location = new System.Drawing.Point(584, 188);
            this.lbFornecedor.Name = "lbFornecedor";
            this.lbFornecedor.Size = new System.Drawing.Size(61, 13);
            this.lbFornecedor.TabIndex = 41;
            this.lbFornecedor.Text = "Fornecedor";
            // 
            // cboFornecedor
            // 
            this.cboFornecedor.FormattingEnabled = true;
            this.cboFornecedor.Location = new System.Drawing.Point(587, 205);
            this.cboFornecedor.Name = "cboFornecedor";
            this.cboFornecedor.Size = new System.Drawing.Size(248, 21);
            this.cboFornecedor.TabIndex = 42;
            this.cboFornecedor.Tag = "1";
            // 
            // lbConvencao
            // 
            this.lbConvencao.AutoSize = true;
            this.lbConvencao.Location = new System.Drawing.Point(12, 232);
            this.lbConvencao.Name = "lbConvencao";
            this.lbConvencao.Size = new System.Drawing.Size(62, 13);
            this.lbConvencao.TabIndex = 43;
            this.lbConvencao.Text = "Convenção";
            // 
            // cboConvencao
            // 
            this.cboConvencao.FormattingEnabled = true;
            this.cboConvencao.Location = new System.Drawing.Point(15, 248);
            this.cboConvencao.Name = "cboConvencao";
            this.cboConvencao.Size = new System.Drawing.Size(264, 21);
            this.cboConvencao.TabIndex = 44;
            this.cboConvencao.Tag = "1";
            // 
            // txtDataUltimaDepreciacao
            // 
            this.txtDataUltimaDepreciacao.AutoSize = true;
            this.txtDataUltimaDepreciacao.Location = new System.Drawing.Point(299, 232);
            this.txtDataUltimaDepreciacao.Name = "txtDataUltimaDepreciacao";
            this.txtDataUltimaDepreciacao.Size = new System.Drawing.Size(100, 13);
            this.txtDataUltimaDepreciacao.TabIndex = 45;
            this.txtDataUltimaDepreciacao.Text = "Ultima Depreciação";
            // 
            // lbExecucaoDepreciacao
            // 
            this.lbExecucaoDepreciacao.AutoSize = true;
            this.lbExecucaoDepreciacao.Location = new System.Drawing.Point(434, 232);
            this.lbExecucaoDepreciacao.Name = "lbExecucaoDepreciacao";
            this.lbExecucaoDepreciacao.Size = new System.Drawing.Size(132, 13);
            this.lbExecucaoDepreciacao.TabIndex = 47;
            this.lbExecucaoDepreciacao.Text = "Execução da depreciação";
            // 
            // lbGrupoAtivo
            // 
            this.lbGrupoAtivo.AutoSize = true;
            this.lbGrupoAtivo.Location = new System.Drawing.Point(584, 229);
            this.lbGrupoAtivo.Name = "lbGrupoAtivo";
            this.lbGrupoAtivo.Size = new System.Drawing.Size(63, 13);
            this.lbGrupoAtivo.TabIndex = 49;
            this.lbGrupoAtivo.Text = "Grupo Ativo";
            // 
            // cboGrupoAtivo
            // 
            this.cboGrupoAtivo.FormattingEnabled = true;
            this.cboGrupoAtivo.Location = new System.Drawing.Point(587, 245);
            this.cboGrupoAtivo.Name = "cboGrupoAtivo";
            this.cboGrupoAtivo.Size = new System.Drawing.Size(248, 21);
            this.cboGrupoAtivo.TabIndex = 50;
            this.cboGrupoAtivo.Tag = "1";
            // 
            // lbPermitirValorNegativo
            // 
            this.lbPermitirValorNegativo.AutoSize = true;
            this.lbPermitirValorNegativo.Location = new System.Drawing.Point(13, 276);
            this.lbPermitirValorNegativo.Name = "lbPermitirValorNegativo";
            this.lbPermitirValorNegativo.Size = new System.Drawing.Size(114, 13);
            this.lbPermitirValorNegativo.TabIndex = 51;
            this.lbPermitirValorNegativo.Text = "Permitir Valor Negativo";
            // 
            // cboPermitirValorNegativo
            // 
            this.cboPermitirValorNegativo.FormattingEnabled = true;
            this.cboPermitirValorNegativo.Location = new System.Drawing.Point(16, 293);
            this.cboPermitirValorNegativo.Name = "cboPermitirValorNegativo";
            this.cboPermitirValorNegativo.Size = new System.Drawing.Size(138, 21);
            this.cboPermitirValorNegativo.TabIndex = 52;
            this.cboPermitirValorNegativo.Tag = "1";
            // 
            // lbPeriodo
            // 
            this.lbPeriodo.AutoSize = true;
            this.lbPeriodo.Location = new System.Drawing.Point(157, 276);
            this.lbPeriodo.Name = "lbPeriodo";
            this.lbPeriodo.Size = new System.Drawing.Size(45, 13);
            this.lbPeriodo.TabIndex = 53;
            this.lbPeriodo.Text = "Período";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(160, 293);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(119, 20);
            this.txtPeriodo.TabIndex = 54;
            this.txtPeriodo.Tag = "3";
            // 
            // lbPeriodoDepreciacaoRestante
            // 
            this.lbPeriodoDepreciacaoRestante.AutoSize = true;
            this.lbPeriodoDepreciacaoRestante.Location = new System.Drawing.Point(299, 276);
            this.lbPeriodoDepreciacaoRestante.Name = "lbPeriodoDepreciacaoRestante";
            this.lbPeriodoDepreciacaoRestante.Size = new System.Drawing.Size(155, 13);
            this.lbPeriodoDepreciacaoRestante.TabIndex = 55;
            this.lbPeriodoDepreciacaoRestante.Text = "Período Depreciação Restante";
            // 
            // cboPeriodoDepreciacaoRestante
            // 
            this.cboPeriodoDepreciacaoRestante.FormattingEnabled = true;
            this.cboPeriodoDepreciacaoRestante.Location = new System.Drawing.Point(302, 293);
            this.cboPeriodoDepreciacaoRestante.Name = "cboPeriodoDepreciacaoRestante";
            this.cboPeriodoDepreciacaoRestante.Size = new System.Drawing.Size(264, 21);
            this.cboPeriodoDepreciacaoRestante.TabIndex = 56;
            this.cboPeriodoDepreciacaoRestante.Tag = "1";
            // 
            // lbValorAquisicao
            // 
            this.lbValorAquisicao.AutoSize = true;
            this.lbValorAquisicao.Location = new System.Drawing.Point(584, 276);
            this.lbValorAquisicao.Name = "lbValorAquisicao";
            this.lbValorAquisicao.Size = new System.Drawing.Size(80, 13);
            this.lbValorAquisicao.TabIndex = 57;
            this.lbValorAquisicao.Text = "Valor Aquisição";
            // 
            // txtValorAquisicao
            // 
            this.txtValorAquisicao.Location = new System.Drawing.Point(587, 293);
            this.txtValorAquisicao.Name = "txtValorAquisicao";
            this.txtValorAquisicao.Size = new System.Drawing.Size(131, 20);
            this.txtValorAquisicao.TabIndex = 58;
            this.txtValorAquisicao.Tag = "3";
            // 
            // txtRevisaoAquisicao
            // 
            this.txtRevisaoAquisicao.Location = new System.Drawing.Point(724, 293);
            this.txtRevisaoAquisicao.Name = "txtRevisaoAquisicao";
            this.txtRevisaoAquisicao.Size = new System.Drawing.Size(111, 20);
            this.txtRevisaoAquisicao.TabIndex = 59;
            this.txtRevisaoAquisicao.Tag = "3";
            // 
            // txtValorSucata
            // 
            this.txtValorSucata.Location = new System.Drawing.Point(302, 340);
            this.txtValorSucata.Name = "txtValorSucata";
            this.txtValorSucata.Size = new System.Drawing.Size(129, 20);
            this.txtValorSucata.TabIndex = 60;
            this.txtValorSucata.Tag = "3";
            // 
            // txtValorVenda
            // 
            this.txtValorVenda.Location = new System.Drawing.Point(437, 340);
            this.txtValorVenda.Name = "txtValorVenda";
            this.txtValorVenda.Size = new System.Drawing.Size(129, 20);
            this.txtValorVenda.TabIndex = 61;
            this.txtValorVenda.Tag = "3";
            // 
            // txtValorICMS
            // 
            this.txtValorICMS.Location = new System.Drawing.Point(587, 340);
            this.txtValorICMS.Name = "txtValorICMS";
            this.txtValorICMS.Size = new System.Drawing.Size(131, 20);
            this.txtValorICMS.TabIndex = 62;
            this.txtValorICMS.Tag = "3";
            // 
            // lbRevisaoAquisicao
            // 
            this.lbRevisaoAquisicao.AutoSize = true;
            this.lbRevisaoAquisicao.Location = new System.Drawing.Point(721, 276);
            this.lbRevisaoAquisicao.Name = "lbRevisaoAquisicao";
            this.lbRevisaoAquisicao.Size = new System.Drawing.Size(95, 13);
            this.lbRevisaoAquisicao.TabIndex = 63;
            this.lbRevisaoAquisicao.Text = "Revisão Aquisição";
            // 
            // lbValorSucata
            // 
            this.lbValorSucata.AutoSize = true;
            this.lbValorSucata.Location = new System.Drawing.Point(299, 323);
            this.lbValorSucata.Name = "lbValorSucata";
            this.lbValorSucata.Size = new System.Drawing.Size(83, 13);
            this.lbValorSucata.TabIndex = 64;
            this.lbValorSucata.Text = "Valor de Sucata";
            // 
            // lbValorVenda
            // 
            this.lbValorVenda.AutoSize = true;
            this.lbValorVenda.Location = new System.Drawing.Point(434, 323);
            this.lbValorVenda.Name = "lbValorVenda";
            this.lbValorVenda.Size = new System.Drawing.Size(80, 13);
            this.lbValorVenda.TabIndex = 65;
            this.lbValorVenda.Text = "Valor de Venda";
            // 
            // lbValorICMS
            // 
            this.lbValorICMS.AutoSize = true;
            this.lbValorICMS.Location = new System.Drawing.Point(584, 323);
            this.lbValorICMS.Name = "lbValorICMS";
            this.lbValorICMS.Size = new System.Drawing.Size(75, 13);
            this.lbValorICMS.TabIndex = 66;
            this.lbValorICMS.Text = "Valor de ICMS";
            // 
            // cboStatusAtivo
            // 
            this.cboStatusAtivo.FormattingEnabled = true;
            this.cboStatusAtivo.Location = new System.Drawing.Point(16, 339);
            this.cboStatusAtivo.Name = "cboStatusAtivo";
            this.cboStatusAtivo.Size = new System.Drawing.Size(263, 21);
            this.cboStatusAtivo.TabIndex = 67;
            this.cboStatusAtivo.Tag = "1";
            // 
            // lbStatusAtivo
            // 
            this.lbStatusAtivo.AutoSize = true;
            this.lbStatusAtivo.Location = new System.Drawing.Point(13, 323);
            this.lbStatusAtivo.Name = "lbStatusAtivo";
            this.lbStatusAtivo.Size = new System.Drawing.Size(64, 13);
            this.lbStatusAtivo.TabIndex = 68;
            this.lbStatusAtivo.Text = "Status Ativo";
            // 
            // lbVidaUtil
            // 
            this.lbVidaUtil.AutoSize = true;
            this.lbVidaUtil.Location = new System.Drawing.Point(721, 323);
            this.lbVidaUtil.Name = "lbVidaUtil";
            this.lbVidaUtil.Size = new System.Drawing.Size(46, 13);
            this.lbVidaUtil.TabIndex = 69;
            this.lbVidaUtil.Text = "Vida Util";
            // 
            // txtVidaUtil
            // 
            this.txtVidaUtil.Location = new System.Drawing.Point(724, 339);
            this.txtVidaUtil.Name = "txtVidaUtil";
            this.txtVidaUtil.Size = new System.Drawing.Size(111, 20);
            this.txtVidaUtil.TabIndex = 70;
            this.txtVidaUtil.Tag = "3";
            // 
            // txtNotaFiscal
            // 
            this.txtNotaFiscal.Location = new System.Drawing.Point(302, 389);
            this.txtNotaFiscal.Name = "txtNotaFiscal";
            this.txtNotaFiscal.Size = new System.Drawing.Size(129, 20);
            this.txtNotaFiscal.TabIndex = 73;
            this.txtNotaFiscal.Tag = "3";
            // 
            // lbDataTrasacao
            // 
            this.lbDataTrasacao.AutoSize = true;
            this.lbDataTrasacao.Location = new System.Drawing.Point(13, 373);
            this.lbDataTrasacao.Name = "lbDataTrasacao";
            this.lbDataTrasacao.Size = new System.Drawing.Size(93, 13);
            this.lbDataTrasacao.TabIndex = 74;
            this.lbDataTrasacao.Text = "Data da Trasação";
            // 
            // lbDataDocumento
            // 
            this.lbDataDocumento.AutoSize = true;
            this.lbDataDocumento.Location = new System.Drawing.Point(157, 373);
            this.lbDataDocumento.Name = "lbDataDocumento";
            this.lbDataDocumento.Size = new System.Drawing.Size(103, 13);
            this.lbDataDocumento.TabIndex = 75;
            this.lbDataDocumento.Text = "Data do Documento";
            // 
            // lbNotaFiscal
            // 
            this.lbNotaFiscal.AutoSize = true;
            this.lbNotaFiscal.Location = new System.Drawing.Point(299, 373);
            this.lbNotaFiscal.Name = "lbNotaFiscal";
            this.lbNotaFiscal.Size = new System.Drawing.Size(60, 13);
            this.lbNotaFiscal.TabIndex = 76;
            this.lbNotaFiscal.Text = "Nota Fiscal";
            // 
            // lbNivelLancamento
            // 
            this.lbNivelLancamento.AutoSize = true;
            this.lbNivelLancamento.Location = new System.Drawing.Point(434, 373);
            this.lbNivelLancamento.Name = "lbNivelLancamento";
            this.lbNivelLancamento.Size = new System.Drawing.Size(93, 13);
            this.lbNivelLancamento.TabIndex = 77;
            this.lbNivelLancamento.Text = "Nivel Lançamento";
            // 
            // cboNivelLancamento
            // 
            this.cboNivelLancamento.FormattingEnabled = true;
            this.cboNivelLancamento.Location = new System.Drawing.Point(437, 389);
            this.cboNivelLancamento.Name = "cboNivelLancamento";
            this.cboNivelLancamento.Size = new System.Drawing.Size(129, 21);
            this.cboNivelLancamento.TabIndex = 78;
            this.cboNivelLancamento.Tag = "1";
            // 
            // lbDepreciacao
            // 
            this.lbDepreciacao.AutoSize = true;
            this.lbDepreciacao.Location = new System.Drawing.Point(587, 373);
            this.lbDepreciacao.Name = "lbDepreciacao";
            this.lbDepreciacao.Size = new System.Drawing.Size(68, 13);
            this.lbDepreciacao.TabIndex = 79;
            this.lbDepreciacao.Text = "Depreciação";
            // 
            // cboDepreciacao
            // 
            this.cboDepreciacao.FormattingEnabled = true;
            this.cboDepreciacao.Location = new System.Drawing.Point(587, 389);
            this.cboDepreciacao.Name = "cboDepreciacao";
            this.cboDepreciacao.Size = new System.Drawing.Size(248, 21);
            this.cboDepreciacao.TabIndex = 80;
            this.cboDepreciacao.Tag = "1";
            // 
            // txtDataUltimaDepre
            // 
            this.txtDataUltimaDepre.Location = new System.Drawing.Point(302, 247);
            this.txtDataUltimaDepre.Mask = "99/99/9999";
            this.txtDataUltimaDepre.Name = "txtDataUltimaDepre";
            this.txtDataUltimaDepre.Size = new System.Drawing.Size(129, 20);
            this.txtDataUltimaDepre.TabIndex = 81;
            this.txtDataUltimaDepre.Tag = "2";
            // 
            // txtDataExecucaoDepreciacao
            // 
            this.txtDataExecucaoDepreciacao.Location = new System.Drawing.Point(437, 248);
            this.txtDataExecucaoDepreciacao.Mask = "99/99/9999";
            this.txtDataExecucaoDepreciacao.Name = "txtDataExecucaoDepreciacao";
            this.txtDataExecucaoDepreciacao.Size = new System.Drawing.Size(129, 20);
            this.txtDataExecucaoDepreciacao.TabIndex = 82;
            this.txtDataExecucaoDepreciacao.Tag = "2";
            // 
            // txtDataTrasação
            // 
            this.txtDataTrasação.Location = new System.Drawing.Point(15, 389);
            this.txtDataTrasação.Mask = "99/99/9999";
            this.txtDataTrasação.Name = "txtDataTrasação";
            this.txtDataTrasação.Size = new System.Drawing.Size(139, 20);
            this.txtDataTrasação.TabIndex = 83;
            this.txtDataTrasação.Tag = "2";
            // 
            // txtDataDocumento
            // 
            this.txtDataDocumento.Location = new System.Drawing.Point(160, 390);
            this.txtDataDocumento.Mask = "99/99/9999";
            this.txtDataDocumento.Name = "txtDataDocumento";
            this.txtDataDocumento.Size = new System.Drawing.Size(119, 20);
            this.txtDataDocumento.TabIndex = 84;
            this.txtDataDocumento.Tag = "2";
            // 
            // frmMovimentacaoAtivoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(856, 538);
            this.Controls.Add(this.txtDataDocumento);
            this.Controls.Add(this.txtDataTrasação);
            this.Controls.Add(this.txtDataExecucaoDepreciacao);
            this.Controls.Add(this.txtDataUltimaDepre);
            this.Controls.Add(this.cboDepreciacao);
            this.Controls.Add(this.lbDepreciacao);
            this.Controls.Add(this.cboNivelLancamento);
            this.Controls.Add(this.lbNivelLancamento);
            this.Controls.Add(this.lbNotaFiscal);
            this.Controls.Add(this.lbDataDocumento);
            this.Controls.Add(this.lbDataTrasacao);
            this.Controls.Add(this.txtNotaFiscal);
            this.Controls.Add(this.txtVidaUtil);
            this.Controls.Add(this.lbVidaUtil);
            this.Controls.Add(this.lbStatusAtivo);
            this.Controls.Add(this.cboStatusAtivo);
            this.Controls.Add(this.lbValorICMS);
            this.Controls.Add(this.lbValorVenda);
            this.Controls.Add(this.lbValorSucata);
            this.Controls.Add(this.lbRevisaoAquisicao);
            this.Controls.Add(this.txtValorICMS);
            this.Controls.Add(this.txtValorVenda);
            this.Controls.Add(this.txtValorSucata);
            this.Controls.Add(this.txtRevisaoAquisicao);
            this.Controls.Add(this.txtValorAquisicao);
            this.Controls.Add(this.lbValorAquisicao);
            this.Controls.Add(this.cboPeriodoDepreciacaoRestante);
            this.Controls.Add(this.lbPeriodoDepreciacaoRestante);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.lbPeriodo);
            this.Controls.Add(this.cboPermitirValorNegativo);
            this.Controls.Add(this.lbPermitirValorNegativo);
            this.Controls.Add(this.cboGrupoAtivo);
            this.Controls.Add(this.lbGrupoAtivo);
            this.Controls.Add(this.lbExecucaoDepreciacao);
            this.Controls.Add(this.txtDataUltimaDepreciacao);
            this.Controls.Add(this.cboConvencao);
            this.Controls.Add(this.lbConvencao);
            this.Controls.Add(this.cboFornecedor);
            this.Controls.Add(this.lbFornecedor);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.lbCliente);
            this.Controls.Add(this.cboPerfilLancamento);
            this.Controls.Add(this.lbPerfilLancamento);
            this.Controls.Add(this.cboAtivo);
            this.Controls.Add(this.lbAtivo);
            this.Controls.Add(this.cboTransacaoAtivo);
            this.Controls.Add(this.lbTransacaoAtivo);
            this.Controls.Add(this.cboMovimentacaoAtivo);
            this.Controls.Add(this.lbMovimentacaoAtivo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMovimentacaoAtivoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmMovimentacaoAtivoCad";
            this.Text = "Cadastro Movimentação Ativo";
            this.Load += new System.EventHandler(this.frmMovimentacaoAtivoCad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton btnImprimir;
        private System.Windows.Forms.RibbonOrbOptionButton ribbonOrbOptionButton1;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.Label lbMovimentacaoAtivo;
        private System.Windows.Forms.ComboBox cboMovimentacaoAtivo;
        private System.Windows.Forms.Label lbTransacaoAtivo;
        private System.Windows.Forms.ComboBox cboTransacaoAtivo;
        private System.Windows.Forms.Label lbAtivo;
        private System.Windows.Forms.ComboBox cboAtivo;
        private System.Windows.Forms.Label lbPerfilLancamento;
        private System.Windows.Forms.ComboBox cboPerfilLancamento;
        private System.Windows.Forms.Label lbCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lbFornecedor;
        private System.Windows.Forms.ComboBox cboFornecedor;
        private System.Windows.Forms.Label lbConvencao;
        private System.Windows.Forms.ComboBox cboConvencao;
        private System.Windows.Forms.Label txtDataUltimaDepreciacao;
        private System.Windows.Forms.Label lbExecucaoDepreciacao;
        private System.Windows.Forms.Label lbGrupoAtivo;
        private System.Windows.Forms.ComboBox cboGrupoAtivo;
        private System.Windows.Forms.Label lbPermitirValorNegativo;
        private System.Windows.Forms.ComboBox cboPermitirValorNegativo;
        private System.Windows.Forms.Label lbPeriodo;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Label lbPeriodoDepreciacaoRestante;
        private System.Windows.Forms.ComboBox cboPeriodoDepreciacaoRestante;
        private System.Windows.Forms.Label lbValorAquisicao;
        private System.Windows.Forms.TextBox txtValorAquisicao;
        private System.Windows.Forms.TextBox txtRevisaoAquisicao;
        private System.Windows.Forms.TextBox txtValorSucata;
        private System.Windows.Forms.TextBox txtValorVenda;
        private System.Windows.Forms.TextBox txtValorICMS;
        private System.Windows.Forms.Label lbRevisaoAquisicao;
        private System.Windows.Forms.Label lbValorSucata;
        private System.Windows.Forms.Label lbValorVenda;
        private System.Windows.Forms.Label lbValorICMS;
        private System.Windows.Forms.ComboBox cboStatusAtivo;
        private System.Windows.Forms.Label lbStatusAtivo;
        private System.Windows.Forms.Label lbVidaUtil;
        private System.Windows.Forms.TextBox txtVidaUtil;
        private System.Windows.Forms.TextBox txtNotaFiscal;
        private System.Windows.Forms.Label lbDataTrasacao;
        private System.Windows.Forms.Label lbDataDocumento;
        private System.Windows.Forms.Label lbNotaFiscal;
        private System.Windows.Forms.Label lbNivelLancamento;
        private System.Windows.Forms.ComboBox cboNivelLancamento;
        private System.Windows.Forms.Label lbDepreciacao;
        private System.Windows.Forms.ComboBox cboDepreciacao;
        private System.Windows.Forms.MaskedTextBox txtDataExecucaoDepreciacao;
        private System.Windows.Forms.MaskedTextBox txtDataTrasação;
        private System.Windows.Forms.MaskedTextBox txtDataDocumento;
        private System.Windows.Forms.MaskedTextBox txtDataUltimaDepre;
    }
}