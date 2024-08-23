namespace ERP
{
    partial class frmGrupoEstoqueCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoEstoqueCad));
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.chkEstoqueFinanceiro = new System.Windows.Forms.CheckBox();
            this.chkEstoqueFisico = new System.Windows.Forms.CheckBox();
            this.chkEstoqueNegativo = new System.Windows.Forms.CheckBox();
            this.chkEstoque = new System.Windows.Forms.CheckBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.cboModeloEstoque = new System.Windows.Forms.ComboBox();
            this.lblModeloEstoque = new System.Windows.Forms.Label();
            this.chkLoteFornecedor = new System.Windows.Forms.CheckBox();
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
            this.ribbon1.Size = new System.Drawing.Size(403, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // chkEstoqueFinanceiro
            // 
            this.chkEstoqueFinanceiro.AutoSize = true;
            this.chkEstoqueFinanceiro.Location = new System.Drawing.Point(138, 261);
            this.chkEstoqueFinanceiro.Name = "chkEstoqueFinanceiro";
            this.chkEstoqueFinanceiro.Size = new System.Drawing.Size(117, 17);
            this.chkEstoqueFinanceiro.TabIndex = 44;
            this.chkEstoqueFinanceiro.Text = "Estoque Financeiro";
            this.chkEstoqueFinanceiro.UseVisualStyleBackColor = true;
            // 
            // chkEstoqueFisico
            // 
            this.chkEstoqueFisico.AutoSize = true;
            this.chkEstoqueFisico.Location = new System.Drawing.Point(15, 261);
            this.chkEstoqueFisico.Name = "chkEstoqueFisico";
            this.chkEstoqueFisico.Size = new System.Drawing.Size(97, 17);
            this.chkEstoqueFisico.TabIndex = 43;
            this.chkEstoqueFisico.Text = "Estoque Físico";
            this.chkEstoqueFisico.UseVisualStyleBackColor = true;
            // 
            // chkEstoqueNegativo
            // 
            this.chkEstoqueNegativo.AutoSize = true;
            this.chkEstoqueNegativo.Location = new System.Drawing.Point(138, 238);
            this.chkEstoqueNegativo.Name = "chkEstoqueNegativo";
            this.chkEstoqueNegativo.Size = new System.Drawing.Size(111, 17);
            this.chkEstoqueNegativo.TabIndex = 42;
            this.chkEstoqueNegativo.Text = "Estoque Negativo";
            this.chkEstoqueNegativo.UseVisualStyleBackColor = true;
            // 
            // chkEstoque
            // 
            this.chkEstoque.AutoSize = true;
            this.chkEstoque.Location = new System.Drawing.Point(15, 238);
            this.chkEstoque.Name = "chkEstoque";
            this.chkEstoque.Size = new System.Drawing.Size(65, 17);
            this.chkEstoque.TabIndex = 41;
            this.chkEstoque.Text = "Estoque";
            this.chkEstoque.UseVisualStyleBackColor = true;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(15, 203);
            this.txtDescricao.MaxLength = 255;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(380, 20);
            this.txtDescricao.TabIndex = 40;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(12, 186);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 39;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(15, 154);
            this.txtNome.MaxLength = 255;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(380, 20);
            this.txtNome.TabIndex = 38;
            this.txtNome.Tag = "1";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(12, 137);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 37;
            this.lblNome.Text = "Nome";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(339, 138);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 36;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
            // 
            // cboModeloEstoque
            // 
            this.cboModeloEstoque.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboModeloEstoque.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModeloEstoque.DropDownWidth = 170;
            this.cboModeloEstoque.FormattingEnabled = true;
            this.cboModeloEstoque.Location = new System.Drawing.Point(15, 329);
            this.cboModeloEstoque.Name = "cboModeloEstoque";
            this.cboModeloEstoque.Size = new System.Drawing.Size(175, 21);
            this.cboModeloEstoque.TabIndex = 47;
            this.cboModeloEstoque.Tag = "1";
            // 
            // lblModeloEstoque
            // 
            this.lblModeloEstoque.AutoSize = true;
            this.lblModeloEstoque.Location = new System.Drawing.Point(12, 313);
            this.lblModeloEstoque.Name = "lblModeloEstoque";
            this.lblModeloEstoque.Size = new System.Drawing.Size(84, 13);
            this.lblModeloEstoque.TabIndex = 46;
            this.lblModeloEstoque.Text = "Modelo Estoque";
            // 
            // chkLoteFornecedor
            // 
            this.chkLoteFornecedor.AutoSize = true;
            this.chkLoteFornecedor.Location = new System.Drawing.Point(15, 284);
            this.chkLoteFornecedor.Name = "chkLoteFornecedor";
            this.chkLoteFornecedor.Size = new System.Drawing.Size(104, 17);
            this.chkLoteFornecedor.TabIndex = 45;
            this.chkLoteFornecedor.Text = "Lote Fornecedor";
            this.chkLoteFornecedor.UseVisualStyleBackColor = true;
            // 
            // frmGrupoEstoqueCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(403, 355);
            this.Controls.Add(this.chkLoteFornecedor);
            this.Controls.Add(this.cboModeloEstoque);
            this.Controls.Add(this.lblModeloEstoque);
            this.Controls.Add(this.chkEstoqueFinanceiro);
            this.Controls.Add(this.chkEstoqueFisico);
            this.Controls.Add(this.chkEstoqueNegativo);
            this.Controls.Add(this.chkEstoque);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmGrupoEstoqueCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmGrupoEstoqueCad";
            this.Text = "Cadastro Grupo Estoque";
            this.Load += new System.EventHandler(this.frmGrupoEstoqueCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGrupoEstoqueCad_KeyDown);
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
        private System.Windows.Forms.CheckBox chkEstoqueFinanceiro;
        private System.Windows.Forms.CheckBox chkEstoqueFisico;
        private System.Windows.Forms.CheckBox chkEstoqueNegativo;
        private System.Windows.Forms.CheckBox chkEstoque;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.ComboBox cboModeloEstoque;
        private System.Windows.Forms.Label lblModeloEstoque;
        private System.Windows.Forms.CheckBox chkLoteFornecedor;
    }
}