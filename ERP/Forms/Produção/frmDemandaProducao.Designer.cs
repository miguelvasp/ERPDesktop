namespace ERP
{
    partial class frmDemandaProducao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDemandaProducao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNovo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.planilhaExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arquivoSeparadoPorVírgulacsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdVariantesCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdVariantesTamanho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdVariantesEstilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdVariantesConfig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tamanho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Config = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Un = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Demanda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNovo,
            this.toolStripSeparator1,
            this.btnReload,
            this.toolStripSeparator3,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(941, 31);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(173, 28);
            this.btnNovo.Text = "Gerar Ordem de Produção";
            this.btnNovo.ToolTipText = "Novo registro";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnReload
            // 
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(28, 28);
            this.btnReload.Text = "Atualizar";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planilhaExcelToolStripMenuItem,
            this.arquivoSeparadoPorVírgulacsvToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(113, 28);
            this.toolStripDropDownButton1.Text = "Exportar para";
            // 
            // planilhaExcelToolStripMenuItem
            // 
            this.planilhaExcelToolStripMenuItem.Name = "planilhaExcelToolStripMenuItem";
            this.planilhaExcelToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.planilhaExcelToolStripMenuItem.Text = "Planilha Excel";
            this.planilhaExcelToolStripMenuItem.Click += new System.EventHandler(this.planilhaExcelToolStripMenuItem_Click);
            // 
            // arquivoSeparadoPorVírgulacsvToolStripMenuItem
            // 
            this.arquivoSeparadoPorVírgulacsvToolStripMenuItem.Name = "arquivoSeparadoPorVírgulacsvToolStripMenuItem";
            this.arquivoSeparadoPorVírgulacsvToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.arquivoSeparadoPorVírgulacsvToolStripMenuItem.Text = "Arquivo separado por vírgula (csv)";
            this.arquivoSeparadoPorVírgulacsvToolStripMenuItem.Click += new System.EventHandler(this.arquivoSeparadoPorVírgulacsvToolStripMenuItem_Click);
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
            this.Id,
            this.IdProduto,
            this.IdVariantesCor,
            this.IdVariantesTamanho,
            this.IdVariantesEstilo,
            this.IdVariantesConfig,
            this.IdUnidade,
            this.Column1,
            this.Column2,
            this.Cor,
            this.Tamanho,
            this.Estilo,
            this.Config,
            this.Un,
            this.Qtde,
            this.Estoque,
            this.Demanda});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 31);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 18;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(941, 509);
            this.dgv.TabIndex = 16;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "IdDemandaProducao";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // IdProduto
            // 
            this.IdProduto.DataPropertyName = "IdProduto";
            this.IdProduto.HeaderText = "Column1";
            this.IdProduto.Name = "IdProduto";
            this.IdProduto.ReadOnly = true;
            this.IdProduto.Visible = false;
            // 
            // IdVariantesCor
            // 
            this.IdVariantesCor.DataPropertyName = "IdVariantesCor";
            this.IdVariantesCor.HeaderText = "Column1";
            this.IdVariantesCor.Name = "IdVariantesCor";
            this.IdVariantesCor.ReadOnly = true;
            this.IdVariantesCor.Visible = false;
            // 
            // IdVariantesTamanho
            // 
            this.IdVariantesTamanho.DataPropertyName = "IdVariantesTamanho";
            this.IdVariantesTamanho.HeaderText = "Column1";
            this.IdVariantesTamanho.Name = "IdVariantesTamanho";
            this.IdVariantesTamanho.ReadOnly = true;
            this.IdVariantesTamanho.Visible = false;
            // 
            // IdVariantesEstilo
            // 
            this.IdVariantesEstilo.DataPropertyName = "IdVariantesEstilo";
            this.IdVariantesEstilo.HeaderText = "Column1";
            this.IdVariantesEstilo.Name = "IdVariantesEstilo";
            this.IdVariantesEstilo.ReadOnly = true;
            this.IdVariantesEstilo.Visible = false;
            // 
            // IdVariantesConfig
            // 
            this.IdVariantesConfig.DataPropertyName = "IdVariantesConfig";
            this.IdVariantesConfig.HeaderText = "Column1";
            this.IdVariantesConfig.Name = "IdVariantesConfig";
            this.IdVariantesConfig.ReadOnly = true;
            this.IdVariantesConfig.Visible = false;
            // 
            // IdUnidade
            // 
            this.IdUnidade.DataPropertyName = "IdUnidade";
            this.IdUnidade.HeaderText = "Column1";
            this.IdUnidade.Name = "IdUnidade";
            this.IdUnidade.ReadOnly = true;
            this.IdUnidade.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Codigo";
            this.Column1.HeaderText = "Código";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Descricao";
            this.Column2.HeaderText = "Descrição";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 400;
            // 
            // Cor
            // 
            this.Cor.DataPropertyName = "Cor";
            this.Cor.HeaderText = "Cor";
            this.Cor.Name = "Cor";
            this.Cor.ReadOnly = true;
            this.Cor.Width = 120;
            // 
            // Tamanho
            // 
            this.Tamanho.DataPropertyName = "Tamanho";
            this.Tamanho.HeaderText = "Tamanho";
            this.Tamanho.Name = "Tamanho";
            this.Tamanho.ReadOnly = true;
            // 
            // Estilo
            // 
            this.Estilo.DataPropertyName = "Estilo";
            this.Estilo.HeaderText = "Estilo";
            this.Estilo.Name = "Estilo";
            this.Estilo.ReadOnly = true;
            // 
            // Config
            // 
            this.Config.DataPropertyName = "Configuracao";
            this.Config.HeaderText = "Config";
            this.Config.Name = "Config";
            this.Config.ReadOnly = true;
            // 
            // Un
            // 
            this.Un.DataPropertyName = "Unidade";
            this.Un.HeaderText = "Un";
            this.Un.Name = "Un";
            this.Un.ReadOnly = true;
            this.Un.Width = 40;
            // 
            // Qtde
            // 
            this.Qtde.DataPropertyName = "Quantidade";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Qtde.DefaultCellStyle = dataGridViewCellStyle1;
            this.Qtde.HeaderText = "Qtde Vendas";
            this.Qtde.Name = "Qtde";
            this.Qtde.ReadOnly = true;
            // 
            // Estoque
            // 
            this.Estoque.DataPropertyName = "Estoque";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Estoque.DefaultCellStyle = dataGridViewCellStyle2;
            this.Estoque.HeaderText = "Estoque";
            this.Estoque.Name = "Estoque";
            this.Estoque.ReadOnly = true;
            this.Estoque.Width = 70;
            // 
            // Demanda
            // 
            this.Demanda.DataPropertyName = "DemandaProducao";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Demanda.DefaultCellStyle = dataGridViewCellStyle3;
            this.Demanda.HeaderText = "Demanda";
            this.Demanda.Name = "Demanda";
            this.Demanda.ReadOnly = true;
            this.Demanda.Width = 70;
            // 
            // frmDemandaProducao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 540);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmDemandaProducao";
            this.Text = "Demanda de Produção";
            this.Load += new System.EventHandler(this.frmPedidoCompras_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNovo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem planilhaExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arquivoSeparadoPorVírgulacsvToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVariantesCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVariantesTamanho;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVariantesEstilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVariantesConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tamanho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Config;
        private System.Windows.Forms.DataGridViewTextBoxColumn Un;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn Demanda;
    }
}