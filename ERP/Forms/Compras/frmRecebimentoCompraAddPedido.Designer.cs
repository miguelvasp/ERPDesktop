namespace ERP
{
    partial class frmRecebimentoCompraAddPedido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtRecebimento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.chkSelecionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdPedidoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPedidoCompraItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pedidonumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantidadeAReceber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantidadeRecebida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ipi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecoUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
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
            this.chkSelecionar,
            this.IdPedidoCompra,
            this.IdPedidoCompraItem,
            this.Pedidonumero,
            this.Column2,
            this.Column3,
            this.Quantidade,
            this.QuantidadeAReceber,
            this.QuantidadeRecebida,
            this.Saldo,
            this.Ipi,
            this.PrecoUnitario,
            this.Total});
            this.dgv.Location = new System.Drawing.Point(17, 66);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 18;
            this.dgv.Size = new System.Drawing.Size(996, 500);
            this.dgv.TabIndex = 17;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(938, 572);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(857, 572);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 19;
            this.btnConfirmar.Text = "C&onfirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtRecebimento
            // 
            this.txtRecebimento.Location = new System.Drawing.Point(19, 24);
            this.txtRecebimento.Name = "txtRecebimento";
            this.txtRecebimento.ReadOnly = true;
            this.txtRecebimento.Size = new System.Drawing.Size(108, 20);
            this.txtRecebimento.TabIndex = 61;
            this.txtRecebimento.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Recebimento";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(251, 24);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(160, 20);
            this.txtUsuario.TabIndex = 63;
            this.txtUsuario.Tag = "";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(250, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 65;
            this.lblUsuario.Text = "Usuário";
            // 
            // txtData
            // 
            this.txtData.Enabled = false;
            this.txtData.Location = new System.Drawing.Point(142, 24);
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.Size = new System.Drawing.Size(94, 20);
            this.txtData.TabIndex = 62;
            this.txtData.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Data";
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Enabled = false;
            this.txtFornecedor.Location = new System.Drawing.Point(426, 24);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(253, 20);
            this.txtFornecedor.TabIndex = 67;
            this.txtFornecedor.Tag = "";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(425, 9);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(61, 13);
            this.lblFornecedor.TabIndex = 68;
            this.lblFornecedor.Text = "Fornecedor";
            // 
            // chkSelecionar
            // 
            this.chkSelecionar.HeaderText = "";
            this.chkSelecionar.Name = "chkSelecionar";
            this.chkSelecionar.Width = 45;
            // 
            // IdPedidoCompra
            // 
            this.IdPedidoCompra.DataPropertyName = "IdPedidoCompra";
            this.IdPedidoCompra.HeaderText = "IdPedidoCompra ";
            this.IdPedidoCompra.Name = "IdPedidoCompra";
            this.IdPedidoCompra.ReadOnly = true;
            this.IdPedidoCompra.Visible = false;
            // 
            // IdPedidoCompraItem
            // 
            this.IdPedidoCompraItem.DataPropertyName = "IdPedidoCompraItem";
            this.IdPedidoCompraItem.HeaderText = "IdPedidoCompraItem ";
            this.IdPedidoCompraItem.Name = "IdPedidoCompraItem";
            this.IdPedidoCompraItem.ReadOnly = true;
            this.IdPedidoCompraItem.Visible = false;
            // 
            // Pedidonumero
            // 
            this.Pedidonumero.DataPropertyName = "Pedidonumero";
            this.Pedidonumero.HeaderText = "N° Pedido";
            this.Pedidonumero.Name = "Pedidonumero";
            this.Pedidonumero.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Codigo";
            this.Column2.HeaderText = "Código Produto";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NomeProduto";
            this.Column3.HeaderText = "Descrição";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Quantidade
            // 
            this.Quantidade.DataPropertyName = "Quantidade";
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            this.Quantidade.Visible = false;
            // 
            // QuantidadeAReceber
            // 
            this.QuantidadeAReceber.DataPropertyName = "QuantidadeAReceber";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.QuantidadeAReceber.DefaultCellStyle = dataGridViewCellStyle1;
            this.QuantidadeAReceber.HeaderText = "Qtde. a Receber";
            this.QuantidadeAReceber.Name = "QuantidadeAReceber";
            this.QuantidadeAReceber.ReadOnly = true;
            this.QuantidadeAReceber.Width = 120;
            // 
            // QuantidadeRecebida
            // 
            this.QuantidadeRecebida.DataPropertyName = "QuantidadeRecebida";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.QuantidadeRecebida.DefaultCellStyle = dataGridViewCellStyle2;
            this.QuantidadeRecebida.HeaderText = "Qtde. Recebida";
            this.QuantidadeRecebida.MaxInputLength = 5;
            this.QuantidadeRecebida.Name = "QuantidadeRecebida";
            this.QuantidadeRecebida.Width = 120;
            // 
            // Saldo
            // 
            this.Saldo.DataPropertyName = "Saldo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Saldo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            this.Saldo.Visible = false;
            // 
            // Ipi
            // 
            this.Ipi.DataPropertyName = "Ipi";
            this.Ipi.HeaderText = "IPI";
            this.Ipi.Name = "Ipi";
            this.Ipi.ReadOnly = true;
            this.Ipi.Visible = false;
            // 
            // PrecoUnitario
            // 
            this.PrecoUnitario.DataPropertyName = "PrecoUnitario";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N4";
            dataGridViewCellStyle4.NullValue = null;
            this.PrecoUnitario.DefaultCellStyle = dataGridViewCellStyle4;
            this.PrecoUnitario.HeaderText = "Preço Unitário";
            this.PrecoUnitario.Name = "PrecoUnitario";
            this.PrecoUnitario.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N4";
            dataGridViewCellStyle5.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle5;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // frmRecebimentoCompraAddPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1034, 607);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.lblFornecedor);
            this.Controls.Add(this.txtRecebimento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "frmRecebimentoCompraAddPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmRecebimentoCompraAddPedido";
            this.Text = "Recebimento de Compra";
            this.Load += new System.EventHandler(this.frmRecebimentoCompraAddPedido_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRecebimentoCompraAddPedido_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtRecebimento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSelecionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPedidoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPedidoCompraItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pedidonumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeAReceber;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeRecebida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ipi;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}