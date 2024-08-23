namespace ERP
{
    partial class frmCodigoImpostoRetidoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCodigoImpostoRetidoCad));
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
            this.chkDeduzirINSS = new System.Windows.Forms.CheckBox();
            this.txtArredondamento = new System.Windows.Forms.TextBox();
            this.lblArredondamento = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigoReceita = new System.Windows.Forms.TextBox();
            this.lblCodigoReceita = new System.Windows.Forms.Label();
            this.lblMetodoCalculo = new System.Windows.Forms.Label();
            this.cboMetodoCalculo = new System.Windows.Forms.ComboBox();
            this.lblFormaArredondamento = new System.Windows.Forms.Label();
            this.cboFormaArredondamento = new System.Windows.Forms.ComboBox();
            this.lblTipoImposto = new System.Windows.Forms.Label();
            this.cboTipoImposto = new System.Windows.Forms.ComboBox();
            this.lblRetidoAReceber = new System.Windows.Forms.Label();
            this.cboRetidoAReceber = new System.Windows.Forms.ComboBox();
            this.lblLiquidacao = new System.Windows.Forms.Label();
            this.cboLiquidacao = new System.Windows.Forms.ComboBox();
            this.lblContaContabil = new System.Windows.Forms.Label();
            this.cboContaContabil = new System.Windows.Forms.ComboBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.cboBase = new System.Windows.Forms.ComboBox();
            this.lblPeriodoLiquidacao = new System.Windows.Forms.Label();
            this.cboPeriodoLiquidacao = new System.Windows.Forms.ComboBox();
            this.lblMoeda = new System.Windows.Forms.Label();
            this.cboMoeda = new System.Windows.Forms.ComboBox();
            this.lblPercentualValor = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgValores = new System.Windows.Forms.DataGridView();
            this.btnAddValores = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgLimite = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddLimite = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgValores)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLimite)).BeginInit();
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
            this.ribbon1.Size = new System.Drawing.Size(840, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 125);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(840, 493);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtPercentualValor);
            this.tabPage1.Controls.Add(this.chkDeduzirINSS);
            this.tabPage1.Controls.Add(this.txtArredondamento);
            this.tabPage1.Controls.Add(this.lblArredondamento);
            this.tabPage1.Controls.Add(this.txtCodigo);
            this.tabPage1.Controls.Add(this.lblCodigo);
            this.tabPage1.Controls.Add(this.txtCodigoReceita);
            this.tabPage1.Controls.Add(this.lblCodigoReceita);
            this.tabPage1.Controls.Add(this.lblMetodoCalculo);
            this.tabPage1.Controls.Add(this.cboMetodoCalculo);
            this.tabPage1.Controls.Add(this.lblFormaArredondamento);
            this.tabPage1.Controls.Add(this.cboFormaArredondamento);
            this.tabPage1.Controls.Add(this.lblTipoImposto);
            this.tabPage1.Controls.Add(this.cboTipoImposto);
            this.tabPage1.Controls.Add(this.lblRetidoAReceber);
            this.tabPage1.Controls.Add(this.cboRetidoAReceber);
            this.tabPage1.Controls.Add(this.lblLiquidacao);
            this.tabPage1.Controls.Add(this.cboLiquidacao);
            this.tabPage1.Controls.Add(this.lblContaContabil);
            this.tabPage1.Controls.Add(this.cboContaContabil);
            this.tabPage1.Controls.Add(this.lblBase);
            this.tabPage1.Controls.Add(this.cboBase);
            this.tabPage1.Controls.Add(this.lblPeriodoLiquidacao);
            this.tabPage1.Controls.Add(this.cboPeriodoLiquidacao);
            this.tabPage1.Controls.Add(this.lblMoeda);
            this.tabPage1.Controls.Add(this.cboMoeda);
            this.tabPage1.Controls.Add(this.lblPercentualValor);
            this.tabPage1.Controls.Add(this.txtDescricao);
            this.tabPage1.Controls.Add(this.lblDescricao);
            this.tabPage1.Controls.Add(this.lbCodigo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(832, 467);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Código de Imposto Retido";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtPercentualValor
            // 
            this.txtPercentualValor.Location = new System.Drawing.Point(254, 95);
            this.txtPercentualValor.Name = "txtPercentualValor";
            this.txtPercentualValor.Size = new System.Drawing.Size(147, 20);
            this.txtPercentualValor.TabIndex = 118;
            // 
            // chkDeduzirINSS
            // 
            this.chkDeduzirINSS.AutoSize = true;
            this.chkDeduzirINSS.Location = new System.Drawing.Point(198, 296);
            this.chkDeduzirINSS.Name = "chkDeduzirINSS";
            this.chkDeduzirINSS.Size = new System.Drawing.Size(90, 17);
            this.chkDeduzirINSS.TabIndex = 111;
            this.chkDeduzirINSS.Text = "Deduzir INSS";
            this.chkDeduzirINSS.UseVisualStyleBackColor = true;
            // 
            // txtArredondamento
            // 
            this.txtArredondamento.Location = new System.Drawing.Point(26, 293);
            this.txtArredondamento.MaxLength = 10;
            this.txtArredondamento.Name = "txtArredondamento";
            this.txtArredondamento.Size = new System.Drawing.Size(166, 20);
            this.txtArredondamento.TabIndex = 113;
            this.txtArredondamento.Tag = "";
            this.txtArredondamento.Text = "0,0000";
            // 
            // lblArredondamento
            // 
            this.lblArredondamento.AutoSize = true;
            this.lblArredondamento.Location = new System.Drawing.Point(23, 273);
            this.lblArredondamento.Name = "lblArredondamento";
            this.lblArredondamento.Size = new System.Drawing.Size(85, 13);
            this.lblArredondamento.TabIndex = 112;
            this.lblArredondamento.Text = "Arredondamento";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(26, 35);
            this.txtCodigo.MaxLength = 200;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(148, 20);
            this.txtCodigo.TabIndex = 86;
            this.txtCodigo.Tag = "1";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(23, 19);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 85;
            this.lblCodigo.Text = "Código";
            // 
            // txtCodigoReceita
            // 
            this.txtCodigoReceita.Location = new System.Drawing.Point(539, 95);
            this.txtCodigoReceita.MaxLength = 10;
            this.txtCodigoReceita.Name = "txtCodigoReceita";
            this.txtCodigoReceita.Size = new System.Drawing.Size(166, 20);
            this.txtCodigoReceita.TabIndex = 96;
            this.txtCodigoReceita.Tag = "";
            // 
            // lblCodigoReceita
            // 
            this.lblCodigoReceita.AutoSize = true;
            this.lblCodigoReceita.Location = new System.Drawing.Point(536, 75);
            this.lblCodigoReceita.Name = "lblCodigoReceita";
            this.lblCodigoReceita.Size = new System.Drawing.Size(95, 13);
            this.lblCodigoReceita.TabIndex = 95;
            this.lblCodigoReceita.Text = "Código da Receita";
            // 
            // lblMetodoCalculo
            // 
            this.lblMetodoCalculo.AutoSize = true;
            this.lblMetodoCalculo.Location = new System.Drawing.Point(291, 275);
            this.lblMetodoCalculo.Name = "lblMetodoCalculo";
            this.lblMetodoCalculo.Size = new System.Drawing.Size(96, 13);
            this.lblMetodoCalculo.TabIndex = 116;
            this.lblMetodoCalculo.Text = "Método de Cálculo";
            // 
            // cboMetodoCalculo
            // 
            this.cboMetodoCalculo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMetodoCalculo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMetodoCalculo.FormattingEnabled = true;
            this.cboMetodoCalculo.Location = new System.Drawing.Point(294, 294);
            this.cboMetodoCalculo.Name = "cboMetodoCalculo";
            this.cboMetodoCalculo.Size = new System.Drawing.Size(217, 21);
            this.cboMetodoCalculo.TabIndex = 117;
            this.cboMetodoCalculo.Tag = "1";
            // 
            // lblFormaArredondamento
            // 
            this.lblFormaArredondamento.AutoSize = true;
            this.lblFormaArredondamento.Location = new System.Drawing.Point(485, 200);
            this.lblFormaArredondamento.Name = "lblFormaArredondamento";
            this.lblFormaArredondamento.Size = new System.Drawing.Size(132, 13);
            this.lblFormaArredondamento.TabIndex = 114;
            this.lblFormaArredondamento.Text = "Forma de Arredondamento";
            // 
            // cboFormaArredondamento
            // 
            this.cboFormaArredondamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFormaArredondamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFormaArredondamento.FormattingEnabled = true;
            this.cboFormaArredondamento.Location = new System.Drawing.Point(488, 219);
            this.cboFormaArredondamento.Name = "cboFormaArredondamento";
            this.cboFormaArredondamento.Size = new System.Drawing.Size(217, 21);
            this.cboFormaArredondamento.TabIndex = 115;
            this.cboFormaArredondamento.Tag = "1";
            // 
            // lblTipoImposto
            // 
            this.lblTipoImposto.AutoSize = true;
            this.lblTipoImposto.Location = new System.Drawing.Point(23, 75);
            this.lblTipoImposto.Name = "lblTipoImposto";
            this.lblTipoImposto.Size = new System.Drawing.Size(68, 13);
            this.lblTipoImposto.TabIndex = 89;
            this.lblTipoImposto.Text = "Tipo Imposto";
            // 
            // cboTipoImposto
            // 
            this.cboTipoImposto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTipoImposto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoImposto.FormattingEnabled = true;
            this.cboTipoImposto.Location = new System.Drawing.Point(26, 94);
            this.cboTipoImposto.Name = "cboTipoImposto";
            this.cboTipoImposto.Size = new System.Drawing.Size(217, 21);
            this.cboTipoImposto.TabIndex = 90;
            this.cboTipoImposto.Tag = "1";
            // 
            // lblRetidoAReceber
            // 
            this.lblRetidoAReceber.AutoSize = true;
            this.lblRetidoAReceber.Location = new System.Drawing.Point(485, 136);
            this.lblRetidoAReceber.Name = "lblRetidoAReceber";
            this.lblRetidoAReceber.Size = new System.Drawing.Size(91, 13);
            this.lblRetidoAReceber.TabIndex = 103;
            this.lblRetidoAReceber.Text = "Retido a Receber";
            // 
            // cboRetidoAReceber
            // 
            this.cboRetidoAReceber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRetidoAReceber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRetidoAReceber.FormattingEnabled = true;
            this.cboRetidoAReceber.Location = new System.Drawing.Point(488, 155);
            this.cboRetidoAReceber.Name = "cboRetidoAReceber";
            this.cboRetidoAReceber.Size = new System.Drawing.Size(217, 21);
            this.cboRetidoAReceber.TabIndex = 104;
            this.cboRetidoAReceber.Tag = "1";
            // 
            // lblLiquidacao
            // 
            this.lblLiquidacao.AutoSize = true;
            this.lblLiquidacao.Location = new System.Drawing.Point(23, 200);
            this.lblLiquidacao.Name = "lblLiquidacao";
            this.lblLiquidacao.Size = new System.Drawing.Size(59, 13);
            this.lblLiquidacao.TabIndex = 105;
            this.lblLiquidacao.Text = "Liquidação";
            // 
            // cboLiquidacao
            // 
            this.cboLiquidacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboLiquidacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboLiquidacao.FormattingEnabled = true;
            this.cboLiquidacao.Location = new System.Drawing.Point(26, 219);
            this.cboLiquidacao.Name = "cboLiquidacao";
            this.cboLiquidacao.Size = new System.Drawing.Size(217, 21);
            this.cboLiquidacao.TabIndex = 106;
            this.cboLiquidacao.Tag = "1";
            // 
            // lblContaContabil
            // 
            this.lblContaContabil.AutoSize = true;
            this.lblContaContabil.Location = new System.Drawing.Point(251, 136);
            this.lblContaContabil.Name = "lblContaContabil";
            this.lblContaContabil.Size = new System.Drawing.Size(76, 13);
            this.lblContaContabil.TabIndex = 101;
            this.lblContaContabil.Text = "Conta Contábil";
            // 
            // cboContaContabil
            // 
            this.cboContaContabil.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboContaContabil.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboContaContabil.FormattingEnabled = true;
            this.cboContaContabil.Location = new System.Drawing.Point(254, 155);
            this.cboContaContabil.Name = "cboContaContabil";
            this.cboContaContabil.Size = new System.Drawing.Size(228, 21);
            this.cboContaContabil.TabIndex = 102;
            this.cboContaContabil.Tag = "1";
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Location = new System.Drawing.Point(251, 200);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(31, 13);
            this.lblBase.TabIndex = 109;
            this.lblBase.Text = "Base";
            // 
            // cboBase
            // 
            this.cboBase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBase.FormattingEnabled = true;
            this.cboBase.Location = new System.Drawing.Point(254, 219);
            this.cboBase.Name = "cboBase";
            this.cboBase.Size = new System.Drawing.Size(228, 21);
            this.cboBase.TabIndex = 110;
            this.cboBase.Tag = "1";
            // 
            // lblPeriodoLiquidacao
            // 
            this.lblPeriodoLiquidacao.AutoSize = true;
            this.lblPeriodoLiquidacao.Location = new System.Drawing.Point(23, 136);
            this.lblPeriodoLiquidacao.Name = "lblPeriodoLiquidacao";
            this.lblPeriodoLiquidacao.Size = new System.Drawing.Size(100, 13);
            this.lblPeriodoLiquidacao.TabIndex = 97;
            this.lblPeriodoLiquidacao.Text = "Período Liquidação";
            // 
            // cboPeriodoLiquidacao
            // 
            this.cboPeriodoLiquidacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPeriodoLiquidacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPeriodoLiquidacao.FormattingEnabled = true;
            this.cboPeriodoLiquidacao.Location = new System.Drawing.Point(26, 155);
            this.cboPeriodoLiquidacao.Name = "cboPeriodoLiquidacao";
            this.cboPeriodoLiquidacao.Size = new System.Drawing.Size(217, 21);
            this.cboPeriodoLiquidacao.TabIndex = 98;
            this.cboPeriodoLiquidacao.Tag = "1";
            // 
            // lblMoeda
            // 
            this.lblMoeda.AutoSize = true;
            this.lblMoeda.Location = new System.Drawing.Point(405, 75);
            this.lblMoeda.Name = "lblMoeda";
            this.lblMoeda.Size = new System.Drawing.Size(40, 13);
            this.lblMoeda.TabIndex = 93;
            this.lblMoeda.Text = "Moeda";
            // 
            // cboMoeda
            // 
            this.cboMoeda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMoeda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMoeda.FormattingEnabled = true;
            this.cboMoeda.Location = new System.Drawing.Point(408, 94);
            this.cboMoeda.Name = "cboMoeda";
            this.cboMoeda.Size = new System.Drawing.Size(125, 21);
            this.cboMoeda.TabIndex = 94;
            this.cboMoeda.Tag = "1";
            // 
            // lblPercentualValor
            // 
            this.lblPercentualValor.AutoSize = true;
            this.lblPercentualValor.Location = new System.Drawing.Point(251, 75);
            this.lblPercentualValor.Name = "lblPercentualValor";
            this.lblPercentualValor.Size = new System.Drawing.Size(100, 13);
            this.lblPercentualValor.TabIndex = 91;
            this.lblPercentualValor.Text = "Percentual de Valor";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(180, 35);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(445, 20);
            this.txtDescricao.TabIndex = 88;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(177, 19);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 87;
            this.lblDescricao.Text = "Descrição";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(351, 19);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 84;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgValores);
            this.tabPage3.Controls.Add(this.btnAddValores);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(832, 467);
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
            this.id,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14});
            this.dgValores.Location = new System.Drawing.Point(17, 45);
            this.dgValores.Name = "dgValores";
            this.dgValores.ReadOnly = true;
            this.dgValores.RowHeadersVisible = false;
            this.dgValores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgValores.Size = new System.Drawing.Size(801, 396);
            this.dgValores.TabIndex = 5;
            this.dgValores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgValores_CellDoubleClick);
            // 
            // btnAddValores
            // 
            this.btnAddValores.Location = new System.Drawing.Point(17, 16);
            this.btnAddValores.Name = "btnAddValores";
            this.btnAddValores.Size = new System.Drawing.Size(137, 23);
            this.btnAddValores.TabIndex = 4;
            this.btnAddValores.Text = "Adicionar valores";
            this.btnAddValores.UseVisualStyleBackColor = true;
            this.btnAddValores.Click += new System.EventHandler(this.btnAddValores_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgLimite);
            this.tabPage2.Controls.Add(this.btnAddLimite);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(832, 467);
            this.tabPage2.TabIndex = 3;
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
            this.dgLimite.Location = new System.Drawing.Point(28, 68);
            this.dgLimite.Name = "dgLimite";
            this.dgLimite.ReadOnly = true;
            this.dgLimite.RowHeadersVisible = false;
            this.dgLimite.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLimite.Size = new System.Drawing.Size(782, 371);
            this.dgLimite.TabIndex = 3;
            this.dgLimite.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLimite_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IdLimiteImpostoRetido";
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
            this.btnAddLimite.Location = new System.Drawing.Point(28, 28);
            this.btnAddLimite.Name = "btnAddLimite";
            this.btnAddLimite.Size = new System.Drawing.Size(137, 23);
            this.btnAddLimite.TabIndex = 2;
            this.btnAddLimite.Text = "Adicionar limite";
            this.btnAddLimite.UseVisualStyleBackColor = true;
            this.btnAddLimite.Click += new System.EventHandler(this.btnAddLimite_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "IdValoresImpostoRetido";
            this.id.HeaderText = "Column6";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
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
            // frmCodigoImpostoRetidoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(840, 618);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmCodigoImpostoRetidoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmCodigoImpostoRetidoCad";
            this.Text = "Cadastro Código Imposto Retido";
            this.Load += new System.EventHandler(this.frmCodigoImpostoRetidoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCodigoImpostoRetidoCad_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgValores)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgLimite)).EndInit();
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
        private System.Windows.Forms.CheckBox chkDeduzirINSS;
        private System.Windows.Forms.TextBox txtArredondamento;
        private System.Windows.Forms.Label lblArredondamento;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigoReceita;
        private System.Windows.Forms.Label lblCodigoReceita;
        private System.Windows.Forms.Label lblMetodoCalculo;
        private System.Windows.Forms.ComboBox cboMetodoCalculo;
        private System.Windows.Forms.Label lblFormaArredondamento;
        private System.Windows.Forms.ComboBox cboFormaArredondamento;
        private System.Windows.Forms.Label lblTipoImposto;
        private System.Windows.Forms.ComboBox cboTipoImposto;
        private System.Windows.Forms.Label lblRetidoAReceber;
        private System.Windows.Forms.ComboBox cboRetidoAReceber;
        private System.Windows.Forms.Label lblLiquidacao;
        private System.Windows.Forms.ComboBox cboLiquidacao;
        private System.Windows.Forms.Label lblContaContabil;
        private System.Windows.Forms.ComboBox cboContaContabil;
        private System.Windows.Forms.Label lblBase;
        private System.Windows.Forms.ComboBox cboBase;
        private System.Windows.Forms.Label lblPeriodoLiquidacao;
        private System.Windows.Forms.ComboBox cboPeriodoLiquidacao;
        private System.Windows.Forms.Label lblMoeda;
        private System.Windows.Forms.ComboBox cboMoeda;
        private System.Windows.Forms.Label lblPercentualValor;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.TextBox txtPercentualValor;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgValores;
        private System.Windows.Forms.Button btnAddValores;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgLimite;
        private System.Windows.Forms.Button btnAddLimite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
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