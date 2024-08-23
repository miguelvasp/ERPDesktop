namespace ERP
{
    partial class frmJuridicaoImpostoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJuridicaoImpostoCad));
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
            this.lblPeriodoLiquidacaoImposto = new System.Windows.Forms.Label();
            this.cboPeriodoLiquidacaoImposto = new System.Windows.Forms.ComboBox();
            this.lblGrupoLancamentoContabil = new System.Windows.Forms.Label();
            this.cboGrupoLancamentoContabil = new System.Windows.Forms.ComboBox();
            this.lblMoeda = new System.Windows.Forms.Label();
            this.cboMoeda = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(30, 154);
            this.txtCodigo.MaxLength = 12;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(341, 20);
            this.txtCodigo.TabIndex = 17;
            this.txtCodigo.Tag = "1";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(27, 135);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 16;
            this.lblCodigo.Text = "Código";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(354, 138);
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
            this.ribbon1.Size = new System.Drawing.Size(406, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(30, 195);
            this.txtDescricao.MaxLength = 40;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(341, 20);
            this.txtDescricao.TabIndex = 19;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(27, 177);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 18;
            this.lblDescricao.Text = "Descrição";
            // 
            // lblPeriodoLiquidacaoImposto
            // 
            this.lblPeriodoLiquidacaoImposto.AutoSize = true;
            this.lblPeriodoLiquidacaoImposto.Location = new System.Drawing.Point(27, 218);
            this.lblPeriodoLiquidacaoImposto.Name = "lblPeriodoLiquidacaoImposto";
            this.lblPeriodoLiquidacaoImposto.Size = new System.Drawing.Size(140, 13);
            this.lblPeriodoLiquidacaoImposto.TabIndex = 20;
            this.lblPeriodoLiquidacaoImposto.Text = "Período Liquidação Imposto";
            // 
            // cboPeriodoLiquidacaoImposto
            // 
            this.cboPeriodoLiquidacaoImposto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPeriodoLiquidacaoImposto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPeriodoLiquidacaoImposto.FormattingEnabled = true;
            this.cboPeriodoLiquidacaoImposto.Location = new System.Drawing.Point(30, 237);
            this.cboPeriodoLiquidacaoImposto.Name = "cboPeriodoLiquidacaoImposto";
            this.cboPeriodoLiquidacaoImposto.Size = new System.Drawing.Size(217, 21);
            this.cboPeriodoLiquidacaoImposto.TabIndex = 21;
            this.cboPeriodoLiquidacaoImposto.Tag = "1";
            // 
            // lblGrupoLancamentoContabil
            // 
            this.lblGrupoLancamentoContabil.AutoSize = true;
            this.lblGrupoLancamentoContabil.Location = new System.Drawing.Point(27, 264);
            this.lblGrupoLancamentoContabil.Name = "lblGrupoLancamentoContabil";
            this.lblGrupoLancamentoContabil.Size = new System.Drawing.Size(139, 13);
            this.lblGrupoLancamentoContabil.TabIndex = 22;
            this.lblGrupoLancamentoContabil.Text = "Grupo Lançamento Contábil";
            // 
            // cboGrupoLancamentoContabil
            // 
            this.cboGrupoLancamentoContabil.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGrupoLancamentoContabil.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoLancamentoContabil.FormattingEnabled = true;
            this.cboGrupoLancamentoContabil.Location = new System.Drawing.Point(30, 283);
            this.cboGrupoLancamentoContabil.Name = "cboGrupoLancamentoContabil";
            this.cboGrupoLancamentoContabil.Size = new System.Drawing.Size(217, 21);
            this.cboGrupoLancamentoContabil.TabIndex = 23;
            this.cboGrupoLancamentoContabil.Tag = "1";
            // 
            // lblMoeda
            // 
            this.lblMoeda.AutoSize = true;
            this.lblMoeda.Location = new System.Drawing.Point(27, 307);
            this.lblMoeda.Name = "lblMoeda";
            this.lblMoeda.Size = new System.Drawing.Size(40, 13);
            this.lblMoeda.TabIndex = 24;
            this.lblMoeda.Text = "Moeda";
            // 
            // cboMoeda
            // 
            this.cboMoeda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMoeda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMoeda.FormattingEnabled = true;
            this.cboMoeda.Location = new System.Drawing.Point(30, 326);
            this.cboMoeda.Name = "cboMoeda";
            this.cboMoeda.Size = new System.Drawing.Size(217, 21);
            this.cboMoeda.TabIndex = 25;
            this.cboMoeda.Tag = "1";
            // 
            // frmJuridicaoImpostoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(406, 366);
            this.Controls.Add(this.lblMoeda);
            this.Controls.Add(this.cboMoeda);
            this.Controls.Add(this.lblGrupoLancamentoContabil);
            this.Controls.Add(this.cboGrupoLancamentoContabil);
            this.Controls.Add(this.lblPeriodoLiquidacaoImposto);
            this.Controls.Add(this.cboPeriodoLiquidacaoImposto);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmJuridicaoImpostoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmJuridicaoImpostoCad";
            this.Text = "Cadastro de Juridição Imposto";
            this.Load += new System.EventHandler(this.frmJuridicaoImpostoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmJuridicaoImpostoCad_KeyDown);
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
        private System.Windows.Forms.Label lblPeriodoLiquidacaoImposto;
        private System.Windows.Forms.ComboBox cboPeriodoLiquidacaoImposto;
        private System.Windows.Forms.Label lblGrupoLancamentoContabil;
        private System.Windows.Forms.ComboBox cboGrupoLancamentoContabil;
        private System.Windows.Forms.Label lblMoeda;
        private System.Windows.Forms.ComboBox cboMoeda;
    }
}