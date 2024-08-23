namespace ERP
{
    partial class frmGrupoRastreamentoCad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoRastreamentoCad));
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.btnAdiciona = new System.Windows.Forms.RibbonButton();
            this.btnAlterar = new System.Windows.Forms.RibbonButton();
            this.btnGrava = new System.Windows.Forms.RibbonButton();
            this.btnCancelar = new System.Windows.Forms.RibbonButton();
            this.btnExcluir = new System.Windows.Forms.RibbonButton();
            this.rbOpcoes = new System.Windows.Forms.RibbonTab();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.chkNumeroSerieEntrada = new System.Windows.Forms.CheckBox();
            this.chkNumeroSerieSaida = new System.Windows.Forms.CheckBox();
            this.chkNumeroSerieAtivo = new System.Windows.Forms.CheckBox();
            this.chkNumeroLoteEntrada = new System.Windows.Forms.CheckBox();
            this.chkNumeroLoteSaida = new System.Windows.Forms.CheckBox();
            this.chkNumeroLoteAtivo = new System.Windows.Forms.CheckBox();
            this.chkObrigatorio = new System.Windows.Forms.CheckBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.ribbon1.Size = new System.Drawing.Size(404, 125);
            this.ribbon1.TabIndex = 14;
            this.ribbon1.Tabs.Add(this.rbOpcoes);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // chkNumeroSerieEntrada
            // 
            this.chkNumeroSerieEntrada.AutoSize = true;
            this.chkNumeroSerieEntrada.Location = new System.Drawing.Point(272, 285);
            this.chkNumeroSerieEntrada.Name = "chkNumeroSerieEntrada";
            this.chkNumeroSerieEntrada.Size = new System.Drawing.Size(130, 17);
            this.chkNumeroSerieEntrada.TabIndex = 38;
            this.chkNumeroSerieEntrada.Text = "Número Série Entrada";
            this.chkNumeroSerieEntrada.UseVisualStyleBackColor = true;
            // 
            // chkNumeroSerieSaida
            // 
            this.chkNumeroSerieSaida.AutoSize = true;
            this.chkNumeroSerieSaida.Location = new System.Drawing.Point(143, 285);
            this.chkNumeroSerieSaida.Name = "chkNumeroSerieSaida";
            this.chkNumeroSerieSaida.Size = new System.Drawing.Size(122, 17);
            this.chkNumeroSerieSaida.TabIndex = 37;
            this.chkNumeroSerieSaida.Text = "Número Série Saída";
            this.chkNumeroSerieSaida.UseVisualStyleBackColor = true;
            // 
            // chkNumeroSerieAtivo
            // 
            this.chkNumeroSerieAtivo.AutoSize = true;
            this.chkNumeroSerieAtivo.Location = new System.Drawing.Point(15, 285);
            this.chkNumeroSerieAtivo.Name = "chkNumeroSerieAtivo";
            this.chkNumeroSerieAtivo.Size = new System.Drawing.Size(117, 17);
            this.chkNumeroSerieAtivo.TabIndex = 36;
            this.chkNumeroSerieAtivo.Text = "Número Série Ativo";
            this.chkNumeroSerieAtivo.UseVisualStyleBackColor = true;
            // 
            // chkNumeroLoteEntrada
            // 
            this.chkNumeroLoteEntrada.AutoSize = true;
            this.chkNumeroLoteEntrada.Location = new System.Drawing.Point(272, 262);
            this.chkNumeroLoteEntrada.Name = "chkNumeroLoteEntrada";
            this.chkNumeroLoteEntrada.Size = new System.Drawing.Size(127, 17);
            this.chkNumeroLoteEntrada.TabIndex = 35;
            this.chkNumeroLoteEntrada.Text = "Número Lote Entrada";
            this.chkNumeroLoteEntrada.UseVisualStyleBackColor = true;
            // 
            // chkNumeroLoteSaida
            // 
            this.chkNumeroLoteSaida.AutoSize = true;
            this.chkNumeroLoteSaida.Location = new System.Drawing.Point(143, 262);
            this.chkNumeroLoteSaida.Name = "chkNumeroLoteSaida";
            this.chkNumeroLoteSaida.Size = new System.Drawing.Size(119, 17);
            this.chkNumeroLoteSaida.TabIndex = 34;
            this.chkNumeroLoteSaida.Text = "Número Lote Saída";
            this.chkNumeroLoteSaida.UseVisualStyleBackColor = true;
            // 
            // chkNumeroLoteAtivo
            // 
            this.chkNumeroLoteAtivo.AutoSize = true;
            this.chkNumeroLoteAtivo.Location = new System.Drawing.Point(15, 262);
            this.chkNumeroLoteAtivo.Name = "chkNumeroLoteAtivo";
            this.chkNumeroLoteAtivo.Size = new System.Drawing.Size(114, 17);
            this.chkNumeroLoteAtivo.TabIndex = 33;
            this.chkNumeroLoteAtivo.Text = "Número Lote Ativo";
            this.chkNumeroLoteAtivo.UseVisualStyleBackColor = true;
            // 
            // chkObrigatorio
            // 
            this.chkObrigatorio.AutoSize = true;
            this.chkObrigatorio.Location = new System.Drawing.Point(15, 239);
            this.chkObrigatorio.Name = "chkObrigatorio";
            this.chkObrigatorio.Size = new System.Drawing.Size(77, 17);
            this.chkObrigatorio.TabIndex = 32;
            this.chkObrigatorio.Text = "Obrigatório";
            this.chkObrigatorio.UseVisualStyleBackColor = true;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(15, 204);
            this.txtDescricao.MaxLength = 255;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(380, 20);
            this.txtDescricao.TabIndex = 31;
            this.txtDescricao.Tag = "1";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(12, 187);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 30;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(15, 155);
            this.txtNome.MaxLength = 255;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(380, 20);
            this.txtNome.TabIndex = 29;
            this.txtNome.Tag = "1";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(12, 138);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 28;
            this.lblNome.Text = "Nome";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(339, 139);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(13, 13);
            this.lbCodigo.TabIndex = 27;
            this.lbCodigo.Text = "0";
            this.lbCodigo.Visible = false;
            // 
            // frmGrupoRastreamentoCad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(404, 311);
            this.Controls.Add(this.chkNumeroSerieEntrada);
            this.Controls.Add(this.chkNumeroSerieSaida);
            this.Controls.Add(this.chkNumeroSerieAtivo);
            this.Controls.Add(this.chkNumeroLoteEntrada);
            this.Controls.Add(this.chkNumeroLoteSaida);
            this.Controls.Add(this.chkNumeroLoteAtivo);
            this.Controls.Add(this.chkObrigatorio);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmGrupoRastreamentoCad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmGrupoRastreamentoCad";
            this.Text = "Cadastro Grupo Rastreamento";
            this.Load += new System.EventHandler(this.frmGrupoRastreamentoCad_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGrupoRastreamentoCad_KeyDown);
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
        private System.Windows.Forms.CheckBox chkNumeroSerieEntrada;
        private System.Windows.Forms.CheckBox chkNumeroSerieSaida;
        private System.Windows.Forms.CheckBox chkNumeroSerieAtivo;
        private System.Windows.Forms.CheckBox chkNumeroLoteEntrada;
        private System.Windows.Forms.CheckBox chkNumeroLoteSaida;
        private System.Windows.Forms.CheckBox chkNumeroLoteAtivo;
        private System.Windows.Forms.CheckBox chkObrigatorio;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lbCodigo;
    }
}