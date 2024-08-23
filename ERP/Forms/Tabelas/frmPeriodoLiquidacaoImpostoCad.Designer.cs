namespace ERP
{
    partial class frmPeriodoLiquidacaoImpostoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPeriodoLiquidacaoImpostoCad));
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboCondicao = new System.Windows.Forms.ComboBox();
            this.lblAutoridade = new System.Windows.Forms.Label();
            this.cboAutoridade = new System.Windows.Forms.ComboBox();
            this.cboIntervaloPeriodo = new System.Windows.Forms.ComboBox();
            this.lblIntervaloPeriodo = new System.Windows.Forms.Label();
            this.txtNumeroUnidade = new System.Windows.Forms.TextBox();
            this.lblNumeroUnidade = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgVencimentos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgVencimentos)).BeginInit();
            this.SuspendLayout();
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
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnExcluir.SmallImage")));
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(25, 154);
            this.txtCodigo.MaxLength = 12;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(185, 20);
            this.txtCodigo.TabIndex = 15;
            this.txtCodigo.Tag = "1";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(22, 138);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 14;
            this.lblCodigo.Text = "Código";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(12, 128);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 13;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
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
            this.ribbon1.Size = new System.Drawing.Size(761, 125);
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(216, 154);
            this.txtDescricao.MaxLength = 40;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(303, 20);
            this.txtDescricao.TabIndex = 17;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(213, 138);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 16;
            this.lblDescricao.Text = "Descrição";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(522, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Condição Pagamento";
            // 
            // cboCondicao
            // 
            this.cboCondicao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCondicao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCondicao.FormattingEnabled = true;
            this.cboCondicao.Location = new System.Drawing.Point(525, 154);
            this.cboCondicao.Name = "cboCondicao";
            this.cboCondicao.Size = new System.Drawing.Size(217, 21);
            this.cboCondicao.TabIndex = 19;
            this.cboCondicao.Tag = "1";
            // 
            // lblAutoridade
            // 
            this.lblAutoridade.AutoSize = true;
            this.lblAutoridade.Location = new System.Drawing.Point(22, 197);
            this.lblAutoridade.Name = "lblAutoridade";
            this.lblAutoridade.Size = new System.Drawing.Size(58, 13);
            this.lblAutoridade.TabIndex = 20;
            this.lblAutoridade.Text = "Autoridade";
            // 
            // cboAutoridade
            // 
            this.cboAutoridade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboAutoridade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAutoridade.FormattingEnabled = true;
            this.cboAutoridade.Location = new System.Drawing.Point(25, 213);
            this.cboAutoridade.Name = "cboAutoridade";
            this.cboAutoridade.Size = new System.Drawing.Size(217, 21);
            this.cboAutoridade.TabIndex = 21;
            this.cboAutoridade.Tag = "1";
            // 
            // cboIntervaloPeriodo
            // 
            this.cboIntervaloPeriodo.FormattingEnabled = true;
            this.cboIntervaloPeriodo.Location = new System.Drawing.Point(248, 213);
            this.cboIntervaloPeriodo.Name = "cboIntervaloPeriodo";
            this.cboIntervaloPeriodo.Size = new System.Drawing.Size(217, 21);
            this.cboIntervaloPeriodo.TabIndex = 23;
            this.cboIntervaloPeriodo.Tag = "1";
            // 
            // lblIntervaloPeriodo
            // 
            this.lblIntervaloPeriodo.AutoSize = true;
            this.lblIntervaloPeriodo.Location = new System.Drawing.Point(245, 197);
            this.lblIntervaloPeriodo.Name = "lblIntervaloPeriodo";
            this.lblIntervaloPeriodo.Size = new System.Drawing.Size(104, 13);
            this.lblIntervaloPeriodo.TabIndex = 22;
            this.lblIntervaloPeriodo.Text = "Intervalo do Período";
            // 
            // txtNumeroUnidade
            // 
            this.txtNumeroUnidade.Location = new System.Drawing.Point(471, 213);
            this.txtNumeroUnidade.MaxLength = 4;
            this.txtNumeroUnidade.Name = "txtNumeroUnidade";
            this.txtNumeroUnidade.Size = new System.Drawing.Size(120, 20);
            this.txtNumeroUnidade.TabIndex = 25;
            this.txtNumeroUnidade.Tag = "1";
            this.txtNumeroUnidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroUnidade_KeyPress);
            // 
            // lblNumeroUnidade
            // 
            this.lblNumeroUnidade.AutoSize = true;
            this.lblNumeroUnidade.Location = new System.Drawing.Point(468, 197);
            this.lblNumeroUnidade.Name = "lblNumeroUnidade";
            this.lblNumeroUnidade.Size = new System.Drawing.Size(87, 13);
            this.lblNumeroUnidade.TabIndex = 24;
            this.lblNumeroUnidade.Text = "Número Unidade";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Adicionar Período";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgVencimentos
            // 
            this.dgVencimentos.AllowUserToAddRows = false;
            this.dgVencimentos.AllowUserToDeleteRows = false;
            this.dgVencimentos.BackgroundColor = System.Drawing.Color.White;
            this.dgVencimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVencimentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgVencimentos.Location = new System.Drawing.Point(25, 286);
            this.dgVencimentos.Name = "dgVencimentos";
            this.dgVencimentos.ReadOnly = true;
            this.dgVencimentos.RowHeadersVisible = false;
            this.dgVencimentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVencimentos.Size = new System.Drawing.Size(717, 241);
            this.dgVencimentos.TabIndex = 27;
            this.dgVencimentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVencimentos_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IdPeriodoLiquidacaoImpostoVenc";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "De";
            this.Column2.HeaderText = "De";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 250;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Ate";
            this.Column3.HeaderText = "Ate";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // frmPeriodoLiquidacaoImpostoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(761, 539);
            this.Controls.Add(this.dgVencimentos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNumeroUnidade);
            this.Controls.Add(this.lblNumeroUnidade);
            this.Controls.Add(this.cboIntervaloPeriodo);
            this.Controls.Add(this.lblIntervaloPeriodo);
            this.Controls.Add(this.lblAutoridade);
            this.Controls.Add(this.cboAutoridade);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboCondicao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmPeriodoLiquidacaoImpostoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "frmPeriodoLiquidacaoImpostoCad";
            this.Text = "Cadastro de Período Liquidação Imposto";
            this.Load += new System.EventHandler(this.frmPeriodoLiquidacaoImpostoCad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgVencimentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboCondicao;
        private System.Windows.Forms.Label lblAutoridade;
        private System.Windows.Forms.ComboBox cboAutoridade;
        private System.Windows.Forms.ComboBox cboIntervaloPeriodo;
        private System.Windows.Forms.Label lblIntervaloPeriodo;
        private System.Windows.Forms.TextBox txtNumeroUnidade;
        private System.Windows.Forms.Label lblNumeroUnidade;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgVencimentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}