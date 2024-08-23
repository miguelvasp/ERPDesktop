namespace ERP
{
    partial class frmMetodoPagamentoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMetodoPagamentoCad));
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
            this.cboGrupoLayoutRetorno = new System.Windows.Forms.ComboBox();
            this.lblGrupoLayoutRetorno = new System.Windows.Forms.Label();
            this.cboGrupoLayoutExportacao = new System.Windows.Forms.ComboBox();
            this.lblGrupoLayoutExpotacao = new System.Windows.Forms.Label();
            this.cboContaTransicao = new System.Windows.Forms.ComboBox();
            this.lblContaTransicao = new System.Windows.Forms.Label();
            this.chkLancamentoCheque = new System.Windows.Forms.CheckBox();
            this.chkLancamentoTransicao = new System.Windows.Forms.CheckBox();
            this.cboTransacaoBancaria = new System.Windows.Forms.ComboBox();
            this.lblTransacaoBancaria = new System.Windows.Forms.Label();
            this.cboFornecedor = new System.Windows.Forms.ComboBox();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboContaContabil = new System.Windows.Forms.ComboBox();
            this.lblContaContabil = new System.Windows.Forms.Label();
            this.cboBanco = new System.Windows.Forms.ComboBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.cboTipoConta = new System.Windows.Forms.ComboBox();
            this.lblTipoConta = new System.Windows.Forms.Label();
            this.cboTipoPagamento = new System.Windows.Forms.ComboBox();
            this.lblTipoPagamento = new System.Windows.Forms.Label();
            this.cboStatusPagamento = new System.Windows.Forms.ComboBox();
            this.lblStatusPagamento = new System.Windows.Forms.Label();
            this.lblCarencia = new System.Windows.Forms.Label();
            this.txtCarencia = new System.Windows.Forms.TextBox();
            this.cboPeriodo = new System.Windows.Forms.ComboBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgEspecificacao = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEspecificacao)).BeginInit();
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
            this.ribbon1.Size = new System.Drawing.Size(784, 125);
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 125);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 440);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cboGrupoLayoutRetorno);
            this.tabPage1.Controls.Add(this.lblGrupoLayoutRetorno);
            this.tabPage1.Controls.Add(this.cboGrupoLayoutExportacao);
            this.tabPage1.Controls.Add(this.lblGrupoLayoutExpotacao);
            this.tabPage1.Controls.Add(this.cboContaTransicao);
            this.tabPage1.Controls.Add(this.lblContaTransicao);
            this.tabPage1.Controls.Add(this.chkLancamentoCheque);
            this.tabPage1.Controls.Add(this.chkLancamentoTransicao);
            this.tabPage1.Controls.Add(this.cboTransacaoBancaria);
            this.tabPage1.Controls.Add(this.lblTransacaoBancaria);
            this.tabPage1.Controls.Add(this.cboFornecedor);
            this.tabPage1.Controls.Add(this.lblFornecedor);
            this.tabPage1.Controls.Add(this.cboCliente);
            this.tabPage1.Controls.Add(this.lblCliente);
            this.tabPage1.Controls.Add(this.cboContaContabil);
            this.tabPage1.Controls.Add(this.lblContaContabil);
            this.tabPage1.Controls.Add(this.cboBanco);
            this.tabPage1.Controls.Add(this.lblBanco);
            this.tabPage1.Controls.Add(this.cboTipoConta);
            this.tabPage1.Controls.Add(this.lblTipoConta);
            this.tabPage1.Controls.Add(this.cboTipoPagamento);
            this.tabPage1.Controls.Add(this.lblTipoPagamento);
            this.tabPage1.Controls.Add(this.cboStatusPagamento);
            this.tabPage1.Controls.Add(this.lblStatusPagamento);
            this.tabPage1.Controls.Add(this.lblCarencia);
            this.tabPage1.Controls.Add(this.txtCarencia);
            this.tabPage1.Controls.Add(this.cboPeriodo);
            this.tabPage1.Controls.Add(this.lblPeriodo);
            this.tabPage1.Controls.Add(this.txtNome);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lbCodigo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 414);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Metodo de Pagamento";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cboGrupoLayoutRetorno
            // 
            this.cboGrupoLayoutRetorno.FormattingEnabled = true;
            this.cboGrupoLayoutRetorno.Location = new System.Drawing.Point(420, 326);
            this.cboGrupoLayoutRetorno.Name = "cboGrupoLayoutRetorno";
            this.cboGrupoLayoutRetorno.Size = new System.Drawing.Size(170, 21);
            this.cboGrupoLayoutRetorno.TabIndex = 111;
            this.cboGrupoLayoutRetorno.Tag = "";
            // 
            // lblGrupoLayoutRetorno
            // 
            this.lblGrupoLayoutRetorno.AutoSize = true;
            this.lblGrupoLayoutRetorno.Location = new System.Drawing.Point(417, 311);
            this.lblGrupoLayoutRetorno.Name = "lblGrupoLayoutRetorno";
            this.lblGrupoLayoutRetorno.Size = new System.Drawing.Size(127, 13);
            this.lblGrupoLayoutRetorno.TabIndex = 110;
            this.lblGrupoLayoutRetorno.Text = "Grupo de Layout Retorno";
            // 
            // cboGrupoLayoutExportacao
            // 
            this.cboGrupoLayoutExportacao.FormattingEnabled = true;
            this.cboGrupoLayoutExportacao.Location = new System.Drawing.Point(225, 326);
            this.cboGrupoLayoutExportacao.Name = "cboGrupoLayoutExportacao";
            this.cboGrupoLayoutExportacao.Size = new System.Drawing.Size(170, 21);
            this.cboGrupoLayoutExportacao.TabIndex = 109;
            this.cboGrupoLayoutExportacao.Tag = "";
            // 
            // lblGrupoLayoutExpotacao
            // 
            this.lblGrupoLayoutExpotacao.AutoSize = true;
            this.lblGrupoLayoutExpotacao.Location = new System.Drawing.Point(222, 311);
            this.lblGrupoLayoutExpotacao.Name = "lblGrupoLayoutExpotacao";
            this.lblGrupoLayoutExpotacao.Size = new System.Drawing.Size(140, 13);
            this.lblGrupoLayoutExpotacao.TabIndex = 108;
            this.lblGrupoLayoutExpotacao.Text = "Grupo de Layout Expotação";
            // 
            // cboContaTransicao
            // 
            this.cboContaTransicao.FormattingEnabled = true;
            this.cboContaTransicao.Location = new System.Drawing.Point(30, 326);
            this.cboContaTransicao.Name = "cboContaTransicao";
            this.cboContaTransicao.Size = new System.Drawing.Size(170, 21);
            this.cboContaTransicao.TabIndex = 107;
            this.cboContaTransicao.Tag = "";
            // 
            // lblContaTransicao
            // 
            this.lblContaTransicao.AutoSize = true;
            this.lblContaTransicao.Location = new System.Drawing.Point(27, 311);
            this.lblContaTransicao.Name = "lblContaTransicao";
            this.lblContaTransicao.Size = new System.Drawing.Size(100, 13);
            this.lblContaTransicao.TabIndex = 106;
            this.lblContaTransicao.Text = "Conta de Transição";
            // 
            // chkLancamentoCheque
            // 
            this.chkLancamentoCheque.AutoSize = true;
            this.chkLancamentoCheque.Location = new System.Drawing.Point(420, 276);
            this.chkLancamentoCheque.Name = "chkLancamentoCheque";
            this.chkLancamentoCheque.Size = new System.Drawing.Size(220, 17);
            this.chkLancamentoCheque.TabIndex = 105;
            this.chkLancamentoCheque.Text = "Lançamento de Compesação de Cheque";
            this.chkLancamentoCheque.UseVisualStyleBackColor = true;
            // 
            // chkLancamentoTransicao
            // 
            this.chkLancamentoTransicao.AutoSize = true;
            this.chkLancamentoTransicao.Location = new System.Drawing.Point(225, 278);
            this.chkLancamentoTransicao.Name = "chkLancamentoTransicao";
            this.chkLancamentoTransicao.Size = new System.Drawing.Size(150, 17);
            this.chkLancamentoTransicao.TabIndex = 104;
            this.chkLancamentoTransicao.Text = "Lançamento de Transição";
            this.chkLancamentoTransicao.UseVisualStyleBackColor = true;
            // 
            // cboTransacaoBancaria
            // 
            this.cboTransacaoBancaria.FormattingEnabled = true;
            this.cboTransacaoBancaria.Location = new System.Drawing.Point(30, 276);
            this.cboTransacaoBancaria.Name = "cboTransacaoBancaria";
            this.cboTransacaoBancaria.Size = new System.Drawing.Size(170, 21);
            this.cboTransacaoBancaria.TabIndex = 103;
            this.cboTransacaoBancaria.Tag = "";
            // 
            // lblTransacaoBancaria
            // 
            this.lblTransacaoBancaria.AutoSize = true;
            this.lblTransacaoBancaria.Location = new System.Drawing.Point(27, 261);
            this.lblTransacaoBancaria.Name = "lblTransacaoBancaria";
            this.lblTransacaoBancaria.Size = new System.Drawing.Size(103, 13);
            this.lblTransacaoBancaria.TabIndex = 102;
            this.lblTransacaoBancaria.Text = "Transação Bancária";
            // 
            // cboFornecedor
            // 
            this.cboFornecedor.DropDownWidth = 255;
            this.cboFornecedor.FormattingEnabled = true;
            this.cboFornecedor.Location = new System.Drawing.Point(225, 226);
            this.cboFornecedor.Name = "cboFornecedor";
            this.cboFornecedor.Size = new System.Drawing.Size(170, 21);
            this.cboFornecedor.TabIndex = 101;
            this.cboFornecedor.Tag = "";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(222, 211);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(61, 13);
            this.lblFornecedor.TabIndex = 100;
            this.lblFornecedor.Text = "Fornecedor";
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownWidth = 255;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(30, 226);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(170, 21);
            this.cboCliente.TabIndex = 99;
            this.cboCliente.Tag = "";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(27, 211);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 98;
            this.lblCliente.Text = "Cliente";
            // 
            // cboContaContabil
            // 
            this.cboContaContabil.FormattingEnabled = true;
            this.cboContaContabil.Location = new System.Drawing.Point(420, 176);
            this.cboContaContabil.Name = "cboContaContabil";
            this.cboContaContabil.Size = new System.Drawing.Size(170, 21);
            this.cboContaContabil.TabIndex = 97;
            this.cboContaContabil.Tag = "1";
            // 
            // lblContaContabil
            // 
            this.lblContaContabil.AutoSize = true;
            this.lblContaContabil.Location = new System.Drawing.Point(417, 161);
            this.lblContaContabil.Name = "lblContaContabil";
            this.lblContaContabil.Size = new System.Drawing.Size(76, 13);
            this.lblContaContabil.TabIndex = 96;
            this.lblContaContabil.Text = "Conta Contábil";
            // 
            // cboBanco
            // 
            this.cboBanco.FormattingEnabled = true;
            this.cboBanco.Location = new System.Drawing.Point(225, 176);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Size = new System.Drawing.Size(170, 21);
            this.cboBanco.TabIndex = 95;
            this.cboBanco.Tag = "1";
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Location = new System.Drawing.Point(222, 161);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(38, 13);
            this.lblBanco.TabIndex = 94;
            this.lblBanco.Text = "Banco";
            // 
            // cboTipoConta
            // 
            this.cboTipoConta.FormattingEnabled = true;
            this.cboTipoConta.Location = new System.Drawing.Point(30, 176);
            this.cboTipoConta.Name = "cboTipoConta";
            this.cboTipoConta.Size = new System.Drawing.Size(170, 21);
            this.cboTipoConta.TabIndex = 93;
            this.cboTipoConta.Tag = "1";
            // 
            // lblTipoConta
            // 
            this.lblTipoConta.AutoSize = true;
            this.lblTipoConta.Location = new System.Drawing.Point(27, 161);
            this.lblTipoConta.Name = "lblTipoConta";
            this.lblTipoConta.Size = new System.Drawing.Size(74, 13);
            this.lblTipoConta.TabIndex = 92;
            this.lblTipoConta.Text = "Tipo de Conta";
            // 
            // cboTipoPagamento
            // 
            this.cboTipoPagamento.FormattingEnabled = true;
            this.cboTipoPagamento.Location = new System.Drawing.Point(225, 128);
            this.cboTipoPagamento.Name = "cboTipoPagamento";
            this.cboTipoPagamento.Size = new System.Drawing.Size(170, 21);
            this.cboTipoPagamento.TabIndex = 91;
            this.cboTipoPagamento.Tag = "1";
            // 
            // lblTipoPagamento
            // 
            this.lblTipoPagamento.AutoSize = true;
            this.lblTipoPagamento.Location = new System.Drawing.Point(222, 113);
            this.lblTipoPagamento.Name = "lblTipoPagamento";
            this.lblTipoPagamento.Size = new System.Drawing.Size(100, 13);
            this.lblTipoPagamento.TabIndex = 90;
            this.lblTipoPagamento.Text = "Tipo de Pagamento";
            // 
            // cboStatusPagamento
            // 
            this.cboStatusPagamento.FormattingEnabled = true;
            this.cboStatusPagamento.Location = new System.Drawing.Point(30, 128);
            this.cboStatusPagamento.Name = "cboStatusPagamento";
            this.cboStatusPagamento.Size = new System.Drawing.Size(170, 21);
            this.cboStatusPagamento.TabIndex = 89;
            this.cboStatusPagamento.Tag = "1";
            // 
            // lblStatusPagamento
            // 
            this.lblStatusPagamento.AutoSize = true;
            this.lblStatusPagamento.Location = new System.Drawing.Point(27, 113);
            this.lblStatusPagamento.Name = "lblStatusPagamento";
            this.lblStatusPagamento.Size = new System.Drawing.Size(109, 13);
            this.lblStatusPagamento.TabIndex = 88;
            this.lblStatusPagamento.Text = "Status do Pagamento";
            // 
            // lblCarencia
            // 
            this.lblCarencia.AutoSize = true;
            this.lblCarencia.Location = new System.Drawing.Point(222, 64);
            this.lblCarencia.Name = "lblCarencia";
            this.lblCarencia.Size = new System.Drawing.Size(49, 13);
            this.lblCarencia.TabIndex = 86;
            this.lblCarencia.Text = "Carência";
            // 
            // txtCarencia
            // 
            this.txtCarencia.Location = new System.Drawing.Point(225, 81);
            this.txtCarencia.MaxLength = 4;
            this.txtCarencia.Name = "txtCarencia";
            this.txtCarencia.Size = new System.Drawing.Size(170, 20);
            this.txtCarencia.TabIndex = 87;
            this.txtCarencia.Tag = "4";
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.FormattingEnabled = true;
            this.cboPeriodo.Location = new System.Drawing.Point(30, 79);
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Size = new System.Drawing.Size(170, 21);
            this.cboPeriodo.TabIndex = 85;
            this.cboPeriodo.Tag = "1";
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(27, 64);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(45, 13);
            this.lblPeriodo.TabIndex = 84;
            this.lblPeriodo.Text = "Período";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(30, 42);
            this.txtNome.MaxLength = 200;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(365, 20);
            this.txtNome.TabIndex = 83;
            this.txtNome.Tag = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "Nome";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(382, 4);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 81;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgEspecificacao);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 414);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Especificações";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgEspecificacao
            // 
            this.dgEspecificacao.AllowUserToAddRows = false;
            this.dgEspecificacao.AllowUserToDeleteRows = false;
            this.dgEspecificacao.BackgroundColor = System.Drawing.Color.White;
            this.dgEspecificacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEspecificacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgEspecificacao.Location = new System.Drawing.Point(18, 60);
            this.dgEspecificacao.Name = "dgEspecificacao";
            this.dgEspecificacao.ReadOnly = true;
            this.dgEspecificacao.RowHeadersVisible = false;
            this.dgEspecificacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEspecificacao.Size = new System.Drawing.Size(737, 332);
            this.dgEspecificacao.TabIndex = 1;
            this.dgEspecificacao.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEspecificacao_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IdEspecificacaoPagamento";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Nome";
            this.Column2.HeaderText = "Nome";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ControleExportacao";
            this.Column3.HeaderText = "Controle Exportação";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TipoPagamento";
            this.Column4.HeaderText = "Tipo de Pgto.";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "FormaPagamento";
            this.Column5.HeaderText = "Forma de Pgto.";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Segmento";
            this.Column6.HeaderText = "Segmento";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Adicionar Especificação";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMetodoPagamentoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 565);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMetodoPagamentoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "frmMetodoPagamentoCad";
            this.Text = "Cadastro Método de Pagamentos";
            this.Load += new System.EventHandler(this.frmMetodoPagamentoCad_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEspecificacao)).EndInit();
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
        private System.Windows.Forms.ComboBox cboGrupoLayoutRetorno;
        private System.Windows.Forms.Label lblGrupoLayoutRetorno;
        private System.Windows.Forms.ComboBox cboGrupoLayoutExportacao;
        private System.Windows.Forms.Label lblGrupoLayoutExpotacao;
        private System.Windows.Forms.ComboBox cboContaTransicao;
        private System.Windows.Forms.Label lblContaTransicao;
        private System.Windows.Forms.CheckBox chkLancamentoCheque;
        private System.Windows.Forms.CheckBox chkLancamentoTransicao;
        private System.Windows.Forms.ComboBox cboTransacaoBancaria;
        private System.Windows.Forms.Label lblTransacaoBancaria;
        private System.Windows.Forms.ComboBox cboFornecedor;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboContaContabil;
        private System.Windows.Forms.Label lblContaContabil;
        private System.Windows.Forms.ComboBox cboBanco;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.ComboBox cboTipoConta;
        private System.Windows.Forms.Label lblTipoConta;
        private System.Windows.Forms.ComboBox cboTipoPagamento;
        private System.Windows.Forms.Label lblTipoPagamento;
        private System.Windows.Forms.ComboBox cboStatusPagamento;
        private System.Windows.Forms.Label lblStatusPagamento;
        private System.Windows.Forms.Label lblCarencia;
        private System.Windows.Forms.TextBox txtCarencia;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgEspecificacao;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}