namespace ERP
{
    partial class frmLancamentoAtivoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLancamentoAtivoCad));
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
            this.cboTipoContaAtivo = new System.Windows.Forms.ComboBox();
            this.lblTipoContaAtivo = new System.Windows.Forms.Label();
            this.cboRelacaoAtivo = new System.Windows.Forms.ComboBox();
            this.lblRelacaoAtivo = new System.Windows.Forms.Label();
            this.cboRelacaoOperacao = new System.Windows.Forms.ComboBox();
            this.lblRelacaoOperacao = new System.Windows.Forms.Label();
            this.cboGrupoAtivo = new System.Windows.Forms.ComboBox();
            this.lblGrupoAtivo = new System.Windows.Forms.Label();
            this.cboRelacaoValores = new System.Windows.Forms.ComboBox();
            this.lblRelacaoValores = new System.Windows.Forms.Label();
            this.cboOperacao = new System.Windows.Forms.ComboBox();
            this.lblOperacao = new System.Windows.Forms.Label();
            this.cboContaContabilContraPartida = new System.Windows.Forms.ComboBox();
            this.lblContaContabilContraPartida = new System.Windows.Forms.Label();
            this.cboContaContabilPartida = new System.Windows.Forms.ComboBox();
            this.lblContaContabilPartida = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(25, 159);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(359, 20);
            this.txtDescricao.TabIndex = 17;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(22, 142);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 16;
            this.lblDescricao.Text = "Descrição";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(349, 143);
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
            this.ribbon1.Size = new System.Drawing.Size(402, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // cboTipoContaAtivo
            // 
            this.cboTipoContaAtivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTipoContaAtivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoContaAtivo.DropDownWidth = 170;
            this.cboTipoContaAtivo.FormattingEnabled = true;
            this.cboTipoContaAtivo.Location = new System.Drawing.Point(25, 208);
            this.cboTipoContaAtivo.Name = "cboTipoContaAtivo";
            this.cboTipoContaAtivo.Size = new System.Drawing.Size(175, 21);
            this.cboTipoContaAtivo.TabIndex = 23;
            this.cboTipoContaAtivo.Tag = "";
            // 
            // lblTipoContaAtivo
            // 
            this.lblTipoContaAtivo.AutoSize = true;
            this.lblTipoContaAtivo.Location = new System.Drawing.Point(22, 192);
            this.lblTipoContaAtivo.Name = "lblTipoContaAtivo";
            this.lblTipoContaAtivo.Size = new System.Drawing.Size(101, 13);
            this.lblTipoContaAtivo.TabIndex = 22;
            this.lblTipoContaAtivo.Text = "Tipo de Conta Ativo";
            // 
            // cboRelacaoAtivo
            // 
            this.cboRelacaoAtivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRelacaoAtivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRelacaoAtivo.DropDownWidth = 170;
            this.cboRelacaoAtivo.FormattingEnabled = true;
            this.cboRelacaoAtivo.Location = new System.Drawing.Point(209, 208);
            this.cboRelacaoAtivo.Name = "cboRelacaoAtivo";
            this.cboRelacaoAtivo.Size = new System.Drawing.Size(175, 21);
            this.cboRelacaoAtivo.TabIndex = 25;
            this.cboRelacaoAtivo.Tag = "";
            // 
            // lblRelacaoAtivo
            // 
            this.lblRelacaoAtivo.AutoSize = true;
            this.lblRelacaoAtivo.Location = new System.Drawing.Point(206, 192);
            this.lblRelacaoAtivo.Name = "lblRelacaoAtivo";
            this.lblRelacaoAtivo.Size = new System.Drawing.Size(74, 13);
            this.lblRelacaoAtivo.TabIndex = 24;
            this.lblRelacaoAtivo.Text = "Relação Ativo";
            // 
            // cboRelacaoOperacao
            // 
            this.cboRelacaoOperacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRelacaoOperacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRelacaoOperacao.DropDownWidth = 170;
            this.cboRelacaoOperacao.FormattingEnabled = true;
            this.cboRelacaoOperacao.Location = new System.Drawing.Point(209, 261);
            this.cboRelacaoOperacao.Name = "cboRelacaoOperacao";
            this.cboRelacaoOperacao.Size = new System.Drawing.Size(175, 21);
            this.cboRelacaoOperacao.TabIndex = 29;
            this.cboRelacaoOperacao.Tag = "";
            // 
            // lblRelacaoOperacao
            // 
            this.lblRelacaoOperacao.AutoSize = true;
            this.lblRelacaoOperacao.Location = new System.Drawing.Point(206, 245);
            this.lblRelacaoOperacao.Name = "lblRelacaoOperacao";
            this.lblRelacaoOperacao.Size = new System.Drawing.Size(97, 13);
            this.lblRelacaoOperacao.TabIndex = 28;
            this.lblRelacaoOperacao.Text = "Relação Operação";
            // 
            // cboGrupoAtivo
            // 
            this.cboGrupoAtivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGrupoAtivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoAtivo.DropDownWidth = 170;
            this.cboGrupoAtivo.FormattingEnabled = true;
            this.cboGrupoAtivo.Location = new System.Drawing.Point(25, 261);
            this.cboGrupoAtivo.Name = "cboGrupoAtivo";
            this.cboGrupoAtivo.Size = new System.Drawing.Size(175, 21);
            this.cboGrupoAtivo.TabIndex = 27;
            this.cboGrupoAtivo.Tag = "";
            // 
            // lblGrupoAtivo
            // 
            this.lblGrupoAtivo.AutoSize = true;
            this.lblGrupoAtivo.Location = new System.Drawing.Point(22, 245);
            this.lblGrupoAtivo.Name = "lblGrupoAtivo";
            this.lblGrupoAtivo.Size = new System.Drawing.Size(63, 13);
            this.lblGrupoAtivo.TabIndex = 26;
            this.lblGrupoAtivo.Text = "Grupo Ativo";
            // 
            // cboRelacaoValores
            // 
            this.cboRelacaoValores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRelacaoValores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRelacaoValores.DropDownWidth = 170;
            this.cboRelacaoValores.FormattingEnabled = true;
            this.cboRelacaoValores.Location = new System.Drawing.Point(209, 313);
            this.cboRelacaoValores.Name = "cboRelacaoValores";
            this.cboRelacaoValores.Size = new System.Drawing.Size(175, 21);
            this.cboRelacaoValores.TabIndex = 33;
            this.cboRelacaoValores.Tag = "";
            // 
            // lblRelacaoValores
            // 
            this.lblRelacaoValores.AutoSize = true;
            this.lblRelacaoValores.Location = new System.Drawing.Point(206, 297);
            this.lblRelacaoValores.Name = "lblRelacaoValores";
            this.lblRelacaoValores.Size = new System.Drawing.Size(85, 13);
            this.lblRelacaoValores.TabIndex = 32;
            this.lblRelacaoValores.Text = "Relação Valores";
            // 
            // cboOperacao
            // 
            this.cboOperacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboOperacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboOperacao.DropDownWidth = 170;
            this.cboOperacao.FormattingEnabled = true;
            this.cboOperacao.Location = new System.Drawing.Point(25, 313);
            this.cboOperacao.Name = "cboOperacao";
            this.cboOperacao.Size = new System.Drawing.Size(175, 21);
            this.cboOperacao.TabIndex = 31;
            this.cboOperacao.Tag = "";
            // 
            // lblOperacao
            // 
            this.lblOperacao.AutoSize = true;
            this.lblOperacao.Location = new System.Drawing.Point(22, 297);
            this.lblOperacao.Name = "lblOperacao";
            this.lblOperacao.Size = new System.Drawing.Size(54, 13);
            this.lblOperacao.TabIndex = 30;
            this.lblOperacao.Text = "Operação";
            // 
            // cboContaContabilContraPartida
            // 
            this.cboContaContabilContraPartida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboContaContabilContraPartida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboContaContabilContraPartida.DropDownWidth = 170;
            this.cboContaContabilContraPartida.FormattingEnabled = true;
            this.cboContaContabilContraPartida.Location = new System.Drawing.Point(209, 365);
            this.cboContaContabilContraPartida.Name = "cboContaContabilContraPartida";
            this.cboContaContabilContraPartida.Size = new System.Drawing.Size(175, 21);
            this.cboContaContabilContraPartida.TabIndex = 37;
            this.cboContaContabilContraPartida.Tag = "";
            // 
            // lblContaContabilContraPartida
            // 
            this.lblContaContabilContraPartida.AutoSize = true;
            this.lblContaContabilContraPartida.Location = new System.Drawing.Point(206, 349);
            this.lblContaContabilContraPartida.Name = "lblContaContabilContraPartida";
            this.lblContaContabilContraPartida.Size = new System.Drawing.Size(152, 13);
            this.lblContaContabilContraPartida.TabIndex = 36;
            this.lblContaContabilContraPartida.Text = "Conta Contábil (Contra Partida)";
            // 
            // cboContaContabilPartida
            // 
            this.cboContaContabilPartida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboContaContabilPartida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboContaContabilPartida.DropDownWidth = 170;
            this.cboContaContabilPartida.FormattingEnabled = true;
            this.cboContaContabilPartida.Location = new System.Drawing.Point(25, 365);
            this.cboContaContabilPartida.Name = "cboContaContabilPartida";
            this.cboContaContabilPartida.Size = new System.Drawing.Size(175, 21);
            this.cboContaContabilPartida.TabIndex = 35;
            this.cboContaContabilPartida.Tag = "";
            // 
            // lblContaContabilPartida
            // 
            this.lblContaContabilPartida.AutoSize = true;
            this.lblContaContabilPartida.Location = new System.Drawing.Point(22, 349);
            this.lblContaContabilPartida.Name = "lblContaContabilPartida";
            this.lblContaContabilPartida.Size = new System.Drawing.Size(118, 13);
            this.lblContaContabilPartida.TabIndex = 34;
            this.lblContaContabilPartida.Text = "Conta Contábil (Partida)";
            // 
            // frmLancamentoAtivoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(402, 394);
            this.Controls.Add(this.cboContaContabilContraPartida);
            this.Controls.Add(this.lblContaContabilContraPartida);
            this.Controls.Add(this.cboContaContabilPartida);
            this.Controls.Add(this.lblContaContabilPartida);
            this.Controls.Add(this.cboRelacaoValores);
            this.Controls.Add(this.lblRelacaoValores);
            this.Controls.Add(this.cboOperacao);
            this.Controls.Add(this.lblOperacao);
            this.Controls.Add(this.cboRelacaoOperacao);
            this.Controls.Add(this.lblRelacaoOperacao);
            this.Controls.Add(this.cboGrupoAtivo);
            this.Controls.Add(this.lblGrupoAtivo);
            this.Controls.Add(this.cboRelacaoAtivo);
            this.Controls.Add(this.lblRelacaoAtivo);
            this.Controls.Add(this.cboTipoContaAtivo);
            this.Controls.Add(this.lblTipoContaAtivo);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmLancamentoAtivoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmLancamentoAtivoCad";
            this.Text = "Cadastro de Lançamento Ativo";
            this.Load += new System.EventHandler(this.frmLancamentoAtivoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLancamentoAtivoCad_KeyDown);
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
        private System.Windows.Forms.ComboBox cboTipoContaAtivo;
        private System.Windows.Forms.Label lblTipoContaAtivo;
        private System.Windows.Forms.ComboBox cboRelacaoAtivo;
        private System.Windows.Forms.Label lblRelacaoAtivo;
        private System.Windows.Forms.ComboBox cboRelacaoOperacao;
        private System.Windows.Forms.Label lblRelacaoOperacao;
        private System.Windows.Forms.ComboBox cboGrupoAtivo;
        private System.Windows.Forms.Label lblGrupoAtivo;
        private System.Windows.Forms.ComboBox cboRelacaoValores;
        private System.Windows.Forms.Label lblRelacaoValores;
        private System.Windows.Forms.ComboBox cboOperacao;
        private System.Windows.Forms.Label lblOperacao;
        private System.Windows.Forms.ComboBox cboContaContabilContraPartida;
        private System.Windows.Forms.Label lblContaContabilContraPartida;
        private System.Windows.Forms.ComboBox cboContaContabilPartida;
        private System.Windows.Forms.Label lblContaContabilPartida;
    }
}