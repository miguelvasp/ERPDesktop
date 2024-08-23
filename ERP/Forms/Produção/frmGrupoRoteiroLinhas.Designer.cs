namespace ERP 
{
    partial class frmGrupoRoteiroLinhas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoRoteiroLinhas));
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAtivacao = new System.Windows.Forms.CheckBox();
            this.chkCapacidade = new System.Windows.Forms.CheckBox();
            this.chkGerenciamentoTrabalho = new System.Windows.Forms.CheckBox();
            this.chkHorarioTrabalho = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Text = "Opções";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.ribbonButton1);
            this.ribbonPanel1.Items.Add(this.ribbonButton2);
            this.ribbonPanel1.Text = "";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = global::ERP.Properties.Resources.save32;
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "Gravar";
            this.ribbonButton1.Click += new System.EventHandler(this.ribbonButton1_Click);
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = global::ERP.Properties.Resources.Close_2_icon;
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "excluir";
            this.ribbonButton2.Click += new System.EventHandler(this.ribbonButton2_Click);
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 8F);
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
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(540, 145);
            this.ribbon1.TabIndex = 5;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(24, 188);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(488, 21);
            this.cboTipo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tipo de roteiro/trabalho";
            // 
            // chkAtivacao
            // 
            this.chkAtivacao.AutoSize = true;
            this.chkAtivacao.Location = new System.Drawing.Point(47, 239);
            this.chkAtivacao.Name = "chkAtivacao";
            this.chkAtivacao.Size = new System.Drawing.Size(68, 17);
            this.chkAtivacao.TabIndex = 8;
            this.chkAtivacao.Text = "Ativação";
            this.chkAtivacao.UseVisualStyleBackColor = true;
            // 
            // chkCapacidade
            // 
            this.chkCapacidade.AutoSize = true;
            this.chkCapacidade.Location = new System.Drawing.Point(47, 262);
            this.chkCapacidade.Name = "chkCapacidade";
            this.chkCapacidade.Size = new System.Drawing.Size(83, 17);
            this.chkCapacidade.TabIndex = 9;
            this.chkCapacidade.Text = "Capacidade";
            this.chkCapacidade.UseVisualStyleBackColor = true;
            // 
            // chkGerenciamentoTrabalho
            // 
            this.chkGerenciamentoTrabalho.AutoSize = true;
            this.chkGerenciamentoTrabalho.Location = new System.Drawing.Point(47, 285);
            this.chkGerenciamentoTrabalho.Name = "chkGerenciamentoTrabalho";
            this.chkGerenciamentoTrabalho.Size = new System.Drawing.Size(158, 17);
            this.chkGerenciamentoTrabalho.TabIndex = 10;
            this.chkGerenciamentoTrabalho.Text = "Gerenciamento de Trabalho";
            this.chkGerenciamentoTrabalho.UseVisualStyleBackColor = true;
            // 
            // chkHorarioTrabalho
            // 
            this.chkHorarioTrabalho.AutoSize = true;
            this.chkHorarioTrabalho.Location = new System.Drawing.Point(47, 308);
            this.chkHorarioTrabalho.Name = "chkHorarioTrabalho";
            this.chkHorarioTrabalho.Size = new System.Drawing.Size(116, 17);
            this.chkHorarioTrabalho.TabIndex = 11;
            this.chkHorarioTrabalho.Text = "Horário de trabalho";
            this.chkHorarioTrabalho.UseVisualStyleBackColor = true;
            // 
            // frmGrupoRoteiroLinhas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(540, 355);
            this.Controls.Add(this.chkHorarioTrabalho);
            this.Controls.Add(this.chkGerenciamentoTrabalho);
            this.Controls.Add(this.chkCapacidade);
            this.Controls.Add(this.chkAtivacao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.ribbon1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGrupoRoteiroLinhas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendário linhas";
            this.Load += new System.EventHandler(this.frmConfGrupoImpostoRetidoCad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAtivacao;
        private System.Windows.Forms.CheckBox chkCapacidade;
        private System.Windows.Forms.CheckBox chkGerenciamentoTrabalho;
        private System.Windows.Forms.CheckBox chkHorarioTrabalho;
    }
}