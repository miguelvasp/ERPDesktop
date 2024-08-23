namespace ERP
{
    partial class frmPagamentoLotePreparacao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.cboMetodoPagamento = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVencimentoAte = new System.Windows.Forms.MaskedTextBox();
            this.txtVencimentoDe = new System.Windows.Forms.MaskedTextBox();
            this.cboFornecedor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.pblBotao = new System.Windows.Forms.Panel();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cboMetodoPagamentoBaixa = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboContaBancariaBaixa = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboContaContabilBaixa = new System.Windows.Forms.ComboBox();
            this.label111 = new System.Windows.Forms.Label();
            this.cboClienteBaixa = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboFornecedorBaixa = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkSelecionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lbCheque = new System.Windows.Forms.Label();
            this.cboCheque = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.pblBotao.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lbTotal);
            this.panel1.Controls.Add(this.btnConfirmar);
            this.panel1.Controls.Add(this.cboMetodoPagamento);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtVencimentoAte);
            this.panel1.Controls.Add(this.txtVencimentoDe);
            this.panel1.Controls.Add(this.cboFornecedor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPesquisar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1019, 97);
            this.panel1.TabIndex = 0;
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(12, 75);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(176, 15);
            this.lbTotal.TabIndex = 24;
            this.lbTotal.Text = "Valor selecionado R$ 0,00";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(841, 30);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(163, 28);
            this.btnConfirmar.TabIndex = 23;
            this.btnConfirmar.Text = "Efetuar Pagamentos";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // cboMetodoPagamento
            // 
            this.cboMetodoPagamento.FormattingEnabled = true;
            this.cboMetodoPagamento.Location = new System.Drawing.Point(495, 34);
            this.cboMetodoPagamento.Name = "cboMetodoPagamento";
            this.cboMetodoPagamento.Size = new System.Drawing.Size(215, 21);
            this.cboMetodoPagamento.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(492, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Metodo de Pagamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Até";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Vencimento";
            // 
            // txtVencimentoAte
            // 
            this.txtVencimentoAte.Location = new System.Drawing.Point(92, 35);
            this.txtVencimentoAte.Mask = "99/99/9999";
            this.txtVencimentoAte.Name = "txtVencimentoAte";
            this.txtVencimentoAte.Size = new System.Drawing.Size(74, 20);
            this.txtVencimentoAte.TabIndex = 18;
            // 
            // txtVencimentoDe
            // 
            this.txtVencimentoDe.Location = new System.Drawing.Point(12, 35);
            this.txtVencimentoDe.Mask = "99/99/9999";
            this.txtVencimentoDe.Name = "txtVencimentoDe";
            this.txtVencimentoDe.Size = new System.Drawing.Size(74, 20);
            this.txtVencimentoDe.TabIndex = 17;
            // 
            // cboFornecedor
            // 
            this.cboFornecedor.FormattingEnabled = true;
            this.cboFornecedor.Location = new System.Drawing.Point(172, 34);
            this.cboFornecedor.Name = "cboFornecedor";
            this.cboFornecedor.Size = new System.Drawing.Size(317, 21);
            this.cboFornecedor.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Fornecedor";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(716, 30);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(119, 28);
            this.btnPesquisar.TabIndex = 14;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // pblBotao
            // 
            this.pblBotao.Controls.Add(this.pnlContainer);
            this.pblBotao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pblBotao.Location = new System.Drawing.Point(0, 159);
            this.pblBotao.Name = "pblBotao";
            this.pblBotao.Size = new System.Drawing.Size(1019, 428);
            this.pblBotao.TabIndex = 21;
            this.pblBotao.Visible = false;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.cboCheque);
            this.pnlContainer.Controls.Add(this.lbCheque);
            this.pnlContainer.Controls.Add(this.button2);
            this.pnlContainer.Controls.Add(this.button1);
            this.pnlContainer.Controls.Add(this.cboMetodoPagamentoBaixa);
            this.pnlContainer.Controls.Add(this.label10);
            this.pnlContainer.Controls.Add(this.cboContaBancariaBaixa);
            this.pnlContainer.Controls.Add(this.label9);
            this.pnlContainer.Controls.Add(this.cboContaContabilBaixa);
            this.pnlContainer.Controls.Add(this.label111);
            this.pnlContainer.Controls.Add(this.cboClienteBaixa);
            this.pnlContainer.Controls.Add(this.label7);
            this.pnlContainer.Controls.Add(this.cboFornecedorBaixa);
            this.pnlContainer.Controls.Add(this.label6);
            this.pnlContainer.Controls.Add(this.label5);
            this.pnlContainer.Location = new System.Drawing.Point(30, 16);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(486, 466);
            this.pnlContainer.TabIndex = 29;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 380);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 30);
            this.button2.TabIndex = 28;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 30);
            this.button1.TabIndex = 27;
            this.button1.Text = "Efetuar Pagamentos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboMetodoPagamentoBaixa
            // 
            this.cboMetodoPagamentoBaixa.FormattingEnabled = true;
            this.cboMetodoPagamentoBaixa.Location = new System.Drawing.Point(26, 266);
            this.cboMetodoPagamentoBaixa.Name = "cboMetodoPagamentoBaixa";
            this.cboMetodoPagamentoBaixa.Size = new System.Drawing.Size(365, 21);
            this.cboMetodoPagamentoBaixa.TabIndex = 26;
            this.cboMetodoPagamentoBaixa.SelectedIndexChanged += new System.EventHandler(this.cboMetodoPagamentoBaixa_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 250);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Metodo de Pagamento";
            // 
            // cboContaBancariaBaixa
            // 
            this.cboContaBancariaBaixa.FormattingEnabled = true;
            this.cboContaBancariaBaixa.Location = new System.Drawing.Point(26, 214);
            this.cboContaBancariaBaixa.Name = "cboContaBancariaBaixa";
            this.cboContaBancariaBaixa.Size = new System.Drawing.Size(365, 21);
            this.cboContaBancariaBaixa.TabIndex = 24;
            this.cboContaBancariaBaixa.SelectedIndexChanged += new System.EventHandler(this.cboContaBancariaBaixa_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Conta Bancária";
            // 
            // cboContaContabilBaixa
            // 
            this.cboContaContabilBaixa.FormattingEnabled = true;
            this.cboContaContabilBaixa.Location = new System.Drawing.Point(26, 163);
            this.cboContaContabilBaixa.Name = "cboContaContabilBaixa";
            this.cboContaContabilBaixa.Size = new System.Drawing.Size(365, 21);
            this.cboContaContabilBaixa.TabIndex = 22;
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(23, 147);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(76, 13);
            this.label111.TabIndex = 21;
            this.label111.Text = "Conta Contábil";
            // 
            // cboClienteBaixa
            // 
            this.cboClienteBaixa.FormattingEnabled = true;
            this.cboClienteBaixa.Location = new System.Drawing.Point(26, 115);
            this.cboClienteBaixa.Name = "cboClienteBaixa";
            this.cboClienteBaixa.Size = new System.Drawing.Size(365, 21);
            this.cboClienteBaixa.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Cliente";
            // 
            // cboFornecedorBaixa
            // 
            this.cboFornecedorBaixa.FormattingEnabled = true;
            this.cboFornecedorBaixa.Location = new System.Drawing.Point(26, 67);
            this.cboFornecedorBaixa.Name = "cboFornecedorBaixa";
            this.cboFornecedorBaixa.Size = new System.Drawing.Size(365, 21);
            this.cboFornecedorBaixa.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Fornecedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(278, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Preencha os dados para efetuar os pagamentos";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column9,
            this.chkSelecionar,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column10});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 97);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 18;
            this.dgv.Size = new System.Drawing.Size(1019, 490);
            this.dgv.TabIndex = 22;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IdContasPagarAberto";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "IdContasPagar";
            this.Column9.HeaderText = "Column9";
            this.Column9.Name = "Column9";
            this.Column9.Visible = false;
            // 
            // chkSelecionar
            // 
            this.chkSelecionar.HeaderText = " * ";
            this.chkSelecionar.Name = "chkSelecionar";
            this.chkSelecionar.Width = 30;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "RazaoSocial";
            this.Column3.HeaderText = "Fornecedor";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 250;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Vencimento";
            this.Column4.HeaderText = "Vencimento";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Documento";
            this.Column5.HeaderText = "Documento";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "MetodoPagamento";
            this.Column6.HeaderText = "Metodo Pagamento";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 170;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "ValorLiquido";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column7.HeaderText = "Valor Liquido";
            this.Column7.Name = "Column7";
            this.Column7.Width = 120;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Saldo";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column8.HeaderText = "Saldo";
            this.Column8.Name = "Column8";
            this.Column8.Width = 120;
            // 
            // Column10
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column10.HeaderText = "Valor a Pagar";
            this.Column10.Name = "Column10";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 102);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lbCheque
            // 
            this.lbCheque.AutoSize = true;
            this.lbCheque.Location = new System.Drawing.Point(23, 307);
            this.lbCheque.Name = "lbCheque";
            this.lbCheque.Size = new System.Drawing.Size(44, 13);
            this.lbCheque.TabIndex = 29;
            this.lbCheque.Text = "Cheque";
            // 
            // cboCheque
            // 
            this.cboCheque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheque.FormattingEnabled = true;
            this.cboCheque.Location = new System.Drawing.Point(26, 323);
            this.cboCheque.Name = "cboCheque";
            this.cboCheque.Size = new System.Drawing.Size(121, 21);
            this.cboCheque.TabIndex = 30;
            // 
            // frmPagamentoLotePreparacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1019, 587);
            this.Controls.Add(this.pblBotao);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPagamentoLotePreparacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmBuscaProduto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBuscaProduto_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pblBotao.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Panel pblBotao;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox cboMetodoPagamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtVencimentoAte;
        private System.Windows.Forms.MaskedTextBox txtVencimentoDe;
        private System.Windows.Forms.ComboBox cboFornecedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cboMetodoPagamentoBaixa;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboContaBancariaBaixa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboContaContabilBaixa;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.ComboBox cboClienteBaixa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboFornecedorBaixa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSelecionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.Label lbCheque;
        private System.Windows.Forms.ComboBox cboCheque;
    }
}