namespace ERP
{
    partial class frmLocalizacaoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocalizacaoCad));
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
            this.lblDeposito = new System.Windows.Forms.Label();
            this.cboDeposito = new System.Windows.Forms.ComboBox();
            this.lblCorredor = new System.Windows.Forms.Label();
            this.cboCorredor = new System.Windows.Forms.ComboBox();
            this.lblTipoLocalizacao = new System.Windows.Forms.Label();
            this.cboTipoLocalizacao = new System.Windows.Forms.ComboBox();
            this.txtRack = new System.Windows.Forms.TextBox();
            this.lblRack = new System.Windows.Forms.Label();
            this.txtPrateleira = new System.Windows.Forms.TextBox();
            this.lblPrateleira = new System.Windows.Forms.Label();
            this.txtLocalizacao = new System.Windows.Forms.TextBox();
            this.lblLocalizacao = new System.Windows.Forms.Label();
            this.txtMaxPaletes = new System.Windows.Forms.TextBox();
            this.lblMaxPaletes = new System.Windows.Forms.Label();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.lblAltura = new System.Windows.Forms.Label();
            this.txtLargura = new System.Windows.Forms.TextBox();
            this.lblLargura = new System.Windows.Forms.Label();
            this.txtProfundidade = new System.Windows.Forms.TextBox();
            this.lblProfundidade = new System.Windows.Forms.Label();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.lblVolume = new System.Windows.Forms.Label();
            this.txtAlturaAbsoluta = new System.Windows.Forms.TextBox();
            this.lblAlturaAbsoluta = new System.Windows.Forms.Label();
            this.txtPesoMaximo = new System.Windows.Forms.TextBox();
            this.lblPesoMaximo = new System.Windows.Forms.Label();
            this.txtVolumeMaximo = new System.Windows.Forms.TextBox();
            this.lblVolumeMaximo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(28, 151);
            this.txtNome.MaxLength = 200;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(339, 20);
            this.txtNome.TabIndex = 15;
            this.txtNome.Tag = "1";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(25, 135);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 14;
            this.lblNome.Text = "Nome";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(357, 135);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 13;
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
            this.ribbon1.Size = new System.Drawing.Size(409, 125);
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // lblDeposito
            // 
            this.lblDeposito.AutoSize = true;
            this.lblDeposito.Location = new System.Drawing.Point(25, 174);
            this.lblDeposito.Name = "lblDeposito";
            this.lblDeposito.Size = new System.Drawing.Size(49, 13);
            this.lblDeposito.TabIndex = 16;
            this.lblDeposito.Text = "Depósito";
            // 
            // cboDeposito
            // 
            this.cboDeposito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDeposito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDeposito.FormattingEnabled = true;
            this.cboDeposito.Location = new System.Drawing.Point(28, 190);
            this.cboDeposito.Name = "cboDeposito";
            this.cboDeposito.Size = new System.Drawing.Size(267, 21);
            this.cboDeposito.TabIndex = 17;
            this.cboDeposito.Tag = "1";
            // 
            // lblCorredor
            // 
            this.lblCorredor.AutoSize = true;
            this.lblCorredor.Location = new System.Drawing.Point(25, 214);
            this.lblCorredor.Name = "lblCorredor";
            this.lblCorredor.Size = new System.Drawing.Size(47, 13);
            this.lblCorredor.TabIndex = 18;
            this.lblCorredor.Text = "Corredor";
            // 
            // cboCorredor
            // 
            this.cboCorredor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCorredor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCorredor.FormattingEnabled = true;
            this.cboCorredor.Location = new System.Drawing.Point(28, 230);
            this.cboCorredor.Name = "cboCorredor";
            this.cboCorredor.Size = new System.Drawing.Size(267, 21);
            this.cboCorredor.TabIndex = 19;
            this.cboCorredor.Tag = "1";
            // 
            // lblTipoLocalizacao
            // 
            this.lblTipoLocalizacao.AutoSize = true;
            this.lblTipoLocalizacao.Location = new System.Drawing.Point(27, 254);
            this.lblTipoLocalizacao.Name = "lblTipoLocalizacao";
            this.lblTipoLocalizacao.Size = new System.Drawing.Size(103, 13);
            this.lblTipoLocalizacao.TabIndex = 20;
            this.lblTipoLocalizacao.Text = "Tipo de Localização";
            // 
            // cboTipoLocalizacao
            // 
            this.cboTipoLocalizacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTipoLocalizacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoLocalizacao.FormattingEnabled = true;
            this.cboTipoLocalizacao.Location = new System.Drawing.Point(30, 270);
            this.cboTipoLocalizacao.Name = "cboTipoLocalizacao";
            this.cboTipoLocalizacao.Size = new System.Drawing.Size(267, 21);
            this.cboTipoLocalizacao.TabIndex = 21;
            this.cboTipoLocalizacao.Tag = "1";
            // 
            // txtRack
            // 
            this.txtRack.Location = new System.Drawing.Point(30, 310);
            this.txtRack.MaxLength = 3;
            this.txtRack.Name = "txtRack";
            this.txtRack.Size = new System.Drawing.Size(105, 20);
            this.txtRack.TabIndex = 23;
            this.txtRack.Tag = "1";
            this.txtRack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRack_KeyPress);
            // 
            // lblRack
            // 
            this.lblRack.AutoSize = true;
            this.lblRack.Location = new System.Drawing.Point(27, 294);
            this.lblRack.Name = "lblRack";
            this.lblRack.Size = new System.Drawing.Size(33, 13);
            this.lblRack.TabIndex = 22;
            this.lblRack.Text = "Rack";
            // 
            // txtPrateleira
            // 
            this.txtPrateleira.Location = new System.Drawing.Point(148, 310);
            this.txtPrateleira.MaxLength = 3;
            this.txtPrateleira.Name = "txtPrateleira";
            this.txtPrateleira.Size = new System.Drawing.Size(105, 20);
            this.txtPrateleira.TabIndex = 25;
            this.txtPrateleira.Tag = "1";
            this.txtPrateleira.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrateleira_KeyPress);
            // 
            // lblPrateleira
            // 
            this.lblPrateleira.AutoSize = true;
            this.lblPrateleira.Location = new System.Drawing.Point(145, 294);
            this.lblPrateleira.Name = "lblPrateleira";
            this.lblPrateleira.Size = new System.Drawing.Size(51, 13);
            this.lblPrateleira.TabIndex = 24;
            this.lblPrateleira.Text = "Prateleira";
            // 
            // txtLocalizacao
            // 
            this.txtLocalizacao.Location = new System.Drawing.Point(30, 349);
            this.txtLocalizacao.MaxLength = 3;
            this.txtLocalizacao.Name = "txtLocalizacao";
            this.txtLocalizacao.Size = new System.Drawing.Size(105, 20);
            this.txtLocalizacao.TabIndex = 27;
            this.txtLocalizacao.Tag = "1";
            this.txtLocalizacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLocalizacao_KeyPress);
            // 
            // lblLocalizacao
            // 
            this.lblLocalizacao.AutoSize = true;
            this.lblLocalizacao.Location = new System.Drawing.Point(27, 333);
            this.lblLocalizacao.Name = "lblLocalizacao";
            this.lblLocalizacao.Size = new System.Drawing.Size(64, 13);
            this.lblLocalizacao.TabIndex = 26;
            this.lblLocalizacao.Text = "Localização";
            // 
            // txtMaxPaletes
            // 
            this.txtMaxPaletes.Location = new System.Drawing.Point(148, 349);
            this.txtMaxPaletes.MaxLength = 3;
            this.txtMaxPaletes.Name = "txtMaxPaletes";
            this.txtMaxPaletes.Size = new System.Drawing.Size(105, 20);
            this.txtMaxPaletes.TabIndex = 29;
            this.txtMaxPaletes.Tag = "1";
            this.txtMaxPaletes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxPaletes_KeyPress);
            // 
            // lblMaxPaletes
            // 
            this.lblMaxPaletes.AutoSize = true;
            this.lblMaxPaletes.Location = new System.Drawing.Point(145, 333);
            this.lblMaxPaletes.Name = "lblMaxPaletes";
            this.lblMaxPaletes.Size = new System.Drawing.Size(96, 13);
            this.lblMaxPaletes.TabIndex = 28;
            this.lblMaxPaletes.Text = "Máximo de Paletes";
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(30, 388);
            this.txtAltura.MaxLength = 10;
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(166, 20);
            this.txtAltura.TabIndex = 31;
            this.txtAltura.Tag = "3";
            this.txtAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAltura_KeyPress);
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(27, 372);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(34, 13);
            this.lblAltura.TabIndex = 30;
            this.lblAltura.Text = "Altura";
            // 
            // txtLargura
            // 
            this.txtLargura.Location = new System.Drawing.Point(201, 388);
            this.txtLargura.MaxLength = 10;
            this.txtLargura.Name = "txtLargura";
            this.txtLargura.Size = new System.Drawing.Size(166, 20);
            this.txtLargura.TabIndex = 33;
            this.txtLargura.Tag = "3";
            this.txtLargura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLargura_KeyPress);
            // 
            // lblLargura
            // 
            this.lblLargura.AutoSize = true;
            this.lblLargura.Location = new System.Drawing.Point(198, 372);
            this.lblLargura.Name = "lblLargura";
            this.lblLargura.Size = new System.Drawing.Size(43, 13);
            this.lblLargura.TabIndex = 32;
            this.lblLargura.Text = "Largura";
            // 
            // txtProfundidade
            // 
            this.txtProfundidade.Location = new System.Drawing.Point(28, 427);
            this.txtProfundidade.MaxLength = 10;
            this.txtProfundidade.Name = "txtProfundidade";
            this.txtProfundidade.Size = new System.Drawing.Size(166, 20);
            this.txtProfundidade.TabIndex = 35;
            this.txtProfundidade.Tag = "3";
            this.txtProfundidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProfundidade_KeyPress);
            // 
            // lblProfundidade
            // 
            this.lblProfundidade.AutoSize = true;
            this.lblProfundidade.Location = new System.Drawing.Point(25, 411);
            this.lblProfundidade.Name = "lblProfundidade";
            this.lblProfundidade.Size = new System.Drawing.Size(70, 13);
            this.lblProfundidade.TabIndex = 34;
            this.lblProfundidade.Text = "Profundidade";
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(201, 427);
            this.txtVolume.MaxLength = 10;
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(166, 20);
            this.txtVolume.TabIndex = 37;
            this.txtVolume.Tag = "3";
            this.txtVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVolume_KeyPress);
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(198, 411);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(42, 13);
            this.lblVolume.TabIndex = 36;
            this.lblVolume.Text = "Volume";
            // 
            // txtAlturaAbsoluta
            // 
            this.txtAlturaAbsoluta.Location = new System.Drawing.Point(28, 466);
            this.txtAlturaAbsoluta.MaxLength = 10;
            this.txtAlturaAbsoluta.Name = "txtAlturaAbsoluta";
            this.txtAlturaAbsoluta.Size = new System.Drawing.Size(166, 20);
            this.txtAlturaAbsoluta.TabIndex = 39;
            this.txtAlturaAbsoluta.Tag = "3";
            this.txtAlturaAbsoluta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlturaAbsoluta_KeyPress);
            // 
            // lblAlturaAbsoluta
            // 
            this.lblAlturaAbsoluta.AutoSize = true;
            this.lblAlturaAbsoluta.Location = new System.Drawing.Point(25, 450);
            this.lblAlturaAbsoluta.Name = "lblAlturaAbsoluta";
            this.lblAlturaAbsoluta.Size = new System.Drawing.Size(78, 13);
            this.lblAlturaAbsoluta.TabIndex = 38;
            this.lblAlturaAbsoluta.Text = "Altura Absoluta";
            // 
            // txtPesoMaximo
            // 
            this.txtPesoMaximo.Location = new System.Drawing.Point(201, 466);
            this.txtPesoMaximo.MaxLength = 10;
            this.txtPesoMaximo.Name = "txtPesoMaximo";
            this.txtPesoMaximo.Size = new System.Drawing.Size(166, 20);
            this.txtPesoMaximo.TabIndex = 41;
            this.txtPesoMaximo.Tag = "3";
            this.txtPesoMaximo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPesoMaximo_KeyPress);
            // 
            // lblPesoMaximo
            // 
            this.lblPesoMaximo.AutoSize = true;
            this.lblPesoMaximo.Location = new System.Drawing.Point(198, 450);
            this.lblPesoMaximo.Name = "lblPesoMaximo";
            this.lblPesoMaximo.Size = new System.Drawing.Size(70, 13);
            this.lblPesoMaximo.TabIndex = 40;
            this.lblPesoMaximo.Text = "Peso Máximo";
            // 
            // txtVolumeMaximo
            // 
            this.txtVolumeMaximo.Location = new System.Drawing.Point(28, 505);
            this.txtVolumeMaximo.MaxLength = 10;
            this.txtVolumeMaximo.Name = "txtVolumeMaximo";
            this.txtVolumeMaximo.Size = new System.Drawing.Size(166, 20);
            this.txtVolumeMaximo.TabIndex = 43;
            this.txtVolumeMaximo.Tag = "3";
            this.txtVolumeMaximo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVolumeMaximo_KeyPress);
            // 
            // lblVolumeMaximo
            // 
            this.lblVolumeMaximo.AutoSize = true;
            this.lblVolumeMaximo.Location = new System.Drawing.Point(25, 489);
            this.lblVolumeMaximo.Name = "lblVolumeMaximo";
            this.lblVolumeMaximo.Size = new System.Drawing.Size(81, 13);
            this.lblVolumeMaximo.TabIndex = 42;
            this.lblVolumeMaximo.Text = "Volume Máximo";
            // 
            // frmLocalizacaoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(409, 556);
            this.Controls.Add(this.txtVolumeMaximo);
            this.Controls.Add(this.lblVolumeMaximo);
            this.Controls.Add(this.txtPesoMaximo);
            this.Controls.Add(this.lblPesoMaximo);
            this.Controls.Add(this.txtAlturaAbsoluta);
            this.Controls.Add(this.lblAlturaAbsoluta);
            this.Controls.Add(this.txtVolume);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.txtProfundidade);
            this.Controls.Add(this.lblProfundidade);
            this.Controls.Add(this.txtLargura);
            this.Controls.Add(this.lblLargura);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.txtMaxPaletes);
            this.Controls.Add(this.lblMaxPaletes);
            this.Controls.Add(this.txtLocalizacao);
            this.Controls.Add(this.lblLocalizacao);
            this.Controls.Add(this.txtPrateleira);
            this.Controls.Add(this.lblPrateleira);
            this.Controls.Add(this.txtRack);
            this.Controls.Add(this.lblRack);
            this.Controls.Add(this.lblTipoLocalizacao);
            this.Controls.Add(this.cboTipoLocalizacao);
            this.Controls.Add(this.lblCorredor);
            this.Controls.Add(this.cboCorredor);
            this.Controls.Add(this.lblDeposito);
            this.Controls.Add(this.cboDeposito);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmLocalizacaoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "frmLocalizacaoCad";
            this.Text = "Cadastro de Localização";
            this.Load += new System.EventHandler(this.frmLocalizacaoCad_Load);
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
        private System.Windows.Forms.Label lblDeposito;
        private System.Windows.Forms.ComboBox cboDeposito;
        private System.Windows.Forms.Label lblCorredor;
        private System.Windows.Forms.ComboBox cboCorredor;
        private System.Windows.Forms.Label lblTipoLocalizacao;
        private System.Windows.Forms.ComboBox cboTipoLocalizacao;
        private System.Windows.Forms.TextBox txtRack;
        private System.Windows.Forms.Label lblRack;
        private System.Windows.Forms.TextBox txtPrateleira;
        private System.Windows.Forms.Label lblPrateleira;
        private System.Windows.Forms.TextBox txtLocalizacao;
        private System.Windows.Forms.Label lblLocalizacao;
        private System.Windows.Forms.TextBox txtMaxPaletes;
        private System.Windows.Forms.Label lblMaxPaletes;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.TextBox txtLargura;
        private System.Windows.Forms.Label lblLargura;
        private System.Windows.Forms.TextBox txtProfundidade;
        private System.Windows.Forms.Label lblProfundidade;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.TextBox txtAlturaAbsoluta;
        private System.Windows.Forms.Label lblAlturaAbsoluta;
        private System.Windows.Forms.TextBox txtPesoMaximo;
        private System.Windows.Forms.Label lblPesoMaximo;
        private System.Windows.Forms.TextBox txtVolumeMaximo;
        private System.Windows.Forms.Label lblVolumeMaximo;
    }
}