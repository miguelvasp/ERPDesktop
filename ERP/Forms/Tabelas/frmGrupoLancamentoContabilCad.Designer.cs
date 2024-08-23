namespace ERP
{
    partial class frmGrupoLancamentoContabilCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoLancamentoContabilCad));
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.lblImpostoPagar = new System.Windows.Forms.Label();
            this.cboImpostoPagar = new System.Windows.Forms.ComboBox();
            this.lblDespesaImposto = new System.Windows.Forms.Label();
            this.cboDespesaImposto = new System.Windows.Forms.ComboBox();
            this.lblDespesaImpostoUso = new System.Windows.Forms.Label();
            this.cboDespesaImpostoUso = new System.Windows.Forms.ComboBox();
            this.lblImpostoReceber = new System.Windows.Forms.Label();
            this.cboImpostoReceber = new System.Windows.Forms.ComboBox();
            this.lblContaLiquidacao = new System.Windows.Forms.Label();
            this.cboContaLiquidacao = new System.Windows.Forms.ComboBox();
            this.lblImpostoUsoPagar = new System.Windows.Forms.Label();
            this.cboImpostoUsoPagar = new System.Windows.Forms.ComboBox();
            this.lblImpostoReceberCurtoPrazo = new System.Windows.Forms.Label();
            this.cboImpostoReceberCurtoPrazo = new System.Windows.Forms.ComboBox();
            this.lblImpostoReceberLongoPrazo = new System.Windows.Forms.Label();
            this.cboImpostoReceberLongoPrazo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(42, 172);
            this.txtDescricao.MaxLength = 10;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(394, 20);
            this.txtDescricao.TabIndex = 17;
            this.txtDescricao.Tag = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Descrição";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(246, 147);
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
            this.ribbon1.Size = new System.Drawing.Size(884, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // lblImpostoPagar
            // 
            this.lblImpostoPagar.AutoSize = true;
            this.lblImpostoPagar.Location = new System.Drawing.Point(39, 228);
            this.lblImpostoPagar.Name = "lblImpostoPagar";
            this.lblImpostoPagar.Size = new System.Drawing.Size(84, 13);
            this.lblImpostoPagar.TabIndex = 18;
            this.lblImpostoPagar.Text = "Imposto a Pagar";
            // 
            // cboImpostoPagar
            // 
            this.cboImpostoPagar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboImpostoPagar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboImpostoPagar.FormattingEnabled = true;
            this.cboImpostoPagar.Location = new System.Drawing.Point(42, 247);
            this.cboImpostoPagar.Name = "cboImpostoPagar";
            this.cboImpostoPagar.Size = new System.Drawing.Size(394, 21);
            this.cboImpostoPagar.TabIndex = 19;
            this.cboImpostoPagar.Tag = "";
            // 
            // lblDespesaImposto
            // 
            this.lblDespesaImposto.AutoSize = true;
            this.lblDespesaImposto.Location = new System.Drawing.Point(439, 228);
            this.lblDespesaImposto.Name = "lblDespesaImposto";
            this.lblDespesaImposto.Size = new System.Drawing.Size(112, 13);
            this.lblDespesaImposto.TabIndex = 20;
            this.lblDespesaImposto.Text = "Despesa com Imposto";
            // 
            // cboDespesaImposto
            // 
            this.cboDespesaImposto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDespesaImposto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDespesaImposto.FormattingEnabled = true;
            this.cboDespesaImposto.Location = new System.Drawing.Point(442, 247);
            this.cboDespesaImposto.Name = "cboDespesaImposto";
            this.cboDespesaImposto.Size = new System.Drawing.Size(419, 21);
            this.cboDespesaImposto.TabIndex = 21;
            this.cboDespesaImposto.Tag = "";
            // 
            // lblDespesaImpostoUso
            // 
            this.lblDespesaImpostoUso.AutoSize = true;
            this.lblDespesaImpostoUso.Location = new System.Drawing.Point(439, 308);
            this.lblDespesaImpostoUso.Name = "lblDespesaImpostoUso";
            this.lblDespesaImpostoUso.Size = new System.Drawing.Size(170, 13);
            this.lblDespesaImpostoUso.TabIndex = 24;
            this.lblDespesaImpostoUso.Text = "Despesa com Imposto sobre o uso";
            // 
            // cboDespesaImpostoUso
            // 
            this.cboDespesaImpostoUso.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDespesaImpostoUso.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDespesaImpostoUso.FormattingEnabled = true;
            this.cboDespesaImpostoUso.Location = new System.Drawing.Point(442, 327);
            this.cboDespesaImpostoUso.Name = "cboDespesaImpostoUso";
            this.cboDespesaImpostoUso.Size = new System.Drawing.Size(419, 21);
            this.cboDespesaImpostoUso.TabIndex = 25;
            this.cboDespesaImpostoUso.Tag = "";
            // 
            // lblImpostoReceber
            // 
            this.lblImpostoReceber.AutoSize = true;
            this.lblImpostoReceber.Location = new System.Drawing.Point(39, 308);
            this.lblImpostoReceber.Name = "lblImpostoReceber";
            this.lblImpostoReceber.Size = new System.Drawing.Size(97, 13);
            this.lblImpostoReceber.TabIndex = 22;
            this.lblImpostoReceber.Text = "Imposto a Receber";
            // 
            // cboImpostoReceber
            // 
            this.cboImpostoReceber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboImpostoReceber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboImpostoReceber.FormattingEnabled = true;
            this.cboImpostoReceber.Location = new System.Drawing.Point(42, 327);
            this.cboImpostoReceber.Name = "cboImpostoReceber";
            this.cboImpostoReceber.Size = new System.Drawing.Size(394, 21);
            this.cboImpostoReceber.TabIndex = 23;
            this.cboImpostoReceber.Tag = "";
            // 
            // lblContaLiquidacao
            // 
            this.lblContaLiquidacao.AutoSize = true;
            this.lblContaLiquidacao.Location = new System.Drawing.Point(439, 379);
            this.lblContaLiquidacao.Name = "lblContaLiquidacao";
            this.lblContaLiquidacao.Size = new System.Drawing.Size(105, 13);
            this.lblContaLiquidacao.TabIndex = 28;
            this.lblContaLiquidacao.Text = "Conta de Liquidação";
            // 
            // cboContaLiquidacao
            // 
            this.cboContaLiquidacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboContaLiquidacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboContaLiquidacao.FormattingEnabled = true;
            this.cboContaLiquidacao.Location = new System.Drawing.Point(442, 398);
            this.cboContaLiquidacao.Name = "cboContaLiquidacao";
            this.cboContaLiquidacao.Size = new System.Drawing.Size(419, 21);
            this.cboContaLiquidacao.TabIndex = 29;
            this.cboContaLiquidacao.Tag = "";
            // 
            // lblImpostoUsoPagar
            // 
            this.lblImpostoUsoPagar.AutoSize = true;
            this.lblImpostoUsoPagar.Location = new System.Drawing.Point(39, 379);
            this.lblImpostoUsoPagar.Name = "lblImpostoUsoPagar";
            this.lblImpostoUsoPagar.Size = new System.Drawing.Size(142, 13);
            this.lblImpostoUsoPagar.TabIndex = 26;
            this.lblImpostoUsoPagar.Text = "Imposto sobre o uso a Pagar";
            // 
            // cboImpostoUsoPagar
            // 
            this.cboImpostoUsoPagar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboImpostoUsoPagar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboImpostoUsoPagar.FormattingEnabled = true;
            this.cboImpostoUsoPagar.Location = new System.Drawing.Point(42, 398);
            this.cboImpostoUsoPagar.Name = "cboImpostoUsoPagar";
            this.cboImpostoUsoPagar.Size = new System.Drawing.Size(394, 21);
            this.cboImpostoUsoPagar.TabIndex = 27;
            this.cboImpostoUsoPagar.Tag = "";
            // 
            // lblImpostoReceberCurtoPrazo
            // 
            this.lblImpostoReceberCurtoPrazo.AutoSize = true;
            this.lblImpostoReceberCurtoPrazo.Location = new System.Drawing.Point(439, 451);
            this.lblImpostoReceberCurtoPrazo.Name = "lblImpostoReceberCurtoPrazo";
            this.lblImpostoReceberCurtoPrazo.Size = new System.Drawing.Size(157, 13);
            this.lblImpostoReceberCurtoPrazo.TabIndex = 32;
            this.lblImpostoReceberCurtoPrazo.Text = "Imposto a receber a curto prazo";
            // 
            // cboImpostoReceberCurtoPrazo
            // 
            this.cboImpostoReceberCurtoPrazo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboImpostoReceberCurtoPrazo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboImpostoReceberCurtoPrazo.FormattingEnabled = true;
            this.cboImpostoReceberCurtoPrazo.Location = new System.Drawing.Point(442, 470);
            this.cboImpostoReceberCurtoPrazo.Name = "cboImpostoReceberCurtoPrazo";
            this.cboImpostoReceberCurtoPrazo.Size = new System.Drawing.Size(419, 21);
            this.cboImpostoReceberCurtoPrazo.TabIndex = 33;
            this.cboImpostoReceberCurtoPrazo.Tag = "";
            // 
            // lblImpostoReceberLongoPrazo
            // 
            this.lblImpostoReceberLongoPrazo.AutoSize = true;
            this.lblImpostoReceberLongoPrazo.Location = new System.Drawing.Point(39, 451);
            this.lblImpostoReceberLongoPrazo.Name = "lblImpostoReceberLongoPrazo";
            this.lblImpostoReceberLongoPrazo.Size = new System.Drawing.Size(159, 13);
            this.lblImpostoReceberLongoPrazo.TabIndex = 30;
            this.lblImpostoReceberLongoPrazo.Text = "Imposto a receber a longo prazo";
            // 
            // cboImpostoReceberLongoPrazo
            // 
            this.cboImpostoReceberLongoPrazo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboImpostoReceberLongoPrazo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboImpostoReceberLongoPrazo.FormattingEnabled = true;
            this.cboImpostoReceberLongoPrazo.Location = new System.Drawing.Point(42, 470);
            this.cboImpostoReceberLongoPrazo.Name = "cboImpostoReceberLongoPrazo";
            this.cboImpostoReceberLongoPrazo.Size = new System.Drawing.Size(394, 21);
            this.cboImpostoReceberLongoPrazo.TabIndex = 31;
            this.cboImpostoReceberLongoPrazo.Tag = "";
            // 
            // frmGrupoLancamentoContabilCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.lblImpostoReceberCurtoPrazo);
            this.Controls.Add(this.cboImpostoReceberCurtoPrazo);
            this.Controls.Add(this.lblImpostoReceberLongoPrazo);
            this.Controls.Add(this.cboImpostoReceberLongoPrazo);
            this.Controls.Add(this.lblContaLiquidacao);
            this.Controls.Add(this.cboContaLiquidacao);
            this.Controls.Add(this.lblImpostoUsoPagar);
            this.Controls.Add(this.cboImpostoUsoPagar);
            this.Controls.Add(this.lblDespesaImpostoUso);
            this.Controls.Add(this.cboDespesaImpostoUso);
            this.Controls.Add(this.lblImpostoReceber);
            this.Controls.Add(this.cboImpostoReceber);
            this.Controls.Add(this.lblDespesaImposto);
            this.Controls.Add(this.cboDespesaImposto);
            this.Controls.Add(this.lblImpostoPagar);
            this.Controls.Add(this.cboImpostoPagar);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmGrupoLancamentoContabilCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmGrupoLancamentoContabilCad";
            this.Text = "Cadastro Grupo Lançamento Contábil";
            this.Load += new System.EventHandler(this.frmGrupoLancamentoContabilCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGrupoLancamentoContabilCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.Label lblImpostoPagar;
        private System.Windows.Forms.ComboBox cboImpostoPagar;
        private System.Windows.Forms.Label lblDespesaImposto;
        private System.Windows.Forms.ComboBox cboDespesaImposto;
        private System.Windows.Forms.Label lblDespesaImpostoUso;
        private System.Windows.Forms.ComboBox cboDespesaImpostoUso;
        private System.Windows.Forms.Label lblImpostoReceber;
        private System.Windows.Forms.ComboBox cboImpostoReceber;
        private System.Windows.Forms.Label lblContaLiquidacao;
        private System.Windows.Forms.ComboBox cboContaLiquidacao;
        private System.Windows.Forms.Label lblImpostoUsoPagar;
        private System.Windows.Forms.ComboBox cboImpostoUsoPagar;
        private System.Windows.Forms.Label lblImpostoReceberCurtoPrazo;
        private System.Windows.Forms.ComboBox cboImpostoReceberCurtoPrazo;
        private System.Windows.Forms.Label lblImpostoReceberLongoPrazo;
        private System.Windows.Forms.ComboBox cboImpostoReceberLongoPrazo;
    }
}