namespace ERP
{
    partial class frmContratoComercialCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContratoComercialCad));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.cboFornecedor = new System.Windows.Forms.ComboBox();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboProduto = new System.Windows.Forms.ComboBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.cboRelacaoItem = new System.Windows.Forms.ComboBox();
            this.lblRelacaoItem = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTamanho = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboEstilo = new System.Windows.Forms.ComboBox();
            this.cboRelacao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataAte = new System.Windows.Forms.MaskedTextBox();
            this.txtDataDe = new System.Windows.Forms.MaskedTextBox();
            this.lblDataAte = new System.Windows.Forms.Label();
            this.lblDataDe = new System.Windows.Forms.Label();
            this.cboUnidade = new System.Windows.Forms.ComboBox();
            this.lblUnidade = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtValorPercentual = new System.Windows.Forms.TextBox();
            this.lblValorPercentual = new System.Windows.Forms.Label();
            this.cboGrupoPrecoDesconto = new System.Windows.Forms.ComboBox();
            this.lblGrupoPrecoDesconto = new System.Windows.Forms.Label();
            this.txtDe = new System.Windows.Forms.TextBox();
            this.lblDe = new System.Windows.Forms.Label();
            this.txtAte = new System.Windows.Forms.TextBox();
            this.lblAte = new System.Windows.Forms.Label();
            this.cboCodigo = new System.Windows.Forms.ComboBox();
            this.lblCodigoTipo = new System.Windows.Forms.Label();
            this.cboGrupoPrecoDescontoProduto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboUnidadePreco = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboGrupoDescontoVarejista = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCodigoContratoComercial = new System.Windows.Forms.ComboBox();
            this.tbcContrato = new System.Windows.Forms.TabControl();
            this.tbpContrato = new System.Windows.Forms.TabPage();
            this.cboConfig = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCondicaoPgto = new System.Windows.Forms.TabPage();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.IdContratoComercialCondPgto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdContratoComercial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CondicaoPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Juros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbcContrato.SuspendLayout();
            this.tbpContrato.SuspendLayout();
            this.tbCondicaoPgto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(752, 39);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(50, 17);
            this.chkAtivo.TabIndex = 5;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(18, 19);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Text = "Código";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(489, 19);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 0;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
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
            this.btnAdiciona.ToolTipTitle = "Adicionar";
            this.btnAdiciona.Click += new System.EventHandler(this.btnAdiciona_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAlterar.SmallImage")));
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.ToolTipTitle = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnGrava
            // 
            this.btnGrava.Enabled = false;
            this.btnGrava.Image = ((System.Drawing.Image)(resources.GetObject("btnGrava.Image")));
            this.btnGrava.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGrava.SmallImage")));
            this.btnGrava.Text = "Gravar";
            this.btnGrava.ToolTipTitle = "Gravar";
            this.btnGrava.Click += new System.EventHandler(this.btnGrava_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.SmallImage")));
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.ToolTipTitle = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnExcluir.SmallImage")));
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.ToolTipTitle = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
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
            this.ribbon1.Size = new System.Drawing.Size(934, 125);
            this.ribbon1.TabIndex = 51;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // cboFornecedor
            // 
            this.cboFornecedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFornecedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFornecedor.DropDownWidth = 255;
            this.cboFornecedor.Enabled = false;
            this.cboFornecedor.FormattingEnabled = true;
            this.cboFornecedor.Location = new System.Drawing.Point(265, 130);
            this.cboFornecedor.Name = "cboFornecedor";
            this.cboFornecedor.Size = new System.Drawing.Size(317, 21);
            this.cboFornecedor.TabIndex = 5;
            this.cboFornecedor.Tag = "";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(262, 114);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(61, 13);
            this.lblFornecedor.TabIndex = 13;
            this.lblFornecedor.Text = "Fornecedor";
            // 
            // cboCliente
            // 
            this.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCliente.DropDownWidth = 255;
            this.cboCliente.Enabled = false;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(264, 90);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(318, 21);
            this.cboCliente.TabIndex = 3;
            this.cboCliente.Tag = "";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(261, 74);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 11;
            this.lblCliente.Text = "Cliente";
            // 
            // cboProduto
            // 
            this.cboProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProduto.DropDownWidth = 255;
            this.cboProduto.Enabled = false;
            this.cboProduto.FormattingEnabled = true;
            this.cboProduto.Location = new System.Drawing.Point(261, 196);
            this.cboProduto.Name = "cboProduto";
            this.cboProduto.Size = new System.Drawing.Size(321, 21);
            this.cboProduto.TabIndex = 8;
            this.cboProduto.Tag = "";
            this.cboProduto.Leave += new System.EventHandler(this.cboProduto_Leave);
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(259, 180);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(44, 13);
            this.lblProduto.TabIndex = 21;
            this.lblProduto.Text = "Produto";
            // 
            // cboRelacaoItem
            // 
            this.cboRelacaoItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRelacaoItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRelacaoItem.FormattingEnabled = true;
            this.cboRelacaoItem.Location = new System.Drawing.Point(14, 198);
            this.cboRelacaoItem.Name = "cboRelacaoItem";
            this.cboRelacaoItem.Size = new System.Drawing.Size(241, 21);
            this.cboRelacaoItem.TabIndex = 7;
            this.cboRelacaoItem.Tag = "";
            this.cboRelacaoItem.Leave += new System.EventHandler(this.cboRelacaoItem_Leave);
            // 
            // lblRelacaoItem
            // 
            this.lblRelacaoItem.AutoSize = true;
            this.lblRelacaoItem.Location = new System.Drawing.Point(15, 182);
            this.lblRelacaoItem.Name = "lblRelacaoItem";
            this.lblRelacaoItem.Size = new System.Drawing.Size(85, 13);
            this.lblRelacaoItem.TabIndex = 17;
            this.lblRelacaoItem.Text = "Relação ao Item";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Tamanho";
            // 
            // cboTamanho
            // 
            this.cboTamanho.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTamanho.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTamanho.Enabled = false;
            this.cboTamanho.FormattingEnabled = true;
            this.cboTamanho.Location = new System.Drawing.Point(14, 319);
            this.cboTamanho.Name = "cboTamanho";
            this.cboTamanho.Size = new System.Drawing.Size(401, 21);
            this.cboTamanho.TabIndex = 12;
            this.cboTamanho.Tag = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(418, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Cor";
            // 
            // cboCor
            // 
            this.cboCor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCor.Enabled = false;
            this.cboCor.FormattingEnabled = true;
            this.cboCor.Location = new System.Drawing.Point(421, 264);
            this.cboCor.Name = "cboCor";
            this.cboCor.Size = new System.Drawing.Size(381, 21);
            this.cboCor.TabIndex = 11;
            this.cboCor.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Estilo";
            // 
            // cboEstilo
            // 
            this.cboEstilo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEstilo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEstilo.Enabled = false;
            this.cboEstilo.FormattingEnabled = true;
            this.cboEstilo.Location = new System.Drawing.Point(15, 264);
            this.cboEstilo.Name = "cboEstilo";
            this.cboEstilo.Size = new System.Drawing.Size(400, 21);
            this.cboEstilo.TabIndex = 10;
            this.cboEstilo.Tag = "";
            // 
            // cboRelacao
            // 
            this.cboRelacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRelacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRelacao.FormattingEnabled = true;
            this.cboRelacao.Location = new System.Drawing.Point(506, 35);
            this.cboRelacao.Name = "cboRelacao";
            this.cboRelacao.Size = new System.Drawing.Size(240, 21);
            this.cboRelacao.TabIndex = 1;
            this.cboRelacao.Tag = "1";
            this.cboRelacao.SelectedIndexChanged += new System.EventHandler(this.cboRelacao_SelectedIndexChanged);
            this.cboRelacao.Leave += new System.EventHandler(this.cboRelacao_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Relação";
            // 
            // txtDataAte
            // 
            this.txtDataAte.Location = new System.Drawing.Point(102, 424);
            this.txtDataAte.Mask = "99/99/9999";
            this.txtDataAte.Name = "txtDataAte";
            this.txtDataAte.Size = new System.Drawing.Size(81, 20);
            this.txtDataAte.TabIndex = 19;
            this.txtDataAte.Tag = "";
            // 
            // txtDataDe
            // 
            this.txtDataDe.Location = new System.Drawing.Point(14, 424);
            this.txtDataDe.Mask = "99/99/9999";
            this.txtDataDe.Name = "txtDataDe";
            this.txtDataDe.Size = new System.Drawing.Size(81, 20);
            this.txtDataDe.TabIndex = 18;
            this.txtDataDe.Tag = "";
            // 
            // lblDataAte
            // 
            this.lblDataAte.AutoSize = true;
            this.lblDataAte.Location = new System.Drawing.Point(99, 408);
            this.lblDataAte.Name = "lblDataAte";
            this.lblDataAte.Size = new System.Drawing.Size(49, 13);
            this.lblDataAte.TabIndex = 41;
            this.lblDataAte.Text = "Data Até";
            // 
            // lblDataDe
            // 
            this.lblDataDe.AutoSize = true;
            this.lblDataDe.Location = new System.Drawing.Point(11, 408);
            this.lblDataDe.Name = "lblDataDe";
            this.lblDataDe.Size = new System.Drawing.Size(45, 13);
            this.lblDataDe.TabIndex = 39;
            this.lblDataDe.Text = "Data de";
            // 
            // cboUnidade
            // 
            this.cboUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboUnidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUnidade.FormattingEnabled = true;
            this.cboUnidade.Location = new System.Drawing.Point(201, 424);
            this.cboUnidade.Name = "cboUnidade";
            this.cboUnidade.Size = new System.Drawing.Size(170, 21);
            this.cboUnidade.TabIndex = 20;
            this.cboUnidade.Tag = "";
            // 
            // lblUnidade
            // 
            this.lblUnidade.AutoSize = true;
            this.lblUnidade.Location = new System.Drawing.Point(198, 408);
            this.lblUnidade.Name = "lblUnidade";
            this.lblUnidade.Size = new System.Drawing.Size(47, 13);
            this.lblUnidade.TabIndex = 43;
            this.lblUnidade.Text = "Unidade";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(202, 373);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(170, 20);
            this.txtValor.TabIndex = 16;
            this.txtValor.Tag = "3";
            this.txtValor.Text = "0";
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(199, 357);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(31, 13);
            this.lblValor.TabIndex = 35;
            this.lblValor.Text = "Valor";
            // 
            // txtValorPercentual
            // 
            this.txtValorPercentual.Location = new System.Drawing.Point(384, 373);
            this.txtValorPercentual.Name = "txtValorPercentual";
            this.txtValorPercentual.Size = new System.Drawing.Size(170, 20);
            this.txtValorPercentual.TabIndex = 17;
            this.txtValorPercentual.Tag = "3";
            this.txtValorPercentual.Text = "0";
            this.txtValorPercentual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorPercentual_KeyPress);
            // 
            // lblValorPercentual
            // 
            this.lblValorPercentual.AutoSize = true;
            this.lblValorPercentual.Location = new System.Drawing.Point(381, 357);
            this.lblValorPercentual.Name = "lblValorPercentual";
            this.lblValorPercentual.Size = new System.Drawing.Size(85, 13);
            this.lblValorPercentual.TabIndex = 37;
            this.lblValorPercentual.Text = "Valor Percentual";
            // 
            // cboGrupoPrecoDesconto
            // 
            this.cboGrupoPrecoDesconto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGrupoPrecoDesconto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoPrecoDesconto.Enabled = false;
            this.cboGrupoPrecoDesconto.FormattingEnabled = true;
            this.cboGrupoPrecoDesconto.Location = new System.Drawing.Point(588, 130);
            this.cboGrupoPrecoDesconto.Name = "cboGrupoPrecoDesconto";
            this.cboGrupoPrecoDesconto.Size = new System.Drawing.Size(330, 21);
            this.cboGrupoPrecoDesconto.TabIndex = 6;
            this.cboGrupoPrecoDesconto.Tag = "";
            // 
            // lblGrupoPrecoDesconto
            // 
            this.lblGrupoPrecoDesconto.AutoSize = true;
            this.lblGrupoPrecoDesconto.Location = new System.Drawing.Point(585, 114);
            this.lblGrupoPrecoDesconto.Name = "lblGrupoPrecoDesconto";
            this.lblGrupoPrecoDesconto.Size = new System.Drawing.Size(116, 13);
            this.lblGrupoPrecoDesconto.TabIndex = 15;
            this.lblGrupoPrecoDesconto.Text = "Grupo Preço Desconto";
            // 
            // txtDe
            // 
            this.txtDe.Location = new System.Drawing.Point(14, 374);
            this.txtDe.Name = "txtDe";
            this.txtDe.Size = new System.Drawing.Size(81, 20);
            this.txtDe.TabIndex = 14;
            this.txtDe.Tag = "";
            this.txtDe.Text = "0";
            this.txtDe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDe_KeyPress);
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(14, 357);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(21, 13);
            this.lblDe.TabIndex = 31;
            this.lblDe.Text = "De";
            // 
            // txtAte
            // 
            this.txtAte.Location = new System.Drawing.Point(102, 374);
            this.txtAte.Name = "txtAte";
            this.txtAte.Size = new System.Drawing.Size(81, 20);
            this.txtAte.TabIndex = 15;
            this.txtAte.Tag = "";
            this.txtAte.Text = "0";
            this.txtAte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAte_KeyPress);
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Location = new System.Drawing.Point(102, 357);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(23, 13);
            this.lblAte.TabIndex = 33;
            this.lblAte.Text = "Até";
            // 
            // cboCodigo
            // 
            this.cboCodigo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCodigo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCodigo.FormattingEnabled = true;
            this.cboCodigo.Location = new System.Drawing.Point(17, 92);
            this.cboCodigo.Name = "cboCodigo";
            this.cboCodigo.Size = new System.Drawing.Size(241, 21);
            this.cboCodigo.TabIndex = 2;
            this.cboCodigo.Tag = "1";
            this.cboCodigo.SelectedIndexChanged += new System.EventHandler(this.cboCodigo_SelectedIndexChanged);
            this.cboCodigo.Leave += new System.EventHandler(this.cboCodigo_Leave);
            // 
            // lblCodigoTipo
            // 
            this.lblCodigoTipo.AutoSize = true;
            this.lblCodigoTipo.Location = new System.Drawing.Point(18, 76);
            this.lblCodigoTipo.Name = "lblCodigoTipo";
            this.lblCodigoTipo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigoTipo.TabIndex = 8;
            this.lblCodigoTipo.Text = "Código";
            // 
            // cboGrupoPrecoDescontoProduto
            // 
            this.cboGrupoPrecoDescontoProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGrupoPrecoDescontoProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoPrecoDescontoProduto.Enabled = false;
            this.cboGrupoPrecoDescontoProduto.FormattingEnabled = true;
            this.cboGrupoPrecoDescontoProduto.Location = new System.Drawing.Point(588, 196);
            this.cboGrupoPrecoDescontoProduto.Name = "cboGrupoPrecoDescontoProduto";
            this.cboGrupoPrecoDescontoProduto.Size = new System.Drawing.Size(330, 21);
            this.cboGrupoPrecoDescontoProduto.TabIndex = 9;
            this.cboGrupoPrecoDescontoProduto.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(585, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Grupo Preço Desconto Produto";
            // 
            // cboUnidadePreco
            // 
            this.cboUnidadePreco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboUnidadePreco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUnidadePreco.FormattingEnabled = true;
            this.cboUnidadePreco.Location = new System.Drawing.Point(384, 424);
            this.cboUnidadePreco.Name = "cboUnidadePreco";
            this.cboUnidadePreco.Size = new System.Drawing.Size(170, 21);
            this.cboUnidadePreco.TabIndex = 21;
            this.cboUnidadePreco.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Unidade Preço";
            // 
            // cboGrupoDescontoVarejista
            // 
            this.cboGrupoDescontoVarejista.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGrupoDescontoVarejista.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoDescontoVarejista.Enabled = false;
            this.cboGrupoDescontoVarejista.FormattingEnabled = true;
            this.cboGrupoDescontoVarejista.Location = new System.Drawing.Point(588, 90);
            this.cboGrupoDescontoVarejista.Name = "cboGrupoDescontoVarejista";
            this.cboGrupoDescontoVarejista.Size = new System.Drawing.Size(330, 21);
            this.cboGrupoDescontoVarejista.TabIndex = 4;
            this.cboGrupoDescontoVarejista.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(585, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Grupo de Desconto Varejista";
            // 
            // cboCodigoContratoComercial
            // 
            this.cboCodigoContratoComercial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCodigoContratoComercial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCodigoContratoComercial.FormattingEnabled = true;
            this.cboCodigoContratoComercial.Location = new System.Drawing.Point(15, 35);
            this.cboCodigoContratoComercial.Name = "cboCodigoContratoComercial";
            this.cboCodigoContratoComercial.Size = new System.Drawing.Size(487, 21);
            this.cboCodigoContratoComercial.TabIndex = 0;
            this.cboCodigoContratoComercial.Tag = "1";
            // 
            // tbcContrato
            // 
            this.tbcContrato.Controls.Add(this.tbpContrato);
            this.tbcContrato.Controls.Add(this.tbCondicaoPgto);
            this.tbcContrato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcContrato.Location = new System.Drawing.Point(0, 125);
            this.tbcContrato.Name = "tbcContrato";
            this.tbcContrato.SelectedIndex = 0;
            this.tbcContrato.Size = new System.Drawing.Size(934, 486);
            this.tbcContrato.TabIndex = 54;
            // 
            // tbpContrato
            // 
            this.tbpContrato.Controls.Add(this.cboConfig);
            this.tbpContrato.Controls.Add(this.label8);
            this.tbpContrato.Controls.Add(this.lblCodigo);
            this.tbpContrato.Controls.Add(this.cboCodigoContratoComercial);
            this.tbpContrato.Controls.Add(this.lbCodigo);
            this.tbpContrato.Controls.Add(this.cboGrupoDescontoVarejista);
            this.tbpContrato.Controls.Add(this.chkAtivo);
            this.tbpContrato.Controls.Add(this.label4);
            this.tbpContrato.Controls.Add(this.lblCliente);
            this.tbpContrato.Controls.Add(this.cboUnidadePreco);
            this.tbpContrato.Controls.Add(this.cboCliente);
            this.tbpContrato.Controls.Add(this.label3);
            this.tbpContrato.Controls.Add(this.lblFornecedor);
            this.tbpContrato.Controls.Add(this.cboGrupoPrecoDescontoProduto);
            this.tbpContrato.Controls.Add(this.cboFornecedor);
            this.tbpContrato.Controls.Add(this.label2);
            this.tbpContrato.Controls.Add(this.lblRelacaoItem);
            this.tbpContrato.Controls.Add(this.cboCodigo);
            this.tbpContrato.Controls.Add(this.cboRelacaoItem);
            this.tbpContrato.Controls.Add(this.lblCodigoTipo);
            this.tbpContrato.Controls.Add(this.lblProduto);
            this.tbpContrato.Controls.Add(this.txtAte);
            this.tbpContrato.Controls.Add(this.cboProduto);
            this.tbpContrato.Controls.Add(this.lblAte);
            this.tbpContrato.Controls.Add(this.cboEstilo);
            this.tbpContrato.Controls.Add(this.txtDe);
            this.tbpContrato.Controls.Add(this.label5);
            this.tbpContrato.Controls.Add(this.lblDe);
            this.tbpContrato.Controls.Add(this.cboCor);
            this.tbpContrato.Controls.Add(this.cboGrupoPrecoDesconto);
            this.tbpContrato.Controls.Add(this.label6);
            this.tbpContrato.Controls.Add(this.lblGrupoPrecoDesconto);
            this.tbpContrato.Controls.Add(this.cboTamanho);
            this.tbpContrato.Controls.Add(this.txtValorPercentual);
            this.tbpContrato.Controls.Add(this.label7);
            this.tbpContrato.Controls.Add(this.lblValorPercentual);
            this.tbpContrato.Controls.Add(this.label1);
            this.tbpContrato.Controls.Add(this.txtValor);
            this.tbpContrato.Controls.Add(this.cboRelacao);
            this.tbpContrato.Controls.Add(this.lblValor);
            this.tbpContrato.Controls.Add(this.lblDataDe);
            this.tbpContrato.Controls.Add(this.cboUnidade);
            this.tbpContrato.Controls.Add(this.lblDataAte);
            this.tbpContrato.Controls.Add(this.lblUnidade);
            this.tbpContrato.Controls.Add(this.txtDataDe);
            this.tbpContrato.Controls.Add(this.txtDataAte);
            this.tbpContrato.Location = new System.Drawing.Point(4, 22);
            this.tbpContrato.Name = "tbpContrato";
            this.tbpContrato.Padding = new System.Windows.Forms.Padding(3);
            this.tbpContrato.Size = new System.Drawing.Size(926, 460);
            this.tbpContrato.TabIndex = 0;
            this.tbpContrato.Text = "Contrato";
            this.tbpContrato.UseVisualStyleBackColor = true;
            // 
            // cboConfig
            // 
            this.cboConfig.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboConfig.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboConfig.Enabled = false;
            this.cboConfig.FormattingEnabled = true;
            this.cboConfig.Location = new System.Drawing.Point(421, 319);
            this.cboConfig.Name = "cboConfig";
            this.cboConfig.Size = new System.Drawing.Size(381, 21);
            this.cboConfig.TabIndex = 13;
            this.cboConfig.Tag = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(418, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 54;
            this.label8.Text = "Configuração";
            // 
            // tbCondicaoPgto
            // 
            this.tbCondicaoPgto.Controls.Add(this.dgv);
            this.tbCondicaoPgto.Controls.Add(this.btnAdd);
            this.tbCondicaoPgto.Location = new System.Drawing.Point(4, 22);
            this.tbCondicaoPgto.Name = "tbCondicaoPgto";
            this.tbCondicaoPgto.Padding = new System.Windows.Forms.Padding(3);
            this.tbCondicaoPgto.Size = new System.Drawing.Size(926, 460);
            this.tbCondicaoPgto.TabIndex = 1;
            this.tbCondicaoPgto.Text = "Condição Pgto";
            this.tbCondicaoPgto.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdContratoComercialCondPgto,
            this.IdContratoComercial,
            this.CondicaoPagamento,
            this.Juros});
            this.dgv.Enabled = false;
            this.dgv.Location = new System.Drawing.Point(6, 45);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(751, 388);
            this.dgv.TabIndex = 51;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // IdContratoComercialCondPgto
            // 
            this.IdContratoComercialCondPgto.DataPropertyName = "IdContratoComercialCondPgto";
            this.IdContratoComercialCondPgto.HeaderText = "IdContratoComercialCondPgto";
            this.IdContratoComercialCondPgto.Name = "IdContratoComercialCondPgto";
            this.IdContratoComercialCondPgto.ReadOnly = true;
            this.IdContratoComercialCondPgto.Visible = false;
            // 
            // IdContratoComercial
            // 
            this.IdContratoComercial.DataPropertyName = "IdContratoComercial";
            this.IdContratoComercial.HeaderText = "IdContratoComercial";
            this.IdContratoComercial.Name = "IdContratoComercial";
            this.IdContratoComercial.ReadOnly = true;
            this.IdContratoComercial.Visible = false;
            this.IdContratoComercial.Width = 140;
            // 
            // CondicaoPagamento
            // 
            this.CondicaoPagamento.DataPropertyName = "CondicaoPagamento";
            this.CondicaoPagamento.HeaderText = "Condição de Pagamento";
            this.CondicaoPagamento.Name = "CondicaoPagamento";
            this.CondicaoPagamento.ReadOnly = true;
            this.CondicaoPagamento.Width = 250;
            // 
            // Juros
            // 
            this.Juros.DataPropertyName = "Juros";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Juros.DefaultCellStyle = dataGridViewCellStyle3;
            this.Juros.HeaderText = "Juros";
            this.Juros.Name = "Juros";
            this.Juros.ReadOnly = true;
            this.Juros.Width = 70;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(6, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(136, 23);
            this.btnAdd.TabIndex = 50;
            this.btnAdd.Text = "Adicionar Condição Pgto";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmContratoComercialCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(934, 611);
            this.Controls.Add(this.tbcContrato);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmContratoComercialCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmContratoComercialCad";
            this.Text = "Cadastro Contrato Comercial";
            this.Load += new System.EventHandler(this.frmContratoComercialCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmContratoComercialCad_KeyDown);
            this.tbcContrato.ResumeLayout(false);
            this.tbpContrato.ResumeLayout(false);
            this.tbpContrato.PerformLayout();
            this.tbCondicaoPgto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.ComboBox cboFornecedor;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboProduto;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.ComboBox cboRelacaoItem;
        private System.Windows.Forms.Label lblRelacaoItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboTamanho;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboEstilo;
        private System.Windows.Forms.ComboBox cboRelacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtDataAte;
        private System.Windows.Forms.MaskedTextBox txtDataDe;
        private System.Windows.Forms.Label lblDataAte;
        private System.Windows.Forms.Label lblDataDe;
        private System.Windows.Forms.ComboBox cboUnidade;
        private System.Windows.Forms.Label lblUnidade;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValorPercentual;
        private System.Windows.Forms.Label lblValorPercentual;
        private System.Windows.Forms.ComboBox cboGrupoPrecoDesconto;
        private System.Windows.Forms.Label lblGrupoPrecoDesconto;
        private System.Windows.Forms.TextBox txtDe;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.TextBox txtAte;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.ComboBox cboCodigo;
        private System.Windows.Forms.Label lblCodigoTipo;
        private System.Windows.Forms.ComboBox cboGrupoPrecoDescontoProduto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboUnidadePreco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboGrupoDescontoVarejista;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCodigoContratoComercial;
        private System.Windows.Forms.TabControl tbcContrato;
        private System.Windows.Forms.TabPage tbpContrato;
        private System.Windows.Forms.TabPage tbCondicaoPgto;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdContratoComercialCondPgto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdContratoComercial;
        private System.Windows.Forms.DataGridViewTextBoxColumn CondicaoPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Juros;
        private System.Windows.Forms.ComboBox cboConfig;
        private System.Windows.Forms.Label label8;
    }
}