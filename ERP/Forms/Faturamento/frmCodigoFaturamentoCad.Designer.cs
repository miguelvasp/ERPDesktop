namespace ERP
{
    partial class frmCodigoFaturamentoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCodigoFaturamentoCad));
            this.lbCodigo = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtCFOP = new System.Windows.Forms.TextBox();
            this.lblCFOP = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescComplementar = new System.Windows.Forms.TextBox();
            this.lblDescComplementar = new System.Windows.Forms.Label();
            this.txtICMSTributacao = new System.Windows.Forms.TextBox();
            this.lblICMSTributacao = new System.Windows.Forms.Label();
            this.lblICMSReducao = new System.Windows.Forms.Label();
            this.chkFormaCalculo = new System.Windows.Forms.CheckBox();
            this.chkIncideIPI = new System.Windows.Forms.CheckBox();
            this.chkIPITributacao = new System.Windows.Forms.CheckBox();
            this.chkIncideISS = new System.Windows.Forms.CheckBox();
            this.lblAliquotaISS = new System.Windows.Forms.Label();
            this.txtPISCTS = new System.Windows.Forms.TextBox();
            this.lblPISCTS = new System.Windows.Forms.Label();
            this.lblAliquotaPIS = new System.Windows.Forms.Label();
            this.txtCofinsCTS = new System.Windows.Forms.TextBox();
            this.lblCofinsCTS = new System.Windows.Forms.Label();
            this.lblAliquotaCofins = new System.Windows.Forms.Label();
            this.txtTexto1 = new System.Windows.Forms.TextBox();
            this.lblTexto1 = new System.Windows.Forms.Label();
            this.txtTexto2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtICMSReducao = new System.Windows.Forms.TextBox();
            this.txtAliquotaISS = new System.Windows.Forms.TextBox();
            this.txtAliquotaPIS = new System.Windows.Forms.TextBox();
            this.txtAliquotaCofins = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(505, 129);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 13;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.SmallImage")));
            this.btnImprimir.Text = "Imprimir";
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
            this.rbOpcoes.Panels.Add(this.ribbonPanel2);
            this.rbOpcoes.Text = "Documento";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.btnImprimir);
            this.ribbonPanel2.Text = "Relatórios";
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
            this.ribbon1.Size = new System.Drawing.Size(539, 125);
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtCFOP
            // 
            this.txtCFOP.Location = new System.Drawing.Point(19, 154);
            this.txtCFOP.MaxLength = 4;
            this.txtCFOP.Name = "txtCFOP";
            this.txtCFOP.Size = new System.Drawing.Size(79, 20);
            this.txtCFOP.TabIndex = 15;
            this.txtCFOP.Tag = "1";
            // 
            // lblCFOP
            // 
            this.lblCFOP.AutoSize = true;
            this.lblCFOP.Location = new System.Drawing.Point(16, 138);
            this.lblCFOP.Name = "lblCFOP";
            this.lblCFOP.Size = new System.Drawing.Size(35, 13);
            this.lblCFOP.TabIndex = 14;
            this.lblCFOP.Text = "CFOP";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(114, 154);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(404, 20);
            this.txtDescricao.TabIndex = 17;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(111, 138);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 16;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtDescComplementar
            // 
            this.txtDescComplementar.Location = new System.Drawing.Point(19, 203);
            this.txtDescComplementar.MaxLength = 250;
            this.txtDescComplementar.Name = "txtDescComplementar";
            this.txtDescComplementar.Size = new System.Drawing.Size(499, 20);
            this.txtDescComplementar.TabIndex = 19;
            this.txtDescComplementar.Tag = "1";
            // 
            // lblDescComplementar
            // 
            this.lblDescComplementar.AutoSize = true;
            this.lblDescComplementar.Location = new System.Drawing.Point(16, 187);
            this.lblDescComplementar.Name = "lblDescComplementar";
            this.lblDescComplementar.Size = new System.Drawing.Size(124, 13);
            this.lblDescComplementar.TabIndex = 18;
            this.lblDescComplementar.Text = "Descrição complementar";
            // 
            // txtICMSTributacao
            // 
            this.txtICMSTributacao.Location = new System.Drawing.Point(19, 255);
            this.txtICMSTributacao.MaxLength = 2;
            this.txtICMSTributacao.Name = "txtICMSTributacao";
            this.txtICMSTributacao.Size = new System.Drawing.Size(79, 20);
            this.txtICMSTributacao.TabIndex = 21;
            this.txtICMSTributacao.Tag = "1";
            // 
            // lblICMSTributacao
            // 
            this.lblICMSTributacao.AutoSize = true;
            this.lblICMSTributacao.Location = new System.Drawing.Point(16, 239);
            this.lblICMSTributacao.Name = "lblICMSTributacao";
            this.lblICMSTributacao.Size = new System.Drawing.Size(87, 13);
            this.lblICMSTributacao.TabIndex = 20;
            this.lblICMSTributacao.Text = "ICMS Tributação";
            // 
            // lblICMSReducao
            // 
            this.lblICMSReducao.AutoSize = true;
            this.lblICMSReducao.Location = new System.Drawing.Point(111, 239);
            this.lblICMSReducao.Name = "lblICMSReducao";
            this.lblICMSReducao.Size = new System.Drawing.Size(80, 13);
            this.lblICMSReducao.TabIndex = 22;
            this.lblICMSReducao.Text = "ICMS Redução";
            // 
            // chkFormaCalculo
            // 
            this.chkFormaCalculo.AutoSize = true;
            this.chkFormaCalculo.Location = new System.Drawing.Point(218, 239);
            this.chkFormaCalculo.Name = "chkFormaCalculo";
            this.chkFormaCalculo.Size = new System.Drawing.Size(93, 17);
            this.chkFormaCalculo.TabIndex = 24;
            this.chkFormaCalculo.Text = "Forma Cálculo";
            this.chkFormaCalculo.UseVisualStyleBackColor = true;
            // 
            // chkIncideIPI
            // 
            this.chkIncideIPI.AutoSize = true;
            this.chkIncideIPI.Location = new System.Drawing.Point(218, 258);
            this.chkIncideIPI.Name = "chkIncideIPI";
            this.chkIncideIPI.Size = new System.Drawing.Size(71, 17);
            this.chkIncideIPI.TabIndex = 25;
            this.chkIncideIPI.Text = "Incide IPI";
            this.chkIncideIPI.UseVisualStyleBackColor = true;
            // 
            // chkIPITributacao
            // 
            this.chkIPITributacao.AutoSize = true;
            this.chkIPITributacao.Location = new System.Drawing.Point(333, 258);
            this.chkIPITributacao.Name = "chkIPITributacao";
            this.chkIPITributacao.Size = new System.Drawing.Size(93, 17);
            this.chkIPITributacao.TabIndex = 29;
            this.chkIPITributacao.Text = "IPI Tributação";
            this.chkIPITributacao.UseVisualStyleBackColor = true;
            // 
            // chkIncideISS
            // 
            this.chkIncideISS.AutoSize = true;
            this.chkIncideISS.Location = new System.Drawing.Point(333, 238);
            this.chkIncideISS.Name = "chkIncideISS";
            this.chkIncideISS.Size = new System.Drawing.Size(75, 17);
            this.chkIncideISS.TabIndex = 26;
            this.chkIncideISS.Text = "Incide ISS";
            this.chkIncideISS.UseVisualStyleBackColor = true;
            this.chkIncideISS.CheckedChanged += new System.EventHandler(this.chkIncideISS_CheckedChanged);
            // 
            // lblAliquotaISS
            // 
            this.lblAliquotaISS.AutoSize = true;
            this.lblAliquotaISS.Location = new System.Drawing.Point(436, 239);
            this.lblAliquotaISS.Name = "lblAliquotaISS";
            this.lblAliquotaISS.Size = new System.Drawing.Size(67, 13);
            this.lblAliquotaISS.TabIndex = 27;
            this.lblAliquotaISS.Text = "Alíquota ISS";
            // 
            // txtPISCTS
            // 
            this.txtPISCTS.Location = new System.Drawing.Point(19, 306);
            this.txtPISCTS.MaxLength = 3;
            this.txtPISCTS.Name = "txtPISCTS";
            this.txtPISCTS.Size = new System.Drawing.Size(79, 20);
            this.txtPISCTS.TabIndex = 31;
            this.txtPISCTS.Tag = "";
            // 
            // lblPISCTS
            // 
            this.lblPISCTS.AutoSize = true;
            this.lblPISCTS.Location = new System.Drawing.Point(16, 290);
            this.lblPISCTS.Name = "lblPISCTS";
            this.lblPISCTS.Size = new System.Drawing.Size(48, 13);
            this.lblPISCTS.TabIndex = 30;
            this.lblPISCTS.Text = "PIS CTS";
            // 
            // lblAliquotaPIS
            // 
            this.lblAliquotaPIS.AutoSize = true;
            this.lblAliquotaPIS.Location = new System.Drawing.Point(111, 290);
            this.lblAliquotaPIS.Name = "lblAliquotaPIS";
            this.lblAliquotaPIS.Size = new System.Drawing.Size(67, 13);
            this.lblAliquotaPIS.TabIndex = 32;
            this.lblAliquotaPIS.Text = "Alíquota PIS";
            // 
            // txtCofinsCTS
            // 
            this.txtCofinsCTS.Location = new System.Drawing.Point(218, 306);
            this.txtCofinsCTS.MaxLength = 3;
            this.txtCofinsCTS.Name = "txtCofinsCTS";
            this.txtCofinsCTS.Size = new System.Drawing.Size(79, 20);
            this.txtCofinsCTS.TabIndex = 35;
            this.txtCofinsCTS.Tag = "";
            // 
            // lblCofinsCTS
            // 
            this.lblCofinsCTS.AutoSize = true;
            this.lblCofinsCTS.Location = new System.Drawing.Point(215, 290);
            this.lblCofinsCTS.Name = "lblCofinsCTS";
            this.lblCofinsCTS.Size = new System.Drawing.Size(60, 13);
            this.lblCofinsCTS.TabIndex = 34;
            this.lblCofinsCTS.Text = "Cofins CTS";
            // 
            // lblAliquotaCofins
            // 
            this.lblAliquotaCofins.AutoSize = true;
            this.lblAliquotaCofins.Location = new System.Drawing.Point(312, 290);
            this.lblAliquotaCofins.Name = "lblAliquotaCofins";
            this.lblAliquotaCofins.Size = new System.Drawing.Size(79, 13);
            this.lblAliquotaCofins.TabIndex = 36;
            this.lblAliquotaCofins.Text = "Alíquota Cofins";
            // 
            // txtTexto1
            // 
            this.txtTexto1.Location = new System.Drawing.Point(19, 355);
            this.txtTexto1.MaxLength = 250;
            this.txtTexto1.Name = "txtTexto1";
            this.txtTexto1.Size = new System.Drawing.Size(499, 20);
            this.txtTexto1.TabIndex = 39;
            this.txtTexto1.Tag = "";
            // 
            // lblTexto1
            // 
            this.lblTexto1.AutoSize = true;
            this.lblTexto1.Location = new System.Drawing.Point(16, 339);
            this.lblTexto1.Name = "lblTexto1";
            this.lblTexto1.Size = new System.Drawing.Size(63, 13);
            this.lblTexto1.TabIndex = 38;
            this.lblTexto1.Text = "Outro Texto";
            // 
            // txtTexto2
            // 
            this.txtTexto2.Location = new System.Drawing.Point(19, 405);
            this.txtTexto2.MaxLength = 250;
            this.txtTexto2.Name = "txtTexto2";
            this.txtTexto2.Size = new System.Drawing.Size(499, 20);
            this.txtTexto2.TabIndex = 41;
            this.txtTexto2.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Outro Texto";
            // 
            // txtICMSReducao
            // 
            this.txtICMSReducao.Location = new System.Drawing.Point(114, 255);
            this.txtICMSReducao.MaxLength = 10;
            this.txtICMSReducao.Name = "txtICMSReducao";
            this.txtICMSReducao.Size = new System.Drawing.Size(79, 20);
            this.txtICMSReducao.TabIndex = 23;
            this.txtICMSReducao.Tag = "4";
            this.txtICMSReducao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtICMSReducao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtICMSReducao_KeyPress);
            // 
            // txtAliquotaISS
            // 
            this.txtAliquotaISS.Location = new System.Drawing.Point(439, 255);
            this.txtAliquotaISS.MaxLength = 10;
            this.txtAliquotaISS.Name = "txtAliquotaISS";
            this.txtAliquotaISS.Size = new System.Drawing.Size(79, 20);
            this.txtAliquotaISS.TabIndex = 28;
            this.txtAliquotaISS.Tag = "4";
            this.txtAliquotaISS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAliquotaISS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAliquotaISS_KeyPress);
            // 
            // txtAliquotaPIS
            // 
            this.txtAliquotaPIS.Location = new System.Drawing.Point(114, 306);
            this.txtAliquotaPIS.MaxLength = 10;
            this.txtAliquotaPIS.Name = "txtAliquotaPIS";
            this.txtAliquotaPIS.Size = new System.Drawing.Size(79, 20);
            this.txtAliquotaPIS.TabIndex = 33;
            this.txtAliquotaPIS.Tag = "4";
            this.txtAliquotaPIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAliquotaPIS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAliquotaPIS_KeyPress);
            // 
            // txtAliquotaCofins
            // 
            this.txtAliquotaCofins.Location = new System.Drawing.Point(315, 306);
            this.txtAliquotaCofins.MaxLength = 10;
            this.txtAliquotaCofins.Name = "txtAliquotaCofins";
            this.txtAliquotaCofins.Size = new System.Drawing.Size(79, 20);
            this.txtAliquotaCofins.TabIndex = 37;
            this.txtAliquotaCofins.Tag = "4";
            this.txtAliquotaCofins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAliquotaCofins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAliquotaCofins_KeyPress);
            // 
            // frmCodigoFaturamentoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(539, 443);
            this.Controls.Add(this.txtAliquotaCofins);
            this.Controls.Add(this.txtAliquotaPIS);
            this.Controls.Add(this.txtAliquotaISS);
            this.Controls.Add(this.txtICMSReducao);
            this.Controls.Add(this.txtTexto2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTexto1);
            this.Controls.Add(this.lblTexto1);
            this.Controls.Add(this.lblAliquotaCofins);
            this.Controls.Add(this.txtCofinsCTS);
            this.Controls.Add(this.lblCofinsCTS);
            this.Controls.Add(this.lblAliquotaPIS);
            this.Controls.Add(this.txtPISCTS);
            this.Controls.Add(this.lblPISCTS);
            this.Controls.Add(this.lblAliquotaISS);
            this.Controls.Add(this.chkIncideISS);
            this.Controls.Add(this.chkIPITributacao);
            this.Controls.Add(this.chkIncideIPI);
            this.Controls.Add(this.chkFormaCalculo);
            this.Controls.Add(this.lblICMSReducao);
            this.Controls.Add(this.txtICMSTributacao);
            this.Controls.Add(this.lblICMSTributacao);
            this.Controls.Add(this.txtDescComplementar);
            this.Controls.Add(this.lblDescComplementar);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtCFOP);
            this.Controls.Add(this.lblCFOP);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmCodigoFaturamentoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmCodigoFaturamentoCad";
            this.Text = "Cadastro de Códigos de Faturamento";
            this.Load += new System.EventHandler(this.frmCodigoFaturamentoCad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.RibbonButton btnImprimir;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.TextBox txtCFOP;
        private System.Windows.Forms.Label lblCFOP;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescComplementar;
        private System.Windows.Forms.Label lblDescComplementar;
        private System.Windows.Forms.TextBox txtICMSTributacao;
        private System.Windows.Forms.Label lblICMSTributacao;
        private System.Windows.Forms.Label lblICMSReducao;
        private System.Windows.Forms.CheckBox chkFormaCalculo;
        private System.Windows.Forms.CheckBox chkIncideIPI;
        private System.Windows.Forms.CheckBox chkIPITributacao;
        private System.Windows.Forms.CheckBox chkIncideISS;
        private System.Windows.Forms.Label lblAliquotaISS;
        private System.Windows.Forms.TextBox txtPISCTS;
        private System.Windows.Forms.Label lblPISCTS;
        private System.Windows.Forms.Label lblAliquotaPIS;
        private System.Windows.Forms.TextBox txtCofinsCTS;
        private System.Windows.Forms.Label lblCofinsCTS;
        private System.Windows.Forms.Label lblAliquotaCofins;
        private System.Windows.Forms.TextBox txtTexto1;
        private System.Windows.Forms.Label lblTexto1;
        private System.Windows.Forms.TextBox txtTexto2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtICMSReducao;
        private System.Windows.Forms.TextBox txtAliquotaISS;
        private System.Windows.Forms.TextBox txtAliquotaPIS;
        private System.Windows.Forms.TextBox txtAliquotaCofins;
    }
}