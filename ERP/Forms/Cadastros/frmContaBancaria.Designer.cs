namespace ERP
{
    partial class frmContaBancaria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContaBancaria));
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtDigitoConta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDigitoAgencia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAgencia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboBanco = new System.Windows.Forms.ComboBox();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.txtNomeConta = new System.Windows.Forms.TextBox();
            this.lblNomeConta = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.tbc = new System.Windows.Forms.TabControl();
            this.tbpContaBancaria = new System.Windows.Forms.TabPage();
            this.tbpCobranca = new System.Windows.Forms.TabPage();
            this.txtCarteira = new System.Windows.Forms.TextBox();
            this.lblCarteira = new System.Windows.Forms.Label();
            this.txtNossoNumero = new System.Windows.Forms.TextBox();
            this.lblNossoNumero = new System.Windows.Forms.Label();
            this.tbpPagamento = new System.Windows.Forms.TabPage();
            this.tbc.SuspendLayout();
            this.tbpContaBancaria.SuspendLayout();
            this.tbpCobranca.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = global::ERP.Properties.Resources.cancel_icon;
            this.btnExcluir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnExcluir.SmallImage")));
            this.btnExcluir.Text = "Cancelar";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.btnGrava);
            this.ribbonPanel1.Items.Add(this.btnExcluir);
            this.ribbonPanel1.Text = "";
            // 
            // btnGrava
            // 
            this.btnGrava.Image = ((System.Drawing.Image)(resources.GetObject("btnGrava.Image")));
            this.btnGrava.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGrava.SmallImage")));
            this.btnGrava.Text = "Gravar";
            this.btnGrava.Click += new System.EventHandler(this.btnGrava_Click);
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
            this.ribbon1.TabIndex = 40;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDigitoConta
            // 
            this.txtDigitoConta.Location = new System.Drawing.Point(294, 132);
            this.txtDigitoConta.MaxLength = 2;
            this.txtDigitoConta.Name = "txtDigitoConta";
            this.txtDigitoConta.Size = new System.Drawing.Size(50, 20);
            this.txtDigitoConta.TabIndex = 5;
            this.txtDigitoConta.Tag = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Dígito";
            // 
            // txtConta
            // 
            this.txtConta.Location = new System.Drawing.Point(188, 132);
            this.txtConta.Name = "txtConta";
            this.txtConta.Size = new System.Drawing.Size(100, 20);
            this.txtConta.TabIndex = 4;
            this.txtConta.Tag = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Conta Corrente";
            // 
            // txtDigitoAgencia
            // 
            this.txtDigitoAgencia.Location = new System.Drawing.Point(127, 132);
            this.txtDigitoAgencia.MaxLength = 2;
            this.txtDigitoAgencia.Name = "txtDigitoAgencia";
            this.txtDigitoAgencia.Size = new System.Drawing.Size(50, 20);
            this.txtDigitoAgencia.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Dígito";
            // 
            // txtAgencia
            // 
            this.txtAgencia.Location = new System.Drawing.Point(21, 132);
            this.txtAgencia.Name = "txtAgencia";
            this.txtAgencia.Size = new System.Drawing.Size(100, 20);
            this.txtAgencia.TabIndex = 2;
            this.txtAgencia.Tag = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Agência";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Banco";
            // 
            // cboBanco
            // 
            this.cboBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBanco.FormattingEnabled = true;
            this.cboBanco.Location = new System.Drawing.Point(21, 29);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Size = new System.Drawing.Size(323, 21);
            this.cboBanco.TabIndex = 0;
            this.cboBanco.Tag = "1";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(345, 128);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 40;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
            // 
            // txtNomeConta
            // 
            this.txtNomeConta.Location = new System.Drawing.Point(21, 79);
            this.txtNomeConta.Name = "txtNomeConta";
            this.txtNomeConta.Size = new System.Drawing.Size(323, 20);
            this.txtNomeConta.TabIndex = 1;
            this.txtNomeConta.Tag = "1";
            // 
            // lblNomeConta
            // 
            this.lblNomeConta.AutoSize = true;
            this.lblNomeConta.Location = new System.Drawing.Point(18, 63);
            this.lblNomeConta.Name = "lblNomeConta";
            this.lblNomeConta.Size = new System.Drawing.Size(81, 13);
            this.lblNomeConta.TabIndex = 21;
            this.lblNomeConta.Text = "Nome da Conta";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "País";
            // 
            // cboPais
            // 
            this.cboPais.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPais.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(21, 182);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(323, 21);
            this.cboPais.TabIndex = 6;
            this.cboPais.Tag = "1";
            // 
            // tbc
            // 
            this.tbc.Controls.Add(this.tbpContaBancaria);
            this.tbc.Controls.Add(this.tbpCobranca);
            this.tbc.Controls.Add(this.tbpPagamento);
            this.tbc.Location = new System.Drawing.Point(12, 144);
            this.tbc.Name = "tbc";
            this.tbc.SelectedIndex = 0;
            this.tbc.Size = new System.Drawing.Size(383, 326);
            this.tbc.TabIndex = 56;
            // 
            // tbpContaBancaria
            // 
            this.tbpContaBancaria.Controls.Add(this.label1);
            this.tbpContaBancaria.Controls.Add(this.label10);
            this.tbpContaBancaria.Controls.Add(this.cboBanco);
            this.tbpContaBancaria.Controls.Add(this.cboPais);
            this.tbpContaBancaria.Controls.Add(this.label2);
            this.tbpContaBancaria.Controls.Add(this.txtNomeConta);
            this.tbpContaBancaria.Controls.Add(this.txtAgencia);
            this.tbpContaBancaria.Controls.Add(this.lblNomeConta);
            this.tbpContaBancaria.Controls.Add(this.label3);
            this.tbpContaBancaria.Controls.Add(this.txtDigitoConta);
            this.tbpContaBancaria.Controls.Add(this.txtDigitoAgencia);
            this.tbpContaBancaria.Controls.Add(this.label4);
            this.tbpContaBancaria.Controls.Add(this.label5);
            this.tbpContaBancaria.Controls.Add(this.txtConta);
            this.tbpContaBancaria.Location = new System.Drawing.Point(4, 22);
            this.tbpContaBancaria.Name = "tbpContaBancaria";
            this.tbpContaBancaria.Padding = new System.Windows.Forms.Padding(3);
            this.tbpContaBancaria.Size = new System.Drawing.Size(375, 300);
            this.tbpContaBancaria.TabIndex = 0;
            this.tbpContaBancaria.Text = "Conta Bancária";
            this.tbpContaBancaria.UseVisualStyleBackColor = true;
            // 
            // tbpCobranca
            // 
            this.tbpCobranca.Controls.Add(this.txtCarteira);
            this.tbpCobranca.Controls.Add(this.lblCarteira);
            this.tbpCobranca.Controls.Add(this.txtNossoNumero);
            this.tbpCobranca.Controls.Add(this.lblNossoNumero);
            this.tbpCobranca.Location = new System.Drawing.Point(4, 22);
            this.tbpCobranca.Name = "tbpCobranca";
            this.tbpCobranca.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCobranca.Size = new System.Drawing.Size(375, 300);
            this.tbpCobranca.TabIndex = 1;
            this.tbpCobranca.Text = "Cobrança";
            this.tbpCobranca.UseVisualStyleBackColor = true;
            // 
            // txtCarteira
            // 
            this.txtCarteira.Location = new System.Drawing.Point(19, 85);
            this.txtCarteira.MaxLength = 30;
            this.txtCarteira.Name = "txtCarteira";
            this.txtCarteira.Size = new System.Drawing.Size(323, 20);
            this.txtCarteira.TabIndex = 8;
            this.txtCarteira.Tag = "";
            // 
            // lblCarteira
            // 
            this.lblCarteira.AutoSize = true;
            this.lblCarteira.Location = new System.Drawing.Point(16, 69);
            this.lblCarteira.Name = "lblCarteira";
            this.lblCarteira.Size = new System.Drawing.Size(43, 13);
            this.lblCarteira.TabIndex = 28;
            this.lblCarteira.Text = "Carteira";
            // 
            // txtNossoNumero
            // 
            this.txtNossoNumero.Location = new System.Drawing.Point(19, 33);
            this.txtNossoNumero.MaxLength = 50;
            this.txtNossoNumero.Name = "txtNossoNumero";
            this.txtNossoNumero.Size = new System.Drawing.Size(323, 20);
            this.txtNossoNumero.TabIndex = 7;
            this.txtNossoNumero.Tag = "";
            // 
            // lblNossoNumero
            // 
            this.lblNossoNumero.AutoSize = true;
            this.lblNossoNumero.Location = new System.Drawing.Point(16, 17);
            this.lblNossoNumero.Name = "lblNossoNumero";
            this.lblNossoNumero.Size = new System.Drawing.Size(77, 13);
            this.lblNossoNumero.TabIndex = 27;
            this.lblNossoNumero.Text = "Nosso Número";
            // 
            // tbpPagamento
            // 
            this.tbpPagamento.Location = new System.Drawing.Point(4, 22);
            this.tbpPagamento.Name = "tbpPagamento";
            this.tbpPagamento.Size = new System.Drawing.Size(375, 300);
            this.tbpPagamento.TabIndex = 2;
            this.tbpPagamento.Text = "Pagamento";
            this.tbpPagamento.UseVisualStyleBackColor = true;
            // 
            // frmContaBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 511);
            this.Controls.Add(this.tbc);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.Name = "frmContaBancaria";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "frmContaBancaria";
            this.Text = "Conta Bancária";
            this.Load += new System.EventHandler(this.frmContaBancaria_Load);
            this.tbc.ResumeLayout(false);
            this.tbpContaBancaria.ResumeLayout(false);
            this.tbpContaBancaria.PerformLayout();
            this.tbpCobranca.ResumeLayout(false);
            this.tbpCobranca.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.TextBox txtDigitoConta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDigitoAgencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAgencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBanco;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.TextBox txtNomeConta;
        private System.Windows.Forms.Label lblNomeConta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.TabControl tbc;
        private System.Windows.Forms.TabPage tbpContaBancaria;
        private System.Windows.Forms.TabPage tbpCobranca;
        private System.Windows.Forms.TextBox txtCarteira;
        private System.Windows.Forms.Label lblCarteira;
        private System.Windows.Forms.TextBox txtNossoNumero;
        private System.Windows.Forms.Label lblNossoNumero;
        private System.Windows.Forms.TabPage tbpPagamento;
    }
}