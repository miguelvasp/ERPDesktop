namespace ERP
{
    partial class frmUnidadeFederacaoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnidadeFederacaoCad));
            this.txtIBGE = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblAliquotaICMS = new System.Windows.Forms.Label();
            this.txtAliquotaICMS = new System.Windows.Forms.TextBox();
            this.txtAliquotaICMSSubs = new System.Windows.Forms.TextBox();
            this.lblAliquotaSubs = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.lblIVA = new System.Windows.Forms.Label();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.SuspendLayout();
            // 
            // txtIBGE
            // 
            this.txtIBGE.Location = new System.Drawing.Point(225, 267);
            this.txtIBGE.MaxLength = 10;
            this.txtIBGE.Name = "txtIBGE";
            this.txtIBGE.Size = new System.Drawing.Size(144, 20);
            this.txtIBGE.TabIndex = 24;
            this.txtIBGE.Tag = "1";
            this.txtIBGE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIBGE_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Código IBGE";
            // 
            // txtUF
            // 
            this.txtUF.Location = new System.Drawing.Point(27, 154);
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(144, 20);
            this.txtUF.TabIndex = 13;
            this.txtUF.Tag = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "UF";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(569, 128);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 11;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(222, 138);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 15;
            this.lblNome.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(225, 154);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(351, 20);
            this.txtNome.TabIndex = 16;
            this.txtNome.Tag = "1";
            // 
            // lblAliquotaICMS
            // 
            this.lblAliquotaICMS.AutoSize = true;
            this.lblAliquotaICMS.Location = new System.Drawing.Point(24, 196);
            this.lblAliquotaICMS.Name = "lblAliquotaICMS";
            this.lblAliquotaICMS.Size = new System.Drawing.Size(76, 13);
            this.lblAliquotaICMS.TabIndex = 17;
            this.lblAliquotaICMS.Text = "Alíquota ICMS";
            // 
            // txtAliquotaICMS
            // 
            this.txtAliquotaICMS.Location = new System.Drawing.Point(27, 212);
            this.txtAliquotaICMS.MaxLength = 18;
            this.txtAliquotaICMS.Name = "txtAliquotaICMS";
            this.txtAliquotaICMS.Size = new System.Drawing.Size(144, 20);
            this.txtAliquotaICMS.TabIndex = 18;
            this.txtAliquotaICMS.Tag = "4";
            this.txtAliquotaICMS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAliquotaICMS_KeyPress);
            // 
            // txtAliquotaICMSSubs
            // 
            this.txtAliquotaICMSSubs.Location = new System.Drawing.Point(225, 212);
            this.txtAliquotaICMSSubs.MaxLength = 18;
            this.txtAliquotaICMSSubs.Name = "txtAliquotaICMSSubs";
            this.txtAliquotaICMSSubs.Size = new System.Drawing.Size(144, 20);
            this.txtAliquotaICMSSubs.TabIndex = 20;
            this.txtAliquotaICMSSubs.Tag = "4";
            this.txtAliquotaICMSSubs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAliquotaICMSSubs_KeyPress);
            // 
            // lblAliquotaSubs
            // 
            this.lblAliquotaSubs.AutoSize = true;
            this.lblAliquotaSubs.Location = new System.Drawing.Point(222, 196);
            this.lblAliquotaSubs.Name = "lblAliquotaSubs";
            this.lblAliquotaSubs.Size = new System.Drawing.Size(106, 13);
            this.lblAliquotaSubs.TabIndex = 19;
            this.lblAliquotaSubs.Text = "Alíquota ICMS Subs.";
            // 
            // txtIVA
            // 
            this.txtIVA.Location = new System.Drawing.Point(27, 267);
            this.txtIVA.MaxLength = 18;
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(144, 20);
            this.txtIVA.TabIndex = 22;
            this.txtIVA.Tag = "4";
            this.txtIVA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIVA_KeyPress);
            // 
            // lblIVA
            // 
            this.lblIVA.AutoSize = true;
            this.lblIVA.Location = new System.Drawing.Point(24, 251);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(24, 13);
            this.lblIVA.TabIndex = 21;
            this.lblIVA.Text = "IVA";
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
            this.ribbon1.Size = new System.Drawing.Size(596, 125);
            this.ribbon1.TabIndex = 26;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // rbOpcoes
            // 
            this.rbOpcoes.Panels.Add(this.ribbonPanel1);
            this.rbOpcoes.Text = "Documento";
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
            // btnAdiciona
            // 
            this.btnAdiciona.Image = ((System.Drawing.Image)(resources.GetObject("btnAdiciona.Image")));
            this.btnAdiciona.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAdiciona.SmallImage")));
            this.btnAdiciona.Text = "Adicionar";
            this.btnAdiciona.Click += new System.EventHandler(this.btnAdiciona_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAlterar.SmallImage")));
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnGrava
            // 
            this.btnGrava.Enabled = false;
            this.btnGrava.Image = ((System.Drawing.Image)(resources.GetObject("btnGrava.Image")));
            this.btnGrava.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGrava.SmallImage")));
            this.btnGrava.Text = "Gravar";
            this.btnGrava.Click += new System.EventHandler(this.btnGrava_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.SmallImage")));
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnExcluir.SmallImage")));
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.DoubleClick += new System.EventHandler(this.btnExcluir_Click);
            // 
            // frmUnidadeFederacaoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(596, 307);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.lblIVA);
            this.Controls.Add(this.txtAliquotaICMSSubs);
            this.Controls.Add(this.lblAliquotaSubs);
            this.Controls.Add(this.txtAliquotaICMS);
            this.Controls.Add(this.lblAliquotaICMS);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtIBGE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbCodigo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmUnidadeFederacaoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmUnidadeFederecaoCad";
            this.Text = "Cadastro de Unidade Federação";
            this.Load += new System.EventHandler(this.frmUnidadeFederacaoCad_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmUnidadeFederacaoCad_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIBGE;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblAliquotaICMS;
        private System.Windows.Forms.TextBox txtAliquotaICMS;
        private System.Windows.Forms.TextBox txtAliquotaICMSSubs;
        private System.Windows.Forms.Label lblAliquotaSubs;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnExcluir;

    }
}