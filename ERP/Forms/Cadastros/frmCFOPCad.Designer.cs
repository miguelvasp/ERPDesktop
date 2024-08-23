namespace ERP.Cadastros
{
    partial class frmCFOPCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCFOPCad));
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtCodigoCFOP = new System.Windows.Forms.TextBox();
            this.lblCodigoCFOP = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.cboLocalizacao = new System.Windows.Forms.ComboBox();
            this.lblLocalizacao = new System.Windows.Forms.Label();
            this.cboDirecao = new System.Windows.Forms.ComboBox();
            this.lblDirecao = new System.Windows.Forms.Label();
            this.cboTextoPadrao = new System.Windows.Forms.ComboBox();
            this.lblTextoPadrao = new System.Windows.Forms.Label();
            this.cboFinalidade = new System.Windows.Forms.ComboBox();
            this.lblFinalidade = new System.Windows.Forms.Label();
            this.chkConsiderarCIAP = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
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
            this.ribbon1.Size = new System.Drawing.Size(555, 125);
            this.ribbon1.TabIndex = 2;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtCodigoCFOP
            // 
            this.txtCodigoCFOP.Location = new System.Drawing.Point(24, 155);
            this.txtCodigoCFOP.MaxLength = 5;
            this.txtCodigoCFOP.Name = "txtCodigoCFOP";
            this.txtCodigoCFOP.Size = new System.Drawing.Size(88, 20);
            this.txtCodigoCFOP.TabIndex = 8;
            this.txtCodigoCFOP.Tag = "1";
            // 
            // lblCodigoCFOP
            // 
            this.lblCodigoCFOP.AutoSize = true;
            this.lblCodigoCFOP.Location = new System.Drawing.Point(21, 138);
            this.lblCodigoCFOP.Name = "lblCodigoCFOP";
            this.lblCodigoCFOP.Size = new System.Drawing.Size(71, 13);
            this.lblCodigoCFOP.TabIndex = 7;
            this.lblCodigoCFOP.Text = "Código CFOP";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(114, 138);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 6;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(24, 206);
            this.txtDescricao.MaxLength = 500;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(518, 20);
            this.txtDescricao.TabIndex = 11;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(21, 189);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 10;
            this.lblDescricao.Text = "Descrição";
            // 
            // cboLocalizacao
            // 
            this.cboLocalizacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboLocalizacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboLocalizacao.DropDownWidth = 170;
            this.cboLocalizacao.FormattingEnabled = true;
            this.cboLocalizacao.Location = new System.Drawing.Point(24, 260);
            this.cboLocalizacao.Name = "cboLocalizacao";
            this.cboLocalizacao.Size = new System.Drawing.Size(200, 21);
            this.cboLocalizacao.TabIndex = 13;
            this.cboLocalizacao.Tag = "1";
            // 
            // lblLocalizacao
            // 
            this.lblLocalizacao.AutoSize = true;
            this.lblLocalizacao.Location = new System.Drawing.Point(21, 244);
            this.lblLocalizacao.Name = "lblLocalizacao";
            this.lblLocalizacao.Size = new System.Drawing.Size(64, 13);
            this.lblLocalizacao.TabIndex = 12;
            this.lblLocalizacao.Text = "Localização";
            // 
            // cboDirecao
            // 
            this.cboDirecao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDirecao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDirecao.DropDownWidth = 170;
            this.cboDirecao.FormattingEnabled = true;
            this.cboDirecao.Location = new System.Drawing.Point(236, 260);
            this.cboDirecao.Name = "cboDirecao";
            this.cboDirecao.Size = new System.Drawing.Size(200, 21);
            this.cboDirecao.TabIndex = 15;
            this.cboDirecao.Tag = "1";
            // 
            // lblDirecao
            // 
            this.lblDirecao.AutoSize = true;
            this.lblDirecao.Location = new System.Drawing.Point(233, 244);
            this.lblDirecao.Name = "lblDirecao";
            this.lblDirecao.Size = new System.Drawing.Size(44, 13);
            this.lblDirecao.TabIndex = 14;
            this.lblDirecao.Text = "Direção";
            // 
            // cboTextoPadrao
            // 
            this.cboTextoPadrao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTextoPadrao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTextoPadrao.DropDownWidth = 170;
            this.cboTextoPadrao.FormattingEnabled = true;
            this.cboTextoPadrao.Location = new System.Drawing.Point(24, 313);
            this.cboTextoPadrao.Name = "cboTextoPadrao";
            this.cboTextoPadrao.Size = new System.Drawing.Size(200, 21);
            this.cboTextoPadrao.TabIndex = 17;
            this.cboTextoPadrao.Tag = "";
            // 
            // lblTextoPadrao
            // 
            this.lblTextoPadrao.AutoSize = true;
            this.lblTextoPadrao.Location = new System.Drawing.Point(21, 297);
            this.lblTextoPadrao.Name = "lblTextoPadrao";
            this.lblTextoPadrao.Size = new System.Drawing.Size(71, 13);
            this.lblTextoPadrao.TabIndex = 16;
            this.lblTextoPadrao.Text = "Texto Padrão";
            // 
            // cboFinalidade
            // 
            this.cboFinalidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFinalidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFinalidade.DropDownWidth = 170;
            this.cboFinalidade.FormattingEnabled = true;
            this.cboFinalidade.Location = new System.Drawing.Point(236, 313);
            this.cboFinalidade.Name = "cboFinalidade";
            this.cboFinalidade.Size = new System.Drawing.Size(200, 21);
            this.cboFinalidade.TabIndex = 19;
            this.cboFinalidade.Tag = "1";
            // 
            // lblFinalidade
            // 
            this.lblFinalidade.AutoSize = true;
            this.lblFinalidade.Location = new System.Drawing.Point(233, 297);
            this.lblFinalidade.Name = "lblFinalidade";
            this.lblFinalidade.Size = new System.Drawing.Size(55, 13);
            this.lblFinalidade.TabIndex = 18;
            this.lblFinalidade.Text = "Finalidade";
            // 
            // chkConsiderarCIAP
            // 
            this.chkConsiderarCIAP.AutoSize = true;
            this.chkConsiderarCIAP.Location = new System.Drawing.Point(24, 354);
            this.chkConsiderarCIAP.Name = "chkConsiderarCIAP";
            this.chkConsiderarCIAP.Size = new System.Drawing.Size(103, 17);
            this.chkConsiderarCIAP.TabIndex = 20;
            this.chkConsiderarCIAP.Text = "Considerar CIAP";
            this.chkConsiderarCIAP.UseVisualStyleBackColor = true;
            // 
            // frmCFOPCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(555, 382);
            this.Controls.Add(this.chkConsiderarCIAP);
            this.Controls.Add(this.cboFinalidade);
            this.Controls.Add(this.lblFinalidade);
            this.Controls.Add(this.cboTextoPadrao);
            this.Controls.Add(this.lblTextoPadrao);
            this.Controls.Add(this.cboDirecao);
            this.Controls.Add(this.lblDirecao);
            this.Controls.Add(this.cboLocalizacao);
            this.Controls.Add(this.lblLocalizacao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtCodigoCFOP);
            this.Controls.Add(this.lblCodigoCFOP);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCFOPCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Código de Faturamento";
            this.Load += new System.EventHandler(this.frmCFOPCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCFOPCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox txtCodigoCFOP;
        private System.Windows.Forms.Label lblCodigoCFOP;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.ComboBox cboLocalizacao;
        private System.Windows.Forms.Label lblLocalizacao;
        private System.Windows.Forms.ComboBox cboDirecao;
        private System.Windows.Forms.Label lblDirecao;
        private System.Windows.Forms.ComboBox cboTextoPadrao;
        private System.Windows.Forms.Label lblTextoPadrao;
        private System.Windows.Forms.ComboBox cboFinalidade;
        private System.Windows.Forms.Label lblFinalidade;
        private System.Windows.Forms.CheckBox chkConsiderarCIAP;

    }
}