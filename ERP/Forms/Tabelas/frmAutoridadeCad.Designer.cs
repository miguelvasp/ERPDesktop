namespace ERP
{
    partial class frmAutoridadeCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutoridadeCad));
            this.txtNomeAutoridade = new System.Windows.Forms.TextBox();
            this.lblNomeAutoridade = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
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
            this.txtIdentificacao = new System.Windows.Forms.TextBox();
            this.lblIdentificacao = new System.Windows.Forms.Label();
            this.cboAgencia = new System.Windows.Forms.ComboBox();
            this.lblAgencia = new System.Windows.Forms.Label();
            this.cboFornecedor = new System.Windows.Forms.ComboBox();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.cboFormaArredondamento = new System.Windows.Forms.ComboBox();
            this.lblFormaArredondamento = new System.Windows.Forms.Label();
            this.txtArredondamento = new System.Windows.Forms.TextBox();
            this.lblArredondamento = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNomeAutoridade
            // 
            this.txtNomeAutoridade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeAutoridade.Location = new System.Drawing.Point(15, 153);
            this.txtNomeAutoridade.MaxLength = 12;
            this.txtNomeAutoridade.Name = "txtNomeAutoridade";
            this.txtNomeAutoridade.Size = new System.Drawing.Size(345, 20);
            this.txtNomeAutoridade.TabIndex = 15;
            this.txtNomeAutoridade.Tag = "1";
            // 
            // lblNomeAutoridade
            // 
            this.lblNomeAutoridade.AutoSize = true;
            this.lblNomeAutoridade.Location = new System.Drawing.Point(12, 137);
            this.lblNomeAutoridade.Name = "lblNomeAutoridade";
            this.lblNomeAutoridade.Size = new System.Drawing.Size(58, 13);
            this.lblNomeAutoridade.TabIndex = 14;
            this.lblNomeAutoridade.Text = "Autoridade";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(339, 137);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 13;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
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
            this.ribbon1.Size = new System.Drawing.Size(384, 125);
            this.ribbon1.TabIndex = 12;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.Location = new System.Drawing.Point(15, 201);
            this.txtDescricao.MaxLength = 40;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(345, 20);
            this.txtDescricao.TabIndex = 17;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(12, 185);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 16;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtIdentificacao
            // 
            this.txtIdentificacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdentificacao.Location = new System.Drawing.Point(15, 249);
            this.txtIdentificacao.MaxLength = 8;
            this.txtIdentificacao.Name = "txtIdentificacao";
            this.txtIdentificacao.Size = new System.Drawing.Size(345, 20);
            this.txtIdentificacao.TabIndex = 19;
            this.txtIdentificacao.Tag = "1";
            // 
            // lblIdentificacao
            // 
            this.lblIdentificacao.AutoSize = true;
            this.lblIdentificacao.Location = new System.Drawing.Point(12, 233);
            this.lblIdentificacao.Name = "lblIdentificacao";
            this.lblIdentificacao.Size = new System.Drawing.Size(68, 13);
            this.lblIdentificacao.TabIndex = 18;
            this.lblIdentificacao.Text = "Identificação";
            // 
            // cboAgencia
            // 
            this.cboAgencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAgencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboAgencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAgencia.DropDownWidth = 170;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(15, 297);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(345, 21);
            this.cboAgencia.TabIndex = 21;
            this.cboAgencia.Tag = "1";
            // 
            // lblAgencia
            // 
            this.lblAgencia.AutoSize = true;
            this.lblAgencia.Location = new System.Drawing.Point(12, 281);
            this.lblAgencia.Name = "lblAgencia";
            this.lblAgencia.Size = new System.Drawing.Size(46, 13);
            this.lblAgencia.TabIndex = 20;
            this.lblAgencia.Text = "Agência";
            // 
            // cboFornecedor
            // 
            this.cboFornecedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFornecedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFornecedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFornecedor.DropDownWidth = 255;
            this.cboFornecedor.FormattingEnabled = true;
            this.cboFornecedor.Location = new System.Drawing.Point(15, 345);
            this.cboFornecedor.Name = "cboFornecedor";
            this.cboFornecedor.Size = new System.Drawing.Size(345, 21);
            this.cboFornecedor.TabIndex = 23;
            this.cboFornecedor.Tag = "";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(12, 330);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(61, 13);
            this.lblFornecedor.TabIndex = 22;
            this.lblFornecedor.Text = "Fornecedor";
            // 
            // cboFormaArredondamento
            // 
            this.cboFormaArredondamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFormaArredondamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFormaArredondamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFormaArredondamento.DropDownWidth = 170;
            this.cboFormaArredondamento.FormattingEnabled = true;
            this.cboFormaArredondamento.Location = new System.Drawing.Point(15, 394);
            this.cboFormaArredondamento.Name = "cboFormaArredondamento";
            this.cboFormaArredondamento.Size = new System.Drawing.Size(345, 21);
            this.cboFormaArredondamento.TabIndex = 25;
            this.cboFormaArredondamento.Tag = "1";
            // 
            // lblFormaArredondamento
            // 
            this.lblFormaArredondamento.AutoSize = true;
            this.lblFormaArredondamento.Location = new System.Drawing.Point(12, 378);
            this.lblFormaArredondamento.Name = "lblFormaArredondamento";
            this.lblFormaArredondamento.Size = new System.Drawing.Size(132, 13);
            this.lblFormaArredondamento.TabIndex = 24;
            this.lblFormaArredondamento.Text = "Forma de Arredondamento";
            // 
            // txtArredondamento
            // 
            this.txtArredondamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArredondamento.Location = new System.Drawing.Point(15, 443);
            this.txtArredondamento.MaxLength = 10;
            this.txtArredondamento.Name = "txtArredondamento";
            this.txtArredondamento.Size = new System.Drawing.Size(175, 20);
            this.txtArredondamento.TabIndex = 27;
            this.txtArredondamento.Tag = "3";
            this.txtArredondamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtArredondamento_KeyPress);
            // 
            // lblArredondamento
            // 
            this.lblArredondamento.AutoSize = true;
            this.lblArredondamento.Location = new System.Drawing.Point(12, 427);
            this.lblArredondamento.Name = "lblArredondamento";
            this.lblArredondamento.Size = new System.Drawing.Size(85, 13);
            this.lblArredondamento.TabIndex = 26;
            this.lblArredondamento.Text = "Arredondamento";
            // 
            // frmAutoridadeCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(384, 489);
            this.Controls.Add(this.txtArredondamento);
            this.Controls.Add(this.lblArredondamento);
            this.Controls.Add(this.cboFormaArredondamento);
            this.Controls.Add(this.lblFormaArredondamento);
            this.Controls.Add(this.cboFornecedor);
            this.Controls.Add(this.lblFornecedor);
            this.Controls.Add(this.cboAgencia);
            this.Controls.Add(this.lblAgencia);
            this.Controls.Add(this.txtIdentificacao);
            this.Controls.Add(this.lblIdentificacao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtNomeAutoridade);
            this.Controls.Add(this.lblNomeAutoridade);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 505);
            this.Name = "frmAutoridadeCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmAutoridadeCad";
            this.Text = "Cadastro de Autoridade";
            this.Load += new System.EventHandler(this.frmAutoridadeCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAutoridadeCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomeAutoridade;
        private System.Windows.Forms.Label lblNomeAutoridade;
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
        private System.Windows.Forms.TextBox txtIdentificacao;
        private System.Windows.Forms.Label lblIdentificacao;
        private System.Windows.Forms.ComboBox cboAgencia;
        private System.Windows.Forms.Label lblAgencia;
        private System.Windows.Forms.ComboBox cboFornecedor;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.ComboBox cboFormaArredondamento;
        private System.Windows.Forms.Label lblFormaArredondamento;
        private System.Windows.Forms.TextBox txtArredondamento;
        private System.Windows.Forms.Label lblArredondamento;
    }
}