namespace ERP
{
    partial class frmTempoDepreciacaoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTempoDepreciacaoCad));
            this.lbCodigo = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.cboGrupoAtivo = new System.Windows.Forms.ComboBox();
            this.lblGrupoAtivo = new System.Windows.Forms.Label();
            this.cboNivelLancamento = new System.Windows.Forms.ComboBox();
            this.lblNivelLancamento = new System.Windows.Forms.Label();
            this.cboPDComum = new System.Windows.Forms.ComboBox();
            this.lblPDComum = new System.Windows.Forms.Label();
            this.cboPDAlternativa = new System.Windows.Forms.ComboBox();
            this.lblPDAlternativa = new System.Windows.Forms.Label();
            this.cboPDExtraordinaria = new System.Windows.Forms.ComboBox();
            this.lblPDExtraordinaria = new System.Windows.Forms.Label();
            this.txtArredondamento = new System.Windows.Forms.TextBox();
            this.lblArredondamento = new System.Windows.Forms.Label();
            this.cboConvencao = new System.Windows.Forms.ComboBox();
            this.lblConvencao = new System.Windows.Forms.Label();
            this.chkDepreciacao = new System.Windows.Forms.CheckBox();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.lblPerido = new System.Windows.Forms.Label();
            this.txtVidaUtil = new System.Windows.Forms.TextBox();
            this.lblVidaUtil = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(338, 142);
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
            this.ribbon1.Size = new System.Drawing.Size(572, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // cboGrupoAtivo
            // 
            this.cboGrupoAtivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGrupoAtivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGrupoAtivo.DropDownWidth = 255;
            this.cboGrupoAtivo.FormattingEnabled = true;
            this.cboGrupoAtivo.Location = new System.Drawing.Point(15, 157);
            this.cboGrupoAtivo.Name = "cboGrupoAtivo";
            this.cboGrupoAtivo.Size = new System.Drawing.Size(177, 21);
            this.cboGrupoAtivo.TabIndex = 25;
            this.cboGrupoAtivo.Tag = "1";
            // 
            // lblGrupoAtivo
            // 
            this.lblGrupoAtivo.AutoSize = true;
            this.lblGrupoAtivo.Location = new System.Drawing.Point(12, 142);
            this.lblGrupoAtivo.Name = "lblGrupoAtivo";
            this.lblGrupoAtivo.Size = new System.Drawing.Size(63, 13);
            this.lblGrupoAtivo.TabIndex = 24;
            this.lblGrupoAtivo.Text = "Grupo Ativo";
            // 
            // cboNivelLancamento
            // 
            this.cboNivelLancamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboNivelLancamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboNivelLancamento.DropDownWidth = 255;
            this.cboNivelLancamento.FormattingEnabled = true;
            this.cboNivelLancamento.Location = new System.Drawing.Point(15, 205);
            this.cboNivelLancamento.Name = "cboNivelLancamento";
            this.cboNivelLancamento.Size = new System.Drawing.Size(177, 21);
            this.cboNivelLancamento.TabIndex = 28;
            this.cboNivelLancamento.Tag = "";
            // 
            // lblNivelLancamento
            // 
            this.lblNivelLancamento.AutoSize = true;
            this.lblNivelLancamento.Location = new System.Drawing.Point(12, 190);
            this.lblNivelLancamento.Name = "lblNivelLancamento";
            this.lblNivelLancamento.Size = new System.Drawing.Size(110, 13);
            this.lblNivelLancamento.TabIndex = 27;
            this.lblNivelLancamento.Text = "Nível de Lançamento";
            // 
            // cboPDComum
            // 
            this.cboPDComum.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPDComum.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPDComum.DropDownWidth = 255;
            this.cboPDComum.FormattingEnabled = true;
            this.cboPDComum.Location = new System.Drawing.Point(15, 258);
            this.cboPDComum.Name = "cboPDComum";
            this.cboPDComum.Size = new System.Drawing.Size(177, 21);
            this.cboPDComum.TabIndex = 30;
            this.cboPDComum.Tag = "";
            // 
            // lblPDComum
            // 
            this.lblPDComum.AutoSize = true;
            this.lblPDComum.Location = new System.Drawing.Point(12, 243);
            this.lblPDComum.Name = "lblPDComum";
            this.lblPDComum.Size = new System.Drawing.Size(138, 13);
            this.lblPDComum.TabIndex = 29;
            this.lblPDComum.Text = "Perfil Depreciação (Comum)";
            // 
            // cboPDAlternativa
            // 
            this.cboPDAlternativa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPDAlternativa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPDAlternativa.DropDownWidth = 255;
            this.cboPDAlternativa.FormattingEnabled = true;
            this.cboPDAlternativa.Location = new System.Drawing.Point(198, 258);
            this.cboPDAlternativa.Name = "cboPDAlternativa";
            this.cboPDAlternativa.Size = new System.Drawing.Size(177, 21);
            this.cboPDAlternativa.TabIndex = 32;
            this.cboPDAlternativa.Tag = "";
            // 
            // lblPDAlternativa
            // 
            this.lblPDAlternativa.AutoSize = true;
            this.lblPDAlternativa.Location = new System.Drawing.Point(195, 243);
            this.lblPDAlternativa.Name = "lblPDAlternativa";
            this.lblPDAlternativa.Size = new System.Drawing.Size(153, 13);
            this.lblPDAlternativa.TabIndex = 31;
            this.lblPDAlternativa.Text = "Perfil Depreciação (Alternativa)";
            // 
            // cboPDExtraordinaria
            // 
            this.cboPDExtraordinaria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPDExtraordinaria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPDExtraordinaria.DropDownWidth = 255;
            this.cboPDExtraordinaria.FormattingEnabled = true;
            this.cboPDExtraordinaria.Location = new System.Drawing.Point(381, 258);
            this.cboPDExtraordinaria.Name = "cboPDExtraordinaria";
            this.cboPDExtraordinaria.Size = new System.Drawing.Size(177, 21);
            this.cboPDExtraordinaria.TabIndex = 34;
            this.cboPDExtraordinaria.Tag = "";
            // 
            // lblPDExtraordinaria
            // 
            this.lblPDExtraordinaria.AutoSize = true;
            this.lblPDExtraordinaria.Location = new System.Drawing.Point(378, 243);
            this.lblPDExtraordinaria.Name = "lblPDExtraordinaria";
            this.lblPDExtraordinaria.Size = new System.Drawing.Size(167, 13);
            this.lblPDExtraordinaria.TabIndex = 33;
            this.lblPDExtraordinaria.Text = "Perfil Depreciação (Extraordinária)";
            // 
            // txtArredondamento
            // 
            this.txtArredondamento.Location = new System.Drawing.Point(15, 311);
            this.txtArredondamento.MaxLength = 10;
            this.txtArredondamento.Name = "txtArredondamento";
            this.txtArredondamento.Size = new System.Drawing.Size(177, 20);
            this.txtArredondamento.TabIndex = 36;
            this.txtArredondamento.Tag = "3";
            this.txtArredondamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtArredondamento_KeyPress);
            // 
            // lblArredondamento
            // 
            this.lblArredondamento.AutoSize = true;
            this.lblArredondamento.Location = new System.Drawing.Point(12, 295);
            this.lblArredondamento.Name = "lblArredondamento";
            this.lblArredondamento.Size = new System.Drawing.Size(85, 13);
            this.lblArredondamento.TabIndex = 35;
            this.lblArredondamento.Text = "Arredondamento";
            // 
            // cboConvencao
            // 
            this.cboConvencao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboConvencao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboConvencao.DropDownWidth = 255;
            this.cboConvencao.FormattingEnabled = true;
            this.cboConvencao.Location = new System.Drawing.Point(198, 310);
            this.cboConvencao.Name = "cboConvencao";
            this.cboConvencao.Size = new System.Drawing.Size(177, 21);
            this.cboConvencao.TabIndex = 38;
            this.cboConvencao.Tag = "";
            // 
            // lblConvencao
            // 
            this.lblConvencao.AutoSize = true;
            this.lblConvencao.Location = new System.Drawing.Point(195, 295);
            this.lblConvencao.Name = "lblConvencao";
            this.lblConvencao.Size = new System.Drawing.Size(62, 13);
            this.lblConvencao.TabIndex = 37;
            this.lblConvencao.Text = "Convenção";
            // 
            // chkDepreciacao
            // 
            this.chkDepreciacao.AutoSize = true;
            this.chkDepreciacao.Location = new System.Drawing.Point(198, 161);
            this.chkDepreciacao.Name = "chkDepreciacao";
            this.chkDepreciacao.Size = new System.Drawing.Size(87, 17);
            this.chkDepreciacao.TabIndex = 26;
            this.chkDepreciacao.Text = "Depreciação";
            this.chkDepreciacao.UseVisualStyleBackColor = true;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(15, 362);
            this.txtPeriodo.MaxLength = 10;
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(177, 20);
            this.txtPeriodo.TabIndex = 40;
            this.txtPeriodo.Tag = "3";
            this.txtPeriodo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeriodo_KeyPress);
            // 
            // lblPerido
            // 
            this.lblPerido.AutoSize = true;
            this.lblPerido.Location = new System.Drawing.Point(12, 346);
            this.lblPerido.Name = "lblPerido";
            this.lblPerido.Size = new System.Drawing.Size(45, 13);
            this.lblPerido.TabIndex = 39;
            this.lblPerido.Text = "Período";
            // 
            // txtVidaUtil
            // 
            this.txtVidaUtil.Location = new System.Drawing.Point(198, 362);
            this.txtVidaUtil.MaxLength = 10;
            this.txtVidaUtil.Name = "txtVidaUtil";
            this.txtVidaUtil.Size = new System.Drawing.Size(177, 20);
            this.txtVidaUtil.TabIndex = 42;
            this.txtVidaUtil.Tag = "3";
            this.txtVidaUtil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVidaUtil_KeyPress);
            // 
            // lblVidaUtil
            // 
            this.lblVidaUtil.AutoSize = true;
            this.lblVidaUtil.Location = new System.Drawing.Point(195, 346);
            this.lblVidaUtil.Name = "lblVidaUtil";
            this.lblVidaUtil.Size = new System.Drawing.Size(46, 13);
            this.lblVidaUtil.TabIndex = 41;
            this.lblVidaUtil.Text = "Vida Útil";
            // 
            // frmTempoDepreciacaoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(572, 418);
            this.Controls.Add(this.txtVidaUtil);
            this.Controls.Add(this.lblVidaUtil);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.lblPerido);
            this.Controls.Add(this.chkDepreciacao);
            this.Controls.Add(this.cboConvencao);
            this.Controls.Add(this.lblConvencao);
            this.Controls.Add(this.txtArredondamento);
            this.Controls.Add(this.lblArredondamento);
            this.Controls.Add(this.cboPDExtraordinaria);
            this.Controls.Add(this.lblPDExtraordinaria);
            this.Controls.Add(this.cboPDAlternativa);
            this.Controls.Add(this.lblPDAlternativa);
            this.Controls.Add(this.cboPDComum);
            this.Controls.Add(this.lblPDComum);
            this.Controls.Add(this.cboNivelLancamento);
            this.Controls.Add(this.lblNivelLancamento);
            this.Controls.Add(this.cboGrupoAtivo);
            this.Controls.Add(this.lblGrupoAtivo);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmTempoDepreciacaoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmTempoDepreciacaoCad";
            this.Text = "Cadastro de Tempo Depreciação";
            this.Load += new System.EventHandler(this.frmTempoDepreciacaoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTempoDepreciacaoCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.ComboBox cboGrupoAtivo;
        private System.Windows.Forms.Label lblGrupoAtivo;
        private System.Windows.Forms.ComboBox cboNivelLancamento;
        private System.Windows.Forms.Label lblNivelLancamento;
        private System.Windows.Forms.ComboBox cboPDComum;
        private System.Windows.Forms.Label lblPDComum;
        private System.Windows.Forms.ComboBox cboPDAlternativa;
        private System.Windows.Forms.Label lblPDAlternativa;
        private System.Windows.Forms.ComboBox cboPDExtraordinaria;
        private System.Windows.Forms.Label lblPDExtraordinaria;
        private System.Windows.Forms.TextBox txtArredondamento;
        private System.Windows.Forms.Label lblArredondamento;
        private System.Windows.Forms.ComboBox cboConvencao;
        private System.Windows.Forms.Label lblConvencao;
        private System.Windows.Forms.CheckBox chkDepreciacao;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Label lblPerido;
        private System.Windows.Forms.TextBox txtVidaUtil;
        private System.Windows.Forms.Label lblVidaUtil;
    }
}