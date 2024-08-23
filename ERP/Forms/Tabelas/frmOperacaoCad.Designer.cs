namespace ERP
{
    partial class frmOperacaoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOperacaoCad));
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
            this.chkMovimentoEstoque = new System.Windows.Forms.CheckBox();
            this.chkTransacoesFinanceiras = new System.Windows.Forms.CheckBox();
            this.cboContaContabil = new System.Windows.Forms.ComboBox();
            this.lblContaContabil = new System.Windows.Forms.Label();
            this.cboPerfilCliente = new System.Windows.Forms.ComboBox();
            this.lblPerfilCliente = new System.Windows.Forms.Label();
            this.cboPerfilFornecedor = new System.Windows.Forms.ComboBox();
            this.lblPerfilFornecedor = new System.Windows.Forms.Label();
            this.cboTipoDirNota = new System.Windows.Forms.ComboBox();
            this.cboDirecaoNotaFiscal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCFOPInterno = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCFOPExterno = new System.Windows.Forms.ComboBox();
            this.chkBonificacao = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(28, 150);
            this.txtCodigo.MaxLength = 10;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(184, 20);
            this.txtCodigo.TabIndex = 17;
            this.txtCodigo.Tag = "1";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(25, 134);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 16;
            this.lblCodigo.Text = "Código";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(352, 134);
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
            this.ribbon1.Size = new System.Drawing.Size(600, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(218, 150);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(349, 20);
            this.txtDescricao.TabIndex = 19;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(215, 134);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 18;
            this.lblDescricao.Text = "Descrição";
            // 
            // chkMovimentoEstoque
            // 
            this.chkMovimentoEstoque.AutoSize = true;
            this.chkMovimentoEstoque.Location = new System.Drawing.Point(28, 186);
            this.chkMovimentoEstoque.Name = "chkMovimentoEstoque";
            this.chkMovimentoEstoque.Size = new System.Drawing.Size(135, 17);
            this.chkMovimentoEstoque.TabIndex = 20;
            this.chkMovimentoEstoque.Text = "Movimento de Estoque";
            this.chkMovimentoEstoque.UseVisualStyleBackColor = true;
            // 
            // chkTransacoesFinanceiras
            // 
            this.chkTransacoesFinanceiras.AutoSize = true;
            this.chkTransacoesFinanceiras.Location = new System.Drawing.Point(178, 186);
            this.chkTransacoesFinanceiras.Name = "chkTransacoesFinanceiras";
            this.chkTransacoesFinanceiras.Size = new System.Drawing.Size(139, 17);
            this.chkTransacoesFinanceiras.TabIndex = 21;
            this.chkTransacoesFinanceiras.Text = "Transações Financeiras";
            this.chkTransacoesFinanceiras.UseVisualStyleBackColor = true;
            // 
            // cboContaContabil
            // 
            this.cboContaContabil.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboContaContabil.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboContaContabil.FormattingEnabled = true;
            this.cboContaContabil.Location = new System.Drawing.Point(28, 249);
            this.cboContaContabil.Name = "cboContaContabil";
            this.cboContaContabil.Size = new System.Drawing.Size(539, 21);
            this.cboContaContabil.TabIndex = 23;
            this.cboContaContabil.Tag = "";
            // 
            // lblContaContabil
            // 
            this.lblContaContabil.AutoSize = true;
            this.lblContaContabil.Location = new System.Drawing.Point(25, 234);
            this.lblContaContabil.Name = "lblContaContabil";
            this.lblContaContabil.Size = new System.Drawing.Size(76, 13);
            this.lblContaContabil.TabIndex = 22;
            this.lblContaContabil.Text = "Conta Contábil";
            // 
            // cboPerfilCliente
            // 
            this.cboPerfilCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPerfilCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPerfilCliente.FormattingEnabled = true;
            this.cboPerfilCliente.Location = new System.Drawing.Point(28, 296);
            this.cboPerfilCliente.Name = "cboPerfilCliente";
            this.cboPerfilCliente.Size = new System.Drawing.Size(253, 21);
            this.cboPerfilCliente.TabIndex = 25;
            this.cboPerfilCliente.Tag = "";
            // 
            // lblPerfilCliente
            // 
            this.lblPerfilCliente.AutoSize = true;
            this.lblPerfilCliente.Location = new System.Drawing.Point(25, 281);
            this.lblPerfilCliente.Name = "lblPerfilCliente";
            this.lblPerfilCliente.Size = new System.Drawing.Size(65, 13);
            this.lblPerfilCliente.TabIndex = 24;
            this.lblPerfilCliente.Text = "Perfil Cliente";
            // 
            // cboPerfilFornecedor
            // 
            this.cboPerfilFornecedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPerfilFornecedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPerfilFornecedor.FormattingEnabled = true;
            this.cboPerfilFornecedor.Location = new System.Drawing.Point(287, 296);
            this.cboPerfilFornecedor.Name = "cboPerfilFornecedor";
            this.cboPerfilFornecedor.Size = new System.Drawing.Size(280, 21);
            this.cboPerfilFornecedor.TabIndex = 27;
            this.cboPerfilFornecedor.Tag = "";
            // 
            // lblPerfilFornecedor
            // 
            this.lblPerfilFornecedor.AutoSize = true;
            this.lblPerfilFornecedor.Location = new System.Drawing.Point(284, 281);
            this.lblPerfilFornecedor.Name = "lblPerfilFornecedor";
            this.lblPerfilFornecedor.Size = new System.Drawing.Size(87, 13);
            this.lblPerfilFornecedor.TabIndex = 26;
            this.lblPerfilFornecedor.Text = "Perfil Fornecedor";
            // 
            // cboTipoDirNota
            // 
            this.cboTipoDirNota.FormattingEnabled = true;
            this.cboTipoDirNota.Location = new System.Drawing.Point(28, 336);
            this.cboTipoDirNota.Name = "cboTipoDirNota";
            this.cboTipoDirNota.Size = new System.Drawing.Size(253, 21);
            this.cboTipoDirNota.TabIndex = 28;
            // 
            // cboDirecaoNotaFiscal
            // 
            this.cboDirecaoNotaFiscal.FormattingEnabled = true;
            this.cboDirecaoNotaFiscal.Location = new System.Drawing.Point(287, 336);
            this.cboDirecaoNotaFiscal.Name = "cboDirecaoNotaFiscal";
            this.cboDirecaoNotaFiscal.Size = new System.Drawing.Size(280, 21);
            this.cboDirecaoNotaFiscal.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Tipo Direção Nota Fiscal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Direção Nota Fiscal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "CFOP Operação dentro do estado";
            // 
            // cboCFOPInterno
            // 
            this.cboCFOPInterno.FormattingEnabled = true;
            this.cboCFOPInterno.Location = new System.Drawing.Point(28, 384);
            this.cboCFOPInterno.Name = "cboCFOPInterno";
            this.cboCFOPInterno.Size = new System.Drawing.Size(253, 21);
            this.cboCFOPInterno.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "CFOP Operação fora do estado";
            // 
            // cboCFOPExterno
            // 
            this.cboCFOPExterno.FormattingEnabled = true;
            this.cboCFOPExterno.Location = new System.Drawing.Point(287, 384);
            this.cboCFOPExterno.Name = "cboCFOPExterno";
            this.cboCFOPExterno.Size = new System.Drawing.Size(280, 21);
            this.cboCFOPExterno.TabIndex = 34;
            // 
            // chkBonificacao
            // 
            this.chkBonificacao.AutoSize = true;
            this.chkBonificacao.Location = new System.Drawing.Point(323, 186);
            this.chkBonificacao.Name = "chkBonificacao";
            this.chkBonificacao.Size = new System.Drawing.Size(82, 17);
            this.chkBonificacao.TabIndex = 36;
            this.chkBonificacao.Text = "Bonificação";
            this.chkBonificacao.UseVisualStyleBackColor = true;
            // 
            // frmOperacaoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(600, 445);
            this.Controls.Add(this.chkBonificacao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCFOPExterno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCFOPInterno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboDirecaoNotaFiscal);
            this.Controls.Add(this.cboTipoDirNota);
            this.Controls.Add(this.cboPerfilFornecedor);
            this.Controls.Add(this.lblPerfilFornecedor);
            this.Controls.Add(this.cboPerfilCliente);
            this.Controls.Add(this.lblPerfilCliente);
            this.Controls.Add(this.cboContaContabil);
            this.Controls.Add(this.lblContaContabil);
            this.Controls.Add(this.chkTransacoesFinanceiras);
            this.Controls.Add(this.chkMovimentoEstoque);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmOperacaoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmOperacaoCad";
            this.Text = "Cadastro de Operação";
            this.Load += new System.EventHandler(this.frmOperacaoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOperacaoCad_KeyDown);
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
        private System.Windows.Forms.CheckBox chkMovimentoEstoque;
        private System.Windows.Forms.CheckBox chkTransacoesFinanceiras;
        private System.Windows.Forms.ComboBox cboContaContabil;
        private System.Windows.Forms.Label lblContaContabil;
        private System.Windows.Forms.ComboBox cboPerfilCliente;
        private System.Windows.Forms.Label lblPerfilCliente;
        private System.Windows.Forms.ComboBox cboPerfilFornecedor;
        private System.Windows.Forms.Label lblPerfilFornecedor;
        private System.Windows.Forms.ComboBox cboTipoDirNota;
        private System.Windows.Forms.ComboBox cboDirecaoNotaFiscal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCFOPInterno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCFOPExterno;
        private System.Windows.Forms.CheckBox chkBonificacao;
    }
}