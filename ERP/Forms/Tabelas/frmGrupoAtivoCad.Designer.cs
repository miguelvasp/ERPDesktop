namespace ERP
{
    partial class frmGrupoAtivoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoAtivoCad));
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
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
            this.lblTipo = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.txtSequenciaNumerica = new System.Windows.Forms.TextBox();
            this.lblSequenciaNumerica = new System.Windows.Forms.Label();
            this.chkNumerarCodigoBarras = new System.Windows.Forms.CheckBox();
            this.txtSequenciaNumericaCodigoBarras = new System.Windows.Forms.TextBox();
            this.lblSequenciaNumericaCodigoBarras = new System.Windows.Forms.Label();
            this.lblTipoPropriedade = new System.Windows.Forms.Label();
            this.cboTipoPropriedade = new System.Windows.Forms.ComboBox();
            this.txtLimiteCapitalizacao = new System.Windows.Forms.TextBox();
            this.lblLimiteCapitalizacao = new System.Windows.Forms.Label();
            this.chkCreditoICMS = new System.Windows.Forms.CheckBox();
            this.chkCreditoPisCofins = new System.Windows.Forms.CheckBox();
            this.txtParcelasDoCredito = new System.Windows.Forms.TextBox();
            this.lblParcelasDoCredito = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.Location = new System.Drawing.Point(18, 155);
            this.txtCodigo.MaxLength = 200;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(355, 20);
            this.txtCodigo.TabIndex = 17;
            this.txtCodigo.Tag = "1";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(24, 139);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 16;
            this.lblCodigo.Text = "Código";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(351, 139);
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
            this.ribbon1.Size = new System.Drawing.Size(395, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.Location = new System.Drawing.Point(18, 205);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(355, 20);
            this.txtDescricao.TabIndex = 19;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(24, 189);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 18;
            this.lblDescricao.Text = "Descrição";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(24, 237);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 22;
            this.lblTipo.Text = "Tipo";
            // 
            // cboTipo
            // 
            this.cboTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(18, 253);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(170, 21);
            this.cboTipo.TabIndex = 23;
            this.cboTipo.Tag = "1";
            // 
            // txtSequenciaNumerica
            // 
            this.txtSequenciaNumerica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSequenciaNumerica.Location = new System.Drawing.Point(194, 253);
            this.txtSequenciaNumerica.MaxLength = 5;
            this.txtSequenciaNumerica.Name = "txtSequenciaNumerica";
            this.txtSequenciaNumerica.Size = new System.Drawing.Size(179, 20);
            this.txtSequenciaNumerica.TabIndex = 25;
            this.txtSequenciaNumerica.Tag = "1";
            // 
            // lblSequenciaNumerica
            // 
            this.lblSequenciaNumerica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSequenciaNumerica.AutoSize = true;
            this.lblSequenciaNumerica.Location = new System.Drawing.Point(203, 237);
            this.lblSequenciaNumerica.Name = "lblSequenciaNumerica";
            this.lblSequenciaNumerica.Size = new System.Drawing.Size(139, 13);
            this.lblSequenciaNumerica.TabIndex = 24;
            this.lblSequenciaNumerica.Text = "Sequencia Numérica (Ativo)";
            // 
            // chkNumerarCodigoBarras
            // 
            this.chkNumerarCodigoBarras.AutoSize = true;
            this.chkNumerarCodigoBarras.Location = new System.Drawing.Point(27, 291);
            this.chkNumerarCodigoBarras.Name = "chkNumerarCodigoBarras";
            this.chkNumerarCodigoBarras.Size = new System.Drawing.Size(150, 17);
            this.chkNumerarCodigoBarras.TabIndex = 27;
            this.chkNumerarCodigoBarras.Text = "Númerar Código de Barras";
            this.chkNumerarCodigoBarras.UseVisualStyleBackColor = true;
            // 
            // txtSequenciaNumericaCodigoBarras
            // 
            this.txtSequenciaNumericaCodigoBarras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSequenciaNumericaCodigoBarras.Location = new System.Drawing.Point(194, 307);
            this.txtSequenciaNumericaCodigoBarras.MaxLength = 10;
            this.txtSequenciaNumericaCodigoBarras.Name = "txtSequenciaNumericaCodigoBarras";
            this.txtSequenciaNumericaCodigoBarras.Size = new System.Drawing.Size(179, 20);
            this.txtSequenciaNumericaCodigoBarras.TabIndex = 29;
            this.txtSequenciaNumericaCodigoBarras.Tag = "1";
            // 
            // lblSequenciaNumericaCodigoBarras
            // 
            this.lblSequenciaNumericaCodigoBarras.AutoSize = true;
            this.lblSequenciaNumericaCodigoBarras.Location = new System.Drawing.Point(203, 291);
            this.lblSequenciaNumericaCodigoBarras.Name = "lblSequenciaNumericaCodigoBarras";
            this.lblSequenciaNumericaCodigoBarras.Size = new System.Drawing.Size(181, 13);
            this.lblSequenciaNumericaCodigoBarras.TabIndex = 28;
            this.lblSequenciaNumericaCodigoBarras.Text = "Sequencia Numérica (Código Barras)";
            // 
            // lblTipoPropriedade
            // 
            this.lblTipoPropriedade.AutoSize = true;
            this.lblTipoPropriedade.Location = new System.Drawing.Point(24, 336);
            this.lblTipoPropriedade.Name = "lblTipoPropriedade";
            this.lblTipoPropriedade.Size = new System.Drawing.Size(103, 13);
            this.lblTipoPropriedade.TabIndex = 30;
            this.lblTipoPropriedade.Text = "Tipo de Propriedade";
            // 
            // cboTipoPropriedade
            // 
            this.cboTipoPropriedade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoPropriedade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTipoPropriedade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoPropriedade.FormattingEnabled = true;
            this.cboTipoPropriedade.Location = new System.Drawing.Point(18, 352);
            this.cboTipoPropriedade.Name = "cboTipoPropriedade";
            this.cboTipoPropriedade.Size = new System.Drawing.Size(170, 21);
            this.cboTipoPropriedade.TabIndex = 31;
            this.cboTipoPropriedade.Tag = "1";
            // 
            // txtLimiteCapitalizacao
            // 
            this.txtLimiteCapitalizacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLimiteCapitalizacao.Location = new System.Drawing.Point(194, 352);
            this.txtLimiteCapitalizacao.MaxLength = 5;
            this.txtLimiteCapitalizacao.Name = "txtLimiteCapitalizacao";
            this.txtLimiteCapitalizacao.Size = new System.Drawing.Size(179, 20);
            this.txtLimiteCapitalizacao.TabIndex = 33;
            this.txtLimiteCapitalizacao.Tag = "1";
            this.txtLimiteCapitalizacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteCapitalizacao_KeyPress);
            // 
            // lblLimiteCapitalizacao
            // 
            this.lblLimiteCapitalizacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLimiteCapitalizacao.AutoSize = true;
            this.lblLimiteCapitalizacao.Location = new System.Drawing.Point(203, 336);
            this.lblLimiteCapitalizacao.Name = "lblLimiteCapitalizacao";
            this.lblLimiteCapitalizacao.Size = new System.Drawing.Size(100, 13);
            this.lblLimiteCapitalizacao.TabIndex = 32;
            this.lblLimiteCapitalizacao.Text = "Limite Capitalização";
            // 
            // chkCreditoICMS
            // 
            this.chkCreditoICMS.AutoSize = true;
            this.chkCreditoICMS.Location = new System.Drawing.Point(27, 388);
            this.chkCreditoICMS.Name = "chkCreditoICMS";
            this.chkCreditoICMS.Size = new System.Drawing.Size(88, 17);
            this.chkCreditoICMS.TabIndex = 34;
            this.chkCreditoICMS.Text = "Crédito ICMS";
            this.chkCreditoICMS.UseVisualStyleBackColor = true;
            // 
            // chkCreditoPisCofins
            // 
            this.chkCreditoPisCofins.AutoSize = true;
            this.chkCreditoPisCofins.Location = new System.Drawing.Point(27, 411);
            this.chkCreditoPisCofins.Name = "chkCreditoPisCofins";
            this.chkCreditoPisCofins.Size = new System.Drawing.Size(110, 17);
            this.chkCreditoPisCofins.TabIndex = 35;
            this.chkCreditoPisCofins.Text = "Crédito Pis/Cofins";
            this.chkCreditoPisCofins.UseVisualStyleBackColor = true;
            // 
            // txtParcelasDoCredito
            // 
            this.txtParcelasDoCredito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParcelasDoCredito.Location = new System.Drawing.Point(194, 404);
            this.txtParcelasDoCredito.MaxLength = 2;
            this.txtParcelasDoCredito.Name = "txtParcelasDoCredito";
            this.txtParcelasDoCredito.Size = new System.Drawing.Size(179, 20);
            this.txtParcelasDoCredito.TabIndex = 37;
            this.txtParcelasDoCredito.Tag = "1";
            this.txtParcelasDoCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParcelasDoCredito_KeyPress);
            // 
            // lblParcelasDoCredito
            // 
            this.lblParcelasDoCredito.AutoSize = true;
            this.lblParcelasDoCredito.Location = new System.Drawing.Point(203, 388);
            this.lblParcelasDoCredito.Name = "lblParcelasDoCredito";
            this.lblParcelasDoCredito.Size = new System.Drawing.Size(99, 13);
            this.lblParcelasDoCredito.TabIndex = 36;
            this.lblParcelasDoCredito.Text = "Parcelas do Crédito";
            // 
            // frmGrupoAtivoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(395, 435);
            this.Controls.Add(this.txtParcelasDoCredito);
            this.Controls.Add(this.lblParcelasDoCredito);
            this.Controls.Add(this.chkCreditoPisCofins);
            this.Controls.Add(this.chkCreditoICMS);
            this.Controls.Add(this.txtLimiteCapitalizacao);
            this.Controls.Add(this.lblLimiteCapitalizacao);
            this.Controls.Add(this.lblTipoPropriedade);
            this.Controls.Add(this.cboTipoPropriedade);
            this.Controls.Add(this.txtSequenciaNumericaCodigoBarras);
            this.Controls.Add(this.lblSequenciaNumericaCodigoBarras);
            this.Controls.Add(this.chkNumerarCodigoBarras);
            this.Controls.Add(this.txtSequenciaNumerica);
            this.Controls.Add(this.lblSequenciaNumerica);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(411, 471);
            this.Name = "frmGrupoAtivoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmGrupoAtivoCad";
            this.Text = "Cadastro Grupo de Ativo";
            this.Load += new System.EventHandler(this.frmGrupoAtivoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGrupoAtivoCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
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
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.TextBox txtSequenciaNumerica;
        private System.Windows.Forms.Label lblSequenciaNumerica;
        private System.Windows.Forms.CheckBox chkNumerarCodigoBarras;
        private System.Windows.Forms.TextBox txtSequenciaNumericaCodigoBarras;
        private System.Windows.Forms.Label lblSequenciaNumericaCodigoBarras;
        private System.Windows.Forms.Label lblTipoPropriedade;
        private System.Windows.Forms.ComboBox cboTipoPropriedade;
        private System.Windows.Forms.TextBox txtLimiteCapitalizacao;
        private System.Windows.Forms.Label lblLimiteCapitalizacao;
        private System.Windows.Forms.CheckBox chkCreditoICMS;
        private System.Windows.Forms.CheckBox chkCreditoPisCofins;
        private System.Windows.Forms.TextBox txtParcelasDoCredito;
        private System.Windows.Forms.Label lblParcelasDoCredito;
    }
}