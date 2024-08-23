namespace ERP
{
    partial class frmConfGrupoImpostoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfGrupoImpostoCad));
            this.lbCodigo = new System.Windows.Forms.Label();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.lblCodigoTributacao = new System.Windows.Forms.Label();
            this.cboCodigoTributacao = new System.Windows.Forms.ComboBox();
            this.chkIsento = new System.Windows.Forms.CheckBox();
            this.chkImpostoSobreUso = new System.Windows.Forms.CheckBox();
            this.lblCodigoIsencao = new System.Windows.Forms.Label();
            this.cboCodigoIsencao = new System.Windows.Forms.ComboBox();
            this.lblPercentualValor = new System.Windows.Forms.Label();
            this.cboCodigoImposto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPercentual = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(418, 144);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 15;
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
            this.ribbonPanel2.Items.Add(this.ribbonButton1);
            this.ribbonPanel2.Items.Add(this.ribbonButton2);
            this.ribbonPanel2.Items.Add(this.ribbonButton3);
            this.ribbonPanel2.Text = "Cadastrar";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = global::ERP.Properties.Resources.File_New_icon;
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "Código Imposto";
            this.ribbonButton1.Click += new System.EventHandler(this.ribbonButton1_Click);
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = global::ERP.Properties.Resources.File_New_icon;
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "Código Isenção";
            this.ribbonButton2.Click += new System.EventHandler(this.ribbonButton2_Click);
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = global::ERP.Properties.Resources.File_New_icon;
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "Código Tributação";
            this.ribbonButton3.Click += new System.EventHandler(this.ribbonButton3_Click);
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
            this.ribbon1.Size = new System.Drawing.Size(519, 141);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // lblCodigoTributacao
            // 
            this.lblCodigoTributacao.AutoSize = true;
            this.lblCodigoTributacao.Location = new System.Drawing.Point(27, 322);
            this.lblCodigoTributacao.Name = "lblCodigoTributacao";
            this.lblCodigoTributacao.Size = new System.Drawing.Size(94, 13);
            this.lblCodigoTributacao.TabIndex = 20;
            this.lblCodigoTributacao.Text = "Código Tributação";
            // 
            // cboCodigoTributacao
            // 
            this.cboCodigoTributacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCodigoTributacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCodigoTributacao.FormattingEnabled = true;
            this.cboCodigoTributacao.Location = new System.Drawing.Point(30, 341);
            this.cboCodigoTributacao.Name = "cboCodigoTributacao";
            this.cboCodigoTributacao.Size = new System.Drawing.Size(448, 21);
            this.cboCodigoTributacao.TabIndex = 21;
            this.cboCodigoTributacao.Tag = "1";
            // 
            // chkIsento
            // 
            this.chkIsento.AutoSize = true;
            this.chkIsento.Location = new System.Drawing.Point(30, 243);
            this.chkIsento.Name = "chkIsento";
            this.chkIsento.Size = new System.Drawing.Size(55, 17);
            this.chkIsento.TabIndex = 23;
            this.chkIsento.Text = "Isento";
            this.chkIsento.UseVisualStyleBackColor = true;
            // 
            // chkImpostoSobreUso
            // 
            this.chkImpostoSobreUso.AutoSize = true;
            this.chkImpostoSobreUso.Location = new System.Drawing.Point(30, 220);
            this.chkImpostoSobreUso.Name = "chkImpostoSobreUso";
            this.chkImpostoSobreUso.Size = new System.Drawing.Size(114, 17);
            this.chkImpostoSobreUso.TabIndex = 22;
            this.chkImpostoSobreUso.Text = "Imposto sobre Uso";
            this.chkImpostoSobreUso.UseVisualStyleBackColor = true;
            // 
            // lblCodigoIsencao
            // 
            this.lblCodigoIsencao.AutoSize = true;
            this.lblCodigoIsencao.Location = new System.Drawing.Point(27, 269);
            this.lblCodigoIsencao.Name = "lblCodigoIsencao";
            this.lblCodigoIsencao.Size = new System.Drawing.Size(81, 13);
            this.lblCodigoIsencao.TabIndex = 26;
            this.lblCodigoIsencao.Text = "Código Isenção";
            // 
            // cboCodigoIsencao
            // 
            this.cboCodigoIsencao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCodigoIsencao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCodigoIsencao.FormattingEnabled = true;
            this.cboCodigoIsencao.Location = new System.Drawing.Point(30, 288);
            this.cboCodigoIsencao.Name = "cboCodigoIsencao";
            this.cboCodigoIsencao.Size = new System.Drawing.Size(448, 21);
            this.cboCodigoIsencao.TabIndex = 27;
            this.cboCodigoIsencao.Tag = "";
            // 
            // lblPercentualValor
            // 
            this.lblPercentualValor.AutoSize = true;
            this.lblPercentualValor.Location = new System.Drawing.Point(27, 380);
            this.lblPercentualValor.Name = "lblPercentualValor";
            this.lblPercentualValor.Size = new System.Drawing.Size(85, 13);
            this.lblPercentualValor.TabIndex = 24;
            this.lblPercentualValor.Text = "Percentual Valor";
            // 
            // cboCodigoImposto
            // 
            this.cboCodigoImposto.FormattingEnabled = true;
            this.cboCodigoImposto.Location = new System.Drawing.Point(30, 180);
            this.cboCodigoImposto.Name = "cboCodigoImposto";
            this.cboCodigoImposto.Size = new System.Drawing.Size(448, 21);
            this.cboCodigoImposto.TabIndex = 28;
            this.cboCodigoImposto.Tag = "1";
            this.cboCodigoImposto.Leave += new System.EventHandler(this.cboCodigoImposto_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Código de Impostos";
            // 
            // txtPercentual
            // 
            this.txtPercentual.Location = new System.Drawing.Point(30, 396);
            this.txtPercentual.Name = "txtPercentual";
            this.txtPercentual.Size = new System.Drawing.Size(114, 20);
            this.txtPercentual.TabIndex = 30;
            this.txtPercentual.Tag = "1";
            this.txtPercentual.Text = "0,0000";
            // 
            // frmConfGrupoImpostoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(519, 468);
            this.Controls.Add(this.txtPercentual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCodigoImposto);
            this.Controls.Add(this.lblPercentualValor);
            this.Controls.Add(this.lblCodigoIsencao);
            this.Controls.Add(this.cboCodigoIsencao);
            this.Controls.Add(this.chkImpostoSobreUso);
            this.Controls.Add(this.chkIsento);
            this.Controls.Add(this.lblCodigoTributacao);
            this.Controls.Add(this.cboCodigoTributacao);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmConfGrupoImpostoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmConfGrupoImpostoCad";
            this.Text = "Cadastro Conf. Grupo Imposto";
            this.Load += new System.EventHandler(this.frmConfGrupoImpostoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConfGrupoImpostoCad_KeyDown);
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
        private System.Windows.Forms.Label lblCodigoTributacao;
        private System.Windows.Forms.ComboBox cboCodigoTributacao;
        private System.Windows.Forms.CheckBox chkIsento;
        private System.Windows.Forms.CheckBox chkImpostoSobreUso;
        private System.Windows.Forms.Label lblCodigoIsencao;
        private System.Windows.Forms.ComboBox cboCodigoIsencao;
        private System.Windows.Forms.Label lblPercentualValor;
        private System.Windows.Forms.ComboBox cboCodigoImposto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPercentual;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonButton ribbonButton3;
    }
}