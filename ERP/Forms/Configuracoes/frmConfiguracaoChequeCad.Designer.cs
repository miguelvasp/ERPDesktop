namespace ERP
{
    partial class frmConfiguracaoChequeCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracaoChequeCad));
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrdem = new System.Windows.Forms.TextBox();
            this.chkHabilitadoContabilizacaoPrincipal = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTextoTransacao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTipoContaDebito = new System.Windows.Forms.ComboBox();
            this.cboContaDebito = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboContaCredito = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTipoContaCredito = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.ribbon1.Size = new System.Drawing.Size(784, 125);
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(30, 167);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(362, 20);
            this.txtDescricao.TabIndex = 13;
            this.txtDescricao.Tag = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Descrição";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Ordem";
            // 
            // txtOrdem
            // 
            this.txtOrdem.Location = new System.Drawing.Point(398, 167);
            this.txtOrdem.Name = "txtOrdem";
            this.txtOrdem.Size = new System.Drawing.Size(97, 20);
            this.txtOrdem.TabIndex = 16;
            this.txtOrdem.Tag = "1";
            // 
            // chkHabilitadoContabilizacaoPrincipal
            // 
            this.chkHabilitadoContabilizacaoPrincipal.AutoSize = true;
            this.chkHabilitadoContabilizacaoPrincipal.Location = new System.Drawing.Point(559, 170);
            this.chkHabilitadoContabilizacaoPrincipal.Name = "chkHabilitadoContabilizacaoPrincipal";
            this.chkHabilitadoContabilizacaoPrincipal.Size = new System.Drawing.Size(188, 17);
            this.chkHabilitadoContabilizacaoPrincipal.TabIndex = 18;
            this.chkHabilitadoContabilizacaoPrincipal.Text = "Habilitado Contabilização Principal";
            this.chkHabilitadoContabilizacaoPrincipal.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Texto de transação";
            // 
            // txtTextoTransacao
            // 
            this.txtTextoTransacao.Location = new System.Drawing.Point(30, 239);
            this.txtTextoTransacao.Name = "txtTextoTransacao";
            this.txtTextoTransacao.Size = new System.Drawing.Size(717, 20);
            this.txtTextoTransacao.TabIndex = 19;
            this.txtTextoTransacao.Tag = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tipo de Conta Débito";
            // 
            // cboTipoContaDebito
            // 
            this.cboTipoContaDebito.FormattingEnabled = true;
            this.cboTipoContaDebito.Location = new System.Drawing.Point(30, 316);
            this.cboTipoContaDebito.Name = "cboTipoContaDebito";
            this.cboTipoContaDebito.Size = new System.Drawing.Size(256, 21);
            this.cboTipoContaDebito.TabIndex = 22;
            // 
            // cboContaDebito
            // 
            this.cboContaDebito.FormattingEnabled = true;
            this.cboContaDebito.Location = new System.Drawing.Point(292, 316);
            this.cboContaDebito.Name = "cboContaDebito";
            this.cboContaDebito.Size = new System.Drawing.Size(455, 21);
            this.cboContaDebito.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Conta Contábil Débito";
            // 
            // cboContaCredito
            // 
            this.cboContaCredito.FormattingEnabled = true;
            this.cboContaCredito.Location = new System.Drawing.Point(292, 401);
            this.cboContaCredito.Name = "cboContaCredito";
            this.cboContaCredito.Size = new System.Drawing.Size(455, 21);
            this.cboContaCredito.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Conta Contábil Crédito";
            // 
            // cboTipoContaCredito
            // 
            this.cboTipoContaCredito.FormattingEnabled = true;
            this.cboTipoContaCredito.Location = new System.Drawing.Point(30, 401);
            this.cboTipoContaCredito.Name = "cboTipoContaCredito";
            this.cboTipoContaCredito.Size = new System.Drawing.Size(256, 21);
            this.cboTipoContaCredito.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 385);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Tipo de Conta Crédito";
            // 
            // frmConfiguracaoChequeCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.cboContaCredito);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboTipoContaCredito);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboContaDebito);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboTipoContaDebito);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTextoTransacao);
            this.Controls.Add(this.chkHabilitadoContabilizacaoPrincipal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOrdem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 505);
            this.Name = "frmConfiguracaoChequeCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmCalendarioCad";
            this.Text = "Cadastro de Calendário";
            this.Load += new System.EventHandler(this.frmAutoridadeCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAutoridadeCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrdem;
        private System.Windows.Forms.CheckBox chkHabilitadoContabilizacaoPrincipal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTextoTransacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTipoContaDebito;
        private System.Windows.Forms.ComboBox cboContaDebito;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboContaCredito;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTipoContaCredito;
        private System.Windows.Forms.Label label7;
    }
}