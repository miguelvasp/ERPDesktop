namespace ERP
{
    partial class frmPedidoVendaAlocaEncargos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkRecebidoSeparado = new System.Windows.Forms.CheckBox();
            this.chkDistribuirTudo = new System.Windows.Forms.CheckBox();
            this.cboLinhas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDistribuirPor = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.chkRecebidoSeparado);
            this.panel1.Controls.Add(this.chkDistribuirTudo);
            this.panel1.Controls.Add(this.cboLinhas);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboDistribuirPor);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 125);
            this.panel1.TabIndex = 0;
            // 
            // chkRecebidoSeparado
            // 
            this.chkRecebidoSeparado.AutoSize = true;
            this.chkRecebidoSeparado.Location = new System.Drawing.Point(238, 95);
            this.chkRecebidoSeparado.Name = "chkRecebidoSeparado";
            this.chkRecebidoSeparado.Size = new System.Drawing.Size(72, 17);
            this.chkRecebidoSeparado.TabIndex = 32;
            this.chkRecebidoSeparado.Text = "Separado";
            this.chkRecebidoSeparado.UseVisualStyleBackColor = true;
            // 
            // chkDistribuirTudo
            // 
            this.chkDistribuirTudo.AutoSize = true;
            this.chkDistribuirTudo.Checked = true;
            this.chkDistribuirTudo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDistribuirTudo.Location = new System.Drawing.Point(15, 95);
            this.chkDistribuirTudo.Name = "chkDistribuirTudo";
            this.chkDistribuirTudo.Size = new System.Drawing.Size(94, 17);
            this.chkDistribuirTudo.TabIndex = 31;
            this.chkDistribuirTudo.Text = "Distribuir Tudo";
            this.chkDistribuirTudo.UseVisualStyleBackColor = true;
            // 
            // cboLinhas
            // 
            this.cboLinhas.FormattingEnabled = true;
            this.cboLinhas.Location = new System.Drawing.Point(238, 59);
            this.cboLinhas.Name = "cboLinhas";
            this.cboLinhas.Size = new System.Drawing.Size(206, 21);
            this.cboLinhas.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Alocar Encargos aos itens";
            // 
            // cboDistribuirPor
            // 
            this.cboDistribuirPor.FormattingEnabled = true;
            this.cboDistribuirPor.Location = new System.Drawing.Point(15, 59);
            this.cboDistribuirPor.Name = "cboDistribuirPor";
            this.cboDistribuirPor.Size = new System.Drawing.Size(206, 21);
            this.cboDistribuirPor.TabIndex = 28;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImage = global::ERP.Properties.Resources.fundo;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(459, 37);
            this.toolStrip1.TabIndex = 27;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(125, 34);
            this.toolStripLabel1.Text = "Alocar Encargos ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Alocação de Encargos";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Column1,
            this.Column2});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 125);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 18;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv.Size = new System.Drawing.Size(459, 255);
            this.dgv.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::ERP.Properties.Resources.fundo1;
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.btnSelecionar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 344);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(459, 36);
            this.panel2.TabIndex = 21;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(325, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(119, 28);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Location = new System.Drawing.Point(200, 3);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(119, 28);
            this.btnSelecionar.TabIndex = 0;
            this.btnSelecionar.Text = "Confirmar";
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "IdPedidoVendaEncargos";
            this.Id.HeaderText = "Column1";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Descricao";
            this.Column1.HeaderText = "Tipo Encargo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Valor";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "Valor";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // frmPedidoVendaAlocaEncargos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(459, 380);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPedidoVendaAlocaEncargos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmBuscaProduto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBuscaProduto_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.CheckBox chkRecebidoSeparado;
        private System.Windows.Forms.CheckBox chkDistribuirTudo;
        private System.Windows.Forms.ComboBox cboLinhas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDistribuirPor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}