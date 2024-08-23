namespace ERP
{
    partial class frmValoresImpostoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValoresImpostoCad));
            this.lbCodigo = new System.Windows.Forms.Label();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.lblAte = new System.Windows.Forms.Label();
            this.lblDe = new System.Windows.Forms.Label();
            this.cboCodigoImposto = new System.Windows.Forms.ComboBox();
            this.lblCodigoImposto = new System.Windows.Forms.Label();
            this.txtLimiteMinimo = new System.Windows.Forms.TextBox();
            this.lblLimiteMinimo = new System.Windows.Forms.Label();
            this.txtLimiteMaximo = new System.Windows.Forms.TextBox();
            this.lblLimiteMaximo = new System.Windows.Forms.Label();
            this.txtPercentualIsencao = new System.Windows.Forms.TextBox();
            this.lblPercentualIsencao = new System.Windows.Forms.Label();
            this.txtMarkup = new System.Windows.Forms.TextBox();
            this.lblMarkup = new System.Windows.Forms.Label();
            this.txtPercentualReducao = new System.Windows.Forms.TextBox();
            this.lblPercentualReducao = new System.Windows.Forms.Label();
            this.txtAliquota = new System.Windows.Forms.TextBox();
            this.lblAliquota = new System.Windows.Forms.Label();
            this.txtDe = new System.Windows.Forms.MaskedTextBox();
            this.txtAte = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(359, 144);
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
            this.ribbon1.Size = new System.Drawing.Size(405, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Location = new System.Drawing.Point(210, 196);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(23, 13);
            this.lblAte.TabIndex = 20;
            this.lblAte.Text = "Até";
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(32, 196);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(21, 13);
            this.lblDe.TabIndex = 18;
            this.lblDe.Text = "De";
            // 
            // cboCodigoImposto
            // 
            this.cboCodigoImposto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCodigoImposto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCodigoImposto.FormattingEnabled = true;
            this.cboCodigoImposto.Location = new System.Drawing.Point(35, 160);
            this.cboCodigoImposto.Name = "cboCodigoImposto";
            this.cboCodigoImposto.Size = new System.Drawing.Size(166, 21);
            this.cboCodigoImposto.TabIndex = 17;
            this.cboCodigoImposto.Tag = "1";
            // 
            // lblCodigoImposto
            // 
            this.lblCodigoImposto.AutoSize = true;
            this.lblCodigoImposto.Location = new System.Drawing.Point(32, 144);
            this.lblCodigoImposto.Name = "lblCodigoImposto";
            this.lblCodigoImposto.Size = new System.Drawing.Size(80, 13);
            this.lblCodigoImposto.TabIndex = 16;
            this.lblCodigoImposto.Text = "Código Imposto";
            // 
            // txtLimiteMinimo
            // 
            this.txtLimiteMinimo.Location = new System.Drawing.Point(35, 268);
            this.txtLimiteMinimo.MaxLength = 10;
            this.txtLimiteMinimo.Name = "txtLimiteMinimo";
            this.txtLimiteMinimo.Size = new System.Drawing.Size(166, 20);
            this.txtLimiteMinimo.TabIndex = 23;
            this.txtLimiteMinimo.Tag = "3";
            this.txtLimiteMinimo.Text = "0,0000";
            this.txtLimiteMinimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteMinimo_KeyPress);
            // 
            // lblLimiteMinimo
            // 
            this.lblLimiteMinimo.AutoSize = true;
            this.lblLimiteMinimo.Location = new System.Drawing.Point(32, 248);
            this.lblLimiteMinimo.Name = "lblLimiteMinimo";
            this.lblLimiteMinimo.Size = new System.Drawing.Size(72, 13);
            this.lblLimiteMinimo.TabIndex = 22;
            this.lblLimiteMinimo.Text = "Limite Mínimo";
            // 
            // txtLimiteMaximo
            // 
            this.txtLimiteMaximo.Location = new System.Drawing.Point(213, 268);
            this.txtLimiteMaximo.MaxLength = 10;
            this.txtLimiteMaximo.Name = "txtLimiteMaximo";
            this.txtLimiteMaximo.Size = new System.Drawing.Size(166, 20);
            this.txtLimiteMaximo.TabIndex = 25;
            this.txtLimiteMaximo.Tag = "3";
            this.txtLimiteMaximo.Text = "0,0000";
            this.txtLimiteMaximo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteMaximo_KeyPress);
            // 
            // lblLimiteMaximo
            // 
            this.lblLimiteMaximo.AutoSize = true;
            this.lblLimiteMaximo.Location = new System.Drawing.Point(210, 248);
            this.lblLimiteMaximo.Name = "lblLimiteMaximo";
            this.lblLimiteMaximo.Size = new System.Drawing.Size(73, 13);
            this.lblLimiteMaximo.TabIndex = 24;
            this.lblLimiteMaximo.Text = "Limite Máximo";
            // 
            // txtPercentualIsencao
            // 
            this.txtPercentualIsencao.Location = new System.Drawing.Point(213, 321);
            this.txtPercentualIsencao.MaxLength = 10;
            this.txtPercentualIsencao.Name = "txtPercentualIsencao";
            this.txtPercentualIsencao.Size = new System.Drawing.Size(166, 20);
            this.txtPercentualIsencao.TabIndex = 29;
            this.txtPercentualIsencao.Tag = "3";
            this.txtPercentualIsencao.Text = "0,0000";
            this.txtPercentualIsencao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPercentualIsencao_KeyPress);
            // 
            // lblPercentualIsencao
            // 
            this.lblPercentualIsencao.AutoSize = true;
            this.lblPercentualIsencao.Location = new System.Drawing.Point(210, 301);
            this.lblPercentualIsencao.Name = "lblPercentualIsencao";
            this.lblPercentualIsencao.Size = new System.Drawing.Size(99, 13);
            this.lblPercentualIsencao.TabIndex = 28;
            this.lblPercentualIsencao.Text = "Percentual Isenção";
            // 
            // txtMarkup
            // 
            this.txtMarkup.Location = new System.Drawing.Point(35, 321);
            this.txtMarkup.MaxLength = 10;
            this.txtMarkup.Name = "txtMarkup";
            this.txtMarkup.Size = new System.Drawing.Size(166, 20);
            this.txtMarkup.TabIndex = 27;
            this.txtMarkup.Tag = "3";
            this.txtMarkup.Text = "0,0000";
            this.txtMarkup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMarkup_KeyPress);
            // 
            // lblMarkup
            // 
            this.lblMarkup.AutoSize = true;
            this.lblMarkup.Location = new System.Drawing.Point(32, 301);
            this.lblMarkup.Name = "lblMarkup";
            this.lblMarkup.Size = new System.Drawing.Size(43, 13);
            this.lblMarkup.TabIndex = 26;
            this.lblMarkup.Text = "Markup";
            // 
            // txtPercentualReducao
            // 
            this.txtPercentualReducao.Location = new System.Drawing.Point(213, 375);
            this.txtPercentualReducao.MaxLength = 10;
            this.txtPercentualReducao.Name = "txtPercentualReducao";
            this.txtPercentualReducao.Size = new System.Drawing.Size(166, 20);
            this.txtPercentualReducao.TabIndex = 33;
            this.txtPercentualReducao.Tag = "3";
            this.txtPercentualReducao.Text = "0,0000";
            this.txtPercentualReducao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPercentualReducao_KeyPress);
            // 
            // lblPercentualReducao
            // 
            this.lblPercentualReducao.AutoSize = true;
            this.lblPercentualReducao.Location = new System.Drawing.Point(210, 355);
            this.lblPercentualReducao.Name = "lblPercentualReducao";
            this.lblPercentualReducao.Size = new System.Drawing.Size(105, 13);
            this.lblPercentualReducao.TabIndex = 32;
            this.lblPercentualReducao.Text = "Percentual Redução";
            // 
            // txtAliquota
            // 
            this.txtAliquota.Location = new System.Drawing.Point(35, 375);
            this.txtAliquota.MaxLength = 10;
            this.txtAliquota.Name = "txtAliquota";
            this.txtAliquota.Size = new System.Drawing.Size(166, 20);
            this.txtAliquota.TabIndex = 31;
            this.txtAliquota.Tag = "3";
            this.txtAliquota.Text = "0,0000";
            this.txtAliquota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAliquota_KeyPress);
            // 
            // lblAliquota
            // 
            this.lblAliquota.AutoSize = true;
            this.lblAliquota.Location = new System.Drawing.Point(32, 355);
            this.lblAliquota.Name = "lblAliquota";
            this.lblAliquota.Size = new System.Drawing.Size(47, 13);
            this.lblAliquota.TabIndex = 30;
            this.lblAliquota.Text = "Alíquota";
            // 
            // txtDe
            // 
            this.txtDe.Location = new System.Drawing.Point(35, 212);
            this.txtDe.Mask = "99/99/9999";
            this.txtDe.Name = "txtDe";
            this.txtDe.Size = new System.Drawing.Size(166, 20);
            this.txtDe.TabIndex = 34;
            this.txtDe.Tag = "2";
            // 
            // txtAte
            // 
            this.txtAte.Location = new System.Drawing.Point(213, 212);
            this.txtAte.Mask = "99/99/9999";
            this.txtAte.Name = "txtAte";
            this.txtAte.Size = new System.Drawing.Size(166, 20);
            this.txtAte.TabIndex = 35;
            this.txtAte.Tag = "2";
            // 
            // frmValoresImpostoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(405, 419);
            this.Controls.Add(this.txtAte);
            this.Controls.Add(this.txtDe);
            this.Controls.Add(this.txtPercentualReducao);
            this.Controls.Add(this.lblPercentualReducao);
            this.Controls.Add(this.txtAliquota);
            this.Controls.Add(this.lblAliquota);
            this.Controls.Add(this.txtPercentualIsencao);
            this.Controls.Add(this.lblPercentualIsencao);
            this.Controls.Add(this.txtMarkup);
            this.Controls.Add(this.lblMarkup);
            this.Controls.Add(this.txtLimiteMaximo);
            this.Controls.Add(this.lblLimiteMaximo);
            this.Controls.Add(this.txtLimiteMinimo);
            this.Controls.Add(this.lblLimiteMinimo);
            this.Controls.Add(this.cboCodigoImposto);
            this.Controls.Add(this.lblCodigoImposto);
            this.Controls.Add(this.lblAte);
            this.Controls.Add(this.lblDe);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmValoresImpostoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmValoresImpostoCad";
            this.Text = "Cadastro Valores Imposto";
            this.Load += new System.EventHandler(this.frmValoresImpostoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmValoresImpostoCad_KeyDown);
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
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Label lblCodigoImposto;
        private System.Windows.Forms.TextBox txtLimiteMinimo;
        private System.Windows.Forms.Label lblLimiteMinimo;
        private System.Windows.Forms.TextBox txtLimiteMaximo;
        private System.Windows.Forms.Label lblLimiteMaximo;
        private System.Windows.Forms.TextBox txtPercentualIsencao;
        private System.Windows.Forms.Label lblPercentualIsencao;
        private System.Windows.Forms.TextBox txtMarkup;
        private System.Windows.Forms.Label lblMarkup;
        private System.Windows.Forms.TextBox txtPercentualReducao;
        private System.Windows.Forms.Label lblPercentualReducao;
        private System.Windows.Forms.TextBox txtAliquota;
        private System.Windows.Forms.Label lblAliquota;
        public System.Windows.Forms.ComboBox cboCodigoImposto;
        private System.Windows.Forms.MaskedTextBox txtDe;
        private System.Windows.Forms.MaskedTextBox txtAte;
    }
}