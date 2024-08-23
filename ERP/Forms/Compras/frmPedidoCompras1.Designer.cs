namespace ERP
{
    partial class frmPedidoCompras1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPedidoCompras1));
            this.pnlPesquisa = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTamanho = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboEstilo = new System.Windows.Forms.ComboBox();
            this.lblGrupoFornecedores = new System.Windows.Forms.Label();
            this.cboGrupoFornecedor = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboLocalizacao = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboDeposito = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboArmazem = new System.Windows.Forms.ComboBox();
            this.txtDataEntregaAte = new System.Windows.Forms.MaskedTextBox();
            this.lblDataEntregaAte = new System.Windows.Forms.Label();
            this.txtDataEntregaDe = new System.Windows.Forms.MaskedTextBox();
            this.lblDataEntregaDe = new System.Windows.Forms.Label();
            this.txtNumPedido = new System.Windows.Forms.TextBox();
            this.lblNumPedido = new System.Windows.Forms.Label();
            this.cboProduto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboFornecedor = new System.Windows.Forms.ComboBox();
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
            this.lblVarianteConfig = new System.Windows.Forms.Label();
            this.cboVariantesConfig = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cboTipoOrdem = new System.Windows.Forms.ComboBox();
            this.lblStatusAprovacao = new System.Windows.Forms.Label();
            this.cboStatusAprovacao = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.pnlPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPesquisa
            // 
            this.pnlPesquisa.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPesquisa.Controls.Add(this.lblStatusAprovacao);
            this.pnlPesquisa.Controls.Add(this.cboStatusAprovacao);
            this.pnlPesquisa.Controls.Add(this.lblStatus);
            this.pnlPesquisa.Controls.Add(this.cboStatus);
            this.pnlPesquisa.Controls.Add(this.label23);
            this.pnlPesquisa.Controls.Add(this.cboTipoOrdem);
            this.pnlPesquisa.Controls.Add(this.lblVarianteConfig);
            this.pnlPesquisa.Controls.Add(this.cboVariantesConfig);
            this.pnlPesquisa.Controls.Add(this.label7);
            this.pnlPesquisa.Controls.Add(this.cboTamanho);
            this.pnlPesquisa.Controls.Add(this.label6);
            this.pnlPesquisa.Controls.Add(this.cboCor);
            this.pnlPesquisa.Controls.Add(this.label5);
            this.pnlPesquisa.Controls.Add(this.cboEstilo);
            this.pnlPesquisa.Controls.Add(this.lblGrupoFornecedores);
            this.pnlPesquisa.Controls.Add(this.cboGrupoFornecedor);
            this.pnlPesquisa.Controls.Add(this.label12);
            this.pnlPesquisa.Controls.Add(this.cboLocalizacao);
            this.pnlPesquisa.Controls.Add(this.label11);
            this.pnlPesquisa.Controls.Add(this.cboDeposito);
            this.pnlPesquisa.Controls.Add(this.label10);
            this.pnlPesquisa.Controls.Add(this.cboArmazem);
            this.pnlPesquisa.Controls.Add(this.txtDataEntregaAte);
            this.pnlPesquisa.Controls.Add(this.lblDataEntregaAte);
            this.pnlPesquisa.Controls.Add(this.txtDataEntregaDe);
            this.pnlPesquisa.Controls.Add(this.lblDataEntregaDe);
            this.pnlPesquisa.Controls.Add(this.txtNumPedido);
            this.pnlPesquisa.Controls.Add(this.lblNumPedido);
            this.pnlPesquisa.Controls.Add(this.cboProduto);
            this.pnlPesquisa.Controls.Add(this.label4);
            this.pnlPesquisa.Controls.Add(this.cboFornecedor);
            this.pnlPesquisa.Controls.Add(this.label3);
            this.pnlPesquisa.Controls.Add(this.txtDataFim);
            this.pnlPesquisa.Controls.Add(this.label2);
            this.pnlPesquisa.Controls.Add(this.txtDataInicio);
            this.pnlPesquisa.Controls.Add(this.label1);
            this.pnlPesquisa.Controls.Add(this.btnPesquisa);
            this.pnlPesquisa.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPesquisa.Location = new System.Drawing.Point(0, 31);
            this.pnlPesquisa.Name = "pnlPesquisa";
            this.pnlPesquisa.Size = new System.Drawing.Size(941, 250);
            this.pnlPesquisa.TabIndex = 15;
            this.pnlPesquisa.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(677, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Tamanho";
            // 
            // cboTamanho
            // 
            this.cboTamanho.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTamanho.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTamanho.FormattingEnabled = true;
            this.cboTamanho.Location = new System.Drawing.Point(680, 174);
            this.cboTamanho.Name = "cboTamanho";
            this.cboTamanho.Size = new System.Drawing.Size(215, 21);
            this.cboTamanho.TabIndex = 15;
            this.cboTamanho.Tag = "";
            this.cboTamanho.TextChanged += new System.EventHandler(this.cboTamanho_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(463, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Cor";
            // 
            // cboCor
            // 
            this.cboCor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCor.FormattingEnabled = true;
            this.cboCor.Location = new System.Drawing.Point(460, 174);
            this.cboCor.Name = "cboCor";
            this.cboCor.Size = new System.Drawing.Size(215, 21);
            this.cboCor.TabIndex = 14;
            this.cboCor.Tag = "";
            this.cboCor.TextChanged += new System.EventHandler(this.cboCor_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Estilo";
            // 
            // cboEstilo
            // 
            this.cboEstilo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEstilo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEstilo.FormattingEnabled = true;
            this.cboEstilo.Location = new System.Drawing.Point(239, 174);
            this.cboEstilo.Name = "cboEstilo";
            this.cboEstilo.Size = new System.Drawing.Size(215, 21);
            this.cboEstilo.TabIndex = 13;
            this.cboEstilo.Tag = "";
            this.cboEstilo.TextChanged += new System.EventHandler(this.cboEstilo_TextChanged);
            // 
            // lblGrupoFornecedores
            // 
            this.lblGrupoFornecedores.AutoSize = true;
            this.lblGrupoFornecedores.Location = new System.Drawing.Point(17, 58);
            this.lblGrupoFornecedores.Name = "lblGrupoFornecedores";
            this.lblGrupoFornecedores.Size = new System.Drawing.Size(119, 13);
            this.lblGrupoFornecedores.TabIndex = 36;
            this.lblGrupoFornecedores.Text = "Grupo de Fornecedores";
            // 
            // cboGrupoFornecedor
            // 
            this.cboGrupoFornecedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboGrupoFornecedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoFornecedor.FormattingEnabled = true;
            this.cboGrupoFornecedor.Location = new System.Drawing.Point(16, 74);
            this.cboGrupoFornecedor.Name = "cboGrupoFornecedor";
            this.cboGrupoFornecedor.Size = new System.Drawing.Size(215, 21);
            this.cboGrupoFornecedor.TabIndex = 6;
            this.cboGrupoFornecedor.Tag = "";
            this.cboGrupoFornecedor.TextChanged += new System.EventHandler(this.cboGrupoFornecedor_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(677, 58);
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
            this.cboLocalizacao.Location = new System.Drawing.Point(680, 74);
            this.cboLocalizacao.Name = "cboLocalizacao";
            this.cboLocalizacao.Size = new System.Drawing.Size(215, 21);
            this.cboLocalizacao.TabIndex = 9;
            this.cboLocalizacao.Tag = "";
            this.cboLocalizacao.TextChanged += new System.EventHandler(this.cboLocalizacao_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(463, 58);
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
            this.cboDeposito.Location = new System.Drawing.Point(460, 74);
            this.cboDeposito.Name = "cboDeposito";
            this.cboDeposito.Size = new System.Drawing.Size(215, 21);
            this.cboDeposito.TabIndex = 8;
            this.cboDeposito.Tag = "";
            this.cboDeposito.TextChanged += new System.EventHandler(this.cboDeposito_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(240, 58);
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
            this.cboArmazem.Location = new System.Drawing.Point(239, 74);
            this.cboArmazem.Name = "cboArmazem";
            this.cboArmazem.Size = new System.Drawing.Size(215, 21);
            this.cboArmazem.TabIndex = 7;
            this.cboArmazem.Tag = "";
            this.cboArmazem.TextChanged += new System.EventHandler(this.cboArmazem_TextChanged);
            // 
            // txtDataEntregaAte
            // 
            this.txtDataEntregaAte.Location = new System.Drawing.Point(338, 24);
            this.txtDataEntregaAte.Mask = "99/99/9999";
            this.txtDataEntregaAte.Name = "txtDataEntregaAte";
            this.txtDataEntregaAte.Size = new System.Drawing.Size(100, 20);
            this.txtDataEntregaAte.TabIndex = 3;
            this.txtDataEntregaAte.TextChanged += new System.EventHandler(this.txtDataEntregaAte_TextChanged);
            // 
            // lblDataEntregaAte
            // 
            this.lblDataEntregaAte.AutoSize = true;
            this.lblDataEntregaAte.Location = new System.Drawing.Point(335, 10);
            this.lblDataEntregaAte.Name = "lblDataEntregaAte";
            this.lblDataEntregaAte.Size = new System.Drawing.Size(23, 13);
            this.lblDataEntregaAte.TabIndex = 33;
            this.lblDataEntregaAte.Text = "Até";
            // 
            // txtDataEntregaDe
            // 
            this.txtDataEntregaDe.Location = new System.Drawing.Point(232, 24);
            this.txtDataEntregaDe.Mask = "99/99/9999";
            this.txtDataEntregaDe.Name = "txtDataEntregaDe";
            this.txtDataEntregaDe.Size = new System.Drawing.Size(100, 20);
            this.txtDataEntregaDe.TabIndex = 2;
            this.txtDataEntregaDe.TextChanged += new System.EventHandler(this.txtDataEntregaDe_TextChanged);
            // 
            // lblDataEntregaDe
            // 
            this.lblDataEntregaDe.AutoSize = true;
            this.lblDataEntregaDe.Location = new System.Drawing.Point(229, 8);
            this.lblDataEntregaDe.Name = "lblDataEntregaDe";
            this.lblDataEntregaDe.Size = new System.Drawing.Size(85, 13);
            this.lblDataEntregaDe.TabIndex = 32;
            this.lblDataEntregaDe.Text = "Data Entrega de";
            // 
            // txtNumPedido
            // 
            this.txtNumPedido.Location = new System.Drawing.Point(446, 24);
            this.txtNumPedido.Name = "txtNumPedido";
            this.txtNumPedido.Size = new System.Drawing.Size(96, 20);
            this.txtNumPedido.TabIndex = 4;
            this.txtNumPedido.Tag = "";
            this.txtNumPedido.TextChanged += new System.EventHandler(this.txtNumPedido_TextChanged);
            this.txtNumPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumPedido_KeyPress);
            // 
            // lblNumPedido
            // 
            this.lblNumPedido.AutoSize = true;
            this.lblNumPedido.Location = new System.Drawing.Point(449, 8);
            this.lblNumPedido.Name = "lblNumPedido";
            this.lblNumPedido.Size = new System.Drawing.Size(55, 13);
            this.lblNumPedido.TabIndex = 34;
            this.lblNumPedido.Text = "N° Pedido";
            // 
            // cboProduto
            // 
            this.cboProduto.AllowDrop = true;
            this.cboProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProduto.FormattingEnabled = true;
            this.cboProduto.Location = new System.Drawing.Point(239, 125);
            this.cboProduto.Name = "cboProduto";
            this.cboProduto.Size = new System.Drawing.Size(215, 21);
            this.cboProduto.TabIndex = 11;
            this.cboProduto.TextChanged += new System.EventHandler(this.cboProduto_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Produto";
            // 
            // cboFornecedor
            // 
            this.cboFornecedor.AllowDrop = true;
            this.cboFornecedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFornecedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFornecedor.FormattingEnabled = true;
            this.cboFornecedor.Location = new System.Drawing.Point(546, 23);
            this.cboFornecedor.Name = "cboFornecedor";
            this.cboFornecedor.Size = new System.Drawing.Size(268, 21);
            this.cboFornecedor.TabIndex = 5;
            this.cboFornecedor.TextChanged += new System.EventHandler(this.cboFornecedor_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(543, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Fornecedor";
            // 
            // txtDataFim
            // 
            this.txtDataFim.Location = new System.Drawing.Point(126, 24);
            this.txtDataFim.Mask = "99/99/9999";
            this.txtDataFim.Name = "txtDataFim";
            this.txtDataFim.Size = new System.Drawing.Size(100, 20);
            this.txtDataFim.TabIndex = 1;
            this.txtDataFim.TextChanged += new System.EventHandler(this.txtDataFim_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 8);
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
            this.label1.Location = new System.Drawing.Point(17, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Data de";
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Location = new System.Drawing.Point(820, 21);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisa.TabIndex = 18;
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
            this.dgv.Location = new System.Drawing.Point(0, 281);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 18;
            this.dgv.Size = new System.Drawing.Size(941, 259);
            this.dgv.TabIndex = 16;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // IdPedidoCompras
            // 
            this.IdPedidoCompras.DataPropertyName = "IdPedidoCompras";
            this.IdPedidoCompras.HeaderText = "IdPedidoCompras";
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
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NomeFantasia";
            this.Column3.HeaderText = "Fornecedor";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DataEntrega";
            this.Column4.HeaderText = "Data de entrega";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
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
            this.Column6.HeaderText = "Status Entrega";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle25.Format = "N4";
            this.Valor.DefaultCellStyle = dataGridViewCellStyle25;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // Desconto
            // 
            this.Desconto.DataPropertyName = "Desconto";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle26.Format = "N4";
            dataGridViewCellStyle26.NullValue = null;
            this.Desconto.DefaultCellStyle = dataGridViewCellStyle26;
            this.Desconto.HeaderText = "Desconto";
            this.Desconto.Name = "Desconto";
            this.Desconto.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle27.Format = "N4";
            this.Total.DefaultCellStyle = dataGridViewCellStyle27;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::ERP.Properties.Resources.fundo1;
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
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(139, 28);
            this.btnNovo.Text = "Pedido de Compras";
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
            this.btnRelatorio.ToolTipText = "Relatório de Pedidos de Compras";
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // lblVarianteConfig
            // 
            this.lblVarianteConfig.AutoSize = true;
            this.lblVarianteConfig.Location = new System.Drawing.Point(17, 158);
            this.lblVarianteConfig.Name = "lblVarianteConfig";
            this.lblVarianteConfig.Size = new System.Drawing.Size(37, 13);
            this.lblVarianteConfig.TabIndex = 42;
            this.lblVarianteConfig.Text = "Config";
            // 
            // cboVariantesConfig
            // 
            this.cboVariantesConfig.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboVariantesConfig.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVariantesConfig.FormattingEnabled = true;
            this.cboVariantesConfig.Location = new System.Drawing.Point(16, 174);
            this.cboVariantesConfig.Name = "cboVariantesConfig";
            this.cboVariantesConfig.Size = new System.Drawing.Size(215, 21);
            this.cboVariantesConfig.TabIndex = 12;
            this.cboVariantesConfig.Tag = "";
            this.cboVariantesConfig.TextChanged += new System.EventHandler(this.cboVariantesConfig_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(17, 109);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(62, 13);
            this.label23.TabIndex = 40;
            this.label23.Text = "Tipo Ordem";
            // 
            // cboTipoOrdem
            // 
            this.cboTipoOrdem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTipoOrdem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoOrdem.FormattingEnabled = true;
            this.cboTipoOrdem.Location = new System.Drawing.Point(16, 125);
            this.cboTipoOrdem.Name = "cboTipoOrdem";
            this.cboTipoOrdem.Size = new System.Drawing.Size(215, 21);
            this.cboTipoOrdem.TabIndex = 10;
            this.cboTipoOrdem.Tag = "";
            this.cboTipoOrdem.TextChanged += new System.EventHandler(this.cboTipoOrdem_TextChanged);
            // 
            // lblStatusAprovacao
            // 
            this.lblStatusAprovacao.AutoSize = true;
            this.lblStatusAprovacao.Location = new System.Drawing.Point(236, 207);
            this.lblStatusAprovacao.Name = "lblStatusAprovacao";
            this.lblStatusAprovacao.Size = new System.Drawing.Size(92, 13);
            this.lblStatusAprovacao.TabIndex = 47;
            this.lblStatusAprovacao.Text = "Status Aprovação";
            // 
            // cboStatusAprovacao
            // 
            this.cboStatusAprovacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboStatusAprovacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStatusAprovacao.FormattingEnabled = true;
            this.cboStatusAprovacao.Location = new System.Drawing.Point(235, 223);
            this.cboStatusAprovacao.Name = "cboStatusAprovacao";
            this.cboStatusAprovacao.Size = new System.Drawing.Size(215, 21);
            this.cboStatusAprovacao.TabIndex = 17;
            this.cboStatusAprovacao.Tag = "";
            this.cboStatusAprovacao.TextChanged += new System.EventHandler(this.cboStatusAprovacao_TextChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(17, 207);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 46;
            this.lblStatus.Text = "Status";
            // 
            // cboStatus
            // 
            this.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(16, 223);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(215, 21);
            this.cboStatus.TabIndex = 16;
            this.cboStatus.Tag = "";
            this.cboStatus.TextChanged += new System.EventHandler(this.cboStatus_TextChanged);
            // 
            // frmPedidoCompras1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 540);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlPesquisa);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmPedidoCompras1";
            this.Text = "Pedido de Compras";
            this.Load += new System.EventHandler(this.frmPedidoCompras_Load);
            this.pnlPesquisa.ResumeLayout(false);
            this.pnlPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNovo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbPesquisa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem planilhaExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arquivoSeparadoPorVírgulacsvToolStripMenuItem;
        private System.Windows.Forms.Panel pnlPesquisa;
        private System.Windows.Forms.ComboBox cboProduto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboFornecedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtDataFim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtDataInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.MaskedTextBox txtDataEntregaAte;
        private System.Windows.Forms.Label lblDataEntregaAte;
        private System.Windows.Forms.MaskedTextBox txtDataEntregaDe;
        private System.Windows.Forms.Label lblDataEntregaDe;
        private System.Windows.Forms.TextBox txtNumPedido;
        private System.Windows.Forms.Label lblNumPedido;
        private System.Windows.Forms.Label lblGrupoFornecedores;
        private System.Windows.Forms.ComboBox cboGrupoFornecedor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboLocalizacao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboDeposito;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboArmazem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboTamanho;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboEstilo;
        private System.Windows.Forms.ToolStripButton btnRelatorio;
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
        private System.Windows.Forms.Label lblVarianteConfig;
        private System.Windows.Forms.ComboBox cboVariantesConfig;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cboTipoOrdem;
        private System.Windows.Forms.Label lblStatusAprovacao;
        private System.Windows.Forms.ComboBox cboStatusAprovacao;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;

    }
}