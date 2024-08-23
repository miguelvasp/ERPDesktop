namespace ERP
{
    partial class frmCodigoImpostoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCodigoImpostoCad));
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtPercentualValor = new System.Windows.Forms.TextBox();
            this.txtCodigoReceita = new System.Windows.Forms.TextBox();
            this.lblCodigoReceita = new System.Windows.Forms.Label();
            this.lblMetodoSustituicaoTributaria = new System.Windows.Forms.Label();
            this.cboMetodoSustituicaoTributaria = new System.Windows.Forms.ComboBox();
            this.chkImpostoIncluso = new System.Windows.Forms.CheckBox();
            this.chkImpostoRetidoRecuperavel = new System.Windows.Forms.CheckBox();
            this.lblCodigoTributacao = new System.Windows.Forms.Label();
            this.cboCodigoTributacao = new System.Windows.Forms.ComboBox();
            this.lblTipoImposto = new System.Windows.Forms.Label();
            this.cboTipoImposto = new System.Windows.Forms.ComboBox();
            this.lblDataCalculo = new System.Windows.Forms.Label();
            this.cboDataCalculo = new System.Windows.Forms.ComboBox();
            this.lblUnidadeOperacional = new System.Windows.Forms.Label();
            this.cboUnidadeOperacional = new System.Windows.Forms.ComboBox();
            this.lblCodigoImposto = new System.Windows.Forms.Label();
            this.cboCodigoImposto = new System.Windows.Forms.ComboBox();
            this.lblMetodCalculo = new System.Windows.Forms.Label();
            this.cboMetodoCalculo = new System.Windows.Forms.ComboBox();
            this.lblBaseMarginal = new System.Windows.Forms.Label();
            this.cboBaseMarginal = new System.Windows.Forms.ComboBox();
            this.lblParametrosCalculo = new System.Windows.Forms.Label();
            this.cboParametrosCalculo = new System.Windows.Forms.ComboBox();
            this.chkPorcentagemNegativaImposto = new System.Windows.Forms.CheckBox();
            this.lblGrupoLancamentoContabil = new System.Windows.Forms.Label();
            this.cboGrupoLancamentoContabil = new System.Windows.Forms.ComboBox();
            this.lblPeriodoLiquidacao = new System.Windows.Forms.Label();
            this.cboPeriodoLiquidacao = new System.Windows.Forms.ComboBox();
            this.lblMoeda = new System.Windows.Forms.Label();
            this.cboMoeda = new System.Windows.Forms.ComboBox();
            this.lblPercentualValor = new System.Windows.Forms.Label();
            this.lblCodigoJuridicao = new System.Windows.Forms.Label();
            this.cboJuridicao = new System.Windows.Forms.ComboBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgLimite = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddLimite = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgValores = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddValores = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLimite)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgValores)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnExcluir.SmallImage")));
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.SmallImage")));
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrava
            // 
            this.btnGrava.Enabled = false;
            this.btnGrava.Image = ((System.Drawing.Image)(resources.GetObject("btnGrava.Image")));
            this.btnGrava.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGrava.SmallImage")));
            this.btnGrava.Text = "Gravar";
            this.btnGrava.Click += new System.EventHandler(this.btnGrava_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAlterar.SmallImage")));
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnAdiciona
            // 
            this.btnAdiciona.Image = ((System.Drawing.Image)(resources.GetObject("btnAdiciona.Image")));
            this.btnAdiciona.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAdiciona.SmallImage")));
            this.btnAdiciona.Text = "Adicionar";
            this.btnAdiciona.Click += new System.EventHandler(this.btnAdiciona_Click);
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
            // rbOpcoes
            // 
            this.rbOpcoes.Panels.Add(this.ribbonPanel1);
            this.rbOpcoes.Text = "Documento";
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
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbDropDown.Visible = false;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbVisible = false;
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(884, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 125);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 480);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtPercentualValor);
            this.tabPage1.Controls.Add(this.txtCodigoReceita);
            this.tabPage1.Controls.Add(this.lblCodigoReceita);
            this.tabPage1.Controls.Add(this.lblMetodoSustituicaoTributaria);
            this.tabPage1.Controls.Add(this.cboMetodoSustituicaoTributaria);
            this.tabPage1.Controls.Add(this.chkImpostoIncluso);
            this.tabPage1.Controls.Add(this.chkImpostoRetidoRecuperavel);
            this.tabPage1.Controls.Add(this.lblCodigoTributacao);
            this.tabPage1.Controls.Add(this.cboCodigoTributacao);
            this.tabPage1.Controls.Add(this.lblTipoImposto);
            this.tabPage1.Controls.Add(this.cboTipoImposto);
            this.tabPage1.Controls.Add(this.lblDataCalculo);
            this.tabPage1.Controls.Add(this.cboDataCalculo);
            this.tabPage1.Controls.Add(this.lblUnidadeOperacional);
            this.tabPage1.Controls.Add(this.cboUnidadeOperacional);
            this.tabPage1.Controls.Add(this.lblCodigoImposto);
            this.tabPage1.Controls.Add(this.cboCodigoImposto);
            this.tabPage1.Controls.Add(this.lblMetodCalculo);
            this.tabPage1.Controls.Add(this.cboMetodoCalculo);
            this.tabPage1.Controls.Add(this.lblBaseMarginal);
            this.tabPage1.Controls.Add(this.cboBaseMarginal);
            this.tabPage1.Controls.Add(this.lblParametrosCalculo);
            this.tabPage1.Controls.Add(this.cboParametrosCalculo);
            this.tabPage1.Controls.Add(this.chkPorcentagemNegativaImposto);
            this.tabPage1.Controls.Add(this.lblGrupoLancamentoContabil);
            this.tabPage1.Controls.Add(this.cboGrupoLancamentoContabil);
            this.tabPage1.Controls.Add(this.lblPeriodoLiquidacao);
            this.tabPage1.Controls.Add(this.cboPeriodoLiquidacao);
            this.tabPage1.Controls.Add(this.lblMoeda);
            this.tabPage1.Controls.Add(this.cboMoeda);
            this.tabPage1.Controls.Add(this.lblPercentualValor);
            this.tabPage1.Controls.Add(this.lblCodigoJuridicao);
            this.tabPage1.Controls.Add(this.cboJuridicao);
            this.tabPage1.Controls.Add(this.txtDescricao);
            this.tabPage1.Controls.Add(this.lblDescricao);
            this.tabPage1.Controls.Add(this.lbCodigo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(876, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Código de imposto";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtPercentualValor
            // 
            this.txtPercentualValor.Location = new System.Drawing.Point(307, 90);
            this.txtPercentualValor.Name = "txtPercentualValor";
            this.txtPercentualValor.Size = new System.Drawing.Size(279, 20);
            this.txtPercentualValor.TabIndex = 87;
            this.txtPercentualValor.Tag = "1";
            // 
            // txtCodigoReceita
            // 
            this.txtCodigoReceita.Location = new System.Drawing.Point(489, 413);
            this.txtCodigoReceita.MaxLength = 10;
            this.txtCodigoReceita.Name = "txtCodigoReceita";
            this.txtCodigoReceita.Size = new System.Drawing.Size(166, 20);
            this.txtCodigoReceita.TabIndex = 86;
            this.txtCodigoReceita.Tag = "";
            // 
            // lblCodigoReceita
            // 
            this.lblCodigoReceita.AutoSize = true;
            this.lblCodigoReceita.Location = new System.Drawing.Point(486, 393);
            this.lblCodigoReceita.Name = "lblCodigoReceita";
            this.lblCodigoReceita.Size = new System.Drawing.Size(95, 13);
            this.lblCodigoReceita.TabIndex = 85;
            this.lblCodigoReceita.Text = "Código da Receita";
            // 
            // lblMetodoSustituicaoTributaria
            // 
            this.lblMetodoSustituicaoTributaria.AutoSize = true;
            this.lblMetodoSustituicaoTributaria.Location = new System.Drawing.Point(589, 326);
            this.lblMetodoSustituicaoTributaria.Name = "lblMetodoSustituicaoTributaria";
            this.lblMetodoSustituicaoTributaria.Size = new System.Drawing.Size(145, 13);
            this.lblMetodoSustituicaoTributaria.TabIndex = 83;
            this.lblMetodoSustituicaoTributaria.Text = "Método Sustituição Tributária";
            // 
            // cboMetodoSustituicaoTributaria
            // 
            this.cboMetodoSustituicaoTributaria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMetodoSustituicaoTributaria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMetodoSustituicaoTributaria.FormattingEnabled = true;
            this.cboMetodoSustituicaoTributaria.Location = new System.Drawing.Point(592, 345);
            this.cboMetodoSustituicaoTributaria.Name = "cboMetodoSustituicaoTributaria";
            this.cboMetodoSustituicaoTributaria.Size = new System.Drawing.Size(276, 21);
            this.cboMetodoSustituicaoTributaria.TabIndex = 84;
            this.cboMetodoSustituicaoTributaria.Tag = "1";
            // 
            // chkImpostoIncluso
            // 
            this.chkImpostoIncluso.AutoSize = true;
            this.chkImpostoIncluso.Location = new System.Drawing.Point(256, 413);
            this.chkImpostoIncluso.Name = "chkImpostoIncluso";
            this.chkImpostoIncluso.Size = new System.Drawing.Size(100, 17);
            this.chkImpostoIncluso.TabIndex = 82;
            this.chkImpostoIncluso.Text = "Imposto Incluso";
            this.chkImpostoIncluso.UseVisualStyleBackColor = true;
            // 
            // chkImpostoRetidoRecuperavel
            // 
            this.chkImpostoRetidoRecuperavel.AutoSize = true;
            this.chkImpostoRetidoRecuperavel.Location = new System.Drawing.Point(28, 413);
            this.chkImpostoRetidoRecuperavel.Name = "chkImpostoRetidoRecuperavel";
            this.chkImpostoRetidoRecuperavel.Size = new System.Drawing.Size(161, 17);
            this.chkImpostoRetidoRecuperavel.TabIndex = 81;
            this.chkImpostoRetidoRecuperavel.Text = "Imposto Retido Recuperável";
            this.chkImpostoRetidoRecuperavel.UseVisualStyleBackColor = true;
            // 
            // lblCodigoTributacao
            // 
            this.lblCodigoTributacao.AutoSize = true;
            this.lblCodigoTributacao.Location = new System.Drawing.Point(304, 326);
            this.lblCodigoTributacao.Name = "lblCodigoTributacao";
            this.lblCodigoTributacao.Size = new System.Drawing.Size(94, 13);
            this.lblCodigoTributacao.TabIndex = 79;
            this.lblCodigoTributacao.Text = "Código Tributação";
            // 
            // cboCodigoTributacao
            // 
            this.cboCodigoTributacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCodigoTributacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCodigoTributacao.FormattingEnabled = true;
            this.cboCodigoTributacao.Location = new System.Drawing.Point(307, 345);
            this.cboCodigoTributacao.Name = "cboCodigoTributacao";
            this.cboCodigoTributacao.Size = new System.Drawing.Size(279, 21);
            this.cboCodigoTributacao.TabIndex = 80;
            this.cboCodigoTributacao.Tag = "1";
            // 
            // lblTipoImposto
            // 
            this.lblTipoImposto.AutoSize = true;
            this.lblTipoImposto.Location = new System.Drawing.Point(25, 326);
            this.lblTipoImposto.Name = "lblTipoImposto";
            this.lblTipoImposto.Size = new System.Drawing.Size(68, 13);
            this.lblTipoImposto.TabIndex = 77;
            this.lblTipoImposto.Text = "Tipo Imposto";
            // 
            // cboTipoImposto
            // 
            this.cboTipoImposto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTipoImposto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoImposto.FormattingEnabled = true;
            this.cboTipoImposto.Location = new System.Drawing.Point(28, 345);
            this.cboTipoImposto.Name = "cboTipoImposto";
            this.cboTipoImposto.Size = new System.Drawing.Size(273, 21);
            this.cboTipoImposto.TabIndex = 78;
            this.cboTipoImposto.Tag = "";
            this.cboTipoImposto.Leave += new System.EventHandler(this.cboTipoImposto_Leave);
            // 
            // lblDataCalculo
            // 
            this.lblDataCalculo.AutoSize = true;
            this.lblDataCalculo.Location = new System.Drawing.Point(589, 259);
            this.lblDataCalculo.Name = "lblDataCalculo";
            this.lblDataCalculo.Size = new System.Drawing.Size(83, 13);
            this.lblDataCalculo.TabIndex = 75;
            this.lblDataCalculo.Text = "Data do Cálculo";
            // 
            // cboDataCalculo
            // 
            this.cboDataCalculo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDataCalculo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDataCalculo.FormattingEnabled = true;
            this.cboDataCalculo.Location = new System.Drawing.Point(592, 278);
            this.cboDataCalculo.Name = "cboDataCalculo";
            this.cboDataCalculo.Size = new System.Drawing.Size(276, 21);
            this.cboDataCalculo.TabIndex = 76;
            this.cboDataCalculo.Tag = "1";
            // 
            // lblUnidadeOperacional
            // 
            this.lblUnidadeOperacional.AutoSize = true;
            this.lblUnidadeOperacional.Location = new System.Drawing.Point(304, 259);
            this.lblUnidadeOperacional.Name = "lblUnidadeOperacional";
            this.lblUnidadeOperacional.Size = new System.Drawing.Size(107, 13);
            this.lblUnidadeOperacional.TabIndex = 73;
            this.lblUnidadeOperacional.Text = "Unidade Operacional";
            // 
            // cboUnidadeOperacional
            // 
            this.cboUnidadeOperacional.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboUnidadeOperacional.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUnidadeOperacional.FormattingEnabled = true;
            this.cboUnidadeOperacional.Location = new System.Drawing.Point(307, 278);
            this.cboUnidadeOperacional.Name = "cboUnidadeOperacional";
            this.cboUnidadeOperacional.Size = new System.Drawing.Size(279, 21);
            this.cboUnidadeOperacional.TabIndex = 74;
            this.cboUnidadeOperacional.Tag = "";
            // 
            // lblCodigoImposto
            // 
            this.lblCodigoImposto.AutoSize = true;
            this.lblCodigoImposto.Location = new System.Drawing.Point(25, 259);
            this.lblCodigoImposto.Name = "lblCodigoImposto";
            this.lblCodigoImposto.Size = new System.Drawing.Size(80, 13);
            this.lblCodigoImposto.TabIndex = 71;
            this.lblCodigoImposto.Text = "Código Imposto";
            // 
            // cboCodigoImposto
            // 
            this.cboCodigoImposto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCodigoImposto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCodigoImposto.FormattingEnabled = true;
            this.cboCodigoImposto.Location = new System.Drawing.Point(28, 278);
            this.cboCodigoImposto.Name = "cboCodigoImposto";
            this.cboCodigoImposto.Size = new System.Drawing.Size(273, 21);
            this.cboCodigoImposto.TabIndex = 72;
            this.cboCodigoImposto.Tag = "";
            // 
            // lblMetodCalculo
            // 
            this.lblMetodCalculo.AutoSize = true;
            this.lblMetodCalculo.Location = new System.Drawing.Point(589, 193);
            this.lblMetodCalculo.Name = "lblMetodCalculo";
            this.lblMetodCalculo.Size = new System.Drawing.Size(81, 13);
            this.lblMetodCalculo.TabIndex = 69;
            this.lblMetodCalculo.Text = "Método Cálculo";
            // 
            // cboMetodoCalculo
            // 
            this.cboMetodoCalculo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMetodoCalculo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMetodoCalculo.FormattingEnabled = true;
            this.cboMetodoCalculo.Location = new System.Drawing.Point(592, 212);
            this.cboMetodoCalculo.Name = "cboMetodoCalculo";
            this.cboMetodoCalculo.Size = new System.Drawing.Size(276, 21);
            this.cboMetodoCalculo.TabIndex = 70;
            this.cboMetodoCalculo.Tag = "1";
            // 
            // lblBaseMarginal
            // 
            this.lblBaseMarginal.AutoSize = true;
            this.lblBaseMarginal.Location = new System.Drawing.Point(304, 193);
            this.lblBaseMarginal.Name = "lblBaseMarginal";
            this.lblBaseMarginal.Size = new System.Drawing.Size(74, 13);
            this.lblBaseMarginal.TabIndex = 67;
            this.lblBaseMarginal.Text = "Base Marginal";
            // 
            // cboBaseMarginal
            // 
            this.cboBaseMarginal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBaseMarginal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBaseMarginal.FormattingEnabled = true;
            this.cboBaseMarginal.Location = new System.Drawing.Point(307, 212);
            this.cboBaseMarginal.Name = "cboBaseMarginal";
            this.cboBaseMarginal.Size = new System.Drawing.Size(279, 21);
            this.cboBaseMarginal.TabIndex = 68;
            this.cboBaseMarginal.Tag = "1";
            // 
            // lblParametrosCalculo
            // 
            this.lblParametrosCalculo.AutoSize = true;
            this.lblParametrosCalculo.Location = new System.Drawing.Point(25, 193);
            this.lblParametrosCalculo.Name = "lblParametrosCalculo";
            this.lblParametrosCalculo.Size = new System.Drawing.Size(122, 13);
            this.lblParametrosCalculo.TabIndex = 65;
            this.lblParametrosCalculo.Text = "Parâmetros para Cálculo";
            // 
            // cboParametrosCalculo
            // 
            this.cboParametrosCalculo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboParametrosCalculo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboParametrosCalculo.FormattingEnabled = true;
            this.cboParametrosCalculo.Location = new System.Drawing.Point(28, 212);
            this.cboParametrosCalculo.Name = "cboParametrosCalculo";
            this.cboParametrosCalculo.Size = new System.Drawing.Size(273, 21);
            this.cboParametrosCalculo.TabIndex = 66;
            this.cboParametrosCalculo.Tag = "1";
            // 
            // chkPorcentagemNegativaImposto
            // 
            this.chkPorcentagemNegativaImposto.AutoSize = true;
            this.chkPorcentagemNegativaImposto.Location = new System.Drawing.Point(28, 146);
            this.chkPorcentagemNegativaImposto.Name = "chkPorcentagemNegativaImposto";
            this.chkPorcentagemNegativaImposto.Size = new System.Drawing.Size(175, 17);
            this.chkPorcentagemNegativaImposto.TabIndex = 60;
            this.chkPorcentagemNegativaImposto.Text = "Porcentagem Negativa Imposto";
            this.chkPorcentagemNegativaImposto.UseVisualStyleBackColor = true;
            // 
            // lblGrupoLancamentoContabil
            // 
            this.lblGrupoLancamentoContabil.AutoSize = true;
            this.lblGrupoLancamentoContabil.Location = new System.Drawing.Point(589, 125);
            this.lblGrupoLancamentoContabil.Name = "lblGrupoLancamentoContabil";
            this.lblGrupoLancamentoContabil.Size = new System.Drawing.Size(139, 13);
            this.lblGrupoLancamentoContabil.TabIndex = 63;
            this.lblGrupoLancamentoContabil.Text = "Grupo Lançamento Contábil";
            // 
            // cboGrupoLancamentoContabil
            // 
            this.cboGrupoLancamentoContabil.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGrupoLancamentoContabil.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoLancamentoContabil.FormattingEnabled = true;
            this.cboGrupoLancamentoContabil.Location = new System.Drawing.Point(592, 144);
            this.cboGrupoLancamentoContabil.Name = "cboGrupoLancamentoContabil";
            this.cboGrupoLancamentoContabil.Size = new System.Drawing.Size(276, 21);
            this.cboGrupoLancamentoContabil.TabIndex = 64;
            this.cboGrupoLancamentoContabil.Tag = "";
            // 
            // lblPeriodoLiquidacao
            // 
            this.lblPeriodoLiquidacao.AutoSize = true;
            this.lblPeriodoLiquidacao.Location = new System.Drawing.Point(304, 125);
            this.lblPeriodoLiquidacao.Name = "lblPeriodoLiquidacao";
            this.lblPeriodoLiquidacao.Size = new System.Drawing.Size(100, 13);
            this.lblPeriodoLiquidacao.TabIndex = 61;
            this.lblPeriodoLiquidacao.Text = "Período Liquidação";
            // 
            // cboPeriodoLiquidacao
            // 
            this.cboPeriodoLiquidacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPeriodoLiquidacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPeriodoLiquidacao.FormattingEnabled = true;
            this.cboPeriodoLiquidacao.Location = new System.Drawing.Point(307, 144);
            this.cboPeriodoLiquidacao.Name = "cboPeriodoLiquidacao";
            this.cboPeriodoLiquidacao.Size = new System.Drawing.Size(279, 21);
            this.cboPeriodoLiquidacao.TabIndex = 62;
            this.cboPeriodoLiquidacao.Tag = "1";
            // 
            // lblMoeda
            // 
            this.lblMoeda.AutoSize = true;
            this.lblMoeda.Location = new System.Drawing.Point(589, 71);
            this.lblMoeda.Name = "lblMoeda";
            this.lblMoeda.Size = new System.Drawing.Size(40, 13);
            this.lblMoeda.TabIndex = 58;
            this.lblMoeda.Text = "Moeda";
            // 
            // cboMoeda
            // 
            this.cboMoeda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMoeda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMoeda.FormattingEnabled = true;
            this.cboMoeda.Location = new System.Drawing.Point(592, 90);
            this.cboMoeda.Name = "cboMoeda";
            this.cboMoeda.Size = new System.Drawing.Size(276, 21);
            this.cboMoeda.TabIndex = 59;
            this.cboMoeda.Tag = "1";
            // 
            // lblPercentualValor
            // 
            this.lblPercentualValor.AutoSize = true;
            this.lblPercentualValor.Location = new System.Drawing.Point(304, 71);
            this.lblPercentualValor.Name = "lblPercentualValor";
            this.lblPercentualValor.Size = new System.Drawing.Size(100, 13);
            this.lblPercentualValor.TabIndex = 57;
            this.lblPercentualValor.Text = "Percentual de Valor";
            // 
            // lblCodigoJuridicao
            // 
            this.lblCodigoJuridicao.AutoSize = true;
            this.lblCodigoJuridicao.Location = new System.Drawing.Point(25, 71);
            this.lblCodigoJuridicao.Name = "lblCodigoJuridicao";
            this.lblCodigoJuridicao.Size = new System.Drawing.Size(85, 13);
            this.lblCodigoJuridicao.TabIndex = 55;
            this.lblCodigoJuridicao.Text = "Código Juridição";
            // 
            // cboJuridicao
            // 
            this.cboJuridicao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboJuridicao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboJuridicao.FormattingEnabled = true;
            this.cboJuridicao.Location = new System.Drawing.Point(28, 90);
            this.cboJuridicao.Name = "cboJuridicao";
            this.cboJuridicao.Size = new System.Drawing.Size(273, 21);
            this.cboJuridicao.TabIndex = 56;
            this.cboJuridicao.Tag = "";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(28, 37);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(445, 20);
            this.txtDescricao.TabIndex = 54;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(25, 21);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 53;
            this.lblDescricao.Text = "Descrição";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(693, 21);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 52;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgLimite);
            this.tabPage2.Controls.Add(this.btnAddLimite);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(876, 454);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Limites";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgLimite
            // 
            this.dgLimite.AllowUserToAddRows = false;
            this.dgLimite.AllowUserToDeleteRows = false;
            this.dgLimite.BackgroundColor = System.Drawing.Color.White;
            this.dgLimite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLimite.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgLimite.Location = new System.Drawing.Point(19, 59);
            this.dgLimite.Name = "dgLimite";
            this.dgLimite.ReadOnly = true;
            this.dgLimite.RowHeadersVisible = false;
            this.dgLimite.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLimite.Size = new System.Drawing.Size(690, 371);
            this.dgLimite.TabIndex = 1;
            this.dgLimite.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLimite_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IdLimiteImposto";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "LimiteMinimo";
            this.Column2.HeaderText = "Limite Mínimo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "LimiteMaximo";
            this.Column3.HeaderText = "Limite Máximo";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "De";
            this.Column4.HeaderText = "De";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Ate";
            this.Column5.HeaderText = "Até";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // btnAddLimite
            // 
            this.btnAddLimite.Location = new System.Drawing.Point(19, 19);
            this.btnAddLimite.Name = "btnAddLimite";
            this.btnAddLimite.Size = new System.Drawing.Size(137, 23);
            this.btnAddLimite.TabIndex = 0;
            this.btnAddLimite.Text = "Adicionar limite";
            this.btnAddLimite.UseVisualStyleBackColor = true;
            this.btnAddLimite.Click += new System.EventHandler(this.btnAddLimite_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgValores);
            this.tabPage3.Controls.Add(this.btnAddValores);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(876, 454);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Valores";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgValores
            // 
            this.dgValores.AllowUserToAddRows = false;
            this.dgValores.AllowUserToDeleteRows = false;
            this.dgValores.BackgroundColor = System.Drawing.Color.White;
            this.dgValores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgValores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14});
            this.dgValores.Location = new System.Drawing.Point(20, 62);
            this.dgValores.Name = "dgValores";
            this.dgValores.ReadOnly = true;
            this.dgValores.RowHeadersVisible = false;
            this.dgValores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgValores.Size = new System.Drawing.Size(690, 371);
            this.dgValores.TabIndex = 3;
            this.dgValores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgValores_CellDoubleClick);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "IdValoresImposto";
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "De";
            this.Column7.HeaderText = "De";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Ate";
            this.Column8.HeaderText = "Ate";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "LimiteMaximo";
            this.Column9.HeaderText = "Limite Max.";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "LimiteMinimo";
            this.Column10.HeaderText = "Limite Min";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "Aliquota";
            this.Column11.HeaderText = "Aliquota";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "PercentualReducao";
            this.Column12.HeaderText = "% Redução";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "Markup";
            this.Column13.HeaderText = "Markup";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "PercentualIsencao";
            this.Column14.HeaderText = "% Isenção";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // btnAddValores
            // 
            this.btnAddValores.Location = new System.Drawing.Point(20, 22);
            this.btnAddValores.Name = "btnAddValores";
            this.btnAddValores.Size = new System.Drawing.Size(137, 23);
            this.btnAddValores.TabIndex = 2;
            this.btnAddValores.Text = "Adicionar valores";
            this.btnAddValores.UseVisualStyleBackColor = true;
            this.btnAddValores.Click += new System.EventHandler(this.btnAddValores_Click);
            // 
            // frmCodigoImpostoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(884, 605);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmCodigoImpostoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmCodigoImpostoCad";
            this.Text = "Cadastro de Código de Imposto";
            this.Load += new System.EventHandler(this.frmCodigoImpostoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCodigoImpostoCad_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgLimite)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgValores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtPercentualValor;
        private System.Windows.Forms.TextBox txtCodigoReceita;
        private System.Windows.Forms.Label lblCodigoReceita;
        private System.Windows.Forms.Label lblMetodoSustituicaoTributaria;
        private System.Windows.Forms.ComboBox cboMetodoSustituicaoTributaria;
        private System.Windows.Forms.CheckBox chkImpostoIncluso;
        private System.Windows.Forms.CheckBox chkImpostoRetidoRecuperavel;
        private System.Windows.Forms.Label lblCodigoTributacao;
        private System.Windows.Forms.ComboBox cboCodigoTributacao;
        private System.Windows.Forms.Label lblTipoImposto;
        private System.Windows.Forms.ComboBox cboTipoImposto;
        private System.Windows.Forms.Label lblDataCalculo;
        private System.Windows.Forms.ComboBox cboDataCalculo;
        private System.Windows.Forms.Label lblUnidadeOperacional;
        private System.Windows.Forms.ComboBox cboUnidadeOperacional;
        private System.Windows.Forms.Label lblCodigoImposto;
        private System.Windows.Forms.ComboBox cboCodigoImposto;
        private System.Windows.Forms.Label lblMetodCalculo;
        private System.Windows.Forms.ComboBox cboMetodoCalculo;
        private System.Windows.Forms.Label lblBaseMarginal;
        private System.Windows.Forms.ComboBox cboBaseMarginal;
        private System.Windows.Forms.Label lblParametrosCalculo;
        private System.Windows.Forms.ComboBox cboParametrosCalculo;
        private System.Windows.Forms.CheckBox chkPorcentagemNegativaImposto;
        private System.Windows.Forms.Label lblGrupoLancamentoContabil;
        private System.Windows.Forms.ComboBox cboGrupoLancamentoContabil;
        private System.Windows.Forms.Label lblPeriodoLiquidacao;
        private System.Windows.Forms.ComboBox cboPeriodoLiquidacao;
        private System.Windows.Forms.Label lblMoeda;
        private System.Windows.Forms.ComboBox cboMoeda;
        private System.Windows.Forms.Label lblPercentualValor;
        private System.Windows.Forms.Label lblCodigoJuridicao;
        private System.Windows.Forms.ComboBox cboJuridicao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgLimite;
        private System.Windows.Forms.Button btnAddLimite;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgValores;
        private System.Windows.Forms.Button btnAddValores;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
    }
}