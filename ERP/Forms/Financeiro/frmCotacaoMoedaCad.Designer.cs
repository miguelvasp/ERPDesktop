﻿namespace ERP
{
    partial class frmCotacaoMoedaCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCotacaoMoedaCad));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.btnImprimir = new System.Windows.Forms.RibbonButton();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMoeda = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.MaskedTextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.ribbon1.Size = new System.Drawing.Size(394, 125);
            this.ribbon1.TabIndex = 2;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // rbOpcoes
            // 
            this.rbOpcoes.Panels.Add(this.ribbonPanel1);
            this.rbOpcoes.Panels.Add(this.ribbonPanel2);
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
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.btnImprimir);
            this.ribbonPanel2.Text = "Relatórios";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.SmallImage")));
            this.btnImprimir.Text = "Imprimir";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(304, 151);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 3;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Moeda";
            // 
            // cboMoeda
            // 
            this.cboMoeda.FormattingEnabled = true;
            this.cboMoeda.Location = new System.Drawing.Point(65, 180);
            this.cboMoeda.Name = "cboMoeda";
            this.cboMoeda.Size = new System.Drawing.Size(252, 21);
            this.cboMoeda.TabIndex = 5;
            this.cboMoeda.Tag = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(65, 229);
            this.txtData.Mask = "99/99/9999";
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(135, 20);
            this.txtData.TabIndex = 7;
            this.txtData.Tag = "2";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(65, 284);
            this.txtValor.MaxLength = 18;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(135, 20);
            this.txtValor.TabIndex = 8;
            this.txtValor.Tag = "3";
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Valor";
            // 
            // frmCotacaoMoedaCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(394, 359);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboMoeda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.Name = "frmCotacaoMoedaCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cotação de Moedas";
            this.Load += new System.EventHandler(this.frmCotacaoMoedaCad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab rbOpcoes;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton btnAdiciona;
        private System.Windows.Forms.RibbonButton btnAlterar;
        private System.Windows.Forms.RibbonButton btnGrava;
        private System.Windows.Forms.RibbonButton btnCancelar;
        private System.Windows.Forms.RibbonButton btnExcluir;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton btnImprimir;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMoeda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtData;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label4;
    }
}