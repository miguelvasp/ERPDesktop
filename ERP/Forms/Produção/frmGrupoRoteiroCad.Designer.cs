namespace ERP
{
    partial class frmGrupoRoteiroCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoRoteiroCad));
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.Descrição = new System.Windows.Forms.Label();
            this.chkCalcularTempoPreparacao = new System.Windows.Forms.CheckBox();
            this.chkCalcularTempoExecusao = new System.Windows.Forms.CheckBox();
            this.chkCalcularQuantidade = new System.Windows.Forms.CheckBox();
            this.chkConsumoAutomaticoTempoExecusao = new System.Windows.Forms.CheckBox();
            this.chkConsumoAutomaticoTempoPreparacao = new System.Windows.Forms.CheckBox();
            this.chkRelatarQuantidadeComoConcluida = new System.Windows.Forms.CheckBox();
            this.chkRelatarOperacaoComoConcluida = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnExcluir.SmallImage")));
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.SmallImage")));
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrava
            // 
            this.btnGrava.Enabled = false;
            this.btnGrava.Image = ((System.Drawing.Image)(resources.GetObject("btnGrava.Image")));
            this.btnGrava.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGrava.SmallImage")));
            this.btnGrava.Text = "Gravar";
            this.btnGrava.Click += new System.EventHandler(this.btnGrava_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAlterar.SmallImage")));
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnAdiciona
            // 
            this.btnAdiciona.Image = ((System.Drawing.Image)(resources.GetObject("btnAdiciona.Image")));
            this.btnAdiciona.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAdiciona.SmallImage")));
            this.btnAdiciona.Text = "Adicionar";
            this.btnAdiciona.Click += new System.EventHandler(this.btnAdiciona_Click);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Adicionar Linha";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(29, 155);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(391, 20);
            this.txtDescricao.TabIndex = 26;
            this.txtDescricao.Tag = "1";
            // 
            // Descrição
            // 
            this.Descrição.AutoSize = true;
            this.Descrição.Location = new System.Drawing.Point(26, 139);
            this.Descrição.Name = "Descrição";
            this.Descrição.Size = new System.Drawing.Size(55, 13);
            this.Descrição.TabIndex = 27;
            this.Descrição.Text = "Descrição";
            // 
            // chkCalcularTempoPreparacao
            // 
            this.chkCalcularTempoPreparacao.AutoSize = true;
            this.chkCalcularTempoPreparacao.Location = new System.Drawing.Point(29, 187);
            this.chkCalcularTempoPreparacao.Name = "chkCalcularTempoPreparacao";
            this.chkCalcularTempoPreparacao.Size = new System.Drawing.Size(177, 17);
            this.chkCalcularTempoPreparacao.TabIndex = 28;
            this.chkCalcularTempoPreparacao.Text = "Calcular o tempo de preparação";
            this.chkCalcularTempoPreparacao.UseVisualStyleBackColor = true;
            // 
            // chkCalcularTempoExecusao
            // 
            this.chkCalcularTempoExecusao.AutoSize = true;
            this.chkCalcularTempoExecusao.Location = new System.Drawing.Point(282, 187);
            this.chkCalcularTempoExecusao.Name = "chkCalcularTempoExecusao";
            this.chkCalcularTempoExecusao.Size = new System.Drawing.Size(161, 17);
            this.chkCalcularTempoExecusao.TabIndex = 29;
            this.chkCalcularTempoExecusao.Text = "Calcular tempo de execução";
            this.chkCalcularTempoExecusao.UseVisualStyleBackColor = true;
            // 
            // chkCalcularQuantidade
            // 
            this.chkCalcularQuantidade.AutoSize = true;
            this.chkCalcularQuantidade.Location = new System.Drawing.Point(532, 187);
            this.chkCalcularQuantidade.Name = "chkCalcularQuantidade";
            this.chkCalcularQuantidade.Size = new System.Drawing.Size(129, 17);
            this.chkCalcularQuantidade.TabIndex = 30;
            this.chkCalcularQuantidade.Text = "Calcular a quantidade";
            this.chkCalcularQuantidade.UseVisualStyleBackColor = true;
            // 
            // chkConsumoAutomaticoTempoExecusao
            // 
            this.chkConsumoAutomaticoTempoExecusao.AutoSize = true;
            this.chkConsumoAutomaticoTempoExecusao.Location = new System.Drawing.Point(29, 210);
            this.chkConsumoAutomaticoTempoExecusao.Name = "chkConsumoAutomaticoTempoExecusao";
            this.chkConsumoAutomaticoTempoExecusao.Size = new System.Drawing.Size(225, 17);
            this.chkConsumoAutomaticoTempoExecusao.TabIndex = 31;
            this.chkConsumoAutomaticoTempoExecusao.Text = "Consumo automático, tempo de execução";
            this.chkConsumoAutomaticoTempoExecusao.UseVisualStyleBackColor = true;
            // 
            // chkConsumoAutomaticoTempoPreparacao
            // 
            this.chkConsumoAutomaticoTempoPreparacao.AutoSize = true;
            this.chkConsumoAutomaticoTempoPreparacao.Location = new System.Drawing.Point(282, 210);
            this.chkConsumoAutomaticoTempoPreparacao.Name = "chkConsumoAutomaticoTempoPreparacao";
            this.chkConsumoAutomaticoTempoPreparacao.Size = new System.Drawing.Size(232, 17);
            this.chkConsumoAutomaticoTempoPreparacao.TabIndex = 32;
            this.chkConsumoAutomaticoTempoPreparacao.Text = "Consumo automático, tempo de preparação";
            this.chkConsumoAutomaticoTempoPreparacao.UseVisualStyleBackColor = true;
            // 
            // chkRelatarQuantidadeComoConcluida
            // 
            this.chkRelatarQuantidadeComoConcluida.AutoSize = true;
            this.chkRelatarQuantidadeComoConcluida.Location = new System.Drawing.Point(29, 233);
            this.chkRelatarQuantidadeComoConcluida.Name = "chkRelatarQuantidadeComoConcluida";
            this.chkRelatarQuantidadeComoConcluida.Size = new System.Drawing.Size(289, 17);
            this.chkRelatarQuantidadeComoConcluida.TabIndex = 33;
            this.chkRelatarQuantidadeComoConcluida.Text = "Relatar automaticamente a quantidade como concluída";
            this.chkRelatarQuantidadeComoConcluida.UseVisualStyleBackColor = true;
            // 
            // chkRelatarOperacaoComoConcluida
            // 
            this.chkRelatarOperacaoComoConcluida.AutoSize = true;
            this.chkRelatarOperacaoComoConcluida.Location = new System.Drawing.Point(532, 210);
            this.chkRelatarOperacaoComoConcluida.Name = "chkRelatarOperacaoComoConcluida";
            this.chkRelatarOperacaoComoConcluida.Size = new System.Drawing.Size(188, 17);
            this.chkRelatarOperacaoComoConcluida.TabIndex = 34;
            this.chkRelatarOperacaoComoConcluida.Text = "Relatar operação como concluída";
            this.chkRelatarOperacaoComoConcluida.UseVisualStyleBackColor = true;
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
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(29, 294);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(743, 255);
            this.dataGridView1.TabIndex = 35;
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
            this.Column2.Width = 270;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Ativacao";
            this.Column3.HeaderText = "Ativação";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 90;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Capacidade";
            this.Column4.HeaderText = "Capacidade";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 90;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Gerenciamento";
            this.Column5.HeaderText = "G. Trabalho";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Horario";
            this.Column6.HeaderText = "Horário Trabalho";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 120;
            // 
            // frmGrupoRoteiroCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chkRelatarOperacaoComoConcluida);
            this.Controls.Add(this.chkRelatarQuantidadeComoConcluida);
            this.Controls.Add(this.chkConsumoAutomaticoTempoPreparacao);
            this.Controls.Add(this.chkConsumoAutomaticoTempoExecusao);
            this.Controls.Add(this.chkCalcularQuantidade);
            this.Controls.Add(this.chkCalcularTempoExecusao);
            this.Controls.Add(this.chkCalcularTempoPreparacao);
            this.Controls.Add(this.Descrição);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 505);
            this.Name = "frmGrupoRoteiroCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmGrupoRoteiroCad";
            this.Text = "Grupo Roteiro";
            this.Load += new System.EventHandler(this.frmAutoridadeCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAutoridadeCad_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label Descrição;
        private System.Windows.Forms.CheckBox chkCalcularTempoPreparacao;
        private System.Windows.Forms.CheckBox chkCalcularTempoExecusao;
        private System.Windows.Forms.CheckBox chkCalcularQuantidade;
        private System.Windows.Forms.CheckBox chkConsumoAutomaticoTempoExecusao;
        private System.Windows.Forms.CheckBox chkConsumoAutomaticoTempoPreparacao;
        private System.Windows.Forms.CheckBox chkRelatarQuantidadeComoConcluida;
        private System.Windows.Forms.CheckBox chkRelatarOperacaoComoConcluida;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}