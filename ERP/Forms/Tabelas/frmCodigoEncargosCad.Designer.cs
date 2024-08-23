namespace ERP
{
    partial class frmCodigoEncargosCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCodigoEncargosCad));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
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
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cboGrupoImpostos = new System.Windows.Forms.ComboBox();
            this.lblGrupoImpostos = new System.Windows.Forms.Label();
            this.cboLancamentoTipo = new System.Windows.Forms.ComboBox();
            this.lblLancamentoDebitoTipo = new System.Windows.Forms.Label();
            this.cboContaContabilDebito = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboContaContabilCredito = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIncluiNotaFiscal = new System.Windows.Forms.CheckBox();
            this.chkIncluiImposto = new System.Windows.Forms.CheckBox();
            this.cboTipoLancamentoCredito = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(17, 154);
            this.txtNome.MaxLength = 200;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(358, 20);
            this.txtNome.TabIndex = 15;
            this.txtNome.Tag = "1";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(14, 138);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 14;
            this.lblNome.Text = "Nome";
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
            this.btnGrava.Image = global::ERP.Properties.Resources.Save_icon_24;
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
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(381, 154);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(489, 20);
            this.txtDescricao.TabIndex = 17;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(378, 138);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 16;
            this.lblDescricao.Text = "Descrição";
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(17, 229);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(219, 21);
            this.cboTipo.TabIndex = 19;
            this.cboTipo.Tag = "1";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(14, 213);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 18;
            this.lblTipo.Text = "Tipo";
            // 
            // cboGrupoImpostos
            // 
            this.cboGrupoImpostos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGrupoImpostos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoImpostos.FormattingEnabled = true;
            this.cboGrupoImpostos.Location = new System.Drawing.Point(242, 229);
            this.cboGrupoImpostos.Name = "cboGrupoImpostos";
            this.cboGrupoImpostos.Size = new System.Drawing.Size(432, 21);
            this.cboGrupoImpostos.TabIndex = 21;
            this.cboGrupoImpostos.Tag = "";
            // 
            // lblGrupoImpostos
            // 
            this.lblGrupoImpostos.AutoSize = true;
            this.lblGrupoImpostos.Location = new System.Drawing.Point(239, 213);
            this.lblGrupoImpostos.Name = "lblGrupoImpostos";
            this.lblGrupoImpostos.Size = new System.Drawing.Size(96, 13);
            this.lblGrupoImpostos.TabIndex = 20;
            this.lblGrupoImpostos.Text = "Grupo de Impostos";
            // 
            // cboLancamentoTipo
            // 
            this.cboLancamentoTipo.FormattingEnabled = true;
            this.cboLancamentoTipo.Location = new System.Drawing.Point(17, 318);
            this.cboLancamentoTipo.Name = "cboLancamentoTipo";
            this.cboLancamentoTipo.Size = new System.Drawing.Size(332, 21);
            this.cboLancamentoTipo.TabIndex = 23;
            this.cboLancamentoTipo.Tag = "";
            // 
            // lblLancamentoDebitoTipo
            // 
            this.lblLancamentoDebitoTipo.AutoSize = true;
            this.lblLancamentoDebitoTipo.Location = new System.Drawing.Point(14, 302);
            this.lblLancamentoDebitoTipo.Name = "lblLancamentoDebitoTipo";
            this.lblLancamentoDebitoTipo.Size = new System.Drawing.Size(139, 13);
            this.lblLancamentoDebitoTipo.TabIndex = 22;
            this.lblLancamentoDebitoTipo.Text = "Tipo de Lançamento Debito";
            // 
            // cboContaContabilDebito
            // 
            this.cboContaContabilDebito.FormattingEnabled = true;
            this.cboContaContabilDebito.Location = new System.Drawing.Point(355, 318);
            this.cboContaContabilDebito.Name = "cboContaContabilDebito";
            this.cboContaContabilDebito.Size = new System.Drawing.Size(319, 21);
            this.cboContaContabilDebito.TabIndex = 25;
            this.cboContaContabilDebito.Tag = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Conta Contábil Débito";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Tipo Lançamento Crédito";
            // 
            // cboContaContabilCredito
            // 
            this.cboContaContabilCredito.FormattingEnabled = true;
            this.cboContaContabilCredito.Location = new System.Drawing.Point(355, 391);
            this.cboContaContabilCredito.Name = "cboContaContabilCredito";
            this.cboContaContabilCredito.Size = new System.Drawing.Size(319, 21);
            this.cboContaContabilCredito.TabIndex = 29;
            this.cboContaContabilCredito.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 375);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Conta Contábil Crédito";
            // 
            // chkIncluiNotaFiscal
            // 
            this.chkIncluiNotaFiscal.AutoSize = true;
            this.chkIncluiNotaFiscal.Location = new System.Drawing.Point(17, 449);
            this.chkIncluiNotaFiscal.Name = "chkIncluiNotaFiscal";
            this.chkIncluiNotaFiscal.Size = new System.Drawing.Size(107, 17);
            this.chkIncluiNotaFiscal.TabIndex = 30;
            this.chkIncluiNotaFiscal.Text = "Inclui Nota Fiscal";
            this.chkIncluiNotaFiscal.UseVisualStyleBackColor = true;
            // 
            // chkIncluiImposto
            // 
            this.chkIncluiImposto.AutoSize = true;
            this.chkIncluiImposto.Location = new System.Drawing.Point(17, 485);
            this.chkIncluiImposto.Name = "chkIncluiImposto";
            this.chkIncluiImposto.Size = new System.Drawing.Size(91, 17);
            this.chkIncluiImposto.TabIndex = 31;
            this.chkIncluiImposto.Text = "Inclui Imposto";
            this.chkIncluiImposto.UseVisualStyleBackColor = true;
            // 
            // cboTipoLancamentoCredito
            // 
            this.cboTipoLancamentoCredito.FormattingEnabled = true;
            this.cboTipoLancamentoCredito.Location = new System.Drawing.Point(17, 391);
            this.cboTipoLancamentoCredito.Name = "cboTipoLancamentoCredito";
            this.cboTipoLancamentoCredito.Size = new System.Drawing.Size(332, 21);
            this.cboTipoLancamentoCredito.TabIndex = 32;
            // 
            // frmCodigoEncargosCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.cboTipoLancamentoCredito);
            this.Controls.Add(this.chkIncluiImposto);
            this.Controls.Add(this.chkIncluiNotaFiscal);
            this.Controls.Add(this.cboContaContabilCredito);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboContaContabilDebito);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboLancamentoTipo);
            this.Controls.Add(this.lblLancamentoDebitoTipo);
            this.Controls.Add(this.cboGrupoImpostos);
            this.Controls.Add(this.lblGrupoImpostos);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 555);
            this.Name = "frmCodigoEncargosCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmCodigoEncargosCad";
            this.Text = "Cadastro de Códigos de Encargos";
            this.Load += new System.EventHandler(this.frmCodigoEncargosCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCodigoEncargosCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
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
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboGrupoImpostos;
        private System.Windows.Forms.Label lblGrupoImpostos;
        private System.Windows.Forms.ComboBox cboLancamentoTipo;
        private System.Windows.Forms.Label lblLancamentoDebitoTipo;
        private System.Windows.Forms.ComboBox cboContaContabilDebito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboContaContabilCredito;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIncluiNotaFiscal;
        private System.Windows.Forms.CheckBox chkIncluiImposto;
        private System.Windows.Forms.ComboBox cboTipoLancamentoCredito;
    }
}