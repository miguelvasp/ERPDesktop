namespace ERP
{
    partial class frmPedidoCompraContabilidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPedidoCompraContabilidade));
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtData = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrigemLancamento = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboContaContabil = new System.Windows.Forms.ComboBox();
            this.txtIDLote = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtValorCredito = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtValorDebito = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMoeda = new System.Windows.Forms.MaskedTextBox();
            this.Moeda = new System.Windows.Forms.Label();
            this.txtOrigem = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtFornecedor = new System.Windows.Forms.MaskedTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtValorAjustado = new System.Windows.Forms.MaskedTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTextoTransacao = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.SmallImage")));
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrava
            // 
            this.btnGrava.Image = ((System.Drawing.Image)(resources.GetObject("btnGrava.Image")));
            this.btnGrava.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGrava.SmallImage")));
            this.btnGrava.Text = "Gravar";
            this.btnGrava.Click += new System.EventHandler(this.btnGrava_Click);
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.btnGrava);
            this.ribbonPanel1.Items.Add(this.btnCancelar);
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
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtData
            // 
            this.txtData.Enabled = false;
            this.txtData.Location = new System.Drawing.Point(12, 173);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(133, 20);
            this.txtData.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 517);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Conta Contábil";
            // 
            // txtOrigemLancamento
            // 
            this.txtOrigemLancamento.Enabled = false;
            this.txtOrigemLancamento.Location = new System.Drawing.Point(151, 173);
            this.txtOrigemLancamento.Name = "txtOrigemLancamento";
            this.txtOrigemLancamento.Size = new System.Drawing.Size(721, 20);
            this.txtOrigemLancamento.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Origem";
            // 
            // cboContaContabil
            // 
            this.cboContaContabil.FormattingEnabled = true;
            this.cboContaContabil.Location = new System.Drawing.Point(12, 533);
            this.cboContaContabil.Name = "cboContaContabil";
            this.cboContaContabil.Size = new System.Drawing.Size(272, 21);
            this.cboContaContabil.TabIndex = 21;
            // 
            // txtIDLote
            // 
            this.txtIDLote.Enabled = false;
            this.txtIDLote.Location = new System.Drawing.Point(12, 232);
            this.txtIDLote.Name = "txtIDLote";
            this.txtIDLote.Size = new System.Drawing.Size(272, 20);
            this.txtIDLote.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 216);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "ID Lote";
            // 
            // txtValorCredito
            // 
            this.txtValorCredito.Enabled = false;
            this.txtValorCredito.Location = new System.Drawing.Point(297, 232);
            this.txtValorCredito.Name = "txtValorCredito";
            this.txtValorCredito.Size = new System.Drawing.Size(133, 20);
            this.txtValorCredito.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(294, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Valor Crédito";
            // 
            // txtValorDebito
            // 
            this.txtValorDebito.Enabled = false;
            this.txtValorDebito.Location = new System.Drawing.Point(436, 232);
            this.txtValorDebito.Name = "txtValorDebito";
            this.txtValorDebito.Size = new System.Drawing.Size(140, 20);
            this.txtValorDebito.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(433, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Valor Débito";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(582, 232);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(290, 20);
            this.txtUsuario.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(579, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Usuário";
            // 
            // txtMoeda
            // 
            this.txtMoeda.Enabled = false;
            this.txtMoeda.Location = new System.Drawing.Point(12, 291);
            this.txtMoeda.Name = "txtMoeda";
            this.txtMoeda.Size = new System.Drawing.Size(133, 20);
            this.txtMoeda.TabIndex = 35;
            // 
            // Moeda
            // 
            this.Moeda.AutoSize = true;
            this.Moeda.Location = new System.Drawing.Point(9, 275);
            this.Moeda.Name = "Moeda";
            this.Moeda.Size = new System.Drawing.Size(40, 13);
            this.Moeda.TabIndex = 36;
            this.Moeda.Text = "Moeda";
            // 
            // txtOrigem
            // 
            this.txtOrigem.Enabled = false;
            this.txtOrigem.Location = new System.Drawing.Point(582, 291);
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.Size = new System.Drawing.Size(290, 20);
            this.txtOrigem.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(579, 275);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Origem";
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Enabled = false;
            this.txtFornecedor.Location = new System.Drawing.Point(151, 291);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.Size = new System.Drawing.Size(425, 20);
            this.txtFornecedor.TabIndex = 39;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(148, 275);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 13);
            this.label19.TabIndex = 40;
            this.label19.Text = "Fornecedor";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 336);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 13);
            this.label18.TabIndex = 42;
            this.label18.Text = "Texto Transacação";
            // 
            // txtValorAjustado
            // 
            this.txtValorAjustado.Location = new System.Drawing.Point(295, 533);
            this.txtValorAjustado.Name = "txtValorAjustado";
            this.txtValorAjustado.Size = new System.Drawing.Size(133, 20);
            this.txtValorAjustado.TabIndex = 53;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(292, 517);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 13);
            this.label20.TabIndex = 54;
            this.label20.Text = "Valor Ajustado";
            // 
            // txtTextoTransacao
            // 
            this.txtTextoTransacao.Location = new System.Drawing.Point(12, 352);
            this.txtTextoTransacao.Multiline = true;
            this.txtTextoTransacao.Name = "txtTextoTransacao";
            this.txtTextoTransacao.Size = new System.Drawing.Size(860, 142);
            this.txtTextoTransacao.TabIndex = 55;
            // 
            // frmPedidoCompraContabilidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.txtTextoTransacao);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtValorAjustado);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtOrigem);
            this.Controls.Add(this.Moeda);
            this.Controls.Add(this.txtMoeda);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtValorDebito);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtValorCredito);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtIDLote);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboContaContabil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOrigemLancamento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 505);
            this.Name = "frmPedidoCompraContabilidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmPedidoVendaApuracaoImposto";
            this.Text = "Apuração de Impostos";
            this.Load += new System.EventHandler(this.frmAutoridadeCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAutoridadeCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.MaskedTextBox txtData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtOrigemLancamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboContaContabil;
        private System.Windows.Forms.MaskedTextBox txtIDLote;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox txtValorCredito;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox txtValorDebito;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtUsuario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txtMoeda;
        private System.Windows.Forms.Label Moeda;
        private System.Windows.Forms.MaskedTextBox txtOrigem;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox txtFornecedor;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MaskedTextBox txtValorAjustado;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtTextoTransacao;
    }
}