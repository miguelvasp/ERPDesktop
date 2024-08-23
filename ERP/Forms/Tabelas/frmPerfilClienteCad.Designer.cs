namespace ERP
{
    partial class frmPerfilClienteCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerfilClienteCad));
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
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.cboRelacaoGrupo = new System.Windows.Forms.ComboBox();
            this.lblRelacaoGrupo = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboGrupoCliente = new System.Windows.Forms.ComboBox();
            this.lblGrupoCliente = new System.Windows.Forms.Label();
            this.cboConta = new System.Windows.Forms.ComboBox();
            this.lblConta = new System.Windows.Forms.Label();
            this.cboLiquidar = new System.Windows.Forms.ComboBox();
            this.lblLiquidar = new System.Windows.Forms.Label();
            this.cboPagamentoAntecipado = new System.Windows.Forms.ComboBox();
            this.lblPagamentoAntecipado = new System.Windows.Forms.Label();
            this.cboDesconto = new System.Windows.Forms.ComboBox();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.cboBaixa = new System.Windows.Forms.ComboBox();
            this.lblBaixa = new System.Windows.Forms.Label();
            this.cboJuros = new System.Windows.Forms.ComboBox();
            this.lblJuros = new System.Windows.Forms.Label();
            this.cboMulta = new System.Windows.Forms.ComboBox();
            this.lblMulta = new System.Windows.Forms.Label();
            this.cboTransferenciaImpostos = new System.Windows.Forms.ComboBox();
            this.lblTransferenciaImpostos = new System.Windows.Forms.Label();
            this.chkBaixa = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(28, 147);
            this.txtNome.MaxLength = 200;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(348, 20);
            this.txtNome.TabIndex = 17;
            this.txtNome.Tag = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nome";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(352, 131);
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
            this.ribbon1.Size = new System.Drawing.Size(591, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(28, 186);
            this.txtDescricao.MaxLength = 255;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(348, 20);
            this.txtDescricao.TabIndex = 19;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(25, 170);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 18;
            this.lblDescricao.Text = "Descrição";
            // 
            // cboRelacaoGrupo
            // 
            this.cboRelacaoGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRelacaoGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRelacaoGrupo.FormattingEnabled = true;
            this.cboRelacaoGrupo.Location = new System.Drawing.Point(28, 224);
            this.cboRelacaoGrupo.Name = "cboRelacaoGrupo";
            this.cboRelacaoGrupo.Size = new System.Drawing.Size(270, 21);
            this.cboRelacaoGrupo.TabIndex = 21;
            this.cboRelacaoGrupo.Tag = "1";
            this.cboRelacaoGrupo.Leave += new System.EventHandler(this.cboRelacaoGrupo_Leave);
            // 
            // lblRelacaoGrupo
            // 
            this.lblRelacaoGrupo.AutoSize = true;
            this.lblRelacaoGrupo.Location = new System.Drawing.Point(25, 209);
            this.lblRelacaoGrupo.Name = "lblRelacaoGrupo";
            this.lblRelacaoGrupo.Size = new System.Drawing.Size(94, 13);
            this.lblRelacaoGrupo.TabIndex = 20;
            this.lblRelacaoGrupo.Text = "Relação ao Grupo";
            // 
            // cboCliente
            // 
            this.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCliente.DropDownWidth = 255;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(28, 263);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(270, 21);
            this.cboCliente.TabIndex = 23;
            this.cboCliente.Tag = "";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(25, 248);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 22;
            this.lblCliente.Text = "Cliente";
            // 
            // cboGrupoCliente
            // 
            this.cboGrupoCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGrupoCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoCliente.FormattingEnabled = true;
            this.cboGrupoCliente.Location = new System.Drawing.Point(308, 263);
            this.cboGrupoCliente.Name = "cboGrupoCliente";
            this.cboGrupoCliente.Size = new System.Drawing.Size(270, 21);
            this.cboGrupoCliente.TabIndex = 25;
            this.cboGrupoCliente.Tag = "";
            // 
            // lblGrupoCliente
            // 
            this.lblGrupoCliente.AutoSize = true;
            this.lblGrupoCliente.Location = new System.Drawing.Point(305, 248);
            this.lblGrupoCliente.Name = "lblGrupoCliente";
            this.lblGrupoCliente.Size = new System.Drawing.Size(71, 13);
            this.lblGrupoCliente.TabIndex = 24;
            this.lblGrupoCliente.Text = "Grupo Cliente";
            // 
            // cboConta
            // 
            this.cboConta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboConta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboConta.FormattingEnabled = true;
            this.cboConta.Location = new System.Drawing.Point(28, 302);
            this.cboConta.Name = "cboConta";
            this.cboConta.Size = new System.Drawing.Size(270, 21);
            this.cboConta.TabIndex = 27;
            this.cboConta.Tag = "";
            // 
            // lblConta
            // 
            this.lblConta.AutoSize = true;
            this.lblConta.Location = new System.Drawing.Point(25, 287);
            this.lblConta.Name = "lblConta";
            this.lblConta.Size = new System.Drawing.Size(35, 13);
            this.lblConta.TabIndex = 26;
            this.lblConta.Text = "Conta";
            // 
            // cboLiquidar
            // 
            this.cboLiquidar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboLiquidar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboLiquidar.FormattingEnabled = true;
            this.cboLiquidar.Location = new System.Drawing.Point(308, 302);
            this.cboLiquidar.Name = "cboLiquidar";
            this.cboLiquidar.Size = new System.Drawing.Size(270, 21);
            this.cboLiquidar.TabIndex = 29;
            this.cboLiquidar.Tag = "";
            // 
            // lblLiquidar
            // 
            this.lblLiquidar.AutoSize = true;
            this.lblLiquidar.Location = new System.Drawing.Point(305, 287);
            this.lblLiquidar.Name = "lblLiquidar";
            this.lblLiquidar.Size = new System.Drawing.Size(44, 13);
            this.lblLiquidar.TabIndex = 28;
            this.lblLiquidar.Text = "Liquidar";
            // 
            // cboPagamentoAntecipado
            // 
            this.cboPagamentoAntecipado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPagamentoAntecipado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPagamentoAntecipado.FormattingEnabled = true;
            this.cboPagamentoAntecipado.Location = new System.Drawing.Point(28, 341);
            this.cboPagamentoAntecipado.Name = "cboPagamentoAntecipado";
            this.cboPagamentoAntecipado.Size = new System.Drawing.Size(270, 21);
            this.cboPagamentoAntecipado.TabIndex = 31;
            this.cboPagamentoAntecipado.Tag = "";
            // 
            // lblPagamentoAntecipado
            // 
            this.lblPagamentoAntecipado.AutoSize = true;
            this.lblPagamentoAntecipado.Location = new System.Drawing.Point(25, 326);
            this.lblPagamentoAntecipado.Name = "lblPagamentoAntecipado";
            this.lblPagamentoAntecipado.Size = new System.Drawing.Size(120, 13);
            this.lblPagamentoAntecipado.TabIndex = 30;
            this.lblPagamentoAntecipado.Text = "Pagamento/Antecipado";
            // 
            // cboDesconto
            // 
            this.cboDesconto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDesconto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDesconto.FormattingEnabled = true;
            this.cboDesconto.Location = new System.Drawing.Point(309, 341);
            this.cboDesconto.Name = "cboDesconto";
            this.cboDesconto.Size = new System.Drawing.Size(270, 21);
            this.cboDesconto.TabIndex = 33;
            this.cboDesconto.Tag = "";
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Location = new System.Drawing.Point(306, 326);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(53, 13);
            this.lblDesconto.TabIndex = 32;
            this.lblDesconto.Text = "Desconto";
            // 
            // cboBaixa
            // 
            this.cboBaixa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBaixa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBaixa.FormattingEnabled = true;
            this.cboBaixa.Location = new System.Drawing.Point(28, 380);
            this.cboBaixa.Name = "cboBaixa";
            this.cboBaixa.Size = new System.Drawing.Size(270, 21);
            this.cboBaixa.TabIndex = 35;
            this.cboBaixa.Tag = "";
            // 
            // lblBaixa
            // 
            this.lblBaixa.AutoSize = true;
            this.lblBaixa.Location = new System.Drawing.Point(25, 365);
            this.lblBaixa.Name = "lblBaixa";
            this.lblBaixa.Size = new System.Drawing.Size(33, 13);
            this.lblBaixa.TabIndex = 34;
            this.lblBaixa.Text = "Baixa";
            // 
            // cboJuros
            // 
            this.cboJuros.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboJuros.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboJuros.FormattingEnabled = true;
            this.cboJuros.Location = new System.Drawing.Point(309, 380);
            this.cboJuros.Name = "cboJuros";
            this.cboJuros.Size = new System.Drawing.Size(270, 21);
            this.cboJuros.TabIndex = 37;
            this.cboJuros.Tag = "";
            // 
            // lblJuros
            // 
            this.lblJuros.AutoSize = true;
            this.lblJuros.Location = new System.Drawing.Point(306, 365);
            this.lblJuros.Name = "lblJuros";
            this.lblJuros.Size = new System.Drawing.Size(32, 13);
            this.lblJuros.TabIndex = 36;
            this.lblJuros.Text = "Juros";
            // 
            // cboMulta
            // 
            this.cboMulta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMulta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMulta.FormattingEnabled = true;
            this.cboMulta.Location = new System.Drawing.Point(28, 419);
            this.cboMulta.Name = "cboMulta";
            this.cboMulta.Size = new System.Drawing.Size(270, 21);
            this.cboMulta.TabIndex = 39;
            this.cboMulta.Tag = "";
            // 
            // lblMulta
            // 
            this.lblMulta.AutoSize = true;
            this.lblMulta.Location = new System.Drawing.Point(25, 404);
            this.lblMulta.Name = "lblMulta";
            this.lblMulta.Size = new System.Drawing.Size(33, 13);
            this.lblMulta.TabIndex = 38;
            this.lblMulta.Text = "Multa";
            // 
            // cboTransferenciaImpostos
            // 
            this.cboTransferenciaImpostos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTransferenciaImpostos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTransferenciaImpostos.FormattingEnabled = true;
            this.cboTransferenciaImpostos.Location = new System.Drawing.Point(308, 419);
            this.cboTransferenciaImpostos.Name = "cboTransferenciaImpostos";
            this.cboTransferenciaImpostos.Size = new System.Drawing.Size(270, 21);
            this.cboTransferenciaImpostos.TabIndex = 41;
            this.cboTransferenciaImpostos.Tag = "";
            // 
            // lblTransferenciaImpostos
            // 
            this.lblTransferenciaImpostos.AutoSize = true;
            this.lblTransferenciaImpostos.Location = new System.Drawing.Point(305, 404);
            this.lblTransferenciaImpostos.Name = "lblTransferenciaImpostos";
            this.lblTransferenciaImpostos.Size = new System.Drawing.Size(132, 13);
            this.lblTransferenciaImpostos.TabIndex = 40;
            this.lblTransferenciaImpostos.Text = "Transferência de Impostos";
            // 
            // chkBaixa
            // 
            this.chkBaixa.AutoSize = true;
            this.chkBaixa.Location = new System.Drawing.Point(28, 446);
            this.chkBaixa.Name = "chkBaixa";
            this.chkBaixa.Size = new System.Drawing.Size(52, 17);
            this.chkBaixa.TabIndex = 49;
            this.chkBaixa.Text = "Baixa";
            this.chkBaixa.UseVisualStyleBackColor = true;
            // 
            // frmPerfilClienteCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(591, 476);
            this.Controls.Add(this.chkBaixa);
            this.Controls.Add(this.cboTransferenciaImpostos);
            this.Controls.Add(this.lblTransferenciaImpostos);
            this.Controls.Add(this.cboMulta);
            this.Controls.Add(this.lblMulta);
            this.Controls.Add(this.cboJuros);
            this.Controls.Add(this.lblJuros);
            this.Controls.Add(this.cboBaixa);
            this.Controls.Add(this.lblBaixa);
            this.Controls.Add(this.cboDesconto);
            this.Controls.Add(this.lblDesconto);
            this.Controls.Add(this.cboPagamentoAntecipado);
            this.Controls.Add(this.lblPagamentoAntecipado);
            this.Controls.Add(this.cboLiquidar);
            this.Controls.Add(this.lblLiquidar);
            this.Controls.Add(this.cboConta);
            this.Controls.Add(this.lblConta);
            this.Controls.Add(this.cboGrupoCliente);
            this.Controls.Add(this.lblGrupoCliente);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cboRelacaoGrupo);
            this.Controls.Add(this.lblRelacaoGrupo);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmPerfilClienteCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmPerfilClienteCad";
            this.Text = "Cadastro Perfil Cliente";
            this.Load += new System.EventHandler(this.frmPerfilClienteCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPerfilClienteCad_KeyDown);
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
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.ComboBox cboRelacaoGrupo;
        private System.Windows.Forms.Label lblRelacaoGrupo;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboGrupoCliente;
        private System.Windows.Forms.Label lblGrupoCliente;
        private System.Windows.Forms.ComboBox cboConta;
        private System.Windows.Forms.Label lblConta;
        private System.Windows.Forms.ComboBox cboLiquidar;
        private System.Windows.Forms.Label lblLiquidar;
        private System.Windows.Forms.ComboBox cboPagamentoAntecipado;
        private System.Windows.Forms.Label lblPagamentoAntecipado;
        private System.Windows.Forms.ComboBox cboDesconto;
        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.ComboBox cboBaixa;
        private System.Windows.Forms.Label lblBaixa;
        private System.Windows.Forms.ComboBox cboJuros;
        private System.Windows.Forms.Label lblJuros;
        private System.Windows.Forms.ComboBox cboMulta;
        private System.Windows.Forms.Label lblMulta;
        private System.Windows.Forms.ComboBox cboTransferenciaImpostos;
        private System.Windows.Forms.Label lblTransferenciaImpostos;
        private System.Windows.Forms.CheckBox chkBaixa;
    }
}