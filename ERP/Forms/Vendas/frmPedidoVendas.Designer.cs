namespace ERP
{
    partial class frmPedidoVendas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPedidoVendas));
            this.cboProduto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataFim = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataInicio = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.IdPedidoCompras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPesquisa = new System.Windows.Forms.Panel();
            this.txtCNPJ = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblStatusAprovacao = new System.Windows.Forms.Label();
            this.cboStatusAprovacao = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblTeleVendas = new System.Windows.Forms.Label();
            this.cboTeleVendas = new System.Windows.Forms.ComboBox();
            this.cboVendedor = new System.Windows.Forms.ComboBox();
            this.lblTipoOrdem = new System.Windows.Forms.Label();
            this.cboTipoOrdem = new System.Windows.Forms.ComboBox();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblVarianteConfig = new System.Windows.Forms.Label();
            this.cboVariantesConfig = new System.Windows.Forms.ComboBox();
            this.txtDataEntregaAte = new System.Windows.Forms.MaskedTextBox();
            this.lblDataEntregaAte = new System.Windows.Forms.Label();
            this.txtDataEntregaDe = new System.Windows.Forms.MaskedTextBox();
            this.lblDataEntregaDe = new System.Windows.Forms.Label();
            this.txtNumPedido = new System.Windows.Forms.TextBox();
            this.lblNumPedido = new System.Windows.Forms.Label();
            this.lblGrupoClientes = new System.Windows.Forms.Label();
            this.cboGrupoCliente = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboLocalizacao = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboDeposito = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboArmazem = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTamanho = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboEstilo = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNovo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPesquisa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.planilhaExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arquivoSeparadoPorVírgulacsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRelatorio = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlPesquisa.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboProduto
            // 
            this.cboProduto.AllowDrop = true;
            this.cboProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProduto.FormattingEnabled = true;
            this.cboProduto.Location = new System.Drawing.Point(676, 126);
            this.cboProduto.Name = "cboProduto";
            this.cboProduto.Size = new System.Drawing.Size(215, 21);
            this.cboProduto.TabIndex = 13;
            this.cboProduto.TextChanged += new System.EventHandler(this.cboProduto_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(673, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Produto";
            // 
            // cboCliente
            // 
            this.cboCliente.AllowDrop = true;
            this.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(571, 22);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(320, 21);
            this.cboCliente.TabIndex = 5;
            this.cboCliente.TextChanged += new System.EventHandler(this.cboCliente_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(568, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Cliente";
            // 
            // txtDataFim
            // 
            this.txtDataFim.Location = new System.Drawing.Point(122, 22);
            this.txtDataFim.Mask = "99/99/9999";
            this.txtDataFim.Name = "txtDataFim";
            this.txtDataFim.Size = new System.Drawing.Size(100, 20);
            this.txtDataFim.TabIndex = 1;
            this.txtDataFim.TextChanged += new System.EventHandler(this.txtDataFim_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Até";
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.Location = new System.Drawing.Point(16, 23);
            this.txtDataInicio.Mask = "99/99/9999";
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(100, 20);
            this.txtDataInicio.TabIndex = 0;
            this.txtDataInicio.TextChanged += new System.EventHandler(this.txtDataInicio_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Data de";
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Location = new System.Drawing.Point(587, 224);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(112, 23);
            this.btnPesquisa.TabIndex = 20;
            this.btnPesquisa.Text = "&Pesquisar";
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPedidoCompras,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Valor,
            this.Desconto,
            this.Total});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 287);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 18;
            this.dgv.Size = new System.Drawing.Size(941, 274);
            this.dgv.TabIndex = 19;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // IdPedidoCompras
            // 
            this.IdPedidoCompras.DataPropertyName = "IdPedidoVendas";
            this.IdPedidoCompras.HeaderText = "IdPedidoVendas";
            this.IdPedidoCompras.Name = "IdPedidoCompras";
            this.IdPedidoCompras.ReadOnly = true;
            this.IdPedidoCompras.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PedidoNumero";
            this.Column1.HeaderText = "N° Pedido";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Data";
            this.Column2.HeaderText = "Data";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NomeFantasia";
            this.Column3.HeaderText = "Cliente";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DataEntrega";
            this.Column4.HeaderText = "Data de Entrega";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "StatusAprovacao";
            this.Column5.HeaderText = "Status Aprovação";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Status";
            this.Column6.HeaderText = "Status";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N4";
            dataGridViewCellStyle1.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle1;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // Desconto
            // 
            this.Desconto.DataPropertyName = "Desconto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.Desconto.DefaultCellStyle = dataGridViewCellStyle2;
            this.Desconto.HeaderText = "Desconto";
            this.Desconto.Name = "Desconto";
            this.Desconto.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle3;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // pnlPesquisa
            // 
            this.pnlPesquisa.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPesquisa.Controls.Add(this.txtCNPJ);
            this.pnlPesquisa.Controls.Add(this.label8);
            this.pnlPesquisa.Controls.Add(this.lblStatusAprovacao);
            this.pnlPesquisa.Controls.Add(this.cboStatusAprovacao);
            this.pnlPesquisa.Controls.Add(this.lblStatus);
            this.pnlPesquisa.Controls.Add(this.cboStatus);
            this.pnlPesquisa.Controls.Add(this.lblTeleVendas);
            this.pnlPesquisa.Controls.Add(this.cboTeleVendas);
            this.pnlPesquisa.Controls.Add(this.cboVendedor);
            this.pnlPesquisa.Controls.Add(this.lblTipoOrdem);
            this.pnlPesquisa.Controls.Add(this.cboTipoOrdem);
            this.pnlPesquisa.Controls.Add(this.lblVendedor);
            this.pnlPesquisa.Controls.Add(this.lblVarianteConfig);
            this.pnlPesquisa.Controls.Add(this.cboVariantesConfig);
            this.pnlPesquisa.Controls.Add(this.txtDataEntregaAte);
            this.pnlPesquisa.Controls.Add(this.lblDataEntregaAte);
            this.pnlPesquisa.Controls.Add(this.txtDataEntregaDe);
            this.pnlPesquisa.Controls.Add(this.lblDataEntregaDe);
            this.pnlPesquisa.Controls.Add(this.txtNumPedido);
            this.pnlPesquisa.Controls.Add(this.lblNumPedido);
            this.pnlPesquisa.Controls.Add(this.lblGrupoClientes);
            this.pnlPesquisa.Controls.Add(this.cboGrupoCliente);
            this.pnlPesquisa.Controls.Add(this.label12);
            this.pnlPesquisa.Controls.Add(this.cboLocalizacao);
            this.pnlPesquisa.Controls.Add(this.label11);
            this.pnlPesquisa.Controls.Add(this.cboDeposito);
            this.pnlPesquisa.Controls.Add(this.label10);
            this.pnlPesquisa.Controls.Add(this.cboArmazem);
            this.pnlPesquisa.Controls.Add(this.label7);
            this.pnlPesquisa.Controls.Add(this.cboTamanho);
            this.pnlPesquisa.Controls.Add(this.label6);
            this.pnlPesquisa.Controls.Add(this.cboCor);
            this.pnlPesquisa.Controls.Add(this.label5);
            this.pnlPesquisa.Controls.Add(this.cboEstilo);
            this.pnlPesquisa.Controls.Add(this.cboProduto);
            this.pnlPesquisa.Controls.Add(this.label4);
            this.pnlPesquisa.Controls.Add(this.cboCliente);
            this.pnlPesquisa.Controls.Add(this.label3);
            this.pnlPesquisa.Controls.Add(this.txtDataFim);
            this.pnlPesquisa.Controls.Add(this.label2);
            this.pnlPesquisa.Controls.Add(this.txtDataInicio);
            this.pnlPesquisa.Controls.Add(this.label1);
            this.pnlPesquisa.Controls.Add(this.btnPesquisa);
            this.pnlPesquisa.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPesquisa.Location = new System.Drawing.Point(0, 31);
            this.pnlPesquisa.Name = "pnlPesquisa";
            this.pnlPesquisa.Size = new System.Drawing.Size(941, 256);
            this.pnlPesquisa.TabIndex = 18;
            this.pnlPesquisa.Visible = false;
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.Location = new System.Drawing.Point(440, 23);
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(125, 20);
            this.txtCNPJ.TabIndex = 4;
            this.txtCNPJ.Tag = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(443, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 51;
            this.label8.Text = "CNPJ";
            // 
            // lblStatusAprovacao
            // 
            this.lblStatusAprovacao.AutoSize = true;
            this.lblStatusAprovacao.Location = new System.Drawing.Point(236, 210);
            this.lblStatusAprovacao.Name = "lblStatusAprovacao";
            this.lblStatusAprovacao.Size = new System.Drawing.Size(92, 13);
            this.lblStatusAprovacao.TabIndex = 49;
            this.lblStatusAprovacao.Text = "Status Aprovação";
            // 
            // cboStatusAprovacao
            // 
            this.cboStatusAprovacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboStatusAprovacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStatusAprovacao.FormattingEnabled = true;
            this.cboStatusAprovacao.Location = new System.Drawing.Point(235, 226);
            this.cboStatusAprovacao.Name = "cboStatusAprovacao";
            this.cboStatusAprovacao.Size = new System.Drawing.Size(215, 21);
            this.cboStatusAprovacao.TabIndex = 19;
            this.cboStatusAprovacao.Tag = "";
            this.cboStatusAprovacao.TextChanged += new System.EventHandler(this.cboStatusAprovacao_TextChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(17, 210);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 48;
            this.lblStatus.Text = "Status";
            // 
            // cboStatus
            // 
            this.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(16, 226);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(215, 21);
            this.cboStatus.TabIndex = 18;
            this.cboStatus.Tag = "";
            this.cboStatus.TextChanged += new System.EventHandler(this.cboStatus_TextChanged);
            // 
            // lblTeleVendas
            // 
            this.lblTeleVendas.AutoSize = true;
            this.lblTeleVendas.Location = new System.Drawing.Point(232, 110);
            this.lblTeleVendas.Name = "lblTeleVendas";
            this.lblTeleVendas.Size = new System.Drawing.Size(63, 13);
            this.lblTeleVendas.TabIndex = 41;
            this.lblTeleVendas.Text = "Televendas";
            // 
            // cboTeleVendas
            // 
            this.cboTeleVendas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTeleVendas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTeleVendas.FormattingEnabled = true;
            this.cboTeleVendas.Location = new System.Drawing.Point(235, 126);
            this.cboTeleVendas.Name = "cboTeleVendas";
            this.cboTeleVendas.Size = new System.Drawing.Size(215, 21);
            this.cboTeleVendas.TabIndex = 11;
            this.cboTeleVendas.Tag = "";
            this.cboTeleVendas.TextChanged += new System.EventHandler(this.cboTeleVendas_TextChanged);
            // 
            // cboVendedor
            // 
            this.cboVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVendedor.FormattingEnabled = true;
            this.cboVendedor.Location = new System.Drawing.Point(456, 126);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Size = new System.Drawing.Size(215, 21);
            this.cboVendedor.TabIndex = 12;
            this.cboVendedor.Tag = "";
            this.cboVendedor.TextChanged += new System.EventHandler(this.cboVendedor_TextChanged);
            // 
            // lblTipoOrdem
            // 
            this.lblTipoOrdem.AutoSize = true;
            this.lblTipoOrdem.Location = new System.Drawing.Point(17, 110);
            this.lblTipoOrdem.Name = "lblTipoOrdem";
            this.lblTipoOrdem.Size = new System.Drawing.Size(62, 13);
            this.lblTipoOrdem.TabIndex = 40;
            this.lblTipoOrdem.Text = "Tipo Ordem";
            // 
            // cboTipoOrdem
            // 
            this.cboTipoOrdem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTipoOrdem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoOrdem.FormattingEnabled = true;
            this.cboTipoOrdem.Location = new System.Drawing.Point(16, 126);
            this.cboTipoOrdem.Name = "cboTipoOrdem";
            this.cboTipoOrdem.Size = new System.Drawing.Size(215, 21);
            this.cboTipoOrdem.TabIndex = 10;
            this.cboTipoOrdem.Tag = "";
            this.cboTipoOrdem.TextChanged += new System.EventHandler(this.cboTipoOrdem_TextChanged);
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(459, 110);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(53, 13);
            this.lblVendedor.TabIndex = 42;
            this.lblVendedor.Text = "Vendedor";
            // 
            // lblVarianteConfig
            // 
            this.lblVarianteConfig.AutoSize = true;
            this.lblVarianteConfig.Location = new System.Drawing.Point(17, 161);
            this.lblVarianteConfig.Name = "lblVarianteConfig";
            this.lblVarianteConfig.Size = new System.Drawing.Size(37, 13);
            this.lblVarianteConfig.TabIndex = 44;
            this.lblVarianteConfig.Text = "Config";
            // 
            // cboVariantesConfig
            // 
            this.cboVariantesConfig.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboVariantesConfig.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVariantesConfig.FormattingEnabled = true;
            this.cboVariantesConfig.Location = new System.Drawing.Point(16, 177);
            this.cboVariantesConfig.Name = "cboVariantesConfig";
            this.cboVariantesConfig.Size = new System.Drawing.Size(215, 21);
            this.cboVariantesConfig.TabIndex = 14;
            this.cboVariantesConfig.Tag = "";
            this.cboVariantesConfig.TextChanged += new System.EventHandler(this.cboVariantesConfig_TextChanged);
            // 
            // txtDataEntregaAte
            // 
            this.txtDataEntregaAte.Location = new System.Drawing.Point(334, 22);
            this.txtDataEntregaAte.Mask = "99/99/9999";
            this.txtDataEntregaAte.Name = "txtDataEntregaAte";
            this.txtDataEntregaAte.Size = new System.Drawing.Size(100, 20);
            this.txtDataEntregaAte.TabIndex = 3;
            // 
            // lblDataEntregaAte
            // 
            this.lblDataEntregaAte.AutoSize = true;
            this.lblDataEntregaAte.Location = new System.Drawing.Point(331, 8);
            this.lblDataEntregaAte.Name = "lblDataEntregaAte";
            this.lblDataEntregaAte.Size = new System.Drawing.Size(23, 13);
            this.lblDataEntregaAte.TabIndex = 33;
            this.lblDataEntregaAte.Text = "Até";
            // 
            // txtDataEntregaDe
            // 
            this.txtDataEntregaDe.Location = new System.Drawing.Point(228, 22);
            this.txtDataEntregaDe.Mask = "99/99/9999";
            this.txtDataEntregaDe.Name = "txtDataEntregaDe";
            this.txtDataEntregaDe.Size = new System.Drawing.Size(100, 20);
            this.txtDataEntregaDe.TabIndex = 2;
            // 
            // lblDataEntregaDe
            // 
            this.lblDataEntregaDe.AutoSize = true;
            this.lblDataEntregaDe.Location = new System.Drawing.Point(225, 6);
            this.lblDataEntregaDe.Name = "lblDataEntregaDe";
            this.lblDataEntregaDe.Size = new System.Drawing.Size(85, 13);
            this.lblDataEntregaDe.TabIndex = 32;
            this.lblDataEntregaDe.Text = "Data Entrega de";
            // 
            // txtNumPedido
            // 
            this.txtNumPedido.Location = new System.Drawing.Point(456, 226);
            this.txtNumPedido.Name = "txtNumPedido";
            this.txtNumPedido.Size = new System.Drawing.Size(125, 20);
            this.txtNumPedido.TabIndex = 4;
            this.txtNumPedido.Tag = "";
            this.txtNumPedido.TextChanged += new System.EventHandler(this.txtNumPedido_TextChanged);
            this.txtNumPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumPedido_KeyPress);
            // 
            // lblNumPedido
            // 
            this.lblNumPedido.AutoSize = true;
            this.lblNumPedido.Location = new System.Drawing.Point(459, 210);
            this.lblNumPedido.Name = "lblNumPedido";
            this.lblNumPedido.Size = new System.Drawing.Size(55, 13);
            this.lblNumPedido.TabIndex = 34;
            this.lblNumPedido.Text = "N° Pedido";
            // 
            // lblGrupoClientes
            // 
            this.lblGrupoClientes.AutoSize = true;
            this.lblGrupoClientes.Location = new System.Drawing.Point(17, 59);
            this.lblGrupoClientes.Name = "lblGrupoClientes";
            this.lblGrupoClientes.Size = new System.Drawing.Size(91, 13);
            this.lblGrupoClientes.TabIndex = 36;
            this.lblGrupoClientes.Text = "Grupo de Clientes";
            // 
            // cboGrupoCliente
            // 
            this.cboGrupoCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboGrupoCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoCliente.FormattingEnabled = true;
            this.cboGrupoCliente.Location = new System.Drawing.Point(16, 75);
            this.cboGrupoCliente.Name = "cboGrupoCliente";
            this.cboGrupoCliente.Size = new System.Drawing.Size(215, 21);
            this.cboGrupoCliente.TabIndex = 6;
            this.cboGrupoCliente.Tag = "";
            this.cboGrupoCliente.TextChanged += new System.EventHandler(this.cboGrupoCliente_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(673, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Localização";
            // 
            // cboLocalizacao
            // 
            this.cboLocalizacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboLocalizacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboLocalizacao.FormattingEnabled = true;
            this.cboLocalizacao.Location = new System.Drawing.Point(676, 75);
            this.cboLocalizacao.Name = "cboLocalizacao";
            this.cboLocalizacao.Size = new System.Drawing.Size(215, 21);
            this.cboLocalizacao.TabIndex = 9;
            this.cboLocalizacao.Tag = "";
            this.cboLocalizacao.TextChanged += new System.EventHandler(this.cboLocalizacao_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(459, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Depósito";
            // 
            // cboDeposito
            // 
            this.cboDeposito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDeposito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDeposito.FormattingEnabled = true;
            this.cboDeposito.Location = new System.Drawing.Point(456, 75);
            this.cboDeposito.Name = "cboDeposito";
            this.cboDeposito.Size = new System.Drawing.Size(215, 21);
            this.cboDeposito.TabIndex = 8;
            this.cboDeposito.Tag = "";
            this.cboDeposito.TextChanged += new System.EventHandler(this.cboDeposito_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(236, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Armazém";
            // 
            // cboArmazem
            // 
            this.cboArmazem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboArmazem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboArmazem.FormattingEnabled = true;
            this.cboArmazem.Location = new System.Drawing.Point(235, 75);
            this.cboArmazem.Name = "cboArmazem";
            this.cboArmazem.Size = new System.Drawing.Size(215, 21);
            this.cboArmazem.TabIndex = 7;
            this.cboArmazem.Tag = "";
            this.cboArmazem.TextChanged += new System.EventHandler(this.cboArmazem_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(673, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Tamanho";
            // 
            // cboTamanho
            // 
            this.cboTamanho.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTamanho.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTamanho.FormattingEnabled = true;
            this.cboTamanho.Location = new System.Drawing.Point(676, 177);
            this.cboTamanho.Name = "cboTamanho";
            this.cboTamanho.Size = new System.Drawing.Size(215, 21);
            this.cboTamanho.TabIndex = 17;
            this.cboTamanho.Tag = "";
            this.cboTamanho.TextChanged += new System.EventHandler(this.cboTamanho_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(459, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Cor";
            // 
            // cboCor
            // 
            this.cboCor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCor.FormattingEnabled = true;
            this.cboCor.Location = new System.Drawing.Point(456, 177);
            this.cboCor.Name = "cboCor";
            this.cboCor.Size = new System.Drawing.Size(215, 21);
            this.cboCor.TabIndex = 16;
            this.cboCor.Tag = "";
            this.cboCor.TextChanged += new System.EventHandler(this.cboCor_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Estilo";
            // 
            // cboEstilo
            // 
            this.cboEstilo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEstilo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEstilo.FormattingEnabled = true;
            this.cboEstilo.Location = new System.Drawing.Point(235, 177);
            this.cboEstilo.Name = "cboEstilo";
            this.cboEstilo.Size = new System.Drawing.Size(215, 21);
            this.cboEstilo.TabIndex = 15;
            this.cboEstilo.Tag = "";
            this.cboEstilo.TextChanged += new System.EventHandler(this.cboEstilo_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::ERP.Properties.Resources.fundo;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNovo,
            this.toolStripSeparator1,
            this.btnReload,
            this.toolStripSeparator3,
            this.tsbPesquisa,
            this.toolStripSeparator2,
            this.toolStripDropDownButton1,
            this.btnRelatorio});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(941, 31);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(128, 28);
            this.btnNovo.Text = "Pedido de Vendas";
            this.btnNovo.ToolTipText = "Novo registro";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnReload
            // 
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(81, 28);
            this.btnReload.Text = "Atualizar";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbPesquisa
            // 
            this.tsbPesquisa.Image = global::ERP.Properties.Resources.Zoom_icon;
            this.tsbPesquisa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPesquisa.Name = "tsbPesquisa";
            this.tsbPesquisa.Size = new System.Drawing.Size(77, 28);
            this.tsbPesquisa.Text = "Pesquisar";
            this.tsbPesquisa.Click += new System.EventHandler(this.tsbPesquisa_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planilhaExcelToolStripMenuItem,
            this.arquivoSeparadoPorVírgulacsvToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(113, 28);
            this.toolStripDropDownButton1.Text = "Exportar para";
            // 
            // planilhaExcelToolStripMenuItem
            // 
            this.planilhaExcelToolStripMenuItem.Name = "planilhaExcelToolStripMenuItem";
            this.planilhaExcelToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.planilhaExcelToolStripMenuItem.Text = "Planilha Excel";
            this.planilhaExcelToolStripMenuItem.Click += new System.EventHandler(this.planilhaExcelToolStripMenuItem_Click);
            // 
            // arquivoSeparadoPorVírgulacsvToolStripMenuItem
            // 
            this.arquivoSeparadoPorVírgulacsvToolStripMenuItem.Name = "arquivoSeparadoPorVírgulacsvToolStripMenuItem";
            this.arquivoSeparadoPorVírgulacsvToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.arquivoSeparadoPorVírgulacsvToolStripMenuItem.Text = "Arquivo separado por vírgula (csv)";
            this.arquivoSeparadoPorVírgulacsvToolStripMenuItem.Click += new System.EventHandler(this.arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Image = global::ERP.Properties.Resources.Printer_3;
            this.btnRelatorio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(74, 28);
            this.btnRelatorio.Text = "Relatório";
            this.btnRelatorio.ToolTipText = "Relatório de Pedidos de Vendas";
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // frmPedidoVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 561);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlPesquisa);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmPedidoVendas";
            this.Text = "Pedido de Vendas";
            this.Load += new System.EventHandler(this.frmPedidoVendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlPesquisa.ResumeLayout(false);
            this.pnlPesquisa.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboProduto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.MaskedTextBox txtDataFim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtDataInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbPesquisa;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem planilhaExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arquivoSeparadoPorVírgulacsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnNovo;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel pnlPesquisa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboTamanho;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboEstilo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboLocalizacao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboDeposito;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboArmazem;
        private System.Windows.Forms.Label lblGrupoClientes;
        private System.Windows.Forms.ComboBox cboGrupoCliente;
        private System.Windows.Forms.TextBox txtNumPedido;
        private System.Windows.Forms.Label lblNumPedido;
        private System.Windows.Forms.MaskedTextBox txtDataEntregaAte;
        private System.Windows.Forms.Label lblDataEntregaAte;
        private System.Windows.Forms.MaskedTextBox txtDataEntregaDe;
        private System.Windows.Forms.Label lblDataEntregaDe;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPedidoCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.ToolStripButton btnRelatorio;
        private System.Windows.Forms.Label lblVarianteConfig;
        private System.Windows.Forms.ComboBox cboVariantesConfig;
        private System.Windows.Forms.Label lblTeleVendas;
        private System.Windows.Forms.ComboBox cboTeleVendas;
        private System.Windows.Forms.ComboBox cboVendedor;
        private System.Windows.Forms.Label lblTipoOrdem;
        private System.Windows.Forms.ComboBox cboTipoOrdem;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblStatusAprovacao;
        private System.Windows.Forms.ComboBox cboStatusAprovacao;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.TextBox txtCNPJ;
        private System.Windows.Forms.Label label8;
    }
}