namespace ERP
{
    partial class frmAjustePreco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAjustePreco));
            this.cboRelacao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCodigoContratoComercial = new System.Windows.Forms.ComboBox();
            this.lblCodigoContrato = new System.Windows.Forms.Label();
            this.cboProduto = new System.Windows.Forms.ComboBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.cboFornecedor = new System.Windows.Forms.ComboBox();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtPorcentagemValor = new System.Windows.Forms.TextBox();
            this.lblPorcetagemValor = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtPorcentagemPercentual = new System.Windows.Forms.TextBox();
            this.lblPercentagemPercentual = new System.Windows.Forms.Label();
            this.txtPorcentagem = new System.Windows.Forms.TextBox();
            this.lblPorcentagem = new System.Windows.Forms.Label();
            this.cboAjuste = new System.Windows.Forms.ComboBox();
            this.lblAjuste = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblAtivo = new System.Windows.Forms.Label();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.cboAtivo = new System.Windows.Forms.ComboBox();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.rbbPnlInfo = new System.Windows.Forms.RibbonPanel();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.SuspendLayout();
            // 
            // cboRelacao
            // 
            this.cboRelacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRelacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRelacao.FormattingEnabled = true;
            this.cboRelacao.Location = new System.Drawing.Point(213, 302);
            this.cboRelacao.Name = "cboRelacao";
            this.cboRelacao.Size = new System.Drawing.Size(170, 21);
            this.cboRelacao.TabIndex = 5;
            this.cboRelacao.Tag = "1";
            this.cboRelacao.Leave += new System.EventHandler(this.cboRelacao_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Relação";
            // 
            // cboCodigoContratoComercial
            // 
            this.cboCodigoContratoComercial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCodigoContratoComercial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCodigoContratoComercial.FormattingEnabled = true;
            this.cboCodigoContratoComercial.Location = new System.Drawing.Point(24, 154);
            this.cboCodigoContratoComercial.Name = "cboCodigoContratoComercial";
            this.cboCodigoContratoComercial.Size = new System.Drawing.Size(358, 21);
            this.cboCodigoContratoComercial.TabIndex = 0;
            this.cboCodigoContratoComercial.Tag = "1";
            // 
            // lblCodigoContrato
            // 
            this.lblCodigoContrato.AutoSize = true;
            this.lblCodigoContrato.Location = new System.Drawing.Point(22, 138);
            this.lblCodigoContrato.Name = "lblCodigoContrato";
            this.lblCodigoContrato.Size = new System.Drawing.Size(40, 13);
            this.lblCodigoContrato.TabIndex = 13;
            this.lblCodigoContrato.Text = "Código";
            // 
            // cboProduto
            // 
            this.cboProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProduto.DropDownWidth = 255;
            this.cboProduto.FormattingEnabled = true;
            this.cboProduto.Location = new System.Drawing.Point(212, 253);
            this.cboProduto.Name = "cboProduto";
            this.cboProduto.Size = new System.Drawing.Size(170, 21);
            this.cboProduto.TabIndex = 3;
            this.cboProduto.Tag = "";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(210, 237);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(44, 13);
            this.lblProduto.TabIndex = 16;
            this.lblProduto.Text = "Produto";
            // 
            // cboFornecedor
            // 
            this.cboFornecedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFornecedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFornecedor.DropDownWidth = 255;
            this.cboFornecedor.FormattingEnabled = true;
            this.cboFornecedor.Location = new System.Drawing.Point(25, 253);
            this.cboFornecedor.Name = "cboFornecedor";
            this.cboFornecedor.Size = new System.Drawing.Size(170, 21);
            this.cboFornecedor.TabIndex = 2;
            this.cboFornecedor.Tag = "";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(21, 237);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(61, 13);
            this.lblFornecedor.TabIndex = 15;
            this.lblFornecedor.Text = "Fornecedor";
            // 
            // cboCliente
            // 
            this.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCliente.DropDownWidth = 255;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(25, 302);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(170, 21);
            this.cboCliente.TabIndex = 4;
            this.cboCliente.Tag = "";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(22, 286);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 17;
            this.lblCliente.Text = "Cliente";
            // 
            // txtPorcentagemValor
            // 
            this.txtPorcentagemValor.Enabled = false;
            this.txtPorcentagemValor.Location = new System.Drawing.Point(213, 405);
            this.txtPorcentagemValor.Name = "txtPorcentagemValor";
            this.txtPorcentagemValor.Size = new System.Drawing.Size(170, 20);
            this.txtPorcentagemValor.TabIndex = 8;
            this.txtPorcentagemValor.Tag = "3";
            this.txtPorcentagemValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentagemValor_KeyPress);
            // 
            // lblPorcetagemValor
            // 
            this.lblPorcetagemValor.AutoSize = true;
            this.lblPorcetagemValor.Location = new System.Drawing.Point(210, 389);
            this.lblPorcetagemValor.Name = "lblPorcetagemValor";
            this.lblPorcetagemValor.Size = new System.Drawing.Size(114, 13);
            this.lblPorcetagemValor.TabIndex = 21;
            this.lblPorcetagemValor.Text = "Porcentagem em Valor";
            // 
            // txtValor
            // 
            this.txtValor.Enabled = false;
            this.txtValor.Location = new System.Drawing.Point(25, 405);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(170, 20);
            this.txtValor.TabIndex = 7;
            this.txtValor.Tag = "3";
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(22, 389);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(31, 13);
            this.lblValor.TabIndex = 20;
            this.lblValor.Text = "Valor";
            // 
            // txtPorcentagemPercentual
            // 
            this.txtPorcentagemPercentual.Enabled = false;
            this.txtPorcentagemPercentual.Location = new System.Drawing.Point(212, 456);
            this.txtPorcentagemPercentual.Name = "txtPorcentagemPercentual";
            this.txtPorcentagemPercentual.Size = new System.Drawing.Size(170, 20);
            this.txtPorcentagemPercentual.TabIndex = 10;
            this.txtPorcentagemPercentual.Tag = "3";
            this.txtPorcentagemPercentual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentagemPercentual_KeyPress);
            // 
            // lblPercentagemPercentual
            // 
            this.lblPercentagemPercentual.AutoSize = true;
            this.lblPercentagemPercentual.Location = new System.Drawing.Point(209, 440);
            this.lblPercentagemPercentual.Name = "lblPercentagemPercentual";
            this.lblPercentagemPercentual.Size = new System.Drawing.Size(141, 13);
            this.lblPercentagemPercentual.TabIndex = 23;
            this.lblPercentagemPercentual.Text = "Porcentagem em Percentual";
            // 
            // txtPorcentagem
            // 
            this.txtPorcentagem.Enabled = false;
            this.txtPorcentagem.Location = new System.Drawing.Point(25, 456);
            this.txtPorcentagem.Name = "txtPorcentagem";
            this.txtPorcentagem.Size = new System.Drawing.Size(170, 20);
            this.txtPorcentagem.TabIndex = 9;
            this.txtPorcentagem.Tag = "3";
            this.txtPorcentagem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentagem_KeyPress);
            // 
            // lblPorcentagem
            // 
            this.lblPorcentagem.AutoSize = true;
            this.lblPorcentagem.Location = new System.Drawing.Point(22, 440);
            this.lblPorcentagem.Name = "lblPorcentagem";
            this.lblPorcentagem.Size = new System.Drawing.Size(70, 13);
            this.lblPorcentagem.TabIndex = 22;
            this.lblPorcentagem.Text = "Porcentagem";
            // 
            // cboAjuste
            // 
            this.cboAjuste.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboAjuste.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAjuste.DropDownWidth = 255;
            this.cboAjuste.FormattingEnabled = true;
            this.cboAjuste.Location = new System.Drawing.Point(25, 353);
            this.cboAjuste.Name = "cboAjuste";
            this.cboAjuste.Size = new System.Drawing.Size(170, 21);
            this.cboAjuste.TabIndex = 6;
            this.cboAjuste.Tag = "";
            this.cboAjuste.SelectedIndexChanged += new System.EventHandler(this.cboAjuste_SelectedIndexChanged);
            // 
            // lblAjuste
            // 
            this.lblAjuste.AutoSize = true;
            this.lblAjuste.Location = new System.Drawing.Point(22, 337);
            this.lblAjuste.Name = "lblAjuste";
            this.lblAjuste.Size = new System.Drawing.Size(36, 13);
            this.lblAjuste.TabIndex = 19;
            this.lblAjuste.Text = "Ajuste";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(0, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 25;
            // 
            // lblAtivo
            // 
            this.lblAtivo.AutoSize = true;
            this.lblAtivo.Location = new System.Drawing.Point(21, 187);
            this.lblAtivo.Name = "lblAtivo";
            this.lblAtivo.Size = new System.Drawing.Size(31, 13);
            this.lblAtivo.TabIndex = 14;
            this.lblAtivo.Text = "Ativo";
            // 
            // rbOpcoes
            // 
            this.rbOpcoes.Text = "Documento";
            // 
            // cboAtivo
            // 
            this.cboAtivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboAtivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAtivo.FormattingEnabled = true;
            this.cboAtivo.Location = new System.Drawing.Point(25, 203);
            this.cboAtivo.Name = "cboAtivo";
            this.cboAtivo.Size = new System.Drawing.Size(170, 21);
            this.cboAtivo.TabIndex = 1;
            this.cboAtivo.Tag = "1";
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
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbVisible = false;
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(395, 125);
            this.ribbon1.TabIndex = 24;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.rbbPnlInfo);
            this.ribbonTab1.Text = "Documento";
            // 
            // rbbPnlInfo
            // 
            this.rbbPnlInfo.Items.Add(this.btnGrava);
            this.rbbPnlInfo.Items.Add(this.btnCancelar);
            this.rbbPnlInfo.Text = "Informações";
            // 
            // btnGrava
            // 
            this.btnGrava.Image = ((System.Drawing.Image)(resources.GetObject("btnGrava.Image")));
            this.btnGrava.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGrava.SmallImage")));
            this.btnGrava.Text = "Gravar";
            this.btnGrava.Click += new System.EventHandler(this.btnGrava_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.SmallImage")));
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmAjustePreco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(395, 483);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.cboAtivo);
            this.Controls.Add(this.lblAtivo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboAjuste);
            this.Controls.Add(this.lblAjuste);
            this.Controls.Add(this.txtPorcentagemPercentual);
            this.Controls.Add(this.lblPercentagemPercentual);
            this.Controls.Add(this.txtPorcentagem);
            this.Controls.Add(this.lblPorcentagem);
            this.Controls.Add(this.txtPorcentagemValor);
            this.Controls.Add(this.lblPorcetagemValor);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cboProduto);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.cboFornecedor);
            this.Controls.Add(this.lblFornecedor);
            this.Controls.Add(this.cboCodigoContratoComercial);
            this.Controls.Add(this.lblCodigoContrato);
            this.Controls.Add(this.cboRelacao);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAjustePreco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmAjustePreco";
            this.Text = "Ajuste de Preço";
            this.Load += new System.EventHandler(this.frmAjustePreco_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboRelacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCodigoContratoComercial;
        private System.Windows.Forms.Label lblCodigoContrato;
        private System.Windows.Forms.ComboBox cboProduto;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.ComboBox cboFornecedor;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtPorcentagemValor;
        private System.Windows.Forms.Label lblPorcetagemValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtPorcentagemPercentual;
        private System.Windows.Forms.Label lblPercentagemPercentual;
        private System.Windows.Forms.TextBox txtPorcentagem;
        private System.Windows.Forms.Label lblPorcentagem;
        private System.Windows.Forms.ComboBox cboAjuste;
        private System.Windows.Forms.Label lblAjuste;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblAtivo;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.ComboBox cboAtivo;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel rbbPnlInfo;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnCancelar;
    }
}