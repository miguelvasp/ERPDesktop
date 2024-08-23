namespace ERP.Auxiliares
{
    partial class frmDiasPagamentoCadAux
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiasPagamentoCad));
            this.txtDiaMes = new System.Windows.Forms.TextBox();
            this.lblDiaMes = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.cboSemanaMes = new System.Windows.Forms.ComboBox();
            this.lblSemanaMes = new System.Windows.Forms.Label();
            this.cboDiaSemana = new System.Windows.Forms.ComboBox();
            this.lblDiaDaSemana = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDiaMes
            // 
            this.txtDiaMes.Location = new System.Drawing.Point(488, 165);
            this.txtDiaMes.MaxLength = 3;
            this.txtDiaMes.Name = "txtDiaMes";
            this.txtDiaMes.Size = new System.Drawing.Size(58, 20);
            this.txtDiaMes.TabIndex = 21;
            this.txtDiaMes.Tag = "1";
            this.txtDiaMes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiaMes_KeyPress);
            // 
            // lblDiaMes
            // 
            this.lblDiaMes.AutoSize = true;
            this.lblDiaMes.Location = new System.Drawing.Point(485, 149);
            this.lblDiaMes.Name = "lblDiaMes";
            this.lblDiaMes.Size = new System.Drawing.Size(61, 13);
            this.lblDiaMes.TabIndex = 20;
            this.lblDiaMes.Text = "Dia do Mês";
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
            this.ribbon1.Size = new System.Drawing.Size(595, 125);
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // cboSemanaMes
            // 
            this.cboSemanaMes.FormattingEnabled = true;
            this.cboSemanaMes.Location = new System.Drawing.Point(28, 164);
            this.cboSemanaMes.Name = "cboSemanaMes";
            this.cboSemanaMes.Size = new System.Drawing.Size(258, 21);
            this.cboSemanaMes.TabIndex = 22;
            this.cboSemanaMes.Tag = "1";
            // 
            // lblSemanaMes
            // 
            this.lblSemanaMes.AutoSize = true;
            this.lblSemanaMes.Location = new System.Drawing.Point(25, 148);
            this.lblSemanaMes.Name = "lblSemanaMes";
            this.lblSemanaMes.Size = new System.Drawing.Size(71, 13);
            this.lblSemanaMes.TabIndex = 23;
            this.lblSemanaMes.Text = "Semana/Mês";
            // 
            // cboDiaSemana
            // 
            this.cboDiaSemana.FormattingEnabled = true;
            this.cboDiaSemana.Location = new System.Drawing.Point(292, 164);
            this.cboDiaSemana.Name = "cboDiaSemana";
            this.cboDiaSemana.Size = new System.Drawing.Size(190, 21);
            this.cboDiaSemana.TabIndex = 24;
            this.cboDiaSemana.Tag = "1";
            // 
            // lblDiaDaSemana
            // 
            this.lblDiaDaSemana.AutoSize = true;
            this.lblDiaDaSemana.Location = new System.Drawing.Point(289, 148);
            this.lblDiaDaSemana.Name = "lblDiaDaSemana";
            this.lblDiaDaSemana.Size = new System.Drawing.Size(85, 13);
            this.lblDiaDaSemana.TabIndex = 25;
            this.lblDiaDaSemana.Text = "Dias da Semana";
            // 
            // frmDiasPagamentoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(595, 232);
            this.Controls.Add(this.cboDiaSemana);
            this.Controls.Add(this.lblDiaDaSemana);
            this.Controls.Add(this.cboSemanaMes);
            this.Controls.Add(this.lblSemanaMes);
            this.Controls.Add(this.txtDiaMes);
            this.Controls.Add(this.lblDiaMes);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDiasPagamentoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "frmDiasPagamentoCad";
            this.Text = "Cadastro Dias de Pagamento";
            this.Load += new System.EventHandler(this.frmDiasPagamentoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDiasPagamentoCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDiaMes;
        private System.Windows.Forms.Label lblDiaMes;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.ComboBox cboSemanaMes;
        private System.Windows.Forms.Label lblSemanaMes;
        private System.Windows.Forms.ComboBox cboDiaSemana;
        private System.Windows.Forms.Label lblDiaDaSemana;
    }
}