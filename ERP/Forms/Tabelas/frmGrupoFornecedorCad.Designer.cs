namespace ERP
{
    partial class frmGrupoFornecedorCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoFornecedorCad));
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.cboGrupoImpostos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCondicaoPgto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.cboPeriodoLiquidacaoImposto = new System.Windows.Forms.ComboBox();
            this.lblPeriodoLiquidacaoImposto = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnExcluir.SmallImage")));
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
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
            this.ribbon1.Size = new System.Drawing.Size(412, 125);
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // cboGrupoImpostos
            // 
            this.cboGrupoImpostos.FormattingEnabled = true;
            this.cboGrupoImpostos.Location = new System.Drawing.Point(31, 275);
            this.cboGrupoImpostos.Name = "cboGrupoImpostos";
            this.cboGrupoImpostos.Size = new System.Drawing.Size(249, 21);
            this.cboGrupoImpostos.TabIndex = 24;
            this.cboGrupoImpostos.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Grupo de Impostos";
            // 
            // cboCondicaoPgto
            // 
            this.cboCondicaoPgto.FormattingEnabled = true;
            this.cboCondicaoPgto.Location = new System.Drawing.Point(31, 223);
            this.cboCondicaoPgto.Name = "cboCondicaoPgto";
            this.cboCondicaoPgto.Size = new System.Drawing.Size(249, 21);
            this.cboCondicaoPgto.TabIndex = 22;
            this.cboCondicaoPgto.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Condição de Pagamento";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(31, 168);
            this.txtDescricao.MaxLength = 255;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(354, 20);
            this.txtDescricao.TabIndex = 20;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(28, 152);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 19;
            this.lblDescricao.Text = "Descrição";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(372, 128);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 18;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
            // 
            // cboPeriodoLiquidacaoImposto
            // 
            this.cboPeriodoLiquidacaoImposto.FormattingEnabled = true;
            this.cboPeriodoLiquidacaoImposto.Location = new System.Drawing.Point(31, 333);
            this.cboPeriodoLiquidacaoImposto.Name = "cboPeriodoLiquidacaoImposto";
            this.cboPeriodoLiquidacaoImposto.Size = new System.Drawing.Size(249, 21);
            this.cboPeriodoLiquidacaoImposto.TabIndex = 26;
            this.cboPeriodoLiquidacaoImposto.Tag = "";
            // 
            // lblPeriodoLiquidacaoImposto
            // 
            this.lblPeriodoLiquidacaoImposto.AutoSize = true;
            this.lblPeriodoLiquidacaoImposto.Location = new System.Drawing.Point(28, 317);
            this.lblPeriodoLiquidacaoImposto.Name = "lblPeriodoLiquidacaoImposto";
            this.lblPeriodoLiquidacaoImposto.Size = new System.Drawing.Size(140, 13);
            this.lblPeriodoLiquidacaoImposto.TabIndex = 25;
            this.lblPeriodoLiquidacaoImposto.Text = "Período Liquidação Imposto";
            // 
            // frmGrupoFornecedorCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(412, 403);
            this.Controls.Add(this.cboPeriodoLiquidacaoImposto);
            this.Controls.Add(this.lblPeriodoLiquidacaoImposto);
            this.Controls.Add(this.cboGrupoImpostos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCondicaoPgto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmGrupoFornecedorCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "frmGrupoFornecedorCad";
            this.Text = "Cadastro Grupo de Fornecedores";
            this.Load += new System.EventHandler(this.frmGrupoFornecedorCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGrupoFornecedorCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.ComboBox cboGrupoImpostos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCondicaoPgto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.ComboBox cboPeriodoLiquidacaoImposto;
        private System.Windows.Forms.Label lblPeriodoLiquidacaoImposto;
    }
}