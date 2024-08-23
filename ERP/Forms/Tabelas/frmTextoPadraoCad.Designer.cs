namespace ERP
{
    partial class frmTextoPadraoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTextoPadraoCad));
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
            this.cboAgencia = new System.Windows.Forms.ComboBox();
            this.lblAgencia = new System.Windows.Forms.Label();
            this.cboRestricao = new System.Windows.Forms.ComboBox();
            this.lblRestricao = new System.Windows.Forms.Label();
            this.chkInformacoesFiscais = new System.Windows.Forms.CheckBox();
            this.txtNumeroProcesso = new System.Windows.Forms.TextBox();
            this.lblNumeroProcesso = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(27, 155);
            this.txtCodigo.MaxLength = 200;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(337, 20);
            this.txtCodigo.TabIndex = 15;
            this.txtCodigo.Tag = "1";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(24, 139);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 14;
            this.lblCodigo.Text = "Código";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(351, 139);
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
            this.ribbon1.Size = new System.Drawing.Size(394, 125);
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(27, 194);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(337, 98);
            this.txtDescricao.TabIndex = 17;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(24, 178);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 16;
            this.lblDescricao.Text = "Descrição";
            // 
            // cboAgencia
            // 
            this.cboAgencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboAgencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(27, 323);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(170, 21);
            this.cboAgencia.TabIndex = 19;
            this.cboAgencia.Tag = "1";
            // 
            // lblAgencia
            // 
            this.lblAgencia.AutoSize = true;
            this.lblAgencia.Location = new System.Drawing.Point(24, 307);
            this.lblAgencia.Name = "lblAgencia";
            this.lblAgencia.Size = new System.Drawing.Size(46, 13);
            this.lblAgencia.TabIndex = 18;
            this.lblAgencia.Text = "Agência";
            // 
            // cboRestricao
            // 
            this.cboRestricao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRestricao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRestricao.FormattingEnabled = true;
            this.cboRestricao.Location = new System.Drawing.Point(27, 363);
            this.cboRestricao.Name = "cboRestricao";
            this.cboRestricao.Size = new System.Drawing.Size(170, 21);
            this.cboRestricao.TabIndex = 22;
            this.cboRestricao.Tag = "";
            // 
            // lblRestricao
            // 
            this.lblRestricao.AutoSize = true;
            this.lblRestricao.Location = new System.Drawing.Point(24, 347);
            this.lblRestricao.Name = "lblRestricao";
            this.lblRestricao.Size = new System.Drawing.Size(52, 13);
            this.lblRestricao.TabIndex = 21;
            this.lblRestricao.Text = "Restrição";
            // 
            // chkInformacoesFiscais
            // 
            this.chkInformacoesFiscais.AutoSize = true;
            this.chkInformacoesFiscais.Location = new System.Drawing.Point(223, 323);
            this.chkInformacoesFiscais.Name = "chkInformacoesFiscais";
            this.chkInformacoesFiscais.Size = new System.Drawing.Size(119, 17);
            this.chkInformacoesFiscais.TabIndex = 20;
            this.chkInformacoesFiscais.Text = "Informações Fiscais";
            this.chkInformacoesFiscais.UseVisualStyleBackColor = true;
            // 
            // txtNumeroProcesso
            // 
            this.txtNumeroProcesso.Location = new System.Drawing.Point(27, 403);
            this.txtNumeroProcesso.MaxLength = 200;
            this.txtNumeroProcesso.Name = "txtNumeroProcesso";
            this.txtNumeroProcesso.Size = new System.Drawing.Size(337, 20);
            this.txtNumeroProcesso.TabIndex = 24;
            this.txtNumeroProcesso.Tag = "";
            // 
            // lblNumeroProcesso
            // 
            this.lblNumeroProcesso.AutoSize = true;
            this.lblNumeroProcesso.Location = new System.Drawing.Point(24, 387);
            this.lblNumeroProcesso.Name = "lblNumeroProcesso";
            this.lblNumeroProcesso.Size = new System.Drawing.Size(106, 13);
            this.lblNumeroProcesso.TabIndex = 23;
            this.lblNumeroProcesso.Text = "Número do Processo";
            // 
            // frmTextoPadraoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(394, 443);
            this.Controls.Add(this.txtNumeroProcesso);
            this.Controls.Add(this.lblNumeroProcesso);
            this.Controls.Add(this.chkInformacoesFiscais);
            this.Controls.Add(this.cboRestricao);
            this.Controls.Add(this.lblRestricao);
            this.Controls.Add(this.cboAgencia);
            this.Controls.Add(this.lblAgencia);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmTextoPadraoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmTextoPadraoCad";
            this.Text = "Cadastro de Texto Padrão";
            this.Load += new System.EventHandler(this.frmTextoPadraoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTextoPadraoCad_KeyDown);
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
        private System.Windows.Forms.ComboBox cboAgencia;
        private System.Windows.Forms.Label lblAgencia;
        private System.Windows.Forms.ComboBox cboRestricao;
        private System.Windows.Forms.Label lblRestricao;
        private System.Windows.Forms.CheckBox chkInformacoesFiscais;
        private System.Windows.Forms.TextBox txtNumeroProcesso;
        private System.Windows.Forms.Label lblNumeroProcesso;
    }
}