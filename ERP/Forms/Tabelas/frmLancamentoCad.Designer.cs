namespace ERP
{
    partial class frmLancamentoCad
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
            this.tbcLancamento = new System.Windows.Forms.TabControl();
            this.tbpVendas = new System.Windows.Forms.TabPage();
            this.dgvVendas = new System.Windows.Forms.DataGridView();
            this.btnAdicionarVendas = new System.Windows.Forms.Button();
            this.grbVendas = new System.Windows.Forms.GroupBox();
            this.tbpCompras = new System.Windows.Forms.TabPage();
            this.btnAdicionarCompras = new System.Windows.Forms.Button();
            this.grbCompras = new System.Windows.Forms.GroupBox();
            this.tbpEstoque = new System.Windows.Forms.TabPage();
            this.btnAdicionarEstoque = new System.Windows.Forms.Button();
            this.grbEstoque = new System.Windows.Forms.GroupBox();
            this.tbpProducao = new System.Windows.Forms.TabPage();
            this.btnAdicionarProducao = new System.Windows.Forms.Button();
            this.grbProducao = new System.Windows.Forms.GroupBox();
            this.IdLancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoLancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContaContabil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEstoque = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProducao = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbcLancamento.SuspendLayout();
            this.tbpVendas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).BeginInit();
            this.tbpCompras.SuspendLayout();
            this.tbpEstoque.SuspendLayout();
            this.tbpProducao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducao)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcLancamento
            // 
            this.tbcLancamento.Controls.Add(this.tbpVendas);
            this.tbcLancamento.Controls.Add(this.tbpCompras);
            this.tbcLancamento.Controls.Add(this.tbpEstoque);
            this.tbcLancamento.Controls.Add(this.tbpProducao);
            this.tbcLancamento.Location = new System.Drawing.Point(0, 0);
            this.tbcLancamento.Name = "tbcLancamento";
            this.tbcLancamento.SelectedIndex = 0;
            this.tbcLancamento.Size = new System.Drawing.Size(954, 505);
            this.tbcLancamento.TabIndex = 40;
            this.tbcLancamento.SelectedIndexChanged += new System.EventHandler(this.tbcLancamento_SelectedIndexChanged);
            // 
            // tbpVendas
            // 
            this.tbpVendas.Controls.Add(this.dgvVendas);
            this.tbpVendas.Controls.Add(this.btnAdicionarVendas);
            this.tbpVendas.Controls.Add(this.grbVendas);
            this.tbpVendas.Location = new System.Drawing.Point(4, 22);
            this.tbpVendas.Name = "tbpVendas";
            this.tbpVendas.Padding = new System.Windows.Forms.Padding(3);
            this.tbpVendas.Size = new System.Drawing.Size(946, 479);
            this.tbpVendas.TabIndex = 0;
            this.tbpVendas.Tag = "1";
            this.tbpVendas.Text = "Pedido de Vendas";
            this.tbpVendas.UseVisualStyleBackColor = true;
            // 
            // dgvVendas
            // 
            this.dgvVendas.AllowUserToAddRows = false;
            this.dgvVendas.AllowUserToDeleteRows = false;
            this.dgvVendas.AllowUserToOrderColumns = true;
            this.dgvVendas.AllowUserToResizeRows = false;
            this.dgvVendas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdLancamento,
            this.Column2,
            this.TipoDocumento,
            this.TipoLancamento,
            this.ContaContabil});
            this.dgvVendas.Location = new System.Drawing.Point(312, 44);
            this.dgvVendas.MultiSelect = false;
            this.dgvVendas.Name = "dgvVendas";
            this.dgvVendas.ReadOnly = true;
            this.dgvVendas.RowTemplate.Height = 18;
            this.dgvVendas.Size = new System.Drawing.Size(631, 428);
            this.dgvVendas.TabIndex = 29;
            this.dgvVendas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendas_CellDoubleClick);
            // 
            // btnAdicionarVendas
            // 
            this.btnAdicionarVendas.Location = new System.Drawing.Point(310, 15);
            this.btnAdicionarVendas.Name = "btnAdicionarVendas";
            this.btnAdicionarVendas.Size = new System.Drawing.Size(113, 23);
            this.btnAdicionarVendas.TabIndex = 28;
            this.btnAdicionarVendas.Text = "Adicionar";
            this.btnAdicionarVendas.UseVisualStyleBackColor = true;
            this.btnAdicionarVendas.Click += new System.EventHandler(this.btnAdicionarVendas_Click);
            // 
            // grbVendas
            // 
            this.grbVendas.Location = new System.Drawing.Point(6, 6);
            this.grbVendas.Name = "grbVendas";
            this.grbVendas.Size = new System.Drawing.Size(300, 466);
            this.grbVendas.TabIndex = 0;
            this.grbVendas.TabStop = false;
            this.grbVendas.Text = "Selecionar";
            // 
            // tbpCompras
            // 
            this.tbpCompras.Controls.Add(this.dgvCompras);
            this.tbpCompras.Controls.Add(this.btnAdicionarCompras);
            this.tbpCompras.Controls.Add(this.grbCompras);
            this.tbpCompras.Location = new System.Drawing.Point(4, 22);
            this.tbpCompras.Name = "tbpCompras";
            this.tbpCompras.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCompras.Size = new System.Drawing.Size(946, 479);
            this.tbpCompras.TabIndex = 1;
            this.tbpCompras.Tag = "2";
            this.tbpCompras.Text = "Pedido de Compras";
            this.tbpCompras.UseVisualStyleBackColor = true;
            // 
            // btnAdicionarCompras
            // 
            this.btnAdicionarCompras.Location = new System.Drawing.Point(310, 15);
            this.btnAdicionarCompras.Name = "btnAdicionarCompras";
            this.btnAdicionarCompras.Size = new System.Drawing.Size(113, 23);
            this.btnAdicionarCompras.TabIndex = 29;
            this.btnAdicionarCompras.Text = "Adicionar";
            this.btnAdicionarCompras.UseVisualStyleBackColor = true;
            this.btnAdicionarCompras.Click += new System.EventHandler(this.btnAdicionarCompras_Click);
            // 
            // grbCompras
            // 
            this.grbCompras.Location = new System.Drawing.Point(6, 6);
            this.grbCompras.Name = "grbCompras";
            this.grbCompras.Size = new System.Drawing.Size(300, 466);
            this.grbCompras.TabIndex = 1;
            this.grbCompras.TabStop = false;
            this.grbCompras.Text = "Selecionar";
            // 
            // tbpEstoque
            // 
            this.tbpEstoque.Controls.Add(this.dgvEstoque);
            this.tbpEstoque.Controls.Add(this.btnAdicionarEstoque);
            this.tbpEstoque.Controls.Add(this.grbEstoque);
            this.tbpEstoque.Location = new System.Drawing.Point(4, 22);
            this.tbpEstoque.Name = "tbpEstoque";
            this.tbpEstoque.Size = new System.Drawing.Size(946, 479);
            this.tbpEstoque.TabIndex = 2;
            this.tbpEstoque.Tag = "3";
            this.tbpEstoque.Text = "Estoque";
            this.tbpEstoque.UseVisualStyleBackColor = true;
            // 
            // btnAdicionarEstoque
            // 
            this.btnAdicionarEstoque.Location = new System.Drawing.Point(310, 15);
            this.btnAdicionarEstoque.Name = "btnAdicionarEstoque";
            this.btnAdicionarEstoque.Size = new System.Drawing.Size(113, 23);
            this.btnAdicionarEstoque.TabIndex = 29;
            this.btnAdicionarEstoque.Text = "Adicionar";
            this.btnAdicionarEstoque.UseVisualStyleBackColor = true;
            this.btnAdicionarEstoque.Click += new System.EventHandler(this.btnAdicionarEstoque_Click);
            // 
            // grbEstoque
            // 
            this.grbEstoque.Location = new System.Drawing.Point(6, 6);
            this.grbEstoque.Name = "grbEstoque";
            this.grbEstoque.Size = new System.Drawing.Size(300, 466);
            this.grbEstoque.TabIndex = 1;
            this.grbEstoque.TabStop = false;
            this.grbEstoque.Text = "Selecionar";
            // 
            // tbpProducao
            // 
            this.tbpProducao.Controls.Add(this.dgvProducao);
            this.tbpProducao.Controls.Add(this.btnAdicionarProducao);
            this.tbpProducao.Controls.Add(this.grbProducao);
            this.tbpProducao.Location = new System.Drawing.Point(4, 22);
            this.tbpProducao.Name = "tbpProducao";
            this.tbpProducao.Size = new System.Drawing.Size(946, 479);
            this.tbpProducao.TabIndex = 3;
            this.tbpProducao.Tag = "4";
            this.tbpProducao.Text = "Produção";
            this.tbpProducao.UseVisualStyleBackColor = true;
            // 
            // btnAdicionarProducao
            // 
            this.btnAdicionarProducao.Location = new System.Drawing.Point(310, 15);
            this.btnAdicionarProducao.Name = "btnAdicionarProducao";
            this.btnAdicionarProducao.Size = new System.Drawing.Size(113, 23);
            this.btnAdicionarProducao.TabIndex = 29;
            this.btnAdicionarProducao.Text = "Adicionar";
            this.btnAdicionarProducao.UseVisualStyleBackColor = true;
            this.btnAdicionarProducao.Click += new System.EventHandler(this.btnAdicionarProducao_Click);
            // 
            // grbProducao
            // 
            this.grbProducao.Location = new System.Drawing.Point(6, 6);
            this.grbProducao.Name = "grbProducao";
            this.grbProducao.Size = new System.Drawing.Size(300, 466);
            this.grbProducao.TabIndex = 1;
            this.grbProducao.TabStop = false;
            this.grbProducao.Text = "Selecionar";
            // 
            // IdLancamento
            // 
            this.IdLancamento.DataPropertyName = "IdLancamento";
            this.IdLancamento.HeaderText = "Código";
            this.IdLancamento.Name = "IdLancamento";
            this.IdLancamento.ReadOnly = true;
            this.IdLancamento.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Descricao";
            this.Column2.HeaderText = "Descrição";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 250;
            // 
            // TipoDocumento
            // 
            this.TipoDocumento.DataPropertyName = "TipoDocumento";
            this.TipoDocumento.HeaderText = "Documento";
            this.TipoDocumento.Name = "TipoDocumento";
            this.TipoDocumento.ReadOnly = true;
            // 
            // TipoLancamento
            // 
            this.TipoLancamento.DataPropertyName = "TipoLancamento";
            this.TipoLancamento.HeaderText = "Tipo Lançamento";
            this.TipoLancamento.Name = "TipoLancamento";
            this.TipoLancamento.ReadOnly = true;
            this.TipoLancamento.Width = 200;
            // 
            // ContaContabil
            // 
            this.ContaContabil.DataPropertyName = "ContaContabil";
            this.ContaContabil.HeaderText = "Conta Contábil";
            this.ContaContabil.Name = "ContaContabil";
            this.ContaContabil.ReadOnly = true;
            this.ContaContabil.Width = 250;
            // 
            // dgvCompras
            // 
            this.dgvCompras.AllowUserToAddRows = false;
            this.dgvCompras.AllowUserToDeleteRows = false;
            this.dgvCompras.AllowUserToOrderColumns = true;
            this.dgvCompras.AllowUserToResizeRows = false;
            this.dgvCompras.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvCompras.Location = new System.Drawing.Point(312, 44);
            this.dgvCompras.MultiSelect = false;
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.ReadOnly = true;
            this.dgvCompras.RowTemplate.Height = 18;
            this.dgvCompras.Size = new System.Drawing.Size(631, 428);
            this.dgvCompras.TabIndex = 30;
            this.dgvCompras.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompras_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IdLancamento";
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Descricao";
            this.dataGridViewTextBoxColumn2.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TipoDocumento";
            this.dataGridViewTextBoxColumn3.HeaderText = "Documento";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TipoLancamento";
            this.dataGridViewTextBoxColumn4.HeaderText = "Tipo Lançamento";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ContaContabil";
            this.dataGridViewTextBoxColumn5.HeaderText = "Conta Contábil";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 250;
            // 
            // dgvEstoque
            // 
            this.dgvEstoque.AllowUserToAddRows = false;
            this.dgvEstoque.AllowUserToDeleteRows = false;
            this.dgvEstoque.AllowUserToOrderColumns = true;
            this.dgvEstoque.AllowUserToResizeRows = false;
            this.dgvEstoque.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstoque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dgvEstoque.Location = new System.Drawing.Point(311, 44);
            this.dgvEstoque.MultiSelect = false;
            this.dgvEstoque.Name = "dgvEstoque";
            this.dgvEstoque.ReadOnly = true;
            this.dgvEstoque.RowTemplate.Height = 18;
            this.dgvEstoque.Size = new System.Drawing.Size(631, 428);
            this.dgvEstoque.TabIndex = 31;
            this.dgvEstoque.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstoque_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "IdLancamento";
            this.dataGridViewTextBoxColumn6.HeaderText = "Código";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Descricao";
            this.dataGridViewTextBoxColumn7.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 250;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TipoDocumento";
            this.dataGridViewTextBoxColumn8.HeaderText = "Documento";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "TipoLancamento";
            this.dataGridViewTextBoxColumn9.HeaderText = "Tipo Lançamento";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 200;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ContaContabil";
            this.dataGridViewTextBoxColumn10.HeaderText = "Conta Contábil";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 250;
            // 
            // dgvProducao
            // 
            this.dgvProducao.AllowUserToAddRows = false;
            this.dgvProducao.AllowUserToDeleteRows = false;
            this.dgvProducao.AllowUserToOrderColumns = true;
            this.dgvProducao.AllowUserToResizeRows = false;
            this.dgvProducao.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvProducao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15});
            this.dgvProducao.Location = new System.Drawing.Point(311, 44);
            this.dgvProducao.MultiSelect = false;
            this.dgvProducao.Name = "dgvProducao";
            this.dgvProducao.ReadOnly = true;
            this.dgvProducao.RowTemplate.Height = 18;
            this.dgvProducao.Size = new System.Drawing.Size(631, 428);
            this.dgvProducao.TabIndex = 32;
            this.dgvProducao.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducao_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "IdLancamento";
            this.dataGridViewTextBoxColumn11.HeaderText = "Código";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Descricao";
            this.dataGridViewTextBoxColumn12.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 250;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "TipoDocumento";
            this.dataGridViewTextBoxColumn13.HeaderText = "Documento";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "TipoLancamento";
            this.dataGridViewTextBoxColumn14.HeaderText = "Tipo Lançamento";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 200;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "ContaContabil";
            this.dataGridViewTextBoxColumn15.HeaderText = "Conta Contábil";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 250;
            // 
            // frmLancamentoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(958, 506);
            this.Controls.Add(this.tbcLancamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmLancamentoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmLancamentoCad";
            this.Text = "Cadastro de Lançamento";
            this.Load += new System.EventHandler(this.frmLancamentoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLancamentoCad_KeyDown);
            this.tbcLancamento.ResumeLayout(false);
            this.tbpVendas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).EndInit();
            this.tbpCompras.ResumeLayout(false);
            this.tbpEstoque.ResumeLayout(false);
            this.tbpProducao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcLancamento;
        private System.Windows.Forms.TabPage tbpVendas;
        private System.Windows.Forms.TabPage tbpCompras;
        private System.Windows.Forms.TabPage tbpEstoque;
        private System.Windows.Forms.TabPage tbpProducao;
        private System.Windows.Forms.GroupBox grbVendas;
        private System.Windows.Forms.GroupBox grbCompras;
        private System.Windows.Forms.GroupBox grbEstoque;
        private System.Windows.Forms.GroupBox grbProducao;
        private System.Windows.Forms.Button btnAdicionarVendas;
        private System.Windows.Forms.Button btnAdicionarCompras;
        private System.Windows.Forms.Button btnAdicionarEstoque;
        private System.Windows.Forms.Button btnAdicionarProducao;
        private System.Windows.Forms.DataGridView dgvVendas;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdLancamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoLancamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContaContabil;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridView dgvEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridView dgvProducao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
    }
}