namespace ERP.Forms.ReportsTool
{
    partial class frmAddReport
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOrigem = new System.Windows.Forms.TabPage();
            this.tabAgrupamento = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboOrigem = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.dgvFields = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabFiltros = new System.Windows.Forms.TabPage();
            this.tabModelo = new System.Windows.Forms.TabPage();
            this.lstCampos2 = new System.Windows.Forms.ListBox();
            this.lstAgrupamento = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lstFiltros = new System.Windows.Forms.ListBox();
            this.lstCampos3 = new System.Windows.Forms.ListBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lstCampos = new System.Windows.Forms.ListBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabOrigem.SuspendLayout();
            this.tabAgrupamento.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).BeginInit();
            this.tabFiltros.SuspendLayout();
            this.tabModelo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabModelo);
            this.tabControl1.Controls.Add(this.tabOrigem);
            this.tabControl1.Controls.Add(this.tabAgrupamento);
            this.tabControl1.Controls.Add(this.tabFiltros);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1061, 641);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabOrigem
            // 
            this.tabOrigem.Controls.Add(this.lstCampos);
            this.tabOrigem.Controls.Add(this.label3);
            this.tabOrigem.Controls.Add(this.label2);
            this.tabOrigem.Controls.Add(this.dgvFields);
            this.tabOrigem.Controls.Add(this.button5);
            this.tabOrigem.Controls.Add(this.cboOrigem);
            this.tabOrigem.Controls.Add(this.label1);
            this.tabOrigem.Controls.Add(this.button9);
            this.tabOrigem.Controls.Add(this.button8);
            this.tabOrigem.Controls.Add(this.button7);
            this.tabOrigem.Controls.Add(this.button6);
            this.tabOrigem.Location = new System.Drawing.Point(4, 22);
            this.tabOrigem.Name = "tabOrigem";
            this.tabOrigem.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrigem.Size = new System.Drawing.Size(1053, 615);
            this.tabOrigem.TabIndex = 0;
            this.tabOrigem.Text = "Origem do Dados";
            this.tabOrigem.UseVisualStyleBackColor = true;
            // 
            // tabAgrupamento
            // 
            this.tabAgrupamento.Controls.Add(this.label5);
            this.tabAgrupamento.Controls.Add(this.label4);
            this.tabAgrupamento.Controls.Add(this.lstAgrupamento);
            this.tabAgrupamento.Controls.Add(this.button2);
            this.tabAgrupamento.Controls.Add(this.button4);
            this.tabAgrupamento.Controls.Add(this.lstCampos2);
            this.tabAgrupamento.Location = new System.Drawing.Point(4, 22);
            this.tabAgrupamento.Name = "tabAgrupamento";
            this.tabAgrupamento.Padding = new System.Windows.Forms.Padding(3);
            this.tabAgrupamento.Size = new System.Drawing.Size(1053, 615);
            this.tabAgrupamento.TabIndex = 1;
            this.tabAgrupamento.Text = "Agrupamento dos dados";
            this.tabAgrupamento.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAnterior);
            this.panel1.Controls.Add(this.btnProximo);
            this.panel1.Controls.Add(this.btnFinalizar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 607);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1061, 34);
            this.panel1.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(977, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(896, 6);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 1;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnProximo
            // 
            this.btnProximo.Location = new System.Drawing.Point(815, 6);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(75, 23);
            this.btnProximo.TabIndex = 2;
            this.btnProximo.Text = "Proximo";
            this.btnProximo.UseVisualStyleBackColor = true;
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(734, 6);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 23);
            this.btnAnterior.TabIndex = 3;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecione a origem dos dados";
            // 
            // cboOrigem
            // 
            this.cboOrigem.FormattingEnabled = true;
            this.cboOrigem.Location = new System.Drawing.Point(21, 30);
            this.cboOrigem.Name = "cboOrigem";
            this.cboOrigem.Size = new System.Drawing.Size(462, 21);
            this.cboOrigem.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(489, 29);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "Carregar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dgvFields
            // 
            this.dgvFields.AllowUserToAddRows = false;
            this.dgvFields.AllowUserToDeleteRows = false;
            this.dgvFields.AllowUserToResizeColumns = false;
            this.dgvFields.AllowUserToResizeRows = false;
            this.dgvFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvFields.Location = new System.Drawing.Point(21, 73);
            this.dgvFields.MultiSelect = false;
            this.dgvFields.Name = "dgvFields";
            this.dgvFields.ReadOnly = true;
            this.dgvFields.RowHeadersVisible = false;
            this.dgvFields.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFields.Size = new System.Drawing.Size(543, 492);
            this.dgvFields.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Campos Disponíveis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(637, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Campos Selecionados";
            // 
            // tabFiltros
            // 
            this.tabFiltros.Controls.Add(this.label6);
            this.tabFiltros.Controls.Add(this.label7);
            this.tabFiltros.Controls.Add(this.lstFiltros);
            this.tabFiltros.Controls.Add(this.button11);
            this.tabFiltros.Controls.Add(this.button13);
            this.tabFiltros.Controls.Add(this.lstCampos3);
            this.tabFiltros.Location = new System.Drawing.Point(4, 22);
            this.tabFiltros.Name = "tabFiltros";
            this.tabFiltros.Padding = new System.Windows.Forms.Padding(3);
            this.tabFiltros.Size = new System.Drawing.Size(1053, 615);
            this.tabFiltros.TabIndex = 2;
            this.tabFiltros.Text = "Filtros do Relatório";
            this.tabFiltros.UseVisualStyleBackColor = true;
            // 
            // tabModelo
            // 
            this.tabModelo.Controls.Add(this.label8);
            this.tabModelo.Controls.Add(this.txtNome);
            this.tabModelo.Location = new System.Drawing.Point(4, 22);
            this.tabModelo.Name = "tabModelo";
            this.tabModelo.Padding = new System.Windows.Forms.Padding(3);
            this.tabModelo.Size = new System.Drawing.Size(1053, 615);
            this.tabModelo.TabIndex = 3;
            this.tabModelo.Text = "Modelo";
            this.tabModelo.UseVisualStyleBackColor = true;
            // 
            // lstCampos2
            // 
            this.lstCampos2.FormattingEnabled = true;
            this.lstCampos2.Location = new System.Drawing.Point(27, 27);
            this.lstCampos2.Name = "lstCampos2";
            this.lstCampos2.Size = new System.Drawing.Size(581, 537);
            this.lstCampos2.TabIndex = 0;
            // 
            // lstAgrupamento
            // 
            this.lstAgrupamento.FormattingEnabled = true;
            this.lstAgrupamento.Location = new System.Drawing.Point(685, 27);
            this.lstAgrupamento.Name = "lstAgrupamento";
            this.lstAgrupamento.Size = new System.Drawing.Size(338, 342);
            this.lstAgrupamento.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Campos do Relatório";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(682, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Campos de agrupamento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(674, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Filtros";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Campos do Relatório";
            // 
            // lstFiltros
            // 
            this.lstFiltros.FormattingEnabled = true;
            this.lstFiltros.Location = new System.Drawing.Point(677, 28);
            this.lstFiltros.Name = "lstFiltros";
            this.lstFiltros.Size = new System.Drawing.Size(338, 342);
            this.lstFiltros.TabIndex = 23;
            // 
            // lstCampos3
            // 
            this.lstCampos3.FormattingEnabled = true;
            this.lstCampos3.Location = new System.Drawing.Point(19, 28);
            this.lstCampos3.Name = "lstCampos3";
            this.lstCampos3.Size = new System.Drawing.Size(581, 537);
            this.lstCampos3.TabIndex = 18;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(31, 36);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(441, 20);
            this.txtNome.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Nome do Relatório";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IdReportCuboFields";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Titulo";
            this.Column2.FillWeight = 300F;
            this.Column2.HeaderText = "Título";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 250;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TipoCampo";
            this.Column3.FillWeight = 150F;
            this.Column3.HeaderText = "Tipo de dados";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // lstCampos
            // 
            this.lstCampos.FormattingEnabled = true;
            this.lstCampos.Location = new System.Drawing.Point(640, 73);
            this.lstCampos.Name = "lstCampos";
            this.lstCampos.Size = new System.Drawing.Size(390, 485);
            this.lstCampos.TabIndex = 11;
            // 
            // button9
            // 
            this.button9.Image = global::ERP.Properties.Resources.Actions_arrow_left_double_icon;
            this.button9.Location = new System.Drawing.Point(581, 328);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(47, 39);
            this.button9.TabIndex = 10;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Image = global::ERP.Properties.Resources.Actions_arrow_left_icon;
            this.button8.Location = new System.Drawing.Point(581, 283);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(47, 39);
            this.button8.TabIndex = 9;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Image = global::ERP.Properties.Resources.Actions_arrow_right_double_icon;
            this.button7.Location = new System.Drawing.Point(581, 216);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 39);
            this.button7.TabIndex = 8;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Image = global::ERP.Properties.Resources.Actions_arrow_right_icon;
            this.button6.Location = new System.Drawing.Point(581, 171);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 39);
            this.button6.TabIndex = 7;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button2
            // 
            this.button2.Image = global::ERP.Properties.Resources.Actions_arrow_left_icon;
            this.button2.Location = new System.Drawing.Point(623, 238);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 39);
            this.button2.TabIndex = 13;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Image = global::ERP.Properties.Resources.Actions_arrow_right_icon;
            this.button4.Location = new System.Drawing.Point(623, 126);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 39);
            this.button4.TabIndex = 11;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button11
            // 
            this.button11.Image = global::ERP.Properties.Resources.Actions_arrow_left_icon;
            this.button11.Location = new System.Drawing.Point(615, 239);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(47, 39);
            this.button11.TabIndex = 21;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button13
            // 
            this.button13.Image = global::ERP.Properties.Resources.Actions_arrow_right_icon;
            this.button13.Location = new System.Drawing.Point(615, 127);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(47, 39);
            this.button13.TabIndex = 19;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // frmAddReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 641);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAddReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Relatório";
            this.Load += new System.EventHandler(this.frmAddReport_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabOrigem.ResumeLayout(false);
            this.tabOrigem.PerformLayout();
            this.tabAgrupamento.ResumeLayout(false);
            this.tabAgrupamento.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).EndInit();
            this.tabFiltros.ResumeLayout(false);
            this.tabFiltros.PerformLayout();
            this.tabModelo.ResumeLayout(false);
            this.tabModelo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOrigem;
        private System.Windows.Forms.TabPage tabAgrupamento;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox cboOrigem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvFields;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TabPage tabFiltros;
        private System.Windows.Forms.TabPage tabModelo;
        private System.Windows.Forms.ListBox lstAgrupamento;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox lstCampos2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstFiltros;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.ListBox lstCampos3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ListBox lstCampos;
    }
}