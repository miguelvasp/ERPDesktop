namespace ERP
{
    partial class frmValoresCentroCustoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValoresCentroCustoCad));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblFinal = new System.Windows.Forms.Label();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.lblDataInicial = new System.Windows.Forms.Label();
            this.dtpDataInicial = new System.Windows.Forms.DateTimePicker();
            this.chkDimensaoTotalizadora = new System.Windows.Forms.CheckBox();
            this.btnAddTotalDimensoes = new System.Windows.Forms.Button();
            this.dgvTotalDimensoes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdValoresCentroCusto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalDimensoes)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(25, 167);
            this.txtNome.MaxLength = 20;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(341, 20);
            this.txtNome.TabIndex = 17;
            this.txtNome.Tag = "1";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(22, 151);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 16;
            this.lblNome.Text = "Nome";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(349, 151);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 15;
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
            this.ribbon1.Size = new System.Drawing.Size(819, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(25, 217);
            this.txtDescricao.MaxLength = 40;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(341, 20);
            this.txtDescricao.TabIndex = 19;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(22, 201);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 18;
            this.lblDescricao.Text = "Descrição";
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.Location = new System.Drawing.Point(218, 263);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(55, 13);
            this.lblFinal.TabIndex = 22;
            this.lblFinal.Text = "Data Final";
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.Checked = false;
            this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataFinal.Location = new System.Drawing.Point(221, 279);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.ShowCheckBox = true;
            this.dtpDataFinal.Size = new System.Drawing.Size(145, 20);
            this.dtpDataFinal.TabIndex = 23;
            this.dtpDataFinal.Tag = "";
            this.dtpDataFinal.ValueChanged += new System.EventHandler(this.dtpDataFinal_ValueChanged);
            // 
            // lblDataInicial
            // 
            this.lblDataInicial.AutoSize = true;
            this.lblDataInicial.Location = new System.Drawing.Point(22, 263);
            this.lblDataInicial.Name = "lblDataInicial";
            this.lblDataInicial.Size = new System.Drawing.Size(60, 13);
            this.lblDataInicial.TabIndex = 20;
            this.lblDataInicial.Text = "Data Inicial";
            // 
            // dtpDataInicial
            // 
            this.dtpDataInicial.Checked = false;
            this.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataInicial.Location = new System.Drawing.Point(25, 279);
            this.dtpDataInicial.Name = "dtpDataInicial";
            this.dtpDataInicial.ShowCheckBox = true;
            this.dtpDataInicial.Size = new System.Drawing.Size(145, 20);
            this.dtpDataInicial.TabIndex = 21;
            this.dtpDataInicial.Tag = "";
            this.dtpDataInicial.ValueChanged += new System.EventHandler(this.dtpDataInicial_ValueChanged);
            // 
            // chkDimensaoTotalizadora
            // 
            this.chkDimensaoTotalizadora.AutoSize = true;
            this.chkDimensaoTotalizadora.Location = new System.Drawing.Point(25, 317);
            this.chkDimensaoTotalizadora.Name = "chkDimensaoTotalizadora";
            this.chkDimensaoTotalizadora.Size = new System.Drawing.Size(134, 17);
            this.chkDimensaoTotalizadora.TabIndex = 24;
            this.chkDimensaoTotalizadora.Text = "Dimensão Totalizadora";
            this.chkDimensaoTotalizadora.UseVisualStyleBackColor = true;
            this.chkDimensaoTotalizadora.CheckedChanged += new System.EventHandler(this.chkDimensaoTotalizadora_CheckedChanged);
            // 
            // btnAddTotalDimensoes
            // 
            this.btnAddTotalDimensoes.Enabled = false;
            this.btnAddTotalDimensoes.Location = new System.Drawing.Point(406, 141);
            this.btnAddTotalDimensoes.Name = "btnAddTotalDimensoes";
            this.btnAddTotalDimensoes.Size = new System.Drawing.Size(146, 23);
            this.btnAddTotalDimensoes.TabIndex = 51;
            this.btnAddTotalDimensoes.Text = "Adicionar Total Dimensões";
            this.btnAddTotalDimensoes.UseVisualStyleBackColor = true;
            this.btnAddTotalDimensoes.Click += new System.EventHandler(this.btnAddTotalDimensoes_Click);
            // 
            // dgvTotalDimensoes
            // 
            this.dgvTotalDimensoes.AllowUserToAddRows = false;
            this.dgvTotalDimensoes.AllowUserToDeleteRows = false;
            this.dgvTotalDimensoes.AllowUserToOrderColumns = true;
            this.dgvTotalDimensoes.AllowUserToResizeRows = false;
            this.dgvTotalDimensoes.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTotalDimensoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalDimensoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.IdValoresCentroCusto,
            this.Column2,
            this.Column8});
            this.dgvTotalDimensoes.Enabled = false;
            this.dgvTotalDimensoes.Location = new System.Drawing.Point(406, 168);
            this.dgvTotalDimensoes.MultiSelect = false;
            this.dgvTotalDimensoes.Name = "dgvTotalDimensoes";
            this.dgvTotalDimensoes.ReadOnly = true;
            this.dgvTotalDimensoes.RowHeadersVisible = false;
            this.dgvTotalDimensoes.Size = new System.Drawing.Size(401, 196);
            this.dgvTotalDimensoes.TabIndex = 52;
            this.dgvTotalDimensoes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTotalDimensoes_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IdTotalDimensoes";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // IdValoresCentroCusto
            // 
            this.IdValoresCentroCusto.DataPropertyName = "IdValoresCentroCusto";
            this.IdValoresCentroCusto.HeaderText = "IdValoresCentroCusto";
            this.IdValoresCentroCusto.Name = "IdValoresCentroCusto";
            this.IdValoresCentroCusto.ReadOnly = true;
            this.IdValoresCentroCusto.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DimensaoDe";
            dataGridViewCellStyle1.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "Dimensão (De)";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 180;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "DimensaoAte";
            dataGridViewCellStyle2.NullValue = null;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column8.HeaderText = "Dimensão (Até)";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 180;
            // 
            // frmValoresCentroCustoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(819, 389);
            this.Controls.Add(this.dgvTotalDimensoes);
            this.Controls.Add(this.btnAddTotalDimensoes);
            this.Controls.Add(this.chkDimensaoTotalizadora);
            this.Controls.Add(this.lblFinal);
            this.Controls.Add(this.dtpDataFinal);
            this.Controls.Add(this.lblDataInicial);
            this.Controls.Add(this.dtpDataInicial);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmValoresCentroCustoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmValoresCentroCustoCad";
            this.Text = "Cadastro Valores Centro de Custo";
            this.Load += new System.EventHandler(this.frmValoresCentroCustoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmValoresCentroCustoCad_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalDimensoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lbCodigo;
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
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.Label lblDataInicial;
        private System.Windows.Forms.DateTimePicker dtpDataInicial;
        private System.Windows.Forms.CheckBox chkDimensaoTotalizadora;
        private System.Windows.Forms.Button btnAddTotalDimensoes;
        private System.Windows.Forms.DataGridView dgvTotalDimensoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdValoresCentroCusto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}