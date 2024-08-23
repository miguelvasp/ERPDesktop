namespace ERP
{
    partial class frmCondPgtoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCondPgtoCad));
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
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtparcelas = new System.Windows.Forms.TextBox();
            this.chkForaSemana = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.cboMetodoPagamento = new System.Windows.Forms.ComboBox();
            this.lblMetodoPagamento = new System.Windows.Forms.Label();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.txtDias = new System.Windows.Forms.TextBox();
            this.lblDia = new System.Windows.Forms.Label();
            this.cboPlanoPagamento = new System.Windows.Forms.ComboBox();
            this.lblPlanoPagamento = new System.Windows.Forms.Label();
            this.cboDiaPagamento = new System.Windows.Forms.ComboBox();
            this.lblDiaPagamento = new System.Windows.Forms.Label();
            this.lblDataCorte = new System.Windows.Forms.Label();
            this.txtMesAdicional = new System.Windows.Forms.TextBox();
            this.lblMesAdicional = new System.Windows.Forms.Label();
            this.txtDataCorte = new System.Windows.Forms.MaskedTextBox();
            this.chkCondicaoVendas = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.ribbon1.Size = new System.Drawing.Size(559, 125);
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
            this.lbCodigo.Location = new System.Drawing.Point(520, 143);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 3;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(287, 143);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 6;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(290, 159);
            this.txtDescricao.MaxLength = 250;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(243, 20);
            this.txtDescricao.TabIndex = 7;
            this.txtDescricao.Tag = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Número de Parcelas";
            // 
            // txtparcelas
            // 
            this.txtparcelas.Location = new System.Drawing.Point(290, 292);
            this.txtparcelas.Name = "txtparcelas";
            this.txtparcelas.Size = new System.Drawing.Size(100, 20);
            this.txtparcelas.TabIndex = 23;
            this.txtparcelas.Tag = "3";
            // 
            // chkForaSemana
            // 
            this.chkForaSemana.AutoSize = true;
            this.chkForaSemana.Location = new System.Drawing.Point(407, 295);
            this.chkForaSemana.Name = "chkForaSemana";
            this.chkForaSemana.Size = new System.Drawing.Size(89, 17);
            this.chkForaSemana.TabIndex = 24;
            this.chkForaSemana.Text = "Fora Semana";
            this.chkForaSemana.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(27, 386);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(506, 181);
            this.dataGridView1.TabIndex = 25;
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IdIntervalo";
            this.Column1.HeaderText = "Código";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Dias";
            this.Column2.HeaderText = "Dias";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Percentual";
            this.Column3.HeaderText = "Percentual";
            this.Column3.Name = "Column3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Detalhamento do percentual das parcelas";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(27, 159);
            this.txtNome.MaxLength = 250;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(243, 20);
            this.txtNome.TabIndex = 5;
            this.txtNome.Tag = "1";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(24, 143);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 4;
            this.lblNome.Text = "Nome";
            // 
            // cboMetodoPagamento
            // 
            this.cboMetodoPagamento.FormattingEnabled = true;
            this.cboMetodoPagamento.Location = new System.Drawing.Point(27, 207);
            this.cboMetodoPagamento.Name = "cboMetodoPagamento";
            this.cboMetodoPagamento.Size = new System.Drawing.Size(243, 21);
            this.cboMetodoPagamento.TabIndex = 9;
            this.cboMetodoPagamento.Tag = "1";
            // 
            // lblMetodoPagamento
            // 
            this.lblMetodoPagamento.AutoSize = true;
            this.lblMetodoPagamento.Location = new System.Drawing.Point(24, 191);
            this.lblMetodoPagamento.Name = "lblMetodoPagamento";
            this.lblMetodoPagamento.Size = new System.Drawing.Size(100, 13);
            this.lblMetodoPagamento.TabIndex = 8;
            this.lblMetodoPagamento.Text = "Método Pagamento";
            // 
            // txtMes
            // 
            this.txtMes.Location = new System.Drawing.Point(290, 207);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(100, 20);
            this.txtMes.TabIndex = 11;
            this.txtMes.Tag = "4";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(287, 191);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(27, 13);
            this.lblMes.TabIndex = 10;
            this.lblMes.Text = "Mês";
            // 
            // txtDias
            // 
            this.txtDias.Location = new System.Drawing.Point(401, 207);
            this.txtDias.Name = "txtDias";
            this.txtDias.Size = new System.Drawing.Size(132, 20);
            this.txtDias.TabIndex = 13;
            this.txtDias.Tag = "4";
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.Location = new System.Drawing.Point(398, 191);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(28, 13);
            this.lblDia.TabIndex = 12;
            this.lblDia.Text = "Dias";
            // 
            // cboPlanoPagamento
            // 
            this.cboPlanoPagamento.FormattingEnabled = true;
            this.cboPlanoPagamento.Location = new System.Drawing.Point(27, 252);
            this.cboPlanoPagamento.Name = "cboPlanoPagamento";
            this.cboPlanoPagamento.Size = new System.Drawing.Size(243, 21);
            this.cboPlanoPagamento.TabIndex = 15;
            this.cboPlanoPagamento.Tag = "";
            // 
            // lblPlanoPagamento
            // 
            this.lblPlanoPagamento.AutoSize = true;
            this.lblPlanoPagamento.Location = new System.Drawing.Point(24, 236);
            this.lblPlanoPagamento.Name = "lblPlanoPagamento";
            this.lblPlanoPagamento.Size = new System.Drawing.Size(91, 13);
            this.lblPlanoPagamento.TabIndex = 14;
            this.lblPlanoPagamento.Text = "Plano Pagamento";
            // 
            // cboDiaPagamento
            // 
            this.cboDiaPagamento.FormattingEnabled = true;
            this.cboDiaPagamento.Location = new System.Drawing.Point(290, 252);
            this.cboDiaPagamento.Name = "cboDiaPagamento";
            this.cboDiaPagamento.Size = new System.Drawing.Size(243, 21);
            this.cboDiaPagamento.TabIndex = 17;
            this.cboDiaPagamento.Tag = "";
            // 
            // lblDiaPagamento
            // 
            this.lblDiaPagamento.AutoSize = true;
            this.lblDiaPagamento.Location = new System.Drawing.Point(287, 236);
            this.lblDiaPagamento.Name = "lblDiaPagamento";
            this.lblDiaPagamento.Size = new System.Drawing.Size(95, 13);
            this.lblDiaPagamento.TabIndex = 16;
            this.lblDiaPagamento.Text = "Dia de Pagamento";
            // 
            // lblDataCorte
            // 
            this.lblDataCorte.AutoSize = true;
            this.lblDataCorte.Location = new System.Drawing.Point(24, 276);
            this.lblDataCorte.Name = "lblDataCorte";
            this.lblDataCorte.Size = new System.Drawing.Size(73, 13);
            this.lblDataCorte.TabIndex = 18;
            this.lblDataCorte.Text = "Data de Corte";
            // 
            // txtMesAdicional
            // 
            this.txtMesAdicional.Location = new System.Drawing.Point(171, 292);
            this.txtMesAdicional.Name = "txtMesAdicional";
            this.txtMesAdicional.Size = new System.Drawing.Size(100, 20);
            this.txtMesAdicional.TabIndex = 21;
            this.txtMesAdicional.Tag = "4";
            this.txtMesAdicional.Text = "0";
            // 
            // lblMesAdicional
            // 
            this.lblMesAdicional.AutoSize = true;
            this.lblMesAdicional.Location = new System.Drawing.Point(168, 276);
            this.lblMesAdicional.Name = "lblMesAdicional";
            this.lblMesAdicional.Size = new System.Drawing.Size(73, 13);
            this.lblMesAdicional.TabIndex = 20;
            this.lblMesAdicional.Text = "Mês Adicional";
            // 
            // txtDataCorte
            // 
            this.txtDataCorte.Location = new System.Drawing.Point(27, 292);
            this.txtDataCorte.Mask = "99/99/9999";
            this.txtDataCorte.Name = "txtDataCorte";
            this.txtDataCorte.Size = new System.Drawing.Size(100, 20);
            this.txtDataCorte.TabIndex = 19;
            this.txtDataCorte.Tag = "";
            // 
            // chkCondicaoVendas
            // 
            this.chkCondicaoVendas.AutoSize = true;
            this.chkCondicaoVendas.Location = new System.Drawing.Point(27, 335);
            this.chkCondicaoVendas.Name = "chkCondicaoVendas";
            this.chkCondicaoVendas.Size = new System.Drawing.Size(197, 17);
            this.chkCondicaoVendas.TabIndex = 26;
            this.chkCondicaoVendas.Text = "Condição de Pagamento de Vendas";
            this.chkCondicaoVendas.UseVisualStyleBackColor = true;
            // 
            // frmCondPgtoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(559, 579);
            this.Controls.Add(this.chkCondicaoVendas);
            this.Controls.Add(this.txtDataCorte);
            this.Controls.Add(this.txtMesAdicional);
            this.Controls.Add(this.lblMesAdicional);
            this.Controls.Add(this.lblDataCorte);
            this.Controls.Add(this.cboDiaPagamento);
            this.Controls.Add(this.lblDiaPagamento);
            this.Controls.Add(this.cboPlanoPagamento);
            this.Controls.Add(this.lblPlanoPagamento);
            this.Controls.Add(this.txtDias);
            this.Controls.Add(this.lblDia);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.cboMetodoPagamento);
            this.Controls.Add(this.lblMetodoPagamento);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chkForaSemana);
            this.Controls.Add(this.txtparcelas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCondPgtoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Condição de Pagamento";
            this.Load += new System.EventHandler(this.frmCondPgtoCad_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmCondPgtoCad_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtparcelas;
        private System.Windows.Forms.CheckBox chkForaSemana;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.ComboBox cboMetodoPagamento;
        private System.Windows.Forms.Label lblMetodoPagamento;
        private System.Windows.Forms.TextBox txtMes;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.TextBox txtDias;
        private System.Windows.Forms.Label lblDia;
        private System.Windows.Forms.ComboBox cboPlanoPagamento;
        private System.Windows.Forms.Label lblPlanoPagamento;
        private System.Windows.Forms.ComboBox cboDiaPagamento;
        private System.Windows.Forms.Label lblDiaPagamento;
        private System.Windows.Forms.Label lblDataCorte;
        private System.Windows.Forms.TextBox txtMesAdicional;
        private System.Windows.Forms.Label lblMesAdicional;
        private System.Windows.Forms.MaskedTextBox txtDataCorte;
        private System.Windows.Forms.CheckBox chkCondicaoVendas;
    }
}