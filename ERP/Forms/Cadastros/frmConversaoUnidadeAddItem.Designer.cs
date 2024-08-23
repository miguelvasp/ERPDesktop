namespace ERP
{
    partial class frmConversaoUnidadeAddItem
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
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtFator = new System.Windows.Forms.TextBox();
            this.lblFator = new System.Windows.Forms.Label();
            this.txtNumerador = new System.Windows.Forms.TextBox();
            this.lblNumerador = new System.Windows.Forms.Label();
            this.txtDenominador = new System.Windows.Forms.TextBox();
            this.lblDenominador = new System.Windows.Forms.Label();
            this.lblUnidadeDe = new System.Windows.Forms.Label();
            this.cboUnidadeDe = new System.Windows.Forms.ComboBox();
            this.lblUnidadePara = new System.Windows.Forms.Label();
            this.cboUnidadePara = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(305, 208);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 14;
            this.btnExcluir.Text = "E&xcluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(224, 208);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(75, 23);
            this.btnIncluir.TabIndex = 13;
            this.btnIncluir.Text = "&Novo";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(143, 208);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 12;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtFator
            // 
            this.txtFator.Location = new System.Drawing.Point(28, 39);
            this.txtFator.MaxLength = 10;
            this.txtFator.Name = "txtFator";
            this.txtFator.Size = new System.Drawing.Size(170, 20);
            this.txtFator.TabIndex = 120;
            this.txtFator.Tag = "3";
            this.txtFator.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFator_KeyPress);
            // 
            // lblFator
            // 
            this.lblFator.AutoSize = true;
            this.lblFator.Location = new System.Drawing.Point(25, 19);
            this.lblFator.Name = "lblFator";
            this.lblFator.Size = new System.Drawing.Size(31, 13);
            this.lblFator.TabIndex = 1;
            this.lblFator.Text = "Fator";
            // 
            // txtNumerador
            // 
            this.txtNumerador.Location = new System.Drawing.Point(28, 93);
            this.txtNumerador.MaxLength = 10;
            this.txtNumerador.Name = "txtNumerador";
            this.txtNumerador.Size = new System.Drawing.Size(170, 20);
            this.txtNumerador.TabIndex = 5;
            this.txtNumerador.Tag = "3";
            this.txtNumerador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumerador_KeyPress);
            // 
            // lblNumerador
            // 
            this.lblNumerador.AutoSize = true;
            this.lblNumerador.Location = new System.Drawing.Point(25, 73);
            this.lblNumerador.Name = "lblNumerador";
            this.lblNumerador.Size = new System.Drawing.Size(59, 13);
            this.lblNumerador.TabIndex = 4;
            this.lblNumerador.Text = "Numerador";
            // 
            // txtDenominador
            // 
            this.txtDenominador.Location = new System.Drawing.Point(210, 93);
            this.txtDenominador.MaxLength = 10;
            this.txtDenominador.Name = "txtDenominador";
            this.txtDenominador.Size = new System.Drawing.Size(170, 20);
            this.txtDenominador.TabIndex = 7;
            this.txtDenominador.Tag = "3";
            this.txtDenominador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDenominador_KeyPress);
            // 
            // lblDenominador
            // 
            this.lblDenominador.AutoSize = true;
            this.lblDenominador.Location = new System.Drawing.Point(207, 73);
            this.lblDenominador.Name = "lblDenominador";
            this.lblDenominador.Size = new System.Drawing.Size(70, 13);
            this.lblDenominador.TabIndex = 6;
            this.lblDenominador.Text = "Denominador";
            // 
            // lblUnidadeDe
            // 
            this.lblUnidadeDe.AutoSize = true;
            this.lblUnidadeDe.Location = new System.Drawing.Point(25, 131);
            this.lblUnidadeDe.Name = "lblUnidadeDe";
            this.lblUnidadeDe.Size = new System.Drawing.Size(70, 13);
            this.lblUnidadeDe.TabIndex = 8;
            this.lblUnidadeDe.Text = "Unidade (De)";
            // 
            // cboUnidadeDe
            // 
            this.cboUnidadeDe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboUnidadeDe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUnidadeDe.FormattingEnabled = true;
            this.cboUnidadeDe.Location = new System.Drawing.Point(28, 150);
            this.cboUnidadeDe.Name = "cboUnidadeDe";
            this.cboUnidadeDe.Size = new System.Drawing.Size(170, 21);
            this.cboUnidadeDe.TabIndex = 9;
            this.cboUnidadeDe.Tag = "1";
            // 
            // lblUnidadePara
            // 
            this.lblUnidadePara.AutoSize = true;
            this.lblUnidadePara.Location = new System.Drawing.Point(207, 131);
            this.lblUnidadePara.Name = "lblUnidadePara";
            this.lblUnidadePara.Size = new System.Drawing.Size(78, 13);
            this.lblUnidadePara.TabIndex = 10;
            this.lblUnidadePara.Text = "Unidade (Para)";
            // 
            // cboUnidadePara
            // 
            this.cboUnidadePara.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboUnidadePara.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUnidadePara.FormattingEnabled = true;
            this.cboUnidadePara.Location = new System.Drawing.Point(210, 150);
            this.cboUnidadePara.Name = "cboUnidadePara";
            this.cboUnidadePara.Size = new System.Drawing.Size(170, 21);
            this.cboUnidadePara.TabIndex = 11;
            this.cboUnidadePara.Tag = "1";
            // 
            // frmConversaoUnidadeAddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(395, 249);
            this.Controls.Add(this.lblUnidadePara);
            this.Controls.Add(this.cboUnidadePara);
            this.Controls.Add(this.lblUnidadeDe);
            this.Controls.Add(this.cboUnidadeDe);
            this.Controls.Add(this.txtDenominador);
            this.Controls.Add(this.lblDenominador);
            this.Controls.Add(this.txtNumerador);
            this.Controls.Add(this.lblNumerador);
            this.Controls.Add(this.txtFator);
            this.Controls.Add(this.lblFator);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.btnSalvar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConversaoUnidadeAddItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmConversaoUnidadeAddItem";
            this.Text = "Conversão de Unidade";
            this.Load += new System.EventHandler(this.frmConversaoUnidadeAddItem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConversaoUnidadeAddItem_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtFator;
        private System.Windows.Forms.Label lblFator;
        private System.Windows.Forms.TextBox txtNumerador;
        private System.Windows.Forms.Label lblNumerador;
        private System.Windows.Forms.TextBox txtDenominador;
        private System.Windows.Forms.Label lblDenominador;
        private System.Windows.Forms.Label lblUnidadeDe;
        private System.Windows.Forms.ComboBox cboUnidadeDe;
        private System.Windows.Forms.Label lblUnidadePara;
        private System.Windows.Forms.ComboBox cboUnidadePara;
    }
}