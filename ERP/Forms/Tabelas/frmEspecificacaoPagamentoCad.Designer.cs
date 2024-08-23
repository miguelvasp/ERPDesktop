namespace ERP
{
    partial class frmEspecificacaoPagamentoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEspecificacaoPagamentoCad));
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
            this.cboMetodoPagamento = new System.Windows.Forms.ComboBox();
            this.lblMetodoPagamento = new System.Windows.Forms.Label();
            this.cboSegmento = new System.Windows.Forms.ComboBox();
            this.Segmento = new System.Windows.Forms.Label();
            this.cboControleDeExportacao = new System.Windows.Forms.ComboBox();
            this.lblControleDeExportacao = new System.Windows.Forms.Label();
            this.cboTipoPagamento = new System.Windows.Forms.ComboBox();
            this.lblTipoPagamento = new System.Windows.Forms.Label();
            this.cboFormaPagamento = new System.Windows.Forms.ComboBox();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(28, 198);
            this.txtNome.MaxLength = 255;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(337, 20);
            this.txtNome.TabIndex = 15;
            this.txtNome.Tag = "1";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(25, 182);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 14;
            this.lblNome.Text = "Nome";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(352, 137);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 13;
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
            this.ribbon1.Size = new System.Drawing.Size(423, 125);
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // cboMetodoPagamento
            // 
            this.cboMetodoPagamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMetodoPagamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMetodoPagamento.FormattingEnabled = true;
            this.cboMetodoPagamento.Location = new System.Drawing.Point(28, 153);
            this.cboMetodoPagamento.Name = "cboMetodoPagamento";
            this.cboMetodoPagamento.Size = new System.Drawing.Size(337, 21);
            this.cboMetodoPagamento.TabIndex = 17;
            this.cboMetodoPagamento.Tag = "1";
            // 
            // lblMetodoPagamento
            // 
            this.lblMetodoPagamento.AutoSize = true;
            this.lblMetodoPagamento.Location = new System.Drawing.Point(25, 138);
            this.lblMetodoPagamento.Name = "lblMetodoPagamento";
            this.lblMetodoPagamento.Size = new System.Drawing.Size(115, 13);
            this.lblMetodoPagamento.TabIndex = 16;
            this.lblMetodoPagamento.Text = "Método de Pagamento";
            // 
            // cboSegmento
            // 
            this.cboSegmento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSegmento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSegmento.FormattingEnabled = true;
            this.cboSegmento.Location = new System.Drawing.Point(28, 397);
            this.cboSegmento.Name = "cboSegmento";
            this.cboSegmento.Size = new System.Drawing.Size(337, 21);
            this.cboSegmento.TabIndex = 25;
            this.cboSegmento.Tag = "1";
            // 
            // Segmento
            // 
            this.Segmento.AutoSize = true;
            this.Segmento.Location = new System.Drawing.Point(25, 382);
            this.Segmento.Name = "Segmento";
            this.Segmento.Size = new System.Drawing.Size(97, 13);
            this.Segmento.TabIndex = 24;
            this.Segmento.Text = "SegmentoBancario";
            // 
            // cboControleDeExportacao
            // 
            this.cboControleDeExportacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboControleDeExportacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboControleDeExportacao.FormattingEnabled = true;
            this.cboControleDeExportacao.Location = new System.Drawing.Point(28, 250);
            this.cboControleDeExportacao.Name = "cboControleDeExportacao";
            this.cboControleDeExportacao.Size = new System.Drawing.Size(337, 21);
            this.cboControleDeExportacao.TabIndex = 19;
            this.cboControleDeExportacao.Tag = "1";
            // 
            // lblControleDeExportacao
            // 
            this.lblControleDeExportacao.AutoSize = true;
            this.lblControleDeExportacao.Location = new System.Drawing.Point(25, 235);
            this.lblControleDeExportacao.Name = "lblControleDeExportacao";
            this.lblControleDeExportacao.Size = new System.Drawing.Size(118, 13);
            this.lblControleDeExportacao.TabIndex = 18;
            this.lblControleDeExportacao.Text = "Controle de Exportação";
            // 
            // cboTipoPagamento
            // 
            this.cboTipoPagamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTipoPagamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoPagamento.FormattingEnabled = true;
            this.cboTipoPagamento.Location = new System.Drawing.Point(28, 300);
            this.cboTipoPagamento.Name = "cboTipoPagamento";
            this.cboTipoPagamento.Size = new System.Drawing.Size(337, 21);
            this.cboTipoPagamento.TabIndex = 21;
            this.cboTipoPagamento.Tag = "1";
            // 
            // lblTipoPagamento
            // 
            this.lblTipoPagamento.AutoSize = true;
            this.lblTipoPagamento.Location = new System.Drawing.Point(25, 285);
            this.lblTipoPagamento.Name = "lblTipoPagamento";
            this.lblTipoPagamento.Size = new System.Drawing.Size(100, 13);
            this.lblTipoPagamento.TabIndex = 20;
            this.lblTipoPagamento.Text = "Tipo de Pagamento";
            // 
            // cboFormaPagamento
            // 
            this.cboFormaPagamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFormaPagamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFormaPagamento.FormattingEnabled = true;
            this.cboFormaPagamento.Location = new System.Drawing.Point(28, 348);
            this.cboFormaPagamento.Name = "cboFormaPagamento";
            this.cboFormaPagamento.Size = new System.Drawing.Size(337, 21);
            this.cboFormaPagamento.TabIndex = 23;
            this.cboFormaPagamento.Tag = "1";
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Location = new System.Drawing.Point(25, 333);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(108, 13);
            this.lblFormaPagamento.TabIndex = 22;
            this.lblFormaPagamento.Text = "Forma de Pagamento";
            // 
            // frmEspecificacaoPagamentoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(423, 454);
            this.Controls.Add(this.cboFormaPagamento);
            this.Controls.Add(this.lblFormaPagamento);
            this.Controls.Add(this.cboTipoPagamento);
            this.Controls.Add(this.lblTipoPagamento);
            this.Controls.Add(this.cboControleDeExportacao);
            this.Controls.Add(this.lblControleDeExportacao);
            this.Controls.Add(this.cboMetodoPagamento);
            this.Controls.Add(this.lblMetodoPagamento);
            this.Controls.Add(this.cboSegmento);
            this.Controls.Add(this.Segmento);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmEspecificacaoPagamentoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "frmEspecificacaoPagamentoCad";
            this.Text = "Cadastro de Especificação de Pagamento";
            this.Load += new System.EventHandler(this.frmEspecificacaoPagamentoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEspecificacaoPagamentoCad_KeyDown);
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
        private System.Windows.Forms.ComboBox cboSegmento;
        private System.Windows.Forms.Label Segmento;
        private System.Windows.Forms.ComboBox cboControleDeExportacao;
        private System.Windows.Forms.Label lblControleDeExportacao;
        private System.Windows.Forms.ComboBox cboTipoPagamento;
        private System.Windows.Forms.Label lblTipoPagamento;
        private System.Windows.Forms.ComboBox cboFormaPagamento;
        private System.Windows.Forms.Label lblFormaPagamento;
        public System.Windows.Forms.ComboBox cboMetodoPagamento;
        public System.Windows.Forms.Label lblMetodoPagamento;
    }
}