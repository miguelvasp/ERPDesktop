namespace ERP
{
    partial class frmAtivoImobilizadoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAtivoImobilizadoCad));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.cboGrupoAtivo = new System.Windows.Forms.ComboBox();
            this.lblGrupoAtivo = new System.Windows.Forms.Label();
            this.txtNumeroFisico = new System.Windows.Forms.TextBox();
            this.lblNumeroFisico = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cboTipoPropriedade = new System.Windows.Forms.ComboBox();
            this.lblTipoPropriedade = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.lblAno = new System.Windows.Forms.Label();
            this.txtNumeroSerie = new System.Windows.Forms.TextBox();
            this.lblNumeroSerie = new System.Windows.Forms.Label();
            this.lblDataGarantia = new System.Windows.Forms.Label();
            this.dtpDataGarantia = new System.Windows.Forms.DateTimePicker();
            this.txtApolice = new System.Windows.Forms.TextBox();
            this.lblApolice = new System.Windows.Forms.Label();
            this.lblDataApolice = new System.Windows.Forms.Label();
            this.dtpDataApolice = new System.Windows.Forms.DateTimePicker();
            this.txtValorSegurado = new System.Windows.Forms.TextBox();
            this.lblValorSegurado = new System.Windows.Forms.Label();
            this.cboFuncionario = new System.Windows.Forms.ComboBox();
            this.lblFuncionario = new System.Windows.Forms.Label();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.lblCodigoBarras = new System.Windows.Forms.Label();
            this.chkAtivoNaoLocalizado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(26, 155);
            this.txtNome.MaxLength = 40;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(341, 20);
            this.txtNome.TabIndex = 17;
            this.txtNome.Tag = "1";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(23, 139);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 16;
            this.lblNome.Text = "Nome";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(350, 139);
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
            this.ribbon1.Size = new System.Drawing.Size(731, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(381, 155);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(341, 20);
            this.txtDescricao.TabIndex = 19;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(378, 139);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 18;
            this.lblDescricao.Text = "Descrição";
            // 
            // cboGrupoAtivo
            // 
            this.cboGrupoAtivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGrupoAtivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoAtivo.DropDownWidth = 170;
            this.cboGrupoAtivo.FormattingEnabled = true;
            this.cboGrupoAtivo.Location = new System.Drawing.Point(26, 207);
            this.cboGrupoAtivo.Name = "cboGrupoAtivo";
            this.cboGrupoAtivo.Size = new System.Drawing.Size(170, 21);
            this.cboGrupoAtivo.TabIndex = 23;
            this.cboGrupoAtivo.Tag = "1";
            // 
            // lblGrupoAtivo
            // 
            this.lblGrupoAtivo.AutoSize = true;
            this.lblGrupoAtivo.Location = new System.Drawing.Point(23, 191);
            this.lblGrupoAtivo.Name = "lblGrupoAtivo";
            this.lblGrupoAtivo.Size = new System.Drawing.Size(63, 13);
            this.lblGrupoAtivo.TabIndex = 22;
            this.lblGrupoAtivo.Text = "Grupo Ativo";
            // 
            // txtNumeroFisico
            // 
            this.txtNumeroFisico.Location = new System.Drawing.Point(209, 207);
            this.txtNumeroFisico.MaxLength = 100;
            this.txtNumeroFisico.Name = "txtNumeroFisico";
            this.txtNumeroFisico.Size = new System.Drawing.Size(324, 20);
            this.txtNumeroFisico.TabIndex = 25;
            this.txtNumeroFisico.Tag = "1";
            // 
            // lblNumeroFisico
            // 
            this.lblNumeroFisico.AutoSize = true;
            this.lblNumeroFisico.Location = new System.Drawing.Point(206, 191);
            this.lblNumeroFisico.Name = "lblNumeroFisico";
            this.lblNumeroFisico.Size = new System.Drawing.Size(76, 13);
            this.lblNumeroFisico.TabIndex = 24;
            this.lblNumeroFisico.Text = "Número Físico";
            // 
            // cboTipo
            // 
            this.cboTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipo.DropDownWidth = 170;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(553, 207);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(170, 21);
            this.cboTipo.TabIndex = 27;
            this.cboTipo.Tag = "1";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(550, 191);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 26;
            this.lblTipo.Text = "Tipo";
            // 
            // cboTipoPropriedade
            // 
            this.cboTipoPropriedade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTipoPropriedade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoPropriedade.DropDownWidth = 170;
            this.cboTipoPropriedade.FormattingEnabled = true;
            this.cboTipoPropriedade.Location = new System.Drawing.Point(26, 256);
            this.cboTipoPropriedade.Name = "cboTipoPropriedade";
            this.cboTipoPropriedade.Size = new System.Drawing.Size(170, 21);
            this.cboTipoPropriedade.TabIndex = 29;
            this.cboTipoPropriedade.Tag = "1";
            // 
            // lblTipoPropriedade
            // 
            this.lblTipoPropriedade.AutoSize = true;
            this.lblTipoPropriedade.Location = new System.Drawing.Point(23, 240);
            this.lblTipoPropriedade.Name = "lblTipoPropriedade";
            this.lblTipoPropriedade.Size = new System.Drawing.Size(103, 13);
            this.lblTipoPropriedade.TabIndex = 28;
            this.lblTipoPropriedade.Text = "Tipo de Propriedade";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(209, 256);
            this.txtMarca.MaxLength = 20;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(170, 20);
            this.txtMarca.TabIndex = 31;
            this.txtMarca.Tag = "1";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(206, 240);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(37, 13);
            this.lblMarca.TabIndex = 30;
            this.lblMarca.Text = "Marca";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(392, 256);
            this.txtModelo.MaxLength = 30;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(189, 20);
            this.txtModelo.TabIndex = 33;
            this.txtModelo.Tag = "1";
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(389, 240);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(42, 13);
            this.lblModelo.TabIndex = 32;
            this.lblModelo.Text = "Modelo";
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(594, 256);
            this.txtAno.MaxLength = 4;
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(69, 20);
            this.txtAno.TabIndex = 35;
            this.txtAno.Tag = "1";
            this.txtAno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAno_KeyPress);
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.Location = new System.Drawing.Point(591, 240);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(26, 13);
            this.lblAno.TabIndex = 34;
            this.lblAno.Text = "Ano";
            // 
            // txtNumeroSerie
            // 
            this.txtNumeroSerie.Location = new System.Drawing.Point(26, 305);
            this.txtNumeroSerie.MaxLength = 255;
            this.txtNumeroSerie.Name = "txtNumeroSerie";
            this.txtNumeroSerie.Size = new System.Drawing.Size(353, 20);
            this.txtNumeroSerie.TabIndex = 37;
            this.txtNumeroSerie.Tag = "1";
            // 
            // lblNumeroSerie
            // 
            this.lblNumeroSerie.AutoSize = true;
            this.lblNumeroSerie.Location = new System.Drawing.Point(23, 289);
            this.lblNumeroSerie.Name = "lblNumeroSerie";
            this.lblNumeroSerie.Size = new System.Drawing.Size(71, 13);
            this.lblNumeroSerie.TabIndex = 36;
            this.lblNumeroSerie.Text = "Número Série";
            // 
            // lblDataGarantia
            // 
            this.lblDataGarantia.AutoSize = true;
            this.lblDataGarantia.Location = new System.Drawing.Point(389, 289);
            this.lblDataGarantia.Name = "lblDataGarantia";
            this.lblDataGarantia.Size = new System.Drawing.Size(73, 13);
            this.lblDataGarantia.TabIndex = 38;
            this.lblDataGarantia.Text = "Data Garantia";
            // 
            // dtpDataGarantia
            // 
            this.dtpDataGarantia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataGarantia.Location = new System.Drawing.Point(392, 305);
            this.dtpDataGarantia.Name = "dtpDataGarantia";
            this.dtpDataGarantia.ShowCheckBox = true;
            this.dtpDataGarantia.Size = new System.Drawing.Size(145, 20);
            this.dtpDataGarantia.TabIndex = 39;
            this.dtpDataGarantia.Tag = "1";
            this.dtpDataGarantia.ValueChanged += new System.EventHandler(this.dtpDataGarantia_ValueChanged);
            // 
            // txtApolice
            // 
            this.txtApolice.Location = new System.Drawing.Point(26, 355);
            this.txtApolice.MaxLength = 255;
            this.txtApolice.Name = "txtApolice";
            this.txtApolice.Size = new System.Drawing.Size(353, 20);
            this.txtApolice.TabIndex = 41;
            this.txtApolice.Tag = "1";
            // 
            // lblApolice
            // 
            this.lblApolice.AutoSize = true;
            this.lblApolice.Location = new System.Drawing.Point(23, 339);
            this.lblApolice.Name = "lblApolice";
            this.lblApolice.Size = new System.Drawing.Size(42, 13);
            this.lblApolice.TabIndex = 40;
            this.lblApolice.Text = "Apólice";
            // 
            // lblDataApolice
            // 
            this.lblDataApolice.AutoSize = true;
            this.lblDataApolice.Location = new System.Drawing.Point(389, 339);
            this.lblDataApolice.Name = "lblDataApolice";
            this.lblDataApolice.Size = new System.Drawing.Size(68, 13);
            this.lblDataApolice.TabIndex = 42;
            this.lblDataApolice.Text = "Data Apólice";
            // 
            // dtpDataApolice
            // 
            this.dtpDataApolice.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataApolice.Location = new System.Drawing.Point(392, 355);
            this.dtpDataApolice.Name = "dtpDataApolice";
            this.dtpDataApolice.ShowCheckBox = true;
            this.dtpDataApolice.Size = new System.Drawing.Size(145, 20);
            this.dtpDataApolice.TabIndex = 43;
            this.dtpDataApolice.Tag = "1";
            this.dtpDataApolice.ValueChanged += new System.EventHandler(this.dtpDataApolice_ValueChanged);
            // 
            // txtValorSegurado
            // 
            this.txtValorSegurado.Location = new System.Drawing.Point(550, 355);
            this.txtValorSegurado.MaxLength = 10;
            this.txtValorSegurado.Name = "txtValorSegurado";
            this.txtValorSegurado.Size = new System.Drawing.Size(173, 20);
            this.txtValorSegurado.TabIndex = 45;
            this.txtValorSegurado.Tag = "3";
            this.txtValorSegurado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorSegurado_KeyPress);
            // 
            // lblValorSegurado
            // 
            this.lblValorSegurado.AutoSize = true;
            this.lblValorSegurado.Location = new System.Drawing.Point(550, 339);
            this.lblValorSegurado.Name = "lblValorSegurado";
            this.lblValorSegurado.Size = new System.Drawing.Size(80, 13);
            this.lblValorSegurado.TabIndex = 44;
            this.lblValorSegurado.Text = "Valor Segurado";
            // 
            // cboFuncionario
            // 
            this.cboFuncionario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFuncionario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFuncionario.DropDownWidth = 170;
            this.cboFuncionario.FormattingEnabled = true;
            this.cboFuncionario.Location = new System.Drawing.Point(26, 404);
            this.cboFuncionario.Name = "cboFuncionario";
            this.cboFuncionario.Size = new System.Drawing.Size(353, 21);
            this.cboFuncionario.TabIndex = 47;
            this.cboFuncionario.Tag = "1";
            // 
            // lblFuncionario
            // 
            this.lblFuncionario.AutoSize = true;
            this.lblFuncionario.Location = new System.Drawing.Point(23, 388);
            this.lblFuncionario.Name = "lblFuncionario";
            this.lblFuncionario.Size = new System.Drawing.Size(62, 13);
            this.lblFuncionario.TabIndex = 46;
            this.lblFuncionario.Text = "Funcionário";
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Location = new System.Drawing.Point(26, 453);
            this.txtCodigoBarras.MaxLength = 200;
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(697, 20);
            this.txtCodigoBarras.TabIndex = 49;
            this.txtCodigoBarras.Tag = "1";
            // 
            // lblCodigoBarras
            // 
            this.lblCodigoBarras.AutoSize = true;
            this.lblCodigoBarras.Location = new System.Drawing.Point(23, 437);
            this.lblCodigoBarras.Name = "lblCodigoBarras";
            this.lblCodigoBarras.Size = new System.Drawing.Size(88, 13);
            this.lblCodigoBarras.TabIndex = 48;
            this.lblCodigoBarras.Text = "Código de Barras";
            // 
            // chkAtivoNaoLocalizado
            // 
            this.chkAtivoNaoLocalizado.AutoSize = true;
            this.chkAtivoNaoLocalizado.Location = new System.Drawing.Point(392, 404);
            this.chkAtivoNaoLocalizado.Name = "chkAtivoNaoLocalizado";
            this.chkAtivoNaoLocalizado.Size = new System.Drawing.Size(127, 17);
            this.chkAtivoNaoLocalizado.TabIndex = 50;
            this.chkAtivoNaoLocalizado.Text = "Ativo Não Localizado";
            this.chkAtivoNaoLocalizado.UseVisualStyleBackColor = true;
            // 
            // frmAtivoImobilizadoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(731, 475);
            this.Controls.Add(this.chkAtivoNaoLocalizado);
            this.Controls.Add(this.txtCodigoBarras);
            this.Controls.Add(this.lblCodigoBarras);
            this.Controls.Add(this.cboFuncionario);
            this.Controls.Add(this.lblFuncionario);
            this.Controls.Add(this.txtValorSegurado);
            this.Controls.Add(this.lblValorSegurado);
            this.Controls.Add(this.lblDataApolice);
            this.Controls.Add(this.dtpDataApolice);
            this.Controls.Add(this.txtApolice);
            this.Controls.Add(this.lblApolice);
            this.Controls.Add(this.lblDataGarantia);
            this.Controls.Add(this.dtpDataGarantia);
            this.Controls.Add(this.txtNumeroSerie);
            this.Controls.Add(this.lblNumeroSerie);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.lblAno);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.cboTipoPropriedade);
            this.Controls.Add(this.lblTipoPropriedade);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtNumeroFisico);
            this.Controls.Add(this.lblNumeroFisico);
            this.Controls.Add(this.cboGrupoAtivo);
            this.Controls.Add(this.lblGrupoAtivo);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmAtivoImobilizadoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmAtivoImobilizadoCad";
            this.Text = "Cadastro Ativo Imobilizado";
            this.Load += new System.EventHandler(this.frmAtivoImobilizadoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAtivoImobilizadoCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.ComboBox cboGrupoAtivo;
        private System.Windows.Forms.Label lblGrupoAtivo;
        private System.Windows.Forms.TextBox txtNumeroFisico;
        private System.Windows.Forms.Label lblNumeroFisico;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboTipoPropriedade;
        private System.Windows.Forms.Label lblTipoPropriedade;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.TextBox txtNumeroSerie;
        private System.Windows.Forms.Label lblNumeroSerie;
        private System.Windows.Forms.Label lblDataGarantia;
        private System.Windows.Forms.DateTimePicker dtpDataGarantia;
        private System.Windows.Forms.TextBox txtApolice;
        private System.Windows.Forms.Label lblApolice;
        private System.Windows.Forms.Label lblDataApolice;
        private System.Windows.Forms.DateTimePicker dtpDataApolice;
        private System.Windows.Forms.TextBox txtValorSegurado;
        private System.Windows.Forms.Label lblValorSegurado;
        private System.Windows.Forms.ComboBox cboFuncionario;
        private System.Windows.Forms.Label lblFuncionario;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.Label lblCodigoBarras;
        private System.Windows.Forms.CheckBox chkAtivoNaoLocalizado;
    }
}