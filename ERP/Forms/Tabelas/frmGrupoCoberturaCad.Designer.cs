namespace ERP
{
    partial class frmGrupoCoberturaCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoCoberturaCad));
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
            this.lblCobertura = new System.Windows.Forms.Label();
            this.cboCobertura = new System.Windows.Forms.ComboBox();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.txtLimiteTempo = new System.Windows.Forms.TextBox();
            this.lblLimiteTempo = new System.Windows.Forms.Label();
            this.txtDiasNegativo = new System.Windows.Forms.TextBox();
            this.lblDiasNegativo = new System.Windows.Forms.Label();
            this.txtDiasPositivo = new System.Windows.Forms.TextBox();
            this.lblDiasPositivo = new System.Windows.Forms.Label();
            this.lblStatusProducao = new System.Windows.Forms.Label();
            this.cboStatusProducao = new System.Windows.Forms.ComboBox();
            this.txtLimiteTempoCobertura = new System.Windows.Forms.TextBox();
            this.lblLimiteTempoCobertura = new System.Windows.Forms.Label();
            this.txtLimiteTempoDetalhamento = new System.Windows.Forms.TextBox();
            this.lblLimiteTempoDetalhamento = new System.Windows.Forms.Label();
            this.txtLimitePlanoPrevisao = new System.Windows.Forms.TextBox();
            this.lblLimitePlanoPrevisao = new System.Windows.Forms.Label();
            this.txtLimiteTempoCapacidade = new System.Windows.Forms.TextBox();
            this.lblLimiteTempoCapacidade = new System.Windows.Forms.Label();
            this.lblReduzirPrevisao = new System.Windows.Forms.Label();
            this.cboReduzirPrevisao = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(31, 158);
            this.txtCodigo.MaxLength = 200;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(344, 20);
            this.txtCodigo.TabIndex = 17;
            this.txtCodigo.Tag = "1";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(28, 142);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 16;
            this.lblCodigo.Text = "Código";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(355, 142);
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
            this.ribbon1.Size = new System.Drawing.Size(409, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(31, 207);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(344, 20);
            this.txtDescricao.TabIndex = 19;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(28, 191);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 18;
            this.lblDescricao.Text = "Descrição";
            // 
            // lblCobertura
            // 
            this.lblCobertura.AutoSize = true;
            this.lblCobertura.Location = new System.Drawing.Point(28, 239);
            this.lblCobertura.Name = "lblCobertura";
            this.lblCobertura.Size = new System.Drawing.Size(53, 13);
            this.lblCobertura.TabIndex = 20;
            this.lblCobertura.Text = "Cobertura";
            // 
            // cboCobertura
            // 
            this.cboCobertura.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCobertura.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCobertura.FormattingEnabled = true;
            this.cboCobertura.Location = new System.Drawing.Point(31, 258);
            this.cboCobertura.Name = "cboCobertura";
            this.cboCobertura.Size = new System.Drawing.Size(217, 21);
            this.cboCobertura.TabIndex = 21;
            this.cboCobertura.Tag = "1";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(31, 314);
            this.txtPeriodo.MaxLength = 10;
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(166, 20);
            this.txtPeriodo.TabIndex = 23;
            this.txtPeriodo.Tag = "3";
            this.txtPeriodo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeriodo_KeyPress);
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(28, 294);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(45, 13);
            this.lblPeriodo.TabIndex = 22;
            this.lblPeriodo.Text = "Período";
            // 
            // txtLimiteTempo
            // 
            this.txtLimiteTempo.Location = new System.Drawing.Point(209, 314);
            this.txtLimiteTempo.MaxLength = 10;
            this.txtLimiteTempo.Name = "txtLimiteTempo";
            this.txtLimiteTempo.Size = new System.Drawing.Size(166, 20);
            this.txtLimiteTempo.TabIndex = 25;
            this.txtLimiteTempo.Tag = "3";
            this.txtLimiteTempo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteTempo_KeyPress);
            // 
            // lblLimiteTempo
            // 
            this.lblLimiteTempo.AutoSize = true;
            this.lblLimiteTempo.Location = new System.Drawing.Point(206, 294);
            this.lblLimiteTempo.Name = "lblLimiteTempo";
            this.lblLimiteTempo.Size = new System.Drawing.Size(85, 13);
            this.lblLimiteTempo.TabIndex = 24;
            this.lblLimiteTempo.Text = "Limite de Tempo";
            // 
            // txtDiasNegativo
            // 
            this.txtDiasNegativo.Location = new System.Drawing.Point(31, 367);
            this.txtDiasNegativo.MaxLength = 10;
            this.txtDiasNegativo.Name = "txtDiasNegativo";
            this.txtDiasNegativo.Size = new System.Drawing.Size(166, 20);
            this.txtDiasNegativo.TabIndex = 27;
            this.txtDiasNegativo.Tag = "3";
            this.txtDiasNegativo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiasNegativo_KeyPress);
            // 
            // lblDiasNegativo
            // 
            this.lblDiasNegativo.AutoSize = true;
            this.lblDiasNegativo.Location = new System.Drawing.Point(28, 347);
            this.lblDiasNegativo.Name = "lblDiasNegativo";
            this.lblDiasNegativo.Size = new System.Drawing.Size(74, 13);
            this.lblDiasNegativo.TabIndex = 26;
            this.lblDiasNegativo.Text = "Dias Negativo";
            // 
            // txtDiasPositivo
            // 
            this.txtDiasPositivo.Location = new System.Drawing.Point(209, 367);
            this.txtDiasPositivo.MaxLength = 10;
            this.txtDiasPositivo.Name = "txtDiasPositivo";
            this.txtDiasPositivo.Size = new System.Drawing.Size(166, 20);
            this.txtDiasPositivo.TabIndex = 29;
            this.txtDiasPositivo.Tag = "3";
            this.txtDiasPositivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiasPositivo_KeyPress);
            // 
            // lblDiasPositivo
            // 
            this.lblDiasPositivo.AutoSize = true;
            this.lblDiasPositivo.Location = new System.Drawing.Point(206, 347);
            this.lblDiasPositivo.Name = "lblDiasPositivo";
            this.lblDiasPositivo.Size = new System.Drawing.Size(68, 13);
            this.lblDiasPositivo.TabIndex = 28;
            this.lblDiasPositivo.Text = "Dias Positivo";
            // 
            // lblStatusProducao
            // 
            this.lblStatusProducao.AutoSize = true;
            this.lblStatusProducao.Location = new System.Drawing.Point(28, 400);
            this.lblStatusProducao.Name = "lblStatusProducao";
            this.lblStatusProducao.Size = new System.Drawing.Size(101, 13);
            this.lblStatusProducao.TabIndex = 30;
            this.lblStatusProducao.Text = "Status de Produção";
            // 
            // cboStatusProducao
            // 
            this.cboStatusProducao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboStatusProducao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStatusProducao.FormattingEnabled = true;
            this.cboStatusProducao.Location = new System.Drawing.Point(31, 419);
            this.cboStatusProducao.Name = "cboStatusProducao";
            this.cboStatusProducao.Size = new System.Drawing.Size(217, 21);
            this.cboStatusProducao.TabIndex = 31;
            this.cboStatusProducao.Tag = "1";
            // 
            // txtLimiteTempoCobertura
            // 
            this.txtLimiteTempoCobertura.Location = new System.Drawing.Point(31, 473);
            this.txtLimiteTempoCobertura.MaxLength = 10;
            this.txtLimiteTempoCobertura.Name = "txtLimiteTempoCobertura";
            this.txtLimiteTempoCobertura.Size = new System.Drawing.Size(166, 20);
            this.txtLimiteTempoCobertura.TabIndex = 33;
            this.txtLimiteTempoCobertura.Tag = "3";
            this.txtLimiteTempoCobertura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteTempoCobertura_KeyPress);
            // 
            // lblLimiteTempoCobertura
            // 
            this.lblLimiteTempoCobertura.AutoSize = true;
            this.lblLimiteTempoCobertura.Location = new System.Drawing.Point(28, 453);
            this.lblLimiteTempoCobertura.Name = "lblLimiteTempoCobertura";
            this.lblLimiteTempoCobertura.Size = new System.Drawing.Size(134, 13);
            this.lblLimiteTempoCobertura.TabIndex = 32;
            this.lblLimiteTempoCobertura.Text = "Limite de Tempo Cobertura";
            // 
            // txtLimiteTempoDetalhamento
            // 
            this.txtLimiteTempoDetalhamento.Location = new System.Drawing.Point(209, 473);
            this.txtLimiteTempoDetalhamento.MaxLength = 10;
            this.txtLimiteTempoDetalhamento.Name = "txtLimiteTempoDetalhamento";
            this.txtLimiteTempoDetalhamento.Size = new System.Drawing.Size(166, 20);
            this.txtLimiteTempoDetalhamento.TabIndex = 35;
            this.txtLimiteTempoDetalhamento.Tag = "3";
            this.txtLimiteTempoDetalhamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteTempoDetalhamento_KeyPress);
            // 
            // lblLimiteTempoDetalhamento
            // 
            this.lblLimiteTempoDetalhamento.AutoSize = true;
            this.lblLimiteTempoDetalhamento.Location = new System.Drawing.Point(206, 453);
            this.lblLimiteTempoDetalhamento.Name = "lblLimiteTempoDetalhamento";
            this.lblLimiteTempoDetalhamento.Size = new System.Drawing.Size(154, 13);
            this.lblLimiteTempoDetalhamento.TabIndex = 34;
            this.lblLimiteTempoDetalhamento.Text = "Limite de Tempo Detalhamento";
            // 
            // txtLimitePlanoPrevisao
            // 
            this.txtLimitePlanoPrevisao.Location = new System.Drawing.Point(209, 531);
            this.txtLimitePlanoPrevisao.MaxLength = 10;
            this.txtLimitePlanoPrevisao.Name = "txtLimitePlanoPrevisao";
            this.txtLimitePlanoPrevisao.Size = new System.Drawing.Size(166, 20);
            this.txtLimitePlanoPrevisao.TabIndex = 39;
            this.txtLimitePlanoPrevisao.Tag = "3";
            this.txtLimitePlanoPrevisao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimitePlanoPrevisao_KeyPress);
            // 
            // lblLimitePlanoPrevisao
            // 
            this.lblLimitePlanoPrevisao.AutoSize = true;
            this.lblLimitePlanoPrevisao.Location = new System.Drawing.Point(206, 511);
            this.lblLimitePlanoPrevisao.Name = "lblLimitePlanoPrevisao";
            this.lblLimitePlanoPrevisao.Size = new System.Drawing.Size(123, 13);
            this.lblLimitePlanoPrevisao.TabIndex = 38;
            this.lblLimitePlanoPrevisao.Text = "Limite Plano de Previsão";
            // 
            // txtLimiteTempoCapacidade
            // 
            this.txtLimiteTempoCapacidade.Location = new System.Drawing.Point(31, 531);
            this.txtLimiteTempoCapacidade.MaxLength = 10;
            this.txtLimiteTempoCapacidade.Name = "txtLimiteTempoCapacidade";
            this.txtLimiteTempoCapacidade.Size = new System.Drawing.Size(166, 20);
            this.txtLimiteTempoCapacidade.TabIndex = 37;
            this.txtLimiteTempoCapacidade.Tag = "3";
            this.txtLimiteTempoCapacidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteTempoCapacidade_KeyPress);
            // 
            // lblLimiteTempoCapacidade
            // 
            this.lblLimiteTempoCapacidade.AutoSize = true;
            this.lblLimiteTempoCapacidade.Location = new System.Drawing.Point(28, 511);
            this.lblLimiteTempoCapacidade.Name = "lblLimiteTempoCapacidade";
            this.lblLimiteTempoCapacidade.Size = new System.Drawing.Size(145, 13);
            this.lblLimiteTempoCapacidade.TabIndex = 36;
            this.lblLimiteTempoCapacidade.Text = "Limite de Tempo Capacidade";
            // 
            // lblReduzirPrevisao
            // 
            this.lblReduzirPrevisao.AutoSize = true;
            this.lblReduzirPrevisao.Location = new System.Drawing.Point(28, 564);
            this.lblReduzirPrevisao.Name = "lblReduzirPrevisao";
            this.lblReduzirPrevisao.Size = new System.Drawing.Size(87, 13);
            this.lblReduzirPrevisao.TabIndex = 40;
            this.lblReduzirPrevisao.Text = "Reduzir Previsão";
            // 
            // cboReduzirPrevisao
            // 
            this.cboReduzirPrevisao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboReduzirPrevisao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboReduzirPrevisao.FormattingEnabled = true;
            this.cboReduzirPrevisao.Location = new System.Drawing.Point(31, 583);
            this.cboReduzirPrevisao.Name = "cboReduzirPrevisao";
            this.cboReduzirPrevisao.Size = new System.Drawing.Size(217, 21);
            this.cboReduzirPrevisao.TabIndex = 41;
            this.cboReduzirPrevisao.Tag = "1";
            // 
            // frmGrupoCoberturaCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(409, 607);
            this.Controls.Add(this.lblReduzirPrevisao);
            this.Controls.Add(this.cboReduzirPrevisao);
            this.Controls.Add(this.txtLimitePlanoPrevisao);
            this.Controls.Add(this.lblLimitePlanoPrevisao);
            this.Controls.Add(this.txtLimiteTempoCapacidade);
            this.Controls.Add(this.lblLimiteTempoCapacidade);
            this.Controls.Add(this.txtLimiteTempoDetalhamento);
            this.Controls.Add(this.lblLimiteTempoDetalhamento);
            this.Controls.Add(this.txtLimiteTempoCobertura);
            this.Controls.Add(this.lblLimiteTempoCobertura);
            this.Controls.Add(this.lblStatusProducao);
            this.Controls.Add(this.cboStatusProducao);
            this.Controls.Add(this.txtDiasPositivo);
            this.Controls.Add(this.lblDiasPositivo);
            this.Controls.Add(this.txtDiasNegativo);
            this.Controls.Add(this.lblDiasNegativo);
            this.Controls.Add(this.txtLimiteTempo);
            this.Controls.Add(this.lblLimiteTempo);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.lblPeriodo);
            this.Controls.Add(this.lblCobertura);
            this.Controls.Add(this.cboCobertura);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmGrupoCoberturaCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmGrupoCoberturaCad";
            this.Text = "Cadastro Grupo de Cobertura";
            this.Load += new System.EventHandler(this.frmGrupoCoberturaCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGrupoCoberturaCad_KeyDown);
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
        private System.Windows.Forms.Label lblCobertura;
        private System.Windows.Forms.ComboBox cboCobertura;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.TextBox txtLimiteTempo;
        private System.Windows.Forms.Label lblLimiteTempo;
        private System.Windows.Forms.TextBox txtDiasNegativo;
        private System.Windows.Forms.Label lblDiasNegativo;
        private System.Windows.Forms.TextBox txtDiasPositivo;
        private System.Windows.Forms.Label lblDiasPositivo;
        private System.Windows.Forms.Label lblStatusProducao;
        private System.Windows.Forms.ComboBox cboStatusProducao;
        private System.Windows.Forms.TextBox txtLimiteTempoCobertura;
        private System.Windows.Forms.Label lblLimiteTempoCobertura;
        private System.Windows.Forms.TextBox txtLimiteTempoDetalhamento;
        private System.Windows.Forms.Label lblLimiteTempoDetalhamento;
        private System.Windows.Forms.TextBox txtLimitePlanoPrevisao;
        private System.Windows.Forms.Label lblLimitePlanoPrevisao;
        private System.Windows.Forms.TextBox txtLimiteTempoCapacidade;
        private System.Windows.Forms.Label lblLimiteTempoCapacidade;
        private System.Windows.Forms.Label lblReduzirPrevisao;
        private System.Windows.Forms.ComboBox cboReduzirPrevisao;
    }
}