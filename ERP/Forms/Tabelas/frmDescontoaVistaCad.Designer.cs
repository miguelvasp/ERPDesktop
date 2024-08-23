namespace ERP
{
    partial class frmDescontoaVistaCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDescontoaVistaCad));
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtDias = new System.Windows.Forms.TextBox();
            this.lblDias = new System.Windows.Forms.Label();
            this.cboCalculo = new System.Windows.Forms.ComboBox();
            this.lblCalculo = new System.Windows.Forms.Label();
            this.txtMeses = new System.Windows.Forms.TextBox();
            this.lblMeses = new System.Windows.Forms.Label();
            this.lblContaContabilCliente = new System.Windows.Forms.Label();
            this.cboContaContabilCliente = new System.Windows.Forms.ComboBox();
            this.lblContaContabilFornecedor = new System.Windows.Forms.Label();
            this.cboContaContabilFornecedor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(28, 154);
            this.txtDescricao.MaxLength = 60;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(344, 20);
            this.txtDescricao.TabIndex = 17;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(25, 138);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 16;
            this.lblDescricao.Text = "Descrição";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(352, 138);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 15;
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
            this.ribbon1.Size = new System.Drawing.Size(398, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDias
            // 
            this.txtDias.Location = new System.Drawing.Point(206, 255);
            this.txtDias.MaxLength = 2;
            this.txtDias.Name = "txtDias";
            this.txtDias.Size = new System.Drawing.Size(166, 20);
            this.txtDias.TabIndex = 23;
            this.txtDias.Tag = "1";
            this.txtDias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDias_KeyPress);
            // 
            // lblDias
            // 
            this.lblDias.AutoSize = true;
            this.lblDias.Location = new System.Drawing.Point(203, 239);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(28, 13);
            this.lblDias.TabIndex = 22;
            this.lblDias.Text = "Dias";
            // 
            // cboCalculo
            // 
            this.cboCalculo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCalculo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCalculo.FormattingEnabled = true;
            this.cboCalculo.Location = new System.Drawing.Point(28, 204);
            this.cboCalculo.Name = "cboCalculo";
            this.cboCalculo.Size = new System.Drawing.Size(217, 21);
            this.cboCalculo.TabIndex = 19;
            this.cboCalculo.Tag = "1";
            // 
            // lblCalculo
            // 
            this.lblCalculo.AutoSize = true;
            this.lblCalculo.Location = new System.Drawing.Point(25, 188);
            this.lblCalculo.Name = "lblCalculo";
            this.lblCalculo.Size = new System.Drawing.Size(42, 13);
            this.lblCalculo.TabIndex = 18;
            this.lblCalculo.Text = "Cálculo";
            // 
            // txtMeses
            // 
            this.txtMeses.Location = new System.Drawing.Point(28, 255);
            this.txtMeses.MaxLength = 2;
            this.txtMeses.Name = "txtMeses";
            this.txtMeses.Size = new System.Drawing.Size(166, 20);
            this.txtMeses.TabIndex = 21;
            this.txtMeses.Tag = "1";
            this.txtMeses.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMeses_KeyPress);
            // 
            // lblMeses
            // 
            this.lblMeses.AutoSize = true;
            this.lblMeses.Location = new System.Drawing.Point(25, 239);
            this.lblMeses.Name = "lblMeses";
            this.lblMeses.Size = new System.Drawing.Size(38, 13);
            this.lblMeses.TabIndex = 20;
            this.lblMeses.Text = "Meses";
            // 
            // lblContaContabilCliente
            // 
            this.lblContaContabilCliente.AutoSize = true;
            this.lblContaContabilCliente.Location = new System.Drawing.Point(25, 290);
            this.lblContaContabilCliente.Name = "lblContaContabilCliente";
            this.lblContaContabilCliente.Size = new System.Drawing.Size(111, 13);
            this.lblContaContabilCliente.TabIndex = 24;
            this.lblContaContabilCliente.Text = "Conta Contábil Cliente";
            // 
            // cboContaContabilCliente
            // 
            this.cboContaContabilCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboContaContabilCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboContaContabilCliente.FormattingEnabled = true;
            this.cboContaContabilCliente.Location = new System.Drawing.Point(28, 309);
            this.cboContaContabilCliente.Name = "cboContaContabilCliente";
            this.cboContaContabilCliente.Size = new System.Drawing.Size(217, 21);
            this.cboContaContabilCliente.TabIndex = 25;
            this.cboContaContabilCliente.Tag = "";
            // 
            // lblContaContabilFornecedor
            // 
            this.lblContaContabilFornecedor.AutoSize = true;
            this.lblContaContabilFornecedor.Location = new System.Drawing.Point(25, 348);
            this.lblContaContabilFornecedor.Name = "lblContaContabilFornecedor";
            this.lblContaContabilFornecedor.Size = new System.Drawing.Size(133, 13);
            this.lblContaContabilFornecedor.TabIndex = 26;
            this.lblContaContabilFornecedor.Text = "Conta Contábil Fornecedor";
            // 
            // cboContaContabilFornecedor
            // 
            this.cboContaContabilFornecedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboContaContabilFornecedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboContaContabilFornecedor.FormattingEnabled = true;
            this.cboContaContabilFornecedor.Location = new System.Drawing.Point(28, 367);
            this.cboContaContabilFornecedor.Name = "cboContaContabilFornecedor";
            this.cboContaContabilFornecedor.Size = new System.Drawing.Size(217, 21);
            this.cboContaContabilFornecedor.TabIndex = 27;
            this.cboContaContabilFornecedor.Tag = "";
            // 
            // frmDescontoaVistaCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(398, 404);
            this.Controls.Add(this.lblContaContabilFornecedor);
            this.Controls.Add(this.cboContaContabilFornecedor);
            this.Controls.Add(this.lblContaContabilCliente);
            this.Controls.Add(this.cboContaContabilCliente);
            this.Controls.Add(this.txtMeses);
            this.Controls.Add(this.lblMeses);
            this.Controls.Add(this.cboCalculo);
            this.Controls.Add(this.lblCalculo);
            this.Controls.Add(this.txtDias);
            this.Controls.Add(this.lblDias);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmDescontoaVistaCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmDescontoaVistaCad";
            this.Text = "Cadastro de Desconto à Vista";
            this.Load += new System.EventHandler(this.frmDescontoaVistaCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDescontoaVistaCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.TextBox txtDias;
        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.ComboBox cboCalculo;
        private System.Windows.Forms.Label lblCalculo;
        private System.Windows.Forms.TextBox txtMeses;
        private System.Windows.Forms.Label lblMeses;
        private System.Windows.Forms.Label lblContaContabilCliente;
        private System.Windows.Forms.ComboBox cboContaContabilCliente;
        private System.Windows.Forms.Label lblContaContabilFornecedor;
        private System.Windows.Forms.ComboBox cboContaContabilFornecedor;
    }
}