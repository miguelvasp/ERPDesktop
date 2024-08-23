namespace ERP
{
    partial class frmMetodoDepreciacaoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMetodoDepreciacaoCad));
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
            this.chkDepreciacao = new System.Windows.Forms.CheckBox();
            this.cboPerfilDepreciacaoComum = new System.Windows.Forms.ComboBox();
            this.lblPerfilDepreciacaoComum = new System.Windows.Forms.Label();
            this.cboPerfilDepreciacaoAlternativa = new System.Windows.Forms.ComboBox();
            this.lblPerfilDepreciacaoAlternativa = new System.Windows.Forms.Label();
            this.cboPerfilDepreciacaoExtraordinaria = new System.Windows.Forms.ComboBox();
            this.lblPerfilDepreciacaoExtraordinaria = new System.Windows.Forms.Label();
            this.txtArredondamento = new System.Windows.Forms.TextBox();
            this.lblArredondamento = new System.Windows.Forms.Label();
            this.txtManterValorLiquidoEm = new System.Windows.Forms.TextBox();
            this.lblManterValorLiquidoem = new System.Windows.Forms.Label();
            this.cboNivelLancamento = new System.Windows.Forms.ComboBox();
            this.lblNivelLancamento = new System.Windows.Forms.Label();
            this.chkPermitirCustoSuperiorAquisicao = new System.Windows.Forms.CheckBox();
            this.chkPermitirValorNegativo = new System.Windows.Forms.CheckBox();
            this.cboConvencao = new System.Windows.Forms.ComboBox();
            this.lblConvencao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(34, 156);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(343, 20);
            this.txtDescricao.TabIndex = 17;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(31, 140);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 16;
            this.lblDescricao.Text = "Descrição";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(358, 140);
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
            this.ribbon1.Size = new System.Drawing.Size(407, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // chkDepreciacao
            // 
            this.chkDepreciacao.AutoSize = true;
            this.chkDepreciacao.Location = new System.Drawing.Point(34, 191);
            this.chkDepreciacao.Name = "chkDepreciacao";
            this.chkDepreciacao.Size = new System.Drawing.Size(87, 17);
            this.chkDepreciacao.TabIndex = 18;
            this.chkDepreciacao.Text = "Depreciação";
            this.chkDepreciacao.UseVisualStyleBackColor = true;
            // 
            // cboPerfilDepreciacaoComum
            // 
            this.cboPerfilDepreciacaoComum.FormattingEnabled = true;
            this.cboPerfilDepreciacaoComum.Location = new System.Drawing.Point(34, 236);
            this.cboPerfilDepreciacaoComum.Name = "cboPerfilDepreciacaoComum";
            this.cboPerfilDepreciacaoComum.Size = new System.Drawing.Size(170, 21);
            this.cboPerfilDepreciacaoComum.TabIndex = 20;
            this.cboPerfilDepreciacaoComum.Tag = "";
            // 
            // lblPerfilDepreciacaoComum
            // 
            this.lblPerfilDepreciacaoComum.AutoSize = true;
            this.lblPerfilDepreciacaoComum.Location = new System.Drawing.Point(31, 221);
            this.lblPerfilDepreciacaoComum.Name = "lblPerfilDepreciacaoComum";
            this.lblPerfilDepreciacaoComum.Size = new System.Drawing.Size(138, 13);
            this.lblPerfilDepreciacaoComum.TabIndex = 19;
            this.lblPerfilDepreciacaoComum.Text = "Perfil Depreciação (Comum)";
            // 
            // cboPerfilDepreciacaoAlternativa
            // 
            this.cboPerfilDepreciacaoAlternativa.FormattingEnabled = true;
            this.cboPerfilDepreciacaoAlternativa.Location = new System.Drawing.Point(211, 236);
            this.cboPerfilDepreciacaoAlternativa.Name = "cboPerfilDepreciacaoAlternativa";
            this.cboPerfilDepreciacaoAlternativa.Size = new System.Drawing.Size(170, 21);
            this.cboPerfilDepreciacaoAlternativa.TabIndex = 22;
            this.cboPerfilDepreciacaoAlternativa.Tag = "";
            // 
            // lblPerfilDepreciacaoAlternativa
            // 
            this.lblPerfilDepreciacaoAlternativa.AutoSize = true;
            this.lblPerfilDepreciacaoAlternativa.Location = new System.Drawing.Point(208, 221);
            this.lblPerfilDepreciacaoAlternativa.Name = "lblPerfilDepreciacaoAlternativa";
            this.lblPerfilDepreciacaoAlternativa.Size = new System.Drawing.Size(153, 13);
            this.lblPerfilDepreciacaoAlternativa.TabIndex = 21;
            this.lblPerfilDepreciacaoAlternativa.Text = "Perfil Depreciação (Alternativa)";
            // 
            // cboPerfilDepreciacaoExtraordinaria
            // 
            this.cboPerfilDepreciacaoExtraordinaria.FormattingEnabled = true;
            this.cboPerfilDepreciacaoExtraordinaria.Location = new System.Drawing.Point(34, 293);
            this.cboPerfilDepreciacaoExtraordinaria.Name = "cboPerfilDepreciacaoExtraordinaria";
            this.cboPerfilDepreciacaoExtraordinaria.Size = new System.Drawing.Size(170, 21);
            this.cboPerfilDepreciacaoExtraordinaria.TabIndex = 24;
            this.cboPerfilDepreciacaoExtraordinaria.Tag = "";
            // 
            // lblPerfilDepreciacaoExtraordinaria
            // 
            this.lblPerfilDepreciacaoExtraordinaria.AutoSize = true;
            this.lblPerfilDepreciacaoExtraordinaria.Location = new System.Drawing.Point(31, 278);
            this.lblPerfilDepreciacaoExtraordinaria.Name = "lblPerfilDepreciacaoExtraordinaria";
            this.lblPerfilDepreciacaoExtraordinaria.Size = new System.Drawing.Size(167, 13);
            this.lblPerfilDepreciacaoExtraordinaria.TabIndex = 23;
            this.lblPerfilDepreciacaoExtraordinaria.Text = "Perfil Depreciação (Extraordinária)";
            // 
            // txtArredondamento
            // 
            this.txtArredondamento.Location = new System.Drawing.Point(34, 344);
            this.txtArredondamento.MaxLength = 10;
            this.txtArredondamento.Name = "txtArredondamento";
            this.txtArredondamento.Size = new System.Drawing.Size(166, 20);
            this.txtArredondamento.TabIndex = 26;
            this.txtArredondamento.Tag = "3";
            this.txtArredondamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtArredondamento_KeyPress);
            // 
            // lblArredondamento
            // 
            this.lblArredondamento.AutoSize = true;
            this.lblArredondamento.Location = new System.Drawing.Point(31, 328);
            this.lblArredondamento.Name = "lblArredondamento";
            this.lblArredondamento.Size = new System.Drawing.Size(85, 13);
            this.lblArredondamento.TabIndex = 25;
            this.lblArredondamento.Text = "Arredondamento";
            // 
            // txtManterValorLiquidoEm
            // 
            this.txtManterValorLiquidoEm.Location = new System.Drawing.Point(211, 344);
            this.txtManterValorLiquidoEm.MaxLength = 10;
            this.txtManterValorLiquidoEm.Name = "txtManterValorLiquidoEm";
            this.txtManterValorLiquidoEm.Size = new System.Drawing.Size(166, 20);
            this.txtManterValorLiquidoEm.TabIndex = 28;
            this.txtManterValorLiquidoEm.Tag = "3";
            this.txtManterValorLiquidoEm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtManterValorLiquidoEm_KeyPress);
            // 
            // lblManterValorLiquidoem
            // 
            this.lblManterValorLiquidoem.AutoSize = true;
            this.lblManterValorLiquidoem.Location = new System.Drawing.Point(208, 328);
            this.lblManterValorLiquidoem.Name = "lblManterValorLiquidoem";
            this.lblManterValorLiquidoem.Size = new System.Drawing.Size(123, 13);
            this.lblManterValorLiquidoem.TabIndex = 27;
            this.lblManterValorLiquidoem.Text = "Manter Valor Líquido em";
            // 
            // cboNivelLancamento
            // 
            this.cboNivelLancamento.FormattingEnabled = true;
            this.cboNivelLancamento.Location = new System.Drawing.Point(34, 399);
            this.cboNivelLancamento.Name = "cboNivelLancamento";
            this.cboNivelLancamento.Size = new System.Drawing.Size(170, 21);
            this.cboNivelLancamento.TabIndex = 30;
            this.cboNivelLancamento.Tag = "1";
            // 
            // lblNivelLancamento
            // 
            this.lblNivelLancamento.AutoSize = true;
            this.lblNivelLancamento.Location = new System.Drawing.Point(31, 384);
            this.lblNivelLancamento.Name = "lblNivelLancamento";
            this.lblNivelLancamento.Size = new System.Drawing.Size(110, 13);
            this.lblNivelLancamento.TabIndex = 29;
            this.lblNivelLancamento.Text = "Nível de Lançamento";
            // 
            // chkPermitirCustoSuperiorAquisicao
            // 
            this.chkPermitirCustoSuperiorAquisicao.AutoSize = true;
            this.chkPermitirCustoSuperiorAquisicao.Location = new System.Drawing.Point(211, 384);
            this.chkPermitirCustoSuperiorAquisicao.Name = "chkPermitirCustoSuperiorAquisicao";
            this.chkPermitirCustoSuperiorAquisicao.Size = new System.Drawing.Size(190, 17);
            this.chkPermitirCustoSuperiorAquisicao.TabIndex = 31;
            this.chkPermitirCustoSuperiorAquisicao.Text = "Permitir Custo Superior a Aquisição";
            this.chkPermitirCustoSuperiorAquisicao.UseVisualStyleBackColor = true;
            // 
            // chkPermitirValorNegativo
            // 
            this.chkPermitirValorNegativo.AutoSize = true;
            this.chkPermitirValorNegativo.Location = new System.Drawing.Point(211, 407);
            this.chkPermitirValorNegativo.Name = "chkPermitirValorNegativo";
            this.chkPermitirValorNegativo.Size = new System.Drawing.Size(133, 17);
            this.chkPermitirValorNegativo.TabIndex = 32;
            this.chkPermitirValorNegativo.Text = "Permitir Valor Negativo";
            this.chkPermitirValorNegativo.UseVisualStyleBackColor = true;
            // 
            // cboConvencao
            // 
            this.cboConvencao.FormattingEnabled = true;
            this.cboConvencao.Location = new System.Drawing.Point(34, 447);
            this.cboConvencao.Name = "cboConvencao";
            this.cboConvencao.Size = new System.Drawing.Size(170, 21);
            this.cboConvencao.TabIndex = 34;
            this.cboConvencao.Tag = "1";
            // 
            // lblConvencao
            // 
            this.lblConvencao.AutoSize = true;
            this.lblConvencao.Location = new System.Drawing.Point(31, 432);
            this.lblConvencao.Name = "lblConvencao";
            this.lblConvencao.Size = new System.Drawing.Size(62, 13);
            this.lblConvencao.TabIndex = 33;
            this.lblConvencao.Text = "Convenção";
            // 
            // frmMetodoDepreciacaoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(407, 502);
            this.Controls.Add(this.cboConvencao);
            this.Controls.Add(this.lblConvencao);
            this.Controls.Add(this.chkPermitirValorNegativo);
            this.Controls.Add(this.chkPermitirCustoSuperiorAquisicao);
            this.Controls.Add(this.cboNivelLancamento);
            this.Controls.Add(this.lblNivelLancamento);
            this.Controls.Add(this.txtManterValorLiquidoEm);
            this.Controls.Add(this.lblManterValorLiquidoem);
            this.Controls.Add(this.txtArredondamento);
            this.Controls.Add(this.lblArredondamento);
            this.Controls.Add(this.cboPerfilDepreciacaoExtraordinaria);
            this.Controls.Add(this.lblPerfilDepreciacaoExtraordinaria);
            this.Controls.Add(this.cboPerfilDepreciacaoAlternativa);
            this.Controls.Add(this.lblPerfilDepreciacaoAlternativa);
            this.Controls.Add(this.cboPerfilDepreciacaoComum);
            this.Controls.Add(this.lblPerfilDepreciacaoComum);
            this.Controls.Add(this.chkDepreciacao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMetodoDepreciacaoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmMetodoDepreciacaoCad";
            this.Text = "Cadastro Método de Depreciação";
            this.Load += new System.EventHandler(this.frmMetodoDepreciacaoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMetodoDepreciacaoCad_KeyDown);
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
        private System.Windows.Forms.CheckBox chkDepreciacao;
        private System.Windows.Forms.ComboBox cboPerfilDepreciacaoComum;
        private System.Windows.Forms.Label lblPerfilDepreciacaoComum;
        private System.Windows.Forms.ComboBox cboPerfilDepreciacaoAlternativa;
        private System.Windows.Forms.Label lblPerfilDepreciacaoAlternativa;
        private System.Windows.Forms.ComboBox cboPerfilDepreciacaoExtraordinaria;
        private System.Windows.Forms.Label lblPerfilDepreciacaoExtraordinaria;
        private System.Windows.Forms.TextBox txtArredondamento;
        private System.Windows.Forms.Label lblArredondamento;
        private System.Windows.Forms.TextBox txtManterValorLiquidoEm;
        private System.Windows.Forms.Label lblManterValorLiquidoem;
        private System.Windows.Forms.ComboBox cboNivelLancamento;
        private System.Windows.Forms.Label lblNivelLancamento;
        private System.Windows.Forms.CheckBox chkPermitirCustoSuperiorAquisicao;
        private System.Windows.Forms.CheckBox chkPermitirValorNegativo;
        private System.Windows.Forms.ComboBox cboConvencao;
        private System.Windows.Forms.Label lblConvencao;
    }
}