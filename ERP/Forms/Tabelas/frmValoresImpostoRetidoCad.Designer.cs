namespace ERP
{
    partial class frmValoresImpostoRetidoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValoresImpostoRetidoCad));
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtAliquota = new System.Windows.Forms.TextBox();
            this.lblAliquota = new System.Windows.Forms.Label();
            this.txtPercentualExclusao = new System.Windows.Forms.TextBox();
            this.lblPercentualExclusao = new System.Windows.Forms.Label();
            this.txtDeducaoIRRF = new System.Windows.Forms.TextBox();
            this.lblDeducaoIRRF = new System.Windows.Forms.Label();
            this.txtLimiteMaximo = new System.Windows.Forms.TextBox();
            this.lblLimiteMaximo = new System.Windows.Forms.Label();
            this.txtLimiteMinimo = new System.Windows.Forms.TextBox();
            this.lblLimiteMinimo = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.lblDe = new System.Windows.Forms.Label();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
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
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.btnAdiciona);
            this.ribbonPanel1.Items.Add(this.btnAlterar);
            this.ribbonPanel1.Items.Add(this.btnGrava);
            this.ribbonPanel1.Items.Add(this.btnCancelar);
            this.ribbonPanel1.Items.Add(this.btnExcluir);
            this.ribbonPanel1.Text = "Informações";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnExcluir.SmallImage")));
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
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
            this.ribbon1.Size = new System.Drawing.Size(397, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtAliquota
            // 
            this.txtAliquota.Location = new System.Drawing.Point(26, 291);
            this.txtAliquota.MaxLength = 10;
            this.txtAliquota.Name = "txtAliquota";
            this.txtAliquota.Size = new System.Drawing.Size(166, 20);
            this.txtAliquota.TabIndex = 46;
            this.txtAliquota.Tag = "3";
            this.txtAliquota.Text = "0,0000";
            this.txtAliquota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAliquota_KeyPress);
            // 
            // lblAliquota
            // 
            this.lblAliquota.AutoSize = true;
            this.lblAliquota.Location = new System.Drawing.Point(23, 271);
            this.lblAliquota.Name = "lblAliquota";
            this.lblAliquota.Size = new System.Drawing.Size(47, 13);
            this.lblAliquota.TabIndex = 45;
            this.lblAliquota.Text = "Alíquota";
            // 
            // txtPercentualExclusao
            // 
            this.txtPercentualExclusao.Location = new System.Drawing.Point(204, 291);
            this.txtPercentualExclusao.MaxLength = 10;
            this.txtPercentualExclusao.Name = "txtPercentualExclusao";
            this.txtPercentualExclusao.Size = new System.Drawing.Size(166, 20);
            this.txtPercentualExclusao.TabIndex = 48;
            this.txtPercentualExclusao.Tag = "3";
            this.txtPercentualExclusao.Text = "0,0000";
            this.txtPercentualExclusao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPercentualExclusao_KeyPress);
            // 
            // lblPercentualExclusao
            // 
            this.lblPercentualExclusao.AutoSize = true;
            this.lblPercentualExclusao.Location = new System.Drawing.Point(201, 271);
            this.lblPercentualExclusao.Name = "lblPercentualExclusao";
            this.lblPercentualExclusao.Size = new System.Drawing.Size(104, 13);
            this.lblPercentualExclusao.TabIndex = 47;
            this.lblPercentualExclusao.Text = "Percentual Exclusão";
            // 
            // txtDeducaoIRRF
            // 
            this.txtDeducaoIRRF.Location = new System.Drawing.Point(26, 345);
            this.txtDeducaoIRRF.MaxLength = 10;
            this.txtDeducaoIRRF.Name = "txtDeducaoIRRF";
            this.txtDeducaoIRRF.Size = new System.Drawing.Size(166, 20);
            this.txtDeducaoIRRF.TabIndex = 50;
            this.txtDeducaoIRRF.Tag = "3";
            this.txtDeducaoIRRF.Text = "0,0000";
            this.txtDeducaoIRRF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeducaoIRRF_KeyPress);
            // 
            // lblDeducaoIRRF
            // 
            this.lblDeducaoIRRF.AutoSize = true;
            this.lblDeducaoIRRF.Location = new System.Drawing.Point(23, 325);
            this.lblDeducaoIRRF.Name = "lblDeducaoIRRF";
            this.lblDeducaoIRRF.Size = new System.Drawing.Size(79, 13);
            this.lblDeducaoIRRF.TabIndex = 49;
            this.lblDeducaoIRRF.Text = "Dedução IRRF";
            // 
            // txtLimiteMaximo
            // 
            this.txtLimiteMaximo.Location = new System.Drawing.Point(204, 238);
            this.txtLimiteMaximo.MaxLength = 10;
            this.txtLimiteMaximo.Name = "txtLimiteMaximo";
            this.txtLimiteMaximo.Size = new System.Drawing.Size(166, 20);
            this.txtLimiteMaximo.TabIndex = 44;
            this.txtLimiteMaximo.Tag = "3";
            this.txtLimiteMaximo.Text = "0,0000";
            this.txtLimiteMaximo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteMaximo_KeyPress);
            // 
            // lblLimiteMaximo
            // 
            this.lblLimiteMaximo.AutoSize = true;
            this.lblLimiteMaximo.Location = new System.Drawing.Point(201, 218);
            this.lblLimiteMaximo.Name = "lblLimiteMaximo";
            this.lblLimiteMaximo.Size = new System.Drawing.Size(73, 13);
            this.lblLimiteMaximo.TabIndex = 43;
            this.lblLimiteMaximo.Text = "Limite Máximo";
            // 
            // txtLimiteMinimo
            // 
            this.txtLimiteMinimo.Location = new System.Drawing.Point(26, 238);
            this.txtLimiteMinimo.MaxLength = 10;
            this.txtLimiteMinimo.Name = "txtLimiteMinimo";
            this.txtLimiteMinimo.Size = new System.Drawing.Size(166, 20);
            this.txtLimiteMinimo.TabIndex = 42;
            this.txtLimiteMinimo.Tag = "3";
            this.txtLimiteMinimo.Text = "0,0000";
            this.txtLimiteMinimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteMinimo_KeyPress);
            // 
            // lblLimiteMinimo
            // 
            this.lblLimiteMinimo.AutoSize = true;
            this.lblLimiteMinimo.Location = new System.Drawing.Point(23, 218);
            this.lblLimiteMinimo.Name = "lblLimiteMinimo";
            this.lblLimiteMinimo.Size = new System.Drawing.Size(72, 13);
            this.lblLimiteMinimo.TabIndex = 41;
            this.lblLimiteMinimo.Text = "Limite Mínimo";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Location = new System.Drawing.Point(201, 166);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(23, 13);
            this.lblAte.TabIndex = 39;
            this.lblAte.Text = "Até";
            // 
            // dtpAte
            // 
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(204, 182);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.ShowCheckBox = true;
            this.dtpAte.Size = new System.Drawing.Size(145, 20);
            this.dtpAte.TabIndex = 40;
            this.dtpAte.Tag = "1";
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(23, 166);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(21, 13);
            this.lblDe.TabIndex = 37;
            this.lblDe.Text = "De";
            // 
            // dtpDe
            // 
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.Location = new System.Drawing.Point(26, 182);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.ShowCheckBox = true;
            this.dtpDe.Size = new System.Drawing.Size(145, 20);
            this.dtpDe.TabIndex = 38;
            this.dtpDe.Tag = "1";
            // 
            // frmValoresImpostoRetidoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(397, 428);
            this.Controls.Add(this.txtAliquota);
            this.Controls.Add(this.lblAliquota);
            this.Controls.Add(this.txtPercentualExclusao);
            this.Controls.Add(this.lblPercentualExclusao);
            this.Controls.Add(this.txtDeducaoIRRF);
            this.Controls.Add(this.lblDeducaoIRRF);
            this.Controls.Add(this.txtLimiteMaximo);
            this.Controls.Add(this.lblLimiteMaximo);
            this.Controls.Add(this.txtLimiteMinimo);
            this.Controls.Add(this.lblLimiteMinimo);
            this.Controls.Add(this.lblAte);
            this.Controls.Add(this.dtpAte);
            this.Controls.Add(this.lblDe);
            this.Controls.Add(this.dtpDe);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmValoresImpostoRetidoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmValoresImpostoRetidoCad";
            this.Text = "Cadastro Valores Imposto Retido";
            this.Load += new System.EventHandler(this.frmValoresImpostoRetidoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmValoresImpostoRetidoCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.TextBox txtAliquota;
        private System.Windows.Forms.Label lblAliquota;
        private System.Windows.Forms.TextBox txtPercentualExclusao;
        private System.Windows.Forms.Label lblPercentualExclusao;
        private System.Windows.Forms.TextBox txtDeducaoIRRF;
        private System.Windows.Forms.Label lblDeducaoIRRF;
        private System.Windows.Forms.TextBox txtLimiteMaximo;
        private System.Windows.Forms.Label lblLimiteMaximo;
        private System.Windows.Forms.TextBox txtLimiteMinimo;
        private System.Windows.Forms.Label lblLimiteMinimo;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.DateTimePicker dtpDe;
    }
}