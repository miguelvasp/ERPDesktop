namespace ERP
{
    partial class frmRoteiroOperacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoteiroOperacao));
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.dgLinhas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddLinhas = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTipoVinculo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTaxaTarefa = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProximo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPorcentagemSucata = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAcumulado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSequencia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrioridade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAtividade = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgLinhas)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.btnAdiciona);
            this.ribbonPanel1.Items.Add(this.btnAlterar);
            this.ribbonPanel1.Items.Add(this.btnGrava);
            this.ribbonPanel1.Items.Add(this.btnCancelar);
            this.ribbonPanel1.Items.Add(this.btnExcluir);
            this.ribbonPanel1.Text = "Informações";
            // 
            // btnAdiciona
            // 
            this.btnAdiciona.Image = ((System.Drawing.Image)(resources.GetObject("btnAdiciona.Image")));
            this.btnAdiciona.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAdiciona.SmallImage")));
            this.btnAdiciona.Text = "Adicionar";
            this.btnAdiciona.Click += new System.EventHandler(this.btnAdiciona_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAlterar.SmallImage")));
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnGrava
            // 
            this.btnGrava.Enabled = false;
            this.btnGrava.Image = ((System.Drawing.Image)(resources.GetObject("btnGrava.Image")));
            this.btnGrava.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGrava.SmallImage")));
            this.btnGrava.Text = "Gravar";
            this.btnGrava.Click += new System.EventHandler(this.btnGrava_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.SmallImage")));
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnExcluir.SmallImage")));
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // rbOpcoes
            // 
            this.rbOpcoes.Panels.Add(this.ribbonPanel1);
            this.rbOpcoes.Text = "Documento";
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            this.ribbon1.OrbDropDown.Visible = false;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbVisible = false;
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(784, 125);
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // dgLinhas
            // 
            this.dgLinhas.AllowUserToAddRows = false;
            this.dgLinhas.AllowUserToDeleteRows = false;
            this.dgLinhas.BackgroundColor = System.Drawing.Color.White;
            this.dgLinhas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLinhas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgLinhas.Location = new System.Drawing.Point(27, 281);
            this.dgLinhas.Name = "dgLinhas";
            this.dgLinhas.ReadOnly = true;
            this.dgLinhas.RowHeadersVisible = false;
            this.dgLinhas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLinhas.Size = new System.Drawing.Size(732, 268);
            this.dgLinhas.TabIndex = 35;
            this.dgLinhas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLinhas_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CodigoItem";
            this.Column2.HeaderText = "Código Item";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Produto";
            this.Column3.HeaderText = "Produto";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "GrupoLancamento";
            this.Column4.HeaderText = "Grupo Lançamento";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "GrupoRoteiro";
            this.Column5.HeaderText = "Grupo Roteiro";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // btnAddLinhas
            // 
            this.btnAddLinhas.Location = new System.Drawing.Point(27, 252);
            this.btnAddLinhas.Name = "btnAddLinhas";
            this.btnAddLinhas.Size = new System.Drawing.Size(147, 23);
            this.btnAddLinhas.TabIndex = 34;
            this.btnAddLinhas.Text = "Adicionar Linhas";
            this.btnAddLinhas.UseVisualStyleBackColor = true;
            this.btnAddLinhas.Click += new System.EventHandler(this.btnAddLinhas_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(481, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Tipo de Vínculo";
            // 
            // cboTipoVinculo
            // 
            this.cboTipoVinculo.FormattingEnabled = true;
            this.cboTipoVinculo.Location = new System.Drawing.Point(484, 210);
            this.cboTipoVinculo.Name = "cboTipoVinculo";
            this.cboTipoVinculo.Size = new System.Drawing.Size(206, 21);
            this.cboTipoVinculo.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(277, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Taxa por Tarefa";
            // 
            // cboTaxaTarefa
            // 
            this.cboTaxaTarefa.FormattingEnabled = true;
            this.cboTaxaTarefa.Location = new System.Drawing.Point(280, 209);
            this.cboTaxaTarefa.Name = "cboTaxaTarefa";
            this.cboTaxaTarefa.Size = new System.Drawing.Size(198, 21);
            this.cboTaxaTarefa.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Próximo";
            // 
            // txtProximo
            // 
            this.txtProximo.Location = new System.Drawing.Point(174, 210);
            this.txtProximo.Name = "txtProximo";
            this.txtProximo.Size = new System.Drawing.Size(100, 20);
            this.txtProximo.TabIndex = 28;
            this.txtProximo.Tag = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Porcentagem de Sucata";
            // 
            // txtPorcentagemSucata
            // 
            this.txtPorcentagemSucata.Location = new System.Drawing.Point(27, 210);
            this.txtPorcentagemSucata.Name = "txtPorcentagemSucata";
            this.txtPorcentagemSucata.Size = new System.Drawing.Size(141, 20);
            this.txtPorcentagemSucata.TabIndex = 26;
            this.txtPorcentagemSucata.Tag = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(587, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Acumulado";
            // 
            // txtAcumulado
            // 
            this.txtAcumulado.Location = new System.Drawing.Point(590, 153);
            this.txtAcumulado.Name = "txtAcumulado";
            this.txtAcumulado.Size = new System.Drawing.Size(100, 20);
            this.txtAcumulado.TabIndex = 24;
            this.txtAcumulado.Tag = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(481, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Sequência";
            // 
            // txtSequencia
            // 
            this.txtSequencia.Location = new System.Drawing.Point(484, 153);
            this.txtSequencia.Name = "txtSequencia";
            this.txtSequencia.Size = new System.Drawing.Size(100, 20);
            this.txtSequencia.TabIndex = 22;
            this.txtSequencia.Tag = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Prioridade";
            // 
            // txtPrioridade
            // 
            this.txtPrioridade.Location = new System.Drawing.Point(378, 153);
            this.txtPrioridade.Name = "txtPrioridade";
            this.txtPrioridade.Size = new System.Drawing.Size(100, 20);
            this.txtPrioridade.TabIndex = 20;
            this.txtPrioridade.Tag = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Atividade";
            // 
            // txtAtividade
            // 
            this.txtAtividade.Location = new System.Drawing.Point(27, 153);
            this.txtAtividade.Name = "txtAtividade";
            this.txtAtividade.Size = new System.Drawing.Size(345, 20);
            this.txtAtividade.TabIndex = 18;
            // 
            // frmRoteiroOperacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dgLinhas);
            this.Controls.Add(this.btnAddLinhas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboTipoVinculo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboTaxaTarefa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtProximo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPorcentagemSucata);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAcumulado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSequencia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrioridade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAtividade);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 505);
            this.Name = "frmRoteiroOperacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmCalendarioCad";
            this.Text = "Roteiro Operação";
            this.Load += new System.EventHandler(this.frmAutoridadeCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAutoridadeCad_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgLinhas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.DataGridView dgLinhas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button btnAddLinhas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboTipoVinculo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboTaxaTarefa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProximo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPorcentagemSucata;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAcumulado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSequencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrioridade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAtividade;
    }
}