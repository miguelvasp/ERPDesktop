namespace ERP
{
    partial class frmUsuarioPermissao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioPermissao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.rbbPnlInfo = new System.Windows.Forms.RibbonPanel();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.lblPerfil = new System.Windows.Forms.Label();
            this.txtPerfil = new System.Windows.Forms.TextBox();
            this.IdUsuarioAcesso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.IdPermissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPerfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoPerfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPrograma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoPrograma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visual = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Incluir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Alterar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Excluir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(12, 150);
            this.txtUsuario.MaxLength = 200;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(442, 20);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.Tag = "";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(9, 134);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Usuário";
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
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbVisible = false;
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(570, 125);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // rbOpcoes
            // 
            this.rbOpcoes.Panels.Add(this.rbbPnlInfo);
            this.rbOpcoes.Text = "Documento";
            // 
            // rbbPnlInfo
            // 
            this.rbbPnlInfo.Items.Add(this.btnGrava);
            this.rbbPnlInfo.Items.Add(this.btnCancelar);
            this.rbbPnlInfo.Text = "Informações";
            // 
            // btnGrava
            // 
            this.btnGrava.Image = ((System.Drawing.Image)(resources.GetObject("btnGrava.Image")));
            this.btnGrava.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGrava.SmallImage")));
            this.btnGrava.Text = "Gravar";
            this.btnGrava.Click += new System.EventHandler(this.btnGrava_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.SmallImage")));
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Location = new System.Drawing.Point(9, 182);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(30, 13);
            this.lblPerfil.TabIndex = 5;
            this.lblPerfil.Text = "Perfil";
            // 
            // txtPerfil
            // 
            this.txtPerfil.Enabled = false;
            this.txtPerfil.Location = new System.Drawing.Point(12, 198);
            this.txtPerfil.MaxLength = 200;
            this.txtPerfil.Name = "txtPerfil";
            this.txtPerfil.Size = new System.Drawing.Size(442, 20);
            this.txtPerfil.TabIndex = 2;
            this.txtPerfil.Tag = "";
            // 
            // IdUsuarioAcesso
            // 
            this.IdUsuarioAcesso.DataPropertyName = "IdUsuarioAcesso";
            this.IdUsuarioAcesso.HeaderText = "IdUsuarioAcesso";
            this.IdUsuarioAcesso.Name = "IdUsuarioAcesso";
            this.IdUsuarioAcesso.Visible = false;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPermissao,
            this.Column2,
            this.NomeUsuario,
            this.IdPerfil,
            this.DescricaoPerfil,
            this.IdPrograma,
            this.DescricaoPrograma,
            this.Visual,
            this.Incluir,
            this.Alterar,
            this.Excluir});
            this.dgv.Location = new System.Drawing.Point(12, 231);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 18;
            this.dgv.Size = new System.Drawing.Size(556, 315);
            this.dgv.TabIndex = 3;
            // 
            // IdPermissao
            // 
            this.IdPermissao.DataPropertyName = "IdPermissao";
            this.IdPermissao.HeaderText = "IdPermissao";
            this.IdPermissao.Name = "IdPermissao";
            this.IdPermissao.ReadOnly = true;
            this.IdPermissao.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "IdUsuario";
            this.Column2.HeaderText = "IdUsuario";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            this.Column2.Width = 250;
            // 
            // NomeUsuario
            // 
            this.NomeUsuario.DataPropertyName = "NomeUsuario";
            this.NomeUsuario.HeaderText = "NomeUsuario";
            this.NomeUsuario.Name = "NomeUsuario";
            this.NomeUsuario.ReadOnly = true;
            this.NomeUsuario.Visible = false;
            // 
            // IdPerfil
            // 
            this.IdPerfil.DataPropertyName = "IdPerfil";
            this.IdPerfil.HeaderText = "IdPerfil";
            this.IdPerfil.Name = "IdPerfil";
            this.IdPerfil.ReadOnly = true;
            this.IdPerfil.Visible = false;
            this.IdPerfil.Width = 150;
            // 
            // DescricaoPerfil
            // 
            this.DescricaoPerfil.DataPropertyName = "DescricaoPerfil";
            this.DescricaoPerfil.HeaderText = "DescricaoPerfil";
            this.DescricaoPerfil.Name = "DescricaoPerfil";
            this.DescricaoPerfil.ReadOnly = true;
            this.DescricaoPerfil.Visible = false;
            // 
            // IdPrograma
            // 
            this.IdPrograma.DataPropertyName = "IdPrograma";
            this.IdPrograma.HeaderText = "IdPrograma";
            this.IdPrograma.Name = "IdPrograma";
            this.IdPrograma.ReadOnly = true;
            this.IdPrograma.Visible = false;
            // 
            // DescricaoPrograma
            // 
            this.DescricaoPrograma.DataPropertyName = "DescricaoPrograma";
            this.DescricaoPrograma.HeaderText = "Programa";
            this.DescricaoPrograma.Name = "DescricaoPrograma";
            this.DescricaoPrograma.ReadOnly = true;
            this.DescricaoPrograma.Width = 200;
            // 
            // Visual
            // 
            this.Visual.DataPropertyName = "Visual";
            this.Visual.HeaderText = "Visual";
            this.Visual.Name = "Visual";
            this.Visual.ReadOnly = true;
            this.Visual.Width = 75;
            // 
            // Incluir
            // 
            this.Incluir.DataPropertyName = "Incluir";
            this.Incluir.HeaderText = "Incluir";
            this.Incluir.Name = "Incluir";
            this.Incluir.ReadOnly = true;
            this.Incluir.Width = 75;
            // 
            // Alterar
            // 
            this.Alterar.DataPropertyName = "Incluir";
            this.Alterar.HeaderText = "Alterar";
            this.Alterar.Name = "Alterar";
            this.Alterar.ReadOnly = true;
            this.Alterar.Width = 75;
            // 
            // Excluir
            // 
            this.Excluir.DataPropertyName = "Incluir";
            this.Excluir.HeaderText = "Excluir";
            this.Excluir.Name = "Excluir";
            this.Excluir.ReadOnly = true;
            this.Excluir.Width = 75;
            // 
            // frmUsuarioPermissao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(570, 544);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.txtPerfil);
            this.Controls.Add(this.lblPerfil);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsuarioPermissao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permissões";
            this.Load += new System.EventHandler(this.frmUsuarioPermissao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.RibbonPanel rbbPnlInfo;
        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.TextBox txtPerfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUsuarioAcesso;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPermissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPerfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoPerfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPrograma;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoPrograma;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Visual;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Incluir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Alterar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Excluir;
    }
}