namespace ERP
{
    partial class frmEmpresaCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpresaCad));
            this.lbCodigo = new System.Windows.Forms.Label();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.rbbConfiguracao = new System.Windows.Forms.RibbonButton();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtInscricao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CNPJ = new System.Windows.Forms.Label();
            this.txtCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lo = new System.Windows.Forms.Label();
            this.txtRazao = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCompl = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCidade = new System.Windows.Forms.ComboBox();
            this.cboUF = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.txtTelefone2 = new System.Windows.Forms.TextBox();
            this.lblTelefone2 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.grContaBancaria = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.tsbAdicionarContaBancaria = new System.Windows.Forms.ToolStripButton();
            this.tsbExcluirContaBancaria = new System.Windows.Forms.ToolStripButton();
            this.lblContador = new System.Windows.Forms.Label();
            this.cboContador = new System.Windows.Forms.ComboBox();
            this.btnProcurarImagem = new System.Windows.Forms.Button();
            this.btnLimparLogo = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboMoeda = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboRegimeTributario = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grContaBancaria)).BeginInit();
            this.toolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(407, 128);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 13;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
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
            this.ribbonPanel2.Items.Add(this.rbbConfiguracao);
            this.ribbonPanel2.Text = "Dados";
            // 
            // rbbConfiguracao
            // 
            this.rbbConfiguracao.Image = ((System.Drawing.Image)(resources.GetObject("rbbConfiguracao.Image")));
            this.rbbConfiguracao.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbbConfiguracao.SmallImage")));
            this.rbbConfiguracao.Text = "Configurar";
            this.rbbConfiguracao.Click += new System.EventHandler(this.rbbConfiguracao_Click);
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
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtInscricao
            // 
            this.txtInscricao.Location = new System.Drawing.Point(294, 201);
            this.txtInscricao.MaxLength = 50;
            this.txtInscricao.Name = "txtInscricao";
            this.txtInscricao.Size = new System.Drawing.Size(175, 20);
            this.txtInscricao.TabIndex = 5;
            this.txtInscricao.Tag = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Inscrição Estadual";
            // 
            // CNPJ
            // 
            this.CNPJ.AutoSize = true;
            this.CNPJ.Location = new System.Drawing.Point(166, 185);
            this.CNPJ.Name = "CNPJ";
            this.CNPJ.Size = new System.Drawing.Size(34, 13);
            this.CNPJ.TabIndex = 32;
            this.CNPJ.Text = "CNPJ";
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.Location = new System.Drawing.Point(169, 201);
            this.txtCNPJ.Mask = "99.999.999/9999-99";
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(116, 20);
            this.txtCNPJ.TabIndex = 4;
            this.txtCNPJ.Tag = "1";
            // 
            // txtFantasia
            // 
            this.txtFantasia.Location = new System.Drawing.Point(629, 160);
            this.txtFantasia.MaxLength = 255;
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.Size = new System.Drawing.Size(251, 20);
            this.txtFantasia.TabIndex = 3;
            this.txtFantasia.Tag = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Razão Social";
            // 
            // lo
            // 
            this.lo.AutoSize = true;
            this.lo.Location = new System.Drawing.Point(626, 144);
            this.lo.Name = "lo";
            this.lo.Size = new System.Drawing.Size(78, 13);
            this.lo.TabIndex = 31;
            this.lo.Text = "Nome Fantasia";
            // 
            // txtRazao
            // 
            this.txtRazao.Location = new System.Drawing.Point(169, 161);
            this.txtRazao.MaxLength = 255;
            this.txtRazao.Name = "txtRazao";
            this.txtRazao.Size = new System.Drawing.Size(455, 20);
            this.txtRazao.TabIndex = 2;
            this.txtRazao.Tag = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 274);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "CEP";
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(15, 290);
            this.txtCEP.Mask = "99999-999";
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(68, 20);
            this.txtCEP.TabIndex = 31;
            this.txtCEP.Tag = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(694, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Bairro";
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(697, 243);
            this.txtBairro.MaxLength = 255;
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(183, 20);
            this.txtBairro.TabIndex = 9;
            this.txtBairro.Tag = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(472, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Complemento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(379, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Número";
            // 
            // txtCompl
            // 
            this.txtCompl.Location = new System.Drawing.Point(475, 243);
            this.txtCompl.MaxLength = 100;
            this.txtCompl.Name = "txtCompl";
            this.txtCompl.Size = new System.Drawing.Size(216, 20);
            this.txtCompl.TabIndex = 8;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(382, 243);
            this.txtNumero.MaxLength = 100;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(87, 20);
            this.txtNumero.TabIndex = 7;
            this.txtNumero.Tag = "1";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(15, 243);
            this.txtLog.MaxLength = 255;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(361, 20);
            this.txtLog.TabIndex = 6;
            this.txtLog.Tag = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Logradouro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Cidade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "UF";
            // 
            // cboCidade
            // 
            this.cboCidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCidade.FormattingEnabled = true;
            this.cboCidade.Location = new System.Drawing.Point(189, 289);
            this.cboCidade.Name = "cboCidade";
            this.cboCidade.Size = new System.Drawing.Size(339, 21);
            this.cboCidade.TabIndex = 12;
            this.cboCidade.Tag = "1";
            // 
            // cboUF
            // 
            this.cboUF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboUF.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUF.FormattingEnabled = true;
            this.cboUF.Location = new System.Drawing.Point(89, 289);
            this.cboUF.Name = "cboUF";
            this.cboUF.Size = new System.Drawing.Size(94, 21);
            this.cboUF.TabIndex = 11;
            this.cboUF.Tag = "1";
            this.cboUF.Leave += new System.EventHandler(this.cboUF_Leave);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(15, 341);
            this.txtEmail.MaxLength = 255;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(427, 20);
            this.txtEmail.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 325);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "E-Mail";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(534, 290);
            this.txtTelefone.MaxLength = 255;
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(112, 20);
            this.txtTelefone.TabIndex = 13;
            this.txtTelefone.Text = "+55 (99) 66778-0987";
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Location = new System.Drawing.Point(531, 274);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(49, 13);
            this.lblTelefone.TabIndex = 41;
            this.lblTelefone.Text = "Telefone";
            // 
            // txtTelefone2
            // 
            this.txtTelefone2.Location = new System.Drawing.Point(652, 290);
            this.txtTelefone2.MaxLength = 255;
            this.txtTelefone2.Name = "txtTelefone2";
            this.txtTelefone2.Size = new System.Drawing.Size(110, 20);
            this.txtTelefone2.TabIndex = 14;
            // 
            // lblTelefone2
            // 
            this.lblTelefone2.AutoSize = true;
            this.lblTelefone2.Location = new System.Drawing.Point(649, 274);
            this.lblTelefone2.Name = "lblTelefone2";
            this.lblTelefone2.Size = new System.Drawing.Size(78, 13);
            this.lblTelefone2.TabIndex = 42;
            this.lblTelefone2.Text = "Outro Telefone";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(768, 290);
            this.txtFax.MaxLength = 255;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(110, 20);
            this.txtFax.TabIndex = 15;
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(765, 274);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(24, 13);
            this.lblFax.TabIndex = 43;
            this.lblFax.Text = "Fax";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 417);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 191);
            this.tabControl1.TabIndex = 58;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.grContaBancaria);
            this.tabPage4.Controls.Add(this.toolStrip4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(876, 165);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Contas Bancárias";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // grContaBancaria
            // 
            this.grContaBancaria.AllowUserToAddRows = false;
            this.grContaBancaria.AllowUserToDeleteRows = false;
            this.grContaBancaria.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grContaBancaria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grContaBancaria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.grContaBancaria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grContaBancaria.Location = new System.Drawing.Point(0, 25);
            this.grContaBancaria.Name = "grContaBancaria";
            this.grContaBancaria.ReadOnly = true;
            this.grContaBancaria.RowHeadersVisible = false;
            this.grContaBancaria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grContaBancaria.Size = new System.Drawing.Size(876, 140);
            this.grContaBancaria.TabIndex = 6;
            this.grContaBancaria.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grContaBancaria_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IdEmpresaContaBancaria";
            this.dataGridViewTextBoxColumn1.HeaderText = "Column8";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "IdContaBancaria";
            this.dataGridViewTextBoxColumn2.HeaderText = "Column13";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Banco";
            this.dataGridViewTextBoxColumn3.HeaderText = "Banco";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Agencia";
            this.dataGridViewTextBoxColumn4.HeaderText = "Agência";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Conta";
            this.dataGridViewTextBoxColumn5.HeaderText = "Conta";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // toolStrip4
            // 
            this.toolStrip4.BackgroundImage = global::ERP.Properties.Resources.fundo;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdicionarContaBancaria,
            this.tsbExcluirContaBancaria});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(876, 25);
            this.toolStrip4.TabIndex = 5;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // tsbAdicionarContaBancaria
            // 
            this.tsbAdicionarContaBancaria.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAdicionarContaBancaria.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdicionarContaBancaria.Image")));
            this.tsbAdicionarContaBancaria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdicionarContaBancaria.Name = "tsbAdicionarContaBancaria";
            this.tsbAdicionarContaBancaria.Size = new System.Drawing.Size(62, 22);
            this.tsbAdicionarContaBancaria.Text = "Adicionar";
            this.tsbAdicionarContaBancaria.Click += new System.EventHandler(this.tsbAdicionarContaBancaria_Click);
            // 
            // tsbExcluirContaBancaria
            // 
            this.tsbExcluirContaBancaria.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbExcluirContaBancaria.Image = ((System.Drawing.Image)(resources.GetObject("tsbExcluirContaBancaria.Image")));
            this.tsbExcluirContaBancaria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExcluirContaBancaria.Name = "tsbExcluirContaBancaria";
            this.tsbExcluirContaBancaria.Size = new System.Drawing.Size(45, 22);
            this.tsbExcluirContaBancaria.Text = "Excluir";
            this.tsbExcluirContaBancaria.Click += new System.EventHandler(this.tsbExcluirContaBancaria_Click);
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Location = new System.Drawing.Point(445, 325);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(50, 13);
            this.lblContador.TabIndex = 45;
            this.lblContador.Text = "Contador";
            // 
            // cboContador
            // 
            this.cboContador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboContador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboContador.FormattingEnabled = true;
            this.cboContador.Location = new System.Drawing.Point(448, 341);
            this.cboContador.Name = "cboContador";
            this.cboContador.Size = new System.Drawing.Size(209, 21);
            this.cboContador.TabIndex = 17;
            this.cboContador.Tag = "";
            // 
            // btnProcurarImagem
            // 
            this.btnProcurarImagem.Location = new System.Drawing.Point(15, 135);
            this.btnProcurarImagem.Name = "btnProcurarImagem";
            this.btnProcurarImagem.Size = new System.Drawing.Size(68, 23);
            this.btnProcurarImagem.TabIndex = 0;
            this.btnProcurarImagem.Text = "Procurar";
            this.btnProcurarImagem.UseVisualStyleBackColor = true;
            this.btnProcurarImagem.Click += new System.EventHandler(this.btnProcurarImagem_Click);
            // 
            // btnLimparLogo
            // 
            this.btnLimparLogo.Location = new System.Drawing.Point(87, 135);
            this.btnLimparLogo.Name = "btnLimparLogo";
            this.btnLimparLogo.Size = new System.Drawing.Size(68, 23);
            this.btnLimparLogo.TabIndex = 0;
            this.btnLimparLogo.Text = "Limpar";
            this.btnLimparLogo.UseVisualStyleBackColor = true;
            this.btnLimparLogo.Click += new System.EventHandler(this.btnLimparLogo_Click);
            // 
            // picLogo
            // 
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Location = new System.Drawing.Point(15, 161);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(140, 60);
            this.picLogo.TabIndex = 59;
            this.picLogo.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(660, 325);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 61;
            this.label10.Text = "Moeda";
            // 
            // cboMoeda
            // 
            this.cboMoeda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMoeda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMoeda.FormattingEnabled = true;
            this.cboMoeda.Location = new System.Drawing.Point(663, 341);
            this.cboMoeda.Name = "cboMoeda";
            this.cboMoeda.Size = new System.Drawing.Size(217, 21);
            this.cboMoeda.TabIndex = 60;
            this.cboMoeda.Tag = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(472, 184);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 63;
            this.label11.Text = "Regime Tributário";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // cboRegimeTributario
            // 
            this.cboRegimeTributario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboRegimeTributario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRegimeTributario.FormattingEnabled = true;
            this.cboRegimeTributario.Location = new System.Drawing.Point(475, 200);
            this.cboRegimeTributario.Name = "cboRegimeTributario";
            this.cboRegimeTributario.Size = new System.Drawing.Size(405, 21);
            this.cboRegimeTributario.TabIndex = 62;
            this.cboRegimeTributario.Tag = "1";
            this.cboRegimeTributario.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // frmEmpresaCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(884, 608);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboRegimeTributario);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboMoeda);
            this.Controls.Add(this.btnLimparLogo);
            this.Controls.Add(this.btnProcurarImagem);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.cboContador);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.lblFax);
            this.Controls.Add(this.txtTelefone2);
            this.Controls.Add(this.lblTelefone2);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCEP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCompl);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCidade);
            this.Controls.Add(this.cboUF);
            this.Controls.Add(this.txtInscricao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CNPJ);
            this.Controls.Add(this.txtCNPJ);
            this.Controls.Add(this.txtFantasia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lo);
            this.Controls.Add(this.txtRazao);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmpresaCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmEmpresaCad";
            this.Text = "Cadastro de Empresa";
            this.Load += new System.EventHandler(this.frmEmpresaCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEmpresaCad_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grContaBancaria)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.TextBox txtInscricao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label CNPJ;
        private System.Windows.Forms.MaskedTextBox txtCNPJ;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lo;
        private System.Windows.Forms.TextBox txtRazao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtCEP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCompl;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCidade;
        private System.Windows.Forms.ComboBox cboUF;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.TextBox txtTelefone2;
        private System.Windows.Forms.Label lblTelefone2;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView grContaBancaria;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton tsbAdicionarContaBancaria;
        private System.Windows.Forms.ToolStripButton tsbExcluirContaBancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.ComboBox cboContador;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnProcurarImagem;
        private System.Windows.Forms.Button btnLimparLogo;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton rbbConfiguracao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboMoeda;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboRegimeTributario;
    }
}