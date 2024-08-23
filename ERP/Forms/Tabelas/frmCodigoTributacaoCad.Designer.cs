namespace ERP
{
    partial class frmCodigoTributacaoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCodigoTributacaoCad));
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.lblDe = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.lblTipoImposto = new System.Windows.Forms.Label();
            this.lblValorFiscal = new System.Windows.Forms.Label();
            this.cboTipoImposto = new System.Windows.Forms.ComboBox();
            this.cboValorFiscal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoSped = new System.Windows.Forms.TextBox();
            this.txtCodigoEntrada = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoSaida = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(34, 158);
            this.txtCodigo.MaxLength = 200;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(341, 20);
            this.txtCodigo.TabIndex = 17;
            this.txtCodigo.Tag = "1";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(31, 142);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 16;
            this.lblCodigo.Text = "Código";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(358, 142);
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
            this.ribbon1.Size = new System.Drawing.Size(427, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(34, 206);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(341, 20);
            this.txtDescricao.TabIndex = 19;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(31, 190);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 18;
            this.lblDescricao.Text = "Descrição";
            // 
            // dtpDe
            // 
            this.dtpDe.Checked = false;
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.Location = new System.Drawing.Point(34, 255);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.ShowCheckBox = true;
            this.dtpDe.Size = new System.Drawing.Size(145, 20);
            this.dtpDe.TabIndex = 21;
            this.dtpDe.Tag = "";
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(31, 239);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(21, 13);
            this.lblDe.TabIndex = 20;
            this.lblDe.Text = "De";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Location = new System.Drawing.Point(226, 239);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(23, 13);
            this.lblAte.TabIndex = 22;
            this.lblAte.Text = "Até";
            // 
            // dtpAte
            // 
            this.dtpAte.Checked = false;
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(229, 255);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.ShowCheckBox = true;
            this.dtpAte.Size = new System.Drawing.Size(145, 20);
            this.dtpAte.TabIndex = 23;
            this.dtpAte.Tag = "";
            // 
            // lblTipoImposto
            // 
            this.lblTipoImposto.AutoSize = true;
            this.lblTipoImposto.Location = new System.Drawing.Point(31, 291);
            this.lblTipoImposto.Name = "lblTipoImposto";
            this.lblTipoImposto.Size = new System.Drawing.Size(68, 13);
            this.lblTipoImposto.TabIndex = 24;
            this.lblTipoImposto.Text = "Tipo Imposto";
            // 
            // lblValorFiscal
            // 
            this.lblValorFiscal.AutoSize = true;
            this.lblValorFiscal.Location = new System.Drawing.Point(31, 346);
            this.lblValorFiscal.Name = "lblValorFiscal";
            this.lblValorFiscal.Size = new System.Drawing.Size(61, 13);
            this.lblValorFiscal.TabIndex = 25;
            this.lblValorFiscal.Text = "Valor Fiscal";
            // 
            // cboTipoImposto
            // 
            this.cboTipoImposto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboTipoImposto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoImposto.FormattingEnabled = true;
            this.cboTipoImposto.Location = new System.Drawing.Point(34, 307);
            this.cboTipoImposto.Name = "cboTipoImposto";
            this.cboTipoImposto.Size = new System.Drawing.Size(217, 21);
            this.cboTipoImposto.TabIndex = 25;
            this.cboTipoImposto.Tag = "1";
            // 
            // cboValorFiscal
            // 
            this.cboValorFiscal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboValorFiscal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboValorFiscal.FormattingEnabled = true;
            this.cboValorFiscal.Location = new System.Drawing.Point(34, 362);
            this.cboValorFiscal.Name = "cboValorFiscal";
            this.cboValorFiscal.Size = new System.Drawing.Size(217, 21);
            this.cboValorFiscal.TabIndex = 26;
            this.cboValorFiscal.Tag = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Código SPED";
            // 
            // txtCodigoSped
            // 
            this.txtCodigoSped.Location = new System.Drawing.Point(34, 414);
            this.txtCodigoSped.Name = "txtCodigoSped";
            this.txtCodigoSped.Size = new System.Drawing.Size(217, 20);
            this.txtCodigoSped.TabIndex = 28;
            // 
            // txtCodigoEntrada
            // 
            this.txtCodigoEntrada.Location = new System.Drawing.Point(34, 458);
            this.txtCodigoEntrada.Name = "txtCodigoEntrada";
            this.txtCodigoEntrada.Size = new System.Drawing.Size(217, 20);
            this.txtCodigoEntrada.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 442);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Código Entrada";
            // 
            // txtCodigoSaida
            // 
            this.txtCodigoSaida.Location = new System.Drawing.Point(34, 508);
            this.txtCodigoSaida.Name = "txtCodigoSaida";
            this.txtCodigoSaida.Size = new System.Drawing.Size(217, 20);
            this.txtCodigoSaida.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 492);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Código Saída";
            // 
            // frmCodigoTributacaoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(427, 544);
            this.Controls.Add(this.txtCodigoSaida);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodigoEntrada);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigoSped);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboValorFiscal);
            this.Controls.Add(this.cboTipoImposto);
            this.Controls.Add(this.lblValorFiscal);
            this.Controls.Add(this.lblTipoImposto);
            this.Controls.Add(this.lblAte);
            this.Controls.Add(this.dtpAte);
            this.Controls.Add(this.lblDe);
            this.Controls.Add(this.dtpDe);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmCodigoTributacaoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmCodigoTributacaoCad";
            this.Text = "Cadastro Código de Tributação";
            this.Load += new System.EventHandler(this.frmCodigoTributacaoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCodigoTributacaoCad_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.Label lblTipoImposto;
        private System.Windows.Forms.Label lblValorFiscal;
        private System.Windows.Forms.ComboBox cboTipoImposto;
        private System.Windows.Forms.ComboBox cboValorFiscal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoSped;
        private System.Windows.Forms.TextBox txtCodigoEntrada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigoSaida;
        private System.Windows.Forms.Label label3;
    }
}