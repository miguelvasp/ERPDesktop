namespace ERP 
{
    partial class frmRoteiroOperacaoRecursos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoteiroOperacaoRecursos));
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboRecurso = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCapacidadeRecurso = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboGrupoRecurso = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboRecursoAvaliacao = new System.Windows.Forms.ComboBox();
            this.chkPlanejamentoTrabalho = new System.Windows.Forms.CheckBox();
            this.chkPlanejamentoOperacao = new System.Windows.Forms.CheckBox();
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
            this.ribbon1.Size = new System.Drawing.Size(770, 145);
            this.ribbon1.TabIndex = 5;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(12, 177);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(232, 21);
            this.cboTipo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Recurso";
            // 
            // cboRecurso
            // 
            this.cboRecurso.FormattingEnabled = true;
            this.cboRecurso.Location = new System.Drawing.Point(250, 177);
            this.cboRecurso.Name = "cboRecurso";
            this.cboRecurso.Size = new System.Drawing.Size(232, 21);
            this.cboRecurso.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Capacidade de Recursos";
            // 
            // cboCapacidadeRecurso
            // 
            this.cboCapacidadeRecurso.FormattingEnabled = true;
            this.cboCapacidadeRecurso.Location = new System.Drawing.Point(488, 177);
            this.cboCapacidadeRecurso.Name = "cboCapacidadeRecurso";
            this.cboCapacidadeRecurso.Size = new System.Drawing.Size(271, 21);
            this.cboCapacidadeRecurso.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Grupo de Recursos";
            // 
            // cboGrupoRecurso
            // 
            this.cboGrupoRecurso.FormattingEnabled = true;
            this.cboGrupoRecurso.Location = new System.Drawing.Point(12, 235);
            this.cboGrupoRecurso.Name = "cboGrupoRecurso";
            this.cboGrupoRecurso.Size = new System.Drawing.Size(232, 21);
            this.cboGrupoRecurso.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Recurso de avaliação de curto";
            // 
            // cboRecursoAvaliacao
            // 
            this.cboRecursoAvaliacao.FormattingEnabled = true;
            this.cboRecursoAvaliacao.Location = new System.Drawing.Point(250, 235);
            this.cboRecursoAvaliacao.Name = "cboRecursoAvaliacao";
            this.cboRecursoAvaliacao.Size = new System.Drawing.Size(232, 21);
            this.cboRecursoAvaliacao.TabIndex = 14;
            // 
            // chkPlanejamentoTrabalho
            // 
            this.chkPlanejamentoTrabalho.AutoSize = true;
            this.chkPlanejamentoTrabalho.Location = new System.Drawing.Point(12, 279);
            this.chkPlanejamentoTrabalho.Name = "chkPlanejamentoTrabalho";
            this.chkPlanejamentoTrabalho.Size = new System.Drawing.Size(150, 17);
            this.chkPlanejamentoTrabalho.TabIndex = 16;
            this.chkPlanejamentoTrabalho.Text = "Planejamento de Trabalho";
            this.chkPlanejamentoTrabalho.UseVisualStyleBackColor = true;
            // 
            // chkPlanejamentoOperacao
            // 
            this.chkPlanejamentoOperacao.AutoSize = true;
            this.chkPlanejamentoOperacao.Location = new System.Drawing.Point(12, 302);
            this.chkPlanejamentoOperacao.Name = "chkPlanejamentoOperacao";
            this.chkPlanejamentoOperacao.Size = new System.Drawing.Size(155, 17);
            this.chkPlanejamentoOperacao.TabIndex = 17;
            this.chkPlanejamentoOperacao.Text = "Planejamento de Operação";
            this.chkPlanejamentoOperacao.UseVisualStyleBackColor = true;
            // 
            // frmRoteiroOperacaoRecursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(770, 346);
            this.Controls.Add(this.chkPlanejamentoOperacao);
            this.Controls.Add(this.chkPlanejamentoTrabalho);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboRecursoAvaliacao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboGrupoRecurso);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCapacidadeRecurso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboRecurso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.ribbon1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRoteiroOperacaoRecursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roteiro Operação Recursos";
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRecurso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCapacidadeRecurso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboGrupoRecurso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboRecursoAvaliacao;
        private System.Windows.Forms.CheckBox chkPlanejamentoTrabalho;
        private System.Windows.Forms.CheckBox chkPlanejamentoOperacao;
    }
}