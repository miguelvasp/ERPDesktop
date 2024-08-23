namespace ERP
{
    partial class frmPlanoMestreCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanoMestreCad));
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
            this.chkIncluirEstoqueDisponivel = new System.Windows.Forms.CheckBox();
            this.chkIncluirTransacoesEstoque = new System.Windows.Forms.CheckBox();
            this.chkIncluirCotacaoVenda = new System.Windows.Forms.CheckBox();
            this.chkIncluirCotacaoCompra = new System.Windows.Forms.CheckBox();
            this.chkIncluirRequisicoes = new System.Windows.Forms.CheckBox();
            this.chkIncluirPrevisaoDemanda = new System.Windows.Forms.CheckBox();
            this.chkIncluirPrevisaoFornecimento = new System.Windows.Forms.CheckBox();
            this.txtLimiteTempoCobertura = new System.Windows.Forms.TextBox();
            this.lblLimiteTempoCobertura = new System.Windows.Forms.Label();
            this.txtLimiteTempoCapacidade = new System.Windows.Forms.TextBox();
            this.lblLimiteTempoCapacidade = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(24, 156);
            this.txtCodigo.MaxLength = 200;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(341, 20);
            this.txtCodigo.TabIndex = 17;
            this.txtCodigo.Tag = "1";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(21, 140);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 16;
            this.lblCodigo.Text = "Código";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(348, 140);
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
            this.ribbon1.Size = new System.Drawing.Size(390, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(24, 207);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(341, 20);
            this.txtDescricao.TabIndex = 19;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(21, 191);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 18;
            this.lblDescricao.Text = "Descrição";
            // 
            // chkIncluirEstoqueDisponivel
            // 
            this.chkIncluirEstoqueDisponivel.AutoSize = true;
            this.chkIncluirEstoqueDisponivel.Location = new System.Drawing.Point(24, 242);
            this.chkIncluirEstoqueDisponivel.Name = "chkIncluirEstoqueDisponivel";
            this.chkIncluirEstoqueDisponivel.Size = new System.Drawing.Size(150, 17);
            this.chkIncluirEstoqueDisponivel.TabIndex = 22;
            this.chkIncluirEstoqueDisponivel.Text = "Incluir Estoque Disponível";
            this.chkIncluirEstoqueDisponivel.UseVisualStyleBackColor = true;
            // 
            // chkIncluirTransacoesEstoque
            // 
            this.chkIncluirTransacoesEstoque.AutoSize = true;
            this.chkIncluirTransacoesEstoque.Location = new System.Drawing.Point(215, 242);
            this.chkIncluirTransacoesEstoque.Name = "chkIncluirTransacoesEstoque";
            this.chkIncluirTransacoesEstoque.Size = new System.Drawing.Size(155, 17);
            this.chkIncluirTransacoesEstoque.TabIndex = 23;
            this.chkIncluirTransacoesEstoque.Text = "Incluir Transações Estoque";
            this.chkIncluirTransacoesEstoque.UseVisualStyleBackColor = true;
            // 
            // chkIncluirCotacaoVenda
            // 
            this.chkIncluirCotacaoVenda.AutoSize = true;
            this.chkIncluirCotacaoVenda.Location = new System.Drawing.Point(24, 265);
            this.chkIncluirCotacaoVenda.Name = "chkIncluirCotacaoVenda";
            this.chkIncluirCotacaoVenda.Size = new System.Drawing.Size(131, 17);
            this.chkIncluirCotacaoVenda.TabIndex = 24;
            this.chkIncluirCotacaoVenda.Text = "Incluir Cotação Venda";
            this.chkIncluirCotacaoVenda.UseVisualStyleBackColor = true;
            // 
            // chkIncluirCotacaoCompra
            // 
            this.chkIncluirCotacaoCompra.AutoSize = true;
            this.chkIncluirCotacaoCompra.Location = new System.Drawing.Point(215, 265);
            this.chkIncluirCotacaoCompra.Name = "chkIncluirCotacaoCompra";
            this.chkIncluirCotacaoCompra.Size = new System.Drawing.Size(136, 17);
            this.chkIncluirCotacaoCompra.TabIndex = 25;
            this.chkIncluirCotacaoCompra.Text = "Incluir Cotação Compra";
            this.chkIncluirCotacaoCompra.UseVisualStyleBackColor = true;
            // 
            // chkIncluirRequisicoes
            // 
            this.chkIncluirRequisicoes.AutoSize = true;
            this.chkIncluirRequisicoes.Location = new System.Drawing.Point(24, 288);
            this.chkIncluirRequisicoes.Name = "chkIncluirRequisicoes";
            this.chkIncluirRequisicoes.Size = new System.Drawing.Size(115, 17);
            this.chkIncluirRequisicoes.TabIndex = 26;
            this.chkIncluirRequisicoes.Text = "Incluir Requisições";
            this.chkIncluirRequisicoes.UseVisualStyleBackColor = true;
            // 
            // chkIncluirPrevisaoDemanda
            // 
            this.chkIncluirPrevisaoDemanda.AutoSize = true;
            this.chkIncluirPrevisaoDemanda.Location = new System.Drawing.Point(215, 288);
            this.chkIncluirPrevisaoDemanda.Name = "chkIncluirPrevisaoDemanda";
            this.chkIncluirPrevisaoDemanda.Size = new System.Drawing.Size(147, 17);
            this.chkIncluirPrevisaoDemanda.TabIndex = 27;
            this.chkIncluirPrevisaoDemanda.Text = "Incluir Previsão Demanda";
            this.chkIncluirPrevisaoDemanda.UseVisualStyleBackColor = true;
            // 
            // chkIncluirPrevisaoFornecimento
            // 
            this.chkIncluirPrevisaoFornecimento.AutoSize = true;
            this.chkIncluirPrevisaoFornecimento.Location = new System.Drawing.Point(24, 311);
            this.chkIncluirPrevisaoFornecimento.Name = "chkIncluirPrevisaoFornecimento";
            this.chkIncluirPrevisaoFornecimento.Size = new System.Drawing.Size(165, 17);
            this.chkIncluirPrevisaoFornecimento.TabIndex = 28;
            this.chkIncluirPrevisaoFornecimento.Text = "Incluir Previsão Fornecimento";
            this.chkIncluirPrevisaoFornecimento.UseVisualStyleBackColor = true;
            // 
            // txtLimiteTempoCobertura
            // 
            this.txtLimiteTempoCobertura.Location = new System.Drawing.Point(24, 358);
            this.txtLimiteTempoCobertura.MaxLength = 3;
            this.txtLimiteTempoCobertura.Name = "txtLimiteTempoCobertura";
            this.txtLimiteTempoCobertura.Size = new System.Drawing.Size(166, 20);
            this.txtLimiteTempoCobertura.TabIndex = 30;
            this.txtLimiteTempoCobertura.Tag = "1";
            this.txtLimiteTempoCobertura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteTempoCobertura_KeyPress);
            // 
            // lblLimiteTempoCobertura
            // 
            this.lblLimiteTempoCobertura.AutoSize = true;
            this.lblLimiteTempoCobertura.Location = new System.Drawing.Point(21, 342);
            this.lblLimiteTempoCobertura.Name = "lblLimiteTempoCobertura";
            this.lblLimiteTempoCobertura.Size = new System.Drawing.Size(134, 13);
            this.lblLimiteTempoCobertura.TabIndex = 29;
            this.lblLimiteTempoCobertura.Text = "Limite de Tempo Cobertura";
            // 
            // txtLimiteTempoCapacidade
            // 
            this.txtLimiteTempoCapacidade.Location = new System.Drawing.Point(200, 358);
            this.txtLimiteTempoCapacidade.MaxLength = 3;
            this.txtLimiteTempoCapacidade.Name = "txtLimiteTempoCapacidade";
            this.txtLimiteTempoCapacidade.Size = new System.Drawing.Size(166, 20);
            this.txtLimiteTempoCapacidade.TabIndex = 32;
            this.txtLimiteTempoCapacidade.Tag = "1";
            this.txtLimiteTempoCapacidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteTempoCapacidade_KeyPress);
            // 
            // lblLimiteTempoCapacidade
            // 
            this.lblLimiteTempoCapacidade.AutoSize = true;
            this.lblLimiteTempoCapacidade.Location = new System.Drawing.Point(197, 342);
            this.lblLimiteTempoCapacidade.Name = "lblLimiteTempoCapacidade";
            this.lblLimiteTempoCapacidade.Size = new System.Drawing.Size(141, 13);
            this.lblLimiteTempoCapacidade.TabIndex = 31;
            this.lblLimiteTempoCapacidade.Text = "Limite de tempo Capacidade";
            // 
            // frmPlanoMestreCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(390, 417);
            this.Controls.Add(this.txtLimiteTempoCapacidade);
            this.Controls.Add(this.lblLimiteTempoCapacidade);
            this.Controls.Add(this.txtLimiteTempoCobertura);
            this.Controls.Add(this.lblLimiteTempoCobertura);
            this.Controls.Add(this.chkIncluirPrevisaoFornecimento);
            this.Controls.Add(this.chkIncluirPrevisaoDemanda);
            this.Controls.Add(this.chkIncluirRequisicoes);
            this.Controls.Add(this.chkIncluirCotacaoCompra);
            this.Controls.Add(this.chkIncluirCotacaoVenda);
            this.Controls.Add(this.chkIncluirTransacoesEstoque);
            this.Controls.Add(this.chkIncluirEstoqueDisponivel);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmPlanoMestreCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmPlanoMestreCad";
            this.Text = "Cadastro Plano Mestre";
            this.Load += new System.EventHandler(this.frmPlanoMestreCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPlanoMestreCad_KeyDown);
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
        private System.Windows.Forms.CheckBox chkIncluirEstoqueDisponivel;
        private System.Windows.Forms.CheckBox chkIncluirTransacoesEstoque;
        private System.Windows.Forms.CheckBox chkIncluirCotacaoVenda;
        private System.Windows.Forms.CheckBox chkIncluirCotacaoCompra;
        private System.Windows.Forms.CheckBox chkIncluirRequisicoes;
        private System.Windows.Forms.CheckBox chkIncluirPrevisaoDemanda;
        private System.Windows.Forms.CheckBox chkIncluirPrevisaoFornecimento;
        private System.Windows.Forms.TextBox txtLimiteTempoCobertura;
        private System.Windows.Forms.Label lblLimiteTempoCobertura;
        private System.Windows.Forms.TextBox txtLimiteTempoCapacidade;
        private System.Windows.Forms.Label lblLimiteTempoCapacidade;
    }
}