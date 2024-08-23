namespace ERP
{
    partial class frmProgramaCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProgramaCad));
            this.txtFormulario = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.chkManutencao = new System.Windows.Forms.CheckBox();
            this.cboTipoPrograma = new System.Windows.Forms.ComboBox();
            this.lblTipoPrograma = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFormulario
            // 
            this.txtFormulario.Location = new System.Drawing.Point(25, 269);
            this.txtFormulario.MaxLength = 50;
            this.txtFormulario.Name = "txtFormulario";
            this.txtFormulario.Size = new System.Drawing.Size(354, 20);
            this.txtFormulario.TabIndex = 17;
            this.txtFormulario.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(22, 201);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 14;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(25, 163);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(354, 20);
            this.txtNome.TabIndex = 13;
            this.txtNome.Tag = "1";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(22, 146);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 12;
            this.lblNome.Text = "Nome";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(366, 135);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(13, 13);
            this.lblCodigo.TabIndex = 11;
            this.lblCodigo.Text = "0";
            this.lblCodigo.Visible = false;
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
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // rbOpcoes
            // 
            this.rbOpcoes.Panels.Add(this.ribbonPanel1);
            this.rbOpcoes.Text = "Documento";
            // 
            // lblFormulario
            // 
            this.lblFormulario.AutoSize = true;
            this.lblFormulario.Location = new System.Drawing.Point(22, 252);
            this.lblFormulario.Name = "lblFormulario";
            this.lblFormulario.Size = new System.Drawing.Size(55, 13);
            this.lblFormulario.TabIndex = 16;
            this.lblFormulario.Text = "Formulário";
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
            this.ribbon1.Size = new System.Drawing.Size(556, 125);
            this.ribbon1.TabIndex = 10;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(25, 218);
            this.txtDescricao.MaxLength = 255;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(515, 20);
            this.txtDescricao.TabIndex = 15;
            this.txtDescricao.Tag = "1";
            // 
            // chkManutencao
            // 
            this.chkManutencao.AutoSize = true;
            this.chkManutencao.Location = new System.Drawing.Point(25, 306);
            this.chkManutencao.Name = "chkManutencao";
            this.chkManutencao.Size = new System.Drawing.Size(124, 17);
            this.chkManutencao.TabIndex = 18;
            this.chkManutencao.Text = "Permite Manutenção";
            this.chkManutencao.UseVisualStyleBackColor = true;
            // 
            // cboTipoPrograma
            // 
            this.cboTipoPrograma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTipoPrograma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoPrograma.DropDownWidth = 170;
            this.cboTipoPrograma.FormattingEnabled = true;
            this.cboTipoPrograma.Location = new System.Drawing.Point(25, 354);
            this.cboTipoPrograma.Name = "cboTipoPrograma";
            this.cboTipoPrograma.Size = new System.Drawing.Size(184, 21);
            this.cboTipoPrograma.TabIndex = 20;
            this.cboTipoPrograma.Tag = "1";
            // 
            // lblTipoPrograma
            // 
            this.lblTipoPrograma.AutoSize = true;
            this.lblTipoPrograma.Location = new System.Drawing.Point(22, 337);
            this.lblTipoPrograma.Name = "lblTipoPrograma";
            this.lblTipoPrograma.Size = new System.Drawing.Size(91, 13);
            this.lblTipoPrograma.TabIndex = 19;
            this.lblTipoPrograma.Text = "Tipo de Programa";
            // 
            // frmProgramaCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(556, 408);
            this.Controls.Add(this.cboTipoPrograma);
            this.Controls.Add(this.lblTipoPrograma);
            this.Controls.Add(this.chkManutencao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtFormulario);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblFormulario);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmProgramaCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "frmProgramaCad";
            this.Text = "Cadastro de Programas";
            this.Load += new System.EventHandler(this.frmProgramaCad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFormulario;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.CheckBox chkManutencao;
        private System.Windows.Forms.ComboBox cboTipoPrograma;
        private System.Windows.Forms.Label lblTipoPrograma;

    }
}