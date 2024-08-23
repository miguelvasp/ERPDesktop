namespace ERP
{
    partial class frmConfGrupoImpostoItemCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfGrupoImpostoItemCad));
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.lblPercentualValor = new System.Windows.Forms.Label();
            this.chkSemCreditoImposto = new System.Windows.Forms.CheckBox();
            this.chkIsento = new System.Windows.Forms.CheckBox();
            this.lblCodigoTributacao = new System.Windows.Forms.Label();
            this.cboCodigoTributacao = new System.Windows.Forms.ComboBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtPercentual = new System.Windows.Forms.TextBox();
            this.cboCodigoImposto = new System.Windows.Forms.ComboBox();
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
            this.ribbon1.Size = new System.Drawing.Size(494, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // lblPercentualValor
            // 
            this.lblPercentualValor.AutoSize = true;
            this.lblPercentualValor.Location = new System.Drawing.Point(22, 260);
            this.lblPercentualValor.Name = "lblPercentualValor";
            this.lblPercentualValor.Size = new System.Drawing.Size(85, 13);
            this.lblPercentualValor.TabIndex = 37;
            this.lblPercentualValor.Text = "Percentual Valor";
            // 
            // chkSemCreditoImposto
            // 
            this.chkSemCreditoImposto.AutoSize = true;
            this.chkSemCreditoImposto.Location = new System.Drawing.Point(256, 283);
            this.chkSemCreditoImposto.Name = "chkSemCreditoImposto";
            this.chkSemCreditoImposto.Size = new System.Drawing.Size(117, 17);
            this.chkSemCreditoImposto.TabIndex = 35;
            this.chkSemCreditoImposto.Text = "Sem Crédito Impsto";
            this.chkSemCreditoImposto.UseVisualStyleBackColor = true;
            // 
            // chkIsento
            // 
            this.chkIsento.AutoSize = true;
            this.chkIsento.Location = new System.Drawing.Point(256, 259);
            this.chkIsento.Name = "chkIsento";
            this.chkIsento.Size = new System.Drawing.Size(55, 17);
            this.chkIsento.TabIndex = 36;
            this.chkIsento.Text = "Isento";
            this.chkIsento.UseVisualStyleBackColor = true;
            // 
            // lblCodigoTributacao
            // 
            this.lblCodigoTributacao.AutoSize = true;
            this.lblCodigoTributacao.Location = new System.Drawing.Point(22, 204);
            this.lblCodigoTributacao.Name = "lblCodigoTributacao";
            this.lblCodigoTributacao.Size = new System.Drawing.Size(94, 13);
            this.lblCodigoTributacao.TabIndex = 33;
            this.lblCodigoTributacao.Text = "Código Tributação";
            // 
            // cboCodigoTributacao
            // 
            this.cboCodigoTributacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCodigoTributacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCodigoTributacao.FormattingEnabled = true;
            this.cboCodigoTributacao.Location = new System.Drawing.Point(25, 223);
            this.cboCodigoTributacao.Name = "cboCodigoTributacao";
            this.cboCodigoTributacao.Size = new System.Drawing.Size(448, 21);
            this.cboCodigoTributacao.TabIndex = 34;
            this.cboCodigoTributacao.Tag = "1";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(22, 155);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 29;
            this.lblCodigo.Text = "Código";
            // 
            // txtPercentual
            // 
            this.txtPercentual.Location = new System.Drawing.Point(25, 281);
            this.txtPercentual.Name = "txtPercentual";
            this.txtPercentual.Size = new System.Drawing.Size(217, 20);
            this.txtPercentual.TabIndex = 38;
            // 
            // cboCodigoImposto
            // 
            this.cboCodigoImposto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCodigoImposto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCodigoImposto.FormattingEnabled = true;
            this.cboCodigoImposto.Location = new System.Drawing.Point(25, 171);
            this.cboCodigoImposto.Name = "cboCodigoImposto";
            this.cboCodigoImposto.Size = new System.Drawing.Size(448, 21);
            this.cboCodigoImposto.TabIndex = 39;
            this.cboCodigoImposto.Leave += new System.EventHandler(this.cboCodigoImposto_Leave);
            // 
            // frmConfGrupoImpostoItemCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(494, 327);
            this.Controls.Add(this.cboCodigoTributacao);
            this.Controls.Add(this.cboCodigoImposto);
            this.Controls.Add(this.txtPercentual);
            this.Controls.Add(this.lblPercentualValor);
            this.Controls.Add(this.chkSemCreditoImposto);
            this.Controls.Add(this.chkIsento);
            this.Controls.Add(this.lblCodigoTributacao);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmConfGrupoImpostoItemCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmConfGrupoImpostoItemCad";
            this.Text = "Cadastro Conf. Grupo ImpostoItemCad";
            this.Load += new System.EventHandler(this.frmConfGrupoImpostoItemCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConfGrupoImpostoCad_KeyDown);
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
        private System.Windows.Forms.Label lblPercentualValor;
        private System.Windows.Forms.CheckBox chkSemCreditoImposto;
        private System.Windows.Forms.CheckBox chkIsento;
        private System.Windows.Forms.Label lblCodigoTributacao;
        private System.Windows.Forms.ComboBox cboCodigoTributacao;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtPercentual;
        private System.Windows.Forms.ComboBox cboCodigoImposto;
    }
}