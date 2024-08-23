namespace ERP
{
    partial class frmListaMateriaisItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaMateriaisItem));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboUnidade = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQtde = new System.Windows.Forms.TextBox();
            this.lblAte = new System.Windows.Forms.Label();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.lblDe = new System.Windows.Forms.Label();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cboArmazem = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTamanho = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboEstilo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboConfiguracao = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblContaPlanoReferencial = new System.Windows.Forms.Label();
            this.cboProduto = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkVariacoesCoProduto = new System.Windows.Forms.CheckBox();
            this.chkUsarCalculo = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTamanhoFormula = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrioridade = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMultiploFormula = new System.Windows.Forms.TextBox();
            this.chkConstrucao = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboAlocacaoCustoTotal = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgMateriais = new System.Windows.Forms.DataGridView();
            this.btnAddMaterial = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMateriais)).BeginInit();
            this.SuspendLayout();
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
            this.ribbon1.Size = new System.Drawing.Size(884, 125);
            this.ribbon1.TabIndex = 2;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // rbOpcoes
            // 
            this.rbOpcoes.Panels.Add(this.ribbonPanel1);
            this.rbOpcoes.Text = "Documento";
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 125);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 486);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkAtivo);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.cboUnidade);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtQtde);
            this.tabPage1.Controls.Add(this.lblAte);
            this.tabPage1.Controls.Add(this.dtpAte);
            this.tabPage1.Controls.Add(this.lblDe);
            this.tabPage1.Controls.Add(this.dtpDe);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cboArmazem);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cboTamanho);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cboCor);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cboEstilo);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cboConfiguracao);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.lblContaPlanoReferencial);
            this.tabPage1.Controls.Add(this.cboProduto);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(876, 460);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Produto";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(322, 264);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(50, 17);
            this.chkAtivo.TabIndex = 101;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 100;
            this.label7.Text = "Unidade";
            // 
            // cboUnidade
            // 
            this.cboUnidade.FormattingEnabled = true;
            this.cboUnidade.Location = new System.Drawing.Point(171, 261);
            this.cboUnidade.Name = "cboUnidade";
            this.cboUnidade.Size = new System.Drawing.Size(145, 21);
            this.cboUnidade.TabIndex = 99;
            this.cboUnidade.Tag = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 98;
            this.label6.Text = "Quantidade";
            // 
            // txtQtde
            // 
            this.txtQtde.Location = new System.Drawing.Point(20, 262);
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Size = new System.Drawing.Size(145, 20);
            this.txtQtde.TabIndex = 97;
            this.txtQtde.Tag = "3";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Location = new System.Drawing.Point(696, 172);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(23, 13);
            this.lblAte.TabIndex = 95;
            this.lblAte.Text = "Até";
            // 
            // dtpAte
            // 
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(699, 188);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.Size = new System.Drawing.Size(145, 20);
            this.dtpAte.TabIndex = 96;
            this.dtpAte.Tag = "";
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(571, 172);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(21, 13);
            this.lblDe.TabIndex = 93;
            this.lblDe.Text = "De";
            // 
            // dtpDe
            // 
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.Location = new System.Drawing.Point(574, 188);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(119, 20);
            this.dtpDe.TabIndex = 94;
            this.dtpDe.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 92;
            this.label4.Text = "Armazem";
            // 
            // cboArmazem
            // 
            this.cboArmazem.FormattingEnabled = true;
            this.cboArmazem.Location = new System.Drawing.Point(299, 188);
            this.cboArmazem.Name = "cboArmazem";
            this.cboArmazem.Size = new System.Drawing.Size(269, 21);
            this.cboArmazem.TabIndex = 91;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 90;
            this.label5.Text = "Tamanho";
            // 
            // cboTamanho
            // 
            this.cboTamanho.FormattingEnabled = true;
            this.cboTamanho.Location = new System.Drawing.Point(20, 188);
            this.cboTamanho.Name = "cboTamanho";
            this.cboTamanho.Size = new System.Drawing.Size(273, 21);
            this.cboTamanho.TabIndex = 89;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(571, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Cor";
            // 
            // cboCor
            // 
            this.cboCor.FormattingEnabled = true;
            this.cboCor.Location = new System.Drawing.Point(574, 115);
            this.cboCor.Name = "cboCor";
            this.cboCor.Size = new System.Drawing.Size(273, 21);
            this.cboCor.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "Estilo";
            // 
            // cboEstilo
            // 
            this.cboEstilo.FormattingEnabled = true;
            this.cboEstilo.Location = new System.Drawing.Point(299, 115);
            this.cboEstilo.Name = "cboEstilo";
            this.cboEstilo.Size = new System.Drawing.Size(269, 21);
            this.cboEstilo.TabIndex = 85;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Configuração";
            // 
            // cboConfiguracao
            // 
            this.cboConfiguracao.FormattingEnabled = true;
            this.cboConfiguracao.Location = new System.Drawing.Point(20, 115);
            this.cboConfiguracao.Name = "cboConfiguracao";
            this.cboConfiguracao.Size = new System.Drawing.Size(273, 21);
            this.cboConfiguracao.TabIndex = 83;
            // 
            // button1
            // 
            this.button1.Image = global::ERP.Properties.Resources.lupa;
            this.button1.Location = new System.Drawing.Point(293, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 82;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblContaPlanoReferencial
            // 
            this.lblContaPlanoReferencial.AutoSize = true;
            this.lblContaPlanoReferencial.Location = new System.Drawing.Point(17, 26);
            this.lblContaPlanoReferencial.Name = "lblContaPlanoReferencial";
            this.lblContaPlanoReferencial.Size = new System.Drawing.Size(44, 13);
            this.lblContaPlanoReferencial.TabIndex = 81;
            this.lblContaPlanoReferencial.Text = "Produto";
            // 
            // cboProduto
            // 
            this.cboProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboProduto.DropDownWidth = 700;
            this.cboProduto.FormattingEnabled = true;
            this.cboProduto.Location = new System.Drawing.Point(20, 42);
            this.cboProduto.Name = "cboProduto";
            this.cboProduto.Size = new System.Drawing.Size(273, 21);
            this.cboProduto.TabIndex = 80;
            this.cboProduto.Tag = "1";
            this.cboProduto.Leave += new System.EventHandler(this.cboProduto_Leave);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkVariacoesCoProduto);
            this.tabPage2.Controls.Add(this.chkUsarCalculo);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.txtTamanhoFormula);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtPrioridade);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtMultiploFormula);
            this.tabPage2.Controls.Add(this.chkConstrucao);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.cboAlocacaoCustoTotal);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(876, 460);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuração";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkVariacoesCoProduto
            // 
            this.chkVariacoesCoProduto.AutoSize = true;
            this.chkVariacoesCoProduto.Location = new System.Drawing.Point(21, 134);
            this.chkVariacoesCoProduto.Name = "chkVariacoesCoProduto";
            this.chkVariacoesCoProduto.Size = new System.Drawing.Size(149, 17);
            this.chkVariacoesCoProduto.TabIndex = 106;
            this.chkVariacoesCoProduto.Text = "Variações de Co-Produtos";
            this.chkVariacoesCoProduto.UseVisualStyleBackColor = true;
            // 
            // chkUsarCalculo
            // 
            this.chkUsarCalculo.AutoSize = true;
            this.chkUsarCalculo.Location = new System.Drawing.Point(21, 111);
            this.chkUsarCalculo.Name = "chkUsarCalculo";
            this.chkUsarCalculo.Size = new System.Drawing.Size(109, 17);
            this.chkUsarCalculo.TabIndex = 105;
            this.chkUsarCalculo.Text = "Usar para cálculo";
            this.chkUsarCalculo.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(622, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 13);
            this.label11.TabIndex = 104;
            this.label11.Text = "Tamanho da Formula";
            // 
            // txtTamanhoFormula
            // 
            this.txtTamanhoFormula.Location = new System.Drawing.Point(625, 42);
            this.txtTamanhoFormula.Name = "txtTamanhoFormula";
            this.txtTamanhoFormula.Size = new System.Drawing.Size(145, 20);
            this.txtTamanhoFormula.TabIndex = 103;
            this.txtTamanhoFormula.Tag = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(471, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 102;
            this.label10.Text = "Prioridade";
            // 
            // txtPrioridade
            // 
            this.txtPrioridade.Location = new System.Drawing.Point(474, 42);
            this.txtPrioridade.Name = "txtPrioridade";
            this.txtPrioridade.Size = new System.Drawing.Size(145, 20);
            this.txtPrioridade.TabIndex = 101;
            this.txtPrioridade.Tag = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(320, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 100;
            this.label9.Text = "Multiplo da Formula";
            // 
            // txtMultiploFormula
            // 
            this.txtMultiploFormula.Location = new System.Drawing.Point(323, 42);
            this.txtMultiploFormula.Name = "txtMultiploFormula";
            this.txtMultiploFormula.Size = new System.Drawing.Size(145, 20);
            this.txtMultiploFormula.TabIndex = 99;
            this.txtMultiploFormula.Tag = "1";
            // 
            // chkConstrucao
            // 
            this.chkConstrucao.AutoSize = true;
            this.chkConstrucao.Location = new System.Drawing.Point(21, 88);
            this.chkConstrucao.Name = "chkConstrucao";
            this.chkConstrucao.Size = new System.Drawing.Size(80, 17);
            this.chkConstrucao.TabIndex = 93;
            this.chkConstrucao.Text = "Construção";
            this.chkConstrucao.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 92;
            this.label8.Text = "Alocação de Custo Total";
            // 
            // cboAlocacaoCustoTotal
            // 
            this.cboAlocacaoCustoTotal.FormattingEnabled = true;
            this.cboAlocacaoCustoTotal.Location = new System.Drawing.Point(21, 42);
            this.cboAlocacaoCustoTotal.Name = "cboAlocacaoCustoTotal";
            this.cboAlocacaoCustoTotal.Size = new System.Drawing.Size(296, 21);
            this.cboAlocacaoCustoTotal.TabIndex = 91;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgMateriais);
            this.tabPage3.Controls.Add(this.btnAddMaterial);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(876, 460);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Materiais que compõem o produto";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgMateriais
            // 
            this.dgMateriais.AllowUserToAddRows = false;
            this.dgMateriais.AllowUserToDeleteRows = false;
            this.dgMateriais.BackgroundColor = System.Drawing.Color.White;
            this.dgMateriais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMateriais.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgMateriais.Location = new System.Drawing.Point(24, 59);
            this.dgMateriais.Name = "dgMateriais";
            this.dgMateriais.ReadOnly = true;
            this.dgMateriais.RowHeadersVisible = false;
            this.dgMateriais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMateriais.Size = new System.Drawing.Size(823, 379);
            this.dgMateriais.TabIndex = 1;
            this.dgMateriais.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMateriais_CellDoubleClick);
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.Location = new System.Drawing.Point(24, 23);
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Size = new System.Drawing.Size(157, 23);
            this.btnAddMaterial.TabIndex = 0;
            this.btnAddMaterial.Text = "Adicionar Material";
            this.btnAddMaterial.UseVisualStyleBackColor = true;
            this.btnAddMaterial.Click += new System.EventHandler(this.btnAddMaterial_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IdListaMateriaisLinhas";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Codigo";
            this.Column2.HeaderText = "Código";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Nome";
            this.Column3.HeaderText = "Nome do Produto";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 400;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Quantidade";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column4.HeaderText = "Quantidade";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // frmListaMateriaisItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmListaMateriaisItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Materiais Item";
            this.Load += new System.EventHandler(this.frmClassificacaoCad_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMateriais)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboArmazem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTamanho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboEstilo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboConfiguracao;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblContaPlanoReferencial;
        private System.Windows.Forms.ComboBox cboProduto;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboUnidade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQtde;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.CheckBox chkConstrucao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboAlocacaoCustoTotal;
        private System.Windows.Forms.CheckBox chkVariacoesCoProduto;
        private System.Windows.Forms.CheckBox chkUsarCalculo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTamanhoFormula;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPrioridade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMultiploFormula;
        private System.Windows.Forms.Button btnAddMaterial;
        private System.Windows.Forms.DataGridView dgMateriais;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}