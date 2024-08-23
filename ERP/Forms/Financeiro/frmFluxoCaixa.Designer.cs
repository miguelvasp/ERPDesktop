namespace ERP.Financeiro
{
    partial class frmFluxoCaixa
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb12Meses = new System.Windows.Forms.RadioButton();
            this.rb6Meses = new System.Windows.Forms.RadioButton();
            this.rb30Dias = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPrevisto = new System.Windows.Forms.RadioButton();
            this.rbRealizado = new System.Windows.Forms.RadioButton();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtSaldo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1193, 74);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(894, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Exportar Excel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(797, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Pesquisar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb12Meses);
            this.groupBox2.Controls.Add(this.rb6Meses);
            this.groupBox2.Controls.Add(this.rb30Dias);
            this.groupBox2.Location = new System.Drawing.Point(493, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 53);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Período";
            // 
            // rb12Meses
            // 
            this.rb12Meses.AutoSize = true;
            this.rb12Meses.Location = new System.Drawing.Point(178, 26);
            this.rb12Meses.Name = "rb12Meses";
            this.rb12Meses.Size = new System.Drawing.Size(71, 17);
            this.rb12Meses.TabIndex = 2;
            this.rb12Meses.Tag = "12";
            this.rb12Meses.Text = "12 Meses";
            this.rb12Meses.UseVisualStyleBackColor = true;
            // 
            // rb6Meses
            // 
            this.rb6Meses.AutoSize = true;
            this.rb6Meses.Location = new System.Drawing.Point(98, 26);
            this.rb6Meses.Name = "rb6Meses";
            this.rb6Meses.Size = new System.Drawing.Size(65, 17);
            this.rb6Meses.TabIndex = 1;
            this.rb6Meses.Tag = "6";
            this.rb6Meses.Text = "6 Meses";
            this.rb6Meses.UseVisualStyleBackColor = true;
            // 
            // rb30Dias
            // 
            this.rb30Dias.AutoSize = true;
            this.rb30Dias.Checked = true;
            this.rb30Dias.Location = new System.Drawing.Point(17, 26);
            this.rb30Dias.Name = "rb30Dias";
            this.rb30Dias.Size = new System.Drawing.Size(59, 17);
            this.rb30Dias.TabIndex = 0;
            this.rb30Dias.TabStop = true;
            this.rb30Dias.Text = "30 dias";
            this.rb30Dias.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbPrevisto);
            this.groupBox1.Controls.Add(this.rbRealizado);
            this.groupBox1.Location = new System.Drawing.Point(164, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 53);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Fluxo";
            // 
            // rbPrevisto
            // 
            this.rbPrevisto.AutoSize = true;
            this.rbPrevisto.Checked = true;
            this.rbPrevisto.Location = new System.Drawing.Point(11, 26);
            this.rbPrevisto.Name = "rbPrevisto";
            this.rbPrevisto.Size = new System.Drawing.Size(135, 17);
            this.rbPrevisto.TabIndex = 2;
            this.rbPrevisto.TabStop = true;
            this.rbPrevisto.Text = "Fluxo de Caixa Previsto";
            this.rbPrevisto.UseVisualStyleBackColor = true;
            // 
            // rbRealizado
            // 
            this.rbRealizado.AutoSize = true;
            this.rbRealizado.Location = new System.Drawing.Point(152, 26);
            this.rbRealizado.Name = "rbRealizado";
            this.rbRealizado.Size = new System.Drawing.Size(144, 17);
            this.rbRealizado.TabIndex = 3;
            this.rbRealizado.Text = "Fluxo de Caixa Realizado";
            this.rbRealizado.UseVisualStyleBackColor = true;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(26, 31);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(123, 20);
            this.txtSaldo.TabIndex = 1;
            this.txtSaldo.Text = "0,00";
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo Inicial";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Conta,
            this.Tipo,
            this.Data1,
            this.Data2,
            this.Data3,
            this.Data4,
            this.Data5,
            this.Data6,
            this.Data7,
            this.Data8,
            this.Data9,
            this.Data10,
            this.Data11,
            this.Data12,
            this.Data13,
            this.Data14,
            this.Data15,
            this.Data16,
            this.Data17,
            this.Data18,
            this.Data19,
            this.Data20,
            this.Data21,
            this.Data22,
            this.Data23,
            this.Data24,
            this.Data25,
            this.Data26,
            this.Data27,
            this.Data28,
            this.Data29,
            this.Data30});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Size = new System.Drawing.Size(1193, 614);
            this.dataGridView1.TabIndex = 3;
            // 
            // Conta
            // 
            this.Conta.DataPropertyName = "Conta";
            this.Conta.HeaderText = "Conta Contábil";
            this.Conta.Name = "Conta";
            this.Conta.ReadOnly = true;
            this.Conta.Width = 250;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Data1
            // 
            this.Data1.DataPropertyName = "Valor1";
            this.Data1.HeaderText = "Column1";
            this.Data1.Name = "Data1";
            this.Data1.ReadOnly = true;
            this.Data1.Width = 75;
            // 
            // Data2
            // 
            this.Data2.DataPropertyName = "Valor2";
            this.Data2.HeaderText = "Column1";
            this.Data2.Name = "Data2";
            this.Data2.ReadOnly = true;
            this.Data2.Width = 75;
            // 
            // Data3
            // 
            this.Data3.DataPropertyName = "Valor3";
            this.Data3.HeaderText = "Column1";
            this.Data3.Name = "Data3";
            this.Data3.ReadOnly = true;
            this.Data3.Width = 75;
            // 
            // Data4
            // 
            this.Data4.DataPropertyName = "Valor4";
            this.Data4.HeaderText = "Column1";
            this.Data4.Name = "Data4";
            this.Data4.ReadOnly = true;
            this.Data4.Width = 75;
            // 
            // Data5
            // 
            this.Data5.DataPropertyName = "Valor5";
            this.Data5.HeaderText = "Column1";
            this.Data5.Name = "Data5";
            this.Data5.ReadOnly = true;
            this.Data5.Width = 75;
            // 
            // Data6
            // 
            this.Data6.DataPropertyName = "Valor6";
            this.Data6.HeaderText = "Column1";
            this.Data6.Name = "Data6";
            this.Data6.ReadOnly = true;
            this.Data6.Width = 75;
            // 
            // Data7
            // 
            this.Data7.DataPropertyName = "Valor7";
            this.Data7.HeaderText = "Column1";
            this.Data7.Name = "Data7";
            this.Data7.ReadOnly = true;
            this.Data7.Width = 75;
            // 
            // Data8
            // 
            this.Data8.DataPropertyName = "Valor8";
            this.Data8.HeaderText = "Column1";
            this.Data8.Name = "Data8";
            this.Data8.ReadOnly = true;
            this.Data8.Width = 75;
            // 
            // Data9
            // 
            this.Data9.DataPropertyName = "Valor9";
            this.Data9.HeaderText = "Column1";
            this.Data9.Name = "Data9";
            this.Data9.ReadOnly = true;
            this.Data9.Width = 75;
            // 
            // Data10
            // 
            this.Data10.DataPropertyName = "Valor10";
            this.Data10.HeaderText = "Column1";
            this.Data10.Name = "Data10";
            this.Data10.ReadOnly = true;
            this.Data10.Width = 75;
            // 
            // Data11
            // 
            this.Data11.DataPropertyName = "Valor11";
            this.Data11.HeaderText = "Column1";
            this.Data11.Name = "Data11";
            this.Data11.ReadOnly = true;
            this.Data11.Width = 75;
            // 
            // Data12
            // 
            this.Data12.DataPropertyName = "Valor12";
            this.Data12.HeaderText = "Column1";
            this.Data12.Name = "Data12";
            this.Data12.ReadOnly = true;
            this.Data12.Width = 75;
            // 
            // Data13
            // 
            this.Data13.DataPropertyName = "Valor13";
            this.Data13.HeaderText = "Column1";
            this.Data13.Name = "Data13";
            this.Data13.ReadOnly = true;
            this.Data13.Width = 75;
            // 
            // Data14
            // 
            this.Data14.DataPropertyName = "Valor14";
            this.Data14.HeaderText = "Data14";
            this.Data14.Name = "Data14";
            this.Data14.ReadOnly = true;
            this.Data14.Width = 75;
            // 
            // Data15
            // 
            this.Data15.DataPropertyName = "Valor15";
            this.Data15.HeaderText = "Column1";
            this.Data15.Name = "Data15";
            this.Data15.ReadOnly = true;
            this.Data15.Width = 75;
            // 
            // Data16
            // 
            this.Data16.DataPropertyName = "Valor16";
            this.Data16.HeaderText = "Column1";
            this.Data16.Name = "Data16";
            this.Data16.ReadOnly = true;
            this.Data16.Width = 75;
            // 
            // Data17
            // 
            this.Data17.DataPropertyName = "Valor17";
            this.Data17.HeaderText = "Column1";
            this.Data17.Name = "Data17";
            this.Data17.ReadOnly = true;
            this.Data17.Width = 75;
            // 
            // Data18
            // 
            this.Data18.DataPropertyName = "Valor18";
            this.Data18.HeaderText = "Column1";
            this.Data18.Name = "Data18";
            this.Data18.ReadOnly = true;
            this.Data18.Width = 75;
            // 
            // Data19
            // 
            this.Data19.DataPropertyName = "Valor19";
            this.Data19.HeaderText = "Column1";
            this.Data19.Name = "Data19";
            this.Data19.ReadOnly = true;
            this.Data19.Width = 75;
            // 
            // Data20
            // 
            this.Data20.DataPropertyName = "Valor20";
            this.Data20.HeaderText = "Column1";
            this.Data20.Name = "Data20";
            this.Data20.ReadOnly = true;
            this.Data20.Width = 75;
            // 
            // Data21
            // 
            this.Data21.DataPropertyName = "Valor21";
            this.Data21.HeaderText = "Column1";
            this.Data21.Name = "Data21";
            this.Data21.ReadOnly = true;
            this.Data21.Width = 75;
            // 
            // Data22
            // 
            this.Data22.DataPropertyName = "Valor22";
            this.Data22.HeaderText = "Column1";
            this.Data22.Name = "Data22";
            this.Data22.ReadOnly = true;
            this.Data22.Width = 75;
            // 
            // Data23
            // 
            this.Data23.DataPropertyName = "Valor23";
            this.Data23.HeaderText = "Column1";
            this.Data23.Name = "Data23";
            this.Data23.ReadOnly = true;
            this.Data23.Width = 75;
            // 
            // Data24
            // 
            this.Data24.DataPropertyName = "Valor24";
            this.Data24.HeaderText = "Column1";
            this.Data24.Name = "Data24";
            this.Data24.ReadOnly = true;
            this.Data24.Width = 75;
            // 
            // Data25
            // 
            this.Data25.DataPropertyName = "Valor25";
            this.Data25.HeaderText = "Column1";
            this.Data25.Name = "Data25";
            this.Data25.ReadOnly = true;
            this.Data25.Width = 75;
            // 
            // Data26
            // 
            this.Data26.DataPropertyName = "Valor26";
            this.Data26.HeaderText = "Column1";
            this.Data26.Name = "Data26";
            this.Data26.ReadOnly = true;
            this.Data26.Width = 75;
            // 
            // Data27
            // 
            this.Data27.DataPropertyName = "Valor27";
            this.Data27.HeaderText = "Column1";
            this.Data27.Name = "Data27";
            this.Data27.ReadOnly = true;
            this.Data27.Width = 75;
            // 
            // Data28
            // 
            this.Data28.DataPropertyName = "valor28";
            this.Data28.HeaderText = "Column1";
            this.Data28.Name = "Data28";
            this.Data28.ReadOnly = true;
            this.Data28.Width = 75;
            // 
            // Data29
            // 
            this.Data29.DataPropertyName = "Valor29";
            this.Data29.HeaderText = "Column1";
            this.Data29.Name = "Data29";
            this.Data29.ReadOnly = true;
            this.Data29.Width = 75;
            // 
            // Data30
            // 
            this.Data30.DataPropertyName = "Valor30";
            this.Data30.HeaderText = "Column1";
            this.Data30.Name = "Data30";
            this.Data30.ReadOnly = true;
            this.Data30.Width = 75;
            // 
            // frmFluxoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1193, 688);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "frmFluxoCaixa";
            this.Text = "Fluxo de Caixa";
            this.Load += new System.EventHandler(this.frmFluxoCaixa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb12Meses;
        private System.Windows.Forms.RadioButton rb6Meses;
        private System.Windows.Forms.RadioButton rb30Dias;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPrevisto;
        private System.Windows.Forms.RadioButton rbRealizado;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data27;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data28;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data29;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data30;
    }
}