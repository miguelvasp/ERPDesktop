namespace ERP.Aprovacao
{
    partial class frmAprovacaoDocumentos
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
            this.pnlNivel = new System.Windows.Forms.Panel();
            this.dgUsuarios = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAddUsuario = new System.Windows.Forms.Panel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cboUsuarios = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSequencia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNivel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.pnlDoc = new System.Windows.Forms.Panel();
            this.dgNiveis = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNovo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCarregar = new System.Windows.Forms.Button();
            this.cboDocs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.pnlNivel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsuarios)).BeginInit();
            this.pnlAddUsuario.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.pnlDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNiveis)).BeginInit();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNivel
            // 
            this.pnlNivel.Controls.Add(this.dgUsuarios);
            this.pnlNivel.Controls.Add(this.pnlAddUsuario);
            this.pnlNivel.Controls.Add(this.panel2);
            this.pnlNivel.Controls.Add(this.toolStrip2);
            this.pnlNivel.Location = new System.Drawing.Point(583, 46);
            this.pnlNivel.Name = "pnlNivel";
            this.pnlNivel.Size = new System.Drawing.Size(691, 371);
            this.pnlNivel.TabIndex = 2;
            this.pnlNivel.Visible = false;
            // 
            // dgUsuarios
            // 
            this.dgUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column4,
            this.Column5});
            this.dgUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUsuarios.Location = new System.Drawing.Point(0, 181);
            this.dgUsuarios.Name = "dgUsuarios";
            this.dgUsuarios.ReadOnly = true;
            this.dgUsuarios.RowHeadersVisible = false;
            this.dgUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUsuarios.Size = new System.Drawing.Size(691, 190);
            this.dgUsuarios.TabIndex = 3;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Nome";
            this.Column4.HeaderText = "Perfil";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 350;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "NomeCompleto";
            this.Column5.HeaderText = "Aprovador";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 350;
            // 
            // pnlAddUsuario
            // 
            this.pnlAddUsuario.Controls.Add(this.toolStrip3);
            this.pnlAddUsuario.Controls.Add(this.label4);
            this.pnlAddUsuario.Controls.Add(this.cboUsuarios);
            this.pnlAddUsuario.Controls.Add(this.button2);
            this.pnlAddUsuario.Controls.Add(this.button1);
            this.pnlAddUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAddUsuario.Location = new System.Drawing.Point(0, 91);
            this.pnlAddUsuario.Name = "pnlAddUsuario";
            this.pnlAddUsuario.Size = new System.Drawing.Size(691, 90);
            this.pnlAddUsuario.TabIndex = 2;
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackgroundImage = global::ERP.Properties.Resources.fundo;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator4,
            this.toolStripButton5});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(691, 25);
            this.toolStrip3.TabIndex = 83;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(149, 22);
            this.toolStripLabel1.Text = "   Cadastro de Aprovadores";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = global::ERP.Properties.Resources.delete16_h;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(133, 22);
            this.toolStripButton5.Text = "Remover Aprovador";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 82;
            this.label4.Text = "Usuário do Sistema";
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuarios.DropDownWidth = 700;
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Location = new System.Drawing.Point(19, 57);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(407, 21);
            this.cboUsuarios.TabIndex = 81;
            this.cboUsuarios.Tag = "1";
            // 
            // button2
            // 
            this.button2.Image = global::ERP.Properties.Resources.lupa;
            this.button2.Location = new System.Drawing.Point(424, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 23);
            this.button2.TabIndex = 80;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(462, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Adicionar Aprovador";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSequencia);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtNivel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(691, 66);
            this.panel2.TabIndex = 1;
            // 
            // txtSequencia
            // 
            this.txtSequencia.Location = new System.Drawing.Point(432, 30);
            this.txtSequencia.Name = "txtSequencia";
            this.txtSequencia.Size = new System.Drawing.Size(90, 20);
            this.txtSequencia.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(429, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sequência";
            // 
            // txtNivel
            // 
            this.txtNivel.Location = new System.Drawing.Point(19, 30);
            this.txtNivel.Name = "txtNivel";
            this.txtNivel.Size = new System.Drawing.Size(407, 20);
            this.txtNivel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nível de Aprovação";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackgroundImage = global::ERP.Properties.Resources.fundo;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripButton3});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(691, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::ERP.Properties.Resources.save1;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(61, 22);
            this.toolStripButton1.Text = "Gravar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::ERP.Properties.Resources.delete16_h;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(65, 22);
            this.toolStripButton2.Text = "Apagar";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::ERP.Properties.Resources.Go_back_icon;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(57, 22);
            this.toolStripButton3.Text = "Voltar";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // pnlDoc
            // 
            this.pnlDoc.Controls.Add(this.dgNiveis);
            this.pnlDoc.Controls.Add(this.panel3);
            this.pnlDoc.Controls.Add(this.panel1);
            this.pnlDoc.Location = new System.Drawing.Point(12, 12);
            this.pnlDoc.Name = "pnlDoc";
            this.pnlDoc.Size = new System.Drawing.Size(554, 431);
            this.pnlDoc.TabIndex = 3;
            // 
            // dgNiveis
            // 
            this.dgNiveis.BackgroundColor = System.Drawing.Color.White;
            this.dgNiveis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNiveis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column1,
            this.Column8,
            this.Column9});
            this.dgNiveis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgNiveis.GridColor = System.Drawing.Color.White;
            this.dgNiveis.Location = new System.Drawing.Point(0, 93);
            this.dgNiveis.Name = "dgNiveis";
            this.dgNiveis.ReadOnly = true;
            this.dgNiveis.RowHeadersVisible = false;
            this.dgNiveis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgNiveis.Size = new System.Drawing.Size(554, 338);
            this.dgNiveis.TabIndex = 6;
            this.dgNiveis.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgNiveis_CellDoubleClick);
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "IdAprovacaoNivel";
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IdAprovacaoDocumento";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Nome";
            this.Column8.HeaderText = "Niveis de Aprovação";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 500;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Sequencia";
            this.Column9.HeaderText = "Sequência";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(554, 32);
            this.panel3.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::ERP.Properties.Resources.fundo;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNovo,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(554, 31);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNovo
            // 
            this.btnNovo.Image = global::ERP.Properties.Resources.Data_Flow_Chart_icon;
            this.btnNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(170, 28);
            this.btnNovo.Text = "Novo Nivel de Aprovação";
            this.btnNovo.ToolTipText = "Novo registro";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnCarregar);
            this.panel1.Controls.Add(this.cboDocs);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 61);
            this.panel1.TabIndex = 2;
            // 
            // btnCarregar
            // 
            this.btnCarregar.Location = new System.Drawing.Point(454, 24);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(93, 23);
            this.btnCarregar.TabIndex = 4;
            this.btnCarregar.Text = "Carregar ";
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // cboDocs
            // 
            this.cboDocs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocs.FormattingEnabled = true;
            this.cboDocs.Location = new System.Drawing.Point(19, 25);
            this.cboDocs.Name = "cboDocs";
            this.cboDocs.Size = new System.Drawing.Size(429, 21);
            this.cboDocs.TabIndex = 3;
            this.cboDocs.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Documento";
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackgroundImage = global::ERP.Properties.Resources.fundo;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(138, 6);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(722, 31);
            this.miniToolStrip.TabIndex = 2;
            // 
            // frmAprovacaoDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1149, 490);
            this.Controls.Add(this.pnlNivel);
            this.Controls.Add(this.pnlDoc);
            this.Name = "frmAprovacaoDocumentos";
            this.Text = "Aprovação de Documentos";
            this.Load += new System.EventHandler(this.frmAprovacaoDocumentos_Load);
            this.pnlNivel.ResumeLayout(false);
            this.pnlNivel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsuarios)).EndInit();
            this.pnlAddUsuario.ResumeLayout(false);
            this.pnlAddUsuario.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.pnlDoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgNiveis)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNivel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TextBox txtSequencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNivel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlAddUsuario;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cboUsuarios;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgUsuarios;
        private System.Windows.Forms.Panel pnlDoc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.ComboBox cboDocs;
        private System.Windows.Forms.Button btnCarregar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridView dgNiveis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNovo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}