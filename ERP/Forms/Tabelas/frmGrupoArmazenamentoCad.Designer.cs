namespace ERP
{
    partial class frmGrupoArmazenamentoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoArmazenamentoCad));
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
            this.chkObrigatorio = new System.Windows.Forms.CheckBox();
            this.chkSiteAtivo = new System.Windows.Forms.CheckBox();
            this.chkSiteSaida = new System.Windows.Forms.CheckBox();
            this.chkSiteEntrada = new System.Windows.Forms.CheckBox();
            this.chkDepositoAtivo = new System.Windows.Forms.CheckBox();
            this.chkDepositoSaida = new System.Windows.Forms.CheckBox();
            this.chkDepositoEntrada = new System.Windows.Forms.CheckBox();
            this.chkLocalizacaoEntrada = new System.Windows.Forms.CheckBox();
            this.chkLocalizacaoSaida = new System.Windows.Forms.CheckBox();
            this.chkLocalizacaoAtivo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(29, 154);
            this.txtNome.MaxLength = 255;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(380, 20);
            this.txtNome.TabIndex = 17;
            this.txtNome.Tag = "1";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(26, 137);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 16;
            this.lblNome.Text = "Nome";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(353, 138);
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
            this.ribbon1.Size = new System.Drawing.Size(429, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(29, 203);
            this.txtDescricao.MaxLength = 255;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(380, 20);
            this.txtDescricao.TabIndex = 19;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(26, 186);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 18;
            this.lblDescricao.Text = "Descrição";
            // 
            // chkObrigatorio
            // 
            this.chkObrigatorio.AutoSize = true;
            this.chkObrigatorio.Location = new System.Drawing.Point(29, 238);
            this.chkObrigatorio.Name = "chkObrigatorio";
            this.chkObrigatorio.Size = new System.Drawing.Size(77, 17);
            this.chkObrigatorio.TabIndex = 20;
            this.chkObrigatorio.Text = "Obrigatório";
            this.chkObrigatorio.UseVisualStyleBackColor = true;
            // 
            // chkSiteAtivo
            // 
            this.chkSiteAtivo.AutoSize = true;
            this.chkSiteAtivo.Location = new System.Drawing.Point(29, 261);
            this.chkSiteAtivo.Name = "chkSiteAtivo";
            this.chkSiteAtivo.Size = new System.Drawing.Size(96, 17);
            this.chkSiteAtivo.TabIndex = 21;
            this.chkSiteAtivo.Text = "Armazém Ativo";
            this.chkSiteAtivo.UseVisualStyleBackColor = true;
            // 
            // chkSiteSaida
            // 
            this.chkSiteSaida.AutoSize = true;
            this.chkSiteSaida.Location = new System.Drawing.Point(157, 261);
            this.chkSiteSaida.Name = "chkSiteSaida";
            this.chkSiteSaida.Size = new System.Drawing.Size(101, 17);
            this.chkSiteSaida.TabIndex = 22;
            this.chkSiteSaida.Text = "Armazém Saída";
            this.chkSiteSaida.UseVisualStyleBackColor = true;
            // 
            // chkSiteEntrada
            // 
            this.chkSiteEntrada.AutoSize = true;
            this.chkSiteEntrada.Location = new System.Drawing.Point(286, 261);
            this.chkSiteEntrada.Name = "chkSiteEntrada";
            this.chkSiteEntrada.Size = new System.Drawing.Size(109, 17);
            this.chkSiteEntrada.TabIndex = 23;
            this.chkSiteEntrada.Text = "Armazém Entrada";
            this.chkSiteEntrada.UseVisualStyleBackColor = true;
            // 
            // chkDepositoAtivo
            // 
            this.chkDepositoAtivo.AutoSize = true;
            this.chkDepositoAtivo.Location = new System.Drawing.Point(29, 284);
            this.chkDepositoAtivo.Name = "chkDepositoAtivo";
            this.chkDepositoAtivo.Size = new System.Drawing.Size(95, 17);
            this.chkDepositoAtivo.TabIndex = 24;
            this.chkDepositoAtivo.Text = "Depósito Ativo";
            this.chkDepositoAtivo.UseVisualStyleBackColor = true;
            // 
            // chkDepositoSaida
            // 
            this.chkDepositoSaida.AutoSize = true;
            this.chkDepositoSaida.Location = new System.Drawing.Point(157, 284);
            this.chkDepositoSaida.Name = "chkDepositoSaida";
            this.chkDepositoSaida.Size = new System.Drawing.Size(100, 17);
            this.chkDepositoSaida.TabIndex = 25;
            this.chkDepositoSaida.Text = "Depósito Saída";
            this.chkDepositoSaida.UseVisualStyleBackColor = true;
            // 
            // chkDepositoEntrada
            // 
            this.chkDepositoEntrada.AutoSize = true;
            this.chkDepositoEntrada.Location = new System.Drawing.Point(286, 284);
            this.chkDepositoEntrada.Name = "chkDepositoEntrada";
            this.chkDepositoEntrada.Size = new System.Drawing.Size(108, 17);
            this.chkDepositoEntrada.TabIndex = 26;
            this.chkDepositoEntrada.Text = "Depósito Entrada";
            this.chkDepositoEntrada.UseVisualStyleBackColor = true;
            // 
            // chkLocalizacaoEntrada
            // 
            this.chkLocalizacaoEntrada.AutoSize = true;
            this.chkLocalizacaoEntrada.Location = new System.Drawing.Point(286, 307);
            this.chkLocalizacaoEntrada.Name = "chkLocalizacaoEntrada";
            this.chkLocalizacaoEntrada.Size = new System.Drawing.Size(123, 17);
            this.chkLocalizacaoEntrada.TabIndex = 29;
            this.chkLocalizacaoEntrada.Text = "Localização Entrada";
            this.chkLocalizacaoEntrada.UseVisualStyleBackColor = true;
            // 
            // chkLocalizacaoSaida
            // 
            this.chkLocalizacaoSaida.AutoSize = true;
            this.chkLocalizacaoSaida.Location = new System.Drawing.Point(157, 307);
            this.chkLocalizacaoSaida.Name = "chkLocalizacaoSaida";
            this.chkLocalizacaoSaida.Size = new System.Drawing.Size(115, 17);
            this.chkLocalizacaoSaida.TabIndex = 28;
            this.chkLocalizacaoSaida.Text = "Localização Saída";
            this.chkLocalizacaoSaida.UseVisualStyleBackColor = true;
            // 
            // chkLocalizacaoAtivo
            // 
            this.chkLocalizacaoAtivo.AutoSize = true;
            this.chkLocalizacaoAtivo.Location = new System.Drawing.Point(29, 307);
            this.chkLocalizacaoAtivo.Name = "chkLocalizacaoAtivo";
            this.chkLocalizacaoAtivo.Size = new System.Drawing.Size(110, 17);
            this.chkLocalizacaoAtivo.TabIndex = 27;
            this.chkLocalizacaoAtivo.Text = "Localização Ativo";
            this.chkLocalizacaoAtivo.UseVisualStyleBackColor = true;
            // 
            // frmGrupoArmazenamentoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(429, 351);
            this.Controls.Add(this.chkLocalizacaoEntrada);
            this.Controls.Add(this.chkLocalizacaoSaida);
            this.Controls.Add(this.chkLocalizacaoAtivo);
            this.Controls.Add(this.chkDepositoEntrada);
            this.Controls.Add(this.chkDepositoSaida);
            this.Controls.Add(this.chkDepositoAtivo);
            this.Controls.Add(this.chkSiteEntrada);
            this.Controls.Add(this.chkSiteSaida);
            this.Controls.Add(this.chkSiteAtivo);
            this.Controls.Add(this.chkObrigatorio);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmGrupoArmazenamentoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmGrupoArmazenamentoCad";
            this.Text = "Cadastro Grupo Armazenamento";
            this.Load += new System.EventHandler(this.frmGrupoArmazenamentoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGrupoArmazenamentoCad_KeyDown);
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
        private System.Windows.Forms.CheckBox chkObrigatorio;
        private System.Windows.Forms.CheckBox chkSiteAtivo;
        private System.Windows.Forms.CheckBox chkSiteSaida;
        private System.Windows.Forms.CheckBox chkSiteEntrada;
        private System.Windows.Forms.CheckBox chkDepositoAtivo;
        private System.Windows.Forms.CheckBox chkDepositoSaida;
        private System.Windows.Forms.CheckBox chkDepositoEntrada;
        private System.Windows.Forms.CheckBox chkLocalizacaoEntrada;
        private System.Windows.Forms.CheckBox chkLocalizacaoSaida;
        private System.Windows.Forms.CheckBox chkLocalizacaoAtivo;
    }
}