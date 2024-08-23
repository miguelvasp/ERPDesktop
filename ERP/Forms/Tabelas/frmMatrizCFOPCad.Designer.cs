namespace ERP
{
    partial class frmMatrizCFOPCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMatrizCFOPCad));
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.cboCFOP = new System.Windows.Forms.ComboBox();
            this.lblCFOP = new System.Windows.Forms.Label();
            this.cboTipoTransacao = new System.Windows.Forms.ComboBox();
            this.lblTipoTransacao = new System.Windows.Forms.Label();
            this.cboOperacao = new System.Windows.Forms.ComboBox();
            this.lblOperacao = new System.Windows.Forms.Label();
            this.cboGrupoCFOP = new System.Windows.Forms.ComboBox();
            this.lblGrupoCFOP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDescricao
            // 
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.Location = new System.Drawing.Point(20, 149);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(350, 20);
            this.txtDescricao.TabIndex = 17;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(25, 133);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 16;
            this.lblDescricao.Text = "Descrição";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(352, 133);
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
            this.ribbon1.Size = new System.Drawing.Size(375, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // cboCFOP
            // 
            this.cboCFOP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCFOP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCFOP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCFOP.FormattingEnabled = true;
            this.cboCFOP.Location = new System.Drawing.Point(20, 196);
            this.cboCFOP.Name = "cboCFOP";
            this.cboCFOP.Size = new System.Drawing.Size(179, 21);
            this.cboCFOP.TabIndex = 19;
            this.cboCFOP.Tag = "1";
            // 
            // lblCFOP
            // 
            this.lblCFOP.AutoSize = true;
            this.lblCFOP.Location = new System.Drawing.Point(25, 181);
            this.lblCFOP.Name = "lblCFOP";
            this.lblCFOP.Size = new System.Drawing.Size(35, 13);
            this.lblCFOP.TabIndex = 18;
            this.lblCFOP.Text = "CFOP";
            // 
            // cboTipoTransacao
            // 
            this.cboTipoTransacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoTransacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTipoTransacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoTransacao.FormattingEnabled = true;
            this.cboTipoTransacao.Location = new System.Drawing.Point(20, 245);
            this.cboTipoTransacao.Name = "cboTipoTransacao";
            this.cboTipoTransacao.Size = new System.Drawing.Size(179, 21);
            this.cboTipoTransacao.TabIndex = 21;
            this.cboTipoTransacao.Tag = "1";
            // 
            // lblTipoTransacao
            // 
            this.lblTipoTransacao.AutoSize = true;
            this.lblTipoTransacao.Location = new System.Drawing.Point(25, 230);
            this.lblTipoTransacao.Name = "lblTipoTransacao";
            this.lblTipoTransacao.Size = new System.Drawing.Size(97, 13);
            this.lblTipoTransacao.TabIndex = 20;
            this.lblTipoTransacao.Text = "Tipo de Transação";
            // 
            // cboOperacao
            // 
            this.cboOperacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOperacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboOperacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboOperacao.FormattingEnabled = true;
            this.cboOperacao.Location = new System.Drawing.Point(20, 293);
            this.cboOperacao.Name = "cboOperacao";
            this.cboOperacao.Size = new System.Drawing.Size(179, 21);
            this.cboOperacao.TabIndex = 23;
            this.cboOperacao.Tag = "1";
            // 
            // lblOperacao
            // 
            this.lblOperacao.AutoSize = true;
            this.lblOperacao.Location = new System.Drawing.Point(25, 278);
            this.lblOperacao.Name = "lblOperacao";
            this.lblOperacao.Size = new System.Drawing.Size(54, 13);
            this.lblOperacao.TabIndex = 22;
            this.lblOperacao.Text = "Operação";
            // 
            // cboGrupoCFOP
            // 
            this.cboGrupoCFOP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGrupoCFOP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGrupoCFOP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoCFOP.FormattingEnabled = true;
            this.cboGrupoCFOP.Location = new System.Drawing.Point(20, 341);
            this.cboGrupoCFOP.Name = "cboGrupoCFOP";
            this.cboGrupoCFOP.Size = new System.Drawing.Size(179, 21);
            this.cboGrupoCFOP.TabIndex = 25;
            this.cboGrupoCFOP.Tag = "1";
            // 
            // lblGrupoCFOP
            // 
            this.lblGrupoCFOP.AutoSize = true;
            this.lblGrupoCFOP.Location = new System.Drawing.Point(25, 326);
            this.lblGrupoCFOP.Name = "lblGrupoCFOP";
            this.lblGrupoCFOP.Size = new System.Drawing.Size(67, 13);
            this.lblGrupoCFOP.TabIndex = 24;
            this.lblGrupoCFOP.Text = "Grupo CFOP";
            // 
            // frmMatrizCFOPCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(375, 389);
            this.Controls.Add(this.cboGrupoCFOP);
            this.Controls.Add(this.lblGrupoCFOP);
            this.Controls.Add(this.cboOperacao);
            this.Controls.Add(this.lblOperacao);
            this.Controls.Add(this.cboTipoTransacao);
            this.Controls.Add(this.lblTipoTransacao);
            this.Controls.Add(this.cboCFOP);
            this.Controls.Add(this.lblCFOP);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(382, 404);
            this.Name = "frmMatrizCFOPCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmMatrizCFOPCad";
            this.Text = "Cadastro Matriz CFOP";
            this.Load += new System.EventHandler(this.frmMatrizCFOPCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMatrizCFOPCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.ComboBox cboCFOP;
        private System.Windows.Forms.Label lblCFOP;
        private System.Windows.Forms.ComboBox cboTipoTransacao;
        private System.Windows.Forms.Label lblTipoTransacao;
        private System.Windows.Forms.ComboBox cboOperacao;
        private System.Windows.Forms.Label lblOperacao;
        private System.Windows.Forms.ComboBox cboGrupoCFOP;
        private System.Windows.Forms.Label lblGrupoCFOP;
    }
}