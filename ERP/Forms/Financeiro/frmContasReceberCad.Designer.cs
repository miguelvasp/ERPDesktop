namespace ERP
{
    partial class frmContasReceberCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContasReceberCad));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label24 = new System.Windows.Forms.Label();
            this.txtOBS = new System.Windows.Forms.TextBox();
            this.chkCalculaRetencao = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cboTipoTransacao = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cboPerfilCliente = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cboEspecificacaoPagamento = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cboMetodoPagamento = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboMoeda = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtVencimentoOriginal = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtVencimento = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboContaContabil = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEmissao = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDataDocumento = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtValorLiquido = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAcrescimo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValorTitulo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdContasPagar = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCondicaoPagamento = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 125);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 486);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cboCondicaoPagamento);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.txtOBS);
            this.tabPage1.Controls.Add(this.chkCalculaRetencao);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.cboTipoTransacao);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.cboPerfilCliente);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.cboEspecificacaoPagamento);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.cboMetodoPagamento);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.cboStatus);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.cboMoeda);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.txtVencimentoOriginal);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.txtVencimento);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.cboContaContabil);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.txtEmissao);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.txtDataDocumento);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtSaldo);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtValorPago);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtValorLiquido);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtAcrescimo);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtDesconto);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtValorTitulo);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cboCliente);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtDocumento);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtIdContasPagar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(876, 460);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Principal";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(11, 335);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 13);
            this.label24.TabIndex = 48;
            this.label24.Text = "Observação";
            // 
            // txtOBS
            // 
            this.txtOBS.Location = new System.Drawing.Point(14, 351);
            this.txtOBS.Multiline = true;
            this.txtOBS.Name = "txtOBS";
            this.txtOBS.Size = new System.Drawing.Size(842, 90);
            this.txtOBS.TabIndex = 24;
            // 
            // chkCalculaRetencao
            // 
            this.chkCalculaRetencao.AutoSize = true;
            this.chkCalculaRetencao.Location = new System.Drawing.Point(562, 292);
            this.chkCalculaRetencao.Name = "chkCalculaRetencao";
            this.chkCalculaRetencao.Size = new System.Drawing.Size(111, 17);
            this.chkCalculaRetencao.TabIndex = 23;
            this.chkCalculaRetencao.Text = "Calcula Retenção";
            this.chkCalculaRetencao.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 273);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(97, 13);
            this.label21.TabIndex = 41;
            this.label21.Text = "Tipo de Transação";
            // 
            // cboTipoTransacao
            // 
            this.cboTipoTransacao.FormattingEnabled = true;
            this.cboTipoTransacao.Location = new System.Drawing.Point(14, 289);
            this.cboTipoTransacao.Name = "cboTipoTransacao";
            this.cboTipoTransacao.Size = new System.Drawing.Size(206, 21);
            this.cboTipoTransacao.TabIndex = 20;
            this.cboTipoTransacao.Tag = "1";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(559, 208);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 13);
            this.label20.TabIndex = 39;
            this.label20.Text = "Perfil Cliente";
            // 
            // cboPerfilCliente
            // 
            this.cboPerfilCliente.FormattingEnabled = true;
            this.cboPerfilCliente.Location = new System.Drawing.Point(562, 224);
            this.cboPerfilCliente.Name = "cboPerfilCliente";
            this.cboPerfilCliente.Size = new System.Drawing.Size(294, 21);
            this.cboPerfilCliente.TabIndex = 19;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(285, 208);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(146, 13);
            this.label19.TabIndex = 37;
            this.label19.Text = "Especificação de Pagamento";
            // 
            // cboEspecificacaoPagamento
            // 
            this.cboEspecificacaoPagamento.FormattingEnabled = true;
            this.cboEspecificacaoPagamento.Location = new System.Drawing.Point(288, 224);
            this.cboEspecificacaoPagamento.Name = "cboEspecificacaoPagamento";
            this.cboEspecificacaoPagamento.Size = new System.Drawing.Size(268, 21);
            this.cboEspecificacaoPagamento.TabIndex = 18;
            this.cboEspecificacaoPagamento.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 208);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(115, 13);
            this.label18.TabIndex = 35;
            this.label18.Text = "Metodo de Pagamento";
            // 
            // cboMetodoPagamento
            // 
            this.cboMetodoPagamento.FormattingEnabled = true;
            this.cboMetodoPagamento.Location = new System.Drawing.Point(14, 224);
            this.cboMetodoPagamento.Name = "cboMetodoPagamento";
            this.cboMetodoPagamento.Size = new System.Drawing.Size(268, 21);
            this.cboMetodoPagamento.TabIndex = 17;
            this.cboMetodoPagamento.Tag = "1";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(713, 77);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "Status";
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(716, 93);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(140, 21);
            this.cboStatus.TabIndex = 10;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(568, 77);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Moeda";
            // 
            // cboMoeda
            // 
            this.cboMoeda.FormattingEnabled = true;
            this.cboMoeda.Location = new System.Drawing.Point(571, 93);
            this.cboMoeda.Name = "cboMoeda";
            this.cboMoeda.Size = new System.Drawing.Size(140, 21);
            this.cboMoeda.TabIndex = 9;
            this.cboMoeda.Tag = "1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(462, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Vencimento Original";
            // 
            // txtVencimentoOriginal
            // 
            this.txtVencimentoOriginal.Location = new System.Drawing.Point(465, 93);
            this.txtVencimentoOriginal.Mask = "99/99/9999";
            this.txtVencimentoOriginal.Name = "txtVencimentoOriginal";
            this.txtVencimentoOriginal.Size = new System.Drawing.Size(100, 20);
            this.txtVencimentoOriginal.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(378, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Vencimento";
            // 
            // txtVencimento
            // 
            this.txtVencimento.Location = new System.Drawing.Point(381, 93);
            this.txtVencimento.Mask = "99/99/9999";
            this.txtVencimento.Name = "txtVencimento";
            this.txtVencimento.Size = new System.Drawing.Size(78, 20);
            this.txtVencimento.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(100, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Conta Contábil";
            // 
            // cboContaContabil
            // 
            this.cboContaContabil.FormattingEnabled = true;
            this.cboContaContabil.Location = new System.Drawing.Point(103, 92);
            this.cboContaContabil.Name = "cboContaContabil";
            this.cboContaContabil.Size = new System.Drawing.Size(272, 21);
            this.cboContaContabil.TabIndex = 6;
            this.cboContaContabil.Tag = "1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Emissão";
            // 
            // txtEmissao
            // 
            this.txtEmissao.Location = new System.Drawing.Point(14, 92);
            this.txtEmissao.Mask = "99/99/9999";
            this.txtEmissao.Name = "txtEmissao";
            this.txtEmissao.Size = new System.Drawing.Size(83, 20);
            this.txtEmissao.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(768, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Data Documento";
            // 
            // txtDataDocumento
            // 
            this.txtDataDocumento.Location = new System.Drawing.Point(771, 35);
            this.txtDataDocumento.Mask = "99/99/9999";
            this.txtDataDocumento.Name = "txtDataDocumento";
            this.txtDataDocumento.Size = new System.Drawing.Size(85, 20);
            this.txtDataDocumento.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(707, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Valor à Pagar";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Enabled = false;
            this.txtSaldo.Location = new System.Drawing.Point(710, 158);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(146, 20);
            this.txtSaldo.TabIndex = 16;
            this.txtSaldo.Text = "0,0000";
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(559, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Valor Pago";
            // 
            // txtValorPago
            // 
            this.txtValorPago.Enabled = false;
            this.txtValorPago.Location = new System.Drawing.Point(562, 158);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.ReadOnly = true;
            this.txtValorPago.Size = new System.Drawing.Size(142, 20);
            this.txtValorPago.TabIndex = 15;
            this.txtValorPago.Text = "0,0000";
            this.txtValorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(402, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Valor Líquido";
            // 
            // txtValorLiquido
            // 
            this.txtValorLiquido.Enabled = false;
            this.txtValorLiquido.Location = new System.Drawing.Point(405, 158);
            this.txtValorLiquido.Name = "txtValorLiquido";
            this.txtValorLiquido.ReadOnly = true;
            this.txtValorLiquido.Size = new System.Drawing.Size(151, 20);
            this.txtValorLiquido.TabIndex = 14;
            this.txtValorLiquido.Text = "0,0000";
            this.txtValorLiquido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(285, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Acrescimo";
            // 
            // txtAcrescimo
            // 
            this.txtAcrescimo.Location = new System.Drawing.Point(288, 158);
            this.txtAcrescimo.Name = "txtAcrescimo";
            this.txtAcrescimo.Size = new System.Drawing.Size(111, 20);
            this.txtAcrescimo.TabIndex = 13;
            this.txtAcrescimo.Text = "0,0000";
            this.txtAcrescimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAcrescimo.Leave += new System.EventHandler(this.txtAcrescimo_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Desconto";
            // 
            // txtDesconto
            // 
            this.txtDesconto.Location = new System.Drawing.Point(170, 158);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(112, 20);
            this.txtDesconto.TabIndex = 12;
            this.txtDesconto.Text = "0,0000";
            this.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDesconto.Leave += new System.EventHandler(this.txtDesconto_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Valor do Título";
            // 
            // txtValorTitulo
            // 
            this.txtValorTitulo.Location = new System.Drawing.Point(14, 158);
            this.txtValorTitulo.Name = "txtValorTitulo";
            this.txtValorTitulo.Size = new System.Drawing.Size(150, 20);
            this.txtValorTitulo.TabIndex = 11;
            this.txtValorTitulo.Tag = "3";
            this.txtValorTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorTitulo.Leave += new System.EventHandler(this.txtValorTitulo_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cliente";
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(127, 34);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(392, 21);
            this.cboCliente.TabIndex = 2;
            this.cboCliente.Tag = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(522, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Documento";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(525, 35);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(240, 20);
            this.txtDocumento.TabIndex = 3;
            this.txtDocumento.Tag = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cod. Recebimento";
            // 
            // txtIdContasPagar
            // 
            this.txtIdContasPagar.Location = new System.Drawing.Point(14, 35);
            this.txtIdContasPagar.Name = "txtIdContasPagar";
            this.txtIdContasPagar.Size = new System.Drawing.Size(107, 20);
            this.txtIdContasPagar.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(876, 460);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vencimentos Em Aberto";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(8, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(860, 383);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.HeaderText = "Column1";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Vencimento";
            this.Column1.HeaderText = "Vencimento";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "NumeroParcela";
            this.Column2.HeaderText = "Número da Parcela";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ValorLiquido";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "Valor Liquido";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ValorPago";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "Valor Pago";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 27);
            this.button1.TabIndex = 19;
            this.button1.Text = "Adicionar Vencimento";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(876, 460);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Centros de Custo";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Condição de Pagamento";
            // 
            // cboCondicaoPagamento
            // 
            this.cboCondicaoPagamento.FormattingEnabled = true;
            this.cboCondicaoPagamento.Location = new System.Drawing.Point(226, 289);
            this.cboCondicaoPagamento.Name = "cboCondicaoPagamento";
            this.cboCondicaoPagamento.Size = new System.Drawing.Size(206, 21);
            this.cboCondicaoPagamento.TabIndex = 49;
            this.cboCondicaoPagamento.Tag = "1";
            // 
            // frmContasReceberCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 505);
            this.Name = "frmContasReceberCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmCalendarioCad";
            this.Text = "Contas a Receber";
            this.Load += new System.EventHandler(this.frmAutoridadeCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAutoridadeCad_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox txtDataDocumento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtValorPago;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtValorLiquido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAcrescimo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValorTitulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdContasPagar;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboMoeda;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox txtVencimentoOriginal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox txtVencimento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboContaContabil;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtEmissao;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboEspecificacaoPagamento;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboMetodoPagamento;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboPerfilCliente;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboTipoTransacao;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtOBS;
        private System.Windows.Forms.CheckBox chkCalculaRetencao;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCondicaoPagamento;
    }
}