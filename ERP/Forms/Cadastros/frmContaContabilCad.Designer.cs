namespace ERP
{
    partial class frmContaContabilCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContaContabilCad));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.btnImprimir = new System.Windows.Forms.RibbonButton();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblTipoLancamento = new System.Windows.Forms.Label();
            this.cboTipoLancamento = new System.Windows.Forms.ComboBox();
            this.lblDebitoCredito = new System.Windows.Forms.Label();
            this.cboDebitoCredito = new System.Windows.Forms.ComboBox();
            this.chkFechar = new System.Windows.Forms.CheckBox();
            this.lblContaPai = new System.Windows.Forms.Label();
            this.cboContaPai = new System.Windows.Forms.ComboBox();
            this.lblContaConsolidacao = new System.Windows.Forms.Label();
            this.cboContaConsolidacao = new System.Windows.Forms.ComboBox();
            this.lblMoeda = new System.Windows.Forms.Label();
            this.cboMoeda = new System.Windows.Forms.ComboBox();
            this.lblTipoConta = new System.Windows.Forms.Label();
            this.cboTipoConta = new System.Windows.Forms.ComboBox();
            this.lblContaPlanoReferencial = new System.Windows.Forms.Label();
            this.cboContaPlanoReferencial = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDePara = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboNatureza = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNivel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTipoReceitaDespesa = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            this.ribbon1.Size = new System.Drawing.Size(784, 125);
            this.ribbon1.TabIndex = 19;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // rbOpcoes
            // 
            this.rbOpcoes.Panels.Add(this.ribbonPanel1);
            this.rbOpcoes.Panels.Add(this.ribbonPanel2);
            this.rbOpcoes.Text = "Documento";
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
            // btnAdiciona
            // 
            this.btnAdiciona.Image = ((System.Drawing.Image)(resources.GetObject("btnAdiciona.Image")));
            this.btnAdiciona.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAdiciona.SmallImage")));
            this.btnAdiciona.Text = "Adicionar";
            this.btnAdiciona.Click += new System.EventHandler(this.btnAdiciona_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAlterar.SmallImage")));
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnGrava
            // 
            this.btnGrava.Enabled = false;
            this.btnGrava.Image = ((System.Drawing.Image)(resources.GetObject("btnGrava.Image")));
            this.btnGrava.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGrava.SmallImage")));
            this.btnGrava.Text = "Gravar";
            this.btnGrava.Click += new System.EventHandler(this.btnGrava_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.SmallImage")));
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnExcluir.SmallImage")));
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.btnImprimir);
            this.ribbonPanel2.Text = "Relatórios";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.SmallImage")));
            this.btnImprimir.Text = "Imprimir";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(320, 156);
            this.txtDescricao.MaxLength = 255;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(440, 20);
            this.txtDescricao.TabIndex = 24;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(317, 140);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 23;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(27, 156);
            this.txtCodigo.MaxLength = 50;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(287, 20);
            this.txtCodigo.TabIndex = 22;
            this.txtCodigo.Tag = "1";
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(24, 140);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(40, 13);
            this.lblNome.TabIndex = 21;
            this.lblNome.Text = "Código";
            // 
            // lblTipoLancamento
            // 
            this.lblTipoLancamento.AutoSize = true;
            this.lblTipoLancamento.Location = new System.Drawing.Point(24, 208);
            this.lblTipoLancamento.Name = "lblTipoLancamento";
            this.lblTipoLancamento.Size = new System.Drawing.Size(105, 13);
            this.lblTipoLancamento.TabIndex = 65;
            this.lblTipoLancamento.Text = "Tipo de Lançamento";
            // 
            // cboTipoLancamento
            // 
            this.cboTipoLancamento.FormattingEnabled = true;
            this.cboTipoLancamento.Location = new System.Drawing.Point(27, 224);
            this.cboTipoLancamento.Name = "cboTipoLancamento";
            this.cboTipoLancamento.Size = new System.Drawing.Size(228, 21);
            this.cboTipoLancamento.TabIndex = 64;
            this.cboTipoLancamento.Tag = "1";
            // 
            // lblDebitoCredito
            // 
            this.lblDebitoCredito.AutoSize = true;
            this.lblDebitoCredito.Location = new System.Drawing.Point(258, 208);
            this.lblDebitoCredito.Name = "lblDebitoCredito";
            this.lblDebitoCredito.Size = new System.Drawing.Size(76, 13);
            this.lblDebitoCredito.TabIndex = 67;
            this.lblDebitoCredito.Text = "Débito/Crédito";
            // 
            // cboDebitoCredito
            // 
            this.cboDebitoCredito.FormattingEnabled = true;
            this.cboDebitoCredito.Location = new System.Drawing.Point(261, 224);
            this.cboDebitoCredito.Name = "cboDebitoCredito";
            this.cboDebitoCredito.Size = new System.Drawing.Size(247, 21);
            this.cboDebitoCredito.TabIndex = 66;
            this.cboDebitoCredito.Tag = "1";
            // 
            // chkFechar
            // 
            this.chkFechar.AutoSize = true;
            this.chkFechar.Location = new System.Drawing.Point(152, 424);
            this.chkFechar.Name = "chkFechar";
            this.chkFechar.Size = new System.Drawing.Size(59, 17);
            this.chkFechar.TabIndex = 68;
            this.chkFechar.Text = "Fechar";
            this.chkFechar.UseVisualStyleBackColor = true;
            // 
            // lblContaPai
            // 
            this.lblContaPai.AutoSize = true;
            this.lblContaPai.Location = new System.Drawing.Point(511, 208);
            this.lblContaPai.Name = "lblContaPai";
            this.lblContaPai.Size = new System.Drawing.Size(53, 13);
            this.lblContaPai.TabIndex = 70;
            this.lblContaPai.Text = "Conta Pai";
            // 
            // cboContaPai
            // 
            this.cboContaPai.FormattingEnabled = true;
            this.cboContaPai.Location = new System.Drawing.Point(514, 224);
            this.cboContaPai.Name = "cboContaPai";
            this.cboContaPai.Size = new System.Drawing.Size(246, 21);
            this.cboContaPai.TabIndex = 69;
            this.cboContaPai.Tag = "";
            // 
            // lblContaConsolidacao
            // 
            this.lblContaConsolidacao.AutoSize = true;
            this.lblContaConsolidacao.Location = new System.Drawing.Point(24, 268);
            this.lblContaConsolidacao.Name = "lblContaConsolidacao";
            this.lblContaConsolidacao.Size = new System.Drawing.Size(117, 13);
            this.lblContaConsolidacao.TabIndex = 72;
            this.lblContaConsolidacao.Text = "Conta de Consolidação";
            // 
            // cboContaConsolidacao
            // 
            this.cboContaConsolidacao.FormattingEnabled = true;
            this.cboContaConsolidacao.Location = new System.Drawing.Point(27, 284);
            this.cboContaConsolidacao.Name = "cboContaConsolidacao";
            this.cboContaConsolidacao.Size = new System.Drawing.Size(228, 21);
            this.cboContaConsolidacao.TabIndex = 71;
            this.cboContaConsolidacao.Tag = "";
            // 
            // lblMoeda
            // 
            this.lblMoeda.AutoSize = true;
            this.lblMoeda.Location = new System.Drawing.Point(258, 268);
            this.lblMoeda.Name = "lblMoeda";
            this.lblMoeda.Size = new System.Drawing.Size(40, 13);
            this.lblMoeda.TabIndex = 74;
            this.lblMoeda.Text = "Moeda";
            // 
            // cboMoeda
            // 
            this.cboMoeda.FormattingEnabled = true;
            this.cboMoeda.Location = new System.Drawing.Point(261, 284);
            this.cboMoeda.Name = "cboMoeda";
            this.cboMoeda.Size = new System.Drawing.Size(247, 21);
            this.cboMoeda.TabIndex = 73;
            this.cboMoeda.Tag = "1";
            // 
            // lblTipoConta
            // 
            this.lblTipoConta.AutoSize = true;
            this.lblTipoConta.Location = new System.Drawing.Point(511, 268);
            this.lblTipoConta.Name = "lblTipoConta";
            this.lblTipoConta.Size = new System.Drawing.Size(74, 13);
            this.lblTipoConta.TabIndex = 76;
            this.lblTipoConta.Text = "Tipo de Conta";
            // 
            // cboTipoConta
            // 
            this.cboTipoConta.FormattingEnabled = true;
            this.cboTipoConta.Location = new System.Drawing.Point(514, 284);
            this.cboTipoConta.Name = "cboTipoConta";
            this.cboTipoConta.Size = new System.Drawing.Size(246, 21);
            this.cboTipoConta.TabIndex = 75;
            this.cboTipoConta.Tag = "1";
            // 
            // lblContaPlanoReferencial
            // 
            this.lblContaPlanoReferencial.AutoSize = true;
            this.lblContaPlanoReferencial.Location = new System.Drawing.Point(24, 346);
            this.lblContaPlanoReferencial.Name = "lblContaPlanoReferencial";
            this.lblContaPlanoReferencial.Size = new System.Drawing.Size(122, 13);
            this.lblContaPlanoReferencial.TabIndex = 78;
            this.lblContaPlanoReferencial.Text = "Plano Conta Referencial";
            // 
            // cboContaPlanoReferencial
            // 
            this.cboContaPlanoReferencial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboContaPlanoReferencial.DropDownWidth = 700;
            this.cboContaPlanoReferencial.FormattingEnabled = true;
            this.cboContaPlanoReferencial.Location = new System.Drawing.Point(27, 362);
            this.cboContaPlanoReferencial.Name = "cboContaPlanoReferencial";
            this.cboContaPlanoReferencial.Size = new System.Drawing.Size(206, 21);
            this.cboContaPlanoReferencial.TabIndex = 77;
            this.cboContaPlanoReferencial.Tag = "1";
            this.cboContaPlanoReferencial.Enter += new System.EventHandler(this.cboContaPlanoReferencial_Enter);
            // 
            // button1
            // 
            this.button1.Image = global::ERP.Properties.Resources.lupa;
            this.button1.Location = new System.Drawing.Point(233, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 79;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDePara
            // 
            this.txtDePara.Location = new System.Drawing.Point(261, 361);
            this.txtDePara.MaxLength = 50;
            this.txtDePara.Name = "txtDePara";
            this.txtDePara.Size = new System.Drawing.Size(247, 20);
            this.txtDePara.TabIndex = 81;
            this.txtDePara.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "De Para";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(511, 345);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Natureza";
            // 
            // cboNatureza
            // 
            this.cboNatureza.FormattingEnabled = true;
            this.cboNatureza.Location = new System.Drawing.Point(514, 361);
            this.cboNatureza.Name = "cboNatureza";
            this.cboNatureza.Size = new System.Drawing.Size(246, 21);
            this.cboNatureza.TabIndex = 82;
            this.cboNatureza.Tag = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 406);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "Nivel";
            // 
            // cboNivel
            // 
            this.cboNivel.FormattingEnabled = true;
            this.cboNivel.Location = new System.Drawing.Point(27, 422);
            this.cboNivel.Name = "cboNivel";
            this.cboNivel.Size = new System.Drawing.Size(119, 21);
            this.cboNivel.TabIndex = 84;
            this.cboNivel.Tag = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 406);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 87;
            this.label4.Text = "Tipo de Receita e Despesa";
            // 
            // cboTipoReceitaDespesa
            // 
            this.cboTipoReceitaDespesa.FormattingEnabled = true;
            this.cboTipoReceitaDespesa.Location = new System.Drawing.Point(261, 422);
            this.cboTipoReceitaDespesa.Name = "cboTipoReceitaDespesa";
            this.cboTipoReceitaDespesa.Size = new System.Drawing.Size(246, 21);
            this.cboTipoReceitaDespesa.TabIndex = 86;
            this.cboTipoReceitaDespesa.Tag = "1";
            // 
            // frmContaContabilCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 483);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboTipoReceitaDespesa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboNivel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboNatureza);
            this.Controls.Add(this.txtDePara);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblContaPlanoReferencial);
            this.Controls.Add(this.cboContaPlanoReferencial);
            this.Controls.Add(this.lblTipoConta);
            this.Controls.Add(this.cboTipoConta);
            this.Controls.Add(this.lblMoeda);
            this.Controls.Add(this.cboMoeda);
            this.Controls.Add(this.lblContaConsolidacao);
            this.Controls.Add(this.cboContaConsolidacao);
            this.Controls.Add(this.lblContaPai);
            this.Controls.Add(this.cboContaPai);
            this.Controls.Add(this.chkFechar);
            this.Controls.Add(this.lblDebitoCredito);
            this.Controls.Add(this.cboDebitoCredito);
            this.Controls.Add(this.lblTipoLancamento);
            this.Controls.Add(this.cboTipoLancamento);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblNome);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmContaContabilCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "frmContaContabilCad";
            this.Text = "Cadastro de Conta Contábil";
            this.Load += new System.EventHandler(this.frmContaContabilCad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton btnImprimir;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblTipoLancamento;
        private System.Windows.Forms.ComboBox cboTipoLancamento;
        private System.Windows.Forms.Label lblDebitoCredito;
        private System.Windows.Forms.ComboBox cboDebitoCredito;
        private System.Windows.Forms.CheckBox chkFechar;
        private System.Windows.Forms.Label lblContaPai;
        private System.Windows.Forms.ComboBox cboContaPai;
        private System.Windows.Forms.Label lblContaConsolidacao;
        private System.Windows.Forms.ComboBox cboContaConsolidacao;
        private System.Windows.Forms.Label lblMoeda;
        private System.Windows.Forms.ComboBox cboMoeda;
        private System.Windows.Forms.Label lblTipoConta;
        private System.Windows.Forms.ComboBox cboTipoConta;
        private System.Windows.Forms.Label lblContaPlanoReferencial;
        private System.Windows.Forms.ComboBox cboContaPlanoReferencial;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDePara;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboNatureza;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNivel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTipoReceitaDespesa;
    }
}