namespace ERP
{
    partial class frmPlanoPagamentoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanoPagamentoCad));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.cboTipoDistribuicao = new System.Windows.Forms.ComboBox();
            this.lblTipoDistribuicao = new System.Windows.Forms.Label();
            this.cboPagamentoPor = new System.Windows.Forms.ComboBox();
            this.lblPagamentoPor = new System.Windows.Forms.Label();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.txtNumeroPagamentos = new System.Windows.Forms.TextBox();
            this.lblNumeroPagameto = new System.Windows.Forms.Label();
            this.txtValorMinimo = new System.Windows.Forms.TextBox();
            this.lblValorMinimo = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.cboAlocacaoImpostos = new System.Windows.Forms.ComboBox();
            this.lblAlocacaoImpostos = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgValores = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgValores)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(24, 156);
            this.txtNome.MaxLength = 200;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(222, 20);
            this.txtNome.TabIndex = 15;
            this.txtNome.Tag = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nome";
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
            this.ribbon1.Size = new System.Drawing.Size(884, 125);
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(252, 156);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(398, 20);
            this.txtDescricao.TabIndex = 17;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(249, 140);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 16;
            this.lblDescricao.Text = "Descrição";
            // 
            // cboTipoDistribuicao
            // 
            this.cboTipoDistribuicao.FormattingEnabled = true;
            this.cboTipoDistribuicao.Location = new System.Drawing.Point(656, 156);
            this.cboTipoDistribuicao.Name = "cboTipoDistribuicao";
            this.cboTipoDistribuicao.Size = new System.Drawing.Size(204, 21);
            this.cboTipoDistribuicao.TabIndex = 19;
            this.cboTipoDistribuicao.Tag = "1";
            // 
            // lblTipoDistribuicao
            // 
            this.lblTipoDistribuicao.AutoSize = true;
            this.lblTipoDistribuicao.Location = new System.Drawing.Point(653, 140);
            this.lblTipoDistribuicao.Name = "lblTipoDistribuicao";
            this.lblTipoDistribuicao.Size = new System.Drawing.Size(101, 13);
            this.lblTipoDistribuicao.TabIndex = 18;
            this.lblTipoDistribuicao.Text = "Tipo de Distribuição";
            // 
            // cboPagamentoPor
            // 
            this.cboPagamentoPor.DropDownWidth = 255;
            this.cboPagamentoPor.FormattingEnabled = true;
            this.cboPagamentoPor.Location = new System.Drawing.Point(24, 210);
            this.cboPagamentoPor.Name = "cboPagamentoPor";
            this.cboPagamentoPor.Size = new System.Drawing.Size(165, 21);
            this.cboPagamentoPor.TabIndex = 21;
            this.cboPagamentoPor.Tag = "1";
            // 
            // lblPagamentoPor
            // 
            this.lblPagamentoPor.AutoSize = true;
            this.lblPagamentoPor.Location = new System.Drawing.Point(21, 194);
            this.lblPagamentoPor.Name = "lblPagamentoPor";
            this.lblPagamentoPor.Size = new System.Drawing.Size(79, 13);
            this.lblPagamentoPor.TabIndex = 20;
            this.lblPagamentoPor.Text = "Pagamento por";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(195, 210);
            this.txtPeriodo.MaxLength = 200;
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(83, 20);
            this.txtPeriodo.TabIndex = 23;
            this.txtPeriodo.Tag = "1";
            this.txtPeriodo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeriodo_KeyPress);
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(192, 194);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(45, 13);
            this.lblPeriodo.TabIndex = 22;
            this.lblPeriodo.Text = "Período";
            // 
            // txtNumeroPagamentos
            // 
            this.txtNumeroPagamentos.Location = new System.Drawing.Point(283, 210);
            this.txtNumeroPagamentos.MaxLength = 10;
            this.txtNumeroPagamentos.Name = "txtNumeroPagamentos";
            this.txtNumeroPagamentos.Size = new System.Drawing.Size(118, 20);
            this.txtNumeroPagamentos.TabIndex = 25;
            this.txtNumeroPagamentos.Tag = "3";
            this.txtNumeroPagamentos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroPagamentos_KeyPress);
            // 
            // lblNumeroPagameto
            // 
            this.lblNumeroPagameto.AutoSize = true;
            this.lblNumeroPagameto.Location = new System.Drawing.Point(280, 194);
            this.lblNumeroPagameto.Name = "lblNumeroPagameto";
            this.lblNumeroPagameto.Size = new System.Drawing.Size(121, 13);
            this.lblNumeroPagameto.TabIndex = 24;
            this.lblNumeroPagameto.Text = "Número de Pagamentos";
            // 
            // txtValorMinimo
            // 
            this.txtValorMinimo.Location = new System.Drawing.Point(546, 210);
            this.txtValorMinimo.MaxLength = 18;
            this.txtValorMinimo.Name = "txtValorMinimo";
            this.txtValorMinimo.Size = new System.Drawing.Size(139, 20);
            this.txtValorMinimo.TabIndex = 29;
            this.txtValorMinimo.Tag = "3";
            this.txtValorMinimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorMinimo_KeyPress);
            // 
            // lblValorMinimo
            // 
            this.lblValorMinimo.AutoSize = true;
            this.lblValorMinimo.Location = new System.Drawing.Point(543, 194);
            this.lblValorMinimo.Name = "lblValorMinimo";
            this.lblValorMinimo.Size = new System.Drawing.Size(69, 13);
            this.lblValorMinimo.TabIndex = 28;
            this.lblValorMinimo.Text = "Valor Mínimo";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(407, 210);
            this.txtValor.MaxLength = 18;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(133, 20);
            this.txtValor.TabIndex = 27;
            this.txtValor.Tag = "3";
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(404, 194);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(31, 13);
            this.lblValor.TabIndex = 26;
            this.lblValor.Text = "Valor";
            // 
            // cboAlocacaoImpostos
            // 
            this.cboAlocacaoImpostos.DropDownWidth = 255;
            this.cboAlocacaoImpostos.FormattingEnabled = true;
            this.cboAlocacaoImpostos.Location = new System.Drawing.Point(691, 210);
            this.cboAlocacaoImpostos.Name = "cboAlocacaoImpostos";
            this.cboAlocacaoImpostos.Size = new System.Drawing.Size(169, 21);
            this.cboAlocacaoImpostos.TabIndex = 31;
            this.cboAlocacaoImpostos.Tag = "1";
            // 
            // lblAlocacaoImpostos
            // 
            this.lblAlocacaoImpostos.AutoSize = true;
            this.lblAlocacaoImpostos.Location = new System.Drawing.Point(688, 194);
            this.lblAlocacaoImpostos.Name = "lblAlocacaoImpostos";
            this.lblAlocacaoImpostos.Size = new System.Drawing.Size(112, 13);
            this.lblAlocacaoImpostos.TabIndex = 30;
            this.lblAlocacaoImpostos.Text = "Alocação de Impostos";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "Adicionar Itens";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgValores
            // 
            this.dgValores.AllowUserToAddRows = false;
            this.dgValores.AllowUserToDeleteRows = false;
            this.dgValores.BackgroundColor = System.Drawing.Color.White;
            this.dgValores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgValores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgValores.Location = new System.Drawing.Point(24, 287);
            this.dgValores.Name = "dgValores";
            this.dgValores.ReadOnly = true;
            this.dgValores.RowHeadersVisible = false;
            this.dgValores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgValores.Size = new System.Drawing.Size(836, 312);
            this.dgValores.TabIndex = 33;
            this.dgValores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgValores_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IdPlanoPagamentoItem";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Quantidade";
            this.Column2.HeaderText = "Quantidade";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ValorTransacao";
            this.Column3.HeaderText = "Valor da Transação";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "PorcentagemValor";
            this.Column4.HeaderText = "Porcentagem Valor";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // frmPlanoPagamentoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.dgValores);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboAlocacaoImpostos);
            this.Controls.Add(this.lblAlocacaoImpostos);
            this.Controls.Add(this.txtValorMinimo);
            this.Controls.Add(this.lblValorMinimo);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.txtNumeroPagamentos);
            this.Controls.Add(this.lblNumeroPagameto);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.lblPeriodo);
            this.Controls.Add(this.cboPagamentoPor);
            this.Controls.Add(this.lblPagamentoPor);
            this.Controls.Add(this.cboTipoDistribuicao);
            this.Controls.Add(this.lblTipoDistribuicao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmPlanoPagamentoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "frmPlanoPagamentoCad";
            this.Text = "Cadastro Plano de Pagamento";
            this.Load += new System.EventHandler(this.frmCidadeCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPlanoPagamentoCad_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgValores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.ComboBox cboTipoDistribuicao;
        private System.Windows.Forms.Label lblTipoDistribuicao;
        private System.Windows.Forms.ComboBox cboPagamentoPor;
        private System.Windows.Forms.Label lblPagamentoPor;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.TextBox txtNumeroPagamentos;
        private System.Windows.Forms.Label lblNumeroPagameto;
        private System.Windows.Forms.TextBox txtValorMinimo;
        private System.Windows.Forms.Label lblValorMinimo;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.ComboBox cboAlocacaoImpostos;
        private System.Windows.Forms.Label lblAlocacaoImpostos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgValores;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}