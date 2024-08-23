namespace ERP
{
    partial class frmBuscaProduto
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.cboDescricao = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboConfiguracao = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTamanho = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboEstilo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboGrupoVariantes = new System.Windows.Forms.ComboBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.IdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdVariantesGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdVariantesCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdVariantesEstilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdVariantesTamanho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdVariantesConfig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.cboProdutoAcabadoMateriaPrima = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.cboProdutoAcabadoMateriaPrima);
            this.panel1.Controls.Add(this.btnSelecionar);
            this.panel1.Controls.Add(this.cboDescricao);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.btnPesquisar);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cboConfiguracao);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboTamanho);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboEstilo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboCor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboGrupoVariantes);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1077, 152);
            this.panel1.TabIndex = 0;
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Location = new System.Drawing.Point(946, 59);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(119, 28);
            this.btnSelecionar.TabIndex = 28;
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // cboDescricao
            // 
            this.cboDescricao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDescricao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDescricao.DropDownWidth = 600;
            this.cboDescricao.FormattingEnabled = true;
            this.cboDescricao.Location = new System.Drawing.Point(546, 59);
            this.cboDescricao.Name = "cboDescricao";
            this.cboDescricao.Size = new System.Drawing.Size(359, 21);
            this.cboDescricao.TabIndex = 2;
            this.cboDescricao.SelectedIndexChanged += new System.EventHandler(this.cboDescricao_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImage = global::ERP.Properties.Resources.fundo;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1077, 37);
            this.toolStrip1.TabIndex = 27;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(322, 34);
            this.toolStripLabel1.Text = "Utilize os filtros para pesquisar nos produtos";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(946, 98);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(119, 28);
            this.btnPesquisar.TabIndex = 14;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(440, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Configuração";
            // 
            // cboConfiguracao
            // 
            this.cboConfiguracao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboConfiguracao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboConfiguracao.FormattingEnabled = true;
            this.cboConfiguracao.Location = new System.Drawing.Point(443, 106);
            this.cboConfiguracao.Name = "cboConfiguracao";
            this.cboConfiguracao.Size = new System.Drawing.Size(221, 21);
            this.cboConfiguracao.TabIndex = 6;
            this.cboConfiguracao.SelectedIndexChanged += new System.EventHandler(this.cboGrupoVariantes_SelectedIndexChanged);
            this.cboConfiguracao.Leave += new System.EventHandler(this.cboConfiguracao_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(273, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tamanho";
            // 
            // cboTamanho
            // 
            this.cboTamanho.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTamanho.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTamanho.FormattingEnabled = true;
            this.cboTamanho.Location = new System.Drawing.Point(273, 106);
            this.cboTamanho.Name = "cboTamanho";
            this.cboTamanho.Size = new System.Drawing.Size(164, 21);
            this.cboTamanho.TabIndex = 5;
            this.cboTamanho.SelectedIndexChanged += new System.EventHandler(this.cboGrupoVariantes_SelectedIndexChanged);
            this.cboTamanho.Leave += new System.EventHandler(this.cboTamanho_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Estilo";
            // 
            // cboEstilo
            // 
            this.cboEstilo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEstilo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEstilo.FormattingEnabled = true;
            this.cboEstilo.Location = new System.Drawing.Point(113, 106);
            this.cboEstilo.Name = "cboEstilo";
            this.cboEstilo.Size = new System.Drawing.Size(154, 21);
            this.cboEstilo.TabIndex = 4;
            this.cboEstilo.SelectedIndexChanged += new System.EventHandler(this.cboGrupoVariantes_SelectedIndexChanged);
            this.cboEstilo.Leave += new System.EventHandler(this.cboEstilo_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cor";
            // 
            // cboCor
            // 
            this.cboCor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCor.DropDownWidth = 300;
            this.cboCor.FormattingEnabled = true;
            this.cboCor.Location = new System.Drawing.Point(373, 59);
            this.cboCor.Name = "cboCor";
            this.cboCor.Size = new System.Drawing.Size(167, 21);
            this.cboCor.TabIndex = 1;
            this.cboCor.SelectedIndexChanged += new System.EventHandler(this.cboGrupoVariantes_SelectedIndexChanged);
            this.cboCor.Leave += new System.EventHandler(this.cboCor_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Grupo de Variantes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(543, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descrição";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Código";
            // 
            // cboGrupoVariantes
            // 
            this.cboGrupoVariantes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboGrupoVariantes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoVariantes.DropDownWidth = 600;
            this.cboGrupoVariantes.FormattingEnabled = true;
            this.cboGrupoVariantes.Location = new System.Drawing.Point(12, 59);
            this.cboGrupoVariantes.Name = "cboGrupoVariantes";
            this.cboGrupoVariantes.Size = new System.Drawing.Size(355, 21);
            this.cboGrupoVariantes.TabIndex = 0;
            this.cboGrupoVariantes.SelectedIndexChanged += new System.EventHandler(this.cboGrupoVariantes_SelectedIndexChanged);
            this.cboGrupoVariantes.Leave += new System.EventHandler(this.cboGrupoVariantes_Leave);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(12, 107);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(95, 20);
            this.txtCodigo.TabIndex = 3;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
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
            this.IdProduto,
            this.IdVariantesGrupo,
            this.IdVariantesCor,
            this.IdVariantesEstilo,
            this.IdVariantesTamanho,
            this.IdVariantesConfig,
            this.Column3,
            this.Column5,
            this.Column2,
            this.Column1,
            this.Column4,
            this.Column7,
            this.Column9});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 152);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 18;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1077, 508);
            this.dgv.TabIndex = 1;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // IdProduto
            // 
            this.IdProduto.DataPropertyName = "IdProduto";
            this.IdProduto.HeaderText = "IdProduto";
            this.IdProduto.Name = "IdProduto";
            this.IdProduto.ReadOnly = true;
            this.IdProduto.Visible = false;
            // 
            // IdVariantesGrupo
            // 
            this.IdVariantesGrupo.DataPropertyName = "IdVariantesGrupo";
            this.IdVariantesGrupo.HeaderText = "IdVariantesGrupo";
            this.IdVariantesGrupo.Name = "IdVariantesGrupo";
            this.IdVariantesGrupo.ReadOnly = true;
            this.IdVariantesGrupo.Visible = false;
            // 
            // IdVariantesCor
            // 
            this.IdVariantesCor.DataPropertyName = "IdVariantesCor";
            this.IdVariantesCor.HeaderText = "IdVariantesCor";
            this.IdVariantesCor.Name = "IdVariantesCor";
            this.IdVariantesCor.ReadOnly = true;
            this.IdVariantesCor.Visible = false;
            // 
            // IdVariantesEstilo
            // 
            this.IdVariantesEstilo.DataPropertyName = "IdVariantesEstilo";
            this.IdVariantesEstilo.HeaderText = "IdVariantesEstilo";
            this.IdVariantesEstilo.Name = "IdVariantesEstilo";
            this.IdVariantesEstilo.ReadOnly = true;
            this.IdVariantesEstilo.Visible = false;
            // 
            // IdVariantesTamanho
            // 
            this.IdVariantesTamanho.DataPropertyName = "IdVariantesTamanho";
            this.IdVariantesTamanho.HeaderText = "IdVariantesTamanho";
            this.IdVariantesTamanho.Name = "IdVariantesTamanho";
            this.IdVariantesTamanho.ReadOnly = true;
            this.IdVariantesTamanho.Visible = false;
            // 
            // IdVariantesConfig
            // 
            this.IdVariantesConfig.DataPropertyName = "IdVariantesConfig";
            this.IdVariantesConfig.HeaderText = "IdVariantesConfig";
            this.IdVariantesConfig.Name = "IdVariantesConfig";
            this.IdVariantesConfig.ReadOnly = true;
            this.IdVariantesConfig.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Grupo";
            this.Column3.HeaderText = "Grupo Variantes";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "COR";
            this.Column5.HeaderText = "Cor";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Descricao";
            this.Column2.HeaderText = "Descrição";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 250;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Codigo";
            this.Column1.HeaderText = "Código";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ESTILO";
            this.Column4.HeaderText = "Estilo";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "TAMANHO";
            this.Column7.HeaderText = "Tamanho";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 200;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "CONFIG";
            this.Column9.HeaderText = "Configuração";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 200;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::ERP.Properties.Resources.fundo1;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 605);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1077, 55);
            this.panel2.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Selecionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(148, 15);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(119, 28);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(667, 90);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(159, 13);
            this.label19.TabIndex = 30;
            this.label19.Text = "Produto Acabado/Matéria Prima";
            // 
            // cboProdutoAcabadoMateriaPrima
            // 
            this.cboProdutoAcabadoMateriaPrima.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProdutoAcabadoMateriaPrima.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProdutoAcabadoMateriaPrima.FormattingEnabled = true;
            this.cboProdutoAcabadoMateriaPrima.Location = new System.Drawing.Point(670, 106);
            this.cboProdutoAcabadoMateriaPrima.Name = "cboProdutoAcabadoMateriaPrima";
            this.cboProdutoAcabadoMateriaPrima.Size = new System.Drawing.Size(235, 21);
            this.cboProdutoAcabadoMateriaPrima.TabIndex = 29;
            this.cboProdutoAcabadoMateriaPrima.Tag = "1";
            // 
            // frmBuscaProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1077, 660);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmBuscaProduto";
            this.Text = "Busca de Produtos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboConfiguracao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTamanho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboEstilo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboGrupoVariantes;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ComboBox cboDescricao;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVariantesGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVariantesCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVariantesEstilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVariantesTamanho;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVariantesConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboProdutoAcabadoMateriaPrima;
    }
}