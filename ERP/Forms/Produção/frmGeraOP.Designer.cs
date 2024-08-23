namespace ERP.Forms.Produção
{
    partial class frmGeraOP
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
            this.cboPlanoProducao = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvProduto = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipoProducao = new System.Windows.Forms.ComboBox();
            this.txtPrevisao = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEstilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTamanho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdConfig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPlanoProducao
            // 
            this.cboPlanoProducao.FormattingEnabled = true;
            this.cboPlanoProducao.Location = new System.Drawing.Point(32, 41);
            this.cboPlanoProducao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboPlanoProducao.Name = "cboPlanoProducao";
            this.cboPlanoProducao.Size = new System.Drawing.Size(809, 24);
            this.cboPlanoProducao.TabIndex = 12;
            this.cboPlanoProducao.SelectedIndexChanged += new System.EventHandler(this.cboPlanoProducao_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 21);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Plano de Produção";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(568, 635);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 18;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvProduto
            // 
            this.dgvProduto.AllowUserToAddRows = false;
            this.dgvProduto.AllowUserToDeleteRows = false;
            this.dgvProduto.BackgroundColor = System.Drawing.Color.White;
            this.dgvProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IdCor,
            this.IdEstilo,
            this.IdTamanho,
            this.IdConfig,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column2,
            this.Qtde});
            this.dgvProduto.Location = new System.Drawing.Point(32, 111);
            this.dgvProduto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProduto.Name = "dgvProduto";
            this.dgvProduto.RowHeadersVisible = false;
            this.dgvProduto.Size = new System.Drawing.Size(1292, 449);
            this.dgvProduto.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Informe a quantidade para cada produto a ser produzido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 564);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(856, 34);
            this.label2.TabIndex = 21;
            this.label2.Text = "* Caso o produto desejado não apareça na listagem verifique os produtos vinculado" +
    "s ao Plano de Produção ou se a \r\nQuantidade de Produção está preenchida no cadas" +
    "tro do produto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 618);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Tipo de Produção";
            // 
            // cboTipoProducao
            // 
            this.cboTipoProducao.FormattingEnabled = true;
            this.cboTipoProducao.Location = new System.Drawing.Point(32, 638);
            this.cboTipoProducao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboTipoProducao.Name = "cboTipoProducao";
            this.cboTipoProducao.Size = new System.Drawing.Size(373, 24);
            this.cboTipoProducao.TabIndex = 22;
            // 
            // txtPrevisao
            // 
            this.txtPrevisao.Location = new System.Drawing.Point(415, 638);
            this.txtPrevisao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrevisao.Mask = "99/99/9999";
            this.txtPrevisao.Name = "txtPrevisao";
            this.txtPrevisao.Size = new System.Drawing.Size(144, 22);
            this.txtPrevisao.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 618);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Previsão de Produção";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "IdProduto";
            this.Id.HeaderText = "Column1";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // IdCor
            // 
            this.IdCor.HeaderText = "Column7";
            this.IdCor.Name = "IdCor";
            this.IdCor.Visible = false;
            // 
            // IdEstilo
            // 
            this.IdEstilo.HeaderText = "Column7";
            this.IdEstilo.Name = "IdEstilo";
            this.IdEstilo.Visible = false;
            // 
            // IdTamanho
            // 
            this.IdTamanho.HeaderText = "Column7";
            this.IdTamanho.Name = "IdTamanho";
            this.IdTamanho.Visible = false;
            // 
            // IdConfig
            // 
            this.IdConfig.HeaderText = "Column7";
            this.IdConfig.Name = "IdConfig";
            this.IdConfig.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "NomeProduto";
            this.Column1.HeaderText = "Nome Produto";
            this.Column1.Name = "Column1";
            this.Column1.Width = 350;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Cor";
            this.Column3.HeaderText = "Cor";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Estilo";
            this.Column4.HeaderText = "Estilo";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Tamanho";
            this.Column5.HeaderText = "Tamanho";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Config";
            this.Column6.HeaderText = "Config";
            this.Column6.Name = "Column6";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Fator";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Qtde
            // 
            this.Qtde.HeaderText = "Qtde";
            this.Qtde.Name = "Qtde";
            this.Qtde.Width = 80;
            // 
            // frmGeraOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 705);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrevisao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTipoProducao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProduto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboPlanoProducao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGeraOP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Geração de Ordem de Produção";
            this.Load += new System.EventHandler(this.frmGeraOP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboPlanoProducao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTipoProducao;
        private System.Windows.Forms.MaskedTextBox txtPrevisao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEstilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTamanho;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qtde;
    }
}