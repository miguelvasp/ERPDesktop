namespace ERP.Forms.Financeiro
{
    partial class frmRelContasReceberFiltro
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSistemico = new System.Windows.Forms.RadioButton();
            this.rbAnalitico = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAte = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDe = new System.Windows.Forms.MaskedTextBox();
            this.rbVencimento = new System.Windows.Forms.RadioButton();
            this.rbEmissao = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboMetodo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSistemico);
            this.groupBox1.Controls.Add(this.rbAnalitico);
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Relatório";
            // 
            // rbSistemico
            // 
            this.rbSistemico.AutoSize = true;
            this.rbSistemico.Location = new System.Drawing.Point(143, 26);
            this.rbSistemico.Name = "rbSistemico";
            this.rbSistemico.Size = new System.Drawing.Size(70, 17);
            this.rbSistemico.TabIndex = 1;
            this.rbSistemico.TabStop = true;
            this.rbSistemico.Text = "Sistémico";
            this.rbSistemico.UseVisualStyleBackColor = true;
            // 
            // rbAnalitico
            // 
            this.rbAnalitico.AutoSize = true;
            this.rbAnalitico.Checked = true;
            this.rbAnalitico.Location = new System.Drawing.Point(34, 26);
            this.rbAnalitico.Name = "rbAnalitico";
            this.rbAnalitico.Size = new System.Drawing.Size(65, 17);
            this.rbAnalitico.TabIndex = 0;
            this.rbAnalitico.TabStop = true;
            this.rbAnalitico.Text = "Analitico";
            this.rbAnalitico.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtAte);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtDe);
            this.groupBox2.Controls.Add(this.rbVencimento);
            this.groupBox2.Controls.Add(this.rbEmissao);
            this.groupBox2.Location = new System.Drawing.Point(24, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 62);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar pela data de";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(439, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "até";
            // 
            // txtAte
            // 
            this.txtAte.Location = new System.Drawing.Point(467, 23);
            this.txtAte.Mask = "99/99/9999";
            this.txtAte.Name = "txtAte";
            this.txtAte.Size = new System.Drawing.Size(73, 20);
            this.txtAte.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "de";
            // 
            // txtDe
            // 
            this.txtDe.Location = new System.Drawing.Point(354, 23);
            this.txtDe.Mask = "99/99/9999";
            this.txtDe.Name = "txtDe";
            this.txtDe.Size = new System.Drawing.Size(73, 20);
            this.txtDe.TabIndex = 2;
            // 
            // rbVencimento
            // 
            this.rbVencimento.AutoSize = true;
            this.rbVencimento.Location = new System.Drawing.Point(143, 26);
            this.rbVencimento.Name = "rbVencimento";
            this.rbVencimento.Size = new System.Drawing.Size(81, 17);
            this.rbVencimento.TabIndex = 1;
            this.rbVencimento.TabStop = true;
            this.rbVencimento.Text = "Vencimento";
            this.rbVencimento.UseVisualStyleBackColor = true;
            // 
            // rbEmissao
            // 
            this.rbEmissao.AutoSize = true;
            this.rbEmissao.Checked = true;
            this.rbEmissao.Location = new System.Drawing.Point(34, 26);
            this.rbEmissao.Name = "rbEmissao";
            this.rbEmissao.Size = new System.Drawing.Size(64, 17);
            this.rbEmissao.TabIndex = 0;
            this.rbEmissao.TabStop = true;
            this.rbEmissao.Text = "Emissão";
            this.rbEmissao.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboCliente);
            this.groupBox3.Location = new System.Drawing.Point(22, 159);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(558, 62);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cliente";
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(9, 27);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(533, 21);
            this.cboCliente.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboMetodo);
            this.groupBox4.Location = new System.Drawing.Point(24, 237);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(558, 62);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Método de Pagamento";
            // 
            // cboMetodo
            // 
            this.cboMetodo.FormattingEnabled = true;
            this.cboMetodo.Location = new System.Drawing.Point(9, 27);
            this.cboMetodo.Name = "cboMetodo";
            this.cboMetodo.Size = new System.Drawing.Size(533, 21);
            this.cboMetodo.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(461, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Visualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmRelContasReceberFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(603, 381);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRelContasReceberFiltro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Contas a Receber";
            this.Load += new System.EventHandler(this.frmRelContasReceberFiltro_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSistemico;
        private System.Windows.Forms.RadioButton rbAnalitico;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbVencimento;
        private System.Windows.Forms.RadioButton rbEmissao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtAte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtDe;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboMetodo;
        private System.Windows.Forms.Button button1;
    }
}