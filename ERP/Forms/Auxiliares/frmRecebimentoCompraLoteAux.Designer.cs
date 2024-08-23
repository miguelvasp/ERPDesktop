namespace ERP
{
    partial class frmRecebimentoCompraLoteAux
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecebimentoCompraLoteAux));
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtDataVencimento = new System.Windows.Forms.MaskedTextBox();
            this.lblDataVencimento = new System.Windows.Forms.Label();
            this.txtDataFabricacao = new System.Windows.Forms.MaskedTextBox();
            this.lblDataFabricacao = new System.Windows.Forms.Label();
            this.txtDataAvisoPrateleira = new System.Windows.Forms.MaskedTextBox();
            this.lblDataAvisoPrateleira = new System.Windows.Forms.Label();
            this.txtDataValidade = new System.Windows.Forms.MaskedTextBox();
            this.lblDataValidade = new System.Windows.Forms.Label();
            this.txtLoteInterno = new System.Windows.Forms.TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtLoteFornecedor = new System.Windows.Forms.TextBox();
            this.lblFornecedorNumero = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbOpcoes
            // 
            this.rbOpcoes.Panels.Add(this.ribbonPanel1);
            this.rbOpcoes.Text = "Documento";
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
            // 
            // btnAlterar
            // 
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAlterar.SmallImage")));
            this.btnAlterar.Text = "Alterar";
            // 
            // btnGrava
            // 
            this.btnGrava.Enabled = false;
            this.btnGrava.Image = ((System.Drawing.Image)(resources.GetObject("btnGrava.Image")));
            this.btnGrava.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnGrava.SmallImage")));
            this.btnGrava.Text = "Gravar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.SmallImage")));
            this.btnCancelar.Text = "Cancelar";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnExcluir.SmallImage")));
            this.btnExcluir.Text = "Excluir";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(285, 187);
            this.txtQuantidade.MaxLength = 10;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(101, 20);
            this.txtQuantidade.TabIndex = 2;
            this.txtQuantidade.Tag = "3";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(282, 171);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(62, 13);
            this.lblQuantidade.TabIndex = 21;
            this.lblQuantidade.Text = "Quantidade";
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
            this.ribbon1.Size = new System.Drawing.Size(644, 125);
            this.ribbon1.TabIndex = 38;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDataVencimento
            // 
            this.txtDataVencimento.Location = new System.Drawing.Point(45, 260);
            this.txtDataVencimento.Mask = "99/99/9999";
            this.txtDataVencimento.Name = "txtDataVencimento";
            this.txtDataVencimento.Size = new System.Drawing.Size(101, 20);
            this.txtDataVencimento.TabIndex = 3;
            // 
            // lblDataVencimento
            // 
            this.lblDataVencimento.AutoSize = true;
            this.lblDataVencimento.Location = new System.Drawing.Point(42, 243);
            this.lblDataVencimento.Name = "lblDataVencimento";
            this.lblDataVencimento.Size = new System.Drawing.Size(104, 13);
            this.lblDataVencimento.TabIndex = 22;
            this.lblDataVencimento.Text = "Data de Vencimento";
            // 
            // txtDataFabricacao
            // 
            this.txtDataFabricacao.Location = new System.Drawing.Point(164, 260);
            this.txtDataFabricacao.Mask = "99/99/9999";
            this.txtDataFabricacao.Name = "txtDataFabricacao";
            this.txtDataFabricacao.Size = new System.Drawing.Size(101, 20);
            this.txtDataFabricacao.TabIndex = 4;
            // 
            // lblDataFabricacao
            // 
            this.lblDataFabricacao.AutoSize = true;
            this.lblDataFabricacao.Location = new System.Drawing.Point(161, 243);
            this.lblDataFabricacao.Name = "lblDataFabricacao";
            this.lblDataFabricacao.Size = new System.Drawing.Size(101, 13);
            this.lblDataFabricacao.TabIndex = 23;
            this.lblDataFabricacao.Text = "Data de Fabricação";
            // 
            // txtDataAvisoPrateleira
            // 
            this.txtDataAvisoPrateleira.Location = new System.Drawing.Point(285, 260);
            this.txtDataAvisoPrateleira.Mask = "99/99/9999";
            this.txtDataAvisoPrateleira.Name = "txtDataAvisoPrateleira";
            this.txtDataAvisoPrateleira.Size = new System.Drawing.Size(101, 20);
            this.txtDataAvisoPrateleira.TabIndex = 5;
            // 
            // lblDataAvisoPrateleira
            // 
            this.lblDataAvisoPrateleira.AutoSize = true;
            this.lblDataAvisoPrateleira.Location = new System.Drawing.Point(282, 243);
            this.lblDataAvisoPrateleira.Name = "lblDataAvisoPrateleira";
            this.lblDataAvisoPrateleira.Size = new System.Drawing.Size(121, 13);
            this.lblDataAvisoPrateleira.TabIndex = 24;
            this.lblDataAvisoPrateleira.Text = "Data de Aviso Prateleira";
            // 
            // txtDataValidade
            // 
            this.txtDataValidade.Location = new System.Drawing.Point(412, 260);
            this.txtDataValidade.Mask = "99/99/9999";
            this.txtDataValidade.Name = "txtDataValidade";
            this.txtDataValidade.Size = new System.Drawing.Size(101, 20);
            this.txtDataValidade.TabIndex = 6;
            // 
            // lblDataValidade
            // 
            this.lblDataValidade.AutoSize = true;
            this.lblDataValidade.Location = new System.Drawing.Point(409, 243);
            this.lblDataValidade.Name = "lblDataValidade";
            this.lblDataValidade.Size = new System.Drawing.Size(89, 13);
            this.lblDataValidade.TabIndex = 25;
            this.lblDataValidade.Text = "Data de Validade";
            // 
            // txtLoteInterno
            // 
            this.txtLoteInterno.Location = new System.Drawing.Point(45, 187);
            this.txtLoteInterno.MaxLength = 10;
            this.txtLoteInterno.Name = "txtLoteInterno";
            this.txtLoteInterno.Size = new System.Drawing.Size(101, 20);
            this.txtLoteInterno.TabIndex = 1;
            this.txtLoteInterno.Tag = "";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(42, 171);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(64, 13);
            this.lblNumero.TabIndex = 20;
            this.lblNumero.Text = "Lote Interno";
            // 
            // txtLoteFornecedor
            // 
            this.txtLoteFornecedor.Location = new System.Drawing.Point(164, 187);
            this.txtLoteFornecedor.MaxLength = 10;
            this.txtLoteFornecedor.Name = "txtLoteFornecedor";
            this.txtLoteFornecedor.Size = new System.Drawing.Size(101, 20);
            this.txtLoteFornecedor.TabIndex = 8;
            this.txtLoteFornecedor.Tag = "";
            // 
            // lblFornecedorNumero
            // 
            this.lblFornecedorNumero.AutoSize = true;
            this.lblFornecedorNumero.Location = new System.Drawing.Point(161, 171);
            this.lblFornecedorNumero.Name = "lblFornecedorNumero";
            this.lblFornecedorNumero.Size = new System.Drawing.Size(85, 13);
            this.lblFornecedorNumero.TabIndex = 27;
            this.lblFornecedorNumero.Text = "Lote Fornecedor";
            // 
            // frmRecebimentoCompraLoteAux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(644, 337);
            this.Controls.Add(this.txtLoteFornecedor);
            this.Controls.Add(this.lblFornecedorNumero);
            this.Controls.Add(this.txtLoteInterno);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.txtDataValidade);
            this.Controls.Add(this.lblDataValidade);
            this.Controls.Add(this.txtDataAvisoPrateleira);
            this.Controls.Add(this.lblDataAvisoPrateleira);
            this.Controls.Add(this.txtDataFabricacao);
            this.Controls.Add(this.lblDataFabricacao);
            this.Controls.Add(this.txtDataVencimento);
            this.Controls.Add(this.lblDataVencimento);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmRecebimentoCompraLoteAux";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmRecebimentoItemLoteAux";
            this.Text = "Lote";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.MaskedTextBox txtDataVencimento;
        private System.Windows.Forms.Label lblDataVencimento;
        private System.Windows.Forms.MaskedTextBox txtDataFabricacao;
        private System.Windows.Forms.Label lblDataFabricacao;
        private System.Windows.Forms.MaskedTextBox txtDataAvisoPrateleira;
        private System.Windows.Forms.Label lblDataAvisoPrateleira;
        private System.Windows.Forms.MaskedTextBox txtDataValidade;
        private System.Windows.Forms.Label lblDataValidade;
        private System.Windows.Forms.TextBox txtLoteInterno;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtLoteFornecedor;
        private System.Windows.Forms.Label lblFornecedorNumero;
    }
}