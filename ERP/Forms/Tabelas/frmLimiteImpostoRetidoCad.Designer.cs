namespace ERP
{
    partial class frmLimiteImpostoRetidoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLimiteImpostoRetidoCad));
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtLimiteMaximo = new System.Windows.Forms.TextBox();
            this.lblLimiteMaximo = new System.Windows.Forms.Label();
            this.txtLimiteMinimo = new System.Windows.Forms.TextBox();
            this.lblLimiteMinimo = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.lblDe = new System.Windows.Forms.Label();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.lbCodigo = new System.Windows.Forms.Label();
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
            this.ribbon1.Size = new System.Drawing.Size(409, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtLimiteMaximo
            // 
            this.txtLimiteMaximo.Location = new System.Drawing.Point(217, 226);
            this.txtLimiteMaximo.MaxLength = 10;
            this.txtLimiteMaximo.Name = "txtLimiteMaximo";
            this.txtLimiteMaximo.Size = new System.Drawing.Size(166, 20);
            this.txtLimiteMaximo.TabIndex = 34;
            this.txtLimiteMaximo.Tag = "3";
            this.txtLimiteMaximo.Text = "0,0000";
            this.txtLimiteMaximo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteMaximo_KeyPress);
            // 
            // lblLimiteMaximo
            // 
            this.lblLimiteMaximo.AutoSize = true;
            this.lblLimiteMaximo.Location = new System.Drawing.Point(214, 206);
            this.lblLimiteMaximo.Name = "lblLimiteMaximo";
            this.lblLimiteMaximo.Size = new System.Drawing.Size(73, 13);
            this.lblLimiteMaximo.TabIndex = 33;
            this.lblLimiteMaximo.Text = "Limite Máximo";
            // 
            // txtLimiteMinimo
            // 
            this.txtLimiteMinimo.Location = new System.Drawing.Point(39, 226);
            this.txtLimiteMinimo.MaxLength = 10;
            this.txtLimiteMinimo.Name = "txtLimiteMinimo";
            this.txtLimiteMinimo.Size = new System.Drawing.Size(166, 20);
            this.txtLimiteMinimo.TabIndex = 32;
            this.txtLimiteMinimo.Tag = "3";
            this.txtLimiteMinimo.Text = "0,0000";
            this.txtLimiteMinimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimiteMinimo_KeyPress);
            // 
            // lblLimiteMinimo
            // 
            this.lblLimiteMinimo.AutoSize = true;
            this.lblLimiteMinimo.Location = new System.Drawing.Point(36, 206);
            this.lblLimiteMinimo.Name = "lblLimiteMinimo";
            this.lblLimiteMinimo.Size = new System.Drawing.Size(72, 13);
            this.lblLimiteMinimo.TabIndex = 31;
            this.lblLimiteMinimo.Text = "Limite Mínimo";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Location = new System.Drawing.Point(214, 154);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(23, 13);
            this.lblAte.TabIndex = 29;
            this.lblAte.Text = "Até";
            // 
            // dtpAte
            // 
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(217, 170);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.ShowCheckBox = true;
            this.dtpAte.Size = new System.Drawing.Size(145, 20);
            this.dtpAte.TabIndex = 30;
            this.dtpAte.Tag = "1";
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(36, 154);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(21, 13);
            this.lblDe.TabIndex = 27;
            this.lblDe.Text = "De";
            // 
            // dtpDe
            // 
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.Location = new System.Drawing.Point(39, 170);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.ShowCheckBox = true;
            this.dtpDe.Size = new System.Drawing.Size(145, 20);
            this.dtpDe.TabIndex = 28;
            this.dtpDe.Tag = "1";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(349, 141);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 26;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
            // 
            // frmLimiteImpostoRetidoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(409, 283);
            this.Controls.Add(this.txtLimiteMaximo);
            this.Controls.Add(this.lblLimiteMaximo);
            this.Controls.Add(this.txtLimiteMinimo);
            this.Controls.Add(this.lblLimiteMinimo);
            this.Controls.Add(this.lblAte);
            this.Controls.Add(this.dtpAte);
            this.Controls.Add(this.lblDe);
            this.Controls.Add(this.dtpDe);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmLimiteImpostoRetidoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmLimiteImpostoCad";
            this.Text = "Cadastro Limite Imposto Retido";
            this.Load += new System.EventHandler(this.frmLimiteImpostoCad_Load);
            this.Click += new System.EventHandler(this.frmLimiteImpostoCad_Load);
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
        private System.Windows.Forms.TextBox txtLimiteMaximo;
        private System.Windows.Forms.Label lblLimiteMaximo;
        private System.Windows.Forms.TextBox txtLimiteMinimo;
        private System.Windows.Forms.Label lblLimiteMinimo;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.Label lbCodigo;
    }
}