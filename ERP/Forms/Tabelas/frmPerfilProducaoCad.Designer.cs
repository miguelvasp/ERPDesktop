namespace ERP
{
    partial class frmPerfilProducaoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerfilProducaoCad));
            this.txtNome = new System.Windows.Forms.TextBox();
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
            this.lblListaSeparacao = new System.Windows.Forms.Label();
            this.cboListaSeparacao = new System.Windows.Forms.ComboBox();
            this.lblContraPartidaListaSeparacao = new System.Windows.Forms.Label();
            this.cboContraPartidaListaSeparacao = new System.Windows.Forms.ComboBox();
            this.lblRelatorioConclusao = new System.Windows.Forms.Label();
            this.cboRelatorioConclusao = new System.Windows.Forms.ComboBox();
            this.lblContraPartidaRelatorioConclusao = new System.Windows.Forms.Label();
            this.cboContraPartidaRelatorioConclusao = new System.Windows.Forms.ComboBox();
            this.lblSaida = new System.Windows.Forms.Label();
            this.cboSaida = new System.Windows.Forms.ComboBox();
            this.lblContraPartidaSaida = new System.Windows.Forms.Label();
            this.cboContraPartidaSaida = new System.Windows.Forms.ComboBox();
            this.lblRecebimento = new System.Windows.Forms.Label();
            this.cboRecebimento = new System.Windows.Forms.ComboBox();
            this.lblContraPartidaRecebimento = new System.Windows.Forms.Label();
            this.cboContraPartidaRecebimento = new System.Windows.Forms.ComboBox();
            this.lblSaidaWIP = new System.Windows.Forms.Label();
            this.cboSaidaWIP = new System.Windows.Forms.ComboBox();
            this.lblContaWIP = new System.Windows.Forms.Label();
            this.cboContaWIP = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(25, 155);
            this.txtNome.MaxLength = 200;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(443, 20);
            this.txtNome.TabIndex = 17;
            this.txtNome.Tag = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nome";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(349, 139);
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
            this.ribbon1.Size = new System.Drawing.Size(488, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // lblListaSeparacao
            // 
            this.lblListaSeparacao.AutoSize = true;
            this.lblListaSeparacao.Location = new System.Drawing.Point(22, 188);
            this.lblListaSeparacao.Name = "lblListaSeparacao";
            this.lblListaSeparacao.Size = new System.Drawing.Size(99, 13);
            this.lblListaSeparacao.TabIndex = 18;
            this.lblListaSeparacao.Text = "Lista de Separação";
            // 
            // cboListaSeparacao
            // 
            this.cboListaSeparacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboListaSeparacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboListaSeparacao.FormattingEnabled = true;
            this.cboListaSeparacao.Location = new System.Drawing.Point(25, 207);
            this.cboListaSeparacao.Name = "cboListaSeparacao";
            this.cboListaSeparacao.Size = new System.Drawing.Size(217, 21);
            this.cboListaSeparacao.TabIndex = 19;
            this.cboListaSeparacao.Tag = "1";
            // 
            // lblContraPartidaListaSeparacao
            // 
            this.lblContraPartidaListaSeparacao.AutoSize = true;
            this.lblContraPartidaListaSeparacao.Location = new System.Drawing.Point(248, 188);
            this.lblContraPartidaListaSeparacao.Name = "lblContraPartidaListaSeparacao";
            this.lblContraPartidaListaSeparacao.Size = new System.Drawing.Size(169, 13);
            this.lblContraPartidaListaSeparacao.TabIndex = 20;
            this.lblContraPartidaListaSeparacao.Text = "Contra Partida Lista de Separação";
            // 
            // cboContraPartidaListaSeparacao
            // 
            this.cboContraPartidaListaSeparacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboContraPartidaListaSeparacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboContraPartidaListaSeparacao.FormattingEnabled = true;
            this.cboContraPartidaListaSeparacao.Location = new System.Drawing.Point(251, 207);
            this.cboContraPartidaListaSeparacao.Name = "cboContraPartidaListaSeparacao";
            this.cboContraPartidaListaSeparacao.Size = new System.Drawing.Size(217, 21);
            this.cboContraPartidaListaSeparacao.TabIndex = 21;
            this.cboContraPartidaListaSeparacao.Tag = "1";
            // 
            // lblRelatorioConclusao
            // 
            this.lblRelatorioConclusao.AutoSize = true;
            this.lblRelatorioConclusao.Location = new System.Drawing.Point(22, 240);
            this.lblRelatorioConclusao.Name = "lblRelatorioConclusao";
            this.lblRelatorioConclusao.Size = new System.Drawing.Size(117, 13);
            this.lblRelatorioConclusao.TabIndex = 22;
            this.lblRelatorioConclusao.Text = "Relatório de Conclusão";
            // 
            // cboRelatorioConclusao
            // 
            this.cboRelatorioConclusao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRelatorioConclusao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRelatorioConclusao.FormattingEnabled = true;
            this.cboRelatorioConclusao.Location = new System.Drawing.Point(25, 259);
            this.cboRelatorioConclusao.Name = "cboRelatorioConclusao";
            this.cboRelatorioConclusao.Size = new System.Drawing.Size(217, 21);
            this.cboRelatorioConclusao.TabIndex = 23;
            this.cboRelatorioConclusao.Tag = "1";
            // 
            // lblContraPartidaRelatorioConclusao
            // 
            this.lblContraPartidaRelatorioConclusao.AutoSize = true;
            this.lblContraPartidaRelatorioConclusao.Location = new System.Drawing.Point(248, 240);
            this.lblContraPartidaRelatorioConclusao.Name = "lblContraPartidaRelatorioConclusao";
            this.lblContraPartidaRelatorioConclusao.Size = new System.Drawing.Size(187, 13);
            this.lblContraPartidaRelatorioConclusao.TabIndex = 24;
            this.lblContraPartidaRelatorioConclusao.Text = "Contra Partida Relatório de Conclusão";
            // 
            // cboContraPartidaRelatorioConclusao
            // 
            this.cboContraPartidaRelatorioConclusao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboContraPartidaRelatorioConclusao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboContraPartidaRelatorioConclusao.FormattingEnabled = true;
            this.cboContraPartidaRelatorioConclusao.Location = new System.Drawing.Point(251, 259);
            this.cboContraPartidaRelatorioConclusao.Name = "cboContraPartidaRelatorioConclusao";
            this.cboContraPartidaRelatorioConclusao.Size = new System.Drawing.Size(217, 21);
            this.cboContraPartidaRelatorioConclusao.TabIndex = 25;
            this.cboContraPartidaRelatorioConclusao.Tag = "1";
            // 
            // lblSaida
            // 
            this.lblSaida.AutoSize = true;
            this.lblSaida.Location = new System.Drawing.Point(22, 294);
            this.lblSaida.Name = "lblSaida";
            this.lblSaida.Size = new System.Drawing.Size(36, 13);
            this.lblSaida.TabIndex = 26;
            this.lblSaida.Text = "Saída";
            // 
            // cboSaida
            // 
            this.cboSaida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSaida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSaida.FormattingEnabled = true;
            this.cboSaida.Location = new System.Drawing.Point(25, 313);
            this.cboSaida.Name = "cboSaida";
            this.cboSaida.Size = new System.Drawing.Size(217, 21);
            this.cboSaida.TabIndex = 27;
            this.cboSaida.Tag = "1";
            // 
            // lblContraPartidaSaida
            // 
            this.lblContraPartidaSaida.AutoSize = true;
            this.lblContraPartidaSaida.Location = new System.Drawing.Point(248, 294);
            this.lblContraPartidaSaida.Name = "lblContraPartidaSaida";
            this.lblContraPartidaSaida.Size = new System.Drawing.Size(106, 13);
            this.lblContraPartidaSaida.TabIndex = 28;
            this.lblContraPartidaSaida.Text = "Contra Partida Saída";
            // 
            // cboContraPartidaSaida
            // 
            this.cboContraPartidaSaida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboContraPartidaSaida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboContraPartidaSaida.FormattingEnabled = true;
            this.cboContraPartidaSaida.Location = new System.Drawing.Point(251, 313);
            this.cboContraPartidaSaida.Name = "cboContraPartidaSaida";
            this.cboContraPartidaSaida.Size = new System.Drawing.Size(217, 21);
            this.cboContraPartidaSaida.TabIndex = 29;
            this.cboContraPartidaSaida.Tag = "1";
            // 
            // lblRecebimento
            // 
            this.lblRecebimento.AutoSize = true;
            this.lblRecebimento.Location = new System.Drawing.Point(22, 350);
            this.lblRecebimento.Name = "lblRecebimento";
            this.lblRecebimento.Size = new System.Drawing.Size(70, 13);
            this.lblRecebimento.TabIndex = 30;
            this.lblRecebimento.Text = "Recebimento";
            // 
            // cboRecebimento
            // 
            this.cboRecebimento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRecebimento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRecebimento.FormattingEnabled = true;
            this.cboRecebimento.Location = new System.Drawing.Point(25, 369);
            this.cboRecebimento.Name = "cboRecebimento";
            this.cboRecebimento.Size = new System.Drawing.Size(217, 21);
            this.cboRecebimento.TabIndex = 31;
            this.cboRecebimento.Tag = "1";
            // 
            // lblContraPartidaRecebimento
            // 
            this.lblContraPartidaRecebimento.AutoSize = true;
            this.lblContraPartidaRecebimento.Location = new System.Drawing.Point(248, 350);
            this.lblContraPartidaRecebimento.Name = "lblContraPartidaRecebimento";
            this.lblContraPartidaRecebimento.Size = new System.Drawing.Size(140, 13);
            this.lblContraPartidaRecebimento.TabIndex = 32;
            this.lblContraPartidaRecebimento.Text = "Contra Partida Recebimento";
            // 
            // cboContraPartidaRecebimento
            // 
            this.cboContraPartidaRecebimento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboContraPartidaRecebimento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboContraPartidaRecebimento.FormattingEnabled = true;
            this.cboContraPartidaRecebimento.Location = new System.Drawing.Point(251, 369);
            this.cboContraPartidaRecebimento.Name = "cboContraPartidaRecebimento";
            this.cboContraPartidaRecebimento.Size = new System.Drawing.Size(217, 21);
            this.cboContraPartidaRecebimento.TabIndex = 33;
            this.cboContraPartidaRecebimento.Tag = "1";
            // 
            // lblSaidaWIP
            // 
            this.lblSaidaWIP.AutoSize = true;
            this.lblSaidaWIP.Location = new System.Drawing.Point(22, 403);
            this.lblSaidaWIP.Name = "lblSaidaWIP";
            this.lblSaidaWIP.Size = new System.Drawing.Size(60, 13);
            this.lblSaidaWIP.TabIndex = 34;
            this.lblSaidaWIP.Text = "Saída WIP";
            // 
            // cboSaidaWIP
            // 
            this.cboSaidaWIP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSaidaWIP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSaidaWIP.FormattingEnabled = true;
            this.cboSaidaWIP.Location = new System.Drawing.Point(25, 422);
            this.cboSaidaWIP.Name = "cboSaidaWIP";
            this.cboSaidaWIP.Size = new System.Drawing.Size(217, 21);
            this.cboSaidaWIP.TabIndex = 35;
            this.cboSaidaWIP.Tag = "1";
            // 
            // lblContaWIP
            // 
            this.lblContaWIP.AutoSize = true;
            this.lblContaWIP.Location = new System.Drawing.Point(248, 403);
            this.lblContaWIP.Name = "lblContaWIP";
            this.lblContaWIP.Size = new System.Drawing.Size(59, 13);
            this.lblContaWIP.TabIndex = 36;
            this.lblContaWIP.Text = "Conta WIP";
            // 
            // cboContaWIP
            // 
            this.cboContaWIP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboContaWIP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboContaWIP.FormattingEnabled = true;
            this.cboContaWIP.Location = new System.Drawing.Point(251, 422);
            this.cboContaWIP.Name = "cboContaWIP";
            this.cboContaWIP.Size = new System.Drawing.Size(217, 21);
            this.cboContaWIP.TabIndex = 37;
            this.cboContaWIP.Tag = "1";
            // 
            // frmPerfilProducaoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(488, 475);
            this.Controls.Add(this.lblContaWIP);
            this.Controls.Add(this.cboContaWIP);
            this.Controls.Add(this.lblSaidaWIP);
            this.Controls.Add(this.cboSaidaWIP);
            this.Controls.Add(this.lblContraPartidaRecebimento);
            this.Controls.Add(this.cboContraPartidaRecebimento);
            this.Controls.Add(this.lblRecebimento);
            this.Controls.Add(this.cboRecebimento);
            this.Controls.Add(this.lblContraPartidaSaida);
            this.Controls.Add(this.cboContraPartidaSaida);
            this.Controls.Add(this.lblSaida);
            this.Controls.Add(this.cboSaida);
            this.Controls.Add(this.lblContraPartidaRelatorioConclusao);
            this.Controls.Add(this.cboContraPartidaRelatorioConclusao);
            this.Controls.Add(this.lblRelatorioConclusao);
            this.Controls.Add(this.cboRelatorioConclusao);
            this.Controls.Add(this.lblContraPartidaListaSeparacao);
            this.Controls.Add(this.cboContraPartidaListaSeparacao);
            this.Controls.Add(this.lblListaSeparacao);
            this.Controls.Add(this.cboListaSeparacao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmPerfilProducaoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmPerfilProducaoCad";
            this.Text = "Cadastro Perfil Produção";
            this.Load += new System.EventHandler(this.frmPerfilProducaoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPerfilProducaoCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
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
        private System.Windows.Forms.Label lblListaSeparacao;
        private System.Windows.Forms.ComboBox cboListaSeparacao;
        private System.Windows.Forms.Label lblContraPartidaListaSeparacao;
        private System.Windows.Forms.ComboBox cboContraPartidaListaSeparacao;
        private System.Windows.Forms.Label lblRelatorioConclusao;
        private System.Windows.Forms.ComboBox cboRelatorioConclusao;
        private System.Windows.Forms.Label lblContraPartidaRelatorioConclusao;
        private System.Windows.Forms.ComboBox cboContraPartidaRelatorioConclusao;
        private System.Windows.Forms.Label lblSaida;
        private System.Windows.Forms.ComboBox cboSaida;
        private System.Windows.Forms.Label lblContraPartidaSaida;
        private System.Windows.Forms.ComboBox cboContraPartidaSaida;
        private System.Windows.Forms.Label lblRecebimento;
        private System.Windows.Forms.ComboBox cboRecebimento;
        private System.Windows.Forms.Label lblContraPartidaRecebimento;
        private System.Windows.Forms.ComboBox cboContraPartidaRecebimento;
        private System.Windows.Forms.Label lblSaidaWIP;
        private System.Windows.Forms.ComboBox cboSaidaWIP;
        private System.Windows.Forms.Label lblContaWIP;
        private System.Windows.Forms.ComboBox cboContaWIP;
    }
}