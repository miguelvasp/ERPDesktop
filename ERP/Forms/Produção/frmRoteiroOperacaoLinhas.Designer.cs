namespace ERP
{
    partial class frmRoteiroOperacaoLinhas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoteiroOperacaoLinhas));
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.cboCodigoItem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboProduto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboGrupoLancamento = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GrupoRoteiro = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboArmazem = new System.Windows.Forms.ComboBox();
            this.txtCarregar = new System.Windows.Forms.TextBox();
            this.txtQtdeRecursos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtValorCustoOperacao = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVAlorCustoQuantidade = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFator = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboFormula = new System.Windows.Forms.ComboBox();
            this.btnAddRecursos = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Text = "Opções";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.ribbonButton1);
            this.ribbonPanel1.Items.Add(this.ribbonButton2);
            this.ribbonPanel1.Text = "";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = global::ERP.Properties.Resources.save32;
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "Gravar";
            this.ribbonButton1.Click += new System.EventHandler(this.ribbonButton1_Click);
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = global::ERP.Properties.Resources.Close_2_icon;
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "excluir";
            this.ribbonButton2.Click += new System.EventHandler(this.ribbonButton2_Click);
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(784, 145);
            this.ribbon1.TabIndex = 5;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // cboCodigoItem
            // 
            this.cboCodigoItem.FormattingEnabled = true;
            this.cboCodigoItem.Location = new System.Drawing.Point(21, 176);
            this.cboCodigoItem.Name = "cboCodigoItem";
            this.cboCodigoItem.Size = new System.Drawing.Size(223, 21);
            this.cboCodigoItem.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Código Item";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Produto";
            // 
            // cboProduto
            // 
            this.cboProduto.FormattingEnabled = true;
            this.cboProduto.Location = new System.Drawing.Point(250, 176);
            this.cboProduto.Name = "cboProduto";
            this.cboProduto.Size = new System.Drawing.Size(272, 21);
            this.cboProduto.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(525, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Grupo Lançamento";
            // 
            // cboGrupoLancamento
            // 
            this.cboGrupoLancamento.FormattingEnabled = true;
            this.cboGrupoLancamento.Location = new System.Drawing.Point(528, 176);
            this.cboGrupoLancamento.Name = "cboGrupoLancamento";
            this.cboGrupoLancamento.Size = new System.Drawing.Size(239, 21);
            this.cboGrupoLancamento.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Grupo de Roteiros";
            // 
            // GrupoRoteiro
            // 
            this.GrupoRoteiro.FormattingEnabled = true;
            this.GrupoRoteiro.Location = new System.Drawing.Point(21, 225);
            this.GrupoRoteiro.Name = "GrupoRoteiro";
            this.GrupoRoteiro.Size = new System.Drawing.Size(223, 21);
            this.GrupoRoteiro.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(247, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Armazém";
            // 
            // cboArmazem
            // 
            this.cboArmazem.FormattingEnabled = true;
            this.cboArmazem.Location = new System.Drawing.Point(250, 225);
            this.cboArmazem.Name = "cboArmazem";
            this.cboArmazem.Size = new System.Drawing.Size(272, 21);
            this.cboArmazem.TabIndex = 14;
            // 
            // txtCarregar
            // 
            this.txtCarregar.Location = new System.Drawing.Point(528, 225);
            this.txtCarregar.Name = "txtCarregar";
            this.txtCarregar.Size = new System.Drawing.Size(117, 20);
            this.txtCarregar.TabIndex = 16;
            this.txtCarregar.Tag = "3";
            // 
            // txtQtdeRecursos
            // 
            this.txtQtdeRecursos.Location = new System.Drawing.Point(650, 225);
            this.txtQtdeRecursos.Name = "txtQtdeRecursos";
            this.txtQtdeRecursos.Size = new System.Drawing.Size(117, 20);
            this.txtQtdeRecursos.TabIndex = 17;
            this.txtQtdeRecursos.Tag = "3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(525, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Carregar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(647, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Qtde. Recursos";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Custo de Preparação";
            // 
            // txtValorCustoOperacao
            // 
            this.txtValorCustoOperacao.Location = new System.Drawing.Point(21, 275);
            this.txtValorCustoOperacao.Name = "txtValorCustoOperacao";
            this.txtValorCustoOperacao.Size = new System.Drawing.Size(161, 20);
            this.txtValorCustoOperacao.TabIndex = 20;
            this.txtValorCustoOperacao.Tag = "3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(185, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Custo Quantidade";
            // 
            // txtVAlorCustoQuantidade
            // 
            this.txtVAlorCustoQuantidade.Location = new System.Drawing.Point(188, 275);
            this.txtVAlorCustoQuantidade.Name = "txtVAlorCustoQuantidade";
            this.txtVAlorCustoQuantidade.Size = new System.Drawing.Size(161, 20);
            this.txtVAlorCustoQuantidade.TabIndex = 22;
            this.txtVAlorCustoQuantidade.Tag = "3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(352, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Fator";
            // 
            // txtFator
            // 
            this.txtFator.Location = new System.Drawing.Point(355, 275);
            this.txtFator.Name = "txtFator";
            this.txtFator.Size = new System.Drawing.Size(167, 20);
            this.txtFator.TabIndex = 24;
            this.txtFator.Tag = "3";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(525, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Fórmula";
            // 
            // cboFormula
            // 
            this.cboFormula.FormattingEnabled = true;
            this.cboFormula.Location = new System.Drawing.Point(528, 274);
            this.cboFormula.Name = "cboFormula";
            this.cboFormula.Size = new System.Drawing.Size(239, 21);
            this.cboFormula.TabIndex = 26;
            // 
            // btnAddRecursos
            // 
            this.btnAddRecursos.Location = new System.Drawing.Point(21, 311);
            this.btnAddRecursos.Name = "btnAddRecursos";
            this.btnAddRecursos.Size = new System.Drawing.Size(161, 23);
            this.btnAddRecursos.TabIndex = 28;
            this.btnAddRecursos.Text = "Adicionar Recursos";
            this.btnAddRecursos.UseVisualStyleBackColor = true;
            this.btnAddRecursos.Click += new System.EventHandler(this.btnAddRecursos_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(21, 340);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(746, 209);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.HeaderText = "Column1";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Tipo";
            this.Column2.HeaderText = "Tipo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Recurso";
            this.Column3.HeaderText = "Recurso";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "CapacidadeRecurso";
            this.Column4.HeaderText = "Capacidade Recurso";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "GrupoRecurso";
            this.Column5.HeaderText = "Grupo Recurso";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // frmRoteiroOperacaoLinhas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAddRecursos);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboFormula);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtFator);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtVAlorCustoQuantidade);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtValorCustoOperacao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtQtdeRecursos);
            this.Controls.Add(this.txtCarregar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboArmazem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GrupoRoteiro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboGrupoLancamento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboProduto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCodigoItem);
            this.Controls.Add(this.ribbon1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRoteiroOperacaoLinhas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roteiro Operação Linhas";
            this.Load += new System.EventHandler(this.frmConfGrupoImpostoRetidoCad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.ComboBox cboCodigoItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboProduto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboGrupoLancamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox GrupoRoteiro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboArmazem;
        private System.Windows.Forms.TextBox txtCarregar;
        private System.Windows.Forms.TextBox txtQtdeRecursos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtValorCustoOperacao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVAlorCustoQuantidade;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFator;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboFormula;
        private System.Windows.Forms.Button btnAddRecursos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}