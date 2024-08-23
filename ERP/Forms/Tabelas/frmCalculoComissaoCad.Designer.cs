namespace ERP
{
    partial class frmCalculoComissaoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculoComissaoCad));
            this.lbCodigo = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.cboGrupoComissao = new System.Windows.Forms.ComboBox();
            this.lblGrupoComissao = new System.Windows.Forms.Label();
            this.cboRelacaoItem = new System.Windows.Forms.ComboBox();
            this.lblRelacaoItem = new System.Windows.Forms.Label();
            this.cboGrupoFornecedor = new System.Windows.Forms.ComboBox();
            this.lblGrupoFornecedor = new System.Windows.Forms.Label();
            this.cboFornecedor = new System.Windows.Forms.ComboBox();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.cboGrupoCliente = new System.Windows.Forms.ComboBox();
            this.lblGrupoCliente = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboGrupoProduto = new System.Windows.Forms.ComboBox();
            this.lblGrupoProduto = new System.Windows.Forms.Label();
            this.cboProduto = new System.Windows.Forms.ComboBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.cboRelacaoGrupo = new System.Windows.Forms.ComboBox();
            this.lblRelacaoGrupo = new System.Windows.Forms.Label();
            this.cboGrupoPrecoDesconto = new System.Windows.Forms.ComboBox();
            this.lblGrupoVendas = new System.Windows.Forms.Label();
            this.cboFuncionario = new System.Windows.Forms.ComboBox();
            this.lblFuncionario = new System.Windows.Forms.Label();
            this.cboDesconto = new System.Windows.Forms.ComboBox();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.cboAplicacao = new System.Windows.Forms.ComboBox();
            this.lblAplicacao = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.lblDe = new System.Windows.Forms.Label();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.cboPagamento = new System.Windows.Forms.ComboBox();
            this.lblPagamento = new System.Windows.Forms.Label();
            this.rdbCliente = new System.Windows.Forms.RadioButton();
            this.rdbFornecedor = new System.Windows.Forms.RadioButton();
            this.rdbProduto = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(361, 137);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 15;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
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
            this.ribbon1.Size = new System.Drawing.Size(610, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // cboGrupoComissao
            // 
            this.cboGrupoComissao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGrupoComissao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoComissao.FormattingEnabled = true;
            this.cboGrupoComissao.Location = new System.Drawing.Point(15, 153);
            this.cboGrupoComissao.Name = "cboGrupoComissao";
            this.cboGrupoComissao.Size = new System.Drawing.Size(240, 21);
            this.cboGrupoComissao.TabIndex = 17;
            this.cboGrupoComissao.Tag = "1";
            // 
            // lblGrupoComissao
            // 
            this.lblGrupoComissao.AutoSize = true;
            this.lblGrupoComissao.Location = new System.Drawing.Point(12, 137);
            this.lblGrupoComissao.Name = "lblGrupoComissao";
            this.lblGrupoComissao.Size = new System.Drawing.Size(84, 13);
            this.lblGrupoComissao.TabIndex = 16;
            this.lblGrupoComissao.Text = "Grupo Comissão";
            // 
            // cboRelacaoItem
            // 
            this.cboRelacaoItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRelacaoItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRelacaoItem.FormattingEnabled = true;
            this.cboRelacaoItem.Location = new System.Drawing.Point(15, 202);
            this.cboRelacaoItem.Name = "cboRelacaoItem";
            this.cboRelacaoItem.Size = new System.Drawing.Size(240, 21);
            this.cboRelacaoItem.TabIndex = 19;
            this.cboRelacaoItem.Tag = "1";
            // 
            // lblRelacaoItem
            // 
            this.lblRelacaoItem.AutoSize = true;
            this.lblRelacaoItem.Location = new System.Drawing.Point(12, 186);
            this.lblRelacaoItem.Name = "lblRelacaoItem";
            this.lblRelacaoItem.Size = new System.Drawing.Size(85, 13);
            this.lblRelacaoItem.TabIndex = 18;
            this.lblRelacaoItem.Text = "Relação ao Item";
            // 
            // cboGrupoFornecedor
            // 
            this.cboGrupoFornecedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGrupoFornecedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoFornecedor.Enabled = false;
            this.cboGrupoFornecedor.FormattingEnabled = true;
            this.cboGrupoFornecedor.Location = new System.Drawing.Point(357, 308);
            this.cboGrupoFornecedor.Name = "cboGrupoFornecedor";
            this.cboGrupoFornecedor.Size = new System.Drawing.Size(240, 21);
            this.cboGrupoFornecedor.TabIndex = 29;
            this.cboGrupoFornecedor.Tag = "";
            // 
            // lblGrupoFornecedor
            // 
            this.lblGrupoFornecedor.AutoSize = true;
            this.lblGrupoFornecedor.Location = new System.Drawing.Point(354, 292);
            this.lblGrupoFornecedor.Name = "lblGrupoFornecedor";
            this.lblGrupoFornecedor.Size = new System.Drawing.Size(93, 13);
            this.lblGrupoFornecedor.TabIndex = 28;
            this.lblGrupoFornecedor.Text = "Grupo Fornecedor";
            // 
            // cboFornecedor
            // 
            this.cboFornecedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFornecedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFornecedor.DropDownWidth = 255;
            this.cboFornecedor.Enabled = false;
            this.cboFornecedor.FormattingEnabled = true;
            this.cboFornecedor.Location = new System.Drawing.Point(103, 308);
            this.cboFornecedor.Name = "cboFornecedor";
            this.cboFornecedor.Size = new System.Drawing.Size(240, 21);
            this.cboFornecedor.TabIndex = 27;
            this.cboFornecedor.Tag = "";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(100, 292);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(61, 13);
            this.lblFornecedor.TabIndex = 26;
            this.lblFornecedor.Text = "Fornecedor";
            // 
            // cboGrupoCliente
            // 
            this.cboGrupoCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGrupoCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoCliente.FormattingEnabled = true;
            this.cboGrupoCliente.Location = new System.Drawing.Point(357, 259);
            this.cboGrupoCliente.Name = "cboGrupoCliente";
            this.cboGrupoCliente.Size = new System.Drawing.Size(240, 21);
            this.cboGrupoCliente.TabIndex = 25;
            this.cboGrupoCliente.Tag = "";
            // 
            // lblGrupoCliente
            // 
            this.lblGrupoCliente.AutoSize = true;
            this.lblGrupoCliente.Location = new System.Drawing.Point(354, 243);
            this.lblGrupoCliente.Name = "lblGrupoCliente";
            this.lblGrupoCliente.Size = new System.Drawing.Size(71, 13);
            this.lblGrupoCliente.TabIndex = 24;
            this.lblGrupoCliente.Text = "Grupo Cliente";
            // 
            // cboCliente
            // 
            this.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCliente.DropDownWidth = 255;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(103, 259);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(240, 21);
            this.cboCliente.TabIndex = 23;
            this.cboCliente.Tag = "";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(100, 243);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 22;
            this.lblCliente.Text = "Cliente";
            // 
            // cboGrupoProduto
            // 
            this.cboGrupoProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGrupoProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoProduto.Enabled = false;
            this.cboGrupoProduto.FormattingEnabled = true;
            this.cboGrupoProduto.Location = new System.Drawing.Point(103, 359);
            this.cboGrupoProduto.Name = "cboGrupoProduto";
            this.cboGrupoProduto.Size = new System.Drawing.Size(240, 21);
            this.cboGrupoProduto.TabIndex = 31;
            this.cboGrupoProduto.Tag = "";
            this.cboGrupoProduto.Leave += new System.EventHandler(this.cboGrupoProduto_Leave);
            // 
            // lblGrupoProduto
            // 
            this.lblGrupoProduto.AutoSize = true;
            this.lblGrupoProduto.Location = new System.Drawing.Point(100, 343);
            this.lblGrupoProduto.Name = "lblGrupoProduto";
            this.lblGrupoProduto.Size = new System.Drawing.Size(76, 13);
            this.lblGrupoProduto.TabIndex = 30;
            this.lblGrupoProduto.Text = "Grupo Produto";
            // 
            // cboProduto
            // 
            this.cboProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProduto.DropDownWidth = 255;
            this.cboProduto.Enabled = false;
            this.cboProduto.FormattingEnabled = true;
            this.cboProduto.Location = new System.Drawing.Point(357, 359);
            this.cboProduto.Name = "cboProduto";
            this.cboProduto.Size = new System.Drawing.Size(240, 21);
            this.cboProduto.TabIndex = 33;
            this.cboProduto.Tag = "";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(354, 343);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(44, 13);
            this.lblProduto.TabIndex = 32;
            this.lblProduto.Text = "Produto";
            // 
            // cboRelacaoGrupo
            // 
            this.cboRelacaoGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRelacaoGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRelacaoGrupo.FormattingEnabled = true;
            this.cboRelacaoGrupo.Location = new System.Drawing.Point(269, 202);
            this.cboRelacaoGrupo.Name = "cboRelacaoGrupo";
            this.cboRelacaoGrupo.Size = new System.Drawing.Size(240, 21);
            this.cboRelacaoGrupo.TabIndex = 21;
            this.cboRelacaoGrupo.Tag = "1";
            // 
            // lblRelacaoGrupo
            // 
            this.lblRelacaoGrupo.AutoSize = true;
            this.lblRelacaoGrupo.Location = new System.Drawing.Point(266, 186);
            this.lblRelacaoGrupo.Name = "lblRelacaoGrupo";
            this.lblRelacaoGrupo.Size = new System.Drawing.Size(94, 13);
            this.lblRelacaoGrupo.TabIndex = 20;
            this.lblRelacaoGrupo.Text = "Relação ao Grupo";
            // 
            // cboGrupoPrecoDesconto
            // 
            this.cboGrupoPrecoDesconto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGrupoPrecoDesconto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoPrecoDesconto.FormattingEnabled = true;
            this.cboGrupoPrecoDesconto.Location = new System.Drawing.Point(15, 418);
            this.cboGrupoPrecoDesconto.Name = "cboGrupoPrecoDesconto";
            this.cboGrupoPrecoDesconto.Size = new System.Drawing.Size(240, 21);
            this.cboGrupoPrecoDesconto.TabIndex = 35;
            this.cboGrupoPrecoDesconto.Tag = "";
            // 
            // lblGrupoVendas
            // 
            this.lblGrupoVendas.AutoSize = true;
            this.lblGrupoVendas.Location = new System.Drawing.Point(12, 402);
            this.lblGrupoVendas.Name = "lblGrupoVendas";
            this.lblGrupoVendas.Size = new System.Drawing.Size(146, 13);
            this.lblGrupoVendas.TabIndex = 34;
            this.lblGrupoVendas.Text = "Grupo de Preço de Desconto";
            // 
            // cboFuncionario
            // 
            this.cboFuncionario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFuncionario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFuncionario.DropDownWidth = 255;
            this.cboFuncionario.FormattingEnabled = true;
            this.cboFuncionario.Location = new System.Drawing.Point(269, 418);
            this.cboFuncionario.Name = "cboFuncionario";
            this.cboFuncionario.Size = new System.Drawing.Size(240, 21);
            this.cboFuncionario.TabIndex = 37;
            this.cboFuncionario.Tag = "1";
            // 
            // lblFuncionario
            // 
            this.lblFuncionario.AutoSize = true;
            this.lblFuncionario.Location = new System.Drawing.Point(266, 402);
            this.lblFuncionario.Name = "lblFuncionario";
            this.lblFuncionario.Size = new System.Drawing.Size(62, 13);
            this.lblFuncionario.TabIndex = 36;
            this.lblFuncionario.Text = "Funcionário";
            // 
            // cboDesconto
            // 
            this.cboDesconto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDesconto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDesconto.FormattingEnabled = true;
            this.cboDesconto.Location = new System.Drawing.Point(15, 467);
            this.cboDesconto.Name = "cboDesconto";
            this.cboDesconto.Size = new System.Drawing.Size(240, 21);
            this.cboDesconto.TabIndex = 39;
            this.cboDesconto.Tag = "";
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Location = new System.Drawing.Point(12, 451);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(53, 13);
            this.lblDesconto.TabIndex = 38;
            this.lblDesconto.Text = "Desconto";
            // 
            // cboAplicacao
            // 
            this.cboAplicacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboAplicacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAplicacao.DropDownWidth = 255;
            this.cboAplicacao.FormattingEnabled = true;
            this.cboAplicacao.Location = new System.Drawing.Point(269, 467);
            this.cboAplicacao.Name = "cboAplicacao";
            this.cboAplicacao.Size = new System.Drawing.Size(240, 21);
            this.cboAplicacao.TabIndex = 41;
            this.cboAplicacao.Tag = "1";
            // 
            // lblAplicacao
            // 
            this.lblAplicacao.AutoSize = true;
            this.lblAplicacao.Location = new System.Drawing.Point(266, 451);
            this.lblAplicacao.Name = "lblAplicacao";
            this.lblAplicacao.Size = new System.Drawing.Size(54, 13);
            this.lblAplicacao.TabIndex = 40;
            this.lblAplicacao.Text = "Aplicação";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Location = new System.Drawing.Point(266, 501);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(23, 13);
            this.lblAte.TabIndex = 44;
            this.lblAte.Text = "Até";
            // 
            // dtpAte
            // 
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(269, 517);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.Size = new System.Drawing.Size(145, 20);
            this.dtpAte.TabIndex = 45;
            this.dtpAte.Tag = "1";
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(12, 501);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(21, 13);
            this.lblDe.TabIndex = 42;
            this.lblDe.Text = "De";
            // 
            // dtpDe
            // 
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.Location = new System.Drawing.Point(15, 517);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(145, 20);
            this.dtpDe.TabIndex = 43;
            this.dtpDe.Tag = "1";
            // 
            // cboPagamento
            // 
            this.cboPagamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPagamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPagamento.FormattingEnabled = true;
            this.cboPagamento.Location = new System.Drawing.Point(12, 566);
            this.cboPagamento.Name = "cboPagamento";
            this.cboPagamento.Size = new System.Drawing.Size(240, 21);
            this.cboPagamento.TabIndex = 47;
            this.cboPagamento.Tag = "1";
            // 
            // lblPagamento
            // 
            this.lblPagamento.AutoSize = true;
            this.lblPagamento.Location = new System.Drawing.Point(12, 550);
            this.lblPagamento.Name = "lblPagamento";
            this.lblPagamento.Size = new System.Drawing.Size(61, 13);
            this.lblPagamento.TabIndex = 46;
            this.lblPagamento.Text = "Pagamento";
            // 
            // rdbCliente
            // 
            this.rdbCliente.AutoSize = true;
            this.rdbCliente.Checked = true;
            this.rdbCliente.Location = new System.Drawing.Point(15, 243);
            this.rdbCliente.Name = "rdbCliente";
            this.rdbCliente.Size = new System.Drawing.Size(57, 17);
            this.rdbCliente.TabIndex = 22;
            this.rdbCliente.TabStop = true;
            this.rdbCliente.Text = "Cliente";
            this.rdbCliente.UseVisualStyleBackColor = true;
            this.rdbCliente.CheckedChanged += new System.EventHandler(this.rdbCliente_CheckedChanged);
            // 
            // rdbFornecedor
            // 
            this.rdbFornecedor.AutoSize = true;
            this.rdbFornecedor.Location = new System.Drawing.Point(15, 292);
            this.rdbFornecedor.Name = "rdbFornecedor";
            this.rdbFornecedor.Size = new System.Drawing.Size(79, 17);
            this.rdbFornecedor.TabIndex = 26;
            this.rdbFornecedor.Text = "Fornecedor";
            this.rdbFornecedor.UseVisualStyleBackColor = true;
            this.rdbFornecedor.CheckedChanged += new System.EventHandler(this.rdbFornecedor_CheckedChanged);
            // 
            // rdbProduto
            // 
            this.rdbProduto.AutoSize = true;
            this.rdbProduto.Location = new System.Drawing.Point(15, 343);
            this.rdbProduto.Name = "rdbProduto";
            this.rdbProduto.Size = new System.Drawing.Size(62, 17);
            this.rdbProduto.TabIndex = 30;
            this.rdbProduto.Text = "Produto";
            this.rdbProduto.UseVisualStyleBackColor = true;
            this.rdbProduto.CheckedChanged += new System.EventHandler(this.rdbProduto_CheckedChanged);
            // 
            // frmCalculoComissaoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(610, 589);
            this.Controls.Add(this.rdbProduto);
            this.Controls.Add(this.rdbFornecedor);
            this.Controls.Add(this.rdbCliente);
            this.Controls.Add(this.cboPagamento);
            this.Controls.Add(this.lblPagamento);
            this.Controls.Add(this.lblAte);
            this.Controls.Add(this.dtpAte);
            this.Controls.Add(this.lblDe);
            this.Controls.Add(this.dtpDe);
            this.Controls.Add(this.cboDesconto);
            this.Controls.Add(this.lblDesconto);
            this.Controls.Add(this.cboAplicacao);
            this.Controls.Add(this.lblAplicacao);
            this.Controls.Add(this.cboGrupoPrecoDesconto);
            this.Controls.Add(this.lblGrupoVendas);
            this.Controls.Add(this.cboFuncionario);
            this.Controls.Add(this.lblFuncionario);
            this.Controls.Add(this.cboRelacaoGrupo);
            this.Controls.Add(this.lblRelacaoGrupo);
            this.Controls.Add(this.cboGrupoProduto);
            this.Controls.Add(this.lblGrupoProduto);
            this.Controls.Add(this.cboProduto);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.cboGrupoFornecedor);
            this.Controls.Add(this.lblGrupoFornecedor);
            this.Controls.Add(this.cboFornecedor);
            this.Controls.Add(this.lblFornecedor);
            this.Controls.Add(this.cboGrupoCliente);
            this.Controls.Add(this.lblGrupoCliente);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cboRelacaoItem);
            this.Controls.Add(this.lblRelacaoItem);
            this.Controls.Add(this.cboGrupoComissao);
            this.Controls.Add(this.lblGrupoComissao);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmCalculoComissaoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmCalculoComissaoCad";
            this.Text = "Cadastro Cálculo de Comissão";
            this.Load += new System.EventHandler(this.frmCalculoComissaoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCalculoComissaoCad_KeyDown);
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
        private System.Windows.Forms.ComboBox cboGrupoComissao;
        private System.Windows.Forms.Label lblGrupoComissao;
        private System.Windows.Forms.ComboBox cboRelacaoItem;
        private System.Windows.Forms.Label lblRelacaoItem;
        private System.Windows.Forms.ComboBox cboGrupoFornecedor;
        private System.Windows.Forms.Label lblGrupoFornecedor;
        private System.Windows.Forms.ComboBox cboFornecedor;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.ComboBox cboGrupoCliente;
        private System.Windows.Forms.Label lblGrupoCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboGrupoProduto;
        private System.Windows.Forms.Label lblGrupoProduto;
        private System.Windows.Forms.ComboBox cboProduto;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.ComboBox cboRelacaoGrupo;
        private System.Windows.Forms.Label lblRelacaoGrupo;
        private System.Windows.Forms.ComboBox cboGrupoPrecoDesconto;
        private System.Windows.Forms.Label lblGrupoVendas;
        private System.Windows.Forms.ComboBox cboFuncionario;
        private System.Windows.Forms.Label lblFuncionario;
        private System.Windows.Forms.ComboBox cboDesconto;
        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.ComboBox cboAplicacao;
        private System.Windows.Forms.Label lblAplicacao;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.ComboBox cboPagamento;
        private System.Windows.Forms.Label lblPagamento;
        private System.Windows.Forms.RadioButton rdbCliente;
        private System.Windows.Forms.RadioButton rdbFornecedor;
        private System.Windows.Forms.RadioButton rdbProduto;
    }
}