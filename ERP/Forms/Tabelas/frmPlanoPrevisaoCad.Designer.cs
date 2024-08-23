namespace ERP
{
    partial class frmPlanoPrevisaoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanoPrevisaoCad));
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
            this.chkIncluirPrevisaoFornecimento = new System.Windows.Forms.CheckBox();
            this.chkIncluirPrevisaoDemanda = new System.Windows.Forms.CheckBox();
            this.txtLimiteTempoCobertura = new System.Windows.Forms.TextBox();
            this.lblLimiteTempoCobertura = new System.Windows.Forms.Label();
            this.txtLimiteTempoDetalhamento = new System.Windows.Forms.TextBox();
            this.lblLimiteTempoDetalhamento = new System.Windows.Forms.Label();
            this.txtLimiteTempoCapacidade = new System.Windows.Forms.TextBox();
            this.lblLimiteTempoCapacidade = new System.Windows.Forms.Label();
            this.txtSequenciaOrdensPlanejada = new System.Windows.Forms.TextBox();
            this.lblSequenciaOrdensPlanejadas = new System.Windows.Forms.Label();
            this.lblReducao = new System.Windows.Forms.Label();
            this.cboReducao = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(26, 158);
            this.txtCodigo.MaxLength = 200;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(353, 20);
            this.txtCodigo.TabIndex = 17;
            this.txtCodigo.Tag = "1";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(23, 142);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 16;
            this.lblCodigo.Text = "Código";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(350, 142);
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
            this.ribbon1.Size = new System.Drawing.Size(399, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(26, 208);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(353, 20);
            this.txtDescricao.TabIndex = 19;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(23, 192);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 18;
            this.lblDescricao.Text = "Descrição";
            // 
            // chkIncluirPrevisaoFornecimento
            // 
            this.chkIncluirPrevisaoFornecimento.AutoSize = true;
            this.chkIncluirPrevisaoFornecimento.Location = new System.Drawing.Point(26, 243);
            this.chkIncluirPrevisaoFornecimento.Name = "chkIncluirPrevisaoFornecimento";
            this.chkIncluirPrevisaoFornecimento.Size = new System.Drawing.Size(165, 17);
            this.chkIncluirPrevisaoFornecimento.TabIndex = 79;
            this.chkIncluirPrevisaoFornecimento.Text = "Incluir Previsão Fornecimento";
            this.chkIncluirPrevisaoFornecimento.UseVisualStyleBackColor = true;
            // 
            // chkIncluirPrevisaoDemanda
            // 
            this.chkIncluirPrevisaoDemanda.AutoSize = true;
            this.chkIncluirPrevisaoDemanda.Location = new System.Drawing.Point(216, 243);
            this.chkIncluirPrevisaoDemanda.Name = "chkIncluirPrevisaoDemanda";
            this.chkIncluirPrevisaoDemanda.Size = new System.Drawing.Size(147, 17);
            this.chkIncluirPrevisaoDemanda.TabIndex = 80;
            this.chkIncluirPrevisaoDemanda.Text = "Incluir Previsão Demanda";
            this.chkIncluirPrevisaoDemanda.UseVisualStyleBackColor = true;
            // 
            // txtLimiteTempoCobertura
            // 
            this.txtLimiteTempoCobertura.Location = new System.Drawing.Point(26, 291);
            this.txtLimiteTempoCobertura.MaxLength = 4;
            this.txtLimiteTempoCobertura.Name = "txtLimiteTempoCobertura";
            this.txtLimiteTempoCobertura.Size = new System.Drawing.Size(170, 20);
            this.txtLimiteTempoCobertura.TabIndex = 82;
            this.txtLimiteTempoCobertura.Tag = "1";
            this.txtLimiteTempoCobertura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteTempoCobertura_KeyPress);
            // 
            // lblLimiteTempoCobertura
            // 
            this.lblLimiteTempoCobertura.AutoSize = true;
            this.lblLimiteTempoCobertura.Location = new System.Drawing.Point(23, 275);
            this.lblLimiteTempoCobertura.Name = "lblLimiteTempoCobertura";
            this.lblLimiteTempoCobertura.Size = new System.Drawing.Size(137, 13);
            this.lblLimiteTempoCobertura.TabIndex = 81;
            this.lblLimiteTempoCobertura.Text = " Limite de Tempo Cobertura";
            // 
            // txtLimiteTempoDetalhamento
            // 
            this.txtLimiteTempoDetalhamento.Location = new System.Drawing.Point(209, 291);
            this.txtLimiteTempoDetalhamento.MaxLength = 4;
            this.txtLimiteTempoDetalhamento.Name = "txtLimiteTempoDetalhamento";
            this.txtLimiteTempoDetalhamento.Size = new System.Drawing.Size(170, 20);
            this.txtLimiteTempoDetalhamento.TabIndex = 84;
            this.txtLimiteTempoDetalhamento.Tag = "1";
            this.txtLimiteTempoDetalhamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteTempoDetalhamento_KeyPress);
            // 
            // lblLimiteTempoDetalhamento
            // 
            this.lblLimiteTempoDetalhamento.AutoSize = true;
            this.lblLimiteTempoDetalhamento.Location = new System.Drawing.Point(206, 275);
            this.lblLimiteTempoDetalhamento.Name = "lblLimiteTempoDetalhamento";
            this.lblLimiteTempoDetalhamento.Size = new System.Drawing.Size(157, 13);
            this.lblLimiteTempoDetalhamento.TabIndex = 83;
            this.lblLimiteTempoDetalhamento.Text = " Limite de Tempo Detalhamento";
            // 
            // txtLimiteTempoCapacidade
            // 
            this.txtLimiteTempoCapacidade.Location = new System.Drawing.Point(26, 344);
            this.txtLimiteTempoCapacidade.MaxLength = 4;
            this.txtLimiteTempoCapacidade.Name = "txtLimiteTempoCapacidade";
            this.txtLimiteTempoCapacidade.Size = new System.Drawing.Size(170, 20);
            this.txtLimiteTempoCapacidade.TabIndex = 86;
            this.txtLimiteTempoCapacidade.Tag = "1";
            this.txtLimiteTempoCapacidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteTempoCapacidade_KeyPress);
            // 
            // lblLimiteTempoCapacidade
            // 
            this.lblLimiteTempoCapacidade.AutoSize = true;
            this.lblLimiteTempoCapacidade.Location = new System.Drawing.Point(23, 328);
            this.lblLimiteTempoCapacidade.Name = "lblLimiteTempoCapacidade";
            this.lblLimiteTempoCapacidade.Size = new System.Drawing.Size(148, 13);
            this.lblLimiteTempoCapacidade.TabIndex = 85;
            this.lblLimiteTempoCapacidade.Text = " Limite de Tempo Capacidade";
            // 
            // txtSequenciaOrdensPlanejada
            // 
            this.txtSequenciaOrdensPlanejada.Location = new System.Drawing.Point(209, 344);
            this.txtSequenciaOrdensPlanejada.MaxLength = 5;
            this.txtSequenciaOrdensPlanejada.Name = "txtSequenciaOrdensPlanejada";
            this.txtSequenciaOrdensPlanejada.Size = new System.Drawing.Size(170, 20);
            this.txtSequenciaOrdensPlanejada.TabIndex = 88;
            this.txtSequenciaOrdensPlanejada.Tag = "1";
            // 
            // lblSequenciaOrdensPlanejadas
            // 
            this.lblSequenciaOrdensPlanejadas.AutoSize = true;
            this.lblSequenciaOrdensPlanejadas.Location = new System.Drawing.Point(206, 328);
            this.lblSequenciaOrdensPlanejadas.Name = "lblSequenciaOrdensPlanejadas";
            this.lblSequenciaOrdensPlanejadas.Size = new System.Drawing.Size(165, 13);
            this.lblSequenciaOrdensPlanejadas.TabIndex = 87;
            this.lblSequenciaOrdensPlanejadas.Text = "Sequência das Ordens Planejada";
            // 
            // lblReducao
            // 
            this.lblReducao.AutoSize = true;
            this.lblReducao.Location = new System.Drawing.Point(23, 378);
            this.lblReducao.Name = "lblReducao";
            this.lblReducao.Size = new System.Drawing.Size(51, 13);
            this.lblReducao.TabIndex = 89;
            this.lblReducao.Text = "Redução";
            // 
            // cboReducao
            // 
            this.cboReducao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboReducao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboReducao.DropDownWidth = 255;
            this.cboReducao.FormattingEnabled = true;
            this.cboReducao.Location = new System.Drawing.Point(26, 394);
            this.cboReducao.Name = "cboReducao";
            this.cboReducao.Size = new System.Drawing.Size(170, 21);
            this.cboReducao.TabIndex = 90;
            this.cboReducao.Tag = "1";
            // 
            // frmPlanoPrevisaoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(399, 446);
            this.Controls.Add(this.lblReducao);
            this.Controls.Add(this.cboReducao);
            this.Controls.Add(this.txtSequenciaOrdensPlanejada);
            this.Controls.Add(this.lblSequenciaOrdensPlanejadas);
            this.Controls.Add(this.txtLimiteTempoCapacidade);
            this.Controls.Add(this.lblLimiteTempoCapacidade);
            this.Controls.Add(this.txtLimiteTempoDetalhamento);
            this.Controls.Add(this.lblLimiteTempoDetalhamento);
            this.Controls.Add(this.txtLimiteTempoCobertura);
            this.Controls.Add(this.lblLimiteTempoCobertura);
            this.Controls.Add(this.chkIncluirPrevisaoDemanda);
            this.Controls.Add(this.chkIncluirPrevisaoFornecimento);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmPlanoPrevisaoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmPlanoPrevisaoCad";
            this.Text = "Cadastro Plano Previsão";
            this.Load += new System.EventHandler(this.frmPlanoPrevisaoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPlanoPrevisaoCad_KeyDown);
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
        private System.Windows.Forms.CheckBox chkIncluirPrevisaoFornecimento;
        private System.Windows.Forms.CheckBox chkIncluirPrevisaoDemanda;
        private System.Windows.Forms.TextBox txtLimiteTempoCobertura;
        private System.Windows.Forms.Label lblLimiteTempoCobertura;
        private System.Windows.Forms.TextBox txtLimiteTempoDetalhamento;
        private System.Windows.Forms.Label lblLimiteTempoDetalhamento;
        private System.Windows.Forms.TextBox txtLimiteTempoCapacidade;
        private System.Windows.Forms.Label lblLimiteTempoCapacidade;
        private System.Windows.Forms.TextBox txtSequenciaOrdensPlanejada;
        private System.Windows.Forms.Label lblSequenciaOrdensPlanejadas;
        private System.Windows.Forms.Label lblReducao;
        private System.Windows.Forms.ComboBox cboReducao;
    }
}