namespace ERP
{
    partial class frmCondicaoFreteCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCondicaoFreteCad));
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
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTpEnd = new System.Windows.Forms.ComboBox();
            this.txtCodigoIntrastat = new System.Windows.Forms.TextBox();
            this.lblCodigoIntrastat = new System.Windows.Forms.Label();
            this.lblCondicaoEncargoFrete = new System.Windows.Forms.Label();
            this.cboCondicaoEncargoFrete = new System.Windows.Forms.ComboBox();
            this.chkAplicarMinimoGratis = new System.Windows.Forms.CheckBox();
            this.txtMinimoGratis = new System.Windows.Forms.TextBox();
            this.lblMinimoGratis = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(28, 153);
            this.txtNome.MaxLength = 200;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(341, 20);
            this.txtNome.TabIndex = 17;
            this.txtNome.Tag = "1";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(25, 137);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 16;
            this.lblNome.Text = "Nome";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(352, 137);
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
            this.ribbon1.Size = new System.Drawing.Size(393, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(28, 202);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(341, 20);
            this.txtDescricao.TabIndex = 19;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(25, 186);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 18;
            this.lblDescricao.Text = "Descrição";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Tipo de Endereço";
            // 
            // cboTpEnd
            // 
            this.cboTpEnd.FormattingEnabled = true;
            this.cboTpEnd.Location = new System.Drawing.Point(28, 252);
            this.cboTpEnd.Name = "cboTpEnd";
            this.cboTpEnd.Size = new System.Drawing.Size(207, 21);
            this.cboTpEnd.TabIndex = 21;
            this.cboTpEnd.Tag = "1";
            // 
            // txtCodigoIntrastat
            // 
            this.txtCodigoIntrastat.Location = new System.Drawing.Point(28, 301);
            this.txtCodigoIntrastat.MaxLength = 200;
            this.txtCodigoIntrastat.Name = "txtCodigoIntrastat";
            this.txtCodigoIntrastat.Size = new System.Drawing.Size(341, 20);
            this.txtCodigoIntrastat.TabIndex = 23;
            this.txtCodigoIntrastat.Tag = "";
            // 
            // lblCodigoIntrastat
            // 
            this.lblCodigoIntrastat.AutoSize = true;
            this.lblCodigoIntrastat.Location = new System.Drawing.Point(25, 285);
            this.lblCodigoIntrastat.Name = "lblCodigoIntrastat";
            this.lblCodigoIntrastat.Size = new System.Drawing.Size(81, 13);
            this.lblCodigoIntrastat.TabIndex = 22;
            this.lblCodigoIntrastat.Text = "Código Intrastat";
            // 
            // lblCondicaoEncargoFrete
            // 
            this.lblCondicaoEncargoFrete.AutoSize = true;
            this.lblCondicaoEncargoFrete.Location = new System.Drawing.Point(25, 337);
            this.lblCondicaoEncargoFrete.Name = "lblCondicaoEncargoFrete";
            this.lblCondicaoEncargoFrete.Size = new System.Drawing.Size(137, 13);
            this.lblCondicaoEncargoFrete.TabIndex = 24;
            this.lblCondicaoEncargoFrete.Text = "Condição de Encargo Frete";
            // 
            // cboCondicaoEncargoFrete
            // 
            this.cboCondicaoEncargoFrete.FormattingEnabled = true;
            this.cboCondicaoEncargoFrete.Location = new System.Drawing.Point(28, 353);
            this.cboCondicaoEncargoFrete.Name = "cboCondicaoEncargoFrete";
            this.cboCondicaoEncargoFrete.Size = new System.Drawing.Size(207, 21);
            this.cboCondicaoEncargoFrete.TabIndex = 25;
            this.cboCondicaoEncargoFrete.Tag = "1";
            // 
            // chkAplicarMinimoGratis
            // 
            this.chkAplicarMinimoGratis.AutoSize = true;
            this.chkAplicarMinimoGratis.Location = new System.Drawing.Point(28, 392);
            this.chkAplicarMinimoGratis.Name = "chkAplicarMinimoGratis";
            this.chkAplicarMinimoGratis.Size = new System.Drawing.Size(126, 17);
            this.chkAplicarMinimoGratis.TabIndex = 26;
            this.chkAplicarMinimoGratis.Text = "Aplicar Mínimo Grátis";
            this.chkAplicarMinimoGratis.UseVisualStyleBackColor = true;
            this.chkAplicarMinimoGratis.CheckedChanged += new System.EventHandler(this.chkAplicarMinimoGratis_CheckedChanged);
            // 
            // txtMinimoGratis
            // 
            this.txtMinimoGratis.Location = new System.Drawing.Point(204, 413);
            this.txtMinimoGratis.MaxLength = 10;
            this.txtMinimoGratis.Name = "txtMinimoGratis";
            this.txtMinimoGratis.Size = new System.Drawing.Size(166, 20);
            this.txtMinimoGratis.TabIndex = 28;
            this.txtMinimoGratis.Tag = "";
            this.txtMinimoGratis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinimoGratis_KeyPress);
            // 
            // lblMinimoGratis
            // 
            this.lblMinimoGratis.AutoSize = true;
            this.lblMinimoGratis.Location = new System.Drawing.Point(201, 393);
            this.lblMinimoGratis.Name = "lblMinimoGratis";
            this.lblMinimoGratis.Size = new System.Drawing.Size(72, 13);
            this.lblMinimoGratis.TabIndex = 27;
            this.lblMinimoGratis.Text = "Mínimo Grátis";
            // 
            // frmCondicaoFreteCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(393, 440);
            this.Controls.Add(this.txtMinimoGratis);
            this.Controls.Add(this.lblMinimoGratis);
            this.Controls.Add(this.chkAplicarMinimoGratis);
            this.Controls.Add(this.lblCondicaoEncargoFrete);
            this.Controls.Add(this.cboCondicaoEncargoFrete);
            this.Controls.Add(this.txtCodigoIntrastat);
            this.Controls.Add(this.lblCodigoIntrastat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTpEnd);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmCondicaoFreteCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmCondicaoFreteCad";
            this.Text = "Cadastro Condição de Frete";
            this.Load += new System.EventHandler(this.frmCondicaoFreteCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCondicaoFreteCad_KeyDown);
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
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTpEnd;
        private System.Windows.Forms.TextBox txtCodigoIntrastat;
        private System.Windows.Forms.Label lblCodigoIntrastat;
        private System.Windows.Forms.Label lblCondicaoEncargoFrete;
        private System.Windows.Forms.ComboBox cboCondicaoEncargoFrete;
        private System.Windows.Forms.CheckBox chkAplicarMinimoGratis;
        private System.Windows.Forms.TextBox txtMinimoGratis;
        private System.Windows.Forms.Label lblMinimoGratis;
    }
}